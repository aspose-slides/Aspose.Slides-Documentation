---
title: Групповые фигуры презентаций в Python через Java
linktitle: Группа фигур
type: docs
weight: 40
url: /ru/python-java/group/
keywords:
- групповая фигура
- группа фигур
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать фигуры в презентациях PowerPoint с помощью Aspose.Slides для Python через Java — пошаговое руководство с бесплатным кодом на Python."
---
## **Обзор**

В этой статье объясняется, как работать с групповыми фигурами в Aspose.Slides. Показано, как добавить групповую фигуру на слайд, разместить внутри неё другие фигуры и сохранить обновлённую презентацию. Также демонстрируется, как получить доступ к фигурам, хранящимся внутри группы, и прочитать их альтернативный текст с помощью [getAlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText). Кроме того, статья кратко охватывает связанные возможности групповых фигур, такие как вложенные группы, порядок Z и параметры блокировки.

## **Добавить групповую фигуру**

Aspose.Slides поддерживает работу с групповыми фигурами на слайдах. Эта возможность помогает разработчикам создавать более насыщенные презентации. Aspose.Slides for Python via Java поддерживает добавление и доступ к групповым фигурам. Вы можете заполнить групповую фигуру другими фигурами или получить доступ к её свойствам. Чтобы добавить групповую фигуру на слайд с помощью Aspose.Slides for Python via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте групповую фигуру на слайд.
1. Добавьте фигуры в групповую фигуру.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён пример, который добавляет групповую фигуру на слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Получить коллекцию фигур слайда.
    slide_shapes = slide.getShapes()

    # Добавить групповую фигуру на слайд.
    group_shape = slide_shapes.addGroupShape()

    # Добавить фигуры внутри групповой фигуры.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Установить кадр (frame) групповой фигуры.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Записать файл PPTX на диск.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к альтернативному тексту**

В этом разделе показано, как получить доступ к альтернативному тексту фигур внутри группы на слайде. Чтобы получить этот текст с помощью Aspose.Slides for Python via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), представляющего файл PPTX.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к коллекции фигур слайда.
1. Получите доступ к групповой фигуре.
1. Прочитайте альтернативный текст её фигур с помощью [getAlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText).

Ниже приведён пример, который получает альтернативный текст фигур внутри группы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Создать экземпляр класса Presentation, представляющего файл PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Получить доступ к фигуре в коллекции фигур слайда.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Получить доступ к фигурам внутри группы.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Прочитать альтернативный текст.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживается ли вложенная группировка (группа внутри группы)?**

Да. У [GroupShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/) есть метод [getParentGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getParentGroup), который указывает на поддержку иерархии: группа может быть дочерней по отношению к другой группе.

**Как контролировать порядок Z группы относительно других объектов на слайде?**

Используйте метод [getZOrderPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getZOrderPosition) объекта [GroupShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/), чтобы проверить его позицию в стеке отображения.

**Можно ли запретить перемещение, редактирование или разгруппировку?**

Да. Блокировки группы доступны через [getGroupShapeLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/#getGroupShapeLock), что позволяет ограничить операции с объектом.