---
title: JavaScript を使用したハンドアウトモードでの PowerPoint プレゼンテーションの変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "プレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Node.js 用 Aspose.Slides を使用して PDF または画像にエクスポートします。サンプルコード付き。無料で試せます。"
---
## **導入**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、Handout モードで印刷用のハンドアウトを作成することも可能です。このモードでは、1 ページに複数のスライドをどのように配置するかを構成でき、会議、セミナー、その他のイベントに便利です。`setSlidesLayoutOptions` メソッドを、[PdfOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/)、および [TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラスで設定することでこのモードを有効にできます。

エクスポート前にハンドアウトページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/nodejs-java/notes-size/) を参照してください。

## **ハンドアウトモードのエクスポート**

Handout モードを構成するには、1 ページに配置するスライド数やその他の表示パラメータを決定する [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。

以下は、Handout モードでプレゼンテーションを PDF に変換するコード例です。

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 1ページに横方向に4枚のスライド
slidesLayoutOptions.setPrintSlideNumbers(true);                                // スライド番号を印刷
slidesLayoutOptions.setPrintFrameSlide(true);                                  // スライドの周囲にフレームを印刷
slidesLayoutOptions.setPrintComments(false);                                   // コメントなし

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **FAQ**

**Handout モードで 1 ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handouttype/) をサポートしており、横または縦方向の並びで最大 9 枚のサムネイルを 1 ページに配置できます。利用できるプリセットは、横/縦方向の 1、2、3、4、6、9 です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**Handout の出力に非表示スライドを含めることはできますか？**

はい。対象形式のエクスポート設定で `setShowHiddenSlides` メソッドを使用します。たとえば、[PdfOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) です。