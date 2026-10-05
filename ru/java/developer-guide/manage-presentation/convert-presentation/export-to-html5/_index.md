---
title: "Конвертировать презентации в HTML5 на Java"
linktitle: "Презентация в HTML5"
type: docs
weight: 40
url: /ru/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Экспортировать презентации PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides for Java. Сохраните форматирование, анимацию и интерактивность."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides for Java. Она охватывает базовый экспорт, управление анимациями фигур и переходами слайдов, а также макет комментариев. Также сравнивается вывод HTML5 с основанным на SVG выводом стандартного экспорта HTML.

## **Экспорт PowerPoint в HTML5**

Следующий пример загружает презентацию из текущего каталога и сохраняет её в формате HTML5. Он использует настройки экспорта по умолчанию; следующий пример показывает, как явно управлять воспроизведением анимации. Замените путь к входному файлу на путь к вашей презентации.

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
Помимо HTML‑документа экспорт записывает поддерживающие файлы CSS и JavaScript для стилизации слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из общедоступных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимаций фигур или переходов слайдов, передайте `false` в [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) в [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Эти настройки независимы, поэтому вы можете включить одну, отключив другую. Пример экспортирует презентацию с отключёнными обоими типами анимаций в сгенерированной странице.

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

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; текст‑заполнитель представляет это содержимое и не является буквальным экспортом.

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
Экспорт на основе SVG не раскрывает фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт HTML5, когда нужны параметры анимации фигур и переходов слайдов, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в просмотр слайдов HTML5**

Экспорт HTML5 создаёт страницу для просмотра и навигации по слайдам презентации в браузере. Этот пример включает как [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-), так и [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-), чтобы экспортированный просмотр слайдов мог воспроизводить эффекты из исходной презентации.

Используйте презентацию, уже содержащую анимацию фигур и переходы слайдов, чтобы увидеть влияние этих настроек. Их включение не добавляет новых эффектов к слайдам, у которых их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере с доступными поддерживающими файлами.

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

## **Преобразовать презентацию в документ HTML5 с комментариями**

Вы можете включить существующие комментарии слайдов в вывод HTML5, чтобы читатели видели обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые комментарии не создаются.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) в метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) класса [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Используйте [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-), чтобы выбрать `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) и разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с этим расположением комментариев. Презентация без комментариев не будет иметь текста комментариев для отображения.

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

Изображение ниже показывает экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в экспортированном документе HTML5](two_comments_html5.png)

## **Исключить JavaScript‑ссылки при экспорте**

Предположим, `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить JavaScript‑ссылку при экспорте, передайте `true` в [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). По умолчанию значение `false`, поэтому такие ссылки не фильтруются, если не включить опцию.

Следующий пример загружает презентацию из текущего каталога и экспортирует её, используя [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

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

Экспортированный файл опускает JavaScript‑ссылку, оставляя её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся без изменений.

Эта опция фильтрует JavaScript‑ссылки; она не удаляет все скрипты или другое активное содержимое и не гарантирует соответствие CSP. Например, вывод HTML5 всё равно включает скрипты для навигации по слайдам и анимаций.

## **Часто задаваемые вопросы**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт HTML5 предоставляет отдельные параметры для включения или отключения [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и расположить (например, справа от слайда) с помощью [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) для заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, настройка [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) позволяет пропускать гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `false`. См. [Exclude JavaScript Hyperlinks During Export](/slides/ru/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта HTML5 и области действия фильтра. Эта настройка не удаляет JavaScript, используемый HTML5‑просмотрщиком для навигации и анимаций.