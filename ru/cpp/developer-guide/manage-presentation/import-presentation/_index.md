---
title: Импорт презентации - C++ PowerPoint API
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/cpp/import-presentation/
keywords: "Импорт PowerPoint, PDF в презентацию, PDF в PPTX, PDF в PPT, C++, Aspose.Slides для C++"
description: "Импорт презентации PowerPoint из PDF. Конвертировать PDF в PowerPoint"
---

Используя [**Aspose.Slides для C++**](https://products.aspose.com/slides/cpp/), вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection), который позволяет вам импортировать презентации из PDF, HTML-документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вы можете конвертировать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса презентации. 
2. Вызовите метод [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) и передайте PDF-файл. 
3. Используйте метод [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) для сохранения файла в формате PowerPoint.

Этот код на C++ демонстрирует операцию преобразования PDF в PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Совет" color="primary" %}} 

Вам может быть интересно ознакомиться с бесплатным веб-приложением **Aspose** [PDF в PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как это живая реализация процесса, описанного здесь. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы можете конвертировать HTML-документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). 
2. Вызовите метод [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) и передайте HTML-файл. 
3. Используйте метод [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) для сохранения файла в формате PowerPoint.

Этот код на C++ демонстрирует операцию преобразования HTML в PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Примечание" color="warning" %}} 

Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}