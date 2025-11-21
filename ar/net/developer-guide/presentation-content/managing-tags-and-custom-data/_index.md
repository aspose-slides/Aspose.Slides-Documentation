---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية في .NET
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/net/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides لـ .NET، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—محفوظة بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* كأحد العناصر في العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة في ISO/IEC 29500. 

يمكن أن توجد بيانات مخصصة (محددة لعرض تقديمي) أو مستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 

العلامات هي في الأساس قيم أزواج المفتاح‑السلسلة. 

{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يوضح هذا المثال البرمجي كيفية الحصول على قيمة العلامة باستخدام Aspose.Slides for .NET لـ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **إضافة علامات إلى العروض التقديمية**

يسمح Aspose.Slides لك بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين: 

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو تجميع جميع العروض من الدول الأمريكية الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يوضح هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
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


## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون iterating عبر المجموعة بأكملها؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/)؛ يعيد مصفوفة بجميع أسماء العلامات.