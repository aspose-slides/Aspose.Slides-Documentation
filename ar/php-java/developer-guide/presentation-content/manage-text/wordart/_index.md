---
title: إنشاء وتطبيق تأثيرات WordArt في PHP
linktitle: WordArt
type: docs
weight: 110
url: /ar/php-java/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهّج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ PHP عبر Java. هذا الدليل التفصيلي يساعد المطورين على تحسين العروض التقديمية بنص احترافي في PHP."
---
## **نظرة عامة**

تتيح تأثيرات WordArt تنسيق النص بملء، حدود، ظلال، انعكاسات، توهّج، تحويلات، وتنسيق ثلاثي الأبعاد. يشرح هذا المقال كيفية إنشاء هذه التأثيرات وتخصيصها في عروض PowerPoint باستخدام Aspose.Slides for PHP via Java، دون الحاجة لتثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

تبني الأمثلة التالية نمط WordArt بسيط عن طريق ضبط النص، الخط، ملء النمط، والحدود.

كل مثال ينشئ عرضًا جديدًا ويضيف مستطيلًا إلى الشريحة الأولى؛ لا يلزم ملف إدخال. المثال الأول يضبط النص إلى "Aspose.Slides". يتم قياس موضع الشكل وأبعاده بالنقاط:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

اضبط الخط إلى Arial Black بحجم 36 نقطة لتكون الصياغة أكثر وضوحًا:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

طبق نمط [SmallGrid](https://reference.aspose.com/slides/ar/php-java/aspose.slides/patternstyle/#SmallGrid) بتدرج برتقالي غامق في المقدمة وخلفية بيضاء، ثم أضف حدًا نصيًا أسود بعرض نقطة واحدة:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

توضح الأمثلة التالية كيفية تطبيق الظلال، الانعكاسات، التوهّج، التحويلات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

يضيف الظل الخارجي عمقًا بوضع ظل خلف النص. يمكنك تخصيص اللون، الاتجاه، المسافة، نصف قطر الضباب، المقياس، والإنحراف.

هذا المثال يستدعي [enableOuterShadowEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) ويضبط ظلًا أسود بنصف قطر ضباب 4 نقاط، اتجاه 230 درجة، ومسافة 30 نقطة. قيم المقياس 100 تحافظ على حجم الظل، بينما يميل الإنحراف الأفقي الزاوية 20 درجة. يُحدد تحويل ألفا الشفافية إلى 32٪:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="ملاحظة" %}}
- عند استخدام الظلال الخارجية والمسبقة معًا، يتم تطبيق الظل الخارجي فقط.
- إذا استُخدم الظلان الخارجي والداخلي في آنٍ واحد، فإن النتيجة تعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

ينشئ الانعكاس نسخةً مرآةً من النص. اضبط موضعه، مقياسه، الضباب، والشفافية للتحكم في مظهره.

هذا المثال يستدعي [enableReflectionEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effectformat/#enableReflectionEffect--) ويقلب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر ضباب 0.5 نقطة ومسافة 4.72 نقطة. تنخفض الشفافية من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهّج**

يضيف التوهّج حدًا ملونًا ناعمًا حول النص. اضبط اللون، الشفافية، ونصف القطر للتحكم في التأثير.

هذا المثال يستدعي [enableGlowEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effectformat/#enableGlowEffect--) ويطبق توهّجًا أحمر بشفافية 54٪ ونصف قطر 7 نقاط:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![تأثير التوهّج](glow_effect.png)

### **تطبيق تحويلات WordArt**

تحول WordArt يثني أو يمدد أو يشوه مجموعة من النصوص.

اضبط [setTransform](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setTransform-int-) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textshapetype/#ArchUpPour) لتقويس إطار النص بأكمله إلى الأعلى:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![تحويل WordArt](transform_effect.png)

{{% alert color="info" title="ملاحظة" %}}
Aspose.Slides for PHP via Java يوفر مجموعة من [أنواع التحويلات المحددة سلفًا](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على الشكل أو على نصه. تتحكم الحواف، البثق، الإضاءة، وإعدادات الكاميرا في المظهر النهائي.

المثال التالي يستخدم [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/) لإضافة حواف دائرية، بثق برتقالي، وحدود حمراء داكنة إلى المستطيل. تُقاس أبعاد الحواف، ارتفاع البثق، عرض الحد، والعمق بالنقاط. مادة بلاستيكية، إضاءة متوازنة تدور 40 درجة حول محور Z، وكاميرا منظور تحدد المظهر:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يطبق هذا المثال تنسيقًا ثلاثيًا أبعادًا مشابهًا على النص عبر [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#getThreeDFormat--). تصغر الحواف حواف الأحرف، بينما يمنح البثق والإضاءة النص عمقًا:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="ملاحظة" %}}
تُحكم قواعد محددة تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله—والتفاعل بين هذه التأثيرات. تخيّل مشهدًا يضم النص والشكل الذي يحتويه. يتضمن تأثير ثلاثي الأبعاد تمثيلًا ثلاثيًا كائنًا والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يُعطى أولوية لمشهد الشكل ويُتجاهل مشهد النص.
- إذا كان الشكل لا يمتلك مشهدًا خاصًا لكنه يحتوي تمثيلًا ثلاثيًا، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي أبعاد، يُعامل كمستوى مسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

تتعلق هذه السلوكيات بطريقتي [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getLightRig--) و[ThreeDFormat::getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

لمزيد من أمثلة التنسيق الثلاثي الأبعاد، راجع [إنشاء تأثيرات ثلاثية الأبعاد في العروض باستخدام PHP](/slides/ar/php-java/3d-presentation/).

## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides for PHP via Java Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، الملء، والحدود بغض النظر عن اللغة، رغم أن توفر الخط وعرضه قد يعتمدان على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشريحة؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في شرائح الماستر، بما في ذلك العناصر النائبة للعنوان، التذييل، أو النص الخلفي. سيتنعكس أي تعديل على تخطيط الماستر على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

تأثيرًا طفيفًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهّج، وملء التدرجات حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفرق عادةً يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [Slide::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage--)، أو تحويل الأشكال الفردية باستخدام [Shape::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getImage--). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.