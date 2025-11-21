---
title: موصل
type: docs
weight: 190
url: /ar/net/examples/elements/connector/
keywords:
- مثال موصل
- إضافة موصل
- الوصول إلى موصل
- إزالة موصل
- إعادة ربط الأشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "ارسم وتحكم في الموصلات باستخدام C# مع Aspose.Slides: أضف، ارسم المسار، أعد رسم المسار، اضبط نقاط الاتصال، الأسهم والأنماط لربط الأشكال في PPT، PPTX و ODP."
---

يعرض كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for .NET**.

## إضافة موصل

أدرج شكل موصل بين نقطتين على الشريحة.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## الوصول إلى موصل

استرجع أول شكل موصل تمت إضافته إلى الشريحة.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## إزالة موصل

احذف موصلًا من الشريحة.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## إعادة ربط الأشكال

اربط موصلًا بشكلين عن طريق تعيين أهداف البداية والنهاية.
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
