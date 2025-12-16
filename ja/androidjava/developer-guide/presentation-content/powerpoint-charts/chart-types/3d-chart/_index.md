---
title: Android のプレゼンテーションで 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/androidjava/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java で PPT および PPTX ファイルをサポートしながら、3D チャートの作成とカスタマイズ方法を学び、プレゼンテーションを今すぐ強化しましょう。"
---

## **3D チャートの RotationX、RotationY、DepthPercents プロパティを設定する**
Aspose.Slides for Android via Java は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、**X,Y Rotation、DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは、前述のプロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. Rotation3D プロパティを設定します。
5. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルトデータでチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャートデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // シリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D プロパティを設定
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // 2 番目のチャートシリーズを取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // シリーズデータを設定中
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap 値を設定
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // プレゼンテーションをディスクに書き込む
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、棒グラフの 3D バリエーションと、[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスで公開されている関連する 3D タイプをサポートします。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) のメンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには、[chart API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) を使用するか、[render the entire slide](/slides/ja/androidjava/convert-powerpoint-to-png/) を PNG や JPEG などの形式で出力できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込みたい場合に便利です。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D 効果を最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズごとのデータポイント数を制限し、対象の表示または印刷要件に合わせた適切な解像度とサイズで出力してください。