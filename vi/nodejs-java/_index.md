---
title: Aspose.Slides cho Node.js qua Java
second_title: Aspose.Slides cho Node.js
type: docs
weight: 47
url: /vi/nodejs-java/
keywords:
- tài liệu
- xử lý bài thuyết trình
- chuyển đổi bài thuyết trình
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho Node.js qua Java, tạo một bài thuyết trình đầu tiên, và tìm các hướng dẫn cho các nhiệm vụ phổ biến, tham khảo API và hỗ trợ."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides cho Node.js qua Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides cho Node.js qua Java là một thư viện để tạo, đọc, chỉnh sửa và chuyển đổi các bài thuyết trình PowerPoint và OpenDocument trong các ứng dụng Node.js, mà không cần Microsoft PowerPoint.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các phiên bản hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/nodejs-java/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/nodejs-java/create-presentation/">Tạo bài thuyết trình đầu tiên của bạn</a></li>
<li><a href="/slides/vi/nodejs-java/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/nodejs-java/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/nodejs-java/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/nodejs-java/licensing/">Giấy phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC THƯỜNG</p>
<ul>
<li><a href="/slides/vi/nodejs-java/open-presentation/">Mở một bài thuyết trình</a></li>
<li><a href="/slides/vi/nodejs-java/save-presentation/">Lưu một bài thuyết trình</a></li>
<li><a href="/slides/vi/nodejs-java/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/nodejs-java/convert-slide/">Kết xuất các slide dưới dạng hình ảnh</a></li>
<li><a href="/slides/vi/nodejs-java/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH SLIDE</p>
<ul>
<li><a href="/slides/vi/nodejs-java/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/nodejs-java/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/nodejs-java/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/nodejs-java/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/nodejs-java/merge-presentation/">Hợp nhất các bài thuyết trình</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/nodejs-java/examples/">Ví dụ theo phần tử slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Tham khảo API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/nodejs-java/known-issues/">Vấn đề đã biết</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bài thuyết trình đầu tiên của bạn**

Ngoài Node.js 20 trở lên, gói này yêu cầu một Java Development Kit (JDK), Python và một chuỗi công cụ xây dựng C++, vì npm biên dịch cầu nối `java` trong quá trình cài đặt. Xem [Cài đặt](/slides/vi/nodejs-java/installation/) để biết các bước trên mỗi hệ điều hành. Sau đó tạo một dự án và cài đặt gói từ npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Lưu đoạn mã này dưới dạng *hello.js* trong thư mục dự án:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides chạy trong một máy ảo Java giữ cho Node.js tiếp tục chạy, vì vậy hãy kết thúc tiến trình một cách rõ ràng.
process.exit(0);
```

Chạy nó bằng `node hello.js`. Kịch bản sẽ lưu *hello.pptx* với một slide chứa hộp văn bản. Nếu không có giấy phép, tệp đã lưu sẽ có dấu bản quyền đánh dấu — xem [Giấy phép](/slides/vi/nodejs-java/licensing/). Để biết thêm cách tạo và điền nội dung cho một bài thuyết trình, xem [Tạo bài thuyết trình](/slides/vi/nodejs-java/create-presentation/).