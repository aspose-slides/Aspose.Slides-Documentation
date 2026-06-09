---
title: Otimizar Cálculos de Gráficos para Apresentações no Android
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/androidjava/chart-calculations/
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
- Android
- Java
- Aspose.Slides
description: "Compreenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides para Android para PPT e PPTX, com exemplos práticos de código Java."
---
## **Visão geral**

Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e tamanho reais dos elementos que implementam `IActualLayout` e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos pai do gráfico e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e a controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint programaticamente.

## **Calcular valores reais dos elementos do gráfico**
Aspose.Slides for Android via Java fornece uma API simples para obter essas propriedades. As propriedades da interface [IAxis](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis) fornecem informações sobre a posição real do elemento de eixo do gráfico ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). É necessário chamar o método [IChart.validateChartLayout()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChart#validateChartLayout--) previamente para preencher as propriedades com valores reais.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Calcular posição real dos elementos pai do gráfico**
Aspose.Slides for Android via Java fornece uma API simples para obter essas propriedades. As propriedades da interface [IActualLayout](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IActualLayout) fornecem informações sobre a posição real do elemento pai do gráfico ([IActualLayout.getActualX](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). É necessário chamar o método [IChart.validateChartLayout()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChart#validateChartLayout--) previamente para preencher as propriedades com valores reais.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ocultar elementos do gráfico**
Este tópico ajuda a entender como ocultar informações do gráfico. Usando Aspose.Slides for Android via Java, você pode ocultar **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ocultando título do gráfico
    chart.setTitle(false);

    ///Ocultando eixo de valores
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Visibilidade do eixo de categoria
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Ocultando legenda
    chart.setLegend(false);

    //Ocultando linhas de grade principais
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Os pastas de trabalho do Excel externos funcionam como fonte de dados e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um pasta de trabalho externo: ao conectar ou atualizar a fonte externa, fórmulas e valores são obtidos dessa pasta de trabalho, e o gráfico reflete as atualizações durante as operações de abertura/edição. A API permite que você [especifique o caminho da pasta de trabalho externa](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-).

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. [Linhas de tendência](/slides/pt/androidjava/trend-line/) (linear, exponencial e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados a partir dos dados da série automaticamente, portanto não é necessário implementar seus próprios cálculos.

**Se uma apresentação tem vários gráficos com links externos, posso controlar qual pasta de trabalho cada gráfico usa para valores calculados?**

Sim. Cada gráfico pode apontar para sua própria [pasta de trabalho externa](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), ou você pode criar/substituir uma pasta de trabalho externa por gráfico independentemente dos demais.