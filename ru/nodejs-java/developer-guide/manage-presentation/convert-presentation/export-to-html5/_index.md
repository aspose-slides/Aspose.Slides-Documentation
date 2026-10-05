---
title: Преобразование презентаций в HTML5 на JavaScript
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/nodejs-java/export-to-html5/
keywords:
- PowerPoint в HTML5
- OpenDocument в HTML5
- презентация в HTML5
- слайд в HTML5
- PPT в HTML5
- PPTX в HTML5
- ODP в HTML5
- сохранить PPT как HTML5
- сохранить PPTX как HTML5
- сохранить ODP как HTML5
- экспортировать PPT в HTML5
- экспортировать PPTX в HTML5
- экспортировать ODP в HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Node.js. Сохраняет форматирование, анимацию и интерактивность."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides для Node.js через Java. Она охватывает базовый экспорт, управление анимациями фигур и переходами слайдов, а также расположение комментариев. Также сравнивается вывод HTML5 с выводом SVG‑основного стандартизированного HTML‑экспорта.

## **Экспорт PowerPoint в HTML5**

Следующий пример загружает презентацию из рабочей директории и сохраняет её в формате HTML5. Он использует настройки экспорта по умолчанию; следующий пример показывает, как явно управлять воспроизведением анимаций. Замените путь к входному файлу на путь к вашей презентации.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Кроме HTML‑документа, экспорт записывает поддерживающие файлы CSS и JavaScript для стилизации слайдов, анимаций, эффектов и навигации. Храните эти файлы вместе с HTML‑документом при перемещении или публикации вывода. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимаций фигур или переходов слайдов, передайте `false` в [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) и [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) в [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Эти настройки независимы, поэтому вы можете включить одну, отключив другую. Пример экспортирует презентацию с отключёнными обоими типами анимаций в сгенерированной странице.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт HTML использует иной подход к рендерингу: содержание слайда представляется в виде SVG внутри HTML‑страницы. Следующий пример преобразует презентацию в HTML‑документ, используя этот подход рендеринга.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; заполнительный текст представляет это содержание и не является буквальным выводом экспорта.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Экспорт на основе SVG не представляет фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт HTML5, когда нужны параметры анимации фигур и переходов слайдов, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в просмотр HTML5‑слайдов**

Экспорт HTML5 создает страницу для просмотра и навигации по слайдам презентации в браузере. В этом примере включены оба [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) и [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-), чтобы экспортируемый просмотр слайдов мог воспроизводить эффекты из исходной презентации.

Используйте презентацию, в которой уже есть анимации фигур и переходы слайдов, чтобы увидеть эффект этих настроек. Включение их не добавляет новых эффектов к слайдам, у которых их нет. После экспорта откройте сгенерированный документ HTML5 в браузере, имея доступ к поддерживающим файлам.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Преобразование презентации в документ HTML5 с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели могли видеть обратную связь рядом с содержимым слайда. Пример в этом разделе ожидает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новых комментариев не создаётся.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) в метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) класса [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Используйте [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) для выбора `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/), чтобы разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с таким расположением комментариев. Презентация без комментариев не будет иметь текста комментариев для отображения.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Изображение ниже показывает экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в выводимом документе HTML5](two_comments_html5.png)

## **Исключение гиперссылок JavaScript при экспорте**

Предположим, `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить JavaScript‑гиперссылку при экспорте, передайте `true` в [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). По умолчанию значение `false`, поэтому такие ссылки не фильтруются, если вы не включите эту опцию.

Следующий пример загружает презентацию из рабочей директории и экспортирует её с помощью [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Экспортированный файл опускает JavaScript‑гиперссылку, сохраняя её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся неизменной.

Эта опция фильтрует JavaScript‑гиперссылки; она не удаляет все скрипты или иной активный контент и не гарантирует соответствие CSP. Например, вывод HTML5 всё ещё включает скрипты для навигации по слайдам и анимаций.

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) и [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии могут быть включены в вывод HTML5 и расположены (например, справа от слайда) через [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) для заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, настройка [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) позволяет пропустить гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `false`. См. раздел [Exclude JavaScript Hyperlinks During Export](/slides/ru/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта HTML5 и области действия фильтра. Эта настройка не удаляет JavaScript, используемый HTML5‑просмотрщиком для навигации и анимаций.