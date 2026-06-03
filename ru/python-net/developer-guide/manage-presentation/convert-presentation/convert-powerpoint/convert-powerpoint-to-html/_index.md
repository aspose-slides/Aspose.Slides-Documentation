---
title: Преобразовать презентации PowerPoint в HTML с помощью Python
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-html/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
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
- Python
- Aspose.Slides
description: "Преобразовать презентации PowerPoint в HTML с помощью Python. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа‑файлов."
---
## **Обзор**

Aspose.Slides for Python via .NET может сохранять презентации PowerPoint в HTML без Microsoft PowerPoint. Базовое преобразование представляет собой загрузку одного [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и вызов `save` с [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/), когда требуется управлять экспортируемым макетом, шрифтами, изображениями, примечаниями, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта в HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация фиксированного, адаптивного или SVG‑основанного HTML.
- Включение заметок выступающего и комментариев.
- Управление качеством изображений и данными обрезанных изображений.
- Встраивание шрифтов или сохранение файлов шрифтов отдельно.
- Выбор способа записи и ссылки на внешние ресурсы и медиа‑файлы.

По умолчанию экспорт в HTML создает самодостаточный HTML‑документ, в котором большинство ресурсов внедрено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите внешние ресурсы, уменьшите DPI изображений и внедряйте только те шрифты, которые недоступны в целевой среде.

## **Конвертировать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и сохраните с помощью [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

В этом примере пишется один HTML‑файл. Оператор `with` освобождает объект презентации и закрывает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) — основной класс конфигурации экспорта в HTML. Общие параметры включают:

- `slides_layout_options`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `html_formatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `slide_image_format`: меняет способ представления слайдов, например как SVG.
- `pictures_compression`: управляет DPI изображений и размером вывода.
- `delete_pictures_cropped_areas`: сохраняет или удаляет данные обрезанных изображений.
- `svg_responsive_layout`: заставляет экспортированный SVG‑контент адаптироваться к контейнеру.
- `show_hidden_slides`: включает скрытые слайды при необходимости.

Ниже перечислены наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Конвертировать выбранные слайды в HTML**

Перегрузка `save`, принимающая номера слайдов, использует позиции, нумеруемые с 1. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если все слайды должны иметь одинаковый макет, создайте один объект [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) и передайте его каждому вызову `save`.

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/responsivehtmlcontroller/) обеспечивает адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше подстраиваться под ширину браузера.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Для адаптивного макета на основе SVG установите `svg_responsive_layout` в [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/). Это полезно, когда содержание слайда экспортируется как масштабируемая разметка SVG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Включить заметки выступающего и комментарии**

Через `html_options.slides_layout_options` используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notescommentslayoutingoptions/), чтобы включить заметки выступающего или комментарии. По умолчанию заметки и комментарии скрыты, если только вы не зададите их положения.

Предположим, исходная презентация содержит заметки выступающего:

![Слайд с заметками выступающего в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками под слайдом.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Экспортированный HTML включает область заметок:

![HTML‑вывод со слайдом и заметками выступающего](HTML_with_notes.png)

Чтобы экспортировать комментарии, задайте `comments_position`, например `CommentsPositions.RIGHT` или `CommentsPositions.BOTTOM`. Если нужны только комментарии, опустите `notes_position`. Если нужны и заметки, и комментарии, задайте оба свойства.

## **Управление качеством изображений и обрезанными областями**

Экспорт в HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `pictures_compression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/picturescompression/), когда требуется более высокое качество изображений.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

По умолчанию обрезанные области изображений могут быть удалены из экспортированного вывода. Сохраняйте обрезанные данные только тогда, когда пользователи должны иметь возможность восстановить или просмотреть скрытые части изображения. Сохранение увеличивает размер HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Добавить CSS**

Для простого стилизования передайте строку CSS в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/). Это изменит внешний HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайдов.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Для пользовательской шапки документа, подключённого CSS‑файла или произвольной разметки вокруг слайдов и фигур используйте пользовательский контроллер форматирования и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/) через `create_custom_formatter`.

## **Встраивание шрифтов**

Если в целевой среде шрифты презентации могут быть не установлены, внедрите их в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/python-net/aspose.sl