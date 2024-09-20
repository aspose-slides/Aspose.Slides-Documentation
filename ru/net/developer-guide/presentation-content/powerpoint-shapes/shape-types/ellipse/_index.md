---
title: Эллипс
type: docs
weight: 30
url: /net/ellipse/
keywords: "Эллипс, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Создание эллипса в презентации PowerPoint на C# или .NET"
---


## **Создание Эллипса**
В этой теме мы познакомим разработчиков с добавлением фигур эллипса на их слайды с помощью Aspose.Slides для .NET. Aspose.Slides для .NET предоставляет более простой набор API для рисования различных типов фигур всего с несколькими строками кода. Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Получите ссылку на слайд, используя его индекс
1. Добавьте автофигуру типа Эллипс с помощью метода AddAutoShape, предоставляемого объектом IShapes
1. Запишите измененную презентацию в файл PPTX

В приведенном ниже примере мы добавили эллипс на первый слайд.

```c#
// Создание экземпляра класса Presentation, который представляет PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автофигуру типа эллипс
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Запишите файл PPTX на диск
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Создание Форматированного Эллипса**
Чтобы добавить лучше отформатированный эллипс на слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте автофигуру типа Эллипс с помощью метода AddAutoShape, предоставляемого объектом IShapes.
1. Установите тип заливки эллипса на Сплошной.
1. Установите цвет эллипса, используя свойство SolidFillColor.Color, предоставляемое объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий эллипса.
1. Установите ширину линий эллипса.
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили отформатированный эллипс на первый слайд презентации.

```c#
// Создание экземпляра класса Presentation, который представляет PPTX
using (Presentation pres = new Presentation())
{

    // Получите первый слайд
    ISlide sld = pres.Slides[0];

    // Добавьте автофигуру типа эллипс
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Примените некоторые стили к фигуре эллипса
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Примените некоторые стили к линии эллипса
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Запишите файл PPTX на диск
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```