---
title: Barre d'erreur
type: docs
url: /fr/androidjava/error-bar/
---

## **Ajouter une barre d'erreur**
Aspose.Slides pour Android via Java fournit une API simple pour gérer les valeurs des barres d'erreur. Le code exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection de [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) de séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Définissez les valeurs et le format des barres.
1. Écrivez la présentation modifiée dans un fichier PPTX.

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

## **Ajouter une valeur de barre d'erreur personnalisée**
Aspose.Slides pour Android via Java fournit une API simple pour gérer les valeurs de barres d'erreur personnalisées. Le code exemple s'applique lorsque la propriété [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection de [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) de séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série de graphiques et définissez les valeurs de la barre d'erreur pour le point de données individuel de la série.
1. Définissez les valeurs et le format des barres.
1. Écrivez la présentation modifiée dans un fichier PPTX.

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