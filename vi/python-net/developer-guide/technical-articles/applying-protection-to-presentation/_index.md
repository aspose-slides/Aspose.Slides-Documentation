---
title: Hạn chế chỉnh sửa bài thuyết trình bằng khóa hình dạng trong Python
linktitle: Hạn chế chỉnh sửa bài thuyết trình
type: docs
weight: 70
url: /vi/python-net/applying-protection-to-presentation/
keywords:
- ngăn ngừa chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bài thuyết trình PPTX bằng Aspose.Slides for Python qua .NET để hạn chế việc chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Nền tảng**

Một cách sử dụng phổ biến của Aspose.Slides for Python qua .NET là tạo, cập nhật và lưu các bài thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận được các bài thuyết trình này, việc hạn chế thay đổi các hình dạng có thể giúp bảo vệ bố cục và nội dung đã định.

Bài viết này giải thích cách các hình dạng được tổ chức trên slide và cách áp dụng và xóa khóa hình dạng trong một bài thuyết trình PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trong bài thuyết trình gồm các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung hình ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bài thuyết trình. Trong Aspose.Slides for Python qua .NET, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Python qua .NET cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) khóa autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) khóa connector shape.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) khóa đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) khóa group shape.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) khóa picture frame.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , lặp qua các slide và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa bảo vệ**

Các trình chỉnh sửa bài thuyết trình tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bài thuyết trình](/slides/vi/python-net/password-protected-presentation/) riêng biệt.

### **Áp dụng bảo vệ cho các Shape PPTX**

Aspose.Slides for Python qua .NET cung cấp lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) để làm việc với các shape trên slide.

Ví dụ thiết lập [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/) , [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) và [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) thành `True` cho các autoshape, với các khóa tương đương cho group shape, connector và picture frame. Connectors sử dụng [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) để di chuyển; các nhóm cũng sử dụng [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) để hạn chế việc nhóm.

Ví dụ tải một bài thuyết trình PPTX hiện có, kiểm tra các shape trong bộ sưu tập shape của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các shape không thuộc bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các shape con bên trong một nhóm.

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

Để xóa một khóa shape, đặt giá trị của nó thành `False`. Ví dụ sau tải một bài thuyết trình có khóa shape và xoá các hạn chế lựa chọn, di chuyển và thay đổi kích thước qua [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) , [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) , [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) . Nó cũng xoá [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) và lưu một bản sao của bài thuyết trình. Các cài đặt khóa khác được giữ nguyên.

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

### **Bảo tồn cắt ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ trái và 8% từ phải, sau đó thiết lập [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) trên picture frame. Cờ này hạn chế việc cắt thêm và bảo tồn cắt hiện có.

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

`PictureLocked.pptx` lưu khóa cắt dưới dạng `True`. Trong PowerPoint, lệnh **Crop** sẽ bị vô hiệu hóa khi ảnh được chọn.

### **Giữ một sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó thiết lập [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) trên chính nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, chẳng hạn di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

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

`DiagramLocked.pptx` lưu khóa không cho tách nhóm dưới dạng `True`. Trong PowerPoint, lệnh **Ungroup** sẽ bị vô hiệu hóa khi toàn bộ sơ đồ được chọn.

### **Báo cáo các khóa shape hiện có**

Để xem xét một mẫu, mở nó và đọc đối tượng khóa cho mỗi shape. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) là `True` khi tất cả các cờ trên đối tượng đó bị tắt và `False` khi ít nhất một cờ được bật. Một group và các phần tử con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các phần tử con ngay cả khi group không có khóa.

Ví dụ này kiểm tra việc di chuyển cho autoshapes, picture frames và groups, cắt ảnh cho picture và tách nhóm cho groups. Nó báo cáo các cờ mà nó nhận dạng và đánh dấu các loại shape mà nó không kiểm tra.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Giả sử slide 1 của `Sample.pptx` chứa một group tên `Layout` với khóa ungrouping, một picture tên `Photo` bên trong với khóa cropping, và một rectangle không khóa tên `Free`. Báo cáo sẽ bỏ qua `Free` và in hai dòng sau:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Báo cáo đọc các cờ chỉnh sửa mức shape đã lưu mà không thay đổi chúng hoặc lưu bài thuyết trình. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

### **Kết luận**

Aspose.Slides for Python qua .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng shape hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại shape, và đặt giá trị của chúng thành `False` khi bạn cần xóa các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa shape và bảo vệ bằng mật khẩu trong cùng một bài thuyết trình không?**

Có. Khóa shape hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/python-net/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bài thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các shape trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào tôi có thể áp dụng khóa cho các shape riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập [các shape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) của nhóm và áp dụng các khóa thích hợp cho mỗi shape con. Lặp lại thao tác này cho bất kỳ nhóm lồng nhau nào, theo cách duyệt trong ví dụ báo cáo.