---
title: Tạo và Áp dụng hiệu ứng WordArt trong .NET
linktitle: WordArt
type: docs
weight: 110
url: /vi/net/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng
- hiệu ứng hiển thị
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh hiệu ứng WordArt trong Aspose.Slides cho .NET. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản chuyên nghiệp trong C#."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn thêm văn bản có kiểu dáng hấp dẫn, được thiết kế đặc biệt vào các bản thuyết trình PowerPoint. Với Aspose.Slides for .NET, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình giống như trong Microsoft PowerPoint — mà không cần cài đặt Office. Bài viết này cung cấp tổng quan về cách làm việc với WordArt trong .NET, bao gồm cách áp dụng các biến đổi văn bản, kiểu tô màu, viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bản trình chiếu của bạn trở nên sống động và hấp dẫn hơn. WordArt cho phép bạn xem văn bản như một đối tượng đồ họa. Nó bao gồm các hiệu ứng hoặc sửa đổi đặc biệt được áp dụng lên văn bản để làm cho nó bắt mắt hoặc nổi bật hơn.

## **Tạo mẫu WordArt đơn giản và áp dụng nó cho văn bản**

Trong phần này, chúng ta sẽ khám phá cách tạo một mẫu WordArt đơn giản và áp dụng nó cho văn bản bằng Aspose.Slides for .NET. WordArt cung cấp một cách dễ dàng để nâng cao giao diện văn bản với các hiệu ứng và kiểu dáng trực quan. Bằng cách học các bước cơ bản để tạo và sử dụng WordArt, bạn có thể nhanh chóng áp dụng các kỹ thuật này cho bất kỳ dự án nào, làm cho bản thuyết trình của bạn sinh động và đáng nhớ hơn.

Đầu tiên, chúng ta tạo văn bản đơn giản bằng đoạn mã C# sau:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Bây giờ, chúng ta đặt chiều cao phông chữ của văn bản lên giá trị lớn hơn để làm cho hiệu ứng nổi bật hơn bằng đoạn mã sau:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

Ở đây, chúng ta áp dụng màu tô hoa văn SmallGrid cho văn bản và thêm một đường viền đen độ rộng 1 bằng đoạn mã sau:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

Văn bản kết quả:

![Mẫu WordArt đơn giản](WordArt_template.png)

## **Áp dụng các hiệu ứng WordArt khác**

Ngoài các biến đổi cơ bản, Aspose.Slides for .NET cho phép bạn áp dụng nhiều hiệu ứng WordArt nâng cao để cải thiện ngoại hình của văn bản. Những hiệu ứng này bao gồm viền, tô màu, bóng đổ, phản chiếu và phát sáng. Bằng cách kết hợp các tính năng này, bạn có thể tạo ra các kiểu văn bản thu hút ánh nhìn và nổi bật trong bản thuyết trình. Phần này minh họa cách áp dụng các hiệu ứng này một cách lập trình bằng các ví dụ mã ngắn gọn, sạch sẽ.

### **Áp dụng hiệu ứng bóng ngoài**

Hiệu ứng bóng ngoài giúp văn bản nổi bật hơn bằng cách thêm một bóng đằng sau viền, tạo cảm giác chiều sâu và tách rời khỏi nền. Aspose.Slides for .NET cho phép bạn dễ dàng áp dụng và tùy chỉnh bóng ngoài cho văn bản WordArt. Trong phần này, bạn sẽ học cách đặt màu bóng, hướng, khoảng cách, bán kính mờ và các thông số khác để đạt được tác động hình ảnh mong muốn.

Đoạn mã C# sau áp dụng hiệu ứng bóng cho văn bản đã tạo ở trên.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

Văn bản kết quả:

![Hiệu ứng bóng ngoài](outer_shadow_effect.png)

{{% alert color="info" %}} 

- Khi OuterShadow và PresetShadow được sử dụng cùng nhau, chỉ có hiệu ứng OuterShadow được áp dụng.
- Nếu OuterShadow và InnerShadow được sử dụng đồng thời, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi, trong khi trong PowerPoint 2007, chỉ có hiệu ứng OuterShadow được áp dụng.

{{% /alert %}}

### **Áp dụng hiệu ứng phản chiếu**

Trong phần này, chúng ta sẽ khám phá cách áp dụng hiệu ứng phản chiếu trong các slide bằng Aspose.Slides for .NET. Hiệu ứng phản chiếu có thể là cách hiệu quả để mang lại cho văn bản hoặc hình dạng một phong cách hiện đại, giúp các yếu tố quan trọng nổi bật và tạo chiều sâu cho bản thuyết trình. Bằng cách hiểu quy trình áp dụng và tùy chỉnh các hiệu ứng này, bạn có thể dễ dàng điều chỉnh chúng để phù hợp với nhu cầu thiết kế và yêu cầu thương hiệu của mình.

Thêm hiệu ứng phản chiếu cho văn bản bằng ví dụ mã C# sau:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableReflectionEffect();
    portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
    portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
    portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
}
```

Văn bản kết quả:

![Hiệu ứng phản chiếu](reflection_effect.png)

### **Áp dụng hiệu ứng phát sáng**

Trong phần này, chúng ta sẽ khám phá cách áp dụng hiệu ứng phát sáng cho văn bản bằng Aspose.Slides for .NET. Hiệu ứng phát sáng có thể làm cho văn bản của bạn nổi bật với một đường viền sáng, tăng sức hấp dẫn trực quan cho các slide. Bằng cách điều chỉnh các thiết lập như màu sắc và độ mạnh, bạn có thể dễ dàng tùy chỉnh phát sáng để phù hợp với thiết kế và nhu cầu thương hiệu, đảm bảo các điểm chính trong bản thuyết trình thu hút sự chú ý của khán giả.

Áp dụng hiệu ứng phát sáng cho văn bản để làm nó tỏa sáng hoặc nổi bật bằng đoạn mã sau:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

Văn bản kết quả:

![Hiệu ứng phát sáng](glow_effect.png)

### **Áp dụng các biến đổi WordArt**

Trong phần này, chúng ta sẽ khám phá cách sử dụng các biến đổi trong WordArt với Aspose.Slides for .NET. Các biến đổi cho phép bạn uốn cong, kéo dài hoặc biến dạng văn bản, tạo ra những hiệu ứng độc đáo và ấn tượng. Bằng cách nắm vững các kỹ thuật này, bạn có thể dễ dàng tùy chỉnh hình dạng và kiểu dáng văn bản để phù hợp với thương hiệu hoặc tầm nhìn sáng tạo của mình, đảm bảo một bản thuyết trình hấp dẫn và chuyên nghiệp.

Sử dụng thuộc tính `Transform` (áp dụng cho toàn bộ khối văn bản) bằng đoạn mã sau:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

Văn bản kết quả:

![Biến đổi WordArt](transform_effect.png)

{{% alert color="info" %}} 

Aspose.Slides for .NET cung cấp một tập hợp các [các loại biến đổi](https://reference.aspose.com/slides/vi/net/aspose.slides/textshapetype/) đã được định nghĩa trước.

{{% /alert %}} 

### **Áp dụng hiệu ứng 3D cho hình dạng và văn bản**

Tạo ra các hình ảnh thực tế, bắt mắt có thể nâng cao đáng kể tác động của bản thuyết trình. Trong phần này, chúng ta sẽ khám phá cách áp dụng hiệu ứng ba chiều (3D) cho các hình dạng bằng Aspose.Slides for .NET. Bằng cách điều chỉnh các tham số như độ sâu, góc và ánh sáng, bạn có thể tạo ra các biến đổi 3D ấn tượng, ngay lập tức thu hút sự chú ý của khán giả. Cho dù bạn muốn tạo ra các điểm nhấn tinh tế hay ảo ảnh kịch tính, những tính năng này cung cấp các cách linh hoạt để nâng cao thiết kế và truyền đạt ý tưởng một cách hấp dẫn hơn.

Sử dụng đoạn mã mẫu sau để đặt hiệu ứng 3D cho hình dạng:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

    autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
    autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

    autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    autoShape.ThreeDFormat.BevelTop.Height = 12.5;
    autoShape.ThreeDFormat.BevelTop.Width = 11;

    autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    autoShape.ThreeDFormat.ExtrusionHeight = 6;

    autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    autoShape.ThreeDFormat.ContourWidth = 1.5;

    autoShape.ThreeDFormat.Depth = 3;

    autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

    autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Hình dạng kết quả:

![Hiệu ứng 3D cho hình dạng](shape_3D_effect.png)

Sử dụng đoạn mã mẫu sau để đặt hiệu ứng 3D cho văn bản:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

Văn bản kết quả:

![Hiệu ứng 3D cho văn bản](text_3D_effect.png)

{{% alert color="info" %}} 

Việc áp dụng hiệu ứng 3D cho văn bản hoặc hình dạng của chúng — và cách các hiệu ứng này tương tác — được điều chỉnh bởi các quy tắc cụ thể. Xét một cảnh bao gồm cả văn bản và hình dạng chứa văn bản đó. Một hiệu ứng 3D bao gồm biểu diễn 3D của đối tượng và cảnh mà nó được đặt lên.

- Nếu một cảnh được thiết lập cho cả hình dạng và văn bản, cảnh của hình dạng sẽ được ưu tiên và cảnh của văn bản sẽ bị bỏ qua.
- Nếu hình dạng không có cảnh riêng nhưng có biểu diễn 3D, cảnh của văn bản sẽ được sử dụng.
- Nếu hình dạng không có hiệu ứng 3D nào, nó được xem như phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các hành vi này liên quan đến các thuộc tính [ThreeDFormat.LightRig](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/lightrig/) và [ThreeDFormat.Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/camera/).

{{% /alert %}} 

## **Câu hỏi thường gặp**

### Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc ký tự khác nhau (ví dụ: Ả Rập, Trung Quốc) không?

Có, Aspose.Slides for .NET hỗ trợ Unicode và hoạt động với tất cả các phông chữ và ký tự chính. Các hiệu ứng WordArt như bóng, tô màu và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù tính khả dụng và việc hiển thị phông chữ có thể phụ thuộc vào phông chữ hệ thống.

### Tôi có thể áp dụng hiệu ứng WordArt cho các thành phần trong master slide không?

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các trình giữ chỗ tiêu đề, chân trang hoặc văn bản nền. Các thay đổi được thực hiện trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

### Hiệu ứng WordArt có làm tăng kích thước tệp bản thuyết trình không?

Một chút. Các hiệu ứng WordArt như bóng, phát sáng và tô màu gradient có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng sự chênh lệch thường là không đáng kể.

### Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản thuyết trình không?

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng phương thức `GetImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) hoặc [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản thuyết trình đầy đủ.