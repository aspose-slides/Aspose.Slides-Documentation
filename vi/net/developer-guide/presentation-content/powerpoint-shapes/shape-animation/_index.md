---
title: Áp dụng hoạt ảnh hình dạng trong bản trình bày với .NET
linktitle: Hoạt ảnh hình dạng
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản hoạt ảnh với Aspose.Slides cho .NET."
---
## **Tổng quan**

Để làm việc với các hành vi riêng lẻ bên trong một hiệu ứng hoặc chỉnh sửa các đoạn đường chuyển động, xem [Tuỳ chỉnh hoạt ảnh](/slides/vi/net/custom-animation/).

Aspose.Slides for .NET đại diện cho hoạt ảnh slide dưới dạng các hiệu ứng trong một dòng thời gian slide. Một hiệu ứng có hình mục tiêu, loại và phụ loại hoạt ảnh, một bộ kích hoạt, cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau hoạt ảnh.

Dòng thời gian chứa hai loại chuỗi:

- **Chuỗi chính** phát khi slide được chuyển tiếp.
- **Chuỗi tương tác** bắt đầu khi hình kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác triển khai [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), bạn sử dụng cùng một phương thức [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) cho hầu hết nội dung slide. Các hiệu ứng khả dụng được liệt kê trong enumeration [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype/).

## **Thêm Hoạt Ảnh Cho Hình**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) với hình mục tiêu, loại hiệu ứng, phụ loại và bộ kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình khác được nhấp, tạo một chuỗi tương tác mà bộ kích hoạt là hình đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Bộ kích hoạt kiểm soát thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) chờ một cú nhấp trong chuỗi chính, hoặc một cú nhấp vào hình kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) bắt đầu khi hiệu ứng trước đó kết thúc.

Để tạo hoạt ảnh cho hình ảnh, biểu đồ, hoặc loại hình khác, truyền đối tượng đó vào [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) thay vì `targetShape`. Đối với các tùy chọn nhóm đặc thù cho biểu đồ, xem [Animated Charts](/slides/vi/net/animated-charts/).

## **Đọc Hoạt Ảnh Đối Tượng**

Sử dụng [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/geteffectsbyshape/) khi bạn biết hình mục tiêu. Để kiểm tra mọi hiệu ứng, liệt kê chuỗi chính và mọi chuỗi tương tác. Việc liệt kê tránh việc giả định một chuỗi chứa hiệu ứng ở chỉ mục `0`.

Ví dụ sau tạo một hình với các hiệu ứng chuỗi chính và chuỗi tương tác, lấy các hiệu ứng nhắm vào hình, và sau đó liệt kê mọi chuỗi trên slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Nếu bạn chỉ cần các hiệu ứng cho một hình, trước tiên xác định hình bằng tên, loại placeholder, hoặc thuộc tính ổn định khác; sau đó gọi [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/geteffectsbyshape/). Không giả định rằng [IShapeCollection.Item](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/item/) ở chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm việc với Hiệu Ứng Placeholder Kế Thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide chủ. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) trả về placeholder cha đó, hoặc `null` khi không có cha.

Trong bản trình bày ví dụ sau, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục, và **Fly In** trên slide chủ.

![Hiệu ứng hoạt ảnh chân trang trên slide bình thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide chủ](master-shape-animation.png)

Ví dụ tiếp theo tự xây dựng cấu trúc hierarchi của placeholder. Nó thêm hiệu ứng vào một placeholder chủ, một placeholder bố cục, và placeholder tương ứng trên slide bình thường. Mọi lần gọi [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) đều được kiểm tra trước khi sử dụng hình trả về.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Thay Đổi Thời Gian Hoạt Ảnh**

Hộp thoại **Timing** của PowerPoint ánh xạ tới các thuộc tính của [ITiming](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Bắt đầu** ánh xạ tới [ITiming.TriggerType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/triggertype/).
- **Thời lượng** ánh xạ tới [ITiming.Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/duration/), tính bằng giây.
- **Độ trễ** ánh xạ tới [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/triggerdelaytime/), tính bằng giây.
- **Lặp lại** ánh xạ tới [ITiming.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick/), hoặc [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Quay lại khi phát xong** ánh xạ tới [ITiming.Rewind](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/rewind/).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/), và lưu kết quả. Giữ tham chiếu [IEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/) trả về tránh việc sử dụng chỉ mục bộ sưu tập không cần thiết.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Cẩn thận sử dụng một chế độ lặp lại. Kết hợp số lần lặp với cờ “until” có thể tạo ra kết quả gây nhầm lẫn ở các trình xem khác nhau. Khi thay đổi chế độ lặp, đặt [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick/) và [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide/) trước [ITiming.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount/), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp hiện tại.

## **Thêm và Trích Xuất Âm Thanh Hoạt Ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu âm thanh nhúng thông qua [IEffect.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/stopprevioussound/) yêu cầu một hiệu ứng dừng âm thanh đã được khởi động bởi hiệu ứng trước.

### **Thêm Âm Thanh Vào Hiệu Ứng**

Ví dụ sau yêu cầu một tệp âm thanh cục bộ có tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/), vì vậy không cần chỉ mục chuỗi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Trích Xuất Âm Thanh Nhúng Của Hiệu Ứng**

Ví dụ sau yêu cầu một bản trình bày cục bộ có tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi chính và chuỗi tương tác và ghi mỗi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn từ loại MIME âm thanh được cung cấp bởi [IAudio.ContentType](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Đối với các đối tượng âm thanh lớn, sử dụng [IAudio.GetStream](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudio/getstream/) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt Hành Vi Sau Hoạt Ảnh**

Tùy chọn **After animation** (Sau hoạt ảnh) kiểm soát những gì xảy ra với một hình sau khi hiệu ứng của nó kết thúc.

![Hộp thoại tùy chọn hiệu ứng PowerPoint hiển thị cài đặt After animation](shape-after-animation.png)

Enumeration [AfterAnimationType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) hỗ trợ giữ nguyên hình không thay đổi, thay đổi màu sắc, ẩn nó sau hoạt ảnh, hoặc ẩn nó khi nhấp lần tiếp theo. Khi kiểu là [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/), cũng đặt [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationcolor/) .

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh của nó qua đối tượng hiệu ứng trả về, và lưu kết quả.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Thay đổi kiểu khỏi [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) sẽ xóa cài đặt màu sau hoạt ảnh.

## **Hoạt Ảnh Văn Bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itextanimation/buildtype/) kiểm soát việc các đoạn xuất hiện cùng nhau hay theo cấp độ đoạn.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) kiểm soát việc văn bản xuất hiện toàn bộ một lúc, theo từ, hoặc theo ký tự. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập sau hoạt ảnh các từ trong một hộp văn bản. [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) vô hiệu hoá việc xây dựng đoạn theo đoạn để cài đặt từ áp dụng cho toàn bộ khung văn bản.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Để xây dựng một hộp văn bản theo đoạn, đặt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) (hoặc cấp độ đoạn khác). Để nhắm mục tiêu một đoạn đơn với hiệu ứng riêng, sử dụng overload của [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) chấp nhận một [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/). Xem [Animated Text](/slides/vi/net/animated-text/) để biết các ví dụ mức đoạn.

## **Xuất Và Ghi Chú Tương Thích**

- Lưu thành PPT hoặc PPTX giữ nguyên mô hình hoạt ảnh, nhưng việc phát cuối cùng được điều khiển bởi trình xem bản trình bày.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/net/export-to-html5/), GIF hoạt ảnh, hoặc [video conversion](/slides/vi/net/convert-powerpoint-to-video/) khi đầu ra phải hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.AnimateShapes](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animateshapes/) và khi cần, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animatetransitions/).
- Kết xuất video hỗ trợ nhiều hiệu ứng vào, nhấn mạnh, thoát và đường chuyển động phụ trợ, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra [supported animations and effects](/slides/vi/net/convert-powerpoint-to-video/#supported-animations-and-effects) và kiểm thử các bản trình bày quan trọng với phiên bản Aspose.Slides mục tiêu.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng nhập từ các định dạng bản trình bày khác có thể được giữ trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu Hỏi Thường Gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint nhưng không trong PDF?**

PDF là định dạng tĩnh, vì vậy các hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF hoạt ảnh, hoặc video khi cần duy trì chuyển động.

**Tại sao một hiệu ứng lại phát khác nhau trong video?**

Xuất video render các hoạt ảnh thay vì lưu hành vi PowerPoint gốc. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ ước lượng. Xem bảng các hiệu ứng được hỗ trợ và kiểm thử bản trình bày thực tế trước khi sử dụng cho sản xuất.

**Việc di chuyển một hình lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh của nó không?**

Không. thứ tự z-order của hình chỉ kiểm soát chồng lên nhau, trong khi thứ tự chuỗi và bộ kích hoạt kiểm soát việc phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.