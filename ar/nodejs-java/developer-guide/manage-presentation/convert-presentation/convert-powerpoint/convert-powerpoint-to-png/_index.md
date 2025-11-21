---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG, PPT إلى PNG, PPTX إلى PNG, java, Aspose.Slides لـ Node.js عبر Java
description: تحويل عرض PowerPoint التقديمي إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تكون الحجم مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في الاطلاع على محولات Aspose المجانية **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ حي للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على كائن الشريحة من المجموعة التي تُرجعها الطريقة [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) ضمن الفئة [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. استخدم الطريقة [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم الطريقة [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` كوسائط لـ `ImageSize`.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل معين فقط (مثل مخطط أو صورة) بدلاً من الشريحة كاملة؟**  
Aspose.Slides يدعم [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/nodejs-java/create-shape-thumbnails/); يمكنك تحويل شكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**  
نعم، لكن لا يجب [مشاركة](/slides/ar/nodejs-java/multithreading/) كائن العرض الواحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود الإصدار التجريبي عند التصدير إلى PNG؟**  
وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/nodejs-java/licensing/) حتى يتم تطبيق الترخيص.