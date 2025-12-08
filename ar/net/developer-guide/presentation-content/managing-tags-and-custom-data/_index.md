---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/net/managing-tags-and-custom-data
keywords: "علامات, بيانات مخصصة, قيمة للعلامات, إضافة علامات, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة علامات وبيانات مخصصة إلى عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تخزين البيانات في ملفات العرض**

يتم تخزين ملفات PPTX—العناصر ذات الامتداد .pptx—في تنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML هيكل البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* أحد عناصر العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يسمح لجزء الشريحة أن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—التي تعرفها ISO/IEC 29500. 

يمكن أن توجد بيانات مخصصة (محددة لعروض تقديمية) أو للمستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
العلامات هي أساسًا قيم زوجية من السلسلة والمفتاح. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يوضح لك هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for .NET ل[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **إضافة علامات إلى العروض التقديمية**

تتيح لك Aspose.Slides إضافة العلامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين: 

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة العلامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو جمع كل العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يوضح لك هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


يمكن أيضًا تعيين العلامات لـ[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


أو لأي [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف يمكنني حذف علامة واحدة باسمها دون التجول عبر المجموعة بأكملها؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرداد القائمة الكاملة لأسماء العلامات للتحليل أو الفلترة؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); تُعيد مصفوفة بجميع أسماء العلامات.