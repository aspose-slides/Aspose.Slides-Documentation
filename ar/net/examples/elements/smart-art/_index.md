---
title: SmartArt
type: docs
weight: 140
url: /ar/net/examples/elements/smart-art/
keywords:
- SmartArt
- إضافة SmartArt
- الوصول إلى SmartArt
- إزالة SmartArt
- تخطيط SmartArt
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع SmartArt في Aspose.Slides لـ .NET: إنشاء وتحرير وتحويل وتنسيق المخططات باستخدام C# لعروض PowerPoint وOpenDocument التقديمية."
---
يوضح هذا المقال كيفية إضافة رسومات SmartArt، والوصول إليها، وإزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for .NET**.

## **إضافة SmartArt**

أدرج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **الوصول إلى SmartArt**

استرجع أول كائن SmartArt في الشريحة.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **إزالة SmartArt**

احذف شكل SmartArt من الشريحة.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **تغيير تخطيط SmartArt**

حدّث نوع التخطيط لرسم SmartArt الموجود.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```