---
title: 在 C++ 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 41
url: /zh-hant/cpp/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片儲存為影像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他影像格式。"
---
## **簡介**

Aspose.Slides for C++ 能夠將 PowerPoint 和 OpenDocument 投影片個別渲染為 PNG、JPEG、GIF、TIFF 以及其他影像格式。

要將投影片轉換為影像，請依照以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入簡報。
2. 選取要渲染的投影片。
3. 如有需要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [ISlide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法。它會傳回 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件。
5. 呼叫 [IImage::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/) 值指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換使用預設的渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件可以在記憶體中處理或儲存至檔案。

以下 C++ 範例會渲染第一張投影片並將其儲存為 PNG 影像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **以自訂尺寸將投影片轉換為影像**

使用接受 [Size](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/size/) 參數的 [ISlide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 多載，以精確的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 影像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **將含註解與評論的投影片轉換為影像**

預設情況下，投影片影像不會包含註解或評論。將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 物件指派給 [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) 方法，以控制註解與評論的顯示位置。

以下範例會將截斷的註解放在投影片下方，評論放在右側：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
在投影片轉影像的過程中，請勿將 [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 方法設為 [BottomFull](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notespositions/)。註解的文字可能超過固定影像大小的容納範圍。請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/) 類別讓您可以控制渲染出的 TIFF 影像的尺寸、解析度及其他屬性。

以下範例會以 300 DPI 渲染第一張投影片為 2160 × 2880 的 TIFF 影像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **將全部投影片轉換為影像**

迭代投影片集合以將整個簡報轉換為一系列影像。除非明確省略，否則隱藏投影片也會被包含。

以下範例會將每張投影片以水平與垂直比例 2 渲染為 JPEG 影像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **建立增強型圖形檔 (EMF) 輸出**

增強型圖形檔 (EMF) 在需要與 Microsoft Office 或其他支援 Windows 圖形檔的 Windows 應用程式交換向量圖形時相當有用。與基於像素的影像不同，EMF 能保留向量繪圖操作，放大時不會同樣失去銳利度。然而，EMF 主要是供具備 Windows 圖形檔支援的應用程式使用的相容性格式，並非通用的交換格式。此外，複雜的投影片內容，如點陣圖及某些特效，可能會作為光柵化元素存放於向量圖形檔的容器中。

### **將投影片匯出為 EMF**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/writeasemf/) 方法會將 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 以 EMF 格式寫入目標串流。以下範例載入簡報，選取第一張投影片，並將其寫入 EMF 檔案串流：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

呼叫端擁有傳遞給 [ISlide::WriteAsEmf](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/writeasemf/) 的串流，必須自行關閉或釋放。Aspose.Slides 會在串流目前的位置寫入，且不會關閉串流。

### **將 SVG 影像轉換為 EMF 並加入簡報**

使用 [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/writeasemf/) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [IImageCollection::AddImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/addimage/) 加入簡報，並以 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ishapecollection/addpictureframe/) 放置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入首張投影片，並儲存簡報：

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/writeasemf/) 不會取得目的串流的所有權。寫入完成後，串流位置位於產生資料的末端。範例呼叫 [MemoryStream::ToArray](https://reference.aspose.com/slides/zh-hant/cpp/system.io/memorystream/toarray/) 以取得完整緩衝區，無論目前串流位置為何，然後將該位元組陣列傳遞給 [IImageCollection::AddImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/addimage/)。在消費端完成讀取之前，請保持串流開啟，之後再關閉。

EMF 產生功能在 Aspose.Slides for C++ 支援的作業系統上皆可使用，但若缺少字型或原生圖形相依性，渲染結果在不同平台可能會有所差異。請安裝來源內容使用的字型或設定適當的替代字型，遵循 Aspose.Slides for C++ 的 [平台需求](/slides/zh-hant/cpp/system-requirements/)，並在目標使用 EMF 的應用程式中驗證結果。Linux 與 macOS 應用程式通常對 Windows 圖形檔的顯示與編輯支援有限或不一致。

## **彩色表情符號呈現**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為影像時，要正確呈現彩色表情符號，必須在執行轉換的系統上安裝並提供簡報中使用的表情符號字型。例如，簡報若使用 **Segoe UI Emoji**，而該字型缺失，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援渲染含動畫的投影片嗎？**

**否**。[ISlide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法會渲染投影片的靜態影像，且不會匯出動畫。

**隱藏投影片可以匯出為影像嗎？**

**可以**。隱藏投影片可像一般投影片一樣渲染。請在處理迴圈中將其納入，如上例所示。

**投影片影像會保留陰影及其他效果嗎？**

**會**。Aspose.Slides 會在投影片影像中呈現陰影、透明度以及其他受支援的圖形效果。