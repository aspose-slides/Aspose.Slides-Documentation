---
title: Группа
type: docs
weight: 40
url: /python-net/group/
keywords: "Группа фигур, Фигура PowerPoint, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление группы фигур в презентацию PowerPoint на Python"
---

## **Добавить Группу Фигур**
Aspose.Slides поддерживает работу с группами фигур на слайдах. Эта функция помогает разработчикам поддерживать более богатые презентации. Aspose.Slides для Python через .NET поддерживает добавление или доступ к группам фигур. Можно добавлять фигуры в добавленную группу фигур для ее заполнения или получать доступ к любому свойству группы фигур. Чтобы добавить группу фигур на слайд, используя Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте группу фигур на слайд.
1. Добавьте фигуры в добавленную группу фигур.
1. Сохраните измененную презентацию в формате PPTX.

В примере ниже добавляется группа фигур на слайд.

```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation
with slides.Presentation() as pres:
    # Получаем первый слайд
    sld = pres.slides[0]

    # Получение коллекции фигур слайдов
    slideShapes = sld.shapes

    # Добавление группы фигур на слайд
    groupShape = slideShapes.add_group_shape()

    # Добавление фигур внутри добавленной группы фигур
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Добавление рамки группы фигур
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # Запись файла PPTX на диск
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к Свойству AltText**
Эта тема показывает простые шаги, включая примеры кода, для добавления группы фигур и доступа к свойству AltText групп фигур на слайдах. Для доступа к AltText группы фигур на слайде, используя Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса `Presentation`, который представляет файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Получение коллекции фигур слайдов.
1. Доступ к группе фигур.
1. Доступ к свойству AltText.

В примере ниже осуществляется доступ к альтернативному тексту группы фигур.

```py
import aspose.slides as slides

# Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation(path + "AltText.pptx") as pres:

    # Получаем первый слайд
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # Получение коллекции фигур слайдов
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # Доступ к группе фигур.
            for j in range(len(shape.shapes)):
                # Доступ к свойству AltText
                print(shape.shapes[j].alternative_text)
```