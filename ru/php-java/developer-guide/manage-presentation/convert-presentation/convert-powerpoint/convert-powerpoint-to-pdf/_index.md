---
title: Преобразование PPT и PPTX в PDF в PHP [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/php-java/convert-powerpoint-to-pdf/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- преобразовать PPT в PDF
- PPTX в PDF
- преобразовать PPTX в PDF
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
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в PHP с помощью Aspose.Slides, используя быстрые примеры кода и расширенные параметры конвертации."
---

## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и др.) в формат PDF в PHP предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве демонстрируется, как преобразовать презентации в PDF‑документы, использовать различные параметры для управления качеством изображений, включать скрытые слайды, защищать PDF‑файлы паролем, обнаруживать замену шрифтов, выбирать отдельные слайды для преобразования и применять стандарты соответствия к выходным документам.

## **Преобразования PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы преобразовать презентацию в PDF, передайте имя файла в качестве аргумента классу [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), а затем сохраните презентацию как PDF, используя метод `save`. Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) предоставляет метод `save`, который обычно используется для преобразования презентации в PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for PHP via Java вставляет сведения о своей версии API в выходные документы. Например, при преобразовании презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer строкой вида "*Aspose.Slides v XX.XX*". **Обратите внимание**, что изменить или удалить эту информацию из выходных документов невозможно.
{{% /alert %}}

Aspose.Slides позволяет конвертировать:

* Полные презентации в PDF
* Выбранные слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая тесное соответствие полученных PDF оригинальным презентациям. Элементы и атрибуты отображаются точно при преобразовании, включая:

* Изображения
* Текстовые поля и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Колонтитулы
* Маркеры
* Таблицы

## **Преобразование PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки на максимальном уровне качества.

Ниже показан код, который демонстрирует, как преобразовать презентацию (PPT, PPTX, ODP и др.) в PDF:
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
Aspose предлагает бесплатный онлайн [**конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), который демонстрирует процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной процедуры.
{{% /alert %}}

## **Преобразование PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions), которые позволяют настроить результирующий PDF, защитить его паролем или указать, как должен проходить процесс преобразования.

### **Преобразование PowerPoint в PDF с пользовательскими параметрами**

С помощью пользовательских параметров преобразования вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Ниже приведён пример кода, демонстрирующего преобразование презентации PowerPoint в PDF с несколькими пользовательскими параметрами.
```php
# Создайте экземпляр класса PdfOptions.
$pdfOptions = new PdfOptions();

# Установите качество для JPG‑изображений.
$pdfOptions->setJpegQuality(90);

# Установите DPI для изображений.
$pdfOptions->setSufficientResolution(300);

# Установите поведение для метафайлов.
$pdfOptions->setSaveMetafilesAsPng(true);

# Установите уровень сжатия текста для текстового содержимого.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Задайте режим соответствия PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Сохраните презентацию как PDF‑документ.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Преобразование PowerPoint в PDF с включёнными скрытыми слайдами**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions), чтобы включить скрытые слайды как страницы в результирующий PDF.

Этот код показывает, как преобразовать презентацию PowerPoint в PDF с включёнными скрытыми слайдами:
```php
# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создайте экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Добавьте скрытые слайды.
    $pdfOptions->setShowHiddenSlides(true);

    # Сохраните презентацию как PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Преобразование PowerPoint в PDF, защищённый паролем**

Этот код демонстрирует, как преобразовать презентацию PowerPoint в PDF, защищённый паролем, используя параметры защиты класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/):
```php
# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Создайте экземпляр класса PdfOptions.
    $pdfOptions = new PdfOptions();

    # Установите пароль PDF и разрешения доступа.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Сохраните презентацию как PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), позволяющий обнаружить замену шрифтов во время процесса преобразования презентации в PDF.

Этот код показывает, как обнаружить замену шрифтов:
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

// Установите обратный вызов предупреждения в параметрах PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Сохраните презентацию как PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 
Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/php-java/font-substitution/).
{{% /alert %}} 

## **Преобразование выбранных слайдов PowerPoint в PDF**

Этот код демонстрирует, как преобразовать только определённые слайды из презентации PowerPoint в PDF:
```php
# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Установите массив номеров слайдов.
    $slides = array(1, 3);

    # Сохраните презентацию как PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


## **Преобразование PowerPoint в PDF с пользовательским размером слайда**

Этот код демонстрирует, как преобразовать презентацию PowerPoint в PDF с указанным размером слайда:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Создайте новую презентацию с изменённым размером слайда.
$resizedPresentation = new Presentation();

try {
    # Установите пользовательский размер слайда.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Склонируйте первый слайд из исходной презентации.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Сохраните изменённую презентацию в PDF с заметками.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **Преобразование PowerPoint в PDF в режиме «Заметки»**

Этот код демонстрирует, как преобразовать презентацию PowerPoint в PDF, включающий заметки:
```php
# Создайте экземпляр класса Presentation, представляющего файл PowerPoint или OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Настройте параметры PDF с расположением заметок.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Сохраните презентацию в PDF с заметками.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процедуру преобразования, соответствующую [Руководству по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Ниже показан процесс преобразования PowerPoint в PDF, который создаёт несколько PDF‑файлов на основе разных стандартов соответствия:
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
Aspose.Slides поддерживает операции преобразования PDF, позволяя конвертировать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF в HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) и [PDF в PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) преобразования. Другие операции преобразования PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) и [PDF в XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

## **FAQ**

**Можно ли выполнять массовое преобразование нескольких файлов PowerPoint в PDF?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать ваши файлы и программно применить процесс преобразования.

**Можно ли защитить полученный PDF паролем?**

Безусловно. Используйте класс [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса преобразования.

**Как включить скрытые слайды в PDF?**

Используйте метод `setShowHiddenSlides` класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Может ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете управлять качеством изображений, используя методы `setJpegQuality` и `setSufficientResolution` класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие различным стандартам, включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы отвечают требованиям доступности и архивного хранения.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides for PHP via Java](/slides/ru/php-java/)
- [Справочник API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)