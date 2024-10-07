---
title: صورة
type: docs
weight: 10
url: /androidjava/image/
description: العمل مع الصور في الشرائح في العروض التقديمية PowerPoint باستخدام Java. إضافة صور من القرص أو من الويب في شرائح PowerPoint باستخدام Java. إضافة صور إلى الشرائح الرئيسية أو كخلفية للشرائح باستخدام Java. إضافة SVG إلى العرض التقديمي PowerPoint باستخدام Java. تحويل SVG إلى أشكال في PowerPoint باستخدام Java. إضافة صور كـ EMF في الشرائح باستخدام Java.
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جذبًا واهتمامًا. في Microsoft PowerPoint، يمكنك إدراج صور من ملف، الإنترنت، أو مواقع أخرى إلى الشرائح. بالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في العروض التقديمية عبر إجراءات مختلفة.

{{% alert  title="نصيحة" color="primary" %}}

يوفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للأشخاص بإنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}}

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات تنسيق قياسية عليها لتغيير حجمها، إضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصور](https://docs.aspose.com/slides/androidjava/picture-frame/).

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}}

يمكنك معالجة عمليات الإدخال/الإخراج التي تتضمن الصور والعروض التقديمية PowerPoint لتحويل صورة من تنسيق إلى آخر. انظر لهذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides العمليات مع الصور في هذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها.

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور على جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يعرض الكود العيّني في Java كيفية إضافة صورة إلى شريحة:

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

إذا كانت الصورة التي ترغب في إضافتها إلى شريحة غير متاحة على جهاز الكمبيوتر لديك، يمكنك إضافة الصورة مباشرة من الويب.

يعرض الكود العيّني كيفية إضافة صورة من الويب إلى شريحة في Java:

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

## **إضافة صور إلى الشرائح الرئيسية**

تعد الشريحة الرئيسية هي الشريحة العلوية التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) لجميع الشرائح تحتها. لذا، عندما تضيف صورة إلى شريحة رئيسية، ستظهر تلك الصورة في كل شريحة تحت تلك الشريحة الرئيسية.

يعرض الكود العيّني في Java كيفية إضافة صورة إلى شريحة رئيسية:

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

يمكنك أن تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، عليك رؤية *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك على هذا النحو:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يعرض الكود العيّني كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```java 
// إنشاء كائن تقديم يمثل ملف PPTX
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
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظائف PowerPoint المستخدمة للعمل مع صور SVG:

![نافذة منبثقة PowerPoint](img_01_01.png)

يتم توفير هذه الوظيفة من خلال أحد التحميلات الزائدة لطريقة [addGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) الخاصة بواجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgImage) كأول وسيط.

يعرض الكود العيّني كيفية استخدام الطريقة المشار إليها لتحويل ملف SVG إلى مجموعة من الأشكال:

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

    // تحويل صورة SVG إلى مجموعة من الأشكال مع تغيير حجمها لتناسب حجم الشريحة
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // حفظ العرض التقديمي بصيغة PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إضافة صور كـ EMF في الشرائح**
يتيح لك Aspose.Slides لأندرويد عبر Java إنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF في الشرائح مع Aspose.Cells.

يعرض الكود العيّني كيفية تنفيذ المهمة الموصوفة:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// حفظ العمل إلى الدفق
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

باستخدام محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، إلخ.

{{% /alert %}}