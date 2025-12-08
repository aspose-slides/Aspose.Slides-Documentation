---
title: Импорт PowerPoint из PDF или HTML
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/net/import-presentation/
keywords: "Импорт PowerPoint, PDF в PowerPoint, HTML в PowerPoint, PDF в PPT, HTML в PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Импорт PowerPoint из PDF или HTML. Преобразовать PDF в PowerPoint. Преобразовать HTML в PowerPoint"
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

## **Импорт PowerPoint из PDF**

В этом случае вы преобразуете PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Вызовите метод [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) и передайте PDF‑файл.
3. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) для сохранения файла в формате PowerPoint.

This C# code demonstrates the PDF to PowerPoint operation:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Возможно, вам будет интересно попробовать бесплатное веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как оно представляет живую реализацию описанного здесь процесса. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы преобразуете HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Вызовите метод [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) и передайте HTML‑файл.
3. Используйте метод [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) для сохранения файла как документ PowerPoint.

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

Таблицы могут обнаруживаться во время импорта; [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) включает параметр [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/), который активирует распознавание таблиц. Эффективность зависит от структуры PDF.

{{% alert title="Note" color="warning" %}} 
Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}