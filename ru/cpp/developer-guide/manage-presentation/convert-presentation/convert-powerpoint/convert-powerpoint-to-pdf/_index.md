---
title: Конвертация PowerPoint в PDF на C++
linktitle: Конвертация PowerPoint в PDF
type: docs
weight: 40
url: /ru/cpp/convert-powerpoint-to-pdf/
keywords:
- конвертировать PowerPoint
- презентация
- PowerPoint в PDF
- PPT в PDF
- PPTX в PDF
- сохранить PowerPoint как PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides для C++
description: "Конвертация презентаций PowerPoint в PDF на C++. Сохраните PowerPoint как PDF с соблюдением стандартов совместимости или доступности."
---

## **Обзор**

Конвертация документов PowerPoint в формат PDF предлагает несколько преимуществ, включая обеспечение совместимости на различных устройствах и сохранение макета и форматирования вашей презентации. В этой статье показано, как конвертировать презентации в PDF-документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, устанавливать пароль на PDF-документы, обнаруживать замены шрифтов, выбирать слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конверсии PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* PPT
* PPTX
* ODP

Чтобы конвертировать презентацию в PDF, вам просто нужно передать имя файла в качестве аргумента в классе [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) и затем сохранить презентацию как PDF с помощью метода [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e). Класс [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) предоставляет метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), который обычно используется для конвертации презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides для C++ непосредственно записывает информацию об API и Номере версии в выходные документы. Например, когда он конвертирует презентацию в PDF, Aspose.Slides для C++ заполняет поле Application значением '*Aspose.Slides*' и поле PDF Producer значением формата '*Aspose.Slides v XX.XX*'. **Обратите внимание**, что вы не можете запрограммировать Aspose.Slides для C++, чтобы изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* целую презентацию в PDF
* конкретные слайды в презентации в PDF
* презентацию 

Aspose.Slides экспортирует презентации в PDF таким образом, что содержимое полученных PDF очень похоже на оригинальные презентации. Эти известные элементы и атрибуты часто правильно отображаются при конвертации презентации в PDF:

* изображения
* текстовые поля и другие фигуры
* тексты и их форматирование
* абзацы и их форматирование
* гиперссылки
* заголовки и колонтитулы
* маркеры
* таблицы

## **Конвертировать PowerPoint в PDF**

Стандартная операция конверсии PowerPoint в PDF выполняется с использованием параметров по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>Шаги: Конвертировать PowerPoint в PDF на C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>Шаги: Конвертировать PPT в PDF на C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>Шаги: Конвертировать PPTX в PDF на C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>Шаги: Конвертировать ODP в PDF на C++</strong></a>

Этот код на C++ показывает, как конвертировать PowerPoint в PDF:

```c++
// Создает экземпляр класса Presentation, который представляет файл PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// Сохраняет презентацию как PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Для живой реализации процедуры, описанной здесь, вы можете протестировать конвертер.

{{% /alert %}}

## **Конвертировать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет настраиваемые параметры — свойства под классом [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/), которые позволяют вам настроить PDF (результат процесса конвертации), защитить PDF паролем или даже указать, как должен проходить процесс конвертации.

### **Конвертировать PowerPoint в PDF с пользовательскими параметрами**

Используя настройки пользовательской конверсии, вы можете установить предпочитаемое качество для растровых изображений, указать, как следует обрабатывать метафайлы, установить уровень сжатия для текстов, установить DPI для изображений и т.д.

Пример кода ниже демонстрирует операцию, в которой презентация PowerPoint конвертируется в PDF с несколькими пользовательскими параметрами:

```c++
// Создает экземпляр класса PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Устанавливает качество для JPG изображений
pdfOptions->set_JpegQuality(90);

// Устанавливает DPI для изображений
pdfOptions->set_SufficientResolution(300);

// Устанавливает поведение для метафайлов
pdfOptions->set_SaveMetafilesAsPng(true);

// Устанавливает уровень сжатия текста для текстового содержимого
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Определяет режим соответствия PDF
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Создает экземпляр класса Presentation, который представляет документ PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Сохраняет презентацию как PDF документ
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Конвертировать PowerPoint в PDF со скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать настраиваемый параметр — свойство [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) из класса [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/), чтобы указать Aspose.Slides включить скрытые слайды как страницы в результирующем PDF.

Этот код C++ показывает, как конвертировать презентацию PowerPoint в PDF с включенными скрытыми слайдами:

```c++
// Создает экземпляр класса Presentation, который представляет файл PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Создает экземпляр класса PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Добавляет скрытые слайды
pdfOptions->set_ShowHiddenSlides(true);

// Сохраняет презентацию как PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Конвертировать PowerPoint в защищенный паролем PDF**

Этот код C++ показывает, как конвертировать PowerPoint в PDF, защищенный паролем (с использованием параметров защиты из класса [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)):

```c++
// Создает экземпляр класса Presentation, который представляет файл PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// Создает экземпляр класса PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Устанавливает пароль для PDF и разрешения доступа
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Сохраняет презентацию как PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Обнаруживать замены шрифтов**

Aspose.Slides предоставляет метод [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) в классе [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/), который позволяет вам обнаруживать замены шрифтов в процессе конвертации презентации в PDF. 

Этот код C++ показывает, как обнаруживать замены шрифтов:

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        System::Console::WriteLine(u"Предупреждение о замене шрифта: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

и следующий код C++ показывает, как использовать предыдущий класс:

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о получении обратных вызовов для замен шрифтов в процессе рендеринга, смотрите [Получение обратных вызовов для замены шрифтов](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов, смотрите статью [Замена шрифтов](https://docs.aspose.com/slides/cpp/font-substitution/).

{{% /alert %}} 

## **Конвертировать выбранные слайды PowerPoint в PDF**

Этот код C++ показывает, как конвертировать конкретные слайды из презентации PowerPoint в PDF:

```C++
// Создает экземпляр класса Presentation, который представляет файл PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Устанавливает массив позиций слайдов
auto slides = System::MakeArray<int32_t>({1, 3});

// Сохраняет презентацию как PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Этот код C++ показывает, как конвертировать PowerPoint с указанным размером слайда в PDF:

```C++
// Путь к директории документов.
String dataDir = GetDataPath()

// Создает экземпляр класса Presentation, который представляет файл PowerPoint 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Устанавливает тип и размер слайда 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **Конвертировать PowerPoint в PDF в режиме предпросмотра с заметками**

Этот код C++ показывает, как конвертировать PowerPoint в PDF с заметками:

```C++
// Путь к директории документов.
System::String dataDir = u"";

// Создает экземпляр класса Presentation, который представляет файл PowerPoint
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Сохраняет презентацию в PDF с заметками
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет вам использовать процедуру конверсии, которая соответствует [Руководству по доступности веб-контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF с использованием любых из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b**, и **PDF/UA**.

Этот код C++ демонстрирует операцию конверсии PowerPoint в PDF, при которой получаются несколько PDF на основе различных стандартов соответствия:

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="Примечание" color="warning" %}} 

Поддержка Aspose.Slides для операций конверсии PDF расширяется возможностью конвертировать PDF в самые популярные форматы файлов. Вы можете выполнить [конвертацию PDF в HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Другие операции конверсии PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}