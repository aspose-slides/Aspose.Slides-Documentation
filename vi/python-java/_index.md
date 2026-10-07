---
title: Aspose.Slides cho Python qua Java
second_title: Aspose.Slides cho Python
type: docs
weight: 47
url: /vi/python-java/
is_root: true
keywords:
- Aspose.Slides cho Python qua Java
- Thư viện PowerPoint cho Python
- quản lý các bài thuyết trình PowerPoint trong Python
- đọc và ghi PowerPoint trong Python
- chỉnh sửa slide PowerPoint trong Python
- xuất PowerPoint sang PDF trong Python
- xuất PowerPoint sang SVG trong Python
- xem trước slide trong Python
- thêm audio và video vào slide trong Python
- PowerPoint mà không cần Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho Python qua Java, tạo một bài thuyết trình đầu tiên, và tìm các hướng dẫn cho các nhiệm vụ chung, tham chiếu API và hỗ trợ."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides cho Python qua Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides cho Python qua Java là một thư viện để tạo, đọc, chỉnh sửa và chuyển đổi các bài thuyết trình PowerPoint và OpenDocument trong các ứng dụng Python, không cần Microsoft PowerPoint; nó chạy engine Aspose.Slides Java trong tiến trình Python của bạn thông qua JPype.

Thư viện này tải và lưu PPT, PPTX, PPS, POT và ODP, bao gồm các phiên bản hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/python-java/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/python-java/create-presentation/">Tạo bài thuyết trình đầu tiên của bạn</a></li>
<li><a href="/slides/vi/python-java/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/python-java/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/python-java/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/python-java/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC CHUNG</p>
<ul>
<li><a href="/slides/vi/python-java/open-presentation/">Mở một bài thuyết trình</a></li>
<li><a href="/slides/vi/python-java/save-presentation/">Lưu một bài thuyết trình</a></li>
<li><a href="/slides/vi/python-java/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/python-java/convert-slide/">Render các slide thành hình ảnh</a></li>
<li><a href="/slides/vi/python-java/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH SLIDES</p>
<ul>
<li><a href="/slides/vi/python-java/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/python-java/powerpoint-animation/">Hoạt hình</a></li>
<li><a href="/slides/vi/python-java/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/python-java/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/python-java/merge-presentation/">Hợp nhất các bài thuyết trình</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/python-java/examples/">Ví dụ theo thành phần slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham chiếu &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/python-java/known-issues/">Vấn đề đã biết</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Bàn trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bài thuyết trình đầu tiên của bạn**

Cài đặt Python và JDK, đặt `JAVA_HOME`, rồi tạo và kích hoạt môi trường ảo như mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Sau đó cài đặt JPype và Aspose.Slides từ PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Lưu mã này thành *hello.py*. Nó khởi động Máy ảo Java, thêm một hình dạng đám mây có văn bản vào slide đầu tiên của một bài thuyết trình mới và lưu lại bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Tạo một bài thuyết trình với một slide trống.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm hình dạng đám mây và đặt văn bản cho nó.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Lưu bài thuyết trình dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chạy nó trong cùng môi trường ảo:

```sh
python hello.py
```

Script sẽ lưu *new_presentation.pptx* với một slide chứa hình dạng đám mây và văn bản “Hello, Aspose!”. Không có giấy phép, tệp đã lưu sẽ có dấu watermark đánh giá — xem [Cấp phép](/slides/vi/python-java/licensing/). Để biết thêm cách tạo và điền nội dung cho một bài thuyết trình, xem [Tạo Bài thuyết trình](/slides/vi/python-java/create-presentation/).