---
title: Преобразование презентаций в HTML5 в .NET
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для .NET. Сохранение форматирования, анимаций и интерактивности."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides для .NET. Описываются базовый экспорт, управление анимацией фигур и переходами слайдов, а также расположение комментариев. Также сравнивается вывод в HTML5 с SVG‑основным выводом стандартного экспорта в HTML.

## **Экспорт PowerPoint в HTML5**

В следующем примере презентация загружается из рабочей директории и сохраняется в формате HTML5. Используются настройки экспорта по умолчанию; в следующем примере показывается, как явно управлять воспроизведением анимации. Замените путь к входному файлу на путь к вашей презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Помимо HTML‑документа, экспорт создаёт поддерживающие файлы CSS и JavaScript для стилизации слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы выполнить экспорт без воспроизведения анимаций фигур или переходов слайдов, установите [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) в `false` в [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Эти параметры независимы, поэтому можно включить один, отключив другой. В примере презентация экспортируется с отключёнными обоими типами анимации на сгенерированной странице.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт в HTML использует другой подход к рендерингу: содержимое слайда представлено в виде SVG внутри HTML‑страницы. В следующем примере презентация преобразуется в HTML‑документ с использованием этого подхода.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

Ниже упрощённая разметка, иллюстрирующая структуру сгенерированной страницы. Элемент SVG содержит рендеринг содержимого слайда; текст‑заполнитель представляет это содержимое и не является реальным результатом экспорта.

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
Экспорт на основе SVG не предоставляет формы PowerPoint в виде отдельных HTML‑элементов. Используйте экспорт в HTML5, если вам нужны параметры анимации фигур и переходов слайдов, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в режим просмотра слайдов HTML5**

Экспорт в HTML5 создает страницу для просмотра и навигации по слайдам презентации в браузере. В этом примере включены как [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/), так и [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/), чтобы экспортированный просмотр слайдов мог воспроизводить эффекты исходной презентации.

Используйте презентацию, уже содержащую анимацию фигур и переходы слайдов, чтобы увидеть эффект этих настроек. Включение их не добавляет новых эффектов к слайдам, где их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере, убедившись, что поддерживающие файлы доступны.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Преобразование презентации в документ HTML5 с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели могли видеть обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые не создаются.

![Два комментария на слайде презентации](two_comments_pptx.png)

Назначьте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) свойству [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) класса [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Установите [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) в значение `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/), чтобы разместить комментарии справа от каждого слайда.

В следующем примере презентация экспортируется в HTML5 с этой компоновкой комментариев. Презентация без комментариев не будет иметь текста комментариев для отображения.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

На изображении ниже показан экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в выходном документе HTML5](two_comments_html5.png)

## **Исключение JavaScript‑ссылок при экспорте**

Предположим, `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить JavaScript‑ссылку при экспорте, установите [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) в `true`. По умолчанию значение `false`, поэтому такие ссылки не фильтруются, если не включить параметр.

В следующем примере презентация загружается из рабочей директории и экспортируется с использованием [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Экспортированный файл удаляет JavaScript‑ссылку, сохраняя её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся неизменной.

Этот параметр фильтрует JavaScript‑ссылки; он не удаляет все скрипты или другой активный контент и не гарантирует соответствие CSP. Например, вывод HTML5 по‑прежнему содержит скрипты для навигации по слайдам и анимаций.

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт в HTML5 предоставляет отдельные параметры для включения или отключения [анимации фигур](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [переходов слайдов](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии могут быть включены в вывод HTML5 и расположены (например, справа от слайда) с помощью [настроек компоновки](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) для заметок и комментариев.

**Могу ли я пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, параметр [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) позволяет пропускать гиперссылки с вызовами JavaScript при сохранении. По умолчанию `false`. См. [Exclude JavaScript Hyperlinks During Export](/slides/ru/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) для простого примера экспорта в HTML, HTML5 и PDF и области действия фильтра. Этот параметр не удаляет JavaScript, используемый HTML5‑просмотрщиком для навигации и анимаций.