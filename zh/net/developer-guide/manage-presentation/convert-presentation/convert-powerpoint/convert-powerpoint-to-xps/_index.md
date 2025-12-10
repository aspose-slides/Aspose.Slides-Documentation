---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 XPS
linktitle: PowerPoint 转 XPS
type: docs
weight: 70
url: /zh/net/convert-powerpoint-to-xps/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 XPS
- 演示文稿 转 XPS
- 幻灯片 转 XPS
- PPT 转 XPS
- PPTX 转 XPS
- 将 PPT 保存为 XPS
- 将 PPTX 保存为 XPS
- 导出 PPT 为 XPS
- 导出 PPTX 为 XPS
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint PPT/PPTX 转换为高质量、跨平台的 XPS。获取一步一步的指南和示例 C# 代码。"
---

## **关于 XPS**
Microsoft 将 [XPS](https://docs.fileformat.com/page-description-language/xps/) 开发为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它通过输出类似 PDF 的文件来实现内容打印。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## **何时使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 

要了解 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [此免费在线转换应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您可以更轻松地保存、共享和打印文档。

Microsoft 在 Windows 中（包括 Windows 10）持续提供对 XPS 的强力支持，因此您可能考虑将文件保存为此格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 或 Windows Vista，XPS 实际上可能是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式保存 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持比对 PDF 文件的支持更好。  
  - **XPS**：提供内置 XPS 查看器/阅读器和 XPS 打印功能。  
  - **PDF**：提供 PDF 阅读器，但没有 PDF 打印功能。  

- **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也优于对 PDF 的支持。  
  - **XPS**：提供内置 XPS 查看器和 XPS 打印功能。  
  - **PDF**：没有 PDF 阅读器，也没有 PDF 打印功能。  

|<p>**输入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最终通过 Windows 10 的“打印到 PDF”功能实现了 PDF 的打印支持。此前，用户只能通过 XPS 格式来打印文档。

## **使用 Aspose.Slides 进行 XPS 转换**

在 .NET 的 [**Aspose.Slides**](https://products.aspose.com/slides/net/) 中，您可以使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides.presentation) 类提供的 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法将整个演示文稿转换为 XPS 文档。

将演示文稿转换为 XPS 时，必须使用以下任一种设置保存演示文稿：

- 默认设置（不使用 [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)）
- 自定义设置（使用 [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

以下 C# 示例代码展示了如何使用标准设置将演示文稿转换为 XPS 文档：
```c#
// 实例化一个代表演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // 将演示文稿保存为 XPS 文档
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **使用自定义设置将演示文稿转换为 XPS**

以下 C# 示例代码展示了如何使用自定义设置将演示文稿转换为 XPS 文档：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // 实例化 TiffOptions 类
    XpsOptions options = new XpsOptions();

    // 将 MetaFiles 保存为 PNG
    options.SaveMetafilesAsPng = true;

    // 将演示文稿保存为 XPS 文档
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **常见问题**

**我可以将 XPS 保存到流中而不是文件吗？**

是的——Aspose.Slides 允许您直接导出到流，这对于 Web API、服务器端管道或任何希望在不接触文件系统的情况下发送 XPS 的场景都非常理想。

**隐藏幻灯片会被带入 XPS 吗？我可以排除它们吗？**

默认情况下，仅渲染常规（可见）幻灯片。您可以在保存为 XPS 之前通过 [导出设置](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) [包含或排除隐藏幻灯片](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/)，确保输出恰好包含您想要的页面。