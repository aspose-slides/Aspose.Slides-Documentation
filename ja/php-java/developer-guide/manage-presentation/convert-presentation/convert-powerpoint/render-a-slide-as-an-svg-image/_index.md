---
title: スライドをSVG画像としてレンダリングする
type: docs
weight: 50
url: /ja/php-java/render-a-slide-as-an-svg-image/
---

SVG（Scalable Vector Graphicsの略）は、二次元画像をレンダリングするために使用される標準的なグラフィックタイプまたは形式です。SVGは、動作や外観を定義する詳細を持つXML形式で画像をベクターとして保存します。

SVGは、スケーラビリティ、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラム性などの基準を非常に高く満たしている画像形式の数少ないものの一つです。このため、Web開発で一般的に使用されています。

SVGファイルを使用する必要がある場合は、次のようなケースが考えられます。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する。** SVG画像は、あらゆる解像度やレベルに拡大できます。品質を損なうことなく、SVG画像を必要に応じて何度でもサイズ変更できます。
- **スライドのチャートやグラフを*異なるメディアやプラットフォーム*で使用する。** 大多数のリーダーはSVGファイルを解釈できます。
- **画像の*可能な限り小さいサイズ*を使用する。** SVGファイルは、一般的に他の形式（特にビットマップ（JPEGまたはPNG）に基づく形式）の高解像度の同等物よりも小さいです。

Aspose.Slides for PHP via Javaを使用すると、プレゼンテーションのスライドをSVG画像としてエクスポートできます。SVG画像を生成するために、次の手順を実行してください。

1. Presentationクラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのスライドを繰り返し処理します。
3. 各スライドをFileOutputStreamを通じてその独自のSVGファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for PHP via JavaからのPPTからSVGへの変換機能を実装した[無料のWebアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)をぜひお試しください。

{{% /alert %}} 

このサンプルコードは、Aspose.Slidesを使用してPPTをSVGに変換する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```