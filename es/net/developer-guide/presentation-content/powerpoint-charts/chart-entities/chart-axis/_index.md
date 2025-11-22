---
title: Eje del gráfico
type: docs
url: /es/net/chart-axis/
keywords: "Eje de gráfico de PowerPoint, Gráficos de presentación, C#, .NET, Manipular eje de gráfico, Datos del gráfico"
description: "Editar el eje del gráfico de PowerPoint en C# o .NET"
---

## **Obteniendo los valores máximos en el eje vertical de los gráficos**
Aspose.Slides for .NET le permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Obtenga el valor máximo real del eje.
1. Obtenga el valor mínimo real del eje.
1. Obtenga la unidad mayor real del eje.
1. Obtenga la unidad menor real del eje.
1. Obtenga la escala de unidad mayor real del eje.
1. Obtenga la escala de unidad menor real del eje.

Este código de ejemplo—una implementación de los pasos anteriores—le muestra cómo obtener los valores requeridos en C#:
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


## **Intercambiando los datos entre ejes**
Aspose.Slides le permite intercambiar rápidamente los datos entre los ejes: los datos representados en el eje vertical (eje y) se trasladan al eje horizontal (eje x) y viceversa. 

Este código C# le muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:
```c#
 // Crea una presentación vacía
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Intercambia filas y columnas
	chart.ChartData.SwitchRowColumn();
		   
	// Guarda la presentación
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Desactivando el eje vertical para gráficos de líneas**

Este código C# le muestra cómo ocultar el eje vertical en un gráfico de líneas:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Desactivando el eje horizontal para gráficos de líneas**

Este código le muestra cómo ocultar el eje horizontal en un gráfico de líneas:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Cambiar el eje de categoría**

Usando la propiedad **CategoryAxisType**, puede especificar el tipo de eje de categoría que prefiera (**date** o **text**). Este código en C# demonstra la operación: 
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


## **Establecer el formato de fecha para el valor del eje de categoría**
Aspose.Slides for .NET le permite establecer el formato de fecha para un valor del eje de categoría. La operación se muestra en este código C#:
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


## **Establecer el ángulo de rotación del título del eje del gráfico**
Aspose.Slides for .NET le permite establecer el ángulo de rotación para el título del eje de un gráfico. Este código C# demuestra la operación:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Establecer la posición del eje en un eje de categoría o de valor**
Aspose.Slides for .NET le permite establecer la posición del eje en un eje de categoría o de valor. Este código C# muestra cómo realizar la tarea:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Habilitar la etiqueta de unidad de visualización en el eje de valores del gráfico**
Aspose.Slides for .NET le permite configurar un gráfico para que muestre una etiqueta de unidad en su eje de valores. Este código C# demuestra la operación:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Los ejes ofrecen una [configuración de cruce](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o abajo o para enfatizar una línea base.

**¿Cómo puedo posicionar las etiquetas de marcas de graduación respecto al eje (junto, fuera, dentro)?**

Establezca la [posición de la etiqueta](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) a "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a ahorrar espacio, especialmente en gráficos pequeños.