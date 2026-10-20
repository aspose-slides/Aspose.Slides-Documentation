---
title: 在 C++ 中将 PPT 和 PPTX 转换为 PDF（包括高级功能）
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/cpp/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- PowerPoint 转 PDF
- 演示文稿 转 PDF
- PPT 转 PDF
- 转换 PPT 为 PDF
- PPTX 转 PDF
- 转换 PPTX 为 PDF
- 将 PowerPoint 保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---
## **概述**

在 C++ 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，为 PDF 文件设置密码，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，然后使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 "*Aspose.Slides*"，在 PDF Producer 字段中填入形如 "*Aspose.Slides v XX.XX*" 的值。**注意** 您无法指示 Aspose.Slides 更改或删除输出文档中的此信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度一致。转换期间会准确呈现以下元素和属性，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。

以下示例加载一个演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用该转换器进行测试，以实现本文所述的实际实现。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下提供了自定义选项——属性，允许您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以定义光栅图像的首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

以下示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **自动选择图像压缩**

当演示文稿包含大量照片或屏幕截图时，减小导出 PDF 的大小可以更方便地通过电子邮件发送或下载。调用 [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) 并传入 `true`，可在 PDF 导出期间自动为每个图像选择最合适的压缩算法。

以下示例加载现有演示文稿，启用自动图像压缩选择，并将其保存为 PDF 文档。所有其他 PDF 导出设置保留默认值。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

此选项会为每个图像选择压缩算法。使用 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 降低 JPEG 质量会降低 JPEG 图像质量，而使用 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 降低分辨率会将图像降采样至较低分辨率，从而减少细节。启用自动压缩选择本身并不会降低这些设置。

选择图像压缩算法会增加额外的处理时间和内存消耗。大小的减少取决于演示文稿的图像和导出设置；并非每个演示文稿都能保证固定的缩减量。

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中嵌入了 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿的数据以及查看幻灯片。调用 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) 并传入 `true`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `false`：OLE 对象的预览图像或图标会在 PDF 页面上渲染，但其嵌入文件不会作为附件包含。将该选项设为 `true` 会额外包含文件数据。预览仍然是视觉表示；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成可交互的 Excel 工作表。

以下示例加载已包含嵌入 Excel 工作簿的演示文稿，并将其导出为带有附件的 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

检查结果：

1. 在支持文件附件的查看器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板，定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开则直接打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件有限制：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 的特定限制。本示例使用默认的 PDF 合规设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **将隐藏幻灯片包含在 PDF 中**

如果演示文稿包含隐藏幻灯片，可使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下示例将演示文稿导出为 PDF，并包含所有隐藏幻灯片。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下提供了 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

以下示例将演示文稿导出为 PDF，并将字体替换警告打印到控制台。仅在导出期间出现不可用字体被替换时才会打印警告。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
有关字体替换的更多信息，请参阅 [**字体替换**](/slides/zh/cpp/font-substitution/) 文章。
{{% /alert %}}

### **处理没有专用粗体字形的字体**

即使字体没有专用的粗体字形，演示文稿也可以对文本应用粗体格式。通过合成粗体，可以人工加粗常规字形。当该文本在 PDF 中看起来过于粗重或与预期外观不符时，可尝试调用 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) 并传入 `true`。此选项在 PDF 导出期间将受影响的文本渲染为位图，可能会改善某些字体的外观。默认值为 `false`。

示例演示文稿包含两个文本框：一个使用常规文本，另一个对同一没有专用粗体字形的字体应用了粗体格式。以下示例加载该演示文稿，启用对不受支持字体样式的光栅化，并将其导出为 PDF：

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

以下预览展示了禁用输出和启用输出的对比。在本示例中，禁用选项时粗体文本的笔画更重；启用选项后，其笔画更轻；常规文本保持不变。请在为您的演示文稿选择设置前比较结果。

| 选项禁用 (`false`，默认) | 选项启用 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在本示例中，启用该选项仅将粗体文本转换为位图：无法选中、复制或在未使用 OCR 的情况下搜索，且在 800% 缩放时边缘更柔和。常规文本仍可搜索。禁用选项时，两段文字均保持为文本。

此选项会对字体没有专用粗体字形时的粗体文本进行光栅化。[字体替换](/slides/zh/cpp/font-substitution/) 则在原始字体不可用时选择其他字体。

## **将选定的幻灯片从 PowerPoint 转换为 PDF**

以下示例将演示文稿的第 1 和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号为从 1 开始，输入的演示文稿必须至少包含三张幻灯片。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适应尺寸，并将单张幻灯片导出为 PDF。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，并在每张幻灯片下方放置演讲者备注。请使用包含演讲者备注的演示文稿以查看效果。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 C++ 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 转换过程：

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为常用文件格式。您可以执行 [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、和 [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 转换。其他面向特定格式的 PDF 转换操作——[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)——亦受支持。
{{% /alert %}}

> **注意：** 在导出为 PDF/UA 时，Aspose.Slides 会将 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会保留为独立内容，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以为转换后的 PDF 设置密码保护？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能在 PDF 中保持高图像质量吗？**

可以，您可以使用 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 和 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 等方法在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 中控制图像质量，以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和存档要求。

## **其他资源**

- [Aspose.Slides for C++ 文档](/slides/zh/cpp/)
- [Aspose.Slides for C++ API 参考](https://reference.aspose.com/slides/cpp/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)