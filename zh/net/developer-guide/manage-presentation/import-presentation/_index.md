---
title: 从 PDF 或 HTML 导入 PowerPoint
linktitle: 导入演示文稿
type: docs
weight: 60
url: /net/import-presentation/
keywords: "导入 PowerPoint, PDF 转 PowerPoint, HTML 转 PowerPoint, PDF 转 PPT, HTML 转 PPT, C#, Csharp, Aspose.Slides for .NET"
description: "从 PDF 或 HTML 导入 PowerPoint。将 PDF 转换为 PowerPoint。将 HTML 转换为 PowerPoint"
---

使用 [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) 类，以便您从 PDF 文档中导入演示文稿。

## **从 PDF 导入 PowerPoint**

在本例中，您将把 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。 
2. 调用 [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) 方法并传入 PDF 文件。 
3. 使用 [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) 方法将文件保存为 PowerPoint 格式。

以下 C# 代码演示了 PDF 转 PowerPoint 的操作：

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="提示" color="primary" %}} 

您可能想查看 **Aspose 免费** [PDF 转 PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 网络应用，因为它是此处描述过程的实时实现。 

{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在本例中，您将把 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。 
2. 调用 [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) 方法并传入 HTML 文件。 
3. 使用 [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) 方法将文件保存为 PowerPoint 文档。

以下 C# 代码演示了 HTML 转 PowerPoint 的操作： 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

您还可以使用 Aspose.Slides 将 HTML 转换为其他流行文件格式： 

* [HTML 转图片](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}