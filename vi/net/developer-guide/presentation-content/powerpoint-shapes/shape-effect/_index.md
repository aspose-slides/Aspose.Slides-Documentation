---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu với .NET
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/net/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho .NET — tạo các slide ấn tượng, chuyên nghiệp trong tích tắc."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/net/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng ánh sáng hào quang của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số tổ hợp hiệu ứng trông đẹp hơn các tổ hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một tổ hợp đã được biết là đẹp gồm hai hoặc nhiều hiệu ứng. Nhờ đó, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình chiếu của bạn.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Mã C# này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) cho một hình chữ nhật:

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

![Hiệu ứng bóng](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng hình ảnh của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lùi vào. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong làm tối phần bên trong các cạnh của nó.

Gọi [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), sau đó cấu hình [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Giá trị lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ C# này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX:

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

![Hình chữ nhật xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và loại bỏ bóng Preset**

Gọi [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) và đặt [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) thành một [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) có tên. Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) để xóa bóng trong khi vẫn giữ nguyên đổ màu và đường viền.

Ví dụ này giữ một bản sao của hình chữ nhật ở mỗi giai đoạn. Cả hai bóng đều được dịch chuyển 10 điểm. Hướng 225° đặt bóng đầu tiên lên trên và bên trái của hình chữ nhật, và 45° đặt bóng thứ hai bên dưới và bên phải.

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

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng Đổ Trên Trái](preset_shadow_top_left.png) | ![Bóng Đổ Dưới Phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides cho .NET, bạn có thể thêm một phản chiếu giống như gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một vẻ ngoài bóng bẩy và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh trên nhiều yếu tố để có thiết kế nhất quán.

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

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho .NET, bạn có thể thêm một hào quang mềm mại, phát sáng xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố thị giác hấp dẫn, thu hút mắt vào bản trình chiếu của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể vẻ ngoài của các slide.

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

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho .NET, bạn có thể tạo một chuyển đổi mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng hơn, hoàn hảo cho các thiết kế cần một diện mạo mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình chiếu.

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

Sử dụng làm mờ hình dạng để làm mềm đổ màu và đường viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không sẽ không thay đổi giao diện.

Cài đặt [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `false`, hiệu ứng mờ được cắt theo giới hạn đã vẽ ban đầu, bao gồm cả đường viền. Khi `true`, hiệu ứng mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một đổ màu, đường viền và kích thước hình dạng trong suốt quá trình. Hàng trên sử dụng `grow = false`; hàng dưới sử dụng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với Grow bị tắt và bật](shape_blur_comparison.png)

Ví dụ C# này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng mờ 5 điểm, sau đó cập nhật lên mờ 15 điểm bằng cách gọi lại [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) và lưu hình dạng mà không có mờ.

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

Làm mờ hình dạng ảnh hưởng tới cả đổ màu và đường viền cùng nhau. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi bóng mờ chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng vào cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.