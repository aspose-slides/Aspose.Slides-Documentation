---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน PHP
linktitle: PowerPoint ไปเป็นวิดีโอ
type: docs
weight: 130
url: /th/php-java/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็นวิดีโอ
- งานนำเสนอไปเป็นวิดีโอ
- PPT ไปเป็นวิดีโอ
- PPTX ไปเป็นวิดีโอ
- PowerPoint ไปเป็น MP4
- งานนำเสนอไปเป็น MP4
- PPT ไปเป็น MP4
- PPTX ไปเป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นวิดีโอด้วย Aspose.Slides สำหรับ PHP. ค้นหาโค้ดตัวอย่างและเทคนิคการทำงานอัตโนมัติเพื่อปรับปรุงกระบวนการทำงานของคุณ."
---
## **บทนำ**

โดยการแปลงงานนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้รับ 

* **เพิ่มความสามารถในการเข้าถึง:** อุปกรณ์ทั้งหมด (ไม่ว่าจะเป็นแพลตฟอร์มใด) มีโปรแกรมเล่นวิดีโอติดตั้งมาโดยอัตโนมัติเมื่อเทียบกับแอปพลิเคชันเปิดงานนำเสนอ ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอได้ง่ายขึ้น
* **เข้าถึงได้มากขึ้น:** ด้วยวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและสื่อสารข้อมูลที่อาจดูน่าเบื่อหากนำเสนอในรูปแบบสไลด์ การสำรวจและสถิติส่วนใหญ่แสดงว่าผู้คนดูและบริโภควิดีโอมากกว่ารูปแบบเนื้อหาอื่น ๆ และโดยทั่วไปพวกเขาชอบเนื้อหาแบบนี้

{{% alert color="primary" %}} 

คุณอาจต้องการตรวจสอบ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) เนื่องจากเป็นการนำไปใช้จริงและมีประสิทธิภาพของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}} 

## **การแปลง PowerPoint เป็นวิดีโอใน Aspose.Slides**

Aspose.Slides รองรับการแปลงงานนำเสนอเป็นวิดีโอ

* ใช้ **Aspose.Slides** เพื่อสร้างชุดเฟรม (จากสไลด์งานนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้ยูทิลิตี้ของบุคคลที่สามอย่าง **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) เพื่อสร้างวิดีโอตามเฟรมที่ได้

### **แปลง PowerPoint เป็นวิดีโอ**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```

2. Download ffmpeg [here](https://ffmpeg.org/download.html).

4. Run the PowerPoint to video PHP code.

This PHP code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

```php
  $presentation = new Presentation();
  try {
    # Adds a smile shape and then animates it
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
    # Configure ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/th/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/th/php-java/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```php
  # Adds a smile shape and animates it
  # ...
  # Adds a new slide and animated transition
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);

```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second):

```php
  $presentation = new Presentation();
  try {
    # Adds text and animations
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
    # Configure ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationplayer/) uses.

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the presentation animation player parameter. The latter is a class that represents a player for a separate animation.

To work with the presentation animation player, the `getDuration` (the full duration of the animation) and   `setTimePosition` methods are used. Each animation position is set within the *0 to duration* range, and then the `getFrame` method will return a BufferedImage that corresponds to the animation state at that moment:

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
        $animationPlayer->setTimePosition(0);// initial animation state
        try {
            # initial animation state bitmap
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// final state of the animation
        try {
            # last frame of the animation
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # Adds a smile shape and animates it
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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

แล้วกรอบที่สร้างขึ้นสามารถคอมไพล์เพื่อผลิตวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video)

## **การสนับสนุนการเคลื่อนไหวและเอฟเฟกต์**

**การเข้า**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Fade** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Fly In** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Float In** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Split** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Wipe** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Shape** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Wheel** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Random Bars** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Grow & Turn** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Zoom** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Swivel** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Bounce** | ![รองรับ](v.png) | ![รองรับ](v.png) |

**การเน้น**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Color Pulse** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Teeter** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Spin** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Grow/Shrink** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Desaturate** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Darken** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Lighten** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Transparency** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Object Color** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Complementary Color** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Line Color** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Fill Color** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |

**การออก**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Fade** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Fly Out** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Float Out** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Split** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Wipe** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Shape** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Random Bars** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Shrink & Turn** | ![ไม่รองรับ](x.png) | ![รองรับ](v.png) |
| **Zoom** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Swivel** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Bounce** | ![รองรับ](v.png) | ![รองรับ](v.png) |

**เส้นทางการเคลื่อนไหว**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Arcs** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Turns** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Shapes** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Loops** | ![รองรับ](v.png) | ![รองรับ](v.png) |
| **Custom Path** | ![รองรับ](v.png) | ![รองรับ](v.png) |

## **คำถามที่พบบ่อย**

**สามารถแปลงงานนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ Aspose.Slides รองรับการทำงานกับ [งานนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/) เมื่อประมวลผลไฟล์เหล่านี้ คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของงานนำเสนอได้

**Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ใช่ Aspose.Slides สามารถรวมเข้าไปในแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ เพื่อให้มีประสิทธิภาพสูงและสามารถขยายได้สำหรับการประมวลผลไฟล์แบบกลุ่ม

**มีข้อจำกัดขนาดของงานนำเสนอระหว่างการแปลงหรือไม่?**

Aspose.Slides สามารถจัดการงานนำเสนอที่มีขนาดเกือบทั้งหมดได้ อย่างไรก็ตามเมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องการทรัพยากรระบบเพิ่มขึ้น และบางครั้งอาจแนะนำให้ปรับแต่งงานนำเสนอเพื่อเพิ่มประสิทธิภาพ