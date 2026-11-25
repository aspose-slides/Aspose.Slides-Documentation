---
title: Hạn chế chỉnh sửa bản thuyết trình bằng khóa hình dạng trong Python
linktitle: Hạn chế chỉnh sửa bản thuyết trình
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
- bản thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản thuyết trình PPTX bằng Aspose.Slides cho Python qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for Python via Java là tạo, cập nhật và lưu các bản thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản thuyết trình này, việc hạn chế thay đổi các hình dạng có thể giúp bảo toàn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được sắp xếp trên slide và cách áp dụng cũng như gỡ bỏ khóa hình dạng trong một bản thuyết trình PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Thành phần của một slide**

Một slide trong bản thuyết trình được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, nhóm hình dạng, khung ảnh, khung video, connector và các yếu tố khác dùng để xây dựng bản thuyết trình. Trong Aspose.Slides for Python via Java, mỗi yếu tố trên slide được biểu diễn bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Python via Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) khóa các autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) khóa các connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) khóa các nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), duyệt qua các slide và đặt các khóa phù hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và gỡ bảo vệ**

Các trình biên tập bản thuyết trình tương thích dùng các khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản thuyết trình](/slides/vi/python-java/password-protected-presentation/).

### **Áp dụng bảo vệ cho các hình PPTX**

Aspose.Slides for Python via Java cung cấp lớp [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) để làm việc với các hình trên slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) và [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) với `True` cho autoshapes, và các khóa tương đương cho nhóm hình, connector và khung ảnh. Connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) cho việc di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bản thuyết trình PPTX hiện có, kiểm tra các hình trong bộ sưu tập hình của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình không thuộc bốn loại được xử lý sẽ không thay đổi. Vòng lặp không duyệt các hình con bên trong một nhóm.

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

### **Gỡ bảo vệ**

Để gỡ một khóa hình dạng, đặt giá trị của nó thành `False`. Ví dụ dưới đây tải một bản thuyết trình có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Nó cũng gỡ hạn chế nhóm bằng cách truyền `False` vào [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bản thuyết trình. Các cài đặt khóa khác không bị thay đổi.

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

### **Bảo lưu việc cắt ảnh**

Đặt một ảnh có tên `photo.jpg` vào thư mục làm việc. Ví dụ cắt 12 % từ bên trái và 8 % từ bên phải, rồi gọi [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) với `True` để bảo lưu việc cắt.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong `PictureLocked.pptx`, PowerPoint sẽ vô hiệu hóa lệnh **Crop** khi bạn chọn ảnh.

### **Giữ một sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) với `True` để giữ hai hình dạng luôn cùng nhau. Bạn vẫn có thể di chuyển nhóm hoặc thay đổi màu nền của thành phần.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong `DiagramLocked.pptx`, PowerPoint sẽ vô hiệu hóa lệnh **Ungroup** khi bạn chọn toàn bộ sơ đồ.

### **Báo cáo các khóa hình hiện có**

Để xem xét một mẫu, mở nó và đọc đối tượng khóa cho mỗi hình dạng. Phương thức [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) trả về `True` khi tất cả các cờ trên đối tượng đó bị tắt và `False` khi ít nhất một cờ được bật. Một nhóm và các thành viên con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các thành viên con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshapes, khung ảnh và nhóm. Nó cũng kiểm tra việc cắt cho ảnh và việc tách nhóm cho các nhóm. Báo cáo liệt kê các cờ đã bật mà nó nhận diện và đánh dấu các loại hình dạng mà nó không kiểm tra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với khóa tách nhóm, một ảnh có tên `Photo` bên trong với khóa cắt, và một hình chữ nhật không khóa có tên `Free`. Báo cáo sẽ bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức hình mà không thay đổi chúng hoặc lưu bản thuyết trình. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình biên tập.

### **Kết luận**

Aspose.Slides for Python via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một tập hợp hạn chế trên toàn bộ các slide. Chọn các khóa được hỗ trợ bởi từng loại hình dạng, và đặt giá trị của chúng thành `False` khi bạn cần gỡ bỏ các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản thuyết trình không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/python-java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Thao tác này sẽ không thay đổi cài đặt khóa trên các slide khác.

**Làm sao tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa phù hợp cho mỗi hình con. Lặp lại quy trình này cho bất kỳ nhóm lồng nhau nào, theo cùng cách duyệt trong ví dụ báo cáo.