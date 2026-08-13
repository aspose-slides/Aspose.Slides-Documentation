---
title: Tạo hiệu ứng 3D trong các bài thuyết trình bằng .NET
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/net/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- quay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng và hiển thị hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong .NET với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho .NET có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, đùn, cạnh chốt, ánh sáng, vật liệu, độ chuyển màu hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành ảnh, PDF hoặc HTML, Aspose.Slides sẽ chuyển các hiệu ứng 3D này thành đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng thuộc tính [IShape.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/threedformat) để áp dụng định dạng 3D cho một hình dạng. Thuộc tính này cung cấp [IThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng thuộc tính [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/threedformat). Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thuộc tính quan trọng nhất là:

| Thuộc tính | Kiểm soát gì | Khi nào sử dụng |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/camera) | Độ nhìn, kiểu máy ảnh mặc định, quay, thu phóng và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với một mẫu quay 3D của PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/lightrig) | Cài đặt ánh sáng, hướng và quay ánh sáng. | Thay đổi cách các điểm nổi bật và bóng tối xuất hiện trên bề mặt 3D. |
| [Material](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/material) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [ExtrusionHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusionheight) | Khoảng cách hình dạng mở rộng về phía sau từ mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày nhìn thấy được. |
| [ExtrusionColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Màu của các mặt bên được đùn. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/depth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt cạnh chốt và vật liệu. |
| [BevelTop](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/beveltop) và [BevelBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/bevelbottom) | Các cạnh nổi lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm hoặc tạo khuôn thay vì mặt phẳng sắc nhọn. |
| [ContourColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/contourcolor) và [ContourWidth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/contourwidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả hiển thị. |

## **Tạo hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thuyết phục là 3D:

- Cài đặt Camera, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt Light, vì ánh sáng giúp các mặt và cạnh trở nên rõ ràng.
- Cài đặt Material, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.
- Cài đặt Extrusion hoặc Depth, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và kết xuất slide thành ảnh PNG.

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

Hình ảnh slide đã kết xuất cho thấy hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được hiển thị với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay hình dạng bằng Camera**

Trong PowerPoint, quay 3D được cấu hình từ bảng điều khiển 3‑D Rotation. Các giá trị quay X, Y và Z tương ứng với phép quay bạn thiết lập qua API camera.

![Bảng điều khiển Xoay 3D của PowerPoint với các giá trị X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và góc quay qua [IThreeDFormat.Camera](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi kết xuất.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Điều khiển độ sâu trong PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusionheight) để xác định độ dày và [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/extrusioncolor) để xác định màu mặt bên:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Sử dụng [IThreeDFormat.Depth](https://reference.aspose.com/slides/vi/net/aspose.slides/ithreedformat/properties/depth) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, material và hiệu ứng văn bản. Trong nhiều trường hợp, `ExtrusionHeight` là cài đặt rõ ràng hơn vì nó trực tiếp biểu thị độ đùn nhìn thấy được.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu nền đặc, gradient, mẫu hoặc ảnh vào mặt trước và vẫn dùng cùng một camera, light, material và cài đặt đùn.

Ví dụ này áp dụng gradient lên hình và màu đùn tối hơn cho các mặt bên:

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

Kết quả đã kết xuất giữ gradient trên mặt trước và kết xuất phần đùn riêng biệt:

![Hình chữ nhật 3D được hiển thị với độ chuyển màu xanh đến cam và đùn màu cam](img_02_03.png)

Để thay thế bằng ảnh nền, thêm hình ảnh vào bản trình bày và gán nó làm màu nền cho hình:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Ảnh được kết xuất trên mặt trước, trong khi phần đùn được hiển thị như bề mặt 3D phía bên:

![Hình chữ nhật 3D được hiển thị với ảnh nền trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến phần thân hình, trong khi định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng loại WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với mẫu đổ màu, áp dụng biến đổi WordArt và cấu hình các cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat):

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

Văn bản được kết xuất dưới dạng chữ 3D cong, đùn:

![Văn bản 3D được hiển thị với biến dạng WordArt dạng vòm, mẫu nền màu cam, và đùn tối](img_02_05.png)

## **Hành vi Xuất và Kết xuất**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi kết xuất hoặc xuất ra các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn kết xuất slide thành [PNG](/slides/vi/net/convert-powerpoint-to-png/), xuất ra [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), xuất ra [HTML](/slides/vi/net/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/net/convert-powerpoint-to-video/).

Hãy lưu ý các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp giữa camera, light rig, material, extrusion, fill và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, hãy đọc [thuộc tính hình dạng hiệu quả](/slides/vi/net/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong các định dạng đó, kết quả trực quan được kết xuất thay vì được lưu giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

### Aspose.Slides có tạo được bài thuyết trình 3D tương tác không?

Aspose.Slides tạo và kết xuất các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

### Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như quay, đùn, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

### Các cài đặt nào bắt buộc để có một hình dạng 3D nhìn thấy được?

Ít nhất cần đặt một góc quay camera và một trong hai: extrusion hoặc depth. Thực tế, nên đồng thời đặt light rig và material để các mặt được kết xuất có điểm nổi bật và bóng rõ ràng.

### Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?

Có. Sử dụng [IShape.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/threedformat) cho phần thân hình và [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/threedformat) cho văn bản.

### Các hiệu ứng 3D có xuất hiện khi xuất ra ảnh, PDF, HTML hoặc khung video không?

Có. Aspose.Slides kết xuất các hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung được dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã kết xuất, không phải một đối tượng 3D có thể chỉnh sửa.

### Tôi có thể đọc các giá trị 3D cuối cùng sau khi đã áp dụng kế thừa và theme không?

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/net/shape-effective-properties/) để đọc camera, light rig, bevel và các giá trị 3D liên quan cuối cùng.