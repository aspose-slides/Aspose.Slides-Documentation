---
title: Chuyển đổi Bản trình bày PowerPoint sang Video trên Android
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/androidjava/convert-powerpoint-to-video/
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
- xuất PPT sang MP4
- xuất PPTX sang MP4
- chuyển đổi video
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bản trình bày PowerPoint sang video bằng Java. Khám phá mã mẫu và các kỹ thuật tự động hoá để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình bày PowerPoint sang video, bạn sẽ nhận được 

* **Tăng khả năng tiếp cận:** Tất cả các thiết bị (bất kể nền tảng) đều được cài sẵn trình phát video theo mặc định so với các ứng dụng mở bản trình bày, vì vậy người dùng dễ dàng mở hoặc phát video hơn.
* **Tiếp cận rộng hơn:** Thông qua video, bạn có thể tiếp cận lượng lớn khán giả và cung cấp cho họ thông tin mà nếu dùng bản trình bày có thể cảm thấy nhàm chán. Hầu hết các khảo sát và thống kê cho thấy mọi người xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên nội dung này.

{{% alert color="primary" %}} 

Bạn có thể muốn kiểm tra [**Trình chuyển đổi PowerPoint sang Video Trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) của chúng tôi vì đây là một triển khai thực tế và hiệu quả của quy trình được mô tả ở đây.

{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Aspose.Slides hỗ trợ chuyển đổi bản trình bày sang video.

* Sử dụng **Aspose.Slides** để tạo ra một bộ khung (từ các slide của bản trình bày) tương ứng với một FPS nhất định (khung hình trên giây)
* Sử dụng công cụ bên thứ ba như **ffmpeg** ([cho java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình. 

### **Chuyển đổi PowerPoint sang Video**

1. Thêm đoạn này vào tệp POM của bạn:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Tải ffmpeg [tại đây](https://ffmpeg.org/download.html).

4. Chạy mã Java chuyển PowerPoint sang video.

Đoạn mã Java này cho bạn thấy cách chuyển đổi một bản trình bày (gồm một hình và hai hiệu ứng hoạt ảnh) sang video:

```java
Presentation presentation = new Presentation();
try {
    // Thêm một hình cười và sau đó tạo hoạt ảnh cho nó
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Hiệu ứng Video**

Bạn có thể áp dụng hoạt ảnh cho các đối tượng trên slide và sử dụng chuyển tiếp giữa các slide. 

{{% alert color="primary" %}} 

Bạn có thể muốn xem các bài viết này: [PowerPoint Animation](https://docs.aspose.com/slides/vi/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/androidjava/shape-animation/), và [Shape Effect](https://docs.aspose.com/slides/vi/androidjava/shape-effect/).

{{% /alert %}} 

Hoạt ảnh và chuyển tiếp làm cho trình chiếu hấp dẫn và thú vị hơn — và chúng cũng làm tương tự cho video. Hãy thêm một slide và chuyển tiếp nữa vào mã cho bản trình bày trước:

```java
// Thêm một hình cười và tạo hoạt ảnh cho nó

// ...

// Thêm một slide mới và chuyển tiếp có hoạt ảnh

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides cũng hỗ trợ hoạt ảnh cho văn bản. Vì vậy chúng ta sẽ tạo hoạt ảnh cho các đoạn văn trên đối tượng, chúng sẽ xuất hiện lần lượt (với độ trễ đặt là một giây):

```java
Presentation presentation = new Presentation();
try {
    // Thêm văn bản và hoạt ảnh
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Passage("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Các lớp Chuyển đổi Video**

Để cho phép bạn thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau) thông qua constructor của nó. Nếu bạn truyền một thể hiện của bản trình bày, `Presentation.SlideSize` sẽ được sử dụng và nó tạo ra các hoạt ảnh mà [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/) sử dụng.

Khi các hoạt ảnh được tạo, một sự kiện `NewAnimation` được tạo cho mỗi hoạt ảnh tiếp theo, có tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/). Lớp này đại diện cho một trình phát cho một hoạt ảnh riêng.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/), thuộc tính [Duration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (thời gian đầy đủ của hoạt ảnh) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) được sử dụng. Mỗi vị trí hoạt ảnh được đặt trong khoảng *0 đến duration*, và sau đó phương thức `GetFrame` sẽ trả về một BufferedImage tương ứng với trạng thái hoạt ảnh tại thời điểm đó:

```java
Presentation presentation = new Presentation();
try {
    // Thêm một hình cười và tạo hoạt ảnh cho nó
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // trạng thái hoạt ảnh ban đầu
            try {
                // bitmap trạng thái hoạt ảnh ban đầu
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // trạng thái cuối cùng của hoạt ảnh
            try {
                // khung hình cuối cùng của hoạt ảnh
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Để làm cho tất cả các hoạt ảnh trong một bản trình bày chạy đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) và FPS cho các hiệu ứng trong constructor và sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt ảnh để chúng được phát:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Sau đó các khung đã tạo có thể được biên dịch để tạo video. Xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hoạt ảnh và hiệu ứng được hỗ trợ**

**Entrance**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
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

**Emphasis**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
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

**Exit**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
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

**Motion Paths**:

| Loại Hoạt ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

**Có thể chuyển đổi các bản trình bày được bảo vệ bằng mật khẩu không?**

Có, Aspose.Slides cho phép làm việc với [bản trình bày được bảo vệ bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/). Khi xử lý các tệp này, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bản trình bày.

**Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu suất cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có bất kỳ giới hạn kích thước nào cho bản trình bày khi chuyển đổi không?**

Aspose.Slides có khả năng xử lý các bản trình bày gần như bất kỳ kích thước nào. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống, và đôi khi nên tối ưu hóa bản trình bày để cải thiện hiệu suất.