---
title: Barra de Error
type: docs
url: /net/error-bar/
keywords: "Barra de error, valores de barra de error presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir barra de error a presentaciones de PowerPoint en C# o .NET"
---

## **Añadir Barra de Error**
Aspose.Slides para .NET proporciona una API simple para gestionar valores de barra de error. El código de muestra se aplica al usar un tipo de valor personalizado. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Añade un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error X.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error Y.
1. Estableciendo valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```c#
// Creando presentación vacía
using (Presentation presentation = new Presentation())
{
    // Creando un gráfico de burbujas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Añadiendo barras de error y estableciendo su formato
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Guardando presentación
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Añadir Valor de Barra de Error Personalizado**
Aspose.Slides para .NET proporciona una API simple para gestionar valores de barra de error personalizados. El código de muestra se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Añade un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error X.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error Y.
1. Accede a los puntos de datos individuales de la serie de gráficos y establece los valores de la barra de error para el punto de datos de la serie individual.
1. Estableciendo valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```c#
// Creando presentación vacía
using (Presentation presentation = new Presentation())
{
    // Creando un gráfico de burbujas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Añadiendo barras de error personalizadas y estableciendo su formato
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Accediendo a los puntos de datos de la serie de gráficos y estableciendo valores de barras de error para el punto individual
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Estableciendo barras de error para los puntos de la serie de gráficos
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Guardando presentación
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```