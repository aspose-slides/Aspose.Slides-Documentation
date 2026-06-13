---
title: SmartArt
type: docs
weight: 140
url: /fa/net/examples/elements/smart-art/
keywords:
- SmartArt
- افزودن SmartArt
- دسترسی به SmartArt
- حذف SmartArt
- طرح‌بندی SmartArt
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با SmartArt در Aspose.Slides برای .NET: ایجاد، ویرایش، تبدیل و استایل‌دهی نمودارها با C# برای ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد که چگونه گرافیک‌های SmartArt را اضافه کنید، به آن‌ها دسترسی پیدا کنید، حذف کنید و طرح‌بندی‌ها را با استفاده از **Aspose.Slides for .NET** تغییر دهید.

## **افزودن SmartArt**

یک گرافیک SmartArt را با استفاده از یکی از طرح‌بندی‌های پیش‌فرض وارد کنید.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **دسترسی به SmartArt**

اولین شیء SmartArt را در یک اسلاید دریافت کنید.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **تغییر طرح‌بندی SmartArt**

نوع طرح‌بندی یک گرافیک SmartArt موجود را به‌روزرسانی کنید.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```