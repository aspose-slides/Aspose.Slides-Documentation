---
title: Ngăn chỉnh sửa bản trình bày bằng Khóa Shape
linktitle: Ngăn chỉnh sửa bản trình bày
type: docs
weight: 60
url: /vi/python-java/applying-protection-to-presentation/
keywords:
- ngăn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa shape
- khóa vị trí
- khóa chọn
- khóa kích thước
- khóa nhóm
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides for Python via Java khóa hoặc mở khóa các shape trong tệp PPT, PPTX và ODP, bảo mật bản trình bày đồng thời cho phép chỉnh sửa có kiểm soát và giao hàng nhanh hơn."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides là tạo, cập nhật và lưu các bản trình bày Microsoft PowerPoint (PPTX) như một phần của quy trình tự động. Người dùng các ứng dụng sử dụng Aspose.Slides theo cách này có quyền truy cập vào các bản trình bày được tạo, do đó việc bảo vệ chúng khỏi việc chỉnh sửa là một mối quan tâm chung. Điều quan trọng là các bản trình bày được tạo tự động phải giữ nguyên định dạng và nội dung ban đầu.

Bài viết này giải thích cách cấu trúc của bản trình bày và các slide, cũng như cách Aspose.Slides for Python via Java có thể áp dụng bảo vệ cho một bản trình bày và sau đó gỡ bỏ. Nó cung cấp cho các nhà phát triển một cách để kiểm soát cách sử dụng các bản trình bày mà ứng dụng của họ tạo ra.

## **Cấu trúc của một Slide**

Một slide trong bản trình bày được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung hình ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bản trình bày. Trong Aspose.Slides for Python via Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) .

Cấu trúc của PPTX khá phức tạp, vì vậy không giống như PPT, nơi có thể sử dụng một khóa chung cho mọi loại hình dạng, các loại hình dạng khác nhau yêu cầu các khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseshapelock/) là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for Python via Java cho PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshapelock/) khóa các autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connectorlock/) khóa các connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshapelock/) khóa các nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframelock/) khóa các khung hình ảnh.  

Bất kỳ hành động nào được thực hiện trên tất cả các đối tượng shape trong một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) sẽ được áp dụng cho toàn bộ bản trình bày.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Việc áp dụng bảo vệ đảm bảo rằng một bản trình bày không thể bị chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bản trình bày.

### **Áp dụng Bảo vệ cho Các Shape trong PPTX**

Aspose.Slides for Python via Java cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) để làm việc với các shape trên slide.

Như đã đề cập ở trên, mỗi lớp shape đều có một lớp shape‑lock tương ứng để bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Các khóa này đảm bảo rằng các shape không thể được chọn (bằng cách nhấp chuột hoặc các phương pháp chọn khác) và không thể di chuyển hoặc thay đổi kích thước.

Mẫu mã sau áp dụng bảo vệ cho tất cả các loại shape trong một bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Duyệt qua tất cả các slide trong bản trình bày.
    for slide in presentation.getSlides():
        # Duyệt qua tất cả các shape trong slide.
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

    # Lưu tệp bản trình bày.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gỡ bỏ Bảo vệ**

Để mở khóa một shape, đặt giá trị của khóa đã áp dụng thành `False`. Mẫu mã dưới đây cho thấy cách mở khóa các shape trong một bản trình bày đã bị khóa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Duyệt qua tất cả các slide trong bản trình bày.
    for slide in presentation.getSlides():
        # Duyệt qua tất cả các shape trong slide.
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

    # Lưu tệp bản trình bày.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kết luận**

Aspose.Slides cung cấp một số tùy chọn để bảo vệ các shape trong một bản trình bày. Bạn có thể khóa một shape riêng lẻ hoặc duyệt qua tất cả các shape trong bản trình bày và khóa từng shape để bảo vệ toàn bộ tệp một cách hiệu quả. Bạn có thể gỡ bỏ bảo vệ bằng cách đặt giá trị khóa thành `False`.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp các khóa shape và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa giới hạn việc chỉnh sửa các đối tượng bên trong tệp, trong khi [password protection](/slides/vi/python-java/password-protected-presentation/) kiểm soát quyền truy cập để mở và/hoặc lưu các thay đổi. Các cơ chế này bổ trợ lẫn nhau và hoạt động cùng nhau.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa cho các shape trên các slide đã chọn; các slide còn lại sẽ vẫn có thể chỉnh sửa.

**Các khóa shape có áp dụng cho các đối tượng nhóm và connector không?**

Có. Các loại khóa riêng được hỗ trợ cho nhóm, connector, đối tượng đồ họa và các loại shape khác.