---
title: Barra de error
type: docs
url: /es/nodejs-java/error-bar/
---

## **Agregar barra de error**

Aspose.Slides para Node.js a través de Java proporciona una API sencilla para administrar los valores de las barras de error. El código de ejemplo se aplica al usar un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) de la serie:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error Y.
1. Establezca los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Crear un gráfico de burbujas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Agregar barras de error y establecer su formato
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Guardar la presentación
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar valor de barra de error personalizada**

Aspose.Slides para Node.js a través de Java proporciona una API sencilla para administrar valores de barras de error personalizados. El código de ejemplo se aplica cuando la propiedad [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) es igual a **Custom**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) de la serie:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error X.
1. Acceda a la primera serie del gráfico y establezca el formato de la barra de error Y.
1. Acceda a los puntos de datos individuales de la serie del gráfico y establezca los valores de la barra de error para cada punto de datos de la serie.
1. Establezca los valores y el formato de las barras.
1. Guarde la presentación modificada en un archivo PPTX.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Creando un gráfico de burbujas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Añadiendo barras de error personalizadas y estableciendo su formato
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Accediendo al punto de datos de la serie del gráfico y estableciendo los valores de las barras de error para
    // punto individual
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Estableciendo barras de error para los puntos de la serie del gráfico
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Guardando la presentación
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento independiente y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, es posible que deba ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y enumeraciones para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) y los enums relacionados [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/).