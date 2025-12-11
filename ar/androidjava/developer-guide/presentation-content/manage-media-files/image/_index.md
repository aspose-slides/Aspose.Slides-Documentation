---
title: تحسين إدارة الصور في العروض التقديمية على Android
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/androidjava/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة Bitmap
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
description: "تبسيط إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في شرائح العرض**

تجعل الصور العروض التقديمية أكثر جذبًا وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة صور إلى الشرائح في عروضك عبر إجراءات مختلفة. 

{{% alert title="نصيحة" color="primary" %}} 
Aspose توفر محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للأشخاص بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}
إذا أردت إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمه، إضافة تأثيرات، وما إلى ذلك—اطلع على [Picture Frame](https://docs.aspose.com/slides/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}
يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/). 
{{% /alert %}}

يدعم Aspose.Slides عمليات التعامل مع الصور في هذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر إلى شريحة في العرض. يوضح لك هذا المثال البرمجي بلغة Java كيفية إضافة صورة إلى شريحة:
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


## **إضافة صور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرةً من الويب. 

يظهر لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة باستخدام Java:
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


## **إضافة صور إلى قوالب الشرائح (Slide Masters)**

قالب الشريحة هو الشريحة العلوية التي تخزن وتتحكم في معلومات (السمة، التخطيط، الخ) لجميع الشرائح تحته. لذلك، عندما تضيف صورة إلى قالب شريحة، تظهر تلك الصورة على كل شريحة ضمن ذلك القالب. 

يظهر لك هذا المثال البرمجي بلغة Java كيفية إضافة صورة إلى قالب شريحة:
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


## **إضافة صور كخلفيات للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة محددة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*. 

## **إضافة SVG إلى العروض التقديمية**

يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection). 

لإنشاء كائن صورة يعتمد على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection  
2. إنشاء كائن PPImage من ISvgImage  
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage  

يظهر لك هذا المثال البرمجي كيفية تنفيذ الخطوات السابقة لإضافة صورة SVG إلى عرض تقديمي:
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

تحويل Aspose.Slides للـ SVG إلى مجموعة من الأشكال مشابه للوظيفة الموجودة في PowerPoint للتعامل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

يتم توفير هذه الوظيفة عبر أحد التحميلات المتعددة لطريقة [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) في واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) كأول وسائط. 

يظهر لك هذا المثال البرمجي كيفية استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
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

    // تحويل صورة SVG إلى مجموعة من الأشكال مع تعديل حجمها لتناسب حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // حفظ العرض التقديمي بتنسيق PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **إضافة صور بصيغة EMF إلى الشرائح**

يتيح Aspose.Slides للـ Android عبر Java إنشاء صور EMF من أوراق Excel وإضافة هذه الصور بصيغة EMF إلى الشرائح باستخدام Aspose.Cells.  

يظهر لك هذا المثال البرمجي كيفية تنفيذ المهمة الواردة:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//حفظ المصنف إلى تدفق
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


## **استبدال الصور في مجموعة الصور (Image Collection)**

يسمح لك Aspose.Slides باستبدال الصور المخزنة في مجموعة صور العرض (بما في ذلك تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر الـ API طرقًا مباشرة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/)، أو صورة أخرى موجودة مسبقًا في المجموعة. 

اتبع الخطوات أدناه:

1. تحميل ملف العرض الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.  
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.  
4. في الأسلوب الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) واستبدال الصورة المستهدفة بذلك الكائن.  
5. في الأسلوب الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.  
6. كتابة العرض المعدل كملف PPTX.  
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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
باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، إنشاء ملفات GIF من النصوص، إلخ. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يبقى دقة الصورة الأصلية كما هي بعد الإدراج؟**  
نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية قياس [الصورة](/slides/ar/androidjava/picture-frame/) على الشريحة وأي ضغط يتم تطبيقه عند الحفظ.  

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**  
ضع الشعار على القالب الرئيسي أو التخطيط واستبدله في مجموعة صور العرض—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.  

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتحرير؟**  
نعم. يمكنك تحويل SVG إلى مجموعة أشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.  

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**  
[تعيين الصورة كخلفية](/slides/ar/androidjava/presentation-background/) على القالب الرئيسي أو التخطيط المناسب—ستُورث الخلفية إلى جميع الشرائح التي تستخدم ذلك القالب/التخطيط.  

**كيف أمنع تضخم حجم العرض بسبب كثرة الصور؟**  
أعد استخدام مورد صورة واحد بدلاً من تكراره، اختر دقات معقولة، طبق الضغط عند الحفظ، واحتفظ بالرسومات المتكررة على القالب عندما يكون ذلك مناسبًا.