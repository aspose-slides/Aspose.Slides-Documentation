---
title: Преобразование презентаций в HTML5 в Python через Java
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Python через Java. Сохранение форматирования, анимаций и интерактивности."
---
## **Обзор**

Эта статья объясняет, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides for Python via Java. Она охватывает базовый экспорт, управление анимацией фигур и переходами слайдов, а также расположение комментариев. Также сравнивается вывод HTML5 с выводом на основе SVG при стандартном экспорте в HTML.

Примеры требуют Aspose.Slides for Python via Java и совместимую среду выполнения Java. Поместите входные презентации в текущий рабочий каталог. Каждый пример запускает JVM только если она ещё не запущена.

## **Экспорт PowerPoint в HTML5**

Следующий пример загружает презентацию из рабочего каталога и сохраняет её в формате HTML5. Он использует настройки экспорта по умолчанию; следующий пример показывает, как явно управлять воспроизведением анимации. Замените путь к входному файлу на путь к вашей презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Кроме HTML‑документа, экспорт записывает поддерживающие файлы CSS и JavaScript для стилизации слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимации фигур или переходов слайдов, передайте `False` в [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) и [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) в [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Эти параметры независимы, поэтому можно включить один, отключив другой. Пример экспортирует презентацию с отключёнными обоими типами анимации в сгенерированной странице.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт в HTML использует иной подход к рендерингу: содержимое слайда представляется в виде SVG внутри HTML‑страницы. Следующий пример преобразует презентацию в HTML‑документ, используя этот подход рендеринга.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
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
Экспорт на основе SVG не раскрывает фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт в HTML5, когда нужны параметры анимации фигур и переходов слайдов, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в просмотр слайдов HTML5**

Экспорт в HTML5 создаёт страницу для просмотра и навигации по слайдам презентации в браузере. Этот пример включает как [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes), так и [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions), чтобы экспортируемый просмотр слайдов мог воспроизводить эффекты из исходной презентации.

Используйте презентацию, которая уже содержит анимацию фигур и переходы слайдов, чтобы увидеть эффект этих параметров. Их включение не добавляет новых эффектов к слайдам, в которых их нет. После экспорта откройте сгенерированный документ HTML5 в браузере с доступными поддерживающими файлами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Преобразовать презентацию в документ HTML5 с комментариями**

Вы можете включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели видели обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новых комментариев не создаётся.

![Два комментария на слайде презентации](two_comments_pptx.png)

Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) в метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) класса [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Используйте [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), чтобы выбрать `Right` из перечисления [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) и разместить комментарии справа от каждого слайда.

Следующий пример экспортирует презентацию в HTML5 с этим расположением комментариев. Презентация без комментариев не будет содержать текста комментариев для отображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Изображение ниже показывает экспортированный документ HTML5 с комментариями, отображаемыми рядом со слайдом.

![Комментарии в выводимом документе HTML5](two_comments_html5.png)

## **Исключить JavaScript‑гиперссылки при экспорте**

Предположим, `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить JavaScript‑гиперссылку при экспорте, передайте `True` в [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). По умолчанию значение `False`, поэтому такие ссылки не фильтруются, пока вы не включите параметр.

Следующий пример загружает презентацию из рабочего каталога и экспортирует её с помощью [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Экспортируемый файл опускает JavaScript‑гиперссылку, сохранив её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся без изменений.

Этот параметр фильтрует JavaScript‑гиперссылки; он не удаляет все скрипты или другое активное содержимое и не гарантирует соответствие CSP. Например, вывод HTML5 по‑прежнему включает скрипты для навигации по слайдам и анимаций.

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы слайдов воспроизводиться в HTML5?**

Да, экспорт в HTML5 предоставляет отдельные параметры для включения или отключения [анимацию фигур](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) и [переходы слайдов](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и расположить (например, справа от слайда) через [настройки макета](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) для заметок и комментариев.

**Могу ли я пропустить ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, параметр [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) позволяет пропустить гиперссылки с вызовами JavaScript при сохранении. По умолчанию значение `False`. См. [Исключить JavaScript‑гиперссылки при экспорте](/slides/ru/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта в HTML5 и области действия фильтра. Этот параметр не удаляет JavaScript, используемый просмотрщиком HTML5 для навигации и анимаций.