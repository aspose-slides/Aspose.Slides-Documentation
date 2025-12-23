---
title: Конвертировать PPT и PPTX в PDF в PHP [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, полнотекстовые PDF в PHP с использованием Aspose.Slides, с быстрыми примерами кода и расширенными параметрами конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF в PHP дает несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), а затем сохраните презентацию как PDF с помощью метода `save`. Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) предоставляет метод `save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Aspose.Slides for PHP via Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Важно**: нельзя указать Aspose.Slides изменить или удалить эту информацию из выходных документов.

{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально точное совпадение полученных PDF с исходными презентациями. При конвертации точно воспроизводятся элементы и атрибуты, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Конвертация PowerPoint в PDF**

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать указанную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

Ниже показан код, который конвертирует презентацию (PPT, PPTX, ODP и др.) в PDF:
```php
# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Сохраните презентацию в PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose предоставляет бесплатный онлайн‑конвертер **PowerPoint в PDF**[**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс конвертации презентации в PDF. Вы можете протестировать работу конвертера для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions), — которые позволяют настроить получаемый PDF, защитить его паролем или указать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров конвертации вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже пример кода, показывающий, как конвертировать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.
```php
# Создать экземпляр класса PdfOptions.
$pdfOptions = new PdfOptions();

# Установить качество JPG‑изображений.
$pdfOptions->setJpegQuality(90);

# Установить DPI для изображений.
$pdfOptions->setSufficientResolution(300);

# Установить поведение для метафайлов.
$pdfOptions->setSaveMetafilesAsPng(true);

# Установить уровень сжатия текста для текстового содержимого.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Задать режим соответствия PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Сохранить презентацию как PDF‑документ.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды как страницы в результирующий PDF.

Этот код демонстрирует, как конвертировать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создать экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Добавить скрытые слайды.
    $pdfOptions->setShowHiddenSlides(true);

    # Сохранить презентацию как PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Конвертация PowerPoint в защищённый паролем PDF**

Этот пример показывает, как конвертировать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/):
```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создать экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Установить пароль PDF и права доступа.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Сохранить презентацию как PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), позволяющий обнаружить замену шрифтов во время конвертации презентации в PDF.

Пример кода, показывающий, как обнаружить замену шрифтов:
```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Установить обратный вызов предупреждения в параметрах PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Сохранить презентацию как PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

Для получения обратных вызовов о замене шрифтов во время процесса рендеринга см. [Получение предупреждающих обратных вызовов для замены шрифтов](/slides/ru/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/php-java/font-substitution/).

{{% /alert %}} 

## **Конвертация выбранных слайдов PowerPoint в PDF**

Этот пример демонстрирует, как конвертировать только определённые слайды презентации PowerPoint в PDF:
```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Установить массив номеров слайдов.
    $slides = array(1, 3);

    # Сохранить презентацию как PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

Этот пример демонстрирует, как конвертировать презентацию PowerPoint в PDF с указанным размером слайда:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Создать новую презентацию с изменённым размером слайда.
$resizedPresentation = new Presentation();

try {
    # Установить пользовательский размер слайда.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Клонировать первый слайд из исходной презентации.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Сохранить изменённую презентацию в PDF с примечаниями.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **Конвертация PowerPoint в PDF в режиме просмотра заметок**

Этот пример демонстрирует, как конвертировать презентацию PowerPoint в PDF, включающий заметки:
```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Настроить параметры PDF с размещением заметок.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Сохранить презентацию в PDF с заметками.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Ниже показан процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов в соответствии с разными стандартами соответствия:
```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Примечание" color="warning" %}} 

Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять конвертации [PDF в HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — также поддерживаются.

{{% /alert %}}

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете пройтись по вашим файлам и программно выполнить процесс конвертации.

**Можно ли защитить полученный PDF паролем?**

Абсолютно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время конвертации.

**Как включить скрытые слайды в PDF?**

Воспользуйтесь методом `setShowHiddenSlides` в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в результирующий PDF.

**Сможет ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете управлять качеством изображений, используя методы `setJpegQuality` и `setSufficientResolution` в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы отвечают требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for PHP via Java](/slides/ru/php-java/)
- [Справочник API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)