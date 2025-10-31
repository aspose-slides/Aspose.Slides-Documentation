---
title: Добавить прямоугольники в презентации на Python
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/python-net/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- форма прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Улучшите ваши презентации PowerPoint и OpenDocument, добавляя прямоугольники с помощью Aspose.Slides для Python через .NET — легко создавайте и изменяйте фигуры программно."
---

## **Создание простого прямоугольника**
Как и в предыдущих темах, здесь речь идёт о добавлении фигуры, а именно о прямоугольнике. В этом разделе описывается, как разработчики могут добавлять простые или форматированные прямоугольники в свои слайды с помощью Aspose.Slides для Python через .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
4. Сохраните изменённую презентацию в виде файла PPTX.

В примере ниже добавлен простой прямоугольник на первый слайд презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа прямоугольник
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Сохранить файл PPTX на диск
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание форматированного прямоугольника**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
4. Установите тип заливки прямоугольника в Solid.
5. Задайте цвет прямоугольника, используя свойство SolidFillColor.Color, предоставляемое объектом FillFormat, связанным с объектом IShape.
6. Установите цвет линий прямоугольника.
7. Задайте ширину линий прямоугольника.
8. Сохраните изменённую презентацию в виде файла PPTX.

Пример реализации приведён ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру типа прямоугольник
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Применить некоторое форматирование к фигуре прямоугольника
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Применить некоторое форматирование к линии прямоугольника
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Сохранить файл PPTX на диск
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**  
Используйте тип фигуры [rounded-corner](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; скругление можно применять к каждому углу отдельно с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**  
Выберите тип заливки [picture](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), укажите источник изображения и настройте [режимы растягивания/повторения](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) .

**Можно ли добавить к прямоугольнику тень и свечение?**  
Да. Доступны [внешняя/внутренняя тень, свечение и мягкие края](/slides/ru/python-net/shape-effect/) с регулируемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**  
Да. [Назначьте гиперссылку](/slides/ru/python-net/manage-hyperlinks/) на клик по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**  
[Используйте блокировки фигур](/slides/ru/python-net/applying-protection-to-presentation/): можно запретить перемещение, изменение размеров, выбор или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**  
Да. Вы можете [визуализировать фигуру](/slides/ru/python-net/shape/get_image/) в изображение заданного размера/масштаба или [экспортировать её как SVG](/slides/ru/python-net/shape/write_as_svg/) для векторного использования.

**Как быстро получить фактические (effective) свойства прямоугольника с учётом темы и наследования?**  
[Используйте эффективные свойства фигуры](/slides/ru/python-net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.