---
title: "Преобразовать презентации в HTML5 с помощью PHP"
linktitle: "Презентация в HTML5"
type: docs
weight: 40
url: /ru/php-java/export-to-html5/
keywords:
- "PowerPoint в HTML5"
- "OpenDocument в HTML5"
- "презентация в HTML5"
- "слайд в HTML5"
- "PPT в HTML5"
- "PPTX в HTML5"
- "ODP в HTML5"
- "сохранить PPT как HTML5"
- "сохранить PPTX как HTML5"
- "сохранить ODP как HTML5"
- "экспортировать PPT в HTML5"
- "экспортировать PPTX в HTML5"
- "экспортировать ODP в HTML5"
- "PHP"
- "Aspose.Slides"
description: "Экспортируйте презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для PHP через Java. Сохраните форматирование, анимацию и интерактивность."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides for PHP via Java. Описываются базовый экспорт, управление анимацией фигур и переходами между слайдами, а также расположение комментариев. Также сравниваются результаты HTML5 с выводом в формате SVG, получаемым при стандартном экспорте в HTML.

## **Экспорт PowerPoint в HTML5**

В следующем примере презентация загружается из рабочего каталога и сохраняется в формате HTML5. Используются настройки экспорта по умолчанию; следующий пример показывает, как явно управлять воспроизведением анимации. Замените путь входного файла на путь к вашей презентации.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Примечание" %}}

Помимо HTML‑документа, экспорт записывает поддерживающие файлы CSS и JavaScript для оформления слайдов, анимаций, эффектов и навигации. Сохраните эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js с публичных CDN; без них навигация по слайдам и анимации не работают.

{{% /alert %}}

Чтобы выполнить экспорт без воспроизведения анимаций фигур или переходов между слайдами, передайте `false` в [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) и [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) в [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Эти параметры независимы, поэтому можно включить один, отключив другой. Пример экспортирует презентацию с отключёнными обоими типами анимации в сгенерированной странице.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт в HTML использует иной подход к визуализации: содержимое слайда представлено в виде SVG внутри HTML‑страницы. В следующем примере презентация преобразуется в HTML‑документ с использованием этого подхода.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; текст‑заполнитель представляет это содержимое и не является фактическим выводом экспорта.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Предупреждение" color="warning" %}}

Экспорт на основе SVG не раскрывает формы PowerPoint как отдельные HTML‑элементы. Используйте экспорт в HTML5, когда нужны параметры анимации фигур и переходов между слайдами, продемонстрированные в этой статье.

{{% /alert %}}

## **Экспорт PowerPoint в представление слайдов HTML5**

Экспорт в HTML5 создаёт страницу для просмотра и навигации по слайдам презентации в браузере. В этом примере включены как [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes), так и [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions), чтобы экспортированное представление слайдов могло воспроизводить эффекты из исходной презентации.

Используйте презентацию, уже содержащую анимацию фигур и переходы между слайдами, чтобы увидеть эффект этих настроек. Включение их не добавляет новые эффекты к слайдам, в которых их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере при наличии поддерживающих файлов.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Преобразование презентации в документ HTML5 с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели могли видеть обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые комментарии не создаются.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) в метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) класса [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Используйте [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), чтобы выбрать `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) и разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с такой компоновкой комментариев. Презентация без комментариев не будет иметь текста комментариев для отображения.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Изображение ниже показывает экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в выводимом документе HTML5](two_comments_html5.png)

## **Исключение гиперссылок JavaScript при экспорте**

Предположим, файл `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить гиперссылку JavaScript при экспорте, передайте `true` в [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). По умолчанию значение `false`, поэтому такие ссылки не фильтруются, если вы не включите параметр.

В следующем примере презентация загружается из рабочего каталога и экспортируется с помощью [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Экспортированный файл опускает JavaScript‑гиперссылку, сохранив её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся неизменной.

Эта опция фильтрует гиперссылки JavaScript; она не удаляет все скрипты или другое активное содержимое и не гарантирует соответствие CSP. Например, вывод HTML5 всё равно включает скрипты для навигации по слайдам и анимаций.

## **FAQ**

**Можно ли управлять тем, будут ли проигрываться анимации объектов и переходы между слайдами в HTML5?**

Да, экспорт в HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) и [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и расположить (например, справа от слайда) через [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) для заметок и комментариев.

**Можно ли пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, настройка [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) позволяет пропустить гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `false`. Смотрите [Exclude JavaScript Hyperlinks During Export](/slides/ru/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта в HTML5 и области действия фильтра. Эта настройка не удаляет JavaScript, используемый просмотрщиком HTML5 для навигации и анимаций.