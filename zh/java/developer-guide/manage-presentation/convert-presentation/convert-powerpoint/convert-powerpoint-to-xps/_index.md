---
title: 将 PowerPoint 转换为 XPS
type: docs
weight: 70
url: /zh/java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX 转 XPS"
description: "在 Java 中将 PowerPoint PPT(X) 转换为 XPS"
---

## **关于 XPS**
Microsoft 开发了 [XPS](https://docs.fileformat.com/page-description-language/xps/) 作为 [PDF](https://docs.fileformat.com/pdf/) 的替代品。它允许你通过输出一个非常类似于 PDF 的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## 何时使用 Microsoft XPS 格式

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，你可以查看 [这个免费的在线转换应用](https://products.aspose.app/slides/conversion)。 

{{% /alert %}} 

如果你想减少存储成本，可以将你的 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，你会发现保存、共享和打印文档变得更容易。

Microsoft 继续在 Windows（甚至在 Windows 10 中）实现对 XPS 的强大支持，因此你可能想考虑将文件保存为此格式。如果你正在使用 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，那么 XPS 可能实际上是你某些操作的最佳选择。

- **Windows 8** 使用 OXPS（开放 XPS）格式来处理 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持优于 PDF 文件。 
  - **XPS:** 提供内置的 XPS 观看器/阅读器和打印到 XPS 功能。 
  - **PDF**: 有 PDF 阅读器，但没有打印到 PDF 功能。 

- **Windows 7 和 Windows Vista** 使用原始的 XPS 格式。这些操作系统对 XPS 文件的支持也优于 PDF 文件。 
  - **XPS**: 提供内置 XPS 观看器和打印到 XPS 功能。 
  - **PDF**: 没有 PDF 阅读器。没有打印到 PDF 功能。 

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft 最终在 Windows 10 中实现了通过打印到 PDF 功能进行 PDF 打印操作的支持。在此之前，用户被期望通过 XPS 格式打印文档。

## 使用 Aspose.Slides 进行 XPS 转换

在 [**Aspose.Slides**](https://products.aspose.com/slides/java/) for Java 中，你可以使用 [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，该方法由 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类提供，来将整个演示文稿转换为 XPS 文档。

在将演示文稿转换为 XPS 时，你必须使用以下设置之一来保存演示文稿：

- 默认设置（没有 [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions)）
- 自定义设置（带有 [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

以下 Java 示例代码展示了如何使用标准设置将演示文稿转换为 XPS 文档：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // 将演示文稿保存为 XPS 文档
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **使用自定义设置将演示文稿转换为 XPS**
以下示例代码展示了如何使用自定义设置将演示文稿转换为 XPS 文档：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // 实例化 TiffOptions 类
    XpsOptions options = new XpsOptions();

    // 作为 PNG 保存元文件
    options.setSaveMetafilesAsPng(true);

    // 将演示文稿保存为 XPS 文档
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```