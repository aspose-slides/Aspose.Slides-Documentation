---
title: إدارة إطارات الصور في العروض باستخدام Java
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/java/picture-frame/
keywords:
- إطار الصورة
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
- نسبة العرض إلى الارتفاع
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إضافة إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. سهل سير عملك وعزز تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — تسمح للأشخاص بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) استنادًا إلى عرض وارتفاع الصورة عبر الطريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح لك هذا الشيفرة Java كيفية إنشاء إطار صورة:
```java
// ينشئ كائن الفئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن الفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد الصورة المتساوية للارتفاع والعرض
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
تسمح لك إطارات الصور بإنشاء شرائح عرض تقديمي سريعًا بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التعامل مع عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}} 

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل القياس النسبي للصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. أضف صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.
6. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح لك هذا الشيفرة Java كيفية إنشاء إطار صورة مع مقياس نسبي:
```java
// إنشاء كائن الفئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // احصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن الفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بأبعاد مساوية للارتفاع والعرض الخاصين بالصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ضبط مقياس العرض والارتفاع النسبي
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // اكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) وحفظها بتنسيقات PNG و JPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بتنسيق PNG.
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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، يسمح Aspose.Slides for Java باسترداد الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك التعرف على كل [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

يوضح المثال التالي كيفية استخراج صورة SVG من إطار صورة:
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


## **احصل على شفافية الصورة**

تسمح لك Aspose.Slides باستخراج تأثير الشفافية المطبق على صورة. يوضح هذا الشيفرة Java العملية:
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يتطابق مع المتطلبات المحددة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة عبر الطريقة [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تحديد لون حدود إطار الصورة.
8. تحديد عرض حدود إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الشيفرة Java عملية تنسيق إطار الصورة:
```java
// إنشاء كائن الفئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يُحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن الفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بأبعاد مساوية للارتفاع والعرض الخاصين بالصورة
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
قامت Aspose مؤخرًا بتطوير [مُصنِّع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت يومًا إلى [دمج JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام عروض تقديمية كبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلًا من تضمين الملفات مباشرةً في العروض. يوضح هذا الشيفرة Java كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يظهر هذا الشيفرة Java كيفية قص صورة موجودة على شريحة:
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

    // يقطع الصورة (قيم النسبة المئوية)
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


## **حذف المناطق المقصوصة من الإطار**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن الققص ضروريًا.

يظهر هذا الشيفرة Java العملية:
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
تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا استُخدمت الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) المعالج، قد يقلل ذلك من حجم العرض التقديمي. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القَص. 
{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا أردت أن يحتفظ شكل يحتوي على صورة بنسبة أبعاده حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتفعيل إعداد *قفل نسبة العرض إلى الارتفاع*.

يوضح هذا الشيفرة Java كيفية قفل نسبة أبعاد الشكل:
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
إعداد *قفل نسبة العرض إلى الارتفاع* يحافظ فقط على نسبة أبعاد الشكل وليس على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل تعبئة.

عند تحديد تمديد لصورة، يتم تعديل حجم المستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. كل حد من حدود مستطيل التعبئة يُعرّف بنسبة إزاحة من الحد المقابل لصندوق حدود الشكل. النسبة الموجبة تُحدّد إدخالاً، بينما السلبية تُحدّد خروجاً.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع تعبئة الشكل.
6. تعيين وضع تعبئة الصورة للشكل.
7. إضافة صورة تعبئة لتملأ الشكل.
8. تحديد إزاحات الصورة من الحد المقابل لصندوق حدود الشكل.
9. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الشيفرة Java عملية استخدام خاصية StretchOff:
```java
// ينشئ كائن فئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ كائن فئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape من النوع Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضبط نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يضبط وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يضبط الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل
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

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تزيد تضمينات الصور الكبيرة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في الحفاظ على صغر حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغيير حجمه عن طريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (مثل تعطيل التحريك أو تغيير الحجم). تُوصف آلية القفل للأشكال في مقالة [الحماية](/slides/ar/java/applying-protection-to-presentation/) وتُدعم لأنواع متعددة من الأشكال، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجهات SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/) أو إلى [تنسيقات نقطية](/slides/ar/java/convert-powerpoint-to-png/)، قد تُرَسم النتيجة كنقطة اعتمادًا على إعدادات التصدير؛ لكن حفظ SVG كمتجه يُؤكد سلوكه عند الاستخراج.