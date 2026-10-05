---
title: Конвертировать презентации в HTML5 на Android
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Android через Java. Сохранить форматирование, анимацию и интерактивность."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides for Android через Java. В ней рассматривается базовый экспорт, управление анимацией фигур и переходами слайдов, а также размещение комментариев. Кроме того, сравнивается вывод в формате HTML5 с SVG‑основанным выводом стандартного экспорта HTML.

## **Экспорт PowerPoint в HTML5**

Следующий пример загружает презентацию из рабочей директории и сохраняет её в формате HTML5. Он использует настройки экспорта по умолчанию; следующий пример показывает, как явно управлять воспроизведением анимаций. Замените путь к входному файлу на путь к вашей презентации.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Помимо HTML‑документа, экспорт записывает поддерживающие CSS‑ и JavaScript‑файлы для оформления слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимаций фигур или переходов слайдов, передайте `false` в методы [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) класса [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Эти настройки независимы, поэтому можно включить одну, отключив другую. Пример экспортирует презентацию с отключёнными обоими типами анимаций в сгенерированной странице.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт HTML использует иной подход к рендерингу: содержимое слайда представляется в виде SVG внутри HTML‑страницы. Следующий пример преобразует презентацию в HTML‑документ, используя этот подход.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; текст‑заполнитель представляет это содержимое и не является буквальным выводом экспорта.

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
Экспорт на основе SVG не раскрывает фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт в HTML5, если вам нужны параметры анимации фигур и переходов слайдов, демонстрируемые в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в HTML5‑просмотр слайдов**

Экспорт в HTML5 создаёт страницу для просмотра и навигации по слайдам презентации в браузере. Этот пример включает как [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-), так и [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), чтобы экспортированный просмотр слайдов мог воспроизводить эффекты исходной презентации.

Используйте презентацию, в которой уже есть анимации фигур и переходы слайдов, чтобы увидеть эффект этих настроек. Включение их не добавит новых эффектов к слайдам, у которых их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере при наличии поддерживающих файлов.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Преобразовать презентацию в HTML5‑документ с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели видели обратную связь рядом с содержимым слайда. Пример в этом разделе ожидает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые комментарии не создаются.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) в метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) класса [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Используйте [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), чтобы выбрать `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) и разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с этой компоновкой комментариев. Презентация без комментариев не будет содержать текст комментариев для отображения.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Изображение ниже показывает экспортированный HTML5‑документ с комментариями, отображаемыми рядом со слайдом.

![Комментарии в результирующем HTML5‑документе](two_comments_html5.png)

## **Исключение гиперссылок JavaScript при экспорте**

Предположим, что `hyperlinks.pptx` содержит текст со ссылкой вида `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить гиперссылку JavaScript при экспорте, передайте `true` в метод [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). По умолчанию значение `false`, поэтому такие ссылки не фильтруются, пока вы не включите опцию.

Следующий пример загружает презентацию из рабочей директории и экспортирует её, используя [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Экспортированный файл опускает гиперссылку JavaScript, сохраняя её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся неизменной.

Эта опция фильтрует гиперссылки JavaScript; она не удаляет все скрипты или другое активное содержимое и не гарантирует соответствие CSP. Например, в выводе HTML5 по‑прежнему присутствуют скрипты для навигации по слайдам и анимаций.

## **Часто задаваемые вопросы**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт в HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и разместить (например, справа от слайда) с помощью [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) для заметок и комментариев.

**Можно ли пропустить ссылки, вызывающие JavaScript, из соображений безопасности или CSP?**

Да, настройка [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) позволяет пропускать гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `false`. См. раздел [Exclude JavaScript Hyperlinks During Export](/slides/ru/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта в HTML5 и области действия фильтра. Эта настройка не удаляет JavaScript, используемый просмотрщиком HTML5 для навигации и анимаций.