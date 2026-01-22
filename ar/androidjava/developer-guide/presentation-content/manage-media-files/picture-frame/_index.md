---
title: إدارة إطارات الصور في العروض التقديمية على Android
linktitle: إطار صورة
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
- المقياس النسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. سهل سير عملك وعزز تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء إطار صورة [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) بناءً على عرض وارتفاع الصورة من خلال طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الرمز Java كيفية إنشاء إطار صورة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بارتفاع وعرض الصورة المتساويين
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء إطار صورة مع المقياس النسبي**

من خلال تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
5. تحديد عرض وارتفاع الصورة النسبيين في إطار الصورة.
6. كتابة العرض التقديمي المعدل كملف PPTX.

يوضح هذا الرمز Java كيفية إنشاء إطار صورة مع المقياس النسبي:
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض مطابقين للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ضبط نسبة التدرج النسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) وحفظها بصيغ PNG وJPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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


## **استخراج صور SVG من إطارات الصور**

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) ، تتيح Aspose.Slides لنظام Android عبر Java استرجاع الصور المتجهة الأصلية بجودة كاملة. عن طريق استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)، والتحقق مما إذا كانت [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) تحمل محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغة SVG الأصلية.

يوضح مثال الشيفرة التالي كيفية استخراج صورة SVG من إطار صورة:
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

تتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبق على الصورة. يوضح هذا الرمز Java العملية:
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يتوافق مع المتطلبات المحددة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء إطار صورة `PictureFrame` بناءً على عرض وارتفاع الصورة من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. ضبط لون خط إطار الصورة.
8. ضبط عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة إما موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الرمز Java عملية تنسيق إطار الصورة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بارتفاع وعرض مساويين للصورة
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


{{% alert title="نصيحة" color="primary" %}}

طوّرت Aspose مؤخرًا أداة [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت أبدًا إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام عروض تقديمية كبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الرمز Java كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يظهر لك هذا الرمز Java كيفية قص صورة موجودة على شريحة:
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

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // يقص الصورة (قيم النسب المئوية)
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

إذا رغبت في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القص ضروريًا.

يظهر هذا الرمز Java العملية:
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

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) المعالجة، فإن هذا الإعداد يمكنه تقليل حجم العرض التقديمي. وإلا سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة عرضه إلى ارتفاعه حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة العرض إلى الارتفاع*.

يظهر لك هذا الرمز Java كيفية قفل نسبة عرض الشكل:
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

    // ضبط الشكل للحفاظ على نسبة العرض إلى الارتفاع عند إعادة التحجيم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="ملاحظة" color="warning" %}} 

يحافظ إعداد *قفل نسبة العرض إلى الارتفاع* فقط على نسبة الشكل ولا يحافظ على الصورة التي يحتويها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمديد لصورة، يتم تحجيم المستطيل المصدر ليتوافق مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرف بنسبة إزاحة من الحافة المقابلة لصندوق حد الشكل. النسبة الموجبة تشير إلى إدخال داخلي بينما النسبة السالبة تشير إلى إخراج خارجي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. ضبط نوع تعبئة الشكل.
6. ضبط وضع تعبئة الصورة للشكل.
7. إضافة صورة محددة لملء الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لصندوق حد الشكل.
9. كتابة العرض التقديمي المعدل كملف PPTX.

يوضح هذا الرمز Java عملية استخدام خاصية StretchOff:
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

    // يضيف AutoShape من نوع Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضبط نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يضبط وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يحدد الصورة لتعبئة الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
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


## **الأسئلة المتكررة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كل من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لــ [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عمومًا مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

يؤدي تضمين صور كبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ يساعد ربط الصور في الحفاظ على صغر حجم العرض لكن يتطلب بقاء الملفات الخارجية متاحة. يوفّر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره غير المقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) (مثلاً لتعطيل التحريك أو إعادة التحجيم). يدعم آلية القفل أنواعًا مختلفة من الأشكال، بما فيها [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجه SVG عند تصدير العرض التقديمي إلى PDF/الصور؟**

تتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) أو إلى [صيغ نقطية](/slides/ar/androidjava/convert-powerpoint-to-png/)، قد يتم تحويل النتيجة إلى نقطية وفقًا لإعدادات التصدير؛ يبقى الاحتفاظ بـ SVG كمتجه واضحًا من سلوك الاستخراج.