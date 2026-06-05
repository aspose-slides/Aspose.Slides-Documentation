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
- презентацию в HTML
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

Aspose.Slides for PHP via Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Базовое преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и вызова `save` с [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/), когда необходимо контролировать экспортированный макет, шрифты, изображения, заметки, комментарии, вывод SVG или связанные ресурсы.

Это руководство сосредоточено на практических сценариях экспорта в HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация HTML с фиксированным макетом, адаптивным или основанным на SVG.
- Включение заметок докладчика и комментариев.
- Управление качеством изображений и обрезанными данными изображений.
- Встраивание шрифтов или отдельное сохранение файлов шрифтов.
- Выбор способа записи и ссылки на внешние ресурсы и медиа‑файлы.

По умолчанию экспорт в HTML создает самостоятельный HTML‑документ, в котором большинство ресурсов внедрено. Это удобно для обмена одним файлом, но может увеличить размер результата. Для публикации в вебе рассмотрите возможность использования внешних ресурсов, снижения DPI изображений и встраивания только тех шрифтов, которые не гарантированно доступны в целевой среде.

## **Преобразование презентации в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и сохраните с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Этот пример записывает один HTML‑файл. Объект презентации освобождается в блоке `finally`, что закрывает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использование HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) — основной класс конфигурации экспорта в HTML. Часто используемые параметры включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: изменяет способ представления слайдов, например как SVG.
- `PicturesCompression`: управляет DPI изображений и размером результата.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных изображений.
- `SvgResponsiveLayout`: делает экспортированный SVG‑контент адаптивным к контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды, если это необходимо.

В следующих разделах показаны наиболее распространённые параметры отдельно, чтобы вы могли комбинировать только те, которые требуются вашему рабочему процессу.

## **Преобразование выбранных слайдов в HTML**

Перегрузка `save`, принимающая номера слайдов, использует 1‑based индексацию. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

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

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если у всех слайдов одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/) и передайте его каждому вызову `save`.

## **Создание адаптивного HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/responsivehtmlcontroller/) обеспечивает адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmlformatter/). Используйте его, когда экспортированная страница должна лучше подстраиваться под ширину браузера.

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

Для адаптивного макета на основе SVG задайте `SvgResponsiveLayout` у [HtmlOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

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

## **Включение заметок докладчика и комментариев**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notescommentslayoutingoptions/) через `HtmlOptions.SlidesLayoutOptions`, чтобы включить заметки докладчика или комментарии. Заметки и комментарии скрыты по умолчанию, если только вы не укажете их позиции.

Предположим, исходная презентация содержит заметки докладчика:

![Слайд с заметками докладчика в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками под слайдом.

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

Экспортированный HTML включает область заметок:

![HTML‑результат