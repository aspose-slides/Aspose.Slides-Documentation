---
title: Управление мастер‑слайдами презентации в Python
linktitle: Мастер‑слайд
type: docs
weight: 80
url: /ru/python-net/slide-master/
keywords:
- мастер‑слайд
- мастер‑слайд
- мастер‑слайд PPT
- множество мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управление мастер‑слайдами в Aspose.Slides для Python через .NET: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Мастер‑слайд** определяет общие настройки дизайна для группы слайдов. Он может содержать общие формы, логотипы, фоны, стили текста, настройки темы и нижних колонтитулов. В PowerPoint редактирование мастер‑слайда — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Python via .NET поддерживает ту же модель. Презентация может содержать один или несколько мастер‑слайдов, а каждый мастер‑слайд может содержать несколько слайдов‑макетов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует слайд‑макет, который принадлежит мастер‑слайду.

Иерархия выглядит так:

1. **Мастер‑слайд** — определяет общий дизайн и тему.  
1. **Слайд‑макет** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** — содержит фактическое содержание презентации и использует один слайд‑макет.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

В Aspose.Slides мастер‑слайд представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/). Все мастер‑слайды в презентации доступны через коллекцию `Presentation.masters`.

{{% alert color="info" title="Наследование" %}}

Когда одно и то же свойство определено на разных уровнях, приоритет имеет более конкретный уровень. Например, если мастер‑слайд и слайд‑макет оба задают фон, слайды, основанные на этом макете, используют фон макета. Для получения дополнительной информации о слайдах‑макетах см. [Apply or Change Slide Layouts](/slides/ru/python-net/slide-layout/).

{{% /alert %}}

## **Доступ к мастер‑слайдам**

В PowerPoint вы можете открыть представление Мастер‑слайда через **Вид** > **Мастер‑слайд**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `masters` для доступа к мастер‑слайдам:

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

Мастер‑слайд — объект, похожий на слайд. Он наследует общие поведения слайда от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/), поэтому предоставляет многие те же свойства слайда, используемые обычными и макетными слайдами. Члены, специфичные для мастера, перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/).

Часто используемые члены мастер‑слайда:

| Member | Purpose |
| --- | --- |
| `background` | Задает фон слайда уровня мастера. |
| `shapes` | Хранит формы, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `layout_slides` | Хранит слайды‑макеты, принадлежащие мастеру. |
| `theme_manager` | Предоставляет доступ к API темы мастера. |
| `header_footer_manager` | Управляет заголовками, нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `get_depending_slides` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих макеты этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый мастер‑слайд:

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

## **Управление отображением графики мастера**

Используйте [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/show_master_shapes/) для скрытия унаследованной графики мастера, такой как логотипы или декоративные формы, без их удаления из мастера. Установите [Slide.show_master_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/show_master_shapes/) в `False` на слайде, где нужно скрыть эту графику, и оставьте `True` на слайдах, где её следует показывать.

Следующий автономный пример создаёт синюю декоративную полосу на мастере и два слайда, использующие один и тот же пустой макет. Полоса видна на первом слайде и скрыта на втором. Вводные презентация или изображение не требуются.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет исходные заполнители первого слайда.

### **Выбор области действия настройки**

Обычный слайд использует свой мастер через [Slide.layout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/layout_slide/) и [LayoutSlide.master_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/master_slide/). Установка свойства на отдельном слайде влияет только на него. Установка [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/show_master_shapes/) в `False` скрывает графику мастера для всех слайдов, использующих этот общий макет, даже если их собственная настройка — `True`. Чтобы скрыть графику только на одном слайде, измените свойство слайда и оставьте общий макет без изменений.

Эта настройка не поддерживается как управление видимостью самого мастер‑слайда. На мастере она всегда возвращает `False`, а попытка установить `True` вызывает исключение. Применяйте её к обычному слайду или к макету.

### **Отличие графики от фона**

| Operation | Effect |
| --- | --- |
| Hide master graphics | Управляет видимостью унаследованных форм мастера без их удаления или изменения собственных форм слайда. |
| Change the slide background fill | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные формы и может оставаться видимой над этим фоном. См. [Presentation Background](/slides/ru/python-net/presentation-background/). |
| Delete a shape from the master | Удаляет общую исходную форму, делая её недоступной для всех слайдов, использующих этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на слайдах‑макетах. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они размещены.

В PowerPoint команды заполнителей доступны в представлении Мастер‑слайда.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с слайдом‑макетом, принадлежащим мастеру:

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

Вы также можете форматировать уже существующие формы заполнителей на мастер‑слайде. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Для получения дополнительных параметров заполнителей и форматирования текста см. [Set Prompt Text in Placeholder](/slides/ru/python-net/manage-placeholder/) и [Text Formatting](/slides/ru/python-net/text-formatting/).

## **Изменение фона мастер‑слайда**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого мастер‑слайда:

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

Для связанных тем см. [Presentation Background](/slides/ru/python-net/presentation-background/) и [Presentation Theme](/slides/ru/python-net/presentation-theme/).

## **Клонирование мастер‑слайда в другую презентацию**

Используйте метод `add_clone` класса [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/) для копирования мастер‑слайда в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/python-net/clone-slides/).

## **Добавление нескольких мастер‑слайдов**

Презентация может содержать несколько мастер‑слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Следующий пример клонирует мастер‑слайд по умолчанию, задаёт клону другой фон, получает пустой макет под этим клонированным мастером и добавляет новый слайд на основе этого макета:

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

## **Сравнение мастер‑слайдов**

Мастер‑слайды можно сравнить с помощью метода `equals`, унаследованного от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как формы, текст, форматирование, анимацию и другие настройки слайда. Он не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

## **Установка представления Мастер‑слайда как представления по умолчанию**

Используйте свойство `last_view` объекта [ViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/) презентации для управления тем, в каком представении PowerPoint открывает файл в первую очередь. Следующий пример открывает презентацию в представлении Мастер‑слайда:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Для получения дополнительных настроек представления см. [Save Presentation](/slides/ru/python-net/save-presentation/).

## **Удаление неиспользуемых мастер‑слайдов**

Иногда презентации содержат мастер‑слайды, которые больше не используются обычными слайдами. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблонов.

Вызовите `remove_unused` для удаления неиспользуемых мастеров из коллекции `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Также можно воспользоваться методом низкоуровневого кода `remove_unused_master_slides` класса [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**В чём разница между мастер‑слайдом и слайдом‑макетом?**

Мастер‑слайд определяет общие настройки дизайна, такие как тема, фон, общие формы и стили текста. Слайд‑макет принадлежит мастер‑слайду и определяет конкретное расположение заполнителей. Обычный слайд использует слайд‑макет, поэтому наследует свойства как от макета, так и от мастера.

**Можно ли в одной презентации иметь несколько мастер‑слайдов?**

Да. Презентация может содержать несколько мастер‑слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в мастер‑слайд или в слайд‑макет?**

В большинстве случаев заполнители добавляют в слайды‑макеты. Общие визуальные элементы и общие форматы помещайте на мастер‑слайд, а заполнители содержимого — на макеты, которые будут использовать обычные слайды.

**Могу ли я удалить мастер‑слайд, который всё ещё используется?**

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды к макетам другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастеры, которые не задействованы.