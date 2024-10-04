---
title: Área de Trazado del Gráfico
type: docs
url: /es/net/chart-plot-area/
keywords: "Área de Trazado del Gráfico presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Obtenga el ancho, alto del área de trazado del gráfico. Establezca el modo de diseño. Presentación de PowerPoint en C# o .NET"
---

## **Obtener Ancho, Alto del Área de Trazado del Gráfico**
Aspose.Slides para .NET proporciona una API simple para. 

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Llame al método IChart.ValidateChartLayout() antes de obtener los valores reales.
1. Obtiene la ubicación X real (izquierda) del elemento del gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtiene la parte superior real del elemento del gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtiene el ancho real del elemento del gráfico.
1. Obtiene la altura real del elemento del gráfico.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Guardar presentación con gráfico
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Establecer Modo de Diseño del Área de Trazado del Gráfico**
Aspose.Slides para .NET proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha agregado a las clases **ChartPlotArea** y **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se debe diseñar el área de trazado por su interior (sin incluir los ejes y las etiquetas de los ejes) o por su exterior (incluyendo los ejes y las etiquetas de los ejes). Hay dos valores posibles que se definen en el enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trazado determinara el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trazado determinara el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

El código de muestra se da a continuación.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```