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

PPT — это устаревший двоичный формат PowerPoint, а PPTX — более новый формат Open XML. Aspose.Slides for PHP via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов, и объясняет, что необходимо проверить после конвертации.

## **Преобразовать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), затем вызовите [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) с параметром [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/#Pptx). Блок `finally` освобождает презентацию и её ресурсы.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Загрузить устаревшую презентацию PPT.
$presentation = new Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/#Pptx). Держите пути входного и выходного файлов разными, если необходимо сохранить оригинальный файл PPT.

## **Преобразовать несколько файлов PPT**

Следующий пример преобразует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому сбой одной конвертации не останавливает остальную партию.

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

Для производственных задач регистрируйте полное исключение, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена файлов с ошибками в очередь повторной попытки или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без необходимого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. раздел [Password-Protected Presentations](/slides/ru/php-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конвертация обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию точно одинаково. Устаревшая функция, не имеющая эквивалента в PPTX или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте преобразованный файл, если он содержит анимации, переходы, встроенные или связанные объекты OLE, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, когда VBA должно оставаться доступным. Также убедитесь, что нужные шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться преобразованная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество и содержание ключевых слайдов, затем сравните его внешний вид и поведение в слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентация будет редактироваться в современных версиях PowerPoint, передаваться системам, работающим с пакетами Open XML, или сохраняться в формате, который проще исследовать и восстанавливать, чем устаревший двоичный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока преобразованная презентация не пройдет проверку точности.

Если вместо этого нужен PDF, HTML, изображения, XPS или другой формат вывода, используйте рекомендации по конкретным форматам в разделе [Convert Presentations to Multiple Formats](/slides/ru/php-java/convert-presentation/), а не предполагайте, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для редкого файла или быстрой проверки вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте PHP API.

## **Связанные статьи**

- [PPT против PPTX](/slides/ru/php-java/ppt-vs-pptx/)
- [Сохранение презентаций в PHP](/slides/ru/php-java/save-presentation/)
- [Поддерживаемые форматы файлов](/slides/ru/php-java/supported-file-formats/)
- [Открытие презентаций в PHP](/slides/ru/php-java/open-presentation/)

## **FAQ**

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for PHP via Java загружает и сохраняет файлы презентаций без необходимости наличия Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентаций, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Просмотрите сгенерированный файл, если он содержит макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Можно ли конвертировать защищённый паролем файл PPT?**

Да, если вы предоставите правильный пароль при загрузке файла. При отсутствии пароля или его неправильном вводе операция загрузки завершится ошибкой.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных просмотрах и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция будет преобразована иначе.