---
title: Android のプレゼンテーション チャートでエラーバーをカスタマイズする
linktitle: エラーバー
type: docs
url: /ja/androidjava/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してチャートにエラーバーを追加・カスタマイズする方法を学び、PowerPoint プレゼンテーションのデータビジュアルを最適化しましょう。"
---

## **エラーバーを追加**
Aspose.Slides for Android via Java は、エラーバー値の管理用にシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
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


## **カスタム エラーバー値を追加**
Aspose.Slides for Android via Java は、カスタム エラーバー値の管理用にシンプルな API を提供します。サンプルコードは、[**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. チャート系列の個別データポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // バブルチャートを作成する
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタムエラーバーを追加し、その書式を設定する
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // チャート系列のデータポイントにアクセスし、エラーバーの値を設定する
    // 個々のポイント
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // チャート系列のポイントにエラーバーを設定する
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


## **FAQ**

**プレゼンテーションを PDF または画像にエクスポートしたとき、エラーバーはどうなりますか？**

エラーバーはチャートの一部としてレンダリングされ、変換時に他のチャート書式と同様に保持されます（互換性のあるバージョンまたはレンダラを使用した場合）。

**エラーバーはマーカーやデータ ラベルと組み合わせられますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと併用できます。要素が重なる場合は書式を調整する必要があります。

**API でエラーバーを操作するためのプロパティやクラスの一覧はどこにありますか？**

API リファレンスで確認できます： [ErrorBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarsformat/) クラスと、関連クラスの [ErrorBarType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarvaluetype/)。