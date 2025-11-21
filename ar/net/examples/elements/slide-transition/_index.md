---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/net/examples/elements/slide-transition/
keywords:
- مثال على انتقال الشريحة
- إضافة انتقال شريحة
- الوصول إلى انتقال الشريحة
- إزالة انتقال الشريحة
- مدة الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في انتقالات الشرائح باستخدام C# و Aspose.Slides: اختر الأنواع والسرعة والصوت والتوقيت لتحسين العروض التقديمية في صيغ PPT و PPTX و ODP."
---

يوضح تطبيق تأثيرات الانتقال بين الشرائح وتوقيتاتها باستخدام **Aspose.Slides for .NET**.

## إضافة انتقال للشرائح

تطبيق تأثير انتقال خافت على الشريحة الأولى.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // تطبيق انتقال تلاشي
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## الوصول إلى انتقال الشريحة

قراءة نوع الانتقال المعين حاليًا إلى شريحة.
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // الوصول إلى نوع الانتقال
    var type = slide.SlideShowTransition.Type;
}
```


## إزالة انتقال الشريحة

إزالة أي تأثير انتقال عن طريق تعيين النوع إلى `None`.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // إزالة الانتقال بتعيين لا شيء
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## تحديد مدة الانتقال

تحديد مدة عرض الشريحة قبل الانتقال التلقائي.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // بالمللي ثانية
}
```
