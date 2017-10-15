using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace OrganizacaoArquivos
{
    public partial class App : Form
    {
        public const String CAMINHO_BASE = "C:/Users/Cassiano/Desktop/trab_oa/";
        public const String ARQ_SEQ = "sequencial";
        public const String ARQ_SEQ_IDX = "indexado";
        public const String ARQ_SEQ_IDX_INDICES = "indexado_indices";
        public const String ARQ_ACESSO_DIRETO = "acesso_direto";

        private OrganizacaoArquivo oa;
        private Int32 qtdReg;
        private String caminhoArq;
        private Control txtResultadoPtr;

        public App()
        {
            InitializeComponent();
        }

        public App(OrganizacaoArquivo oa, Int32 qtdReg, String caminhoArq, Control txtResultadoPtr)
        {
            this.oa = oa;
            this.qtdReg = qtdReg;
            this.caminhoArq = caminhoArq;
            this.txtResultadoPtr = txtResultadoPtr;
        }

        private void App_Load(object sender, EventArgs e)
        {

        }

        private void btnInserirSequencial_Click(object sender, EventArgs e)
        {
            OASequencial oaSequencial = new OASequencial(CAMINHO_BASE + ARQ_SEQ);
            var popup = new PopupInsercao(oaSequencial);
        
            popup.Show(this);
        }

        private void btnBuscarSequencial_Click(object sender, EventArgs e)
        {
            OASequencial oaSequencial = new OASequencial(CAMINHO_BASE + ARQ_SEQ);
            Colaborador colaborador = new Colaborador(Decimal.ToInt32(txtSeqNum.Value));
            buscar(oaSequencial, colaborador);
        }

        private void btnGerar1mSequencial_Click(object sender, EventArgs e)
        {
            caminhoArq = CAMINHO_BASE + "arquivo_1m_sequencial";

            File.Delete(caminhoArq);
            OASequencial oaSequencial = new OASequencial(caminhoArq);
            App app = new App(oaSequencial, 1000000, caminhoArq, txtResultado);

            txtResultado.Text = "Gerando arquivo sequencial com 1 milhão de registros, aguarde...";

            Thread thred = new Thread(app.gerarArquivo);
            thred.Start();
        }

        private void gerarArquivo()
        {
            Random aleatorio = new Random(5);

            for (int i = 0; i < qtdReg; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                oa.inserir(colaborador, "Numero");
            }

            this.SetText("Arquivo gerado com sucesso em: " + caminhoArq);

            oa.finalizar();
        }

        private void btnGerar1mSequencialIndexado_Click(object sender, EventArgs e)
        {
            caminhoArq = CAMINHO_BASE + "arquivo_1m_sequencial_indexado";
            String caminhoArqIndices = CAMINHO_BASE + "arquivo_1m_sequencial_indexado_indices";

            File.Delete(caminhoArq);
            File.Delete(caminhoArqIndices);

            OASequencialIndexado oaSequencialIndexado = new OASequencialIndexado(caminhoArq, caminhoArqIndices);
            App app = new App(oaSequencialIndexado, 1000000, caminhoArq, txtResultado);

            txtResultado.Text = "Gerando arquivo sequencial indexado com 1 milhão de registros, aguarde...";

            Thread thred = new Thread(app.gerarArquivo);
            thred.Start();
        }

        private void btnInserirSequencialIndexado_Click(object sender, EventArgs e)
        {
            OASequencialIndexado oaSequencialIndexado = new OASequencialIndexado(CAMINHO_BASE + ARQ_SEQ_IDX, CAMINHO_BASE + ARQ_SEQ_IDX_INDICES);
            var popup = new PopupInsercao(oaSequencialIndexado);

            popup.Show(this);
        }

        private void btnBuscarSequencialIndexado_Click(object sender, EventArgs e)
        {
            OASequencialIndexado oaSequencialIndexado = new OASequencialIndexado(CAMINHO_BASE + ARQ_SEQ_IDX, CAMINHO_BASE + ARQ_SEQ_IDX_INDICES);
            Colaborador colaborador = new Colaborador(Decimal.ToInt32(txtSeqIndexadoNum.Value));
            buscar(oaSequencialIndexado, colaborador);
        }

        private void btnGerar1mAcessoDireto_Click(object sender, EventArgs e)
        {
            caminhoArq = CAMINHO_BASE + "arquivo_1m_acesso_direto";

            File.Delete(caminhoArq);
            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(caminhoArq);
            App app = new App(oaAcessoDireto, 1000000, caminhoArq, txtResultado);

            txtResultado.Text = "Gerando arquivo acesso direto com 1 milhão de registros, aguarde...";

            Thread thred = new Thread(app.gerarArquivo);
            thred.Start();
        }

        private void btnInserirAcessoDireto_Click(object sender, EventArgs e)
        {
            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(CAMINHO_BASE + ARQ_ACESSO_DIRETO);
            var popup = new PopupInsercao(oaAcessoDireto);

            popup.Show(this);
        }

        private void btnBuscarAcessoDireto_Click(object sender, EventArgs e)
        {
            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(CAMINHO_BASE + ARQ_ACESSO_DIRETO);
            Colaborador colaborador = new Colaborador(Decimal.ToInt32(txtAcessoDiretoNum.Value));
            buscar(oaAcessoDireto, colaborador);
        }

        private void SetText(string text)
        {
            if (txtResultadoPtr.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                txtResultadoPtr.Invoke(d, new object[] { text });
            }
            else
            {
                txtResultadoPtr.Text = text;
            }
        }

        delegate void SetTextCallback(string text);

        private void buscar(OrganizacaoArquivo oa, Colaborador colaborador)
        {
            Colaborador colaboradorBusca = (Colaborador)oa.consultar(colaborador, "Numero");

            if (colaboradorBusca != null)
            {
                txtResultado.Text = colaboradorBusca.ToString();
            }
            else
            {
                txtResultado.Text = "Colaborador não encontrador!";
            }

            oa.finalizar();
        }
    }
}
