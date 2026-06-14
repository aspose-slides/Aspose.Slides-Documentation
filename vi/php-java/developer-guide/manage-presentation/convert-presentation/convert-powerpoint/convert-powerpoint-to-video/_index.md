---
title: Chuyển đổi bản trình chiếu PowerPoint sang video trong PHP
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/php-java/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bản trình bày sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bản trình bày sang MP4
- PPT sang MP4
- PPTX sang MP4
- lưu PPT dưới dạng MP4
- lưu PPTX dưới dạng MP4
- xuất PPT thành MP4
- xuất PPTX thành MP4
- chuyển đổi video
- PowerPoint
- PHP
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang video bằng Aspose.Slides cho PHP. Khám phá mã mẫu và các kỹ thuật tự động hóa để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình bày PowerPoint của bạn sang video, bạn sẽ có 

* **Tăng khả năng truy cập:** Tất cả các thiết bị (bất kể nền tảng) đều được trang bị trình phát video mặc định so với các ứng dụng mở bản trình bày, do đó người dùng dễ dàng mở hoặc phát video hơn.
* **Tiếp cận rộng hơn:** Thông qua video, bạn có thể tiếp cận một lượng lớn khán giả và cung cấp cho họ thông tin mà nếu dùng bản trình bày có thể sẽ nhàm chán. Hầu hết các khảo sát và thống kê cho thấy người dùng xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên dạng nội dung này.

{{% alert color="primary" %}} 

Bạn có thể muốn thử [**Trình chuyển đổi PowerPoint sang Video Trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) vì đây là một ví dụ trực tiếp và hiệu quả của quy trình được mô tả ở đây.

{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Aspose.Slides hỗ trợ chuyển đổi bản trình bày sang video.

* Sử dụng **Aspose.Slides** để tạo một tập hợp các khung hình (từ các slide của bản trình bày) tương ứng với một tốc độ FPS nhất định (khung hình mỗi giây).
* Sử dụng công cụ của bên thứ ba như **ffmpeg** ([cho java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình.

### **Chuyển đổi PowerPoint sang Video**

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

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/vi/php-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/php-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/vi/php-java/shape-effect/).

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

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation::getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationplayer/) uses.

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

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

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

Sau đó các khung hình đã tạo có thể được biên dịch để tạo ra một video. Xem phần [Chuyển đổi PowerPoint sang Video](https://docs.aspose.com/slides/vi/php-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hiệu ứng và chuyển động được hỗ trợ**

**Vào**:

| Loại Hiệu Ứng | Aspose.Slides | PowerPoint |
|---|---|---|
| **Xuất hiện** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Mờ dần** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bay vào** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Trôi vào** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Tách** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoá** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bánh xe** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thanh ngẫu nhiên** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Phóng to & Xoay** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Thu phóng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoay quanh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bật nảy** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Nhấn mạnh**:

| Loại Hiệu Ứng | Aspose.Slides | PowerPoint |
|---|---|---|
| **Nhịp tim** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Nhịp màu** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Lắc lư** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Quay** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Phóng to/Thu nhỏ** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Giảm độ bão hòa** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Tối hơn** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Sáng hơn** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Độ trong suốt** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu đối tượng** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu bổ sung** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu đường viền** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu tô** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |

**Ra**:

| Loại Hiệu Ứng | Aspose.Slides | PowerPoint |
|---|---|---|
| **Biến mất** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Mờ dần** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bay ra** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Trôi ra** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Tách** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoá** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thanh ngẫu nhiên** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thu nhỏ & Xoay** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Thu phóng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoay quanh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bật nảy** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Đường chuyển động**:

| Loại Hiệu Ứng | Aspose.Slides | PowerPoint |
|---|---|---|
| **Đường thẳng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Cung** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Quẹo** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Vòng lặp** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Đường tùy chỉnh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

## **Câu hỏi thường gặp**

**Có thể chuyển đổi các bản trình bày được bảo mật bằng mật khẩu không?**

Có, Aspose.Slides cho phép làm việc với [bản trình bày được bảo mật bằng mật khẩu](/slides/vi/php-java/password-protected-presentation/). Khi xử lý các tệp như vậy, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bản trình bày.

**Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu suất cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có bất kỳ giới hạn kích thước nào cho bản trình bày khi chuyển đổi không?**

Aspose.Slides có khả năng xử lý các bản trình bày với kích thước hầu như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống, và đôi khi nên tối ưu hóa bản trình bày để cải thiện hiệu suất.