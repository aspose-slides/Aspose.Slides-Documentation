---
title: Chuyển đổi PPTX sang PPT trong Python
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/python-net/convert-pptx-to-ppt/
keywords:
- PPTX sang PPT
- chuyển đổi PPTX sang PPT
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- Python
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides cho Python qua .NET—đảm bảo tương thích liền mạch với các định dạng PowerPoint trong khi giữ nguyên bố cục và chất lượng của bản trình chiếu."
---
## **Tổng quan**

Aspose.Slides for Python cho phép bạn chuyển đổi các bản trình chiếu PPTX hiện đại sang định dạng PPT cổ điển hoàn toàn bằng mã. Mở một tệp PPTX và xuất nó dưới dạng PPT trong khi giữ nguyên nội dung và bố cục của bản trình chiếu, khiến kết quả tương thích với các phiên bản PowerPoint cũ hơn. Quy trình làm việc này cũng có thể tạo ra các đầu ra khác—như PDF, XPS, ODP, HTML hoặc hình ảnh—để dễ dàng tích hợp vào các script, pipeline CI và xử lý hàng loạt.

## **Chuyển đổi PPTX sang PPT**

Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Ví dụ Python bên dưới chuyển một bản trình chiếu từ PPTX sang PPT bằng các tùy chọn mặc định.

```py
import aspose.slides as slides

# Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX.
presentation = slides.Presentation("presentation.pptx")

# Lưu bản trình chiếu dưới dạng tệp PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được giữ nguyên khi lưu sang định dạng PPT (97–2003) không?**

Không phải lúc nào cũng vậy. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ: một số hiệu ứng, đối tượng và hành vi), do đó các tính năng có thể bị đơn giản hoá hoặc raster hoá trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ các slide được chọn sang PPT thay vì toàn bộ bản trình chiếu không?**

Lưu trực tiếp sẽ áp dụng cho toàn bộ bản trình chiếu. Để chuyển đổi các slide cụ thể, tạo một bản trình chiếu mới chỉ chứa các slide đó và lưu dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi từng slide.

**Các bản trình chiếu được bảo vệ bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể phát hiện xem tệp có được bảo vệ hay không, mở nó bằng mật khẩu, và cũng có thể [cấu hình cài đặt bảo vệ/mã hóa](/slides/vi/python-net/password-protected-presentation/) cho tệp PPT đã lưu.

**Xem thêm:**
- [Chuyển đổi PPT & PPTX sang PDF trong Python | Tùy chọn nâng cao](/slides/vi/python-net/convert-powerpoint-to-pdf/)
- [Chuyển đổi bản trình chiếu PowerPoint sang XPS trong Python](/slides/vi/python-net/convert-powerpoint-to-xps/)
- [Chuyển đổi bản trình chiếu PowerPoint sang HTML trong Python](/slides/vi/python-net/convert-powerpoint-to-html/)
- [Chuyển đổi các slide PowerPoint sang PNG trong Python](/slides/vi/python-net/convert-powerpoint-to-png/)