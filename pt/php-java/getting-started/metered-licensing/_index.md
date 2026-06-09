---
title: Licenciamento por Consumo
type: docs
weight: 100
url: /pt/php-java/metered-licensing/
keywords:
- licença
- licença por consumo
- chaves de licença
- chave pública
- chave privada
- quantidade de consumo
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Saiba como o Aspose.Slides para PHP via Java com licenciamento por consumo permite processar arquivos PowerPoint e OpenDocument de forma flexível, pagando apenas pelo que você usa."
---
## **Introdução**

Licenciamento por consumo é um mecanismo de licenciamento que pode ser usado juntamente com métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento por consumo.

## **Aplicar Chaves Metered**

Quando você compra uma licença por consumo, recebe chaves (e não um arquivo de licença). Essa chave de consumo pode ser aplicada usando a classe [Metered](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/) que a Aspose fornece para operações de medição. Para mais detalhes, veja [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Crie uma instância da classe [Metered](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/).

1. Passe suas chaves públicas e privadas para o método [setMeteredKey](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Execute algum processamento (realize tarefas).

1. Chame o método [getConsumptionQuantity](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/#getConsumptionQuantity--) da classe `Metered`.

Você deverá ver a quantidade de requisições da API que consumiu até o momento.

Este código de exemplo mostra como usar o licenciamento por consumo:

```php
// Cria uma instância da classe Metered
$metered = new Metered();

try {
    // Passa as chaves pública e privada para o objeto Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Obtém o valor da quantidade consumida antes das chamadas de API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Faz algo com a API Aspose.Slides aqui
    // ...

    // Obtém o valor da quantidade consumida após as chamadas de API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Para usar o licenciamento por consumo, você precisa de uma conexão de internet estável, pois o mecanismo de licenciamento usa a internet para interagir constantemente com nossos serviços e realizar cálculos.
{{% /alert %}} 

## **Perguntas Frequentes**

**Posso usar uma licença por consumo juntamente com uma licença regular (perpétua ou temporária) na mesma aplicação?**

Sim. O licenciamento por consumo é um mecanismo adicional que pode ser usado juntamente com os [métodos de licenciamento](/slides/pt/php-java/licensing/) existentes. Você escolhe qual mecanismo aplicar quando a aplicação inicia.

**O que exatamente conta como consumo sob uma licença por consumo: operações ou arquivos?**

É contabilizado o uso da API, ou seja, o número de solicitações ou operações. Você pode obter o consumo atual através dos [métodos de rastreamento de consumo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/).

**O licenciamento por consumo é adequado para microsserviços e ambientes serverless onde as instâncias reiniciam com frequência?**

Sim. Como a contagem é feita no nível de chamadas à API, cenários com reinicializações frequentes (cold starts) são compatíveis, desde que haja acesso de rede estável para os cálculos de consumo.

**A funcionalidade da biblioteca difere ao usar uma licença por consumo em comparação com uma licença perpétua?**

Não. Isto se refere apenas ao mecanismo de licenciamento e faturamento; as capacidades do produto permanecem as mesmas.

**Como o licenciamento por consumo se relaciona com a versão de avaliação e a licença temporária?**

A versão de avaliação possui limitações e marca d'água, a [licença temporária](https://purchase.aspose.com/temporary-license/) remove as limitações por 30 dias, e o licenciamento por consumo remove as limitações e cobra com base no uso real.

**Posso controlar o orçamento reagindo automaticamente quando um limite de consumo é excedido?**

Sim. Uma prática comum é ler periodicamente o consumo atual através dos [métodos de rastreamento](https://reference.aspose.com/slides/pt/php-java/aspose.slides/metered/) e implementar seus próprios limites ou alertas no nível da aplicação ou de monitoramento.