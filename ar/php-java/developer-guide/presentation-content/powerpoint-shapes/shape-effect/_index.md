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
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides لـ PHP عبر Java—أنشئ شرائح مبهرة ومهنية في ثوانٍ."
---
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [الملء](/slides/ar/php-java/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، وتوزيع توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يقدّم PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تراكيب التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات تحت **Preset**. خيارات Preset هي تراكيب من تأثيرين أو أكثر يُعرف أنها تبدو جيدة. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides لـ PHP عبر Java الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، واتجاهها، ومسافتها، ونصف قطر الضبابية لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق ظل خارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حواف الشكل، مما يخلق الانطباع بأن الشكل مرتفع فوق الشريحة. اضبط لونه، واتجاهه، ومسافته، ونصف قطر الضبابية لتتناسب مع الإضاءة وتنسيق القالب الخاص بك.

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

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط البصري للقالب، استخدم ظلًا داخليًا لمنح البطاقة أو اللوحة مظهرًا متراجعًا. يمتد الظل الخارجي خارج الشكل ويجعله يبدو مرتفعًا، بينما يظلل الظل الداخلي داخل حواف الشكل.

استدعِ [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)، ثم قم بتهيئة الظل المُرجع بواسطة [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). القيم الأكبر لنصف قطر الضبابية تنتج حوافًا أكثر نعومة.

ينشئ هذا المثال PHP بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX. اتجاه الظل هو 225 درجة، والمسافة 7 نقاط، ونصف قطر الضبابية 6 نقاط:

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

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides لـ PHP عبر Java، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، وضبط معلمات مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك التقديمية من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتعقيدًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides لـ PHP عبر Java، يمكنك إضافة هالة ناعمة ومتوهجة حول الأشكال، وضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى العرض التقديمي الخاص بك. من السهل تنفيذه بكود بسيط، مما يعزز المظهر العام لشرائحك.

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء انتقال ناعم وممحو حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر لطيف وناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك التقديمي.

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

استخدم تشويش الشكل لتنعيم تعبئة الشكل وخطه مع الحفاظ على إمكانية تعديل الشكل. استدعِ [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث تنتج القيم الأكبر تشويشًا أقوى. نصف القطر صفر يترك المظهر دون تغيير.

تتحكم إعدادات [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) في الحدود المرئية للتأثير. مع `false`، يتم قطع التشويش عند الحدود الأصلية المرسومة، بما في ذلك الخط الخارجي. مع `true`، يمكن للتشويش أن يمتد خارج تلك الحدود. لا يغيّر أيٌ من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والخط الخارجي وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنةً بنصف قطر الضبابية 5 و15 نقطة، مع تعطيل وتمكين خاصية النمو](shape_blur_comparison.png)

ينشئ هذا المثال PHP مستطيلًا برتقاليًا بخط خارجي أزرق داكن، يطبق تشويشًا بقوة 5 نقاط، ثم يحدّثه إلى تشويش بقوة 15 نقطة عن طريق استدعاء [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) مرة أخرى. يحفظ الحالتين المشوشتين، ثم يستدعِ [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) ويحفظ الشكل دون تشويش.

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

تؤثر ضبابية الشكل على التعبئة والخط الخارجي معًا. يخفّف تأثير الحواف الناعمة حواف الشكل، بينما يُنعّم تشويش الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق التشويش مباشرةً على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجموعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجموعة. سيُطبق التأثير على المجموعة بأكملها.