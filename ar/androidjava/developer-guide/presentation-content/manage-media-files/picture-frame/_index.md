---
title: إطار الصورة
type: docs
weight: 10
url: /ar/androidjava/picture-frame/
keywords: "إضافة إطار صورة، إنشاء إطار صورة، إضافة صورة، إنشاء صورة، استخراج صورة، خاصية StretchOff، تنسيق إطار الصورة، خصائص إطار الصورة، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "إضافة إطار صورة إلى عرض PowerPoint في Java"

---

إطار الصورة هو شكل يحتوي على صورة - إنه مثل صورة في إطار.

يمكنك إضافة صورة إلى شريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية - [JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) - تسمح للناس بإنشاء العروض التقديمية بسرعة من الصور.

{{% /alert %}} 

## **إنشاء إطار صورة**

1. قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال الفهرس الخاص بها. 
3. قم بإنشاء كائن [IPPImage]() من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` المعروضة بواسطة كائن الشكل المرتبط بالشريحة المرجعية.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. اكتب العرض المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية بلغة Java كيفية إنشاء إطار صورة:

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بارتفاع وعرض يعادل ارتفاع وعرض الصورة
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

تسمح لك إطارات الصورة بإنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ لـ Aspose.Slides، يمكنك manip.ArrayList<IShape> . يمكنك الاطلاع على هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة باستخدام المقياس النسبي**

عن طريق تغيير مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال الفهرس الخاص بها. 
3. أضف صورة إلى مجموعة الصور في العرض.
4. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
5. حدد عرض الصورة وارتفاعها النسبي في إطار الصورة.
6. اكتب العرض المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية بلغة Java كيفية إنشاء إطار صورة باستخدام المقياس النسبي:

```java
// تنشئ فئة Presentation التي تمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // تنشئ فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض يعادل الصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تعيين المقياس النسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج صورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) وحفظها بتنسيقات PNG و JPG وغيرها. توضح الشيفرة البرمجية أدناه كيفية استخراج صورة من الوثيقة "sample.pptx" وحفظها بتنسيق PNG.

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

تتيح لك Aspose.Slides الحصول على شفافية الصورة. توضح هذه الشيفرة البرمجية بلغة Java العملية:

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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تغيير إطار الصورة لتناسب متطلبات محددة.

1. قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال الفهرس الخاص بها. 
3. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) من خلال إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) المتاحة في كائن [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المرجعية.
6. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
7. قم بتعيين لون خط إطار الصورة.
8. قم بتعيين عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة بإضافة قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة. 
   * القيمة السلبية تدور الصورة في عكس اتجاه عقارب الساعة.
10. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.
11. اكتب العرض المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية بلغة Java عملية تنسيق إطار الصورة:

```java
// ينشئ فئة Presentation التي تمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بارتفاع وعرض يعادل الصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تطبيق بعض التنسيق على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}}

طورت Aspose مؤخرًا [صانع الكولاج المجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة يومًا ما إلى [دمج JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب الأحجام الكبيرة للعروض التقديمية، يمكنك إضافة الصور (أو الفيديوهات) عبر الروابط بدلاً من تضمين الملفات مباشرة في العروض التقديمية. توضح هذه الشيفرة البرمجية بلغة Java كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

توضح هذه الشيفرة البرمجية بلغة Java كيفية قص صورة موجودة على شريحة:

```java
Presentation pres = new Presentation();
// ينشئ كائن صورة جديدة
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

## حذف المناطق المقطوعة من الصورة

إذا كنت ترغب في حذف المناطق المقطوعة من صورة موجودة في إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). تُرجع هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا كانت القطع غير ضرورية.

توضح هذه الشيفرة البرمجية بلغة Java العملية:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // يحذف المناطق المقطوعة من صورة إطار الصورة ويعيد الصورة المقطوعة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقطوعة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) المعالجة، فإن هذه الإعداد يمكن أن تقلل من حجم العرض التقديمي. خلاف ذلك، سيزداد عدد الصور في العرض التقديمي الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صور PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا كنت تريد أن يحتفظ شكل يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*.

توضح هذه الشيفرة البرمجية بلغة Java كيفية قفل نسبة أبعاد الشكل:

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

    // تعيين الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تحتفظ إعداد *قفل نسبة الأبعاد* هذه فقط بنسبة الأبعاد للشكل وليس للصورة التي تحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل التعبئة.

عند تحديد التمديد لصورة، يتم تغيير حجم مستطيل المصدر ليتناسب مع المستطيل المحدد. يتم تعريف كل حافة من المستطيل التعبوي بواسطة نسبة مئوية من الحافة المقابلة لصندوق حد الشكل. تحدد النسبة المئوية الإيجابية إدخالًا بينما تحدد النسبة المئوية السلبية إدخالًا خارجيًا.

1. قم بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio).
2. احصل على مرجع الشريحة من خلال الفهرس الخاص بها.
3. أضف مستطيل `AutoShape`. 
4. أنشئ صورة.
5. قم بتعيين نوع تعبئة الشكل.
6. قم بتعيين وضع ملء الصورة في الشكل.
7. أضف صورة محددة لملء الشكل.
8. حدد إزاحات الصورة من الحافة المقابلة لصندوق حد الشكل.
9. اكتب العرض المعدل كملف PPTX.

توضح هذه الشيفرة البرمجية بلغة Java عملية تستخدم خاصية StretchOff:

```java
// ينشئ فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ فئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape مضبوطة على شكل مستطيل
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // تعيين نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // تعيين وضع تعبئة الصورة في الشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // تعيين الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // تحديد إزاحات الصورة من الحافة المقابلة لصندوق حد الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```