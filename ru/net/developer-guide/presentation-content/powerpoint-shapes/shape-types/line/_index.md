---
title: Добавить линейные фигуры в презентации в .NET
linktitle: Линия
type: docs
weight: 50
url: /ru/net/Line/
keywords:
- линия
- создать линию
- добавить линию
- обычная линия
- настроить линию
- кастомизировать линию
- стиль штриха
- стрелочный наконечник
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для .NET. Откройте свойства, методы и примеры."
---

Aspose.Slides for .NET поддерживает добавление различных типов фигур на слайды. В этой статье мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for .NET разработчики могут не только создавать простые линии, но и рисовать красивые линии на слайдах.

## **Create a Plain Line**
Чтобы добавить простую обычную линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), предоставляемого объектом Shapes.
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.
```c#
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить AutoShape типа line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Записать PPTX на диск
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **Create an Arrow-Shaped Line**
Aspose.Slides for .NET также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода AddAutoShape, предоставляемого объектом Shapes.
- Установите стиль линии (Line Style) в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите ширину (Width) линии.
- Установите [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) линии в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) и длину начального конца линии.
- Установите стиль и длину стрелочного конца линии.
- Сохраните изменённую презентацию в файл PPTX.
```c#
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить AutoShape типа line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применить некоторое форматирование к линии
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Write the PPTX to Disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) type and the [corresponding APIs](/slides/ru/net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/ru/net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) that let you [disallow editing operations](/slides/ru/net/applying-protection-to-presentation/).