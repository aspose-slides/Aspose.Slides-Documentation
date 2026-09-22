---
title: Определить исходный формат презентации в PHP
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/php-java/detect-presentation-source-format/
keywords:
- исходный формат
- определение формата презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Прочитайте исходный формат загруженной презентации в PHP с помощью Aspose.Slides for PHP via Java, сравните API обнаружения и работайте с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации вызовите метод [Presentation::getSourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSourceFormat) чтобы определить её исходный формат. Используйте его, когда последующая обработка зависит от формата, из которого была загружена текущая копия.

Исходный формат отличается от выбранного [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/) для выходного файла. Сохранение в другой формат не меняет исходный формат существующего экземпляра.

## **Чтение исходного формата файла**

Этот пример требует существующего файла `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation::getSourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSourceFormat), а не имя файла. Измените путь ввода, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения логикой вашего приложения.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Распознавание поддерживаемых значений**

Класс [SourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sourceformat/) определяет целочисленные константы, которые различают следующие форматы презентаций. Приведённые ниже расширения являются условными, а не восстановлением оригинального имени файла.

| Значение SourceFormat | Расширение | Формат |
| --- | --- | --- |
| `Ppt` | `.ppt` | Презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Презентация Office Open XML |
| `Pptm` | `.pptm` | Презентация Office Open XML с поддержкой макросов |
| `Pps` | `.pps` | Слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | Слайд-шоу Office Open XML с поддержкой макросов |
| `Pot` | `.pot` | Шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | Шаблон Office Open XML |
| `Potm` | `.potm` | Шаблон Office Open XML с поддержкой макросов |
| `Odp` | `.odp` | Презентация OpenDocument |
| `Otp` | `.otp` | Шаблон презентации OpenDocument |
| `Fodp` | `.fodp` | Презентация Flat XML ODF |
| `Xml` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Этот пример требует существующего файла `sample.pps`. Чтение его байтов в поток памяти имитирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) принимает только поток.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь различить слайд-шоу или шаблон. Без имени файла устаревший контент PPS и POT может быть определён как `SourceFormat::Ppt`; пример PPS выше выводит целочисленное значение `SourceFormat::Ppt`.

Если вашему приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение служит полезной подсказкой для этих устаревших подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение обнаружения до и после загрузки**

Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) и [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#getLoadFormat), когда необходимо проанализировать файл до загрузки полной объектной модели презентации. Используйте [Presentation::getSourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSourceFormat), когда экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит целочисленные значения `LoadFormat::Pptx` и `SourceFormat::Pptx` соответственно. В продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не требует дополнительного анализа только для получения её исходного формата.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Результаты используют константы из разных классов: [LoadFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sourceformat/). Не сравнивайте их числовые значения и не полагайте, что каждый формат имеет одинаковые результаты обнаружения. PowerPoint XML может быть определён как `LoadFormat::Unknown` до загрузки и как `SourceFormat::Xml` после загрузки.

## **Сохраняйте исходный и выходной форматы раздельно**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит целочисленное значение `SourceFormat::Pptx` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из ODP‑выхода, сообщает `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Презентация, созданная с нуля с помощью `new Presentation()`, сообщает `SourceFormat::Pptx`. У неё нет входного файла: это значение по умолчанию для вновь созданного экземпляра, а не свидетельство того, что был загружен файл PPTX. Отслеживайте, создало ли ваше приложение экземпляр или загрузило, если это различие важно.

## **Отображение исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он сопоставляет каждое из поддерживаемых в настоящее время значений [SourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/sourceformat/) обычному расширению, без парсинга имени входного файла. Резервный вариант предотвращает безмолвное присвоение расширения нераспознанному значению.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Это сопоставление не конвертирует файл и не восстанавливает устаревший подтип PPS/POT, потерянный при загрузке из потока. Для реального сохранения явно выбирайте [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/), или используйте преобразование, показанное в [Save Presentations in Their Original Format](/slides/ru/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создаёт презентацию и записывает три файла в рабочем каталоге, перезаписывая файлы с теми же именами. Он открывает каждый вывод как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, тогда как загрузка тех же байтов без имени файла сообщает `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Следующая таблица суммирует определение исходного формата для презентаций с совпадающими расширениями. Имена обозначают константы; примеры PHP выводят их целочисленные значения:

| Сохранённый формат | SourceFormat из пути к файлу | SourceFormat из безымянного потока |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | То же, что путь к файлу |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | То же, что путь к файлу |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | То же, что путь к файлу |
| ODP, OTP | `Odp`, `Otp` соответственно | То же, что путь к файлу |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT контент определяется как `Ppt` для безымянных потоков. Таблица описывает идентификацию формата, а не сохранение всех особенностей презентации при конвертации.

## **FAQ**

**Сохранение в ODP изменяет исходный формат презентации, загруженной из PPTX?**

Нет. Существующий экземпляр по‑прежнему сообщает `Pptx`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `Odp`.

**Всегда ли поток может различить устаревшую презентацию, слайд-шоу и шаблон?**

Нет. PPT, PPS и POT используют один и тот же бинарный формат. Храните имя файла или метаданные подтипа отдельно, когда требуется такое различие.

**Какой API использовать, если презентация уже загружена?**

Читайте [Presentation::getSourceFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSourceFormat). Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/#getPresentationInfo) для анализа перед загрузкой.