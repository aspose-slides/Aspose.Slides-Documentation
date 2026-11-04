---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu bằng .NET
linktitle: Hiệu ứng Hình dạng
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
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho .NET—tạo các slide ấn tượng, chuyên nghiệp trong tích tắc."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được dùng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/net/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số sự kết hợp của các hiệu ứng trông đẹp hơn những sự kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một sự kết hợp đã được biết tới là đẹp mắt của hai hoặc nhiều hiệu ứng. Bằng cách chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính mờ để phù hợp với thiết kế của bài thuyết trình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính mờ để phù hợp với ánh sáng và phong cách của mẫu.

Đoạn mã C# này cho thấy cách áp dụng [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) cho một hình chữ nhật:

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

Khi tái tạo phong cách hình ảnh của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng điều khiển một vẻ ngoài chìm. Bóng ngoài mở rộng ra ngoài hình và làm cho nó trông nổi, trong khi bóng trong làm tối các cạnh bên trong.

Gọi [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), sau đó cấu hình [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Giá trị lớn hơn tạo ra các cạnh mềm hơn.

Đoạn mã C# này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX:

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

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides for .NET, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bài thuyết trình bằng cách mang lại cho các hình dạng một diện mạo hoàn thiện và tinh tế hơn. Nó dễ thực hiện với đoạn mã đơn giản, cho phép áp dụng nhanh trên nhiều phần tử để đạt thiết kế nhất quán.

Đoạn mã C# này cho thấy cách áp dụng [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) cho một hình dạng:

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

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for .NET, bạn có thể thêm một hào quang nhẹ, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm yếu tố hình ảnh hấp dẫn, thu hút ánh nhìn vào bài thuyết trình của bạn. Nó dễ triển khai với ít đoạn mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã C# này cho thấy cách áp dụng [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) cho một hình dạng:

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

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for .NET, bạn có thể tạo một chuyển tiếp mịn, mờ xung quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng, thích hợp cho các thiết kế cần một diện mạo mềm mại hơn. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bài thuyết trình.

Đoạn mã C# này cho thấy cách áp dụng [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) cho một hình dạng:

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

Sử dụng làm mờ hình dạng để làm mềm màu nền và đường viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên giao diện.

Cài đặt [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) kiểm soát giới hạn hiển thị của hiệu ứng. Khi đặt `false`, hiệu ứng mờ sẽ bị cắt theo giới hạn vẽ gốc, bao gồm cả đường viền. Khi đặt `true`, hiệu ứng mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một màu nền, đường viền và kích thước hình dạng trong suốt quá trình. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow bị tắt và bật](shape_blur_comparison.png)

Đoạn mã C# này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng mờ 5 điểm, sau đó cập nhật lên mờ 15 điểm bằng cách gọi lại [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Nó lưu cả hai trạng thái bị mờ, sau đó gọi [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) và lưu hình dạng mà không có mờ.

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

Làm mờ hình dạng ảnh hưởng đến cả màu nền và đường viền cùng nhau. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành hình ảnh.

## **CÂU HỎI THƯỜNG GẶP**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo năng động hơn.

**Các loại hình dạng nào có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho các hình dạng khác nhau, bao gồm các hình dạng tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.