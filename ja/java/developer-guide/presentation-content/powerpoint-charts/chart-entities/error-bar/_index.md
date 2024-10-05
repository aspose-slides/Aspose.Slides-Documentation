---
title: エラーバー
type: docs
url: /java/error-bar/
---

## **エラーバーを追加する**
Aspose.Slides for Javaは、エラーバーの値を管理するためのシンプルなAPIを提供します。このサンプルコードは、カスタム値タイプを使用する際に適用されます。値を指定するには、[**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)シリーズの特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバーXフォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバーYフォーマットを設定します。
1. バーの値とフォーマットを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // バブルチャートを作成する
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // エラーバーを追加し、そのフォーマットを設定する
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

    // プレゼンテーションを保存する
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタムエラーバー値を追加する**
Aspose.Slides for Javaは、カスタムエラーバー値を管理するためのシンプルなAPIを提供します。このサンプルコードは、[**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--)プロパティが**Custom**に等しい場合に適用されます。値を指定するには、[**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection)シリーズの特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバーXフォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバーYフォーマットを設定します。
1. チャート系列の個別データポイントにアクセスし、個別系列データポイントのエラーバー値を設定します。
1. バーの値とフォーマットを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // バブルチャートを作成する
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタムエラーバーを追加し、そのフォーマットを設定する
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // チャート系列データポイントにアクセスし、個別ポイントのエラーバー値を設定する
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // チャート系列ポイントのエラーバーを設定する
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // プレゼンテーションを保存する
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```