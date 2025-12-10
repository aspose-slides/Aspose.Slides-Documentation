---
title: 将 PPT 和 PPTX 转换为 C++ PDF【包括高级功能】
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/cpp/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- PowerPoint 转 PDF
- 演示文稿转 PDF
- PPT 转 PDF
- 将 PPT 转换为 PDF
- PPTX 转 PDF
- 将 PPTX 转换为 PDF
- 将 PowerPoint 保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---

## **概述**

在 C++ 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保持演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件进行密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，然后使用 `Save` 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开了 `Save` 方法，通常用于将演示文稿转换为 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入“*Aspose.Slides*”，在 PDF Producer 字段中填入形如“*Aspose.Slides v XX.XX*”的值。**注意**，您无法指示 Aspose.Slides 更改或移除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中元素和属性均被准确渲染，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置在最高质量水平上将提供的演示文稿转换为 PDF。

下面的 C++ 代码展示了如何将演示文稿（PPT、PPTX、ODP 等）转换为 PDF：
```c++
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// 将演示文稿保存为 PDF。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

Aspose 提供了一个免费在线的[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实现本文所述的实时实现。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义生成的 PDF，使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以定义光栅图像的首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

下面的代码示例演示了如何使用多个自定义选项将 PowerPoint 演示文稿转换为 PDF。
```c++
// 实例化 PdfOptions 类。
auto pdfOptions = MakeObject<PdfOptions>();

// 为 JPG 图像设置质量。
pdfOptions->set_JpegQuality(90);

// 为图像设置 DPI。
pdfOptions->set_SufficientResolution(300);

// 为元文件设置行为。
pdfOptions->set_SaveMetafilesAsPng(true);

// 为文本内容设置压缩级别。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// 定义 PDF 合规模式。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 将演示文稿保存为 PDF 文档。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的 C++ 代码展示了如何在转换为 PDF 时包含隐藏幻灯片：
```c++
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 实例化 PdfOptions 类。
auto pdfOptions = MakeObject<PdfOptions>();

// 添加隐藏幻灯片。
pdfOptions->set_ShowHiddenSlides(true);

// 将演示文稿保存为 PDF。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **将 PowerPoint 转换为受密码保护的 PDF**

下面的 C++ 代码演示了如何使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类的保护参数将 PowerPoint 演示文稿转换为受密码保护的 PDF：
```c++
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 实例化 PdfOptions 类。
auto pdfOptions = MakeObject<PdfOptions>();

// 设置 PDF 密码和访问权限。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// 将演示文稿保存为 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类下提供了 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

下面的 C++ 代码展示了如何检测字体替换：
```c++
// 警告回调的实现。
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // 在 PDF 选项中设置警告回调。
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // 将演示文稿保存为 PDF。
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

有关在渲染过程中接收字体替换回调的更多信息，请参阅[Getting Warning Callbacks for Fonts Substitution](/slides/zh/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参阅[Font Substitution](/slides/zh/cpp/font-substitution/)文章。

{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

下面的 C++ 代码演示了如何仅将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：
```C++
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 设置幻灯片编号数组。
auto slides = MakeArray<int32_t>({ 1, 3 });

// 将演示文稿保存为 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

下面的 C++ 代码演示了如何使用指定的幻灯片大小将 PowerPoint 演示文稿转换为 PDF：
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

下面的 C++ 代码演示了如何在生成的 PDF 中包含备注，将 PowerPoint 演示文稿转换为 PDF：
```C++
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 使用备注布局配置 PDF 选项。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 将演示文稿保存为带有备注的 PDF。
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的转换流程。您可以使用以下合规标准之一将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的 C++ 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 到 PDF 转换过程：
```C++
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支持 PDF 转换操作，您可以将 PDF 文件转换为流行的文件格式。您可以执行[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)和[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/)转换。还支持将 PDF 转换为专用格式的操作——[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)以及[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)。

{{% /alert %}}

## **FAQ**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持批量将多个 PPT 或 PPTX 文件转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**能否为转换后的 PDF 设置密码保护？**

完全可以。使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中使用 `set_ShowHiddenSlides` 方法即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以，您可以使用 `set_JpegQuality` 和 `set_SufficientResolution` 等方法在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 类中控制图像质量，确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和存档要求。

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/zh/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)