---
title: Добавление прямоугольников в презентации в .NET
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/net/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- прямоугольная фигура
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для .NET—легко создавайте и изменяйте фигуры программно."
---

## **Создать простой прямоугольник**
Как и в предыдущих темах, эта также посвящена добавлению фигуры, и на этот раз мы будем рассматривать Прямоугольник. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники на свои слайды с помощью Aspose.Slides for .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.
```c#
// Создайте экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автофигуру типа Rectangle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Сохраните файл PPTX на диск
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Создать форматированный прямоугольник**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставляемого объектом IShapes.
1. Установите тип заливки прямоугольника в Solid.
1. Установите цвет прямоугольника, используя свойство SolidFillColor.Color, предоставляемое объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите ширину линий прямоугольника.
1. Сохраните изменённую презентацию в файл PPTX.
   Приведённые выше шаги реализованы в примере ниже.
```c#
// Создайте экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автофигуру типа Rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Примените некоторое форматирование к фигуре прямоугольника
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Примените некоторое форматирование к линии прямоугольника
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write файл PPTX на диск
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) с закруглёнными углами и отрегулируйте радиус угла в свойствах фигуры; скругление также можно применить к каждому углу отдельно с помощью настроек геометрии.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и световое свечение?**

Да. Доступны [Outer/inner shadow, glow, and soft edges](/slides/ru/net/shape-effect/) с регулируемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Assign a hyperlink](/slides/ru/net/manage-hyperlinks/) к клику по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/net/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размера, выбор или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) в изображение заданного размера/масштаба или [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.