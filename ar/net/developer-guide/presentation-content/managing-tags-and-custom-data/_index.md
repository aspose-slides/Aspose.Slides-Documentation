---
title: إدارة الوسوم والبيانات المخصصة في العروض التقديمية في .NET
linktitle: الوسوم والبيانات المخصصة
type: docs
weight: 300
url: /ar/net/managing-tags-and-custom-data/
keywords:
- خصائص الوثيقة
- وسم
- بيانات مخصصة
- إضافة وسم
- قيم أزواج
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة الوسوم والبيانات المخصصة في Aspose.Slides لـ .NET، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

تُخزن ملفات PPTX—العناصر ذات الامتداد .pptx—بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML البنية للبيانات الموجودة في العروض التقديمية. 

مع اعتبار *slide* أحد عناصر العروض التقديمية، يحتوي *slide part* على محتوى شريحة واحدة. يُسمح لـ slide part بوجود علاقات صريحة مع العديد من الأجزاء—مثل User Defined Tags—المحددة حسب ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (المحددة لعرض تقديمي) أو المستخدم كوسوم ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
الوسوم هي أساسًا قيم أزواج مفتاح-سلسلة. 
{{% /alert %}} 

## **الحصول على قيم الوسوم**

في الشرائح، يتطابق الوسم مع الخاصية IDocumentProperties.Keywords. يوضح هذا المثال البرمجي كيفية الحصول على قيمة وسم باستخدام Aspose.Slides for .NET لـ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **إضافة وسوم إلى العروض التقديمية**

يسمح Aspose.Slides لك بإضافة وسوم إلى العروض التقديمية. يتكون الوسم عادةً من عنصرين: 

- اسم خاصية مخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فستستفيد من إضافة وسوم إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء وسم أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يظهر هذا المثال البرمجي كيفية إضافة وسم إلى [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


يمكن أيضًا تعيين الوسوم لـ [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide):
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

**هل يمكنني إزالة جميع الوسوم من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح–القيمة مرة واحدة.

**كيف أحذف وسمًا واحدًا باسمه دون التجول عبر مجموعة الوسوم بالكامل؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) لحذف الوسم بمفتاحه.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء الوسوم للتحليل أو التصفية؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); تُرجع مصفوفة تحتوي على جميع أسماء الوسوم.