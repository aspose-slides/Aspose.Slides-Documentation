---
title: Aspose.Slides cho Python qua .NET
second_title: Aspose.Slides cho Python
type: docs
weight: 35
url: /vi/python-net/
is_root: true
keywords:
- Aspose.Slides cho Python
- Tự động hóa PowerPoint bằng Python
- Thư viện PPT Python
- Xuất PowerPoint sang PDF bằng Python
- Xuất PowerPoint sang SVG bằng Python
- Chỉnh sửa PowerPoint trong Python
- PowerPoint Python không cần Microsoft Office
- Quản lý PPTX bằng Python
- Xem trước slide bằng Python
- Python thêm âm thanh vào slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho Python qua .NET, tạo một bản trình chiếu đầu tiên, và tìm các hướng dẫn cho các nhiệm vụ phổ biến, tham chiếu API và hỗ trợ."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides cho Python qua .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET là một thư viện Python để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument, mà không cần Microsoft PowerPoint hay Microsoft Office.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các phiên bản hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>HƯỚNG DẪN BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/python-net/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/python-net/create-presentation/">Tạo bản trình chiếu đầu tiên</a></li>
<li><a href="/slides/vi/python-net/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/python-net/supported-file-formats/">Các định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/python-net/evaluate-aspose-slides/">Các giới hạn dùng thử</a></li>
<li><a href="/slides/vi/python-net/licensing/">Bản quyền</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÁC NHIỆM VỤ THƯỜNG</p>
<ul>
<li><a href="/slides/vi/python-net/open-presentation/">Mở một bản trình chiếu</a></li>
<li><a href="/slides/vi/python-net/save-presentation/">Lưu một bản trình chiếu</a></li>
<li><a href="/slides/vi/python-net/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/python-net/convert-slide/">Kết xuất các slide thành hình ảnh</a></li>
<li><a href="/slides/vi/python-net/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH CÔNG VIỆC VỚI SLIDES</p>
<ul>
<li><a href="/slides/vi/python-net/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/python-net/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/python-net/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/python-net/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/python-net/merge-presentation/">Gộp các bản trình chiếu</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/python-net/examples/">Ví dụ theo thành phần slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Ví dụ trên GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Ghi chú phát hành</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trung tâm hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bài thuyết trình đầu tiên của bạn**

Cài đặt gói từ PyPI:

```bash
pip install aspose.slides
```

Gói này bao gồm môi trường .NET runtime mà nó sử dụng, vì vậy bạn không cần cài đặt .NET. Trên Linux, cũng cần cài đặt các thư viện libgdiplus và ICU, và với Python hệ thống của Debian hoặc Ubuntu, hãy chạy lệnh trong một môi trường ảo. macOS có các yêu cầu bổ sung, và chúng tôi chưa kiểm chứng quá trình cài đặt trên đó. Xem [Installation](/slides/vi/python-net/installation/) để biết các lệnh, yêu cầu trước cho macOS và các phiên bản Python được hỗ trợ.

Lưu đoạn mã này dưới tên *hello.py*:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto-shape loại CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Chạy nó bằng `python hello.py`. Script sẽ lưu *new_presentation.pptx* trong thư mục hiện tại, với một slide chứa hình dạng đám mây có nội dung "Hello, Aspose!". Nếu không có giấy phép, tệp đã lưu sẽ có dấu bản quyền dùng thử — xem [Licensing](/slides/vi/python-net/licensing/). Để biết thêm nhiều cách tạo và lấp đầy một bản trình chiếu, xem [Create Presentations](/slides/vi/python-net/create-presentation/).