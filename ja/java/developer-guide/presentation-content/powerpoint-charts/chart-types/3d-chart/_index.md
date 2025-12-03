---
title: Java を使用したプレゼンテーションでの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で 3-D チャートを作成しカスタマイズする方法を学び、PPT と PPTX ファイルをサポートしてプレゼンテーションを向上させましょう。"
---

## **3D チャートの RotationX、RotationY および DepthPercents プロパティの設定**
Aspose.Slides for Java は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、**X、Y 回転、DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは、上記のプロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。
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
    
    // ここでシリーズデータを設定
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap 値を設定
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // プレゼンテーションをディスクに保存
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャート タイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D を含む、柱状チャートの 3D バリアントをサポートします。また、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスで公開されている関連の 3D タイプもサポートします。正確で最新の一覧については、インストールされているバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) メンバーを確認してください。

**レポートや Web 用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像としてエクスポートするには、[chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) または [スライド全体をレンダリング](/slides/ja/java/convert-powerpoint-to-png/) して PNG や JPEG などの形式に変換できます。これは、ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、Web ページにチャートを埋め込む際に便利です。

**大規模な 3D チャートの構築およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D エフェクトは最小限に抑え、壁やプロット領域の重いテクスチャを避け、可能な限り各系列のデータポイント数を制限し、対象の表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。