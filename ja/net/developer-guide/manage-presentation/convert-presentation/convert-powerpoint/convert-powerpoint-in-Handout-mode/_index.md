---
title: "C# でハンドアウトモードのプレゼンテーションを変換"
type: docs
weight: 150
url: /ja/net/convert-powerpoint-in-Handout-mode/
keywords:
- "PowerPoint を変換"
- "ハンドアウトモード"
- "ハンドアウト"
- "PowerPoint"
- "PPT"
- "PPTX"
- "プレゼンテーション"
- "C#"
- "Csharp"
- ".NET"
- "Aspose.Slides"
description: "C# でハンドアウトモードのプレゼンテーションを変換"
---

## **ハンドアウトモードのエクスポート**

Aspose.Slides は、さまざまな形式へのプレゼンテーション変換機能を提供し、ハンドアウトモードで印刷用ハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントで便利です。`SlidesLayoutOptions` プロパティを設定することで、このモードを有効にできます。対象は [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイスです。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```c#
// プレゼンテーションを読み込む。
using var presentation = new Presentation("sample.pptx");

// エクスポートオプションを設定。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 1ページに横方向で4枚のスライド
        PrintSlideNumbers = true,                   // スライド番号を印刷
        PrintFrameSlide = true,                     // スライドの周囲に枠線を印刷
        PrintComments = false                       // コメントなし
    }
};

// 選択したレイアウトでプレゼンテーションをPDFにエクスポート。
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
`SlidesLayoutOptions` プロパティは、PDF、HTML、TIFF、画像としてレンダリングする場合など、特定の出力形式でのみ利用可能であることに注意してください。
{{% /alert %}} 

## **FAQ**

**ハンドアウトモードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) をサポートしており、1ページあたり最大 9 枚のサムネイルを横方向または縦方向で配置できます。利用可能な設定は 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 列挙型で厳密に管理されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `ShowHiddenSlides` オプションを有効にしてください。例: [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)。