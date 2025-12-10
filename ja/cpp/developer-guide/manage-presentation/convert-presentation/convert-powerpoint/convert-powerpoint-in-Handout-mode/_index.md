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
description: "C++ でプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---

## **配布資料モードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、配布資料モードで印刷用のハンドアウトを作成することもできます。このモードでは、1 ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントで便利です。このモードは、[IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/), および [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) インターフェイスの `set_SlidesLayoutOptions` メソッドを設定することで有効にできます。

配布資料モードを構成するには、1 ページに配置するスライド数やその他の表示パラメーターを決定する [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。

以下は、配布資料モードでプレゼンテーションを PDF に変換するコード例です。
```cpp
// プレゼンテーションをロード。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 横向きに1ページあたり4枚のスライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲に枠線を印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポート。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **FAQ**

**配布資料モードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) をサポートしており、ページあたり最大 9 枚のサムネイルを水平方向または垂直方向に配置できます。利用可能なオプションは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドをページあたりのスライド数として定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) 列挙型で厳密に制御されており、任意のレイアウトはサポートされていません。

**隠しスライドを配布資料の出力に含めることはできますか？**

はい。対象形式のエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。たとえば [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), または [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) です。