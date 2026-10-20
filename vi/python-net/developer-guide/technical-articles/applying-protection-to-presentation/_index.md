---
title: Hạn chế chỉnh sửa bản trình bày bằng các khóa hình dạng trong Python
linktitle: Hạn chế chỉnh sửa bản trình bày
type: docs
weight: 70
url: /vi/python-net/applying-protection-to-presentation/
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
- presentation
- Python
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình bày PPTX bằng Aspose.Slides cho Python qua .NET để hạn chế việc chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides for Python via .NET là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận những bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng cũng như loại bỏ khóa hình dạng trong một bản trình bày PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trình bày được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, nhóm hình dạng, khung ảnh, khung video, connector, và các yếu tố khác được sử dụng để xây dựng một bài thuyết trình. Trong Aspose.Slides for Python via .NET, mỗi yếu tố trên một slide được đại diện bởi một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for Python via .NET cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) khóa các autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) khóa các connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) khóa các nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), lặp lại qua các slide của nó và đặt các khóa thích hợp cho mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước các hình dạng. Chúng không làm cho toàn bộ bản trình bày không thể chỉnh sửa.

### **Áp dụng Bảo vệ cho Các Hình Dạng PPTX**

Aspose.Slides cho Python qua .NET cung cấp lớp [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) để làm việc với các hình dạng trên một slide.

Ví dụ đặt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) và [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) thành `True` cho autoshape, với các khóa tương đương cho nhóm hình dạng, connector và khung ảnh. Connectors sử dụng [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) cho việc di chuyển; các nhóm cũng sử dụng [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) để hạn chế việc nhóm lại.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng ngoại trừ bốn loại được xử lý sẽ không thay đổi. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

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

### **Xóa Bảo vệ**

Để loại bỏ khóa hình dạng, đặt giá trị của nó thành `False`. Ví dụ sau tải một bản trình bày có khóa hình dạng và xóa các hạn chế về chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Nó cũng xóa [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác sẽ không thay đổi.

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

### **Kết luận**

Aspose.Slides cho Python qua .NET cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng cùng một hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `False` khi bạn cần loại bỏ các hạn chế đó.

## **Câu hỏi thường gặp**

**Có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/python-net/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào để áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp qua bộ sưu tập [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) của nhóm và áp dụng các khóa thích hợp cho từng hình dạng con. Lặp lại cho bất kỳ nhóm lồng nhau nào. Các ví dụ trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.