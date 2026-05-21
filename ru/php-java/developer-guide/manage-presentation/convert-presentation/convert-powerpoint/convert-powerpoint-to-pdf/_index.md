---
title: Конвертировать PPT и PPTX в PDF на PHP [включены расширенные функции]
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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в PHP с помощью Aspose.Slides, с быстрыми примерами кода и расширенными параметрами преобразования."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF в PHP предоставляет ряд преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования презентации. В этом руководстве показано, как преобразовать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для преобразования и применять стандарты соответствия к результирующим документам.

## **Преобразования PowerPoint в PDF**

С помощью Aspose.Slides можно преобразовать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), а затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation) предоставляет метод `save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java вставляет сведения о своей API и номер версии в создаваемые документы. Например, при преобразовании презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Примечание**: изменить или удалить эту информацию из выходных документов нельзя.

{{% /alert %}}

Aspose.Slides позволяет преобразовать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая максимально близкое соответствие полученных PDF оригинальным презентациям. При преобразовании точно воспроизводятся элементы и свойства, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркированные списки
* Таблицы

## **Преобразовать PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, применяя оптимальные настройки с максимальным уровнем качества.

Этот пример кода показывает, как преобразовать презентацию (PPT, PPTX, ODP и др.) в PDF:

```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Сохранить презентацию в формате PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose предлагает бесплатный онлайн **конвертер PowerPoint в PDF**[https://products.aspose.app/slides/ru/conversion/ppt-to-pdf](), который демонстрирует процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для живой реализации описанной здесь процедуры.

{{% /alert %}}

## **Преобразовать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PdfOptions) — которые позволяют настроить результирующий PDF, защитить PDF паролем или указать, как должен происходить процесс преобразования.

### **Преобразовать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры преобразования, можно задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, задать DPI для изображений и многое другое.

Ниже приведён пример кода, показывающий, как преобразовать презентацию PowerPoint в PDF с несколькими пользовательскими параметрами.

```php
# Создать экземпляр класса PdfOptions.
$pdfOptions = new PdfOptions();

# Установить качество JPG‑изображений.
$pdfOptions->setJpegQuality(90);

# Установить DPI для изображений.
$pdfOptions->setSufficientResolution(300);

# Установить поведение для метафайлов.
$pdfOptions->setSaveMetafilesAsPng(true);

# Установить уровень сжатия текста для текстового содержания.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Определить режим соответствия PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Сохранить презентацию в виде PDF‑документа.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Преобразовать PowerPoint в PDF с включением скрытых слайдов**

Если в презентации есть скрытые слайды, можно использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды в виде страниц в результирующий PDF.

Этот пример кода показывает, как преобразовать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:

```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создать экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Добавить скрытые слайды.
    $pdfOptions->setShowHiddenSlides(true);

    # Сохранить презентацию в формате PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Преобразовать PowerPoint в PDF с защитой паролем**

Этот пример кода демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты из класса [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/):

```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создать экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Установить пароль PDF и разрешения доступа.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Сохранить презентацию в формате PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса преобразования презентации в PDF.

Этот пример кода показывает, как обнаружить замену шрифтов:

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

// Установить обратный вызов предупреждений в параметрах PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Сохранить презентацию в формате PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/php-java/font-substitution/).

{{% /alert %}} 

## **Преобразовать выбранные слайды PowerPoint в PDF**

Этот пример кода демонстрирует, как преобразовать только определённые слайды из презентации PowerPoint в PDF:

```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Установить массив номеров слайдов.
    $slides = array(1, 3);

    # Сохранить презентацию в формате PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Преобразовать PowerPoint в PDF с пользовательским размером слайда**

Этот пример кода демонстрирует, как преобразовать презентацию PowerPoint в PDF с указанным размером слайда:

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

    # Сохранить изменённую презентацию в PDF с нотатками.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Преобразовать PowerPoint в PDF в представлении сносов**

Этот пример кода демонстрирует, как преобразовать презентацию PowerPoint в PDF, включающий сноски:

```php
# Создать экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Настроить параметры PDF с расположением нотаток.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Сохранить презентацию в PDF с нотатками.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Доступность и стандарты соответствия PDF**

Aspose.Slides позволяет использовать процедуру преобразования, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, соблюдая любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот пример кода демонстрирует процесс преобразования PowerPoint в PDF, генерирующий несколько PDF‑файлов в соответствии с разными стандартами соответствия:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides поддерживает операции преобразования PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнить преобразования [PDF в HTML](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-png/). Поддерживаются также специализированные преобразования PDF в [SVG](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-svg/), [TIFF](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-tiff/) и [XML](https://products.aspose.com/slides/ru/php-java/conversion/pdf-to-xml/).

{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть отмечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **FAQ**

**Можно ли выполнять массовое преобразование нескольких файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать файлы и программно применить процесс преобразования.

**Можно ли защитить полученный PDF паролем?**

Конечно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса преобразования.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете управлять качеством изображений, используя методы такие как `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for PHP via Java Documentation](/slides/ru/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/ru/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ru/conversion)