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
description: "إضافة إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Android عبر Java. سهل سير عملك وعزز تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="Tip" color="info" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر مؤشرها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `AddPictureFrame` المكشوفة بواسطة كائن الشكل المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. حفظ العرض المعدل كملف PPTX.

يظهر لك هذا الرمز Java كيفية إنشاء إطار صورة:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة مع ارتفاع وعرض الصورة المقابلين
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء إطار صورة مع مقياس نسبي**

من خلال تغيير مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر مؤشرها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. حفظ العرض المعدل كملف PPTX.

يظهر لك هذا الرمز Java كيفية إنشاء إطار صورة مع مقياس نسبي:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // إضافة إطار صورة بارتفاع وعرض مساويين للصورة
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // ضبط مقياس العرض والارتفاع النسبي
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

يمكنك استخراج صور نقطية من [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PictureFrame) وحفظها بصيغ PNG، JPG، وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج صور SVG من إطارات الصور**

عند وجود رسومات SVG داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) في عرض تقديمي، يتيح Aspose.Slides for Android عبر Java استرداد الصور المتجهة الأصلية بجودة كاملة. بمجرد حصولك على [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) يحتوي على [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يحمل محتوى SVG، يمكنك قراءة تلك الصورة SVG وحفظها على القرص أو في تدفق بصيغتها الأصلية SVG.

يعرض مثال الشيفرة التالي كيفية استخراج صورة SVG من إطار صورة:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

تمكنك Aspose.Slides من الحصول على تأثير الشفافية المُطبق على صورة. يوضح هذا الرمز Java العملية:

```java
import com.aspose.slides.*;

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

تمكنك Aspose.Slides من الحصول على تأثير السطوع والتباين المُطبق على صورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iluminance/) هذا التحويل في الصورة.

يظهر لك هذا الرمز Java كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```java
import com.aspose.slides.*;

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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يطابق المتطلبات المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر مؤشرها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) المكشوفة بواسطة كائن [IShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.  
   * القيمة الإيجابية تدور الصورة عقليًا.  
   * القيمة السلبية تدور الصورة عكس عقليًا.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. حفظ العرض المعدل كملف PPTX.

يظهر لك هذا الرمز Java عملية تنسيق إطار الصورة:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إنشاء كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // إضافة إطار صورة بارتفاع وعرض مساويين للصورة
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

{{% alert title="Tip" color="info" %}}
طورت Aspose مؤخرًا أداة [Collage Maker مجانية](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العرض. يوضح هذا الرمز Java كيفية إضافة صورة وفيديو في العنصر النائب:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

يُظهر هذا الرمز Java كيفية قص صورة موجودة على شريحة:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// إنشاء كائن صورة جديد
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة إطار صورة إلى شريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // قص الصورة (قِيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // حفظ النتيجة
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف المناطق المقتطعة من الصورة**

إذا رغبت بحذف المناطق المقتطعة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القَط ضرورياً.

يُظهر هذا الرمز Java العملية:

```java
import com.aspose.slides.*;

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
تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض. إذا استُخدمت الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) المعالجة، فإن هذا الإعداد يمكن أن يقلل حجم العرض. وإلا سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية خلال عملية القص. 
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . تقوم هذه الطريقة بضغط الصورة عن طريق تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة.

تعدل حجم الصورة ودقتها بشكل مشابه لميزة **Picture Format > Compress Pictures > Resolution** في PowerPoint.

توضح الأمثلة Java التالية كيفية ضغط صورة في عرض تقديمي بتحديد دقة مستهدفة وحذف المناطق المقصوصة اختياريًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
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

أو باستخدام قيمة DPI مخصصة مباشرة:

```java
import com.aspose.slides.*;

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
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل و DPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف.  
إذا كانت الصورة ملفًا متجهًا (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما يتم الحفاظ على جودة JPEG أو تقليلها قليلًا حسب الدقة، كما يفعل PowerPoint مع JPEG عالي الدقة. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتفعيل خيار *Lock Aspect Ratio*.

يظهر لك هذا الرمز Java كيفية قفل نسبة أبعاد الشكل:

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // تعيين الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
إعداد *Lock Aspect Ratio* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/ar/angularjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمدد لصورة، يتم موازنة المستطيل المصدر ليتناسب مع مستطيل الملء المحدد. يتم تعريف كل حافة من حواف مستطيل الملء بنسبة مئوية من الحافة المقابلة لصندوق حد الشكل. النسبة المئوية الإيجابية تعني تقصير بينما السلبية تعني إظهار خارجي.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر مؤشرها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع تعبئة الشكل.
6. تعيين وضع تعبئة الصورة للشكل.
7. إضافة صورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لصندوق حد الشكل.
9. حفظ العرض المعدل كملف PPTX.

يظهر لك هذا الرمز Java عملية استخدام خاصية StretchOff:

```java
import com.aspose.slides.*;

// ينشئ كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ كائن ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف AutoShape محدد ك Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // يحدد نوع ملء الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يحدد وضع ملء الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يحدد الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //يكتب ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

### كيف يمكنني معرفة صيغ الصور المدعومة لإطار صورة؟

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

### كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم PPTX والأداء؟

إدماج صور كبيرة يزيد من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. توفر Aspose.Slides القدرة على إضافة الصور عبر روابط لتقليل حجم الملف.

### كيف يمكنني قفل كائن الصورة لمنعه من التحرك أو التغيير العرضي؟

استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) لـ [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) (مثلاً، تعطيل التحرك أو تغيير الحجم). يدعم نظام القفل أنواعًا متعددة من الأشكال، بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/).

### هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض إلى PDF/صور؟

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/androidjava/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطة اعتمادًا على إعدادات التصدير؛ يبقى وجود SVG كمتجه مُؤكدًا من سلوك الاستخراج.