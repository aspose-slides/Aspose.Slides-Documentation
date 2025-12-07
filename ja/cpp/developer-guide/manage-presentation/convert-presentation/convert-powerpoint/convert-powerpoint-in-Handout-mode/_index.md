---
title: C++でハンドアウトモードを使用してPowerPointプレゼンテーションを変換する
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint変換
- プレゼンテーション変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++でプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slidesを使用してPDFまたは画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---

## **配布資料モードのエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、配布資料モードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントに便利です。`set_SlidesLayoutOptions` メソッドを設定することで、このモードを有効にできます。対象のインターフェイスは [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) です。

配布資料モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、配布資料モードでプレゼンテーションを PDF に変換するコード例です。
```cpp
// プレゼンテーションをロードします。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// エクスポート オプションを設定します。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1ページに水平に4枚のスライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷します
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲に枠を印刷します
slidesLayoutOptions->set_PrintComments(false);                       // コメントなし

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 

`set_SlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式および画像としてレンダリングする場合にのみ利用可能であることに注意してください。

{{% /alert %}} 

## **よくある質問**

**配布資料モードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) をサポートしており、水平または垂直の順序で1ページあたり最大9枚のサムネイルを配置できます。利用できる設定は 1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）です。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**配布資料の出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。たとえば [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) などです。