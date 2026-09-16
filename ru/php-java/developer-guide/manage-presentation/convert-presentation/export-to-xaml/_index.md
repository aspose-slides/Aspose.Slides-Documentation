---
title: Экспорт презентаций в XAML на PHP
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/php-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспортировать PPT в XAML
- экспортировать PPTX в XAML
- экспортировать ODP в XAML
- PHP
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument в XAML с помощью Aspose.Slides для PHP через Java — быстрое решение без необходимости Office, сохраняющее макет."
---
## **Обзор**

В этой статье объясняется, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Описывается краткое введение в XAML, показывается, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрируется настройка экспорта через [XamlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью XAML‑стека и поведением экспорта скрытых слайдов.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример PHP показывает, как экспортировать презентацию в XAML с настройками по умолчанию. Инициализируйте PHP Java Bridge и загрузите `aspose.slides.php` перед запуском примеров в этой статье. Поместите `pres.pptx` в рабочий каталог сервера Java Bridge или укажите абсолютный путь, доступный этому серверу.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога сервера Java Bridge. Папка создаётся автоматически, а все необходимые изображения сохраняются там же.

Имя выходной папки берётся из имени исходного файла без расширения. Для `pres.pptx` создаются файлы `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если вы передаёте абсолютный путь к входной презентации, выходная папка создаётся относительно текущего рабочего каталога сервера Java Bridge, а не рядом с файлом‑источником.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить результаты в пользовательском месте, предоставьте Java‑прокси, реализующий [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/), и передайте экземпляр вашей реализации в метод [setOutputSaver](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/#setOutputSaver) объекта [XamlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) со значением `true`, как показано в следующем примере PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Сбор всех сгенерированных XAML‑артефактов**

Экспорт в XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Назначьте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/) в метод [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/#setOutputSaver), чтобы получать эти артефакты вместо использования стандартного сохранения в файловой системе. Запустите экспорт с помощью перегрузки [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save), принимающей XAML‑параметры.

Функция `java_closure` PHP Java Bridge раскрывает объект PHP как Java‑интерфейс. Держите оба объекта — PHP‑сохраняющий и его прокси — живыми до завершения экспорта. Ссылки на интерфейс указывают на Java‑API, реализованное прокси.

### **Понимание жизненного цикла обратного вызова**

Экспортер вызывает [IXamlOutputSaver::save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, поскольку XAML может ссылаться на ресурсы по относительным путям.
- `data` содержит байты артефакта. Изображения и другие двоичные ресурсы не должны декодироваться как текст.
- Сохраняющий объект отвечает за сохранение или удержание данных до возврата. Примеры преобразуют каждый массив Java‑байтов в PHP‑строку‑бинарник, принадлежащую приложению.
- Считайте экспорт успешным только тогда, когда операция сохранения презентации завершилась и каждый обратный вызов выполнился без ошибок. Не игнорируйте ошибки хранения и не запускайте незамеченные фоновые записи. Если постоянное сохранение происходит позже, сообщайте о полном успехе только после успешного завершения и этого шага.

[ XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) также применяется к пользовательскому сохраняющему. Настройка по умолчанию `false` исключает XAML‑документы скрытых слайдов. Установка `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагайте один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и инспекция артефактов**

В этом полном примере загружается `pres.pptx`, собираются все артефакты в ассоциативный массив PHP‑строк‑бинарников и выводятся их имя, тип и количество байтов. Имена сохраняются точно так, как переданы. Дублирующие имена делают коллекцию недействительной вместо бесшумного перезаписывания артефакта. Пример проверяет это перед использованием результатов.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Только XAML рассматривается как текст UTF-8 для необязательной инспекции.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты без изменений при хранении или передаче. PHP‑строки могут удерживать двоичные данные, включая нулевые байты. Рассматривайте строку как UTF‑8‑текст только при просмотре XAML; не перекодируйте изображение или ресурсы.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот независимый пример собирает экспорт, проверяет имена и записывает оригинальные байты в ZIP‑архив. Специально созданный каталог задач отделяет параллельные процессы экспорта. Пример требует расширения PHP Phar с поддержкой ZIP. Записи ZIP используют прямые слэши и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, приводят к отклонению всего пакета до записи.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Пример использует [PharData](https://www.php.net/manual/en/class.phardata.php) для записи локального ZIP‑архива в рабочий каталог процесса PHP; сам экспортер не пишет отдельные XAML‑ или файлы изображений. Для удалённого хранилища замените этап записи архива загрузкой собранных бинарных строк. Используйте идентификатор задачи экспорта плюс полное относительное имя артефакта в качестве ключа блоба, либо сохраняйте идентификатор задачи, относительное имя и бинарные данные в строке базы данных. Публикуйте задачу только после завершения всех загрузок или фиксации транзакции БД. При неудачном сохранении очищайте частичный вывод.

Для больших презентаций пользовательский сохраняющий может сохранять каждый артефакт напрямую в хранилище приложения, избегая необходимости держать полную копию экспорта в памяти. Держите каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранение имён ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если этого требует назначение, но сохраняйте относительные каталоги. Не используйте только [basename](https://www.php.net/manual/en/function.basename.php), если только не гарантировано, что каждое сгенерированное имя уникально и ссылки остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода вверх, преобразуйте место назначения в абсолютный путь и убедитесь, что он находится внутри целевого каталога экспорта, включая разделитель в проверке containment. Используйте управляемый приложением каталог без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохраняющий объект и пространство имён хранения для каждой задачи экспорта. Обнаруживайте конфликты после нормализации разделителей и в соответствии с правилом чувствительности к регистру места назначения.
- Перед публикацией разбирайте каждый XAML‑документ как XML и проверяйте ссылки на ресурсы, такие как атрибуты `Source` или `ImageSource` изображений. Разрешайте каждый относительный URI относительно каталога содержащего артефакта XAML, нормализуйте получившееся имя хранилища и убедитесь, что соответствующий ключ карты, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и выражения XAML‑разметки отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Сохранение только `image1.png` нарушит эту связь. При объектном хранилище сохраняйте ту же структуру под префиксом задачи и делайте эти URL‑ы доступными потребителю XAML. Откройте завершённый ZIP, проверьте имена записей и байты ресурсов, а также загрузите типичные слайды в целевую XAML‑среду, чтобы убедиться, что изображения корректно разрешаются.

## **Часто задаваемые вопросы**

**Как можно обеспечить предсказуемость шрифтов, если исходный шрифт недоступен на машине?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) в объекте [XamlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/) — он используется как резервный шрифт при экспорте, когда оригинальный шрифт отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, присутствуют в окружении, где он отображается.

**Предназначен ли экспортированный XAML только для WPF или его можно использовать и в других XAML‑стэках?**

Aspose.Slides экспортирует XAML для WPF через публичный API. Совместимость с другими XAML‑стэками, такими как UWP и Xamarin.Forms, не гарантируется. Протестируйте сгенерированную разметку в целевом окружении.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) в объекте [XamlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/xamloptions/) — оставьте его отключённым, если вам не требуется экспортировать скрытые слайды.