---
title: JavaScript でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVGは、Web公開、スライドビューア、アクセシビリティワークフロー、そして自動ポストプロセッシングに適した、拡張性のあるXMLベースの画像フォーマットです。Aspose.Slides for Node.js via Javaは各スライドを個別のSVGファイルにエクスポートし、テキスト、フォント、画像、SVG要素の書き出し方法を制御できます。

エクスポートされたSVGをコンパクトに保ち、ブラウザ間で予測可能にし、インタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/)を使用します。

## **スライドをSVGとしてエクスポート**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) でストリームに書き出します。以下の例は、プレゼンテーション内のすべてのスライドを個別のSVGファイルとしてエクスポートします。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

ファイル名はループインデックスではなく[Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) を使用しています。スライドビューアやWebページが特定のシェイプだけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) を使用して個々のシェイプをエクスポートすることもできます。

## **SVG出力の構成**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) はSVGのレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) はフレームの回転を適用するかどうかを決定します。テキストを合字なしで描画する必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **矢じりでの線端クロッピングの制御**

SVG 1.1 には、矢じりの下で線を停止させる位置を指定するマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされた線を短くし、ストロークがマーカーを突き抜けないようにします。[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) を `true` で呼び出すと、ストロークが線の元の終点まで描画されます。この設定は SVG の出力にのみ影響し、スライド上の線の位置と長さは保持されます。

この例は、太さ2ポイントと10ポイントの線に三角形とダイヤモンドの矢じりを描画します。同じスライドを2回エクスポートし、クロッピングオプションだけを変更しています。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

比較は、10ポイントの線上の三角形の矢じりを示しています。クロッピングが有効なときに鋭い先端を持つ拡大された10ポイントの三角形、クロッピングが無効なときに平坦な端部

![クロッピングが有効なときに鋭い先端を持つ拡大された10ポイントの三角形、クロッピングが無効なときに平坦な端部](line-end-cropping.png)

例の他の線では、2ポイントの三角形では突き抜けるストロークが目立ちにくくなります。塗りつぶされたダイヤモンドは、両方の太さでストロークの端部を覆います。

## **テキストとフォントの制御**

スライドをSVGにエクスポートする際、テキストをテキストのまま保持するかベクターグラフィックに変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。以下のオプションは、エクスポートされたSVGにおける視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクトル化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を `true` に設定すると、スライドのすべてのテキストがベクターグラフィックとして書き出されます。これによりフォント依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストはSVGテキストとして選択や検索ができなくなります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **外部フォントの取り扱い方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへのリンクを参照し、`Embed` でフォントデータをSVGに埋め込み、`Vectorize` で外部フォントを使用するテキストのみをグラフィックとしてレンダリングします。フォントを埋め込む前にライセンスを確認してください。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **埋め込み画像サイズの削減**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) で切り取られた元領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) でJPEGエンコード品質を制御します。これらの設定は、画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **メタファイルのラスター化解像度の制御**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) は、SVGエクスポート時にメタファイルをラスター化する際の下限解像度を設定します。EMF または WMF 画像をラスター化する際の詳細度とファイルサイズのバランスを取るのに使用します。これは SVG の全体 DPI を定義したり、スライド上のすべてのオブジェクトをラスター画像に変換したりはしません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。これは、間隔の狭い対角線を持つEMF画像を含みます。以下の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) を使用して最初のスライドを3つのラスター化解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できます。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

出力では、EMF が各SVGに1つの埋め込みPNGに変換されています。以下の測定値は提供されたプレゼンテーションに対するもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスター化 DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、拡大表示サイズを同一にした埋め込みラスターの同じ領域を示しています。対角線は 72 DPIで目に見えるピクセル化が発生し、解像度が高くなるほど滑らかなエッジになりますが、SVG ファイルは大きくなります。値を上げても必ずしもすべてのディテールが改善したり、すべてのエクスポート画像が変化したりするわけではありません。

![72、150、300 DPIで拡大された対角線のディテール](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) は画像解像度の削減を制御し、メタファイルのラスター化解像度の変更による影響を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) は JPEG エンコード品質を制御し、メタファイルのラスター化解像度は制御しません。

## **シェイプとテキストに安定した ID を割り当てる**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) に書式設定コントローラを渡すことで、各 SVG シェイプに対して [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) を設定できます。テキストスパンも処理するコントローラは、テキストの `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) の値を設定できます。

以下のコントローラは、シェイプの存続期間中安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) と、テキストスパン用の繰り返し可能なカウンタを使用します。これにより、生成された ID は変更されていないプレゼンテーションの後処理に適します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG イベントハンドラの追加**

書式設定コントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) でコントローラを割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義してください。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティの強化、その他のインタラクティブな SVG ワークフローが可能になります。

## **よくある質問**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) の代わりに使用すべきタイミングは？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) はテキストをフォントに依存させたくない場合に使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) は外部フォントを使用するテキストだけをグラフィックに変換したいときに使用します。

**SVG を小さくする最善の方法は何ですか？**

まず、埋め込み画像の圧縮、切り取られた画像領域の削除、そして対象環境が提供可能な場合はリンクされたフォントファイルを選択してください。結果をテストしてください。画像解像度の低下、JPEG 品質の低下、テキストのベクトル化はそれぞれ品質とサイズのトレードオフがあります。

**エクスポート後に SVG 要素を変更できますか？**

はい。書式設定コントローラで ID を割り当て、ポストプロセスツールやブラウザスクリプトで対応する SVG 要素を選択してください。