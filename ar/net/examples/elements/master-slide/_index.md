---
title: الشريحة الرئيسية
type: docs
weight: 30
url: /ar/net/examples/elements/master-slide/
keywords:
- شريحة رئيسية
- إضافة شريحة رئيسية
- الوصول إلى شريحة رئيسية
- إزالة شريحة رئيسية
- شريحة رئيسية غير مستخدمة
- مثال على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استكشف أمثلة الشرائح الرئيسية في Aspose.Slides for .NET: إنشاء، تعديل، وتنسيق الشرائح الرئيسية، العناصر النائبة، والسمات في صيغ PPT و PPTX و ODP باستخدام كود C# واضح."
---
تشكل الشرائح الرئيسية المستوى العلوي في تسلسل وراثة الشرائح في PowerPoint. تحدد **الشريحة الرئيسية** عناصر التصميم الشائعة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسية، و**الشرائح العادية** ترث من شرائح التخطيط.

يوضح هذا المقال كيفية إنشاء وتعديل وإدارة الشرائح الرئيسية باستخدام Aspose.Slides for .NET.

## **إضافة شريحة رئيسية**

يوضح هذا المثال كيفية إنشاء شريحة رئيسية جديدة عن طريق استنساخ الشريحة الافتراضية. ثم يضيف شريط عنوان اسم الشركة إلى جميع الشرائح عبر وراثة التخطيط.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // استنساخ الشريحة الرئيسية الافتراضية.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // إضافة لافتة باسم الشركة إلى أعلى الشريحة الرئيسية.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // تعيين الشريحة الرئيسية الجديدة إلى شريحة تخطيط.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // تعيين شريحة التخطيط إلى الشريحة الأولى في العرض التقديمي.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **ملاحظة 1:** توفر الشرائح الرئيسية طريقة لتطبيق العلامة التجارية المتسقة أو عناصر التصميم المشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الشريحة الرئيسية ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة.
> 💡 **ملاحظة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة رئيسية يتم وراثتها بواسطة شرائح التخطيط، وبالتالي جميع الشرائح العادية التي تستخدم تلك التخطيطات.
> تُظهر الصورة أدناه كيف يتم عرض مربع النص المضاف إلى شريحة رئيسية تلقائيًا على الشريحة النهائية.

![مثال وراثة الشريحة الرئيسية](master-slide-banner.png)

## **الوصول إلى شريحة رئيسية**

يمكنك الوصول إلى الشرائح الرئيسية باستخدام مجموعة `Presentation.Masters`. إليك كيفية استرجاعها والعمل معها:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // الوصول إلى الشريحة الرئيسية الأولى.
    var firstMasterSlide = presentation.Masters[0];

    // تغيير نوع الخلفية.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **إزالة شريحة رئيسية**

يمكن إزالة الشرائح الرئيسية إما عن طريق الفهرس أو بالمرجع.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // إزالة شريحة رئيسية بواسطة الفهرس.
    presentation.Masters.RemoveAt(0);

    // إزالة شريحة رئيسية بواسطة المرجع.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **إزالة الشرائح الرئيسية غير المستخدمة**

تحتوي بعض العروض التقديمية على شرائح رئيسية غير مستخدمة. قد يساعد إزالة هذه الشرائح على تقليل حجم الملف.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // إزالة جميع الشرائح الرئيسية غير المستخدمة (حتى تلك التي تم وضع علامة Preserve عليها).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```