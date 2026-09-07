---
title: Chuyển đổi PPTX sang PPT trong Python
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/python-java/convert-pptx-to-ppt/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPTX
- PPTX sang PPT
- lưu PPTX dưới dạng PPT
- xuất PPTX sang PPT
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi PPTX sang định dạng PPT cổ điển trong Python bằng Aspose.Slides cho Python thông qua Java. Bao gồm ví dụ mã và ghi chú về khả năng tương thích và tệp được bảo vệ."
---
## **Tổng quan**

Aspose.Slides cho Python thông qua Java cho phép bạn chuyển đổi một bản trình chiếu PPTX sang định dạng PPT cổ điển được sử dụng bởi PowerPoint 97–2003 mà không cần cài đặt Microsoft PowerPoint. Tải tệp PPTX và lưu nó dưới định dạng đầu ra PPT, như dưới đây.

## **Chuyển đổi PPTX sang PPT**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) , sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với đường dẫn đầu ra và [SaveFormat.Ppt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Ppt) .

Ví dụ sau sẽ khởi động máy ảo Java nếu cần và chuyển đổi `template.pptx` sang `output.ppt` bằng các tùy chọn mặc định. Thay đổi các đường dẫn bằng tên tệp của bạn. Khối `finally` giải phóng tài nguyên bản trình chiếu ngay cả khi việc lưu thất bại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tải bản trình chiếu PPTX.
presentation = Presentation("template.pptx")
try:
    # Lưu bản trình chiếu ở định dạng PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Tham số [SaveFormat.Ppt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Ppt) lựa chọn định dạng đầu ra; chỉ thay đổi phần mở rộng của tệp không chuyển đổi bản trình chiếu. Giữ lại tệp PPTX gốc để bạn có thể quay lại nếu một tính năng mới không có tương đương trong PPT.

## **Chuyển đổi PPTX sang các Định dạng Khác**

Aspose.Slides cũng hỗ trợ các định dạng đầu ra khác. Xem các bài viết tương ứng để biết các tùy chọn và ví dụ riêng cho từng định dạng:

- [Chuyển đổi PowerPoint sang PDF trong Python](/slides/vi/python-java/convert-powerpoint-to-pdf/)
- [Chuyển đổi PowerPoint sang XPS trong Python](/slides/vi/python-java/convert-powerpoint-to-xps/)
- [Chuyển đổi PowerPoint sang HTML trong Python](/slides/vi/python-java/convert-powerpoint-to-html/)
- [Lưu Bản trình chiếu dưới dạng ODP trong Python](/slides/vi/python-java/save-presentation/)
- [Chuyển đổi PowerPoint sang PNG trong Python](/slides/vi/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Tất cả các hiệu ứng và tính năng PPTX có được giữ nguyên sau khi chuyển đổi sang PPT không?**

Không luôn luôn. Định dạng PPT cổ điển không hỗ trợ mọi tính năng có trong PPTX. Một số hiệu ứng, đối tượng hoặc hành vi có thể được đơn giản hoá hoặc hiển thị khác nhau. Hãy xem lại bản trình chiếu đã chuyển đổi trong trình xem dự định, đặc biệt khi nó chứa các tính năng PowerPoint mới.

**Tôi có thể chuyển đổi chỉ các slide đã chọn sang PPT không?**

Lưu sang PPT sẽ ghi toàn bộ bản trình chiếu. Để chuyển đổi chỉ các slide đã chọn, tạo một bản trình chiếu mới, xóa slide trống đầu tiên, sao chép các slide cần thiết vào đó, và lưu nó dưới dạng PPT. Xem [Clone Slides in Python](/slides/vi/python-java/clone-slides/) .

**Tôi có thể chuyển đổi tệp PPTX được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải bản trình chiếu nguồn. Bạn cũng có thể cấu hình bảo vệ cho tệp đầu ra. Xem [Password-Protected Presentations](/slides/vi/python-java/password-protected-presentation/) .