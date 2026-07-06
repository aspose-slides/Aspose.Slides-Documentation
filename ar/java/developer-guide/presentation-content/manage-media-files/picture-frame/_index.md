---
title: إدارة إطارات الصورة في العروض التقديمية باستخدام Java
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقطوعة
- خاصية StretchOff
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. سهل سير عملك وعزز تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء كائن [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PictureFrame) بناءً على عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (الذي يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية إنشاء إطار صورة:

```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من الفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بارتفاع وعرض الصورة المتكافئين
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

تسمح إطارات الصورة بإنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية إنشاء إطار صورة بمقياس نسبي:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض يساويان الصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تعيين مقياس العرض والارتفاع النسبي
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج صور نقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PictureFrame) وحفظها بصيغ PNG وJPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **استخراج صور SVG من إطارات الصورة**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/)، يتيح Aspose.Slides for Java استرجاع الصور المتجهة الأصلية بكامل الدقة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغة SVG الأصلية.

الكود التالي يوضح كيفية استخراج صورة SVG من إطار صورة:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **الحصول على شفافية الصورة**

يسمح Aspose.Slides لك بالحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود بلغة Java العملية:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **الحصول على سطوع وتباين الصورة**

يسمح Aspose.Slides لك بالحصول على تأثير السطوع والتباين المطبق على صورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iluminance/) هذا التأثير التحويلي للصورة.

يظهر هذا الكود بلغة Java كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة في اتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Java يوضح عملية تنسيق إطار الصورة:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بارتفاع وعرض يساويان الصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تطبيق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}}

قامت Aspose مؤخرًا بتطوير [أداة مجانية لإنشاء الكولاج](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح هذا الكود بلغة Java كيفية إضافة صورة وفيديو إلى عنصر نائب:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **قص الصور**

يظهر هذا الكود بلغة Java كيفية قص صورة موجودة على شريحة:

```java
Presentation pres = new Presentation();
// إنشاء كائن صورة جديد
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة إطار صورة إلى شريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // قص الصورة (قيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // حفظ النتيجة
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف المناطق المقتصة من إطار الصورة**

إذا رغبت في حذف المناطق المقتصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقتصة أو الصورة الأصلية إذا كان القص غير ضروري.

يُظهر هذا الكود بلغة Java العملية:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقتصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) المعالج، يمكن لهذا الإعداد تقليل حجم العرض التقديمي. وإلا، سيزيد عدد الصور في العرض التقديمي الناتج.

تحول هذه الطريقة ملفات WMF/EMF الميتافيلي إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . تقلل هذه الطريقة من حجم الصورة بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقتصة.

إنها تضبط حجم الصورة ودقتها بطريقة مماثلة لميزة **Picture Format -> Compress Pictures -> Resolution** في PowerPoint.

توضح الأمثلة التالية بلغة Java كيفية ضغط صورة في عرض تقديمي عبر تحديد دقة هدف وإزالة المناطق المقتصة إن رغبت:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة بدقة هدف 150 DPI (دقة الويب) وإزالة المناطق المقطوعة.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // فحص نتيجة الضغط.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

أو باستخدام قيمة DPI مخصصة مباشرةً:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة إلى 150 DPI (دقة الويب)، مع إزالة المناطق المقصوصة.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل و DPI المقدم. يمكن أيضًا حذف المناطق المقتصة لتحسين حجم الملف.  
إذا كانت الصورة ملف ميتافيلي (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما تُحافظ جودة JPEG أو تُقلل قليلًا بناءً على الدقة، كما يحدث في PowerPoint مع JPEG عالي الدقة.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*.

يظهر هذا الكود بلغة Java كيفية قفل نسبة أبعاد الشكل:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // ضبط الشكل للحفاظ على نسبة الأبعاد عند إعادة التحجيم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملئ.

عند تحديد تمديد لصورة، يتم مقاس المستطيل المصدر لتناسب مستطيل الملئ المحدد. كل حافة من مستطيل الملئ تُعرف بنسبة إزاحة من الحافة المقابلة لمستطيل حدّ الشكل. النسبة الموجبة تُشير إلى تقليص، بينما النسبة السالبة تُشير إلى توسعة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع ملئ الشكل.
6. تعيين وضع ملئ صورة الشكل.
7. إضافة صورة للملء داخل الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لمستطيل حدود الشكل.
9. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة Java يوضح عملية استخدام خاصية StretchOff:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء كائن من فئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة AutoShape على شكل مستطيل
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // تعيين نوع ملء الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // تعيين وضع ملء الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تعيين الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // تحديد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم PPTX والأداء؟**

يزید تضمین الصور الكبيرة من حجم الملف واستخدام الذاكرة؛ ربط الصور يقلل من حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره عن طريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) (مثل تعطيل النقل أو تغيير الحجم). تم شرح آلية القفل للأشكال في مقال [حماية العروض التقديمية](/slides/ar/java/applying-protection-to-presentation/) وتُدعم لأنواع مختلفة من الأشكال، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجهات في SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/java/convert-powerpoint-to-png/)، قد يتم تحويل النتيجة إلى نقطية بناءً على إعدادات التصدير؛ يُؤكد سلوك الاستخراج أن SVG الأصلي يبقى متجهًا.