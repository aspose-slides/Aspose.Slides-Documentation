---
title: 3Dチャート
type: docs
url: /ja/nodejs-java/3d-chart/
---

## **3DチャートのRotationX、RotationY、DepthPercentsプロパティの設定**

Aspose.Slides for Node.js via Java は、これらのプロパティを設定するためのシンプルな API を提供します。この記事では、**X、Y 回転、DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは、上記のプロパティの設定を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // デフォルトデータでチャートを追加
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // チャート データシートのインデックスを設定
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得
    var fact = chart.getChartData().getChartDataWorkbook();
    // 系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Rotation3D プロパティを設定
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // 2 番目のチャート系列を取得
    var series = chart.getChartData().getSeries().get_Item(1);
    // 系列データを設定中
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // OverLap 値を設定
    series.getParentSeriesGroup().setOverlap(100);
    // プレゼンテーションをディスクに保存
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D バリアントの縦棒チャートをサポートし、[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 列挙体で公開される関連 3D タイプも含まれます。正確で最新の一覧については、インストールされているバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) メンバーをご確認ください。

**レポートや Web 用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) を使用するか、[スライド全体をレンダリング](/slides/ja/nodejs-java/convert-powerpoint-to-png/)して PNG や JPEG 形式に変換できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにチャートをドキュメント、ダッシュボード、Web ページに埋め込む場合に便利です。

**大規模な 3D チャートの作成とレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストな結果を得るには、3D エフェクトは最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能であれば系列ごとのデータ点数を制限し、対象の表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。