---
title: Java を使用したプレゼンテーションの 3D チャートのカスタマイズ
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
description: "Aspose.Slides for Java で 3-D チャートを作成およびカスタマイズする方法を学び、PPT と PPTX ファイルに対応し、プレゼンテーションを今すぐ強化しましょう。"
---

## **3D チャートの RotationX、RotationY、DepthPercents プロパティの設定**
Aspose.Slides for Java は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、**X,Y Rotation、DepthPercents** などのさまざまなプロパティの設定方法を解説します。サンプルコードは、上記プロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルト データでチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // チャート データ シートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 系列を追加
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
    
    // 2番目のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 系列データを設定中
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap 値を設定
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // プレゼンテーションをディスクへ保存
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **FAQ**

**Aspose.Slides で 3D モードをサポートしているチャートの種類は何ですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、柱状チャートの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストールされているバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) のメンバーを確認してください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには、[chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) を使用するか、スライド全体を PNG や JPEG などの形式に変換するには [/slides/java/convert-powerpoint-to-png/](/slides/ja/java/convert-powerpoint-to-png/) を利用してください。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込む際に便利です。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るために、3D エフェクトは最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズごとのデータポイント数を制限し、ターゲットの表示または印刷要件に合わせた解像度とサイズで出力をレンダリングしてください。