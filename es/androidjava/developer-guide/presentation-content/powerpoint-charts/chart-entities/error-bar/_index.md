---
title: Barra de Error
type: docs
url: /androidjava/error-bar/
---

## **Agregar Barra de Error**
Aspose.Slides para Android a través de Java proporciona una API sencilla para gestionar los valores de barra de error. El código de muestra se aplica al usar un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie de gráficos y establezca el formato de la barra de error X.
1. Acceda a la primera serie de gráficos y establezca el formato de la barra de error Y.
1. Configuración de valores y formato de las barras.
1. Escriba la presentación modificada en un archivo PPTX.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Creando un gráfico de burbujas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Agregando barras de error y estableciendo su formato
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

    // Guardando presentación
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Valor de Barra de Error Personalizado**
Aspose.Slides para Android a través de Java proporciona una API sencilla para gestionar valores de barra de error personalizados. El código de muestra se aplica cuando la propiedad [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) es igual a **Personalizado**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregue un gráfico de burbujas en la diapositiva deseada.
1. Acceda a la primera serie de gráficos y establezca el formato de la barra de error X.
1. Acceda a la primera serie de gráficos y establezca el formato de la barra de error Y.
1. Acceda a los puntos de datos individuales de la serie de gráficos y configure los valores de la Barra de Error para el punto de datos individual de la serie.
1. Configuración de valores y formato de las barras.
1. Escriba la presentación modificada en un archivo PPTX.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Creando un gráfico de burbujas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Agregando barras de error personalizadas y estableciendo su formato
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Accediendo a los puntos de datos de la serie de gráficos y configurando los valores de las barras de error para
    // el punto individual
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Configurando barras de error para los puntos de la serie de gráficos
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Guardando presentación
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```