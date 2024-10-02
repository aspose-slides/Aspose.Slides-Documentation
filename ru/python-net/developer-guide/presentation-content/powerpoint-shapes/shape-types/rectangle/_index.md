---
title: Прямоугольник
type: docs
weight: 80
url: /ru/python-net/rectangle/
keywords: "Создать прямоугольник, фигура PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создать прямоугольник в презентации PowerPoint на Python"
---


## **Создание простого прямоугольника**
Как и в предыдущих темах, эта также посвящена добавлению фигуры, и на этот раз мы обсудим прямоугольник. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники на свои слайды с использованием Aspose.Slides для Python через .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Прямоугольник с помощью метода AddAutoShape, предоставленного объектом IShapes.
4. Запишите измененную презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получите первый слайд
    sld = pres.slides[0]

    # Добавьте автофигуру типа прямоугольник
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Запишите файл PPTX на диск
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Создание форматированного прямоугольника**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Прямоугольник с помощью метода AddAutoShape, предоставленного объектом IShapes.
4. Установите тип заливки прямоугольника на Сплошной.
5. Установите цвет прямоугольника, используя свойство SolidFillColor.Color, предоставленное объектом FillFormat, связанным с объектом IShape.
6. Установите цвет линий прямоугольника.
7. Установите ширину линий прямоугольника.
8. Запишите измененную презентацию в файл PPTX.
   Эти шаги реализованы в примере ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получите первый слайд
    sld = pres.slides[0]

    # Добавьте автофигуру типа прямоугольник
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Примените некоторые настройки к фигуре прямоугольника
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Примените некоторые настройки к линии прямоугольника
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Запишите файл PPTX на диск
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```