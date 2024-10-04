---
title: Línea de Tendencia
type: docs
url: /net/trend-line/
keywords: "Línea de tendencia, línea personalizada presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Agregue línea de tendencia y línea personalizada a presentaciones de PowerPoint en C# o .NET"
---

## **Agregar Línea de Tendencia**
Aspose.Slides for .NET proporciona una API simple para gestionar diferentes Líneas de Tendencia de gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con el tipo deseado (este ejemplo utiliza ChartType.ClusteredColumn).
1. Agregar línea de tendencia exponencial para la serie de gráfico 1.
1. Agregar línea de tendencia lineal para la serie de gráfico 1.
1. Agregar línea de tendencia logarítmica para la serie de gráfico 2.
1. Agregar línea de tendencia de media móvil para la serie de gráfico 2.
1. Agregar línea de tendencia polinómica para la serie de gráfico 3.
1. Agregar línea de tendencia de potencia para la serie de gráfico 3.
1. Escribir la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con Líneas de Tendencia.

```c#
// Creando presentación vacía
Presentation pres = new Presentation();

// Creando un gráfico de columnas agrupadas
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Agregando línea de tendencia exponencial para la serie de gráfico 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Agregando línea de tendencia lineal para la serie de gráfico 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Agregando línea de tendencia logarítmica para la serie de gráfico 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("Nueva línea de tendencia logarítmica");

// Agregando línea de tendencia de media móvil para la serie de gráfico 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "Nuevo Nombre de Línea de Tendencia";

// Agregando línea de tendencia polinómica para la serie de gráfico 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Agregando línea de tendencia de potencia para la serie de gráfico 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Guardando presentación
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Agregar Línea Personalizada**
Aspose.Slides for .NET proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los siguientes pasos:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva utilizando su índice
- Crear un nuevo gráfico utilizando el método AddChart expuesto por el objeto Shapes
- Agregar una forma automática de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el color de las líneas de la forma.
- Escribir la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con Líneas Personalizadas.

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