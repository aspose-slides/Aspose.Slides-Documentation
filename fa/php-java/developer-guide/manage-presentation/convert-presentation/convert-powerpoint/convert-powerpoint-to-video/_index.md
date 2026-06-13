---
title: تبدیل ارائه‌های PowerPoint به ویدئو در PHP
linktitle: PowerPoint به ویدئو
type: docs
weight: 130
url: /fa/php-java/convert-powerpoint-to-video/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به ویدئو
- ارائه به ویدئو
- PPT به ویدئو
- PPTX به ویدئو
- PowerPoint به MP4
- ارائه به MP4
- PPT به MP4
- PPTX به MP4
- ذخیره PPT به عنوان MP4
- ذخیره PPTX به عنوان MP4
- صدور PPT به MP4
- صدور PPTX به MP4
- تبدیل ویدئو
- PowerPoint
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را با Aspose.Slides برای PHP به ویدئو تبدیل کنید. کدهای نمونه و تکنیک‌های خودکارسازی را کشف کنید تا جریان کاری خود را بهبود بخشید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint خود به ویدئو، شما دریافت می‌کنید 

* **افزایش دسترسی‌پذیری:** تمام دستگاه‌ها (بدون در نظر گرفتن پلتفرم) به‌طور پیشفرض دارای پخش‌کنندگان ویدئو هستند در مقایسه با برنامه‌های باز کردن ارائه، بنابراین کاربران راحت‌تر می‌توانند ویدئوها را باز یا پخش کنند.
* **دسترس‌پذیری بیشتر:** از طریق ویدئوها می‌توانید به مخاطب بزرگ دست پیدا کنید و اطلاعاتی را به آن‌ها ارائه دهید که در صورت ارائه ممکن است خسته‌کننده به نظر برسد. اکثر نظرسنجی‌ها و آمارها نشان می‌دهند که مردم ویدئوها را بیشتر از سایر انواع محتوا مشاهده و مصرف می‌کنند و عموماً این نوع محتوا را ترجیح می‌دهند.

{{% alert color="primary" %}} 

ممکن است بخواهید [**مبدل آنلاین PowerPoint به ویدئو**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما را بررسی کنید زیرا این یک اجرای زنده و مؤثر از فرایندی است که در اینجا توصیف شده است.

{{% /alert %}} 

## **تبدیل PowerPoint به ویدئو در Aspose.Slides**

Aspose.Slides از تبدیل ارائه به ویدئو پشتیبانی می‌کند.

* از **Aspose.Slides** برای تولید مجموعه‌ای از فریم‌ها (از اسلایدهای ارائه) که متناسب با FPS مشخصی (فریم در ثانیه) هستند استفاده کنید
* از یک ابزار شخص ثالث مانند **ffmpeg** ([برای java](https://github.com/bramp/ffmpeg-cli-wrapper)) برای ایجاد ویدئو بر پایه فریم‌ها استفاده کنید.

### **تبدیل PowerPoint به ویدئو**

۱. این را به فایل POM خود اضافه کنید:
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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/fa/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/fa/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/fa/php-java/shape-effect/).

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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationplayer/) uses.

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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

سپس فریم‌های تولید شده می‌توانند برای تولید یک ویدئو ترکیب شوند. بخش [تبدیل PowerPoint به ویدئو](https://docs.aspose.com/slides/fa/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

**ورود**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظاهر شدن** | ![not supported](x.png) | ![supported](v.png) |
| **محو شدن** | ![supported](v.png) | ![supported](v.png) |
| **ورود پروازی** | ![supported](v.png) | ![supported](v.png) |
| **ورود شناور** | ![supported](v.png) | ![supported](v.png) |
| **تقسیم** | ![supported](v.png) | ![supported](v.png) |
| **پاک‌سازی** | ![supported](v.png) | ![supported](v.png) |
| **شکل** | ![supported](v.png) | ![supported](v.png) |
| **چرخ** | ![supported](v.png) | ![supported](v.png) |
| **نوارهای تصادفی** | ![supported](v.png) | ![supported](v.png) |
| **رشد و چرخش** | ![not supported](x.png) | ![supported](v.png) |
| **بزرگ‌نمایی** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **پره‌پری** | ![supported](v.png) | ![supported](v.png) |

**تاکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **پالس** | ![not supported](x.png) | ![supported](v.png) |
| **پالس رنگ** | ![not supported](x.png) | ![supported](v.png) |
| **تکان** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **رشد/کوچک‌ شدن** | ![not supported](x.png) | ![supported](v.png) |
| **کاهش اشباع** | ![not supported](x.png) | ![supported](v.png) |
| **تیره کردن** | ![not supported](x.png) | ![supported](v.png) |
| **روشن کردن** | ![not supported](x.png) | ![supported](v.png) |
| **شفافیت** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ شیء** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ تکمیلی** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ خط** | ![not supported](x.png) | ![supported](v.png) |
| **رنگ پرکردن** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **ناپدید شدن** | ![not supported](x.png) | ![supported](v.png) |
| **محو شدن** | ![supported](v.png) | ![supported](v.png) |
| **خروج پروازی** | ![supported](v.png) | ![supported](v.png) |
| **خروج شناور** | ![supported](v.png) | ![supported](v.png) |
| **تقسیم** | ![supported](v.png) | ![supported](v.png) |
| **پاک‌سازی** | ![supported](v.png) | ![supported](v.png) |
| **شکل** | ![supported](v.png) | ![supported](v.png) |
| **نوارهای تصادفی** | ![supported](v.png) | ![supported](v.png) |
| **کوچک‌ شدن و چرخش** | ![not supported](x.png) | ![supported](v.png) |
| **بزرگ‌نمایی** | ![supported](v.png) | ![supported](v.png) |
| **چرخش** | ![supported](v.png) | ![supported](v.png) |
| **پره‌پری** | ![supported](v.png) | ![supported](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **قوس‌ها** | ![supported](v.png) | ![supported](v.png) |
| **چرخش‌ها** | ![supported](v.png) | ![supported](v.png) |
| **اشکال** | ![supported](v.png) | ![supported](v.png) |
| **حلقه‌ها** | ![supported](v.png) | ![supported](v.png) |
| **مسیر سفارشی** | ![supported](v.png) | ![supported](v.png) |

## **پرسش‌های متداول**

**آیا امکان تبدیل ارائه‌های محافظت‌شده با رمز عبور وجود دارد؟**

بله، Aspose.Slides امکان کار با [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/php-java/password-protected-presentation/) را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides از استفاده در راه‌حل‌های ابری پشتیبانی می‌کند؟**

بله، Aspose.Slides می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده است و عملکرد بالا و مقیاس‌پذیری را برای پردازش دسته‌ای فایل‌ها تضمین می‌کند.

**آیا محدودیت حجمی برای ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides قادر به پردازش ارائه‌هایی با هر ابعادی است. اما هنگام کار با فایل‌های بسیار بزرگ، ممکن است به منابع سیستم بیشتری نیاز باشد و گاهی توصیه می‌شود که برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.