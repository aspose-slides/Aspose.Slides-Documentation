---
title: Импорт PowerPoint из PDF или HTML
linktitle: Импорт презентации
type: docs
weight: 60
url: /net/import-presentation/
keywords: "Импорт PowerPoint, PDF в PowerPoint, HTML в PowerPoint, PDF в PPT, HTML в PPT, C#, Csharp, Aspose.Slides для .NET"
description: "Импорт PowerPoint из PDF или HTML. Конвертировать PDF в PowerPoint. Конвертировать HTML в PowerPoint"
---

Используя [**Aspose.Slides для .NET**](https://products.aspose.com/slides/net/), вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) для того, чтобы вы могли импортировать презентации из PDF-документов.

## **Импорт PowerPoint из PDF**

В этом случае вы можете конвертировать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Вызовите метод [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) и передайте PDF-файл. 
3. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), чтобы сохранить файл в формате PowerPoint.

Этот код на C# демонстрирует операцию PDF в PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="СОВЕТ" color="primary" %}} 

Вам может быть интересно посмотреть на **бесплатное приложение Aspose** [PDF в PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как это живая реализация процесса, описанного здесь. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы можете конвертировать HTML-документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Вызовите метод [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) и передайте HTML-файл. 
3. Используйте метод [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), чтобы сохранить файл как документ PowerPoint.

Этот код на C# демонстрирует операцию HTML в PowerPoint: 

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

{{% alert title="Замечание" color="warning" %}} 

Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}