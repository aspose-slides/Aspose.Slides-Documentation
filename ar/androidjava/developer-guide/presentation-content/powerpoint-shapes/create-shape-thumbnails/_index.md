---
title: إنشاء صور مصغرة لأشكال العرض التقديمي على Android
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/androidjava/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- رسم الشكل
- عرض الشكل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides لأندرويد عبر Java – بسهولة إنشاء وتصدير صور مصغرة للعرض التقديمي."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides for Android عبر Java لإنشاء ملفات عرض تقديمي تكون كل صفحة فيها شريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعدهم Aspose.Slides for Android عبر Java على إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنظهر كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة لشكل ضمن حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for Android عبر Java، نفّذ ما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو مؤشرها.
1. [احصل على صورة المصغرة للشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) للشرحة المرجعية على المقياس الافتراضي.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود العيني كيفية إنشاء صورة مصغرة لشكل من شريحة:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بحجم كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء صورة مصغرة بمعامل قياس يحدده المستخدم**
لإنشاء صورة مصغرة للشكل من شريحة باستخدام Aspose.Slides for Android عبر Java، نفّذ ما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو مؤشرها.
1. [احصل على صورة المصغرة للشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) للشرحة المرجعية بأبعاد يحددها المستخدم.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود العيني كيفية إنشاء صورة مصغرة للشكل بناءً على معامل قياس محدد:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بحجم كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة ضمن حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد صورة المصغرة المولدة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حد مظهره، نفّذ ما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرّفها أو مؤشرها.
1. احصل على صورة المصغرة للشرحة المرجعية بحدود الشكل كمظهر.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

هذا الكود العيني مبني على الخطوات أعلاه:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بحجم كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ صور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) عن طريق حفظ محتوى الشكل كـ SVG.

**ما هو الفرق بين حدود الشكل وحدود المظهر عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/androidjava/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على شكل كمخفي؟ هل سيظل يتم إنشاء صورة مصغرة له؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورته؛ علامة الإخفاء تؤثر على عرض الشريحة في العرض التقديمي لكنها لا تمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية والرسوم البيانية وSmartArt وغيرها من الكائنات المعقدة؟**

نعم. يمكن حفظ أي كائن ممثل كـ [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة نظاميًا على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) (أو [تكوين بدائل الخطوط](/slides/ar/androidjava/font-substitution/)) لتجنب الوقوع في الخطوط الاحتياطية غير المرغوب فيها وإعادة تدفق النص.