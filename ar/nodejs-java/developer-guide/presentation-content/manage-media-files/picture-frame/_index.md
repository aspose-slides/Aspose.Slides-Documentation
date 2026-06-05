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
- منطقة مقطوعة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Node.js عبر Java. سهل سير عملك وعزّز تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt) — التي تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها. 
3. إنشاء كائن `PPImage` عن طريق إضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء كائن [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `addPictureFrame` التي يُقدمها كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض المعدل كملف PPTX.

يعرض هذا الكود JavaScript كيفية إنشاء إطار صورة:

```javascript
// ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // يحصل على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // ينشئ كائن من الفئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // يضيف إطار صورة بالارتفاع والعرض المكافئ للصورة
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

تتيح لك إطارات الصورة إنشاء شرائح عرض بسرعة استنادًا إلى الصور. عند دمج إطار الصورة مع خيارات حفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر.

## **إنشاء إطار صورة بمقاس نسبي**

عن طريق تعديل المقياس النسبي للصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PPImage) عن طريق إضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد عرض الصورة النسبي وارتفاعها في إطار الصورة.
6. كتابة العرض المعدل كملف PPTX.

يعرض هذا الكود JavaScript كيفية إنشاء إطار صورة بمقاس نسبي:

```javascript
// إنشاء فئة Presentation التي تمثل PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء فئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بالارتفاع والعرض المكافئ للصورة
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

## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PictureFrame) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح مثال الرمز أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عند وجود عرض يحتوي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) ، يتيح لك Aspose.Slides for Node.js عبر Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان الـ [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG.

يوضح مثال الرمز التالي كيفية استخراج صورة SVG من إطار صورة:

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

يوفر Aspose.Slides إمكانية الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود JavaScript العملية:

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

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يطابق المتطلبات المحددة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال مؤشرها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PPImage) عن طريق إضافة صورة إلى [ImagesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء كائن `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) التي يُقدمها كائن [Shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ShapeCollection) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. ضبط لون خط إطار الصورة.
8. ضبط عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود JavaScript عملية تنسيق إطار الصورة:

```javascript
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إنشاء كائن من الفئة Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // إضافة إطار صورة بالارتفاع والعرض المكافئ للصورة
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
