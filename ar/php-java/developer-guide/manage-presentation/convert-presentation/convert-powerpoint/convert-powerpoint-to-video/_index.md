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
description: "تعرف على كيفية تحويل عروض PowerPoint إلى فيديو باستخدام Aspose.Slides لـ PHP. اكتشف عينة الشيفرات وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

من خلال تحويل عرض PowerPoint التقديمي إلى فيديو، ستحصل على 

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام) مجهزة بمشغلات الفيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل مقاطع الفيديو.
* **نطاق أوسع:** من خلال مقاطع الفيديو، يمكنك الوصول إلى جمهور كبير وتوجيههم بمعلومات قد تبدو مملة في العرض التقديمي. تشير معظم الاستطلاعات والإحصاءات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من غيرها من أشكال المحتوى، وهم يفضّلون هذه النوعية من المحتوى عمومًا.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تنفيذ مباشر وفعّال للعملية الموصوفة هنا.
{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

يدعم Aspose.Slides تحويل العروض التقديمية إلى فيديو.

* استخدم **Aspose.Slides** لإنشاء مجموعة من الإطارات (من شرائح العرض) التي تتطابق مع عدد معين من الإطارات في الثانية (FPS).
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

4. شغّل كود PHP لتحويل PowerPoint إلى فيديو.

هذا الكود PHP يوضح لك كيفية تحويل عرض تقديمي (يحتوي على شكل وتأثيرين حركيين) إلى فيديو:
```php
  $presentation = new Presentation();
  try {
    # يضيف شكل بسمة ثم يحركه
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
    # تكوين مجلد ملفات ffmpeg الثنائيات. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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
قد ترغب في مشاهدة هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/php-java/shape-animation/), و[Shape Effect](https://docs.aspose.com/slides/php-java/shape-effect/).
{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتؤدي نفس الغرض للفيديوهات. لنضيف شريحة أخرى وانتقالًا إلى الكود للعرض التقديمي السابق:
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


يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، بحيث تظهر واحدة تلو الأخرى (مع تأخير محدد لثانية):
```php
  $presentation = new Presentation();
  try {
    # يضيف نصًا ورسومًا متحركة
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
    # تكوين مجلد ثنائيات ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
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

لتتيح لك أداء مهام تحويل PowerPoint إلى فيديو، يقدم Aspose.Slides فئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) .

[PresentationAnimationsGenerator] يتيح لك تحديد حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) عبر المُنشئ الخاص به. إذا قمت بتمرير نسخة من العرض التقديمي، سيتم استخدام `Presentation::getSlideSize` وهو يولد رسومًا متحركة يستخدمها [PresentationPlayer].

عند إنشاء الرسوم المتحركة، يتم توليد حدث `NewAnimation` لكل رسم متحرك لاحق، والذي يحتوي على معامل مشغل عرض الرسوم المتحركة. الأخير هو فئة تمثل مشغلًا لرسوم متحركة منفصلة.

للعمل مع مشغل عرض الرسوم المتحركة، تُستخدم طريقتا `getDuration` (المدة الكاملة للرسوم المتحركة) و`setTimePosition`. يتم ضبط كل موضع للرسوم المتحركة ضمن النطاق *0 إلى المدة*، ثم تعيد طريقة `getFrame` صورة BufferedImage تمثل حالة الرسوم المتحركة في تلك اللحظة:
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
            # صورة bitmap لحالة الرسوم المتحركة الأولية
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
    # يضيف شكل ابتسامة ويحركه
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


لجعل جميع الرسوم المتحركة في عرض تقديمي تُشغَل في آن واحد، تُستخدم فئة [PresentationPlayer]. تأخذ هذه الفئة نسخة من [PresentationAnimationsGenerator] وعدد FPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المُولَّدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

نعم، يتيح Aspose.Slides العمل مع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/). عند معالجة مثل هذه الملفات، يجب تقديم كلمة المرور الصحيحة بحيث يتمكن المكتبة من الوصول إلى محتوى العرض التقديمي.

**هل يدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. صُممت المكتبة للعمل في بيئات الخادم، مما يضمن أداءً عاليًا وقابلية توسع لمعالجة الملفات على دفعات.

**هل توجد أية قيود على حجم العروض التقديمية أثناء التحويل؟**

يستطيع Aspose.Slides معالجة عروض تقديمية بأي حجم تقريبًا. ومع ذلك، عند التعامل مع ملفات كبيرة جدًا، قد تكون هناك حاجة إلى موارد نظام إضافية، ويُنصح أحيانًا بتحسين العرض التقديمي لتحسين الأداء.