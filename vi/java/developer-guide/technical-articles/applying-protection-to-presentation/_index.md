---
title: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày Bằng Khóa Shape
linktitle: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày
type: docs
weight: 60
url: /vi/java/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi chỉnh sửa
- khóa shape
- khóa vị trí
- khóa chọn
- khóa kích thước
- khóa nhóm
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides for Java khóa hoặc mở khóa các shape trong tệp PPT, PPTX và ODP, bảo mật bản trình bày đồng thời cho phép chỉnh sửa kiểm soát và giao hàng nhanh hơn."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides là tạo, cập nhật và lưu các bản trình bày Microsoft PowerPoint (PPTX) trong một quy trình tự động. Người dùng các ứng dụng sử dụng Aspose.Slides theo cách này có quyền truy cập vào các bản trình bày đã tạo, vì vậy việc bảo vệ chúng khỏi việc chỉnh sửa là mối quan tâm chung. Điều quan trọng là các bản trình bày được tạo tự động phải giữ nguyên định dạng và nội dung gốc.

Bài viết này giải thích cách cấu trúc của bản trình bày và các slide, cũng như cách Aspose.Slides for Java có thể áp dụng bảo vệ cho một bản trình bày và sau đó gỡ bỏ nó. Nó cung cấp cho nhà phát triển một cách để kiểm soát cách sử dụng các bản trình bày do ứng dụng của họ tạo ra.

## **Thành phần của một slide**

Một slide trong bản trình bày được cấu thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các shape nhóm, khung hình ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bản trình bày. Trong Aspose.Slides for Java, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Cấu trúc của PPTX phức tạp, vì vậy khác với PPT, nơi một khóa chung có thể được sử dụng cho mọi loại shape, các loại shape khác nhau yêu cầu các khóa riêng. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseshapelock/) là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for Java cho PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshapelock/) khóa các autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnectorlock/) khóa các shape connector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igroupshapelock/) khóa các shape nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/) khóa các khung hình ảnh.  

Bất kỳ hành động nào được thực hiện trên tất cả các đối tượng shape trong một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sẽ được áp dụng cho toàn bộ bản trình bày.

## **Áp dụng và gỡ bỏ bảo vệ**

Áp dụng bảo vệ đảm bảo rằng bản trình bày không thể được chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bản trình bày.

### **Áp dụng bảo vệ cho các shape PPTX**

Aspose.Slides for Java cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để làm việc với các shape trên slide.

Như đã đề cập ở trên, mỗi lớp shape có một lớp shape-lock tương ứng để bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Những khóa này đảm bảo rằng các shape không thể được chọn (qua nhấp chuột hoặc các phương pháp chọn khác) và cũng không thể di chuyển hoặc thay đổi kích thước.

Mẫu mã dưới đây áp dụng bảo vệ cho tất cả các loại shape trong một bản trình bày.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Duyệt qua tất cả các slide trong bản trình bày.
for (ISlide slide : presentation.getSlides()) {

    // Duyệt qua tất cả các shape trong slide.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Ép kiểu shape thành autoshape và lấy khóa shape của nó.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Ép kiểu shape thành group shape và lấy khóa shape của nó.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Ép kiểu shape thành connector và lấy khóa shape của nó.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Ép kiểu shape thành picture frame và lấy khóa shape của nó.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Lưu tệp bản trình bày.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Gỡ bỏ bảo vệ**

Để bỏ khóa một shape, đặt giá trị của khóa đã áp dụng thành `false`. Mẫu mã dưới đây minh họa cách bỏ khóa các shape trong một bản trình bày đã được khóa.

```java
// Tạo đối tượng lớp Presentation đại diện cho tệp PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Duyệt qua tất cả các slide trong bản trình bày.
for (ISlide slide : presentation.getSlides()) {

    // Duyệt qua tất cả các shape trong slide.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Ép kiểu shape thành autoshape và lấy khóa shape của nó.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Ép kiểu shape thành group shape và lấy khóa shape của nó.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Ép kiểu shape thành connector và lấy khóa shape của nó.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Ép kiểu shape thành picture frame và lấy khóa shape của nó.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Lưu tệp bản trình bày.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Kết luận**

Aspose.Slides cung cấp một số tùy chọn để bảo vệ các shape trong một bản trình bày. Bạn có thể khóa một shape riêng lẻ hoặc duyệt qua tất cả các shape trong bản trình bày và khóa từng shape để bảo vệ toàn bộ tệp một cách hiệu quả. Bạn có thể gỡ bỏ bảo vệ bằng cách đặt giá trị khóa thành `false`.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Có. Các khóa hạn chế việc chỉnh sửa các đối tượng bên trong tệp, trong khi [password protection](/slides/vi/java/password-protected-presentation/) kiểm soát quyền truy cập để mở và/hoặc lưu các thay đổi. Những cơ chế này bổ trợ lẫn nhau và hoạt động đồng thời.

**Can I restrict editing on specific slides without affecting others?**

Có. Áp dụng khóa cho các shape trên các slide đã chọn; các slide còn lại sẽ vẫn có thể chỉnh sửa.

**Do shape locks apply to grouped objects and connectors?**

Có. Các loại khóa riêng biệt được hỗ trợ cho nhóm, connector, đối tượng đồ họa và các loại shape khác.