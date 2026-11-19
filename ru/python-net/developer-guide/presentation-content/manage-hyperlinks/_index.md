---
title: "Управление гиперссылками презентации в Python"
linktitle: "Управление гиперссылками"
type: docs
weight: 20
url: /ru/python-net/manage-hyperlinks/
keywords:
- "добавить URL"
- "добавить гиперссылку"
- "создать гиперссылку"
- "форматировать гиперссылку"
- "удалить гиперссылку"
- "обновить гиперссылку"
- "текстовая гиперссылка"
- "гиперссылка на слайд"
- "гиперссылка на фигуру"
- "гиперссылка на изображение"
- "гиперссылка на видео"
- "изменяемая гиперссылка"
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, форматируйте, обновляйте и удаляйте гиперссылки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, используя примеры на Python."
---
## **Введение**

Гиперссылка соединяет содержимое презентации с веб‑сайтом или местом внутри презентации. В PowerPoint гиперссылки обычно используются в двух целях:

* Открыть веб‑сайт из текста, фигуры или медиа‑кадра.
* Перейти к другому слайду, например, из оглавления.

Aspose.Slides for Python via .NET позволяет добавлять такие ссылки, управлять их внешним видом и звуком, обновлять свойства и удалять их. Примеры ниже показывают, как работать с гиперссылками на отдельных элементах и как получать доступ к гиперссылкам на уровне презентации, слайда или текстового кадра.

{{% alert color="info" title="Note" %}}

Вы также можете редактировать презентации с помощью [бесплатного онлайн‑редактора Aspose PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **Добавление URL‑гиперссылок**

Вы можете назначить URL‑адрес веб‑сайта тексту, фигуре или медиа‑кадру. Элемент, к которому присваивается гиперссылка, определяет область, по которой можно кликнуть: часть текста связывает выбранный текст, тогда как фигура или кадр связывают объект слайда.

Для презентаций, содержащих относительные гиперссылки, см. [Manage the Hyperlink Base](/slides/ru/python-net/presentation-properties/#manage-the-hyperlink-base), чтобы прочитать, изменить или очистить базовый путь уровня документа.

### **Добавление URL‑гиперссылок к тексту**

Чтобы связать текст с веб‑сайтом, назначьте [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) свойству [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) части текста, как показано ниже. Кликабельной становится только эта часть текста.

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

### **Добавление URL‑гиперссылок к фигурам и медиа‑кадрам**

Назначьте URL‑адрес свойству [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) прямоугольника, чтобы сделать всю его площадь кликабельной. Атрибут [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) показывает читателям подсказку о назначении при наведении курсора на прямоугольник. Те же свойства применимы к кадрам изображения, аудио и видео.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Использование гиперссылок для создания оглавления**

Внутренние гиперссылки позволяют читателям переходить из оглавления к определённому слайду. В следующем примере используется [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) для ссылки текста «Page 2» на первом слайде ко второму слайду.

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

## **Форматирование гиперссылок**

Вы можете изменить цвет связанного текста, воспроизвести или остановить звук при активации ссылки и задать всплывающую подсказку, отображаемую при наведении.

### **Цвет**

Свойство [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) у [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) определяет, использует ли гиперссылка цвет гиперссылки презентации или форматирование части текста. Чтобы применить пользовательский цвет текста, выберите [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) и задайте цвет заливки части. Эта возможность была внедрена в PowerPoint 2019; более старые версии эту настройку не поддерживают.

В этом примере установка [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) на первой ссылке делает её текст красным. Вторая ссылка сохраняет цвет гиперссылки презентации.

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

Гиперссылка может воспроизводить звук при активации или остановить уже играющий звук. Используйте следующие свойства для настройки этих поведений:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) указывает аудио, связанное с гиперссылкой.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) управляет тем, будет ли активация гиперссылки останавливать предыдущий звук.

#### **Добавление звука к гиперссылке**

Кнопка на первом слайде использует [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) для воспроизведения аудио из WAV‑файла при клике читателя. На втором слайде отдельная кнопка использует [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) для остановки воспроизведения и удерживает читателя на этом слайде.

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

#### **Извлечение звука из гиперссылки**

В следующем примере открывается презентация, созданная выше, и читается звук гиперссылки первой фигуры в память через [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) и [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

### **Всплывающая подсказка и настройки взаимодействия**

После назначения гиперссылки тексту или фигуре вы можете обновить следующие свойства [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/):

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) задаёт текст, который пользователь видит как подсказку к ссылке.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) указывает целевой кадр внутри родительского HTML‑фреймсета, если применимо.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) определяет, добавляется ли назначение ссылки в список просмотренных гиперссылок.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) управляет тем, будет ли гиперссылка подсвечиваться при клике.

## **Удаление гиперссылок из презентаций**

Используйте [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) для получения контейнеров гиперссылок, включая ссылки частей текста, перед их изменением. В следующем примере удаляются оба типа активации с первого слайда. Чтобы удалить только один тип, вызовите только [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) или [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); удаление действия клика не удаляет его аналог при наведении.

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

Для безусловного удаления [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) удаляет оба типа активации в выбранном диапазоне одним вызовом. Для выборочной очистки и охвата мастеров, макетов и заметок см. [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Очистка гиперссылок перед заменой текста SmartArt**

При замене абзаца в существующей ноде SmartArt очистка её частей текста может оставить старую гиперссылку. Получите абзац через [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Перед очисткой его частей вызовите [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) через [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) на текстовом кадре фигуры ноды, отображающей абзац. Это удалит каждую гиперссылку в этом кадре, включая ссылки в других её абзацах.

В `SmartArtHyperlink.pptx` третья фигура на первом слайде представляет графику SmartArt. Пример заменяет первый абзац её четвёртой ноды. В этой презентации первая фигура ноды отображает этот абзац.

После добавления обеих частей пример читает их эффективное форматирование с помощью [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Эффективное свойство [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) возвращает новую гиперссылку для первой части и `None` для второй.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Создание полного инвентаря гиперссылок**

Перед распространением презентации составьте инвентарь её интерактивных действий и веб‑ссылок. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) возвращает объекты [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/), а не плоский список URL‑строк. Исследуйте как [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/), так и [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) в каждом контейнере. Они независимы: один контейнер может содержать оба действия, поэтому полный отчёт требует до двух строк на контейнер.

Сканирование только гиперссылок уровня фигуры может пропустить ссылки, прикреплённые к частям текста. Запрашивайте соответствующий диапазон и сохраняйте полученные контейнеры, чтобы позже обновлять или удалять их действия.

### **Запрос диапазонов презентации, слайда и текстового кадра**

Класс [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) доступен через [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) и [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Каждый диапазон поддерживает одинаковые запросы:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) возвращает контейнеры с действием клика.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) возвращает контейнеры с действием при наведении.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) возвращает контейнеры с любым из действий или с обоими.

В этом примере к фигуре и её тексту назначаются действия клика и наведения, а к отдельной кнопке — действие макроса. Сравниваются контейнеры, возвращённые [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/), с подсчётами для каждого типа активации. Запрос текстового кадра считает только ссылки в тексте. Действия самой фигуры отображаются в запросах слайда и презентации.

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

Для этого примера запросы презентации и слайда каждая возвращают три контейнера клика, два контейнера наведения и три контейнера с любым действием. Запрос текстового кадра показывает по одному контейнеру в каждой категории.

### **Классификация действий и назначений**

Используйте [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) для определения действия перед анализом его назначения. Значения [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) охватывают больше, чем веб‑навигацию:

| Значения | Значение для аудита |
| --- | --- |
| `HYPERLINK` | Внешняя гиперссылка; проверьте URL и его схему. |
| `JUMP_SPECIFIC_SLIDE` | Внутренняя навигация к конкретному слайду. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Встроенная навигация по показу, разрешается в контексте слайд‑шоу. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Завершить текущий показ или запустить пользовательский. |
| `START_MACRO` | Выполнить макрос. |
| `START_PROGRAM` | Запустить программу. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Открыть файл или другую презентацию; проверяйте отдельно от веб‑URL. |
| `START_STOP_MEDIA` | Запустить или остановить воспроизведение медиа. |
| `NO_ACTION`, `UNKNOWN` | Нет навигационного действия или действие не распознано и требует проверки. |

Чтите внешние назначения из [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) и конкретные внутренние назначения из [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Внутренние действия и встроенные команды могут не иметь внешнего URL; пустой URL не означает отсутствие действия. Сохраняйте [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/), если он отличается от нормализованного URL, и включайте [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/), когда он доступен.

### **Отчёт, очистка и проверка гиперссылок**

В этом примере открывается презентация из предыдущего примера и создаётся одна запись JSON на каждое действие. Для сбора контейнеров на обычных слайдах, мастерах, макетах и заметках, включая мастера заметок и раздаточных материалов, используется [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/). Каждый диапазон запрашивается один раз, чтобы избежать дублирования, применяется политика, описанная ниже, и затем сохраняется презентация для проверки как кликов, так и наведения.

В отчёте фиксируются индекс слайда (начиная с 1) и [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/), если он доступен. Коллектор сохраняет владеющий слайд и диапазон вместе с каждым полученным контейнером. Мастера, макеты и заметки не имеют обычного индекса слайда и идентифицируются по диапазону. Контейнеры фигур и контейнеры форматирования частей текста помечаются отдельно; остальные типы сохраняют своё имя типа во время выполнения. Каждый контейнер получает локальный идентификатор отчёта, чтобы его два действия можно было сопоставить.

Эта преднамеренно строгая политика приложения разрешает только абсолютные HTTPS‑URL и действительные внутренние цели слайдов. Она отклоняет макросы, программы, действия с файлами, другие действия слайд‑шоу, неизвестные действия и другие схемы URL. Эти отклонения — решения политики, а не оценка безопасности Aspose.Slides. Один лишь HTTPS не гарантирует доверие: добавьте списки разрешённых хостов и другие проверки для вашего приложения. Проверяются как оригинальные, так и нормализованные внешние URL. Пример аудитирует метаданные без перехода по ссылкам и без выполнения действий.

Для исправления контейнерный [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) поддерживает [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) и [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Здесь запрещённые внешние ссылки кликов заменяются фиксированной HTTPS‑страницей; другие запрещённые клики и запрещённые действия наведения удаляются независимо. Установите `replace_external_clicks` в `False`, чтобы удалить все нарушения политики. Выберите страницу‑заменитель, принадлежащую вашему приложению, перед развертыванием.

Флаг экспорта в отчёте использует консервативную политику проверки PDF: помечайте действия наведения и всё, что не является внешней ссылкой или переходом к конкретному слайду, как потенциально неподдерживаемое. Это подсказка для проверки, а не тест возможностей или гарантия того, что непомеченные ссылки сохранятся при экспорте. Поддерживаемый [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) экспорт может сохранять гиперссылки в зависимости от действия, параметров экспорта и просмотрщика. Растровые [images](/slides/ru/python-net/convert-powerpoint-to-png/) и [video](/slides/ru/python-net/convert-powerpoint-to-video/) не могут сохранять интерактивные гиперссылки; помечайте каждое действие при аудите для этих форматов.

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
    # Запросить каждый диапазон слайда один раз, сохраняя его владельца для каждого контейнера.
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

С учётом входных данных, созданных выше, отчёт содержит пять строк действий. Ссылка мыши и клик макроса удаляются, а HTTPS‑ссылки и внутренняя навигация остаются. При проверке выводится ноль запрещённых действий. Ввод с запрещённым внешним URL также демонстрирует ветку замены. Контейнер с разрешённым кликом и запрещённым наведением сохраняет действие клика.

Эта выборочная очистка отличается от [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), который удаляет оба типа активации во всём выбранном диапазоне независимо от политики. Проверка здесь проверяет только действия гиперссылок; она не удаляет встроенные VBA‑проекты, OLE‑объекты или другое активное содержимое и не проверяет экспортированный PDF или HTML файл.

## **FAQ**

**Как добавить ссылку на раздел или его первый слайд?**

Разделы в PowerPoint группируют слайды, но внутренняя гиперссылка указывает отдельный слайд. Чтобы создать навигацию к разделу, привяжите её к первому слайду в этом разделе.

**Можно ли привязать гиперссылку к элементам мастер‑слайда, чтобы она работала на всех слайдах?**

Да. Элементы мастер‑слайда и макета поддерживают гиперссылки. Ссылки на этих элементах доступны во время показа на слайдах, использующих соответствующий мастер или макет.

**Сохраняются ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

Поддерживаемый экспорт в PDF и HTML может сохранять гиперссылки; растровые изображения и видео — нет. См. соображения по экспорту в разделе [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).