---
title: إدارة إطارات الصور في العروض التقديمية باستخدام JavaScript
linktitle: إطار صورة
type: docs
weight: 10
url: /ar/nodejs-java/picture-frame/
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
- نسبة أبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Node.js عبر Java. سهل سير عملك وحسّن تصميم الشرائح."
---
## **مقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن `PPImage` بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `addPictureFrame` المكشوفة من كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الشيفرة JavaScript كيفية إنشاء إطار صورة:

```javascript
// يقوم بإنشاء كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يقوم بإنشاء كلاس Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بالارتفاع والعرض المكافئين للصورة
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

تسمح إطارات الصورة بإنشاء شرائح عرض بسرعة استنادًا إلى الصور. عند دمج إطار الصورة مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر.

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الشيفرة JavaScript كيفية إنشاء إطار صورة بمقياس نسبي:

```javascript
// إنشاء كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء كلاس Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بارتفاع وعرض مكافئ للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // تعيين مقياس نسبي للعرض والارتفاع
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج صور نقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFrame) وحفظها بصيغ PNG أو JPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **استخراج صور SVG من إطارات الصور**

عند احتواء العرض على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for Node.js via Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو تدفق بصيغتها الأصلية SVG.

يوضح مثال الشيفرة التالي كيفية استخراج صورة SVG من إطار صورة:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **الحصول على شفافية الصورة**

يوفر Aspose.Slides إمكانية الحصول على تأثير الشفافية المطبق على صورة. يوضح لك هذا الشيفرة JavaScript العملية:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **الحصول على السطوع والتباين للصورة**

يتيح Aspose.Slides الحصول على تأثير السطوع والتباين المطبق على صورة. تمثل فئة [Luminance](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/luminance/) هذا التأثير التحويلي للصورة.

يُظهر لك هذا الشيفرة JavaScript كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) المكشوفة من كائن [Shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض المعدل كملف PPTX.

يظهر لك هذا الشيفرة JavaScript عملية تنسيق إطار الصورة:

```javascript
// إنشاء كلاس Presentation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء كلاس Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بارتفاع وعرض مكافئ للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // تطبيق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // يكتب ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="نصيحة" color="primary" %}}

طوّرت Aspose مؤخرًا [صانع كولاج مجاني](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العرض، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح لك هذا الشيفرة JavaScript كيفية إضافة صورة وفيديو إلى عنصر نائب:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **قص الصورة**

يُظهر لك هذا الشيفرة JavaScript كيفية قص صورة موجودة على شريحة:

```javascript
var pres = new aspose.slides.Presentation();
// إنشاء كائن صورة جديد
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // إضافة إطار صورة إلى شريحة
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // قص الصورة (قيم النسبة المئوية)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // حفظ النتيجة
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف المناطق المقصوصة من الإطار**

إذا أردت حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن هناك حاجة للقص.

يُظهر لك هذا الشيفرة JavaScript العملية:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // يحصل على إطار الصورة من الشريحة الأولى
    var picFrame = slide.getShapes().get_Item(0);
    // يحذف المناطق المقصوصة من صورة إطار الصورة ويرجع الصورة المقصوصة
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة نقطية PNG أثناء عملية القص. 
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض باستخدام طريقة [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . تقوم هذه الطريقة بضغط الصورة عبر تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة.

إنها تضبط حجم الصورة ودقتها مشابهًا لخاصية **Picture Format → Compress Pictures → Resolution** في PowerPoint.

توضح الأمثلة JavaScript التالية كيفية ضغط صورة في عرض عبر تحديد دقة هدف وإزالة المناطق المقصوصة اختياريًا:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // تحقق من نتيجة الضغط.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

أو باستخدام قيمة DPI محددة مسبقًا أخرى:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // ضغط الصورة إلى 96 DPI (دقة البريد الإلكتروني)، وإزالة المناطق المقصوصة.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف. إذا كانت الصورة ملف ميتا (WMF/EMF) أو SVG، فلن يُطبق الضغط. كما تُحافظ جودة JPEG أو تُخفض قليلًا حسب الدقة، مشابهًا لكيفية معالجة PowerPoint لملفات JPEG عالية الدقة. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل المحتوي على صورة بنسبة أبعادها حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) لتفعيل إعداد *قفل نسبة الأبعاد*.

يُظهر لك هذا الشيفرة JavaScript كيفية قفل نسبة أبعاد الشكل:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // ضبط الشكل للحفاظ على نسبة الأبعاد عند إعادة التحجيم
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="ملاحظة" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الطرق [setStretchOffsetLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) و[setStretchOffsetBottom](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمدد لصورة، يُصبح المستطيل المصدر مُقاسًا ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرف بنسبة إزاحة من الحافة المقابلة لمربع حدود الشكل. النسبة الموجبة تُحدد إدخالًا بينما النسبة السالبة تُحدد خروجًا.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تحديد نوع ملء الشكل.
6. تحديد وضع ملء صورة الشكل.
7. إضافة صورة لتملأ الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل.
9. كتابة العرض المعدل كملف PPTX.

يُظهر لك هذا الشيفرة JavaScript عملية استخدام خاصية StretchOff:

```javascript
// ينشئ كلاس Prseetation الذي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // ينشئ كلاس ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف AutoShape محدد كـ Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // يحدد نوع ملء الشكل
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // يحدد وضع ملء الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // يحدد الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // يكتب ملف PPTX إلى القرص
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة صيغ الصور التي يدعمها إطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عمومًا مع قدرات محرك تحويل الشرائح والصورة.

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم وأداء ملف PPTX؟**

تزيد إضافة الصور الكبيرة مباشرةً من حجم الملف واستهلاك الذاكرة؛ الربط بالصور يساعد على تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة من التحرك أو التحجيم غير المقصود؟**

استخدم [قواعد القفل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) (على سبيل المثال، تعطيل التحريك أو التحجيم). يدعم آلية القفل أنواعًا مختلفة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/).

**هل يتم الحفاظ على جودة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية اعتمادًا على إعدادات التصدير؛ ومع ذلك يبقى SVG الأصلي محفوظًا كمتجه وفق سلوك الاستخراج.