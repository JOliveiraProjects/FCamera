# FCamera Projeto Banco
 

###Summário###


# PERGUNTAS: #

1) EXPLIQUE COM SUAS PALAVRAS O QUE É DOMAIN DRIVEN DESIGN E SUA IMPORTÂNCIA NA ESTRATÉGIA DE DESENVOLVIMENTO DE SOFTWARE.

- R: A ideia inicial do DDD é voltar à uma modelagem OO mais pura, por assim dizer. Devemos esquecer de como os dados são persistidos e nos preocupar em como representar melhor as necessidades de negócio em classes e comportamentos

2) EXPLIQUE COM SUAS PALAVRAS O QUE É E COMO FUNCIONA UMA ARQUITETURA BASEADA EM MICROSERVICES. EXPLIQUE GANHOS COM ESTE MODELO E DESAFIOS EM SUA IMPLEMENTAÇÃO.

- R: São pequenas aplicações focada simplesmente no negócio em que ela foi projetada e assim se unem com outras partes de um todo.
Com uma arquitetura de microserviços podemos modelar uma arquitetura de acordo com cada negócio para isso usando do padrão de GATEWAY 
para redirecionar as saidas dos endpoints de cada microserviços vinculado ao GATEWAY.

3) EXPLIQUE QUAL A DIFERENÇA ENTRE COMUNICAÇÃO SINCRONA E ASSINCRONA E QUAL O MELHOR CENÁRIO PARA UTILIZAR UMA OU OUTRA.

-R: Uma comunicação sincrona as informações são enviadas mesmo que ainda não tenha sido processada ou terminada de processar.
Já a comunicação assincrona em uma requisição que aguarda a resposta de um servidor por exemplo HTTP ele fica em espera até que tenha recebido uma resposta do servidor que solicitou a requisição.


###Tecnologias usada###
 - .net core 2.2
 - postgresql
