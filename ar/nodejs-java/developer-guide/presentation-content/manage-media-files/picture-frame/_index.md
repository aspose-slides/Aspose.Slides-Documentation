---
title: إطار الصورة
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
- قص صورة
- خاصية StretchOff
- تنسيق إطار صورة
- خصائص إطار صورة
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides لـ Node.js عبر Java
description: "إضافة إطار صورة إلى عرض تقديمي في PowerPoint باستخدام JavaScript"
---

إطار الصورة هو شكل يحتوي على صورة—إنه كالصورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 
تقدم Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—التي تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن `PPImage` بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
4. تحديد عرض الصورة وارتفاعها. 
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `addPictureFrame` التي تُعرض بواسطة كائن الشكل المرتبط بالشريحة المشار إليها. 
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة. 
7. كتابة العرض التقديمي المعدل كملف PPTX. 

يعرض لك هذا الكود JavaScript كيفية إنشاء إطار صورة:
```javascript
// يقوم بإنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // يقوم بإنشاء فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بالارتفاع والعرض المقابل للصورة
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


{{% alert color="warning" %}} 
تتيح لك إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عندما تجمع بين إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك معالجة عمليات الإدخال/الإخراج لتحويل الصور من صيغة إلى أخرى. قد ترغب في زيارة هذه الصفحات: تحويل [image إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); تحويل [JPG إلى image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي. 
4. إنشاء كائن `PPImage` بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة. 
6. كتابة العرض التقديمي المعدل كملف PPTX. 

يعرض لك هذا الكود JavaScript كيفية إنشاء إطار صورة مع مقياس نسبي:
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بارتفاع وعرض مساويين للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // ضبط مقياس العرض والارتفاع النسبي
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


## **استخراج صور نقطية من إطارات الصورة**

يمكنك استخراج صور نقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) وحفظها بصيغ PNG وJPG وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG. 
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


## **استخراج صور SVG من إطارات الصورة**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ، يتيح Aspose.Slides لـ Node.js عبر Java استرداد الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame]، والتحقق مما إذا كان [PPImage] الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG. 

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

يتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود JavaScript العملية:
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


## **تنسيق إطار الصورة**

يقدم Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يتناسب مع متطلبات معينة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن `PPImage` بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
4. تحديد عرض الصورة وارتفاعها. 
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) التي تُعرض بواسطة كائن [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) المرتبط بالشريحة المشار إليها. 
6. إضافة إطار الصورة (يحتوي على الصورة) إلى الشريحة. 
7. تعيين لون خط إطار الصورة. 
8. تعيين عرض خط إطار الصورة. 
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة. 
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة. 
10. إضافة إطار الصورة (يحتوي على الصورة) إلى الشريحة. 
11. كتابة العرض التقديمي المعدل كملف PPTX. 

يعرض لك هذا الكود JavaScript عملية تنسيق إطار الصورة:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء كائن من فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بارتفاع وعرض مساويين للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // تطبيق بعض التنسيقات على PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // كتابة ملف PPTX إلى القرص
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

طورت Aspose مؤخرًا [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت يومًا إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كارتباط**

لتجنب أحجام العرض التقديمي الكبيرة، يمكنك إضافة صور (أو مقاطع فيديو) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح لك هذا الكود JavaScript كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يوضح لك هذا الكود JavaScript كيفية قص صورة موجودة على شريحة:
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
    // اقتصاص الصورة (قيم النسبة المئوية)
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


## **حذف المناطق المقطوعة من الصورة**

إذا كنت تريد حذف المناطق المقطوعة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا لم يكن الاقتطاع ضروريًا.

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // يحصل على إطار الصورة من الشريحة الأولى
    var picFrame = slide.getShapes().get_Item(0);
    // يحذف المناطق المقتطعة من صورة إطار الصورة ويعيد الصورة المقتطعة
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // يحفظ النتيجة
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) تُضيف الصورة المقطوعة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض التقديمي. وإلا، سيزداد عدد الصور في العرض الناتج. 

تحول هذه الطريقة ملفات WMF/EMF الميتا إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ شكل يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة الأبعاد*.

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
    // تعيين الشكل للحفاظ على نسبة الأبعاد عند تعديل الحجم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

هذا الإعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام طرق [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) و[setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمدد لصورة، يتم تعديل مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرّف بنسبة إزاحة من الحافة المقابلة لمربع حد الشكل. النسبة الموجبة تُشير إلى تقليص بينما النسبة السالبة تُشير إلى توسّع.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentatio) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة. 
5. تعيين نوع تعبئة الشكل. 
6. تعيين وضع تعبئة صورة الشكل. 
7. إضافة صورة معينة لملء الشكل. 
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع حد الشكل 
9. كتابة العرض التقديمي المعدل كملف PPTX. 

يعرض لك هذا الكود JavaScript عملية استخدام خاصية StretchOff:
```javascript
// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // ينشئ كائن من فئة ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف AutoShape من نوع Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // يضبط نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // يضبط وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // يضبط الصورة لملء الشكل
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // يحدد إزاحات الصورة من الحافة المقابلة لمربع حد الشكل
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


## **أسئلة متكررة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) . عادةً ما تتقاطع قائمة الصيغ المدعومة مع إمكانيات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX وأداءه؟**

تزيد إضافة الصور الكبيرة داخل العرض من حجم الملف واستهلاك الذاكرة؛ بينما يساعد ربط الصور على تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره غير المقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) لإطار صورة ([PictureFrame]) (مثلاً، تعطيل التحريك أو إعادة التحجيم). تم شرح آلية القفل للأشكال في مقالة الحماية المنفصلة (/slides/ar/nodejs-java/applying-protection-to-presentation/) ويدعم أنواع الأشكال المختلفة بما فيها [PictureFrame].

**هل يتم الحفاظ على جودة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF أو صيغ نقطية، قد يتم تحويله إلى نقطية وفقًا لإعدادات التصدير؛ لكن يُؤكد سلوك الاستخراج أن SVG الأصلي يبقى كمتجه.