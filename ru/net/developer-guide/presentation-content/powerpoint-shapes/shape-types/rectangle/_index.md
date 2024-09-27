---
title: Прямоугольник
type: docs
weight: 80
url: /ru/net/rectangle/
keywords: "Создание прямоугольника, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Создание прямоугольника в презентации PowerPoint на C# или .NET"
---


## **Создание простого прямоугольника**
Как и в предыдущих темах, эта также посвящена добавлению фигуры, и на этот раз мы обсудим прямоугольник. В этой теме мы описали, как разработчики могут добавлять простые или оформленные прямоугольники на свои слайды с помощью Aspose.Slides для .NET. Чтобы добавить простой прямоугольник на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставленного объектом IShapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.

```c#
// Создайте экземпляр класса Presentation, который представляет PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автошейп типа прямоугольник
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Сохраните файл PPTX на диск
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **Создание оформленного прямоугольника**
Чтобы добавить оформленный прямоугольник на слайд, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте IAutoShape типа Rectangle с помощью метода AddAutoShape, предоставленного объектом IShapes.
1. Установите тип заполнения прямоугольника на Solid.
1. Установите цвет прямоугольника с помощью свойства SolidFillColor.Color, предоставленного объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите ширину линий прямоугольника.
1. Запишите изменённую презентацию в файл PPTX.
   Вышеуказанные шаги реализованы в приведённом ниже примере.

```c#
// Создайте экземпляр класса Presentation, который представляет PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автошейп типа прямоугольник
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Примените некоторые форматы к фигуре прямоугольника
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Примените некоторые форматы к линии прямоугольника
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Сохраните файл PPTX на диск
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```