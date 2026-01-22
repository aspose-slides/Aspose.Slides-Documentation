---
title: تحسين إدارة الصور في العروض التقديمية على Android
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/androidjava/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة بت ماب
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، وتحسين الأداء وأتمتة سير عملك."
---

## **الصور في شرائح العرض**

الصور تجعل العروض التقديمية أكثر جذبًا وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. بالمثل، يتيح لك Aspose.Slides إضافة صور إلى الشرائح في عروضك عبر إجراءات مختلفة. 

{{% alert  title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت تريد إضافة صورة ككائن إطار—خاصةً إذا كنت تخطط لاستخدام خيارات التنسيق القياسية لتغيير حجمها، وإضافة تأثيرات، وما إلى ذلك—انظر إلى [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/). 

{{% /alert %}} 

يدعم Aspose.Slides العمليات مع الصور بهذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر إلى شريحة في عرض تقديمي. يُظهر لك هذا المثال البرمجي في Java كيفية إضافة صورة إلى شريحة:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **إضافة الصور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرة من الويب. 

يُظهر لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة في Java:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **إضافة الصور إلى القوالب الرئيسية للشرائح**

قالب الشريحة الرئيسي هو الشريحة العليا التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) جميع الشرائح تحته. لذا، عندما تضيف صورة إلى القالب الرئيسي، تظهر تلك الصورة على كل شريحة تحت هذا القالب. 

يُظهر لك هذا المثال البرمجي في Java كيفية إضافة صورة إلى القالب الرئيسي:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **إضافة الصور كخلفيات للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[إعداد الصور كخلفيات للشرائح](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*. 

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام الطريقة [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection). 

لإنشاء كائن صورة يعتمد على صورة SVG، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يُظهر لك هذا المثال البرمجي كيفية تنفيذ الخطوات المذكورة لإضافة صورة SVG إلى عرض تقديمي:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل SVG إلى مجموعة من الأشكال**
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للعمل مع صور SVG:

![قائمة منبثقة في PowerPoint](img_01_01.png)

توفر الوظيفة عبر أحد التحميلات الزائدة للطريقة [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) من واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) التي تقبل كائن [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) كأول وسيط. 

يُظهر لك هذا المثال البرمجي كيفية استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
```java 
// إنشاء عرض تقديمي جديد
IPresentation presentation = new Presentation();
try {
    // قراءة محتوى ملف SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // إنشاء كائن SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // الحصول على حجم الشريحة
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتناسب حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // حفظ العرض التقديمي بصيغة PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **إضافة الصور كـ EMF إلى الشرائح**
يتيح Aspose.Slides for Android عبر Java إمكانية إنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells.  

يُظهر لك هذا المثال البرمجي كيفية تنفيذ المهمة الموصوفة:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Save the workbook to stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **استبدال الصور في مجموعة الصور**

يسمح لك Aspose.Slides باستبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة طرق لتحديث الصور في المجموعة. توفر API طرقًا مباشرة لاستبدال صورة باستخدام بيانات بايتية خام، أو كائن [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات أدناه:

1. تحميل ملف العرض التقديمي الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة الهدف بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) واستبدال الصورة الهدف بهذا الكائن.
5. في النهج الثالث، استبدال الصورة الهدف بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
6. كتابة العرض التقديمي المعدل كملف PPTX.

```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // الطريقة الثانية.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // الطريقة الثالثة.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // حفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose FREE [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، وإنشاء ملفات GIF من النصوص، وما إلى ذلك. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل تبقى دقة الصورة الأصلية سليمة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [الصورة](/slides/ar/androidjava/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح دفعة واحدة؟**

ضع الشعار على القالب الرئيسي أو على تخطيط، واستبدله في مجموعة صور العرض التقديمي—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني ضبط صورة كخلفية لعدة شرائح في وقت واحد؟**

[تعيين الصورة كخلفية](/slides/ar/androidjava/presentation-background/) على القالب الرئيسي أو التخطيط المقصود—ستورث أي شريحة تستخدم ذلك القالب/التخطيط الخلفية.

**كيف أمنع زيادة حجم العرض التقديمي بشكل كبير بسبب وجود الكثير من الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتعددة، اختر دقات معقولة، طبّق ضغطًا عند الحفظ، واحفظ الرسوم المتكررة على القالب حيثما كان ذلك مناسبًا.