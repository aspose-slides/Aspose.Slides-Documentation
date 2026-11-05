---
title: .NET でハンドアウトモードで PowerPoint プレゼンテーションを変換する
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/net/convert-powerpoint-in-handout-mode/
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
description: ".NET でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートします。サンプル C# コード付きです。無料でお試しください。"
---
## **導入**

Aspose.Slides を使用すると、配布資料モードに対応した出力形式にプレゼンテーションを変換できます。このモードでは、複数のスライドが1ページに配置され、会議、セミナー、その他のイベント用の資料印刷に便利です。

配布資料モードは `SlidesLayoutOptions` プロパティで構成され、[IPdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/itiffoptions/) で利用できます。配布レイアウトを定義するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。

エクスポート前に配布ページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/net/notes-size/) を参照してください。

## **配布資料モードのエクスポート**

配布資料モードでプレゼンテーションをエクスポートするには、対象のエクスポートオプションの `SlidesLayoutOptions` プロパティを設定し、1ページあたりのスライド数や関連表示パラメーターを定義する [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handoutlayoutingoptions/) インスタンスを割り当てます。

以下に、配布資料モードでプレゼンテーションを PDF に変換するコード例を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Load a presentation. => プレゼンテーションを読み込みます。
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slides on one page horizontally => 1ページに横方向で4枚のスライド
        PrintSlideNumbers = true,                   // print slide numbers => スライド番号を印刷
        PrintFrameSlide = true,                     // print a frame around slides => スライドの周囲にフレームを印刷
        PrintComments = false                       // no comments => コメントなし
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
`SlidesLayoutOptions` プロパティは、PDF、HTML、TIFF などの特定の出力形式、および画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **FAQ**

### 配布資料モードでページあたりのスライドサムネイルの最大数は？

Aspose.Slides は、1ページあたり最大 9 枚のサムネイルをサポートし、横方向または縦方向の順序で配置できる [presets](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handouttype/) を提供します。利用可能なオプションは 1、2、3、4（横方向/縦方向）、6（横方向/縦方向）、9（横方向/縦方向）です。

### 5 枚や 8 枚のスライドなど、カスタムグリッドを定義できますか？

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.export/handouttype/) 列挙体で厳密に管理されており、任意のレイアウトはサポートされていません。

### 隠しスライドを配布資料の出力に含めることはできますか？

はい。対象フォーマットのエクスポート設定で `ShowHiddenSlides` オプションを有効にします。例として [PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) があります。