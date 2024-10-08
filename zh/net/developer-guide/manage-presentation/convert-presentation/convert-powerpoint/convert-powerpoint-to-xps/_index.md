---
title: 将 PowerPoint 转换为 XPS 
type: docs
weight: 70
url: /net/convert-powerpoint-to-xps
keywords: "转换 PowerPoint 演示文稿, PowerPoint 转 XPS, PPT 转 XPS, PPTX 转 XPS, 转换, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 XPS。"
---

## **关于 XPS**
微软开发的 [XPS](https://docs.fileformat.com/page-description-language/xps/) 是 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许通过输出类似于 PDF 的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持不变。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [这个免费的在线转换器应用程序](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现保存、共享和打印文档变得更容易。

微软继续在 Windows（甚至在 Windows 10 中）中实施对 XPS 的强力支持，因此您可能想要考虑将文件保存为此格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，那么 XPS 可能实际上是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式的 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件提供了比 PDF 文件更好的支持。
  - **XPS:** 内置 XPS 查看器和打印到 XPS 功能可用。
  - **PDF**: 可用 PDF 阅读器，但没有打印到 PDF 功能。

- **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统也对 XPS 文件提供了比 PDF 更好的支持。
  - **XPS**: 内置 XPS 查看器和打印到 XPS 功能可用。
  - **PDF**: 无 PDF 阅读器。无打印到 PDF 功能。

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

微软最终通过 Windows 10 中的打印到 PDF 功能实现了对 PDF 打印操作的支持。之前，用户被期望通过 XPS 格式打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 [**Aspose.Slides**](https://products.aspose.com/slides/net/) for .NET 中，您可以使用 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法，由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类提供，将整个演示文稿转换为 XPS 文档。

在将演示文稿转换为 XPS 时，您必须使用以下任一设置保存演示文稿：

- 默认设置（不带 [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)）
- 自定义设置（带 [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

以下 C# 示例代码演示如何使用标准设置将演示文稿转换为 XPS 文档：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // 将演示文稿保存为 XPS 文档
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **使用自定义设置将演示文稿转换为 XPS**

以下示例代码演示如何使用 C# 中的自定义设置将演示文稿转换为 XPS 文档：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // 实例化 TiffOptions 类
    XpsOptions options = new XpsOptions();

    // 将元文件保存为 PNG
    options.SaveMetafilesAsPng = true;

    // 将演示文稿保存为 XPS 文档
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```