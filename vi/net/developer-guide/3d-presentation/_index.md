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
- extrusion 3D
- độ dốc 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong .NET với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, extrusion, các loại đổ màu, và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for .NET có thể tạo, chỉnh sửa, bảo tồn và render định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, extrude, bevel, ánh sáng, vật liệu, đổ màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản của PowerPoint. Nó không liên quan tới việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng thuộc tính [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) để áp dụng định dạng 3D cho một hình dạng. Thuộc tính này cung cấp [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), kiểm soát cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng thuộc tính [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Thuộc tính này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thuộc tính quan trọng nhất là:

| Property | What it controls | When to use it |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Điểm quan sát, loại máy ảnh được đặt trước, quay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một cài đặt quay 3D của PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Cài đặt ánh sáng, hướng và quay ánh sáng. | Thay đổi cách hiện ra các điểm sáng và bóng trên bề mặt 3D. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Chất liệu bề mặt, như phẳng, mờ, nhựa, hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ rệt. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Màu của các mặt bên được tạo ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền mặt trước. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và chất liệu. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) và [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì một mặt phẳng sắc nét. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) và [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh giới hạn đối tượng trong đầu ra được render. |

## **Tạo một Hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thật 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần extrude.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và các bên có thể nhìn thấy.
- Cài đặt chất liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt extrude hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ dưới đây tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị quay máy ảnh được tính bằng độ, và chiều cao extrude là 100 điểm. Ví dụ này render slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình chiếu dưới dạng PPTX.

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

Ảnh slide đã render hiển thị hình chữ nhật dưới dạng khối 3D dày:

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình bằng Máy ảnh**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3‑D Rotation. Các giá trị quay X, Y và Z tương ứng với việc bạn thiết lập qua API máy ảnh.

![Bảng PowerPoint 3‑D Rotation với các giá trị quay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh thông qua [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước dạng orthographic, và đặt các góc quay X, Y, Z thành 20, 30 và 40 độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó chỉ thay đổi quan điểm 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

### **Sao chép Định hướng Máy ảnh từ Hình mẫu**

Để khớp một hình trong mẫu, sao chép cài đặt trước [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) và đọc các góc bằng [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Ví dụ mở `template.pptx`, đọc máy ảnh từ hình đầu tiên trên slide đầu tiên, và áp dụng định hướng này cho hình thứ hai. Cả hai hình đã có ánh sáng 3D, và hình thứ hai không có quay máy ảnh rõ ràng.

Các góc tính bằng độ. Chỉ số `0` là vĩ độ, chỉ số `1` là kinh độ, và chỉ số `2` là vòng quay. Gửi chúng đến [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) theo thứ tự đó. Nếu nguồn trả về `null`, nghĩa là không có quay rõ ràng, vì vậy để nguyên góc của hình thứ hai. Một quay rõ ràng `(0, 0, 0)` trả về ba số 0 và nên được sao chép.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Khi bạn mở lại `camera-copy.pptx`, hai hình sẽ có cùng cài đặt trước máy ảnh và cùng góc quay. Trong PowerPoint, mũi tên bên phải sử dụng định hướng máy ảnh đã sao chép từ hình chữ nhật bên trái. Cả hai hình đều dùng cùng ánh sáng và độ sâu extrude.

![Một hình chữ nhật 3D màu xanh và một mũi tên phải với định hướng máy ảnh khớp, nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Extrude và Độ sâu**

Extrude làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu extrude và chiều cao extrude](img_02_02.png)

Đặt [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) để xác định độ dày và [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) để đặt màu mặt bên. Ví dụ này cho một hình chữ nhật extrude 100 điểm với các mặt bên màu tím và quay máy ảnh để hiển thị độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Thuộc tính [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) đặt độ sâu cho một hình dạng 3D. Thuộc tính [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) kiểm soát chiều cao của hiệu ứng extrude, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu nền đặc, gradient, mẫu hoặc hình ảnh cho mặt trước và vẫn dùng cùng máy ảnh, ánh sáng, chất liệu và cài đặt extrude.

Ví dụ này áp dụng gradient từ xanh sang cam cho mặt trước và màu cam đậm cho extrude 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị quay máy ảnh tính bằng độ. Slide được render thành ảnh PNG với kích thước gấp đôi mặc định:

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

Đầu ra đã render giữ gradient trên mặt trước và render extrude riêng biệt:

![Hình chữ nhật 3D được render với đổ màu gradient từ xanh sang cam và extrude màu cam](img_02_03.png)

Để sử dụng đổ màu ảnh, thêm ảnh vào bản trình chiếu và chỉ định nó làm nền cho hình dạng. Ví dụ này yêu cầu có một tệp tên “image.jpg” trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng extrude 150 điểm, và đặt quay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc render tệp:

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

Ảnh được render trên mặt trước, trong khi extrude được render như bề mặt bên 3D:

![Hình chữ nhật 3D được render với nền ảnh trên mặt trước và extrude màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến phần thân hình dạng. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần extrude, chất liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với mẫu lưới màu cam và trắng, áp dụng một cung cong lên, và cấu hình cài đặt 3D qua [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Chiều cao extrude và độ sâu tính bằng điểm, và quay ánh sáng tính bằng độ. Phần nền và viền của hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này render ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

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

Văn bản được render dưới dạng chữ 3D cong, extrude:

![Văn bản 3D được render với biến đổi WordArt dạng cung, đổ mẫu màu cam, và extrude tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản dễ đọc trong khi vẫn bảo toàn hình dạng 3D, đặt [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) qua [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình: máy ảnh, ánh sáng, chất liệu và extrude vẫn được cấu hình qua [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Nó cũng khác với việc quay thông thường. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) quay hình trong mặt phẳng slide, trong khi [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) điều khiển góc quay tùy chỉnh của văn bản trong khung chứa. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong hai trường hợp này.

Ví dụ tự chứa dưới đây tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao extrude là 40 điểm. Ví dụ lưu bản trình chiếu dưới dạng PPTX và render slide so sánh thành PNG với kích thước gấp đôi mặc định.

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

Ở bên trái, văn bản theo hướng 3D. Ở bên phải, văn bản giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ extrude và hướng 3D nhìn thấy được.

![Hai hình chữ nhật 3D bên cạnh: KeepTextFlat là false ở bên trái và true ở bên phải](keep_text_flat.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo toàn định dạng 3D khi lưu thành các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/net/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/net/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/net/convert-powerpoint-to-video/).

Hãy lưu ý các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, bộ ánh sáng, vật liệu, extrude, nền và tỉ lệ slide.
- Nếu cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên chủ đề, hãy đọc [Các thuộc tính hình dạng hiệu quả](/slides/vi/net/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả trực quan được render thay vì được giữ như các cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo các bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho hình ảnh, PDF hoặc trang HTML được xuất thành các cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như quay, extrude, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết để có một hình 3D nhìn thấy được?**

Ít nhất, cần đặt một góc quay máy ảnh và hoặc extrude hoặc độ sâu. Thực tế, bạn cũng nên đặt bộ ánh sáng và chất liệu để các mặt được render có nét sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) cho phần thân hình dạng và [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt chủ đề không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Các thuộc tính hình dạng hiệu quả](/slides/vi/net/shape-effective-properties/) để đọc máy ảnh, bộ ánh sáng, bevel và các giá trị 3D liên quan cuối cùng.