---
title: JavaScriptでプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドをSVGに変換
type: docs
weight: 50
url: /ja/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーション を SVG に変換
- スライド を SVG に変換
- PPT を SVG に変換
- PPTX を SVG に変換
- SVG エクスポート オプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScriptでPowerPointスライドをSVG画像としてエクスポートし、フォント、テキスト、画像、ID、イベントをAspose.Slidesで制御します。"
---
## **概要**

SVG は、Web 公開、スライド ビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適した、スケーラブルな XML ベースの画像フォーマットです。Aspose.Slides for Node.js via Java は、各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに、ブラウザ間で予測可能に、またはインタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/writeassvg/) でストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく、[Slide.getSlideNumber](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/getslidenumber/) を使用します。また、スライドビューアやウェブページが特定の形状だけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/writeassvg/) を使用して個別の形状をエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setuseframesize/) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) はフレームの回転を適用するかどうかを決定します。テキストを合字なしでレンダリングする必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

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

## **テキストとフォントの制御**

### **すべてのテキストをベクトル化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を `true` に設定すると、スライドのすべてのテキストがベクトルグラフィックスとして書き出されます。これによりフォントへの依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

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

### **外部フォントの処理方法を選択**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照が作成され、`Embed` を選択するとフォントデータが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストのみがグラフィックとしてレンダリングされます。フォントを埋め込む前にライセンスを確認してください。

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) で切り抜かれた元領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setjpegquality/) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

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

## **形状とテキストに安定した ID を割り当てる**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) にフォーマットコントローラを渡すことで、各 SVG 形状に対して [SvgShape.setId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgshape/setid/) を設定できます。テキストスパンも処理するコントローラは、テキスト `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgtspan/setid/) の値を設定できます。

以下のコントローラは、形状の存続期間中に安定した [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) と、テキストスパン用の再現可能なカウンタを使用します。これにより、生成された ID が変更されていないプレゼンテーションのポストプロセスに適したものになります。

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

フォーマットコントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgevent/) の値を渡すことで、エクスポートされた形状に JavaScript イベントハンドラを追加できます。[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) でコントローラを割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義します。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティの向上、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgexternalfontshandling/) の代わりに使用すべきタイミングは？**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) は、すべてのテキストがフォントに依存しない必要がある場合に使用します。[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgexternalfontshandling/) は、外部フォントを使用するテキストのみをグラフィックに変換したい場合に使用します。

**SVG を小さくする最善の方法は何ですか？**

まずは埋め込み画像を圧縮し、切り抜かれた画像領域を削除し、対象環境で提供できる場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、ベクトル化されたテキストはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマットコントローラで ID を割り当てた後、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択できます。