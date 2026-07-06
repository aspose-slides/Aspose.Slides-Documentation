---
title: إدارة إطارات الصور في العروض التقديمية على Android
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/androidjava/picture-frame/
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
- منطقة مقصوصة
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
- Android
- Java
- Aspose.Slides
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. سهل سير عملك وحسّن تصاميم الشرائح."
---
## **مقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. إنشاء إطار [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PictureFrame) استنادًا إلى عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` المعروضة من قبل كائن الشكل المرتبط بالشريحة المرجعية.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. احفظ العرض التقديمي المعدل كملف PPTX.

```java
// تنشئ كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // تنشئ كلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بارتفاع وعرض الصورة المكافئين
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يحفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء إطار صورة بمقياس نسبي**

من خلال تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. احفظ العرض التقديمي المعدل كملف PPTX.

```java
// إنشاء كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض مساويين للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ضبط مقياس العرض والارتفاع النسبي
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // حفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PictureFrame) وحفظها بتنسيقات PNG وJPG وغيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بتنسيق PNG.

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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/)، يتيح Aspose.Slides for Android عبر Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/)، والتحقق مما إذا كان كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يحمل محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو تدفق بتنسيق SVG الأصلي.

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

يتيح Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح الكود الجافا التالي العملية:

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

## **الحصول على السطوع والتباين للصورة**

يتيح Aspose.Slides الحصول على تأثير السطوع والتباين المطبق على صورة. تمثل واجهة [ILuminance](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iluminance/) هذا التحويل.

يوضح الكود الجافا التالي كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار صورة ليتوافق مع متطلبات محددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) المعروضة من قبل كائن [IShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المرجعية.
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. احفظ العرض التقديمي المعدل كملف PPTX.

```java
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بارتفاع وعرض مساويين للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يطبق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // يحفظ ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

قامت Aspose مؤخرًا بتطوير [صانع كولاج مجاني](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو مقاطع الفيديو) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح الكود الجافا التالي كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

يوضح الكود الجافا التالي كيفية قص صورة موجودة على شريحة:

```java
Presentation pres = new Presentation();
// Creates new image object
// إنشاء كائن صورة جديد
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds a PictureFrame to a Slide
    // إضافة إطار صورة إلى شريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Crops the image (percentage values)
    // قص الصورة (قيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Saves the result
    // حفظ النتيجة
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف المناطق المقصوصة من صورة**

إذا رغبت في حذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا لم يكن القَط مطلوبًا.

يوضح الكود الجافا التالي العملية:

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

{{% alert title="NOTE" color="warning" %}} 

طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تضيف الصورة المقطوعة إلى مجموعة صور العرض. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) الذي تم معالجته، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزيد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . تقوم هذه الطريقة بضغط الصورة عن طريق تقليل حجمها وفقًا لحجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة.

إنها تعدل حجم الصورة ودقتها مماثلة لميزة **Picture Format > Compress Pictures > Resolution** في PowerPoint.

توضح الأمثلة الجافا التالية كيفية ضغط صورة في عرض تقديمي عبر تحديد دقة مستهدفة وحذف المناطق المقصوصة اختياريًا:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة بدقة مستهدف 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // تحقق من نتيجة الضغط.
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

أو باستخدام قيمة DPI مخصصة مباشرة:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة إلى 150 DPI (دقة الويب)، وإزالة المناطق المقصوصة.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف.  
إذا كانت الصورة ملف تعريف (WMF/EMF) أو SVG، لا يتم تطبيق الضغط. كما تُحافظ جودة JPEG أو تُقلل قليلًا بناءً على الدقة، كما يفعل PowerPoint مع JPEG عالي الدقة.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لضبط إعداد *قفل نسبة الأبعاد*.

يوضح الكود الجافا التالي كيفية قفل نسبة أبعاد الشكل:

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

    // ضبط الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس على الصورة التي يحتويها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد التمدد لصورة، يتم تحجيم مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرَّف بنسبة إزاحة من الحافة المقابلة لمربع الحد للشكل. النسبة الموجبة تحدد تقليصًا بينما النسبة السالبة تحدد توسيعًا.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرستها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع ملء الشكل.
6. تعيين وضع ملء الصورة للشكل.
7. إضافة صورة للملء إلى الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع الحد الخاص بالشكل.
9. احفظ العرض التقديمي المعدل كملف PPTX.

```java
// ينشئ كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ كلاس ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape من نوع Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضبط نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يضبط وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يضبط الصورة لتملئ الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // يحفظ ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار صورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ[PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/). تتقاطع قائمة التنسيقات المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تزيد الصور المضمّنة الكبيرة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة من التحرك أو تغيير حجمه بطريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ[PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) (مثل تعطيل التحرك أو تغيير الحجم). تدعم آلية القفل أنواعًا مختلفة من الأشكال، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) أو [التنسيقات النقطية](/slides/ar/androidjava/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي اعتمادًا على إعدادات التصدير؛ سلوك الاستخراج يؤكد أن SVG الأصلي يبقى متجهًا.