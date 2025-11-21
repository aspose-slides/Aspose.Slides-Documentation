---
title: エラーバー
type: docs
url: /ja/nodejs-java/error-bar/
---

## **エラーバーを追加**

Aspose.Slides for Node.js via Java はエラーバーの値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. バーの値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // バブルチャートを作成
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // エラーバーを追加し、書式を設定
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
    // プレゼンテーションを保存
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタムエラーバー値の追加**

Aspose.Slides for Node.js via Java はカスタムエラーバー値を管理するためのシンプルな API を提供します。サンプルコードは [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. チャート系列の個々のデータポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```javascript
// Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // バブルチャートを作成
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // カスタムエラーバーを追加し、その書式を設定
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // チャート系列のデータポイントにアクセスし、エラーバーの値を設定
    // 個々のポイント
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // チャート系列のポイントにエラーバーを設定
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // プレゼンテーションを保存
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**プレゼンテーションを PDF や画像にエクスポートするとエラーバーはどうなりますか？**

エラーバーはチャートの一部として描画され、変換時にもチャートの書式設定とともに保持されます（互換性のあるバージョンまたはレンダラーを使用した場合）。

**エラーバーをマーカーやデータ ラベルと組み合わせることはできますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと併用できます。要素が重なる場合は、書式を調整する必要があることがあります。

**API でエラーバーを操作するためのプロパティや列挙体の一覧はどこで確認できますか？**

API リファレンスで確認できます：[ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) クラスと関連列挙体 [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/)。