---
title: تحويل الشريحة
type: docs
weight: 35
url: /ar/androidjava/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى بتMapped 
- Java
- Aspose.Slides لـ Android عبر Java
description: "تحويل شريحة PowerPoint إلى صورة (Bitmap، PNG، أو JPG) في Java"
---

Aspose.Slides لـ Android عبر Java يتيح لك تحويل الشرائح (في العروض التقديمية) إلى صور. هذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. أولاً، قم بتعيين معلمات التحويل وأجسام الشرائح التي ترغب في تحويلها باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions).

2. ثانيًا، قم بتحويل الشريحة إلى صورة باستخدام طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) .

## **حول Bitmap وغيرها من تنسيقات الصور**

في Java، [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) هي كائن يتيح لك العمل مع الصور المحددة بناءً على بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

طورت Aspose مؤخرًا أداة تحويل عبر الإنترنت [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **تحويل الشرائح إلى Bitmap وحفظ الصور بتنسيق PNG**

هذا الكود في Java يظهر لك كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن bitmap ثم كيفية حفظ الصورة بتنسيق PNG:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن Images
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// حفظ الصورة بتنسيق PNG
	try {
        // حفظ الصورة على القرص.
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

هذا الكود النموذجي يظهر لك كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن bitmap باستخدام طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// الحصول على حجم الشريحة في العرض التقديمي
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// إنشاء كائن Images بحجم الشريحة
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // حفظ الصورة على القرص.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}} 

يمكنك تحويل شريحة إلى كائن Images ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل شريحة إلى Images ثم حفظ الصورة بتنسيق JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام تحميل زائد من طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) ، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (الطول والعرض).

هذا الكود النموذجي يوضح عملية التحويل المقترحة باستخدام طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) في Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى Bitmap بحجم معين
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// حفظ الصورة بتنسيق JPEG
	try {
         // حفظ الصورة على القرص.
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح تحتوي على ملاحظات وتعليقات. 

يوفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) و[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)—تتيح لك التحكم في تقديم الشرائح إلى صور. كلتا الواجهتين تحتويان على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) التي تتيح لك إضافة ملاحظات وتعليقات على شريحة عند تحويل تلك الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}} 

مع واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) ، يمكنك تحديد موضعك المفضل للملاحظات والتعليقات في الصورة الناتجة.

{{% /alert %}} 

هذا الكود في Java يوضح عملية التحويل لشريحة تحتوي على ملاحظات وتعليقات:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // إنشاء خيارات العرض
    IRenderingOptions options = new RenderingOptions();

    // تعيين موضع الملاحظات على الصفحة
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // تعيين موضع التعليقات على الصفحة 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // تعيين عرض منطقة إخراج التعليقات
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // تعيين لون منطقة التعليقات
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // تحويل الشريحة الأولى من العرض التقديمي إلى كائن Bitmap
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // حفظ الصورة بتنسيق GIF
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

هذا الكود في Java يوضح عملية التحويل لشريحة تحتوي على ملاحظات باستخدام طريقة [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// الحصول على حجم ملاحظات العرض التقديمي
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// إنشاء خيارات العرض
	IRenderingOptions options = new RenderingOptions();

	// تعيين موضع الملاحظات
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// إنشاء كائن Images بحجم الملاحظات
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// حفظ الصورة بتنسيق PNG
    try {
         // حفظ الصورة على القرص.
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن تعيين خاصية [NotesPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) إلى BottomFull (لتحديد الموضع للملاحظات) لأن نص الملاحظة قد يكون كبيرًا، مما يعني أنه قد لا يناسب الحجم المحدد للصورة.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

واجهة [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions) تعطيك المزيد من التحكم (من حيث المعلمات) على الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم، الدقة، لوحة الألوان، ومعلمات أخرى للصورة الناتجة.

هذا الكود في Java يوضح عملية تحويل حيث يتم استخدام ITiffOptions لإنتاج صورة بالأبيض والأسود بدقة 300dpi وحجم 2160 × 2800:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// الحصول على شريحة بواسطة فهرسها
	ISlide slide = pres.getSlides().get_Item(0);

	// إنشاء كائن TiffOptions
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// تعيين الخط المستخدم في حالة عدم العثور على الخط المصدر
	options.setDefaultRegularFont("Arial Black");

	// تعيين موضع الملاحظات على الصفحة
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// تعيين تنسيق البكسل (أبيض وأسود)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// تعيين الدقة
	options.setDpiX(300);
	options.setDpiY(300);

	// تحويل الشريحة إلى كائن Bitmap
	IImage slideImage = slide.getImage(options);

	// حفظ الصورة بتنسيق TIFF
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

دعم Tiff ليس مضمونًا في النسخ السابقة لـ JDK 9.

{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

يتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي واحد إلى صور. في الأساس، يمكنك تحويل العرض التقديمي (بكامل الجملة) إلى صور. 

هذا الكود النموذجي يوضح لك كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // عرض العرض التقديمي إلى مصفوفة من الصور شريحة تلو الأخرى
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // التحكم في الشرائح المخفية (لا تعرض الشرائح المخفية)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // تحويل الشريحة إلى كائن Bitmap
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // حفظ الصورة بتنسيق PNG
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```