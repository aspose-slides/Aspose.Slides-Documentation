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
description: "Улучшите свои презентации PowerPoint и OpenDocument, добавляя прямоугольники с помощью Aspose.Slides for Python via .NET — легко создавайте и изменяйте фигуры программно."
---

## **Создание простого прямоугольника**
Как и в предыдущих темах, здесь речь идёт о добавлении фигуры, и в этот раз мы обсуждаем прямоугольник. В этой теме мы описали, как разработчики могут добавить простые или форматированные прямоугольники на свои слайды с помощью Aspose.Slides for Python via .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
4. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание форматированного прямоугольника**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
4. Установите тип заливки прямоугольника — Solid.
5. Задайте цвет заливки, используя свойство SolidFillColor.Color объекта FillFormat, связанного с объектом IShape.
6. Задайте цвет линий прямоугольника.
7. Установите ширину линий прямоугольника.
8. Сохраните изменённую презентацию в файл PPTX.

Ниже приведён пример реализации перечисленных шагов.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Как добавить прямоугольник со скруглёнными углами?**  
Используйте тип фигуры со скруглёнными углами ([shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) и настройте радиус угла в свойствах фигуры; скругление можно задать отдельно для каждого угла с помощью геометрических корректировок.

**Как залить прямоугольник изображением (текстурой)?**  
Выберите тип заливки — picture ([fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)), укажите источник изображения и настройте режимы растягивания/мозаики ([stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)).

**Можно ли добавить тень и свечение к прямоугольнику?**  
Да. Доступны внешняя/внутренняя тень, свечение и мягкие края (/slides/ru/python-net/shape-effect/) с регулируемыми параметрами.

**Можно ли превратить прямоугольник в кнопку со ссылкой?**  
Да. Присвойте фигуре гиперссылку (/slides/ru/python-net/manage-hyperlinks/) по клику (переход на слайд, файл, веб‑адрес или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**  
Используйте блокировки фигур (/slides/ru/python-net/applying-protection-to-presentation/): можно запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить разметку.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**  
Да. Вы можете отрисовать фигуру ([render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)) в изображение нужного размера/масштаба или экспортировать её как SVG ([export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)) для векторного использования.

**Как быстро получить реальные (эффективные) свойства прямоугольника с учётом темы и наследования?**  
Воспользуйтесь эффективными свойствами фигуры (/slides/ru/python-net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.