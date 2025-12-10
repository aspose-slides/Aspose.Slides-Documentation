---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/net/examples/elements/layout-slide/
keywords:
- مثال شريحة تخطيط
- إضافة شريحة تخطيط
- الوصول إلى شريحة تخطيط
- إزالة شريحة تخطيط
- شريحة تخطيط غير المستخدمة
- استنساخ شريحة تخطيط
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدم C# لإدارة شرائح التخطيط مع Aspose.Slides: إنشاء، تطبيق، استنساخ، إعادة تسمية، وتخصيص العناصر النائبة والقوالب في العروض التقديمية لـ PPT و PPTX و ODP."
---

توضح هذه المقالة كيفية العمل مع **Layout Slides** في Aspose.Slides for .NET. تُعرّف شريحة التخطيط التصميم والتنسيق التي تُورثها الشرائح العادية. يمكنك إضافة، وصول، نسخ، وإزالة شرائح التخطيط، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتعريف تنسيق قابل لإعادة الاستخدام. على سبيل المثال، قد تضيف مربع نص يظهر في جميع الشرائح التي تستخدم هذا التخطيط.

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
````

> 💡 **نصيحة 1:** تُعد شرائح التخطيط قوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **نصيحة 2:** عندما تضيف أشكالًا أو نصًا إلى شريحة التخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط المحتوى المشترك تلقائيًا.  
> الصورة أدناه تُظهر شريحتين، كل منهما يرث مربع نص من نفس شريحة التخطيط.

![الشرائح التي ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط عبر الفهرس أو نوع التخطيط (مثل `Blank`، `Title`، `SectionHeader`، إلخ).

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط محددة إذا لم تعد بحاجة إليها.

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض التقديمي، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شرائح عادية.

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## **نسخ شريحة تخطيط**

يمكنك تكرار شريحة التخطيط باستخدام طريقة `AddClone`.

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **الملخص:** تعد شرائح التخطيط أدوات قوية لإدارة تنسيق موحد عبر الشرائح. يتيح Aspose.Slides التحكم الكامل في إنشاء وإدارة وتحسين شرائح التخطيط.