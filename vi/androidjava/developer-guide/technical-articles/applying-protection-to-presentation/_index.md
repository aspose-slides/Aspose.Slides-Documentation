---
title: Hạn chế chỉnh sửa bản thuyết trình bằng khóa hình dạng trên Android
linktitle: Hạn chế chỉnh sửa bản thuyết trình
type: docs
weight: 60
url: /vi/androidjava/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản thuyết trình PPTX bằng Aspose.Slides cho Android qua Java để hạn chế việc chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một mục đích phổ biến của Aspose.Slides for Android via Java là tạo, cập nhật và lưu các bản thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản thuyết trình này, việc giới hạn thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và xóa khóa hình dạng trong một bản thuyết trình PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Cấu tạo của một Slide**

Một slide trong bản thuyết trình được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung hình, khung video, kết nối và các yếu tố khác được sử dụng để xây dựng bản thuyết trình. Trong Aspose.Slides for Android via Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for Android via Java cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) khóa các autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) khóa các hình dạng kết nối.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) khóa các hình dạng nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) khóa các khung hình.

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), duyệt qua các slide của nó và đặt các khóa phù hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước hình dạng. Chúng không khiến toàn bộ bản thuyết trình không thể chỉnh sửa.

### **Áp dụng Bảo vệ cho Các Hình Dạng PPTX**

Aspose.Slides for Android via Java cung cấp giao diện [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) để làm việc với các hình dạng trên slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), và [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) với `true` cho các autoshape, với các khóa tương đương cho các hình dạng nhóm, kết nối và khung hình. Các kết nối sử dụng [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) để hạn chế việc nhóm.

Ví dụ tải một bản thuyết trình PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ được để nguyên. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

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

### **Gỡ bỏ Bảo vệ**

Để gỡ bỏ khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản thuyết trình có khóa hình dạng và xoá các hạn chế chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Nó cũng gỡ bỏ hạn chế nhóm bằng cách truyền `false` vào [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) và lưu một bản sao của bản thuyết trình. Các cài đặt khóa khác được để nguyên.

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

Aspose.Slides for Android via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần gỡ bỏ các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản thuyết trình không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ của nhóm.