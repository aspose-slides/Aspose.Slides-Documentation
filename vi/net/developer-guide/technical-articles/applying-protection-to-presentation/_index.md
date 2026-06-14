---
title: Ngăn chặn việc chỉnh sửa bản trình chiếu bằng khóa Shape trong .NET
linktitle: Ngăn chặn việc chỉnh sửa bản trình chiếu
type: docs
weight: 70
url: /vi/net/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa shape
- khóa vị trí
- khóa chọn
- khóa kích thước
- khóa nhóm
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách Aspose.Slides for .NET khóa hoặc mở khóa các shape trong tệp PPT, PPTX và ODP, bảo mật bản trình chiếu đồng thời cho phép chỉnh sửa có kiểm soát."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides là tạo, cập nhật và lưu các bản trình chiếu Microsoft PowerPoint (PPTX) như một phần của quy trình tự động. Người dùng các ứng dụng sử dụng Aspose.Slides theo cách này có quyền truy cập vào các bản trình chiếu đã tạo, vì vậy việc bảo vệ chúng khỏi việc chỉnh sửa là một mối quan tâm chung. Điều quan trọng là các bản trình chiếu được tạo tự động phải giữ nguyên định dạng và nội dung gốc.

Bài viết này giải thích cách cấu trúc của bản trình chiếu và các slide, cũng như cách Aspose.Slides for .NET có thể áp dụng bảo vệ cho một bản trình chiếu và sau đó gỡ bỏ nó. Nó cung cấp cho các nhà phát triển một cách để kiểm soát cách sử dụng các bản trình chiếu do ứng dụng của họ tạo ra.

## **Cấu trúc của một slide**

Một slide của bản trình chiếu được tạo thành các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng được nhóm, khung hình ảnh, khung video, connector, và các yếu tố khác dùng để xây dựng bản trình chiếu. Trong Aspose.Slides for .NET, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện đó.

Cấu trúc của PPTX rất phức tạp, do đó không giống như PPT, nơi có thể sử dụng một khóa chung cho mọi loại hình dạng, các loại hình dạng khác nhau yêu cầu các khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseshapelock/) là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for .NET cho PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshapelock/) khóa các autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/vi/net/aspose.slides/iconnectorlock/) khóa các connector shape.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/vi/net/aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/igroupshapelock/) khóa các group shape.  
- [IPictureFrameLock](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/) khóa các picture frame.  

Bất kỳ hành động nào được thực hiện trên tất cả các đối tượng shape trong một đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sẽ được áp dụng cho toàn bộ bản trình chiếu.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Áp dụng bảo vệ đảm bảo rằng bản trình chiếu không thể bị chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bản trình chiếu.

### **Áp dụng Bảo vệ cho các Shape PPTX**

Aspose.Slides for .NET cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) để làm việc với các shape trên một slide.

Như đã đề cập trước đó, mỗi lớp shape có một lớp shape-lock tương ứng để bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Các khóa này đảm bảo rằng shape không thể được chọn (bằng cách nhấp chuột hoặc các phương pháp chọn khác) và không thể di chuyển hoặc thay đổi kích thước.

Mẫu mã sau áp dụng bảo vệ cho tất cả các loại shape trong một bản trình chiếu.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Duyệt qua tất cả các slide trong bản trình chiếu.
foreach (ISlide slide in presentation.Slides)
{
    // Duyệt qua tất cả các shape trong slide.
    foreach (IShape shape in slide.Shapes)
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

// Lưu tệp bản trình chiếu.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Gỡ bỏ Bảo vệ**

Để mở khóa một shape, đặt giá trị của khóa đã áp dụng thành `false`. Mẫu mã sau cho thấy cách mở khóa các shape trong một bản trình chiếu đã được khóa.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Duyệt qua tất cả các slide trong bản trình chiếu.
foreach (ISlide slide in presentation.Slides)
{
    // Duyệt qua tất cả các shape trong slide.
    foreach (IShape shape in slide.Shapes)
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

// Lưu tệp bản trình chiếu.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Kết luận**

Aspose.Slides cung cấp một số tùy chọn để bảo vệ các shape trong một bản trình chiếu. Bạn có thể khóa một shape riêng lẻ hoặc lặp qua tất cả các shape trong một bản trình chiếu và khóa từng shape để bảo vệ toàn bộ tệp một cách hiệu quả. Bạn có thể gỡ bỏ bảo vệ bằng cách đặt giá trị khóa thành `false`.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa shape và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Các khóa hạn chế việc chỉnh sửa các đối tượng trong tệp, trong khi [password protection](/slides/vi/net/password-protected-presentation/) kiểm soát quyền truy cập để mở và/hoặc lưu các thay đổi. Hai cơ chế này bổ trợ lẫn nhau và hoạt động cùng nhau.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa cho các shape trên các slide đã chọn; các slide còn lại sẽ vẫn có thể chỉnh sửa.

**Các khóa shape có áp dụng cho các đối tượng được nhóm và các connector không?**

Có. Các loại khóa riêng biệt được hỗ trợ cho các nhóm, connector, đối tượng đồ họa và các loại shape khác.