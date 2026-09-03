---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng .NET
linktitle: Chuyển đổi Slide
type: docs
weight: 90
url: /vi/net/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình chuyển tiếp slide tự động, và tùy chỉnh Morph cùng các hiệu ứng chuyển đổi khác với Aspose.Slides cho .NET."
---
## **Tổng quan**

Các hiệu ứng chuyển đổi slide kiểm soát cách các slide hiển thị trong buổi trình chiếu. Với Aspose.Slides for .NET, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn đặc thù cho một hiệu ứng. Bài viết này sử dụng các ví dụ C# để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng minh họa cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và truy cập thuộc tính [SlideShowTransition](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/slideshowtransition/). Đặt [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/type/) thành một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitiontype/). Sau đó lưu bản trình chiếu.

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

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có chuyển tiếp buổi trình chiếu hay không. Các thuộc tính sau kiểm soát hành vi này:

- [AdvanceOnClick](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceonclick/) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [AdvanceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceafter/) kích hoạt việc chuyển tiếp tự động.
- [AdvanceAfterTime](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceaftertime/) xác định độ trễ trước khi chuyển tiếp tự động, tính bằng mili giây.

Kích hoạt cả chuyển tiếp bằng nhấp chuột và bằng bộ đếm thời gian để người xem có thể tiếp tục bằng một cú nhấp chuột hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, đặt [AdvanceOnClick](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceonclick/) thành `false`. Độ trễ kiểm soát thời điểm buổi trình chiếu chuyển tiếp; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và kích hoạt chuyển tiếp tự động sau lần lượt 3, 5 và 7 giây. Các slide cũng có thể được chuyển tiếp bằng cú nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem chuyển tiếp có được tự động theo thời gian hay không, đọc [AdvanceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceafter/). Một độ trễ được lưu không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật chuyển tiếp bằng nhấp chuột cho các slide đó và lưu lại cài đặt đã cập nhật.

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

Sử dụng [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/duration/) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Thuộc tính [SlideShowTransition](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/slideshowtransition/) của slide cung cấp các cài đặt này thông qua [ISlideShowTransition](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/):

| Thuộc tính | Mục đích |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/duration/) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng mili giây. Kích hoạt [AdvanceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceafter/) để bật bộ hẹn giờ này. |
| [Speed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/speed/) | Chọn một hạng tốc độ định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium hoặc Fast. Được sử dụng khi không chỉ định thời lượng chính xác. |

[Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/duration/) chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide còn lại trên màn hình. Cấu hình độ trễ tự động chuyển tiếp riêng biệt. Khi không có thời lượng cụ thể nào được đặt, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [Speed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitiontype/), và đặt thời lượng 750 mili giây cho mỗi chuyển đổi. Đồng thời bật chuyển tiếp tự động sau 5.000 mili giây và tắt chuyển tiếp bằng nhấp chuột, rồi lưu kết quả dưới dạng PPTX.

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

    // Cấu hình chuyển tiếp tự động độc lập với thời lượng hiệu ứng.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, dùng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho phần giới thiệu chương. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra động**

Khi chuẩn bị một [animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/net/export-to-html5/), hoặc [video](/slides/vi/net/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ chuyển tiếp của mỗi slide riêng biệt để dành thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, phối hợp tốc độ khung hình của đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở 30 khung hình mỗi giây. Trong HTML5, bật chuyển đổi động trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian mà định dạng xuất đã chọn hỗ trợ, và xem trước để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Đọc [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/duration/) trước khi chỉnh sửa chuyển đổi để xác định liệu có giá trị rõ ràng được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng cụ thể nào được đặt; một giá trị không âm chỉ thời lượng đã lưu tính bằng mili giây. Giá trị chưa được đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides sử dụng loại chuyển đổi và [Speed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/speed/) để xác định thời lượng đó. Đặt loại chuyển đổi có thể khởi tạo một thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

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

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng được hoạt ảnh giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ sau tạo một slide chứa hình chữ nhật văn bản, sao chép slide đó, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ enum [TransitionType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

Enum [TransitionMorphType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionmorphtype/) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionmorphtype/) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionmorphtype/) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Đặt [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/type/) của chuyển đổi thành Morph trước khi truy cập [Value](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/value/). Giá trị này sau đó cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/imorphtransition/), trong đó thuộc tính [MorphType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/imorphtransition/morphtype/) chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt ảnh Morph dựa trên từ.

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

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/type/) của chuyển đổi đã chọn. Đặt loại trước, sau đó sử dụng giao diện thích hợp từ [Value](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/value/).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó đặt [FromBlack](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/ioptionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát lại của chuyển đổi slide không?**

Có. Ưu tiên sử dụng [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/duration/) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [Speed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/speed/) khi một hạng mục tốc độ định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionspeed/)—Slow, Medium, hoặc Fast—đủ và không có thời lượng cụ thể nào được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi riêng biệt với độ trễ tự động chuyển tiếp.

**Tôi có thể gắn âm thanh vào một chuyển đổi và lặp lại nó không?**

Có. Gán âm thanh nhúng cho [Sound](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/sound/), đặt [SoundMode](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/soundmode/) thành StartSound từ enum [TransitionSoundMode](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionsoundmode/), và bật [SoundLoop](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/soundloop/). Âm thanh sẽ lặp lại cho đến khi có sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Duyệt qua bộ sưu tập [Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) của bản trình chiếu và đặt [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/type/) của mỗi slide thành cùng một giá trị. Đặt bất kỳ tùy chọn thời gian hay hiệu ứng nào trong cùng một vòng lặp để hành vi được duy trì nhất quán trên tất cả các slide.

**Làm thế nào để kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Đọc thuộc tính [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/type/) từ [SlideShowTransition](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/slideshowtransition/) của slide. Nó trả về một giá trị từ enum [TransitionType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitiontype/); giá trị None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.