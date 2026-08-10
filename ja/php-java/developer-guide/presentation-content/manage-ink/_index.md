---
title: PHPでプレゼンテーションのインクオブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/php-java/manage-ink/
keywords:
- インク
- インクオブジェクト
- インクトレース
- インクの管理
- インクを描く
- 描画
- インクのエクスポート
- インクのレンダリング
- インクの非表示
- InkOptions
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint のインクオブジェクトを管理し、トレースやブラシプロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインク表示を制御します。"
---
## **はじめに**

PowerPoint は自由形状のストロークを書き込むことができるインク機能を提供します。インクは他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides はインクオブジェクトを操作するために必要な型を提供します。たとえば、[Ink](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ink/) クラスはスライド上のインクオブジェクトを表します。

## **通常オブジェクトとインクオブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) オブジェクトで表されます。最も単純な形では、シェイプはオブジェクト自体（フレーム）の領域と、コンテナサイズ、形状、背景などのプロパティを定義するコンテナです。詳しくは [Shape Layout Format](https://docs.aspose.com/slides/ja/php-java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint がインクオブジェクトを処理する際は、コンテナ（フレーム）のサイズ以外のすべてのプロパティを無視します。コンテナ領域のサイズは標準の [Shape.getWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getWidth) と [Shape.getHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getHeight) メソッドで決まります。

![ink_powerpoint1](ink_powerpoint1.png)

## **インクトレース**

インクトレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録する基本要素です。トレースは接続されたポイントのシーケンスを保持します。

最も単純なエンコード形式は各サンプル点の X および Y 座標を指定します。すべての接続ポイントが描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシプロパティ**

ブラシはインクトレースのポイントを結ぶ線を描くために使用されます。ブラシには独自の色とサイズがあり、[InkBrush.getColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkbrush/#getColor) および [InkBrush.getSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkbrush/#getSize) メソッドで取得できます。

### **インクブラシの色を設定する**

この PHP コードはインクブラシの色を設定する方法を示します。

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **インクブラシのサイズを設定する**

この PHP コードはインクブラシのサイズを設定する方法を示します。

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

通常、ブラシの幅と高さは一致せず、PowerPoint はブラシサイズを表示しません（対応するデータ セクションは灰色表示になります）。幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

わかりやすくするために、インクオブジェクトの高さを増やして重要な寸法を確認します。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮しません。常に線の太さはゼロと見なされます（前の画像を参照）。

したがって、インクオブジェクト全体の可視領域を決定するには、トレースのブラシサイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキストトレース）がコンテナ（フレーム）のサイズにスケーリングされています。コンテナのサイズが変わってもブラシサイズは一定のままで、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキストオブジェクトにも同様の動作を使用します。

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク表示制御**

Aspose.Slides はインクオブジェクトのエクスポートまたはレンダリング時の表示方法を制御するために [InkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/) クラスを提供します。プロパティを使用してインクを完全に非表示にしたり、インクブラシのマスク操作の解釈方法を変更したりできます。

Ink オプションはさまざまな出力タイプのエクスポートまたはレンダリング オプションを通じて利用できます。

| 出力 | Ink オプション プロパティ |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| スライド画像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/#getInkOptions) |

次の [InkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/) メソッドは同じ 2 つの設定を公開します。

- [InkOptions.getHideInk](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#getHideInk) はインクオブジェクトを出力に含めるかどうかを決定します。デフォルトは `false` です。
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) はインクブラシをレンダリングするときにマスク操作を不透明度として解釈するかどうかを決定します。デフォルトは `true` です。`false` を渡して [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) を呼び出すと ROP 操作が使用されます。

### **PDF 出力でインクオブジェクトを非表示にする**

デフォルトではインクオブジェクトはエクスポート時に表示されます。手書き注釈やその他のインクコンテンツを除いたクリーンな出力を作成するには、`true` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#setHideInk) を呼び出します。

次の PHP サンプルはインクオブジェクトをすべて非表示にしてプレゼンテーションを PDF にエクスポートします。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **スライドを画像としてレンダリングする際にインクオブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際にインクオブジェクトを非表示にするには、[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/#getInkOptions) を設定し、レンダリング オプションを [Slide.getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage) に渡します。

次の PHP サンプルはインクオブジェクトを除いた PNG 画像として最初のスライドをレンダリングします。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **インクマスクのレンダリング制御**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 設定はインクブラシをレンダリングする際のマスク操作の解釈方法を制御します。デフォルトは `true`（不透明度使用）です。ROP 操作を使用するには、`false` を渡して [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) を呼び出します。

次の PHP サンプルはスライドを SVG にエクスポートし、インクマスク操作に ROP ベースのレンダリングを使用します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

同じ設定はプレゼンテーションを TIFF にエクスポートまたはスライドを TIFF にレンダリングする際に [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/#getInkOptions) を介して適用できます。

### **インクを非表示にするか保持するかの選択**

配布用のクリーンな注釈付きプレゼンテーションが必要な場合は、エクスポート時に `true` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#setHideInk) を呼び出します。

レビューコメント、手書きノート、ハイライト、描画など、インク注釈が意図したコンテンツの一部である場合は、[InkOptions.getHideInk](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#getHideInk) をデフォルトの `false` のままにしておきます。これにより、同じプレゼンテーションからソースのインクオブジェクトを変更せずに、レビュー用と最終版の出力を別々に生成できます。

## **FAQ**

**既存のインクストロークの色やサイズを変更できますか？**

はい。まず [Ink.getTraces](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ink/#getTraces) からトレースを取得し、[InkTrace.getBrush](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inktrace/#getBrush) を取得します。その後、[InkBrush.setColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkbrush/#setColor) または [InkBrush.setSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkbrush/#setSize) を呼び出してブラシを変更します。

**インクを非表示にすると元のプレゼンテーションが変更されますか？**

いいえ。 [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/php-java/aspose.slides/inkoptions/#setHideInk) を呼び出すと、レンダリングまたはエクスポート結果にのみ影響し、元のプレゼンテーション内のインクオブジェクトは削除も変更もされません。

**どのエクスポート形式がインクオプションをサポートしていますか？**

上表に示した PDF、HTML、SVG、TIFF、ビットマップ スライド画像でインクオプションを構成できます。

**さらに読む**

* シェイプ全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/ja/php-java/powerpoint-shapes/) セクションを参照してください。
* 有効なプロパティの詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/ja/php-java/shape-effective-properties/#get-effective-font-height-value) をご覧ください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/php-java/convert-powerpoint-to-pdf/) を参照してください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/php-java/convert-powerpoint-to-html/) を参照してください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/php-java/render-a-slide-as-an-svg-image/) を参照してください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/php-java/convert-powerpoint-to-tiff/) を参照してください。
* スライド画像レンダリングの詳細は、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/php-java/convert-slide/) を参照してください。