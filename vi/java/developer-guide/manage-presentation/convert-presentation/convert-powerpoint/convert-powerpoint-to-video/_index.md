---
title: Chuyển đổi bài thuyết trình PowerPoint sang video trong Java
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/java/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bài thuyết trình sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bài thuyết trình sang MP4
- PPT sang MP4
- PPTX sang MP4
- lưu PPT dưới dạng MP4
- lưu PPTX dưới dạng MP4
- xuất PPT sang MP4
- xuất PPTX sang MP4
- chuyển đổi video
- PowerPoint
- Java
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bài thuyết trình PowerPoint sang video trong Java. Khám phá mã mẫu và các kỹ thuật tự động hoá để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bài thuyết trình PowerPoint hoặc OpenDocument của bạn sang video, bạn sẽ được:

**Tăng khả năng tiếp cận:** Tất cả các thiết bị, bất kể nền tảng, đều được trang bị trình phát video mặc định, giúp người dùng mở hoặc phát video dễ dàng hơn so với các ứng dụng trình chiếu truyền thống.

**Phạm vi tiếp cận rộng hơn:** Video cho phép bạn tiếp cận đối tượng lớn hơn và trình bày thông tin theo dạng hấp dẫn hơn. Các khảo sát và thống kê cho thấy mọi người thích xem và tiêu thụ nội dung video hơn so với các hình thức khác, làm cho thông điệp của bạn có tác động mạnh mẽ hơn.

{{% alert color="primary" %}} 
Bạn có thể muốn kiểm tra [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) vì đây là một triển khai trực tiếp và hiệu quả của quy trình được mô tả ở đây.
{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Trong [Aspose.Slides 22.11](https://docs.aspose.com/slides/vi/java/aspose-slides-for-java-22-11-release-notes/), chúng tôi đã triển khai hỗ trợ chuyển đổi bài thuyết trình sang video. 

* Sử dụng **Aspose.Slides** để tạo ra một tập hợp các khung hình (từ các slide của bài thuyết trình) tương ứng với một FPS (khung hình trên giây) nhất định
* Sử dụng công cụ của bên thứ ba như **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình. 

### **Chuyển đổi PowerPoint sang Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Tải ffmpeg [ở đây](https://ffmpeg.org/download.html).

4. Chạy mã Java chuyển đổi PowerPoint sang video.

Mã Java này cho bạn thấy cách chuyển đổi một bài thuyết trình (chứa một hình và hai hiệu ứng hoạt ảnh) sang video:

```java
Presentation presentation = new Presentation();
try {
    // Thêm một hình mặt cười và sau đó áp dụng hoạt ảnh
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

## **Hiệu Ứng Video**

Bạn có thể áp dụng các hoạt ảnh cho các đối tượng trên slide và sử dụng chuyển tiếp giữa các slide. 

{{% alert color="primary" %}} 
Bạn có thể muốn xem các bài viết này: [PowerPoint Animation](https://docs.aspose.com/slides/vi/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/java/shape-animation/), và [Shape Effect](https://docs.aspose.com/slides/vi/java/shape-effect/).
{{% /alert %}} 

Các hoạt ảnh và chuyển tiếp làm cho slide trở nên hấp dẫn và thú vị hơn—và chúng cũng tạo ra hiệu quả tương tự cho video. Hãy thêm một slide và chuyển tiếp khác vào mã cho bài thuyết trình trước:

```java
// Thêm một hình mặt cười và áp dụng hoạt ảnh

// ...

// Thêm một slide mới và chuyển tiếp hoạt ảnh

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides cũng hỗ trợ hoạt ảnh cho văn bản. Vì vậy chúng tôi sẽ thực hiện hoạt ảnh cho các đoạn văn trên đối tượng, chúng sẽ xuất hiện lần lượt (với độ trễ được đặt là một giây):

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
    para3.getPortions().add(new Portion("paragraph by paragraph"));
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

## **Các Lớp Chuyển Đổi Video**

Để cho phép bạn thực hiện các nhiệm vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) cho phép bạn thiết lập kích thước khung cho video (sẽ được tạo sau) thông qua hàm khởi tạo. Nếu bạn truyền một thể hiện của bài thuyết trình, `Presentation.SlideSize` sẽ được sử dụng và nó tạo ra các hoạt ảnh mà [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/) sử dụng. 

Khi các hoạt ảnh được tạo, một sự kiện `NewAnimation` được sinh ra cho mỗi hoạt ảnh tiếp theo, có tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/). Tham số này là một lớp đại diện cho trình phát hoạt ảnh riêng biệt.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/), thuộc tính [Duration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (thời lượng đầy đủ của hoạt ảnh) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) được sử dụng. Mỗi vị trí hoạt ảnh được đặt trong khoảng *0 đến duration*, sau đó phương thức `GetFrame` sẽ trả về một BufferedImage tương ứng với trạng thái hoạt ảnh tại thời điểm đó:

```java
Presentation presentation = new Presentation();
try {
    // Thêm một hình mặt cười và áp dụng hoạt ảnh
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
                // ảnh bitmap của trạng thái hoạt ảnh ban đầu
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // trạng thái cuối cùng của hoạt ảnh
            try {
                // khung cuối cùng của hoạt ảnh
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

Để làm cho tất cả các hoạt ảnh trong một bài thuyết trình chơi đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) và FPS cho hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt ảnh để chúng được phát:

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

Sau đó các khung hình đã tạo có thể được biên dịch để tạo thành video. Xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các Hoạt Ảnh và Hiệu Ứng Được Hỗ Trợ**

**Mở đầu**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Hiện** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Mờ dần** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bay vào** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Nổi lên** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Tách** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoá** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bánh xe** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thanh ngẫu nhiên** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Phát triển & Xoay** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Phóng to** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Quay quanh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Nảy** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Nhấn mạnh**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Xung** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Xung màu** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Lắc** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Quay** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Mở rộng/Thu nhỏ** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Giảm bão hòa** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Làm tối** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Làm sáng** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Trong suốt** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu đối tượng** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu bổ sung** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu đường** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Màu tô** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |

**Kết thúc**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Biến mất** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Mờ dần** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bay ra** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Nổi ra** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Tách** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoá** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thanh ngẫu nhiên** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Thu nhỏ & Xoay** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Phóng to** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Quay quanh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Nảy** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Đường chuyển động**:

| Loại Hoạt Ảnh | Aspose.Slides | PowerPoint |
|---|---|---|
| **Đường thẳng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Cung** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Xoắn** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Hình dạng** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Vòng lặp** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Đường tùy chỉnh** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

## **Câu hỏi thường gặp**

**Có thể chuyển đổi các bài thuyết trình được bảo mật bằng mật khẩu không?**

Có, Aspose.Slides cho phép làm việc với [password-protected presentations](/slides/vi/java/password-protected-presentation/). Khi xử lý các tệp như vậy, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bài thuyết trình.

**Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có giới hạn kích thước nào cho các bài thuyết trình khi chuyển đổi không?**

Aspose.Slides có khả năng xử lý các bài thuyết trình có kích thước gần như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi nên tối ưu hóa bài thuyết trình để cải thiện hiệu suất.