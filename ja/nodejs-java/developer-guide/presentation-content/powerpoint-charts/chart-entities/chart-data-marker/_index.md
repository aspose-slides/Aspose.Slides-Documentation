---
title: チャート データ マーカー
type: docs
url: /ja/nodejs-java/chart-data-marker/
---

## **チャート マーカー オプションの設定**

マーカーは特定の系列のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- Presentation クラスをインスタンス化します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータ ポイントを追加します。
- プレゼンテーションを書き込みます。

以下の例では、データ ポイント レベルでチャート マーカー オプションを設定しています。
```javascript
// 空のプレゼンテーションを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // デフォルトのチャートを作成
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // デフォルトのチャート データ ワークシート インデックスを取得
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得
    var fact = chart.getChartData().getChartDataWorkbook();
    // デモシリーズを削除
    chart.getChartData().getSeries().clear();
    // 新しいシリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // 画像 1 をロード
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // 画像 2 をロード
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // 最初のチャートシリーズを取得
    var series = chart.getChartData().getSeries().get_Item(0);
    // そこに新しいポイント (1:3) を追加.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // チャートシリーズのマーカーを変更
    series.getMarker().setSize(15);
    // チャート付きプレゼンテーションを保存
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**利用可能な標準マーカー形状は何ですか？**

標準の形状が利用可能です（円、四角、ダイヤモンド、三角形など）。一覧は[MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/)列挙型で定義されています。非標準の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートするときにマーカーは保持されますか？**

はい。チャートを[raster formats](/slides/ja/nodejs-java/convert-powerpoint-to-png/)にレンダリングする場合や、[shapes as SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/)として保存する場合、マーカーはサイズ、塗り、輪郭などの外観と設定を保持します。