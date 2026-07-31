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
description: "プレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for Node.js を使用して PDF または画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換できる機能を提供し、Handout モードで印刷用の配布資料を作成することも可能です。このモードでは、複数のスライドを 1 ページにどのように配置するかを設定できるため、会議やセミナーなどのイベントで便利です。`setSlidesLayoutOptions` メソッドを使用して、[PdfOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/) 、[RenderingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/) 、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) 、および [TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラスでこのモードを有効にできます。

## **Handout モードのエクスポート**

Handout モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、Handout モードでプレゼンテーションを PDF に変換するコード例です。

```js
// プレゼンテーションをロードします。
let presentation = new asposeSlides.Presentation("sample.pptx");

// エクスポート オプションを設定します。
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 1ページに横方向に4枚のスライド
slidesLayoutOptions.setPrintSlideNumbers(true);                                // スライド番号を印刷
slidesLayoutOptions.setPrintFrameSlide(true);                                  // スライドの周囲にフレームを印刷
slidesLayoutOptions.setPrintComments(false);                                   // コメントなし

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式や画像としてレンダリングする場合にのみ利用可能です。
{{% /alert %}} 

## **FAQ**

**配布資料モードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handouttype/) により、横方向または縦方向の順序で最大 9 枚のサムネイルをページあたりにサポートします：1、2、3、4（横/縦）、6（横/縦）、9（横/縦）。

**5 枚や 8 枚など、独自のグリッドを定義できますか？**

できません。サムネイルの数と順序は、[HandoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**隠しスライドを配布資料に含めることはできますか？**

できます。対象フォーマットのエクスポート設定で `setShowHiddenSlides` メソッドを使用します。例えば、[PdfOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/) 、[HtmlOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/htmloptions/) 、または [TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) などです。