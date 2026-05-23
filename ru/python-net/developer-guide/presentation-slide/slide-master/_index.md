---
title: Управление шаблонами слайдов презентации в Python
linktitle: Шаблон слайда
type: docs
weight: 80
url: /ru/python-net/slide-master/
keywords:
- шаблон слайда
- мастер‑слайд
- мастер‑слайд PPT
- несколько мастер‑слайдов
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
description: "Управляйте шаблонами слайдов в Aspose.Slides для Python через .NET: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Шаблон слайда** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, параметры темы и параметры нижних колонтитулов. В PowerPoint редактирование шаблона слайда — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for Python via .NET поддерживает ту же модель. Презентация может содержать один или несколько шаблонов слайдов, и каждый шаблон слайда может содержать несколько макетных слайдов. Обычные слайды обычно не ссылаются напрямую на шаблон слайда. Вместо этого обычный слайд использует макетный слайд, который принадлежит шаблону слайда.

Иерархия выглядит так:

1. **Шаблон слайда** — определяет общий дизайн и тему.  
1. **Макетный слайд** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** — содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия шаблонов слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides шаблон слайда представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/). Все шаблоны слайдов в презентации доступны через коллекцию `Presentation.masters`.

{{% alert color="info" title="Наследование" %}}

Когда одно и то же свойство определено на нескольких уровнях, более специфичный уровень имеет приоритет. Например, если шаблон слайда и макетный слайд оба задают фон, слайды, основанные на этом макете, используют фон макетного слайда. Более подробную информацию о макетных слайдах см. в статье [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **Доступ к шаблонам слайдов**

В PowerPoint вы можете открыть представление Шаблона слайда через **Вид** > **Шаблон слайда**.

![Кнопка Шаблон слайда на вкладке Вид в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `masters` для доступа к шаблонам слайдов:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Вы также можете получить шаблон слайда, используемый обычным слайдом, через его макет:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Что содержит шаблон слайда**

Шаблон слайда — объект, похожий на слайд. Он наследует общие свойства слайда от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/), поэтому предоставляет многие те же свойства, что и обычные и макетные слайды. Члены, специфичные для шаблона, перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/).

Часто используемые члены шаблона слайда:

| Член | Назначение |
| --- | --- |
| `background` | Устанавливает фон на уровне шаблона. |
| `shapes` | Содержит фигуры, размещённые в шаблоне, такие как логотипы, рамки изображений и общий текст. |
| `layout_slides` | Содержит макетные слайды, принадлежащие шаблону. |
| `theme_manager` | Предоставляет доступ к API темы шаблона. |
| `header_footer_manager` | Управляет верхними и нижними колонтитулами, датой и номерами слайдов для шаблона и его дочерних макетов. |
| `get_depending_slides` | Возвращает обычные слайды, зависящие от шаблона через их макеты. |

## **Добавление изображения в шаблон слайда**

Когда вы добавляете изображение в шаблон слайда, оно появляется на слайдах, использующих макеты из этого шаблона. Это полезно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Ниже приведён пример, который добавляет логотип на первый шаблон слайда:

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

Дополнительную информацию о кадрах изображений см. в статье [Picture Frame](/python-net/picture-frame/).

## **Работа с заполнителями**

Заполнители обычно определяются в макетных слайдах. Шаблон слайда обеспечивает общий стиль и тему, которые эти макеты наследуют, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Шаблон слайда.

![Команда Вставить заполнитель в представлении Шаблон слайда PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим шаблону:

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

Можно также форматировать фигуры заполнителей, уже существующие в шаблоне слайда. Ниже пример, который находит заполнитель заголовка и применяет линейную градиентную заливку:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для получения дополнительных вариантов форматирования заполнителей и текста см. статьи [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) и [Text Formatting](/python-net/text-formatting/).

## **Изменение фона шаблона слайда**

Фон шаблона наследуется макетами и слайдами, которые не переопределяют его. Ниже пример, который задаёт сплошной цвет фона для первого шаблона слайда:

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

См. также темы [Presentation Background](/python-net/presentation-background/) и [Presentation Theme](/python-net/presentation-theme/).

## **Клонирование шаблона слайда в другую презентацию**

Используйте метод `add_clone` класса [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/) для копирования шаблона слайда в другую презентацию. Скопированный шаблон затем может использоваться макетами и слайдами в целевой презентации.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Если необходимо клонировать обычные слайды вместе с их шаблоном, см. статью [Clone Slides](/python-net/clone-slides/).

## **Добавление нескольких шаблонов слайдов**

Презентация может содержать несколько шаблонов слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления шаблонами слайдов](slide-master_9.jpg)

Ниже пример, который клонирует шаблон по умолчанию, задаёт клону другой фон, получает пустой макет под этим клонированным шаблоном и добавляет новый слайд на основе этого макета:

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

## **Сравнение шаблонов слайдов**

Шаблоны слайдов можно сравнивать с помощью метода `equals`, унаследованного от класса [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

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

Подробности см. в статье [Compare Presentation Slides](/python-net/compare-slides/).

## **Установка представления Шаблон слайда как представления по умолчанию**

Используйте свойство `last_view` объекта [ViewProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/viewproperties/) презентации, чтобы задать представление, которое PowerPoint открывает первым. Ниже пример, открывающий презентацию в представлении Шаблон слайда:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Для дополнительных параметров представления см. статью [Save Presentation](/python-net/save-presentation/).

## **Удаление неиспользуемых шаблонов слайдов**

В презентациях иногда встречаются шаблоны слайдов, которые больше не используются ни одним обычным слайдом. Удаление неиспользуемых шаблонов может уменьшить размер файла и упростить поддержку шаблонов.

Вызовите `remove_unused` для удаления неиспользуемых шаблонов из коллекции `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Можно также воспользоваться методом низкоуровневого кода `remove_unused_master_slides` класса [Compress](https://reference.aspose.com/slides/ru/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**В чём разница между шаблоном слайда и макетным слайдом?**

Шаблон слайда определяет общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит шаблону и задаёт конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует как от макета, так и от шаблона.

**Может ли одна презентация содержать несколько шаблонов слайдов?**

Да. Презентация может содержать несколько шаблонов слайдов. Используйте несколько шаблонов, когда разные разделы требуют разных визуальных систем или брендинга.

**Куда следует добавлять заполнители: в шаблон слайда или в макетный слайд?**

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общее форматирование помещайте в шаблон слайда, а заполнители контента — в макеты, которые будут использовать обычные слайды.

**Можно ли удалить шаблон слайда, который всё ещё используется?**

Нет. Шаблон слайда, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты другого шаблона или используйте метод очистки неиспользуемых шаблонов, который удаляет только те шаблоны, которые действительно не задействованы.