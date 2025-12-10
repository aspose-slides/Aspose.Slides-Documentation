---
title: Añadir líneas de tendencia a los gráficos de presentación en .NET
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
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para .NET — una guía práctica para cautivar a tu audiencia."
---

## **Agregar una línea de tendencia**
Aspose.Slides for .NET ofrece una API simple para administrar diferentes líneas de tendencia de gráficos:

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Agregue un gráfico con datos predeterminados y cualquiera de los tipos deseados (en este ejemplo se usa ChartType.ClusteredColumn).
4. Añadiendo una línea de tendencia exponencial para la serie 1 del gráfico.
5. Añadiendo una línea de tendencia lineal para la serie 1 del gráfico.
6. Añadiendo una línea de tendencia logarítmica para la serie 2 del gráfico.
7. Añadiendo una línea de tendencia de promedio móvil para la serie 2 del gráfico.
8. Añadiendo una línea de tendencia polinómica para la serie 3 del gráfico.
9. Añadiendo una línea de tendencia de potencia para la serie 3 del gráfico.
10. Guarde la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con líneas de tendencia.
```c#
// Creando una presentación vacía
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

// Guardando la presentación
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **Agregar una línea personalizada**
Aspose.Slides for .NET ofrece una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su índice
- Cree un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregue un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establezca el color de las líneas de la forma.
- Guarde la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con líneas personalizadas.
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


## **FAQ**

**¿Qué significan 'forward' y 'backward' en una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/net/convert-powerpoint-to-pdf/)/[SVG](/slides/es/net/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/net/create-shape-thumbnails/).