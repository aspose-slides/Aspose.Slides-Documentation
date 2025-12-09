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
description: "Легко импортировать документы PDF и HTML в презентации PowerPoint и OpenDocument в .NET с помощью Aspose.Slides для бесшовной и высокопроизводительной обработки слайдов."
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

## **Импорт PowerPoint из PDF**

В этом случае вы можете преобразовать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Вызовите метод [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) и передайте PDF‑файл. 
3. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) для сохранения файла в формате PowerPoint.

Этот код на C# демонстрирует операцию преобразования PDF в PowerPoint:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Возможно, вам будет интересен бесплатный веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как оно представляет живую реализацию описанного здесь процесса. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы можете преобразовать HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Вызовите метод [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) и передайте HTML‑файл. 
3. Используйте метод [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) для сохранения файла как документ PowerPoint.

Этот код на C# демонстрирует операцию преобразования HTML в PowerPoint: 
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

Таблицы могут обнаруживаться при импорте; класс [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) содержит параметр [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/), который включает распознавание таблиц. Эффективность зависит от структуры PDF‑документа.

{{% alert title="Note" color="warning" %}} 
Вы также можете использовать Aspose.Slides для преобразования HTML в другие популярные форматы файлов: 

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}