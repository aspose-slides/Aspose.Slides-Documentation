---
title: JavaScript でプレゼンテーションの Ink オブジェクトを管理する
linktitle: Ink の管理
type: docs
weight: 95
url: /ja/nodejs-java/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インク の管理
- インク を描く
- 描画
- インク エクスポート
- インク レンダリング
- インク を非表示にする
- InkOptions
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint のインク オブジェクトを管理し、トレースやブラシ プロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインクの外観を Aspose.Slides for Node.js を使用して制御します。"
---
## **はじめに**

PowerPoint は、自由な筆跡を描くことができる Ink 機能を提供します。Ink は、他のオブジェクトを強調したり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

Aspose.Slides は、Ink オブジェクトを操作するために必要な型を提供します。たとえば、[Ink](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ink/) クラスは、スライド上の Ink オブジェクトを表します。

## **通常オブジェクトと Ink オブジェクトの違い**

PowerPoint スライド上のオブジェクトは通常、シェイプ オブジェクトで表されます。最もシンプルな形では、シェイプはオブジェクト自体の領域（フレーム）を定義するコンテナであり、コンテナのサイズ、形状、背景などのプロパティを持ちます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/ja/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

ただし、PowerPoint が Ink オブジェクトを処理する場合、コンテナ（フレーム）のサイズ以外のすべてのプロパティを無視します。コンテナ領域のサイズは、標準の[Shape.getWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getWidth--) と[Shape.getHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getHeight--) メソッドで決定されます。

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink トレース**

Ink トレースは、ユーザーがデジタル インクで書く際のペンの軌跡を記録する基本要素です。トレースは、連続したポイントのシーケンスを保持します。

最もシンプルなエンコーディングは、各サンプルポイントの X および Y 座標を指定します。すべての接続ポイントが描画されると、次のような画像が生成されます。

![ink_powerpoint2](ink_powerpoint2.png)

## **線を描画するためのブラシ プロパティ**

ブラシは、Ink トレースのポイントを接続する線を描くために使用されます。ブラシは独自の色とサイズを持ち、[InkBrush.getColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkbrush/#getColor--) と[InkBrush.getSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkbrush/#getSize--) メソッドで表されます。

### **Ink ブラシの色を設定する**

この JavaScript コードは、Ink ブラシの色を設定する方法を示しています。

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Ink ブラシのサイズを設定する**

この JavaScript コードは、Ink ブラシのサイズを設定する方法を示しています。

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

一般に、ブラシの幅と高さは一致せず、PowerPoint はブラシ サイズを表示しません（対応するデータ セクションは灰色で表示されます）。ブラシの幅と高さが一致した場合、PowerPoint は次のようにサイズを表示します。

![ink_powerpoint3](ink_powerpoint3.png)

わかりやすくするために、Ink オブジェクトの高さを増やし、重要な寸法を確認します。

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮しません。常に線の太さを 0 と仮定します（前の画像を参照）。

したがって、Ink オブジェクト全体の可視領域を決定するには、トレースのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキスト トレース）がコンテナ（フレーム）のサイズに合わせてスケーリングされています。コンテナのサイズが変わっても、ブラシ サイズは一定のままであり、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキスト オブジェクトでも同様の動作を使用します。

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時の Ink の外観を制御する**

Aspose.Slides は、エクスポートまたはレンダリングされた出力で Ink オブジェクトの表示方法を制御するための [InkOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/) クラスを提供します。これらのプロパティを使用して、Ink を完全に非表示にしたり、Ink ブラシのマスク操作の解釈方法を変更したりできます。

Ink オプションは、複数の出力タイプのエクスポートまたはレンダリング オプションを介して利用できます。

| 出力 | Ink オプション プロパティ |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| スライド画像 | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

以下の [InkOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/) メソッドは、同じ 2 つの設定を公開します。

- [InkOptions.getHideInk](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#getHideInk--) は、Ink オブジェクトを出力に含めるかどうかを決定します。デフォルト値は `false` です。
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) は、Ink ブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。デフォルト値は `true` です。代わりに ROP 操作を使用するには、`false` を指定して [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出します。

### **PDF 出力で Ink オブジェクトを非表示にする**

デフォルトでは、エクスポート時に Ink オブジェクトは表示されたままです。手書きの注釈やその他の Ink コンテンツを除いたきれいな出力を作成するには、`true` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) を呼び出します。

次の JavaScript サンプルは、すべての Ink オブジェクトを非表示にした状態でプレゼンテーションを PDF にエクスポートします。

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **スライドを画像としてレンダリングする際に Ink オブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際に Ink オブジェクトを非表示にするには、[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) を構成し、レンダリング オプションを [Slide.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) に渡します。

次の JavaScript サンプルは、Ink オブジェクトなしで最初のスライドを PNG 画像としてレンダリングします。

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Ink マスクのレンダリングを制御する**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) 設定は、Ink ブラシをレンダリングする際にマスク操作がどのように解釈されるかを制御します。デフォルトは `true` で、不透明度として扱われます。代わりに ROP 操作を使用するには、`false` を指定して [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) を呼び出します。

次の JavaScript サンプルは、スライドを SVG にエクスポートし、Ink マスク操作に ROP ベースのレンダリングを使用します。

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

同じ設定は、プレゼンテーションをエクスポートしたりスライドを TIFF にレンダリングしたりする際に、[TiffOptions.getInkOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) を介して適用できます。

### **Ink を非表示にするか保持するかを選択する**

配布用に注釈付きプレゼンテーションのクリーン バージョンが必要な場合は、エクスポート時に `true` を指定して [InkOptions.setHideInk](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) を呼び出します。

Ink 注釈が意図されたコンテンツの一部である（レビュー コメント、手書きノート、ハイライト、描画など）場合は、[InkOptions.getHideInk](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#getHideInk--) をデフォルトの `false` のままにします。これにより、同じプレゼンテーションからソース Ink オブジェクトを変更せずに、レビュー用と最終版の出力を別々に生成できます。

## **FAQ**

**既存の Ink ストロークの色やサイズを変更できますか？**

はい。[Ink.getTraces](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ink/#getTraces--) でトレースを取得し、[InkTrace.getBrush](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inktrace/#getBrush--) を変更します。次に、[InkBrush.setColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) または [InkBrush.setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) を呼び出してブラシを変更します。

**Ink を非表示にしても元のプレゼンテーションは変更されますか？**

いいえ。[InkOptions.setHideInk](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) の呼び出しは、レンダリングまたはエクスポート結果にのみ影響し、ソース プレゼンテーション内の Ink オブジェクトを削除したり変更したりしません。

**どのエクスポート形式が Ink オプションをサポートしていますか？**

上記の表に示したように、PDF、HTML、SVG、TIFF、ビットマップ スライド画像のエクスポートまたはレンダリング時に Ink オプションを構成できます。

**さらに読む**

* 形状全般については、[PowerPoint Shapes](https://docs.aspose.com/slides/ja/nodejs-java/powerpoint-shapes/) セクションを参照してください。
* 有効な値の詳細については、[Shape Effective Properties](https://docs.aspose.com/slides/ja/nodejs-java/shape-effective-properties/#get-effective-font-height-value) を参照してください。
* PDF エクスポートの詳細は、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) を参照してください。
* HTML エクスポートの詳細は、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/nodejs-java/convert-powerpoint-to-html/) を参照してください。
* SVG エクスポートの詳細は、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) を参照してください。
* TIFF エクスポートの詳細は、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/nodejs-java/convert-powerpoint-to-tiff/) を参照してください。
* スライド画像へのレンダリングの詳細は、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/nodejs-java/convert-slide/) を参照してください。