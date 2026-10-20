---
title: Hạn chế chỉnh sửa bản trình chiếu bằng khóa hình dạng trong .NET
linktitle: Hạn chế chỉnh sửa bản trình chiếu
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong các bản trình chiếu PPTX bằng Aspose.Slides cho .NET để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for .NET là tạo, cập nhật và lưu các bản trình chiếu PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản trình chiếu này, việc hạn chế thay đổi các hình dạng có thể giúp bảo toàn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng cũng như gỡ bỏ khóa hình dạng trong một bản trình chiếu PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một slide**

Một slide trong bản trình chiếu được tạo thành từ các thành phần như hình tự động, bảng, đối tượng OLE, các hình dạng được nhóm, khung ảnh, khung video, kết nối, và các yếu tố khác dùng để xây dựng bản trình chiếu. Trong Aspose.Slides for .NET, mỗi yếu tố trên slide được đại diện bởi một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for .NET cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) khóa các hình tự động.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) khóa các hình kết nối.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) khóa các hình nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), lặp qua các slide của nó và thiết lập các khóa phù hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước các hình dạng. Chúng không làm cho toàn bộ bản trình chiếu không thể chỉnh sửa.

### **Áp dụng Bảo vệ cho các Hình dạng PPTX**

Aspose.Slides for .NET cung cấp giao diện [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ thiết lập [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), và [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) thành `true` cho các hình tự động, với các khóa tương đương cho hình nhóm, kết nối và khung ảnh. Các kết nối sử dụng [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) cho việc di chuyển; các nhóm cũng sử dụng [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) để hạn chế việc nhóm lại.

Ví dụ tải một bản trình chiếu PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

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

### **Gỡ bỏ Bảo vệ**

Để gỡ bỏ một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình chiếu có khóa hình dạng và xóa các hạn chế chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Nó cũng xóa [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) và lưu một bản sao của bản trình chiếu. Các cài đặt khóa khác sẽ không bị thay đổi.

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

### **Kết luận**

Aspose.Slides for .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng các hạn chế giống nhau trên nhiều slide. Chọn các khóa được hỗ trợ bởi từng loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần gỡ bỏ các hạn chế đó.

## **Câu hỏi thường gặp**

**Có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/net/password-protected-presentation/) có thể hạn chế việc mở hoặc chỉnh sửa bản trình chiếu. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide được chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào để áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.