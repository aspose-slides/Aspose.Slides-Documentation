---
title: JavaでプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドをSVGに変換
type: docs
weight: 50
url: /ja/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPointからSVGへ
- プレゼンテーションからSVGへ
- スライドからSVGへ
- PPTからSVGへ
- PPTXからSVGへ
- SVGエクスポートオプション
- インタラクティブSVG
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "JavaでPowerPointスライドをSVG画像としてエクスポートし、フォント、テキスト、画像、ID、イベントをAspose.Slidesで制御します。"
---
## **概要**

SVG は、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適した、スケーラブルな XML ベースの画像フォーマットです。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに保ち、ブラウザ間で予測可能にし、インタラクティブな利用ができるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を作成し、スライドを選択して、[ISlide.writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) を使用してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

ファイル名はループインデックスではなく、[ISlide.getSlideNumber](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getSlideNumber--) を使用します。また、スライドビューアや Web ページが特定のシェイプだけを必要とする場合は、[IShape.writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) を使用して個々のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) はフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) を `true` に設定します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **テキストとフォントの制御**

### **すべてのテキストをベクタライズ**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) を `true` に設定すると、すべてのスライドテキストがベクタ画像として書き出されます。これによりフォント依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **外部フォントの取り扱い方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照が作成され、`Embed` を選択すると SVG にフォントデータが埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストだけがグラフィックとして描画されます。フォントを埋め込む前に、ライセンスを確認してください。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **埋め込み画像サイズの削減**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) で切り取られた元領域を除外し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) で JPEG エンコード品質を制御します。これらの設定により、画像の忠実度や保持データを犠牲にしてファイルサイズを削減できます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **シェイプとテキストに安定した ID を割り当てる**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgshapeformattingcontroller/) を使用して各 SVG シェイプに対し [ISvgShape.setId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) を設定します。テキスト `tspan` 要素にも [ISvgTSpan.setId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) を設定したい場合は、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) を実装します。いずれのコントローラも [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) で割り当てます。

以下のコントローラは [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) を使用します。この ID はシェイプの存続期間中安定しており、テキストスパンには繰り返し可能なカウンタを使用します。これにより、生成された ID は変更されていないプレゼンテーションのポストプロセスに適しています。

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **SVG イベントハンドラの追加**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgshapeformattingcontroller/) 内で、[ISvgShape.setEventHandler](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) に [SvgEvent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) で割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義します。

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティの向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**いつ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgexternalfontshandling/) の代わりに使用すべきですか？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) は、すべてのテキストをフォントに依存しないようにする必要がある場合に使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgexternalfontshandling/) は、外部フォントを使用するテキストのみをグラフィックに変換したい場合に使用します。

**SVG を小さくする最善の方法は何ですか？**

まず、埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で提供できる場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、ベクタライズされたテキストはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコントローラで ID を割り当てた後、ポストプロセスツールやブラウザスクリプトで該当する SVG 要素を選択できます。