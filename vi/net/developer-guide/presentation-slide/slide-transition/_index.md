---
title: Quản lý chuyển đổi slide trong bản trình bày bằng .NET
linktitle: Chuyển đổi slide
type: docs
weight: 90
url: /vi/net/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi Morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến tự động của slide, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho .NET."
---
## **Tổng quan**

Hiệu ứng chuyển đổi slide điều khiển cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides cho .NET, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ C# để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng chuyển đổi, tải một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và truy cập thuộc tính [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) của slide. Đặt [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) thành một giá trị trong enum [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) , sau đó lưu bản trình bày.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Chuyển đổi Wheel**

Thuộc tính [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) của [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) kiểm soát số sector tia radial hiển thị slide đích. Đặt [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) của slide thành Wheel từ [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) trước khi truy cập [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) dưới dạng [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Ví dụ này tạo hai cặp slide giống hệt: một slide đen tiếp theo là slide có hình chữ nhật màu vàng. Các slide đích sử dụng số spoke là 1 và 8, với cùng [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) và một [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) rõ ràng là 8.000 milgiây để dễ quan sát sự khác nhau.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Mở bản trình bày đầu ra trong PowerPoint và chạy buổi trình chiếu. Tiến từ slide 1 sang slide 2, sau đó từ slide 3 sang slide 4. Trong chế độ phát của PowerPoint, số spoke đã xác nhận là 1 sẽ hiển thị slide bằng một quét chiều kim đồng hồ; số 8 sẽ hiển thị nó qua tám sector đồng thời. Nội dung đích và thời gian chuyển đổi đều giống nhau, vì vậy điểm khác nhau chỉ là số sector hiển thị.

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide ở lại trên màn hình và việc nhấp chuột có tiến bộ buổi trình chiếu hay không. Các thuộc tính sau kiểm soát hành vi này:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) cho phép người xem tiến tới bằng cách nhấp chuột.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) cho phép tiến tự động.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) xác định độ trễ trước khi tiến tự động, tính bằng milgiây.

Bật cả tiến bằng nhấp chuột và tiến theo thời gian để cho phép người xem chuyển tiếp bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ dùng bộ hẹn giờ, đặt [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) thành `false`. Độ trễ kiểm soát thời điểm buổi trình chiếu tiến lên; nó không đặt thời lượng của hiệu ứng chuyển đổi hình ảnh.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tự động sau 3, 5 và 7 giây, tương ứng. Nhấp chuột cũng có thể tiến các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Để kiểm tra xem tiến tự động theo thời gian có được bật hay không, đọc [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Một độ trễ lưu trữ một mình không cho biết bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật, và tắt tiến tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho các slide đó và lưu các cài đặt đã cập nhật.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng milgiây. Thuộc tính [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) của slide cung cấp các cài đặt này thông qua [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Thuộc tính | Mục đích |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng milgiây. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Đặt độ trễ trước khi slide tiến tự động, tính bằng milgiây. Bật [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) để kích hoạt bộ hẹn giờ này. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Chọn một hạng tốc độ đã định sẵn từ enum [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, hoặc Fast. Được dùng khi không có thời lượng cụ thể được chỉ định. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) chỉ điều khiển hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến tự động riêng biệt. Khi không đặt thời lượng rõ ràng, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), và đặt mỗi chuyển đổi có thời lượng 750 milgiây. Nó riêng biệt bật tiến tự động sau 5.000 milgiây và tắt tiến bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Cấu hình tiến tự động độc lập với thời lượng hiệu ứng.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Đặt thời lượng khác nhau cho các slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, dùng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho phần giới thiệu mục. Ví dụ này đặt 500 milgiây cho slide đầu tiên và 1.200 milgiây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Phối hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/net/export-to-html5/), hoặc [video](/slides/vi/net/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng fade 600 milgiây giữa các cảnh, và điều chỉnh độ trễ tiến của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung đầu ra với thời lượng hiệu ứng: 600 milgiây tương ứng với 18 khung ở 30 khung mỗi giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Đọc [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) trước khi sửa đổi chuyển đổi để xác định xem có giá trị cụ thể nào được lưu không. Giá trị `-1` nghĩa là không có thời lượng cụ thể được đặt; giá trị không âm chỉ thời lượng đã lưu tính bằng milgiây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides sử dụng loại chuyển đổi và [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) để xác định thời lượng đó. Đặt loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Chuyển đổi Morph**

Chuyển đổi Morph hoạt họa các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp cho chuyển đổi các đối tượng tương ứng để hoạt họa giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide có hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enum [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem bản trình bày hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Các loại chuyển đổi Morph**

Enum [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt họa nội dung:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) xử lý mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) hoạt họa văn bản bằng cách ghép các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) hoạt họa văn bản bằng cách ghép các ký tự khi có thể.

Đặt [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) của chuyển đổi thành Morph trước khi truy cập [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Giá trị sau đó cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), thuộc tính [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) chọn chế độ khớp.

Ví dụ này mở bản trình bày được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt họa Morph dựa trên từ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Các đơn vị khớp Morph được hiển thị dưới dạng hình dạng toàn bộ, các từ riêng lẻ và các ký tự riêng lẻ.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph có thể khớp toàn bộ hình dạng, từ hoặc ký tự khi có thể. Các hộp này xác định các đơn vị khớp chứ không phải chuyển động quan sát được. Ví dụ chọn ByWord trên slide thứ hai.*
<!-- visual-explanation:slide-transition:end -->

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn có sẵn phụ thuộc vào [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) chuyển đổi đã chọn. Đặt loại trước, sau đó sử dụng giao diện thích hợp từ [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó đặt [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát lại của một chuyển đổi slide không?**

Có. Ưu tiên sử dụng [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng milgiây. Sử dụng [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) khi một hạng mục [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) đã định sẵn—Slow, Medium, hoặc Fast—đủ và không có thời lượng cụ thể nào được đặt. Các cài đặt này điều khiển hiệu ứng chuyển đổi một cách độc lập với độ trễ tiến tự động.

**Tôi có thể đính kèm âm thanh vào một chuyển đổi và làm nó lặp lại không?**

Có. Gán âm thanh nhúng cho [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), đặt [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) thành StartSound từ enum [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), và bật [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Duyệt qua bộ sưu tập [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) của bản trình bày và đặt [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) của mỗi slide thành cùng một giá trị. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để giữ hành vi nhất quán giữa các slide.

**Làm thế nào để kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Đọc thuộc tính [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) từ [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) của slide. Nó trả về một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.