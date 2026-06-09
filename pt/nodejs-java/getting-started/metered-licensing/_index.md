---
title: Licenciamento Medido
type: docs
weight: 100
url: /pt/nodejs-java/metered-licensing/
keywords:
- licença
- licença medida
- chaves de licença
- chave pública
- chave privada
- quantidade de consumo
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba como o Aspose.Slides para Node.js via Java com licenciamento medido permite processar arquivos PowerPoint e OpenDocument de forma flexível, pagando somente pelo que você usa."
---
## **Introdução**

Licenciamento medido é um mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento medido.

## **Aplicar chaves medidas**

Ao comprar uma licença medida, você recebe chaves (e não um arquivo de licença). Essa chave medida pode ser aplicada usando a classe [Metered](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/) que a Aspose fornece para operações de medição. Para mais detalhes, veja [FAQ de Licenciamento Medido](https://purchase.aspose.com/faqs/licensing/metered).

1. Crie uma instância da classe [Metered](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/).

1. Passe suas chaves pública e privada para o método [setMeteredKey](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Execute algum processamento (realize tarefas).

1. Chame o método [getConsumptionQuantity](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) da classe `Metered`.

Você deve ver a quantidade de solicitações da API consumidas até o momento.

Este código de exemplo mostra como usar o licenciamento medido:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cria uma instância da classe Metered
var metered = new aspose.slides.Metered();

// Passa as chaves pública e privada para o objeto Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Obtém o valor da quantidade consumida antes das chamadas de API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Faça algo com a API Aspose.Slides aqui
// ...

// Obtém o valor da quantidade consumida depois das chamadas de API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

Para usar o licenciamento medido, é necessário uma conexão de internet estável, pois o mecanismo de licenciamento utiliza a internet para interagir constantemente com nossos serviços e realizar os cálculos.

{{% /alert %}} 

## **FAQ**

**Posso usar uma licença medida junto com uma licença regular (perpétua ou temporária) na mesma aplicação?**

Sim. O licenciamento medido é um mecanismo adicional que pode ser usado juntamente com os [métodos de licenciamento](/slides/pt/nodejs-java/licensing/). Você escolhe qual mecanismo aplicar quando a aplicação inicia.

**O que exatamente conta como consumo em uma licença medida: operações ou arquivos?**

É contado o uso da API, ou seja, o número de solicitações ou operações. Você pode obter o consumo atual via [métodos de acompanhamento de consumo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/).

**O licenciamento medido é adequado para microsserviços e ambientes serverless onde as instâncias reiniciam com frequência?**

Sim. Como a contabilidade é feita no nível de chamadas de API, cenários com reinicializações frequentes são compatíveis, desde que haja acesso de rede estável para os cálculos de medição.

**A funcionalidade da biblioteca difere ao usar uma licença medida em comparação com uma licença perpétua?**

Não. Isso afeta apenas o mecanismo de licenciamento e cobrança; as capacidades do produto permanecem as mesmas.

**Como o licenciamento medido se relaciona com a versão de avaliação e a licença temporária?**

A versão de avaliação tem limitações e marcas d’água, a [licença temporária](https://purchase.aspose.com/temporary-license/) remove as limitações por 30 dias, e o licenciamento medido remove as limitações e cobra com base no uso real.

**Posso controlar o orçamento reagindo automaticamente quando um limite de consumo é ultrapassado?**

Sim. Uma prática comum é ler periodicamente o consumo atual via [métodos de acompanhamento](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/metered/) e implementar seus próprios limites ou alertas no nível da aplicação ou de monitoramento.