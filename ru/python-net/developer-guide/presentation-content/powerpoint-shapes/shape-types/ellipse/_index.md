---
title: Эллипс
type: docs
weight: 30
url: /python-net/ellipse/
keywords: "Эллипс, форма PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создание эллипса в презентации PowerPoint на Python"
---


## **Создать эллипс**
В этой теме мы ознакомим разработчиков с добавлением форм эллипса на их слайды с помощью Aspose.Slides для Python через .NET. Aspose.Slides для Python через .NET предоставляет более простой набор API для рисования различных видов форм всего за несколько строк кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Получите ссылку на слайд, используя его индекс
1. Добавьте автоформу типа эллипс с помощью метода AddAutoShape, предоставленного объектом IShapes
1. Запишите модифицированную презентацию в файл PPTX

В приведенном ниже примере мы добавили эллипс на первый слайд.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получите первый слайд
    sld = pres.slides[0]

    # Добавьте автоформу типа эллипс
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Запишите файл PPTX на диск
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Создать форматированный эллипс**
Чтобы добавить более красиво оформленный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте автоформу типа эллипс с помощью метода AddAutoShape, предоставленного объектом IShapes.
1. Установите тип заливки эллипса на сплошной.
1. Установите цвет эллипса, используя свойство SolidFillColor.Color, предоставленное объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий эллипса.
1. Установите ширину линий эллипса.
1. Запишите модифицированную презентацию в файл PPTX.

В приведенном ниже примере мы добавили форматированный эллипс на первый слайд презентации.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получите первый слайд
    sld = pres.slides[0]

    # Добавьте автоформу типа эллипс
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Примените некоторые настройки к форме эллипса
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Примените некоторые настройки к линии эллипса
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Запишите файл PPTX на диск
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```