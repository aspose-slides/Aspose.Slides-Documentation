---
title: تحويل شرائح PowerPoint إلى PNG باستخدام JavaScript
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة باستخدام JavaScript بسرعة مع Aspose.Slides لـ Node.js، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **حول التحويل من PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.  

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا يمثل الحجم مشكلة، يكون PNG تنسيقًا أفضل للصور مقارنةً بـ JPEG.  

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة أدوات Aspose المجانية **لتحويل PowerPoint إلى PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هذه أدوات تنفيذ مباشر للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. أنشئ كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على كائن الشريحة من المجموعة التي تُرجعها طريقة [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) ضمن فئة [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide).
3. استخدم طريقة [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) لحفظ الصورة المصغرة للشرائح بتنسيق PNG.

هذا الكود JavaScript يوضح لك كيفية تحويل عرض PowerPoint إلى PNG:
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

إذا أردت الحصول على ملفات PNG بمقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY` التي تحدد أبعاد الصورة المصغرة الناتجة.  

هذا الكود JavaScript يوضح العملية الموصوفة:
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

إذا أردت الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` إلى `ImageSize`.  

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
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


## **FAQ**

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/nodejs-java/create-shape-thumbnails/)؛ يمكنك تصيير الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، لكن يجب [عدم مشاركة](/slides/ar/nodejs-java/multithreading/) نسخة العرض الواحدة عبر الخيوط. استخدم نسخة منفصلة لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/nodejs-java/licensing/) حتى يتم تطبيق ترخيص.