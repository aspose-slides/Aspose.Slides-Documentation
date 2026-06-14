---
title: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày Bằng Khóa Shape Trong Python
linktitle: Ngăn Chặn Việc Chỉnh Sửa Bản Trình Bày
type: docs
weight: 70
url: /vi/python-net/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
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
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python qua .NET khóa hoặc mở khóa các shape trong các tệp PPT, PPTX và ODP, bảo vệ bản trình bày trong khi cho phép chỉnh sửa có kiểm soát và giao hàng nhanh hơn."
---
## **Bối cảnh**

Một cách sử dụng phổ biến của Aspose.Slides là tạo, cập nhật và lưu các bản trình bày Microsoft PowerPoint (PPTX) như một phần của quy trình tự động. Người dùng các ứng dụng sử dụng Aspose.Slides theo cách này có quyền truy cập vào các bản trình bày đã tạo, do đó việc bảo vệ chúng khỏi việc chỉnh sửa là một mối quan ngại phổ biến. Điều quan trọng là các bản trình bày được tạo tự động phải giữ nguyên định dạng và nội dung gốc.

Bài viết này giải thích cách cấu trúc các bản trình bày và các slide cũng như cách Aspose.Slides for Python có thể áp dụng bảo vệ cho một bản trình bày và sau đó gỡ bỏ nó. Nó cung cấp cho các nhà phát triển một cách để kiểm soát cách các bản trình bày mà ứng dụng của họ tạo ra được sử dụng.

## **Cấu trúc của một Slide**

Một slide trình bày được tạo thành từ các thành phần như autoshape, bảng, đối tượng OLE, nhóm hình dạng, khung ảnh, khung video, connector và các yếu tố khác dùng để xây dựng bản trình bày. Trong Aspose.Slides for Python, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) .

Cấu trúc của PPTX rất phức tạp, vì vậy khác với PPT, nơi một khóa chung có thể được sử dụng cho mọi loại hình dạng, các loại hình dạng khác nhau yêu cầu các khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseshapelock/) là lớp khóa chung cho PPTX. Các loại khóa sau được hỗ trợ trong Aspose.Slides for Python cho PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshapelock/) khóa autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/connectorlock/) khóa các shape connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshapelock/) khóa các group shape.  
- [PictureFrameLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframelock/) khóa các picture frame.  

Mọi hành động được thực hiện trên tất cả các đối tượng shape trong một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) sẽ được áp dụng cho toàn bộ bản trình bày.

## **Áp dụng và Gỡ bỏ Bảo vệ**

Áp dụng bảo vệ đảm bảo rằng một bản trình bày không thể bị chỉnh sửa. Đây là một kỹ thuật hữu ích để bảo vệ nội dung của bản trình bày.

### **Áp dụng Bảo vệ cho Các Shape PPTX**

Aspose.Slides for Python cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) để làm việc với các shape trên slide.

Như đã đề cập ở trên, mỗi lớp shape có một lớp shape-lock tương ứng để bảo vệ. Bài viết này tập trung vào các khóa NoSelect, NoMove và NoResize. Các khóa này đảm bảo rằng các shape không thể được chọn (bằng cách nhấp chuột hoặc các phương pháp chọn khác) và không thể di chuyển hoặc thay đổi kích thước.

Mẫu mã sau đây áp dụng bảo vệ cho tất cả các loại shape trong một bản trình bày.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Duyệt qua tất cả các slide trong bản trình bày.
    for slide in presentation.slides:
        # Duyệt qua tất cả các shape trong slide.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Lưu tệp bản trình bày.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Gỡ bỏ Bảo vệ**

Để mở khóa một shape, đặt giá trị của khóa đã áp dụng thành `False`. Mã mẫu dưới đây cho thấy cách mở khóa các shape trong một bản trình bày đã khóa.

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Duyệt qua tất cả các slide trong bản trình bày.
    for slide in presentation.slides:
        # Duyệt qua tất cả các shape trong slide.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Lưu tệp bản trình bày.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Kết luận**

Aspose.Slides cung cấp một vài tùy chọn để bảo vệ các shape trong một bản trình bày. Bạn có thể khóa một shape riêng lẻ hoặc duyệt qua tất cả các shape trong bản trình bày và khóa từng shape để bảo mật toàn bộ tệp. Bạn có thể gỡ bỏ bảo vệ bằng cách đặt giá trị khóa thành `False`.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa shape và bảo vệ bằng mật khẩu trong cùng một bản trình bày không?**

Có. Các khóa hạn chế việc chỉnh sửa các đối tượng bên trong tệp, trong khi [password protection](/slides/vi/python-net/password-protected-presentation/) kiểm soát quyền truy cập để mở và/hoặc lưu các thay đổi. Các cơ chế này bổ trợ cho nhau và hoạt động đồng thời.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa cho các shape trên các slide đã chọn; các slide còn lại sẽ vẫn có thể chỉnh sửa.

**Các khóa shape có áp dụng cho các đối tượng nhóm và connector không?**

Có. Các loại khóa riêng biệt được hỗ trợ cho nhóm, connector, đối tượng đồ họa và các loại shape khác.