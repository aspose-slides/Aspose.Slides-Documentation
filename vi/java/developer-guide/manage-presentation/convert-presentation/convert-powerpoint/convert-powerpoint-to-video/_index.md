---
title: Chuyển đổi bản trình chiếu PowerPoint sang video trong Java
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/java/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bản trình chiếu sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bản trình chiếu sang MP4
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
description: "Tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang video trong Java. Khám phá mã mẫu và các kỹ thuật tự động hóa để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình chiếu PowerPoint hoặc OpenDocument sang video, bạn sẽ có được:

**Tăng khả năng tiếp cận:** Tất cả các thiết bị, bất kể nền tảng, đều được trang bị trình phát video mặc định, giúp người dùng dễ dàng mở hoặc phát video hơn so với các ứng dụng trình chiếu truyền thống.

**Mở rộng phạm vi:** Video cho phép bạn tiếp cận khán giả lớn hơn và trình bày thông tin theo định dạng hấp dẫn hơn. Các khảo sát và thống kê cho thấy mọi người ưu tiên xem và tiêu thụ nội dung video hơn các hình thức khác, giúp thông điệp của bạn có tác động mạnh mẽ hơn.

{{% alert color="info" %}} 
Bạn có thể muốn thử công cụ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/vi/video) vì đây là một triển khai thực tế và hiệu quả của quy trình được mô tả ở đây.
{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Trong [Aspose.Slides 22.11](https://docs.aspose.com/slides/vi/java/aspose-slides-for-java-22-11-release-notes/), chúng tôi đã triển khai hỗ trợ chuyển đổi bản trình chiếu sang video. 

* Sử dụng **Aspose.Slides** để tạo một tập hợp các khung (từ các slide) tương ứng với một FPS (khung hình trên giây) nhất định  
* Sử dụng công cụ của bên thứ ba như **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình. 

### **Chuyển đổi PowerPoint sang Video**

1. Thêm đoạn này vào file POM của bạn:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Tải ffmpeg [ở đây](https://ffmpeg.org/download.html).

4. Chạy mã Java chuyển đổi PowerPoint sang video.

Mã Java này cho bạn thấy cách chuyển đổi một bản trình chiếu (có hình ảnh và hai hiệu ứng hoạt hình) sang video:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Thêm một hình mặt cười và sau đó tạo hoạt ảnh cho nó
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

Bạn có thể áp dụng hoạt hình cho các đối tượng trên slide và sử dụng chuyển tiếp giữa các slide. 

{{% alert color="info" %}} 
Bạn có thể xem các bài viết sau: [PowerPoint Animation](https://docs.aspose.com/slides/vi/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/vi/java/shape-animation/), và [Shape Effect](https://docs.aspose.com/slides/vi/java/shape-effect/).
{{% /alert %}} 

Hoạt hình và chuyển tiếp làm cho bài trình chiếu sinh động và hấp dẫn hơn — và chúng cũng mang lại hiệu quả tương tự cho video. Hãy thêm một slide và chuyển tiếp khác vào mã của bản trình chiếu trước:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Thêm một hình mặt cười và tạo hoạt ảnh cho nó

    // ...

    // Thêm một slide mới và chuyển tiếp hoạt ảnh

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides cũng hỗ trợ hoạt hình cho văn bản. Vì vậy chúng ta có thể hoạt hình các đoạn văn trên các đối tượng, sẽ xuất hiện lần lượt (với độ trễ đặt là một giây):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

## **Các lớp chuyển đổi Video**

Để cho phép bạn thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau này) thông qua hàm khởi tạo. Nếu bạn truyền một thể hiện của bản trình chiếu, `Presentation.SlideSize` sẽ được sử dụng và nó sẽ tạo các hoạt hình mà [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/) dùng.

Khi các hoạt hình được tạo, một sự kiện `NewAnimation` sẽ được sinh ra cho mỗi hoạt hình tiếp theo, với tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/). Lớp này đại diện cho một trình phát cho một hoạt hình riêng biệt.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/), thuộc tính [Duration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (thời lượng đầy đủ của hoạt hình) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) được sử dụng. Mỗi vị trí hoạt hình được đặt trong phạm vi *0 đến duration*, sau đó phương thức `getFrame` sẽ trả về một [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) tương ứng với trạng thái hoạt hình tại thời điểm đó:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Thêm một hình mặt cười và tạo hoạt ảnh cho nó
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

            animationPlayer.setTimePosition(0); // trạng thái ban đầu của hoạt ảnh
            // bitmap trạng thái ban đầu của hoạt ảnh
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // trạng thái cuối cùng của hoạt ảnh
            // khung cuối cùng của hoạt ảnh
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // tạo các hoạt ảnh - đây là thao tác kích hoạt các sự kiện đã xử lý ở trên
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Để làm cho tất cả các hoạt hình trong một bản trình chiếu chạy đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationanimationsgenerator/) và FPS cho các hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho mọi hoạt hình để chúng được phát:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Sau đó các khung hình đã tạo có thể được biên dịch thành video. Xem phần [Convert PowerPoint to Video](https://docs.aspose.com/slides/vi/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hoạt hình và hiệu ứng được hỗ trợ**

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

### Có thể chuyển đổi các bản trình chiếu được bảo mật bằng mật khẩu không?

Có, Aspose.Slides cho phép làm việc với [password-protected presentations](/slides/vi/java/password-protected-presentation/). Khi xử lý các tệp này, bạn cần cung cấp mật khẩu chính xác để thư viện có thể truy cập nội dung của bản trình chiếu.

### Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

### Có giới hạn kích thước nào cho bản trình chiếu khi chuyển đổi không?

Aspose.Slides có khả năng xử lý các bản trình chiếu có kích thước gần như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi nên tối ưu hoá bản trình chiếu để cải thiện hiệu năng.