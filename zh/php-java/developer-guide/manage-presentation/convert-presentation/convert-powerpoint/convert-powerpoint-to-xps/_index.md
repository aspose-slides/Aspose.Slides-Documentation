---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 XPS
linktitle: PowerPoint 转 XPS
type: docs
weight: 70
url: /zh/php-java/convert-powerpoint-to-xps/
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
  - 将 PPT 导出为 XPS
  - 将 PPTX 导出为 XPS
  - PowerPoint
  - 演示文稿
  - PHP
  - Aspose.Slides
description: "使用通过 Java 的 PHP 版 Aspose.Slides 将 PowerPoint PPT/PPTX 转换为高质量、跨平台的 XPS。获取逐步指南和示例代码。"
---

## **关于 XPS**
Microsoft 开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许您通过输出与 PDF 非常相似的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## **何时使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [此免费在线转换应用](https://products.aspose.app/slides/conversion)。 
{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现保存、共享和打印文档更为简便。

Microsoft 仍在 Windows（甚至在 Windows 10）中对 XPS 提供强力支持，因此您可能想考虑将文件保存为此格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，那么 XPS 可能是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（Open XPS）格式来存储 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持优于对 PDF 文件的支持。  
  - **XPS**：内置 XPS 查看器/读取器，并提供打印到 XPS 的功能。  
  - **PDF**：提供 PDF 阅读器，但没有打印到 PDF 的功能。  

-  **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也优于对 PDF 的支持。  
  - **XPS**：内置 XPS 查看器，并提供打印到 XPS 的功能。  
  - **PDF**：没有 PDF 阅读器。没有打印到 PDF 的功能。  

|<p>**输入 PPT(X)：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS：</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft 最终在 Windows 10 中通过“打印为 PDF”功能实现了对 PDF 打印操作的支持。在此之前，用户需要通过 XPS 格式来打印文档。

## **使用 Aspose.Slides 进行 XPS 转换**

在适用于 Java 的 [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) 中，您可以使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类公开的 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，将整个演示文稿转换为 XPS 文档。

将演示文稿转换为 XPS 时，您必须使用以下任一设置保存演示文稿：

- 默认设置（不使用 [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)）
- 自定义设置（使用 [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

以下示例代码展示了如何使用标准设置将演示文稿转换为 XPS 文档：
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # 将演示文稿保存为 XPS 文档
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **使用自定义设置将演示文稿转换为 XPS**

以下示例代码展示了如何使用自定义设置将演示文稿转换为 XPS 文档：
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # 实例化 TiffOptions 类
    $options = new XpsOptions();
    # 将元文件保存为 PNG
    $options->setSaveMetafilesAsPng(true);
    # 将演示文稿保存为 XPS 文档
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问答**

**我可以将 XPS 保存到流中而不是文件吗？**

是的 — Aspose.Slides 允许您直接导出到流，这对于 Web API、服务器端管道或任何需要在不接触文件系统的情况下发送 XPS 的场景都非常理想。

**隐藏的幻灯片会被转到 XPS 吗？我可以排除它们吗？**

默认情况下，仅渲染常规（可见）幻灯片。您可以在保存为 XPS 之前通过 [导出设置](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) 的 [包含或排除隐藏幻灯片](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) 功能来包含或排除隐藏幻灯片，以确保输出恰好包含您想要的页面。