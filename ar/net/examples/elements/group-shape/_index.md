---
title: مجموعة الشكل
type: docs
weight: 170
url: /ar/net/examples/elements/group-shape/
keywords:
- مثال مجموعة
- إضافة مجموعة شكل
- الوصول إلى مجموعة شكل
- إزالة مجموعة شكل
- إلغاء تجميع الأشكال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع مجموعات الأشكال في C# باستخدام Aspose.Slides: إنشاء وإلغاء التجميع، إعادة ترتيب الأشكال الفرعية، ضبط التحويلات والحدود عبر PowerPoint وOpenDocument."
---

أمثلة لإنشاء مجموعات من الأشكال، والوصول إليها، وإلغاء التجميع، والإزالة باستخدام **Aspose.Slides for .NET**.

## إضافة مجموعة أشكال

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


## الوصول إلى مجموعة أشكال

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


## إزالة مجموعة أشكال

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


## إلغاء تجميع الأشكال

نقل الأشكال خارج حاوية المجموعة.
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
