---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/net/managing-tags-and-custom-data
keywords: "العلامات، البيانات المخصصة، القيمة للعلامات، إضافة العلامات، عرض باوربوينت، C#، Csharp، Aspose.Slides for .NET"
description: "إضافة العلامات والبيانات المخصصة إلى عروض باوربوينت باستخدام C# أو .NET"
---

## تخزين البيانات في ملفات العروض

تُخزَّن ملفات PPTX، وهي العناصر ذات الامتداد .pptx، في تنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML الهيكلية للبيانات الموجودة في العروض. 

مع كون *الشريحة* واحدة من العناصر في العروض، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء – مثل العلامات المعرفة من قِبل المستخدم – المحددة بموجب ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) وأجزاء CustomXml ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 

العلامات هي في الأساس قيم تتكون من أزواج مفاتيح وسلاسل. 

{{% /alert %}} 

## الحصول على القيم للعلامات

في الشرائح، تتوافق علامة مع خاصية IDocumentProperties.Keywords. يعرض هذا الكود النموذجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for .NET لـ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## إضافة علامات إلى العروض

تسمح Aspose.Slides لك بإضافة علامات إلى العروض. تتكون العلامة عادةً من عنصرين: 

- اسم الميزة المخصصة - `MyTag` 
- قيمة الميزة المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية معينة، فيمكنك الاستفادة من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا كنت تريد تصنيف أو تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكية شمالية ثم تعيين الدول المعنية (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يعرض هذا الكود النموذجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

يمكن أيضًا تعيين العلامات لــ [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

أو لأي [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) فردي:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```