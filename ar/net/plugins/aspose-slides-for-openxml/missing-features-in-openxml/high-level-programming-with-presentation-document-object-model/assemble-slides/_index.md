---
title: تجميع الشرائح
type: docs
weight: 10
url: /ar/net/assemble-slides/
---

## **إضافة شريحة إلى عرض تقديمي**
قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. كل ملف عرض تقديمي من PowerPoint يحتوي على شريحة رئيسية/تخطيط وشريحة عادية أخرى. هذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التقديمي التي لا تحتوي على شرائح غير مدعومة من Aspose.Slides for .NET. كل شريحة لها معرف فريد وتُرتب جميع الشرائح العادية وفقًا لفهرس يبدأ من الصفر.

يسمح Aspose.Slides for .NET للمطورين بإضافة شرائح فارغة إلى العرض التقديمي. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة **Presentation**
- إنشاء فئة **SlideCollection** عن طريق تعيين مرجع إلى الخاصية Slides (مجموعة كائنات Slide المحتوى) التي تُعرض بواسطة كائن Presentation.
- إضافة شريحة فارغة إلى عرض التقديم في نهاية مجموعة الشرائح المحتوى عبر استدعاء طريقة **AddEmptySlide** التي تُعرض بواسطة كائن **SlideCollection**
- إجراء بعض الأعمال باستخدام الشريحة الفارغة التي تم إضافتها حديثًا
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن **Presentation**

``` csharp
 PresentationEx pres = new PresentationEx();

 //إنشاء كائن من الفئة SlideCollection
 SlideExCollection slds = pres.Slides;

 for (int i = 0; i < pres.LayoutSlides.Count; i++)
 {
     //إضافة شريحة فارغة إلى مجموعة الشرائح
     slds.AddEmptySlide(pres.LayoutSlides[i]);
 }

 //حفظ ملف PPTX إلى القرص
 pres.Write("EmptySlide.pptx");
``` 
## **الوصول إلى شرائح العرض التقديمي**
يوفر Aspose.Slides for .NET فئة Presentation التي يمكن استخدامها للعثور على أي شريحة مرغوبة والوصول إليها داخل العرض التقديمي.

**استخدام مجموعة الشرائح**

تمثل فئة **Presentation** ملف عرض تقديمي وتُظهر جميع الشرائح فيه كـ **SlideCollection** (وهي مجموعة من كائنات **Slide**). يمكن الوصول إلى جميع هذه الشرائح من خلال مجموعة **Slides** باستخدام فهرس الشريحة.

``` csharp
 //إنشاء كائن Presentation يمثل ملف عرض تقديمي
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 //الوصول إلى شريحة باستخدام فهرسها
 SlideEx slide = pres.Slides[0];
``` 
## **إزالة الشرائح**
نعلم أن فئة Presentation في **Aspose.Slides for .NET** تمثل ملف عرض تقديمي. تُغلق فئة Presentation مجموعة **SlideCollection** التي تعمل كمستودع لجميع الشرائح التي تشكل جزءًا من العرض. يمكن للمطورين إزالة شريحة من مجموعة الشرائح بطريقتين:

- باستخدام مرجع الشريحة
- باستخدام فهرس الشريحة

**باستخدام مرجع الشريحة**

لإزالة شريحة باستخدام مرجعها، يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع شريحة باستخدام معرفها Id أو فهرسها Index
- إزالة الشريحة المرجعية من العرض التقديمي
- كتابة ملف العرض التقديمي المعدل

``` csharp
 //إنشاء كائن Presentation يمثل ملف عرض تقديمي
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 //الوصول إلى شريحة باستخدام فهرسها في مجموعة الشرائح
 SlideEx slide = pres.Slides[0];

 //إزالة شريحة باستخدام مرجعها
 pres.Slides.Remove(slide);

 //كتابة ملف العرض التقديمي
 pres.Write("modified.pptx");
``` 
## **تغيير موضع الشريحة**
من السهل جدًا تغيير موضع الشريحة في العرض التقديمي. ما عليك سوى اتباع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع شريحة باستخدام فهرسها Index
- تغيير خاصية SlideNumber للشريحة المرجعية
- كتابة ملف العرض التقديمي المعدل

في المثال أدناه، قمنا بتغيير موضع شريحة (الواقعة في الفهرس الصفري 0) إلى الفهرس 1 (الموضع 2).

``` csharp
 private static string MyDir = @"..\..\..\Sample Files\";

 static void Main(string[] args)
 {
     AddingSlidetoPresentation();
     AccessingSlidesOfPresentation();
     RemovingSlides();
     ChangingPositionOfSlide();
 }

 public static void AddingSlidetoPresentation()
 {
     Presentation pres = new Presentation();
     //إنشاء كائن SlideCollection
     ISlideCollection slds = pres.Slides;
     for (int i = 0; i < pres.LayoutSlides.Count; i++)
     {
         //إضافة شريحة فارغة إلى مجموعة الشرائح
         slds.AddEmptySlide(pres.LayoutSlides[i]);
     }
     //حفظ ملف PPTX إلى القرص
     pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
 }

 public static void AccessingSlidesOfPresentation()
 {
     //إنشاء كائن Presentation يمثل ملف عرض تقديمي
     Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
     //الوصول إلى شريحة باستخدام فهرسها
     ISlide slide = pres.Slides[0];
 }

 public static void RemovingSlides()
 {
     //إنشاء كائن Presentation يمثل ملف عرض تقديمي
     Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
     //الوصول إلى شريحة باستخدام فهرسها في مجموعة الشرائح
     ISlide slide = pres.Slides[0];
     //إزالة شريحة باستخدام مرجعها
     pres.Slides.Remove(slide);
     //حفظ ملف العرض التقديمي
     pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
 }

 public static void ChangingPositionOfSlide()
 {
     //إنشاء كائن Presentation لتحميل ملف العرض المصدر
     Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
     {
         //الحصول على الشريحة التي سيُغيّر موضعها
         ISlide sld = pres.Slides[0];
         //تعيين الموضع الجديد للشريحة
         sld.SlideNumber = 2;
         //حفظ العرض إلى القرص
         pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
     }
 }
``` 
## **تنزيل شفرة المثال**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)