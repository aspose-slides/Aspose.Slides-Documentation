---
title: Barra de error
type: docs
url: /java/error-bar/
---

## **Agregar Barra de Error**
Aspose.Slides para Java proporciona una API simple para gestionar los valores de las barras de error. El código de muestra se aplica al utilizar un tipo de valor personalizado. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de series [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error X.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error Y.
1. Establecer valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Creating a bubble chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adding Error bars and setting its format
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

    // Saving presentation
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Valor de Barra de Error Personalizado**
Aspose.Slides para Java proporciona una API simple para gestionar valores de barras de error personalizados. El código de muestra se aplica cuando la propiedad [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) es igual a **Custom**. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de series [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error X.
1. Accede a la primera serie de gráficos y establece el formato de la barra de error Y.
1. Accede a los puntos de datos individuales de la serie de gráficos y establece los valores de la barra de error para el punto de datos de serie individual.
1. Establecer valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Creating a bubble chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Adding custom Error bars and setting its format
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Accessing chart series data point and setting error bars values for
    // individual point
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Setting error bars for chart series points
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Saving presentation
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```