---
title: JavaScript でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドを SVG に変換
type: docs
weight: 50
url: /ja/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーションを SVG に変換
- スライドを SVG に変換
- PPT を SVG に変換
- PPTX を SVG に変換
- SVG エクスポートオプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PowerPoint のスライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVGは、スケーラブルなXMLベースの画像フォーマットで、Web公開、スライドビューア、アクセシビリティワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides for Node.js via Javaは各スライドを個別のSVGファイルにエクスポートし、テキスト、フォント、画像、SVG要素の書き出し方法を制御できます。

エクスポートされたSVGがコンパクトで、ブラウザ間で予測可能、またはインタラクティブに使用できる必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) を使用します。

## **スライドをSVGとしてエクスポート**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、スライドを選択して、[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) でストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別のSVGファイルとしてエクスポートします。

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

ファイル名はループインデックスではなく [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) を使用します。また、スライドビューアやウェブページが特定のシェイプだけを必要とする場合は、[Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) で個々のシェイプをエクスポートすることもできます。

## **SVG出力の構成**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) はSVGのレンダリングを制御します。テキストフレームの場合、[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) はレンダリング領域にテキストフレームを含め、[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) はフレームの回転が適用されるかどうかを決定します。テキストをリガチャなしでレンダリングする必要がある場合は、[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) を `true` に設定します。

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

スライドをSVGにエクスポートする際、テキストをテキストのまま保持するかベクターグラフィックに変換するか、外部フォントをどのように含めるか、参照するかを制御できます。以下のオプションは、エクスポートされたSVGにおける視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクター化**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を `true` に設定すると、すべてのスライドテキストがベクターグラフィックとして書き出されます。これによりフォント依存性がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストはSVGテキストとして選択や検索ができなくなります。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると別々のフォントファイルへの参照が作成され、`Embed` を選択するとフォントデータがSVGに含まれ、`Vectorize` を選択すると外部フォントを使用するテキストのみがグラフィックとしてレンダリングされます。フォントを埋め込む前に、フォントのライセンスを確認してください。

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) でクロップされた元領域を省略し、[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

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

## **メタファイルラスタライズ解像度の制御**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) は、SVGエクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF または WMF 画像がラスタライズされる際のディテールとファイルサイズのバランスを取るために使用します。これは SVG 全体の DPI を定義するものでも、スライド上のすべてのオブジェクトをラスタ画像に変換するものでもありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。この文件には、間隔の狭い対角線を持つ EMF 画像が含まれています。以下の例は、[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) を使用して最初のスライドを 3 つのラスタライズ解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できるようにしています。

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

出力では、EMF が各 SVG に埋め込まれた PNG に変換されています。以下の測定値は提供されたプレゼンテーションに対するものであり、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタライズ DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ（バイト） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、拡大表示サイズが同じで埋め込みラスタの同一エリアを示しています。対角線は 72 DPI でピクセル化が目立ち、解像度が高くなるにつれてエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げてもすべてのディテールが向上したり、すべてのエクスポート画像が変わるわけではありません。

![72、150、300 DPI の拡大対角線ディテール](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) は画像解像度の低減を制御し、メタファイルのラスタライズ解像度変更の影響を隠すことがあります。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) は JPEG エンコード品質を制御し、メタファイルのラスタライズ解像度を制御するものではありません。

## **シェイプとテキストに安定した ID を割り当て**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) にフォーマッティングコントローラを渡して、各 SVG シェイプに対して [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) を設定します。テキストスパンも扱うコントローラは、テキスト `tspan` 要素に対して [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) の値を設定できます。

以下のコントローラは [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) を使用します。この ID はシェイプの存続期間中安定しており、テキストスパンには再利用可能なカウンタを使用します。これにより生成された ID は、変更されていないプレゼンテーションのポストプロセッシングに適しています。

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

## **SVG イベントハンドラを追加**

フォーマッティングコントローラ内で、[SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) でコントローラを割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義してください。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ向上、その他のインタラクティブ SVG ワークフローが可能になります。

## **FAQ**

**いつ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を使用すべきで、[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) を使用すべきではないですか？**

すべてのテキストがフォントに依存しない必要がある場合は [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) を使用します。外部フォントを使用するテキストのみをグラフィックに変換すべき場合は [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) を使用します。

**SVG を小さくする最善の方法は何ですか？**

まず、埋め込み画像を圧縮し、クロップされた画像領域を削除し、対象環境で配信可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクター化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコントローラで ID を割り当て、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択してください。