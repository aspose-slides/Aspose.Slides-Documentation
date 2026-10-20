---
title: Hạn chế chỉnh sửa bản trình chiếu bằng khóa hình dạng trong Python
linktitle: Hạn chế chỉnh sửa bản trình chiếu
type: docs
weight: 60
url: /vi/python-java/applying-protection-to-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình chiếu PPTX bằng Aspose.Slides cho Python qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for Python via Java là tạo, cập nhật và lưu các bản trình chiếu PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản trình chiếu này, việc hạn chế thay đổi các hình dạng có thể giúp bảo toàn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và gỡ bỏ khóa hình dạng trong một bản trình chiếu PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Cấu trúc của một Slide**

Một slide trong bản trình chiếu được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, nhóm hình dạng, khung hình, khung video, connector và các yếu tố khác được dùng để xây dựng bản trình chiếu. Trong Aspose.Slides for Python via Java, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Python via Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) khóa các autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) khóa các connector shape.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) khóa các nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) khóa các khung hình.  

Để áp dụng khóa cho toàn bộ một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), hãy lặp qua các slide của nó và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Gỡ bỏ bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước các hình dạng. Chúng không làm cho toàn bộ bản trình chiếu trở nên không thể chỉnh sửa.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides for Python via Java cung cấp lớp [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) để làm việc với các hình dạng trên một slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), và [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) với `True` cho các autoshape, với các khóa tương đương cho nhóm hình dạng, connector và picture frame. Các connector sử dụng [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bản trình chiếu PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gỡ bỏ bảo vệ**

Để gỡ bỏ một khóa hình dạng, đặt giá trị của nó thành `False`. Ví dụ sau tải một bản trình chiếu có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), và [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Nó cũng gỡ bỏ hạn chế nhóm bằng cách truyền `False` cho [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), và lưu một bản sao của bản trình chiếu. Các cài đặt khóa khác sẽ không bị thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kết luận**

Aspose.Slides for Python via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một hạn chế trên toàn bộ các slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `False` khi bạn cần gỡ bỏ các hạn chế đó.

## **FAQ**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/python-java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình chiếu. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập được trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa thích hợp cho từng hình dạng con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.