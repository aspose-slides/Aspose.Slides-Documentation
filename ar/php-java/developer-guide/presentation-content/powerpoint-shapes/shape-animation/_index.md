---
title: رسوم متحركة للشكل
type: docs
weight: 60
url: /ar/php-java/shape-animation/
keywords: "رسوم متحركة في PowerPoint, تأثير الرسوم المتحركة, تطبيق الرسوم المتحركة, عرض PowerPoint, Java, Aspose.Slides لـ PHP عبر Java"
description: "تطبيق الرسوم المتحركة في PowerPoint"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](https://docs.aspose.com/slides/php-java/animated-charts/). إنها تضفي الحيوية على العروض التقديمية أو مكوناتها.

### **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

من خلال استخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الفهم أو المعالجة
* جذب انتباه قرائك أو مشاهديك إلى الأجزاء المهمة في العرض التقديمي

توفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

### **الرسوم المتحركة في Aspose.Slides**

* يوفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة اسم `Aspose.Slides.Animation`
* يقدم Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** تحت تعداد [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

يسمح لك Aspose.Slides لـ PHP عبر Java بتطبيق الرسوم المتحركة على النص داخل شكل.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة شكل `مستطيل` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير الرسوم المتحركة إلى [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
7. تعيين خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الرمز PHP كيفية تطبيق تأثير `Fade` على AutoShape وتعيين الرسوم المتحركة للنص إلى قيمة *حسب فقرات المستوى الأول*:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape جديدة مع نص
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("الفقرة الأولى \nالفقرة الثانية \n الفقرة الثالثة");
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $sld->getTimeline()->getMainSequence();
    # إضافة تأثير Fade على الشكل
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # تحريك نص الشكل حسب فقرات المستوى الأول
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # حفظ ملف PPTX على القرص
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

بجانب تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [فقرة](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph) واحدة. راجع [**النصوص المتحركة**](/slides/ar/php-java/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) على الشريحة.
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير الرسوم المتحركة إلى [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).
6. كتابة العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الرمز PHP كيفية تطبيق تأثير `Fly` على إطار الصورة:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $pres = new Presentation();
  try {
    # تحميل الصورة لإضافتها في مجموعة صور العرض التقديمي
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # إضافة إطار الصورة إلى الشريحة
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # إضافة تأثير Fly من اليسار إلى إطار الصورة
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # حفظ ملف PPTX على القرص
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تطبيق الرسوم المتحركة على الشكل**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة شكل `مستطيل` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
4. إضافة شكل `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل Bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للحركة إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الرمز PHP كيفية تطبيق تأثير `PathFootball` (تأثير كرة القدم) على شكل:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء تأثير PathFootball لشكل موجود من الصفر.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("TextBox متحرك");
    # إضافة تأثير الرسوم المتحركة PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # إنشاء نوع من "زر".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # إنشاء تسلسل من التأثيرات لهذا الزر.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # إنشاء مسار مستخدم مخصص. سيتحرك كائننا فقط بعد النقر على الزر.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # إضافة أوامر للحركة حيث أن المسار الذي تم إنشاؤه فارغ.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # كتابة ملف PPTX على القرص
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على الشكل**

يمكنك أن تقرر معرفة جميع تأثيرات الرسوم المتحركة المطبقة على شكل واحد.

يظهر لك هذا الرمز PHP كيفية الحصول على جميع التأثيرات المطبقة على شكل معين:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # الحصول على أول شكل في الشريحة.
    $shape = $firstSlide->getShapes()->get_Item(0);
    # الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الشكل.
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("الشكل " . $shape->getName() . " لديه " . $Array->getLength($shapeEffects) . " تأثيرات رسوم متحركة.");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يسمح لك Aspose.Slides لـ PHP عبر Java بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هنا المراسلات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) هي:

- قائمة خيارات **البداية** في توقيت PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) .
- **مدة** توقيت PowerPoint تتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) . مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.
- **التأخير** في توقيت PowerPoint يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) .

هذه هي الطريقة التي يمكنك من خلالها تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) التي تحتاجها.
3. حفظ ملف PPTX المعدل.

يظهر لك هذا الرمز PHP العملية:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # الحصول على أول تأثير من التسلسل الرئيسي.
    $effect = $sequence->get_Item(0);
    # تغيير نوع TriggerType للتأثير ليبدأ عند النقر
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # تغيير مدة التأثير
    $effect->getTiming()->setDuration(3.0);
    # تغيير TriggerDelayTime للتأثير
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # حفظ ملف PPTX على القرص
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **صوت تأثير الرسوم المتحركة**

يوفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت تأثير الرسوم المتحركة**

يوضح لك هذا الرمز PHP كيفية إضافة صوت لتأثير الرسوم المتحركة والتوقف عنه عندما يبدأ التأثير التالي:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # إضافة صوت إلى مجموعة أصوات العرض التقديمي
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
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # الحصول على أول تأثير من التسلسل الرئيسي
    $firstEffect = $sequence->get_Item(0);
    # تحقق من التأثير "بدون صوت"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # إضافة صوت للتأثير الأول
      $firstEffect->setSound($effectSound);
    }
    # الحصول على أول تسلسل تفاعلي للشريحة.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # تعيين علم "إيقاف الصوت السابق" للتأثير
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # كتابة ملف PPTX إلى القرص
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمن في كل تأثير متحرك.

يظهر لك هذا الرمز PHP كيفية استخراج الصوت المضمن في تأثير الرسوم المتحركة:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # الحصول على التسلسل الرئيسي للشريحة.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # استخراج صوت التأثير في مصفوفة بايت
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **بعد الرسوم المتحركة**

يسمح لك Aspose.Slides لـ PHP عبر Java بتغيير خاصية "بعد الرسوم المتحركة" لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تتوافق قائمة خيارات **بعد الرسوم المتحركة** في PowerPoint مع هذه الخصائص: 

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع بعد الرسوم المتحركة :
  * تتطابق **ألوان إضافية** في PowerPoint مع نوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) ;
  * تطابق عنصر القائمة **لا تخفف** في PowerPoint مع نوع [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (نوع الرسوم المتحركة بعد الافتراضي) ;
  * تطابق عنصر القائمة **اخفاء بعد الرسوم المتحركة** مع نوع [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * تطابق عنصر القائمة **اخفاء عند النقر على الفأرة التالية** مع نوع [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) .
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تعرف صيغة اللون بعد الرسوم المتحركة. تعمل هذه الخاصية بالتعاون مع نوع [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) . إذا قمت بتغيير النوع إلى آخر، ستتم إزالة لون بعد الرسوم المتحركة.

يوضح لك هذا الرمز PHP كيفية تغيير تأثير الرسوم المتحركة بعد:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # الحصول على أول تأثير من التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # تغيير نوع بعد الرسوم المتحركة إلى اللون
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # تعيين لون تخفيف بعد الرسوم المتحركة
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # كتابة ملف PPTX إلى القرص
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحريك النص**

يوفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *تحريك النص* لتأثير الرسوم المتحركة:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - دفعة واحدة ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) نوع)
  - حسب الكلمة ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) نوع)
  - حسب الحرف ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) نوع)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تضبط التأخير بين أجزاء النص المتحرك (الكلمات أو الحروف). تحدد القيمة الإيجابية النسبة المئوية لمدة التأثير. بينما تشير القيمة السلبية إلى التأخير بالثواني.

هذه هي الطريقة التي يمكنك من خلالها تغيير خصائص تأثير تحريك النص:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين خاصية [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) إلى قيمة [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) لإيقاف وضع الرسوم المتحركة *حسب الفقرات*.
3. تعيين قيم جديدة لخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. حفظ ملف PPTX المعدل.

يظهر لك هذا الرمز PHP عملية التنفيذ:

```php
  # إنشاء مثيل من فئة عرض تقديمي يمثل ملف عرض تقديمي.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # الحصول على أول تأثير من التسلسل الرئيسي
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # تغيير نوع تأثير الرسوم المتحركة للنص إلى "كائن واحد"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # تغيير نوع تأثير الرسوم المتحركة للنص إلى "حسب الكلمة"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # تعيين التأخير بين الكلمات إلى 20% من مدة التأثير
    $firstEffect->setDelayBetweenTextParts(20.0);
    # كتابة ملف PPTX إلى القرص
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```