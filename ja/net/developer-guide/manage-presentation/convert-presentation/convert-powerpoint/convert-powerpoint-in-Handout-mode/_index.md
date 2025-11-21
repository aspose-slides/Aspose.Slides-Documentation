---
title: .NET でハンドアウトモードの PowerPoint プレゼンテーションを変換
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
description: ".NET でプレゼンテーションをハンドアウトに変換します。スライド数/ページを設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートできます。サンプル C# コード付きです。無料でお試しください。"
---

## **ハンドアウトモードのエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントで便利です。`SlidesLayoutOptions` プロパティを設定することで、このモードを有効にできます。対象は [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイスです。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```c#
// プレゼンテーションを読み込みます。
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 1ページに横方向で4枚のスライド
        PrintSlideNumbers = true,                   // スライド番号を印刷
        PrintFrameSlide = true,                     // スライドの周囲にフレームを印刷
        PrintComments = false                       // コメントなし
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
`SlidesLayoutOptions` プロパティは、PDF、HTML、TIFF などの特定の出力形式や画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) をサポートしており、最大 9 枚のサムネイルを1ページに配置できます。配置は横方向または縦方向で、1、2、3、4（横/縦）、6（横/縦）、9（横/縦）があります。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `ShowHiddenSlides` オプションを有効にしてください。例として [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) があります。