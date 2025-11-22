---
title: Área de trazado del gráfico
type: docs
url: /es/net/chart-plot-area/
keywords: "Área de trazado del gráfico presentación PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Obtener ancho y alto del área de trazado del gráfico. Establecer modo de diseño. Presentación PowerPoint en C# o .NET"
---

## **Obtener ancho y alto del área de trazado del gráfico**
Aspose.Slides para .NET proporciona una API sencilla para .

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Llame al método IChart.ValidateChartLayout() antes para obtener los valores reales.
1. Obtiene la ubicación X real (izquierda) del elemento del gráfico, relativa a la esquina superior izquierda del gráfico.
1. Obtiene la parte superior real del elemento del gráfico, relativa a la esquina superior izquierda del gráfico.
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
Aspose.Slides para .NET proporciona una API sencilla para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** y **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad indica si el diseño del área de trazado se basa en su interior (sin incluir ejes y etiquetas de ejes) o en su exterior (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles que se definen en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

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


## **Preguntas frecuentes**

**¿En qué unidades se devuelven ActualX, ActualY, ActualWidth y ActualHeight?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el Área de trazado del Área del gráfico en cuanto al contenido?**

El Área de trazado es la región de dibujo de datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el Área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En gráficos 3D, el Área de trazado también incluye las paredes/suelo y los ejes.

**¿Cómo se interpretan X, Y, Ancho y Alto del Área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está desactivado y se usan las fracciones que usted establece.

**¿Por qué cambió la posición del Área de trazado después de añadir/mover la leyenda?**

La leyenda se coloca en el área del gráfico fuera del Área de trazado, pero afecta al diseño y al espacio disponible, por lo que el Área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)