---
title: 在 C++ 中将 PPT 和 PPTX 转换为 PDF [包含高级功能]
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

在 C++ 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备间的兼容性以及保留演示文稿的布局和格式。本文档演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件设置密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，然后使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开的 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法通常用于将演示文稿转换为 PDF。

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段填入 “*Aspose.Slides*”，在 PDF Producer 字段填入 “*Aspose.Slides v XX.XX*” 形式的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中会准确渲染以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 过程使用默认选项。在这种情况下，Aspose.Slides 会尝试使用最高质量级别的最佳设置将提供的演示文稿转换为 PDF。

下面的示例加载演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

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

Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现本文所述的过程。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下的属性，允许您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以定义栅格图像的首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

下面的示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

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

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中嵌入了 Excel 工作簿，您可能希望 PDF 接收者既能访问工作簿数据，又能查看幻灯片。调用 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) 并传入 `true`，即可在生成的 PDF 中将嵌入的 OLE 文件作为附件保留。

默认值为 `false`：OLE 对象的预览图像或图标会在 PDF 页面上渲染，但其嵌入文件不会作为附件包含。将该选项设为 `true` 会额外包含文件数据。预览仍然是视觉表现；附件则允许接收者单独打开或保存嵌入的文件。OLE 对象不会在 PDF 页面上变为可交互的 Excel 工作表。

下面的示例加载已经包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

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

检查结果的步骤：

1. 在支持文件附件的查看器（例如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板并定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或在查看器允许的情况下直接打开。PDF 页面上的预览与附件分离。

{{% alert color="info" title="Note" %}}

PDF/A 标准对附件有约束：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 的特定限制。本示例使用默认的 PDF 合规设置，并未演示 PDF/A 导出。

{{% /alert %}}

### **将隐藏幻灯片包含在 PDF 中**

如果演示文稿包含隐藏幻灯片，您可以使用来自 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的示例将演示文稿导出为 PDF，包含所有隐藏幻灯片。

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

下面的示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

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

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下提供了 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，帮助您在演示文稿转 PDF 的过程中检测字体替换。

下面的示例将演示文稿导出为 PDF，并在控制台打印字体替换警告。仅在导出期间替换了不可用字体时才会打印警告。

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

有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/cpp/font-substitution/) 文章。

{{% /alert %}} 

### **处理没有专用粗体字形的字体**

即使字体本身没有专用的粗体字形，演示文稿仍可对文本应用粗体格式。此时文本会通过合成粗体（人工加粗常规字形）显示。如果合成粗体在 PDF 中显得过重或与预期外观不符，可调用 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) 并传入 `true`。该选项在 PDF 导出时将受影响的文本渲染为位图，从而在某些字体下改善外观。默认值为 `false`。

示例演示文稿包含两个文本框：一个普通文本框和一个对同一无专用粗体字形的字体应用粗体格式的文本框。下面的示例加载该演示文稿，启用不支持的字体样式栅格化，并将其导出为 PDF：

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

以下预览展示了未启用和已启用选项的输出。在本例中，禁用选项时粗体文本的笔划更重；启用选项后笔划更轻，普通文本保持不变。请在为您的演示文稿选择设置前对比结果。

| 禁用选项 (`false`, 默认) | 启用选项 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在本例中，启用选项后仅把粗体文本转换为位图：该位图文本无法被选中、复制或在未使用 OCR 时搜索，其边缘在 800% 放大时显得更柔和。普通文本仍保持可搜索。禁用选项时，两段文字均保持为文本。

此选项会对字体没有专用粗体字形的粗体文本进行栅格化。[字体替换](/slides/zh/cpp/font-substitution/) 则会在原字体不可用时选择另一种字体。

## **将选定的幻灯片从 PowerPoint 转换为 PDF**

下面的示例将演示文稿的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用从 1 开始的索引，且输入演示文稿必须至少包含三张幻灯片。

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

下面的示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸设为 612 × 792 点（8.5 × 11 英寸），并将该单张幻灯片导出为 PDF。

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

## **在备注幻灯片视图下将 PowerPoint 转换为 PDF**

下面的示例将演示文稿导出为 PDF，并在每张幻灯片下方放置对应的演讲者备注。请使用包含演讲者备注的演示文稿以查看效果。

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

## **PDF 的可访问性与合规标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的 C++ 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 过程：

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

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为常见格式。您可以执行 [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) 和 [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 转换。还支持将 PDF 转换为专用格式的操作——[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) 和 [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)。

{{% /alert %}}

> **注意：** 在导出为 PDF/UA 时，Aspose.Slides 将 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会保留为独立内容，可能被标记为伪元素；仅为整体图形提供替代文本。

## **FAQ**

**是否可以批量将多个 PowerPoint 文件转换为 PDF？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以在代码中遍历文件并逐个执行转换过程。

**是否可以对转换后的 PDF 设置密码保护？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以，您可以使用诸如 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 和 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中控制图像质量，以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和存档要求。

## **其他资源**

- [Aspose.Slides for C++ 文档](/slides/zh/cpp/)
- [Aspose.Slides for C++ API 参考](https://reference.aspose.com/slides/cpp/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)