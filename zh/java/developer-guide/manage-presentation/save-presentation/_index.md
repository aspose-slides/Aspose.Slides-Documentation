---
title: 保存演示文稿
type: docs
weight: 80
url: /zh/java/save-presentation/
---

## **概述**
{{% alert color="primary" %}} 

[打开演示文稿](/slides/zh/java/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类打开演示文稿。本文解释了如何创建和保存演示文稿。

{{% /alert %}} 

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类保存演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都希望保存演示文稿。使用 Aspose.Slides for Java，可以将其保存为 **文件** 或 **流**。本文解释了如何以不同方式保存演示文稿：

## **将演示文稿保存为文件**
通过调用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的 [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法将演示文稿保存为文件。只需将文件名和 [**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) 传递给 [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法。

下面的示例演示了如何使用 Aspose.Slides for Java 保存演示文稿。

```java
// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // ...在此处执行一些工作...
    
    // 将演示文稿保存到文件中
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **将演示文稿保存为流**
可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的 [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) 方法，将演示文稿保存为流。可以保存演示文稿的多种类型的流。在下面的示例中，我们创建了一个新的演示文稿文件，在形状中添加文本，并将演示文稿保存到流中。

```java
// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // 向形状添加文本
    shape.getTextFrame().setText("此演示展示了如何创建 PowerPoint 文件并将其保存到流中。");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用预定义视图类型保存演示文稿**
Aspose.Slides for Java 提供了一个功能，可以在通过 [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) 类打开生成的演示文稿时设置视图类型。[**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) 属性用于通过使用 [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType) 枚举来设置视图类型。

```java
// 打开演示文稿文件
Presentation pres = new Presentation();
try {
    // 设置视图类型
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // 保存演示文稿
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将演示文稿保存为严格的 Office Open XML 格式**
Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。为此，它提供了 [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) 类，您可以在保存演示文稿文件时设置 Conformance 属性。如果您将其值设置为 [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict)，则输出演示文稿文件将以严格的 Open XML 格式保存。

以下示例代码创建一个演示文稿，并以严格的 Office Open XML 格式保存它。在为演示文稿调用 [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法时，将带有 Conformance 属性设置为 [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict) 的 [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) 对象传递给它。

```java
// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加类型为线的自动形状
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // 设置严格的 Office Open XML 格式保存选项
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // 将演示文稿保存到文件中
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **将演示文稿保存为 Office Open XML 格式的 Zip64 模式**

Office Open XML 文件是一个 ZIP 压缩文件，具有 4 GB (2^32 字节) 的限制，适用于未压缩文件的大小、压缩文件的大小和压缩包的总大小，以及在压缩包中 65,535 (2^16-1) 个文件的限制。ZIP64 格式扩展将这些限制提高到 2^64。

新的 [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) 属性允许您选择何时对保存的 Office Open XML 文件使用 ZIP64 格式扩展。

此属性提供以下模式：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) 意味着只有在演示文稿超出上述限制时才使用 ZIP64 格式扩展。这是默认模式。
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) 意味着不使用 ZIP64 格式扩展。
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) 意味着始终使用 ZIP64 格式扩展。

下面的代码演示了如何使用 ZIP64 格式扩展将演示文稿保存为 PPTX 格式：

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}}

以 Zip64Mode.Never 模式保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/) 。

{{% /alert %}}

## **以百分比保存进度更新**
新的 [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) 接口已添加到 [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) 接口和 [**SaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions) 抽象类中。 [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) 接口表示一个用于保存进度更新的回调对象，进度更新以百分比表示。

下面的代码片段展示了如何使用 [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) 接口：

```java
// 打开演示文稿文件
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // 在这里使用进度百分比值
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% 文件已转换");
    }
}
```

{{% alert title="信息" color="info" %}}

使用其自己的 API，Aspose 开发了一个 [免费的 PowerPoint 分割器应用](https://products.aspose.app/slides/splitter)，允许用户将他们的演示文稿拆分成多个文件。本质上，该应用将给定演示文稿的选定幻灯片保存为新的 PowerPoint (PPTX 或 PPT) 文件。 

{{% /alert %}}