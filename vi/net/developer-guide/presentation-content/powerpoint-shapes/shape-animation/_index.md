---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản thuyết trình bằng .NET
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/net/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng hoạt ảnh
- văn bản hoạt ảnh
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bản thuyết trình PowerPoint với Aspose.Slides cho .NET. Nổi bật!"
---
## **Giới thiệu**

Hoạt ảnh là các hiệu ứng hình ảnh có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [biểu đồ](/slides/vi/net/animated-charts/). Chúng mang lại sức sống cho các bài thuyết trình hoặc các thành phần của chúng. 

## **Tại sao nên sử dụng hoạt ảnh trong bản thuyết trình?**

Bằng cách sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bản thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và các hiệu ứng hoạt ảnh trong các danh mục **đầu vào**, **đầu ra**, **nhấn mạnh**, và **đường di chuyển**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu cần thiết để làm việc với hoạt ảnh trong không gian tên [Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/) ,
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** trong enumeration [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype). Những hiệu ứng này về cơ bản là các hiệu ứng tương đương được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides cho .NET cho phép bạn áp dụng hoạt ảnh cho văn bản trong một hình dạng. 

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) class.
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape). 
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/properties/textframe).
5. Lấy chuỗi hiệu ứng chính.
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape).
7. Đặt thuộc tính [TextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/textanimation/properties/buildtype) thành giá trị từ [BuildType Enumeration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype).
8. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã C# này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```c#
// Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Thêm AutoShape mới với văn bản
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Lấy chuỗi chính của slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Thêm hiệu ứng hoạt ảnh Fade vào shape
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hoạt ảnh văn bản shape theo các đoạn cấp độ 1
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Lưu tệp PPTX vào ổ đĩa
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](/slides/vi/net/animated-text/) riêng lẻ. Xem [**Văn bản hoạt ảnh**](/slides/vi/net/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) class.
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe) trên slide. 
5. Lấy chuỗi hiệu ứng chính.
6. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe).
8. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã C# này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```c#
// Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình.
using (Presentation pres = new Presentation())
{
    // Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của bản thuyết trình
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm picture frame vào slide
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Thêm hiệu ứng hoạt ảnh Fly từ Trái vào picture frame
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu tệp PPTX vào ổ đĩa
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) class.
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape). 
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi hiệu ứng trên hình dạng bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm lệnh di chuyển tới `UserPath`.
8. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã C# này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường bóng) cho một shape:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp bản thuyết trình.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Thêm hiệu ứng hoạt ảnh PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tạo một loại "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tạo một chuỗi hiệu ứng cho button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ chỉ được di chuyển sau khi button được nhấn.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Thêm các lệnh di chuyển vì đường dẫn đã tạo hiện đang rỗng.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Ghi tệp PPTX vào ổ đĩa
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho Shape**

Các ví dụ dưới đây cho bạn thấy cách sử dụng phương thức `GetEffectsByShape` từ giao diện [ISequence](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã được áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape trên slide bình thường**

Trước đây, bạn đã học cách thêm hiệu ứng hoạt ảnh vào các shape trong bản thuyết trình PowerPoint. Đoạn mã mẫu sau cho bạn thấy cách lấy các hiệu ứng đã áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bản thuyết trình `AnimExample_out.pptx`.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Lấy chuỗi hoạt ảnh chính của slide.
    // Lấy shape đầu tiên trên slide đầu tiên.
    // Lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm các hiệu ứng được kế thừa từ placeholder**

Nếu một shape trên slide bình thường có các placeholder nằm trên layout slide và/hoặc master slide, và các hiệu ứng hoạt ảnh đã được thêm vào những placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong quá trình trình chiếu, bao gồm cả các hiệu ứng được kế thừa từ placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** đã được áp dụng cho shape.

![Hiệu_ứng_họat_ảnh_hình_dạng_slide](slide-shape-animation.png)

Giả sử thêm hiệu ứng **Split** đã được áp dụng cho placeholder footer trên slide **layout**.

![Hiệu_ứng_họat_ảnh_hình_dạng_bố_cục](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** đã được áp dụng cho placeholder footer trên slide **master**.

![Hiệu_ứng_họat_ảnh_hình_dạng_master](master-shape-animation.png)

Đoạn mã mẫu sau cho bạn thấy cách sử dụng phương thức `GetBasePlaceholder` từ giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm cả các hiệu ứng được kế thừa từ placeholder nằm trên layout và master slide.

```cs
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
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Thay đổi các thuộc tính thời gian của hiệu ứng hoạt ảnh**

Aspose.Slides cho .NET cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Timing của Animation và menu mở rộng trong Microsoft PowerPoint:

![hình_đồ_hoạ_1](shape-animation.png)

Đây là các tương quan giữa PowerPoint Timing và các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/properties/timing):

- PowerPoint Timing **Bắt đầu** drop-down list khớp với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/triggertype). 
- PowerPoint Timing **Thời lượng** khớp với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/duration). Thời lượng của một hoạt ảnh (tính bằng giây) là tổng thời gian hoạt ảnh hoàn thành một chu kỳ. 
- PowerPoint Timing **Độ trễ** khớp với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- PowerPoint Timing **Lặp lại** drop-down list khớp với các thuộc tính này: 
  * thuộc tính [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount) mô tả *số lần* hiệu ứng được lặp lại;
  * cờ [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide) chỉ định liệu hiệu ứng có được lặp lại cho đến cuối slide hay không;
  * cờ [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick) chỉ định liệu hiệu ứng có được lặp lại cho đến lần nhấp tiếp theo hay không.
- PowerPoint Timing **Quay lại khi phát xong** checkbox khớp với thuộc tính [Effect.Timing.Rewind](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/rewind/). 

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/properties/timing) mà bạn cần. 
3. Lưu tệp PPTX đã sửa đổi.

Đoạn mã C# này minh họa thao tác:

```c#
// Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Lấy hiệu ứng đầu tiên của chuỗi chính.
    IEffect effect = sequence[0];

    // Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấp
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

    // Bật tùy chọn Rewind cho hiệu ứng
        effect.Timing.Rewind = true;
    
    // Lưu tệp PPTX vào ổ đĩa
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Âm thanh hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 
- [IEffect.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Đoạn mã C# này cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Thêm âm thanh vào bộ sưu tập âm thanh của bản thuyết trình
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Lấy chuỗi chính của slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Lấy hiệu ứng đầu tiên của chuỗi chính
	IEffect firstEffect = sequence[0];

	// Kiểm tra hiệu ứng để xem có "No Sound" không
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Thêm âm thanh cho hiệu ứng đầu tiên
		firstEffect.Sound = effectSound;
	}

	// Lấy chuỗi tương tác đầu tiên của slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Đặt cờ "Stop previous sound" cho hiệu ứng
	interactiveSequence[0].StopPreviousSound = true;

	// Ghi tệp PPTX vào ổ đĩa
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Trích xuất âm thanh của hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Lấy chuỗi hiệu ứng chính. 
4. Trích xuất [Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effect/sound/) được nhúng trong mỗi hiệu ứng hoạt ảnh. 

Đoạn mã C# này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```c#
// Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy chuỗi chính của slide.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Trích xuất âm thanh hiệu ứng dưới dạng mảng byte
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Sau khi hoạt ảnh**

Aspose.Slides cho .NET cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng After Animation của Effect và menu mở rộng trong Microsoft PowerPoint:

![hình_đồ_hoạ_1](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list khớp với các thuộc tính sau: 

- Thuộc tính [IEffect.AfterAnimationType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationtype/) mô tả kiểu After animation :
  * PowerPoint **Nhiều màu** khớp với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/).
  * PowerPoint **Không làm mờ** khớp với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) (kiểu after animation mặc định);
  * PowerPoint **Ẩn sau khi hoạt ảnh** khớp với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Ẩn khi nhấn chuột tiếp theo** khớp với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/);
- Thuộc tính [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationcolor/) định nghĩa định dạng màu sau khi hoạt ảnh. Thuộc tính này hoạt động phối hợp với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/). Nếu bạn thay đổi kiểu sang kiểu khác, màu after animation sẽ bị xóa.

Đoạn mã C# này cho bạn thấy cách thay đổi một hiệu ứng after animation:

```c#
 // Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình
 using (Presentation pres = new Presentation("AnimImage_out.pptx"))
 {
     ISlide firstSlide = pres.Slides[0];
 
     // Lấy hiệu ứng đầu tiên của chuỗi chính
     IEffect firstEffect = firstSlide.Timeline.MainSequence[0];
 
     // Thay đổi kiểu after animation thành Color
     firstEffect.AfterAnimationType = AfterAnimationType.Color;
 
     // Đặt màu dim cho after animation
     firstEffect.AfterAnimationColor.Color = Color.AliceBlue;
 
     // Ghi tệp PPTX vào ổ đĩa
     pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
 }
```

## **Hoạt ảnh Văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Hoạt ảnh văn bản* của một hiệu ứng hoạt ảnh:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) mô tả kiểu animate text của hiệu ứng. Văn bản shape có thể được hoạt ảnh:
  - Cả lúc một lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) type)
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) type)
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) đặt độ trễ giữa các phần văn bản đã hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ phần trăm thời lượng hiệu ứng. Giá trị âm chỉ độ trễ tính bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt thuộc tính [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itextanimation/buildtype/) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) để tắt chế độ hoạt ảnh *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) và [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Lưu tệp PPTX đã sửa đổi.

Đoạn mã C# này minh họa thao tác:

```c#
// Khởi tạo một lớp presentation đại diện cho tệp bản thuyết trình.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Thay đổi loại hoạt ảnh văn bản của hiệu ứng thành "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Thay đổi kiểu Animate text của hiệu ứng thành "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
    firstEffect.DelayBetweenTextParts = 20f;

    // Ghi tệp PPTX vào ổ đĩa
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Làm sao tôi có thể đảm bảo các hoạt ảnh được giữ nguyên khi xuất bản bản thuyết trình lên web?**

[Export to HTML5](/slides/vi/net/export-to-html5/) và bật các [tùy chọn](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animateshapes/) và [transition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animatetransitions/). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có thể.

**Thay đổi thứ tự z (thứ tự lớp) của các shape ảnh hưởng như thế nào đến hoạt ảnh?**

Hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/zorderposition/) quyết định phần nào phủ lên phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic tương tự.)

**Có giới hạn nào khi chuyển đổi hoạt ảnh thành video đối với một số hiệu ứng không?**

Nhìn chung, [các hoạt ảnh được hỗ trợ](/slides/vi/net/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc các hiệu ứng cụ thể có thể được render khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn sử dụng và với phiên bản thư viện.