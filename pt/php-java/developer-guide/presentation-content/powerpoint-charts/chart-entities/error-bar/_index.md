---
title: Personalizar Barras de Erro em Gráficos de Apresentação Usando PHP
linktitle: Barra de Erro
type: docs
url: /pt/php-java/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como adicionar e personalizar barras de erro em gráficos com Aspose.Slides para PHP via Java — otimize a visualização de dados em apresentações do PowerPoint."
---
## **Overview**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando o Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barras de erro X e Y e aplicar diferentes tipos de valor, como valores fixos, percentuais e personalizados.

Também demonstra como atribuir valores de barra de erro personalizados para pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados, e onde encontrar as classes e enums de referência da API relacionados.

## **Add Error Bars**
Aspose.Slides for PHP via Java fornece uma API simples para gerenciar valores de barras de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção de [**data points**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriescollection/) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato de barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato de barra de erro Y.
1. Definindo os valores e o formato das barras.
1. Salve a apresentação modificada em um arquivo PPTX.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Criando um gráfico de bolhas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Adicionando barras de erro e definindo seu formato
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Salvando a apresentação
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add Custom Error Bar Values**
Aspose.Slides for PHP via Java fornece uma API simples para gerenciar valores personalizados de barras de erro. O código de exemplo se aplica quando o método [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/errorbarsformat/#getValueType) retorna **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção de [**data points**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseriescollection/) da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série do gráfico e defina o formato de barra de erro X.
1. Acesse a primeira série do gráfico e defina o formato de barra de erro Y.
1. Acesse os pontos de dados individuais da série do gráfico e configure os valores da barra de erro para cada ponto de dados da série.
1. Definindo os valores e o formato das barras.
1. Salve a apresentação modificada em um arquivo PPTX.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Criando um gráfico de bolhas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Adicionando barras de erro personalizadas e definindo seu formato
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Acessando o ponto de dados da série do gráfico e definindo valores de barras de erro para
    # ponto individual
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Definindo barras de erro para os pontos da série do gráfico
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Salvando a apresentação
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão junto com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobreporem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e classes para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/errorbarsformat/) e as classes relacionadas [ErrorBarType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/errorbarvaluetype/).