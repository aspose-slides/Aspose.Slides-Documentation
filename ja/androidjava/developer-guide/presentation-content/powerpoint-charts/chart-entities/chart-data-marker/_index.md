---
title: チャートデータマーカー
type: docs
url: /androidjava/chart-data-marker/
---

## **チャートマーカーオプションの設定**
マーカーは特定の系列内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するためには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。

```java
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルトのチャートを作成
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // デフォルトのチャートデータワークシートインデックスを取得
    int defaultWorksheetIndex = 0;
    
    // チャートデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // デモ系列を削除
    chart.getChartData().getSeries().clear();
    
    // 新しい系列を追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "シリーズ 1"), chart.getType());

    // 画像 1 を読み込む
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 画像 2 を読み込む
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // 最初のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 新しいポイント (1:3) を追加
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
    
    // チャート系列マーカーを変更
    series.getMarker().setSize(15);
    
    // チャートを含むプレゼンテーションを保存
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```