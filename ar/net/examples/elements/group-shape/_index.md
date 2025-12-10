---
title: مجموعة الأشكال
type: docs
weight: 170
url: /ar/net/examples/elements/group-shape/
keywords:
- مثال مجموعة
- إضافة مجموعة أشكال
- الوصول إلى مجموعة أشكال
- إزالة مجموعة أشكال
- إلغاء تجميع الأشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع مجموعات الأشكال في C# باستخدام Aspose.Slides: إنشاء وإلغاء تجميع، إعادة ترتيب الأشكال الفرعية، ضبط التحويلات والحدود في PowerPoint وOpenDocument."
---

أمثلة على إنشاء مجموعات من الأشكال، والوصول إليها، وإلغاء تجميعها، وإزالتها باستخدام **Aspose.Slides for .NET**.

## **إضافة مجموعة أشكال**

إنشاء مجموعة تحتوي على شكلين أساسيين.
```csharp
static void Add_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```


## **الوصول إلى مجموعة أشكال**

استرجاع أول مجموعة أشكال من الشريحة.
```csharp
static void Access_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```


## **إزالة مجموعة أشكال**

حذف مجموعة أشكال من الشريحة.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## **إلغاء تجميع الأشكال**

نقل الأشكال إلى خارج حاوية المجموعة.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // نقل الشكل خارج المجموعة
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
