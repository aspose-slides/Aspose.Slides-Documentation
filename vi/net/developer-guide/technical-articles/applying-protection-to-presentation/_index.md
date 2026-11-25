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

## **Thành phần của một Slide**

Một slide trong bản trình bày được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung hình ảnh, khung video, connector, và các yếu tố khác được sử dụng để xây dựng bản trình bày. Trong Aspose.Slides for .NET, mỗi thành phần trên một slide được đại diện bằng một đối tượng thực thi giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện đó.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for .NET cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) khóa autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) khóa các hình connector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) khóa các hình nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) khóa các khung hình ảnh.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), hãy lặp qua các slide và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các trình chỉnh sửa bản trình bày tương thích sử dụng các khóa hình dạng để hạn chế các thao tác chỉnh sửa cá nhân. Mã hóa tệp và bảo vệ ghi ở mức độ tài liệu là các [cài đặt bảo vệ bản trình bày](/slides/vi/net/password-protected-presentation/) riêng biệt.

### **Áp dụng Bảo vệ cho Các Hình PPTX**

Aspose.Slides for .NET cung cấp giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ đặt [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), và [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) thành `true` cho autoshapes, với các khóa tương đương cho các hình dạng nhóm, connector và picture frames. Các connector sử dụng [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) cho việc di chuyển; các nhóm cũng sử dụng [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) để hạn chế việc nhóm.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

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

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình bày có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Nó cũng xóa [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác sẽ không bị thay đổi.

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

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ bên trái và 8% từ bên phải, sau đó đặt [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) trên khung hình ảnh. Cờ này hạn chế việc cắt thêm và bảo tồn crop hiện có.

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

`PictureLocked.pptx` lưu khóa crop dưới dạng `true`. Trong PowerPoint, lệnh **Crop** bị vô hiệu hoá khi ảnh được chọn.

### **Giữ Đồ Thị Nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó đặt [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) trên chính nhóm để giữ các thành phần của biểu đồ cùng nhau. Các chỉnh sửa khác, như di chuyển nhóm hoặc thay đổi màu nền của một thành phần, vẫn khả dụng.

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

`DiagramLocked.pptx` lưu khóa không thể tách nhóm dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu hoá khi toàn bộ biểu đồ được chọn.

### **Báo cáo Các Khóa Hình dạng Hiện có**

Để xem xét một mẫu, mở nó và đọc đối tượng khóa cho mỗi hình dạng. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) là `true` khi tất cả các cờ trên đối tượng đó bị tắt và `false` khi ít nhất một cờ được bật. Một nhóm và các thành phần con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các thành phần con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshapes, khung hình ảnh và nhóm, việc cắt cho ảnh, và việc tách nhóm cho các nhóm. Nó báo cáo các cờ mà nó nhận dạng được và đánh dấu các loại hình dạng mà nó không kiểm tra.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với khóa không thể tách nhóm, một ảnh có tên `Photo` bên trong nó với khóa crop, và một hình chữ nhật không khóa có tên `Free`. Báo cáo bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức độ hình dạng được lưu mà không thay đổi chúng hoặc lưu bản trình bày. Bảo vệ ghi ở mức độ tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

### **Kết luận**

Aspose.Slides for .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần loại bỏ những hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/net/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng các khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm sao tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nhóm và áp dụng các khóa thích hợp cho mỗi hình dạng con. Lặp lại việc này cho bất kỳ nhóm lồng nhau nào, theo cách duyệt trong ví dụ báo cáo.