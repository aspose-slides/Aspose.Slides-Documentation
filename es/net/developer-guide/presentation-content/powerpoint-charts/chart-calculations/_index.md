---
title: Cálculos de Gráficos
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "Cálculos de gráficos, elementos de gráfico, posición de elemento, valores de gráfico C#, Csharp, Aspose.Slides para .NET"
description: "Cálculos y valores de gráficos de PowerPoint en C# o .NET"
---

## **Calcular Valores Reales de los Elementos del Gráfico**
Aspose.Slides para .NET proporciona una API simple para obtener estas propiedades. Esto te ayudará a calcular los valores reales de los elementos del gráfico. Los valores reales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) y los valores reales de los ejes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Guardando la presentación
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Calcular la Posición Actual de los Elementos Parent del Gráfico**
Aspose.Slides para .NET proporciona una API simple para obtener estas propiedades. Las propiedades de IActualLayout proporcionan información sobre la posición actual del elemento parent del gráfico. Es necesario llamar al método IChart.ValidateChartLayout() previamente para llenar las propiedades con valores reales.

```c#
// Creando una presentación vacía
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Ocultar Información del Gráfico**
Este tema te ayuda a entender cómo ocultar información del gráfico. Usando Aspose.Slides para .NET puedes ocultar **Título, Eje Vertical, Eje Horizontal** y **Líneas de Cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // Ocultando el Título del gráfico
    chart.HasTitle = false;

    // Ocultando el eje de Valores
    chart.Axes.VerticalAxis.IsVisible = false;

    // Visibilidad del Eje de Categoría
    chart.Axes.HorizontalAxis.IsVisible = false;

    // Ocultando la Leyenda
    chart.HasLegend = false;

    // Ocultando Líneas de Cuadrícula Mayores
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // Estableciendo el color de la línea de la serie
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```