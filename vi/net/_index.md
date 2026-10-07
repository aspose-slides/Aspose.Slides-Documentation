---
title: Aspose.Slides cho .NET
second_title: Aspose.Slides cho .NET
type: docs
weight: 10
url: /vi/net/
keywords:
- tài liệu
- xử lý bản trình bày
- chuyển đổi bản trình bày
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho .NET, tạo bản trình bày đầu tiên, và tìm các hướng dẫn cho các tác vụ thường gặp, triển khai và tài liệu tham chiếu API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET là một thư viện lớp giúp tạo, đọc, chỉnh sửa và chuyển đổi các bài thuyết trình PowerPoint và OpenDocument trong các ứng dụng .NET, mà không cần Microsoft PowerPoint hay Office Automation.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể có macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/vi/net/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/net/create-presentation/">Tạo bài thuyết trình đầu tiên</a></li>
<li><a href="/slides/vi/net/system-requirements/">Yêu cầu hệ thống</a></li>
<li><a href="/slides/vi/net/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/vi/net/supported-file-formats/">Các định dạng file được hỗ trợ</a></li>
<li><a href="/slides/vi/net/features-overview/">Tổng quan tính năng</a></li>
<li><a href="/slides/vi/net/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/net/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/vi/net/open-presentation/">Mở một bài thuyết trình</a></li>
<li><a href="/slides/vi/net/save-presentation/">Lưu một bài thuyết trình</a></li>
<li><a href="/slides/vi/net/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/net/convert-slide/">Kết xuất các slide thành hình ảnh</a></li>
<li><a href="/slides/vi/net/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/vi/net/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/net/powerpoint-animation/">Hoạt ảnh</a></li>
<li><a href="/slides/vi/net/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/net/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/net/merge-presentation/">Gộp các bài thuyết trình</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/vi/net/examples/">Các ví dụ theo phần tử slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Ví dụ trên GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Triển khai &amp; Hỗ trợ</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/vi/net/net6/">Đa nền tảng (.NET 6+)</a></li>
<li><a href="/slides/vi/net/how-to-run-aspose-slides-in-docker/">Chạy trong Docker</a></li>
<li><a href="/slides/vi/net/deploy-fonts/">Phông chữ</a></li>
<li><a href="/slides/vi/net/security/">Bảo mật</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Tài liệu API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/net/known-issues/">Các vấn đề đã biết</a></li>
<li><a href="/slides/vi/net/api-limitations/">Giới hạn siêu dữ liệu đầu ra</a></li>
<li><a href="https://products.aspose.com/slides/net/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Tải xuống</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Hỗ trợ trả phí</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Bài thuyết trình đầu tiên của bạn**

Tạo một ứng dụng console với .NET SDK 6 trở lên:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Sau đó thêm một gói cho nền tảng của bạn:

- Trên Windows: `dotnet add package Aspose.Slides.NET`
- Trên Linux và macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — xem [Installation](/slides/vi/net/installation/) để biết yêu cầu trước cho Linux và các hệ thống cần sử dụng Aspose.Slides.NET thay thế.

Thay thế nội dung của *Program.cs* bằng đoạn mã này và chạy `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Chương trình sẽ lưu *hello.pptx* với một slide chứa một hộp văn bản. Khi không có giấy phép, file đã lưu sẽ có dấu nước đánh giá — xem [Licensing](/slides/vi/net/licensing/). Để biết thêm cách tạo và điền nội dung vào một bài thuyết trình, hãy xem [Create Presentations](/slides/vi/net/create-presentation/).