---
title: تحويل PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/php-java/convert-powerpoint-to-video/
keywords: "تحويل PowerPoint, PPT, PPTX, عرض تقديمي, فيديو, MP4, PPT إلى فيديو, PPT إلى MP4, Java, Aspose.Slides"
description: "تحويل PowerPoint إلى فيديو"
---

من خلال تحويل عرض PowerPoint التقديمي إلى فيديو، يمكنك الحصول على

* **زيادة في الوصول:** جميع الأجهزة (بغض النظر عن النظام) مزودة بمشغلات فيديو بشكل افتراضي مقارنةً بتطبيقات تشغيل العروض التقديمية، لذلك يجد المستخدمون أنه من الأسهل فتح أو تشغيل مقاطع الفيديو.
* **وصول أكبر:** من خلال مقاطع الفيديو، يمكنك الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من أشكال المحتوى الأخرى، وعادةً ما يفضلون هذا المحتوى.

{{% alert color="primary" %}} 

قد ترغب في التحقق من [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تطبيق مباشر وفعال للعملية الموضحة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/)، قمنا بتنفيذ دعم تحويل العرض التقديمي إلى فيديو.

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من شرائح العرض التقديمي) التي تتوافق مع معدل الإطارات المطلوب (FPS).
* استخدم أداة خارجية مثل **ffmpeg** ([لـ Java](https://github.com/bramp/ffmpeg-cli-wrapper)) لإنشاء فيديو استنادًا إلى الإطارات.

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

2. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).

4. قم بتشغيل كود PHP لتحويل PowerPoint إلى فيديو.

يوضح كود PHP هذا كيفية تحويل عرض تقديمي (يحتوي على شكل واثنين من تأثيرات الرسوم المتحركة) إلى فيديو:

```php
  $presentation = new Presentation();
  try {
    # إضافة شكل ابتسامة ثم تحريكه
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
    # تهيئة مجلد ثنائيات ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

قد ترغب في رؤية هذه المقالات: [رسوم متحركة PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-animation/)، [رسوم متحركة الشكل](https://docs.aspose.com/slides/php-java/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/php-java/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات العرض التقديمي أكثر جاذبية واهتمامًا—وهي تفعل الشيء نفسه بالنسبة لمقاطع الفيديو. دعنا نضيف شريحة أخرى وانتقال إلى كود العرض التقديمي السابق:

```php
  # إضافة شكل ابتسامة وتحريكه
  # ...
  # إضافة شريحة جديدة وانتقال متحرك
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، والتي ستظهر واحدة تلو الأخرى (مع تأخير مضبوط لثانية واحدة):

```php
  $presentation = new Presentation();
  try {
    # إضافة نصوص ورسوم متحركة
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 120, 300, 300);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Aspose Slides for Java"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("تحويل عرض PowerPoint مع نص إلى فيديو"));
    $para3 = new Paragraph();
    $para3->getPortions()->add(new Portion("فقرة تلو الأخرى"));
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
    # تهيئة مجلد ثنائيات ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

لتمكينك من تنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) الفئات.

تسمح لك [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) بتعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) من خلال بنائها. إذا قمت بتمرير مثيل من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` ويتم إنشاء الرسوم المتحركة التي تستخدمها [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/).

عندما يتم توليد الرسوم المتحركة، يتم توليد حدث `NewAnimation` لكل رسوم متحركة لاحقة، والذي يحتوي على بارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/). والأخير هو فئة تمثل لاعبًا لرسوم متحركة منفصلة.

للاتصال بـ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/)، يتم استخدام خاصية [Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#getDuration--) (المدة الكاملة للرسوم المتحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/php-java/aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). يتم تعيين كل موضع للرسوم المتحركة ضمن النطاق *0 إلى المدة*، ثم ستقدم طريقة `GetFrame` صورة مدعومة تتوافق مع حالة الرسوم المتحركة في تلك اللحظة:

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
        echo(sprintf("المدة الكلية للرسوم المتحركة: %f", $animationPlayer->getDuration()));
        $animationPlayer->setTimePosition(0);// الحالة الأولية للرسوم المتحركة
        try {
            # الحالة الأولية للرسوم المتحركة
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
    # إضافة شكل ابتسامة وتحريكه
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

لجعل كل الرسوم المتحركة في عرض تقديمي تلعب مرة واحدة، يتم استخدام فئة [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/). تأخذ هذه الفئة مثيل من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) وFPS للتأثيرات في بنائها ثم تستدعي حدث `FrameTick` لجميع الرسوم المتحركة للحصول على تشغيلها:

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

ثم يمكن تجميع الإطارات الناتجة لإنتاج فيديو. انظر قسم [تحويل PowerPoint إلى فيديو](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة المدعومة والتأثيرات**

**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الطيران إلى الداخل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التطفو إلى الداخل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الانقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو & دوران** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تحويل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **قنبلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبض لون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **اهتزاز** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو / انكماش** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تخفيف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تظليل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **إضاءة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الكائن** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون تكميلي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الطيران إلى الخارج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التطفو إلى الخارج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الانقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انكماش & دوران** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تحويل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **قنبلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **لفات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوائر** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |