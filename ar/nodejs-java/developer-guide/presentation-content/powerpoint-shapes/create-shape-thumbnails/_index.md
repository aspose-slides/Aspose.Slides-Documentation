---
title: إنشاء صور مصغرة لأشكال العروض التقديمية باستخدام JavaScript
linktitle: مصغرات الأشكال
type: docs
weight: 70
url: /ar/nodejs-java/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- عرض الشكل
- تصيير الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---
## **مقدمة**

يُستخدم Aspose.Slides لإنشاء ملفات العروض التقديمية حيث تكون كل صفحة شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. لكن أحيانًا قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعدك Aspose.Slides على إنشاء صور مصغرة لأشكال الشريحة. يتم شرح كيفية استخدام هذه الميزة في هذا المقال.

يوضح هذا المقال كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد محددة من قبل المستخدم.
- إنشاء صورة مصغرة داخل حدود مظهر الشكل.

## **إنشاء صور مصغرة للأشكال من الشرائح**

لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides لـ Node.js عبر Java، قم بما يلي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getImage--) من الشريحة المرجعية بالمقياس الافتراضي.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود المثال كيفية إنشاء صورة مصغرة لشكل من شريحة:

```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
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

## **إنشاء صور مصغرة للأشكال بمعامل تحجيم معرف من قبل المستخدم**

لإنشاء صورة مصغرة لشكل شريحة باستخدام Aspose.Slides لـ Node.js عبر Java، قم بما يلي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) من الشريحة المرجعية بأبعاد محددة من قبل المستخدم.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود المثال كيفية إنشاء صورة مصغرة لشكل بناءً على معامل تحجيم محدد:

```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
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

## **إنشاء صورة مصغرة للشكل ضمن الحدود**

تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة ضمن حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. تُقيد الصورة المصغرة التي تم إنشاؤها بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حد مظهره، قم بما يلي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية بحدود الشكل كالمظهر.
1. احفظ صورة المصغرة بالتنسيق الصورة المفضل لديك.

يعتمد هذا الكود المثال على الخطوات أعلاه:

```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
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

## **الحصول على الحدود البصرية الفعلية للشكل**

تصف خصائص الإطار لكائن [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)—الطرق `getX()`, `getY()`, `getWidth()`, و`getHeight()`—المستطيل المخزن في نموذج العرض. يمكن للمحتوى الذي يتم عرضه فعليًا أن يمتد خارج ذلك الإطار أو يشغل مستطيلًا محوريًا مختلفًا. يمكن أن تُغيّر الدوران، والحدود، ورؤوس الأسهم، وتخطيط النص وتفريغه، والهندسة المولدة لـ SmartArt، وغيرها من تأثيرات العرض المنطقة المشغولة.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getVisualBounds--) لحساب تلك المنطقة المشغولة دون إنشاء صورة. تُعيد الطريقة كائنًا من نوع [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) في إحداثيات الشريحة. المستطيل المُعاد غير مقصوص إلى الشريحة، لذا قد تكون إحداثياته سلبية عندما يمتد المحتوى خارج أصل الشريحة.

المثال التالي يحصل على حدود الإطار والحدود البصرية ويقارن بينها:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

يمكن استخدام نفس المستطيل لمحاذاة الأشكال القريبة إلى حافته اليسرى أو اليمنى أو العليا أو السفلى؛ وحجز مساحة كافية في تخطيط مُولد؛ أو اكتشاف محتوى خارج المنطقة المسموح بها. تكون الحدود البصرية مفيدة بشكل خاص لـ SmartArt، وصناديق النص، والسهام، والصور، والأشكال المدورة، وأشكال المجموعات، حيث قد لا يمثل الإطار المخزن النتيجة الكاملة المعروضة.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getVisualBounds--) عندما تحتاج إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [Shape.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getImage--) عندما تحتاج إلى عرض الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapethumbnailbounds/)، يقوم `ShapeThumbnailBounds.Shape` بتحديد حجم الصورة بناءً على حدود الشكل، بما في ذلك إعدادات الحدود، بينما يقوم `ShapeThumbnailBounds.Appearance` بتحديد الحجم بناءً على مظهر الشكل ويقيد النتيجة بحدود الشريحة. بالمقابل، تُعيد [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getVisualBounds--) المستطيل المُحسب فقط ولا تقصه إلى الشريحة.

## **الأسئلة المتكررة**

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا تصدير الأشكال كـ [SVG متجهة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/writeassvg/) عن طريق حفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود الشكل وحدود المظهر عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/nodejs-java/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تعيين الشكل ك مخفي؟ هل سيظل يُنشأ له صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن عرضه؛ علم الإخفاء يؤثر على عرض الشرائح لكنه لا يمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن مُمثل كـ [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة بالنظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/nodejs-java/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/nodejs-java/font-substitution/)) لتجنب fallback غير مرغوب فيه وإعادة تدفق النص.