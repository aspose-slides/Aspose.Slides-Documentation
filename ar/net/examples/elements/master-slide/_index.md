---
title: شريحة رئيسية
type: docs
weight: 30
url: /ar/net/examples/elements/master-slide/
keywords:
- مثال شريحة رئيسية
- إضافة شريحة رئيسية
- الوصول إلى شريحة رئيسية
- إزالة شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة الشرائح الرئيسة في C# باستخدام Aspose.Slides: إنشاء، تعديل، استنساخ، وتنسيق القوالب والخلفيات وعناصر الحجز لتوحيد الشرائح في PowerPoint وOpenDocument."
---

تشكل الشرائح الرئيسة المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **الشريحة الرئيسة** تُعرّف عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسة، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء الشرائح الرئيسة وتعديلها وإدارتها باستخدام Aspose.Slides للـ .NET.

## إضافة شريحة رئيسية

يُظهر هذا المثال كيفية إنشاء شريحة رئيسة جديدة عن طريق استنساخ الشريحة الرئيسة الافتراضية. ثم يضيف شعارًا باسم الشركة إلى جميع الشرائح عبر وراثة التخطيط.

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **نصيحة 1:** توفر الشرائح الرئيسة طريقة لتطبيق العلامة التجارية المتسقة أو عناصر التصميم المشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الشريحة الرئيسة ستنعكس تلقائيًا على الشرائح التخطيطية والشرائح العادية التابعة لها.

> 💡 **نصيحة 2:** أي شكل أو تنسيق يُضاف إلى شريحة رئيسة يُورّث إلى شرائح التخطيط، ومن ثم إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات.  
> الصورة أدناه توضح كيف يتم عرض مربع نص يُضاف إلى شريحة رئيسة تلقائيًا على الشريحة النهائية.

![مثال على وراثة الشريحة الرئيسية](master-slide-banner.png)

## الوصول إلى شريحة رئيسية

يمكنك الوصول إلى الشرائح الرئيسة باستخدام مجموعة `Presentation.Masters`. إليك كيفية استرجاعها والعمل معها:

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## حذف شريحة رئيسية

يمكن حذف الشرائح الرئيسة إما حسب الفهرس أو حسب الإشارة.

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## حذف الشرائح الرئيسة غير المستخدمة

بعض العروض التقديمية تحتوي على شرائح رئيسة غير مستعملة. حذف هذه الشرائح يمكن أن يساعد في تقليل حجم الملف.

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **نصيحة:** استخدم `RemoveUnused(true)` لتنظيف الشرائح الرئيسة غير المستخدمة وتقليل حجم العرض التقديمي.