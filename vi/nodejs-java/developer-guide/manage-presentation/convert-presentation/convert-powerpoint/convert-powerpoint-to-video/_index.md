---
title: Chuyển đổi bản trình chiếu PowerPoint sang video bằng JavaScript
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang video bằng JavaScript. Khám phá mã mẫu và các kỹ thuật tự động hoá để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình chiếu PowerPoint của bạn sang video, bạn sẽ có 

* **Tăng khả năng truy cập:** Tất cả các thiết bị (bất kể nền tảng) đều được trang bị sẵn các trình phát video so với các ứng dụng mở bản trình chiếu, vì vậy người dùng dễ dàng mở hoặc phát video hơn.
* **Tiếp cận rộng hơn:** Thông qua video, bạn có thể tiếp cận một lượng lớn khán giả và truyền tải thông tin mà nếu dùng bản trình chiếu có thể sẽ gây nhàm chán. Hầu hết các khảo sát và thống kê cho thấy mọi người xem và tiêu thụ video nhiều hơn các dạng nội dung khác, và họ thường ưu tiên loại nội dung này.

{{% alert color="primary" %}} 

Bạn có thể muốn kiểm tra [**Trình chuyển đổi PowerPoint sang Video Trực tuyến**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) vì đây là một triển khai trực tiếp và hiệu quả của quy trình được mô tả ở đây.

{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Video trong Aspose.Slides**

Aspose.Slides hỗ trợ chuyển đổi bản trình chiếu sang video.

* Sử dụng **Aspose.Slides** để tạo một tập hợp các khung hình (từ các slide của bản trình chiếu) tương ứng với một FPS nhất định (khung hình mỗi giây)
* Sử dụng công cụ bên thứ ba như **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) để tạo video dựa trên các khung hình. 

### **Chuyển đổi PowerPoint sang Video**

1. Tải ffmpeg [tại đây](https://ffmpeg.org/download.html).

2. Chạy mã JavaScript chuyển PowerPoint sang video.

Mã JavaScript này cho bạn thấy cách chuyển đổi một bản trình chiếu (chứa một hình và hai hiệu ứng hoạt hình) sang video:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Thêm một hình mặt cười và sau đó tạo hoạt hình cho nó
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Hiệu ứng Video**

Bạn có thể áp dụng hoạt hình cho các đối tượng trên slide và sử dụng chuyển tiếp giữa các slide. 

{{% alert color="primary" %}} 

Bạn có thể muốn xem các bài viết này: [Hoạt hình PowerPoint](https://docs.aspose.com/slides/vi/nodejs-java/powerpoint-animation/), [Hoạt hình Hình dạng](https://docs.aspose.com/slides/vi/nodejs-java/shape-animation/), và [Hiệu ứng Hình dạng](https://docs.aspose.com/slides/vi/nodejs-java/shape-effect/).

{{% /alert %}} 

Hoạt hình và chuyển tiếp làm cho bài thuyết trình trở nên sinh động và thú vị—và chúng cũng làm điều tương tự cho video. Hãy thêm một slide và chuyển tiếp khác vào mã cho bản trình chiếu trước:

```javascript
// Thêm một hình mặt cười và tạo hoạt hình cho nó
// ...
// Thêm một slide mới và chuyển tiếp hoạt hình
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides cũng hỗ trợ hoạt hình cho văn bản. Vì vậy chúng tôi hoạt hình các đoạn văn trên các đối tượng, chúng sẽ xuất hiện lần lượt (với độ trễ được đặt là một giây):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Thêm văn bản và hoạt ảnh
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Các lớp chuyển đổi Video**

Để cho phép bạn thực hiện các nhiệm vụ chuyển đổi PowerPoint sang video, Aspose.Slides cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationanimationsgenerator/) cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau này) thông qua hàm khởi tạo của nó. Nếu bạn truyền một thể hiện của bản trình chiếu, `Presentation.getSlideSize` sẽ được sử dụng và nó tạo ra các hoạt hình mà [PresentationPlayer](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationplayer/) sử dụng.

Khi các hoạt hình được tạo, một sự kiện `NewAnimation` được sinh ra cho mỗi hoạt hình tiếp theo, có tham số trình phát hoạt hình bản trình chiếu. Tham số này là một lớp đại diện cho trình phát cho một hoạt hình riêng biệt.

Để làm việc với trình phát hoạt hình bản trình chiếu, phương thức `getDuration` (độ dài toàn bộ của hoạt hình) và phương thức `setTimePosition` được sử dụng. Mỗi vị trí hoạt hình được đặt trong khoảng *0 đến duration*, và sau đó phương thức `getFrame` sẽ trả về một BufferedImage tương ứng với trạng thái hoạt hình tại thời điểm đó:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Thêm một hình mặt cười và tạo hoạt hình cho nó
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// trạng thái ban đầu của hoạt hình
            try {
                // bitmap trạng thái ban đầu của hoạt hình
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// trạng thái cuối cùng của hoạt hình
            try {
                // khung cuối cùng của hoạt hình
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Để làm cho tất cả các hoạt hình trong một bản trình chiếu chạy đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationanimationsgenerator/) và FPS cho các hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt hình để chúng được phát:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Sau đó các khung hình đã tạo có thể được biên dịch để tạo thành video. Xem phần [Chuyển đổi PowerPoint sang Video](https://docs.aspose.com/slides/vi/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Các hoạt hình và hiệu ứng được hỗ trợ**

**Mở đầu**:

| Loại hoạt hình | Aspose.Slides | PowerPoint |
|---|---|---|
| **Xuất hiện** | ![not supported](x.png) | ![supported](v.png) |
| **Mờ dần** | ![supported](v.png) | ![supported](v.png) |
| **Bay vào** | ![supported](v.png) | ![supported](v.png) |
| **Trôi vào** | ![supported](v.png) | ![supported](v.png) |
| **Tách** | ![supported](v.png) | ![supported](v.png) |
| **Lau** | ![supported](v.png) | ![supported](v.png) |
| **Hình dạng** | ![supported](v.png) | ![supported](v.png) |
| **Bánh xe** | ![supported](v.png) | ![supported](v.png) |
| **Thanh ngẫu nhiên** | ![supported](v.png) | ![supported](v.png) |
| **Phóng to & Xoay** | ![not supported](x.png) | ![supported](v.png) |
| **Thu phóng** | ![supported](v.png) | ![supported](v.png) |
| **Quay tròn** | ![supported](v.png) | ![supported](v.png) |
| **Bị nẩy** | ![supported](v.png) | ![supported](v.png) |

**Nhấn mạnh**:

| Loại hoạt hình | Aspose.Slides | PowerPoint |
|---|---|---|
| **Nhịp tim** | ![not supported](x.png) | ![supported](v.png) |
| **Nhịp tim màu** | ![not supported](x.png) | ![supported](v.png) |
| **Lắc lư** | ![supported](v.png) | ![supported](v.png) |
| **Xoay** | ![supported](v.png) | ![supported](v.png) |
| **Phóng to/Thu nhỏ** | ![not supported](x.png) | ![supported](v.png) |
| **Mờ màu** | ![not supported](x.png) | ![supported](v.png) |
| **Tối hơn** | ![not supported](x.png) | ![supported](v.png) |
| **Sáng hơn** | ![not supported](x.png) | ![supported](v.png) |
| **Độ trong suốt** | ![not supported](x.png) | ![supported](v.png) |
| **Màu đối tượng** | ![not supported](x.png) | ![supported](v.png) |
| **Màu bổ sung** | ![not supported](x.png) | ![supported](v.png) |
| **Màu đường viền** | ![not supported](x.png) | ![supported](v.png) |
| **Màu nền** | ![not supported](x.png) | ![supported](v.png) |

**Kết thúc**:

| Loại hoạt hình | Aspose.Slides | PowerPoint |
|---|---|---|
| **Biến mất** | ![not supported](x.png) | ![supported](v.png) |
| **Mờ dần** | ![supported](v.png) | ![supported](v.png) |
| **Bay ra** | ![supported](v.png) | ![supported](v.png) |
| **Trôi ra** | ![supported](v.png) | ![supported](v.png) |
| **Tách** | ![supported](v.png) | ![supported](v.png) |
| **Lau** | ![supported](v.png) | ![supported](v.png) |
| **Hình dạng** | ![supported](v.png) | ![supported](v.png) |
| **Thanh ngẫu nhiên** | ![supported](v.png) | ![supported](v.png) |
| **Thu nhỏ & Xoay** | ![not supported](x.png) | ![supported](v.png) |
| **Thu phóng** | ![supported](v.png) | ![supported](v.png) |
| **Quay tròn** | ![supported](v.png) | ![supported](v.png) |
| **Bị nẩy** | ![supported](v.png) | ![supported](v.png) |

**Đường di chuyển**:

| Loại hoạt hình | Aspose.Slides | PowerPoint |
|---|---|---|
| **Đường thẳng** | ![supported](v.png) | ![supported](v.png) |
| **Cung** | ![supported](v.png) | ![supported](v.png) |
| **Xoay vòng** | ![supported](v.png) | ![supported](v.png) |
| **Hình dạng** | ![supported](v.png) | ![supported](v.png) |
| **Vòng lặp** | ![supported](v.png) | ![supported](v.png) |
| **Đường tùy chỉnh** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

**Có thể chuyển đổi các bản trình chiếu được bảo vệ bằng mật khẩu không?**

Có, Aspose.Slides cho phép làm việc với các bản trình chiếu được bảo vệ bằng mật khẩu. Khi xử lý các tệp này, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bản trình chiếu.

**Aspose.Slides có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có giới hạn kích thước nào cho bản trình chiếu khi chuyển đổi không?**

Aspose.Slides có khả năng xử lý các bản trình chiếu với kích thước gần như bất kỳ. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi được khuyến nghị tối ưu hóa bản trình chiếu để cải thiện hiệu năng.