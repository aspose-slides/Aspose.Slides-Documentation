---
title: PHPでプレゼンテーションチャートをエクスポート
linktitle: チャートのエクスポート
type: docs
weight: 90
url: /ja/php-java/export-chart/
keywords:
- チャート
- チャートを画像に
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT および PPTX 形式をサポートし、レポート作成をあらゆるワークフローに統合できます。"
---

## **チャート画像を取得する**
Aspose.Slides for PHP via Java は、特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**チャートをラスタ画像ではなくベクター（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG保存メソッド](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)を使用してSVGに保存できます。

**エクスポートしたチャートのサイズをピクセル単位で正確に設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる画像レンダリングのオーバーロードを使用します。ライブラリは指定した寸法/スケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

[必要なフォントをロード](/slides/ja/php-java/custom-font/)し、[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/)を使用してチャートのレンダリングがメトリックとテキストの外観を保持するようにします。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗り、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

[API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[documentation](/slides/ja/php-java/convert-powerpoint/)をご参照ください。出力先（[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/php-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/) など）や関連するレンダリングオプションが記載されています。