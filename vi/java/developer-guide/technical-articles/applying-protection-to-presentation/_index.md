---
title: Hạn chế chỉnh sửa bài thuyết trình với Khóa Shape trong Java
linktitle: Hạn chế chỉnh sửa bài thuyết trình
type: docs
weight: 60
url: /vi/java/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa shape
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các shape trong bài thuyết trình PPTX bằng Aspose.Slides cho Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Nền tảng**

Một cách sử dụng phổ biến của Aspose.Slides for Java là tạo, cập nhật và lưu các bài thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bài thuyết trình này, việc hạn chế thay đổi các shape có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các shape được tổ chức trên slide và cách áp dụng cũng như xóa bỏ khóa shape trong một bài thuyết trình PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng shape riêng lẻ.

## **Cấu trúc của một slide**

Một slide trong bài thuyết trình được tạo thành từ các thành phần như autoshape, bảng, đối tượng OLE, shape nhóm, khung hình, khung video, connector và các yếu tố khác dùng để xây dựng bài thuyết trình. Trong Aspose.Slides for Java, mỗi yếu tố trên slide được đại diện bởi một đối tượng thực thi giao diện [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại shape khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) là giao diện cơ bản cho các khóa shape. Aspose.Slides for Java cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) khóa autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) khóa các connector shape.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) khóa shape nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) khóa các khung hình.  

Để áp dụng khóa trên một [Bản trình chiếu](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), duyệt qua các slide của nó và thiết lập các khóa phù hợp trên mỗi shape được hỗ trợ.

## **Áp dụng và Xóa bảo vệ**

Các khóa shape hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước shape. Chúng không làm cho toàn bộ bài thuyết trình không thể chỉnh sửa.

### **Áp dụng bảo vệ cho các shape PPTX**

Aspose.Slides for Java cung cấp giao diện [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) để làm việc với các shape trên một slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), và [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) với giá trị `true` cho autoshape, với các khóa tương đương cho shape nhóm, connector và picture frame. Các connector sử dụng [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) để hạn chế việc nhóm.

Ví dụ tải một bài thuyết trình PPTX hiện có, kiểm tra các shape trong bộ sưu tập shape của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các shape không thuộc bốn loại được xử lý sẽ được giữ nguyên. Vòng lặp không duyệt qua các shape con bên trong một nhóm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Xóa bảo vệ**

Để xóa một khóa shape, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình chiếu có khóa shape và xóa các hạn chế về chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Nó cũng loại bỏ hạn chế nhóm bằng cách truyền `false` cho [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) và lưu một bản sao của bài thuyết trình. Các cài đặt khóa khác được giữ nguyên.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kết luận**

Aspose.Slides for Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng shape riêng lẻ hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại shape, và đặt giá trị của chúng thành `false` khi cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa shape và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Khóa shape hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình chiếu. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các shape trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các shape riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập được trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) của nhóm và áp dụng các khóa phù hợp cho mỗi shape con. Lặp lại cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập shape của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ của nhóm.