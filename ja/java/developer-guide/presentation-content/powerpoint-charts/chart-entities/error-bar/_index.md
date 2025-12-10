---
title: Java を使用したプレゼンテーションチャートのエラーバーのカスタマイズ
linktitle: エラーバー
type: docs
url: /ja/java/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してチャートにエラーバーを追加およびカスタマイズする方法を学び、PowerPoint プレゼンテーションのデータビジュアルを最適化します。"
---

## **Add Error Bars**
Aspose.Slides for Java はエラーバーの値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. バーの値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // バブルチャートを作成します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // エラーバーを追加し、その書式を設定します
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

    // プレゼンテーションを保存します
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add Custom Error Bar Values**
Aspose.Slides for Java はカスタムエラーバー値を管理するためのシンプルな API を提供します。サンプルコードは [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. チャート系列の個々のデータポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // バブルチャートを作成します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタム エラーバーを追加し、書式を設定します
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // チャート系列のデータポイントにアクセスし、エラーバーの値を設定します
    // 個々のポイント
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // チャート系列ポイントのエラーバーを設定します
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // プレゼンテーションを保存します
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

エラーバーはチャートの一部として描画され、互換性のあるバージョンまたはレンダラが使用されている限り、変換中にチャートの他の書式設定とともに保持されます。

**Can error bars be combined with markers and data labels?**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式設定を調整する必要がある場合があります。

**Where can I find the list of properties and classes for working with error bars in the API?**

API リファレンスで確認できます: [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) クラスと、関連クラスの [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/)。