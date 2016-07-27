Funcionalidade: Cálculo de IOF (Imposto sobre Operações Financeiras)
	Para conhecer como calcula o valor de IOF de um determinado titulo
	Como através de operação matemática
	Eu quero informar a 
		Data de Proposta, 
		Data de Vencimento, 
		taxa de IOF, 
		valor de Compra do titulo e o percentual de IOF aplicado e com isso saber o valor de IOF calculado

	NARRATIVA
	O calculo deverá ser dividido em três partes	
	
	PRIMEIRA PARTE - Utilizaremos Data da Proposta, Vencimento, Taxa e Valor do titulo
		1 - Passo: Devemos subtrair a data da Proposta menos a data de Vencimento, onde encontraremos o prazo em dias.
		2 - Passo: Entao deveremos dividir a Taxa de IOF por 365 dias e chegaremos a Taxa do dia, este resultado deverá ser arrendondado em 4 casas decimais.
		3 - Passo: Multiplicamos Taxa do Dia encontrada x o Prazo em dias, dai que teremos a Taxa no Periodo.
		4 - Passo: Multiplicamos a Taxa no Periodo pelo valor de Compra do Título e dividi-se por 100.
	Então teremos o primeiro valor do IOF, este resultado deverá ser arrendondado em 2 casas decimais e resultará no valor de R$ 0.42	
	
	SEGUNDA PARTE - Utilizaremos o percentual de IOF informado e o primeiro Valor Calculado
		Multiplicar o valor de Compra do Título pelo percentual de IOF
	Então teremos a segunda parte do Calculo deverá resultar no valor de R$ 1.342084
	
	TERCEIRA PARTE - Somar valores encontrados (Valod IOF)
		Calculado as partes acima deveremos soma-las (primeira + segunda) onde teremos o valor R$ 1.762084

	FORA DE ESCOPO	
	Aplicar boas praticas (SOLID,TDD e outros)
	Exibir o valor calculado titulo a titulo sempre
	Dado uma operação com mais de um titulo exibir a soma de todos os valores de IOF calculado
	Validação de entada 
		- taxa igual a zero ou negativa
		- data de operação não pode ser menor que a data atual (data corrente)
		- valor de compra do titulo não pode ser negativo ou igual a zero

Cenário: Calcular IOF do titulo
	Dado que estou em uma tela de operação de titulos
	E a data da Proposta 31-10-2012
	E a data de Vencimento 29-11-2012
	E a Taxa de IOF de 1,50%
	E o percentual de IOF informado é de 0,38%
	E o valor de Compra do Titulo de R$ 353,18
	Quando for solicitado o valor do IOF do titulo
	Então teremos o valor de IOF do titulo de R$ R$ 1,76