---
title: 在 C++ 中變更備註頁尺寸與方向
linktitle: 備註頁尺寸
type: docs
weight: 10
url: /zh-hant/cpp/notes-size/
keywords:
- 備註頁尺寸
- 備註方向
- 橫向備註
- 直向備註
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中讀取並變更備註頁尺寸，切換方向，驗證已儲存的尺寸，並將備註或講義匯出為 PDF 與影像。"
---
## **概觀**

使用 [Presentation::get_NotesSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_notessize/) 來存取投影片的備註頁設定。它會傳回一個 [INotesSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotessize/) 物件，其 [set_Size](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotessize/set_size/) 方法設定尺寸。雖然無法取代備註設定物件，但您可以變更其大小。

寬度與高度以 **點** 為單位指定，每英吋 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定適用於整個投影片，而不是單一投影片的備註。

| 設定 | 目的 |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_notessize/) | 控制備註頁的尺寸以及用於講義匯出的頁面尺寸。 |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_slidesize/) | 透過 [ISlideSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/) 控制一般投影片的尺寸。 |

變更任一設定不會自動變更另一個。變更備註頁的方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/cpp/slide-size/) 以調整一般投影片的大小。

以下範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張包含講者備註的投影片的檔案。每個範例皆可獨立執行。

## **讀取備註頁尺寸與方向**

讀取寬度與高度並比較以判斷方向：較寬的頁面為橫向，較高的頁面為直向，若尺寸相等則為方形頁面。此範例會以點為單位印出實際尺寸，且不假設標準紙張大小。

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

## **切換為橫向而不變更紙張大小**

若只想變更方向，請交換現有的寬度與高度。這會保留兩側的長度，包括自訂紙張大小的長度。以下條件可防止已是橫向的頁面被切換回直向，且方形頁面保持不變。

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

對於直向，當 `size.get_Width() > size.get_Height()` 時使用相同的指派。除非您同時想變更紙張大小，否則不要改用 A4 或 Letter 尺寸。

## **設定與驗證自訂備註頁尺寸**

同時指派兩個尺寸，然後使用 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 寫入投影片。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持久化的值。比較允許 0.01 點的浮點容差；這並不保證每種檔案格式的精確度。

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

預期結果為 `900 x 600 points` 與 `Size preserved: True`。檢查新開啟的投影片可驗證已儲存的檔案，而不僅是記憶體中的設定。

## **匯出備註與講義**

頁面尺寸定義了備註或講義版面的可用區域。它們本身不會啟用這些版面配置：仍須設定匯出選項。一般投影片匯出仍使用投影片尺寸。

### **匯出備註至 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 指派給 [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) 以在 PDF 中包含備註。此範例也使用 [Slide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/getimage/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/) 將第一張含備註的投影片轉為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notespositions/) 模式會將備註保留在單一頁面；不適合的備註會被截斷。PDF 使用 900 × 600 點的頁面。以下使用的 1 × 1 影像比例下，PNG 為 900 × 600 像素。點描述頁面幾何形狀；像素描述光柵輸出，其尺寸亦受渲染比例影響。

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

對於備註較長的 PDF 匯出，[BottomFull](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notespositions/) 會在需要時新增頁面。不要在上述單投影片影像呼叫中使用此模式，因為它不支援。調整大小後，請檢查輸出是否有被裁切的備註以及現有 notes‑master 物件的位置；僅變更頁面尺寸並不保證所有內容皆能容納。請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/cpp/convert-powerpoint-to-pdf-with-notes/) 了解更多備註匯出資訊。

### **匯出講義至 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handoutlayoutingoptions/) 於單一頁面上放置多個投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/handouttype/) 以水平方式將最多四張投影片排列於每頁。水平預設控制投影片順序；頁面方向則由其寬度和高度決定。

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

變更頁面大小會改變講義格線的可用區域，但不會變更來源投影片的尺寸。對於講義影像，請使用 [Presentation::GetImages](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/getimages/) 搭配講義版面，而非個別投影片的影像方法。在 Aspose.Slides 中，投影片層級的講義渲染使用備註頁尺寸，而個別投影片的影像呼叫不會產生講義頁面。請參閱 [Handout Mode](/slides/zh-hant/cpp/convert-powerpoint-in-handout-mode/) 了解版面選項。

## **檢視器、匯出與列印中的頁面尺寸**

保持儲存的投影片尺寸、匯出頁面尺寸以及列印紙張尺寸之間的區別：

- **Presentation viewers:** 檢視程式可以使用自身的版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會正規化它們。
- **Export formats:** 上述備註與講義 PDF 範例使用已配置的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，因而在影像輸出時會對小數點的點值進行四捨五入。匯出一般投影片不會套用備註頁尺寸。
- **Printer drivers:** 紙張選取、自動旋轉與自動調整至頁面設定可改變實體輸出，而不會變更投影片或 PDF 中儲存的尺寸。若使用特定紙張尺寸，請配合印表機設定並檢查列印預覽。

## **常見問題**

**我可以只為單一投影片設定備註尺寸嗎？**

備註頁尺寸是投影片層級的設定。個別投影片可以有不同的備註內容，但此屬性不會為每張投影片提供單獨的頁面尺寸。

**為什麼變更備註方向不會影響我的投影片？**

備註頁與一般投影片的尺寸是獨立的。若要調整投影片本身的大小，請使用一般投影片尺寸設定。

**為什麼我的儲存或列印結果尺寸不同？**

首先重新開啟已儲存的投影片，並比較其備註尺寸。若已變更，請檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，請檢查匯出版面、影像比例、檢視器設定以及印表機紙張選取。