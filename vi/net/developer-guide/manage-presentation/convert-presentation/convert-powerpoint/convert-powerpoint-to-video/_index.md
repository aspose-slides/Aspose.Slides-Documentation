---
title: Chuyển đổi bài thuyết trình PowerPoint sang video trong .NET
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/net/convert-powerpoint-to-video/
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
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bài thuyết trình PowerPoint sang video trong .NET. Khám phá mã C# mẫu và các kỹ thuật tự động hóa để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bài thuyết trình PowerPoint hoặc OpenDocument của bạn sang video, bạn sẽ có được:

**Tăng khả năng tiếp cận:** Tất cả các thiết bị, bất kể nền tảng, đều được trang bị trình phát video mặc định, giúp người dùng dễ dàng mở hoặc phát video hơn so với các ứng dụng trình chiếu truyền thống.

**Mở rộng phạm vi:** Video cho phép bạn tiếp cận nhiều khán giả hơn và trình bày thông tin theo định dạng hấp dẫn hơn. Các khảo sát và thống kê cho thấy mọi người thích xem và tiêu thụ nội dung video hơn các hình thức khác, làm cho thông điệp của bạn có sức ảnh hưởng mạnh hơn.

{{% alert color="info" %}} 
Kiểm tra [**Trình chuyển đổi PowerPoint sang Video trực tuyến**](https://products.aspose.app/slides/vi/video) vì nó cung cấp một triển khai thực tế và hiệu quả của quy trình được mô tả ở đây.
{{% /alert %}} 

Trong Aspose.Slides for .NET, chúng tôi đã triển khai hỗ trợ chuyển đổi bài thuyết trình sang video.

* Sử dụng Aspose.Slides for .NET để tạo khung hình từ các slide của bài thuyết trình với tốc độ khung hình (FPS) chỉ định.
* Sau đó, sử dụng công cụ bên thứ ba như ffmpeg để biên dịch các khung hình này thành video.

## **Chuyển đổi bài thuyết trình PowerPoint sang video**

1. Sử dụng lệnh `dotnet add package` để thêm Aspose.Slides và thư viện FFMpegCore vào dự án của bạn:
   * chạy `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * chạy `dotnet add package FFMpegCore --version 4.8.0`
2. Tải ffmpeg từ [đây](https://ffmpeg.org/download.html).
3. FFMpegCore yêu cầu bạn chỉ định đường dẫn tới ffmpeg đã tải về (ví dụ: giải nén tới "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Chạy mã chuyển đổi PowerPoint sang video.

Đoạn mã C# dưới đây minh họa cách chuyển đổi một bài thuyết trình (gồm một hình dạng và hai hiệu ứng hoạt hình) thành video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // sẽ sử dụng các tệp nhị phân FFmpeg mà chúng tôi đã giải nén tới C:\tools\ffmpeg trước đây.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm một hình dạng cười và sau đó tạo hoạt ảnh cho nó.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Chuyển đổi các khung hình thành video webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Hiệu ứng video**

Khi chuyển đổi bài thuyết trình PowerPoint sang video bằng Aspose.Slides for .NET, bạn có thể áp dụng các hiệu ứng video khác nhau để nâng cao chất lượng hình ảnh của đầu ra. Các hiệu ứng này cho phép bạn kiểm soát cách hiển thị các slide trong video cuối cùng bằng cách thêm chuyển đổi mượt mà, hoạt hình và các yếu tố hình ảnh khác. Phần này giải thích các tùy chọn hiệu ứng video có sẵn và cách áp dụng chúng.

{{% alert color="info" %}} 
Xem:
- [Nâng cao bài thuyết trình PowerPoint với hoạt hình trong C#](https://docs.aspose.com/slides/vi/net/powerpoint-animation/)
- [Hoạt hình hình dạng](https://docs.aspose.com/slides/vi/net/shape-animation/)
- [Áp dụng hiệu ứng hình dạng trong PowerPoint bằng C#](https://docs.aspose.com/slides/vi/net/shape-effect/)
{{% /alert %}} 

Hoạt hình và chuyển đổi làm cho bản trình chiếu hấp dẫn và thú vị — và chúng cũng làm điều tương tự cho video. Hãy thêm một slide và chuyển đổi khác vào mã cho bài thuyết trình trước:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Thêm một hình dạng cười và tạo hoạt ảnh cho nó (xem mã ở trên).

    // Thêm một slide mới và một chuyển đổi có hoạt ảnh.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides cũng hỗ trợ hoạt hình văn bản. Trong ví dụ này, chúng tôi hoạt hình các đoạn văn trên các đối tượng để chúng xuất hiện lần lượt, với độ trễ một giây giữa mỗi đoạn:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm văn bản và hoạt ảnh.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Cấu hình thư mục chứa các tệp nhị phân ffmpeg. Xem trang này: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Chuyển đổi các khung hình thành video webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Các lớp chuyển đổi video**

Để thực hiện các tác vụ chuyển đổi PowerPoint sang video, Aspose.Slides for .NET cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` cho phép bạn đặt kích thước khung cho video (sẽ được tạo sau này) và giá trị FPS (khung hình mỗi giây) thông qua hàm khởi tạo của nó. Nếu bạn truyền một thể hiện của bài thuyết trình, `Presentation.SlideSize` của nó sẽ được sử dụng và nó tạo ra các hoạt hình mà [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/) sử dụng.

Khi các hoạt hình được tạo, một sự kiện `NewAnimation` sẽ được kích hoạt cho mỗi hoạt hình tiếp theo, bao gồm một tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/). Lớp này đại diện cho một trình phát cho một hoạt hình cá nhân.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/), bạn sử dụng thuộc tính [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/duration/) (cung cấp thời lượng đầy đủ của hoạt hình) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Mỗi vị trí hoạt hình được đặt trong phạm vi *0 đến duration*, và phương thức `GetFrame` sẽ trả về một Bitmap đại diện cho trạng thái hoạt hình tại thời điểm đó.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm một hình dạng cười và tạo hoạt ảnh cho nó.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);        // Trạng thái hoạt ảnh ban đầu.
            IImage image = animationPlayer.GetFrame(); // Hình ảnh trạng thái hoạt ảnh ban đầu.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Trạng thái cuối cùng của hoạt ảnh.
            IImage lastImage = animationPlayer.GetFrame();             // Khung hình cuối cùng của hoạt ảnh.
            lastImage.Save("last.png");
        };
    }
}
```

Để làm cho tất cả các hoạt hình trong một bài thuyết trình phát đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationanimationsgenerator/) và một giá trị FPS cho các hiệu ứng trong hàm khởi tạo, sau đó gọi sự kiện `FrameTick` cho tất cả các hoạt hình để phát chúng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Sau đó các khung hình đã tạo có thể được biên dịch để tạo thành video. Xem phần [Chuyển đổi bài thuyết trình PowerPoint sang video](/slides/vi/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Các hoạt hình và hiệu ứng được hỗ trợ**

Khi chuyển đổi bài thuyết trình PowerPoint sang video bằng Aspose.Slides for .NET, việc hiểu các hoạt hình và hiệu ứng nào được hỗ trợ trong đầu ra là rất quan trọng. Aspose.Slides hỗ trợ một loạt các hiệu ứng nhập, xuất và nhấn mạnh thông thường như mờ dần, bay vào, thu phóng và quay. Tuy nhiên, một số hoạt hình nâng cao hoặc tùy chỉnh có thể không được bảo toàn hoàn toàn hoặc có thể xuất hiện khác nhau trong video cuối cùng. Phần này liệt kê các hoạt hình và hiệu ứng được hỗ trợ.

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

## **Các hiệu ứng chuyển đổi slide được hỗ trợ**

Các hiệu ứng chuyển đổi slide đóng vai trò quan trọng trong việc tạo ra các thay đổi mượt mà và trực quan giữa các slide trong video. Aspose.Slides for .NET hỗ trợ nhiều hiệu ứng chuyển đổi thường dùng để giúp duy trì luồng và phong cách của bài thuyết trình gốc. Phần này nêu rõ các hiệu ứng chuyển đổi nào được hỗ trợ trong quá trình chuyển đổi.

**Subtle**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Exciting**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamic Content**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Câu hỏi thường gặp**

### Có thể chuyển đổi các bài thuyết trình được bảo vệ bằng mật khẩu không?

Có, Aspose.Slides for .NET cho phép làm việc với các bài thuyết trình được bảo vệ bằng mật khẩu. Khi xử lý các tệp này, bạn cần cung cấp mật khẩu đúng để thư viện có thể truy cập nội dung của bài thuyết trình.

### Aspose.Slides for .NET có hỗ trợ sử dụng trong các giải pháp đám mây không?

Có, Aspose.Slides for .NET có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

### Có giới hạn kích thước nào cho bài thuyết trình khi chuyển đổi không?

Aspose.Slides for .NET có khả năng xử lý các bài thuyết trình có kích thước gần như không giới hạn. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống và đôi khi bạn nên tối ưu hoá bài thuyết trình để cải thiện hiệu năng.