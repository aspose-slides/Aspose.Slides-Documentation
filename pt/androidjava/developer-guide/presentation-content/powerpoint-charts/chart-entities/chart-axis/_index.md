---
title: Personalizar Eixos de Gráfico em Apresentações no Android
linktitle: Eixo de Gráfico
type: docs
url: /pt/androidjava/chart-axis/
keywords:
- eixo de gráfico
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
- Android
- Java
- Aspose.Slides
description: "Descubra como usar o Aspose.Slides para Android via Java para personalizar eixos de gráfico em apresentações PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráfico no Aspose.Slides. Ele mostra como obter valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal em gráficos de linhas, alterar o tipo de eixo de categoria, definir o formato de data para valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obter os Valores Máximos no Eixo Vertical em Gráficos**
Aspose.Slides for Android via Java permite obter os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) classe.
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Obtenha o valor máximo real no eixo.
1. Obtenha o valor mínimo real no eixo.
1. Obtenha a unidade principal real do eixo.
1. Obtenha a unidade secundária real do eixo.
1. Obtenha a escala da unidade principal real do eixo.
1. Obtenha a escala da unidade secundária real do eixo.

Este código de exemplo — uma implementação das etapas acima — mostra como obter os valores necessários em Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Salva a apresentação
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Trocar os Dados entre Eixos**
O Aspose.Slides permite trocar rapidamente os dados entre os eixos — os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa. 

Este código Java mostra como realizar a troca de dados entre eixos em um gráfico:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Troca linhas e colunas
	chart.getChartData().switchRowColumn();

	// Salva a apresentação
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Desativar o Eixo Vertical em Gráficos de Linha**

Este código Java mostra como ocultar o eixo vertical em um gráfico de linha:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Desativar o Eixo Horizontal em Gráficos de Linha**

Este código mostra como ocultar o eixo horizontal em um gráfico de linha:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Alterar um Eixo de Categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em Java demonstra a operação: 

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Definir o Formato de Data para Valores do Eixo de Categoria**
O Aspose.Slides para Android via Java permite definir o formato de data para um valor do eixo de categoria. A operação é demonstrada neste código Java:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Definir um Ângulo de Rotação para o Título do Eixo do Gráfico**
O Aspose.Slides para Android via Java permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código Java demonstra a operação:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Definir a Posição do Eixo em um Eixo de Categoria ou Valor**
O Aspose.Slides para Android via Java permite definir a posição do eixo em um eixo de categoria ou valor. Este código Java mostra como executar a tarefa:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Habilitar a Exibição do Rótulo de Unidade no Eixo de Valor do Gráfico**
O Aspose.Slides para Android via Java permite configurar um gráfico para exibir um rótulo de unidade no seu eixo de valor. Este código Java demonstra a operação:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Como definço o valor em que um eixo cruza o outro (cruzamento do eixo)?**

Os eixos oferecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/axis/#setCrossType-int-): você pode escolher cruzar em zero, na categoria/valor máximo, ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posso posicionar os rótulos de marcações em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.