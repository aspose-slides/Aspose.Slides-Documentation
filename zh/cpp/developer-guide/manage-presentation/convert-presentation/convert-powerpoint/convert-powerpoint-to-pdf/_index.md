---
title: 在 C++ 中将 PowerPoint 转换为 PDF
linktitle: 将 PowerPoint 转换为 PDF
type: docs
weight: 40
url: /zh/cpp/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将 PowerPoint 保存为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides for C++
description: "在 C++ 中将 PowerPoint 演示文稿转换为 PDF。将 PowerPoint 保存为符合或可访问性标准的 PDF。"
---

## **概述**

将 PowerPoint 文档转换为 PDF 格式提供多个优点，包括确保在不同设备之间的兼容性，以及保留演示文稿的布局和格式。本文将向您展示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，使用密码保护 PDF 文档，检测字体替换，选择要转换的幻灯片，并将合规标准应用于输出文档。

## **PowerPoint 到 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* PPT
* PPTX
* ODP

要将演示文稿转换为 PDF，您只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类，然后使用 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类暴露了通常用于将演示文稿转换为 PDF 的 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法。

{{%  alert title="注意"  color="warning"   %}}

Aspose.Slides for C++ 直接在输出文档中写入 API 信息和版本号。例如，当将演示文稿转换为 PDF 时，Aspose.Slides for C++ 会将应用程序字段填充为 '*Aspose.Slides*' 值，PDF 生成字段填充为 '*Aspose.Slides v XX.XX*' 的形式。**注意**，您无法指示 Aspose.Slides for C++ 更改或从输出文档中移除此信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF
* 最终演示文稿

Aspose.Slides 将演示文稿导出为 PDF 的方式，使生成的 PDF 内容与原始演示文稿非常相似。以下已知元素和属性通常在演示文稿到 PDF 的转换中正确呈现：

* 图像
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint PDF 转换操作使用默认选项执行。在这种情况下，Aspose.Slides 尝试使用最佳设置在最高质量级别下转换提供的演示文稿为 PDF。

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>步骤：在 C++ 中将 PowerPoint 转换为 PDF</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>步骤：在 C++ 中将 PPT 转换为 PDF</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>步骤：在 C++ 中将 PPTX 转换为 PDF</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>步骤：在 C++ 中将 ODP 转换为 PDF</strong></a>

以下 C++ 代码展示了如何将 PowerPoint 转换为 PDF：

```c++
// 实例化表示 PowerPoint 文件的 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// 将演示文稿保存为 PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}}

Aspose 提供了一个免费的在线 [**PowerPoint 到 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。要获得此处描述的过程的实时实现，您可以尝试使用转换器。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——[PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) 类下的属性——允许您自定义 PDF（从转换过程中得到的结果），使用密码锁定 PDF，甚至指定转换过程应该如何进行。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像设置首选质量设置，指定如何处理元文件，设置文本的压缩级别，设置图像的 DPI 等。

以下代码示例演示了一个 PowerPoint 演示文稿使用多个自定义选项转换为 PDF 的操作：

```c++
// 实例化 PdfOptions 类
auto pdfOptions = System::MakeObject<PdfOptions>();

// 设置 JPG 图像的质量
pdfOptions->set_JpegQuality(90);

// 为图像设置 DPI
pdfOptions->set_SufficientResolution(300);

// 设置元文件的行为
pdfOptions->set_SaveMetafilesAsPng(true);

// 设置文本内容的压缩级别
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// 定义 PDF 合规模式
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// 实例化表示 PowerPoint 文档的 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// 将演示文稿保存为 PDF 文档
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **将 PowerPoint 转换为带有隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) 类中的 [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) 属性——指示 Aspose.Slides 在结果 PDF 中包含隐藏幻灯片作为页。

以下 C++ 代码展示了如何将 PowerPoint 演示文稿转换为包含隐藏幻灯片的 PDF：

```c++
// 实例化表示 PowerPoint 文件的 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// 实例化 PdfOptions 类
auto pdfOptions = System::MakeObject<PdfOptions>();

// 添加隐藏幻灯片
pdfOptions->set_ShowHiddenSlides(true);

// 将演示文稿保存为 PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下 C++ 代码展示了如何将 PowerPoint 转换为受密码保护的 PDF（使用 [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) 类中的保护参数）：

```c++
// 实例化表示 PowerPoint 文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// 实例化 PdfOptions 类
auto pdfOptions = System::MakeObject<PdfOptions>();

// 设置 PDF 密码和访问权限
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// 将演示文稿保存为 PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### 检测字体替换

Aspose.Slides 提供了 [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) 方法在 [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) 类下，允许您在演示文稿到 PDF 转换过程中检测字体替换。

以下 C++ 代码展示了如何检测字体替换：

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        System::Console::WriteLine(u"字体替换警告: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

接下来的 C++ 代码展示了如何使用上述类：

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

有关在渲染过程中获取字体替换的回调的更多信息，请参见 [获取字体替换的警告回调](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参见 [字体替换](https://docs.aspose.com/slides/cpp/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中的选定幻灯片转换为 PDF**

以下 C++ 代码展示了如何将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：

```C++
// 实例化表示 PowerPoint 文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// 设置幻灯片位置数组
auto slides = System::MakeArray<int32_t>({1, 3});

// 将演示文稿保存为 PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下 C++ 代码展示了如何在指定幻灯片大小的情况下将 PowerPoint 转换为 PDF：

```C++
// 文档目录的路径。
String dataDir = GetDataPath()

// 实例化表示 PowerPoint 文件的 Presentation 对象 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// 设置幻灯片类型和大小 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下 C++ 代码展示了如何将 PowerPoint 转换为 PDF 备注：

```C++
// 文档目录的路径。
System::String dataDir = u""; 

// 实例化表示 PowerPoint 文件的 Presentation 类
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// 将演示文稿保存为 PDF 备注
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换程序。您可以使用以下任何合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 C++ 代码演示了一种 PowerPoint 到 PDF 的转换操作，其中根据不同的合规标准获得多个 PDF：

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 对 PDF 转换操作的支持扩展到允许您将 PDF 转换为最流行的文件格式。您可以进行 [PDF 到 HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF 到图像](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF 到 JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) 和 [PDF 到 PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 的转换。其他 PDF 转换操作针对特定格式——[PDF 到 SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF 到 TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/) 和 [PDF 到 XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}