---
title: انیمیشن
type: docs
weight: 100
url: /fa/net/examples/elements/animation/
keywords:
- انیمیشن
- افزودن انیمیشن
- دسترسی به انیمیشن
- حذف انیمیشن
- توالی انیمیشن
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مثال‌های انیمیشن Aspose.Slides for .NET را کاوش کنید: افزودن، توالی و سفارشی‌سازی افکت‌ها و انتقال‌ها با C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه ایجاد انیمیشن‌های ساده و مدیریت ترتیب آن‌ها را با استفاده از **Aspose.Slides for .NET** نشان می‌دهد.

## **افزودن انیمیشن**
یک شکل مستطیل ایجاد کنید و افکت محو شدن را که با کلیک فعال می‌شود اعمال کنید.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // افکت محو شدن.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **دسترسی به انیمیشن**
اولین اثر انیمیشن را از جدول زمان‌بندی اسلاید بازیابی کنید.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // دسترسی به اولین اثر انیمیشن.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **حذف انیمیشن**
یک اثر انیمیشن را از توالی حذف کنید.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // حذف اثر.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **توالی‌سازی انیمیشن‌ها**
چندین اثر اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```