---
title: ".NET でハンドアウトモードの PowerPoint プレゼンテーションを変換"
linktitle: "ハンドアウトモード"
type: docs
weight: 150
url: /ja/net/convert-powerpoint-in-Handout-mode/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "ハンドアウトモード"
- "ハンドアウト"
- "PowerPoint"
- "プレゼンテーション"
- "PPT"
- "PPTX"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートできます。サンプル C# コード付きです。無料でお試しください。"
---

## **ハンドアウト モード エクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1 ページに複数のスライドを配置する方法を設定できるため、会議やセミナーなどのイベントで便利です。`SlidesLayoutOptions` プロパティを設定することで、このモードを有効にできます。対象となるインターフェイスは [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) です。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライドの枚数やその他の表示パラメータを決定します。

以下は、プレゼンテーションをハンドアウトモードで PDF に変換するコード例です。
```c#
 // Load a presentation.
 using var presentation = new Presentation("sample.pptx");

 // Set the export options.
 var pdfOptions = new PdfOptions
 {
     SlidesLayoutOptions = new HandoutLayoutingOptions
     {
         Handout = HandoutType.Handouts4Horizontal,  // 1ページに横方向で4枚のスライド
         PrintSlideNumbers = true,                   // スライド番号を印刷
         PrintFrameSlide = true,                     // スライドの周りに枠を印刷
         PrintComments = false                       // コメントはありません
     }
 };

 // Export the presentation to PDF with the chosen layout.
 presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
`SlidesLayoutOptions` プロパティは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **FAQ**

**ハンドアウトモードでページあたりのスライドサムネイルの最大数は何枚ですか？**

Aspose.Slides は、横向きまたは縦向きの並び順で 1、2、3、4（横/縦）、6（横/縦）、および 9（横/縦）枚のサムネイルまでの [presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) をサポートしています。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

できません。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 列挙型で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `ShowHiddenSlides` オプションを有効にします。たとえば [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) です。