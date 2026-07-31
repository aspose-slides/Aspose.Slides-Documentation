---
title: C++ を使用したハンドアウトモードでの PowerPoint プレゼンテーションの変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/cpp/convert-powerpoint-in-handout-mode/
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
description: "C++ でプレゼンテーションをハンドアウトに変換します。1 ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---
## **概要**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用の配布資料を作成することも可能です。このモードでは、1 ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントに便利です。`set_SlidesLayoutOptions` メソッドを [IPdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/itiffoptions/) インターフェイスで設定することで、このモードを有効にできます。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```cpp
// プレゼンテーションを読み込みます。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1 ページに横向きで 4 スライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲にフレームを印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式や、画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handouttype/) に対応しており、横方向または縦方向の並びで最大 9 枚のサムネイルを 1 ページに配置できます。利用可能なオプションは、1, 2, 3, 4（横/縦）、6（横/縦）、9（横/縦）です。

**ページあたり5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handouttype/) 列挙型で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象の形式のエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。例えば、[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) などです。