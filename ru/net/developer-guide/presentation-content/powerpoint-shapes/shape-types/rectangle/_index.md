---
title: Добавление прямоугольников в презентации в .NET
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/net/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- фигура прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Улучшите ваши презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для .NET — легко создавайте и изменяйте фигуры программно."
---

## **Создать простой прямоугольник**
Как и в предыдущих темах, данная также посвящена добавлению фигур, и в этот раз рассматривается прямоугольник. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники на свои слайды с помощью Aspose.Slides для .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.
```c#
// Создайте экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру прямоугольного типа
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Записать файл PPTX на диск
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Создать форматированный прямоугольник**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
1. Установите тип заливки прямоугольника в Solid.
1. Задайте цвет прямоугольника, используя свойство SolidFillColor.Color, предоставляемое объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите толщину линий прямоугольника.
1. Сохраните изменённую презентацию в файл PPTX.

Приведённый ниже пример реализует указанные шаги.
```c#
// Создайте экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру прямоугольного типа
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Применить некоторое форматирование к форме прямоугольника
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Применить форматирование к линии прямоугольника
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Записать файл PPTX на диск
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) и отрегулируйте радиус скругления в свойствах фигуры; скругление также может быть применено к каждому углу отдельно с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/), укажите источник изображения и настройте [stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и свечение?**

Да. Доступны [Outer/inner shadow, glow, and soft edges](/slides/ru/net/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Assign a hyperlink](/slides/ru/net/manage-hyperlinks/) к щелчку по фигуре (переход к слайду, файлу, веб‑адресу или электронной почте).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/net/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размера, выбор или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) в изображение заданного размера/масштаба или [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.