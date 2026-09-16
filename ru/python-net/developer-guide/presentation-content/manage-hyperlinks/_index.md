---
title: Управление гиперссылками презентации в Python
linktitle: Управление гиперссылками
type: docs
weight: 20
url: /ru/python-net/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- текстовая гиперссылка
- гиперссылка на слайд
- гиперссылка на объект
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, используя примеры на Python."
---
## **Введение**

Гиперссылка связывает содержимое презентации с веб‑сайтом или расположением внутри презентации. В PowerPoint гиперссылки обычно служат для двух целей:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Python via .NET позволяет добавлять эти ссылки, управлять их внешним видом и звуком, обновлять их свойства и удалять их. Приведённые ниже примеры показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}
Вы также можете редактировать презентации с помощью [бесплатный онлайн‑редактор Aspose PowerPoint](https://products.aspose.app/slides/ru/editor).
{{% /alert %}}

## **Добавить URL‑гиперссылки**

Вы можете назначить URL веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому вы привязываете гиперссылка, определяет кликабельную область: часть текста связывает выбранный текст, а фигура или кадр связывают объект слайда.

### **Добавить URL‑гиперссылки к тексту**

Чтобы связать текст с веб‑сайтом, назначьте объект [Hyperlink](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/) свойству [hyperlink_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/hyperlink_click/) части текста, как показано ниже. Только эта часть текста станет кликабельной.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Добавить URL‑гиперссылки к фигурам и медиа‑кадрам**

Чтобы сделать фигуру или кадр кликабельным, задайте её свойство [hyperlink_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/hyperlink_click/). Гиперссылка принадлежит самому объекту, а не части текста внутри него.

Тот же подход применяется к кадрам изображения, аудио и видео: назначьте гиперссылку кадру и при необходимости задайте [tooltip](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/tooltip/) ссылки.

Следующий пример делает прямоугольник кликабельным:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Использовать гиперссылки для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к конкретному слайду. В следующем примере используется [set_internal_hyperlink_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) для привязки текста «Page 2» на первом слайде ко второму слайду.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Форматировать гиперссылки**

### **Цвет**

Свойство [color_source](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/color_source/) объекта [Hyperlink](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/) определяет, использует ли гиперссылка цвет гиперссылок презентации или форматирование части текста. Чтобы задать пользовательский цвет текста, выберите [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlinkcolorsource/) и задайте цвет заливки части. Эта функция была добавлена в PowerPoint 2019; более старые версии её не поддерживают.

В следующем примере добавляются две текстовые гиперссылки на один и тот же слайд. Первая использует красный цвет текста, в то время как вторая сохраняет цвет гиперссылки по умолчанию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Звук**

Гиперссылка может воспроизводить звук при активации или останавливать уже воспроизводимый звук. Для настройки этих поведений используйте следующие свойства:

- [Hyperlink.sound](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/sound/) указывает аудио, связанное с гиперссылкой.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/stop_sound_on_click/) управляет тем, останавливается ли при активации гиперссылка предыдущий звук.

#### **Добавить звук к гиперссылке**

В следующем примере загружается `sampleaudio.wav` и связывается с кнопкой на первом слайде. При нажатии кнопки воспроизводится звук и происходит переход к следующему слайду. Вторая фигура на этом слайде останавливает предыдущий звук при нажатии, не выполняя переход.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Извлечь звук из гиперссылки**

В следующем примере открывается созданная выше презентация и аудио гиперссылки первой фигуры читается в память с помощью [sound](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlink/sound/) и [binary_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Настройки подсказки и взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете обновить следующие свойства [Hyperlink]:

- [tooltip] задаёт текст, который пользователь может увидеть как подсказку к ссылке.
- [target_frame] указывает целевой фрейм внутри родительского HTML‑фреймсета, если применимо.
- [history] управляет тем, добавляется ли при активации ссылка в список просмотренных гиперссылок.
- [highlight_click] управляет тем, будет ли гиперссылка выделена при нажатии.

## **Удалить гиперссылки из презентаций**

Используйте [get_any_hyperlinks] для сбора контейнеров гиперссылок, включая ссылки на части текста, перед их изменением. В следующем примере удаляются оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите только [remove_hyperlink_click] или [remove_hyperlink_mouse_over]; удаление действия клика не удаляет соответствующее действие наведения мышью.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Для безусловного удаления [remove_all_hyperlinks] удаляет оба типа активации в выбранной области одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. раздел [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Создать полный реестр гиперссылок**

Перед распространением презентации выполните инвентаризацию её интерактивных действий и веб‑ссылок. [get_any_hyperlinks] возвращает объекты [IHyperlinkContainer], а не простой список URL‑строк. Проверьте как [hyperlink_click], так и [hyperlink_mouse_over] в каждом контейнере. Они независимы: один и тот же контейнер может содержать оба действия, поэтому полный отчёт может требовать до двух строк на контейнер.

Сканирование только гиперссылок уровня фигур может пропустить ссылки, привязанные к частям текста. Вместо этого выполните запрос в соответствующей области и сохраните возвращённые контейнеры, чтобы позже обновить или удалить их действия.

### **Запрос областей презентации, слайда и текстового кадра**

Класс [HyperlinkQueries] доступен через [Presentation.hyperlink_queries](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/hyperlink_queries/), и [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/hyperlink_queries/). Каждая область поддерживает одинаковые запросы:

- [get_hyperlink_clicks] возвращает контейнеры с действием клика.
- [get_hyperlink_mouse_overs] возвращает контейнеры с действием наведения мышью.
- [get_any_hyperlinks] возвращает контейнеры с одним или обоими действиями.

В следующем примере создаётся `hyperlink-audit-input.pptx` с внешней ссылкой клика, ссылкой наведения мышью на файл, внутренней навигацией по слайдам, ссылкой наведения мышью на текст и действием макроса. Он не выполняет ни одно из этих действий. Одни и те же три запроса работают во всех областях; количество относится к контейнерам, а не к сумме действий. Область текстового кадра исключает собственные ссылки охватывающей её фигуры.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Для этого примера запросы презентации и слайда возвращают три контейнера клика, два контейнера наведения мышью и три контейнера с любым из действий. Запрос текстового кадра возвращает по одному контейнеру в каждой категории.

### **Классификация действий и целей**

Используйте [Hyperlink.action_type] для определения типа действия перед определением его назначения. Значения [HyperlinkActionType] охватывают больше, чем веб‑навигацию:

| Значения | Смысл для аудита |
| --- | --- |
| `HYPERLINK` | Внешняя гиперссылка; проверьте URL и её схему. |
| `JUMP_SPECIFIC_SLIDE` | Внутренняя навигация к конкретному слайду. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Встроенная навигация в режиме показа, разрешается в контексте показа. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Завершить текущий показ или запустить пользовательский показ. |
| `START_MACRO` | Выполнить макрос. |
| `START_PROGRAM` | Запустить программу. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Открыть файл или другую презентацию; рассматривать отдельно от веб‑URL. |
| `START_STOP_MEDIA` | Запустить или остановить воспроизведение медиа. |
| `NO_ACTION`, `UNKNOWN` | Отсутствие навигационного действия или неизвестное действие, требующее проверки. |

Чтение внешних целей производится из [external_url] и конкретные внутренние цели — из [target_slide]. Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия у контейнера. Сохраняйте [external_url_original], когда он отличается от нормализованного URL, и включайте [tooltip], если он доступен.

### **Отчет, очистка и проверка гиперссылок**

В следующем примере на Python читается существующая презентация (используйте файл, созданный выше), записывается `hyperlink-audit.json`, применяется политика, сохраняется `hyperlink-sanitized.pptx` и снова открывается для повторной проверки обоих типов активации. Он собирает контейнеры перед их изменением и запрашивает каждую область слайда один раз, чтобы избежать двойной обработки. Запросы презентации охватывают обычные слайды; для инвентаризации всего пакета пример запрашивает обычные слайды, мастера, макеты, заметки и мастера заметок и раздаточных материалов, если они присутствуют.

Отчёт регистрирует индекс слайда, начинающийся с единицы, и [slide_id], где это возможно. Сборщик сохраняет владелец‑слайд и область вместе с каждым возвращённым контейнером. У мастеров, макетов и заметок нет обычного индекса слайда и они идентифицируются по своей области. Контейнеры фигур и контейнеры форматирования текстовых частей помечаются отдельно; остальные типы контейнеров сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный ID отчёта, чтобы его два действия можно было сопоставить.

Отчёт использует консервативную политику проверки экспорта в PDF: помечать действия наведения мышью и всё, что не является внешней ссылкой или переходом к определённому слайду, как потенциально неподдерживаемое. Это лишь подсказка для проверки, а не тест возможностей или гарантия, что непомеченные ссылки выживут при экспорте. Поддерживаемый экспорт в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) может сохранять гиперссылки в зависимости от действия, параметров экспорта и используемого просмотрщика. Растровые [images](/slides/ru/python-net/convert-powerpoint-to-png/) и [video](/slides/ru/python-net/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудитe для этих форматов вывода.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Запросить каждый слайд один раз, сохраняя его владельца для каждого контейнера.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

С созданным выше вводом отчёт содержит пять строк действий. Ссылка наведения мышью на файл и клик макроса удаляются, тогда как HTTPS‑ссылки и внутренняя навигация по слайдам сохраняются. Проверка выводит ноль запрещённых действий. Ввод, содержащий запрещённый внешний URL клика, также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым наведением мыши сохраняет действие клика.

Эта выборочная очистка отличается от [remove_all_hyperlinks], который удаляет оба типа активации во всей выбранной области независимо от политики. Проверка здесь рассматривает только действия гиперссылок; она не удаляет встроенные VBA‑проекты, OLE‑объекты или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **Часто задаваемые вопросы**

**Как создать ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка направлена на отдельный слайд. Чтобы создать навигацию к разделу, привяжите ссылку к первому слайду этого раздела.

**Могу ли я привязать гиперссылку к элементам слайда‑мастера, чтобы она работала на всех слайдах?**

Да. Элементы слайда‑мастера и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа слайдов на тех слайдах, которые используют соответствующий мастер или макет.

**Сохранятся ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. Смотрите сведения об экспорте в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).