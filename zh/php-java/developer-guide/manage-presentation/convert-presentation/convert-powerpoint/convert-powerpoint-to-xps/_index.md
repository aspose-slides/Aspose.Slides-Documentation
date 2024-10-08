---
title: 将 PowerPoint 转换为 XPS
type: docs
weight: 70
url: /php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX 转 XPS"
description: "将 PowerPoint PPT(X) 转换为 XPS "
---

## **关于 XPS**
Microsoft 开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许您通过输出与 PDF 非常相似的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [这个免费的在线转换器应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现更容易保存、分享和打印您的文档。

Microsoft 继续在 Windows（甚至 Windows 10）中实施对 XPS 的强力支持，因此您可能想考虑将文件保存为该格式。如果您使用的是 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，那么 XPS 可能实际上是某些操作的最佳选择。

- **Windows 8** 使用 OXPS（开放 XPS）格式用于 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持比对 PDF 文件的支持更好。
  - **XPS:** 提供内置的 XPS 查看器/阅读器和打印到 XPS 功能。
  - **PDF**: 提供 PDF 阅读器，但没有打印到 PDF 的功能。

-  **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也比对 PDF 的支持更好。
  - **XPS**: 提供内置的 XPS 查看器和打印到 XPS 功能。
  - **PDF**: 没有 PDF 阅读器。没有打印到 PDF 的功能。

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft 最终通过 Windows 10 中的打印到 PDF 功能实现了对 PDF 打印操作的支持。以前，用户被期望通过 XPS 格式打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) for Java 中，您可以使用 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法， 该方法由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类公开，用于将整个演示文稿转换为 XPS 文档。

转换演示文稿为 XPS 时，您必须使用以下设置之一来保存演示文稿：

- 默认设置（不带 [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)）
- 自定义设置（带 [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

以下示例代码演示如何使用标准设置将演示文稿转换为 XPS 文档：

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
以下示例代码演示如何使用自定义设置将演示文稿转换为 XPS 文档：

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