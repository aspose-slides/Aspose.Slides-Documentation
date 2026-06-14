---
title: Áp dụng Hiệu Ứng Hình Dạng trong Bài Trình Bày trên .NET
linktitle: Hiệu Ứng Hình Dạng
type: docs
weight: 30
url: /vi/net/shape-effect
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bài trình bày
- .NET
- C#
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng tiên tiến bằng Aspose.Slides cho .NET—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [fills](/slides/vi/net/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình dạng, v.v.

<img src="shape-effect.png" alt="hiệu-ứng-hình-dạng" style="zoom:50%;" />

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông đẹp hơn những kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một sự kết hợp đã được biết là đẹp mắt của hai hoặc nhiều hiệu ứng. Bằng cách này, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp tốt.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Để áp dụng hiệu ứng bóng cho một hình dạng trong Aspose.Slides cho .NET, bạn có thể dễ dàng điều chỉnh các tham số như màu sắc, bán kính làm mờ và hướng. Điều này giúp các hình dạng của bạn trông năng động và chuyên nghiệp hơn, thêm độ sâu và tiêu điểm. Bằng cách sử dụng các đoạn mã đơn giản, bạn có thể áp dụng các hiệu ứng này cho nhiều hình dạng, nâng cao sức hấp dẫn tổng thể của bản trình chiếu.

Đoạn mã C# này cho thấy cách áp dụng [outer shadow effect](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/outershadoweffect/) cho một hình chữ nhật:

```c#
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

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho .NET, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình chiếu bằng cách mang lại cho các hình dạng một diện mạo sáng bóng và tinh tế hơn. Thực hiện dễ dàng với đoạn mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều đối tượng để đạt được thiết kế nhất quán.

Đoạn mã C# này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/reflectioneffect/) cho một hình dạng:

```c#
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

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho .NET, bạn có thể thêm một hào quang mềm mại, tỏa sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố thị giác thu hút vào bản trình chiếu. Thực hiện dễ dàng với ít đoạn mã, nâng cao vẻ ngoài tổng thể của các slide.

Đoạn mã C# này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/gloweffect/) cho một hình dạng:

```c#
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

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho .NET, bạn có thể tạo ra một chuyển đổi mịn, mềm mại quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần vẻ ngoài nhẹ nhàng. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bản trình chiếu.

Đoạn mã C# này cho thấy cách áp dụng [cạnh mềm](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/softedgeeffect/) cho một hình dạng:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Câu hỏi thường gặp**

**Bạn có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo nên diện mạo năng động hơn.

**Bạn có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và các loại khác.

**Bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.