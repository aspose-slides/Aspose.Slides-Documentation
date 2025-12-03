---
title: تحسين إدارة الصور في العروض التقديمية باستخدام Java
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/java/image/
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Java، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في شرائح العرض**

تجعل الصور العروض التقديمية أكثر جذبًا وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج الصور من ملف أو من الإنترنت أو من أماكن أخرى إلى الشرائح. بالمثل، يتيح Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية عبر إجراءات مختلفة. 

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للمستخدمين بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
إذا أردت إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات التنسيق القياسية لتغيير حجمها، وإضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصورة](https://docs.aspose.com/slides/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 
{{% /alert %}}

يدعم Aspose.Slides عمليات مع الصور بهذه الصيغ الشائعة: JPEG وPNG وGIF وغيرها. 

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو عدة صور من حاسوبك إلى شريحة في عرض تقديمي. يوضح لك رمز العينة هذا في Java كيفية إضافة صورة إلى شريحة:
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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على حاسوبك، يمكنك إضافة الصورة مباشرة من الويب. 
يوضح لك رمز العينة هذا كيفية إضافة صورة من الويب إلى شريحة في Java:
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

قالب الشريحة الرئيسي هو الشريحة العليا التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) لجميع الشرائح تحته. لذلك، عندما تضيف صورة إلى قالب الشريحة الرئيسي، تظهر تلك الصورة على كل شريحة تحت ذلك القالب. 
يوضح لك رمز العينة هذا في Java كيفية إضافة صورة إلى قالب الشريحة الرئيسي:
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


## **إضافة الصور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة محددة أو عدة شرائح. في هذه الحالة، يجب عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام الطريقة [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection). 
لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام الواجهة IPPImage

يوضح لك رمز العينة هذا كيفية تنفيذ الخطوات المذكورة أعلاه لإضافة صورة SVG إلى عرض تقديمي:
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
يوضح تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال شبيهًا بوظيفة PowerPoint المستخدمة للعمل مع صور SVG:

![قائمة منبثقة PowerPoint](img_01_01.png)

توفر هذه الوظيفة إحدى الإصدارات المتعددة للطريقة [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) في الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) التي تأخذ كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) كأول وسيط. 
يوضح لك رمز العينة هذا كيفية استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
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

    // تحويل صورة SVG إلى مجموعة من الأشكال وتكييفها إلى حجم الشريحة
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
يوضح لك رمز العينة هذا كيفية تنفيذ المهمة الموضحة:
```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// حفظ المصنف إلى التدفق
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
يمكّن Aspose.Slides من استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما فيها تلك المستخدمة في أشكال الشرائح). يعرض هذا القسم عدة طرق لتحديث الصور في المجموعة. توفر واجهة برمجة التطبيقات طرقًا بسيطة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة. 

1. حمّل ملف العرض التقديمي الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن.
5. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
6. اكتب العرض التقديمي المعدل كملف PPTX.
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
باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء ملفات GIF من النصوص، وما إلى ذلك. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يظل دقة الصورة الأصلية كما هي بعد الإدراج؟**
نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [الصورة](/slides/ar/java/picture-frame/) في الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**
ضع الشعار على الشريحة الرئيسية أو على تخطيط واستبدله في مجموعة صور العرض التقديمي — ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتحرير؟**
نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الأشكال القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح دفعة واحدة؟**
[عيّن الصورة كخلفية](/slides/ar/java/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب — ستحصل جميع الشرائح التي تستخدم هذا القالب/التخطيط على الخلفية.

**كيف أمنع ازدياد حجم العرض التقديمي بسبب كثرة الصور؟**
أعد استخدام مورد صورة واحد بدلاً من النسخ المتكررة، اختر دقات معقولة، طبق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة على القالب الرئيسي حيثما يلزم.