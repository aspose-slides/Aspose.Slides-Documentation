---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng .NET
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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho .NET—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Introduction**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/net/shape-formatting/#gradient-fill) hoặc viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan truyền ánh hào quang của hình dạng, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số tổ hợp hiệu ứng trông đẹp hơn những tổ hợp khác. Vì lý do này, PowerPoint có các tùy chọn trong **Preset**. Các tùy chọn Preset về cơ bản là một tổ hợp đã được biết là đẹp mắt của hai hoặc nhiều hiệu ứng. Như vậy, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho .NET hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế của bài thuyết trình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

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

![Shadow effect](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng trực quan của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một diện mạo lùi vào. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong làm tối phần bên trong các cạnh của nó.

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho .NET, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ cho bài thuyết trình của bạn bằng cách mang lại cho các hình dạng một vẻ ngoài mịn màng và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để có thiết kế nhất quán.

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

![Reflection effect](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho .NET, bạn có thể thêm một hào quang mềm mại, phát sáng xung quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố hình ảnh hấp dẫn, thu hút ánh nhìn vào bài thuyết trình của bạn. Nó dễ thực hiện với ít mã, nâng cao vẻ ngoài tổng thể của các slide.

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

![Glow effect](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho .NET, bạn có thể tạo một chuyển đổi mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này mang lại một vẻ ngoài tinh tế và nhẹ nhàng hơn, hoàn hảo cho các thiết kế cần một diện mạo nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bài thuyết trình của mình.

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

![Soft edges effect](soft_edges_effect.png)

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Bạn có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng đã nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng đã nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.