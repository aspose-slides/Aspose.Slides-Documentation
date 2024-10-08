---
title: 将 PowerPoint 转换为 PDF 在 Java 中
linktitle: 将 PowerPoint 转换为 PDF
type: docs
weight: 40
url: /androidjava/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 保存 PowerPoint 为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides for Android via Java
description: "在 Java 中将 PowerPoint 演示文稿转换为 PDF。以符合法规或可访问性标准的方式保存 PowerPoint 为 PDF。"
---

## **概述**

将 PowerPoint 文档转换为 PDF 格式有几个优点，包括确保不同设备之间的兼容性以及保留演示文稿的布局和格式。本文将向您展示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，以密码保护 PDF 文档，检测字体替代，选择要转换的幻灯片，并将合规标准应用于输出文档。

## **PowerPoint 到 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* PPT
* PPTX
* ODP

要将演示文稿转换为 PDF，您只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类，然后使用 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法将演示文稿保存为 PDF。 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类公开了通常用于将演示文稿转换为 PDF 的 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Android via Java 直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Android via Java 将“*Aspose.Slides*”的值填充到应用程序字段中，并将 PDF 制作程序字段填充为“*Aspose.Slides v XX.XX*”形式的值。**注意**，您无法指示 Aspose.Slides for Android via Java 更改或删除输出文档中的此信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF
* 演示文稿 

Aspose.Slides 以一种使得生成的 PDF 的内容与原始演示文稿非常相似的方式将演示文稿导出为 PDF。这些已知的元素和属性在演示文稿到 PDF 的转换中通常会正确呈现：

* 图像
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint PDF 转换操作使用默认选项执行。在这种情况下，Aspose.Slides 尝试在最大质量水平下使用最佳设置将提供的演示文稿转换为 PDF。

以下 Java 代码演示了如何将 PowerPoint 转换为 PDF：

```java
// 实例化代表 PowerPoint 文件的 Presentation 类
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // 将演示文稿保存为 PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose 提供了一个免费的在线 [**PowerPoint 到 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。要实时实现这里描述的过程，您可以使用该转换器进行测试。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) 类下的属性——允许您自定义 PDF（转换过程生成的结果），用密码锁定 PDF，甚至指定转换过程应如何执行。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以设置所需的光栅图像质量设置，指定元文件的处理方式，为文本设置压缩级别，为图像设置 DPI 等。

以下代码示例演示了将 PowerPoint 演示文稿转换为 PDF 的操作，带有几个自定义选项：

```java
// 实例化 PdfOptions 类
PdfOptions pdfOptions = new PdfOptions();

// 设置 JPG 图像的质量
pdfOptions.setJpegQuality((byte)90);

// 为图像设置 DPI
pdfOptions.setSufficientResolution(300);

// 设置元文件的行为
pdfOptions.setSaveMetafilesAsPng(true);

// 设置文本内容的压缩级别
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// 定义 PDF 合规模式
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// 实例化代表 PowerPoint 文档的 Presentation 类
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 将演示文稿保存为 PDF 文档
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **包含隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[ShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) 属性，该属性来自 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) 类——指示 Aspose.Slides 将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下 Java 代码演示了如何将一个包含隐藏幻灯片的 PowerPoint 演示文稿转换为 PDF：

```java
// 实例化代表 PowerPoint 文件的 Presentation 类
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类
    PdfOptions pdfOptions = new PdfOptions();
    
    // 添加隐藏幻灯片
    pdfOptions.setShowHiddenSlides(true);
    
    // 将演示文稿保存为 PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **将 PowerPoint 转换为密码保护的 PDF**

以下 Java 代码演示了如何将 PowerPoint 转换为带有密码保护的 PDF（使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) 类中的保护参数）：

```java
// 实例化代表 PowerPoint 文件的 Presentation 对象
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类
    PdfOptions pdfOptions = new PdfOptions();
    
    // 设置 PDF 密码和访问权限
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // 将演示文稿保存为 PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### 检测字体替代

Aspose.Slides 提供了 [getWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#getWarningCallback--) 方法，该方法位于 [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/) 类下，允许您在演示文稿到 PDF 转换过程中检测字体替代。

以下 Java 代码演示了如何检测字体替代： 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("字体替代警告: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

有关获取渲染过程中字体替代的回调的更多信息，请参见 [获取字体替代的警告回调](https://docs.aspose.com/slides/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替代的更多信息，请参阅 [字体替代](https://docs.aspose.com/slides/androidjava/font-substitution/) 文章。

{{% /alert %}} 

## **将选定的幻灯片从 PowerPoint 转换为 PDF**

以下 Java 代码演示了如何将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：

```java
// 实例化代表 PowerPoint 文件的 Presentation 对象
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 设置幻灯片位置的数组
    int[] slides = { 1, 3 };
    
    // 将演示文稿保存为 PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下 Java 代码演示了如何在指定幻灯片大小的情况下将 PowerPoint 转换为 PDF：

```java
// 实例化代表 PowerPoint 文件的 Presentation 对象 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // 设置幻灯片类型和大小 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在笔记幻灯片视图中转换 PowerPoint 为 PDF**

以下 Java 代码演示了如何将 PowerPoint 转换为 PDF 笔记：

```java
// 实例化代表 PowerPoint 文件的 Presentation 类
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任一合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 Java 代码演示了在一种 PowerPoint 到 PDF 转换操作中，基于不同合规标准获得多个 PDF 的过程：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 对 PDF 转换操作的支持扩展到允许您将 PDF 转换为最流行的文件格式。您可以进行 [PDF 到 HTML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-html/)、[PDF 到图像](https://products.aspose.com/slides/androidjava/conversion/pdf-to-image/)、[PDF 到 JPG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-jpg/) 和 [PDF 到 PNG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-png/) 的转换。其他 PDF 转换操作到专业格式——[PDF 到 SVG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-svg/)、[PDF 到 TIFF](https://products.aspose.com/slides/androidjava/conversion/pdf-to-tiff/) 和 [PDF 到 XML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}