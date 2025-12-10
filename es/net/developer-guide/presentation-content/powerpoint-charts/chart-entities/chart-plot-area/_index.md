---
title: Personalizar áreas de trazado de gráficos en .NET
linktitle: Área de trazado
type: docs
url: /es/net/chart-plot-area/
keywords:
- gráfico
- área de trazado
- ancho del área de trazado
- alto del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trazado de los gráficos en presentaciones de PowerPoint con Aspose.Slides para .NET. Mejore los visuales de sus diapositivas sin esfuerzo."
---

## **Obtener el ancho y la altura del área de trazado de un gráfico**
Aspose.Slides for .NET proporciona una API simple para .

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Llame al método IChart.ValidateChartLayout() antes de obtener los valores reales.
1. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
1. Obtiene la posición superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
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





## **Establecer el modo de diseño del área de trazado de un gráfico**
Aspose.Slides for .NET proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** e **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si el área de trazado se dispone por su interior (sin incluir ejes y etiquetas de eje) o por su exterior (incluyendo ejes y etiquetas de eje). Hay dos valores posibles que se definen en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** - indica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - indica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra el código de ejemplo.
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

**¿En qué se diferencia el área de trazado del área del gráfico en cuanto al contenido?**

El área de trazado es la región donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el área de trazado también incluye los muros/piso y los ejes.

**¿Cómo se interpretan X, Y, Ancho y Alto del área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está desactivado y se utilizan las fracciones que usted establezca.

**¿Por qué cambió la posición del área de trazado después de agregar o mover la leyenda?**

La leyenda se encuentra en el área del gráfico fuera del área de trazado, pero afecta el diseño y el espacio disponible, por lo que el área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)