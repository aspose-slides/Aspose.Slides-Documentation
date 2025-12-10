---
title: تحسين إدارة الصور في العروض التقديمية باستخدام Java
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/java/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة صورة نقطية
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java، تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في شرائح العرض**

الصور تجعل العروض أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى إلى الشرائح. وبالمثل، يتيح Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية من خلال إجراءات مختلفة. 

{{% alert  title="Tip" color="primary" %}} 
Aspose توفر محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—التي تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
إذا كنت تريد إضافة صورة ككائن إطار—وخاصة إذا كنت تنوي استخدام خيارات تنسيق قياسية لتغيير حجمه وإضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصورة](https://docs.aspose.com/slides/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
يمكنك تعديل عمليات الإدخال والإخراج التي تشمل الصور وعروض PowerPoint لتحويل صورة من صيغة إلى أخرى. راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides يدعم عمليات الصور بهذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر إلى شريحة في عرض تقديمي. يُظهر هذا الكود النموذجي في Java كيفية إضافة صورة إلى شريحة:
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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرةً من الويب. 
يُظهر هذا الكود النموذجي كيفية إضافة صورة من الويب إلى شريحة في Java:
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

قالب الشريحة الرئيسي هو الشريحة العلوية التي تخزن وتتحكم في المعلومات (السمة، التصميم، إلخ) لجميع الشرائح تحته. لذلك، عند إضافة صورة إلى القالب الرئيسي، تظهر تلك الصورة على كل شريحة تحته. 
يُظهر هذا الكود النموذجي في Java كيفية إضافة صورة إلى القالب الرئيسي للشرائح:
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

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك مراجعة *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection). 
لإنشاء كائن صورة استنادًا إلى صورة SVG، يمكنك فعل ذلك بهذه الطريقة:
1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage
يُظهر هذا الكود النموذجي كيفية تنفيذ الخطوات السابقة لإضافة صورة SVG إلى عرض تقديمي:
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
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
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه للوظيفة في PowerPoint المستخدمة للعمل مع صور SVG:
![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة أحد الإصدارات الزائدة لطريقة [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) في واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) كأول معطى.
يُظهر هذا الكود النموذجي كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:
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

    // تحويل صورة SVG إلى مجموعة من الأشكال وتحديد حجمها وفق حجم الشريحة
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
يتيح Aspose.Slides for Java إنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF إلى الشرائح باستخدام Aspose.Cells. 
يُظهر هذا الكود النموذجي كيفية تنفيذ المهمة الموصوفة:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//حفظ المصنف إلى التدفق
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
Aspose.Slides يتيح لك استبدال الصور المخزنة في مجموعة صور العرض (بما فيها تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر API طرقًا بسيطة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.
اتبع الخطوات التالية:
1. حمّل ملف العرض الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
1. في النهج الثاني، حمّل الصورة إلى كائن [IImage] واستبدل الصورة المستهدفة بهذا الكائن.
1. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
1. احفظ العرض المعدل كملف PPTX.
```java
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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


{{% alert title="Info" color="info" %}}
باستخدام محول Aspose FREE [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، إنشاء GIFs من النصوص، إلخ. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يبقى دقة الصورة الأصلية سليمة بعد الإدراج؟**

نعم. يتم الحفاظ على بيكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية مقياس [الصورة](/slides/ar/java/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عدة عشرات من الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على تخطيط واستبدله في مجموعة صور العرض—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخلة إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/java/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب—ستُورث أي شرائح تستخدم ذلك القالب الخلفية.

**كيف يمكنني منع زيادة حجم العرض التقديمي بسبب الكثير من الصور؟**

أعد استخدام مورد صورة واحدة بدلاً من التكرارات، اختر دقات معقولة، طبّق الضغط عند الحفظ، واحتفظ بالرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.