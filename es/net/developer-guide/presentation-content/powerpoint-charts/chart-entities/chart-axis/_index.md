---
title: Eje de Gráfico
type: docs
url: /net/chart-axis/
keywords: "Eje de Gráfico de PowerPoint, Gráficos de Presentación, C#, .NET, Manipular Eje de Gráfico, Datos de Gráfico"
description: "Editar el eje de gráfico de PowerPoint en C# o .NET"
---


## **Obteniendo los Valores Máximos en el Eje Vertical en Gráficos**
Aspose.Slides para .NET te permite obtener los valores mínimos y máximos en un eje vertical. Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Obtén el valor máximo real en el eje.
1. Obtén el valor mínimo real en el eje.
1. Obtén la unidad mayor real del eje.
1. Obtén la unidad menor real del eje.
1. Obtén la escala de unidad mayor real del eje.
1. Obtén la escala de unidad menor real del eje.

Este código de muestra—una implementación de los pasos anteriores—te muestra cómo obtener los valores requeridos en C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Guarda la presentación
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Intercambiando los Datos entre Ejes**
Aspose.Slides te permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje y) se trasladan al eje horizontal (eje x) y viceversa.

Este código en C# te muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```c#
// Crea una presentación vacía
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Intercambia filas y columnas
	chart.ChartData.SwitchRowColumn();
		   
	// Guarda la presentación
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Desactivando el Eje Vertical para Gráficos de Líneas**

Este código en C# te muestra cómo ocultar el eje vertical para un gráfico de líneas:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Desactivando el Eje Horizontal para Gráficos de Líneas**

Este código te muestra cómo ocultar el eje horizontal para un gráfico de líneas:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Cambiando el Eje de Categoría**

Usando la propiedad **CategoryAxisType**, puedes especificar tu tipo de eje de categoría preferido (**fecha** o **texto**). Este código en C# demuestra la operación:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Estableciendo el Formato de Fecha para el Valor del Eje de Categoría**
Aspose.Slides para .NET te permite establecer el formato de fecha para un valor del eje de categoría. La operación se demuestra en este código en C#:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Estableciendo el Ángulo de Rotación para el Título del Eje del Gráfico**
Aspose.Slides para .NET te permite establecer el ángulo de rotación para un título de eje de gráfico. Este código en C# demuestra la operación:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Estableciendo la Posición del Eje en un Eje de Categoría o Valor**
Aspose.Slides para .NET te permite establecer la posición del eje en un eje de categoría o valor. Este código en C# muestra cómo realizar la tarea:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Habilitando la Etiqueta de Unidad de Visualización en el Eje de Valor del Gráfico**
Aspose.Slides para .NET te permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valor del gráfico. Este código en C# demuestra la operación:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```