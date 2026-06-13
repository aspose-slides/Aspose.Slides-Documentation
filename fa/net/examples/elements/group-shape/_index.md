---
title: شکل گروهی
type: docs
weight: 170
url: /fa/net/examples/elements/group-shape/
keywords:
- گروه
- اضافه کردن شکل گروهی
- دسترسی به شکل گروهی
- حذف شکل گروهی
- جدا کردن اشکال
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت اشکال گروه‌بندی‌شده در Aspose.Slides برای .NET: ایجاد، تو در تو کردن، تراز، مرتب‌سازی و استایل‌دهی به شکل‌های گروهی با مثال‌های C# در ارائه‌های PPT، PPTX و ODP."
---
مثال‌هایی برای ایجاد گروه‌های اشکال، دسترسی به آن‌ها، جداسازی و حذف با استفاده از **Aspose.Slides for .NET**.

## **اضافه کردن یک شکل گروهی**

یک گروه حاوی دو شکل پایه ایجاد کنید.

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

## **دسترسی به یک شکل گروهی**

شکل گروهی اول را از یک اسلاید بازیابی کنید.

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

## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **جدا کردن اشکال**

اشکال را از داخل یک محفظه گروه خارج کنید.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // جابجایی شکل خارج از گروه.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```