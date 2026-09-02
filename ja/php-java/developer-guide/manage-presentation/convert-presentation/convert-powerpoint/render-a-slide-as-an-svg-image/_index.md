---
title: PHP でプレゼンテーションスライドを SVG 画像としてレンダリング
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
- SVG エクスポートオプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: PHP で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。
---
## **概要**

SVG は、スケーラブルな XML ベースの画像フォーマットで、ウェブ公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き込み方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブな使用に適している必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#writeAsSvg) でストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[Slide.getSlideNumber](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getSlideNumber) を使用します。また、スライドビューアやウェブページで特定のシェイプだけが必要な場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#writeAsSvg) で個々のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setUseFrameSize) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setUseFrameRotation) はフレームの回転を適用するかどうかを決定します。テキストを合字なしでレンダリングする必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

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

## **テキストとフォントの制御**

### **すべてのテキストをベクトル化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setVectorizeText) を `true` に設定すると、すべてのスライドテキストがベクトルグラフィックとして書き込まれます。これによりフォント依存がなくなり、ブラウザ間で視覚結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

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

### **外部フォントの処理方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部で読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照が作成され、`Embed` ではフォントデータが SVG に埋め込まれ、`Vectorize` では外部フォントを使用するテキストのみがグラフィックとしてレンダリングされます。フォントを埋め込む前にライセンスを確認してください。

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

## **埋め込み画像サイズの削減**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り抜かれた元領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保存データを犠牲にしてファイルサイズを削減します。

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

## **シェイプとテキストに安定した ID を割り当て**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setShapeFormattingController) にフォーマットコールバックを提供して、各 SVG シェイプの [SvgShape.setId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgshape/#setId) を設定します。このコールバックはテキストの `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgtspan/#setId) の値も設定できます。

PhpJavaBridge はストリームモードで実行中に `writeAsSvg` から PHP コールバックを呼び出すことができません。フォーマットロジックを小さな Java ヘルパークラスに入れ、コンパイルして生成された JAR ファイルをブリッジのクラスパスに追加します。ヘルパーはシェイプの存続期間中安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getOfficeInteropShapeId) を使用し、テキストスパン用に繰り返し可能なカウンタを使用できます。ヘルパーコードは [Java implementation of `StableSvgIdController`](/slides/ja/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) を参照してください。

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

## **SVG イベントハンドラの追加**

フォーマットコールバック内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コールバックは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setShapeFormattingController) で割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義します。

安定した ID と同様に、PhpJavaBridge がストリームモードを使用している場合はコールバックを Java ヘルパーで実装します。[Java implementation of `SvgEventController`](/slides/ja/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) は `ActionButton` という名前のシェイプに ID と `OnClick` ハンドラを割り当てます。そのヘルパーをコンパイルし、ブリッジのクラスパスに `com.example.slides.SvgEventController` として追加し、以下のように PHP から使用します：

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ機能、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**いつ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setVectorizeText) を使用し、[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgexternalfontshandling/) を使用すべきではないのでしょうか？**

すべてのテキストがフォントに依存しない必要がある場合は [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/#setVectorizeText) を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgexternalfontshandling/) を使用します。

**SVG を小さくする最適な方法は何ですか？**

まず埋め込み画像を圧縮し、切り抜かれた画像領域を削除し、ターゲット環境で提供できる場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、ベクトル化テキストはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコールバックで ID を割り当てた後、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択して変更できます。