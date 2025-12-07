---
title: C++ を使用してハンドアウトモードで PowerPoint プレゼンテーションを変換
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
description: "C++ でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートできます。サンプルコード付きです。無料でお試しください。"
---

## **配布モードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、配布モードで印刷用のハンドアウトを作成することも可能です。このモードでは、1ページに複数のスライドをどのように配置するかを設定できるため、会議やセミナーなどのイベントに便利です。`set_SlidesLayoutOptions` メソッドを[IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/)、および[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/)インターフェイスで設定することでこのモードを有効にできます。

配布モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/)オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、配布モードでプレゼンテーションを PDF に変換するコード例です。
```cpp
// プレゼンテーションを読み込みます。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// エクスポートオプションを設定します。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1ページにスライドを横方向に4枚配置
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲に枠線を印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式や画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**配布モードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) をサポートしており、ページあたり最大 9 枚のサムネイルを水平または垂直の順序で配置できます: 1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**配布出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。例えば、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/)、または[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) です。