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
description: "Узнайте, как группировать и разгруппировать фигуры в PowerPoint и пакетах OpenDocument с помощью Aspose.Slides для Python — быстрый пошаговый руководствo с бесплатным кодом."
---

## **Обзор**

Группировка фигур позволяет рассматривать несколько графических объектов как единое целое, чтобы перемещать, изменять размер, форматировать и трансформировать их совместно. С Aspose.Slides для Python вы можете создать [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), добавить и расположить дочерние фигуры внутри него и сохранить результат в PPTX. В этой статье показано, как добавить групповую фигуру на слайд и как получить доступ к метаданным доступности, таким как Alt Text, из фигур внутри группы, обеспечивая более чистую структуру и более богатые, более поддерживаемые презентации.

## **Добавление групповых фигур**

Aspose.Slides поддерживает работу с групповыми фигурами на слайде. Эта возможность позволяет создавать более богатые презентации, рассматривая несколько фигур как один объект. Вы можете добавлять новые групповые фигуры, получать доступ к существующим, заполнять их дочерними фигурами и читать или изменять любые их свойства. Чтобы добавить групповую фигуру на слайд:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) на слайд.
4. Добавьте фигуры в новую групповую фигуру.
5. Сохраните изменённую презентацию в файл PPTX.

Пример ниже показывает, как добавить групповую фигуру на слайд.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить групповую фигуру на слайд.
    group_shape = slide.shapes.add_group_shape()

    # Добавить фигуры внутри групповой фигуры.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Записать файл PPTX на диск.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Доступ к свойству Alt Text**

В этом разделе объясняется, как прочитать Alt Text фигур, содержащихся в групповой фигуре на слайде, используя Aspose.Slides. Чтобы получить доступ к Alt Text фигур:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , представляющего файл PPTX.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к коллекции фигур слайда.
4. Получите доступ к [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Считайте свойство Alt Text.

Пример ниже получает Alt Text фигур, содержащихся в групповых фигурах.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation для открытия файла PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Доступ к групповой фигуре.
            for child_shape in shape.shapes:
                # Доступ к свойству Alt Text.
                print(child_shape.alternative_text)
```


## **FAQ**

**Поддерживается ли вложенная группировка (группа внутри группы)?**

Да. У [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) есть свойство [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), которое напрямую указывает на поддержку иерархии (группа может быть дочерней для другой группы).

**Как управлять порядком z-слоя группы относительно других объектов на слайде?**

Используйте свойство [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) группы [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), чтобы просмотреть её положение в стеке отображения.

**Могу ли я запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), что позволяет ограничивать операции над объектом.