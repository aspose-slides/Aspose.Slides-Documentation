---
title: Personalizar barras de error en gráficos de presentación en .NET
linktitle: Barra de error
type: docs
url: /es/net/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo agregar y personalizar barras de error en gráficos con Aspose.Slides para .NET—optimice los visuales de datos en presentaciones de PowerPoint."
---

## **Agregar barra de error**
Aspose.Slides for .NET proporciona una API simple para administrar los valores de las barras de error. El código de ejemplo se aplica al usar un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Cree una instancia de la [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de barra de error Y.
1. Configure los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.
```c#
// Creando presentación vacía
using (Presentation presentation = new Presentation())
{
    // Creando un gráfico de burbujas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Añadiendo barras de error y configurando su formato
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

    // Guardando la presentación
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **Agregar valor de barra de error personalizado**
Aspose.Slides for .NET proporciona una API simple para administrar valores personalizados de barras de error. El código de ejemplo se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Cree una instancia de la [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de barra de error Y.
1. Acceda a los puntos de datos individuales de la serie del gráfico y configure los valores de la barra de error para cada punto de datos de la serie.
1. Configure los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.
```c#
// Creando presentación vacía
using (Presentation presentation = new Presentation())
{
    // Creando un gráfico de burbujas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Añadiendo barras de error personalizadas y configurando su formato
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Accediendo al punto de datos de la serie del gráfico y estableciendo valores de barras de error para cada punto individual
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Configurando barras de error para los puntos de la serie del gráfico
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


## **Preguntas frecuentes**

**¿Qué sucede con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento separado y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, es posible que deba ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y enumeraciones para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) y las enumeraciones relacionadas [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).