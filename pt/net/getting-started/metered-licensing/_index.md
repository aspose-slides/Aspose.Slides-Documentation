---
title: Licenciamento Medido
type: docs
weight: 90
url: /pt/net/metered-licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Saiba como o licenciamento medido do Aspose.Slides para .NET permite processar arquivos PowerPoint e OpenDocument de forma flexível, pagando apenas pelo que você usa."
---
## **Introdução**

Licenciamento medido é um mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento medido.

## **Aplicar chaves medidas**

Quando você compra uma licença medida, recebe chaves (e não um arquivo de licença). Essa chave medida pode ser aplicada usando a classe [Metered](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/) que a Aspose fornece para operações de medição. Para mais detalhes, veja o [FAQ de Licenciamento Medido](https://purchase.aspose.com/faqs/licensing/metered).

1. Crie uma instância da classe [Metered](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/).
1. Passe suas chaves públicas e privadas para o método [SetMeteredKey](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/setmeteredkey/).
1. Execute algum processamento (realize tarefas).
1. Chame o método [GetConsumptionQuantity](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/getconsumptionquantity/) da classe `Metered`.

Você deverá ver a quantidade de solicitações de API que consumiu até o momento.

Este código de exemplo mostra como usar o licenciamento medido:

```cs
// Cria uma instância da classe Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passa as chaves pública e privada para o objeto Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Obtém a quantidade de dados medidos antes da chamada da API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Faça algo com a API Aspose.Slides aqui
// ...

// Obtém a quantidade de dados medidos após a chamada da API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Para usar o licenciamento medido, você precisa de uma conexão de internet estável porque o mecanismo de licenciamento usa a internet para interagir constantemente com nossos serviços e realizar cálculos.

{{% /alert %}} 

## **FAQ**

**Posso usar uma licença medida junto com uma licença regular (perpétua ou temporária) na mesma aplicação?**

Sim. O licenciamento medido é um mecanismo adicional que pode ser usado juntamente com os [métodos de licenciamento](/slides/pt/net/licensing/). Você escolhe qual mecanismo aplicar quando a aplicação inicia.

**O que exatamente conta como consumo em uma licença medida: operações ou arquivos?**

O uso da API é contabilizado, ou seja, o número de solicitações ou operações. Você pode obter o consumo atual através dos [métodos de rastreamento de consumo](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/).

**O licenciamento medido é adequado para microsserviços e ambientes serverless onde as instâncias reiniciam frequentemente?**

Sim. Como a contagem é feita ao nível de chamadas de API, cenários com reinicializações frequentes são compatíveis, desde que haja acesso de rede estável para os cálculos do licenciamento medido.

**A funcionalidade da biblioteca difere ao usar uma licença medida em comparação com uma licença perpétua?**

Não. Isso se refere apenas ao mecanismo de licenciamento e faturamento; as capacidades do produto são as mesmas.

**Como o licenciamento medido se relaciona com a versão de avaliação e a licença temporária?**

A versão de avaliação tem limitações e marcas d'água, a [licença temporária](https://purchase.aspose.com/temporary-license/) remove as limitações por 30 dias, e o licenciamento medido remove as limitações e cobra com base no uso real.

**Posso controlar o orçamento reagindo automaticamente quando um limite de consumo for excedido?**

Sim. Uma prática comum é ler periodicamente o consumo atual via [métodos de rastreamento](https://reference.aspose.com/slides/pt/net/aspose.slides/metered/) e implementar seus próprios limites ou alertas no nível da aplicação ou de monitoramento.