---
title: تحويل الشريحة
type: docs
weight: 35
url: /ar/java/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- شريحة إلى صورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى بت ماب
- Java
- Aspose.Slides for Java
description: "تحويل شريحة PowerPoint إلى صورة (بت ماب، PNG، أو JPG) في Java"
---

Aspose.Slides for Java يتيح لك تحويل الشرائح (في العروض التقديمية) إلى صور. هذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل شريحة إلى صورة، قم بما يلي:

1. أولاً، قم بتعيين معلمات التحويل وكائنات الشرائح للتحويل باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions).

2. ثانياً، قم بتحويل الشريحة إلى صورة باستخدام الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-).

## **حول بت ماب وتنسيقات الصور الأخرى**

في Java، [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) هو كائن يتيح لك العمل مع الصور المحددة بواسطة بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

طورت Aspose مؤخرًا محولًا عبر الإنترنت [Text to GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **تحويل الشرائح إلى بت ماب وحفظ الصور في PNG**

يعرض هذا الرمز في Java كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب ثم كيفية حفظ الصورة بتنسيق PNG:

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

يعرض هذا الرمز المصدري كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب باستخدام الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-):

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// الحصول على حجم شريحة العرض التقديمي
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// إنشاء Images بحجم الشريحة
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

يمكنك تحويل الشريحة إلى كائن Images ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل الشريحة إلى Images ثم حفظ الصورة بتنسيق JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام تحميل زائد من الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) ، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (الطول والعرض).

يعرض هذا الرمز المصدري عملية التحويل المقترحة باستخدام الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) في Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى بت ماب بالحجم المحدد
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

تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين - [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) و [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) - التي تتيح لك التحكم في عرض شرائح العرض التقديمي إلى صور. تحتوي كلتا الواجهتين على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) التي تتيح لك إضافة ملاحظات وتعليقات إلى الشريحة عند تحويل هذه الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}} 

مع واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions)، يمكنك تحديد موقعك المفضل للملاحظات والتعليقات في الصورة الناتجة.

{{% /alert %}} 

يعرض هذا الرمز في Java عملية التحويل لشريحة تحتوي على ملاحظات وتعليقات:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // إنشاء خيارات العرض
    IRenderingOptions options = new RenderingOptions();

    // تعيين موقع الملاحظات على الصفحة
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // تعيين موقع التعليقات على الصفحة 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // تعيين عرض منطقة إخراج التعليق
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // تعيين اللون لمنطقة التعليقات
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
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

يعرض هذا الرمز في Java عملية التحويل لشريحة مع ملاحظات باستخدام الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) :

``` java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// الحصول على حجم ملاحظات العرض
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// إنشاء خيارات العرض
	IRenderingOptions options = new RenderingOptions();

	// تعيين موقع الملاحظات
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// إنشاء Images بحجم الملاحظات
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

في أي عملية تحويل شريحة إلى صورة، لا يمكن تعيين خاصية [NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) إلى BottomFull (لتحديد الموقع للملاحظات) لأن نص الملاحظة قد يكون كبيرًا، وهو ما يعني أنه قد لا يتناسب مع حجم الصورة المحدد. 

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) لك مزيدًا من التحكم (من حيث المعلمات) على الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم، الدقة، لوحة الألوان، ومعلمات أخرى للصورة الناتجة.

يعرض هذا الرمز في Java عملية تحويل حيث يتم استخدام ITiffOptions لإنتاج صورة بالأبيض والأسود بدقة 300 نقطة في البوصة وحجم 2160 × 2800:

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

	// تعيين موقع الملاحظات على الصفحة
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// تعيين تنسيق البكسل (بالأبيض والأسود)
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// تعيين الدقة
	options.setDpiX(300);
	options.setDpiY(300);

	// تحويل الشريحة إلى كائن بت ماب
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

لا يتم ضمان دعم Tiff في الإصدارات السابقة من JDK 9.

{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

يتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي واحد إلى صور. بشكل أساسي، يمكنك تحويل العرض التقديمي (ككل) إلى صور.

يعرض هذا الرمز المصدري كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور في Java:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // تقديم العرض التقديمي إلى مصفوفة الصور شريحة تلو الأخرى
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // التحكم في الشرائح المخفية (عدم عرض الشرائح المخفية)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // تحويل الشريحة إلى كائن بت ماب
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