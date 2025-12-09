---
title: SmartArt
type: docs
weight: 140
url: /ar/net/examples/elements/smartart/
keywords:
- مثال SmartArt
- إضافة SmartArt
- الوصول إلى SmartArt
- إزالة SmartArt
- تخطيط SmartArt
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتعديل SmartArt في C# باستخدام Aspose.Slides: إضافة العقد، تغيير التخطيطات والأنماط، التحويل إلى أشكال بدقة، وتصدير للـ PPT و PPTX و ODP."
---

يظهر كيفية إضافة رسومات SmartArt والوصول إليها وإزالتها وتغيير التخطيطات باستخدام **Aspose.Slides for .NET**.

## إضافة SmartArt

أدخل رسم SmartArt باستخدام أحد التخطيطات المدمجة.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## الوصول إلى SmartArt

استرجع أول كائن SmartArt في الشريحة.
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## إزالة SmartArt

احذف شكل SmartArt من الشريحة.
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## تغيير تخطيط SmartArt

حدّث نوع تخطيط رسم SmartArt الموجود.
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
