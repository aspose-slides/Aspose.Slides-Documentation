---
title: Optimizar Cálculos de Gráficos para Presentaciones en .NET
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /es/net/chart-calculations/
keywords:
- cálculos de gráficos
- elementos del gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores del gráfico
- valor real
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Comprenda los cálculos de gráficos, la actualización de datos y el control de precisión en Aspose.Slides para .NET en PPT y PPTX, con ejemplos prácticos de código en C#."
---

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for .NET proporciona una API sencilla para obtener estas propiedades. Esto le ayudará a calcular los valores reales de los elementos del gráfico. Los valores reales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) y los valores reales de los ejes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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


## **Calcular la posición real de los elementos principales del gráfico**
Aspose.Slides for .NET proporciona una API sencilla para obtener estas propiedades. Las propiedades de IActualLayout proporcionan información sobre la posición real del elemento principal del gráfico. Es necesario llamar previamente al método IChart.ValidateChartLayout() para rellenar las propiedades con los valores reales.
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


## **Ocultar información del gráfico**
Este tema le ayuda a comprender cómo ocultar información del gráfico. Con Aspose.Slides for .NET puede ocultar **Título, Eje vertical, Eje horizontal** y **Líneas de cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo utilizar estas propiedades.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ocultando título del gráfico
    chart.HasTitle = false;

    ///Ocultando eje de valores
    chart.Axes.VerticalAxis.IsVisible = false;

    //Visibilidad del eje de categorías
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Ocultando leyenda
    chart.HasLegend = false;

    //Ocultando líneas de cuadrícula principales
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

    //Setting series line color
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso al recálculo?**

Sí. Un gráfico puede hacer referencia a un libro de trabajo externo: cuando se conecta o actualiza la fuente externa, las fórmulas y los valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar el libro de trabajo externo](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) y administrar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. Las [líneas de tendencia](/slides/es/net/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no necesita implementar sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro de trabajo usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro de trabajo externo](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/), o puede crear/reemplazar un libro de trabajo externo por gráfico de forma independiente de los demás.