---
title: Сохранение презентаций в PHP
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/php-java/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- процесс сохранения
- PHP
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки в PHP с помощью Aspose.Slides и настройте вывод PPTX и отчёт о ходе процесса."
---
## **Обзор**

После того как вы создадите презентацию или [откроете существующую](/slides/ru/php-java/open-presentation/), используйте метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) для записи результата. Aspose.Slides for PHP via Java может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и параметры, доступные для вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/) в метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save). Значение формата определяет тип файла, который создаёт Aspose.Slides.

В следующем примере создаётся презентация и сохраняется как файл PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Добавьте или измените содержимое презентации здесь.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций в их исходном формате**

Для примеров обнаружения файлов и потоков, поведения вновь созданных презентаций и различий между исходными и целевыми форматами см. [Determine the Original Presentation Format](/slides/ru/php-java/detect-presentation-source-format/).

В пакетном приложении формат входных данных может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью метода [Presentation::getSourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSourceFormat). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sourceformat/) в [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/#toSaveFormat), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/), а затем используйте [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) для записи изменённой презентации.

В следующем полном примере обрабатывается каждый файл во входном каталоге, обновляется его заголовок и сохраняется в выходном каталоге в том же формате, в котором был загружен:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

Метод SlideUtil::toSaveFormat сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он сопоставляет только исходные форматы презентаций; он не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недопустимого значения [SourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sourceformat/) приводит к возникновению [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если необходимо сохранить эти устаревшие подтипы, храните оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени и формата выходного файла.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без указания окончательного пути к файлу, передайте в метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) поток, поддерживающий запись, и значение [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/). Такой подход полезен, когда вывод должен быть возвращён из веб‑сервиса, сохранён в базе данных или обработан в памяти.

В следующем примере новая презентация сохраняется в файловый поток:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций с предопределённым типом представления**

Можно задать представление, в котором PowerPoint изначально откроет сохранённую презентацию. Перед сохранением используйте метод [ViewProperties::setLastView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#setLastView) с значением [ViewType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewtype/).

В следующем примере в качестве начального представления настраивается вид Slide Master:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/) и вызовите его метод [PptxOptions::setConformance](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setConformance) с параметром [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Затем передайте параметры в метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждого элемента, общий размер архива и количество элементов. Поскольку файл PPTX представляет собой ZIP‑архив, очень большая презентация может превысить эти ограничения. Расширения ZIP64 повышают соответствующие лимиты размеров и количества элементов.

Для управления тем, будет ли Aspose.Slides записывать расширения ZIP64, используйте метод [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setZip64Mode):

- [IfNecessary](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#IfNecessary) использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Never) отключает расширения ZIP64.
- [Always](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Always) всегда записывает расширения ZIP64.

В следующем примере для выводимой презентации всегда включаются расширения ZIP64:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Если используется [Zip64Mode::Never](https://reference.aspose.com/slides/ru/php-java/aspose.slides/zip64mode/#Never) и презентация не помещается в стандартные ограничения ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX можно сбалансировать скорость сохранения и размер файла, используя метод [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Класс [CompressionLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/) предоставляет следующие значения:

- [None](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#None) хранит данные без сжатия.
- [Level1](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level1) обеспечивает самое быстрое сжатие и наибольший размер сжатого вывода.
- [Level2](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level2) до [Level5](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level5) постепенно отдают предпочтение более небольшому выводу в ущерб скорости сохранения.
- [Level6](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level6) балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- [Level7](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level7) и [Level8](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level8) ещё больше отдают предпочтение более небольшому выводу в ущерб скорости сохранения.
- [Level9](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compressionlevel/#Level9) обеспечивает самое сильное сжатие и требует наибольшего времени обработки.

В следующем примере сохраняется презентация без сжатия:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

В следующем примере используется максимальный уровень сжатия:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Когда презентация сохраняется как PPTX, метод [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет её миниатюрой документа:

- `true` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `false` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides не генерирует её.

В следующем примере сохраняется презентация без обновления её миниатюры:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Обновления прогресса сохранения в процентах**

Чтобы мониторить процесс сохранения, предоставьте Java‑прокси, реализующий интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/), и передайте прокси в метод [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides затем вызывает метод [IProgressCallback::reporting](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/#reporting-double-) с значениями прогресса во время экспорта.

В следующем примере прогресс экспорта PDF выводится в консоль:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на API Aspose.Slides. Он сохраняет выбранные слайды из презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое сохранение»?**

Нет. Каждая операция сохранения записывает полностью итоговый файл, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/php-java/multithreading/). Доступ к каждому экземпляру и его сохранение должны осуществляться только из одного потока одновременно.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/php-java/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохранённая презентация всё ещё должна иметь доступ к их расположениям.

**Можно ли сохранять метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/php-java/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.