---
title: Otimizar cálculos de gráficos para apresentações em PHP
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/php-java/chart-calculations/
keywords:
- cálculos de gráficos
- elementos de gráfico
- posição do elemento
- posição real
- elemento filho
- elemento pai
- valores do gráfico
- valor real
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Entenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides for PHP via Java para PPT e PPTX, com exemplos de código práticos."
---
## **Visão geral**

Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e o tamanho reais dos elementos e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos pai do gráfico e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular valores reais dos elementos do gráfico**
Aspose.Slides for PHP via Java fornece uma API simples para obter essas propriedades. Métodos da classe [Axis](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/) fornecem informações sobre a posição real do elemento do eixo do gráfico ([getActualMaxValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/pt/php-java/aspose.slides/axis/getactualminorunitscale/)). É necessário chamar o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/validatechartlayout/) previamente para preencher as propriedades com os valores reais.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Calcular posição real dos elementos pai do gráfico**
Aspose.Slides for PHP via Java fornece uma API simples para obter essas propriedades. Métodos da classe `ActualLayout` fornecem informações sobre a posição real do elemento pai do gráfico (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). É necessário chamar o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/validatechartlayout/) previamente para preencher as propriedades com os valores reais.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ocultar elementos do gráfico**
Este tópico ajuda a entender como ocultar informações de um gráfico. Usando Aspose.Slides for PHP via Java, você pode ocultar **Título, Eixo vertical, Eixo horizontal** e **Linhas de grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Ocultando o título do gráfico
    $chart->setTitle(false);
    # /Ocultando eixo de valores
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Visibilidade do eixo de categorias
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Ocultando legenda
    $chart->setLegend(false);
    # Ocultando linhas de grade principais
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Definindo cor da linha da série
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Os livros de trabalho do Excel externos funcionam como fonte de dados e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um livro de trabalho externo: ao conectar ou atualizar a fonte externa, as fórmulas e valores são obtidos desse livro de trabalho, e o gráfico reflete as atualizações durante as operações de abertura/edição. A API permite que você [especifique o livro de trabalho externo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setexternalworkbook/) o caminho e gerencie os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar regressão eu mesmo?**

Sim. [Linhas de tendência](/slides/pt/php-java/trend-line/) (lineares, exponenciais e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto você não precisa implementar seus próprios cálculos.

**Se uma apresentação tem vários gráficos com links externos, posso controlar qual livro de trabalho cada gráfico usa para os valores calculados?**

Sim. Cada gráfico pode apontar para seu próprio [livro de trabalho externo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/setexternalworkbook/), ou você pode criar/substituir um livro de trabalho externo por gráfico independentemente dos demais.