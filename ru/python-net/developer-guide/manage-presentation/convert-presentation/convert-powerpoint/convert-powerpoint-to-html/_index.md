---
title: Конвертировать презентации PowerPoint в HTML на Python
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-net/convert-powerpoint-to-html/
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
- Python
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в HTML на Python. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Python via .NET может сохранять презентации PowerPoint в HTML без Microsoft PowerPoint. Основное преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) и вызова `save` с [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) когда необходимо контролировать экспортируемый макет, шрифты, изображения, заметки, комментарии, вывод SVG или связанные ресурсы.

Это руководство посвящено практическим сценариям экспорта HTML:

- Экспортировать всю презентацию или выбранные слайды.
- Создавать HTML с фиксированным макетом, адаптивный или основанный на SVG.
- Включать нотатки докладчика и комментарии.
- Контролировать качество изображений и обрезанные данные изображений.
- Встраивать шрифты или сохранять файлы шрифтов отдельно.
- Выбирать, как записываются и ссылаются внешние ресурсы и медиа‑файлы.

По умолчанию экспорт HTML создает автономный HTML‑документ, в котором большинство ресурсов встраиваются. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для веб‑публикаций рассматривайте внешние ресурсы, уменьшайте DPI изображений и встраивайте только те шрифты, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), а затем сохраните с помощью [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/).



Этот пример записывает один HTML‑файл. Оператор `with` освобождает объект презентации и закрывает дескрипторы файлов и ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) — основной класс конфигурации для экспорта HTML. Распространённые настройки включают:

- `slides_layout_options`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `html_formatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `slide_image_format`: изменяет способ представления слайдов, например как SVG.
- `pictures_compression`: контролирует DPI изображения и размер вывода.
- `delete_pictures_cropped_areas`: сохраняет или удаляет данные обрезанных изображений.
- `svg_responsive_layout`: делает экспортированный SVG‑контент адаптивным к контейнеру.
- `show_hidden_slides`: включает скрытые слайды при необходимости.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему процессу.

## **Экспортировать выбранные слайды в HTML**

Перегрузка `save`, принимающая номера слайдов, использует нумерацию, начинающуюся с 1. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

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

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) и передавайте его каждому вызову `save`.

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/responsivehtmlcontroller/) обеспечивает адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/). Используйте его, когда экспортированная страница должна лучше адаптироваться к ширине браузера.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Для адаптивного макета на основе SVG установите `svg_responsive_layout` в [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Включить нотатки докладчика и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notescommentslayoutingoptions/) через `html_options.slides_layout_options`, чтобы включить нотатки докладчика или комментарии. Нотатки и комментарии скрыты по умолчанию, если только не указаны их позиции.

Предположим, исходная презентация содержит нотатки докладчика:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с нотатками докладчика под слайдом.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

Экспортированный HTML включает область нотаток:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Для экспорта комментариев установите `comments_position`, например `CommentsPositions.RIGHT` или `CommentsPositions.BOTTOM`. Если нужны только комментарии, опустите `notes_position`. Если нужны и нотатки, и комментарии, задайте оба свойства.

## **Контролировать качество изображений и обрезанные области**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `pictures_compression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/picturescompression/), когда требуется более высокое качество изображения.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

По умолчанию обрезанные области изображений могут быть удалены из экспортированного вывода. Сохраняйте обрезанные данные только тогда, когда пользователи должны иметь возможность восстановить или просмотреть скрытые части изображения. Сохранение их может увеличить размер HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Добавить CSS**

Для простого стилизования передайте строку CSS в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/). Это изменит окружающий HTML‑документ, в то время как Aspose.Slides продолжит рендерить содержимое слайда.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Для собственного заголовка документа, подключённого CSS‑файла или пользовательской разметки вокруг слайдов и фигур используйте пользовательский контроллер форматирования и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/) с `create_custom_formatter`.

## **Встраивание шрифтов**

Если в целевой среде шрифты презентации могут быть не установлены, встраивайте шрифты в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Встраивание повышает визуальную точность, но увеличивает размер вывода.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Исключайте шрифт только тогда, когда уверены, что целевые браузеры или системы уже предоставляют его. Для брендовых или менее распространённых шрифтов встраивание обычно безопаснее.

## **Ссылаться на файлы шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, вы можете записать данные шрифтов в отдельные файлы WOFF и добавить правила `@font-face` в HTML. Для этого требуется контроллер, который настраивает способ записи данных шрифтов во время экспорта. В Python через .NET реализуйте такой контроллер в небольшом .NET‑вспомогательном сборке, загрузите его в Python и передайте вспомогательный объект в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmlformatter/) с `create_custom_formatter`.

При внешнем хранении шрифтов выберите два пути сознательно:

- Каталог файловой системы, куда будут записываться сгенерированные WOFF‑файлы.
- URL‑путь, который будет указан в HTML‑документе и который браузер будет использовать для загрузки этих файлов шрифтов.

Храните HTML‑файл и сгенерированные файлы шрифтов вместе до окончательного определения путей развертывания. Если файлы развертываются в другом месте, сделайте URL‑префикс соответствующим опубликованному URL‑пути.

## **Сохранять ресурсы внешне**

Автономный HTML легко перемещать, но встроенные ресурсы Base64 могут сделать файл большим. Если вашему приложению нужны внешние файлы изображений, шрифтов, аудио или видео, используйте пользовательский контроллер link/embed и передайте его в конструктор [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/).

При внешнем хранении ресурсов выберите два пути сознательно:

- Путь в файловой системе, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

Для полного обсуждения привязки изображений см. [Export Presentations to HTML with Externally Linked Images](/slides/ru/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Экспортировать медиа‑файлы**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/videoplayerhtmlcontroller/) экспортирует видео и аудио файлы и записывает HTML, который может воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, куда будут записываться сгенерированные медиа‑файлы.
- `file_name`: имя генерируемого HTML‑файла.
- `base_uri`: абсолютный URI‑префикс, используемый в HTML‑ссылках на медиа‑файлы.

Если HTML‑файл находится по пути `html-output/presentation.html`, а медиа‑файлы сохраняются в `html-output/media`, `path` должен указывать на каталог медиа‑файлов на диске, а `base_uri` — на тот же каталог с точки зрения браузера. Для локального предварительного просмотра можно построить URI `file:///` из каталога медиа‑файлов. Для развернутого приложения используйте абсолютный URL опубликованного каталога медиа‑файлов.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Используйте каталоги вывода, уникальные для каждого задания экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конверсия HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI в `pictures_compression`, встроенные шрифты, вывод SVG и сохранённые обрезанные области изображений могут улучшить точность, но обычно увеличивают размер вывода.

Для пакетного преобразования:

- Своевременно освобождайте каждый экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для отдельных заданий.
- Избегайте встраивания распространённых шрифтов, если это не требуется для точности.
- Уменьшайте DPI изображений, когда HTML нужен для предпросмотра или миниатюр.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе до окончательного определения путей развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Можно ли параллельно конвертировать презентации в HTML?**

Да, но не делитесь одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) между потоками. Обрабатывайте разные файлы с отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода. См. [multithreading guidance](/slides/ru/python-net/multithreading/) для деталей.

**Является ли объект Presentation потокобезопасным?**

Нет. Один экземпляр [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте независимый экземпляр на каждый поток или процесс.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы прямо в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте из встраивания распространённые шрифты и уменьшайте `pictures_compression`, когда важнее меньший размер вывода, чем максимальная точность.

**Как выбрать base_uri для экспорта медиа?**

Выбирайте `base_uri` с точки зрения браузера и передавайте его как абсолютный URI. Для локального предварительного просмотра можно получить его из каталога вывода с помощью `Path(media_directory).as_uri() + "/"`. Для развертывания используйте абсолютный URL опубликованного каталога медиа‑файлов. Файловый путь `path` и браузерный `base_uri` не обязаны быть одной и той же строкой, но должны указывать на одно и то же место ресурсов.

**Можно ли включать скрытые слайды?**

Да. Установите `show_hidden_slides = True` на [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/), когда скрытые слайды необходимо экспортировать.