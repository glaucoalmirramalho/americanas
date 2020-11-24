Funcionalidade: Cesta de compras
Eu, como um cliente do site
Quero ter uma lista com os ítens de minha escolha
Para que eu possa realizar uma compra.

Contexto: Ítem do Painel 'Os Mais Vendidos de Hoje' na Cesta de Compras
	Dado que eu acesse um Produto
	Quando eu adiciono o Produto na Cesta
	
	Cenário: Nome do ítem adicionado é o mesmo que o selecionado.
		Então o nome do ítem adicionado na Cesta de Compras será o mesmo escolhido anteriormente

	Cenário: Excluir ítem do Cesta de Compras.
		Quando eu excluo o ítem adicionado anteriormente
		Então a Cesta de Compras estará vazia	
	