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
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للـ PHP عبر Java. هذا الدليل خطوة بخطوة يساعد المطورين على تحسين العروض التقديمية بنصوص احترافية."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك وضع حد للنص أو تعبئته بلون (أو تدرج)، إضافة تأثيرات ثلاثية الأبعاد إليه، وما إلى ذلك. يمكنك أيضًا إمالة النص، انحنائه، وتمديد شكله. 

{{% alert color="primary" %}} 

WordArt يتيح لك التعامل مع النص كما تتعامل مع كائن رسومي. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُطبق على النصوص لجعلها أكثر جاذبية أو وضوحًا. 

{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد القوالب المعرّفة مسبقًا لـ WordArt. قالب WordArt هو مجموعة من التأثيرات التي تُطبّق على النص أو شكله. 

**WordArt في Aspose.Slides**

في Aspose.Slides for PHP via Java 20.10، قمنا بتنفيذ دعم WordArt وأجرينا تحسينات على الميزة في الإصدارات اللاحقة من Aspose.Slides for PHP via Java.  
مع Aspose.Slides for PHP via Java، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) وتطبيقه على النصوص.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

**استخدام Aspose.Slides** 

أولًا، نقوم بإنشاء نص بسيط باستخدام كود PHP التالي:
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

الآن، نقوم بضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا باستخدام هذا الكود:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);
```


**استخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt محدد مسبقًا. من القائمة على اليسار، يمكنك تحديد الإعدادات لـ WordArt جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**استخدام Aspose.Slides**

هنا، نطبق لون نمط [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/patternstyle/#SmallGrid) على النص ونضيف حدًا نصيًا أسود بعرض 1 باستخدام هذا الكود:
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

## **تطبيق تأثيرات WordArt أخرى**

**استخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نص، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ ويمكن تطبيق تنسيق 3D وتدوير 3D على كتلة النص؛ ويمكن تطبيق خاصية الحواف الناعمة على كائن شكل (ما زالت لها تأثير عندما لا يتم ضبط خاصية تنسيق 3D).

### **تطبيق تأثيرات الظل**

هنا، نهدف إلى ضبط الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود :
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


يدعم Aspose.Slides API ثلاثة أنواع من الظلال: OuterShadow و InnerShadow و PresetShadow.  
مع PresetShadow، يمكنك تطبيق ظل على النص (باستخدام قيم مسبقة). 

**استخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**استخدام Aspose.Slides**

في الواقع، يتيح Aspose.Slides تطبيق نوعين من الظلال في آن واحد: InnerShadow و PresetShadow.

**ملاحظات:**
- عندما يتم استخدام OuterShadow و PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط. 
- إذا تم استخدام OuterShadow و InnerShadow في وقت واحد، فإن النتيجة أو التأثير المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. لكن في PowerPoint 2007، يتم تطبيق تأثير OuterShadow. 

### **تطبيق تأثيرات الانعكاس على النص**

نضيف عرضًا إلى النص عبر عينة الكود التالية :
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


### **تطبيق تأثيرات التوهج على النص**

نطبق تأثير التوهج على النص لجعله يلمع أو يبرز باستخدام هذا الكود:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

يمكنك تغيير المعلمات للظل، العرض، والتوهج. يتم ضبط خصائص التأثيرات على كل جزء من النص بشكل منفصل. 

{{% /alert %}} 

### **استخدام التحويلات في WordArt**

نستخدم خاصية Transform (الموجودة في كتلة النص بالكامل) عبر هذا الكود:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

يقدم كل من Microsoft PowerPoint و Aspose.Slides for PHP via Java عددًا معينًا من أنواع التحويل المعرّفة مسبقًا.

{{% /alert %}} 

**استخدام PowerPoint**

للوصول إلى أنواع التحويل المعرّفة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**استخدام Aspose.Slides**

لتحديد نوع التحويل، استخدم تعداد TextShapeType. 

### **تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال**

نقوم بتعيين تأثير ثلاثي الأبعاد إلى شكل نص باستخدام عينة الكود التالية:
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

نطبق تأثير ثلاثي الأبعاد على النص باستخدام كود PHP التالي:
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

تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعلات هذه التأثيرات تعتمد على قواعد معينة.

اعتبر مشهدًا للنص والشكل الذي يحتوي على هذا النص. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وُضع فيه الكائن.

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل مشهد الشكل على أولوية أعلى—ويتم تجاهل مشهد النص.
- عندما يفتقر الشكل إلى مشهد خاص به ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- وإلا—عندما لا يحتوي الشكل أصلاً على تأثير ثلاثي الأبعاد—يكون الشكل مسطحًا ويتم تطبيق تأثير ثلاثي الأبعاد على النص فقط.

هذه الأوصاف مرتبطة بالطرق ThreeDFormat.getLightRig() و ThreeDFormat.getCamera().

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النص**

يوفر Aspose.Slides for PHP via Java فئتي [OuterShadow](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/) و [InnerShadow](https://reference.aspose.com/slides/php-java/aspose.slides/innershadow/) اللتين تتيحان لك تطبيق تأثيرات الظل على نص محمول بواسطة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). اتبع هذه الخطوات:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع شريحة باستخدام فهرسها.  
3. إضافة AutoShape من نوع مستطيل إلى الشريحة.  
4. الوصول إلى الـ TextFrame المرتبط بـ AutoShape.  
5. ضبط FillType للـ AutoShape إلى NoFill.  
6. إنشاء مثيل لفئة OuterShadow  
7. ضبط BlurRadius للظل.  
8. ضبط Direction للظل  
9. ضبط Distance للظل.  
10. ضبط RectanglelAlign إلى TopLeft.  
11. ضبط PresetColor للظل إلى Black.  
12. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

يعرض لك هذا الكود العيني —تنفيذ الخطوات السابقة— كيفية تطبيق تأثير الظل الخارجي على نص:
```php
  $pres = new Presentation();
  try {
    # الحصول على مرجع الشريحة
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع مستطيل
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("Aspose TextBox");
    # تعطيل تعبئة الشكل في حال أردنا الحصول على ظل النص
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة ظل خارجي وتعيين جميع المعلمات الضرورية
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تطبيق تأثيرات الظل الداخلي على الأشكال**

اتبع هذه الخطوات:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة.  
3. إضافة AutoShape من نوع Rectangle.  
4. تمكين InnerShadowEffect.  
5. ضبط جميع المعلمات اللازمة.  
6. ضبط ColorType إلى Scheme.  
7. ضبط Scheme Color.  
8. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

يوضح لك هذا الكود العيني (استنادًا إلى الخطوات أعلاه) كيفية إضافة موصل بين شكلين :
```php
  $pres = new Presentation();
  try {
    # الحصول على مرجع الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع مستطيل
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
    # تعيين ColorType كـ Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # تعيين لون Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # حفظ العرض التقديمي
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية، الصينية)؟**

نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد على أي لغة، على الرغم من أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر سلايد الماستر؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في سلايدات الماستر، بما في ذلك عناصر العنونة، التذييلات، أو النص الخلفي. سيتم عكس التغييرات التي تجريها على تخطيط الماستر عبر جميع السلايدات المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**

قليلاً. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج من حجم الملف بشكل طفيف بسبب إضافة بيانات تنسيق، لكن الفرق عادة ما يكون غير ملحوظ.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض التقديمي؟**

نعم، يمكنك تحويل السلايدات التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) أو [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض التقديمي بالكامل.