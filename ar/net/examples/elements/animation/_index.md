---
title: تحريك
type: docs
weight: 100
url: /ar/net/examples/elements/animation/
keywords:
- مثال على التحريك
- إضافة تحريك
- الوصول إلى التحريك
- إزالة التحريك
- تسلسل التحريك
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في رسوم الشرائح المتحركة في C# باستخدام Aspose.Slides: أضف، حرّر، وأزل التأثيرات، التوقيتات، والمحفّزات لإنشاء عروض تقديمية ديناميكية في PPT و PPTX و ODP."
---

يوضح كيفية إنشاء رسوم متحركة بسيطة وإدارة تسلسلها باستخدام **Aspose.Slides for .NET**.

## **إضافة حركة**

إنشاء شكل مستطيل وتطبيق تأثير تلاشي عند النقر.
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // تأثير الظهور التدريجي
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## **الوصول إلى حركة**

استرداد أول تأثير حركة من جدول زمني الشريحة.
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // الوصول إلى أول تأثير حركة
    var effect = slide.Timeline.MainSequence[0];
}
```


## **إزالة حركة**

إزالة تأثير حركة من التسلسل.
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // إزالة التأثير
    slide.Timeline.MainSequence.Remove(effect);
}
```


## **تسلسل الحركات**

إضافة تأثيرات متعددة وإظهار الترتيب الذي تحدث فيه الحركات.
```csharp
static void Sequence_Animations()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var seq = slide.Timeline.MainSequence;
    seq.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    seq.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```
