---
title: Преобразование презентаций PowerPoint в HTML с помощью Python через Java
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/python-java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в HTML с помощью Python через Java. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Python via Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Основное преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и вызова [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) с [SaveFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/) когда необходимо управлять экспортируемым макетом, шрифтами, изображениями, примечаниями, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспортировать всю презентацию или выбранные слайды.
- Создавать HTML с фиксированным макетом, адаптивный или основанный на SVG.
- Включать заметки для выступающего и комментарии.
- Контролировать качество изображений и данные об обрезанных изображениях.
- Встраивать шрифты или сохранять файлы шрифтов отдельно.
- Выбирать, как внешние ресурсы и медиафайлы записываются и упоминаются.

По умолчанию экспорт HTML создает автономный HTML‑документ, где большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе учитывайте внешние ресурсы, более низкое DPI изображений и встраивание только тех шрифтов, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и сохраните её с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/python-java/aspose.slides/saveformat/#Html).

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

Каждый пример загружает `presentation.pptx` из текущего рабочего каталога. Установите Aspose.Slides for Python via Java и совместимую Java‑runtime перед запуском. JVM запускается один раз на процесс Python.

Этот пример записывает один HTML‑файл. Объект презентации освобождается в блоке `finally`, что закрывает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Настроить экспорт HTML**

[HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/) – основной класс конфигурации для экспорта HTML. Распространённые настройки включают:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): добавляет заметки, комментарии, раздаточные материалы или другую макетную информацию.
- [setHtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setHtmlFormatter): изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- [setSlideImageFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlideImageFormat): изменяет способ представления слайдов, например как SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression): управляет DPI изображений и размером вывода.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): сохраняет или удаляет данные об обрезанных областях изображений.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): делает экспортированный SVG‑контент адаптивным к контейнеру.
- [setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): включает скрытые слайды при необходимости.

Следующие разделы показывают самые часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Преобразовать выбранные слайды в HTML**

Перегрузка [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save), принимающая номера слайдов, использует 1‑based позицию слайдов. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

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

Используйте этот шаблон, когда веб‑сайт или приложение требуют одну HTML‑страницу на слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/) и передайте его каждому вызову [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save).

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/responsivehtmlcontroller/) предоставляет адаптивный HTML‑вывод через [HtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше подстраиваться под ширину браузера.

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

Для адаптивного макета на основе SVG вызовите [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) с `True`. Это полезно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

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

## **Включить заметки выступающего и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) через [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions), чтобы включить заметки выступающего или комментарии. Заметки и комментарии скрыты по умолчанию, если только вы не укажете их позиции.

Предположим, исходная презентация содержит заметки выступающего:

![Слайд с заметками выступающего в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками выступающего под слайдом.

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

![HTML‑вывод со слайдом и заметками выступающего](HTML_with_notes.png)

Чтобы экспортировать комментарии, вызовите [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), например с [CommentsPositions.Right](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentspositions/#Right) или [CommentsPositions.Bottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/commentspositions/#Bottom). Если нужны только комментарии, опустите [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Если нужны и заметки, и комментарии, вызовите оба метода.

## **Контролировать качество изображений и обрезанные области**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Передайте значение в [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression) из [PicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturescompression/) когда требуется более высокое качество изображений.

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

По умолчанию обрезанные области изображений могут быть удалены из экспортированного вывода. Сохраняйте обрезанные данные только когда пользователи должны иметь возможность восстановить или просмотреть эти скрытые части изображения. Сохранение увеличивает размер HTML.

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

Для простого стилизования передайте строку CSS в [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Это изменит окружающий HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайда.

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

Для пользовательского заголовка документа, подключённого CSS‑файла или пользовательской разметки вокруг слайдов и фигур используйте пользовательский контроллер форматирования через прокси JPype‑интерфейса и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/) с помощью [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Встроить шрифты**

Если в целевой среде шрифты презентации могут быть не установлены, встраивайте шрифты в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/embedallfontshtmlcontroller/). Встраивание улучшает визуальную точность, но увеличивает размер вывода.

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

Исключайте шрифты только когда уверены, что целевые браузеры или системы уже их предоставляют. Для фирменных или редких шрифтов встраивание обычно надёжнее.

## **Сохранять ресурсы внешне**

Самодостаточный HTML легко перемещать, но встроенные ресурсы в формате Base64 могут сделать файл большим. Если вашему приложению нужны внешние файлы изображений, реализуйте контроллер связывания ресурсов через прокси JPype‑интерфейса и передайте его в конструктор [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/).

При внешнем хранении ресурсов выбирайте два пути сознательно:

- Путь вывода в файловой системе, куда приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

## **Экспорт медиа‑файлов**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoplayerhtmlcontroller/) экспортирует видео и аудио файлы и записывает HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в который будут записаны сгенерированные медиа‑файлы.
- `fileName`: имя генерируемого HTML‑файла.
- `baseUri`: абсолютный префикс URI, используемый в HTML‑ссылках на медиа‑файлы.

Следующий пример экспортирует медиа, уже встроенные в `presentation.pptx`. Сгенерированный HTML ссылается на медиа‑файлы только по имени файла, относительно HTML‑документа, поэтому `path` должен быть тем же каталогом, где сохраняется HTML‑файл. `baseUri` должен быть абсолютным URI: для локального просмотра сформируйте `file:///` URI из каталога вывода; для развернутого приложения используйте абсолютный URL опубликованного каталога.

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

Используйте каталоги вывода, уникальные для каждого задания экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конверсия в HTML – операция рендеринга, поэтому время обработки и потребление памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI, переданные в [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression), встраивание шрифтов, вывод SVG и сохранение обрезанных областей изображений повышают точность, но обычно увеличивают размер вывода.

Для пакетного конвертирования:

- Быстро освобождайте каждый объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для разных заданий.
- Не встраивайте общие шрифты, если только это не требуется для точности.
- Уменьшайте DPI изображений, когда HTML нужен только для предпросмотра или эскизов.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не будут окончательны пути развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Можно ли конвертировать презентации в HTML параллельно?**

Да, но не делите один объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) между потоками. Обрабатывайте разные файлы отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода. См. руководство по [multithreading](/slides/ru/python-java/multithreading/) для деталей.

**Является ли объект презентации потокобезопасным?**

Нет. Один объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте независимый экземпляр на каждый поток или процесс.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы напрямую в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑содержимое и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте общие шрифты из встраивания и передайте более низкое значение DPI в [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setPicturesCompression), когда важнее небольшой размер, чем максимальная точность.

**Почему значения font-size в HTML отличаются от значений в PowerPoint?**

Экспортируемая страница может использовать системы координат SVG и трансформации масштабирования. Одиночное значение CSS или SVG font-size не описывает окончательный отображаемый размер. Сравните отрисованный слайд при предполагаемом масштабе и проверьте наличие шрифтов, если текст выглядит иначе.

**Как выбрать baseUri для экспорта медиа?**

Выбирайте `baseUri` с точки зрения браузера и передавайте его как абсолютный URI. Для локального просмотра можно получить его из каталога вывода, используя `output_directory.as_uri() + "/"`. Для развертывания используйте абсолютный URL опубликованного каталога. Файловая система `path` и браузерный `baseUri` не обязаны быть одинаковой строкой, но должны указывать на одно и то же место, которое должно быть каталогом, содержащим сгенерированный HTML‑файл, потому что ссылки на медиа записываются относительно него.

**Можно ли включать скрытые слайды?**

Да. Вызовите [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) с `True`, когда необходимо экспортировать скрытые слайды.