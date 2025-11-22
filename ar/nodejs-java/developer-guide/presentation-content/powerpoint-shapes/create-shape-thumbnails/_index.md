---
title: إنشاء صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/nodejs-java/create-shape-thumbnails/
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides for Node.js via Java لإنشاء ملفات عرض تقديمي حيث تتطابق كل صفحة مع شريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعد Aspose.Slides for Node.js via Java في إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنُظهر كيفية إنشاء مصغرات الشرائح في حالات مختلفة:

- إنشاء مصغرة الشكل داخل شريحة.
- إنشاء مصغرة الشكل لشكل شريحة بأبعاد يحددها المستخدم.
- إنشاء مصغرة الشكل ضمن حدود مظهر الشكل.

## **إنشاء مصغرات الشكل من الشرائح**
لإنشاء مصغرة شكل من أي شريحة باستخدام Aspose.Slides for Node.js via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة مصغرة للشكل من الشريحة المرجعية بمقياس افتراضي.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

يوضح هذا الكود النموذجي كيفية إنشاء مصغرة شكل من شريحة:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // حفظ الصورة إلى القرص بصيغة PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء مصغرات الشكل باستخدام معامل التحجيم المحدد من قبل المستخدم**
لإنشاء مصغرة شكل من شريحة باستخدام Aspose.Slides for Node.js via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة مصغرة للشكل من الشريحة المرجعية بأبعاد يحددها المستخدم.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

يوضح هذا الكود النموذجي كيفية إنشاء مصغرة شكل استنادًا إلى معامل التحجيم المحدد:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // حفظ الصورة إلى القرص بصيغة PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إنشاء مصغرة شكل للحدود**
تتيح هذه الطريقة لإنشاء مصغرات الأشكال للمطورين إنشاء مصغرة ضمن حدود مظهر الشكل. وهي تأخذ في الاعتبار جميع تأثيرات الشكل. تكون مصغرة الشكل التي تم إنشاؤها مقيدة بحدود الشريحة. لإنشاء مصغرة لشكل شريحة ضمن حدود مظهره، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

هذا الكود النموذجي يعتمد على الخطوات أعلاه:
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // حفظ الصورة إلى القرص بصيغة PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ما تنسيقات الصور التي يمكن استخدامها عند حفظ مصغرات الشكل؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصديرها كـ SVG متجه](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) بحفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود Shape وAppearance عند إنشاء مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/nodejs-java/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تعليم شكل على أنه مخفي؟ هل سيظل يُظهر كمصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن عرضه؛ علم الإخفاء يؤثر على عرض العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل تُدعم الأشكال الجماعية والرسوم البيانية وSmartArt وغيرها من الكائنات المعقدة؟**

نعم. يمكن حفظ أي كائن يُمثل كـ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) كمصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة المصغرات للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/nodejs-java/custom-font/) (أو [تهيئة استبدالات الخط](/slides/ar/nodejs-java/font-substitution/)) لتجنب التحويلات غير المرغوبة وإعادة تنسيق النص.