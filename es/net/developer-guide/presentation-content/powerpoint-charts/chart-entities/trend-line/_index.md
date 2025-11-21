---
title: Agregar líneas de tendencia a los gráficos de presentaciones en .NET
linktitle: Línea de tendencia
type: docs
url: /es/net/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de promedio móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Agregue y personalice rápidamente líneas de tendencia en gráficos de PowerPoint con Aspose.Slides para .NET — una guía práctica para cautivar a su audiencia."
---

## **Agregar línea de tendencia**
Aspose.Slides para .NET proporciona una API simple para administrar diferentes líneas de tendencia de gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera del tipo deseado (este ejemplo usa ChartType.ClusteredColumn).
1. Agregar una línea de tendencia exponencial para la serie 1 del gráfico.
1. Agregar una línea de tendencia lineal para la serie 1 del gráfico.
1. Agregar una línea de tendencia logarítmica para la serie 2 del gráfico.
1. Agregar una línea de tendencia de promedio móvil para la serie 2 del gráfico.
1. Agregar una línea de tendencia polinómica para la serie 3 del gráfico.
1. Agregar una línea de tendencia de potencia para la serie 3 del gráfico.
1. Escribir la presentación modificada a un archivo PPTX.

El siguiente código se usa para crear un gráfico con líneas de tendencia.
```c#
// Creando presentación vacía
Presentation pres = new Presentation();

// Creando un gráfico de columnas agrupadas
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Añadiendo línea de tendencia exponencial para la serie 1 del gráfico
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Añadiendo línea de tendencia lineal para la serie 1 del gráfico
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Añadiendo línea de tendencia logarítmica para la serie 2 del gráfico
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Añadiendo línea de tendencia de promedio móvil para la serie 2 del gráfico
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Añadiendo línea de tendencia polinómica para la serie 3 del gráfico
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Añadiendo línea de tendencia de potencia para la serie 3 del gráfico
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Guardando presentación
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Agregar línea personalizada**
Aspose.Slides para .NET proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva usando su Índice
- Crear un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregar un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el Color de las líneas de la forma.
- Escribir la presentación modificada como un archivo PPTX

El siguiente código se usa para crear un gráfico con líneas personalizadas.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' en una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Sólo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva a una imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/net/convert-powerpoint-to-pdf/)/[SVG](/slides/es/net/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/net/create-shape-thumbnails/).