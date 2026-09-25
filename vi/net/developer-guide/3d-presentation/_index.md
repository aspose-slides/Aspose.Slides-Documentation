---
title: Tạo 3D Effects trong Presentations Sử dụng .NET
linktitle: 3D Presentation
type: docs
weight: 232
url: /vi/net/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng và kết xuất các hiệu ứng 3D cho các hình và văn bản PowerPoint trong .NET với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, tô màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for .NET có thể tạo, chỉnh sửa, bảo tồn và kết xuất định dạng 3D kiểu PowerPoint cho các hình và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, bevel, ánh sáng, vật liệu, tô gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình và văn bản trong PowerPoint. Nó không đề cập đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ kết xuất các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Các khái niệm Định dạng 3D**

Sử dụng thuộc tính [IShape.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/threedformat) để áp dụng định dạng 3D cho một hình. Thuộc tính này phơi bày [IThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat), bộ điều khiển cảnh 3D cho hình đó.

Đối với văn bản, sử dụng thuộc tính [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/threedformat). Điều này áp dụng định dạng 3D cho khung văn bản thay vì thân hình.

Các thuộc tính quan trọng nhất là:

| Thuộc tính | Chức năng điều khiển | Khi nào nên dùng |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/camera) | Điểm nhìn, loại camera được cài sẵn, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc phù hợp với một cài đặt xoay 3D của PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/lightrig) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách hiển thị các điểm sáng và bóng trên bề mặt 3D. |
| [Material](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/material) | Chất liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [ExtrusionHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusionheight) | Khoảng cách hình dạng mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành đối tượng 3D dày rõ ràng. |
| [ExtrusionColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền phía trước. |
| [Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/depth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [BevelTop](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/beveltop) và [BevelBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/bevelbottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc tạo hình thay vì mặt phẳng sắc nhọn. |
| [ContourColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/contourcolor) và [ContourWidth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/contourwidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả hiển thị. |

## **Tạo hình 3D**

Một hình thường cần bốn loại cài đặt trước khi trông thực sự 3D:

- Cài đặt camera, vì góc nhìn mặc định có thể ẩn đùn.
- Cài đặt ánh sáng, vì ánh sáng làm các mặt và cạnh dễ nhận biết.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được kết xuất.
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị xoay camera được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ kết xuất slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình chiếu dưới dạng PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Ảnh slide đã kết xuất hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh dương được kết xuất với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay hình bằng Camera**

Trong PowerPoint, xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với xoay bạn đặt qua API camera.

![Bảng PowerPoint 3-D Rotation với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập camera qua [IThreeDFormat.Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/camera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước trực giao, và đặt các góc xoay X, Y, Z lần lượt là 20, 30 và 40 độ. Nó cấu hình hình trong bộ nhớ mà không lưu tệp:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D trên slide, mà thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi kết xuất.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình trông dày bằng cách mở rộng ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày nhìn thấy này, và điều khiển màu đặt màu cho các mặt bên.

![Điều khiển độ sâu trong PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusionheight) để xác định độ dày và [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusioncolor) để đặt màu mặt bên. Ví dụ này cho hình chữ nhật một đùn 100 điểm với các mặt bên màu tím và xoay camera để hiển thị độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu tệp:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Thuộc tính [IThreeDFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/depth) đặt độ sâu cho một hình 3D. Thuộc tính [ExtrusionHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusionheight) kiểm soát chiều cao hiệu ứng đùn, như minh họa trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D không phụ thuộc vào việc tô màu hình. Bạn có thể áp dụng màu đặc, gradient, mẫu hoặc ảnh lên mặt trước và vẫn sử dụng cùng một cài đặt camera, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient màu xanh‑đến‑cam cho mặt trước và màu cam đậm cho đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu bắt đầu và kết thúc gradient. Giá trị xoay camera được tính bằng độ. Slide được kết xuất thành ảnh PNG với kích thước gấp đôi mặc định:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Kết quả đã giữ gradient trên mặt trước và kết xuất đùn riêng biệt:

![Hình chữ nhật 3D với gradient màu xanh‑đến‑cam và đùn màu cam](img_02_03.png)

Để sử dụng ảnh thay vì gradient, thêm ảnh vào bản trình chiếu và gán cho tô màu hình. Ví dụ này yêu cầu một tệp tồn tại có tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm, và đặt góc xoay camera tính bằng độ. Nó cấu hình hình trong bộ nhớ mà không lưu hoặc kết xuất tệp:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Ảnh được kết xuất trên mặt trước, trong khi đùn được kết xuất như bề mặt bên 3D:

![Hình chữ nhật 3D với ảnh nền trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình ảnh ảnh hưởng đến thân hình. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với mẫu lưới cam‑trắng, áp dụng một cung cong lên trên, và cấu hình cài đặt 3D qua [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/threedformat). Chiều cao và độ sâu đùn tính bằng điểm, và góc quay ánh sáng tính bằng độ. Tô màu và đường viền của hình được ẩn để chỉ văn bản hiển thị. Ví dụ kết xuất ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Văn bản được kết xuất dưới dạng chữ 3D uốn cong, đùn, có mẫu màu cam và đùn tối:

![Văn bản 3D được kết xuất với biến dạng WordArt dạng cung, mẫu màu cam và đùn tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản dễ đọc trong khi vẫn duy trì vẻ 3D của hình, đặt [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/keeptextflat/) qua [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/textframeformat/). Khi giá trị là `true`, văn bản sẽ nằm ngoài cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không xóa định dạng 3D của hình: camera, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [IShape.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/threedformat/). Nó cũng khác với xoay thông thường. [IShape.Rotation](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/rotation/) xoay hình trong mặt phẳng slide, trong khi [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/rotationangle/) điều khiển góc xoay tùy chỉnh của văn bản trong khung của nó. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh hình gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở phía trái và `true` ở phía phải. Góc camera tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ lưu bản trình chiếu dưới dạng PPTX và kết xuất slide so sánh thành PNG với kích thước gấp đôi mặc định.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Ở bên trái, văn bản theo hướng 3D. Ở bên phải, nó vẫn phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng một độ đùn và hướng 3D hiển thị.

![Hai hình chữ nhật 3D cạnh nhau: KeepTextFlat là false ở trái và true ở phải](keep_text_flat.png)

## **Hành vi Xuất và Kết xuất**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi kết xuất hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn kết xuất slide thành [PNG](/slides/vi/net/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/net/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/net/convert-powerpoint-to-video/).

Hãy lưu ý các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể được xoay bởi người xem sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của camera, light rig, vật liệu, đùn, tô màu và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [thuộc tính hình hiệu quả](/slides/vi/net/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong những định dạng đó, kết quả trực quan được kết xuất thay vì được lưu giữ dưới dạng thiết lập 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và kết xuất các hiệu ứng 3D của PowerPoint cho hình và văn bản. Nó không làm cho các ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng áp dụng cho một hình PowerPoint thông thường hoặc văn bản, chẳng hạn xoay, đùn, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào cần thiết để có một hình 3D nhìn được?**

Ít nhất, cần đặt một góc xoay camera và hoặc đùn hoặc độ sâu. Thực tế, cũng nên đặt light rig và vật liệu để các mặt được kết xuất có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình và văn bản không?**

Có. Sử dụng [IShape.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/threedformat) cho thân hình và [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/threedformat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides kết xuất hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa kết quả đã kết xuất, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và giao diện không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Thuộc tính Hình Hiệu quả](/slides/vi/net/shape-effective-properties/) để đọc camera, light rig, bevel và các giá trị 3D liên quan cuối cùng.