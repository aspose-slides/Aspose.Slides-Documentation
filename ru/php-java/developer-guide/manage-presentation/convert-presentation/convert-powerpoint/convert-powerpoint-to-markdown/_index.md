---
title: Преобразовать презентации PowerPoint в Markdown в PHP
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/php-java/convert-powerpoint-to-markdown/
keywords:
  - конвертировать PowerPoint
  - конвертировать презентацию
  - конвертировать слайд
  - конвертировать PPT
  - конвертировать PPTX
  - PowerPoint в MD
  - презентация в MD
  - слайд в MD
  - PPT в MD
  - PPTX в MD
  - сохранить PowerPoint как Markdown
  - сохранить презентацию как Markdown
  - сохранить слайд как Markdown
  - сохранить PPT как MD
  - сохранить PPTX как MD
  - экспортировать PPT в MD
  - экспортировать PPTX в MD
  - Экспорт изображений Markdown
  - ссылки на изображения CDN
  - PowerPoint
  - презентация
  - Markdown
  - PHP
  - Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на PHP и управлять тем, где сохраняются и как ссылаются экспортированные растровые, метафайловые и SVG-изображения."
---
## **Обзор**

Aspose.Slides for PHP via Java может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и рабочих процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержимое слайдов, и решать, где сохранять экспортированные изображения и как сгенерированный Markdown будет на них ссылаться.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, установите тип экспорта с помощью метода [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) в значение `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownexporttype/). `Sequential` рендерит элементы слайдов отдельно и по порядку, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные отношения. Значение `TextOnly` не генерирует ресурсы изображений, поэтому обратные вызовы сохранения изображений не вызываются в этом режиме.

## **Преобразовать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), а затем вызовите метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Выбрать вариант Markdown**

Метод [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) управляет спецификацией Markdown, используемой для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию в формате CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Экспорт изображений с использованием поведения сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) предоставляет два метода для настройки локально сохраняемых изображений:

- [setBasePath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) задает базовый каталог для документа Markdown и его ресурсов.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) задает подпапку для изображений. Значение по умолчанию — `Images`.

Следующий пример рендерит визуальное содержимое, записывает изображения в `output/assets` и создает относительные ссылки на изображения в документе Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Это поведение также используется в качестве резервного варианта, когда пользовательский обработчик сохранения изображений возвращает `false`.

## **Настройка сохранения изображений и ссылок Markdown**

Используйте метод [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) для регистрации обратного вызова для растровых и метафайловых ресурсов, не являющихся SVG, генерируемых при экспорте в Markdown. Его обратный вызов `MarkdownImageSavingHandler` получает объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/), значение [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/) и сгенерированную ссылку Markdown в виде массива Java строк из одного элемента. Сохраните или загрузите изображение в указанном формате и замените `$link[0]` ссылкой, которая должна появиться в выводе Markdown.

Ресурсы, генерируемые в формате SVG, обрабатываются отдельно. Зарегистрируйте обратный вызов с помощью метода [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/). Его обратный вызов `MarkdownSvgImageSavingHandler` получает объект [ISvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/isvgimage/) и массив Java строк `$link` из одного элемента. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML-данные через метод [ISvgImage::getSvgData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/isvgimage/). В зависимости от режима экспорта и визуального группирования, SVG в исходной презентации может быть растеризован или объединён с другим содержимым; полученный не‑SVG ресурс затем передаётся в обратный вызов сохранения изображения. Регистрируйте оба обратных вызова, когда каждый экспортируемый визуальный ресурс требует пользовательской обработки.

В PHP через Java реализуйте каждый обратный вызов в PHP‑классе и используйте `java_closure`, чтобы открыть этот объект как соответствующий Java‑интерфейс.

{{% alert color="info" title="Note" %}}
Инициализируйте PHP/Java Bridge с включённым `JAVA_PREFER_VALUES` перед загрузкой `Java.inc`. Метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) возвращает `void`, а режим потока по умолчанию моста не может вызвать PHP‑обратный вызов во время этой поставленной в очередь операции. Полный пример ниже включает необходимую инициализацию.
{{% /alert %}}

Значение, возвращаемое обработчиком, определяет, кто будет обрабатывать изображение:

- Вернуть `true` после того, как обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил допустимое значение `$link[0]`. Aspose.Slides записывает это значение в документ Markdown и не выполняет своё сохранение по умолчанию.
- Вернуть `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сгенерировать его ссылку в соответствии со значениями, установленными через [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Обработчик, возвращающий `true`, берёт на себя ответственность за изображение. Если он возвращает `true`, не присвоив допустимую, непустую ссылку, экспорт завершается ошибкой `InvalidOperationException`.
{{% /alert %}}

### **Сохранить изображения в директорию CDN‑источника и использовать внешние URL**

Следующий пример рассматривает `cdn-origin/presentations/quarterly-report` как смонтированную или синхронизированную директорию CDN‑источника. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в эту пользовательскую директорию и заменяет сгенерированную локальную ссылку публичным URL CDN. Сам пример не выполняет загрузку по сети: URL становится действительным только после монтирования директории как источника CDN или публикации её файлов в CDN. Для объектного хранилища замените запись в файловой системе операцией загрузки через SDK хранилища и присвойте `$link[0]` только после успешной загрузки.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Обработчик растровых изображений намеренно возвращает `false` для изображений меньше 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images`, используя поведение по умолчанию. Большие растровые и метафайловые ресурсы, а также SVG‑ресурсы обрабатываются пользовательским кодом. Например, сгенерированная локальная ссылка `fallback-images/image1.png` превращается в `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют пути операционной системы только при записи файлов; ссылки, записываемые в Markdown, используют прямые слэши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталогов, зависящий от платформы.

## **FAQ**

**Может ли один обработчик обрабатывать как растровые, так и SVG‑изображения?**

Нет. Используйте [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) для ресурсов, генерируемых как растровые и метафайлы, и [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) для ресурсов, генерируемых как SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/iimage/) и значение [ImageFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/); второй – объект [ISvgImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/isvgimage/), данные SVG которого можно прочитать с помощью [ISvgImage::getSvgData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/isvgimage/). SVG‑файл, растеризованный во время экспорта, обрабатывается обратным вызовом сохранения изображения.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует своё поведение сохранения по умолчанию. Расположение изображения и сгенерированная ссылка контролируются значениями, установленными с помощью [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/ru/php-java/aspose.slides/markdownsaveoptions/).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его в другой сервис, присвоить полученный URL переменной `$link[0]` и вернуть `true`. Обработчик обязан завершить обработку самостоятельно; возврат `true` предотвращает сохранение по умолчанию.

**Почему экспорт в Markdown бросает `InvalidOperationException` из обработчика?**

Это исключение возникает, когда обработчик возвращает `true`, но не предоставляет корректную ссылку. Присвойте относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `true`.

**Какой разделитель пути следует использовать в ссылках на изображения?**

Используйте прямые слэши в ссылках Markdown и URL. `DIRECTORY_SEPARATOR` применяйте только для путей файловой системы, а затем отдельно формируйте или нормализуйте ссылку Markdown.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/php-java/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/php-java/slide-transition/) и [animations](/slides/ru/php-java/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать презентации в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций параллельно, но не делитесь одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) между потоками. Следуйте [multithreading guidelines](/slides/ru/php-java/multithreading/) и используйте отдельный экземпляр для каждого файла.