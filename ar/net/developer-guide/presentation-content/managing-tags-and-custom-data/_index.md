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
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides لـ .NET، مع أمثلة لعروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

توضح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint التقديمية. وتلخص بإيجاز كيف يتم تخزين البيانات في ملفات PPTX، وتذكر أن البيانات الخاصة بالعرض يمكن أن توجد كعلامات وأجزاء XML مخصصة، وتصف العلامات على أنها أزواج سلسلة مفتاح‑قيمة. كما تُظهر كيفية قراءة قيم العلامات وكيفية إضافة العلامات إلى عرض تقديمي أو شريحة فردية أو شكل. بالإضافة إلى ذلك، تغطي المقالة مهام إدارة العلامات الشائعة مثل مسح جميع العلامات، إزالة علامة حسب الاسم، واسترجاع قائمة بأسماء العلامات.

## **تخزين البيانات في ملفات العرض**

تُخزن ملفات PPTX — العناصر ذات الامتداد .pptx — بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية.  

مع اعتبار *الشريحة* أحد عناصر العروض التقديمية، يحتوي جزء الشريحة على محتوى شريحة واحدة. يُسمح لجزء الشريحة أن يكون له علاقات صريحة مع العديد من الأجزاء — مثل العلامات المعرفة من قبل المستخدم — كما هو معرف في ISO/IEC 29500.  

يمكن أن تكون البيانات المخصصة (الخاصة بعرض تقديمي) أو التي يضيفها المستخدم موجودة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/itagcollection)) وأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/icustomxmlpartcollection)).  

{{% alert color="primary" %}} 
العلامات هي في الأساس أزواج قيمة مفتاح‑سلسلة. 
{{% /alert %}} 

## **جلب قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يُظهر هذا المثال البرمجي كيفية الحصول على قيمة العلامة باستخدام Aspose.Slides for .NET للـ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **إضافة علامات إلى العروض**

يمكّنك Aspose.Slides من إضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين: 

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يعرض هذا المثال البرمجي كيفية إضافة علامة إلى الـ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) باستخدام Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/ar/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

أو لأي [Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/shape) فردي:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **القيود**

العلامات المضافة عبر مجموعة `CustomData.Tags` تُخزن فقط داخل ملف PowerPoint. وهي **لا** تُنقل إلى بنية العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع المعرف المخصص المُعيّن كعلامة من ملف PDF المعلَّم.  

**الحل البديل**: يمكنك تخزين معرف مخصص في الخاصية **Alt Text** للكائن (مثال، `shape.AlternativeText = "MyId"`). بعد التصدير إلى PDF، قد تظهر النص البديل في بنية العلامات في ملف PDF.  

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**  
نعم. يدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.  

**كيف أحذف علامة واحدة حسب اسمها دون المرور على المجموعة بأكملها؟**  
استخدم عملية [Remove(name)](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/) لحذف العلامة باستخدام مفتاحها.  

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**  
استخدم [GetNamesOfTags](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/getnamesoftags/) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/net/aspose.slides/tagcollection/); تُعيد مصفوفة تحتوي على جميع أسماء العلامات.