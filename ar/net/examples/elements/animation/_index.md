---
title: الرسوم المتحركة
type: docs
weight: 100
url: /ar/net/examples/elements/animation/
keywords:
- الرسوم المتحركة
- إضافة رسوم متحركة
- الوصول إلى رسوم متحركة
- إزالة رسوم متحركة
- تسلسل الرسوم المتحركة
- مثال على كود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف أمثلة الرسوم المتحركة في Aspose.Slides for .NET: إضافة، تسلسل، وتخصيص التأثيرات والانتقالات باستخدام C# لعرض تقديمي PPT، PPTX، وODP."
---
توضح هذه المقالة كيفية إنشاء رسوم متحركة بسيطة وإدارة تسلسلها باستخدام **Aspose.Slides for .NET**.

## **إضافة حركة**
أنشئ شكلاً مستطيلاً وطبق تأثير تلاشي يتم تشغيله عند النقر.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // تأثير التلاشي.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **الوصول إلى حركة**
استرجع أول تأثير حركة من جدول زمني الشريحة.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // الوصول إلى أول تأثير حركة.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **إزالة حركة**
قم بإزالة تأثير الحركة من التسلسل.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // إزالة التأثير.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **تسلسل الحركات**
أضف تأثيرات متعددة وبيّن الترتيب الذي تحدث به الرسوم المتحركة.

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