---
title: Aspose.Slides cho Node.js qua .NET
second_title: Aspose.Slides cho Node.js
type: docs
weight: 47
url: /vi/nodejs-net/
keywords:
- tài liệu
- xử lý bản trình chiếu
- chuyển đổi bản trình chiếu
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho Node.js qua .NET, tạo bản trình chiếu đầu tiên, và tìm các hướng dẫn cho các tác vụ thường gặp, cấp phép, tham khảo API và hỗ trợ."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides cho Node.js qua .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides cho Node.js qua .NET là một thư viện để tạo, đọc, chỉnh sửa và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument trong các ứng dụng Node.js, mà không cần Microsoft PowerPoint hoặc Office Automation. Nó chạy Aspose.Slides cho .NET thông qua cầu nối edge-js, do đó API JavaScript của nó phản chiếu API .NET, với các tên thành viên camelCase.

Nó tải và lưu PPT, PPTX, PPS, POT và ODP, bao gồm các phiên bản có macro và mẫu, và xuất ra PDF, XPS, HTML, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/nodejs-net/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/nodejs-net/create-presentation/">Tạo bài trình chiếu đầu tiên của bạn</a></li>
<li><a href="/slides/vi/nodejs-net/developer-guide/">Hướng dẫn dành cho nhà phát triển</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/nodejs-net/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/nodejs-net/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC PHỔ BIẾN</p>
<ul>
<li><a href="/slides/vi/nodejs-net/open-presentation/">Mở và lưu một bản trình chiếu</a></li>
<li><a href="/slides/vi/nodejs-net/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/nodejs-net/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/vi/nodejs-net/manage-text/">Chỉnh sửa văn bản</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/vi/net/">Tham khảo API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/vi/nodejs-net/release-notes/">Ghi chú phát hành</a></li>
<li><a href="https://releases.aspose.com/slides/vi/nodejs-net/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/vi/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bài trình chiếu đầu tiên của bạn**

Bạn cần Node.js 22 hoặc 24 và .NET SDK 8 trở lên; Linux cũng cần một vài gói hệ thống. [Installation](/slides/vi/nodejs-net/installation/) liệt kê chúng và các nền tảng đã được kiểm thử. Tạo một dự án, thêm một override để chỉ cho npm phiên bản edge-js nào cần cài đặt, và cài đặt gói:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Một lần cho mỗi máy, khôi phục các gói .NET mà thư viện phụ thuộc. Lưu tệp `deps.csproj` từ [Restore the .NET Dependencies](/slides/vi/nodejs-net/installation/#restore-the-net-dependencies) vào thư mục `deps` trong thư mục dự án, sau đó chạy:

```sh
dotnet restore deps/deps.csproj
```

Lưu đoạn mã này dưới dạng *hello.js* trong thư mục dự án:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Một bản trình chiếu mới chứa một slide trống.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Vị trí và kích thước tính bằng điểm (1/72 inch): x, y, width, height.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Giải phóng đối tượng .NET hỗ trợ bản trình chiếu.
    presentation.dispose();
}
```

Chạy nó từ thư mục dự án:

```sh
node hello.js
```

Kịch bản in ra `Saved hello.pptx` và lưu *hello.pptx* với một slide chứa một hình chữ nhật có văn bản. Nếu không có giấy phép, tệp đã lưu sẽ mang watermark đánh giá — xem [Licensing](/slides/vi/nodejs-net/licensing/). Để biết thêm cách tạo và điền nội dung vào bản trình chiếu, xem [Create a Presentation](/slides/vi/nodejs-net/create-presentation/).