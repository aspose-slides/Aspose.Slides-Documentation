---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام PHP
linktitle: رسوم متحركة للشكل
type: docs
weight: 60
url: /ar/php-java/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسوم متحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. تميز!"
---

الرسوم المتحركة هي تأثيرات مرئية يمكن تطبيقها على النصوص والصور والأشكال أو [المخططات](https://docs.aspose.com/slides/php-java/animated-charts/). إنها تضيف حياة إلى العروض التقديمية أو مكوّناتها.

## **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك  

* التحكم في تدفق المعلومات  
* تسليط الضوء على النقاط المهمة  
* زيادة الاهتمام أو المشاركة بين جمهورك  
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة  
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض التقديمي  

يُوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة الاسم `Aspose.Slides.Animation`،  
* توفر Aspose.Slides أكثر من **150 تأثيرًا متحركًا** ضمن تعداد [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). هذه التأثيرات هي أساسًا نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع نص**

تمكّن Aspose.Slides لـ PHP عبر Java من تطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع شريحة عبر فهرسها.  
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) على شكل مستطيل.  
4. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) الخاص بـ `AutoShape`.  
5. الحصول على تسلسل رئيسي من التأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).  
7. استخدام طريقة `TextAnimation.setBuildType` والقيمة من تعداد `BuildType`.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.  

يعرض هذا الكود PHP كيفية تطبيق تأثير `Fade` على AutoShape وتعيين رسوم النص إلى قيمة *By 1st Level Paragraphs*:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape جديد مع النص
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # يحصل على التسلسل الرئيسي للشرائح.
    $sequence = $sld->getTimeline()->getMainSequence();
    # يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # يحرك نص الشكل وفق الفقرات من المستوى الأول
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # يحفظ ملف PPTX إلى القرص
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/). راجع [**Animated Text**](/slides/ar/php-java/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) على الشريحة.  
4. الحصول على التسلسل الرئيسي للتأثيرات.  
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. كتابة العرض التقديمي إلى القرص كملف PPTX.  

يعرض هذا الكود PHP كيفية تطبيق تأثير `Fly` على إطار صورة:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    # تحميل صورة لتُضاف إلى مجموعة صور العرض التقديمي
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف إطار صورة إلى الشريحة
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # يضيف تأثير الطيران من اليسار إلى إطار الصورة
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # يحفظ ملف PPTX إلى القرص
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) على شكل مستطيل.  
4. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) بحد (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).  
5. إنشاء تسلسل من التأثيرات على شكل الـ bevel.  
6. إنشاء `UserPath` مخصص.  
7. إضافة أوامر للتحرك إلى `UserPath`.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.  

يعرض هذا الكود PHP كيفية تطبيق تأثير `PathFootball` (path football) على شكل:
```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # يضيف تأثير الرسوم المتحركة PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # ينشئ نوعًا ما من "زر".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # ينشئ سلسلة من التأثيرات لهذا الزر.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # ينشئ مسار مستخدم مخصص. سيتم تحريك الكائن فقط بعد النقر على الزر.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # يضيف أوامر الحركة لأن المسار المنشأ فارغ.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # يكتب ملف PPTX إلى القرص
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

توضح الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من الفئة [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود المثال التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # يحصل على التسلسل الرئيسي للرسوم المتحركة في الشريحة.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # يحصل على الشكل الأول في الشريحة الأولى.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من النائبات**

إذا كان الشكل في شريحة عادية يحتوي على نائبي محتوى موجودين في شريحة التخطيط و/أو الشريحة الرئيسية، وتم إضافة تأثيرات رسوم متحركة إلى هذه النائبات، فسيتم تشغيل جميع تأثيرات الشكل أثناء العرض، بما في ذلك تلك الموروثة من النائبات.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة فيها فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير رسوم متحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على نائبة التذييل في شريحة **التخطيط**.

![تأثير رسوم متحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على نائبة التذييل في شريحة **الماستر**.

![تأثير رسوم متحركة لشكل الماستر](master-shape-animation.png)

يُظهر الكود المثال التالي كيفية استخدام طريقة `getBasePlaceholder` من الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للوصول إلى نائبات الشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من النائبات الموجودة في شريحة التخطيط والماستر.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// احصل على تأثيرات الرسوم المتحركة للنائبة في شريحة التخطيط.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// احصل على تأثيرات الرسوم المتحركة للنائبة في شريحة الماستر.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```

```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


الإخراج:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // طيران, أسفل
Type: 134, subtype: 45            // انقسام, عمودي داخلي
Type: 126, subtype: 22            // أشرطة عشوائية, أفقي
```


## **تغيير أساليب توقيت تأثير الرسوم المتحركة**

تمكّن Aspose.Slides لـ PHP عبر Java من تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![لوحة توقيت الرسوم المتحركة](shape-animation.png)

هذه هي المقابلات بين توقيت PowerPoint وخصائص [Effect Timing](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming):

- قائمة **Start** المنسدلة في PowerPoint Timing تتطابق مع طريقة [Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType).  
- توقيت **Duration** في PowerPoint يتطابق مع طريقة [Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration). مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.  
- توقيت **Delay** في PowerPoint يتطابق مع طريقة [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime).  

هكذا تغير خصائص توقيت التأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. تعيين القيم الجديدة التي تحتاجها باستخدام طريقة [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming).  
3. حفظ ملف PPTX المعدل.  

يُظهر هذا الكود PHP العملية:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # يحصل على أول تأثير في التسلسل الرئيسي.
    $effect = $sequence->get_Item(0);
    # يغير TriggerType للتأثير ليبدأ عند النقر
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # يغير مدة التأثير
    $effect->getTiming()->setDuration(3.0);
    # يغير TriggerDelayTime للتأثير
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الطرق لتسمح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض هذا الكود PHP كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # يحصل على التسلسل الرئيسي للشرائح.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # يحصل على أول تأثير في التسلسل الرئيسي.
    $firstEffect = $sequence->get_Item(0);
    # يتحقق من تأثير "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # يضيف صوتًا للتأثير الأول
      $firstEffect->setSound($effectSound);
    }
    # يحصل على أول تسلسل تفاعلي للشرائح.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # يضبط علم تأثير "Stop previous sound"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع شريحة عبر فهرسها.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمّن لكل تأثير رسوم متحركة.  

يعرض هذا الكود PHP كيفية استخراج الصوت المضمّن في تأثير الرسوم المتحركة:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # يستخرج صوت التأثير في مصفوفة بايت
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **بعد الرسوم المتحركة**

تمكّن Aspose.Slides لـ PHP عبر Java من تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint](shape-after-animation.png)

قائمة التحديد **After animation** في PowerPoint تتطابق مع هذه الطرق:

- طريقة [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType) التي تصف نوع بعد الرسوم المتحركة:
  * PowerPoint **More Colors** يتطابق مع النوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color)؛
  * PowerPoint **Don't Dim** يتطابق مع النوع [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (نوع الرسوم المتحركة الافتراضي بعد الانتهاء)؛
  * PowerPoint **Hide After Animation** يتطابق مع النوع [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation)؛
  * PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick)؛
- طريقة [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor) التي تحدد تنسيق لون بعد الرسوم المتحركة. تعمل هذه الطريقة بالتزامن مع النوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). إذا تم تغيير النوع إلى آخر، سيتم مسح لون بعد الرسوم المتحركة.

يعرض هذا الكود PHP كيفية تغيير تأثير بعد الرسوم المتحركة:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # يحصل على أول تأثير في التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # يغيّر نوع الرسوم المتحركة بعد الانتهاء إلى اللون
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # يضبط لون التعتيم بعد الرسوم المتحركة
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحريك النص**

توفر Aspose.Slides هذه الطرق لتسمح لك بالعمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))؛
  - حسب الكلمة ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))؛
  - حسب الحرف ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))؛
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) يحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تمثل نسبة مدة التأثير. القيمة السالبة تمثل التأخير بالثواني.

هكذا تغير خصائص تحريك النص للتأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. استخدام طريقة `setBuildType(int value)` و قيمة [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) لإيقاف وضع *By Paragraphs*.  
3. تعيين القيم الجديدة باستخدام طريقتي [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. حفظ ملف PPTX المعدل.  

يعرض هذا الكود PHP العملية:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # يحصل على أول تأثير في التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # يغيّر نوع تحريك النص للتأثير إلى "ككائن واحد"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # يغيّر نوع تحريك النص للتأثير إلى "حسب الكلمة"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    $firstEffect->setDelayBetweenTextParts(20.0);
    # يكتب ملف PPTX إلى القرص
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**

[Export to HTML5](/slides/ar/php-java/export-to-html5/) وتمكين الـ[options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) المسؤولة عن [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) و[transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) للرسوم المتحركة. لا تقوم HTML العادية بتشغيل رسوم الشرائح، بينما تدعم HTML5 ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) ما يغطي ما. النتيجة المرئية تُحدَّد بتكوينهما معًا. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للتأثيرات والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، **الرسوم المتحركة مدعومة** (/slides/ar/php-java/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات محددة بشكل مختلف. يوصى باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.