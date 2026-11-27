---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng .NET
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/net/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho .NET—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/net/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng ánh hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số tổ hợp hiệu ứng trông tốt hơn các tổ hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một tổ hợp đã biết đẹp mắt của hai hoặc nhiều hiệu ứng. Bằng cách này, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một tổ hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Aspose.Slides for .NET hỗ trợ bóng đổ ngoài và bên trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bài thuyết trình của bạn.

### **Áp dụng bóng đổ ngoài**

Sử dụng bóng đổ ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật so với nền slide. Bóng đổ mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

Mã C# này cho thấy cách áp dụng [hiệu ứng bóng đổ bên ngoài](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) cho một hình chữ nhật:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Hiệu ứng bóng đổ](shadow_effect.png)

#### **Kiểm soát hướng bóng khi hình dạng quay**

Mặc định, [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) là `true`, vì vậy bóng sẽ quay cùng hình dạng. Để các hình dạng với các góc quay khác nhau trông như được chiếu sáng từ cùng một hướng, đặt thuộc tính này thành `false` và cấp cho bóng của chúng cùng một [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

Ví dụ tạo hai mũi tên với bóng xám lệch sang phải (`Direction = 0`). Sau đó sao chép slide và quay cả hai mũi tên 90° theo chiều kim đồng hồ.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

Trong slide thứ hai, mũi tên bên trái bỏ bóng xuống dưới, trong khi mũi tên bên phải vẫn bỏ bóng sang phải. Hướng đã cấu hình vẫn là 0° cho cả hai bóng.

![Kết xuất PowerPoint trước và sau khi quay 90°. Cả hai bóng bắt đầu ở phía bên phải. Sau khi quay, bóng chuyển xuống dưới mũi tên bên trái và vẫn ở bên phải mũi tên bên phải.](arrow-shadow-rotation.png)

### **Áp dụng bóng đổ bên trong**

Khi tái tạo kiểu dáng trực quan của mẫu, sử dụng bóng đổ bên trong để tạo cảm giác khối hoặc bảng điều khiển chìm vào. Bóng đổ ngoài mở rộng ra ngoài hình dạng và làm cho nó trông như nổi lên, trong khi bóng đổ bên trong làm tối bên trong các cạnh của nó.

Gọi [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), sau đó cấu hình [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Giá trị lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ C# này tạo một thẻ màu xanh nhạt với bóng đổ bên trong màu xám đậm và lưu dưới dạng tệp PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Hình chữ nhật màu xanh nhạt với bóng đổ bên trong](inner_shadow_effect.png)

Để xóa bóng đổ bên trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và xóa một Preset Shadow**

Gọi [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) và đặt [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) thành một [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) có tên. Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) để xóa bóng mà vẫn giữ lại màu nền và viền.

Ví dụ này giữ một bản sao của hình chữ nhật ở mỗi giai đoạn. Cả hai bóng đều lệch 10 điểm. Hướng 225° đặt bóng đầu tiên lên trên và sang trái của hình chữ nhật, và 45° đặt bóng thứ hai xuống dưới và sang phải.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Gốc | Bộ preset đầu tiên | Bộ preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng đổ góc trên trái](preset_shadow_top_left.png) | ![Bóng đổ góc dưới phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides for .NET, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bài thuyết trình bằng cách tạo cho các hình dạng một vẻ ngoài tinh tế và chuyên nghiệp hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để có thiết kế nhất quán.

Mã C# này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) cho một hình dạng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for .NET, bạn có thể thêm một hào quang mềm mại, phát sáng xung quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm yếu tố trực quan hấp dẫn cho bài thuyết trình của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Mã C# này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) cho một hình dạng:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for .NET, bạn có thể tạo một chuyển đổi mịn, mờ quanh các cạnh của hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng, phù hợp cho các thiết kế cần độ mềm mại nhẹ nhàng. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bài thuyết trình.

Mã C# này cho thấy cách áp dụng [cạnh mềm](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) cho một hình dạng:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm màu nền và viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo độ mờ mạnh hơn. Bán kính bằng không sẽ không thay đổi ngoại hình.

Cài đặt [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) kiểm soát giới hạn hiển thị của hiệu ứng. Với `false`, độ mờ bị cắt theo giới hạn vẽ ban đầu, bao gồm cả viền. Với `true`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình dạng.

Bảng so sánh dưới đây sử dụng cùng màu nền, viền và kích thước hình dạng trong toàn bộ quá trình. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow bị tắt và bật](shape_blur_comparison.png)

Ví dụ C# này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) lần nữa. Nó lưu cả hai trạng thái mờ, rồi gọi [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) và lưu hình dạng không có độ mờ.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Làm mờ hình dạng ảnh hưởng đến cả màu nền và viền cùng lúc. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành hình ảnh.

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra giao diện năng động hơn.

**Những loại hình dạng nào có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.