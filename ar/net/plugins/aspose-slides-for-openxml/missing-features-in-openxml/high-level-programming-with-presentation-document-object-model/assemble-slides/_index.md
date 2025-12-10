---
title: تجميع الشرائح
type: docs
weight: 10
url: /ar/net/assemble-slides/
---

## **إضافة شريحة إلى عرض تقديمي**
قبل الحديث عن إضافة الشرائح إلى ملفات العروض التقديمية، دعونا نناقش بعض الحقائق حول الشرائح. كل ملف عرض تقديمي PowerPoint يحتوي على شريحة رئيسية/تصميمية وشُرائح عادية أخرى. هذا يعني أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for .NET. كل شريحة لها معرف فريد وجميع الشرائح العادية مرتبة حسب ترتيب يُحدد بواسطة الفهرس الصفري.

يسمح Aspose.Slides for .NET للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة **Presentation**
- إنشاء فئة **SlideCollection** عن طريق تعيين إشارة إلى الخاصية Slides (مجموعة من كائنات Slide المحتوى) التي تكشف عنها كائن Presentation
- إضافة شريحة فارغة إلى العرض في نهاية مجموعة شرائح المحتوى عن طريق استدعاء طريقة **AddEmptySlide** المكشوفة بواسطة كائن **SlideCollection**
- قم ببعض الأعمال مع الشريحة الفارغة التي تم إضافتها حديثاً
- أخيراً، احفظ ملف العرض باستخدام كائن **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

``` 
## **الوصول إلى شرائح العرض**
يوفر Aspose.Slides for .NET فئة Presentation التي يمكن استخدامها للبحث والوصول إلى أي شريحة مرغوبة موجودة في العرض.

**استخدام مجموعة الشرائح**

فئة **Presentation** تمثل ملف عرض وتكشف عن جميع الشرائح فيه كـ مجموعة **SlideCollection** (وهي مجموعة من كائنات **Slide**). يمكن الوصول إلى جميع هذه الشرائح من مجموعة **Slides** باستخدام فهرس الشريحة.

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **إزالة الشرائح**
نعلم أن فئة Presentation في **Aspose.Slides for .NET** تمثل ملف عرض تقديمي. فئة Presentation تضم **SlideCollection** التي تعمل كمستودع لجميع الشرائح التي هي جزء من العرض. يمكن للمطورين إزالة شريحة من مجموعة الشرائح هذه بطريقتين:

- باستخدام إشارة الشريحة
- باستخدام فهرس الشريحة

**باستخدام إشارة الشريحة**

لإزالة شريحة باستخدام إشارة لها، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة Presentation
- الحصول على إشارة شريحة باستخدام معرفها أو فهرسها
- إزالة الشريحة المشار إليها من العرض
- حفظ ملف العرض المعدل

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

``` 
## **تغيير موضع الشريحة**
من السهل جداً تغيير موضع شريحة في العرض. فقط اتبع الخطوات أدناه:

- إنشاء مثال من فئة Presentation
- الحصول على إشارة شريحة باستخدام فهرستها
- تغيير قيمة SlideNumber للشريحة المشار إليها
- حفظ ملف العرض المعدل

في المثال أدناه، قمنا بتغيير موضع شريحة (الموجودة في الفهرس الصفري الموضع 1) من العرض إلى الفهرس 1 (الموضع 2).

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

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **تنزيل الكود النموذجي**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)