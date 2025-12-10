---
title: موصل
type: docs
weight: 190
url: /ar/net/examples/elements/connector/
keywords:
- مثال موصل
- إضافة موصل
- وصول إلى موصل
- إزالة موصل
- إعادة ربط الأشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "ارسم وتحكم في الموصلات باستخدام C# مع Aspose.Slides: أضف، وحدد مسار، وأعد توجيه، واضبط نقاط الاتصال، والأسهم والأنماط لربط الأشكال في PPT و PPTX و ODP."
---

يعرض طريقة ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for .NET**.

## **إضافة موصل**

إدراج شكل موصل بين نقطتين على الشريحة.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## **الوصول إلى موصل**

استرجاع أول شكل موصل تم إضافته إلى الشريحة.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## **إزالة موصل**

حذف موصل من الشريحة.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## **إعادة ربط الأشكال**

إرفاق موصل إلى شكلين عن طريق تعيين أهداف البدء والنهاية.
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
