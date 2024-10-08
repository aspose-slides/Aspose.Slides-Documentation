---
title: صورة
type: docs
weight: 10
url: /ar/java/image/
description: العمل مع الصور في الشرائح في عروض PowerPoint باستخدام Java. أضف صورًا من القرص أو من الويب في شرائح PowerPoint باستخدام Java. أضف صورًا إلى شرائح الماستر أو كخلفية للشرائح باستخدام Java. أضف SVG إلى عروض PowerPoint باستخدام Java. تحويل SVG إلى أشكال في PowerPoint باستخدام Java. أضف صورًا كـ EMF في الشرائح باستخدام Java.
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية واهتمامًا. في Microsoft PowerPoint، يمكنك إدراج صور من ملف، الإنترنت، أو من مواقع أخرى في الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في العروض التقديمية الخاصة بك من خلال إجراءات مختلفة.

{{% alert  title="نصيحة" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت تريد إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات تنسيق قياسية عليها لتغيير حجمها، إضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصورة](https://docs.aspose.com/slides/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملحوظة" color="warning" %}}

يمكنك التعامل مع عمليات الإدخال/الإخراج التي تتضمن الصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides العمليات مع الصور في هذه التنسيقات الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور على جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يوضح لك نموذج التعليمات البرمجية هذا في Java كيفية إضافة صورة إلى شريحة:

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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متاحة على جهاز الكمبيوتر الخاص بك، يمكنك إضافة الصورة مباشرة من الويب.

يوضح لك نموذج التعليمات البرمجية هذا كيفية إضافة صورة من الويب إلى شريحة في Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[استبدل بالرابط]");
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

## **إضافة صور إلى شرائح الماستر**

شريحة الماستر هي الشريحة العليا التي تخزن وتتحكم في المعلومات (الثيم، التنسيق، إلخ) حول جميع الشرائح تحتها. لذا، عند إضافة صورة إلى شريحة الماستر، ستظهر تلك الصورة في كل شريحة تحت تلك الشريحة.

يوضح لك نموذج التعليمات البرمجية هذا في Java كيفية إضافة صورة إلى شريحة الماستر:

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

## **إضافة صور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، يجب عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تتبع واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يوضح لك نموذج التعليمات البرمجية هذا كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
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
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للعمل مع صور SVG:

![قائمة منبثقة PowerPoint](img_01_01.png)

تتم توفير الوظيفة من خلال أحد التحميلات الزائدة لطريقة [addGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) من واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgImage) كأول وسيط.

يوضح لك نموذج التعليمات البرمجية هذا كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:

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

    // تحويل صورة SVG إلى مجموعة من الأشكال مع ضبطها على حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // حفظ العرض التقديمي في صيغة PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إضافة صور كـ EMF في الشرائح**
يتيح لك Aspose.Slides لـ Java إنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells.

يوضح لك نموذج التعليمات البرمجية هذا كيفية تنفيذ المهمة الموصوفة:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// حفظ دفتر العمل إلى تدفق
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

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [Text to GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، وما إلى ذلك. 

{{% /alert %}}