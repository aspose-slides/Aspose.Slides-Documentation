---
title: JavaでプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドからSVG
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

SVG はスケーラブルな XML ベースの画像形式で、Web 公開、スライドビューア、アクセシビリティのワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成し、スライドを選択して、[ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) を使用してストリームに書き込みます。以下の例は、プレゼンテーション内の各スライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) を使用します。スライドビューアや Web ページで特定のシェイプだけが必要な場合は、[IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) はフレーム回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) を `true` に設定します。

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

## **矢尻でのラインエンドクロッピングの制御**

SVG 1.1 には、矢尻の下でラインが停止すべき位置を指定するマーカーインセット設定がありません。既定では、Aspose.Slides はエクスポートされたラインを短くし、ストロークがマーカーを突き抜けないようにします。[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) を `true` に設定すると、ストロークがラインの元の終点まで描画されます。この設定は SVG 出力にのみ影響し、スライド上のラインの位置と長さは保持されます。

この例では、太さ 2 ポイントと 10 ポイントのラインに三角形と菱形の矢尻を描画します。同じスライドを 2 回エクスポートし、クロッピングオプションだけを変更します。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

比較では、10 ポイントのライン上の三角形矢尻が示されています。クロッピングを有効にすると、先端が鋭くなります。クロッピングを無効にすると、ストロークがマーカーの斜め側面を突き抜け、平らな終端になります。

![クロッピング有効時に先端が鋭い拡大された 10 ポイント三角形、クロッピング無効時に平らな端](line-end-cropping.png)

例の他のラインでは、2 ポイントの三角形では突き出したストロークが目立ちにくくなります。塗りつぶされた菱形は、両幅でストロークの終端を覆います。

## **テキストとフォントの制御**

スライドを SVG にエクスポートする際、テキストをテキストのままに保持するかベクターグラフィックに変換するか、外部フォントをどのように組み込むまたは参照するかを制御できます。以下のオプションは、エクスポートされた SVG の視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタライズ**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) を `true` に設定すると、スライドのすべてのテキストがベクターグラフィックとして書き出されます。これによりフォント依存性が排除され、ブラウザ間での視覚結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) は、外部で読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照となり、`Embed` を選択するとフォントデータが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストのみがグラフィックとしてレンダリングされます。フォントを埋め込む前にライセンスを確認してください。

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

## **埋め込み画像サイズの縮小**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) で切り取られた元画像領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度または保持された画像データを犠牲にしてファイルサイズを縮小します。

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

## **メタファイルのラスタライズ解像度の制御**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) は SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF や WMF 画像がラスタライズされるときに詳細とファイルサイズのバランスを取るために使用します。これは SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトをラスタ画像に強制変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このファイルには密に配置された対角線を持つ EMF 画像が含まれています。以下の例では、[ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) を使用して最初のスライドを 3 つのラスタライズ解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できます。

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

出力では、EMF が各 SVG に埋め込まれた PNG に変換されました。以下の測定値は提供されたプレゼンテーションのもので、 DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG のサイズ | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、同じ拡大表示サイズで埋め込みラスタ画像の同一領域を示しています。対角線は 72 DPI でピクセル化が目立ち、高解像度ではより滑らかなエッジになりますが、SVG ファイルは大きくなります。値を上げてもすべてのディテールが向上したり、すべてのエクスポート画像が変わるわけではありません。

![72、150、300 DPI で拡大された対角線の詳細](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) は画像解像度の低減を制御し、メタファイルのラスタライズ解像度変更の影響を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) は JPEG エンコード品質を制御し、メタファイルのラスタライズ解像度は制御しません。

## **シェイプとテキストに安定した ID を割り当てる**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) を使用して、各 SVG シェイプに対して [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) を設定します。テキスト `tspan` 要素にも [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) の値を設定するには、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) を実装します。[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) でいずれかのコントローラを割り当てます。

以下のコントローラは、シェイプの存続期間中安定した [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) と、テキストスパン用の繰り返し可能なカウンタを使用します。これにより、生成された ID は変更されていないプレゼンテーションのポストプロセッシングに適したものになります。

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) 内で、[SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) の値を使用して [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) を呼び出すことで、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) でコントローラを割り当て、結果をホストするページまたは SVG 文書内で JavaScript 関数を定義します。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) の代わりに使用すべきタイミングは？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) はすべてのテキストをフォントに依存しないようにしたいときに使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) は外部フォントを使用するテキストのみをグラフィックに変換したいときに使用します。

**SVG を小さくするベストな方法は何ですか？**

まず埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で配信可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、ベクタライズされたテキストはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマットコントローラを通じて ID を割り当て、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択してください。