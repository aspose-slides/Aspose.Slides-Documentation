---
title: Chuyển Đổi Bản Trình Chiếu Sang Nhiều Định Dạng trong .NET
linktitle: Chuyển Đổi Bản Trình Chiếu
type: docs
weight: 70
url: /vi/net/convert-presentation/
keywords:
- chuyển đổi bản trình chiếu
- xuất bản trình chiếu
- PPT sang PPTX
- PPTX sang PPT
- ODP sang PPTX
- PPT sang PDF
- PPTX sang PDF
- ODP sang PDF
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- PPT sang PNG
- PPTX sang PNG
- ODP sang PNG
- PPTX sang JPG
- ODP sang JPG
- PPT sang XPS
- PPTX sang XPS
- ODP sang XPS
- PPT sang TIFF
- PPTX sang TIFF
- ODP sang TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và nhiều định dạng khác với Aspose.Slides for .NET."
---
## **Tổng quan**

Aspose.Slides for .NET có thể tải các bản trình chiếu PowerPoint và OpenDocument và lưu hoặc render chúng sang nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hay LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản trình chiếu sang các tài liệu bố cục cố định như PDF và XPS, công bố các slide dưới dạng HTML, hoặc render các slide thành các tệp hình ảnh để làm preview, thumbnail và lưu trữ.

Hầu hết các chuyển đổi tài liệu sử dụng quy trình chung: tải tệp nguồn, chọn định dạng đầu ra mong muốn và áp dụng các tùy chọn đặc thù cho định dạng khi cần. Đối với các định dạng hình ảnh, mỗi slide được render riêng biệt và sau đó lưu dưới dạng ảnh raster hoặc vector. Các bài viết chuyên biệt được liên kết bên dưới cung cấp chi tiết triển khai cho từng trường hợp.

## **Chọn Kịch bản Chuyển đổi**

Sử dụng các bài viết dưới đây để có các ví dụ C# hoàn chỉnh và các tùy chọn đặc thù cho từng định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Cập nhật các tệp PPT lạc hậu, chuẩn hoá các tệp PPTX hiện có, hoặc chuyển đổi bản trình chiếu OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/net/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/net/convert-odp-to-pptx/), [Lưu Trình chiếu](/slides/vi/net/save-presentation/) |
| PPTX to PPT | Lưu một bản trình chiếu PowerPoint hiện đại sang định dạng nhị phân PPT cũ để tương thích với quy trình làm việc cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Tạo các tài liệu bố cục cố định, có thể tìm kiếm, để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Xuất ghi chú người thuyết trình cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF với Ghi chú](/slides/vi/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Công bố trình chiếu dưới dạng các trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục đáp ứng. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Xuất slide sang HTML5 để xem trên trình duyệt với định dạng và tính tương tác được bảo lưu. | [Xuất Trình chiếu sang HTML5](/slides/vi/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Render mỗi slide thành ảnh PNG để preview, thumbnail hoặc xuất web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Render slide thành ảnh JPG và kiểm soát kích thước và chất lượng ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Xuất các slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Render Slide dưới dạng SVG](/slides/vi/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Tạo các tài liệu XPS có bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Lưu trình chiếu dưới dạng tệp TIFF đa trang cho in ấn, quét, fax hoặc quy trình lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Lưu slide có ghi chú người thuyết trình sang TIFF. | [Chuyển đổi PowerPoint sang TIFF với Ghi chú](/slides/vi/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Chuyển đổi slide sang tài liệu Word khi bạn cần đầu ra dạng tài liệu. | [Chuyển đổi PowerPoint sang Word](/slides/vi/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Trích xuất nội dung trình chiếu sang Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Tạo GIF động từ các slide. | [Chuyển đổi PowerPoint sang GIF động](/slides/vi/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Xây dựng quy trình xuất video từ các slide trình chiếu. | [Chuyển đổi PowerPoint sang Video](/slides/vi/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Xuất slide sang XAML cho các kịch bản giao diện .NET. | [Xuất Trình chiếu sang XAML](/slides/vi/net/export-to-xaml/) |

Đối với danh sách rộng hơn các định dạng đầu vào và đầu ra, xem [Định dạng Tệp được Hỗ trợ](/slides/vi/net/supported-file-formats/).

## **Chuyển đổi PowerPoint và OpenDocument**

Aspose.Slides for .NET hỗ trợ chuyển đổi từ các định dạng trình chiếu thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. Cùng một API chuyển đổi được dùng cho các tệp PowerPoint và OpenDocument, vì vậy một quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ bằng cách thay đổi tệp đầu vào.

Khi chuyển đổi tệp ODP, hãy nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi bố cục và tính năng định dạng một cách giống hệt nhau. Nếu tệp ODP được tạo bằng LibreOffice hoặc OpenOffice Impress, hãy kiểm tra kết quả và sử dụng các tùy chọn được mô tả trong [Chuyển đổi Bản trình chiếu OpenDocument](/slides/vi/net/convert-openoffice-odp/) khi cần hướng dẫn chi tiết cho định dạng.

## **Chuyển đổi PPT sang PPTX**

PPT là định dạng nhị phân PowerPoint cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides for .NET hỗ trợ chuyển đổi PPT sang PPTX với độ trung thực cao đồng thời giữ nguyên các cấu trúc phức tạp của trình chiếu như master, layout, slide, biểu đồ, nhóm hình dạng, placeholder, khung văn bản, texture và fill ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/net/convert-ppt-to-pptx/) và [PPT vs PPTX](/slides/vi/net/ppt-vs-pptx/).

## **Xuất định dạng cố định**

PDF, XPS và TIFF hữu ích khi đầu ra cần giữ nguyên hình ảnh trên mọi thiết bị và không được chỉnh sửa như một bản trình chiếu. Sử dụng [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions/) và [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/) để kiểm soát tính tuân thủ, slide ẩn, ghi chú, chất lượng ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, công bố web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide phải trở thành một preview, thumbnail hoặc tài sản raster riêng biệt. Sử dụng các bài viết PNG, JPG và SVG để biết hướng dẫn render chi tiết cho từng định dạng.

## **Câu hỏi thường gặp**

**Tôi có cần Microsoft PowerPoint để chuyển đổi trình chiếu không?**

Không. Aspose.Slides for .NET là thư viện độc lập và không yêu cầu Microsoft PowerPoint hay tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều trình chiếu không?**

Có. Tải mỗi trình chiếu, lưu nó sang định dạng yêu cầu và giải phóng đối tượng `Presentation` sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện trình chiếu riêng biệt và tuân theo hướng dẫn về [đa luồng](/slides/vi/net/multithreading/).

**Tôi có thể xuất chỉ một số slide đã chọn không?**

Có. Một số phương pháp xuất cho phép bạn truyền chỉ số slide hoặc render các slide riêng lẻ, tùy vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng thuộc tính `ShowHiddenSlides` trong [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) hoặc [XpsOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/xpsoptions/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn qua [PdfOptions.Compliance](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/compliance/) và [PdfCompliance](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfcompliance/).

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, fallback phông chữ và cài đặt thay thế phông chữ. Xem [Phông chữ Nhúng](/slides/vi/net/embedded-font/), [Phông chữ Thay thế](/slides/vi/net/fallback-font/) và [Thay thế Phông chữ](/slides/vi/net/font-substitution/).