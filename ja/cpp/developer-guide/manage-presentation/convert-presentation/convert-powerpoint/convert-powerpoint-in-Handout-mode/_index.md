---
title: "C++ でハンドアウトモードの PowerPoint プレゼンテーションを変換"
linktitle: "ハンドアウトモード"
type: docs
weight: 150
url: /ja/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "ハンドアウトモード"
- "ハンドアウト"
- "PPT"
- "PPTX"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "C++ でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF や画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---

## **配付モードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、配付モードで印刷用のハンドアウトを作成することもできます。このモードでは、1 ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントで役立ちます。`set_SlidesLayoutOptions` メソッドを設定することで、このモードを有効にできます。対象のインターフェイスは [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) です。

配付モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、配付モードでプレゼンテーションを PDF に変換するコード例です。
```cpp
// プレゼンテーションを読み込む。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// エクスポートオプションを設定する。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲にフレームを印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートする。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **FAQ**

**配付モードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) により、横方向または縦方向の並びでページあたり最大 9 枚のサムネイルをサポートします。利用できるレイアウトは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**ページあたり 5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) 列挙型で厳密に制御されており、任意のレイアウトはサポートされていません。

**配付出力に非表示スライドを含めることはできますか？**

はい。対象の形式（例: [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)）のエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。