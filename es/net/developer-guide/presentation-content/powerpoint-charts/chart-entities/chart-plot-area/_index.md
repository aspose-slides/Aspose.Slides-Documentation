---
title: Personalizar áreas de trazado de gráficos de presentación en .NET
linktitle: Área de trazado
type: docs
url: /es/net/chart-plot-area/
keywords:
- gráfico
- área de trazado
- ancho del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trazado de los gráficos en presentaciones de PowerPoint con Aspose.Slides para .NET. Mejore la apariencia de sus diapositivas sin esfuerzo."
---

## **Obtener ancho y alto del área de trazado del gráfico**
Aspose.Slides para .NET proporciona una API simple para .

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Llamar al método IChart.ValidateChartLayout() antes para obtener los valores reales.
1. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativo a la esquina superior izquierda del gráfico.
1. Obtiene la posición superior real del elemento del gráfico relativo a la esquina superior izquierda del gráfico.
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
	
	// Guardar presentación con el gráfico
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **Establecer modo de diseño del área de trazado del gráfico**
Aspose.Slides para .NET proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** e **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se diseña el área de trazado por su interior (sin incluir ejes y etiquetas de ejes) o por su exterior (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles definidos en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra un ejemplo de código.
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


## **FAQ**

**¿En qué unidades se devuelven ActualX, ActualY, ActualWidth y ActualHeight?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el Área de Trazado del Área del Gráfico en cuanto al contenido?**

El Área de Trazado es la zona donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el Área del Gráfico incluye los elementos circundantes (título, leyenda, etc.). En gráficos 3D, el Área de Trazado también incluye las paredes/suelo y los ejes.

**¿Cómo se interpretan X, Y, Ancho y Alto del Área de Trazado cuando el diseño es manual?**

Se tratan como fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está deshabilitado y se utilizan las fracciones que se establecen.

**¿Por qué la posición del Área de Trazado cambió después de añadir/mover la leyenda?**

La leyenda se sitúa en el área del gráfico fuera del Área de Trazado pero afecta al diseño y al espacio disponible, por lo que el Área de Trazado puede desplazarse cuando el posicionamiento automático está en vigor. (Este es el comportamiento estándar de los gráficos de PowerPoint.)