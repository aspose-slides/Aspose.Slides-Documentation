---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في Java
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/java/create-shape-thumbnails/
keywords:
- مصغّر الشكل
- صورة الشكل
- تصيير الشكل
- تصيير الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for Java – إنشاء وتصدير مصغرات العروض التقديمية بسهولة."
---
## **مقدمة**

Aspose.Slides for Java يمكن استخدامها لإنشاء ملفات عرض تقديمي حيث تتطابق كل صفحة مع شريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، تساعد Aspose.Slides for Java على إنشاء صور مصغرة لأشكال الشرائح.

تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل من شكل شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة لشكل ضمن حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for Java، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. [احصل على صورة المصغّر للشكل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage--) للشرحة المرجعية بالمقياس الافتراضي.
4. احفظ صورة المصغّر بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود المثال كيفية إنشاء صورة مصغرة لشكل من شريحة:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // حفظ الصورة إلى القرص بصيغة PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء صورة مصغرة بمعامل تكبير يحدده المستخدم**
لإنشاء صورة المصغّر لشكل من شريحة باستخدام Aspose.Slides for Java، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. [احصل على صورة المصغّر للشكل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage-int-float-float-) للشرحة المرجعية بأبعاد يحددها المستخدم.
4. احفظ صورة المصغّر بالتنسيق الصورة المفضل لديك.

يعرض لك هذا الكود المثال كيفية إنشاء صورة مصغرة للشكل بناءً على معامل تكبير محدد:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // حفظ الصورة إلى القرص بصيغة PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء صورة مصغرة لمظهر الشكل المستند إلى الحدود**
تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء مصغرة ضمن حدود مظهر الشكل. فهي تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد صورة الشكل المصغرة الناتجة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدود مظهره، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) .
2. احصل على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. احصل على صورة المصغّر للشرحة المرجعية باستخدام حدود الشكل كمظهر.
4. احفظ صورة المصغّر بالتنسيق الصورة المفضل لديك.

يعتمد هذا الكود المثال على الخطوات أعلاه:

```java
// إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بالحجم الكامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // حفظ الصورة إلى القرص بصيغة PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على حدود الشكل البصرية الفعلية**
تصف خصائص الإطار لـ [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) — طرق `getX()` و `getY()` و `getWidth()` و `getHeight()` — المستطيل المخزن في نموذج العرض التقديمي. المحتوى الذي يتم عرضه فعليًا يمكن أن يمتد خارج ذلك الإطار أو يشغل مستطيلًا محاذيًا مختلفًا. يمكن أن تغير الدوران، والحدود، ورؤوس الأسطر، وتخطيط النص وتدفقه، والهندسة التي يتم إنشاؤها من SmartArt، وغيرها من تأثيرات التصيير المنطقة المحتلة.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getVisualBounds--) لحساب تلك المنطقة المحتلة دون إنشاء صورة. تُرجِع الطريقة كائنًا من نوع [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) بإحداثيات الشريحة. المستطيل المرتجع لا يتم قصه إلى حدود الشريحة، لذلك يمكن أن تكون إحداثياته سالبة عندما يمتد المحتوى خارج أصل الشريحة.

حاليًا، لا يتم إعلان [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getVisualBounds--) في واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/). لذلك، احتفظ بالشكل المستخرج من مجموعة أشكال الشريحة كقيمة واجهة وقم بتحويله فقط عند استدعاء الطريقة.

المثال التالي يحصل على حدود الإطار والبصرية ويقارنها:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

يمكن استخدام نفس [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) لمحاذاة الأشكال القريبة إلى اليسار أو اليمين أو الأعلى أو الأسفل، أو لحجز مساحة كافية في تخطيط تم إنشاؤه، أو لاكتشاف محتوى خارج المنطقة المسموح بها. تكون الحدود البصرية مفيدة بشكل خاص لـ SmartArt، ومربعات النص، والسهام، والصور، والأشكال الدوارة، والأشكال الجماعية، حيث قد لا تمثّل الإطار المخزن النتيجة المُصوّرة بالكامل.

استخدم [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getVisualBounds--) عندما تحتاج إلى إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [IShape.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getImage--) عندما تحتاج إلى تصيير الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapethumbnailbounds/)، حجم `ShapeThumbnailBounds.Shape` الصورة من حدود الشكل، بما في ذلك إعدادات الحدود، بينما حجم `ShapeThumbnailBounds.Appearance` الصورة من مظهر الشكل ويقيد النتيجة بحدود الشريحة. بالمقابل، تُرجِع [Shape.getVisualBounds](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getVisualBounds--) المستطيل المحسوب فقط ولا تقصه إلى الشريحة.

## **الأسئلة الشائعة**
**ما هي تنسيقات الصور التي يمكن استخدامها عند حفظ مصغرات الأشكال؟**

PNG, JPEG, BMP, GIF, TIFF، وغيرها. يمكن أيضًا [تم تصديرها كـ SVG متجه](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) عن طريق حفظ محتوى الشكل كـ SVG.

**ما هو الفرق بين حدود Shape و Appearance عند تصيير مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/java/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيظل يتم تصييره كمصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علامة الإخفاء تؤثر على عرض العرض التقديمي ولكنها لا تمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية والرسوم البيانية وSmartArt وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/smartart/)) يمكن حفظه كمصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة المصغرات لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/java/custom-font/) (أو [تهيئة بدائل الخطوط](/slides/ar/java/font-substitution/)) لتجنب الرجوع غير المرغوب فيه وإعادة تدفق النص.