---
title: تجميع الشرائح
type: docs
weight: 10
url: /ar/net/assemble-slides/
---

تغطي الميزات التالية:
## **إضافة شريحة إلى العرض التقديمي**
قبل التحدث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي من PowerPoint على شريحة رئيسية / تخطيط بالإضافة إلى شرائح عادية أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم أن نعرف أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides لـ .NET. تحتوي كل شريحة على معرف فريد وجميع الشرائح العادية مرتبة وفقًا لترتيب محدد بواسطة فهرس يبدأ من الصفر.

يتيح Aspose.Slides لـ .NET للمطورين إضافة شرائح فارغة إلى العرض التقديمي الخاص بهم. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة **Presentation**
- إنشاء مثيل من فئة **SlideCollection** عن طريق تعيين مرجع إلى خاصية Slides (مجموعة من كائنات شريحة المحتوى) المعروضة بواسطة كائن Presentation.
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوية عن طريق استدعاء طرق **AddEmptySlide** المعروضة بواسطة كائن **SlideCollection**
- القيام ببعض الأعمال مع الشريحة الفارغة المضافة حديثًا
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//إنشاء مثيل لفئة SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//إضافة شريحة فارغة إلى مجموعة الشرائح

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//حفظ ملف PPTX على القرص

pres.Write("EmptySlide.pptx");

``` 
## **الوصول إلى شرائح العرض التقديمي**
يوفر Aspose.Slides لـ .NET فئة Presentation التي يمكن استخدامها للعثور على أي شريحة مرغوبة والوصول إليها الموجودة في العرض التقديمي.

**استخدام مجموعة الشرائح**

تمثل فئة **Presentation** ملف عرض تقديمي وتعرض جميع الشرائح التي تحتويها كـ **SlideCollection** (وهي مجموعة من كائنات **Slide**). يمكن الوصول إلى جميع هذه الشرائح من هذه المجموعة **Slides** باستخدام فهرس شريحة.

``` csharp

 //إنشاء كائن Presentation يمثل ملف عرض تقديمي

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//الوصول إلى شريحة باستخدام فهرس الشريحة

SlideEx slide = pres.Slides[0];

``` 
## **إزالة الشرائح**
نعلم أن فئة Presentation في **Aspose.Slides لـ .NET** تمثل ملف عرض تقديمي. تقوم فئة Presentation بتغليف **SlideCollection** التي تعمل كمستودع لجميع الشرائح التي هي جزء من العرض التقديمي. يمكن للمطورين إزالة شريحة من مجموعة الشرائح هذه بعدة طرق:

- باستخدام مرجع الشريحة
- باستخدام فهرس الشريحة

**استخدام مرجع الشريحة**

لإزالة شريحة باستخدام مرجعها، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع لشريحة باستخدام معرفها أو فهرسها
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
## **تغيير موضع الشريحة:**
من السهل جدًا تغيير موضع شريحة في العرض التقديمي. فقط اتبع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع لشريحة باستخدام فهرسها
- تغيير SlideNumber للشريحة المرجعية
- كتابة ملف العرض التقديمي المعدل

في المثال الموضح أدناه، قمنا بتغيير موضع شريحة (توجد في فهرس صفر الموضع 1) من العرض التقديمي إلى فهرس 1 (الموضع 2).

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

//إنشاء مثيل لفئة SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //إضافة شريحة فارغة إلى مجموعة الشرائح

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//حفظ ملف PPTX على القرص

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//إنشاء كائن Presentation يمثل ملف عرض تقديمي

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//الوصول إلى شريحة باستخدام فهرس شريحة

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

//كتابة ملف العرض التقديمي

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //الحصول على الشريحة التي يجب تغيير موضعها

    ISlide sld = pres.Slides[0];

    //تعيين الموقف الجديد للشريحة

    sld.SlideNumber = 2;

    //كتابة العرض التقديمي على القرص

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **تحميل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)