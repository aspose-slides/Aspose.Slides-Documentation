---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/net/examples/elements/slide-transition/
keywords:
- مثال انتقال شريحة
- إضافة انتقال شريحة
- الوصول إلى انتقال شريحة
- إزالة انتقال شريحة
- مدة الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "التحكم في انتقالات الشرائح في C# باستخدام Aspose.Slides: اختيار الأنواع والسرعة والصوت والتوقيت لتصميم عروض تقديمية متقنة في صيغ PPT، PPTX و ODP."
---

يعرض تطبيق تأثيرات انتقال الشرائح والتوقيتات باستخدام **Aspose.Slides for .NET**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // تطبيق انتقال تلاشي
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين حاليًا لشريحة.
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


## **إزالة انتقال شريحة**

إزالة أي تأثير انتقال عن طريق تعيين النوع إلى `None`.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // إزالة الانتقال عن طريق تعيين none
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## **تعيين مدة الانتقال**

حدد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // بالملي ثانية
}
```
