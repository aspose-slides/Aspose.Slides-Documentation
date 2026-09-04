---
title: Групповая фигура
type: docs
weight: 170
url: /ru/python-java/examples/elements/group-shape/
keywords:
- пример кода
- групповая фигура
- добавить групповую фигуру
- получить групповую фигуру
- удалить групповую фигуру
- разгруппировать фигуры
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Управляйте групповыми фигурами в презентациях с помощью Aspose.Slides for Python via Java: добавляйте, получайте, удаляйте и разгруппируйте фигуры в файлах PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как создавать группы фигур, получать к ним доступ, удалять их и разгруппировать их содержимое с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после запуска JVM.

## **Добавить группу фигур**

Создайте группу, содержащую две базовые фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Получить группу фигур**

Получите первую группу фигур со слайда.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Удалить группу фигур**

Удалите группу фигур со слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Разгруппировать фигуры**

Переместите фигуру из контейнера группы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Переместить фигуру из группы.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```