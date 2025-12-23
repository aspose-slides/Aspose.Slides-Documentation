---
title: PHP を使用してプレゼンテーションのチャート データ マーカーを管理する
linktitle: データ マーカー
type: docs
url: /ja/php-java/chart-data-marker/
keywords:
- チャート
- データポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶしタイプ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP でチャート データ マーカーをカスタマイズする方法を学び、PPT と PPTX 形式のプレゼンテーション効果を向上させる明確なコード例を提供します。"
---

## **チャート マーカー オプションを設定**

マーカーは特定のシリーズ内のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)  
- デフォルトのチャートを作成します。  
- 画像を設定します。  
- 最初のチャートシリーズを取得します。  
- 新しいデータポイントを追加します。  
- プレゼンテーションをディスクに書き込みます。  

以下の例では、データポイント単位でチャート マーカー オプションを設定しています。  
```php
  # 空のプレゼンテーションを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトのチャートを作成
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # デフォルトのチャート データ ワークシート インデックスを取得
    $defaultWorksheetIndex = 0;
    # チャート データ ワークシートを取得
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # デモシリーズを削除
    $chart->getChartData()->getSeries()->clear();
    # 新しいシリーズを追加
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # 画像1をロード
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # 画像2をロード
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # 最初のチャートシリーズを取得
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # そこに新しいポイント (1:3) を追加。
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # チャートシリーズのマーカーを変更
    $series->getMarker()->setSize(15);
    # チャート付きでプレゼンテーションを保存
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**標準で利用できるマーカー形状は何ですか？**

標準の形状 (円、正方形、ダイヤモンド、三角形など) が利用可能です。リストは [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/) クラスで定義されています。標準外の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像または SVG にエクスポートする際にマーカーは保持されますか？**

はい。チャートを [raster formats](/slides/ja/php-java/convert-powerpoint-to-png/) にレンダリングしたり、[shapes as SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/) として保存したりすると、マーカーは外観と設定 (サイズ、塗りつぶし、アウトライン) を保持します。