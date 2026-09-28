---
title: Tổng quan các tính năng
type: docs
weight: 94
url: /vi/net/features-overview/
keywords:
- tính năng
- nền tảng được hỗ trợ
- định dạng tệp
- chuyển đổi
- kết xuất
- nội dung bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem lại những gì Aspose.Slides for .NET bao gồm trước khi bạn đánh giá nó: các nền tảng được hỗ trợ, định dạng tệp, kết xuất slide, và nội dung bạn có thể tạo và chỉnh sửa."
---
## **Tổng quan**

Aspose.Slides for .NET là một thư viện lớp để tạo, đọc, chỉnh sửa, chuyển đổi và hiển thị các bản trình chiếu PowerPoint và OpenDocument. Thư viện không có giao diện người dùng riêng và không yêu cầu Microsoft PowerPoint hay Office, vì vậy bạn có thể sử dụng nó trong các ứng dụng console, ứng dụng desktop như Windows Forms, ứng dụng web và dịch vụ web. Bài viết này tóm tắt những gì thư viện hỗ trợ và liên kết tới các bài viết mô tả từng lĩnh vực.

## **Nền tảng được hỗ trợ**

Aspose.Slides for .NET được phân phối dưới dạng hai gói NuGet có cùng API:

|**Gói**|**Bản dựng trong gói**|**Hệ điều hành**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 và .NET 6. Sử dụng với .NET Framework 4.6.2 trở lên, hoặc với .NET 6 trở lên.|Windows. Linux và macOS với thư viện `libgdiplus` và tùy chọn `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Sử dụng với .NET 6 trở lên.|Windows (x86, x64), Linux (x64 với glibc 2.23 hoặc mới hơn, ARM64 với glibc 2.39 hoặc mới hơn), và macOS (x64, ARM64).|

[Installation](/slides/vi/net/installation/) giải thích cách chọn gói và những yêu cầu trên Linux cho mỗi gói. [System Requirements](/slides/vi/net/system-requirements/) liệt kê chi tiết các nền tảng được hỗ trợ.

## **Định dạng tệp và chuyển đổi**

Aspose.Slides mở và lưu các bản trình chiếu PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP và PowerPoint XML. Nó nhập nội dung PDF và HTML vào các slide, và lưu bản trình chiếu dưới dạng PDF, XPS, HTML, HTML5, TIFF, GIF hoạt hình, SWF, Markdown và XAML. [Supported File Formats](/slides/vi/net/supported-file-formats/) liệt kê mọi định dạng cùng với API đọc/ghi tương ứng.

|**Tính năng**|**Mô tả**|
| :- | :- |
|[PPT and PPTX](/slides/vi/net/ppt-vs-pptx/)|Đọc và ghi cả định dạng PowerPoint nhị phân 97-2003 và định dạng Office Open XML.|
|[PPT to PPTX conversion](/slides/vi/net/convert-ppt-to-pptx/)|Chuyển đổi các bản trình chiếu PPT cũ sang PPTX.|
|[Portable Document Format (PDF)](/slides/vi/net/convert-powerpoint-to-pdf/)|Xuất bản trình chiếu ra PDF, bao gồm tài liệu PDF/A và PDF/UA.|
|[XML Paper Specification (XPS)](/slides/vi/net/convert-powerpoint-to-xps/)|Xuất bản trình chiếu ra tài liệu XPS.|
|[Tagged Image File Format (TIFF)](/slides/vi/net/convert-powerpoint-to-tiff/)|Xuất bản trình chiếu ra hình ảnh TIFF.|
|[HTML](/slides/vi/net/convert-powerpoint-to-html/)|Xuất bản trình chiếu ra HTML và HTML5.|
|[PDF and HTML import](/slides/vi/net/import-presentation/)|Tạo các slide từ các trang PDF và nội dung HTML.|

## **Kết xuất bản trình chiếu**

Aspose.Slides kết xuất các slide và các hình dạng riêng lẻ dưới dạng PNG, JPEG, BMP, GIF, TIFF và SVG, và các slide dưới dạng tệp metafile EMF. Xem [Convert Presentation Slides to Images](/slides/vi/net/convert-slide/), [Render a Slide as an SVG Image](/slides/vi/net/render-a-slide-as-an-svg-image/) và [Create Shape Thumbnails](/slides/vi/net/create-shape-thumbnails/).

## **Các tính năng nội dung**

Aspose.Slides cho phép bạn tạo, đọc và chỉnh sửa hầu hết mọi nội dung của một bản trình chiếu:

|**Khu vực**|**Bạn có thể làm gì**|
| :- | :- |
|[Slides](/slides/vi/net/presentation-slide/)|Thêm, sao chép, sắp xếp lại và xóa slide; áp dụng bố cục và mẫu; tổ chức slide thành các phần; thay đổi kích thước slide.|
|[Design](/slides/vi/net/presentation-design/)|Đặt nền, màu chủ đề, header và footer, và phông chữ.|
|[Text](/slides/vi/net/manage-text/)|Tạo và chỉnh sửa khung văn bản, đoạn văn và phần; đặt phông chữ, màu sắc, dấu đầu dòng và căn chỉnh; tìm và thay thế văn bản.|
|[Shapes](/slides/vi/net/powerpoint-shapes/)|Tạo AutoShapes, đường thẳng, kết nối, nhóm hình dạng và khung hình ảnh; đặt vị trí, kích thước, đường viền và màu nền đặc, gradient hoặc mẫu; tìm hình dạng bằng văn bản thay thế.|
|[Tables](/slides/vi/net/powerpoint-table/), [charts](/slides/vi/net/powerpoint-charts/), and [SmartArt](/slides/vi/net/powerpoint-smartart/)|Tạo và chỉnh sửa bảng, biểu đồ Microsoft Office và sơ đồ SmartArt.|
|[Media](/slides/vi/net/manage-media-files/), [OLE objects](/slides/vi/net/manage-ole/), and [ActiveX controls](/slides/vi/net/activex/)|Thêm khung âm thanh và video được nhúng hoặc liên kết, nhúng đối tượng OLE, và thêm, chỉnh sửa hoặc xóa điều khiển ActiveX.|
|[Notes](/slides/vi/net/presentation-notes/) and [comments](/slides/vi/net/presentation-comments/)|Thêm, đọc và chỉnh sửa ghi chú diễn giả và bình luận xem xét.|
|[Animation](/slides/vi/net/powerpoint-animation/) and [transitions](/slides/vi/net/slide-transition/)|Áp dụng hiệu ứng hoạt hình cho các hình dạng, đặt chuyển tiếp slide và cấu hình cài đặt trình chiếu.|
|[Security](/slides/vi/net/presentation-security/)|Mã hóa bản trình chiếu bằng mật khẩu, đặt bảo vệ ghi và làm việc với chữ ký số.|
|[VBA macros](/slides/vi/net/presentation-via-vba/)|Thêm, trích xuất và xóa mô-đun VBA trong các bản trình chiếu hỗ trợ macro.|
|[Properties](/slides/vi/net/presentation-properties/)|Đọc và chỉnh sửa thuộc tính tài liệu.|

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint trên máy chủ hoặc PC để thư viện hoạt động không?**

Không. PowerPoint không bắt buộc; Aspose.Slides là một engine độc lập để tạo, chỉnh sửa, chuyển đổi và kết xuất bản trình chiếu.

**Đa luồng hoạt động như thế nào? Có thể xử lý song song không?**

An toàn khi xử lý các tài liệu khác nhau trên các luồng riêng biệt; cùng một đối tượng [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) không được sử dụng bởi [multiple threads](/slides/vi/net/multithreading/) đồng thời.

**Có hỗ trợ mật khẩu tệp và mã hóa không?**

Có. [You can](/slides/vi/net/password-protected-presentation/) mở các bản trình chiếu được mã hóa, đặt hoặc xóa mật khẩu mở và ghi, và kiểm tra trạng thái bảo vệ.

**Tôi có cần quan tâm đến phông chữ trong các container Linux không?**

Có. Các phông chữ được sử dụng trong bản trình chiếu của bạn, hoặc các phông chữ thay thế phù hợp, phải được cài đặt trên hệ thống để văn bản hiển thị đúng. Bạn cũng có thể [specify font directories](/slides/vi/net/custom-font/) trong ứng dụng của mình. [Installation](/slides/vi/net/installation/) liệt kê các yêu cầu trước của Linux cho mỗi gói.

**Có giới hạn nào trong phiên bản đánh giá không?**

Có. Khi không có [license](/slides/vi/net/licensing/), Aspose.Slides thêm dấu bản quyền đánh giá vào mỗi slide được lưu và cắt ngắn văn bản đọc từ bản trình chiếu. Một [30-day temporary license](https://purchase.aspose.com/temporary-license/) có sẵn để thử nghiệm đầy đủ tính năng.

**Có hỗ trợ nhập định dạng ngoại vi vào bản trình chiếu (PDF hoặc HTML sang PPTX) không?**

Có. Bạn có thể thêm [PDF pages and HTML content](/slides/vi/net/import-presentation/) vào bản trình chiếu, chuyển chúng thành các slide.