---
title: 在Java中将PowerPoint转换为PDF
linktitle: 将PowerPoint转换为PDF
type: docs
weight: 40
url: /zh/java/convert-powerpoint-to-pdf/
keywords:
- 转换PowerPoint
- 演示文稿
- PowerPoint转PDF
- PPT转PDF
- PPTX转PDF
- 将PowerPoint保存为PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides for Java
description: "在Java中将PowerPoint演示文稿转换为PDF。按照合规或可访问性标准将PowerPoint保存为PDF。"
---

## **概述**

将PowerPoint文档转换为PDF格式有几个优点，包括确保在不同设备上的兼容性以及保持演示文稿的布局和格式。本文将向您展示如何将演示文稿转换为PDF文档，使用各种选项控制图像质量，包含隐藏幻灯片，用密码保护PDF文档，检测字体替换，选择要转换的幻灯片，以及将合规标准应用于输出文档。

## **PowerPoint到PDF的转换**

使用Aspose.Slides，您可以将以下格式的演示文稿转换为PDF：

* PPT
* PPTX
* ODP

要将演示文稿转换为PDF，您只需将文件名作为参数传递给[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类，然后使用[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)方法将演示文稿保存为PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类公开了[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)方法，该方法通常用于将演示文稿转换为PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Java直接在输出文档中写入API信息和版本号。例如，当它将演示文稿转换为PDF时，Aspose.Slides for Java将“应用程序”字段填充为“*Aspose.Slides*”的值，“PDF生成器”字段填充为“*Aspose.Slides v XX.XX*”的值。**注意**，您无法指示Aspose.Slides for Java更改或删除此信息。

{{% /alert %}}

Aspose.Slides允许您转换：

* 整个演示文稿为PDF
* 演示文稿中的特定幻灯片为PDF
* 一个演示文稿 

Aspose.Slides以一种方式将演示文稿导出为PDF，使得生成的PDF内容与原始演示文稿非常相似。这些已知元素和属性在演示文稿到PDF的转换中通常正确呈现：

* 图像
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将PowerPoint转换为PDF**

标准的PowerPoint PDF转换操作使用默认选项执行。在这种情况下，Aspose.Slides尝试使用最佳设置在最大质量级别下将所提供的演示文稿转换为PDF。

以下Java代码显示了如何将PowerPoint转换为PDF：

```java
// 实例化一个表示PowerPoint文件的Presentation类
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // 将演示文稿保存为PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose提供一个免费的在线[**PowerPoint到PDF转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到PDF的转换过程。要测试这里描述的程序的实时实现，您可以使用该转换器进行测试。

{{% /alert %}}

## **使用选项将PowerPoint转换为PDF**

Aspose.Slides提供自定义选项——[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)类下的属性——允许您自定义PDF（源自转换过程的结果），用密码锁定PDF，甚至指定转换过程的方式。

### **使用自定义选项将PowerPoint转换为PDF**

使用自定义转换选项，您可以设置光栅图像的首选质量设置，指定如何处理元文件，为文本设置压缩级别，设置图像的DPI等。

以下代码示例演示了在多个自定义选项下将PowerPoint演示文稿转换为PDF的操作：

```java
// 实例化PdfOptions类
PdfOptions pdfOptions = new PdfOptions();

// 设置JPG图像的质量
pdfOptions.setJpegQuality((byte)90);

// 设置图像的DPI
pdfOptions.setSufficientResolution(300);

// 设置元文件的行为
pdfOptions.setSaveMetafilesAsPng(true);

// 设置文本内容的压缩等级
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// 定义PDF合规模式
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// 实例化一个表示PowerPoint文档的Presentation类
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 保存演示文稿为PDF文档
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **包含隐藏幻灯片将PowerPoint转换为PDF**

如果演示文稿包含隐藏幻灯片，您可以使用一个自定义选项——[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)类中的[ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--)属性——指示Aspose.Slides将隐藏幻灯片作为生成的PDF中的页面包含。

以下Java代码显示了如何将PowerPoint演示文稿转换为PDF，同时包含隐藏幻灯片：

```java
// 实例化一个表示PowerPoint文件的Presentation类
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 实例化PdfOptions类
    PdfOptions pdfOptions = new PdfOptions();
    
    // 添加隐藏幻灯片
    pdfOptions.setShowHiddenSlides(true);
    
    // 保存演示文稿为PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **将PowerPoint转换为带密码保护的PDF**

以下Java代码显示了如何将PowerPoint转换为带密码保护的PDF（使用来自[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)类的保护参数）：

```java
// 实例化一个表示PowerPoint文件的Presentation对象
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 实例化PdfOptions类
    PdfOptions pdfOptions = new PdfOptions();
    
    // 设置PDF密码和访问权限
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // 保存演示文稿为PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **检测字体替换**

Aspose.Slides提供了[SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/)类下的[getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--)方法，允许您在演示文稿到PDF转换过程中检测字体替换。

以下Java代码显示了如何检测字体替换：

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
            System.out.println("字体替换警告: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

有关在渲染过程中获取字体替换的回调的更多信息，请参见[获取字体替换的警告回调](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参见[字体替换](https://docs.aspose.com/slides/java/font-substitution/)一文。

{{% /alert %}} 

## **将选定幻灯片的PowerPoint转换为PDF**

以下Java代码显示了如何将PowerPoint演示文稿中的特定幻灯片转换为PDF：

```java
// 实例化一个表示PowerPoint文件的Presentation对象
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // 设置幻灯片的位置数组
    int[] slides = { 1, 3 };
    
    // 保存演示文稿为PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将PowerPoint转换为具有自定义幻灯片大小的PDF**

以下Java代码显示了如何将指定幻灯片大小的PowerPoint转换为PDF：

```java
// 实例化一个表示PowerPoint文件的Presentation对象 
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

## **在备注幻灯片视图中将PowerPoint转换为PDF**

以下Java代码显示了如何将PowerPoint转换为PDF备注：

```java
// 实例化一个表示PowerPoint文件的Presentation类
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

## **PDF的无障碍和合规标准**

Aspose.Slides允许您使用符合[网页内容无障碍指南（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的转换程序。您可以使用以下任何合规标准将PowerPoint文档导出为PDF：**PDF/A1a**、**PDF/A1b**和**PDF/UA**。

以下Java代码演示了在将PowerPoint转换为PDF的操作中，基于不同合规标准获取多个PDF：

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

Aspose.Slides对PDF转换操作的支持扩展到允许您将PDF转换为最流行的文件格式。您可以进行[PDF到HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF到图像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF到JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)和[PDF到PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/)的转换。其他PDF转换操作到专业格式——[PDF到SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF到TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)和[PDF到XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)——也得到了支持。

{{% /alert %}}