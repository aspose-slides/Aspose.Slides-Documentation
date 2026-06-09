---
title: Personalizar Eixos de Gráficos em Apresentações Usando Java
linktitle: Eixo do Gráfico
type: docs
url: /pt/java/chart-axis/
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
- Java
- Aspose.Slides
description: "Descubra como usar Aspose.Slides para Java para personalizar os eixos de gráficos em apresentações do PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar eixos de gráficos no Aspose.Slides. Ele mostra como obter valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal para gráficos de linhas, alterar o tipo do eixo de categoria, definir o formato de data para valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obter os valores máximos no eixo vertical dos gráficos**
Aspose.Slides for Java permite que você obtenha os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
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

## **Trocar os dados entre os eixos**
Aspose.Slides permite que você troque rapidamente os dados entre os eixos — os dados representados no eixo vertical (eixo y) passam para o eixo horizontal (eixo x) e vice‑versa. 

Este código Java mostra como executar a troca de dados entre eixos em um gráfico:

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

## **Desativar o eixo vertical para gráficos de linhas**

Este código Java mostra como ocultar o eixo vertical em um gráfico de linhas:

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

## **Desativar o eixo horizontal para gráficos de linhas**

Este código mostra como ocultar o eixo horizontal em um gráfico de linhas:

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

## **Alterar um eixo de categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar seu tipo de eixo de categoria preferido (**date** ou **text**). Este código em Java demonstra a operação: 

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

## **Definir o formato de data para valores do eixo de categoria**
Aspose.Slides for Java permite definir o formato de data para um valor de eixo de categoria. A operação é demonstrada neste código Java:

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

## **Definir um ângulo de rotação para o título do eixo de um gráfico**
Aspose.Slides for Java permite definir o ângulo de rotação para o título do eixo de um gráfico. Este código Java demonstra a operação:

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

## **Definir a posição do eixo em um eixo de categoria ou valor**
Aspose.Slides for Java permite definir a posição do eixo em um eixo de categoria ou valor. Este código Java mostra como executar a tarefa:

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

## **Habilitar a exibição do rótulo de unidade no eixo de valor do gráfico**
Aspose.Slides for Java permite configurar um gráfico para exibir um rótulo de unidade no seu eixo de valor. Este código Java demonstra a operação:

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

**Como defino o valor em que um eixo cruza o outro (cruzamento de eixos)?**

Eixos fornecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/java/com.aspose.slides/axis/#setCrossType-int-): você pode escolher cruzar em zero, no máximo da categoria/valor ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para destacar uma linha de base.

**Como posso posicionar os rótulos de marcação em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/axis/#setMajorTickMark-int-) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.