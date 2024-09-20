---
title: Линия
type: docs
weight: 50
url: /net/Line/
keywords: "Линия, Форма PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавить линию в презентацию PowerPoint на C# или .NET"
---

Aspose.Slides для .NET поддерживает добавление различных видов форм на слайды. В этой теме мы начнем работать с формами, добавляя линии на слайды. С помощью Aspose.Slides для .NET разработчики могут не только создавать простые линии, но также рисовать некоторые сложные линии на слайдах.
## **Создать простую линию**
Чтобы добавить простую плоскую линию на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автоформу типа линии с использованием метода [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), предоставляемого объектом Shapes.
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```c#
// Создаем экземпляр класса PresentationEx, который представляет файл PPTX
using (Presentation pres = new Presentation())
{
    // Получаем первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляем автоформу типа линия
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Записываем PPTX на диск
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Создать линию в форме стрелки**
Aspose.Slides для .NET также позволяет разработчикам настраивать некоторые свойства линии, чтобы сделать ее более привлекательной. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги для этого:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автоформу типа линии с использованием метода AddAutoShape, предоставляемого объектом Shapes.
- Установите стиль линии на один из стилей, предложенных Aspose.Slides для .NET.
- Установите ширину линии.
- Установите [стиль штриховки](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) линии на один из стилей, предложенных Aspose.Slides для .NET.
- Установите [стиль и длину стрелки](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) для начальной точки линии.
- Установите стиль и длину стрелки для конечной точки линии.
- Запишите измененную презентацию в файл PPTX.

```c#
// Создаем экземпляр класса PresentationEx, который представляет файл PPTX
using (Presentation pres = new Presentation())
{

    // Получаем первый слайд
    ISlide sld = pres.Slides[0];

    // Добавляем автоформу типа линия
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применяем форматирование к линии
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Записываем PPTX на диск
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```