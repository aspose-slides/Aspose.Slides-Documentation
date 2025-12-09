---
title: JavaScript でハンドアウトモードでプレゼンテーションを変換する
type: docs
weight: 150
url: /ja/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint を変換
- ハンドアウトモード
- ハンドアウト
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript でハンドアウトモードでプレゼンテーションを変換する"
---

## **ハンドアウトモードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントで便利です。`setSlidesLayoutOptions` メソッドを設定することで、このモードを有効にできます。対象のクラスは [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) です。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```js
// プレゼンテーションを読み込みます。
let presentation = new asposeSlides.Presentation("sample.pptx");

// エクスポートオプションを設定します。
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 横向きに1ページに4枚のスライド
slidesLayoutOptions.setPrintSlideNumbers(true);                                // スライド番号を印刷
slidesLayoutOptions.setPrintFrameSlide(true);                                  // スライドの周囲にフレームを印刷
slidesLayoutOptions.setPrintComments(false);                                   // コメントはなし

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **FAQ**

**Handoutモードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[プリセット](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) をサポートしており、水平または垂直の順序で 1 ページあたり最大 9 つのサムネイルを配置できます。利用できる設定は 1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）です。

**5枚または8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。対象の形式（例: [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/)）のエクスポート設定で `setShowHiddenSlides` メソッドを使用します。