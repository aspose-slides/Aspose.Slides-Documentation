---
title: C++ を使用したハンドアウトモードで PowerPoint プレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ でプレゼンテーションをハンドアウトに変換します。1 ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートできます。サンプルコード付きです。無料でお試しください。"
---

## **配布資料モード エクスポート**

Aspose.Slides は、さまざまな形式へのプレゼンテーションの変換機能を提供し、Handout モードで印刷用の配布資料を作成することもできます。このモードでは、1 ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントに便利です。このモードは、`set_SlidesLayoutOptions` メソッドを[IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/)、および[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/)インターフェイスで設定することで有効にできます。

Handout モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/)オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、Handout モードでプレゼンテーションを PDF に変換するコード例です。
```cpp
// プレゼンテーションを読み込む。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1ページに横方向に4枚スライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲に枠線を印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**Handout モードで1ページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) により、横方向または縦方向の順序で最大 9 個のサムネイルを1ページに配置できます。利用可能な設定は 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は[HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**非表示スライドを Handout の出力に含めることができますか？**

はい。対象フォーマットのエクスポート設定で`set_ShowHiddenSlides`メソッドを使用します。例えば、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)などです。