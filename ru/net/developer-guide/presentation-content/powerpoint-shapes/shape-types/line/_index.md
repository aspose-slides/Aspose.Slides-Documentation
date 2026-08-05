---
title: Добавление линейных фигур в презентации в .NET
linktitle: Линия
type: docs
weight: 50
url: /ru/net/line/
keywords:
- линия
- создание линии
- добавление линии
- простая линия
- настройка линии
- кастомизация линии
- стиль штриха
- стрелка
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для .NET. Ознакомьтесь со свойствами, методами и примерами."
---
## **Обзор**

Aspose.Slides позволяет программно добавлять линейные фигуры в слайды PowerPoint. В этой статье показано, как создать простую линию и как настроить её так, чтобы она выглядела как стрелка.

Вы узнаете, как добавить линейную фигуру на слайд, изменить её визуальное оформление и сохранить обновлённую презентацию. Примеры сосредоточены на практических параметрах форматирования линии, таких как стиль, ширина, шаблон штриха, параметры наконечников и цвет заливки.

## **Создание простой линии**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class.
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода [AddAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/methods/addautoshape/index), доступного у объекта Shapes.
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.

```c#
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получить первый слайд
    ISlide sld = pres.Slides[0];

    // Добавить AutoShape типа line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write Записать PPTX на диск
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Создание линии‑стрелки**
Aspose.Slides for .NET также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/ru/aspose.slides/)[](http://www.aspose.com/api/net/slides/ru/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода AddAutoShape, доступного у объекта Shapes.
- Установите стиль линии (Line Style) в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/ru/net/aspose.slides/linedashstyle) линии в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/net/aspose.slides/linearrowheadstyle) и длину начального наконечника линии.
- Установите стиль и длину конечного наконечника линии.
- Запишите изменённую презентацию в файл PPTX.

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

    //Записать PPTX на диск
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязывалась» к объектам?**

Нет. Обычная линия (AutoShape типа Line) автоматически не превращается в соединитель. Чтобы она привязывалась к объектам, используйте специальный тип [Connector](https://reference.aspose.com/slides/ru/net/aspose.slides/connector/) и соответствующие API (/slides/ru/net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и сложно определить их конечные значения?**

[Читайте эффективные свойства](/slides/ru/net/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/autoshapelock/), которые позволяют [запретить операции редактирования](/slides/ru/net/applying-protection-to-presentation/).