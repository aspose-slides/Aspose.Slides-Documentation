---
title: Tạo và áp dụng hiệu ứng WordArt trong .NET
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
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- .NET
- C#
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho .NET. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình bày với văn bản chuyên nghiệp trong C#."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn tạo kiểu cho văn bản bằng các màu nền, viền, bóng, phản chiếu, hào quang, biến đổi và định dạng 3D. Bài viết này giải thích cách tạo và tùy chỉnh các hiệu ứng này trong bài thuyết trình PowerPoint bằng Aspose.Slides cho .NET, mà không cần cài đặt Microsoft Office.

## **Tạo mẫu WordArt đơn giản và áp dụng cho văn bản**

Các ví dụ sau tạo một kiểu WordArt đơn giản bằng cách đặt văn bản, phông chữ, mẫu nền và viền.

Mỗi ví dụ tạo một bản trình bày mới và thêm một hình chữ nhật vào slide đầu tiên; không cần tệp đầu vào. Ví dụ đầu tiên đặt văn bản thành “Aspose.Slides”. Vị trí và kích thước của hình được đo bằng điểm:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Đặt phông chữ thành Arial Black kích thước 36 điểm để làm nổi bật định dạng:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Áp dụng mẫu [SmallGrid](https://reference.aspose.com/slides/vi/net/aspose.slides/patternstyle/) với màu cam đậm làm nền trước và nền trắng, sau đó thêm viền văn bản màu đen với độ rộng 1 điểm:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Văn bản kết quả:

![Mẫu WordArt đơn giản](WordArt_template.png)

## **Áp dụng các hiệu ứng WordArt khác**

Các ví dụ dưới đây minh họa cách áp dụng bóng, phản chiếu, hào quang, biến đổi và hiệu ứng 3D cho văn bản.

### **Áp dụng hiệu ứng Outer Shadow**

Bóng ngoài tạo độ sâu bằng cách đặt bóng phía sau văn bản. Bạn có thể tùy chỉnh màu, hướng, khoảng cách, bán kính mờ, tỷ lệ và độ nghiêng.

Ví dụ này gọi [EnableOuterShadowEffect](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/enableoutershadoweffect/) và đặt bóng màu đen với bán kính mờ 4 điểm, hướng 230 độ và khoảng cách 30 điểm. Giá trị tỷ lệ 100 giữ nguyên kích thước bóng, trong khi độ nghiêng ngang nghiêng bóng 20 độ. Biến đổi alpha đặt độ mờ của bóng ở mức 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Văn bản kết quả:

![Hiệu ứng Outer Shadow](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Khi bóng ngoài và bóng đặt trước được sử dụng cùng nhau, chỉ bóng ngoài được áp dụng.
- Nếu bóng ngoài và bóng trong được sử dụng đồng thời, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi, trong khi trong PowerPoint 2007, chỉ bóng ngoài được áp dụng.
{{% /alert %}}

### **Áp dụng hiệu ứng Reflection**

Phản chiếu tạo một bản sao phản chiếu của văn bản. Điều chỉnh vị trí, tỷ lệ, độ mờ và độ trong suốt để kiểm soát cách hiển thị.

Ví dụ này gọi [EnableReflectionEffect](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/enablereflectioneffect/) và lật phản chiếu theo chiều dọc với tỷ lệ -100%. Nó sử dụng bán kính mờ 0.5 điểm và khoảng cách 4.72 điểm. Độ trong suốt giảm từ 60% xuống 0.9% giữa các vị trí 0% và 60% trên phản chiếu:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

Văn bản kết quả:

![Hiệu ứng Reflection](reflection_effect.png)

### **Áp dụng hiệu ứng Glow**

Hào quang thêm một viền màu mềm quanh văn bản. Điều chỉnh màu, độ trong suốt và bán kính để kiểm soát hiệu ứng.

Ví dụ này gọi [EnableGlowEffect](https://reference.aspose.com/slides/vi/net/aspose.slides/effectformat/enablegloweffect/) và áp dụng hào quang màu đỏ với độ trong suốt 54% và bán kính 7 điểm:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Văn bản kết quả:

![Hiệu ứng Glow](glow_effect.png)

### **Áp dụng biến đổi WordArt**

Biến đổi WordArt uốn, kéo dài hoặc làm biến dạng một khối văn bản.

Đặt [Transform](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/transform/) thành [ArchUpPour](https://reference.aspose.com/slides/vi/net/aspose.slides/textshapetype/) để uốn cong toàn bộ khung văn bản lên phía trên:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Văn bản kết quả:

![Biến đổi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides cho .NET cung cấp một tập hợp các [loại biến đổi](https://reference.aspose.com/slides/vi/net/aspose.slides/textshapetype/) được định sẵn.
{{% /alert %}}

### **Áp dụng hiệu ứng 3D cho hình và văn bản**

Bạn có thể áp dụng hiệu ứng 3D cho một hình hoặc cho văn bản của nó. Các yếu tố bevel, extrusion, ánh sáng và cài đặt camera kiểm soát kết quả hiển thị.

Ví dụ dưới đây sử dụng [ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/) để thêm bevel vòng tròn, extrusion màu cam và viền màu đỏ đậm cho hình chữ nhật. Các kích thước bevel, chiều cao extrusion, độ rộng viền và độ sâu đều đo bằng điểm. Vật liệu nhựa, ánh sáng cân bằng quay 40 độ quanh trục Z và camera phối cảnh xác định vẻ ngoài:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

Hình kết quả:

![Hiệu ứng 3D cho hình](shape_3D_effect.png)

Ví dụ này áp dụng định dạng 3D tương tự cho văn bản thông qua [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/threedformat/). Bevel nhỏ hơn tạo hình các cạnh chữ, trong khi extrusion và ánh sáng mang lại độ sâu cho văn bản:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

Văn bản kết quả:

![Hiệu ứng 3D cho văn bản](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Việc áp dụng hiệu ứng 3D cho văn bản hoặc cho các hình chứa chúng — và cách chúng tương tác với nhau — được điều chỉnh bởi các quy tắc cụ thể. Hãy xem xét một cảnh bao gồm cả văn bản và hình chứa nó. Một hiệu ứng 3D bao gồm đại diện 3D của đối tượng và cảnh mà nó được đặt trong đó.

- Nếu một cảnh được đặt cho cả hình và văn bản, cảnh của hình sẽ có ưu tiên và cảnh của văn bản sẽ bị bỏ qua.
- Nếu hình không có cảnh riêng nhưng có đại diện 3D, cảnh của văn bản sẽ được sử dụng.
- Nếu hình hoàn toàn không có hiệu ứng 3D, nó được coi là phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các hành vi này liên quan đến các thuộc tính [ThreeDFormat.LightRig](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/lightrig/) và [ThreeDFormat.Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Để giữ văn bản phẳng và dễ đọc trong khi vẫn giữ định dạng 3D của hình, hãy xem [Giữ Văn Bản Phẳng trên Hình 3D](/slides/vi/net/3d-presentation/) để so sánh cả hai cài đặt và một ví dụ C# đầy đủ.

## **FAQ**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc bảng chữ viết khác nhau (ví dụ: Arabic, Chinese) không?**

Có, Aspose.Slides cho .NET hỗ trợ Unicode và hoạt động với tất cả các phông chữ và bảng chữ viết chính. Các hiệu ứng WordArt như bóng, nền và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù tính khả dụng của phông chữ và việc hiển thị có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt cho các thành phần trong slide master không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình trên slide master, bao gồm các khung tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến dung lượng file trình chiếu không?**

Ảnh hưởng nhẹ. Các hiệu ứng WordArt như bóng, hào quang và nền gradient có thể làm tăng nhẹ dung lượng file do thêm metadata định dạng, nhưng sự chênh lệch thường là không đáng kể.

**Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu trình chiếu không?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng [ISlide.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/), hoặc render các hình riêng lẻ bằng [IShape.GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getimage/). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình chiếu đầy đủ.