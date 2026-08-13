---
title: Chuyển đổi Bản thuyết trình PowerPoint sang Video trên Android
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/androidjava/convert-powerpoint-to-video/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang video
- bản thuyết trình sang video
- PPT sang video
- PPTX sang video
- PowerPoint sang MP4
- bản thuyết trình sang MP4
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
description: "Tìm hiểu cách chuyển đổi bản thuyết trình PowerPoint sang video bằng Java. Khám phá mã mẫu và các kỹ thuật tự động hoá để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bài thuyết trình PowerPoint của bạn sang video, bạn sẽ nhận được 

* **Tăng khả năng truy cập:** Tất cả các thiết bị (bất kể nền tảng) đều được trang bị trình phát video mặc định so với các ứng dụng mở bản thuyết trình, vì vậy người dùng dễ dàng mở hoặc phát video hơn.
* **Tiếp cận rộng hơn:** Thông qua video, bạn có thể tiếp cận lượng lớn khán giả và truyền tải thông tin mà nếu dùng bản thuyết trình có thể sẽ nhàm chán. Hầu hết các khảo sát và thống kê cho thấy mọi người xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên nội dung này.

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Aspose.Slides hỗ trợ chuyển đổi bản thuyết trình sang video.

* Sử dụng **Aspose.Slides** để tạo ra một tập hợp các khung hình (từ các slide của bản thuyết trình) tương ứng với một tốc độ FPS (khung hình mỗi giây) nhất định
* Sử dụng công cụ của bên thứ ba như **ffmpeg** ([cho java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình. 

### **Chuyển đổi PowerPoint sang Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [tại đây](https://ffmpeg.org/download.html).

3. Run the PowerPoint to video Java code.

Mã Java này cho bạn thấy cách chuyển đổi một bản thuyết trình (chứa một hình và hai hiệu ứng hoạt ảnh) sang video:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Thêm một hình dạng cười và sau đó tạo hoạt ảnh cho nó
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

    // Cấu hình thư mục binary ffmpeg. Xem trang này: https://github.com/bramp/ffmpeg-cli-wrapper
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

Bạn có thể áp dụng hoạt hình cho các đối tượng trên slide và sử dụng chuyển đổi giữa các slide. 

{{% alert color="info" %}} 

Bạn có thể muốn xem các bài viết sau: [Hoạt hình PowerPoint](https://docs.aspose.com/slides/vi/androidjava/powerpoint-animation/), [Hoạt hình Hình dạng](https://docs.aspose.com/slides/vi/androidjava/shape-animation/), và [Hiệu ứng Hình dạng](https://docs.aspose.com/slides/vi/androidjava/shape-effect/).

{{% /alert %}} 

Hoạt hình và chuyển đổi làm cho slide trình chiếu trở nên hấp dẫn và thú vị hơn — và chúng cũng làm điều tương tự cho video. Hãy thêm một slide và chuyển đổi khác vào mã cho bản thuyết trình trước:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bản thuyết trình với hình dạng cười được tạo động ở trên.
Presentation presentation = new Presentation();
try {
    // Thêm một slide mới và chuyển đổi có hoạt ảnh

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides cũng hỗ trợ hoạt hình cho văn bản. Vì vậy chúng tôi hoạt hình các đoạn văn trên đối tượng, sẽ xuất hiện lần lượt (với độ trễ đặt là một giây):

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

    // Cấu hình thư mục binary ffmpeg. Xem trang này: https://github.com/bramp/ffmpeg-cli-wrapper
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

Để cho phép bạn thực hiện các nhiệm vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau) thông qua hàm khởi tạo của nó. Nếu bạn truyền một instance của bản thuyết trình, `Presentation.SlideSize` sẽ được sử dụng và nó sẽ tạo ra các hoạt hình mà [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/) sử dụng.

Khi các hoạt hình được tạo, một sự kiện `NewAnimation` sẽ được sinh ra cho mỗi hoạt hình tiếp theo, có tham số là [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/). Lớp này đại diện cho một trình phát cho một hoạt hình riêng biệt.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/), thuộc tính [Duration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (thời lượng đầy đủ của hoạt hình) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) được sử dụng. Mỗi vị trí hoạt hình được đặt trong khoảng *0 đến duration*, sau đó phương thức `getFrame` sẽ trả về một [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) tương ứng với trạng thái hoạt hình tại thời điểm đó:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Thêm một hình dạng cười và tạo hoạt ảnh cho nó
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
            // bitmap trạng thái hoạt ảnh ban đầu
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // trạng thái cuối cùng của hoạt ảnh
            // khung hình cuối cùng của hoạt ảnh
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Tạo các hoạt ảnh. Callback ở trên sẽ chạy cho từng hoạt ảnh.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Để làm cho tất cả các hoạt hình trong một bản thuyết trình phát đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationplayer/) được sử dụng. Lớp này nhận một instance của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationanimationsgenerator/) và FPS cho các hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt hình để chúng được phát:

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

Sau đó các khung hình được tạo có thể được biên dịch để tạo video. Xem phần [Chuyển đổi PowerPoint sang Video](https://docs.aspose.com/slides/vi/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các Hoạt hình và Hiệu Ứng Được Hỗ trợ**

**Xuất hiện**:

| Loại Hoạt hình | Aspose.Slides | PowerPoint |
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

**Nhấn mạnh**:

| Loại Hoạt hình | Aspose.Slides | PowerPoint |
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

**Kết thúc**:

| Loại Hoạt hình | Aspose.Slides | PowerPoint |
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

**Đường chuyển động**:

| Loại Hoạt hình | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

### Có thể chuyển đổi các bản thuyết trình được bảo mật bằng mật khẩu không?

Có, Aspose.Slides cho phép làm việc với [bản thuyết trình được bảo mật bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/). Khi xử lý các tệp này, bạn cần cung cấp mật khẩu chính xác để thư viện có thể truy cập nội dung của bản thuyết trình.

### Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng khi xử lý hàng loạt file.

### Có giới hạn kích thước nào cho bản thuyết trình khi chuyển đổi không?

Aspose.Slides có khả năng xử lý các bản thuyết trình có kích thước gần như vô hạn. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần bổ sung tài nguyên hệ thống và đôi khi nên tối ưu hóa bản thuyết trình để cải thiện hiệu năng.