---
title: Java を使用してプレゼンテーションでチャート データ マーカーを管理する
linktitle: データ マーカー
type: docs
url: /ja/java/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でチャート データ マーカーをカスタマイズする方法を学び、PPT および PPTX 形式のプレゼンテーションの効果を高める、わかりやすい Java コード例をご紹介します。"
---

## **チャート マーカー オプションの設定**
マーカーは特定のシリーズ内のチャート データポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート シリーズを取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャート マーカー オプションを設定しています。
```java
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルトのチャートを作成
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // デフォルトのチャート データ ワークシート インデックスを取得
    int defaultWorksheetIndex = 0;
    
    // チャート データ ワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デモシリーズを削除
    chart.getChartData().getSeries().clear();
    
    // 新しいシリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // 画像 1 をロード
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 画像 2 をロード
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // 最初のチャートシリーズを取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // そこに新しいポイント (1:3) を追加.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // チャートシリーズのマーカーを変更
    series.getMarker().setSize(15);
    
    // チャート付きのプレゼンテーションを保存
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**デフォルトで利用できるマーカー形状は何ですか？**

標準の形状（円、正方形、菱形、三角形など）が利用可能です。リストは [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/) クラスで定義されています。非標準の形状が必要な場合は、画像塗りつぶし付きのマーカーを使用してカスタム ビジュアルをエミュレートできます。

**チャートを画像または SVG にエクスポートするときにマーカーは保持されますか？**

はい。チャートを [raster formats](/slides/ja/java/convert-powerpoint-to-png/) にレンダリングする場合や、[shapes as SVG](/slides/ja/java/render-a-slide-as-an-svg-image/) を保存する場合、マーカーはサイズ、塗りつぶし、輪郭などの外観と設定を保持します。