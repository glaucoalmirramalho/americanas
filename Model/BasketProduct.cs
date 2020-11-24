namespace Americanas.Model
{
    
    /// <summary>
    /// Ítem quando adicionado ao Cesta de Compras.
    /// </summary>
    public class BasketProduct : Product
    {
        private string qty;

        public string Qty { get => qty; set => qty = value; }
    }
}
