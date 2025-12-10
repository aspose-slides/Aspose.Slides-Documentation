---
title: Импорт презентаций из PDF или HTML в C++
linktitle: Импорт презентации
type: docs
weight: 60
url: /ru/cpp/import-presentation/
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
- C++
- Aspose.Slides
description: "Легко импортировать документы PDF и HTML в презентации PowerPoint и OpenDocument на C++ с помощью Aspose.Slides для беспрепятственной, высокопроизводительной обработки слайдов."
---

Используя [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), вы можете импортировать презентации из файлов других форматов. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection), позволяющий импортировать презентации из PDF, HTML‑документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вы можете преобразовать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте объект класса Presentation.  
2. Вызовите метод [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) и передайте PDF‑файл.  
3. Используйте метод [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), чтобы сохранить файл в формате PowerPoint.

Этот C++ код демонстрирует операцию преобразования PDF в PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 
Возможно, вам стоит обратить внимание на бесплатное веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) , так как оно демонстрирует процесс, описанный здесь. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы можете преобразовать HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).  
2. Вызовите метод [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) и передайте HTML‑файл.  
3. Используйте метод [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), чтобы сохранить файл в формате PowerPoint.

Этот C++ код демонстрирует операцию преобразования HTML в PowerPoint:
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/cpp/conversion/html-to-image/)  
* [HTML в JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)  
* [HTML в XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)  
* [HTML в TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/) 

{{% /alert %}}

## **FAQ**

**Сохраняются ли таблицы при импорте PDF и можно ли улучшить их обнаружение?**

Таблицы могут быть обнаружены при импорте; [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) включает метод [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/), который включает распознавание таблиц. Эффективность зависит от структуры PDF.