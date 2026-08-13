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
description: "أضف إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java. سهل سير العمل وزد من جودة تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="info" %}} 
توفر Aspose محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt) — تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PictureFrame) استنادًا إلى عرض الصورة وارتفاعها عبر طريقة `AddPictureFrame` المتاحة بواسطة كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود Java كيفية إنشاء إطار صورة:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من الفئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بالارتفاع والعرض المقابلين للصورة
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
تسمح لك إطارات الصورة بإنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عند دمج إطار الصورة مع خيارات حفظ Aspose.Slides، يمكنك معالجة عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في الاطلاع على هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/svg-to-png/).
{{% /alert %}}

## **إنشاء إطار صورة باستخدام مقياس نسبي**

من خلال تغيير مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود Java كيفية إنشاء إطار صورة باستخدام مقياس نسبي:

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
    
    
    // إضافة إطار صورة بالارتفاع والعرض المتساويين للصورة
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

## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/PictureFrame) وحفظها بصيغ PNG, JPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

## **استخراج صور SVG من إطارات الصورة**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) ، يتيح Aspose.Slides for Java استرجاع الصور المتجهة الأصلية بكامل الدقة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك التعرف على كل [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG.

يوضح مثال الشيفرة التالي كيفية استخراج صورة SVG من إطار صورة:

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

        // تُعيد getSvgImage قيمة null عندما تكون الصورة صورة نقطية.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **الحصول على شفافية الصورة**

يسمح Aspose.Slides لك بالحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود Java العملية:

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

يسمح Aspose.Slides لك بالحصول على تأثير السطوع والتباين المطبق على صورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iluminance/) هذا التأثير التحويلي للصورة.

يظهر لك هذا الكود Java كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` استنادًا إلى عرض الصورة وارتفاعها عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) المتاحة بواسطة كائن [IShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IShapeCollection) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود Java عملية تنسيق إطار الصورة:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ينشئ كائن من فئة Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // يضيف إطار صورة بالارتفاع والعرض المتساويين للصورة
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

{{% alert title="Tip" color="info" %}}
قامت Aspose مؤخرًا بتطوير [صانع الكولاج المجاني](https://products.aspose.app/slides/ar/collage). إذا احتجت يومًا إلى [دمج JPG/JPEG](https://products.aspose.app/slides/ar/collage/jpg) أو صور PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كارتباط**

لتقليل حجم العروض الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الكود Java كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

يظهر لك هذا الكود Java كيفية قص صورة موجودة على شريحة:

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

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

    // إضافة PictureFrame إلى شريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // قص الصورة (قيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // حفظ النتيجة
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف المناطق المقصوصة من إطار صورة**

إذا أردت حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا كانت القص غير ضرورية.

يظهر لك هذا الكود Java العملية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // حفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستعملة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF الوصفية إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . تقلل هذه الطريقة حجم الصورة بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة.

تُعدّل حجم الصورة ودقتها بطريقة مشابهة لميزات PowerPoint **Picture Format -> Compress Pictures -> Resolution**.

توفر الأمثلة Java التالية كيفية ضغط صورة في عرض تقديمي بتحديد دقة مستهدفة وحذف المناطق المقصوصة إذا رغبت:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
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
import com.aspose.slides.*;

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

{{% alert title="NOTE" color="warning" %}} 
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل و DPI المُقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف.  
إذا كانت الصورة ملفًا وصفيًا (WMF/EMF) أو SVG، لا يُطبق الضغط. كما تُحافظ جودة JPEG أو تُقلل قليلاً حسب الدقة، مشابهًا لكيفية معالجة PowerPoint لملفات JPEG عالية الدقة. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي صورة بنسبة أبعادها حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*.

يظهر لك هذا الكود Java كيفية قفل نسبة أبعاد الشكل:

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

    // تعيين الشكل للحفاظ على نسبة الأبعاد عند إعادة التحجيم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
هذا الإعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل ولا يحافظ على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat) و فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل تعبئة.

عند تحديد التمدد لصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. يُعرّف كل جانب من جوانب مستطيل التعبئة بإنزلاق نسبة مئوية من الجانب المقابل لصندوق حدود الشكل. النسبة المئوية الموجبة تمثّل انقاصًا بينما السلبية تمثّل توسعًا.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع تعبئة الشكل.
6. تعيين وضع تعبئة صورة الشكل.
7. إضافة صورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الجانب المقابل لصندوق حدود الشكل.
9. كتابة العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود Java عملية استخدام خاصية StretchOff:

```java
import com.aspose.slides.*;

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

    // يحدد نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(FillType.Picture);

    // يحدد وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // يضع الصورة لتعبئة الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // يحدد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // يكتب ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

### كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيَّن إلى [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

### كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم PPTX والأداء؟

تؤدي تضمين صور كبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكن يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

### كيف يمكنني قفل كائن الصورة لمنعه من التحريك/تغيير الحجم غير المقصود؟

استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) لإطار صورة (على سبيل المثال، تعطيل التحريك أو تغيير الحجم). تُوصف آلية القفل للأشكال في مقالة [الحماية](/slides/ar/java/applying-protection-to-presentation/) وتُدعم لأنواع أشكال متعددة بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/).

### هل يتم الحفاظ على دقة المتجه SVG عند تصدير عرض تقديمي إلى PDF/صور؟

يتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية اعتمادًا على إعدادات التصدير؛ سلوك الاستخراج يؤكد أن SVG الأصلي يُحفظ كمتجه.