---
title: Линия
type: docs
weight: 50
url: /ru/net/Line/
keywords: "Линия, фигура PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавить линию в презентацию PowerPoint на C# или .NET"
---

Aspose.Slides for .NET поддерживает добавление различных типов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for .NET разработчики могут не только создавать простые линии, но также рисовать на слайдах декоративные линии.
## **Создать простую линию**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line, используя метод [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index), предоставляемый объектом Shapes.
- Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```c#
 // Создать экземпляр класса PresentationEx, представляющего файл PPTX
 using (Presentation pres = new Presentation())
 {
     // Получить первый слайд
     ISlide sld = pres.Slides[0];

     // Добавить автофигуру типа line
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

     //Записать PPTX на диск
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```


## **Создать линию со стрелкой**
Aspose.Slides for .NET также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line, используя метод AddAutoShape, предоставляемый объектом Shapes.
- Установите стиль линии (Line Style) одним из стилей, предлагаемых Aspose.Slides for .NET.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) линии одним из стилей, предлагаемых Aspose.Slides for .NET.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) и длину начальной точки линии.
- Установите стиль и длину конечной точки линии.
- Сохраните изменённую презентацию в файл PPTX.
```c#
 // Создать экземпляр класса PresentationEx, представляющего файл PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Получить первый слайд
     ISlide sld = pres.Slides[0];
 
     // Добавить автофигуру типа line
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

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «прилипала» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она «прилипала» к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) и [соответствующие API](/slides/ru/net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Читайте эффективные свойства](/slides/ru/net/shape-effective-properties/) через классы [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от изменения (перемещения, изменения размера)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/), которые позволяют [запретить операции редактирования](/slides/ru/net/applying-protection-to-presentation/).