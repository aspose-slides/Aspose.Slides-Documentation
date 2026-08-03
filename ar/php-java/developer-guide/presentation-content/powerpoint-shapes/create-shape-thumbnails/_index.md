---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في PHP
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/php-java/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- عرض الشكل
- تقديم الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة لأشكال PowerPoint باستخدام Aspose.Slides for PHP عبر Java – إنشاء وتصدير صور مصغرة للعروض التقديمية بسهولة."
---
## **المقدمة**

يُستخدم Aspose.Slides لإنشاء ملفات عروض تقديمية حيث كل صفحة هي شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. لكن في أحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات يساعدك Aspose.Slides على إنشاء صور مصغرة لأشكال الشرائح. يتم شرح كيفية استخدام هذه الميزة في هذه المقالة.  
تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة للشكل داخل حدود مظهره.

## **إنشاء صورة مصغرة للشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for PHP via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getImage) للشريحة المرجعية بالمقياس الافتراضي.
1. حفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال البرمجي يوضح لك كيفية إنشاء صورة مصغرة للشكل من شريحة:

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # حفظ الصورة على القرص بتنسيق PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء صورة مصغرة بمعامل مقياس محدد من قبل المستخدم**
لإنشاء صورة مصغرة للشكل في شريحة باستخدام Aspose.Slides for PHP via Java، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getImage) للشريحة المرجعية بأبعاد يحددها المستخدم.
1. حفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال البرمجي يوضح لك كيفية إنشاء صورة مصغرة للشكل بناءً على معامل مقياس معرف من قبل المستخدم:

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # حفظ الصورة على القرص بتنسيق PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تسمح هذه الطريقة بإنشاء صور مصغرة للأشكال بحيث تكون داخل حدود مظهر الشكل، مع مراعاة جميع تأثيرات الشكل. تكون الصورة المصغرة المحدودة بالحدود الخاصة بالشريحة. لإنشاء صورة مصغرة لشكل شريحة داخل حدود مظهره، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. حفظ صورة المصغرة بالتنسيق الذي تفضله.

هذا المثال البرمجي يعتمد على الخطوات السابقة:

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # حفظ الصورة على القرص بتنسيق PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على الحدود البصرية الفعلية للشكل**

خصائص الإطار لـ [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/)—`Shape::getX()`، `Shape::getY()`، `Shape::getWidth()`، و`Shape::getHeight()`—تصف المستطيل المخزن في نموذج العرض. المحتوى المعروض فعليًا يمكن أن يمتد خارج ذلك الإطار أو يشغل مستطيلًا محاذيًا مختلفًا. يمكن أن تغير الدوران، والحدود، ورؤوس السهام، وتخطيط النص وتدفقه، والهندسة التي يولدها SmartArt، وغيرها من تأثيرات العرض المنطقة المشغولة.

استخدم [Shape::getVisualBounds](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getVisualBounds) لحساب تلك المنطقة المشغولة دون إنشاء صورة. تُعيد الطريقة كائنًا من نوع [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) بإحداثيات الشريحة. المستطيل المرتجع غير مقصوص على الشريحة، لذا يمكن أن تكون إحداثياته سالبة عندما يمتد المحتوى خارج أصل الشريحة.

المثال التالي يحصل على حدود الإطار والحدود البصرية ويقارن بينهما:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

يمكن استخدام نفس كائن [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) لمحاذاة الأشكال المجاورة إلى حدها الأيسر أو الأيمن أو الأعلى أو الأسفل؛ أو لحجز مساحة كافية في تخطيط مُولد؛ أو لاكتشاف المحتوى خارج المنطقة المسموح بها. تكون الحدود البصرية مفيدة بشكل خاص لـ SmartArt، ومربعات النص، والأسهم، والصور، والأشكال المدارة، والأشكال الجماعية، حيث قد لا يمثل الإطار المخزن النتيجة المرئية بالكامل.

استخدم [Shape::getVisualBounds](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getVisualBounds) عندما تحتاج إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [Shape::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getImage) عندما تحتاج إلى عرض الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapethumbnailbounds/)، يُحدد `ShapeThumbnailBounds::Shape` حجم الصورة من حدود الشكل، بما في ذلك إعدادات الحدود، بينما يُحدد `ShapeThumbnailBounds::Appearance` حجمها من مظهر الشكل ويقيد النتيجة بحدود الشريحة. بالمقابل، تُعيد `Shape::getVisualBounds` فقط المستطيل المحسوب ولا تقصه على الشريحة.

## **الأسئلة المتكررة**

**ما صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كمتجه SVG](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/writeassvg/) بحفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود Shape و Appearance عند إنشاء صورة مصغرة؟**  
`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/php-java/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كخفي؟ هل سيظل يُنشأ كصورة مصغرة؟**  
يبقى الشكل المخفي جزءًا من النموذج ويمكن عرضه؛ علم الإخفاء يؤثر فقط على عرض الشرائح ولا يمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال الجماعية، والرسوم البيانية، وSmartArt، والكائنات المعقدة الأخرى؟**  
نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**  
نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/php-java/custom-font/) (أو [تهيئة استبدال الخطوط](/slides/ar/php-java/font-substitution/)) لتجنب البدائل غير المرغوب فيها وإعادة تدفق النص.