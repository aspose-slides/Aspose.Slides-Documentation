---
title: Hạn chế chỉnh sửa bản thuyết trình bằng khóa hình dạng trong Java
linktitle: Hạn chế chỉnh sửa bản thuyết trình
type: docs
weight: 60
url: /vi/java/applying-protection-to-presentation/
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
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản thuyết trình PPTX bằng Aspose.Slides cho Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for Java là tạo, cập nhật và lưu các bản thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản thuyết trình này, việc hạn chế thay đổi các hình dạng có thể giúp bảo vệ bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên slide và cách áp dụng và loại bỏ khóa hình dạng trong một bản thuyết trình PPTX. Những khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Cấu trúc của một Slide**

Một slide trong bản thuyết trình được tạo nên từ các thành phần như autoshape, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bản thuyết trình. Trong Aspose.Slides for Java, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng triển khai giao diện [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for Java cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) khóa các autoshape.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) khóa các shape connector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) khóa các shape nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) khóa các khung ảnh.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), hãy lặp qua các slide của nó và đặt các khóa phù hợp cho mỗi shape được hỗ trợ.

## **Áp dụng và Xóa bảo vệ**

Các trình chỉnh sửa bản thuyết trình tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa cá nhân. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản thuyết trình](/slides/vi/java/password-protected-presentation/) riêng biệt.

### **Áp dụng bảo vệ cho các Shape PPTX**

Aspose.Slides for Java cung cấp giao diện [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) để làm việc với các shape trên slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), và [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) với `true` cho autoshape, với các khóa tương đương cho shape nhóm, connector và picture frame. Connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) để hạn chế việc nhóm.

Ví dụ tải một bản thuyết trình PPTX hiện có, kiểm tra các shape trong bộ sưu tập shape của mỗi slide, và lưu một bản sao với các hạn chế này đã được áp dụng. Các shape không thuộc bốn loại được xử lý sẽ được để nguyên. Vòng lặp không duyệt qua các shape con bên trong một nhóm.

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

Để xóa một khóa shape, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản thuyết trình có các khóa shape và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Nó cũng xóa hạn chế nhóm bằng cách truyền `false` vào [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) và lưu một bản sao của bản thuyết trình. Các cài đặt khóa khác sẽ được giữ nguyên.

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

### **Bảo tồn việc Cắt Ảnh**

Đặt một bức ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ bên trái và 8% từ bên phải, sau đó gọi [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) trên khóa của picture frame. Truyền `true` sẽ hạn chế việc cắt thêm và bảo tồn crop hiện có.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` lưu khóa crop dưới dạng `true`. Trong PowerPoint, lệnh **Crop** bị vô hiệu hoá khi ảnh được chọn.

### **Giữ biểu đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) trên khóa của nhóm để giữ các thành phần của biểu đồ lại với nhau. Các thao tác chỉnh sửa khác, như di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` lưu khóa ungrouping dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu hoá khi toàn bộ biểu đồ được chọn.

### **Báo cáo các Khóa Shape hiện có**

Để xem xét một mẫu, mở nó và đọc đối tượng khóa cho mỗi shape. Phương thức [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) trả về `true` khi tất cả các cờ trên đối tượng đó bị tắt và `false` khi có ít nhất một cờ được bật. Một nhóm và các phần tử con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các phần tử con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshape, picture frame và nhóm. Nó cũng kiểm tra việc crop cho ảnh và ungrouping cho nhóm. Báo cáo liệt kê các cờ được bật mà nó nhận biết và đánh dấu các loại shape mà nó không kiểm tra.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với khóa ungrouping, một ảnh có tên `Photo` bên trong đó với khóa cropping, và một hình chữ nhật không khóa có tên `Free`. Báo cáo bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức shape đã lưu mà không thay đổi chúng hoặc lưu bản thuyết trình. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

### **Kết luận**

Aspose.Slides for Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng shape hoặc áp dụng cùng một hạn chế trên toàn bộ slide. Chọn các khóa được hỗ trợ bởi mỗi loại shape, và đặt giá trị của chúng thành `false` khi bạn cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa shape và bảo vệ bằng mật khẩu trong cùng một bản thuyết trình không?**

Có. Khóa shape hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Chỉ áp dụng các khóa cho các shape trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các shape riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) của nhóm và áp dụng các khóa phù hợp cho từng shape con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào, theo thứ tự duyệt trong ví dụ báo cáo.