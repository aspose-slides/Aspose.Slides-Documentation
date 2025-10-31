---
title: 在 Python 中将 PowerPoint 演示文稿转换为 XPS
linktitle: PowerPoint 转 XPS
type: docs
weight: 70
url: /zh/python-net/convert-powerpoint-to-xps/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- PowerPoint 转 XPS
- 演示文稿 转 XPS
- PPT 转 XPS
- PPTX 转 XPS
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 PowerPoint PPT/PPTX 转换为高质量、平台无关的 XPS。获取分步指南和示例代码。"
---

## **关于 XPS**
Microsoft 开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许您通过输出与 PDF 非常相似的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要了解 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看[此免费在线转换应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现保存、共享和打印文档更为方便。

Microsoft 仍在 Windows（甚至在 Windows 10）中对 XPS 提供强大支持，因此您可能希望将文件保存为此格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，那么 XPS 可能是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式的 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持优于对 PDF 文件的支持。  
  - **XPS**：内置 XPS 查看器/阅读器，支持打印到 XPS。  
  - **PDF**：提供 PDF 阅读器，但不支持打印到 PDF。  

- **Windows 7** 和 **Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也优于对 PDF 的支持。  
  - **XPS**：内置 XPS 查看器，支持打印到 XPS。  
  - **PDF**：没有 PDF 阅读器。也不支持打印到 PDF。  

|<p>**输入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最终在 Windows 10 中通过“打印到 PDF”功能实现了 PDF 的打印支持。以前，用户需要通过 XPS 格式来打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 .NET 的 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，您可以使用 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法（由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类提供）将整个演示文稿转换为 XPS 文档。

将演示文稿转换为 XPS 时，您必须使用以下任意一种设置保存演示文稿：

- 默认设置（不使用 [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/)）
- 自定义设置（使用 [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/)）

### **使用默认设置将演示文稿转换为 XPS**

以下 Python 示例代码演示了如何使用标准设置将演示文稿转换为 XPS 文档：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_XPS.pptx")

# 将演示文稿保存为 XPS 文档
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **使用自定义设置将演示文稿转换为 XPS**

以下示例代码展示了如何在 Python 中使用自定义设置将演示文稿转换为 XPS 文档：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_XPS_Options.pptx")

# 实例化 TiffOptions 类
options = slides.export.XpsOptions()

# 将元文件保存为 PNG
options.save_metafiles_as_png = True

# 将演示文稿保存为 XPS 文档
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **常见问题**

**我可以将 XPS 保存到流而不是文件吗？**

是的—Aspose.Slides 允许您直接导出到流，这对于 Web API、服务器端管道或任何需要在不触及文件系统的情况下发送 XPS 的场景都非常理想。

**隐藏的幻灯片会被包含在 XPS 中吗？我可以排除它们吗？**

默认情况下，仅渲染普通（可见）幻灯片。您可以通过[导出设置](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/)中的[include or exclude hidden slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/)在保存为 XPS 之前进行控制，确保输出仅包含您想要的页面。