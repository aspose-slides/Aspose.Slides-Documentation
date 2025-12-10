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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в PDF высокого качества с возможностью поиска в C++ с использованием Aspose.Slides, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в C++ предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. Это руководство демонстрирует, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

Используя Aspose.Slides, вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод `Save`. Класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) предоставляет метод `Save`, который обычно используется для конвертации презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ вставляет информацию об API и номер версии в выходные документы. Например, при конвертации презентации в PDF, Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением в формате "*Aspose.Slides v XX.XX*". **Note** что вы не можете указать Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Все презентации в PDF
* Конкретные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая, что полученные PDF‑файлы максимально соответствуют оригинальным презентациям. Элементы и атрибуты отображаются точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркированные списки
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

Этот код C++ показывает, как конвертировать презентацию (PPT, PPTX, ODP и т.д.) в PDF:
```c++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Сохраните презентацию в PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 
Aspose предлагает бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс конвертации презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), которые позволяют настроить полученный PDF, заблокировать PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия для текста, настроить DPI для изображений и многое другое.

Пример кода ниже демонстрирует, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```c++
// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите качество для JPG-изображений.
pdfOptions->set_JpegQuality(90);

// Установите DPI для изображений.
pdfOptions->set_SufficientResolution(300);

// Задайте поведение для метафайлов.
pdfOptions->set_SaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержимого.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Определите режим соответствия PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument файл.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Сохраните презентацию как PDF-документ.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в качестве страниц в получаемом PDF.

Этот код C++ показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```c++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Добавьте скрытые слайды.
pdfOptions->set_ShowHiddenSlides(true);

// Сохраните презентацию в PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Конвертация PowerPoint в PDF, защищённый паролем**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите пароль PDF и права доступа.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Сохраните презентацию в PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаружить замену шрифтов во время процесса конвертации презентации в PDF.

Этот код C++ показывает, как обнаружить замену шрифтов:
```c++
// Реализация обработчика предупреждений.
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
    // Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Установите обработчик предупреждений в параметрах PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Сохраните презентацию в PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 
Для получения дополнительной информации о получении callbacks для замены шрифтов во время процесса рендеринга, смотрите [Getting Warning Callbacks for Fonts Substitution](/slides/ru/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов, см. статью [Font Substitution](/slides/ru/cpp/font-substitution/).
{{% /alert %}}

## **Конвертация выбранных слайдов из PowerPoint в PDF**

Этот код C++ демонстрирует, как конвертировать только конкретные слайды из презентации PowerPoint в PDF:
```C++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Установите массив номеров слайдов.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Сохраните презентацию в PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
auto resizedPresentation = MakeObject<Presentation>();

// Установите пользовательский размер слайда.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Клонируйте первый слайд из оригинальной презентации.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Сохраните изменённую презентацию в PDF с заметками.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **Конвертация PowerPoint в PDF в виде слайдов с примечаниями**

Этот код C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF с включёнными примечаниями:
```C++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configure the PDF options with Notes Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to a PDF with notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код C++ демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов в соответствии с различными стандартами соответствия:
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
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

## **FAQ**

**Могу ли я конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Конечно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `set_ShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в получаемый PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы, такие как `set_JpegQuality` и `set_SufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для C++](/slides/ru/cpp/)
- [Ссылка на API Aspose.Slides для C++](https://reference.aspose.com/slides/cpp/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)