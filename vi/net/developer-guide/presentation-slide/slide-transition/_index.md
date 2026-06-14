---
title: Quản lý chuyển đổi slide trong bản thuyết trình bằng .NET
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
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tùy chỉnh chuyển đổi slide trong Aspose.Slides cho .NET, với hướng dẫn từng bước cho bản thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý chuyển đổi slide trong các bản thuyết trình bằng cách sử dụng Aspose.Slides. Nó trình bày cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như chuyển tiếp khi nhấp chuột hoặc sau một khoảng thời gian nhất định, kiểm tra và vô hiệu hóa việc tự động chuyển tiếp, sử dụng chuyển đổi Morph và các loại của nó, và đặt các tùy chọn hiệu ứng chuyển đổi. Các ví dụ cho thấy cách tải hoặc tạo một bản thuyết trình, sửa đổi cài đặt chuyển đổi cho các slide đã chọn, và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide, và kiểm tra chuyển đổi hiện đang được đặt trên một slide.

## **Thêm chuyển đổi slide**
Để dễ hiểu hơn, chúng tôi đã trình diễn việc sử dụng Aspose.Slides cho .NET để quản lý các chuyển đổi slide đơn giản. Các nhà phát triển không chỉ có thể áp dụng các hiệu ứng chuyển đổi slide khác nhau trên các slide mà còn tùy chỉnh hành vi của các hiệu ứng chuyển đổi này. Để tạo một hiệu ứng chuyển đổi slide đơn giản, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) class.
1. Áp dụng một loại chuyển đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides cho .NET cung cấp thông qua enum TransitionType.
1. Ghi tệp bản thuyết trình đã sửa đổi.

```c#
// Tạo thể hiện lớp Presentation để tải tệp bản thuyết trình nguồn
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Áp dụng chuyển đổi loại circle cho slide 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Áp dụng chuyển đổi loại comb cho slide 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Ghi bản thuyết trình ra đĩa
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Thêm chuyển đổi slide nâng cao**
Trong phần trên, chúng tôi chỉ áp dụng một hiệu ứng chuyển đổi đơn giản trên slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản đó tốt hơn và được kiểm soát, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) class.
1. Áp dụng một loại chuyển đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides cho .NET cung cấp.
1. Bạn cũng có thể đặt chuyển đổi để Tiến lên Khi Nhấp, sau một khoảng thời gian cụ thể hoặc cả hai.
1. Nếu chuyển đổi slide được bật để Tiến lên Khi Nhấp, chuyển đổi sẽ chỉ tiến khi người dùng nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được đặt, chuyển đổi sẽ tự động tiến sau thời gian đã chỉ định.
1. Ghi bản thuyết trình đã sửa đổi dưới dạng tệp bản thuyết trình.

```c#
// Tạo thể hiện lớp Presentation đại diện cho một tệp bản thuyết trình
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Áp dụng chuyển đổi loại circle cho slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Đặt thời gian chuyển đổi là 3 giây
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Áp dụng chuyển đổi loại comb cho slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Đặt thời gian chuyển đổi là 5 giây
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Áp dụng chuyển đổi loại zoom cho slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Đặt thời gian chuyển đổi là 7 giây
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Ghi bản thuyết trình ra đĩa
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Ngoài ra, bằng cách sử dụng thuộc tính [AdvanceAfter](https://reference.aspose.com/slides/vi/net/aspose.slides/islideshowtransition/advanceafter/) , bạn có thể kiểm tra xem chuyển đổi slide đã được cấu hình để chuyển sang slide tiếp theo hay đã vô hiệu hóa cài đặt.

Đoạn mã C# này minh họa hoạt động:

```c#
 // Khởi tạo một lớp Presentation đại diện cho một tệp bản thuyết trình
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Lấy chuyển đổi slide
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Kiểm tra xem cài đặt Advance After Time có được bật không
        if (slideTransition.AdvanceAfter)
        {
            // In ra giá trị Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Vô hiệu hóa chuyển đổi sau một thời gian nhất định nếu giá trị AdvanceAfterTime lớn hơn 2 giây
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Chuyển đổi Morph**
Aspose.Slides cho .NET hiện hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/imorphtransition). Đây là một chuyển đổi morph mới được giới thiệu trong PowerPoint 2019. Chuyển đổi Morph cho phép bạn tạo hoạt ảnh di chuyển mượt mà từ slide này sang slide tiếp theo. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph hiệu quả, bạn cần có hai slide ít nhất chia sẻ một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến vị trí khác.

Đoạn mã dưới đây cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bản thuyết trình và đặt một chuyển đổi [morph type](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) cho slide thứ hai.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Các loại chuyển đổi Morph**
Enum mới [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionmorphtype) đã được thêm. Nó đại diện cho các loại chuyển đổi Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện xem các hình dạng là các đối tượng không thể chia nhỏ.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển đổi văn bản theo từ nếu có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển đổi văn bản theo ký tự nếu có thể.

Đoạn mã dưới đây cho bạn thấy cách đặt chuyển đổi morph cho slide và thay đổi loại morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Đặt hiệu ứng chuyển đổi**
Aspose.Slides cho .NET hỗ trợ thiết lập các hiệu ứng chuyển đổi như, từ màu đen, từ trái, từ phải, v.v. Để đặt hiệu ứng chuyển đổi, vui lòng thực hiện các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) class.
- Lấy tham chiếu của slide.
- Đặt hiệu ứng chuyển đổi.
- Ghi bản thuyết trình dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Đặt hiệu ứng
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Ghi bản thuyết trình ra đĩa
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Đúng. Đặt [Speed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/speed/) của chuyển đổi bằng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/transitionspeed/) (ví dụ: slow/medium/fast).

**Tôi có thể đính kèm âm thanh vào một chuyển đổi và lặp lại nó không?**

Đúng. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi thông qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/soundloop/), cộng với siêu dữ liệu như [SoundIsBuiltIn](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) và [SoundName](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của từng slide; các chuyển đổi được lưu riêng cho mỗi slide, vì vậy việc áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả nhất quán.

**Làm thế nào tôi có thể kiểm tra chuyển đổi hiện đang được đặt trên một slide?**

Kiểm tra [cài đặt chuyển đổi](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide/slideshowtransition/) của slide và đọc [loại chuyển đổi](https://reference.aspose.com/slides/vi/net/aspose.slides.slideshow/slideshowtransition/type/); giá trị đó cho biết chính xác hiệu ứng nào đang được áp dụng.