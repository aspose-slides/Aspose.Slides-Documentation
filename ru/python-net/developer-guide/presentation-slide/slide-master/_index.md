---
title: Управление мастерами слайдов презентации в Python
linktitle: Мастер слайда
type: docs
weight: 80
url: /ru/python-net/slide-master/
keywords:
- мастер слайда
- мастер-слайд
- мастер-слайд PPT
- несколько мастеров слайдов
- сравнение мастеров слайдов
- фон
- заполнитель
- клонирование мастера слайда
- копирование мастера слайда
- дублирование мастера слайда
- неиспользуемый мастер слайда
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте мастерами слайдов в Aspose.Slides для Python через .NET: доступ, редактирование, клонирование, сравнение и удаление мастеров слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Мастер‑слайд** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, параметры темы и нижние колонтитулы. В PowerPoint редактирование мастера‑слайда — обычный способ поддерживать единообразие презентации без необходимости повторять одинаковое форматирование на каждом слайде.

Aspose.Slides for Python via .NET поддерживает ту же модель. Презентация может содержать один или несколько мастеров‑слайдов, и каждый мастер‑слайд может включать несколько макетных слайдов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует макетный слайд, который принадлежит мастеру‑слайду.

Иерархия выглядит так:

1. **Мастер‑слайд** — определяет общий дизайн и тему.  
1. **Макетный слайд** — определяет конкретную расстановку заполнителей и форматирование уровня макета.  
1. **Обычный слайд** — содержит фактическое содержание презентации и использует один макетный слайд.

![Иерархия мастеров‑слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides мастер‑слайд представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/) . Все мастера‑слайдов в презентации доступны через коллекцию `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, приоритет имеет более конкретный уровень. Например, если мастер‑слайд и макетный слайд оба задают фон, слайды, основанные на этом макете, используют фон макета. Подробнее о макетных слайдах см. в разделе [Apply or Change Slide Layouts](/slides/ru/python-net/slide-layout/).
{{% /alert %}}

## **Доступ к мастерам‑слайдов**

В PowerPoint вы можете открыть представление мастера‑слайда через **View** > **Slide Master**.

![Команда Мастер слайдов на вкладке Вид в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `masters`, чтобы получить доступ к мастерам‑слайдам:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Вы также можете получить мастер‑слайд, используемый обычным слайдом, через его макет:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Что содержит мастер‑слайд**

Мастер‑слайд — это объект, похожий на слайд. Он наследует общие свойства слайда от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/), поэтому предоставляет многие те же свойства слайда, используемые обычными и макетными слайдами. Специфические для мастера члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/).

Часто используемые члены мастера‑слайда включают:

| Член | Назначение |
| --- | --- |
| `background` | Задает фон уровня мастера‑слайда. |
| `shapes` | Хранит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `layout_slides` | Содержит макетные слайды, принадлежащие мастеру. |
| `theme_manager` | Предоставляет доступ к API темы мастера. |
| `header_footer_manager` | Управляет верхними и нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `get_depending_slides` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих макеты этого мастера. Это полезно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Для получения дополнительной информации о рамках изображений см. [Picture Frame](/slides/ru/python-net/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Мастер‑слайд обеспечивает общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они размещены.

В PowerPoint команды заполнителей доступны в представлении мастера‑слайда.

![Команда Вставить заполнитель в представлении мастера‑слайда PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с Aspose.Slides, работайте с макетным слайдом, принадлежащим мастеру:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Вы также можете изменить форматирование фигур‑заполнителей, уже существующих на мастере‑слайде. В следующем примере находится заполнитель заголовка и применяется линейный градиентный залив:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Отформатированный заполнитель заголовка, наследуемый обычными слайдами](slide-master_8.png)

Для получения дополнительных вариантов форматирования заполнителей и текста см. [Set Prompt Text in Placeholder](/slides/ru/python-net/manage-placeholder/) и [Text Formatting](/slides/ru/python-net/text-formatting/).

## **Изменение фона мастера‑слайда**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. В следующем примере задаётся сплошной цвет фона для первого мастера‑слайда:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

По смежным темам см. [Presentation Background](/slides/ru/python-net/presentation-background/) и [Presentation Theme](/slides/ru/python-net/presentation-theme/).

## **Клонирование мастера‑слайда в другую презентацию**

Используйте метод `add_clone` класса [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/), чтобы скопировать мастер‑слайд в другую презентацию. Скопированный мастер затем может быть использован макетами и слайдами в целевой презентации.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/python-net/clone-slides/).

## **Добавление нескольких мастеров‑слайдов**

Презентация может содержать несколько мастеров‑слайдов. Это полезно, когда разные разделы требуют различного фирменного стиля, структуры страниц или параметров темы.

![Команды PowerPoint для вставки и управления мастерами‑слайдов](slide-master_9.jpg)

В следующем примере происходит клонирование стандартного мастера, задаётся другой фон клону, извлекается пустой макет под этим клонированным мастером и добавляется новый слайд на основе этого макета:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Сравнение мастеров‑слайдов**

Мастера‑слайды можно сравнивать с помощью метода `equals`, унаследованного от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Для получения дополнительной информации см. [Compare Presentation Slides](/slides/ru/python-net/compare-slides/).

## **Установка представления мастера‑слайдов как представления по умолчанию**

Используйте свойство `last_view` объекта презентации [ViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/), чтобы задать представление, которое PowerPoint открывает первым. В следующем примере презентация открывается в представлении мастера‑слайдов:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Для получения дополнительных параметров представления см. [Save Presentation](/slides/ru/python-net/save-presentation/).

## **Удаление неиспользуемых мастеров‑слайдов**

Иногда презентации содержат мастеры‑слайды, которые больше не используются обычными слайдами. Удаление неиспользуемых мастеров может снизить размер файла и упростить обслуживание шаблона.

Используйте `remove_unused`, чтобы удалить неиспользуемые мастера из коллекции `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Вы также можете воспользоваться методом низкоуровневого кода `remove_unused_master_slides` класса [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### В чём разница между мастером‑слайдом и макетным слайдом?

Мастер‑слайд определяет общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит мастеру‑слайду и задаёт конкретную расстановку заполнителей. Обычный слайд использует макетный слайд, поэтому он наследует как параметры макета, так и параметры мастера.

### Может ли одна презентация содержать несколько мастеров‑слайдов?

Да. Презентация может содержать несколько мастеров‑слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или фирменного стиля.

### Следует ли добавлять заполнители в мастер‑слайд или в макетный слайд?

В большинстве случаев заполнители добавляются в макетные слайды. Общие визуальные элементы и общие параметры форматирования помещайте на мастер‑слайд, а заполнители контента — в макеты, которые будут использовать обычные слайды.

### Можно ли удалить мастер‑слайд, который всё ещё используется?

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастера, которые не задействованы.