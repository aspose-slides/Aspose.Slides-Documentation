---
title: 将 PowerPoint 转换为 XPS 
type: docs
weight: 70
url: /zh/python-net/convert-powerpoint-to-xps
keywords: "转换 PowerPoint 演示文稿, PowerPoint 转 XPS, PPT 转 XPS, PPTX 转 XPS, 转换, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint 演示文稿转换为 XPS。"
---

## **关于 XPS**
微软开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它通过输出一个非常类似于 PDF 的文件来允许您打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持不变。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [这个免费的在线转换应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想减少存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现更容易保存、共享和打印文档。

微软持续在 Windows 中（甚至在 Windows 10 中）实施对 XPS 的强力支持，因此您可能想考虑将文件保存为此格式。如果您处理的是 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，则对于某些操作，XPS 实际上可能是您最好的选择。

- **Windows 8** 使用 OXPS（开放 XPS）格式来处理 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持比对 PDF 文件的支持更好。
  - **XPS:** 具有内置的 XPS 查看器/阅读器和打印到 XPS 的功能。
  - **PDF**: 有 PDF 阅读器，但没有打印到 PDF 的功能。

- **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也比对 PDF 的支持更好。
  - **XPS**: 具有内置的 XPS 查看器和打印到 XPS 的功能。
  - **PDF**: 没有 PDF 阅读器。没有打印到 PDF 的功能。

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |


微软最终通过 Windows 10 的打印到 PDF 功能实现了对 PDF 打印操作的支持。之前，用户被期望通过 XPS 格式打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) for .NET 中，您可以使用 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，该方法由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开，以将整个演示文稿转换为 XPS 文档。

在将演示文稿转换为 XPS 时，您必须使用以下设置之一来保存演示文稿：

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
以下示例代码演示了如何使用自定义设置将演示文稿转换为 XPS 文档：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_XPS_Options.pptx")

# 实例化 TiffOptions 类
options = slides.export.XpsOptions()

# 将 MetaFiles 保存为 PNG
options.save_metafiles_as_png = True

# 将演示文稿保存为 XPS 文档
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```