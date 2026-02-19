---
title: شريحة
type: docs
weight: 10
url: /ar/net/examples/elements/slide/
keywords:
- شريحة
- إضافة شريحة
- الوصول إلى الشريحة
- فهرس الشريحة
- استنساخ شريحة
- إعادة ترتيب الشرائح
- إزالة شريحة
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في الشرائح في Aspose.Slides for .NET: أنشئ، استنسخ، أعد ترتيب، غيّر الحجم، اضبط الخلفيات، وطبق الانتقالات باستخدام C# لعروض PPT و PPTX و ODP."
---
يوفر هذا المقال سلسلة من الأمثلة التي توضح كيفية التعامل مع الشرائح باستخدام **Aspose.Slides for .NET**. ستتعلم كيفية إضافة، والوصول، واستنساخ، وإعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

يتضمن كل مثال أدناه شرحًا موجزًا يليه مقتطف شفرة بلغة C#.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // كل شريحة تستند إلى تخطيط، والذي بدوره يستند إلى شريحة رئيسية.
    // استخدم تخطيط Blank لإنشاء شريحة جديدة.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // أضف شريحة فارغة جديدة باستخدام التخطيط المحدد.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **ملاحظة:** كل تخطيط شريحة مستمد من شريحة رئيسية، التي تُحدد التصميم العام وهيكل العناصر النائبة. تُظهر الصورة أدناه كيف يتم تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح حسب الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها، أو العثور على فهرس شريحة بناءً على مرجع. هذا مفيد للتنقل عبر الشرائح أو تعديل شرائح معينة.

```csharp
static void AccessSlide()
{
    // بشكل افتراضي، يتم إنشاء عرض تقديمي بشريحة فارغة واحدة.
    using var presentation = new Presentation();

    // أضف شريحة فارغة أخرى.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // الوصول إلى الشرائح حسب الفهرس.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // احصل على فهرس الشريحة من مرجع، ثم وصل إليها حسب الفهرس.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **استنساخ شريحة**

يوضح هذا المثال كيفية استنساخ شريحة موجودة. يتم إضافة الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```csharp
static void CloneSlide()
{
    // بشكل افتراضي، يحتوي العرض التقديمي على شريحة فارغة واحدة.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // استنسخ الشريحة الأولى؛ ستُضاف في نهاية العرض التقديمي.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // فهرس الشريحة المستنسخة هو 1 (الشريحة الثانية في العرض التقديمي).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح بنقل إحدى الشرائح إلى فهرس جديد. في هذه الحالة، نقوم بنقل الشريحة المستنسخة إلى الموضع الأول.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // أضف نسخة مستنسخة من الشريحة الأولى (تم إنشاؤها بشكل افتراضي).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // انقل الشريحة المستنسخة إلى الموضع الأول (تنزلق البقية للأسفل).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `Remove`. يضيف هذا المثال شريحة ثانية ثم يزيل الأصلية، مما يترك الشريحة الجديدة فقط.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // أضف شريحة فارغة جديدة بالإضافة إلى الشريحة الأولى الافتراضية.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // احذف الشريحة الأولى؛ ستبقى الشريحة التي أضيفت حديثًا فقط.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```