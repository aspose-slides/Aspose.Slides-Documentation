---
title: Mengonversi Presentasi PowerPoint ke Video dalam PHP
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/php-java/convert-powerpoint-to-video/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke video
- presentasi ke video
- PPT ke video
- PPTX ke video
- PowerPoint ke MP4
- presentasi ke MP4
- PPT ke MP4
- PPTX ke MP4
- simpan PPT sebagai MP4
- simpan PPTX sebagai MP4
- ekspor PPT ke MP4
- ekspor PPTX ke MP4
- konversi video
- PowerPoint
- PHP
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint ke video dengan Aspose.Slides untuk PHP. Temukan contoh kode dan teknik otomatisasi untuk menyederhanakan alur kerja Anda."
---
## **Pengantar**

Dengan mengonversi presentasi PowerPoint Anda menjadi video, Anda mendapatkan 

* **Peningkatan aksesibilitas:** Semua perangkat (terlepas dari platform) dilengkapi dengan pemutar video secara default dibandingkan dengan aplikasi pembuka presentasi, sehingga pengguna lebih mudah membuka atau memutar video.
* **Jangkauan lebih luas:** Dengan video, Anda dapat menjangkau audiens yang besar dan menargetkan mereka dengan informasi yang mungkin terasa membosankan dalam presentasi. Sebagian besar survei dan statistik menunjukkan bahwa orang menonton dan mengonsumsi video lebih banyak daripada bentuk konten lainnya, dan mereka umumnya lebih menyukai konten tersebut.

{{% alert color="primary" %}} 

Anda mungkin ingin memeriksa [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/id/conversion/ppt-to-word) kami karena ini merupakan implementasi langsung dan efektif dari proses yang dijelaskan di sini.

{{% /alert %}} 

## **Konversi PowerPoint ke Video di Aspose.Slides**

Aspose.Slides mendukung konversi presentasi ke video.

* Gunakan **Aspose.Slides** untuk menghasilkan sekumpulan frame (dari slide presentasi) yang sesuai dengan FPS tertentu (frame per detik)
* Gunakan utilitas pihak ketiga seperti **ffmpeg** ([untuk java](https://github.com/bramp/ffmpeg-cli-wrapper)) untuk membuat video berdasarkan frame-frame tersebut.

### **Konversi PowerPoint ke Video**

Tambahkan ini ke file POM Anda:
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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/id/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/id/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/id/php-java/shape-effect/).

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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationplayer/) uses.

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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Kemudian frame yang dihasilkan dapat dikompilasi untuk menghasilkan video. Lihat bagian [Convert PowerPoint to Video](https://docs.aspose.com/slides/id/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

**Masuk**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fade** | ![didukung](v.png) | ![didukung](v.png) |
| **Fly In** | ![didukung](v.png) | ![didukung](v.png) |
| **Float In** | ![didukung](v.png) | ![didukung](v.png) |
| **Split** | ![didukung](v.png) | ![didukung](v.png) |
| **Wipe** | ![didukung](v.png) | ![didukung](v.png) |
| **Shape** | ![didukung](v.png) | ![didukung](v.png) |
| **Wheel** | ![didukung](v.png) | ![didukung](v.png) |
| **Random Bars** | ![didukung](v.png) | ![didukung](v.png) |
| **Grow & Turn** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zoom** | ![didukung](v.png) | ![didukung](v.png) |
| **Swivel** | ![didukung](v.png) | ![didukung](v.png) |
| **Bounce** | ![didukung](v.png) | ![didukung](v.png) |

**Penekanan**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Color Pulse** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Teeter** | ![didukung](v.png) | ![didukung](v.png) |
| **Spin** | ![didukung](v.png) | ![didukung](v.png) |
| **Grow/Shrink** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Desaturate** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Darken** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Lighten** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Transparency** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Object Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Complementary Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Line Color** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fill Color** | ![tidak didukung](x.png) | ![didukung](v.png) |

**Keluar**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Fade** | ![didukung](v.png) | ![didukung](v.png) |
| **Fly Out** | ![didukung](v.png) | ![didukung](v.png) |
| **Float Out** | ![didukung](v.png) | ![didukung](v.png) |
| **Split** | ![didukung](v.png) | ![didukung](v.png) |
| **Wipe** | ![didukung](v.png) | ![didukung](v.png) |
| **Shape** | ![didukung](v.png) | ![didukung](v.png) |
| **Random Bars** | ![didukung](v.png) | ![didukung](v.png) |
| **Shrink & Turn** | ![tidak didukung](x.png) | ![didukung](v.png) |
| **Zoom** | ![didukung](v.png) | ![didukung](v.png) |
| **Swivel** | ![didukung](v.png) | ![didukung](v.png) |
| **Bounce** | ![didukung](v.png) | ![didukung](v.png) |

**Jalur Gerakan**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![didukung](v.png) | ![didukung](v.png) |
| **Arcs** | ![didukung](v.png) | ![didukung](v.png) |
| **Turns** | ![didukung](v.png) | ![didukung](v.png) |
| **Shapes** | ![didukung](v.png) | ![didukung](v.png) |
| **Loops** | ![didukung](v.png) | ![didukung](v.png) |
| **Custom Path** | ![didukung](v.png) | ![didukung](v.png) |

## **FAQ**

**Apakah mungkin mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides memungkinkan bekerja dengan [presentasi yang dilindungi kata sandi](/slides/id/php-java/password-protected-presentation/). Saat memproses file tersebut, Anda harus menyediakan kata sandi yang benar agar perpustakaan dapat mengakses isi presentasi.

**Apakah Aspose.Slides mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch berkas.

**Apakah ada batasan ukuran untuk presentasi saat konversi?**

Aspose.Slides mampu menangani presentasi dengan hampir semua ukuran. Namun, saat bekerja dengan file yang sangat besar, mungkin diperlukan sumber daya sistem tambahan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.