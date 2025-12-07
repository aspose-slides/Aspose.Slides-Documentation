---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 XPS
linktitle: PowerPoint 转 XPS
type: docs
weight: 70
url: /zh/cpp/convert-powerpoint-to-xps
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 XPS
- 演示文稿转 XPS
- 幻灯片转 XPS
- PPT 转 XPS
- PPTX 转 XPS
- 将 PPT 保存为 XPS
- 将 PPTX 保存为 XPS
- 导出 PPT 为 XPS
- 导出 PPTX 为 XPS
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint PPT/PPTX 转换为高质量、跨平台的 XPS。获取分步指南和示例代码。"
---

## **关于 XPS**
Microsoft 开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它通过输出与 PDF 非常相似的文件来实现内容打印。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## **何时使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 

要了解 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [此免费在线转换应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样可以更轻松地保存、共享和打印文档。

Microsoft 仍在 Windows（包括 Windows 10）中对 XPS 提供强大支持，您可能需要考虑将文件保存为此格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，XPS 实际上可能是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式来存储 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持比对 PDF 文件的支持更好。  
  - **XPS**：内置 XPS 查看器/阅读器并支持打印为 XPS。  
  - **PDF**：提供 PDF 阅读器，但不支持打印为 PDF。  

- **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也优于对 PDF 的支持。  
  - **XPS**：内置 XPS 查看器并支持打印为 XPS。  
  - **PDF**：没有 PDF 阅读器，也不支持打印为 PDF。  

|<p>**输入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最终在 Windows 10 中通过 “Print to PDF” 功能实现了对 PDF 打印操作的支持。此之前，用户通常通过 XPS 格式进行文档打印。

## **使用 Aspose.Slides 进行 XPS 转换**

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) for C++ 中，您可以使用 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类公开的 [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法将整个演示文稿转换为 XPS 文档。

将演示文稿转换为 XPS 时，需要使用以下任意一种设置进行保存：

- 默认设置（不使用 [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)）  
- 自定义设置（使用 [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options)）

### **使用默认设置将演示文稿转换为 XPS**

以下 C++ 示例代码演示如何使用标准设置将演示文稿转换为 XPS 文档：
``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// 将演示文稿保存为 XPS 文档
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **使用自定义设置将演示文稿转换为 XPS**

以下示例代码展示如何在 C++ 中使用自定义设置将演示文稿转换为 XPS 文档：
``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// 实例化 TiffOptions 类
auto options = System::MakeObject<XpsOptions>();

// 将 MetaFiles 保存为 PNG
options->set_SaveMetafilesAsPng(true);

// 将演示文稿保存为 XPS 文档
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **常见问题**

**我可以将 XPS 保存到流而不是文件吗？**

可以——Aspose.Slides 允许直接导出到流，这对于 Web API、服务器端流水线或任何需要在不触及文件系统的情况下发送 XPS 的场景都非常理想。

**隐藏的幻灯片会被转换为 XPS 吗？我可以排除它们吗？**

默认情况下，仅渲染常规（可见）幻灯片。您可以通过在保存为 XPS 之前使用 [export settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) 中的 [**set_ShowHiddenSlides**](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) 来 **包含或排除隐藏幻灯片**，从而确保输出仅包含您希望的页面。