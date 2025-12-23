---
title: تحويل عروض PowerPoint إلى فيديو في PHP
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/php-java/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض التقديمي إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض التقديمي إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT بصيغة MP4
- حفظ PPTX بصيغة MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- PHP
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو باستخدام Aspose.Slides للـ PHP. اكتشف رمز العينة وتقنيات الأتمتة لتبسيط سير عملك."
---

من خلال تحويل عرض PowerPoint التقديمي إلى فيديو، ستحصل على 

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مجهزة بتشغيل الفيديو افتراضيًا مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون الأمر أسهل في فتح أو تشغيل الفيديوهات.
* **توسيع الوصول:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون الفيديوهات أكثر من أشكال المحتوى الأخرى، وهم يفضلون هذا النوع من المحتوى عادةً.

{{% alert color="primary" %}} 

قد ترغب في فحص [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تنفيذ مباشر وفعّال للعملية الموضحة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/)، نفذنا دعمًا لتحويل العروض التقديمية إلى فيديو.

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من شرائح العرض) التي تتطابق مع معدل إطارات معين (FPS).
* استخدم أداة طرف ثالث مثل **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو بناءً على الإطارات.

### **تحويل PowerPoint إلى فيديو**

1. أضف هذا إلى ملف POM الخاص بك:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. حمّل ffmpeg [هنا](https://ffmpeg.org/download.html).

4. شغّل كود PHP للتحويل من PowerPoint إلى فيديو.

هذا كود PHP يوضح لك كيفية تحويل عرض تقديمي (يتضمن شكلًا وتأثيري تحريك) إلى فيديو:
```php
  $presentation = new Presentation();
  try {
    # يضيف شكل ابتسامة ثم يحركه
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubType::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # إعداد مجلد ملفات ffmpeg التنفيذية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **تأثيرات الفيديو**

يمكنك تطبيق الرسوم المتحركة على الكائنات في الشرائح واستخدام الانتقالات بين الشرائح. 

{{% alert color="primary" %}} 

قد ترغب في مشاهدة هذه المقالات: [رسوم متحركة في PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [رسوم متحركة للأشكال](https://docs.aspose.com/slides/php-java/shape-animation/), و[تأثير الشكل](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}} 

الرسوم المتحركة والانتقالات تجعل عروض الشرائح أكثر جذبًا وإثارة للاهتمام—وتفعل الشيء نفسه للفيديوهات. لنضيف شريحة وانتقالًا آخرين إلى الكود للعرض السابق:
```php
  # يضيف شكل ابتسامة ويحركه
  # ...
  # يضيف شريحة جديدة وانتقالًا متحركًا
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك فقرات على الكائنات، وستظهر واحدة تلو الأخرى (مع تأخير ثانية واحدة):
```php
  $presentation = new Presentation();
  try {
    # يضيف نصًا وحركات
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("convert PowerPoint Presentation with text to video"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("paragraph by paragraph"));
    $paragraphCollection = $autoShape->getTextFrame()->getParagraphs();
    $paragraphCollection->add($para1);
    $paragraphCollection->add($para2);
    $paragraphCollection->add($para3);
    $paragraphCollection->add(new Paragraph());
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effect1 = $mainSequence->addEffect($para1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect2 = $mainSequence->addEffect($para2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect3 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect4 = $mainSequence->addEffect($para3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $effect1->getTiming()->setTriggerDelayTime(1.0);
    $effect2->getTiming()->setTriggerDelayTime(1.0);
    $effect3->getTiming()->setTriggerDelayTime(1.0);
    $effect4->getTiming()->setTriggerDelayTime(1.0);
    $fps = 33;

    class FrameTick {
      function invoke($sender, $arg) {
            try {
                $frame = sprintf("frame_%04d.png", $sender->getFrameIndex());
                $arguments->getFrame()->save($frame, ImageFormat::Png);
                $frames->add($frame);
                } catch (JavaException $e) {
                  }
             }
    }

    $frames = new Java("java.util.ArrayList");
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, $fps);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
    # تكوين مجلد ملفات ffmpeg التنفيذية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **فئات تحويل الفيديو**

للسماح لك بأداء مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides الفئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) يتيح لك تعيين حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) عبر المُنشئ الخاص به. إذا مررّت نسخة من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` وينتج الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

عند إنشاء الرسوم المتحركة، يتم توليد حدث `NewAnimation` لكل رسمة متحركة لاحقة، والذي يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). الأخير هو فئة تمثل مشغلًا لرسمة متحركة منفصلة.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/)، تُستخدم خاصية [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للرسمة المتحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). يتم تعيين كل موقع للرسمة المتحركة ضمن نطاق *0 إلى المدة*، ثم تُرجع طريقة `GetFrame` صورة BufferedImage تتطابق مع حالة الرسمة المتحركة في تلك اللحظة:
```php
use aspose\slides\Presentation;
use aspose\slides\PresentationPlayer;
use aspose\slides\PresentationAnimationsGenerator;
use aspose\slides\ImageFormat;
use aspose\slides\ShapeType;
use aspose\slides\EffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectPresetClassType;

class PresentationAnimationPlayer {
    function invoke($animationPlayer) {
        echo(sprintf("Animation total duration: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// حالة الرسوم المتحركة الأولية
        try {
            # صورة حالة الرسوم المتحركة الأولية
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// الحالة النهائية للرسوم المتحركة
        try {
            # الإطار الأخير للرسوم المتحركة
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # يضيف شكل ابتسامة ويُحركه
    $smile = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::SmileyFace, 110, 20, 500, 500);
    $mainSequence = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $effectIn = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    $effectOut = $mainSequence->addEffect($smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    $effectIn->getTiming()->setDuration(2.0);
    $effectOut->setPresetClassType(EffectPresetClassType::Exit);
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    $presentationAnimation=java_closure(new PresentationAnimationPlayer(), null, java("com.aspose.slides.PresentationAnimationsGeneratorNewAnimation"));
    try {
        $animationsGenerator->setNewAnimation($presentationAnimation);
    } finally {
        if (!java_is_null($animationsGenerator)) {
            $animationsGenerator->dispose();
        }
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


لجعل جميع الرسوم المتحركة في عرض تقديمي تُشغل في وقت واحد، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/). هذه الفئة تأخذ نسخة من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) ومعدل FPS للتأثيرات في المُنشئ الخاص بها، ثم تستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:
```php

class FrameTick {
      function invoke($sender, $arg) {
            try {
                $arguments->getFrame()->save("frame_" . $sender->getFrameIndex() . ".png", ImageFormat::Png);
                } catch (JavaException $e) {
                  }
             }
    }

  $presentation = new Presentation("animated.pptx");
  try {
    $animationsGenerator = new PresentationAnimationsGenerator($presentation);
    try {
      $player = new PresentationPlayer($animationsGenerator, 33);
      try {
        $frameTick = java_closure(new FrameTick(), null, java("com.aspose.slides.PresentationPlayerFrameTick"));
        $player->setFrameTick($frameTick);
        $animationsGenerator->run($presentation->getSlides());
      } finally {
        if (!java_is_null($player)) {
          $player->dispose();
        }
      }
    } finally {
      if (!java_is_null($animationsGenerator)) {
        $animationsGenerator->dispose();
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


ثم يمكن تجميع الإطارات المُولدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**

**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

**هل من الممكن تحويل العروض التقديمية المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides العمل مع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/). عند معالجة هذه الملفات، يجب توفير كلمة المرور الصحيحة لكي تتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. صُممت المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسع لمعالجة الملفات على نطاق واسع.

**هل هناك أي حدود للحجم للعروض التقديمية أثناء التحويل؟**

يمكن لـ Aspose.Slides التعامل مع عروض تقديمية بحجم شبه غير محدود. ومع ذلك، عند العمل مع ملفات كبيرة جدًا قد تتطلب موارد نظام إضافية، وقد يُنصح أحيانًا بتحسين العرض لتحسين الأداء.