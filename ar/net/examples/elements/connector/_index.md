---
title: موصل
type: docs
weight: 190
url: /ar/net/examples/elements/connector/
keywords:
- موصل
- إضافة موصل
- الوصول إلى الموصل
- إزالة موصل
- إعادة ربط الأشكال
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وربط وتنسيق الموصلات بين الأشكال باستخدام Aspose.Slides لـ .NET، مع أمثلة C# لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for .NET**.

## **إضافة موصل**
أدرج شكل موصل بين نقطتين على الشريحة.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **الوصول إلى موصل**
استرجع أول شكل موصل تمت إضافته إلى شريحة.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **إزالة موصل**
احذف موصلًا من الشريحة.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **إعادة ربط الأشكال**
ربط موصل باثنين من الأشكال عن طريق تعيين الأهداف البداية والنهاية.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```