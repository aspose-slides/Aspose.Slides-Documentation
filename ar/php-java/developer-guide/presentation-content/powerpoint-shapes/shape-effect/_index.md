---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام PHP
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/php-java/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides للـ PHP عبر Java—أنشئ شرائح ملفتة ومهنية في ثوانٍ."
---
## **مقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئات](/slides/ar/php-java/shape-formatting/#gradient-fill) أو المخططات. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، إلخ.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **Preset**. خيارات Preset هي تركيبات من تأثيرين أو أكثر تُعرف بأنها تبدو جيدة. بهذه الطريقة، عند اختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides الخصائص والطرق تحت فئة [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides للـ PHP عبر Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، ومسافتها، ونصف قطر الضبابية لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق الظل الخارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز مقابل خلفية الشريحة. يمتد الظل إلى ما بعد حواف الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. عدل لونه، واتجاهه، ومسافته، ونصف قطر الضبابية ليتناسب مع الإضاءة وتنسيق القالب.

يعرض هذا الكود PHP كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) على مستطيل:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![تأثير الظل](shadow_effect.png)

#### **التحكم في اتجاه الظل عندما يدور الشكل**

بشكل افتراضي، يدور الظل الخارجي مع الشكل. لجعل الأشكال ذات الدورانات المختلفة تبدو مضاءة من نفس الاتجاه، استدعِ [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) مع `false` واستخدم [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) لإعطاء ظلالها نفس الاتجاه.

ينشئ المثال سهمين أزرقين بظلال رمادية إزاحتها 42 نقطة إلى اليمين (0°). ثم يكرر الشريحة ويدور السهمين 90° في اتجاه عقارب الساعة.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في الشريحة الثانية، يسقط السهم الأيسر ظله إلى الأسفل، بينما ما زال السهم الأيمن يلقي ظله إلى اليمين. يبقى الاتجاه المُضبط 0° لكلا الظلين.

![تصيير PowerPoint قبل وبعد دوران 90°. يبدأ كلا الظلين على اليمين. بعد الدوران، ينتقل الظل أسفل السهم الأيسر ويبقى إلى يمين السهم الأيمن.](arrow-shadow-rotation.png)

### **تطبيق الظل الداخلي**

عند إعادة إنتاج نمط القالب البصري، استخدم الظل الداخلي لإعطاء بطاقة أو لوحة مظهرًا منقوشًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)، ثم قم بتكوين الظل الذي تُعيده [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). قيم نصف قطر الضبابية الأكبر تنتج حوافًا أطرى.

ينشئ هذا المثال PHP بطاقة زرقاء فاتحة بظل داخلي رمادي غامق ويحفظها كملف PPTX. اتجاه الظل هو 225 درجة، والمسافة 7 نقاط، ونصف قطر الضبابية 6 نقاط:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![مستطيل أزرق فاتح بظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) على تنسيق تأثير الشكل.

### **تطبيق وتغيير وإزالة ظل مُسبق الإعداد**

استدعِ [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) لتمكين ظل مسبق الإعداد. استخدم [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) لاختيار [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) أو للانتقال إلى نمط آخر على نفس الشكل. استدعِ [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) لإزالة الظل مع الحفاظ على التعبئة والمخطط.

ينسخ هذا المثال PHP المستطيل بعد كل من المراحل الثلاث الأولى بحيث يمكنك مقارنة جميع المراحل الأربع جنبًا إلى جنب على شريحة واحدة. كلا الظلين إزاحتهما 10 نقاط. اتجاه 225° يضع الظل الأول فوق ويسار المستطيل، و45° يضع الظل الثاني أسفل ويسار المستطيل.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| الأصل | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل قطر أعلى يسار](preset_shadow_top_left.png) | ![ظل قطر أسفل يمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides للـ PHP عبر Java، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع ضبط معلمات مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتأنقًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

يعرض هذا الكود PHP كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) على شكل:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير التوهج على شكل في Aspose.Slides للـ PHP عبر Java، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى عرضك التقديمي. من السهل تنفيذه بكود بسيط، مما يحسن المظهر العام لشرائحك.

يعرض هذا الكود PHP كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) على شكل:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides للـ PHP عبر Java، يمكنك إنشاء انتقال ناعم ومُطمّس حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقةً وتفصيلًا، وهو مثالي للتصاميم التي تحتاج إلى مظهرٍ هادئٍ وناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر مختلف الأشكال في عرضك.

يعرض هذا الكود PHP كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) على شكل:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتنعيم تعبئة وشكل الحد للأشكال مع الحفاظ على قابلية تحرير الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تنتج القيم الأكبر ضبابية أقوى. نصف القطر صفر يترك المظهر دون تغيير.

تتحكم إعدادات [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) في الحدود المرئية للتأثير. مع `false`، يتم قص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك المخطط. مع `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والمخطط وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنةً بنصف قطر ضبابية 5 و15 نقطة، مع تمكين وتعطيل النمو](shape_blur_comparison.png)

ينشئ هذا المثال PHP مستطيلًا برتقاليًا مع مخطط أزرق داكن، يطبق ضبابية 5 نقاط، ثم يحدّثها إلى ضبابية 15 نقطة باستدعاء [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) ويحفظ الشكل بدون ضبابية.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تؤثر ضبابية الشكل على التعبئة والمخطط معًا. يخفف تأثير الحواف الناعمة حواف الشكل، بينما ينعّم ضبابية الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر حيوية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بالكامل.