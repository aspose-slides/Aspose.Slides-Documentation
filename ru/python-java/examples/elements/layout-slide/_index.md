---
title: Слайд макета
type: docs
weight: 20
url: /ru/python-java/examples/elements/layout-slide/
keywords:
- пример кода
- макет слайда
- добавить макет слайда
- доступ к макету слайда
- удалить макет слайда
- неиспользуемый макет слайда
- клонировать макет слайда
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте макетами слайдов с помощью Aspose.Slides for Python через Java: добавляйте, получайте доступ, удаляйте, очищайте и клонируйте макеты в презентациях PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как работать с **layout slides** с помощью Aspose.Slides для Python через Java. Layout slide определяет дизайн и форматирование, наследуемое обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять layout slides, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после того, как JVM запущена.

## **Добавить Layout Slide**

Создайте пользовательский layout slide, чтобы определить повторно используемое форматирование. В следующем примере добавляется текстовое поле к новому layout, а затем создаются два слайда, использующие его.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Создайте слайд макета с типом пустого макета и пользовательским именем.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Добавьте текстовое поле на слайд макета.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Добавьте два слайда, которые наследуют текст из макета.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Примечание 1:** Layout slides выступают в качестве шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и переиспользовать их во множестве слайдов.

> 💡 **Примечание 2:** Когда вы добавляете фигуры или текст в layout slide, все слайды, основанные на этом layout, автоматически отображают общие элементы.  
> Снимок экрана ниже показывает два слайда, которые наследуют текстовое поле из одного и того же layout slide.

![Слайды, наследующие содержимое Layout](layout-slide-result.png)

## **Доступ к Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Доступ к слайду макета по индексу.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Доступ к слайду макета по типу.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Удалить Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Удалить неиспользуемые Layout Slides**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Клонировать Layout Slide**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Итого:** Layout slides помогают поддерживать единообразное форматирование во всей презентации. Aspose.Slides позволяет создавать, управлять, переиспользовать и очищать layout по мере необходимости.