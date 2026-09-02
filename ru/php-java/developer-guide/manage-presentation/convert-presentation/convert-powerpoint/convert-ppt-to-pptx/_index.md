---
title: Конвертировать PPT в PPTX в PHP
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/php-java/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX в PHP с помощью Aspose.Slides. Включает примеры PHP для конвертации одного файла и пакетной обработки, обработку ошибок и заметки о точности."
---
## **Обзор**

PPT — это устаревший бинарный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides для PHP через Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов и объясняет, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), затем вызовите [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) с параметром [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/#Pptx). Блок `finally` освобождает презентацию и её ресурсы.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Загрузить устаревшую PPT презентацию.
$presentation = new Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Расширение файла само по себе не определяет формат вывода; это делает параметр [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/#Pptx). Держите пути входного и выходного файлов разными, если нужно сохранить исходный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому неудачная конверсия одного файла не останавливает остальную часть пакета.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Для производственных нагрузок журналируйте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена файлов, в которых произошла ошибка, в очередь повторных попыток или проверки. Повреждённые файлы, файлы, защищённые паролем, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут вызвать сбой конвертации. См. [Password-Protected Presentations](/php-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию точно одинаково. Устаревшая функция, которой нет эквивалента в PPTX, или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте конвертированный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий workflow с поддержкой макросов, когда VBA необходимо оставить. Также убедитесь, что требуемые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться конвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество слайдов и их содержание, затем сравните внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или сохранять в формате, который проще инспектировать и восстанавливать, чем устаревший бинарный PPT. Сохраните оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не прошла проверку точности.

Если вместо этого нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации по конкретному формату в [Convert Presentations to Multiple Formats](/php-java/convert-presentation/), а не предполагаете, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для единичного файла или быстрой сравнения можно воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторных конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте PHP API.

## **Связанные статьи**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Сохранение презентаций в PHP](/php-java/save-presentation/)
- [Поддерживаемые форматы файлов](/php-java/supported-file-formats/)
- [Открытие презентаций в PHP](/php-java/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides для PHP через Java загружает и сохраняет файлы презентаций без необходимости в Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если он содержит макросы, OLE‑ или ActiveX‑объекты, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла предоставить правильный пароль. Отсутствие пароля или неверный пароль приводит к сбою операции загрузки.

**Стоит ли удалять файл PPT после конвертации?**

Сохраните оригинал, пока вы не проверили PPTX в нужных вам просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертируется иначе.