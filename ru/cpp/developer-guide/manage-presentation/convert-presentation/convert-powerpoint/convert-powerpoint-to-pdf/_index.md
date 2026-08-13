---
title: Конвертация PPT и PPTX в PDF на C++ [включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/cpp/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентацию в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества, с возможностью поиска, на C++ с помощью Aspose.Slides, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C++ предлагает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и затем сохраните презентацию как PDF, вызвав метод `Save`. Класс [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) предоставляет метод `Save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ вставляет информацию о своей API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Примечание** что изменить или удалить эту информацию из выходных документов с помощью Aspose.Slides нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* полностью презентацию в PDF
* отдельные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие полученных PDF оригинальным презентациям. При конвертации точно отображаются элементы и атрибуты, включая:

* изображения
* текстовые блоки и фигуры
* форматирование текста
* форматирование абзацев
* гиперссылки
* колонтитулы
* маркеры
* таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки и максимальное качество.

Этот код на C++ показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Сохраните презентацию в формате PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose предоставляет бесплатный онлайн [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) — которые позволяют настроить получаемый PDF, защитить его паролем или задать порядок выполнения процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочитаемое качество растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите качество для JPG изображений.
pdfOptions->set_JpegQuality(90);

// Установите DPI для изображений.
pdfOptions->set_SufficientResolution(300);

// Установите поведение для метафайлов.
pdfOptions->set_SaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержимого.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Определите режим соответствия PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Сохраните презентацию в виде PDF документа.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Конвертация PowerPoint в PDF с включёнными скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующий PDF.

Этот код на C++ показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Добавить скрытые слайды.
pdfOptions->set_ShowHiddenSlides(true);

// Сохраните презентацию в формате PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Конвертация PowerPoint в защищённый паролем PDF**

Этот код на C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите пароль PDF и разрешения доступа.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Сохраните презентацию в PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/set_warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код на C++ показывает, как обнаружить замену шрифтов:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Реализация обратного вызова предупреждения.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Установите обратный вызов предупреждения в параметрах PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Сохраните презентацию в формате PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов во время процесса рендеринга см. [Getting Warning Callbacks for Fonts Substitution](/slides/ru/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/cpp/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот код на C++ демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Задайте массив номеров слайдов.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Сохраните презентацию в формате PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код на C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
auto resizedPresentation = MakeObject<Presentation>();

// Установите пользовательский размер слайда.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Клонируйте первый слайд из исходной презентации.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Сохраните изменённую презентацию в PDF с заметками.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Конвертация PowerPoint в PDF в режиме просмотра заметок**

Этот код на C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте объект класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Настройте параметры PDF с разметкой заметок.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Сохраните презентацию в PDF с заметками.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процесс конвертации, соответствующий [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код на C++ демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с различными стандартами соответствия:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF to HTML](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-jpg/), и [PDF to PNG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **Часто задаваемые вопросы**

### Можно ли конвертировать несколько файлов PowerPoint в PDF массово?

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

### Можно ли защитить полученный PDF паролем?

Безусловно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

### Как включить скрытые слайды в PDF?

Используйте метод `set_ShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

### Может ли Aspose.Slides сохранять высокое качество изображений в PDF?

Да, вы можете управлять качеством изображений, используя методы такие как `set_JpegQuality` и `set_SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

### Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for C++ Documentation](/slides/ru/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/ru/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ru/conversion)