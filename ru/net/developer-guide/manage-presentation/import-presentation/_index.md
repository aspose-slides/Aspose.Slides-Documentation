---
title: Импорт презентаций из PDF или HTML в .NET
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/net/import-presentation/
keywords:
- импорт презентации
- импорт слайда
- импорт PDF
- импорт HTML
- PDF в презентацию
- PDF в PPT
- PDF в PPTX
- PDF в ODP
- HTML в презентацию
- HTML в PPT
- HTML в PPTX
- HTML в ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Легко импортировать PDF и HTML документы в презентации PowerPoint и OpenDocument в .NET с помощью Aspose.Slides для бесшовной, высокопроизводительной обработки слайдов."
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

## **Импорт PowerPoint из PDF**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) method and pass the PDF file. 
3. Use the [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file in the PowerPoint format.

This C# code demonstrates the PDF to PowerPoint operation:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="СОВЕТ" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
2. Call the [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) method and pass the HTML file. 
3. Use the [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) method to save the file as a PowerPoint document.

This C# code demonstrates the HTML to PowerPoint operation: 
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

**Сохраняются ли таблицы при импорте PDF и можно ли улучшить их обнаружение?**

Tables can be detected during import; [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) includes a [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) parameter that enables table recognition. The effectiveness depends on the PDF’s structure.

{{% alert title="Примечание" color="warning" %}} 

You may also use Aspose.Slides to convert HTML to other popular file formats: 

* [HTML в изображение](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}