---
title: Конвертировать PPT и PPTX в PDF на C++ [Включены расширенные возможности]
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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, просматриваемые PDF на C++ с использованием Aspose.Slides, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C++ предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Презентация](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [Сохранить](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Класс [Презентация](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) предоставляет метод [Сохранить](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Примечание" %}}

Aspose.Slides for C++ вставляет информацию о своём API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в форме "*Aspose.Slides v XX.XX*". **Обратите внимание**, что вы не можете заставить Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки и максимальное качество.

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

{{% alert color="info" title="Примечание" %}}

Aspose предлагает бесплатный онлайн‑[**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для получения живой реализации процедуры, описанной здесь.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), — которые позволяют настроить результирующий PDF, защитить его паролем или задать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG = 90, разрешением изображения = 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

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

### **Сохранение встроенных OLE‑файлов как вложений PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным этой книги, а также просматривать слайды. Вызовите [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) с `true`, чтобы сохранить встроенные OLE‑файлы в виде вложений в результирующий PDF.

Значение по умолчанию — `false`: предварительный просмотр OLE‑объекта или его значок отображаются на странице PDF, но встроенный файл не включён как вложение. Установка опции в `true` дополнительно включает данные файла. Предпросмотр остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

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

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения, например в Adobe Acrobat Reader.
2. Откройте панель **Вложения** и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для просмотра данных, либо откройте напрямую, если просмотрщик это позволяет. Предпросмотр на странице PDF отделён от вложения.

{{% alert color="info" title="Примечание" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встроенные файлы, PDF/A‑2 позволяет только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. В этом примере используется значение соответствия PDF по умолчанию и не демонстрируется экспорт PDF/A.

{{% /alert %}}

### **Конвертация PowerPoint в PDF со скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), чтобы включить скрытые слайды в виде страниц в результирующий PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

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

### **Конвертация PowerPoint в PDF, защищённый паролем**

Следующий пример экспортирует презентацию в PDF, для открытия которого требуется пароль `password`. Права доступа позволяют печать, включая печать высокого качества.

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

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только тогда, когда недоступный шрифт заменяется при экспорте.

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

{{% alert color="info" title="Примечание" %}}

Дополнительную информацию о замене шрифтов см. в статье [Замена шрифтов](/slides/ru/cpp/font-substitution/).

{{% /alert %}} 

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у используемого шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть жирным за счёт синтетического утолщения, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от желаемого вида в PDF, попробуйте вызвать [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) с `true`. Эта опция рендерит затронутый текст как растровое изображение во время экспорта в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В образце презентации два текстовых блока: один с обычным текстом, другой с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. Следующий пример загружает презентацию, включает растризацию неподдерживаемых стилей шрифтов и экспортирует её в PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Ниже показаны предварительные просмотры вывода с отключённой и включённой опцией. В этом примере при отключённой опции жирный текст имеет более тяжёлые штрихи. При включённой опции штрихи стали легче; обычный текст остался без изменений. Сравните результаты перед выбором настройки для вашей презентации.

| Отключена опция (`false`, значение по умолчанию) | Включена опция (`true`) |
|---|---|
| ![PDF с отключённой растризацией неподдерживаемого стиля шрифта](unsupported-bold-disabled.png) | ![PDF с включённой растризацией неподдерживаемого стиля шрифта](unsupported-bold-enabled.png) |

В этом примере включение опции преобразует только жирный текст в растровое изображение: его нельзя выделить, скопировать или искать как текст без OCR, а его края выглядят мягче при увеличении в 800 %. Обычный текст остаётся поисковым. При отключённой опции обе строки остаются текстом.

Эта опция растризует текст, отформатированный как жирный, когда у шрифта нет отдельного жирного начертания. [Замена шрифтов](/slides/ru/cpp/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертация выбранных слайдов PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве нумеруются с 1, и входная презентация должна содержать как минимум три слайда.

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

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется для соответствия и экспортируется в PDF как одиночный слайд.

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

## **Конвертация PowerPoint в PDF в режиме заметок к слайдам**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A‑1a**, **PDF/A‑1b** и **PDF/UA**.

Этот код C++ демонстрирует процесс конвертации PowerPoint в PDF, который генерирует несколько PDF‑файлов на основе разных стандартов соответствия:

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

{{% alert color="info" title="Примечание" %}}

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетную конвертацию множества файлов PPT или PPTX в PDF. Вы можете проходить по своим файлам и программно применять процесс конвертации.

**Можно ли защищать полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Сможет ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) и [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A‑1a, PDF/A‑1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for C++](/slides/ru/cpp/)
- [API‑справочник Aspose.Slides for C++](https://reference.aspose.com/slides/cpp/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)