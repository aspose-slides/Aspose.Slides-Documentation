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
description: "C++ でプレゼンテーションをハンドアウトに変換します。スライドをページごとに設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートします。サンプルコード付き。無料で試せます。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用の配布資料を作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントに便利です。`set_SlidesLayoutOptions` メソッドを呼び出すことで、このモードを有効にできます。対象となるインターフェイスは [IPdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/itiffoptions/) です。

エクスポート前にハンドアウトページのサイズと向きを設定するには、[ノートページサイズ](/slides/ja/cpp/notes-size/) を参照してください。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、1ページに配置するスライド数やその他の表示パラメータを決定する [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーションを読み込む。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 1ページに横方向で4スライド
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // スライド番号を印刷
slidesLayoutOptions->set_PrintFrameSlide(true);                      // スライドの周囲にフレームを印刷
slidesLayoutOptions->set_PrintComments(false);                       // コメントは印刷しません

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

### ハンドアウトモードでページあたりのスライドサムネイルの最大数は何ですか？

Aspose.Slides は、横方向または縦方向の順序で 1 ページあたり最大 9 枚のサムネイルをサポートしています。利用できる [presets](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handouttype/) は 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

### 5 枚や 8 枚など、カスタムグリッドを定義できますか？

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

### 非表示スライドをハンドアウト出力に含めることはできますか？

はい。対象フォーマットのエクスポート設定で `set_ShowHiddenSlides` メソッドを使用します。例として [PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/tiffoptions/) があります。