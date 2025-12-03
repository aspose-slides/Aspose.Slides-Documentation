---
title: إدارة إطارات الصور في العروض التقديمية باستخدام Java
linktitle: إطار صورة
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
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير صورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إضافة إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java. سهل سير عملك وعزز تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه كالصورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)— تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهارسها. 
3. أنشئ كائنًا من نوع [IPPImage]() بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة. 
5. أنشئ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) بناءً على عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي توفرها كائن الشكل المرتبط بالشريحة المشار إليها. 
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. احفظ العرض المعدل كملف PPTX. 

هذا الكود بلغة Java يوضح كيفية إنشاء إطار صورة:
```java
// ينشئ كائن فئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد ارتفاع وعرض الصورة المقابلة
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
تسمح لك إطارات الصورة بإنشاء شرائح عرض بسرعة بناءً على الصور. عندما تجمع إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. احصل على مرجع الشريحة من خلال فهارسها. 
3. أضف صورة إلى مجموعة صور العرض. 
4. أنشئ كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
5. حدد العرض والارتفاع النسبيين للصورة داخل إطار الصورة. 
6. احفظ العرض المعدل كملف PPTX. 

هذا الكود بلغة Java يوضح كيفية إنشاء إطار صورة بمقياس نسبي:
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بأبعاد ارتفاع وعرض الصورة المعادلة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ضبط عرض وارتفاع النسبة النسبية
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

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) وحفظها بصيغة PNG أو JPG أو غيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عند احتواء عرض شرائح على رسومات SVG داخل أشكال [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، تسمح Aspose.Slides for Java باسترجاع الصور المتجهة الأصلية بكامل دقتها. عبر استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، والتحقق ما إذا كان [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) المتصل يحمل محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

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

تمكنك Aspose.Slides من الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود بلغة Java العملية:
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. احصل على مرجع الشريحة من خلال فهارسها. 
3. أنشئ كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
4. حدد عرض وارتفاع الصورة. 
5. أنشئ `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي توفرها كائن [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها. 
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. اضبط لون خط إطار الصورة. 
8. اضبط عرض خط إطار الصورة. 
9. دوّر إطار الصورة بإعطائه قيمة إما موجبة أو سالبة. 
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة. 
10. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة مرة أخرى. 
11. احفظ العرض المعدل كملف PPTX. 

هذا الكود بلغة Java يوضح عملية تنسيق إطار الصورة:
```java
// ينشئ كائن فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد ارتفاع وعرض الصورة المقابلة
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
طورت Aspose مؤخرًا أداة [صانعة كولاج مجانية](https://products.aspose.app/slides/collage). إذا احتجت إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة داخل العروض. يوضح هذا الكود بلغة Java كيفية إضافة صورة وفيديو إلى عنصر نائب:
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


## **قص الصورة**

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

    // قص الصورة (قِيَم النسبة المئوية)
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


## **حذف المناطق المقطعة من الصور**

إذا رغبت بحذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقطعة أو الصورة الأصلية إذا لم يكن القَطُّ ضروريًا.

هذا الكود بلغة Java يوضح العملية:
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يجلب إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقطوعة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="ملاحظة" color="warning" %}} 
طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تُضيف الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة تُستعمل فقط في [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) المُعالجة، فإن هذا الإعداد يمكن أن يقلل من حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج. 

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لضبط إعداد *قفل نسبة الأبعاد*. 

هذا الكود بلغة Java يوضح كيفية قفل نسبة أبعاد الشكل:
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
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="ملاحظة" color="warning" %}} 
إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من الواجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) والفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملء. 

عند تحديد تمديد لصورة، يُقاس مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطیل الملء تُعرَّف بنسبة إزاحة من الحافة المقابلة لصناديق الشكل الحدية. النسبة الموجبة تعني تقليص بينما النسبة السالبة تعني توسع.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio). 
2. احصل على مرجع الشريحة من خلال فهارسها. 
3. أضف مستطيل `AutoShape`. 
4. أنشئ صورة. 
5. اضبط نوع تعبئة الشكل. 
6. اضبط وضع تعبئة الصورة للشكل. 
7. أضف صورة لتعبئة الشكل. 
8. حدد إزاحات الصورة من الحافة المقابلة لصندوق الشكل الحدية. 
9. احفظ العرض المعدل كملف PPTX. 

هذا الكود بلغة Java يوضح عملية استخدام خاصية StretchOff:
```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ فئة ImageEx
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

    // يضبط الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حد الشكل
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
يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عامةً مع قدرات محرك التحويل بين الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**  
يؤدي تضمين الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. توفر Aspose.Slides إمكانية إضافة الصور عبر رابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنعه من التحرك/إعادة الحجم عن طريق الخطأ؟**  
استخدم [قفل الأشكال](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (على سبيل المثال، تعطيل التحرك أو تغيير الحجم). توضح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/java/applying-protection-to-presentation/) وتدعم أنواعًا متعددة من الأشكال، بما فيها [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على الدقة المتجهة لملف SVG عند تصدير العرض إلى PDF/صور؟**  
يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/) أو إلى [الصيغ النقطية](/slides/ar/java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية بحسب إعدادات التصدير؛ لكن سُجل أن SVG الأصلي يُحفظ كمتجه وفق سلوك الاستخراج.