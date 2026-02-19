---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/net/examples/elements/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
- الوصول إلى انتقال شريحة
- إزالة انتقال شريحة
- مدة الانتقال
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إتقان انتقالات الشرائح في Aspose.Slides for .NET: إضافة وتخصيص وتسلسل التأثيرات والمدة باستخدام أمثلة C# لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة تطبيق تأثيرات انتقال الشرائح والوقت مع **Aspose.Slides for .NET**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // تطبيق انتقال تلاشي.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين حاليًا لشريحة.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // الوصول إلى نوع الانتقال.
    var type = slide.SlideShowTransition.Type;
}
```

## **إزالة انتقال شريحة**

مسح أي تأثير انتقال عن طريق تعيين النوع إلى `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // إزالة الانتقال بتعيين None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **تعيين مدة الانتقال**

حدد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // بالملي ثانية
}
```