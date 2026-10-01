---
title: C++ でノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/cpp/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- ハンドアウトサイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でノートページの寸法を読み取り・変更し、向きを切り替えて保存サイズを検証し、ノートまたはハンドアウトを PDF や画像にエクスポートします。"
---
## **概要**

Presentation のノートページ設定にアクセスするには、[Presentation::get_NotesSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_notessize/) を使用します。これは、寸法を設定する [set_Size](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotessize/set_size/) メソッドを持つ [INotesSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotessize/) オブジェクトを返します。ノート設定オブジェクトは置き換えることはできませんが、サイズは変更できます。

幅と高さは **ポイント** で指定され、1インチは 72 ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチです。これらの設定はプレゼンテーション全体に適用され、個々のスライドのノートには適用されません。

| 設定 | 目的 |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_notessize/) | ノートページの寸法と、ハンドアウトエクスポートで使用されるページ寸法を制御します。 |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_slidesize/) | 通常のプレゼンテーションスライドの寸法を [ISlideSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidesize/) を介して制御します。 |

どちらかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。通常のスライドのサイズを変更するには、[Slide Size](/slides/ja/cpp/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポート例では、スピーカーノートを含むスライドが少なくとも1枚あるプレゼンテーションを使用してください。各例は独立して実行できます。

## **ノートページのサイズと向きの読み取り**

幅と高さを読み取り、比較して向きを判定します。幅が大きいページは横向き、高さが大きいページは縦向き、サイズが同じ場合は正方形です。この例は標準用紙サイズを前提せず、実際の寸法（ポイント）を出力します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、既存の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両辺の長さが保たれます。以下の条件は、すでに横向きのページが縦向きに戻されることを防ぎ、正方形のページは変更しません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

縦向きにする場合は、`size.get_Width() > size.get_Height()` のときに同じ代入を使用します。用紙サイズも変更したい場合以外は、A4 や Letter の寸法に置き換えないでください。

## **カスタムノートページサイズの設定と検証**

両方の寸法を同時に設定し、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) を使用してプレゼンテーションを書き出します。この例では 900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存されたファイルを再度開いて永続化された値を確認します。比較は浮動小数点値に対して 0.01 ポイントの許容誤差を許容しますが、すべてのファイル形式での精度を保証するものではありません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

期待される結果は `900 x 600 points` と `Size preserved: True` です。新しく開いたプレゼンテーションを確認することで、メモリ上の設定だけでなく、保存されたファイルが正しいことを検証します。

## **ノートとハンドアウトのエクスポート**

ページ寸法はノートやハンドアウトレイアウトの利用可能領域を定義しますが、これだけでレイアウトが有効になるわけではありません。エクスポートオプションも設定してください。通常のスライドのエクスポートはスライドの寸法を引き続き使用します。

### **ノートを PDF と PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notescommentslayoutingoptions/) を [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) に割り当てて、PDF にノートを含めます。この例では、[Slide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/getimage/) と [RenderingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notespositions/) モードはノートを 1 ページに収め、収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。下記で使用する 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を示し、ピクセルはラスタ出力を示し、寸法はレンダリングスケールにも依存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

長いノートを含む PDF エクスポートでは、[BottomFull](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/notespositions/) を使用すると必要に応じて追加ページが生成されます。ただし、上記の単一スライド画像呼び出しはこのモードをサポートしていないため使用しないでください。サイズ変更後は、切り取られたノートや既存の notes‑master オブジェクトの配置を確認してください。ページ寸法のみを変更しても、すべてのコンテンツが収まる保証にはなりません。ノートエクスポートの詳細については、[Convert PowerPoint to PDF with Notes](/slides/ja/cpp/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **ハンドアウトを PDF にエクスポート**

1 ページに複数のスライドサムネイルを配置するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handoutlayoutingoptions/) を使用します。以下の例では 900 × 600 ポイントのページを設定し、[HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/handouttype/) を使用してページあたり最大 4 枚のスライドを配置します。水平プリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

ページサイズを変更すると、ハンドアウトグリッドの利用可能領域が変わりますが、元のスライドの寸法は変わりません。ハンドアウト画像を取得するには、個々のスライドの画像メソッドではなく、ハンドアウトレイアウトを指定して [Presentation::GetImages](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/getimages/) を使用してください。Aspose.Slides では、プレゼンテーションレベルのハンドアウトレンダリングはノートページの寸法を使用し、個別スライドの画像呼び出しはハンドアウトページを生成しません。レイアウトオプションについては、[Handout Mode](/slides/ja/cpp/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷された用紙サイズは別々に管理してください：

- **Presentation viewers:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。別のアプリケーションでファイルが保存された場合は、再度開いて寸法を確認してください。そのアプリケーションの形式変換により正規化されることがあります。
- **Export formats:** 上記のノートおよびハンドアウト PDF の例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、画像出力では小数点以下のポイント値が丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **Printer drivers:** 用紙の選択、自動回転、ページに合わせる設定により、プレゼンテーションや PDF に保存された寸法を変更せずに物理的な出力が変わることがあります。特定の用紙サイズの場合は、プリンタ設定と印刷プレビューを確認してください。

## **よくある質問**

**1 つのスライドだけのノートサイズを設定できますか？**

ノートページサイズはプレゼンテーションレベルの設定です。個々のスライドは異なるノート内容を持つことができますが、このプロパティはスライドごとに別々のページサイズを提供しません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果のサイズが異なるのはなぜですか？**

まず保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。変更があれば、別のアプリケーションで保存または変換した際にページ設定が変わったか確認します。変わっていない場合は、エクスポートレイアウト、画像スケール、ビューア設定、プリンタの用紙選択を確認してください。