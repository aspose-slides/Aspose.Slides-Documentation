---
title: 在 PHP 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/php-java/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转视频
- 演示文稿转视频
- PPT 转视频
- PPTX 转视频
- PowerPoint 转 MP4
- 演示文稿转 MP4
- PPT 转 MP4
- PPTX 转 MP4
- 将 PPT 保存为 MP4
- 将 PPTX 保存为 MP4
- 导出 PPT 为 MP4
- 导出 PPTX 为 MP4
- 视频转换
- PowerPoint
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP 将 PowerPoint 演示文稿转换为视频。探索示例代码和自动化技术，以简化您的工作流程。"
---

通过将 PowerPoint 演示文稿转换为视频，您可以获得 

* **可访问性提升：** 与演示文稿打开应用程序相比，所有设备（无论平台）默认配备视频播放器，用户更容易打开或播放视频。
* **更广的覆盖面：** 通过视频，您可以触达更大的受众，并向他们提供在演示文稿中可能显得枯燥的信息。大多数调查和统计表明，人们观看和消费视频的比例高于其他内容形式，且普遍更喜欢此类内容。

{{% alert color="primary" %}} 

您可能想查看我们的[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word)，因为它是本文所述过程的实时且有效的实现。

{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 转视频转换**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-22-11-release-notes/)，我们实现了对演示文稿转视频的支持。

* 使用 **Aspose.Slides** 生成一组帧（来自演示文稿幻灯片），对应特定的 FPS（每秒帧数）
* 使用第三方工具如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）基于这些帧创建视频。

### **将 PowerPoint 转换为视频**

1. 将以下内容添加到您的 POM 文件中：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```php

```


2. 从[此处](https://ffmpeg.org/download.html)下载 ffmpeg。

4. 运行 PowerPoint 转视频的 PHP 代码。

以下 PHP 代码演示如何将包含图形和两个动画效果的演示文稿转换为视频：
```php
  $presentation = new Presentation();
  try {
    # 添加笑脸形状并对其进行动画处理
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
    # 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **视频效果**

您可以对幻灯片上的对象应用动画，并使用幻灯片之间的转换。

{{% alert color="primary" %}} 

您可能想查看以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/php-java/powerpoint-animation/)，[Shape Animation](https://docs.aspose.com/slides/php-java/shape-animation/)，和[Shape Effect](https://docs.aspose.com/slides/php-java/shape-effect/)。

{{% /alert %}} 

动画和转换使幻灯片放映更具吸引力和趣味性——对视频也是如此。让我们在前一个演示文稿的代码中添加另一张幻灯片及其转换：
```php
  # 添加笑脸形状并为其添加动画
  # ...
  # 添加新幻灯片并添加动画过渡
  $newSlide = $presentation->getSlides()->addEmptySlide($presentation->getSlides()->get_Item(0)->getLayoutSlide());
  $newSlide->getBackground()->setType(BackgroundType::OwnBackground);
  $newSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
  $newSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
  $newSlide->getSlideShowTransition()->setType(TransitionType::Push);
```


Aspose.Slides 也支持文本动画。因此我们为对象上的段落添加动画，使其依次出现（延迟设置为一秒）：
```php
  $presentation = new Presentation();
  try {
    # 添加文本和动画
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
    # 配置 ffmpeg 二进制文件夹。参见此页面: https://github.com/rosenbjerg/FFMpegCore#installation
    $ffmpeg = new Java("net.bramp.ffmpeg.builder.FFmpeg", "path/to/ffmpeg");
    $ffprobe = new Java("net.bramp.ffmpeg.builder.FFprobe", "path/to/ffprobe");
    $builder = (new Java("net.bramp.ffmpeg.builder.FFmpegBuilder"))->addExtraArgs("-start_number", "1")->setInput("frame_%04d.png")->addOutput("output.avi")->setVideoFrameRate(FFmpeg->FPS_24)->setFormat("avi")->done();
    $executor = new Java("net.bramp.ffmpeg.builder.FFmpegExecutor", $ffmpeg, $ffprobe);
    $executor->createJob($builder)->run();
  } catch (JavaException $e) {
    $e->printStackTrace();
  }
```


## **视频转换类**

为了让您执行 PowerPoint 转视频的任务，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/php-java/aspose.slides/presentationanimationsgenerator/) 和 [PresentationPlayer](https://reference.aspose.com/slides/php-java/aspose.slides/presentationplayer/) 类。

[PresentationAnimationsGenerator] 允许您通过构造函数设置视频的帧大小（稍后将创建）。如果传入演示文稿实例，则使用 `Presentation.SlideSize`，并生成供 [PresentationPlayer] 使用的动画。

生成动画时，会为每个后续动画生成 `NewAnimation` 事件，携带 [IPresentationAnimationPlayer] 参数。后者是表示单独动画播放器的类。

要使用 [IPresentationAnimationPlayer]，需要使用 [Duration]（动画的完整时长）属性和 [SetTimePosition] 方法。每个动画位置在 *0 到 duration* 范围内设置，然后 `GetFrame` 方法将返回对应时间点动画状态的 BufferedImage：
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
        $animationPlayer->setTimePosition(0);// 初始动画状态
        try {
            # 初始动画状态位图
            $animationPlayer->getFrame()->save("firstFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
        $animationPlayer->setTimePosition($animationPlayer->getDuration());// final state of the animation
        try {
            # 动画的最后一帧
            $animationPlayer->getFrame()->save("lastFrame.png", ImageFormat::Png);
        } catch (JavaException $e) {
        }
    }
}
$presentation = new Presentation();
try {
    # 添加笑脸形状并对其进行动画
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


为了让演示文稿中的所有动画一次性播放，使用 [PresentationPlayer] 类。该类在构造函数中接受一个 [PresentationAnimationsGenerator] 实例和用于效果的 FPS，然后调用 `FrameTick` 事件以播放所有动画：
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


然后可以将生成的帧编译生成视频。请参阅 [Convert PowerPoint to Video](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 部分。

## **支持的动画和效果**

**入口**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**强调**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**退出**：

| 动画类型 | Aspose.Slides | PowerPoint |
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

**运动路径**：

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**是否可以转换受密码保护的演示文稿？**

是的，Aspose.Slides 支持处理[受密码保护的演示文稿](/slides/zh/php-java/password-protected-presentation/)。在处理此类文件时，需要提供正确的密码，以便库能够访问演示文稿的内容。

**Aspose.Slides 是否支持在云解决方案中使用？**

是的，Aspose.Slides 可以集成到云应用和服务中。该库专为服务器环境设计，确保在批量文件处理时具备高性能和可扩展性。

**在转换过程中对演示文稿的大小有限制吗？**

Aspose.Slides 能够处理几乎任何大小的演示文稿。不过，在处理非常大的文件时，可能需要额外的系统资源，有时建议对演示文稿进行优化以提升性能。