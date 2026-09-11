---
title: Добавление эллипсов в презентации в Python через Java
linktitle: Эллипс
type: docs
weight: 30
url: /ru/python-java/ellipse/
keywords:
  - эллипс
  - форма
  - добавить эллипс
  - создать эллипс
  - нарисовать эллипс
  - отформатированный эллипс
  - PowerPoint
  - презентация
  - Python
  - Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять эллипсными фигурами в Aspose.Slides для Python через Java в презентациях PPT и PPTX — включены примеры кода на Python."
---
## **Обзор**

В этой статье показано, как добавить эллиптические фигуры на слайды PowerPoint с помощью Aspose.Slides. Описывается создание простого эллипса, создание отформатированного эллипса и сохранение обновлённой презентации в виде файла PPTX. Также рассматриваются связанные вопросы, такие как позиционирование и размер эллипса, управление порядком наложения и применение анимационных эффектов.

## **Создание эллипса**

Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите ссылку на слайд по его индексу.
- Добавьте эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).
- Запишите изменённую презентацию в файл PPTX.

Следующий пример добавляет эллипс на первый слайд:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получите первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавьте форму эллипса.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Запишите файл PPTX на диск.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создание отформатированного эллипса**

Чтобы добавить отформатированный эллипс на слайд, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите ссылку на слайд по его индексу.
- Добавьте эллипс с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).
- Установите тип заливки эллипса как сплошную.
- Задайте цвет сплошной заливки через [getSolidFillColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getSolidFillColor) у объекта [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/), связанного с объектом [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/).
- Установите цвет контура эллипса.
- Задайте толщину контура эллипса.
- Запишите изменённую презентацию в файл PPTX.

Следующий пример добавляет отформатированный эллипс на первый слайд презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получите первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавьте форму эллипса.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Отформатируйте заливку эллипса.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Отформатируйте контур эллипса.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Запишите файл PPTX на диск.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Вопросы и ответы**

**Как установить точные позицию и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно задаются **в пунктах**. Для предсказуемых результатов основывайте вычисления на размере слайда и преобразуйте требуемые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Измените порядок рисования объекта, переместив его на передний план или отправив на задний. Это позволяет эллипсу перекрывать другие объекты или раскрывать находящиеся под ним.

**Как анимировать появление или выделение эллипса?**

[Apply](/slides/ru/python-java/shape-animation/) эффекты входа, выделения или выхода к фигуре и настройте триггеры и тайминг, чтобы управлять тем, когда и как анимация воспроизводится.