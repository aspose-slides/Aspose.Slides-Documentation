---
title: 更改 C++ 中的备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/cpp/notes-size/
keywords:
- 备注页尺寸
- 备注方向
- 横向备注
- 纵向备注
- 讲义尺寸
- PowerPoint
- 演示文稿
- PPT
- PPTX
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中读取并更改备注页尺寸，切换方向，验证已保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation::get_NotesSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_notessize/) 访问演示文稿的备注页设置。它返回一个 [INotesSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotessize/) 对象，其 [set_Size](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inotessize/set_size/) 方法用于设置尺寸。虽然不能替换备注设置对象，但可以修改其大小。

宽度和高度以 **点** 为单位，1 英寸等于 72 点。例如，900 × 600 点相当于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的备注。

| 设置 | 目的 |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_notessize/) | 控制备注页尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_slidesize/) | 通过 [ISlideSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidesize/) 控制常规演示文稿幻灯片尺寸。 |

更改任一设置不会自动更改另一设置。更改备注页方向也不会旋转常规幻灯片。请参阅 [Slide Size](/slides/zh/cpp/slide-size/) 以调整常规幻灯片的大小。

下面的示例使用现有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例都可以独立运行。

## **读取备注页尺寸和方向**

读取宽度和高度并进行比较以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等为正方形页面。此示例以点为单位打印实际尺寸，不假设标准纸张大小。

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

## **在不更改纸张尺寸的情况下切换为横向**

仅更改方向时，交换现有的宽度和高度。这会保留两侧的长度，包括自定义纸张尺寸。下面的条件可防止已是横向的页面被切回纵向，并保持正方形页面不变。

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

对于纵向方向，当 `size.get_Width() > size.get_Height()` 时使用相同的赋值。除非您也想更改纸张尺寸，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

一次性同时分配两个维度，然后使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 将演示文稿写入文件。此示例设置 900 × 600 点的横向页面，将其保存为 PPTX，并再次打开已保存的文件以检查持久化的值。比较允许 0.01 点的浮点容差；这并不能保证每种文件格式的精确度。

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

预期结果为 `900 x 600 points` 和 `Size preserved: True`。检查新打开的演示文稿可验证已保存的文件，而不仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局的可用区域。它们本身并不会启用这些布局：还需配置导出选项。常规幻灯片导出仍使用幻灯片尺寸。

### **将备注导出为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/) 赋给 [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) 以在 PDF 中包含备注。此示例还使用 [Slide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/getimage/) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/renderingoptions/) 将第一张带备注的幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notespositions/) 模式将备注保留在一页上；不适合的备注会被截断。PDF 使用 900 × 600 点的页面。以下使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何，像素描述光栅输出，其尺寸还取决于渲染比例。

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

对于带有长备注的 PDF 导出，[BottomFull](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notespositions/) 可在需要时添加额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不支持。调整大小后，检查输出中是否有被裁剪的备注以及现有备注母版对象的位置；仅更改页面尺寸并不能保证所有内容都能适配。更多备注导出信息请参阅 [Convert PowerPoint to PDF with Notes](/slides/zh/cpp/convert-powerpoint-to-pdf-with-notes/)。

### **将讲义导出为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/handoutlayoutingoptions/) 可在一页上放置多个幻灯片缩略图。下面的示例设置 900 × 600 点的页面，并使用 [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/handouttype/) 将每页安排最多四张幻灯片。水平预设控制幻灯片顺序；页面方向由其宽度和高度决定。

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

更改页面尺寸会在不改变源幻灯片尺寸的情况下改变讲义网格的可用面积。对于讲义图像，请使用带有讲义布局的 [Presentation::GetImages](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/getimages/)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单个幻灯片图像调用不会生成讲义页面。更多布局选项请参阅 [Handout Mode](/slides/zh/cpp/convert-powerpoint-in-handout-mode/)。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出的页面尺寸以及打印的纸张尺寸互相独立：

- **演示文稿查看器：** 查看器可以使用自己的布局规则显示或打印备注。如果其他应用程序保存了文件，请重新打开并再次检查尺寸；该应用程序的格式转换可能会对其进行标准化。
- **导出格式：** 上述备注和讲义 PDF 示例使用配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中可能会对小数点值进行四舍五入。导出常规幻灯片不适用备注页尺寸。
- **打印机驱动程序：** 纸张选择、自动旋转和适合页面设置可在不更改演示文稿或 PDF 中存储的尺寸的情况下改变实际输出。针对特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以只为一张幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。单个幻灯片可以有不同的备注内容，但此属性不提供针对每张幻灯片的单独页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和常规幻灯片拥有独立的尺寸。需要调整幻灯片本身时，请使用常规幻灯片尺寸设置。

**为什么我的保存或打印结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果这些已更改，请检查在其他应用程序中保存或转换文件时是否更改了页面设置。如果没有，更检查导出布局、图像比例、查看器设置以及打印机纸张选择。