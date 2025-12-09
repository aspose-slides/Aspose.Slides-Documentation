---
title: .NETでハンドアウトモードにPowerPointプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: ".NETでプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.SlidesでPDFまたは画像にエクスポートします。サンプルC#コード付きです。無料でお試しください。"
---

## **ハンドアウトモードのエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドを配置する方法を設定でき、会議やセミナーなどのイベントに便利です。このモードは、`SlidesLayoutOptions` プロパティを、[IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイスで設定することで有効にできます。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```c#
// プレゼンテーションをロードします。
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 1ページに横方向に4枚のスライド
        PrintSlideNumbers = true,                   // スライド番号を印刷する
        PrintFrameSlide = true,                     // スライドの周囲に枠線を印刷する
        PrintComments = false                       // コメントなし
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
`SlidesLayoutOptions` プロパティは、PDF、HTML、TIFF などの特定の出力形式および画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) により、横方向または縦方向の順序でページあたり最大 9 枚のサムネイルをサポートしています。利用可能な設定は 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 列挙体で厳密に管理されており、任意のレイアウトはサポートされていません。

**非表示スライドをハンドアウトの出力に含めることはできますか？**

はい。対象のフォーマット（例: [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)）のエクスポート設定で `ShowHiddenSlides` オプションを有効にしてください。