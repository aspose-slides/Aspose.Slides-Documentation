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
description: "Конвертируйте PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в C++ с помощью Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т. д.) в формат PDF с помощью C++ предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования презентации. В этом руководстве демонстрируется, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для преобразования и применять стандарты соответствия к результирующим документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и затем сохраните презентацию в PDF с помощью метода `Save`. Класс [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) предоставляет метод `Save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ вставляет информацию о своем API и номер версии в генерируемые документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в формате "*Aspose.Slides v XX.XX*". **Примечание**: изменить или удалить эту информацию из генерируемых документов с помощью Aspose.Slides нельзя.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное соответствие полученных PDF оригинальным презентациям. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальными уровнями качества.

Следующий код на C++ показывает, как конвертировать презентацию (PPT, PPTX, ODP и т. д.) в PDF:
```c++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Сохраните презентацию в PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн **конвертер PowerPoint в PDF**(https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предлагает пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), которые позволяют настроить получаемый PDF, защитить его паролем или задать порядок выполнения процесса конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующий, как преобразовать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```c++
// Создайте объект класса PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Установите качество JPG‑изображений.
pdfOptions->set_JpegQuality(90);

// Установите DPI для изображений.
pdfOptions->set_SufficientResolution(300);

// Установите поведение для метафайлов.
pdfOptions->set_SaveMetafilesAsPng(true);

// Установите уровень сжатия текста для текстового содержимого.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Определите режим соответствия PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument файл.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Сохраните презентацию как PDF‑документ.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в виде страниц в получаемый PDF.

Следующий код на C++ показывает, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
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

Этот код на C++ демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/):
```c++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
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


### **Обнаружение замен шрифтов**

Aspose.Slides предоставляет метод [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) в классе [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий код на C++ показывает, как обнаружить замену шрифтов:
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
    // Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument файл.
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

Для получения дополнительной информации о получении обратных вызовов при замене шрифтов в процессе рендеринга см. [Getting Warning Callbacks for Fonts Substitution](/slides/ru/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения более подробных сведений о замене шрифтов см. статью [Font Substitution](/slides/ru/cpp/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Следующий код на C++ демонстрирует, как конвертировать только определённые слайды из презентации PowerPoint в PDF:
```C++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Задайте массив номеров слайдов.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Сохраните презентацию в PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Следующий код на C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Создайте новую презентацию с изменённым размером слайда.
auto resizedPresentation = MakeObject<Presentation>();

// Установите пользовательский размер слайда.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **Конвертация PowerPoint в PDF в режиме заметок к слайдам**

Следующий код на C++ демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки к слайдам:
```C++
// Создайте объект класса Presentation, представляющий файл PowerPoint или OpenDocument.
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


## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Следующий код на C++ демонстрирует процесс конвертации PowerPoint в PDF, который создаёт несколько PDF‑файлов на основе разных стандартов соответствия:
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

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Используйте метод `set_ShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Сможет ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как `set_JpegQuality` и `set_SufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для C++](/slides/ru/cpp/)
- [Справочник API Aspose.Slides для C++](https://reference.aspose.com/slides/cpp/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)