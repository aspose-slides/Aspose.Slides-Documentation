---
title: 在 .NET 中从 PDF 或 HTML 导入演示文稿
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/net/import-presentation/
keywords:
- 导入演示文稿
- 导入幻灯片
- 导入 PDF
- 导入 HTML
- PDF 转演示文稿
- PDF 转 PPT
- PDF 转 PPTX
- PDF 转 ODP
- HTML 转演示文稿
- HTML 转 PPT
- HTML 转 PPTX
- HTML 转 ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides，在 .NET 中轻松将 PDF 和 HTML 文档导入 PowerPoint 和 OpenDocument 演示文稿，实现无缝、高性能的幻灯片处理。"
---

使用 [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) 类，以便从 PDF 文档导入演示文稿。

## **从 PDF 导入 PowerPoint**

在此示例中，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 创建 Presentation 类的实例。 
2. 调用 [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) 方法并传入 PDF 文件。 
3. 使用 [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) 方法将文件保存为 PowerPoint 格式。

以下 C# 代码演示了 PDF 到 PowerPoint 的转换操作：
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
您可能想了解 **Aspose free** 的[PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)网络应用，因为它是本文所述过程的实时实现。 
{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在此示例中，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 Presentation 类的实例。 
2. 调用 [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) 方法并传入 HTML 文件。 
3. 使用 [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) 方法将文件保存为 PowerPoint 文档。

以下 C# 代码演示了 HTML 到 PowerPoint 的转换操作： 
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


## **FAQ**

**在导入 PDF 时表格会被保留吗？是否可以改进其检测？**

在导入过程中可以检测到表格；[PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) 包含一个 [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) 参数，可启用表格识别。其效果取决于 PDF 的结构。

{{% alert title="Note" color="warning" %}} 
您还可以使用 Aspose.Slides 将 HTML 转换为其他常用文件格式： 

* [HTML 转图像](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}