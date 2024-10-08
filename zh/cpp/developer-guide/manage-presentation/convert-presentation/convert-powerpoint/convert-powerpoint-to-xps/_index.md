---
title: 转换 PowerPoint 到 XPS 
type: docs
weight: 70
url: /zh/cpp/convert-powerpoint-to-xps
keywords: "转换, PowerPoint 到 XPS, 转换, PPT 到 XPS, PPTX 到 XPS"
description: "使用 Aspose.Slides API 将 PowerPoint PPT、PPTX 转换为 XPS 文档。"
---

## **关于 XPS**
微软开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许您通过输出一个非常类似于 PDF 的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持不变。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [这个免费的在线转换应用程序](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想减少存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现保存、共享和打印文档变得更加容易。 

微软在 Windows 中（甚至在 Windows 10 中）持续实施对 XPS 的强大支持，因此您可能想考虑将文件保存为此格式。如果您正在使用 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，那么 XPS 实际上可能是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式来保存 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持比对 PDF 文件的支持更好。 
  - **XPS：** 内置 XPS 查看器/读取器和打印到 XPS 功能可用。 
  - **PDF：** 提供 PDF 阅读器，但没有打印到 PDF 功能。 

-  **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也比对 PDF 文件的支持更好。 
  - **XPS：** 内置 XPS 查看器和打印到 XPS 功能可用。 
  - **PDF：** 没有 PDF 阅读器。没有打印到 PDF 功能。 

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

微软最终在 Windows 10 通过打印到 PDF 功能实现了对 PDF 的打印操作的支持。之前，用户被期望通过 XPS 格式打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) for C++ 中，您可以使用 [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法，该方法由 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类公开，用于将整个演示文稿转换为 XPS 文档。

在将演示文稿转换为 XPS 时，您必须使用以下设置之一保存演示文稿：

- 默认设置（没有 [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)）
- 自定义设置（带 [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)）

### **使用默认设置将演示文稿转换为 XPS**

以下 C++ 示例代码演示了如何使用标准设置将演示文稿转换为 XPS 文档：

``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// 将演示文稿保存为 XPS 文档
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **使用自定义设置将演示文稿转换为 XPS**
以下示例代码演示了如何使用自定义设置将演示文稿转换为 XPS 文档：

``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// 实例化 TiffOptions 类
auto options = System::MakeObject<XpsOptions>();

// 将元文件保存为 PNG
options->set_SaveMetafilesAsPng(true);

// 将演示文稿保存为 XPS 文档
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```