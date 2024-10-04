---
title: Eje del Gráfico
type: docs
url: /es/androidjava/chart-axis/
keywords: "Eje del Gráfico de PowerPoint, Gráficos de Presentación, Java, Manipular Eje del Gráfico, Datos del gráfico"
description: "Cómo editar el eje de gráfico de PowerPoint en Java"
---

## **Obteniendo los Valores Máximos en el Eje Vertical de los Gráficos**
Aspose.Slides para Android a través de Java te permite obtener los valores mínimos y máximos en un eje vertical. Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Obtén el valor máximo real en el eje.
1. Obtén el valor mínimo real en el eje.
1. Obtén la unidad mayor real del eje.
1. Obtén la unidad menor real del eje.
1. Obtén la escala de unidad mayor real del eje.
1. Obtén la escala de unidad menor real del eje.

Este código de ejemplo—una implementación de los pasos anteriores—te muestra cómo obtener los valores requeridos en Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Guarda la presentación
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Intercambiando los Datos entre Ejes**
Aspose.Slides te permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje y) se mueven al eje horizontal (eje x) y viceversa.

Este código Java te muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Intercambia filas y columnas
	chart.getChartData().switchRowColumn();

	// Guarda la presentación
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Deshabilitando el Eje Vertical para Gráficos de Línea**

Este código Java te muestra cómo ocultar el eje vertical para un gráfico de líneas:

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

## **Deshabilitando el Eje Horizontal para Gráficos de Línea**

Este código te muestra cómo ocultar el eje horizontal para un gráfico de líneas:

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

## **Cambiando el Eje de Categoría**

Usando la propiedad **CategoryAxisType**, puedes especificar tu tipo de eje de categoría preferido (**fecha** o **texto**). Este código en Java demuestra la operación:

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

## **Configurando el Formato de Fecha para el Valor del Eje de Categoría**
Aspose.Slides para Android a través de Java te permite establecer el formato de fecha para un valor de eje de categoría. La operación se demuestra en este código Java:

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

## **Configurando el Ángulo de Rotación para el Título del Eje del Gráfico**
Aspose.Slides para Android a través de Java te permite establecer el ángulo de rotación para un título del eje del gráfico. Este código Java demuestra la operación:

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

## **Configurando el Eje de Posición en un Eje de Categoría o Valor**
Aspose.Slides para Android a través de Java te permite establecer el eje de posición en un eje de categoría o valor. Este código Java muestra cómo realizar la tarea:

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

## **Habilitando la Etiqueta de Unidad de Visualización en el Eje de Valor del Gráfico**
Aspose.Slides para Android a través de Java te permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valor del gráfico. Este código Java demuestra la operación:

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