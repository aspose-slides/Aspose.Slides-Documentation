---
title: Chuyển đổi Trình chiếu sang Nhiều Định dạng trên Android
linktitle: Chuyển đổi Trình chiếu
type: docs
weight: 70
url: /vi/androidjava/convert-presentation/
keywords:
- chuyển đổi trình chiếu
- xuất trình chiếu
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và hơn thế nữa với Aspose.Slides cho Android via Java."
---
## **Tổng quan**

Aspose.Slides for Android qua Java có thể tải các bản trình chiếu PowerPoint và OpenDocument và lưu hoặc render chúng ra nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hoặc LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản trình chiếu ra các tài liệu bố cục cố định như PDF và XPS, xuất bản các slide dưới dạng HTML, hoặc render các slide thành các tệp hình ảnh để xem trước, tạo ảnh thu nhỏ và lưu trữ.

Hầu hết các chuyển đổi tài liệu đều sử dụng cùng một quy trình chung: tải tệp nguồn, chọn định dạng đầu ra yêu cầu và áp dụng các tùy chọn riêng cho định dạng khi cần thiết. Đối với các định dạng hình ảnh, mỗi slide được render riêng biệt rồi lưu dưới dạng hình raster hoặc vector. Các bài viết chuyên biệt được liên kết dưới đây cung cấp chi tiết triển khai cho mỗi trường hợp.

## **Chọn Kịch bản Chuyển đổi**

Sử dụng các bài viết dưới đây để có các ví dụ Java đầy đủ và các tùy chọn riêng cho từng định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP sang PPTX | Cập nhật các tệp PPT cũ, chuẩn hoá các tệp PPTX hiện có, hoặc chuyển đổi các bản trình chiếu OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/androidjava/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/androidjava/convert-odp-to-pptx/), [Lưu Trình chiếu](/slides/vi/androidjava/save-presentation/) |
| PPTX sang PPT | Lưu một bản trình chiếu PowerPoint hiện đại dưới định dạng PPT nhị phân cũ để tương thích với các quy trình làm việc cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP sang PDF | Tạo các tài liệu bố cục cố định, có thể mang đi, tìm kiếm được để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP sang PDF có ghi chú | Xuất ghi chú người nói cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF có Ghi chú](/slides/vi/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP sang HTML | Xuất bản các trình chiếu dưới dạng trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục đáp ứng. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP sang HTML5 | Xuất các slide sang HTML5 để xem trên trình duyệt với định dạng và tính tương tác được bảo toàn. | [Chuyển đổi Trình chiếu sang HTML5](/slides/vi/androidjava/export-to-html5/) |
| PPT/PPTX/ODP sang PNG | Render mỗi slide thành hình ảnh PNG để xem trước, tạo ảnh thu nhỏ hoặc xuất ra web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP sang JPG | Render các slide thành hình ảnh JPG và kiểm soát kích thước và chất lượng hình ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/androidjava/convert-powerpoint-to-jpg/) |
| Slide sang SVG | Xuất các slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Render Slide dưới dạng SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP sang XPS | Tạo các tài liệu XPS bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP sang TIFF | Lưu một bản trình chiếu dưới dạng tệp TIFF nhiều trang để in ấn, quét, fax hoặc quy trình lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP sang TIFF có ghi chú | Lưu các slide kèm ghi chú người nói thành TIFF. | [Chuyển đổi PowerPoint sang TIFF có Ghi chú](/slides/vi/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX sang Word | Chuyển đổi các slide sang tài liệu Word khi bạn cần đầu ra dạng tài liệu. | [Chuyển đổi PowerPoint sang Word](/slides/vi/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX sang Markdown | Trích xuất nội dung trình chiếu thành Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX sang GIF động | Tạo GIF động từ các slide. | [Chuyển đổi PowerPoint sang GIF động](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX sang video | Xây dựng quy trình xuất video từ các slide trình chiếu. | [Chuyển đổi PowerPoint sang Video](/slides/vi/androidjava/convert-powerpoint-to-video/) |
| Trình chiếu sang XAML | Xuất các slide sang XAML cho các kịch bản UI trên Android hoặc Java. | [Xuất Trình chiếu sang XAML](/slides/vi/androidjava/export-to-xaml/) |

Để xem danh sách đầy đủ các định dạng đầu vào và đầu ra, xem [Định dạng tệp được hỗ trợ](/slides/vi/androidjava/supported-file-formats/).

## **Chuyển đổi PowerPoint và OpenDocument**

Aspose.Slides for Android qua Java hỗ trợ chuyển đổi từ các định dạng trình chiếu thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. cùng một API chuyển đổi được dùng cho các tệp PowerPoint và OpenDocument, vì vậy một quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ bằng cách thay đổi tệp đầu vào.

Khi chuyển đổi các tệp ODP, hãy nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi tính năng bố cục và định dạng một cách giống hệt nhau. Nếu tệp ODP được tạo bằng LibreOffice hoặc OpenOffice Impress, hãy kiểm tra kết quả và sử dụng các tùy chọn được mô tả trong [Chuyển đổi Trình chiếu OpenDocument](/slides/vi/androidjava/convert-openoffice-odp/) khi bạn cần hướng dẫn riêng cho định dạng.

## **Chuyển đổi PPT sang PPTX**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides for Android qua Java hỗ trợ chuyển đổi PPT sang PPTX với độ trung thực cao, đồng thời bảo toàn các cấu trúc trình chiếu phức tạp như master, layout, slide, biểu đồ, nhóm hình dạng, placeholder, khung văn bản, texture và màu nền hình ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/androidjava/convert-ppt-to-pptx/) và [PPT so với PPTX](/slides/vi/androidjava/ppt-vs-pptx/).

## **Xuất Bố cục Cố định**

PDF, XPS và TIFF hữu ích khi đầu ra cần giữ cùng một giao diện trên mọi thiết bị và không được chỉnh sửa như một bản trình chiếu. Các bài viết chuyên biệt về PDF, XPS và TIFF giải thích cách kiểm soát tính tuân thủ, các slide ẩn, ghi chú, chất lượng hình ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, xuất bản web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide cần trở thành một bản xem trước, ảnh thu nhỏ hoặc tài sản raster riêng biệt. Sử dụng các bài viết về PNG, JPG và SVG để được hướng dẫn render riêng cho từng định dạng.

## **Câu hỏi thường gặp**

**Tôi có cần Microsoft PowerPoint để chuyển đổi trình chiếu không?**

Không. Aspose.Slides for Android qua Java là một thư viện độc lập và không yêu cầu Microsoft PowerPoint hoặc tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều trình chiếu không?**

Có. Tải mỗi trình chiếu, lưu nó sang định dạng yêu cầu và giải phóng đối tượng trình chiếu sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện trình chiếu riêng biệt và tuân theo hướng dẫn [đa luồng](/slides/vi/androidjava/multithreading/).

**Tôi có thể xuất chỉ các slide đã chọn không?**

Có. Một số phương pháp xuất cho phép bạn truyền chỉ số slide hoặc render các slide riêng lẻ, tùy thuộc vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng các cài đặt xuất slide ẩn được mô tả trong các bài viết chuyển đổi [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) và [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn cho việc xuất PDF. Xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) để biết chi tiết.

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, phông chữ dự phòng và cài đặt thay thế phông chữ. Xem [Phông chữ nhúng](/slides/vi/androidjava/embedded-font/), [Phông chữ dự phòng](/slides/vi/androidjava/fallback-font/) và [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/).