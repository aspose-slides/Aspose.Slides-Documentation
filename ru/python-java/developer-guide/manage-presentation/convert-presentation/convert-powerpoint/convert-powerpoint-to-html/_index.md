---
title: Преобразование презентаций PowerPoint в HTML в Python через Java
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-java/convert-powerpoint-to-html/
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
- Python
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в HTML в Python через Java. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Python via Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Базовое преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и вызова [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с параметром [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/), когда необходимо управлять экспортируемой разметкой, шрифтами, изображениями, заметками, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация фиксированной, адаптивной или SVG‑основанной разметки HTML.
- Включение заметок диктора и комментариев.
- Управление качеством изображений и данными обрезанных областей.
- Встраивание шрифтов или сохранение файлов шрифтов отдельно.
- Выбор способа записи и ссылки на внешние ресурсы и медиа‑файлы.

По умолчанию экспорт HTML создаёт автономный HTML‑документ, в котором большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите возможность внешних ресурсов, снижения DPI изображений и встраивания только тех шрифтов, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и сохраните с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Каждый пример загружает `presentation.pptx` из текущего рабочего каталога. Установите Aspose.Slides for Python via Java и совместимую среду выполнения Java перед запуском. JVM запускается один раз на процесс Python.

Этот пример записывает один HTML‑файл. Объект презентации уничтожается в блоке `finally`, что освобождает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Настройка экспорта HTML**

[HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/) — основной класс конфигурации экспорта HTML. Часто используемые настройки включают:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): добавляет заметки, комментарии, раздаточные материалы или другую информацию о разметке.
- [setHtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setHtmlFormatter): изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- [setSlideImageFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlideImageFormat): меняет способ представления слайдов, например как SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression): контролирует DPI изображений и размер вывода.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): сохраняет или удаляет данные обрезанных изображений.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): делает экспортируемый SVG‑контент адаптивным к своему контейнеру.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): включает скрытые слайды при необходимости.

В последующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Преобразовать выбранные слайды в HTML**

Перегрузка [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), принимающая номера слайдов, использует 1‑based позиции. Ниже цикл, сохраняющий каждый слайд в отдельный HTML‑файл.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одной HTML‑страницы на слайд. Если все слайды должны иметь одинаковую разметку, создайте один экземпляр [HtmlOptions] и передайте его каждому вызову [Presentation.save].

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/responsivehtmlcontroller/) предоставляет адаптивный HTML‑вывод через [HtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/). Используйте его, когда экспортированная страница должна лучше подстраиваться под ширину браузера.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Для адаптивной разметки на основе SVG вызовите [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) с параметром `True`. Это полезно, когда содержимое слайда экспортируется как масштабируемая SVG‑разметка.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Включить заметки диктора и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) через [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), чтобы включить заметки диктора или комментарии. Заметки и комментарии скрыты по умолчанию, если только вы не укажете их положение.

Предположим, исходная презентация содержит заметки диктора:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками под слайдом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Экспортированный HTML включает область заметок:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Чтобы экспортировать комментарии, вызовите [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), например с [CommentsPositions.Right](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentspositions/#Right) или [CommentsPositions.Bottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentspositions/#Bottom). Если нужны только комментарии, опустите вызов [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Если нужны и заметки, и комментарии, вызовите оба метода.

## **Контроль качества изображений и обрезанных областей**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Передайте значение в [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression) из [PicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturescompression/), когда требуется более высокое качество изображений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

По умолчанию обрезанные области изображений могут быть удалены из экспортируемого вывода. Сохраняйте обрезанные данные только тогда, когда пользователи должны иметь возможность восстановить или проанализировать эти скрытые части изображения. Сохранение увеличивает размер HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Добавить CSS**

Для простого стилизования передайте строку CSS в [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Это меняет окружающий HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Для пользовательского заголовка документа, подключённого CSS‑файла или произвольной разметки вокруг слайдов и фигур используйте пользовательский контроллер форматирования через прокси‑интерфейс JPype и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/) с помощью [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Встраивание шрифтов**

Если в целевой среде шрифты презентации могут быть не установлены, внедрите их в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embedallfontshtmlcontroller/). Встраивание повышает визуальную точность, но увеличивает размер вывода.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Исключайте шрифты только тогда, когда уверены, что целевые браузеры или системы уже их предоставляют. Для фирменных или менее распространённых шрифтов встраивание обычно безопаснее.

## **Сохранить ресурсы внешне**

Автономный HTML легко перемещать, но встроенные Base64‑ресурсы могут сделать файл объёмным. Если вашему приложению нужны внешние файлы изображений, реализуйте контроллер связывания ресурсов через прокси‑интерфейс JPype и передайте его в конструктор [HtmlOptions].

При внешнем размещении ресурсов выбирайте два пути сознательно:

- Путь вывода в файловой системе, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

## **Экспорт медиа‑файлов**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoplayerhtmlcontroller/) экспортирует видео‑ и аудио‑файлы и пишет HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в который будут записаны сгенерированные медиа‑файлы.
- `fileName`: имя генерируемого HTML‑файла.
- `baseUri`: абсолютный префикс URI, используемый в HTML‑ссылках на медиа‑файлы.

В следующем примере экспортируются медиа, уже встроенные в `presentation.pptx`. Сгенерированный HTML ссылается на медиа‑файлы только по имени файла, относительно HTML‑документа, поэтому `path` должен быть тем же каталогом, куда записывается HTML‑файл. `baseUri` должен быть абсолютным URI: для локального предварительного просмотра сформируйте URI `file:///` из каталога вывода; для развернутого приложения используйте абсолютный URL опубликованного каталога.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Используйте каталоги вывода, уникальные для каждой задачи экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конвертация в HTML — операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI, передаваемые в [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression), встраивание шрифтов, вывод SVG и сохранение обрезанных областей могут улучшить точность, но обычно увеличивают размер вывода.

Для пакетного преобразования:

- Своевременно уничтожайте каждый объект [Presentation].
- Используйте отдельные каталоги вывода для отдельных задач.
- Избегайте встраивания общих шрифтов, если только это не требуется для точности.
- Снижайте DPI изображений, когда HTML нужен для предварительного просмотра или эскизов.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не будут окончательно определены пути развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Можно ли конвертировать презентации в HTML параллельно?**

Да, но не делитесь одним объектом [Presentation] между потоками. Обрабатывайте разные файлы отдельными экземплярами презентаций, отдельными потоками ввода/вывода и отдельными каталогами вывода. См. руководство по [multithreading guidance](/slides/ru/python-java/multithreading/) для деталей.

**Является ли объект презентации потокобезопасным?**

Нет. Один объект [Presentation] должен загружаться, модифицироваться, сохраняться и уничтожаться в одном потоке. Для параллельной работы создавайте отдельный экземпляр на каждый поток или процесс.

**Почему сгенерированный HTML‑файл большой?**

Экспорт по умолчанию может встраивать ресурсы непосредственно в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте общие шрифты из встраивания и передайте более низкое значение DPI в [HtmlOptions.setPicturesCompression], когда важнее небольшие размеры вывода, чем максимальная точность.

**Почему значения font-size в HTML могут отличаться от значений в PowerPoint?**

Экспортированная страница может использовать системы координат SVG и трансформации масштабирования. Одно лишь значение CSS или SVG font-size не описывает конечный отображаемый размер. Сравните отрендеренный слайд при нужном уровне масштабирования и проверьте наличие шрифтов, если текст выглядит иначе.

**Как выбрать baseUri для экспорта медиа?**

Выберите `baseUri` с учётом точки зрения браузера и передайте его как абсолютный URI. Для локального предварительного просмотра можно сформировать его из каталога вывода: `output_directory.as_uri() + "/"`. Для развертывания используйте абсолютный URL опубликованного каталога. Путь файловой системы `path` и браузерный `baseUri` не обязаны быть одинаковой строкой, но они должны указывать на одно и то же место, которое является каталогом, содержащим сгенерированный HTML‑файл, поскольку ссылки на медиа записываются относительно него.

**Можно ли включать скрытые слайды?**

Да. Вызовите [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) с параметром `True`, когда скрытые слайды необходимо экспортировать.