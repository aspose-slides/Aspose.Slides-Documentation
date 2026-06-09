---
title: Licenciamento por Medição
type: docs
weight: 100
url: /pt/java/metered-licensing/
keywords:
- licença
- licença por medição
- chaves de licença
- chave pública
- chave privada
- quantidade de consumo
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra como o licenciamento por medição do Aspose.Slides para Java permite processar arquivos PowerPoint e OpenDocument de forma flexível, pagando apenas pelo que você usa."
---
## **Introdução**

Licenciamento por medição é um mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento por medição.

## **Aplicar chaves de medição**

{{% alert color="primary" %}} 

O licenciamento por medição é um novo mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento por medição.

Ao adquirir uma licença por medição, você recebe chaves (e não um arquivo de licença). Esta chave de medição pode ser aplicada usando a classe [Metered](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/) fornecida pela Aspose para operações de medição. Para mais detalhes, consulte [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crie uma instância da classe [Metered](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/).

1. Passe suas chaves pública e privada para o método [setMeteredKey](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Execute algum processamento (realize tarefas).

1. Chame o método [getConsumptionQuantity](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/#getConsumptionQuantity--) da classe `Metered`.

Você deverá ver a quantidade de solicitações de API que consumiu até agora.

Este código de exemplo mostra como usar o licenciamento por medição:

```java
// Cria uma instância da classe Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passa as chaves pública e privada para o objeto Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Obtém o valor da quantidade consumida antes das chamadas da API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Faça algo com a API Aspose.Slides aqui
    // ...

    // Obtém o valor da quantidade consumida após as chamadas da API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Para usar o licenciamento por medição, você precisa de uma conexão de internet estável, pois o mecanismo de licenciamento usa a internet para interagir constantemente com nossos serviços e realizar cálculos.

{{% /alert %}} 

## **Perguntas Frequentes**

**Posso usar uma licença por medição juntamente com uma licença regular (perpétua ou temporária) na mesma aplicação?**

Sim. O licenciamento por medição é um mecanismo adicional que pode ser usado juntamente com os [métodos de licenciamento](/slides/pt/java/licensing/) existentes. Você escolhe qual mecanismo aplicar quando a aplicação é iniciada.

**O que exatamente conta como consumo em uma licença por medição: operações ou arquivos?**

O uso da API é contabilizado, isto é, o número de solicitações ou operações. Você pode obter o consumo atual por meio dos [métodos de rastreamento de consumo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/).

**O licenciamento por medição é adequado para microsserviços e ambientes serverless onde as instâncias reiniciam frequentemente?**

Sim. Como a contabilização é feita no nível de chamadas de API, cenários com reinicializações frequentes (cold starts) são compatíveis, desde que haja acesso de rede estável para os cálculos de medição.

**A funcionalidade da biblioteca difere ao usar uma licença por medição em comparação com uma licença perpétua?**

Não. Isso se refere apenas ao mecanismo de licenciamento e cobrança; as capacidades do produto permanecem as mesmas.

**Como o licenciamento por medição se relaciona com a versão de avaliação e a licença temporária?**

A versão de avaliação tem limitações e marcas d’água, a [licença temporária](https://purchase.aspose.com/temporary-license/) remove as limitações por 30 dias, e o licenciamento por medição remove as limitações e cobra com base no uso real.

**Posso controlar o orçamento reagindo automaticamente quando um limite de consumo é ultrapassado?**

Sim. Uma prática comum é ler periodicamente o consumo atual por meio dos [métodos de rastreamento](https://reference.aspose.com/slides/pt/java/com.aspose.slides/metered/) e implementar seus próprios limites ou alertas no nível da aplicação ou de monitoramento.