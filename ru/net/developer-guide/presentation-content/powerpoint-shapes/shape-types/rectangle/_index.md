---
title: Прямоугольник
type: docs
weight: 80
url: /ru/net/rectangle/
keywords: "Создать прямоугольник, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Создание прямоугольника в презентации PowerPoint на C# или .NET"
---

## **Создать простой прямоугольник**
Как и в предыдущих темах, здесь также речь идет о добавлении фигуры, а именно о прямоугольнике. В этой теме мы описали, как разработчики могут добавить простые или форматированные прямоугольники на свои слайды с помощью Aspose.Slides for .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, доступного у объекта IShapes.
1. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили простой прямоугольник на первый слайд презентации.
```c#
// Создать экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру типа Rectangle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Записать файл PPTX на диск
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Создать форматированный прямоугольник**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, доступного у объекта IShapes.
1. Установите тип заливки прямоугольника в Solid.
1. Установите цвет прямоугольника, задав свойство SolidFillColor.Color у объекта FillFormat, связанного с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите ширину линий прямоугольника.
1. Запишите изменённую презентацию в файл PPTX.
   Приведённые выше шаги реализованы в примере ниже.
```c#
// Создать экземпляр класса Presentation, представляющего PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить автофигуру типа Rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Применить некоторое форматирование к фигуре прямоугольника
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Применить некоторое форматирование к линии прямоугольника
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Записать файл PPTX на диск
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; радиус можно задать отдельно для каждого угла через геометрические корректировки.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки [picture fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Можно ли добавить тень и свечение к прямоугольнику?**

Да. Доступны [внешняя/внутренняя тень, свечение и мягкие края](/slides/ru/net/shape-effect/) с регулируемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Назначьте гиперссылку](/slides/ru/net/manage-hyperlinks/) на клик по фигуре (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Используйте блокировки фигур](/slides/ru/net/applying-protection-to-presentation/): можно запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [рендерить фигуру](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) в изображение заданного размера/масштаба или [экспортировать её как SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/net/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.