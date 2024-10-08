---
title: فن الكلمات
type: docs
weight: 110
url: /ar/php-java/wordart/
---


## **ما هو فن الكلمات؟**
فن الكلمات هو ميزة تتيح لك تطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام فن الكلمات، على سبيل المثال، يمكنك وضع إطار حول نص أو ملؤه بلون (أو تدرج)، وإضافة تأثيرات ثلاثية الأبعاد، إلخ. يمكنك أيضًا إمالة أو انحناء أو تمديد شكل النص.

{{% alert color="primary" %}} 

يتيح لك فن الكلمات التعامل مع النص كما تفعل مع كائن رسومي. بشكل عام، يتكون فن الكلمات من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحاً.

{{% /alert %}} 

**فن الكلمات في Microsoft PowerPoint**

لاستخدام فن الكلمات في Microsoft PowerPoint، عليك اختيار أحد قوالب فن الكلمات المحددة مسبقًا. قالب فن الكلمات هو مجموعة من التأثيرات التي تُطبق على نص أو شكله.

**فن الكلمات في Aspose.Slides**

في Aspose.Slides لـ PHP عبر Java 20.10، قمنا بتنفيذ دعم لفن الكلمات وأدخلنا تحسينات على الميزة في إصدارات Aspose.Slides اللاحقة لـ PHP عبر Java.

مع Aspose.Slides لـ PHP عبر Java، يمكنك بسهولة إنشاء قالب فن الكلمات الخاص بك (تأثير واحد أو مجموعة من التأثيرات) وتطبيقه على النصوص.

## إنشاء قالب فن كلمات بسيط وتطبيقه على نص

**باستخدام Aspose.Slides** 

أولاً، ننشئ نصًا بسيطًا باستخدام كود PHP هذا:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
الآن، نضع ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**باستخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات فن الكلمات في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير فن كلمات محدد مسبقًا. من القائمة على اليسار، يمكنك تحديد الإعدادات لفن كلمات جديد.

هذه بعض من المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق لون نمط [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) على النص ونضيف إطار نصي أسود بعرض 1 باستخدام هذا الكود:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## تطبيق تأثيرات فن كلمات أخرى

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نصية، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على نص؛ يمكن تطبيق تأثيرات التنسيق ثلاثي الأبعاد والدوران ثلاثي الأبعاد على كتلة نصية؛ خاصية الحواف الناعمة يمكن تطبيقها على كائن شكل (لا تزال تؤثر عند عدم تعيين خاصية التنسيق ثلاثي الأبعاد).

### تطبيق تأثيرات الظل

هنا، نعتزم تعيين الخصائص المتعلقة بالنص فقط. نقوم بتطبيق تأثير الظل على النص باستخدام هذا الكود:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

تدعم واجهة برمجة تطبيقات Aspose.Slides ثلاثة أنواع من الظلال: OuterShadow، InnerShadow، وPresetShadow.

مع PresetShadow، يمكنك تطبيق ظل على نص (باستخدام قيم محددة مسبقًا).

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

تتيح لك Aspose.Slides بالفعل تطبيق نوعين من الظلال في آن واحد: InnerShadow وPresetShadow.

**ملاحظات:**

- عند استخدام OuterShadow وPresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط. 
- إذا تم استخدام OuterShadow وInnerShadow في وقت واحد، يعتمد التأثير الناتج أو المطبق على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. ولكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow.

### تطبيق العرض على النصوص

نضيف عرض إلى النص من خلال عينة الكود هذه:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);

```

### تطبيق تأثير التوهج على النصوص

نطبق تأثير التوهج على النص لجعله يتألق أو يبرز باستخدام هذا الكود:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

يمكنك تغيير المعلمات الخاصة بالظل، العرض، والتوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل.

{{% /alert %}} 

### باستخدام التحولات في فن الكلمات

نستخدم خاصية التحويل (التي تعود لجميع كتلة النص) من خلال هذا الكود:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

يوفر كل من Microsoft PowerPoint وAspose.Slides لـ PHP عبر Java عددًا معينًا من أنواع التحولات المحددة مسبقًا.

{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحولات المحددة مسبقًا، انتقل إلى: **التنسيق** -> **تأثير النص** -> **تحويل**

**باستخدام Aspose.Slides**

لاختيار نوع التحويل، استخدم تعداد TextShapeType. 

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نقوم بتعيين تأثير ثلاثي الأبعاد على شكل النص باستخدام هذا الكود التجريبي:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثير ثلاثي الأبعاد على النص باستخدام كود PHP هذا:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

```

نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

يعتمد تطبيق التأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات على قواعد معينة. 

اعتبر مشهدًا لنص والشكل الذي يحتوي على هذا النص. يتضمن التأثير ثلاثي الأبعاد تمثيل كائن ثلاثي الأبعاد والمشهد الذي تم وضع الكائن فيه. 

- عند تعيين المشهد لكل من الشكل والنص، يكون لمشهد الشكل الأولوية الأعلى—يتم تجاهل مشهد النص. 
- عندما يفتقر الشكل إلى مشهد خاص به ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يتم استخدام مشهد النص. 
- بخلاف ذلك—عندما لا يحتوي الشكل في الأصل على تأثير ثلاثي الأبعاد—يكون الشكل مسطحًا ويتم تطبيق التأثير ثلاثي الأبعاد فقط على النص. 

تتعلق هذه الأوصاف بأساليب ThreeDFormat.getLightRig() وThreeDFormat.getCamera().

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
تقدم Aspose.Slides لـ PHP عبر Java الفصول [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) و[**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) التي تتيح لك تطبيق تأثيرات الظل على النص الذي تحمله [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). اتبع هذه الخطوات:

1. إنشاء مثيل من فصل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. إضافة شكل تلقائي من نوع مستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبط بالشكل التلقائي.
5. تعيين FillType للشكل التلقائي إلى NoFill.
6. إنشاء مثيل من فصل OuterShadow.
7. تعيين BlurRadius للظل.
8. تعيين اتجاه الظل.
9. تعيين مسافة الظل.
10. تعيين RectangleAlign إلى TopLeft.
11. تعيين PresetColor للظل إلى الأسود.
12. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

هذا الكود التجريبي — تنفيذاً للخطوات أعلاه — يوضح لك كيفية تطبيق تأثير الظل الخارجي على نص:

```php
  $pres = new Presentation();
  try {
    # الحصول على مرجع للشريحة
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع المستطيل
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("Aspose TextBox");
    # تعطيل ملء الشكل في حال أردنا الحصول على ظل النص
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة ظل خارجي وضبط جميع المعلمات الضرورية
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # كتابة العرض إلى القرص
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع هذه الخطوات:

1. إنشاء مثيل من فصل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. الحصول على مرجع للشريحة.
3. إضافة شكل تلقائي من نوع المستطيل.
4. تمكين InnerShadowEffect.
5. تعيين جميع المعلمات الضرورية.
6. تعيين ColorType كـ Scheme.
7. تعيين لون المخطط.
8. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

هذا الكود التجريبي (استنادًا إلى الخطوات أعلاه) يوضح لك كيفية إضافة موصل بين شكلين:

```php
  $pres = new Presentation();
  try {
    # الحصول على مرجع للشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من نوع المستطيل
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # تمكين InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # تعيين جميع المعلمات الضرورية
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # تعيين ColorType كمخطط
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # تعيين لون المخطط
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # حفظ العرض
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```