---
title: Добавление прямоугольников в презентации на Python
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/python-net/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- фигура прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint и OpenDocument, добавив прямоугольники с помощью Aspose.Slides for Python via .NET — легко создавайте и изменяйте формы программно."
---

## **Создать простой прямоугольник**
Как и в предыдущих темах, здесь также рассматривается добавление фигуры, а именно — прямоугольника. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники в свои презентации с помощью Aspose.Slides for Python via .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа Rectangle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Сохранить файл PPTX на диск
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Создать форматированный прямоугольник**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
1. Установите тип заливки Rectangle в Solid.
1. Задайте цвет прямоугольника через свойство SolidFillColor.Color объекта FillFormat, связанного с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите толщину линий прямоугольника.
1. Сохраните изменённую презентацию в файл PPTX.
   Приведённые выше шаги реализованы в примере ниже.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа Rectangle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Применить некоторое форматирование к фигуре прямоугольника
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Применить некоторое форматирование к линии прямоугольника
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Сохранить файл PPTX на диск
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; скругление можно применять отдельно к каждому углу с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**

Выберите тип заливки изображения [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), укажите источник изображения и настройте режимы растяжения/мозаики [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и свечение?**

Да. Доступны [outer/inner shadow, glow и soft edges](/slides/ru/python-net/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Assign a hyperlink](/slides/ru/python-net/manage-hyperlinks/) к клику по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/python-net/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) в изображение с указанными размерами/масштабом или [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) для векторного использования.

**Как быстро получить фактические (effective) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/python-net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.