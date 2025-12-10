---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في Java
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/java/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- تصيير الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for Java – بسهولة إنشاء وتصدير صور مصغرة للعرض التقديمي."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides for Java لإنشاء ملفات عرض تقديمي يكون كل صفحة فيها مطابقة لشريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعدهم Aspose.Slides for Java على إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنوضح كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد محددة من قبل المستخدم.
- إنشاء صورة مصغرة لشكل ضمن حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for Java، قم بما يلي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) للشرائح المرجعية بمقياس افتراضي.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

يعرض لك هذا المثال كيفية إنشاء صورة مصغرة لشكل من شريحة:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // حفظ الصورة إلى القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء صورة مصغرة بمعامل تكبير محدد من قبل المستخدم**
لإنشاء صورة مصغرة للشكل من شريحة باستخدام Aspose.Slides for Java، قم بما يلي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) للشرائح المرجعية بأبعاد محددة من قبل المستخدم.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال يوضح كيفية إنشاء صورة مصغرة بناءً على معامل التكبير المحدد:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // حفظ الصورة إلى القرص بتنسيق PNG
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
تسمح طريقة إنشاء الصور المصغرة للأشكال هذه للمطورين بإنشاء صورة مصغرة ضمن حدود مظهر الشكل. وتأخذ في الاعتبار جميع تأثيرات الشكل. تكون الصورة المصغرة المولدة مقيدة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدود مظهره، قم بما يلي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة المصغرة للشرائح المرجعية بحدود الشكل كالمظهر.
1. احفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال مبني على الخطوات أعلاه:
```java
// إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // حفظ الصورة إلى القرص بتنسيق PNG
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

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ الصور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كمتجه SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) عن طريق حفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود Shape وAppearance عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات المرئية](/slides/ar/java/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيظل يُنشأ كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورته؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/java/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/java/font-substitution/)) لتجنب الانتقالات غير المرغوب فيها وإعادة تدفق النص.