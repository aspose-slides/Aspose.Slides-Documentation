---
title: Управление мастерами слайдов презентации в Python через Java
linktitle: Мастер слайда
type: docs
weight: 70
url: /ru/python-java/slide-master/
keywords:
- мастер слайда
- мастер слайда
- мастер слайда PPT
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
- Java
- Aspose.Slides
description: "Управляйте мастерами слайдов в Aspose.Slides для Python через Java: получайте доступ, редактируйте, клонируйте, сравнивайте и удаляйте мастера слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Мастер‑слайда** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фон, стили текста, параметры темы и параметры колонтитулов. В PowerPoint редактирование мастера‑слайда обычно используется для поддержания согласованности презентации без необходимости повторять одинаковое форматирование на каждом слайде.

Aspose.Slides for Python via Java поддерживает ту же модель. Презентация может содержать один или несколько мастеров‑слайдов, и каждый мастер‑слайд может содержать несколько шаблонных слайдов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует шаблонный слайд, а этот шаблонный слайд принадлежит мастеру‑слайду.

Иерархия выглядит так:

1. **Мастер‑слайд** – определяет общий дизайн и тему.  
1. **Шаблонный слайд** – определяет конкретное расположение заполнителей и форматирование уровня шаблона.  
1. **Обычный слайд** – содержит фактическое содержимое презентации и использует один шаблонный слайд.

![Иерархия мастеров‑слайдов, шаблонных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides мастер‑слайд представлен классом [MasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/). Все мастера‑слайды в презентации доступны через коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasters), которая представлена классом [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, более специфичный уровень берёт верх. Например, если мастер‑слайд и шаблонный слайд оба задают фон, слайды, основанные на этом шаблоне, используют фон шаблона. Подробнее о шаблонных слайдах см. в статье [Apply or Change Slide Layouts](/slides/ru/python-java/slide-layout/).
{{% /alert %}}

## **Доступ к мастерам слайдов**

В PowerPoint вы можете открыть представление Мастера‑слайда через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию [Presentation.getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasters) для доступа к мастерам‑слайдов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Вы также можете получить мастер‑слайд, используемый обычным слайдом, через его шаблон:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Что содержит мастер‑слайд**

Мастер‑слайд – это объект, похожий на слайд. Он наследуется от [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/), поэтому предоставляет многие из тех же свойств, что и обычные и шаблонные слайды. Специфические для мастера члены перечислены на странице API [MasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/).

Часто используемые члены мастера‑слайда включают:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getBackground) | Задает фон уровня мастера. |
| [getShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getShapes) | Содержит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| [getLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getLayoutSlides) | Хранит шаблонные слайды, принадлежащие мастеру. |
| [getThemeManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getThemeManager) | Предоставляет доступ к API темы мастера. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Управляет колонтитулами, датами и номерами слайдов для мастера и его дочерних шаблонов. |
| [getDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getDependingSlides) | Возвращает обычные слайды, зависящие от мастера через их шаблоны. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих шаблоны из этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип к первому мастеру‑слайду:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Подробнее о рамках изображений см. в статье [Picture Frame](/slides/ru/python-java/picture-frame/).

## **Управление видимостью графики мастера**

Используйте [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#setShowMasterShapes), чтобы скрыть унаследованную графику мастера, такую как логотипы или декоративные фигуры, без их удаления из мастера. Передайте `False` в [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setShowMasterShapes) на слайде, где нужно скрыть графику, и оставьте `True` на слайдах, где её следует показать.

Следующий автономный пример создаёт синюю декоративную полосу на мастере и два слайда, использующие один и тот же пустой шаблон. Полоса видна на первом слайде и скрыта на втором. Входные презентация и изображение не требуются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Пример использует шаблон **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнители начального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой мастер через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getLayoutSlide) и [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getMasterSlide). Установка свойства на отдельном слайде влияет только на этот слайд. Передача `False` в [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#setShowMasterShapes) скрывает графику мастера для всех слайдов, использующих данный общий шаблон, даже если их собственная настройка `True`. Чтобы скрыть графику только на одном слайде, измените свойство слайда и оставьте общий шаблон неизменным.

Настройка не поддерживается как контроль видимости непосредственно на мастере‑слайде. На мастере [getShowMasterShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getShowMasterShapes) всегда возвращает `False`, а передача `True` в [setShowMasterShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#setShowMasterShapes) вызывает исключение. Применяйте её к обычному слайду или к шаблону.

### **Отличие графики от фона**

| Operation | Effect |
| --- | --- |
| Hide master graphics | Управляет видимостью унаследованных фигур мастера без их удаления или изменения собственных фигур слайда. |
| Change the slide background fill | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные фигуры, которые могут оставаться видимыми поверх этого фона. См. [Presentation Background](/slides/ru/python-java/presentation-background/). |
| Delete a shape from the master | Удаляет общую исходную фигуру, поэтому она больше недоступна ни одному слайду, использующему этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на шаблонных слайдах. Мастер‑слайд обеспечивает общий стиль и тему, которые наследуют эти шаблоны, а каждый шаблон решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Мастера‑слайда.

![Команда Insert Placeholder в представлении Мастера‑слайда PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с шаблонным слайдом, принадлежащим мастеру:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Вы также можете форматировать уже существующие фигуры‑заполнители на мастере‑слайде. Следующий пример находит заполнитель заголовка и применяет линейный градиент заливки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для дополнительных вариантов форматирования заполнителей и текста см. [Set Prompt Text in Placeholder](/slides/ru/python-java/manage-placeholder/) и [Text Formatting](/slides/ru/python-java/text-formatting/).

## **Изменение фона мастера‑слайда**

Фон мастера наследуется шаблонами и слайдами, которые его не переопределяют. Следующий пример задает сплошной цвет фона для первого мастера‑слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

См. также темы [Presentation Background](/slides/ru/python-java/presentation-background/) и [Presentation Theme](/slides/ru/python-java/presentation-theme/).

## **Клонирование мастера‑слайда в другую презентацию**

Используйте [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/#addClone), чтобы скопировать мастер‑слайд в другую презентацию. Скопированный мастер затем может использоваться шаблонами и слайдами в целевой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Если нужно клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/python-java/clone-slides/).

## **Добавление нескольких мастеров‑слайдов**

Презентация может содержать несколько мастеров‑слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления мастерами‑слайдов](slide-master_9.jpg)

Следующий пример клонирует мастер‑по‑умолчанию, задаёт клону иной фон, создаёт шаблон под этим клоном и добавляет новый слайд на основе этого шаблона:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Сравнение мастеров‑слайдов**

Мастера‑слайды можно сравнивать с помощью метода [equals](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#equals), унаследованного от [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/). Сравнение проверяет структуру и статическое содержимое, такие как фигуры, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Подробнее см. в статье [Compare Presentation Slides](/slides/ru/python-java/compare-slides/).

## **Установка представления мастера‑слайда как представления по умолчанию**

Используйте метод [setLastView](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/#setLastView) у класса [ViewProperties](https://reference.aspose.com/slides/ru/python-java/aspose.slides/viewproperties/) для управления тем представлением, которое PowerPoint открывает первым. Следующий пример открывает презентацию в режиме Мастера‑слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для дополнительных настроек представления см. [Save Presentation](/slides/ru/python-java/save-presentation/).

## **Удаление неиспользуемых мастеров‑слайдов**

Иногда в презентациях остаются мастера‑слайды, которые больше не используются обычными слайдами. Удаление неиспользуемых мастеров может снизить размер файла и упростить обслуживание шаблонов.

Используйте [removeUnused](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/#removeUnused) для удаления неиспользуемых мастеров из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Также можно воспользоваться методом low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**В чём разница между мастером‑слайда и шаблонным слайдом?**

Мастер‑слайд задаёт общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Шаблонный слайд принадлежит мастеру‑слайду и определяет конкретное расположение заполнителей. Обычный слайд использует шаблонный слайд, поэтому наследует параметры как от шаблона, так и от мастера.

**Может ли одна презентация содержать несколько мастеров‑слайдов?**

Да. Презентация может содержать несколько мастеров‑слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендирования.

**Стоит ли добавлять заполнители в мастер‑слайд или в шаблонный слайд?**

В большинстве случаев заполнители добавляют в шаблонные слайды. На мастер‑слайд помещают общие визуальные элементы и общие параметры форматирования, а заполнители контента – в шаблоны, которые будут использовать обычные слайды.

**Можно ли удалить мастер‑слайд, который всё ещё используется?**

Нет. Мастер‑слайд, от которого зависят другие слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды к шаблонам другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастеры, которые не задействованы.