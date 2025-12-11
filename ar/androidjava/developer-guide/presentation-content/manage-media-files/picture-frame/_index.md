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
description: "أضف إطارات الصور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. سهل سير عملك وحسّن تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة من خلال فهرسها.  
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `AddPictureFrame` التي تُعرضها كائن الشكل المرتبط بالشريحة المشار إليها.  
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.  
7. كتابة العرض المعدل كملف PPTX.  

هذا الكود Java يوضح لك كيفية إنشاء إطار صورة:
```java
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد ارتفاع وعرض الصورة المكافئ
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 

تسمح إطارات الصور بإنشاء شرائح عرض بسرعة بناءً على الصور. عندما تجمع إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/). 

{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة من خلال فهرسها.  
3. إضافة صورة إلى مجموعة صور العرض.  
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.  
5. تحديد عرض الصورة النسبي وارتفاعها في إطار الصورة.  
6. كتابة العرض المعدل كملف PPTX.  

هذا الكود Java يوضح لك كيفية إنشاء إطار صورة مع مقياس نسبي:
```java
// إنشاء كلاس Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كلاس Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بأبعاد ارتفاع وعرض مساوية للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // تعيين نسبة التحجيم النسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج صور نقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) وحفظها بصيغ PNG, JPG وغيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) ، يتيح Aspose.Slides للـ Android عبر Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](hhttps://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG. 

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


## **الحصول على شفافية صورة**

يتيح Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح الكود Java التالي العملية:
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


## **تنسيق إطار صورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة من خلال فهرسها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تُعرضها كائن [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.  
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
7. تعيين لون خط إطار الصورة.  
8. تعيين عرض خط إطار الصورة.  
9. تدوير إطار الصورة بإعطائه قيمة إما موجبة أو سالبة.  
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة.  
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.  
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
11. كتابة العرض المعدل كملف PPTX.  

هذا الكود Java يوضح عملية تنسيق إطار الصورة:
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بأبعاد ارتفاع وعرض مساوية للصورة
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

قامت Aspose مؤخرًا بتطوير [free Collage Maker](https://products.aspose.app/slides/collage). إذا أردت دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كارتباط**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح هذا الكود Java كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يظهر هذا الكود Java كيفية قص صورة موجودة على شريحة:
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


## **حذف مناطق مقصوصة من إطار صورة**

إذا أردت حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القص ضروريًا. 

هذا الكود Java يوضح العملية:
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // يحذف المناطق المقصوصة من صورة إطار الصورة ويرجع الصورة المقصوصة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 

طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) تضيف الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج. 

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*. 

هذا الكود Java يوضح كيفية قفل نسبة أبعاد الشكل:
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

    // اضبط الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها. 

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل تعبئة. 

عند تحديد تمديد لصورة، يتم تحجيم المستطيل المصدر ليناسب مستطيل التعبئة المحدد. يُعرّف كل جانب من جوانب مستطيل التعبئة بنسبة إزاحة من الحد المقابل لمربع حد الشكل. النسبة الموجبة تشير إلى تقليل، والنسبة السالبة إلى توسيع. 

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentatio).  
2. الحصول على مرجع الشريحة من خلال فهرسها.  
3. إضافة مستطيل `AutoShape`.  
4. إنشاء صورة.  
5. تعيين نوع تعبئة الشكل.  
6. تعيين وضع تعبئة صورة الشكل.  
7. إضافة صورة تعبئة لتعبئة الشكل.  
8. تحديد إزاحات الصورة من الحد المقابل لمربع حد الشكل.  
9. كتابة العرض المعدل كملف PPTX.  

هذا الكود Java يوضح عملية استخدام خاصية StretchOff:
```java
// ينشئ كائن الفئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ كائن الفئة ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape على شكل مستطيل
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يضبط نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يضبط وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يضبط الصورة لملء الشكل
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

**كيف يمكنني معرفة صيغ الصور المدعومة لإطارات الصور؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيّن لـ [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عمومًا مع قدرات محرك تحويل الشرائح والصور.

**كيف يؤثر إضافة عشرات الصور الكبيرة على حجم PPTX والأداء؟**

تزيد إدراج الصور الكبيرة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكن قفل كائن الصورة من التحرك/إعادة التحجيم غير المقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) (مثل تعطيل التحرك أو التحجيم). تُوصف آلية القفل للأشكال في مقال حماية منفصل [/slides/androidjava/applying-protection-to-presentation/] وتُدعم لأنواع متعددة من الأشكال بما في ذلك [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجه SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/androidjava/convert-powerpoint-to-png/)، قد يتم تحويل النتيجة إلى نقطية حسب إعدادات التصدير؛ لكن يبقى SVG الأصلي مخزنًا كمتجه كما يُظهر سلوك الاستخراج.