---
title: Hạn chế chỉnh sửa bản trình bày bằng khóa hình dạng trong Python
linktitle: Hạn chế chỉnh sửa bản trình bày
type: docs
weight: 70
url: /vi/python-net/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình bày PPTX bằng Aspose.Slides cho Python qua .NET để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Nền tảng**

Một cách sử dụng phổ biến của Aspose.Slides for Python qua .NET là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp duy trì bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được sắp xếp trên các slide và cách áp dụng và xóa khóa hình dạng trong một bản trình bày PPTX. Những khóa này cho phép bạn giới hạn các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Cấu trúc của một slide**

Một slide trong bản trình bày được tạo nên từ các thành phần như autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors và các yếu tố khác được sử dụng để xây dựng bản trình bày. Trong Aspose.Slides for Python qua .NET, mỗi yếu tố trên slide được đại diện bởi một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Python qua .NET cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) khóa các autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) khóa các connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) khóa các graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) khóa các group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) khóa các picture frames.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), lặp qua các slide và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa bảo vệ**

Các trình chỉnh sửa bản trình bày tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản trình bày](/slides/vi/python-net/password-protected-presentation/) riêng biệt.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides for Python qua .NET cung cấp lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) để làm việc với các hình dạng trên slide.

Ví dụ đặt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) và [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) thành `True` cho các autoshapes, với các khóa tương tự cho group shapes, connectors và picture frames. Connectors sử dụng [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) để di chuyển; các nhóm cũng sử dụng [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) để hạn chế việc nhóm.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `False`. Ví dụ sau tải một bản trình bày có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Nó cũng xóa [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác không bị thay đổi.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Bảo toàn việc cắt ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12 % từ bên trái và 8 % từ bên phải, sau đó đặt [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) trên picture frame để bảo toàn việc cắt.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` lưu khóa cắt là `True`. Trong PowerPoint, lệnh **Crop** bị vô hiệu khi ảnh được chọn.

### **Giữ một sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó đặt [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) trên chính nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, chẳng hạn di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` lưu khóa gỡ nhóm là `True`. Trong PowerPoint, lệnh **Ungroup** bị vô hiệu khi toàn bộ sơ đồ được chọn.

### **Kết luận**

Aspose.Slides for Python qua .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một tập hợp hạn chế trên các slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `False` khi cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/python-net/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một file.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng tới các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide được chọn. Điều này sẽ không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) của nhóm và áp dụng các khóa thích hợp cho mỗi hình dạng con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ của nhóm.