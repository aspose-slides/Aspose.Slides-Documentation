---
title: Aspose.Slides cho Python qua .NET
second_title: Aspose.Slides cho Python
type: docs
weight: 35
url: /vi/python-net/
is_root: true
keywords:
- Aspose.Slides cho Python
- Tự động PowerPoint bằng Python
- Thư viện PPT Python
- Xuất PowerPoint sang PDF bằng Python
- Xuất PowerPoint sang SVG bằng Python
- Chỉnh sửa PowerPoint bằng Python
- PowerPoint Python không cần Microsoft Office
- Quản lý PPTX bằng Python
- Xem trước slides bằng Python
- Python thêm âm thanh vào slides
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides cho Python qua .NET cung cấp một bộ tính năng toàn diện, bao gồm quản lý văn bản, hình dạng, bảng và hoạt ảnh, thêm âm thanh và video vào các slide, xem trước slide, và xuất ra SVG, PDF và nhiều định dạng khác."
---
{{% alert color="primary" %}}

**Chào mừng đến với Aspose.Slides for Python via .NET**

![Logo Sản phẩm Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET là một thư viện lớp mạnh mẽ cho phép các ứng dụng của bạn đọc và ghi các bản trình bày PowerPoint® mà không cần Microsoft PowerPoint®.

Đây là thành phần đầu tiên và duy nhất cung cấp quản lý tài liệu PowerPoint® đầy đủ tính năng cho các nhà phát triển Python.

Aspose.Slides for Python via .NET bao gồm một loạt tính năng như làm việc với văn bản, hình dạng, bảng và hoạt ảnh; thêm âm thanh và video; xem trước các slide; và xuất các slide sang các định dạng như SVG, PDF và nhiều hơn nữa.

{{% /alert %}}

## Cài đặt Aspose.Slides cho Python qua .NET

```bash
pip install aspose.slides
```

Gói này đi kèm với môi trường .NET runtime cần thiết, vì vậy không cần cài đặt gì thêm và không yêu cầu Microsoft PowerPoint. Python 3.7 trở lên trên Windows, Linux hoặc macOS.

## Tạo một bài thuyết trình PowerPoint trong Python

Ví dụ này tạo một bài thuyết trình, thêm một hình dạng có văn bản vào slide đầu tiên, và lưu kết quả dưới dạng PPTX và PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Khi chạy, nó sẽ ghi `presentation.pptx` (khoảng 34 KB) và `presentation.pdf` (khoảng 36 KB) vào thư mục làm việc.

Nếu không có giấy phép, thư viện sẽ chạy ở chế độ đánh giá, thêm dấu watermark và giới hạn số lượng slide. Xem [Cấp phép](/slides/vi/python-net/licensing/) để áp dụng.

## Tài nguyên Aspose.Slides cho Python qua .NET

Khám phá các tài nguyên hữu ích này:

- [Tài liệu trực tuyến Aspose.Slides cho Python qua .NET](/slides/vi/python-net/)
- [Tính năng Aspose.Slides cho Python qua .NET](/slides/vi/python-net/features-overview/)
- [Ghi chú phát hành Aspose.Slides cho Python qua .NET](https://releases.aspose.com/slides/vi/python-net/release-notes/)
- [Trang sản phẩm Aspose.Slides cho Python qua .NET](https://products.aspose.com/slides/vi/python-net/)
- [Tải xuống Aspose.Slides cho Python qua .NET](https://releases.aspose.com/slides/vi/python-net/)
- [Cài đặt gói PyPi Aspose.Slides cho Python qua .NET](https://pypi.org/project/aspose.slides/)
- [Hướng dẫn tham chiếu API Aspose.Slides cho Python qua .NET](https://reference.aspose.com/slides/vi/python-net/)
- [Diễn đàn hỗ trợ miễn phí Aspose.Slides cho Python qua .NET](https://forum.aspose.com/c/slides/vi/11)
- [Trung tâm hỗ trợ trả phí Aspose.Slides cho Python qua .NET](https://helpdesk.aspose.com/)

## Câu hỏi thường gặp

### Aspose.Slides cho Python qua .NET là gì?

Aspose.Slides cho Python qua .NET là một thư viện Python mạnh mẽ cho phép bạn tạo, chỉnh sửa và chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX, ODP) một cách lập trình mà không cần cài đặt Microsoft PowerPoint.

### Các tính năng trình bày nào mà Aspose.Slides hỗ trợ?

Thư viện hỗ trợ quản lý văn bản, hình dạng, bảng, biểu đồ, hoạt ảnh, slide mẫu, âm thanh, video và nhiều hơn nữa. Nó cũng cho phép xem trước slide, render, in ấn và xuất sang các định dạng như PDF, SVG, HTML và hình ảnh.

### Tôi có thể chuyển đổi các bài thuyết trình sang định dạng khác bằng Aspose.Slides không?

Có. Aspose.Slides cho phép chuyển đổi các tệp PowerPoint sang PDF, SVG, HTML, JPG, PNG, TIFF và các định dạng khác với độ chính xác và hiệu năng cao.

### Cần Microsoft PowerPoint để sử dụng Aspose.Slides không?

Không. Aspose.Slides là một API độc lập và không yêu cầu Microsoft Office hay bất kỳ phần mềm bên thứ ba nào.

### Aspose.Slides cho Python qua .NET hỗ trợ những nền tảng nào?

Nó đa nền tảng và hoạt động trên các môi trường Windows, Linux và macOS.

### Làm thế nào để bắt đầu với Aspose.Slides cho Python?

Bạn có thể cài đặt nó qua PyPi và khám phá [Hướng dẫn dành cho nhà phát triển](/slides/vi/python-net/developer-guide/) để bắt đầu với các ví dụ, tài liệu tham khảo API và hướng dẫn.