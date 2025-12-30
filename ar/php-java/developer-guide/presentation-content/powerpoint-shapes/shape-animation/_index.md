---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام PHP
linktitle: رسوم متحركة للأشكال
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
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](https://docs.aspose.com/slides/php-java/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها.

## **لماذا تستخدم الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات  
* التأكيد على النقاط الهامة  
* زيادة الاهتمام أو المشاركة بين جمهورك  
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة  
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض التقديمي  

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* Aspose.Slides يوفر الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الأسماء `Aspose.Slides.Animation`،  
* Aspose.Slides يوفر أكثر من **150 تأثير رسوم متحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

Aspose.Slides for PHP via Java يسمح لك بتطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. الحصول على تسلسل رئيسي للتأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
7. ضبط خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود PHP يوضح كيفية تطبيق تأثير `Fade` على AutoShape وضبط رسوم النص إلى القيمة *By 1st Level Paragraphs*:
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape جديدًا مع نص
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $sld->getTimeline()->getMainSequence();
    # يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # يُحرك نص الشكل حسب فقرات المستوى الأول
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
بجانب تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيقها على [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph) واحد. راجع [**Animated Text**](/slides/ar/php-java/animated-text/).  
{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) على الشريحة.  
4. الحصول على التسلسل الرئيسي للتأثيرات.  
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. كتابة العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود PHP يوضح كيفية تطبيق تأثير `Fly` على إطار الصورة:
```php
  # يقوم بإنشاء فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    # تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
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
    # يضيف تأثير Fly من اليسار إلى إطار الصورة
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


## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) (عند النقر على هذا الكائن يُشغل الرسوم المتحركة).  
5. إنشاء تسلسل للتأثيرات على الشكل المائل.  
6. إنشاء `UserPath` مخصص.  
7. إضافة أوامر للتحرك إلى `UserPath`.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود PHP يوضح كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```php
  # إنشاء فئة Presentation تمثل ملف PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء تأثير PathFootball للشكل الموجود من الصفر.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # إضافة تأثير PathFootBall للرسوم المتحركة
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # إنشاء نوع من "زر".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # إنشاء تسلسل من التأثيرات لهذا الزر.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # إضافة أوامر للتحريك لأن المسار الذي تم إنشاؤه فارغ.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # كتابة ملف PPTX إلى القرص
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

توضح الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من فئة [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**  

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود التالي كيفية الحصول على التأثيرات المطبقة على أول شكل في أول شريحة عادية في العرض `AnimExample_out.pptx`.  
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # يحصل على تسلسل الرسوم المتحركة الرئيسي للشريحة.
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


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك الموروثة من العناصر النائبة**  

إذا كان لل形 على شريحة عادية عناصر نائبة موجودة على شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات الرسوم المتحركة إلى هذه العناصر النائبة، فستُلعب جميع تأثيرات الشكل أثناء العرض، بما في ذلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة فيها شكل تذييل فقط بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير الرسوم المتحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أنه تم تطبيق تأثير **Split** على عنصر التذييل النائب في شريحة **التخطيط**.

![تأثير الرسوم المتحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر التذييل النائب في شريحة **القالب**.

![تأثير الرسوم المتحركة لشكل القالب](master-shape-animation.png)

يظهر الكود التالي كيفية استخدام طريقة `getBasePlaceholder` من فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للوصول إلى العناصر النائبة للأشكال والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والقالب.  
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// احصل على تأثيرات الرسوم المتحركة للشكل على الشريحة العادية.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة التخطيط.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة القالب.
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


Output:  
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // طيران, أسفل
Type: 134, subtype: 45            // تقسيم, عمودي داخل
Type: 126, subtype: 22            // أشرطة عشوائية, أفقي
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

Aspose.Slides for PHP via Java يسمح لك بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) :

- قائمة **Start** في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--).  
- **Duration** في PowerPoint تتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--). مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي لإكمال دورة واحدة.  
- **Delay** في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--).  

كيفية تغيير خصائص توقيت التأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. ضبط القيم الجديدة للخصائص في [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) التي تحتاجها.  
3. حفظ ملف PPTX المعدل.  

الكود PHP التالي يوضح العملية:  
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # يحصل على التأثير الأول في التسلسل الرئيسي.
    $effect = $sequence->get_Item(0);
    # يغيّر TriggerType للتأثير لتبدأ عند النقر
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # يغيّر مدة التأثير
    $effect->getTiming()->setDuration(3.0);
    # يغيّر TriggerDelayTime للتأثير
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

Aspose.Slides يوفر هذه الخصائص للعمل مع الأصوات في تأثيرات الرسوم المتحركة:

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

هذا الكود PHP يوضح كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:  
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
    # يحصل على التسلسل الرئيسي للشريحة.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # يحصل على التأثير الأول في التسلسل الرئيسي
    $firstEffect = $sequence->get_Item(0);
    # يتحقق مما إذا كان التأثير بدون صوت
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # يضيف صوتًا للتأثير الأول
      $firstEffect->setSound($effectSound);
    }
    # يحصل على التسلسل التفاعلي الأول للشريحة.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # يضبط علامة "إيقاف الصوت السابق" للتأثير
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # يكتب ملف PPTX إلى القرص
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **استخراج صوت لتأثير الرسوم المتحركة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المدمج في كل تأثير رسوم متحركة.  

هذا الكود PHP يوضح كيفية استخراج الصوت المدمج في تأثير الرسوم المتحركة:  
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
      # يستخرج صوت التأثير كمصفوفة بايت
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **بعد الرسوم المتحركة**

Aspose.Slides for PHP via Java يسمح لك بتغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** في PowerPoint تتطابق مع هذه الخصائص:

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) التي تحدد نوع After animation :
  * **More Colors** في PowerPoint يتطابق مع النوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color)؛
  * عنصر **Don't Dim** يتطابق مع النوع [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (النوع الافتراضي)؛
  * عنصر **Hide After Animation** يتطابق مع النوع [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation)؛
  * عنصر **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تعرّف صيغة لون After animation. تعمل هذه الخاصية مع النوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيُمسح لون After animation.  

هذا الكود PHP يوضح كيفية تغيير تأثير After animation:  
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # يحصل على التأثير الأول في التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # يغيّر نوع الرسوم المتحركة بعد العرض إلى اللون
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # يضبط لون التعتيم بعد الرسوم المتحركة
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # يكتب ملف PPTX إلى القرص
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحريك النص**

Aspose.Slides يوفر هذه الخصائص للعمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) التي تحدد نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - بالكامل مرة واحدة ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))؛
  - بحسب الكلمة ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))؛
  - بحسب الحرف ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter)).  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) يحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو حروف). القيمة الموجبة تمثل نسبة من مدة التأثير، والقيمة السالبة تمثل التأخير بالثواني.  

كيفية تغيير خصائص Animate text للتأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. ضبط خاصية [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) لإيقاف وضع *By Paragraphs*.  
3. ضبط القيم الجديدة لكل من خصائص [setAnimateTextType(int value)] و[setDelayBetweenTextParts(float value)].  
4. حفظ ملف PPTX المعدل.  

الكود PHP التالي يوضح العملية:  
```php
  # ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # يحصل على التأثير الأول في التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # يغيّر نوع تحريك النص للتأثير إلى "ككائن واحد"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # يغيّر نوع تحريك النص للتأثير إلى "حسب الكلمة"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # يحدد التأخير بين الكلمات إلى 20% من مدة التأثير
    $firstEffect->setDelayBetweenTextParts(20.0);
    # يكتب ملف PPTX إلى القرص
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**كيف يمكنني ضمان حفظ الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**  

[Export to HTML5](/slides/ar/php-java/export-to-html5/) وتمكين [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) المسؤولة عن [animateshapes](/slides/ar/php-java/aspose.slides/html5options/setanimateshapes/) و[animatetransitions](/slides/ar/php-java/aspose.slides/html5options/setanimatetransitions/). HTML العادي لا يشغل رسوم الشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**  

الرسوم المتحركة وترتيب الرسم مستقلان: التأثير يتحكم في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) ما يغطي ما. النتيجة المرئية تُحدد بتداخلهما. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لتأثيرات معينة؟**  

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/php-java/convert-powerpoint-to-video/)، لكن قد تُعالج بعض الحالات النادرة أو التأثيرات الخاصة بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.