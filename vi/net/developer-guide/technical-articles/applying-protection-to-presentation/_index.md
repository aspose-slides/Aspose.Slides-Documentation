---
title: Hạn chế chỉnh sửa bản trình bày bằng khóa hình dạng trong .NET
linktitle: Hạn chế chỉnh sửa bản trình bày
type: docs
weight: 70
url: /vi/net/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình bày PPTX bằng Aspose.Slides cho .NET để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for .NET là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và loại bỏ khóa hình dạng trong một bản trình bày PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một slide**

Một slide trong bản trình bày bao gồm các thành phần như tự động hình dạng, bảng, đối tượng OLE, hình dạng nhóm, khung ảnh, khung video, kết nối và các yếu tố khác được dùng để xây dựng bản trình bày. Trong Aspose.Slides for .NET, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for .NET cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) khóa các hình dạng tự động.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) khóa các hình dạng kết nối.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) khóa các hình dạng nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) khóa các khung ảnh.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), duyệt qua các slide và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các trình chỉnh sửa bản trình bày tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản trình bày](/slides/vi/net/password-protected-presentation/) riêng biệt.

### **Áp dụng Bảo vệ cho Các Hình dạng PPTX**

Aspose.Slides for .NET cung cấp giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ thiết lập [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) và [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) thành `true` cho các autoshape, với các khóa tương đương cho hình dạng nhóm, kết nối và khung ảnh. Các kết nối sử dụng [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) cho việc di chuyển; các nhóm cũng sử dụng [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) để hạn chế việc nhóm lại.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này đã được áp dụng. Các hình dạng không thuộc bốn loại đã xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Xóa Bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình bày có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) và [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Nó cũng xóa [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác sẽ không bị thay đổi.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Bảo tồn Cắt Ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ bên trái và 8% từ bên phải, sau đó thiết lập [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) trên khung ảnh. Cờ này hạn chế việc cắt tiếp và bảo tồn phần cắt hiện có.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` lưu trạng thái khóa cắt là `true`. Trong PowerPoint, lệnh **Crop** bị vô hiệu hoá khi ảnh được chọn.

### **Giữ Đồ họa Nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó thiết lập [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) trên chính nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, chẳng hạn di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` lưu trạng thái khóa không nhóm là `true`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu hoá khi toàn bộ sơ đồ được chọn.

### **Kết luận**

Aspose.Slides for .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng các hạn chế tương tự trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/net/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Chỉ áp dụng các khóa cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nhóm và áp dụng các khóa thích hợp cho mỗi hình dạng con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.