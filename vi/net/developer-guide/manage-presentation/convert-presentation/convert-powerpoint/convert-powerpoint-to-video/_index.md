---
title: Chuyển đổi bản trình chiếu PowerPoint sang video trong .NET
linktitle: PowerPoint sang Video
type: docs
weight: 130
url: /vi/net/convert-powerpoint-to-video/
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
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi bản trình chiếu PowerPoint sang video trong .NET. Khám phá mã mẫu C# và các kỹ thuật tự động hóa để tối ưu hóa quy trình làm việc của bạn."
---
## **Giới thiệu**

Bằng cách chuyển đổi bản trình chiếu PowerPoint hoặc OpenDocument sang video, bạn sẽ có được:

**Tăng khả năng tiếp cận:** Tất cả các thiết bị, bất kể nền tảng, đều được trang bị trình phát video mặc định, giúp người dùng dễ dàng mở hoặc phát video hơn so với các ứng dụng trình chiếu truyền thống.

**Phạm vi tiếp cận rộng hơn:** Video cho phép bạn tiếp cận lượng khán giả lớn hơn và trình bày thông tin theo định dạng hấp dẫn hơn. Các khảo sát và thống kê cho thấy mọi người ưu tiên xem và tiêu thụ nội dung video hơn các dạng khác, khiến thông điệp của bạn trở nên ấn tượng hơn.

{{% alert color="primary" %}} 

Hãy xem [**Trình chuyển đổi PowerPoint sang Video trực tuyến**](https://products.aspose.app/slides/vi/video) vì nó cung cấp một triển khai trực tiếp và hiệu quả của quy trình được mô tả ở đây.

{{% /alert %}} 

Trong Aspose.Slides for .NET, chúng tôi đã triển khai hỗ trợ chuyển đổi bản trình chiếu sang video.

* Sử dụng Aspose.Slides for .NET để tạo khung hình từ các slide của bản trình chiếu với tốc độ khung hình (FPS) xác định.
* Sau đó, sử dụng công cụ bên thứ ba như ffmpeg để biên dịch các khung hình này thành video.

## **Chuyển đổi Bản trình chiếu PowerPoint sang Video**

1. Sử dụng lệnh `dotnet add package` để thêm Aspose.Slides và thư viện FFMpegCore vào dự án của bạn:
   * chạy `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * chạy `dotnet add package FFMpegCore --version 4.8.0`
2. Tải xuống ffmpeg từ [đây](https://ffmpeg.org/download.html).
3. FFMpegCore yêu cầu bạn chỉ định đường dẫn tới ffmpeg đã tải xuống (ví dụ: giải nén tới "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Chạy mã chuyển đổi PowerPoint thành video.

Mã C# dưới đây minh họa cách chuyển đổi một bản trình chiếu (chứa một hình dạng và hai hiệu ứng hoạt ảnh) thành video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // sẽ sử dụng các tệp nhị phân FFmpeg mà chúng tôi đã giải nén vào C:\tools\ffmpeg trước đó.
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

## **Hiệu ứng Video**

Khi chuyển đổi bản trình chiếu PowerPoint sang video bằng Aspose.Slides for .NET, bạn có thể áp dụng nhiều hiệu ứng video khác nhau để nâng cao chất lượng hình ảnh của đầu ra. Những hiệu ứng này cho phép bạn kiểm soát cách hiển thị các slide trong video cuối cùng bằng cách thêm chuyển tiếp mượt mà, hoạt ảnh và các yếu tố trực quan khác. Phần này giải thích các tùy chọn hiệu ứng video có sẵn và chỉ cách áp dụng chúng.

{{% alert color="primary" %}} 

Xem:
- [Nâng cao Bản trình chiếu PowerPoint bằng Hoạt ảnh trong C#](https://docs.aspose.com/slides/vi/net/powerpoint-animation/)
- [Hoạt ảnh Hình dạng](https://docs.aspose.com/slides/vi/net/shape-animation/)
- [Áp dụng Hiệu ứng Hình dạng trong PowerPoint bằng C#](https://docs.aspose.com/slides/vi/net/shape-effect/)

{{% /alert %}} 

Hoạt ảnh và chuyển tiếp làm cho slideshow trở nên hấp dẫn và thú vị — và chúng cũng làm tương tự cho video. Hãy thêm một slide và chuyển tiếp nữa vào mã cho bản trình chiếu trước đây:

```c#
// Thêm một hình dạng cười và tạo hoạt ảnh cho nó.
// ...

// Thêm một slide mới và một chuyển tiếp hoạt ảnh.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides cũng hỗ trợ hoạt ảnh văn bản. Trong ví dụ này, chúng tôi hoạt ảnh các đoạn văn trên các đối tượng sao cho chúng xuất hiện lần lượt, với độ trễ một giây giữa mỗi đoạn:

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

## **Các lớp Chuyển đổi Video**

Để thực hiện các nhiệm vụ chuyển đổi PowerPoint sang video, Aspose.Slides for .NET cung cấp các lớp [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationanimationsgenerator/) và [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` cho phép bạn thiết lập kích thước khung hình cho video (sẽ được tạo sau) và giá trị FPS (khung hình mỗi giây) thông qua constructor. Nếu bạn truyền một đối tượng presentation, `Presentation.SlideSize` của nó sẽ được sử dụng và nó sẽ tạo ra các hoạt ảnh mà [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/) sử dụng.

Khi các hoạt ảnh được tạo, sự kiện `NewAnimation` sẽ được kích hoạt cho mỗi hoạt ảnh tiếp theo, bao gồm một tham số [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/). Lớp này đại diện cho một trình phát cho một hoạt ảnh riêng lẻ.

Để làm việc với [IPresentationAnimationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/), bạn sử dụng thuộc tính [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/duration/) (cung cấp thời lượng đầy đủ của hoạt ảnh) và phương thức [SetTimePosition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Mỗi vị trí hoạt ảnh được đặt trong phạm vi *0 đến duration*, và phương thức `GetFrame` sẽ trả về một Bitmap biểu diễn trạng thái hoạt ảnh tại thời điểm đó.

```c#
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

            animationPlayer.SetTimePosition(0);          // Trạng thái hoạt ảnh ban đầu.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmap trạng thái hoạt ảnh ban đầu.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Trạng thái cuối cùng của hoạt ảnh.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Khung hình cuối cùng của hoạt ảnh.
            lastBitmap.Save("last.png");
        };
    }
}
```

Để làm cho tất cả các hoạt ảnh trong một bản trình chiếu chạy đồng thời, lớp [PresentationPlayer](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationplayer/) được sử dụng. Lớp này nhận một thể hiện của [PresentationAnimationsGenerator](https://reference.aspose.com/slides/vi/net/aspose.slides.export/presentationanimationsgenerator/) và một giá trị FPS cho các hiệu ứng trong constructor, sau đó gọi sự kiện `FrameTick` cho mọi hoạt ảnh để phát chúng:

```c#
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

Sau đó các khung hình đã tạo có thể được biên dịch để tạo thành video. Xem phần [Chuyển đổi Bản trình chiếu PowerPoint sang Video](/slides/vi/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Các Hoạt ảnh và Hiệu ứng được Hỗ trợ**

Khi chuyển đổi bản trình chiếu PowerPoint sang video bằng Aspose.Slides for .NET, việc hiểu các hoạt ảnh và hiệu ứng nào được hỗ trợ trong đầu ra là rất quan trọng. Aspose.Slides hỗ trợ một loạt các hiệu ứng nhập, xuất và nhấn mạnh phổ biến như mờ, bay vào, thu phóng và quay. Tuy nhiên, một số hoạt ảnh nâng cao hoặc tùy chỉnh có thể không được bảo toàn hoàn toàn hoặc có thể hiển thị khác biệt trong video cuối cùng. Phần này liệt kê các hoạt ảnh và hiệu ứng được hỗ trợ.

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fade** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Fly In** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Float In** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Split** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Wipe** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Shape** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Wheel** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Random Bars** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Grow & Turn** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Zoom** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Swivel** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bounce** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Color Pulse** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Teeter** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Spin** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Grow/Shrink** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Desaturate** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Darken** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Lighten** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Transparency** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Object Color** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Complementary Color** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Line Color** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fill Color** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fade** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Fly Out** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Float Out** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Split** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Wipe** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Shape** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Random Bars** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Shrink & Turn** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Zoom** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Swivel** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Bounce** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Arcs** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Turns** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Shapes** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Loops** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Custom Path** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

## **Các hiệu ứng Chuyển tiếp Slide được Hỗ trợ**

Hiệu ứng chuyển tiếp slide đóng vai trò quan trọng trong việc tạo ra các chuyển đổi mượt mà và hấp dẫn giữa các slide trong video. Aspose.Slides for .NET hỗ trợ nhiều hiệu ứng chuyển tiếp phổ biến để giúp duy trì luồng và phong cách của bản trình chiếu gốc. Phần này nêu bật các hiệu ứng chuyển tiếp được hỗ trợ trong quá trình chuyển đổi.

**Subtle**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fade** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Push** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Pull** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Wipe** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Split** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Reveal** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Random Bars** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Shape** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Uncover** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Cover** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Flash** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Strips** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

**Exciting**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Drape** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Curtains** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Wind** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Prestige** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fracture** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Crush** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Peel Off** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Page Curl** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Airplane** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Origami** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Dissolve** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Checkerboard** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Blinds** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Clock** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Ripple** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Honeycomb** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Glitter** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Vortex** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Shred** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Switch** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Flip** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Gallery** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Cube** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Doors** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Box** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Comb** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Zoom** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Random** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |

**Dynamic Content**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Ferris Wheel** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |
| **Conveyor** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Rotate** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Orbit** | ![không hỗ trợ](x.png) | ![được hỗ trợ](v.png) |
| **Fly Through** | ![được hỗ trợ](v.png) | ![được hỗ trợ](v.png) |

## **Câu hỏi thường gặp**

**Có thể chuyển đổi các bản trình chiếu được bảo vệ bằng mật khẩu không?**

Có, Aspose.Slides for .NET cho phép làm việc với các bản trình chiếu được bảo vệ bằng mật khẩu. Khi xử lý các tệp này, bạn cần cung cấp đúng mật khẩu để thư viện có thể truy cập nội dung của bản trình chiếu.

**Aspose.Slides for .NET có hỗ trợ sử dụng trong các giải pháp đám mây không?**

Có, Aspose.Slides for .NET có thể được tích hợp vào các ứng dụng và dịch vụ đám mây. Thư viện được thiết kế để hoạt động trong môi trường máy chủ, đảm bảo hiệu năng cao và khả năng mở rộng cho việc xử lý hàng loạt các tệp.

**Có giới hạn kích thước nào cho các bản trình chiếu khi chuyển đổi không?**

Aspose.Slides for .NET có khả năng xử lý các bản trình chiếu với kích thước gần như vô hạn. Tuy nhiên, khi làm việc với các tệp rất lớn, có thể cần thêm tài nguyên hệ thống, và đôi khi nên tối ưu hóa bản trình chiếu để cải thiện hiệu suất.