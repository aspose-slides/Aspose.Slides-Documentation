---
title: Конвертировать презентации PowerPoint в HTML на PHP
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- PHP
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в HTML на PHP. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for PHP via Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Базовое преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и вызова `save` с [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) когда нужно управлять экспортируемым макетом, шрифтами, изображениями, примечаниями, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспортировать всю презентацию или выбранные слайды.
- Создавать HTML с фиксированным макетом, адаптивный или основанный на SVG.
- Включать примечания докладчика и комментарии.
- Управлять качеством изображений и данными обрезанных изображений.
- Встраивать шрифты или сохранять файлы шрифтов отдельно.
- Выбирать способ записи и ссылки на внешние ресурсы и медиафайлы.

По умолчанию экспорт HTML создает автономный HTML‑документ, где большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите внешние ресурсы, уменьшение DPI изображений и встраивание только тех шрифтов, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и сохраните её с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

В этом примере записывается один HTML‑файл. Объект презентации освобождается в блоке `finally`, что освобождает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) — основной класс конфигурации экспорта HTML. Часто используемые параметры:

- `SlidesLayoutOptions`: добавляет примечания, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: изменяет способ представления слайдов, например как SVG.
- `PicturesCompression`: контролирует DPI изображений и размер вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных изображений.
- `SvgResponsiveLayout`: делает экспортированный SVG‑контент адаптивным к контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды при необходимости.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему workflow.

## **Преобразовать выбранные слайды в HTML**

Перегрузка `save`, принимающая номера слайдов, использует 1‑based позицию слайдов. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Используйте эту схему, когда веб‑сайт или приложение требует отдельную HTML‑страницу для каждого слайда. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) и передайте его каждому вызову `save`.

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/responsivehtmlcontroller/) предоставляет адаптивный HTML‑вывод через [HtmlFormatter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше подстраиваться под ширину браузера.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Для адаптивного макета на основе SVG установите `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/). Это удобно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Включить примечания докладчика и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/) через `HtmlOptions.SlidesLayoutOptions`, чтобы включить примечания докладчика или комментарии. Примечания и комментарии скрыты по умолчанию, если не указаны их позиции.

Предположим, исходная презентация содержит примечания докладчика:

![Слайд с примечаниями докладчика в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с примечаниями под слайдом.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Экспортированный HTML включает область примечаний:

![HTML‑вывод со слайдом и примечаниями докладчика](HTML_with_notes.png)

Чтобы экспортировать комментарии, установите `CommentsPosition`, например `CommentsPositions.Right` или `CommentsPositions.Bottom`. Если нужны только комментарии, опустите `NotesPosition`. Если нужны и примечания, и комментарии, задайте оба свойства.

## **Управление качеством изображений и обрезанными областями**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `PicturesCompression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/php-java/aspose.slides/picturescompression/), когда требуется более высокое качество изображений.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

По умолчанию обрезанные области изображений могут быть удалены из экспортируемого вывода. Сохраняйте обрезанные данные только когда пользователи должны иметь возможность восстановить или изучить скрытые части изображения. Сохранение увеличивает размер HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Добавить CSS**

Для простого стилирования передайте строку CSS в [HtmlFormatter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmlformatter/) через `createDocumentFormatter`. Это меняет окружающий HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайда.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Для пользовательского заголовка документа, подключаемого CSS‑файла или пользовательской разметки вокруг слайдов и фигур используйте собственный контроллер форматирования и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmlformatter/) с помощью `createCustomFormatter`.

## **Встроить шрифты**

Если в целевой среде шрифты презентации могут быть не установлены, встроите их в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embedallfontshtmlcontroller/). Встраивание повышает визуальное соответствие, но увеличивает размер вывода.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Исключайте шрифты только когда вы уверены, что целевые браузеры или системы уже их предоставляют. Для брендовых или редких шрифтов встраивание обычно безопаснее.

## **Ссылаться на файлы шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, можно записать данные шрифтов в отдельные файлы WOFF и добавить правила `@font-face` в HTML. В PHP via Java такой сценарий обычно реализуется небольшим Java‑вспомогательным классом, который наследует [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/embedallfontshtmlcontroller/), записывает байты шрифта в каталог вывода и внедряет правила `@font-face` в сгенерированный HTML. Скомпилируйте этот helper, добавьте его в classpath PHP Java Bridge и затем создайте его из PHP через `new Java(...)`.

При построении такого helper выберите два пути намеренно:

- Путь файловой системы, куда записываются сгенерированные файлы шрифтов.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов шрифтов.

## **Сохранить ресурсы внешне**

Автономный HTML легко переносить, но встроенные ресурсы в формате Base64 могут сделать файл крупным. Если приложению нужны внешние файлы изображений, предоставьте пользовательский контроллер link/embed в конструкторе [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/).

Когда вы вынуждаете ресурсы наружу, выберите два пути намеренно:

- Путь файловой системы, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

Согласуйте эти пути с вашей схемой развертывания, чтобы сгенерированный HTML мог загружать внешние ресурсы после переноса на веб‑сервер или в другой каталог.

## **Экспорт медиафайлов**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/videoplayerhtmlcontroller/) экспортирует видео и аудио файлы и пишет HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог вывода, используемый сгенерированным HTML и медиафайлами.
- `fileName`: имя создаваемого HTML‑файла.
- `baseUri`: абсолютный URI‑префикс, используемый в ссылках HTML на медиафайлы.

Если HTML‑файл находится по пути `html-output/presentation.html`, `path` должен указывать на `html-output`, а `baseUri` — на тот же каталог с точки зрения браузера. Для локального превью можно построить URI `file:///` из каталога вывода. Для развернутого приложения используйте абсолютный URL опубликованного каталога вывода.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Используйте уникальные каталоги вывода для каждой задачи экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конверсия HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI в `PicturesCompression`, встроенные шрифты, вывод SVG и сохранённые обрезанные области могут улучшить точность, но обычно увеличивают размер вывода.

Для пакетного конвертирования:

- Своевременно освобождайте каждый объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для разных задач.
- Избегайте встраивания общих шрифтов, если только это не требуется для точного воспроизведения.
- Уменьшайте DPI изображений, когда HTML используется для предварительного просмотра или миниатюр.
- Держите исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не будет окончательно определён путь развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, пока целевой URL действителен.

**Можно ли конвертировать презентации в HTML параллельно?**

Да, но не используйте один объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) одновременно в нескольких потоках. Обрабатывайте разные файлы отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода.

**Является ли объект Presentation потокобезопасным?**

Нет. Один объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте независимый экземпляр на каждый поток или процесс.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может внедрять ресурсы непосредственно в HTML. Встроенные шрифты, изображения высокого DPI, медиа, SVG‑контент и сохранённые обрезанные области также увеличивают размер. Используйте внешние ресурсы, исключайте общие шрифты из встраивания и уменьшайте `PicturesCompression`, когда важнее меньший размер, чем максимальная точность.

**Как выбирать baseUri для экспорта медиа?**

Выбирайте `baseUri` с точки зрения браузера и передавайте его как абсолютный URI. Для локального превью можно получить его из каталога вывода с помощью Java‑URI файла. Для развертывания используйте абсолютный URL опубликованного каталога медиа. Путь файловой системы `path` и `baseUri` в браузере не обязаны быть одинаковыми строками, но должны описывать одно и то же место ресурса.

**Можно ли включать скрытые слайды?**

Да. Установите `ShowHiddenSlides` в `true` в [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/), когда скрытые слайды должны быть экспортированы.