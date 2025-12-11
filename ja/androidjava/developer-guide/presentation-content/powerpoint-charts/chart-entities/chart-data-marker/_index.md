---
title: Androidでプレゼンテーションのチャート データ マーカーを管理
linktitle: データ マーカー
type: docs
url: /ja/androidjava/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカーオプション
- マーカーサイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android のチャート データ マーカーをカスタマイズし、PPT および PPTX 形式のプレゼンテーション効果を向上させる、分かりやすい Java コード例付き。"
---

## **Set Chart Marker Options**
マーカーは特定の系列内のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- Instantiate [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

以下の例では、データ ポイント レベルでチャート マーカー オプションを設定しています。
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
    
    // チャート データのワークシートを取得
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

**Which marker shapes are available out of the box?**

標準の形状（円、四角、ダイヤモンド、三角形など）が利用可能で、一覧は [MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/) クラスで定義されています。非標準の形状が必要な場合は、画像塗りつぶし付きのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**Are markers preserved when exporting a chart to an image or SVG?**

はい。チャートを [raster formats](/slides/ja/androidjava/convert-powerpoint-to-png/) にレンダリングする場合や、[shapes as SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) として保存する場合、マーカーはサイズ、塗りつぶし、輪郭などの外観と設定を保持します。