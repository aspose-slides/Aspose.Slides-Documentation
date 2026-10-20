---
title: Переобразование PPT и PPTX в PDF в PHP [Включены расширенные функции]
linktitle: PowerPoint в PDF
type: docs
weight: 40
url: /ru/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественные, индексируемые PDF в PHP с помощью Aspose.Slides, используя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Конвертация презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF с помощью PHP предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В этом руководстве показано, как преобразовать презентации в документы PDF, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF паролем, обнаруживать замену шрифтов, выбирать конкретные слайды для конвертации и применять стандарты соответствия к выводимым документам.

## **Преобразования PowerPoint в PDF**

С помощью Aspose.Slides вы можете преобразовать презентации в следующих форматах в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в конструктор класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) предоставляет метод [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), который обычно используется для преобразования презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java вставляет информацию о своей версии API в выводимые документы. Например, при преобразовании презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*" и поле PDF Producer значением вида "*Aspose.Slides v XX.XX*". **Примечание** что изменить или убрать эту информацию из выводимых документов с помощью Aspose.Slides нельзя.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Полные презентации в PDF
* Определённые слайды из презентации в PDF

Aspose.Slides экспортирует презентации в PDF, обеспечивая, что полученные PDF‑файлы максимально похожи на оригинальные презентации. Элементы и атрибуты рендерятся точно при конвертации, включая:

* Изображения
* Текстовые блоки и фигуры
* Форматирование текста
* Форматирование абзацев
* Гиперссылки
* Верхние и нижние колонтитулы
* Маркеры
* Таблицы

## **Преобразовать PowerPoint в PDF**

Стандартный процесс преобразования PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается преобразовать предоставленную презентацию в PDF, используя оптимальные настройки с максимальным качеством.

Следующий пример загружает презентацию и сохраняет все видимые слайды в PDF, используя настройки экспорта по умолчанию.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose предлагает бесплатный онлайн‑инструмент [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете протестировать этот конвертер для живой реализации процедуры, описанной здесь.
{{% /alert %}}

## **Преобразовать PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), — которые позволяют настроить получаемый PDF, защитить его паролем или указать, как должен происходить процесс конвертации.

### **Преобразовать PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, указать, как обрабатывать метафайлы, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

Следующий пример экспортирует презентацию в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняет как PNG и использует сжатие текста Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Автоматический выбор сжатия изображений**

Если в презентации содержится много фотографий или скриншотов, уменьшение размера экспортируемого PDF может облегчить его отправку по электронной почте или загрузку. Вызовите [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) с параметром `true`, чтобы автоматически выбирать наиболее подходящий алгоритм сжатия для каждого изображения при экспорте в PDF.

Следующий пример загружает существующую презентацию, включает автоматический выбор сжатия изображений и сохраняет её как PDF‑документ. Все остальные параметры экспорта PDF остаются со значениями по умолчанию.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Этот параметр выбирает алгоритм сжатия для каждого изображения. Понижение значения, передаваемого в [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/), уменьшает качество JPEG‑изображения, а понижение значения, передаваемого в [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/), позволяет уменьшить разрешение изображений, что может снизить детализацию. Включение автоматического выбора сжатия само по себе не меняет эти параметры.

Выбор алгоритмов сжатия изображений требует дополнительных вычислительных ресурсов и памяти. Сокращение размера зависит от изображений презентации и настроек экспорта; фиксированное уменьшение не гарантировано для каждой презентации.

### **Сохранить встроенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF могли получить доступ к данным книги, а также просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) с параметром `true`, чтобы сохранять встроенные OLE‑файлы как вложения в результирующем PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта рендерится на странице PDF, но встроенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить встроенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

Следующий пример загружает презентацию, уже содержащую встроенную книгу Excel, и экспортирует её в PDF с прикреплённой книгой.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Для проверки результата:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Attachments** (Вложений) и найдите встроенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, либо откройте напрямую, если просмотрщик это позволяет. Превью на странице PDF отделено от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A‑1 запрещает вложенные файлы, PDF/A‑2 позволяет только вложения PDF/A, а PDF/A‑3 допускает иные типы файлов, включая книги Excel. Эти ограничения являются требованиями стандартов, а не ограничениями Aspose.Slides. В этом примере используется настройка соответствия PDF по умолчанию и не демонстрирует экспорт PDF/A.
{{% /alert %}}

### **Преобразовать PowerPoint в PDF со скрытыми слайдами**

Если в презентации есть скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) из класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды как страницы в результирующий PDF.

Следующий пример экспортирует презентацию в PDF, включая любые скрытые слайды.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Преобразовать PowerPoint в PDF, защищённый паролем**

Следующий пример экспортирует презентацию в PDF, требующий пароль `password` для открытия. Права доступа позволяют печатать, включая печать высокого качества.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Обнаружить замену шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

Следующий пример экспортирует презентацию в PDF и выводит предупреждения о замене шрифтов в консоль. Предупреждение выводится только когда недоступный шрифт заменяется во время экспорта.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Для получения дополнительной информации о замене шрифтов см. статью [Замена шрифтов](/slides/ru/php-java/font-substitution/).
{{% /alert %}} 

### **Обработка шрифтов без отдельного жирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного жирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического утолщения, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от желаемого отображения в PDF, попробуйте вызвать [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) с параметром `true`. Этот параметр рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

Примерная презентация содержит два текстовых блока: один с обычным текстом и один с полужирным форматированием того же шрифта, у которого нет отдельного жирного начертания. Следующий пример загружает презентацию, включает растрирование неподдерживаемых стилей шрифтов и экспортирует её в PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Ниже показаны предварительные результаты с отключённым и включённым параметром. В этом примере при отключённом параметре жирный текст имеет более тяжёлые штрихи. При включённом параметре его штрихи становятся легче; обычный текст остаётся без изменений. Сравните результаты, прежде чем выбирать настройку для вашей презентации.

| Option disabled (`false`, the default) | Option enabled (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

В этом примере включение параметра преобразует только жирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его контуры выглядят мягче при увеличении 800 %. Обычный текст остаётся searchable. При отключённом параметре оба текста остаются текстом.

Этот параметр растрирует текст, оформленный как жирный, когда его шрифт не имеет отдельного жирного начертания. [Замена шрифтов](/slides/ru/php-java/font-substitution/) вместо этого выбирает другой шрифт, если оригинал недоступен.

## **Конвертировать выбранные слайды PowerPoint в PDF**

Следующий пример экспортирует слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве нумеруются с единицы, и входная презентация должна содержать не менее трёх слайдов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Конвертировать PowerPoint в PDF с пользовательским размером слайда**

Следующий пример копирует первый слайд из презентации в новую презентацию с размером слайда 612 × 792 points (8,5 × 11 дюймов). Он масштабирует содержимое слайда для подгонки и экспортирует единственный слайд в PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Удалить пустой слайд, с которым была создана новая презентация.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Конвертировать PowerPoint в PDF в режиме заметок к слайдам**

Следующий пример экспортирует презентацию в PDF, размещая заметки докладчика под каждым слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Доступность и стандарты соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из следующих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, который генерирует несколько PDF‑файлов на основе разных стандартов соответствия:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides поддерживает операции конвертации PDF, позволяя преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнять [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) и [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) конвертации. Другие операции конвертации PDF в специализированные форматы — [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), и [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единую фигуру. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всей фигуры.

## **FAQ**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**

Да, Aspose.Slides поддерживает пакетное преобразование нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить пароль‑защищённый PDF?**

Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**

Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) с параметром `true` в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для включения скрытых слайдов в результирующий PDF.

**Сможет ли Aspose.Slides сохранять высокое качество изображений в PDF?**

Да, вы можете контролировать качество изображений, используя методы такие как [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) и [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для обеспечения высокого качества изображений в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**

Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, обеспечивая соответствие ваших документов требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Aspose.Slides for PHP via Java Documentation](/slides/ru/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)