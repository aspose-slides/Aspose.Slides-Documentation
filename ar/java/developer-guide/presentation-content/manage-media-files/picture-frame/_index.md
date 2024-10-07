---
title: إطار الصورة
type: docs
weight: 10
url: /java/picture-frame/
keywords: "إضافة إطار صورة، إنشاء إطار صورة، إضافة صورة، إنشاء صورة، استخراج صورة، خاصية StretchOff، تنسيق إطار الصورة، خصائص إطار الصورة، عرض PowerPoint، جافا، Aspose.Slides لجافا"
description: "إضافة إطار صورة إلى عرض PowerPoint في جافا"

---

إطار الصورة هو شكل يحتوي على صورة - إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية - [JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) - التي تتيح للناس إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على مرجع الشريحة من خلال مؤشرها.
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. تحديد العرض والارتفاع للصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` التي تعرضها كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض المعدل كملف PPTX.

تظهر لك هذه الشيفرة بلغة جافا كيفية إنشاء إطار صورة:

```java
// إنشاء مثيل للفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء مثيل للفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة مع الارتفاع والعرض المماثل للصورة
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // كتابة ملف PPTX على القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

تسمح لك إطارات الصورة بإنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عندما تجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك التلاعب بعمليات الإدخال / الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في رؤية هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

من خلال تغيير نسبة مقياس الصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على مرجع الشريحة من خلال مؤشرها.
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
5. تحديد العرض والارتفاع النسبي للصورة في إطار الصورة.
6. كتابة العرض المعدل كملف PPTX.

تظهر لك هذه الشيفرة بلغة جافا كيفية إنشاء إطار صورة بمقياس نسبي:

```java
// إنشاء مثيل للفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء مثيل للفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض مكافئ للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تعيين نسبة المقياس النسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // كتابة ملف PPTX على القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج صورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) وحفظها في تنسيقات PNG و JPG وغيرها. توضح الشيفرة المثال أدناه كيفية استخراج صورة من الوثيقة "sample.pptx" وحفظها في تنسيق PNG.

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

## **الحصول على شفافية الصورة**

تتيح لك Aspose.Slides الحصول على شفافية الصورة. توضح الشيفرة التالية هذه العملية:

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("شفافية الصورة: " + transparencyValue);
    }
}
```

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تغيير إطار الصورة لجعله يتناسب مع متطلبات معينة.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. الحصول على مرجع الشريحة من خلال مؤشرها.
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. تحديد العرض والارتفاع للصورة.
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تعرضها كائن [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) المرتبطة بالشريحة المرجعية.
6. إضافة إطار الصورة (يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة من خلال إعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة.
   * القيمة السلبية تدور الصورة في الاتجاه المعاكس.
10. إضافة إطار الصورة (يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض المعدل كملف PPTX.

توضح هذه الشيفرة بلغة جافا عملية تنسيق إطار الصورة:

```java
// إنشاء مثيل للفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء مثيل للفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بارتفاع وعرض مكافئ للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تطبيق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // كتابة ملف PPTX على القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}}

طورت Aspose مؤخرًا [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة أبدًا إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب الأحجام الكبيرة للعروض التقديمية، يمكنك إضافة صور (أو فيديوهات) من خلال روابط بدلاً من تضمين الملفات مباشرة في العروض التقديمية. توضح هذه الشيفرة بلغة جافا كيفية إضافة صورة وفيديو إلى موضع:

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

توضح هذه الشيفرة بلغة جافا كيفية قص صورة موجودة على الشريحة:

```java
Presentation pres = new Presentation();
// إنشاء كائن صورة جديدة
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة إطار صورة إلى الشريحة
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

## حذف المناطق المقطوعة من الصورة

إذا كنت ترغب في حذف المناطق المقطوعة من صورة محتواة في إطار، يمكنك استخدام الطريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). تعيد هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا كان القص غير ضروري.

توضح هذه الشيفرة بلغة جافا العملية:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // الحصول على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // حذف المناطق المقطوعة من صورة إطار الصورة وإعادة الصورة المقطوعة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // حفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف الطريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقطوعة إلى مجموعة الصور الخاصة بالعروض التقديمية. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، يمكن أن يؤدي هذا الإعداد إلى تقليل حجم العرض التقديمي. خلاف ذلك، ستزداد عدد الصور في العرض التقديمي الناتج.

تحول هذه الطريقة الملفات التعريفية WMF/EMF إلى صورة PNG نقطية في عملية القص. 

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا كنت تريد أن يحتفظ الشكل المحتوي على صورة بنسبته بعد تغيير أبعاد الصورة، يمكنك استخدام الطريقة [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*.

توضح هذه الشيفرة بلغة جافا كيفية قفل نسبة أبعاد الشكل:

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

    // تعيين الشكل للحفاظ على نسبة الأبعاد عند إعادة التحجيم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

يحافظ إعداد *قفل نسبة الأبعاد* على نسبة الأبعاد فقط للشكل وليس للصورة التي يحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) والفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل الملء.

عند تحديد التمديد لصورة، يتم تغيير مقطع مصدر ليتناسب مع مستطيل الملء المحدد. يتم تعريف كل حافة من مستطيل الملء بواسطة نسبة مئوية من الحافة المطابقة لصندوق حدود الشكل. تحدد النسبة المئوية الإيجابية نقطة داخل بينما تحدد النسبة السلبية نقطة خارج.

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) class.
2. الحصول على مرجع الشريحة من خلال مؤشرها.
3. إضافة شكل مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع ملء الشكل.
6. تعيين وضع ملء الصورة للشكل.
7. إضافة صورة تم تعيينها لملء الشكل.
8. تحديد الحدود المرئية للصورة من الحواف المطابقة لصندوق حدود الشكل.
9. كتابة العرض المعدل كملف PPTX.

توضح هذه الشيفرة بلغة جافا عملية يتم فيها استخدام خاصية StretchOff:

```java
// إنشاء مثيل للفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء مثيل للفئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة شكل تلقائي تم تعيينه كمستطيل
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // تعيين نوع ملء الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // تعيين وضع ملء الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تعيين الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // تحديد الحدود المرئية للصورة من الحواف المطابقة لصندوق حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // كتابة ملف PPTX على القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```