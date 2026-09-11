---
title: Добавление прямоугольников в презентации на Python через Java
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/python-java/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- прямоугольная фигура
- простой прямоугольник
- отформатированный прямоугольник
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Улучшите ваши презентации PowerPoint, добавив прямоугольники с помощью Aspose.Slides для Python через Java — легко создавайте и изменяйте фигуры программно."
---
## **Обзор**

В этой статье показано, как добавлять прямоугольные фигуры в слайды PowerPoint с помощью Aspose.Slides. Описывается создание простого прямоугольника, создание отформатированного прямоугольника и сохранение обновлённой презентации в формате PPTX.

Вы также увидите, как применить базовое форматирование прямоугольника, такое как сплошной цвет заливки, цвет линии и ширина линии. Кроме того, в разделе FAQ статьи указаны связанные задачи с прямоугольниками, включая скруглённые углы, заливку изображением, визуальные эффекты, гиперссылки, блокировку фигур, параметры экспорта и эффективные свойства.

## **Добавление прямоугольника на слайд**

Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите ссылку на слайд по его индексу.
- Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа прямоугольник, используя метод [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).
- Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.

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

    # Добавьте форму прямоугольника.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Запишите файл PPTX на диск.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление отформатированного прямоугольника на слайд**

Чтобы добавить отформатированный прямоугольник на слайд, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите ссылку на слайд по его индексу.
- Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа прямоугольник, используя метод [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) объекта [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).
- Установите [fill type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) прямоугольника в значение solid.
- Установите цвет прямоугольника с помощью метода [setColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colorformat/#setColor) у сплошного цвета заливки объекта [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/) связанного с объектом [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/).
- Установите цвет контура прямоугольника.
- Установите ширину контура прямоугольника.
- Сохраните изменённую презентацию в файл PPTX.

Вышеуказанные шаги реализованы в примере, приведённом ниже.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получите первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавьте форму прямоугольника.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Форматируйте заливку прямоугольника.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Форматируйте контур прямоугольника.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Запишите файл PPTX на диск.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры со скруглёнными углами [shape type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; скругление также можно применить к отдельным углам с помощью геометрических настроек.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки изображением [fill type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и свечение?**

Да. [Outer/inner shadow, glow, and soft edges](/slides/ru/python-java/shape-effect/) доступны с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Assign a hyperlink](/slides/ru/python-java/manage-hyperlinks/) к клику по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/python-java/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размера, выделение или редактирование текста, чтобы сохранить расположение.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) в изображение заданного размера/масштаба или [export it as SVG](/slides/ru/python-java/create-shape-thumbnails/) для использования в векторном виде.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/python-java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.