---
title: Personalizar barras de error en gráficos de presentaciones usando Java
linktitle: Barra de error
type: docs
url: /es/java/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo agregar y personalizar barras de error en gráficos con Aspose.Slides para Java—optimice la visualización de datos en presentaciones de PowerPoint."
---

## **Agregar barras de error**
Aspose.Slides for Java proporciona una API sencilla para gestionar los valores de las barras de error. El código de ejemplo se aplica al usar un tipo de valor personalizado. Para especificar un valor, utilice la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato X de la barra de error.
1. Acceder a la primera serie del gráfico y establecer el formato Y de la barra de error.
1. Establecer los valores y el formato de las barras.
1. Escribir la presentación modificada en un archivo PPTX.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Crear un gráfico de burbujas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Agregar barras de error y establecer su formato
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Guardar la presentación
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar valores personalizados de barra de error**
Aspose.Slides for Java proporciona una API sencilla para gestionar valores personalizados de barra de error. El código de ejemplo se aplica cuando la propiedad [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) es igual a **Custom**. Para especificar un valor, utilice la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato X de la barra de error.
1. Acceder a la primera serie del gráfico y establecer el formato Y de la barra de error.
1. Acceder a los puntos de datos individuales de la serie del gráfico y establecer los valores de la barra de error para cada punto de datos de la serie.
1. Establecer los valores y el formato de las barras.
1. Escribir la presentación modificada en un archivo PPTX.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Crear un gráfico de burbujas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Agregar barras de error personalizadas y establecer su formato
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Accediendo al punto de datos de la serie del gráfico y estableciendo los valores de las barras de error para
    // punto individual
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Estableciendo barras de error para los puntos de la serie del gráfico
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Guardando la presentación
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento separado y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, puede ser necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y clases para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) y las clases relacionadas [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).