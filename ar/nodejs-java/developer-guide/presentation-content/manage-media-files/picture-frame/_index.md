---
title: إدارة إطارات الصور في العروض التقديمية باستخدام JavaScript
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/nodejs-java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- اقتصاص صورة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لبيئة Node.js عبر Java. سهل سير عملك وعزز تصميمات الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة—إنه يشبه الصورة داخل إطار. 

يمكنك إضافة صورة إلى الشريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن `PPImage` بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.  
4. تحديد عرض وارتفاع الصورة.  
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) بناءً على عرض وارتفاع الصورة عبر طريقة `addPictureFrame` التي تُعرضها كائن الشكل المرتبط بالشريحة المرجعية.  
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.  
7. كتابة العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود JavaScript كيفية إنشاء إطار صورة:
```javascript
// ينشئ كائنًا من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // ينشئ كائنًا من الفئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بأبعاد الطول والعرض المطابقين للصورة
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


يسمح لك إطارات الصور بإنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر.

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.  

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة صورة إلى مجموعة صور العرض التقديمي.  
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.  
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.  
6. كتابة العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود JavaScript كيفية إنشاء إطار صورة بمقياس نسبي:
```javascript
// إنشاء فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بأبعاد الطول والعرض المطابقة للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // ضبط مقياس النسبي للعرض والارتفاع
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

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)، يتيح Aspose.Slides for Node.js via Java استرداد الصور المتجهة الأصلية بدقة كاملة. عبر استعراض مجموعة أشكال الشريحة، يمكنك التعرف على كل [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) يحمل محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

يوضح المثال البرمجي التالي كيفية استخراج صورة SVG من إطار صورة:
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

يسمح Aspose.Slides بالحصول على تأثير الشفافية المطبق على صورة. يوضح لك هذا الكود JavaScript العملية:
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

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام تلك الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) المرتبطة بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.  
4. تحديد عرض وارتفاع الصورة.  
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) التي تُعرضها كائن [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) المرتبط بالشريحة المرجعية.  
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
7. ضبط لون خط إطار الصورة.  
8. ضبط عرض خط إطار الصورة.  
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.  
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة.  
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.  
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة مرة أخرى.  
11. كتابة العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود JavaScript عملية تنسيق إطار الصورة:
```javascript
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // ينشئ كائنًا من فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بأبعاد الارتفاع والعرض المكافئة للصورة
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // يطبق بعض التنسيقات على PictureFrameEx
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

طورت Aspose مؤخرًا أداة [Collage Maker مجانية](https://products.aspose.app/slides/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح لك هذا الكود JavaScript كيفية إضافة صورة وفيديو إلى عنصر نائب:
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


## **اقتصاص الصورة**

يظهر لك هذا الكود JavaScript كيفية اقتصاص صورة موجودة على شريحة:
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


## **حذف المناطق المقصوصة من الإطار**

إذا أردت حذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن الاقتصاص ضروريًا.

يظهر لك هذا الكود JavaScript العملية:
```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // يحصل على إطار الصورة من الشريحة الأولى
    var picFrame = slide.getShapes().get_Item(0);
    // يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
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

طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) تضيف الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا استُخدمت الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض التقديمي. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية الاقتصاص. 

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) لضبط إعداد *قفل نسبة الأبعاد*.

يظهر لك هذا الكود JavaScript كيفية قفل نسبة أبعاد الشكل:
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
    // ضبط الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
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

باستخدام الطرق [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)، [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)، [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) و[setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) من فئة [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمدد للصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُحدَّد بنسبة إزاحة من الحافة المقابلة لمربع تحديد الشكل. النسبة الموجبة تمثل تقليصًا بينما السالبة تمثل توسيعًا.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة مستطيل `AutoShape`.  
4. إنشاء صورة.  
5. ضبط نوع ملء الشكل.  
6. ضبط وضع ملء الصورة للشكل.  
7. إضافة صورة للملء إلى الشكل.  
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع تحديد الشكل.  
9. كتابة العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود JavaScript عملية استخدام خاصية StretchOff:
```javascript
// ينشئ كائنًا من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // ينشئ كائنًا من الفئة ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف AutoShape من النوع Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // يحدد نوع تعبئة الشكل
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // يحدد وضع تعبئة الصورة للشكل
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // يعيّن الصورة لتعبئة الشكل
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


## **الأسئلة الشائعة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/). قائمة الصيغ المدعومة تتقاطع عمومًا مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تزيد الصور المضمنة الكبيرة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في خفض حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره عن طريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (مثل تعطيل النقل أو التحجيم). يدعم آلية القفل أنواعًا مختلفة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة الصورة المتجهة SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية حسب إعدادات التصدير؛ لكن يبقى الـ SVG الأصلي محفوظًا كمتجه كما يؤكد سلوك الاستخراج.