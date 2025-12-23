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
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للـ PHP عبر Java. يقدِّم هذا الدليل خطوة بخطوة للمطوّرين طريقةً لتعزيز العروض التقديمية بنص احترافي."
---

## **حول WordArt؟**
WordArt أو Word Art هي ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها بارزة. باستخدام WordArt، على سبيل المثال، يمكنك تحديد حدود النص أو ملئه بلون (أو تدرج)، وإضافة تأثيرات ثلاثية الأبعاد إليه، إلخ. كما يمكنك أيضًا إمالة، انحناء، وتمديد شكل النص. 

{{% alert color="primary" %}} 
يسمح لك WordArt بمعاملة النص كما لو كان كائنًا رسوميًا. بشكل عام، يتكون WordArt من تأثيرات أو تعديلات خاصة تُجرى على النصوص لجعلها أكثر جاذبية أو وضوحًا. 
{{% /alert %}} 

**WordArt في Microsoft PowerPoint**

لاستخدام WordArt في Microsoft PowerPoint، عليك اختيار أحد قوالب WordArt المعرفة مسبقًا. قالب WordArt هو مجموعة من التأثيرات تُطبق على النص أو شكله. 

**WordArt في Aspose.Slides**

في Aspose.Slides for PHP via Java 20.10، نفّذنا دعمًا لـ WordArt وأجرينا تحسينات على الميزة في الإصدارات اللاحقة من Aspose.Slides for PHP via Java. 

مع Aspose.Slides for PHP via Java، يمكنك بسهولة إنشاء قالب WordArt الخاص بك (تأثير واحد أو مجموعة من التأثيرات) وتطبيقه على النصوص. 

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

**باستخدام Aspose.Slides** 

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الكود PHP:
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

الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**باستخدام Microsoft PowerPoint**

انتقل إلى قائمة تأثيرات WordArt في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير WordArt معرف مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات WordArt جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نطبق لون نمط [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) على النص ونضيف حدًا نصيًا أسود بسمك 1 باستخدام هذا الكود:
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

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص، كتلة نص، شكل، أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل، الانعكاس، والتوهج على النص؛ تأثيرات التنسيق ثلاثي الأبعاد والدوران ثلاثي الأبعاد يمكن تطبيقها على كتلة النص؛ وخاصية الحواف الناعمة يمكن تطبيقها على كائن الشكل (تظل لها تأثير حتى عند عدم ضبط خاصية التنسيق ثلاثي الأبعاد). 

### **تطبيق تأثيرات الظل**

هنا نهدف إلى ضبط الخصائص المتعلقة بالنص فقط. نطبق تأثير الظل على النص باستخدام هذا الكود :
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

مع PresetShadow، يمكنك تطبيق ظل للنص (باستخدام قيم مسبقة). 

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظلال. إليك مثالًا:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

في الواقع يسمح Aspose.Slides لك بتطبيق نوعين من الظلال في آن واحد: InnerShadow و PresetShadow.

**ملاحظات:**
- عندما يُستخدم OuterShadow و PresetShadow معًا، يُطبق فقط تأثير OuterShadow. 
- إذا تم استخدام OuterShadow و InnerShadow معًا، فإن النتيجة أو التأثير المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير. لكن في PowerPoint 2007 يُطبق تأثير OuterShadow. 

### **تطبيق تأثيرات الانعكاس على النص**

نضيف العرض للنص من خلال مثال الكود التالي :
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
يمكنك تغيير معلمات الظل، العرض، والتوهج. تُضبط خصائص التأثيرات على كل جزء من النص بشكل منفصل. 
{{% /alert %}} 

### **استخدام التحويلات في WordArt**

نستخدم خاصية Transform (الموجودة في كتلة النص بالكامل) عبر هذا الكود:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
يقدم كل من Microsoft PowerPoint و Aspose.Slides for PHP via Java عددًا معينًا من أنواع التحويلات المعرفة مسبقًا. 
{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحويلات المعرفة مسبقًا، انتقل عبر: **Format** -> **TextEffect** -> **Transform**

**باستخدام Aspose.Slides**

لتحديد نوع التحويل، استخدم تعداد TextShapeType. 

### **تطبيق تأثيرات ثلاثية الأبعاد على النص والأشكال**

نضبط تأثيرًا ثلاثيًا الأبعاد على شكل نص باستخدام مثال الكود التالي:
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


النص والشكل الناتج:

![todo:image_alt_text](image-20200930114816-9.png)

نطبق تأثيرًا ثلاثيًا الأبعاد على النص بهذا الكود PHP:
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
تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها وتفاعلات التأثيرات بين بعضها البعض يعتمد على قواعد معينة. 
ضع في الاعتبار مشهدًا للنص والشكل الذي يحتويه. يحتوي تأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي يُوضع فيه الكائن. 
- عندما يُحدد المشهد لكل من الشكل والنص، يحصل المشهد الخاص بالشكل على أولوية أعلى—ويُتجاهل مشهد النص. 
- عندما لا يملك الشكل مشهدًا خاصًا لكنه يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص. 
- وإلا—عندما لا يكون للشكل تأثير ثلاثي الأبعاد أصلاً—يبقى الشكل مسطحًا وتُطبق تأثيرات ثلاثية الأبعاد فقط على النص. 
هذه الأوصاف مرتبطة بالطرق ThreeDFormat.getLightRig() و ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **تطبيق تأثير الظل الخارجي على النص**
توفر Aspose.Slides for PHP via Java الفئتين [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) و [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) اللتين تسمحان لك بتطبيق تأثيرات الظل على النص الموجود داخل [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة باستخدام الفهرس.  
3. إضافة AutoShape من النوع Rectangle إلى الشريحة.  
4. الوصول إلى TextFrame المرتبط بـ AutoShape.  
5. تعيين FillType للـ AutoShape إلى NoFill.  
6. إنشاء كائن OuterShadow.  
7. تعيين BlurRadius للظل.  
8. تعيين Direction للظل.  
9. تعيين Distance للظل.  
10. تعيين RectanglelAlign إلى TopLeft.  
11. تعيين PresetColor للظل إلى Black.  
12. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/)  

هذا مثال الكود —تنفيذ للخطوات أعلاه— يوضح كيفية تطبيق تأثير الظل الخارجي على النص:
```php
  $pres = new Presentation();
  try {
    # احصل على مرجع الشريحة
    $sld = $pres->getSlides()->get_Item(0);
    # أضف AutoShape من النوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # أضف TextFrame إلى Rectangle
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
    # احفظ العرض التقديمي إلى القرص
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة.  
3. إضافة AutoShape من النوع Rectangle.  
4. تمكين InnerShadowEffect.  
5. تعيين جميع المعلمات الضرورية.  
6. تعيين ColorType إلى Scheme.  
7. تعيين Scheme Color.  
8. كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  

هذا مثال الكود (بناءً على الخطوات أعلاه) يوضح كيفية إضافة موصل بين شكلين :
```php
  $pres = new Presentation();
  try {
    # احصل على مرجع الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # أضف AutoShape من النوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # أضف TextFrame إلى المستطيل
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # تفعيل InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # تعيين جميع المعلمات الضرورية
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # تعيين ColorType كـ Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # تعيين لون المخطط
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # احفظ العرض التقديمي
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو أنظمة كتابة مختلفة (مثل العربية أو الصينية)؟**  
نعم، يدعم Aspose.Slides Unicode ويعمل مع جميع الخطوط والأنظمة الكتابية الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الرئيسية؟**  
نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في الشرائح الرئيسية، بما في ذلك عناصر النُسق، التذييل، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على النُسق الرئيسي على جميع الشرائح المرتبطة بها.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**  
تؤثر بشكل طفيف. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفرق غالبًا ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**  
نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `getImage` من واجهة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) أو [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.