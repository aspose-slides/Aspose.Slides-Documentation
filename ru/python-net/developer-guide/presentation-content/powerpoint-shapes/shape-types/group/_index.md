---
title: Группировка фигур презентации с Python
linktitle: Группа фигур
type: docs
weight: 40
url: /ru/python-net/group/
keywords:
- групповая фигура
- группа фигур
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать фигуры в PowerPoint и OpenDocument decks с помощью Aspose.Slides for Python — быстрый пошаговый гид с бесплатным кодом."
---

## **Обзор**

Группировка фигур позволяет рассматривать несколько графических объектов как единый элемент, чтобы перемещать, изменять размер, форматировать и трансформировать их вместе. С помощью Aspose.Slides for Python вы можете создать [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), добавить и расположить дочерние фигуры внутри неё и сохранить результат в PPTX. В этой статье показано, как добавить групповую фигуру на слайд и как получить метаданные доступности, такие как Alt Text, из фигур внутри группы, обеспечивая более чистую структуру и более богатые, удобные для поддержки презентации.

## **Добавление групповых фигур**

Aspose.Slides поддерживает работу с групповыми фигурами на слайде. Эта возможность позволяет создавать более насыщенные презентации, рассматривая несколько фигур как один объект. Вы можете добавлять новые групповые фигуры, получать доступ к существующим, наполнять их дочерними фигурами и читать или изменять любые их свойства. Чтобы добавить групповую фигуру на слайд:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) на слайд.
4. Добавьте фигуры в новую групповую фигуру.
5. Сохраните изменённую презентацию в файл PPTX.

Пример ниже показывает, как добавить групповую фигуру на слайд.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к свойству Alt Text**

В этом разделе объясняется, как считать Alt Text фигур, содержащихся в групповой фигуре на слайде, с помощью Aspose.Slides. Чтобы получить Alt Text фигур:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для представления файла PPTX.
2. Получите ссылку на слайд по его индексу.
3. Доступ к коллекции фигур слайда.
4. Доступ к [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Считайте свойство Alt Text.

Пример ниже извлекает Alt Text фигур, содержащихся в групповых фигурах.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **Часто задаваемые вопросы**

**Поддерживается ли вложенная группировка (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) имеет свойство [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), которое явно указывает поддержку иерархии (группа может быть дочерним элементом другой группы).

**Как управлять порядком наложения группы относительно других объектов на слайде?**

Используйте свойство [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) класса [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) для просмотра или изменения её позиции в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), который позволяет ограничивать операции над объектом.