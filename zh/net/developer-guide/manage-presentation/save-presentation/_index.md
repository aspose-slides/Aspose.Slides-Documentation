---
title: 在.NET中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/net/save-presentation/
keywords: "保存PowerPoint, PPT, PPTX, 保存演示文稿, 文件, 流, C#, Csharp, .NET"
description: "在C#或.NET中将PowerPoint演示文稿保存为文件或流"
---

## **保存演示文稿**
打开演示文稿描述了如何使用[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类打开演示文稿。本文解释了如何创建和保存演示文稿。
[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类持有演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都希望保存演示文稿。使用Aspose.Slides for .NET，可以将其保存为**文件**或**流**。本文解释了如何以不同方式保存演示文稿：

### **将演示文稿保存为文件**
通过调用[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)方法将演示文稿保存为文件。只需将文件名和保存格式传递给[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)方法。以下示例显示了如何使用C#和Aspose.Slides for .NET保存演示文稿。

```c#
// 实例化一个表示PPT文件的Presentation对象
Presentation presentation= new Presentation();

//...在这里做一些工作...

// 将您的演示文稿保存到文件
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **将演示文稿保存为流**
通过将输出流传递给[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的Save方法，可以将演示文稿保存为流。有多种类型的流可以保存演示文稿。在下面的示例中，我们创建了一个新的演示文稿文件，在形状中添加文本，并将演示文稿保存到流中。

```c#
// 实例化一个表示PPT文件的Presentation对象
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // 向形状添加文本
    shape.TextFrame.Text = "此演示展示了如何创建PowerPoint文件并将其保存到流中。";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```


### **保存具有预定义视图类型的演示文稿**
Aspose.Slides for .NET提供了一种功能，可以在PowerPoint中打开生成的演示文稿时设置视图类型，通过[ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)类。[LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview)属性用于通过使用[ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype)枚举来设置视图类型。

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **将演示文稿保存为严格的Office Open XML格式**
Aspose.Slides允许您将演示文稿保存为严格的Office Open XML格式。为此，它提供了[**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)类，您可以在保存演示文稿文件时设置Conformance属性。如果将其值设置为Conformance.Iso29500_2008_Strict，则输出的演示文稿文件将以严格的Office Open XML格式保存。

以下示例代码创建一个演示文稿并将其保存为严格的Office Open XML格式。在调用演示文稿的Save方法时，将**[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)**对象传递给它，并将[**Conformance**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance)属性设置为[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/net/aspose.slides.export/conformance)。

```csharp
   // 实例化一个表示演示文稿文件的Presentation对象
   using (Presentation presentation = new Presentation())
   {
       // 获取第一张幻灯片
       ISlide slide = presentation.Slides[0];

       // 添加一个类型为线的自动形状
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // 将演示文稿保存为严格的Office Open XML格式
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }
```

### **将演示文稿保存为Zip64模式的Office Open XML格式**
Office Open XML文件是一个ZIP存档，它在未压缩的文件大小、压缩的文件大小以及存档的总大小上有4 GB（2^32字节）的限制，存档中的文件限制为65,535（2^16-1）。ZIP64格式扩展可以将这些限制增加到2^64。

新的[**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/)属性允许您选择何时使用ZIP64格式扩展来保存Office Open XML文件。

该属性提供以下模式：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)意味着只有在演示文稿超出上述限制时，才会使用ZIP64格式扩展。这是默认模式。
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)意味着将不会使用ZIP64格式扩展。 
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/)意味着将始终使用ZIP64格式扩展。

以下C#代码演示了如何使用ZIP64格式扩展将演示文稿保存为PPTX格式：

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="注意" color="warning" %}}

在Zip64Mode.Never模式下保存时，如果演示文稿无法以ZIP32格式保存，将抛出[PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/)异常。

{{% /alert %}}

### **以百分比形式保存进度更新**
新的[**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback)接口已添加到[**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions)接口和[**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions)抽象类中。**IProgressCallback**接口表示一个回调对象，用于以百分比形式保存进度更新。

以下代码片段展示了如何使用IProgressCallback接口：

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}
```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 在此处使用进度百分比值
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% 文件已转换");
    }
}
```

{{% alert title="信息" color="info" %}}

使用其自己的API，Aspose开发了一个[免费的PowerPoint拆分器应用程序](https://products.aspose.app/slides/splitter)，允许用户将演示文稿拆分为多个文件。本质上，该应用将给定演示文稿中的选定幻灯片保存为新的PowerPoint（PPTX或PPT）文件。

{{% /alert %}}

<h2>打开和保存演示文稿</h2>

<a name="csharp-open-save-presentation"><strong>步骤：在C#中打开和保存演示文稿</strong></a>

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类的实例，使用任何格式，即PPT、PPTX、ODP等。
2. 将_Presentation_保存为[SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)支持的任何格式。

```c#
// 加载任何受支持的文件到Presentation，例如ppt、pptx、odp等。
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```