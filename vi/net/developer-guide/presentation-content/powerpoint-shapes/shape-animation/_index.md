---
title: Áp dụng hoạt ảnh Shape trong các bài thuyết trình trên .NET
linktitle: Hoạt ảnh Hình
type: docs
weight: 60
url: /vi/net/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng động
- văn bản động
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bài thuyết trình PowerPoint với Aspose.Slides cho .NET. Nổi bật!"
---
## **Giới thiệu**

Hoạt ảnh là các hiệu ứng hình ảnh có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [biểu đồ](/slides/vi/net/animated-charts/). Chúng mang lại sức sống cho các bài thuyết trình hoặc các thành phần của chúng. 

## **Tại sao nên dùng hoạt ảnh trong bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc sự tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và các hiệu ứng hoạt ảnh trong các danh mục **đầu vào**, **đầu ra**, **nhấn mạnh**, và **đường di chuyển**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu mà bạn cần để làm việc với hoạt ảnh trong không gian tên [Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/),
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** trong enumeration [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype). Các hiệu ứng này về cơ bản giống (hoặc tương đương) các hiệu ứng được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides cho .NET cho phép bạn áp dụng hoạt ảnh cho văn bản trong một hình dạng. 

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape). 
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/properties/textframe).
5. Lấy chuỗi chính của các hiệu ứng.
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape).
7. Đặt thuộc tính [TextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/textanimation/properties/buildtype) thành giá trị từ [BuildType Enumeration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype).
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Thêm AutoShape mới với văn bản
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Thêm ba đoạn văn để chế độ xây dựng theo đoạn có gì để duyệt qua.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Lấy chuỗi chính của slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Thêm hiệu ứng hoạt ảnh Fade cho shape
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hoạt ảnh văn bản shape theo các đoạn cấp 1
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Lưu tệp PPTX vào đĩa
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph) đơn lẻ. Xem [**Animated Text**](/slides/vi/net/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe) trên slide. 
5. Lấy chuỗi chính của các hiệu ứng.
6. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe).
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một khung hình ảnh:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation pres = new Presentation())
{
    // Tải ảnh để thêm vào bộ sưu tập ảnh của bài thuyết trình
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm khung hình ảnh vào slide
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Thêm hiệu ứng Fly từ trái vào khung hình ảnh
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu tệp PPTX vào đĩa
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape). 
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi các hiệu ứng trên hình dạng bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh di chuyển tới `UserPath`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường bóng đá) cho một hình dạng:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Thêm hiệu ứng hoạt ảnh PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tạo một loại "button" nào đó.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tạo một chuỗi các hiệu ứng cho button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Tạo một đường path tùy chỉnh. Đối tượng của chúng ta sẽ chỉ di chuyển sau khi button được nhấp.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Thêm các lệnh di chuyển vì đường path đã tạo còn trống.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Ghi tệp PPTX vào đĩa
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `GetEffectsByShape` từ giao diện [ISequence](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một shape trên slide bình thường**

Trước đây, bạn đã học cách thêm các hiệu ứng hoạt ảnh vào các shape trong bài thuyết trình PowerPoint. Mã mẫu dưới đây cho bạn thấy cách lấy các hiệu ứng đã áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Lấy chuỗi hoạt ảnh chính của slide.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Lấy shape đầu tiên trên slide đầu tiên.
    IShape shape = firstSlide.Shapes[0];

    // Lấy các hiệu ứng hoạt ảnh được áp dụng cho shape.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm cả những hiệu ứng kế thừa từ placeholders**

Nếu một shape trên slide bình thường có placeholders nằm trên slide bố cục và/hoặc slide master, và các hiệu ứng hoạt ảnh đã được thêm vào các placeholders này, thì tất cả các hiệu ứng của shape sẽ được phát trong buổi chiếu slide, bao gồm cả những hiệu ứng kế thừa từ các placeholders.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** được áp dụng cho shape.

![Hiệu ứng hoạt ảnh shape slide](slide-shape-animation.png)

Giả sử thêm rằng hiệu ứng **Split** được áp dụng cho placeholder footer trên slide **layout**.

![Hiệu ứng hoạt ảnh shape layout](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** được áp dụng cho placeholder footer trên slide **master**.

![Hiệu ứng hoạt ảnh shape master](master-shape-animation.png)

Mã mẫu dưới đây cho bạn thấy cách sử dụng phương thức `GetBasePlaceholder` từ giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm cả những hiệu ứng kế thừa từ các placeholder nằm trên slide layout và master.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy các hiệu ứng hoạt ảnh của shape trên slide bình thường.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Lấy các hiệu ứng hoạt ảnh của placeholder trên slide layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Lấy các hiệu ứng hoạt ảnh của placeholder trên slide master.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Thay đổi các thuộc tính thời gian của hiệu ứng hoạt ảnh**

Aspose.Slides cho .NET cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Timing và menu mở rộng trong Microsoft PowerPoint:

![Cửa sổ Animation Timing](shape-animation.png)

Các tương quan giữa PowerPoint Timing và các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/properties/timing):

- Danh sách thả xuống **Start** của PowerPoint Timing tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/triggertype). 
- PowerPoint Timing **Duration** tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/duration). Thời lượng của một hoạt ảnh (giây) là tổng thời gian hoạt ảnh cần để hoàn thành một chu kỳ. 
- PowerPoint Timing **Delay** tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- PowerPoint Timing **Repeat** danh sách thả xuống tương ứng với các thuộc tính: 
  * Thuộc tính [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount) mô tả *số* lần hiệu ứng được lặp lại;
  * cờ [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide) chỉ định hiệu ứng có được lặp lại cho đến khi slide kết thúc hay không;
  * cờ [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick) chỉ định hiệu ứng có được lặp lại cho đến lần nhấp tiếp theo hay không.
- Ô kiểm **Rewind when done playing** của PowerPoint Timing tương ứng với thuộc tính [Effect.Timing.Rewind](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/rewind/). 

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/properties/timing) mà bạn cần. 
3. Lưu tệp PPTX đã sửa đổi.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lấy hiệu ứng đầu tiên của chuỗi chính.
    IEffect effect = sequence[0];

    // Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấp chuột
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Thay đổi Duration của hiệu ứng
    effect.Timing.Duration = 3f;

    // Thay đổi TriggerDelayTime của hiệu ứng
    effect.Timing.TriggerDelayTime = 0.5f;

    // Nếu giá trị Repeat của hiệu ứng là "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Thay đổi Repeat của hiệu ứng thành "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Thay đổi Repeat của hiệu ứng thành "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Bật chế độ Rewind cho hiệu ứng
        effect.Timing.Rewind = true;
    
    // Lưu tệp PPTX vào đĩa
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Âm thanh của hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 
- [IEffect.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Mã C# này cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Thêm âm thanh vào bộ sưu tập âm thanh của bài thuyết trình
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Lấy chuỗi chính của slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Lấy hiệu ứng đầu tiên của chuỗi chính
	IEffect firstEffect = sequence[0];

	// Kiểm tra hiệu ứng xem có "No Sound" không
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Thêm âm thanh cho hiệu ứng đầu tiên
		firstEffect.Sound = effectSound;
	}

	// Lấy chuỗi tương tác đầu tiên của slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Đặt cờ "Stop previous sound" cho hiệu ứng
	interactiveSequence[0].StopPreviousSound = true;

	// Ghi tệp PPTX vào đĩa
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Trích xuất âm thanh của hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Lấy chuỗi chính của các hiệu ứng. 
4. Trích xuất [Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/sound/) được nhúng vào mỗi hiệu ứng hoạt ảnh. 

Mã C# này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy chuỗi chính của slide.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Trích xuất âm thanh của hiệu ứng dưới dạng mảng byte
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Sau hoạt ảnh**

Aspose.Slides cho .NET cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![Cửa sổ Animation Effect](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint Effect tương ứng với các thuộc tính sau: 

- Thuộc tính [IEffect.AfterAnimationType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationtype/) mô tả loại After animation :
  * PowerPoint **More Colors** tương ứng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) ;
  * Mục **Don't Dim** của PowerPoint tương ứng với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) (kiểu after animation mặc định);
  * Mục **Hide After Animation** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) ;
  * Mục **Hide on Next Mouse Click** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) ;
- Thuộc tính [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationcolor/) định nghĩa định dạng màu after animation. Thuộc tính này hoạt động cùng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/). Nếu bạn thay đổi kiểu sang một kiểu khác, màu after animation sẽ bị xóa.

Mã C# này cho bạn thấy cách thay đổi một hiệu ứng after animation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Thay đổi loại after animation thành Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Đặt màu dim cho after animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Ghi tệp PPTX vào đĩa
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Hoạt ảnh Văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- Thuộc tính [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) mô tả loại animate text của hiệu ứng. Văn bản shape có thể được hoạt ảnh:
  - Tất cả cùng lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) )
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) )
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) )
- Thuộc tính [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) thiết lập độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ phần trăm thời lượng hiệu ứng. Giá trị âm chỉ độ trễ tính bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt thuộc tính [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itextanimation/buildtype/) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) để tắt chế độ hoạt ảnh *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) và [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Lưu tệp PPTX đã sửa đổi.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Khởi tạo một lớp Presentation biểu diễn một tệp bài thuyết trình.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Lấy hiệu ứng đầu tiên của chuỗi chính
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Thay đổi kiểu hoạt ảnh Văn bản của hiệu ứng thành "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Thay đổi kiểu Animate text của hiệu ứng thành "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
	firstEffect.DelayBetweenTextParts = 20f;

	// Ghi tệp PPTX vào đĩa
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

### Làm sao để đảm bảo hoạt ảnh được giữ nguyên khi xuất bản bài thuyết trình lên web?

[Export to HTML5](/slides/vi/net/export-to-html5/) và bật [các tùy chọn](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animateshapes/) và [transition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animatetransitions/). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có.

### Thay đổi thứ tự z-order (thứ tự lớp) của các shape ảnh hưởng thế nào đến hoạt ảnh?

Hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/zorderposition/) xác định phần nào phủ lên phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic tương tự.)

### Có những hạn chế nào khi chuyển đổi hoạt ảnh sang video cho một số hiệu ứng không?

Nói chung, [các hoạt ảnh được hỗ trợ](/slides/vi/net/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc các hiệu ứng cụ thể có thể được hiển thị khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn dùng và với phiên bản thư viện.