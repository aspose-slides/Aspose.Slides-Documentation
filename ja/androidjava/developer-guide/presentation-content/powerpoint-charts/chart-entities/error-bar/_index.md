---
title: エラーバー
type: docs
url: /ja/androidjava/error-bar/
---

## **エラーバーを追加**
Aspose.Slides for Android via Javaは、エラーバーの値を管理するためのシンプルなAPIを提供します。サンプルコードは、カスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの[**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスして、エラーバーXのフォーマットを設定します。
1. 最初のチャートシリーズにアクセスして、エラーバーYのフォーマットを設定します。
1. バーの値とフォーマットを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // バブルチャートの作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // エラーバーを追加し、そのフォーマットを設定
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

    // プレゼンテーションの保存
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタムエラーバー値を追加**
Aspose.Slides for Android via Javaは、カスタムエラーバー値を管理するためのシンプルなAPIを提供します。サンプルコードは、[**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--)プロパティが**Custom**に等しい場合に適用されます。値を指定するには、シリーズの[**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection)コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスして、エラーバーXのフォーマットを設定します。
1. 最初のチャートシリーズにアクセスして、エラーバーYのフォーマットを設定します。
1. チャートシリーズの各データポイントにアクセスし、各シリーズデータポイントのエラーバー値を設定します。
1. バーの値とフォーマットを設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // バブルチャートの作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタムエラーバーを追加し、そのフォーマットを設定
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // チャートシリーズのデータポイントにアクセスし、各点のエラーバー値を設定
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // チャートシリーズポイントのエラーバーを設定
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // プレゼンテーションの保存
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```