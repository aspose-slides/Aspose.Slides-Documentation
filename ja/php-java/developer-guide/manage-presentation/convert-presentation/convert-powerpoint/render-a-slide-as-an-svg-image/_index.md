---
title: PHPでプレゼンテーション スライドをSVG画像としてレンダリング
linktitle: スライドをSVGへ
type: docs
weight: 50
url: /ja/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPointからSVGへ
- プレゼンテーションからSVGへ
- スライドからSVGへ
- PPTからSVGへ
- PPTXからSVGへ
- SVGエクスポート オプション
- インタラクティブSVG
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHPでPowerPointスライドをSVG画像としてエクスポートし、Aspose.Slidesを使用してフォント、テキスト、画像、ID、イベントを制御します。"
---
## **概要**

SVG はスケーラブルな XML ベースの画像形式で、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトにし、ブラウザ間で予測可能にし、またはインタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) でストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループ インデックスではなく [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) を使用します。スライドビューアや Web ページで特定の形状だけが必要な場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) を使用して個別の形状をエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキスト フレームについては、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) がレンダリング領域にテキスト フレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) がフレーム回転の適用有無を決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

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

スライドを SVG にエクスポートする際、テキストをテキストのまま保持するかベクタ画像に変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。以下のオプションは、エクスポートされた SVG の視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタ化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を `true` に設定すると、スライド上のすべてのテキストがベクタ グラフィックとして書き出されます。これによりフォント依存がなくなり、ブラウザ間での視覚的な結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

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

### **外部フォントの取り扱い方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) は、外部からロードされるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォント ファイルへの参照となり、`Embed` を選択するとフォント データが SVG に組み込まれ、`Vectorize` を選択すると外部フォントを使用するテキストだけがグラフィックとして描画されます。フォントを組み込む前にライセンスを確認してください。

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) で切り取られた元領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持データとのトレードオフでファイル サイズを削減します。

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) は、SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF や WMF 画像がラスタライズされる際のディテールとファイル サイズのバランスを取るために使用します。これは SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトを必ずラスタ画像に変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。これには対角線が密に並んだ EMF 画像が含まれています。以下の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) を使用して、最初のスライドを 3 つのラスタライズ解像度でエクスポートします。その他のエクスポート設定はすべて同一に保たれているため、結果を比較できます。

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

出力では、EMF が各 SVG に埋め込まれた PNG に変換されています。以下の測定値は提供されたプレゼンテーションに基づくもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG の寸法 | SVG ファイル サイズ（バイト） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、同じ拡大表示サイズで埋め込みラスタの同一領域を示しています。対角線は 72 DPI で目に見えるピクセル化が発生し、解像度が上がるほど滑らかなエッジになりますが、SVG ファイルは大きくなります。値を上げてもすべてのディテールが必ず向上するわけでも、すべてのエクスポート画像が変わるわけでもありません。

![拡大された対角線のディテール（72、150、300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) は画像解像度の低減を制御し、メタファイル ラスタライズ解像度の変更効果を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) は JPEG エンコード品質を制御し、メタファイル ラスタライズ解像度とは無関係です。

## **形状とテキストに安定した ID を割り当てる**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) にフォーマッティング コールバックを提供し、各 SVG 形状に対して [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) を設定します。このコールバックは、テキスト `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) の値を設定することもできます。

PhpJavaBridge は `writeAsSvg` がストリーム モードで実行されるときに PHP コールバックを呼び出すことができません。フォーマッティング ロジックを小さな Java ヘルパークラスに入れ、コンパイルして生成された JAR をブリッジのクラスパスに追加してください。ヘルパーは [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) を使用できます。この ID は形状の存続期間中安定しており、テキスト スパン用に繰り返し可能なカウンタを併用します。ヘルパーコードは [Java implementation of `StableSvgIdController`](/slides/ja/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) を参照してください。

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

フォーマッティング コールバック内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) に [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) の値を渡すことで、エクスポートされた形状に JavaScript イベント ハンドラを追加します。コールバックは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) で設定し、結果をホストするページまたは SVG ドキュメント内に JavaScript 関数を定義してください。

安定した ID と同様に、PhpJavaBridge がストリーム モードを使用する場合は Java ヘルパーでコールバックを実装します。[Java implementation of `SvgEventController`](/slides/ja/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) は、`ActionButton` という名前の形状に ID と `OnClick` ハンドラを割り当てます。そのヘルパーをコンパイルし、ブリッジのクラスパスに `com.example.slides.SvgEventController` として追加し、PHP から以下のように使用します：

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

ホスト ページはハンドラが参照する JavaScript 関数を定義できます。ID とイベント ハンドラを割り当てることで、スライド ビューア、アクセシビリティ機能、その他のインタラクティブ SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) の代わりに使用すべきタイミングは？**

すべてのテキストをフォントに依存しない形で保持したい場合は [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) を使用してください。

**SVG を小さくする最良の方法は？**

まず埋め込み画像を圧縮し、切り取られた画像領域を削除し、ターゲット環境で配信可能な場合はリンクされたフォント ファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクタ化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を修正できますか？**

はい。フォーマッティング コールバックで ID を割り当て、その ID を使用してポストプロセッシング ツールやブラウザ スクリプトで該当する SVG 要素を選択できます。