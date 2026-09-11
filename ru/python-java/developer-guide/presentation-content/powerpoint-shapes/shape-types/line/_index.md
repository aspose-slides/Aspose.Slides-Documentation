---
title: Добавление линейных фигур в презентации на Python через Java
linktitle: Линия
type: docs
weight: 50
url: /ru/python-java/line/
keywords:
- линия
- создать линию
- добавить линию
- обычная линия
- настроить линию
- кастомизировать линию
- пунктирный стиль
- стрелка
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Откройте свойства, методы и примеры."
---
## **Обзор**

Aspose.Slides позволяет программно добавлять линейные фигуры на слайды PowerPoint. В этой статье показано, как создать простую линию и как настроить линию, чтобы она выглядела как стрелка.

Вы узнаете, как добавить линейную фигуру на слайд, изменить её внешний вид и сохранить обновлённую презентацию. Примеры сосредоточены на практических параметрах форматирования линии, таких как стиль, ширина, пунктирный шаблон, параметры наконечника стрелки и цвет заливки.

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
- Получите ссылку на слайд по его индексу.
- Добавьте линейную фигуру с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/) .
- Запишите изменённую презентацию в файл PPTX.

Следующий пример добавляет линию на первый слайд презентации:

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

    # Добавьте линейную фигуру.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Запишите файл PPTX на диск.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создать линию со стрелкой**

Aspose.Slides for Python via Java также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Чтобы настроить линию как стрелку, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
- Получите ссылку на слайд по его индексу.
- Добавьте линейную фигуру с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/) .
- Установите [line style](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linestyle/) в один из стилей, предлагаемых Aspose.Slides for Python via Java.
- Установите ширину линии.
- Установите [dash style](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linedashstyle/) в один из стилей, предлагаемых Aspose.Slides for Python via Java.
- Установите [arrowhead style](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linearrowheadstyle/) и [length](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linearrowheadlength/) в начале линии.
- Установите [arrowhead style](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linearrowheadstyle/) и [length](https://reference.aspose.com/slides/ru/python-java/aspose.slides/linearrowheadlength/) в конце линии.
- Запишите изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получите первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавьте линейную фигуру.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Примените форматирование к линии.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Запишите файл PPTX на диск.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Вопросы и ответы**

**Можно ли преобразовать обычную линию в соединитель, чтобы она «прилипала» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/)) не превращается автоматически в соединитель. Чтобы она «прилипала» к фигурам, используйте специализированный тип [Connector](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/) и [соответствующие API](/slides/ru/python-java/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и сложно определить окончательные значения?**

[Прочитайте эффективные свойства](/slides/ru/python-java/shape-effective-properties/) линии и её заливки — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#getAutoShapeLock), которые позволяют вам [запретить операции редактирования](/slides/ru/python-java/applying-protection-to-presentation/).