---
title: مجموعة الأشكال
type: docs
weight: 170
url: /ar/net/examples/elements/group-shape/
keywords:
- مجموعة
- إضافة مجموعة شكل
- الوصول إلى مجموعة شكل
- إزالة مجموعة شكل
- إلغاء تجميع الأشكال
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الأشكال المجمعة في Aspose.Slides for .NET: إنشاء، تضمين، محاذاة، إعادة ترتيب، وتنسيق مجموعات الأشكال باستخدام أمثلة C# في عروض PPT و PPTX و ODP."
---
أمثلة على إنشاء مجموعات من الأشكال، والوصول إليها، وإلغاء التجميع، وإزالتها باستخدام **Aspose.Slides for .NET**.

## **إضافة مجموعة أشكال**

إنشاء مجموعة تحتوي على شكلين أساسيين.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **الوصول إلى مجموعة أشكال**

استرجاع أول مجموعة أشكال من الشريحة.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **إزالة مجموعة أشكال**

حذف مجموعة أشكال من الشريحة.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **إلغاء تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // نقل الشكل خارج المجموعة.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```