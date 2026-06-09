---
title: Otimizar cálculos de gráficos para apresentações em JavaScript
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/nodejs-java/chart-calculations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Compreenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides for Node.js para PPT e PPTX, com exemplos práticos de código JavaScript."
---
## **Visão geral**

O Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e o tamanho reais dos elementos e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos pai do gráfico e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e a controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular Valores Reais dos Elementos do Gráfico**

O Aspose.Slides for Node.js via Java fornece uma API simples para obter essas propriedades. As propriedades da classe [Axis](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis) fornecem informações sobre a posição real do elemento de eixo do gráfico ([Axis.getActualMaxValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). É necessário chamar o método [Chart.validateChartLayout()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#validateChartLayout--) anteriormente para preencher as propriedades com os valores reais.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Calcular a Posição Real dos Elementos Pai do Gráfico**

O Aspose.Slides for Node.js via Java fornece uma API simples para obter essas propriedades. As propriedades da classe `ActualLayout` fornecem informações sobre a posição real do elemento pai do gráfico `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. É necessário chamar o método [Chart.validateChartLayout()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#validateChartLayout--) anteriormente para preencher as propriedades com os valores reais.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ocultar Informações do Gráfico**

Este tópico ajuda a entender como ocultar informações de um gráfico. Usando o Aspose.Slides for Node.js via Java, você pode ocultar **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Ocultando o título do gráfico
    chart.setTitle(false);
    // /Ocultando eixo de Valores
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Visibilidade do eixo de categoria
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Ocultando a legenda
    chart.setLegend(false);
    // Ocultando linhas de grade principais
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Definindo cor da linha da série
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Os livros de trabalho do Excel externos funcionam como fonte de dados e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um livro de trabalho externo: ao conectar ou atualizar a fonte externa, as fórmulas e valores são obtidos desse livro, e o gráfico reflete as atualizações durante as operações de abertura/edição. A API permite que você [specify the external workbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) caminho e gerencie os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. As [Trendlines](/slides/pt/nodejs-java/trend-line/) (lineares, exponenciais e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto você não precisa implementar seus próprios cálculos.

**Se uma apresentação tem vários gráficos com links externos, posso controlar qual livro de trabalho cada gráfico usa para os valores calculados?**

Sim. Cada gráfico pode apontar para seu próprio [external workbook](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), ou você pode criar/substituir um livro de trabalho externo por gráfico independentemente dos demais.