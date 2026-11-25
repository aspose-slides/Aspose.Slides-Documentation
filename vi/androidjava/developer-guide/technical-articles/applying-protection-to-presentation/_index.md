---
title: Hạn chế chỉnh sửa bản trình chiếu bằng khóa hình dạng trên Android
linktitle: Hạn chế chỉnh sửa bản trình chiếu
type: docs
weight: 60
url: /vi/androidjava/applying-protection-to-presentation/
keywords:
- ngăn chặn việc chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình chiếu PPTX bằng Aspose.Slides cho Android qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides for Android via Java là tạo, cập nhật và lưu các bản trình chiếu PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản trình chiếu này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự kiến.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng cũng như loại bỏ các khóa hình dạng trong một bản trình chiếu PPTX. Những khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trong bản trình chiếu bao gồm các thành phần như hình tự động, bảng, đối tượng OLE, các hình dạng được nhóm, khung hình ảnh, khung video, kết nối, và các yếu tố khác được sử dụng để xây dựng bản trình chiếu. Trong Aspose.Slides for Android via Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng thực thi giao diện [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) hoặc kế thừa từ một lớp thực hiện giao diện này.

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Giao diện [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) là giao diện cơ sở cho các khóa hình dạng. Aspose.Slides for Android via Java cung cấp các giao diện khóa sau:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) khóa các hình tự động.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) khóa các hình kết nối.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) khóa các đối tượng đồ họa.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) khóa các hình dạng nhóm.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) khóa các khung hình ảnh.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), hãy duyệt qua các slide của nó và đặt các khóa thích hợp cho từng hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các trình chỉnh sửa bản trình chiếu tương thích sử dụng các khóa hình dạng để hạn chế các thao tác chỉnh sửa cá nhân. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [presentation protection settings](/slides/vi/androidjava/password-protected-presentation/) riêng biệt.

### **Áp dụng Bảo vệ cho Các Hình dạng PPTX**

Aspose.Slides for Android via Java cung cấp giao diện [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) để làm việc với các hình dạng trên một slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), và [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) với `true` cho các hình tự động, cùng với các khóa tương đương cho các hình dạng nhóm, kết nối và khung hình ảnh. Các kết nối sử dụng [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) để hạn chế việc nhóm.

Ví dụ tải một bản trình chiếu PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng không thuộc bốn loại được xử lý sẽ được giữ nguyên. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

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

### **Xóa Bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình chiếu có các khóa hình dạng và xóa các hạn chế về lựa chọn, di chuyển và thay đổi kích thước thông qua [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), và [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Nó cũng xóa hạn chế nhóm bằng cách truyền `false` vào [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), và lưu một bản sao của bản trình chiếu. Các thiết lập khóa khác vẫn được giữ nguyên.

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

### **Bảo tồn Cắt ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ phía trái và 8% từ phía phải, sau đó gọi [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) trên khóa của khung hình ảnh. Truyền `true` sẽ hạn chế việc cắt thêm và bảo tồn phần cắt hiện có.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` lưu khóa cắt dưới dạng `true`. Trong PowerPoint, lệnh **Crop** sẽ bị vô hiệu hoá khi ảnh được chọn.

### **Giữ một Sơ đồ ở dạng Nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) trên khóa của nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, như di chuyển nhóm hoặc thay đổi màu tô của một thành phần, vẫn khả dụng.

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

`DiagramLocked.pptx` lưu khóa tách nhóm dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** sẽ bị vô hiệu hoá khi toàn bộ sơ đồ được chọn.

### **Báo cáo Các Khóa Hình dạng Hiện có**

Để xem xét một mẫu, mở nó và đọc đối tượng khóa cho mỗi hình dạng. Phương thức [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) trả về `true` khi tất cả các cờ trên đối tượng đó bị tắt và `false` khi ít nhất một cờ được bật. Một nhóm và các thành phần con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các thành phần con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho các hình tự động, khung hình ảnh và các nhóm. Nó cũng kiểm tra việc cắt cho ảnh và tách nhóm cho các nhóm. Báo cáo liệt kê các cờ được bật mà nó nhận diện và đánh dấu các loại hình dạng mà nó không kiểm tra.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

Giả sử slide 1 của `Sample.pptx` chứa một nhóm tên `Layout` với khóa tách nhóm, một ảnh tên `Photo` bên trong với khóa cắt, và một hình chữ nhật không khóa tên `Free`. Báo cáo bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức hình dạng được lưu mà không thay đổi chúng hoặc lưu bản trình chiếu. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

## **Kết luận**

Aspose.Slides for Android via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng các hạn chế tương tự trên các slide. Chọn các khóa được hỗ trợ cho mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/androidjava/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình chiếu. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng các khóa chỉ cho các hình dạng trên các slide được chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng các khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) của nhóm và áp dụng các khóa thích hợp cho mỗi hình dạng con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào, theo quy trình duyệt trong ví dụ báo cáo.