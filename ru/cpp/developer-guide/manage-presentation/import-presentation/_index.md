---
title: Импорт презентаций из PDF или HTML на C++
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
description: "Легко импортируйте документы PDF и HTML в презентации PowerPoint и OpenDocument на C++ с помощью Aspose.Slides для беспроблемной и высокопроизводительной обработки слайдов."
---
## **Введение**

Используя [**Aspose.Slides for C++**](https://products.aspose.com/slides/ru/cpp/), вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.slide_collection) для импорта презентаций из PDF, HTML‑документов и т. д.

## **Импорт PowerPoint из PDF**

В этом случае вы преобразуете PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса Presentation.  
2. Вызовите метод [AddFromPdf()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) и передайте файл PDF.  
3. Используйте метод [Save()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) для сохранения файла в формате PowerPoint.

This C++ code demonstrates the PDF to PowerPoint operation:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
Возможно, вам будет интересен бесплатный веб‑приложение **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ru/import/pdf-to-powerpoint), так как оно демонстрирует процесс в реальном времени. 
{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вы преобразуете HTML‑документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation/) .  
2. Вызовите метод [AddFromHtml()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) и передайте файл HTML.  
3. Используйте метод [Save()](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) для сохранения файла в формате PowerPoint.

This C++ code demonstrates the HTML to PowerPoint operation:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Вы также можете использовать Aspose.Slides для преобразования HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/ru/cpp/conversion/html-to-image/)  
* [HTML в JPG](https://products.aspose.com/slides/ru/cpp/conversion/html-to-jpg/)  
* [HTML в XML](https://products.aspose.com/slides/ru/cpp/conversion/html-to-xml/)  
* [HTML в TIFF](https://products.aspose.com/slides/ru/cpp/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

### Сохраняются ли таблицы при импорте PDF и можно ли улучшить их обнаружение?

Таблицы могут быть обнаружены во время импорта; [PdfImportOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/pdfimportoptions/) включает метод [set_DetectTables](https://reference.aspose.com/slides/ru/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/), который включает распознавание таблиц. Эффективность зависит от структуры PDF.