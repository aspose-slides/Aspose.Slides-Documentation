---
title: شريحة
type: docs
weight: 10
url: /ar/net/examples/elements/slide/
keywords:
- مثال شريحة
- إضافة شريحة
- الوصول إلى الشريحة
- مؤشر الشريحة
- استنساخ شريحة
- إعادة ترتيب الشرائح
- إزالة شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الشرائح في C# باستخدام Aspose.Slides: إنشاء، استنساخ، إعادة ترتيب، إخفاء، ضبط الخلفيات والحجم، تطبيق الانتقالات، وتصدير إلى PowerPoint و OpenDocument."
---

هذه المقالة تقدم مجموعة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for .NET**. ستتعلم كيفية إضافة، الوصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

كل مثال أدناه يتضمن شرحًا مختصرًا يتبعه مقطع شفرة بلغة C#.

## إضافة شريحة

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // كل شريحة تعتمد على تخطيط، والذي يعتمد بدوره على شريحة رئيسية.
    // استخدم تخطيط Blank لإنشاء شريحة جديدة.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // أضف شريحة فارغة جديدة باستخدام التخطيط المحدد
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
````
  
> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## Access Slides by Index

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // بشكل افتراضي، يتم إنشاء عرض تقديمي بشريحة فارغة واحدة
    using var pres = new Presentation();

    // أضف شريحة فارغة أخرى
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // الوصول إلى الشرائح حسب الفهرس
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // احصل على فهرس الشريحة من مرجع، ثم احصل عليها عبر الفهرس
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## Clone a Slide

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // بشكل افتراضي، يحتوي العرض التقديمي على شريحة فارغة واحدة
    using var pres = new Presentation();

    // قم باستنساخ الشريحة الأولى؛ سيتم إضافتها في نهاية العرض التقديمي
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // فهرس الشريحة المستنسخة هو 1 (الشريحة الثانية في العرض التقديمي)
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## Reorder Slides

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // أضف نسخة مستنسخة من الشريحة الأولى (تم إنشاؤها بشكل افتراضي)
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // انقل الشريحة المستنسخة إلى الموضع الأول (تنزلق الشرائح الأخرى لأسفل)
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## Remove a Slide

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // أضف شريحة فارغة جديدة بالإضافة إلى الشريحة الأولى الافتراضية
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // احذف الشريحة الأولى؛ ستبقى الشريحة الجديدة فقط
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
