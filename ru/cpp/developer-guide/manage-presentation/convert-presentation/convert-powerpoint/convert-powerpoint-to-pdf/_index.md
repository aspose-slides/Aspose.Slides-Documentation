---
title: Преобразовать PPT и PPTX в PDF на C++ [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/cpp/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- конвертировать PPT в PDF
- PPTX в PDF
- конвертировать PPTX в PDF
- сохранить PowerPoint как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Преобразуйте PowerPoint PPT/PPTX в PDF высокого качества, с возможностью поиска, на C++ с помощью Aspose.Slides, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF на C++ предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертации PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) , а затем сохраните презентацию как PDF, используя метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) . Класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) , который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в форме "*Aspose.Slides v XX.XX*". **Примечание**: вы не можете указать Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, гарантируя, что полученные PDF‑файлы максимально соответствуют исходным презентациям. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Преобразовать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует настройки по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные параметры при максимальном качестве.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя настройки экспорта по умолчанию.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Преобразовать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) , которые позволяют настроить полученный PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Преобразовать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG, установленным на 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG и применяется компрессия текста Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную рабочую книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным рабочей книги, а также просматривать слайды. Вызовите [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) с `true`, чтобы сохранить встроенные OLE‑файлы в качестве вложений в получаемый PDF.

Значение по умолчанию — `false`: предпросмотр изображения или значка OLE‑объекта отображается на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Предпросмотр остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную рабочую книгу Excel, и экспортирует её в PDF с вложенной рабочей книгой.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Вложения** просмотрщика и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, или откройте его напрямую, если просмотрщик позволяет. Предпросмотр на странице PDF отделён от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает встроенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 позволяет другие типы файлов, включая рабочие книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В этом примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Преобразовать PowerPoint в PDF с скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) , чтобы включить скрытые слайды в качестве страниц в получаемом PDF.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Преобразовать PowerPoint в защищённый паролем PDF**

Следующий пример экспортирует презентацию в PDF, требующий пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) , позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда недоступный шрифт заменяется во время экспорта.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/cpp/font-substitution/).
{{% /alert %}} 

## **Преобразовать выбранные слайды из PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Преобразовать PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Он масштабирует содержимое слайда до размеров и экспортирует единственный слайд в PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Преобразовать PowerPoint в PDF в режиме заметок к слайдам**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C++ демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов на основе разных стандартов соответствия:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как одну фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить паролем полученный PDF?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в получаемый PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) и [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) , чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для C++](/slides/ru/cpp/)
- [Справочник API Aspose.Slides для C++](https://reference.aspose.com/slides/cpp/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)