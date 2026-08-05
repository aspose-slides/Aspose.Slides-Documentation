---
title: Конвертировать PPT и PPTX в PDF на C++ [Включены расширенные функции]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества с возможностью поиска в C++ с помощью Aspose.Slides, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF на C++ дает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, определять замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса[Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод`Save`. Класс[Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) предоставляет метод`Save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides для C++ вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в форме "*Aspose.Slides v XX.XX*". **Note** то, что изменить или удалить эту информацию из выходных документов вы не сможете.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигурки
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертировать PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным уровнем качества.

Этот код C++ показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:

```c++
// Создайте экземпляр класса Presentation, который представляет файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн[**PowerPoint to PDF converter**](https://products.aspose.app/slides/ru/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/), — которые позволяют настраивать получаемый PDF, защищать PDF паролем или указать, как должен проходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растрированных изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, показывающий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```c++
// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите качество JPG‑изображений.
pdfOptions->set_JpegQuality(90);

// Установите DPI для изображений.
pdfOptions->set_SufficientResolution(300);

// Установите поведение для метафайлов.
pdfOptions->set_SaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового контента.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Определите режим соответствия PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Создайте экземпляр класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Сохраните презентацию как PDF‑документ.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Конвертировать PowerPoint в PDF с скрытыми слайдами**

Если в презентации присутствуют скрытые слайды, вы можете использовать метод[set_ShowHiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в качестве страниц в получаемом PDF.

Этот код C++ показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```c++
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Добавьте скрытые слайды.
pdfOptions->set_ShowHiddenSlides(true);

// Сохраните презентацию как PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Конвертировать PowerPoint в PDF, защищённый паролем**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты класса[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/):

```c++
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите пароль PDF и права доступа.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Сохраните презентацию как PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Определение замен шрифтов**

Aspose.Slides предоставляет метод[set_WarningCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/set_warningcallback/) в классе[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Этот код C++ показывает, как обнаружить замену шрифтов:

```c++
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
    // Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Установите обратный вызов предупреждения в параметрах PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Сохраните презентацию как PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов в процессе рендеринга см. [Getting Warning Callbacks for Fonts Substitution](/slides/ru/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения более подробной информации о замене шрифтов см. статью[Font Substitution](/slides/ru/cpp/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот код C++ демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:

```C++
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Установите массив номеров слайдов.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Сохраните презентацию как PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF с заданным размером слайда:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Конвертировать PowerPoint в PDF в режиме заметок слайдов**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:

```C++
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Настройте параметры PDF с расположением заметок.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Сохраните презентацию в PDF с заметками.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C++ демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑документов в соответствии с разными стандартами соответствия:

```C++
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

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять[PDF to HTML](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-html/),[PDF to image](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-image/),[PDF to JPG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-jpg/), и[PDF to PNG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-png/)конвертации. Другие операции конвертации PDF в специализированные форматы —[PDF to SVG](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-svg/),[PDF to TIFF](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-tiff/), и[PDF to XML](https://products.aspose.com/slides/ru/cpp/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

> **Note:** При экспорте в PDF/UA Aspose.Slides рассматривает сложные графические элементы, такие как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для целого объекта.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Конечно. Используйте класс[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод`set_ShowHiddenSlides` класса[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как`set_JpegQuality` и`set_SufficientResolution` в классе[PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for C++ Documentation](/slides/ru/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/ru/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ru/conversion)