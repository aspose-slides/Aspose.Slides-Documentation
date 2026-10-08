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
- вложение
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественные, поисковые PDF в PHP с помощью Aspose.Slides, предоставляя быстрые примеры кода и расширенные параметры конвертации."
---
## **Обзор**

Преобразование презентаций PowerPoint (PPT, PPTX, ODP и т.д.) в формат PDF в PHP предоставляет несколько преимуществ, включая совместимость с различными устройствами и сохранение макета и форматирования вашей презентации. В данном руководстве показано, как конвертировать презентации в PDF‑документы, использовать различные параметры для контроля качества изображений, включать скрытые слайды, защищать PDF файлы паролем, обнаруживать замену шрифтов, выбирать определённые слайды для конвертации и применять стандарты соответствия к выходным документам.

## **Конвертация PowerPoint в PDF**

С помощью Aspose.Slides вы можете конвертировать презентации следующих форматов в PDF:

* **PPT**
* **PPTX**
* **ODP**

Чтобы конвертировать презентацию в PDF, передайте имя файла в качестве аргумента классу [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и затем сохраните презентацию как PDF, используя метод [сохранить](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Класс [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) предоставляет метод [сохранить](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), который обычно используется для конвертации презентации в PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides для PHP через Java вставляет информацию о своем API и номер версии в выходные документы. Например, при конвертации презентации в PDF Aspose.Slides заполняет поле Application значением "*Aspose.Slides*", а поле PDF Producer — значением в форме "*Aspose.Slides v XX.XX*". **Примечание** то, что вы не можете указать Aspose.Slides изменить или удалить эту информацию из выходных документов.
{{% /alert %}}

Aspose.Slides позволяет вам конвертировать:

* Весь набор слайдов в PDF
* Определённые слайды из презентации в PDF

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

Стандартный процесс конвертации PowerPoint в PDF использует параметры по умолчанию. В этом случае Aspose.Slides пытается конвертировать предоставленную презентацию в PDF, используя оптимальные настройки при максимальном качестве.

В следующем примере загружается презентация и сохраняются все видимые слайды в PDF с использованием настроек экспорта по умолчанию.

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
Aspose предлагает бесплатный онлайн‑конвертер [**Конвертер PowerPoint в PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), демонстрирующий процесс преобразования презентации в PDF. Вы можете выполнить тест с этим конвертером для живой реализации описанной здесь процедуры.
{{% /alert %}}

## **Конвертация PowerPoint в PDF с параметрами**

Aspose.Slides предоставляет пользовательские параметры — свойства класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), которые позволяют настроить получаемый PDF, защитить PDF паролем или указать, как должен происходить процесс конвертации.

### **Конвертация PowerPoint в PDF с пользовательскими параметрами**

Используя пользовательские параметры конвертации, вы можете задать предпочтительные настройки качества растровых изображений, определить способ обработки метафайлов, установить уровень сжатия текста, настроить DPI для изображений и многое другое.

В следующем примере презентация экспортируется в PDF 1.5 с качеством JPEG, установленным в 90, разрешением изображения 300 DPI, метафайлы сохраняются как PNG, а текст сжимается методом Flate.

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

### **Сохранить вложенные OLE‑файлы как вложения PDF**

Если презентация содержит встроенную книгу Excel, вы можете захотеть, чтобы получатели PDF имели доступ к данным книги, а также могли просматривать слайды. Вызовите [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) с параметром `true`, чтобы сохранить вложенные OLE‑файлы как вложения в получаемом PDF.

Значение по умолчанию — `false`: превью‑изображение или значок OLE‑объекта отображается на странице PDF, но его вложенный файл не включается как вложение. Установка параметра в `true` дополнительно включает данные файла. Превью остаётся визуальным представлением; вложение позволяет получателям открыть или сохранить вложенный файл отдельно. OLE‑объект не превращается в интерактивный лист Excel на странице PDF.

В следующем примере загружается презентация, уже содержащая встроенную книгу Excel, и экспортируется в PDF с прикреплённой книгой.

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

Чтобы проверить результат:

1. Откройте экспортированный PDF в просмотрщике, поддерживающем вложения файлов, например Adobe Acrobat Reader.
2. Откройте панель **Вложения** просмотрщика и найдите вложенную книгу.
3. Сохраните вложение и откройте его в Excel для проверки данных, или откройте его напрямую, если просмотрщик позволяет. Превью на странице PDF отдельно от вложения.

{{% alert color="info" title="Note" %}}
Стандарты PDF/A накладывают ограничения на вложения: PDF/A-1 запрещает вложенные файлы, PDF/A-2 допускает только вложения PDF/A, а PDF/A-3 допускает другие типы файлов, включая книги Excel. Это требования стандартов, а не ограничения, специфичные для Aspose.Slides. Этот пример использует настройки соответствия PDF по умолчанию и не демонстрирует экспорт в PDF/A.
{{% /alert %}}

### **Конвертация PowerPoint в PDF с включением скрытых слайдов**

Если презентация содержит скрытые слайды, вы можете использовать метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) из класса [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в виде страниц в получаемом PDF.

В следующем примере презентация экспортируется в PDF с включением всех скрытых слайдов.

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

### **Конвертация PowerPoint в защищённый паролем PDF**

В следующем примере презентация экспортируется в PDF, который требует пароль `password` для открытия. Права доступа позволяют печатать, включая печать высокого качества.

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

### **Обнаружение замены шрифтов**

Aspose.Slides предоставляет метод [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), позволяющий обнаруживать замену шрифтов во время процесса конвертации презентации в PDF.

В следующем примере презентация экспортируется в PDF, а предупреждения о замене шрифтов выводятся в консоль. Предупреждение выводится только когда недоступный шрифт заменяется во время экспорта.

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
Для получения дополнительной информации о замене шрифтов см. статью [Font Substitution](/slides/ru/php-java/font-substitution/).
{{% /alert %}}

### **Обработка шрифтов без отдельного полужирного начертания**

Презентация может применять полужирное форматирование к тексту, даже если у шрифта нет отдельного полужирного начертания. Текст всё равно может выглядеть полужирным за счёт синтетического полужирного начертания, которое искусственно утолщает обычные глифы. Когда такой текст выглядит слишком тяжёлым или иначе отличается от желаемого отображения в PDF, попробуйте вызвать [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) с параметром `true`. Эта опция рендерит затронутый текст как растровое изображение при экспорте в PDF и может улучшить его отображение для некоторых шрифтов. Значение по умолчанию — `false`.

В демонстрационной презентации содержатся два текстовых блока: один с обычным текстом и один с полужирным форматом того же шрифта, у которого нет отдельного полужирного начертания. В следующем примере презентация загружается, включается растеризация неподдерживаемых стилей шрифтов, и экспортируется в PDF:

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

Ниже представлены превью результатов с отключенной и включенной опцией. В этом примере полужирный текст имеет более тяжёлые штрихи при отключенной опции. При включенной опции его штрихи становятся тоньше; обычный текст остаётся без изменений. Сравните результаты, прежде чем выбирать настройку для вашей презентации.

| Опция отключена (`false`, по умолчанию) | Опция включена (`true`) |
|---|---|
| ![PDF с растеризацией неподдерживаемого стиля шрифта отключена](unsupported-bold-disabled.png) | ![PDF с растеризацией неподдерживаемого стиля шрифта включена](unsupported-bold-enabled.png) |

В этом примере включение опции превращает только полужирный текст в растровое изображение: его нельзя выделять, копировать или искать как текст без OCR, а его края выглядят мягче при масштабе 800 %. Обычный текст остаётся доступным для поиска. При отключённой опции обе строки остаются текстом.

Эта опция растеризует текст, отформатированный как полужирный, когда у шрифта нет отдельного полужирного начертания. [Font substitution](/slides/ru/php-java/font-substitution/) вместо этого выбирает другой шрифт, если оригинальный недоступен.

## **Конвертация выбранных слайдов PowerPoint в PDF**

В следующем примере экспортируются слайды 1 и 3 из презентации в PDF. Номера слайдов в этом массиве начинаются с единицы, и входная презентация должна содержать как минимум три слайда.

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

## **Конвертация PowerPoint в PDF с пользовательским размером слайда**

В следующем примере первый слайд из презентации копируется в новую презентацию с размером слайда 612 × 792 пунктов (8,5 × 11 дюймов). Содержимое слайда масштабируется под размер и экспортируется в PDF как один слайд.

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

## **Конвертация PowerPoint в PDF в режиме заметок слайда**

В следующем примере презентация экспортируется в PDF, размещая заметки докладчика каждого слайда под самим слайдом. Используйте презентацию, содержащую заметки докладчика, чтобы увидеть результат.

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

## **Стандарты доступности и соответствия для PDF**

Aspose.Slides позволяет использовать процедуру конвертации, соответствующую [Руководствам по доступности веб‑контента (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Вы можете экспортировать документ PowerPoint в PDF, используя любой из этих стандартов соответствия: **PDF/A1a**, **PDF/A1b** и **PDF/UA**.

Этот код демонстрирует процесс конвертации PowerPoint в PDF, создающий несколько PDF‑файлов на основе разных стандартов соответствия:

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
Aspose.Slides поддерживает операции конвертации PDF, позволяя вам преобразовывать PDF‑файлы в популярные форматы. Вы можете выполнить конвертации [PDF в HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF в изображение](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF в JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), и [PDF в PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Другие операции конвертации PDF в специализированные форматы — [PDF в SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF в TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), и [PDF в XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — также поддерживаются.
{{% /alert %}}

> **Примечание:** При экспорте в PDF/UA Aspose.Slides рассматривает сложную графику, такую как SmartArt, диаграммы и формулы, как единый объект. Отдельные элементы пути не сохраняются как отдельный контент и могут быть помечены как артефакты; альтернативный текст предоставляется только для всего объекта.

## **Часто задаваемые вопросы**

**Можно ли конвертировать несколько файлов PowerPoint в PDF пакетно?**  
Да, Aspose.Slides поддерживает пакетную конвертацию нескольких файлов PPT или PPTX в PDF. Вы можете перебрать свои файлы и программно применить процесс конвертации.

**Можно ли защитить преобразованный PDF паролем?**  
Да. Используйте класс [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) для установки пароля и определения прав доступа во время процесса конвертации.

**Как включить скрытые слайды в PDF?**  
Вызовите [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) с параметром `true` в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), чтобы включить скрытые слайды в получаемый PDF.

**Может ли Aspose.Slides поддерживать высокое качество изображений в PDF?**  
Да, вы можете управлять качеством изображений, используя методы, такие как [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) и [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) в классе [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), чтобы обеспечить высококачественные изображения в вашем PDF.

**Поддерживает ли Aspose.Slides стандарты соответствия PDF/A?**  
Да, Aspose.Slides позволяет экспортировать PDF, соответствующие [различным стандартам](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), включая PDF/A1a, PDF/A1b и PDF/UA, гарантируя, что ваши документы соответствуют требованиям доступности и архивирования.

## **Дополнительные ресурсы**

- [Документация Aspose.Slides для PHP через Java](/slides/ru/php-java/)
- [Справочник API Aspose.Slides для PHP через Java](https://reference.aspose.com/slides/php-java/)
- [Бесплатные онлайн‑конвертеры Aspose](https://products.aspose.app/slides/conversion)