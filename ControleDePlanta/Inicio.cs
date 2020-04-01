using Modbus_Poll_CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControleDePlanta
{
    public partial class Inicio : Form
    {
        #region Load Objects
        /* chama o objeto modbus da biblioteca */
        modbus mb = new modbus();
        /* chama o objeto serialport do IO.Ports */
        SerialPort sp = new SerialPort();
        /* chama o objeto timer do sistema */
        System.Timers.Timer timer = new System.Timers.Timer();
        /* defini variaveis tipo texto, booleano e inteiro */
        string dataType;
        bool isPolling = false;
        int pollCount;
        
        /* iniciando componentes ao abrir o programa */
        public Inicio()
        {
            InitializeComponent();
        }

        /* carrega a lista do dropdown das portas ao carregar o programa */
        private void Inicio_Load(object sender, EventArgs e)
        {
            LoadListboxes();
        }

        /* preenche o dropdown com as portas USBs conectadas */
        private void LoadListboxes()
        {
            string[] ports = SerialPort.GetPortNames();
            lstPorts.Items.Clear();
            foreach (string port in ports)
            {
                lstPorts.Items.Add(port);
            }
            /* se não carregou portas no dropdown desabilita o botão e o dropdown atualiza status e grava log */
            if (lstPorts.Items.Count == 0)
            {
                lstPorts.Enabled = false;
                lstPorts.Text = "Não Encontrado";
                lblStatus.Text = "Placa não Encontrada";
                Grava_Log(lblStatus.Text);
                btnStart.Enabled = false;
            }
            /* se carregou uma porta no dropdown desabilita o dropdown atualiza status e grava log */
            else if (lstPorts.Items.Count == 1)
            {
                lstPorts.Enabled = false;
                lstPorts.SelectedIndex = 0;
                lblStatus.Text = "Pronto";
                Grava_Log(lblStatus.Text);
                btnStart.Enabled = true;
            }
            /* caso contrario libera dropdown para selecionar a porta atualiza status e grava log */
            else
            {
                lstPorts.Enabled = true;
                lstPorts.SelectedIndex = 0;
                lblStatus.Text = "Pronto";
                Grava_Log(lblStatus.Text);
                btnStart.Enabled = true;
            }

        }

        /* ao clicar no botão recarrega o LoadListboxes portas USBs */
        private void btnLoadPortas_Click(object sender, EventArgs e)
        {
            LoadListboxes();
        }
        #endregion

        #region GUI Delegate Declarations
        /* declarando metodos de delegar publicos */
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        #region Start and Stop Procedures
        /* inicia pesquisa */
        private void StartPoll()
        {
            /* abre a porta COM selecionada com os parametros baudrate 115200 e 8 bits */
            if (mb.Open(lstPorts.SelectedItem.ToString(), Convert.ToInt32("115200"), 8, Parity.None, StopBits.One))
            {
                /* desabilita botão para evitar mais de um acionamento */
                btnStart.Enabled = false;
                dataType = "Decimal";

                /* determina variavel como verdadeiro */
                isPolling = true;

                /* inicia o time com intervalo de 1000 milesegundos */
                timer.AutoReset = true;
                timer.Interval = 1000;
                timer.Elapsed += timer_Elapsed;
                timer.Enabled = true;
                timer.Start();
            }
            /* atualiza o status e chama o gravalog */
            lblStatus.Text = mb.modbusStatus;
            Grava_Log(lblStatus.Text);
        }

        /* para de pesquisar */
        private void StopPoll()
        {
            isPolling = false;
            timer.Stop();
            mb.Close();
            btnStart.Enabled = true;
            lblStatus.Text = mb.modbusStatus;
            Grava_Log(lblStatus.Text);
        }

        /* ao clicar o botão inicia a pesquisa */
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPoll();
        }

        /* ao clicar o botão para a pesquisa */
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPoll();
            btnLedLiga.Enabled = false;
            btnLedDesliga.Enabled = false;
        }

        /* determina comando para ligar o led */
        private void btnLedLiga_Click(object sender, EventArgs e)
        {
            /* determina variaveis do comando */
            byte address = Convert.ToByte("5");
            ushort start = Convert.ToUInt16("7");
            short[] value = new short[1];
            value[0] = Convert.ToInt16("1");
            /* tenta executar o envio da função 6 */
            try
            {
                while (!mb.SendFc6(address, start, value)) ;
            }
            /* pega exceção caso tenha dado algum problema */
            catch (Exception err)
            {
                DoGUIStatus("Error ao enviar comando: " + err.Message);
            }
            /* pega o resultado gerado e envia para gravação do log */
            DoGUIStatus(mb.modbusStatus);
            DoGUIConexao(mb.modbusComunicacao);
        }

        /* determina comando para desligar o led */
        private void btnLedDesliga_Click(object sender, EventArgs e)
        {
            /* determina variaveis do comando */
            byte address = Convert.ToByte("5");
            ushort start = Convert.ToUInt16("7");
            short[] value = new short[1];
            value[0] = Convert.ToInt16("0");
            /* tenta executar o envio da função 6 */
            try
            {
                while (!mb.SendFc6(address, start, value)) ;
            }
            /* pega exceção caso tenha dado algum problema */
            catch (Exception err)
            {
                DoGUIStatus("Error ao enviar comando: " + err.Message);
            }
            /* pega o resultado gerado e envia para gravação do log */
            DoGUIStatus(mb.modbusStatus);
            DoGUIConexao(mb.modbusComunicacao);
        }
        #endregion

        #region Timer Events
        /* metodo que é executado pelo timer */
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PollFunction();
            Reload_Values();
            DoGUIChart(lblTemperatura.Text);
        }

        /* metodo que atualiza o gráfico de temperatura */
        private void Atualiza_Chart(int ValTemp)
        {
            if (chart1.Series[0].Points.Count > 10)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            chart1.Series[0].Points.AddXY(0, ValTemp);
            chart1.Update();
        }

        /* metodo que grava o log */
        private void Grava_Log(string valor)
        {
            lstLogValues.Items.Add(valor);
        }

        /* metodo de pesquisa de comunicação */
        private void PollFunction()
        {
            /* Atualiza número de leituras */
            DoGUIClear();
            pollCount++;
            DoGUIStatus("Número de leituras: " + pollCount.ToString());

            /* Cria variaveis para leitura */
            short[] values = new short[Convert.ToInt32("3")];
            ushort pollStart;
            ushort pollLength;

            /* determina inicio e tamanho */
            pollStart = 0;
            pollLength = 3;

            /* tenta realizar a leitura com os parametros */
            try
            {
                while (!mb.SendFc3(Convert.ToByte("5"), pollStart, pollLength, ref values)) ;
            }
            /* pega exceção caso de algum problema */
            catch (Exception err)
            {
                DoGUIStatus("Erro na leitura do modbus: " + err.Message);
            }

            string itemString;

            switch (dataType)
            {
                case "Decimal":
                    for (int i = 0; i < pollLength; i++)
                    {
                        itemString = "[" + Convert.ToString(pollStart + i + 40001) + "] , MB[" +
                            Convert.ToString(pollStart + i) + "] = " + values[i].ToString();
                        DoGUIUpdate(itemString);
                    }
                    break;
            }
            /* manda resultado para gravar log */
            DoGUIConexao(mb.modbusComunicacao);
        }

        /* recarrega valores */
        private void Reload_Values()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(Reload_Values));
                return;
            }
            /* para a pesquisa atualiza status e grava log se a lista de registro não está sendo preenchida */
            if (lstRegisterValues.Items.Count == 0)
            {
                StopPoll();
                lblStatus.Text = "Erro, verifique se a porta selecionada é a da placa";
                Grava_Log(lblStatus.Text);
            }
            /* pega a temperatura da lista de registro caso tenha algum valor */
            if (lstRegisterValues.Items.Count >= 1)
            {
                lblTemperatura.Text = lstRegisterValues.Items[0].ToString().Substring(18);
            }
            /* caso contrario temperatura = 0 */
            else
            {
                lblTemperatura.Text = "0";
            }
            /* determina se o botão está ligado ou desligado a partir do valor da lista de registro */
            if (lstRegisterValues.Items.Count >= 2)
            {
                if (lstRegisterValues.Items[1].ToString().Substring(18) == "1")
                {
                    lblBotao.Text = "Ligado";
                }
                else
                {
                    lblBotao.Text = "Desligado";
                }
            }
            /* caso contrario botao = desligado */
            else
            {
                lblBotao.Text = "Desligado";
            }
            /* determina se o led está ou não ligado a partir do valor da lista de registros */
            if (lstRegisterValues.Items.Count >= 3)
            {
                if (lstRegisterValues.Items[2].ToString().Substring(18) == "1")
                {
                    lblLed.Text = "Ligado";
                    btnLedDesliga.Enabled = true;
                    btnLedLiga.Enabled = false;
                }
                else
                {
                    lblLed.Text = "Desligado";
                    btnLedDesliga.Enabled = false;
                    btnLedLiga.Enabled = true;
                }
            }
            /* caso contrario desligado */
            else
            {
                lblLed.Text = "Desligado";
                btnLedDesliga.Enabled = false;
                btnLedLiga.Enabled = false;
            }
        }
        #endregion

        #region Delegate Functions
        public void DoGUIClear()
        {
            /* função delegada para limpar os itens da lista de registros */
            if (this.InvokeRequired)
            {
                GUIClear delegateMethod = new GUIClear(this.DoGUIClear);
                this.Invoke(delegateMethod);
            }
            else
                this.lstRegisterValues.Items.Clear();
        }
        public void DoGUIStatus(string paramString)
        {
            /* função delegada para gravar log e atualizar status com o que recebeu da placa no paramstring */
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIStatus);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
            {
                this.lblStatus.Text = paramString;
                Grava_Log(this.lblStatus.Text);
            }
        }
        public void DoGUIConexao(string paramString)
        {
            /* função delegada para gravar log com o que recebeu da placa no paramstring */
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIConexao);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
            {
                Grava_Log(paramString);
            }
        }
        public void DoGUIChart(string paramString)
        {
            /* função delegada para atualizar o gráfico com o valor da placa */
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIChart);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
            {
                Atualiza_Chart(Convert.ToInt16(paramString));
            }
        }
        public void DoGUIUpdate(string paramString)
        {
            /* função delegada para incluir os itens da lista de registros */
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
                this.lstRegisterValues.Items.Add(paramString);
        }
        #endregion

    }
}
