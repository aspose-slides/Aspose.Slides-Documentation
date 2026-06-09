---
title: Personalizar Eixos de Gráficos em Apresentações Usando PHP
linktitle: Eixo do Gráfico
type: docs
url: /pt/php-java/chart-axis/
keywords:
- eixo do gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como usar Aspose.Slides for PHP via Java para personalizar eixos de gráficos em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos no Aspose.Slides. Mostra como obter os valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal em gráficos de linha, alterar o tipo do eixo de categoria, definir o formato de data para os valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obter os valores máximos no eixo vertical em gráficos**
Aspose.Slides for PHP via Java permite obter os valores mínimos e máximos em um eixo vertical. Siga estas etapas:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) class.
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Obtenha o valor máximo real no eixo.
1. Obtenha o valor mínimo real no eixo.
1. Obtenha a unidade maior real do eixo.
1. Obtenha a unidade menor real do eixo.
1. Obtenha a escala da unidade maior real do eixo.
1. Obtenha a escala da unidade menor real do eixo.

Este código de exemplo—uma implementação das etapas acima—mostra como obter os valores necessários :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Salva a apresentação
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Trocar os Dados entre Eixos**
Aspose.Slides permite trocar rapidamente os dados entre eixos—os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa. 

Este código PHP mostra como executar a troca de dados entre eixos em um gráfico:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Troca linhas e colunas
    $chart->getChartData()->switchRowColumn();
    # Salva a apresentação
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Desativar o Eixo Vertical para Gráficos de Linha**

Este código PHP mostra como ocultar o eixo vertical em um gráfico de linha:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Desativar o Eixo Horizontal para Gráficos de Linha**

Este código mostra como ocultar o eixo horizontal em um gráfico de linha:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar o Eixo de Categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código demonstra a operação:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Definir o Formato de Data para Valores do Eixo de Categoria**
Aspose.Slides for PHP via Java permite definir o formato de data para um valor do eixo de categoria. A operação é demonstrada neste código PHP:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Definir o Ângulo de Rotação para o Título do Eixo de um Gráfico**
Aspose.Slides for PHP via Java permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código PHP demonstra a operação:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**
Aspose.Slides for PHP via Java permite definir a posição do eixo em um eixo de categoria ou valor. Este código PHP mostra como executar a tarefa:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Habilitar a Exibição do Rótulo de Unidade no Eixo de Valor do Gráfico**
Aspose.Slides for PHP via Java permite configurar um gráfico para exibir um rótulo de unidade no seu eixo de valor. Este código PHP demonstra a operação:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Como defino o valor no qual um eixo cruza o outro (cruzamento de eixo)?**

Os eixos oferecem uma [crossing setting](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/setcrosstype/): você pode escolher cruzar em zero, no valor máximo da categoria/valor ou em um valor numérico específico. Isso é útil para mover o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posso posicionar os rótulos de marcações em relação ao eixo (ao lado, fora, dentro)?**

Defina a [label position](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/setmajortickmark/) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.