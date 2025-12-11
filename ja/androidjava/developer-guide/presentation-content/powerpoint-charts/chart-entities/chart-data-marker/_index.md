---
title: Android のプレゼンテーションでチャート データ マーカーを管理する
linktitle: データ マーカー
type: docs
url: /ja/androidjava/chart-data-marker/
keywords:
- チャート
- データ ポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でチャート データ マーカーをカスタマイズし、PPT および PPTX フォーマット全体でプレゼンテーションの効果を高め、明確な Java コード例を提供します。"
---

## **チャート マーカー オプションの設定**
特定の系列内のチャート データ ポイントにマーカーを設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータ ポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

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
        
        // チャート データ ワークシートを取得
        IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
        
        // デモ系列を削除
        chart.getChartData().getSeries().clear();
        
        // 新しい系列を追加
        chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

        // 画像 1 をロード
        IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
        
        // 画像 2 をロード
        IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
        
        // 最初のチャート系列を取得
        IChartSeries series = chart.getChartData().getSeries().get_Item(0);
        
        // そこに新しいポイント (1:3) を追加。
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
        
        // チャート系列のマーカーを変更
        series.getMarker().setSize(15);
        
        // チャート付きプレゼンテーションを保存
        pres.save("ScatterChart.pptx", SaveFormat.Pptx);
    } catch (IOException e) {
    } finally {
        if (pres != null) pres.dispose();
    }
```


## **FAQ**

**標準で利用可能なマーカー形状は何ですか？**

標準形状（円、正方形、ダイヤモンド、三角形など）が利用可能です。リストは[MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/)クラスで定義されています。標準外の形状が必要な場合は、画像で塗りつぶしたマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートした場合、マーカーは保持されますか？**

はい。チャートを[raster formats](/slides/ja/androidjava/convert-powerpoint-to-png/)にレンダリングしたり、[shapes as SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)として保存したりすると、マーカーはサイズ、塗り、アウトラインなどの外観と設定を保持します。