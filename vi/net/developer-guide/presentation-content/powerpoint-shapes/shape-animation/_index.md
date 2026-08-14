---
title: Áp dụng hoạt ảnh hình dạng trong bản trình chiếu bằng .NET
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản hoạt ảnh bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Aspose.Slides for .NET biểu diễn các hoạt ảnh slide dưới dạng hiệu ứng trong một dòng thời gian slide. Mỗi hiệu ứng có hình dạng mục tiêu, loại và phụ hiệu ứng, bộ kích hoạt, các thiết lập thời gian và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau hoạt ảnh.

Dòng thời gian chứa hai loại chuỗi:

- **chuỗi chính** phát khi slide được chuyển sang.
- **chuỗi tương tác** bắt đầu khi hình dạng kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác đều triển khai [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), bạn sử dụng cùng một phương thức [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) cho hầu hết nội dung slide. Các hiệu ứng có sẵn được liệt kê trong enum [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype/).

## **Thêm hoạt ảnh cho hình dạng**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) với hình dạng mục tiêu, loại hiệu ứng, phụ hiệu ứng và bộ kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một chuỗi tương tác có bộ kích hoạt là hình dạng đó.

Ví dụ dưới đây tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

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

Bộ kích hoạt quyết định thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) chờ một cú nhấp trong chuỗi chính, hoặc một cú nhấp vào hình dạng kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype/) bắt đầu khi hiệu ứng trước đó kết thúc.

Để hoạt ảnh một hình ảnh, biểu đồ hoặc một loại hình dạng khác, truyền đối tượng đó vào [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) thay vì `targetShape`. Đối với các tùy chọn nhóm riêng cho biểu đồ, xem mục [Animated Charts](/slides/vi/net/animated-charts/).

## **Đọc hoạt ảnh của hình dạng**

Sử dụng [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/geteffectsbyshape/) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, duyệt qua chuỗi chính và mọi chuỗi tương tác. Việc duyệt tránh việc giả định rằng một chuỗi có hiệu ứng ở chỉ mục `0`.

Ví dụ dưới đây tạo một hình dạng với hiệu ứng chuỗi‑chính và chuỗi‑tương tác, lấy các hiệu ứng nhắm vào hình dạng đó, rồi duyệt mọi chuỗi trên slide.

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

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước tiên xác định hình dạng bằng tên, kiểu trình giữ chỗ hoặc thuộc tính ổn định khác; sau đó gọi [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/geteffectsbyshape/). Đừng giả định rằng [IShapeCollection.Item](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/item/) ở chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm việc với hiệu ứng trình giữ chỗ kế thừa**

Một trình giữ chỗ trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ trình giữ chỗ tương ứng trên slide bố cục và slide chủ. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) trả về trình giữ chỗ cha đó, hoặc `null` nếu không có cha.

Trong bản trình bày mẫu dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục và **Fly In** trên slide chủ.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Ví dụ tiếp theo xây dựng cấu trúc trình giữ chỗ. Nó thêm hiệu ứng vào một trình giữ chỗ chủ, một trình giữ chỗ bố cục và trình giữ chỗ tương ứng trên slide bình thường. Mọi lần gọi [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) đều được kiểm tra trước khi sử dụng hình dạng trả về.

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

## **Thay đổi thời gian hoạt ảnh**

Hộp thoại PowerPoint **Timing** ánh xạ tới các thuộc tính của [ITiming](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** ánh xạ tới [ITiming.TriggerType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** ánh xạ tới [ITiming.Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/duration/), tính bằng giây.
- **Delay** ánh xạ tới [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/triggerdelaytime/), tính bằng giây.
- **Repeat** ánh xạ tới [ITiming.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick/), hoặc [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** ánh xạ tới [ITiming.Rewind](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/rewind/).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó qua đối tượng trả về bởi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/), và lưu kết quả. Giữ tham chiếu tới [IEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/) trả về giúp tránh việc truy cập không cần thiết vào chỉ mục bộ sưu tập.

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

Sử dụng một chế độ lặp duy nhất. Kết hợp số lần lặp với cờ “until” có thể tạo ra kết quả gây nhầm lẫn trên các trình xem khác nhau. Khi thay đổi chế độ lặp, đặt [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick/) và [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide/) trước [ITiming.RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount/), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp đang hoạt động.

## **Thêm và Trích xuất Âm thanh cho hoạt ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu âm thanh nhúng qua [IEffect.Sound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/stopprevioussound/) yêu cầu hiệu ứng dừng âm thanh đã được khởi chạy bởi một hiệu ứng trước đó.

### **Thêm âm thanh vào một hiệu ứng**

Ví dụ dưới đây yêu cầu một tệp âm thanh cục bộ tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai dừng âm thanh. Các đối tượng được sử dụng là kết quả trả về từ [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/), vì vậy không cần chỉ mục chuỗi.

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

### **Trích xuất âm thanh hiệu ứng đã nhúng**

Ví dụ dưới đây yêu cầu một bản trình bày cục bộ tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi chính và chuỗi tương tác và ghi mọi âm thanh hiệu ứng đã nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn dựa trên kiểu MIME âm thanh được cung cấp bởi [IAudio.ContentType](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudio/contenttype/).

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

Đối với các đối tượng âm thanh lớn, sử dụng [IAudio.GetStream](https://reference.aspose.com/slides/vi/net/aspose.slides/iaudio/getstream/) và sao chép luồng tới tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt hành vi sau hoạt ảnh**

Tùy chọn **After animation** điều khiển điều gì xảy ra với hình dạng sau khi hiệu ứng của nó kết thúc.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

Enum [AfterAnimationType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) hỗ trợ để hình dạng giữ nguyên, thay đổi màu, ẩn sau hoạt ảnh, hoặc ẩn ở lần nhấp tiếp theo. Khi kiểu là [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/), cũng cần đặt [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh qua đối tượng hiệu ứng trả về, và lưu kết quả.

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

Thay đổi kiểu khỏi [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/afteranimationtype/) sẽ xóa thiết lập màu sau hoạt ảnh.

## **Hoạt ảnh văn bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itextanimation/buildtype/) quyết định các đoạn văn xuất hiện đồng thời hay theo mức độ đoạn.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/animatetexttype/) quyết định văn bản xuất hiện một lúc, theo từ hoặc theo ký tự. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập dưới đây hoạt ảnh các từ trong một hộp văn bản. [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) tắt chế độ xây dựng đoạn‑đoạn, vì vậy thiết lập từ sẽ áp dụng cho toàn bộ khung văn bản.

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

Để xây dựng hộp văn bản theo đoạn, đặt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/buildtype/) (hoặc mức đoạn khác). Để nhắm mục tiêu một đoạn riêng biệt với hiệu ứng riêng, sử dụng phiên bản overload của [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) chấp nhận một [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/). Xem mục [Animated Text](/slides/vi/net/animated-text/) để biết các ví dụ cấp đoạn.

## **Xuất và lưu ý về khả năng tương thích**

- Lưu dưới dạng PPT hoặc PPTX bảo toàn mô hình hoạt ảnh, nhưng việc phát lại cuối cùng do trình xem bản trình bày điều khiển.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/net/export-to-html5/), GIF hoạt ảnh, hoặc [video conversion](/slides/vi/net/convert-powerpoint-to-video/) khi đầu ra cần hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.AnimateShapes](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animateshapes/) và khi cần, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/html5options/animatetransitions/).
- Kết xuất video hỗ trợ nhiều hiệu ứng nhập cảnh, nhấn mạnh, thoát và đường chuyển động phổ biến, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra bảng [supported animations and effects](/slides/vi/net/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình bày quan trọng với phiên bản Aspose.Slides bạn dùng.
- Các hiệu ứng tùy chỉnh nâng cao và những hiệu ứng được nhập từ các định dạng bản trình bày khác có thể được lưu trong tệp nhưng sẽ hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Hãy xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu hỏi thường gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint mà không xuất hiện trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển tiếp slide không được phát. Xuất sang HTML5, GIF hoạt ảnh hoặc video khi cần bảo toàn chuyển động.

**Tại sao một hiệu ứng lại phát khác nhau trong video?**

Xuất video diễn giải hoạt ảnh thay vì lưu nguyên hành vi PowerPoint. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được ước tính. Xem bảng hiệu ứng được hỗ trợ và kiểm tra bản trình bày thực tế trước khi đưa vào sản xuất.

**Việc di chuyển một hình dạng lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh không?**

Không. Thứ tự z‑order của hình dạng chỉ kiểm soát sự chồng lên nhau, trong khi thứ tự chuỗi và bộ kích hoạt quyết định thứ tự phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần thứ tự phát khác.