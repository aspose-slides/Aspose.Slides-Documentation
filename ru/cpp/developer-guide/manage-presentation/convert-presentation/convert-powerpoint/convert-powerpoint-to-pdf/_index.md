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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поддерживаемые поиск по тексту PDF в C++ с помощью Aspose.Slides, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.п.) в формат PDF на C++ предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и затем сохраните презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ вставляет информацию о своей API и номер версии в итоговые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer – значением вида "*Aspose.Slides v XX.XX*". **Обратите внимание**, что вы не можете указать Aspose.Slides изменить или удалить эту информацию из итоговых документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая точное соответствие полученных PDF оригинальным презентациям. При конвертации точно сохраняются элементы и атрибуты, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

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

Aspose предлагает бесплатный онлайн‑конвертер [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), позволяющие настроить результирующий PDF, установить пароль защиты или задать правила конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, задать DPI для изображений и многое другое.

В следующем примере экспортируется презентация в PDF 1.5 с качеством JPEG = 90, разрешением изображения = 300 DPI, метафайлы сохраняются как PNG, а текст сжимается с помощью Flate.

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

### **Автоматический выбор сжатия изображений**

Если в презентации содержится множество фотографий или скриншотов, уменьшение размера экспортируемого PDF упростит его отправку по электронной почте или загрузку. Вызовите [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) с `true`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

В следующем примере загружается существующая презентация, включается автоматический выбор сжатия изображений и сохраняется как PDF‑документ. Все остальные параметры экспорта PDF сохраняются со значениями по умолчанию.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение качества JPEG с помощью [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) уменьшает качество JPEG‑изображений, а понижение разрешения с помощью [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) позволяет понизить разрешение изображений, что также может снизить детали. Включение автоматического выбора сжатия само по себе не меняет ни одного из этих параметров.

Выбор алгоритмов сжатия изображений требует дополнительных вычислительных ресурсов и памяти. Степень уменьшения размера зависит от изображений в презентации и параметров экспорта; фиксированное сокращение не гарантировано для каждой презентации.

### **Сохранение встроенных OLE‑файлов как вложений PDF**

Если в презентации находится встроенная рабочая книга Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным этой книги, а также просматривать слайды. Вызовите [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) с `true`, чтобы сохранить встроенные OLE‑файлы в виде вложений в результирующем PDF.

Значение по умолчанию — `false`: в PDF отображается превью‑изображение или значок OLE‑объекта, но сам встроенный файл не включается как вложение. Установка параметра в `true` также добавляет данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не становится интерактивной таблицей Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную рабочую книгу Excel, и экспортируется в PDF с прикреплённой книгой.

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
2. Откройте панель **Attachments** и найдите встроенную рабочую книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}

Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает встроенные файлы, PDF/A‑2 допускает только вложения PDF/A, а PDF/A‑3 допускает другие типы файлов, включая рабочие книги Excel. Эти ограничения являются требованиями стандартов, а не особенностями Aspose.Slides. В данном примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.

{{% /alert %}}

### **Конвертация PowerPoint в PDF с включёнными скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в результирующий PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

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

### **Конвертация PowerPoint в PDF с защитой паролем**

В следующем примере презентация экспортируется в PDF, который требует пароль `password` для открытия. Права доступа позволяют печать, включая печать высокого качества.

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

### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение печатается только тогда, когда недоступный шрифт заменяется во время экспорта.

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

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/cpp/font-substitution/).

{{% /alert %}} 

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического утолщения, которое искусственно расширяет обычные глифы. Если такой текст выглядит слишком тяжёлым или отличается от ожидаемого вида в PDF, попробуйте вызвать [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) с `true`. Этот параметр рендерит затронутый текст в виде растрового изображения при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

Примерная презентация содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. В следующем примере загружается презентация, включается растрирование неподдерживаемых стилей шрифта и экспортируется в PDF:

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

Ниже показаны превью с отключённым и включённым режимом. В этом примере полужирный текст имеет более тяжёлые штрихи при отключённом параметре. При включённом параметре штрихи становятся тоньше; обычный текст остаётся без изменений. Сравните результаты, прежде чем выбрать настройку для своей презентации.

| Опция отключена (`false`, по умолчанию) | Опция включена (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение параметра преобразует только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его контуры выглядят мягче при увеличении до 800 %. Обычный текст остаётся доступным для поиска. При отключённом параметре обе строки остаются текстом.

Этот параметр растрирует текст, отформатированный как полужирный, когда у шрифта нет отдельного жирного начертания. [Font substitution](/slides/ru/cpp/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертация выбранных слайдов PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве являются 1‑based, и исходная презентация должна содержать минимум три слайда.

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

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 точек (8,5 × 11 дюймов). Содержание слайда масштабируется под размер и экспортируется в PDF как один слайд.

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

## **Конвертация PowerPoint в PDF в режиме "Заметки к слайдам"**

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C++ демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:

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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) и [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли пакетно конвертировать несколько файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает массовую конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применять процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) и [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивного хранения.

## **Дополнительные ресурсы**

- [Aspose.Slides for C++ Documentation](/slides/ru/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)