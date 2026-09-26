---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /vi/net/
keywords:
- tài liệu
- xử lý bài trình chiếu
- chuyển đổi bài trình chiếu
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho .NET, tạo một bản trình chiếu đầu tiên, và tìm các hướng dẫn cho các tác vụ phổ biến, tham chiếu API và hỗ trợ."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET là một thư viện lớp cho phép tạo, đọc, chỉnh sửa và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument trong các ứng dụng .NET, mà không cần Microsoft PowerPoint hoặc tự động hóa Office.

Nó tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể có macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/net/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/net/create-presentation/">Tạo bản trình chiếu đầu tiên của bạn</a></li>
<li><a href="/slides/vi/net/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/net/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/net/evaluate-aspose-slides/">Giới hạn bản dùng thử</a></li>
<li><a href="/slides/vi/net/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC PHỔ BIẾN</p>
<ul>
<li><a href="/slides/vi/net/open-presentation/">Mở một bản trình chiếu</a></li>
<li><a href="/slides/vi/net/save-presentation/">Lưu một bản trình chiếu</a></li>
<li><a href="/slides/vi/net/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/net/convert-slide/">Kết xuất các slide dưới dạng hình ảnh</a></li>
<li><a href="/slides/vi/net/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH SLIDES</p>
<ul>
<li><a href="/slides/vi/net/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/net/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/net/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/net/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/net/merge-presentation/">Hợp nhất các bản trình chiếu</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/net/examples/">Ví dụ theo phần tử slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Ví dụ trên GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tham khảo &amp; Hỗ trợ</b></p>
<hr>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/vi/net/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/vi/net/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/net/known-issues/">Vấn đề đã biết</a></li>
<li><a href="https://releases.aspose.com/slides/vi/net/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/vi/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Bàn trợ giúp hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

## **Bản trình chiếu đầu tiên của bạn**

Tạo một ứng dụng console bằng .NET SDK 6 hoặc mới hơn:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Sau đó thêm một gói cho nền tảng của bạn:

- Trên Windows:`dotnet add package Aspose.Slides.NET`
- Trên Linux và macOS:`dotnet add package Aspose.Slides.NET6.CrossPlatform` — xem [Installation](/slides/vi/net/installation/) để biết yêu cầu trước cho Linux và các hệ thống cần Aspose.Slides.NET thay thế.

Thay thế nội dung của *Program.cs* bằng mã này và chạy `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Chương trình lưu *hello.pptx* với một slide chứa một hộp văn bản. Nếu không có giấy phép, tệp đã lưu sẽ có dấu mốc đánh giá — xem [Licensing](/slides/vi/net/licensing/). Để biết thêm cách tạo và điền nội dung vào bản trình chiếu, xem [Create Presentations](/slides/vi/net/create-presentation/).