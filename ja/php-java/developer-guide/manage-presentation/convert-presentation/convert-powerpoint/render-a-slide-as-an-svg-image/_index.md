---
title: PHPでプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
- PPT から SVG へ
- PPTX から SVG へ
- SVG エクスポート オプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHPでPowerPointスライドをSVG画像としてエクスポートし、フォント、テキスト、画像、ID、イベントをAspose.Slidesで制御します。"
---
## **概要**

SVG は、ウェブ公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適した、スケーラブルな XML ベースの画像形式です。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、および SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブに使用できる必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポートする**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) でストリームに書き込みます。次の例はプレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

ファイル名はループインデックスではなく [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) を使用しています。スライドビューアやウェブページが特定の形状だけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) を使用して個々の形状をエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキスト フレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) はテキスト フレームを描画領域に含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) はフレーム回転が適用されるかを決定します。テキストを合字なしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **矢じりでのライン端トリミングの制御**

SVG 1.1 には、ラインが矢じりの下で止まる位置を指定するマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされたラインを短くして、ストロークがマーカーを突き抜けないようにします。[SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) を `true` に設定すると、ストロークは元のエンドポイントまで描画されます。この設定は SVG 出力のみに影響し、スライド上のラインの位置と長さは変わりません。

この例は、太さ 2 ポイントと 10 ポイントのラインに三角形とダイヤモンドの矢じりを描画します。同じスライドを 2 回エクスポートし、トリミング オプションだけを変更しています。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

比較では、10 ポイントのライン上にある三角形矢じりが示されています。トリミングが有効な場合、先端は鋭くなります。トリミングが無効な場合、ストロークがマーカーの斜めの側面を突き抜けて平らな端になります。

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

他の例のラインでは、2 ポイントの三角形では突出したストロークが目立ちにくくなります。塗りつぶしダイヤモンドは、幅がいずれでもストロークの端を覆います。

## **テキストとフォントの制御**

スライドを SVG にエクスポートする際、テキストをテキストとして保持するかベクター画像に変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。以下のオプションは、エクスポートされた SVG の視覚的一貫性、テキスト選択、およびフォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタライズする**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を `true` に設定すると、すべてのスライドテキストがベクター グラフィックとして書き込まれます。これによりフォント依存性がなくなり、ブラウザ間で視覚結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **外部フォントの取り扱い方法を選択する**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォント ファイルへの参照が作成され、`Embed` を選択するとフォント データが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストだけがグラフィックとして描画されます。埋め込み前にフォント ライセンスを必ず確認してください。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **埋め込み画像サイズの縮小**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り取られた領域を省き、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御します。これらの設定は画像の忠実度や保持データと引き換えにファイル サイズを縮小します。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **メタファイル ラスタライズ解像度の制御**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) は、SVG エクスポート時にメタファイルをラスタライズする下限解像度を設定します。EMF や WMF 画像をラスタライズする際の詳細度とファイル サイズのバランスに使用します。これは SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトをラスタ画像に変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このプレゼンテーションには、間隔の狭い対角線を含む EMF 画像が含まれています。次の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) を使用して、最初のスライドを 3 つのラスタライズ解像度でエクスポートします。その他のエクスポート設定はすべて同一に保ち、結果を比較できるようにしています。

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

出力では、EMF が各 SVG に埋め込まれた PNG に変換されています。以下の測定値は添付のプレゼンテーションに基づくもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下の比較は、同じ領域の埋め込みラスタを同じ拡大表示サイズで示しています。対角線は 72 DPI で目に見えるピクセル化が発生し、解像度が上がるほどエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げてもすべてのディテールが改善したり、すべてのエクスポート画像が変わるわけではありません。

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) は画像解像度の低減を制御し、メタファイル ラスタライズ解像度の変更効果を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) は JPEG エンコード品質を制御し、メタファイル ラスタライズ解像度には影響しません。

## **形状とテキストに安定した ID を割り当てる**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) にフォーマット コールバックを提供し、各 SVG 形状に対して [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) を設定します。コールバックはテキスト `tspan` 要素の [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) も設定できます。

PhpJavaBridge はストリーム モードで実行中に `writeAsSvg` から PHP コールバックを呼び出せません。フォーマット ロジックを小さな Java ヘルパー クラスに入れ、コンパイルして生成された JAR をブリッジのクラスパスに追加してください。ヘルパーは [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) を使用でき、これは形状の存続期間中に安定しており、テキスト スパン用に繰り返し可能なカウンタを使用できます。ヘルパー コードの例は [Java implementation of `StableSvgIdController`](/slides/ja/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) を参照してください。

コンパイル済みの `com.example.slides.StableSvgIdController` クラスをブリッジのクラスパスに追加した後、PHP からインスタンス化し、`SVGOptions` に割り当てます。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG イベント ハンドラの追加**

フォーマット コールバック内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) の値を渡して、エクスポートされた形状に JavaScript イベント ハンドラを追加します。コールバックは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定し、結果をホストするページまたは SVG ドキュメントで JavaScript 関数を定義してください。

安定した ID と同様に、PhpJavaBridge がストリーム モードを使用する場合は Java ヘルパーでコールバックを実装します。[Java implementation of `SvgEventController`](/slides/ja/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) は `ActionButton` という名前の形状に ID と `OnClick` ハンドラを割り当てます。そのヘルパーをコンパイルし、ブリッジのクラスパスに `com.example.slides.SvgEventController` として追加し、以下のように PHP から使用します。

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

ホスト ページはハンドラが参照する JavaScript 関数を定義できます。ID とイベント ハンドラを割り当てることで、スライド ビューア、アクセシビリティ強化、およびその他のインタラクティブ SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) の代わりに使用すべきタイミングはいつですか？**

すべてのテキストをフォントに依存せずにしたい場合は [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) を使用してください。

**SVG を小さくする最良の方法は何ですか？**

まず埋め込み画像を圧縮し、切り取られた画像領域を削除し、環境が提供できる場合はフォント ファイルへのリンクを使用します。画像解像度の低下、JPEG 品質の低下、テキストのベクタライズはそれぞれ品質とサイズのトレードオフが異なるため、結果を必ずテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマット コールバックで ID を割り当てた後、ポストプロセッシング ツールやブラウザ スクリプトで該当する SVG 要素を選択して変更できます。