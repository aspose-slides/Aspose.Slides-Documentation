---
title: Конвертировать презентации в HTML5 с помощью Python
linktitle: Презентация в HTML5
type: docs
weight: 40
url: /ru/python-net/export-to-html5/
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
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в адаптивный HTML5 с помощью Aspose.Slides для Python через .NET. Сохраняет форматирование, анимацию и интерактивность."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в HTML5 с помощью Aspose.Slides for Python via .NET. Рассматриваются базовый экспорт, управление анимациями фигур и переходами между слайдами, а также расположение комментариев. Также сравнивается вывод HTML5 с выводом на основе SVG при стандартном экспорте в HTML.

## **Экспорт PowerPoint в HTML5**

В следующем примере презентация загружается из рабочей директории и сохраняется в формате HTML5. Используются настройки экспорта по умолчанию; в следующем примере показано, как явно управлять воспроизведением анимаций. Замените путь к входному файлу на путь к вашей презентации.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Помимо HTML‑документа, экспорт создает поддерживающие файлы CSS и JavaScript для стилизации слайдов, анимаций, эффектов и навигации. Сохраняйте эти файлы вместе с HTML‑документом при перемещении или публикации результата. Сгенерированная страница также загружает jQuery и Anime.js из публичных CDN; без них навигация по слайдам и анимации не работают.
{{% /alert %}}

Чтобы экспортировать без воспроизведения анимаций фигур или переходов между слайдами, установите [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) в `False` в [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Эти параметры независимы, поэтому можно включить один, отключив другой. В примере презентация экспортируется с отключенными обоими типами анимаций на сгенерированной странице.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Экспорт PowerPoint в HTML**

Стандартный экспорт в HTML использует иной подход к рендерингу: содержимое слайда представляется в виде SVG внутри HTML‑страницы. В следующем примере презентация конвертируется в HTML‑документ с использованием этого подхода.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Упрощённая разметка ниже иллюстрирует структуру сгенерированной страницы. Элемент SVG содержит отрисованное содержимое слайда; текст‑заполнитель представляет это содержимое и не является реальным выводом экспорта.

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
Экспорт на основе SVG не раскрывает фигуры PowerPoint как отдельные HTML‑элементы. Используйте экспорт в HTML5, когда требуются варианты анимации фигур и переходов между слайдами, продемонстрированные в этой статье.
{{% /alert %}}

## **Экспорт PowerPoint в представление слайдов HTML5**

Экспорт в HTML5 создает страницу для просмотра и навигации по слайдам презентации в браузере. В этом примере включены как [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/), так и [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/), чтобы представление экспортированных слайдов могло воспроизводить эффекты из исходной презентации.

Используйте презентацию, которая уже содержит анимации фигур и переходы между слайдами, чтобы увидеть эффект этих настроек. Включение их не добавит новые эффекты к слайдам, где их нет. После экспорта откройте сгенерированный HTML5‑документ в браузере с доступными поддерживающими файлами.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Конвертация презентации в документ HTML5 с комментариями**

Можно включить существующие комментарии к слайдам в вывод HTML5, чтобы читатели видели обратную связь рядом с содержимым слайда. Пример в этом разделе предполагает, что исходная презентация содержит комментарии, как показано ниже. Он экспортирует эти комментарии; новые не создаёт.

![Два комментария на слайде презентации](two_comments_pptx.png)

Назначьте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) свойству [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) класса [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Установите [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) в `RIGHT` из перечисления [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/), чтобы разместить комментарии справа от каждого слайда.

В следующем примере презентация экспортируется в HTML5 с такой компоновкой комментариев. Презентация без комментариев не будет содержать текста комментариев для отображения.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![Комментарии в выводимом документе HTML5](two_comments_html5.png)

## **Исключение гиперссылок JavaScript при экспорте**

Предположим, что `hyperlinks.pptx` содержит связанный текст с целью `javascript:alert('Hello')` и обычную ссылку `https://example.com/`. Чтобы исключить гиперссылку JavaScript при экспорте, установите [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) в `True`. По умолчанию значение `False`, поэтому такие ссылки не фильтруются, если не включить параметр.

В следующем примере презентация загружается из рабочей директории и экспортируется с использованием [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Экспортируемый файл опускает гиперссылку JavaScript, сохраняя её текст и обычную HTTPS‑ссылку. Исходная презентация остаётся без изменений.

Этот параметр фильтрует гиперссылки JavaScript; он не удаляет все скрипты или иной активный контент и не гарантирует соответствие CSP. Например, вывод HTML5 по‑прежнему включает скрипты для навигации по слайдам и анимаций.

## **FAQ**

**Могу ли я управлять тем, будут ли анимации объектов и переходы между слайдами воспроизводиться в HTML5?**

Да, экспорт в HTML5 предоставляет отдельные параметры для включения или отключения [анимаций фигур](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) и [переходов между слайдами](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Поддерживаются ли комментарии и где их можно разместить относительно слайда?**

Да, существующие комментарии можно включить в вывод HTML5 и разместить (например, справа от слайда) с помощью [настроек расположения](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) для заметок и комментариев.

**Могу ли я пропускать ссылки, вызывающие JavaScript, по соображениям безопасности или CSP?**

Да, параметр [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) позволяет пропускать гиперссылки с вызовами JavaScript при сохранении. По умолчанию `False`. Смотрите [Exclude JavaScript Hyperlinks During Export](/slides/ru/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) для примера экспорта в HTML5 и области действия фильтра. Этот параметр не удаляет JavaScript, используемый просмотрщиком HTML5 для навигации и анимаций.