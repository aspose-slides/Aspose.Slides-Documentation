---
title: إدارة إطارات الصور في العروض التقديمية باستخدام Java
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
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java. سهل سير عملك وحسّن تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهارسها. 
3. قم بإنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) بناءً على عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي يُظهرها كائن الشكل المرتبط بالشريحة المرجعية.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. احفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود Java كيفية إنشاء إطار صورة:
```java
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائنًا من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد العرض والارتفاع المكافئة للصورة
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 

تتيح لك إطارات الصور إنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك معالجة عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في مشاهدة هذه الصفحات: تحويل [image إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة مع المقياس النسبي**

من خلال تعديل المقياس النسبي للصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهارسها. 
3. أضف صورة إلى مجموعة صور العرض التقديمي.
4. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
5. حدد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. احفظ العرض التقديمي المعدل كملف PPTX.

المثال التالي للشفرة يوضح كيفية إنشاء إطار صورة مع المقياس النسبي:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بأبعاد العرض والارتفاع المكافئة للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تعيين مقياس نسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخراج صور نقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح مثال الكود أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for Java استرداد الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة الأشكال في الشريحة، يمكنك تحديد كل [PictureFrame]، والتحقق مما إذا كان [IPPImage] الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG.

المثال التالي للشفرة يوضح كيفية استخراج صورة SVG من إطار صورة:
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

يتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح لك هذا الكود Java العملية:
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


## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتناسب مع متطلبات محددة.

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهارسها. 
3. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي يُظهرها كائن [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المرجعية.
6. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
7. حدد لون خط إطار الصورة.
8. حدد عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة.
   * القيمة السالبة تدور الصورة عكس عقارب الساعة.
10. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
11. احفظ العرض التقديمي المعدل كملف PPTX.

المثال التالي للشفرة يوضح عملية تنسيق إطار الصورة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد الارتفاع والعرض المكافئة للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يطبق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Tip" color="primary" %}}

قامت Aspose مؤخرًا بتطوير [أداة تركيب مجانية](https://products.aspose.app/slides/collage). إذا احتجت يومًا إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب حجم العروض التقديمية الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر الروابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح لك هذا الكود Java كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يظهر لك هذا الكود Java كيفية قص صورة موجودة على شريحة:
```java
Presentation pres = new Presentation();
// ينشئ كائن صورة جديد
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف PictureFrame إلى شريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // يقص الصورة (قيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // يحفظ النتيجة
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **حذف المناطق المقصوصة من صورة**

إذا رغبت في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن الاقتصاص ضروريًا.

يظهر لك هذا الكود Java العملية:
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

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) المعالجة، فإن هذا الإعداد يمكن أن يقلل من حجم العرض التقديمي. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية الاقتصاص. 

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة الأبعاد حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *Lock Aspect Ratio*.

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

    // تعيين الشكل للحفاظ على نسبة الأبعاد عند التحجيم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 

هذا الإعداد *Lock Aspect Ratio* يحافظ فقط على نسبة الأبعاد للشكل وليس على الصورة التي يحتويها. 

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل تعبئة.

عند تحديد التمدد لصورة، يتم تحويل مستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. يتم تعريف كل حافة من حواف مستطيل التعبئة بواسطة إزاحة مئوية من الحافة المقابلة لمربع حدود الشكل. النسبة المئوية الإيجابية تشير إلى تقليص، بينما السلبية تشير إلى توسع.

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف مستطيلًا `AutoShape`.
4. قم بإنشاء صورة.
5. حدد نوع تعبئة الشكل.
6. حدد وضع تعبئة صورة الشكل.
7. أضف صورة لتعبئة الشكل.
8. حدد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
9. احفظ العرض التقديمي المعدل كملف PPTX.

المثال التالي للشفرة يوضح عملية استخدام خاصية StretchOff:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ كائن من فئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape محددة إلى مستطيل
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يحدد نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يحدد وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يحدد الصورة لتعبئة الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحواف المقابلة لصندوق حد الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). قائمة الصيغ المدعومة تتقاطع عادةً مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم وأداء PPTX؟**

تؤدي دمج الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يقدم Aspose.Slides إمكانية إضافة الصور عبر الرابط لتقليل الحجم.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تحجيمه عن طريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (مثلاً، تعطيل النقل أو التحجيم). يتم شرح آلية القفل للأشكال في مقالة الحماية المستقلة وتدعم أنواعًا مختلفة من الأشكال، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجه SVG عند تصدير العرض إلى PDF/صور؟**

يتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF أو صيغ نقطية، قد يتم تحويله إلى نقطية اعتمادًا على إعدادات التصدير؛ ومع ذلك، يظل SVG الأصلي محفوظًا كمتجه وفق سلوك الاستخراج.