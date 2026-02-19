---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/net/examples/elements/layout-slide/
keywords:
- شريحة تخطيط
- إضافة شريحة تخطيط
- الوصول إلى شريحة تخطيط
- إزالة شريحة تخطيط
- شريحة تخطيط غير مستخدمة
- استنساخ شريحة تخطيط
- مثال شفرة
- باوربوينت
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "شرائح تخطيط رئيسية في Aspose.Slides لـ .NET: اختر، وطبق، وخصص تخطيطات الشرائح، والعناصر النائبة، والماستر باستخدام أمثلة C# لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية العمل مع **Layout Slides** في Aspose.Slides لـ .NET. يُعرّف شريحة التخطيط التصميم والتنسيق الموروثين من الشرائح العادية. يمكنك إضافة، الوصول إلى، استنساخ، وإزالة شرائح التخطيط، وكذلك تنظيف الشرائح غير المستخدمة لتقليل حجم العرض.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق قابل لإعادة الاستخدام. على سبيل المثال، قد تضيف مربع نص يظهر على جميع الشرائح التي تستخدم هذا التخطيط.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // إضافة مربع نص إلى شريحة التخطيط.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // إضافة شريحتين باستخدام هذا التخطيط؛ كلاهما سيورث النص من التخطيط.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **ملاحظة 1:** تُعد شرائح التخطيط قوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.
> 
> 💡 **ملاحظة 2:** عندما تضيف أشكالًا أو نصًا إلى شريحة التخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> توضح اللقطة أدناه شريحتين، كل منهما يرث مربع نص من نفس شريحة التخطيط.

![شرائح وراثة محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط إما بواسطة الفهرس أو بنوع التخطيط (مثل `Blank`، `Title`، `SectionHeader`، إلخ).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // الوصول إلى شريحة تخطيط بحسب الفهرس.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // الوصول إلى شريحة تخطيط بحسب النوع.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط محددة إذا لم تعد بحاجة إليها.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // احصل على شريحة تخطيط بحسب النوع ثم قم بإزالتها.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شرائح عادية.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // يقوم تلقائيًا بإزالة جميع شرائح التخطيط التي لا يُشار إليها من أي شريحة.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **استنساخ شريحة تخطيط**

يمكنك تكرار شريحة تخطيط باستخدام طريقة `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // الحصول على شريحة تخطيط موجودة بحسب النوع.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // استنساخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **الملخص:** شرائح التخطيط أدوات قوية لإدارة تنسيق متسق عبر الشرائح. يتيح Aspose.Slides التحكم الكامل في إنشاء، إدارة، وتحسين شرائح التخطيط.