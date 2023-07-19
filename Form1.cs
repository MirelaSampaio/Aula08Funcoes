namespace Aula08Estoque
{
    public partial class Form1 : Form
    {
        // Variáveis globais
        List<string> produtoNome = new List<string>();
        List<int> produtoQuantidade = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }
        // Funções

        void adicionaProduto()
        {
            string nome = txtNome.Text;
            int quantidade = int.Parse(txtQuantidade.Text);

            produtoNome.Add(nome);
            produtoQuantidade.Add(quantidade);
        }

        void atualizaInterface ()
        {
            int quantidadeCadastrada = produtoQuantidade.Count();
            lblCadastrados.Text = quantidadeCadastrada.ToString();


        }

        void limpaCampos()
        {
            txtNome.Clear();
            txtQuantidade.Clear();

            // Ou você pode usar o
            // txtNome.Text = "";
            // txtQuantidade.Text = "";

            txtNome.Focus();

            // Esse comando serve para Focar em uma das textbox após você executar o comando.'
        }

        void verProduto(bool primeiro )
        {
            if ( listaEstaVazia() == true ) 
            {
                MessageBox.Show("Não há nada na lista ainda, tente adicionar algo!");
                return;
            }
            string nome;
            int quantidade;

            if ( primeiro == true)
            {
                nome = produtoNome[0];
                quantidade = produtoQuantidade[0];
            }
            else
            {
                nome = produtoNome[produtoNome.Count() - 1];
                quantidade = produtoQuantidade[produtoQuantidade.Count() - 1];
            }

            MessageBox.Show($"Nome: {nome}, Quantidade: {quantidade}");

        }

        void RemoveProduto()
        {
            if ( listaEstaVazia() == true )
            {
                MessageBox.Show("Não há nada para remover na lista.");
            }
            else
            {
                produtoNome.RemoveAt(0);
                produtoQuantidade.RemoveAt(0);
                atualizaInterface();
                MessageBox.Show("Produto removido com sucesso!");
            }
        }

        bool listaEstaVazia()
        {
            if (produtoNome.Count() > 0 )
            {
                return false;
            }
            else 
            {
                return true; 
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            adicionaProduto();
            atualizaInterface();
            limpaCampos();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos(); 
        }

        private void btnVerPrimeiroProduto_Click(object sender, EventArgs e)
        {
            verProduto(true);
        }

        private void btnVerUltimoProduto_Click(object sender, EventArgs e)
        {
            verProduto(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveProduto();
            
        }
    }
}