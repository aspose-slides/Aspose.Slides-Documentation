---
title: إنشاء صور مصغرة لأشكال العروض التقديمية على Android
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/androidjava/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- عرض الشكل
- تصيير الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for Android عبر Java – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---
## **المقدمة**

يمكن استخدام Aspose.Slides for Android عبر Java لإنشاء ملفات عروض تقديمية حيث تتطابق كل صفحة مع شريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعد Aspose.Slides for Android عبر Java على إنشاء صور مصغرة لأشكال الشرائح.

في هذا الموضوع، سنوضح كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة لشكل ضمن حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for Android عبر Java، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape#getImage--) للشرحة المرجعية بمقياس افتراضي.
4. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
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

## **إنشاء صورة مصغرة بمعامل مقياس يحدده المستخدم**
لإنشاء صورة مصغرة لشكل شريحة باستخدام Aspose.Slides for Android عبر Java، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) للشرحة المرجعية بأبعاد يحددها المستخدم.
4. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
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
تتيح هذه الطريقة إنشاء صور مصغرة للأشكال داخل حدود مظهر الشكل مع أخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد الصورة المصغرة التي يتم إنشاؤها بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة داخل حد مظهره، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. احصل على صورة المصغرة للشرحة المرجعية مع حدود الشكل كمظهر.
4. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
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

## **الحصول على الحدود البصرية الفعلية للشكل**

تصف خصائص الإطار في [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)—الطرق `getX()`, `getY()`, `getWidth()`, و `getHeight()`—المستطيل المخزن في نموذج العرض. المحتوى الذي يتم عرضه فعليًا قد يمتد خارج ذلك الإطار أو يشغل مستطيلًا محوريًا مختلفًا. يمكن أن تغير الدوران، الخطوط الخارجية، رؤوس السهام، تخطيط النص والتجاوز، هندسة SmartArt المُولدة، وغيرها من تأثيرات العرض المنطقة المشغولة.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getVisualBounds--) لحساب تلك المنطقة المشغولة دون إنشاء صورة. تُعيد الطريقة كائنًا من النوع [RectF](https://developer.android.com/reference/android/graphics/RectF) في إحداثيات الشريحة. المستطيل المُعاد غير مقطوع إلى حدود الشريحة، لذا قد تكون إحداثياته سالبة عندما يمتد المحتوى خارج أصل الشريحة.

[Shape.getVisualBounds](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getVisualBounds--) غير مُعلن حاليًا في واجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/). لذلك، احتفظ بالشكل الذي تم الحصول عليه من مجموعة أشكال الشريحة كقيمة واجهة واستخدم التحويل فقط عند استدعاء الطريقة.

المثال التالي يحصل على الحدود الإطارية والبصرية ويقارن بينها:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

يمكن استخدام نفس كائن [RectF](https://developer.android.com/reference/android/graphics/RectF) لمحاذاة الأشكال القريبة إلى حافته اليسرى أو اليمنى أو العليا أو السفلى؛ أو لتخصيص مساحة كافية في تخطيط مُولَّد؛ أو لاكتشاف محتوى خارج منطقة مسموحة. تعد الحدود البصرية مفيدة خاصةً لـ SmartArt، صناديق النص، الأسهم، الصور، الأشكال المدارة، ومجموعات الأشكال، حيث قد لا يمثل الإطار المخزن النتيجة الكاملة للعرض.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getVisualBounds--) عندما تحتاج إلى إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [IShape.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getImage--) عندما تحتاج إلى عرض الشكل. باستخدام [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapethumbnailbounds/)، يُحدد `ShapeThumbnailBounds.Shape` حجم الصورة من حدود الشكل، بما في ذلك إعدادات الخط الخارجي، بينما يُحدد `ShapeThumbnailBounds.Appearance` الحجم من مظهر الشكل ويقيد النتيجة بحدود الشريحة. على النقيض من ذلك، تُعيد [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getVisualBounds--) المستطيل المحسوب فقط ولا تقصه إلى الشريحة.

## **الأسئلة المتكررة**

**ما هي تنسيقات الصورة التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) بحفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود Shape و Appearance عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [visual effects](/slides/ar/androidjava/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كإخفاء؟ هل سيظل يُنشأ له صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن عرضه؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثل كـ [Shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) (أو [تكوين استبدال الخطوط](/slides/ar/androidjava/font-substitution/)) لتجنب الاعتماد على خطوط بديلة غير مرغوبة وإعادة تدفق النص.