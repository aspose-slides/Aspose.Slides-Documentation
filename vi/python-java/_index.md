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
- Quản lý bản trình chiếu PowerPoint trong Python
- Đọc và ghi PowerPoint trong Python
- Chỉnh sửa slide PowerPoint trong Python
- Xuất PowerPoint sang PDF trong Python
- Xuất PowerPoint sang SVG trong Python
- Xem trước slide trong Python
- Thêm âm thanh và video vào slide trong Python
- PowerPoint không cần Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Bắt đầu ở đây: cài đặt Aspose.Slides cho Python qua Java, tạo bản trình chiếu đầu tiên, và tìm các hướng dẫn cho các tác vụ thường gặp, tài liệu API và hỗ trợ."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java là một thư viện để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument trong các ứng dụng Python, mà không cần Microsoft PowerPoint; nó chạy động cơ Aspose.Slides Java trong quá trình Python của bạn thông qua JPype.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/python-java/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/python-java/create-presentation/">Tạo bản trình chiếu đầu tiên của bạn</a></li>
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
<p>CÔNG VIỆC THƯỜNG</p>
<ul>
<li><a href="/slides/vi/python-java/open-presentation/">Mở bản trình chiếu</a></li>
<li><a href="/slides/vi/python-java/save-presentation/">Lưu bản trình chiếu</a></li>
<li><a href="/slides/vi/python-java/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/python-java/convert-slide/">Render slide thành hình ảnh</a></li>
<li><a href="/slides/vi/python-java/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH SLIDES</p>
<ul>
<li><a href="/slides/vi/python-java/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/python-java/powerpoint-animation/">Hoạt hình</a></li>
<li><a href="/slides/vi/python-java/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/python-java/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/python-java/merge-presentation/">Ghép bản trình chiếu</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/python-java/examples/">Ví dụ theo yếu tố slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Tham khảo API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/python-java/known-issues/">Vấn đề đã biết</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Tải về</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trung tâm trợ giúp trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản trình chiếu đầu tiên của bạn**

Cài đặt Python và JDK, thiết lập `JAVA_HOME`, và tạo cũng như kích hoạt môi trường ảo như mô tả trong [Installation](/slides/vi/python-java/installation/). Sau đó cài đặt JPype và Aspose.Slides từ PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Lưu đoạn mã này dưới tên *hello.py*. Nó khởi động Máy ảo Java, thêm một hình dạng đám mây với văn bản vào slide đầu tiên của một bản trình chiếu mới, và lưu bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Tạo một bản trình chiếu với một slide trống.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm hình dạng đám mây và đặt văn bản.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chạy nó trong cùng môi trường ảo:

```sh
python hello.py
```

Kịch bản sẽ lưu *new_presentation.pptx* với một slide chứa hình dạng đám mây có văn bản "Hello, Aspose!". Nếu không có giấy phép, tệp đã lưu cũng sẽ có dấu mờ đánh giá — xem [Licensing](/slides/vi/python-java/licensing/). Để biết thêm các cách tạo và điền nội dung vào bản trình chiếu, hãy xem [Create Presentations](/slides/vi/python-java/create-presentation/).