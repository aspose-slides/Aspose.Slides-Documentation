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
- простая линия
- настроить линию
- кастомизировать линию
- штриховой стиль
- стрелка
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для .NET. Откройте свойства, методы и примеры."
---

Aspose.Slides for .NET поддерживает добавление различных типов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for .NET разработчики могут не только создавать простые линии, но и рисовать на слайдах некоторые декоративные линии.
## **Создать простую линию**
Для добавления простой линии на выбранный слайд презентации выполните следующие шаги:

- Создайте экземпляр [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя метод [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), предоставляемый объектом Shapes.
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
 // Создать экземпляр класса PresentationEx, представляющего файл PPTX
 using (Presentation pres = new Presentation())
 {
     // Получить первый слайд
     ISlide sld = pres.Slides[0];
 
     // Добавить автофигуру типа линия
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     //Записать PPTX на диск
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```



## **Создать линию‑стрелку**
Aspose.Slides for .NET также позволяет разработчикам настраивать некоторые свойства линии, чтобы сделать её более привлекательной. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
- Установите Line Style в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите Width линии.
- Установите [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) линии в один из стилей, предлагаемых Aspose.Slides for .NET.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) и Length начальной точки линии.
- Установите Arrow Head Style и Length конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.
```c#
 // Создать экземпляр класса PresentationEx, представляющего файл PPTX
 using (Presentation pres = new Presentation())
 {

     // Получить первый слайд
     ISlide sld = pres.Slides[0];

     // Добавить автофигуру типа линия
     IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

     // Применить некоторую форматировку к линии
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

**Можно ли преобразовать обычную линию в соединитель, чтобы она «привязывалась» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы она привязывалась к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) и [соответствующие API](/slides/ru/net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Читать эффективные свойства](/slides/ru/net/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), которые позволяют [запретить операции редактирования](/slides/ru/net/applying-protection-to-presentation/).