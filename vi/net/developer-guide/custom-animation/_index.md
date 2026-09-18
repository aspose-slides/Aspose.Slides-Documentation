---
title: Tạo và Chỉnh sửa Hành vi Hoạt ảnh Tùy chỉnh trong .NET
linktitle: Hoạt ảnh Tùy chỉnh
type: docs
weight: 151
url: /vi/net/custom-animation/
keywords:
- hoạt ảnh tùy chỉnh
- hành vi hoạt ảnh
- đường chuyển động
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tạo, kiểm tra và chỉnh sửa hành vi hoạt ảnh tùy chỉnh và đường chuyển động có thể chỉnh sửa trong các bản trình bày PowerPoint với Aspose.Slides cho .NET."
---
## **Tổng quan**

Các hành vi hoạt ảnh tùy chỉnh cho phép bạn kiểm soát các thao tác riêng lẻ trong một hiệu ứng hoạt ảnh, chẳng hạn như thay đổi màu, xoay hình dạng, hoặc theo một đường chuyển động có thể chỉnh sửa. Hướng dẫn này cho biết cách tạo và kết hợp các hành vi, cấu hình thời gian của chúng, kiểm tra và sửa đổi các hoạt ảnh hiện có, và xác minh rằng các thuộc tính của chúng vẫn tồn tại sau khi lưu và mở lại bản trình bày.

Đối với các hiệu ứng đã định nghĩa trước và kích hoạt bằng nhấp chuột, xem [Hoạt ảnh hình dạng](/slides/vi/net/shape-animation/).

## **Hiểu mô hình hoạt ảnh**

Một hoạt ảnh được tổ chức dưới dạng **Timeline → Sequence → Effect → Behaviors**:

- Timeline của slide chứa chuỗi chính và các chuỗi tương tác.
- ISequence chứa các hiệu ứng, có thể nhắm mục tiêu các hình dạng khác nhau.
- IEffect xác định hình dạng mục tiêu, preset, subtype và thời gian của hiệu ứng.
- IEffect.Behaviors chứa các thao tác thực hiện hiệu ứng: thay đổi màu, di chuyển, xoay, đặt thuộc tính, v.v.

## **Tạo các hành vi riêng lẻ**

Gọi [ISequence.AddEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/isequence/addeffect/) để tạo một hiệu ứng và truy cập bộ sưu tập [Behaviors](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/behaviors/) của nó. Một preset có thể tự động điền bộ sưu tập này. Giữ lại các thao tác của nó khi mở rộng preset, hoặc sử dụng [Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/clear/) khi cố ý thay thế chúng.

[IBehaviorFactory](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/) tạo ra tám loại hành vi được minh họa dưới đây. Motion được đề cập trong [Xây dựng một đường chuyển động](#build-a-motion-path). Mỗi ví dụ tạo là một chương trình hoàn chỉnh; các ví dụ chỉnh sửa sau sẽ cho biết tệp đầu ra nào được sử dụng.

### **Xoay**

Sử dụng [CreateRotationEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) để tạo một phép xoay. [By](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/irotationeffect/by/) chỉ định góc tương đối tính bằng độ; [From](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/irotationeffect/from/) và [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/irotationeffect/to/) chỉ định các điểm cuối.

Ví dụ bắt đầu với một hiệu ứng Spin, thay thế các thao tác preset của nó bằng một hành vi xoay, và đặt thời lượng cho thao tác này là hai giây. Góc tương đối 90 độ biểu thị một vòng quay phần tư từ hướng ban đầu của hình, vì vậy không cần góc khởi đầu cụ thể.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` chứa một hình và một hành vi xoay. Bộ sưu tập, thời gian và các ví dụ chỉnh sửa xoay bên dưới sử dụng tệp này.

### **Thu phóng**

Sử dụng [CreateScaleEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) với phần trăm X/Y: [From](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/iscaleeffect/from/) và [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/iscaleeffect/to/) mô tả kích thước bắt đầu và kết thúc, trong khi [By](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/iscaleeffect/by/) mô tả thay đổi tương đối. Ở đây, 100 có nghĩa là kích thước gốc.

Ví dụ tăng cả hai chiều từ 100 % lên 125 % trong hai giây. Sử dụng các phần trăm ngang và dọc bằng nhau giữ tỉ lệ hình, các phần trăm khác nhau sẽ kéo dài một chiều hơn chiều còn lại.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Màu**

Sử dụng [CreateColorEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) để thay đổi màu nền từ xanh dương sang cam. [From](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icoloreffect/from/) và [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icoloreffect/to/) là các màu; [By](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icoloreffect/by/) là độ lệch màu. [IBehavior.Properties](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehavior/properties/) xác định thuộc tính đang được hoạt ảnh.

Nền đặc của hình được khởi tạo thành màu xanh, trùng với màu bắt đầu của hoạt ảnh. Việc chọn thuộc tính màu nền cho biết hành vi sẽ thay đổi phần nào của hình; các màu đầu và cuối không xác định thuộc tính đó. Hiệu ứng đã lưu mô tả một chuyển đổi hai giây sang màu cam.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Bộ lọc**

Sử dụng [CreateFilterEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) để chọn một kiểu wip. [Type](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ifiltereffect/subtype/), và [Reveal](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ifiltereffect/reveal/) xác định bộ lọc, hướng và việc hiện hoặc ẩn hình.

Ví dụ này cấu hình một wip hai giây hiện ra hình bằng subtype hướng phải. Các cài đặt bộ lọc thuộc về hành vi bên trong hiệu ứng, vì vậy chúng được cấu hình sau khi các thao tác gốc của preset đã bị xoá.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Thuộc tính**

Sử dụng [CreatePropertyEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) để hoạt ảnh độ mờ. [From](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ipropertyeffect/to/), và [By](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ipropertyeffect/by/) là các chuỗi được diễn giải bằng [ValueType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ipropertyeffect/valuetype/) và [CalcMode](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ipropertyeffect/calcmode/). Chọn các điểm cuối hoặc độ lệch tương đối thay vì thiết lập cả ba một cách tùy tiện.

Ở đây, thuộc tính được chọn là opacity, và các chuỗi số đại diện cho sự thay đổi từ 25 % opacity lên opacity đầy đủ. Nội suy tuyến tính mô tả sự thay đổi dần dần giữa các giá trị này. Khi áp dụng ví dụ này cho thuộc tính khác, hãy chọn kiểu giá trị và các giá trị đầu/cuối phù hợp với thuộc tính đó.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Đặt**

Sử dụng [CreateSetEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) để gán khả năng hiển thị qua [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/iseteffect/to/). Hành vi set không nội suy giữa các điểm cuối.

Ví dụ chọn thuộc tính visibility và gán chuỗi `visible` khi hành vi chạy. Hình chữ nhật đã hiển thị trong bản trình bày tối thiểu này, vì vậy việc gán có thể không tạo ra thay đổi hình ảnh rõ ràng. Một thao tác như vậy hữu ích khi là một phần của hiệu ứng lớn hơn cũng kiểm soát việc ẩn hoặc hiển thị hình.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Lệnh**

Sử dụng [CreateCommandEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) và cấu hình [Type](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icommandeffect/commandstring/), và [ShapeTarget](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/icommandeffect/shapetarget/). Đặt một tệp ghi âm WAV có tên `sample.wav` trong thư mục làm việc. Ví dụ này nhúng nó bằng [AddAudioFrameEmbedded](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addaudioframeembedded/) và gắn lệnh phát vào khung âm thanh.

Khung âm thanh vừa là mục tiêu của hiệu ứng vừa là mục tiêu của lệnh. Điều này kết nối yêu cầu phát với bản ghi đã nhúng; một chuỗi lệnh một mình không xác định đối tượng media nào sẽ được điều khiển. Hiệu ứng được cấu hình để bắt đầu khi nhấp trong khi trình chiếu.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Lưu trữ lệnh trong `command.pptx`; nó không phát bản ghi. Phát lại yêu cầu một trình chiếu hỗ trợ lệnh và mục tiêu media của nó.

## **Quản lý bộ sưu tập hành vi**

[IBehaviorCollection](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/) hỗ trợ [Add](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/remove/), và [RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/removeat/). Ví dụ này mở `rotation.pptx`, thêm thu phóng, di chuyển nó trước khi xoay, và xoá xoay. Việc xoá và chèn lại cùng một đối tượng thay đổi vị trí lưu trữ mà không tạo bản sao.

Trình tự chỉnh sửa thay đổi bộ sưu tập từ rotation–scale sang scale–rotation, rồi chỉ còn scale. Các chỉ số tham chiếu bộ sưu tập hiện tại, vì vậy việc xoá sử dụng chỉ số mới của rotation sau khi sắp xếp lại. Đếm cuối cùng xác nhận hành vi nào sẽ được lưu.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Kết quả là `ScaleEffect`: chỉ còn thu phóng. Thứ tự trong bộ sưu tập không tự động lên lịch các hành vi liên tiếp nhau. Xóa bộ sưu tập chỉ khi thay thế toàn bộ các thao tác của nó.

## **Cấu hình thời gian hành vi**

[IBehavior.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehavior/timing/) cung cấp [ITiming](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/), độc lập với [IEffect.Timing](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/timing/). Thời gian hiệu ứng lên lịch cho toàn bộ hiệu ứng; thời gian hành vi mô tả một thao tác bên trong nó.

### **Đặt Thời lượng, Độ trễ, Lặp lại và Tăng tốc**

Mở `rotation.pptx` và đặt [Duration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/duration/) và [TriggerDelayTime](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/triggerdelaytime/) theo giây, sau đó cấu hình [RepeatCount](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/accelerate/) và [Decelerate](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/decelerate/) là phần của thời lượng; tổng của chúng không được vượt quá 1.

Tệp đầu vào là tệp được tạo trong ví dụ xoay, trong đó hành vi đầu tiên là một xoay. Ví dụ này chỉ thay đổi thời gian của hành vi đó; góc 90 độ vẫn giữ nguyên. Giữ góc và thời gian riêng biệt giúp điều chỉnh tốc độ mà không cần xây dựng lại hoạt ảnh.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Hành vi sử dụng thời lượng hai giây, độ trễ nửa giây, và lặp lại 3 lần. 20 % đầu và cuối thời lượng được dùng cho tăng tốc và giảm tốc.

Các chính sách lặp lại khác bao gồm [RepeatDuration](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilendslide/), và [RepeatUntilNextClick](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/repeatuntilnextclick/); chọn một chính sách thay vì bật chúng đồng thời. [AutoReverse](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/itiming/autoreverse/) phát hoạt ảnh ngược lại sau lần chạy xuôi. Tăng tốc và giảm tốc áp dụng cho các thay đổi liên tục, không phải cho các gán rời rạc hoặc lệnh.

## **Xây dựng một Đường chuyển động**

Sử dụng [CreateMotionEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) để tạo chuyển động. Các thuộc tính [From](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/to/), và [By](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/by/) mô tả tọa độ hoặc độ lệch dựa trên phần trăm. Để tạo một lộ trình có thể chỉnh sửa, tạo một [MotionPath](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motionpath/) và gán nó cho [IMotionEffect.Path](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotionpath/) lưu trữ các lệnh đường.

[MotionCommandPathType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motioncommandpathtype/) chọn thao tác:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Đặt vị trí bắt đầu. |
| LineTo | One | Di chuyển dọc theo một đoạn thẳng đến điểm cuối của nó. |
| CurveTo | Three | Theo một đường cong bậc ba được định nghĩa bởi hai điểm điều khiển và một điểm cuối. |
| CloseLoop | None | Trở về vị trí bắt đầu. |
| End | None | Kết thúc đường. |

[MotionPathPointsType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motionpathpointstype/) mô tả đặc tính chỉnh sửa điểm, chẳng hạn như điểm góc hoặc điểm mượt. Nó không thay thế kiểu lệnh. Sử dụng kiểu điểm cong cho ví dụ đường cong dưới đây, và kiểu điểm góc cho các đoạn thẳng.

Tọa độ đường được chuẩn hoá theo kích thước slide: độ dịch X 0.25 biểu thị một phần tư chiều rộng slide, không phải 0.25 điểm. Y dương chạy xuống dưới. Các lệnh tuyệt đối chỉ định vị trí trong hệ tọa độ đường; các lệnh tương đối chỉ định độ lệch từ vị trí hiện tại. Điều này tách biệt với [Origin](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/origin/), chọn khung tham chiếu của đường, và [PathEditMode](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioneffect/patheditmode/), kiểm soát cách đường di chuyển khi hình được di chuyển.

### **Tạo Đường Thẳng**

Tạo một hành vi chuyển động với điểm bắt đầu, một đoạn thẳng và lệnh end. [IMotionPath.Add](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotionpath/add/) nhận loại lệnh, các điểm, kiểu điểm và cờ tọa độ tương đối.

Lệnh bắt đầu thiết lập (0, 0), và đoạn line kết thúc tại (0.25, 0), tạo ra một dịch chuyển ngang bằng một phần tư chiều rộng slide. Lệnh end không có điểm tọa độ. Khi đường đã được gán, việc thêm hành vi chuyển động vào hiệu ứng sẽ kết nối lộ trình này với hình chữ nhật.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` chứa một hành vi chuyển động với ba lệnh đường. Các ví dụ chỉnh sửa tệp dưới đây sử dụng cấu trúc đã biết này.

### **So sánh tọa độ tuyệt đối và tương đối**

Hai đối tượng đường này mô tả cùng một lộ trình. Lệnh tuyệt đối kết thúc tại (0.3, 0.1); lệnh tương đối cộng (0.1, 0.1) vào vị trí hiện tại (0.2, 0).

Cả hai đường đều bắt đầu ở cùng vị trí. Đối với line tương đối, cộng các độ lệch X và Y vào vị trí hiện tại để có điểm cuối; đối với line tuyệt đối, đọc điểm cuối trực tiếp. Thay đổi cờ mà không chuyển đổi tọa độ sẽ tạo ra một lộ trình khác.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Gán bất kỳ đường nào cho một hành vi chuyển động để sử dụng trong bản trình bày. Đối số Boolean cuối cùng chọn tọa độ tương đối cho lệnh đó.

### **Thay thế Đường thẳng bằng Đường cong**

Mở `motion.pptx` và thay thế lệnh line bằng một đường cong bậc ba. Đầu tiên cung cấp hai điểm điều khiển, sau đó cung cấp điểm cuối.

Vị trí bắt đầu được cung cấp bởi lệnh trước đó. Hai điểm đầu tiên định hình đường cong, trong khi điểm thứ ba là điểm đích; chúng không phải là ba điểm đích liên tiếp. Cập nhật đồng thời loại lệnh, kiểu chỉnh sửa điểm và mảng điểm giữ cho đoạn phù hợp với hình học mới.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Đường trong `curve.pptx` vẫn có ba lệnh; lệnh ở giữa giờ định nghĩa một đường cong.

## **Kiểm tra và chỉnh sửa Đường đã lưu**

Mỗi [IMotionCmdPath](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioncmdpath/) cung cấp [Points](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioncmdpath/pointstype/), và [IsRelative](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotioncmdpath/isrelative/). Các ví dụ sau sử dụng đường ba lệnh đã biết trong `motion.pptx`. Đối với đầu vào tùy ý, hãy xác định hiệu ứng mong muốn và kiểm tra loại lệnh và số lượng điểm trước khi chỉnh sửa theo chỉ số.

### **Đọc Lệnh và Tọa độ**

Đọc đường mà không thay đổi. Các lệnh end và close-loop không cần điểm, vì vậy cho phép một mảng điểm null.

Kết quả ghép mỗi lệnh với cờ tọa độ tương đối trước khi liệt kê các điểm. Điều này cho phép bạn phân biệt một điểm cuối với một độ lệch trước khi sửa đổi đường. Một curve sẽ liệt kê ba điểm, trong khi line thẳng trong tệp này chỉ liệt kê một điểm.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Danh sách chứa một điểm bắt đầu, một line tuyệt đối kết thúc tại (0.25, 0), và một lệnh end.

### **Thay đổi Điểm cuối**

Mở `motion.pptx` và thay thế mảng điểm của line để di chuyển điểm cuối của nó.

Trong tệp đầu vào, chỉ số 0 là lệnh bắt đầu và chỉ số 1 là line. Thay thế điểm duy nhất của line thay đổi đích mà không thay đổi loại lệnh, thời gian hoặc vị trí trong bộ sưu tập. Vì lệnh sử dụng tọa độ tuyệt đối, cặp mới chỉ định một vị trí chứ không phải một độ lệch cộng thêm.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

Line trong `motion-endpoint.pptx` kết thúc tại (0.4, 0.1); tệp gốc không thay đổi.

### **Thay thế một Đoạn**

Sử dụng [Insert](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotionpath/insert/) và [RemoveAt](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/imotionpath/removeat/) để thay thế line trong `motion.pptx`. Việc chèn dịch chuyển line cũ sang chỉ số 2.

Điều này minh họa việc thay thế một đối tượng lệnh thay vì chỉnh sửa tọa độ hiện có. Sau khi chèn, bộ sưu tập tạm thời chứa lệnh bắt đầu, line mới, line cũ và lệnh end. Việc xoá chỉ số 2 loại bỏ line cũ và để lại lộ trình mới.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Đường đã lưu vẫn có ba lệnh, với line mới kết thúc tại (0.2, 0.1) và lệnh end ở cuối.

## **Sửa đổi và Xác minh một Hành vi hiện có**

Khi không biết chỉ số của hành vi, hãy chọn nó theo loại. Ví dụ này mở `rotation.pptx`, tìm [IRotationEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/irotationeffect/), thay đổi góc, và kiểm tra giá trị đã lưu sau khi mở lại.

Kiểm tra kiểu cho phép vòng lặp bỏ qua các hành vi không phải xoay. Lần tải thứ hai đọc tệp đã lưu vào một đối tượng trình chiếu riêng, vì vậy so sánh kiểm tra dữ liệu đã lưu thay vì giá trị còn trong bộ nhớ. Ví dụ này vẫn giả định hiệu ứng đã biết là đầu tiên trong chuỗi chính; việc chọn hành vi theo loại không xác định đúng hiệu ứng trong một bản trình bày bất kỳ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Kết quả là `Rotation preserved: True`. Áp dụng cùng một mẫu kiểm tra kiểu cho các hành vi khác. Để kiểm tra bảo tồn đầy đủ, so sánh hình mục tiêu, hiệu ứng, loại và thứ tự hành vi, thời gian, và các lệnh đường. Sử dụng độ sai số số cho các giá trị dấu chấm động. Đối với bản trình bày có bố cục hoạt ảnh không xác định, xem [Read Shape Animations](/slides/vi/net/shape-animation/#read-shape-animations) để duyệt chuỗi chính và chuỗi tương tác.

## **Thứ tự Hành vi, Preset và Phát lại**

Thứ tự trong [IBehaviorCollection](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehaviorcollection/) là thứ tự lưu trữ các thao tác của một hiệu ứng. Nó không phải là một danh sách phát mà mỗi hành vi tự động chờ hành vi trước. Thời gian và hiệu ứng bao quanh quyết định lịch trình. Các hành vi có thể chồng lên nhau, và các thao tác trên cùng một thuộc tính có thể tương tác thông qua [Additive](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehavior/additive/) và [Accumulate](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ibehavior/accumulate/). Không nên chỉ dùng việc sắp xếp lại bộ sưu tập để lên lịch “di chuyển, rồi xoay”; hãy dùng thời gian rõ ràng hoặc các hiệu ứng riêng như đã mô tả trong [Shape Animation](/slides/vi/net/shape-animation/).

[Type](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/type/) và [Subtype](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/ieffect/subtype/) của hiệu ứng mô tả preset. Chúng không phải là mô tả đầy đủ của cây hành vi đã chỉnh sửa. Chọn preset và subtype trước khi tùy chỉnh hành vi: thay đổi preset có thể xây dựng lại bộ sưu tập và xóa các thao tác tùy chỉnh của bạn. Ví dụ, thay đổi một hiệu ứng Spin đã tùy chỉnh thành Fade có thể thay thế hành vi xoay bằng các hành vi set và filter. Kiểm tra lại bộ sưu tập sau khi thay đổi preset hoặc subtype. Xóa các hành vi preset cũng có thể loại bỏ các thao tác hiển thị hoặc khởi tạo mà preset cần. Các ví dụ cố ý sử dụng các hình có thể nhìn thấy và thay thế các hành vi; chúng không tái tạo toàn bộ việc triển khai mỗi preset.

## **Tương thích Định dạng**

Một cây hành vi được bảo tồn không đảm bảo việc phát lại giống hệt trong mọi trình xem hoặc bộ xuất. Kiểm tra dữ liệu đã lưu và đầu ra được render riêng biệt.

| Định dạng hoặc đầu ra | Cần xác minh |
| --- | --- |
| PPTX | Sử dụng làm định dạng chính cho các ví dụ này. Mở lại để xác minh cây hành vi có thể chỉnh sửa, sau đó kiểm tra phát lại trong phiên bản PowerPoint dự kiến. |
| PPT | Định dạng nhị phân legacy có thể khác với PPTX. Thực hiện một chu kỳ lưu‑mở‑phát lại riêng và kiểm tra; không suy ra hỗ trợ cho mọi kết hợp tùy chỉnh chỉ dựa vào kết quả PPTX thành công. |
| PDF, PNG, JPEG và các ảnh tĩnh slide khác | Chứa đại diện tĩnh của slide, không phải một dòng thời gian hành vi có thể phát hoặc khung cuối hoạt ảnh được đảm bảo. |
| [HTML5](/slides/vi/net/export-to-html5/) | Có thể phát các hoạt ảnh được hỗ trợ khi bật hoạt ảnh hình dạng trong tùy chọn xuất. Kiểm tra các kết hợp tùy chỉnh trong trình duyệt. |
| [Animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/) | Lưu các khung đã render, không phải các hành vi có thể chỉnh sửa hoặc tương tác bằng click. Kiểm tra chuyển động thực tế đã render. |
| [Video](/slides/vi/net/convert-powerpoint-to-video/) | Render các khung hoạt ảnh và mã hoá thành video. Hỗ trợ bị giới hạn bởi [các hoạt ảnh và hiệu ứng được hỗ trợ](/slides/vi/net/convert-powerpoint-to-video/#supported-animations-and-effects) của bộ render; lệnh và sự kiện tương tác không trở thành một dòng thời gian có thể chỉnh sửa. |

## **FAQ**

**Tại sao hiệu ứng của tôi lại chứa các hành vi trước khi tôi thêm bất kỳ hành vi nào?**

Việc tạo một hiệu ứng đã định nghĩa trước có thể tạo ra các thao tác nền tảng của nó. Kiểm tra chúng trước khi quyết định mở rộng preset hoặc thay thế các hành vi.

**Việc di chuyển một hành vi lên đầu có làm nó chạy trước không?**

Không nhất thiết. Thứ tự trong bộ sưu tập không thay thế cho thời gian. Kiểm tra độ trễ, thời lượng và tương tác giữa các thao tác trên cùng một thuộc tính.

**Tại sao lệnh end không có điểm nào?**

Nó đánh dấu kết thúc của đường và không cần tọa độ. Khi kiểm tra một đường đọc từ tệp, hãy kiểm tra mảng điểm null.

**Liệu một vòng quay thành công có đủ để xác nhận việc phát lại không?**

Không. Mở lại chỉ xác nhận việc bảo tồn các thuộc tính bạn đã kiểm tra. Cần thử trình chiếu hoặc xuất hoạt ảnh riêng biệt để xác nhận hành vi trực quan.