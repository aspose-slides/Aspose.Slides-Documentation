---
title: Chuyển đổi bản trình bày sang nhiều định dạng trong JavaScript
linktitle: Chuyển đổi bản trình bày
type: docs
weight: 70
url: /vi/nodejs-java/convert-presentation/
keywords:
- chuyển đổi bản trình bày
- xuất bản trình bày
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và hơn nữa với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể tải các bản trình bày PowerPoint và OpenDocument và lưu hoặc render chúng sang nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hoặc LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản trình bày sang các tài liệu bố cục cố định như PDF và XPS, xuất bản các slide dưới dạng HTML, hoặc render các slide thành các tệp hình ảnh để xem trước, tạo ảnh thu nhỏ và lưu trữ.

Hầu hết các chuyển đổi tài liệu đều sử dụng cùng một quy trình chung: tải tệp nguồn, chọn định dạng đầu ra yêu cầu và áp dụng các tùy chọn đặc thù của định dạng khi cần. Đối với các định dạng hình ảnh, mỗi slide được render riêng biệt và sau đó được lưu dưới dạng hình raster hoặc vector. Các bài viết chuyên biệt được liên kết dưới đây cung cấp chi tiết thực hiện cho từng trường hợp.

## **Chọn kịch bản chuyển đổi**

Sử dụng các bài viết dưới đây để xem các ví dụ JavaScript đầy đủ và các tùy chọn đặc thù cho từng định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP sang PPTX | Cập nhật các tệp PPT cũ, chuẩn hoá các tệp PPTX hiện có, hoặc chuyển đổi các bản trình bày OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/nodejs-java/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/nodejs-java/convert-odp-to-pptx/), [Lưu bản trình bày](/slides/vi/nodejs-java/save-presentation/) |
| PPTX sang PPT | Lưu một bản trình bày PowerPoint hiện đại sang định dạng nhị phân PPT cũ để tương thích với quy trình làm việc cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP sang PDF | Tạo tài liệu di động, có thể tìm kiếm, bố cục cố định để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP sang PDF có ghi chú | Xuất ghi chú người thuyết trình cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF có Ghi chú](/slides/vi/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP sang HTML | Xuất bản bản trình bày dưới dạng trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục đáp ứng. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP sang HTML5 | Xuất các slide sang HTML5 để xem trên trình duyệt với định dạng và tương tác được bảo toàn. | [Chuyển đổi Bản trình bày sang HTML5](/slides/vi/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP sang PNG | Render mỗi slide thành hình ảnh PNG để xem trước, tạo ảnh thu nhỏ hoặc xuất web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP sang JPG | Render các slide thành hình ảnh JPG và kiểm soát kích thước và chất lượng hình ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide sang SVG | Xuất các slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Render Slide dưới dạng SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP sang XPS | Tạo tài liệu XPS bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP sang TIFF | Lưu bản trình bày dưới dạng tệp TIFF đa trang để in, quét, fax hoặc lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP sang TIFF có ghi chú | Lưu các slide kèm ghi chú người thuyết trình dưới dạng TIFF. | [Chuyển đổi PowerPoint sang TIFF có Ghi chú](/slides/vi/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX sang Markdown | Trích xuất nội dung bản trình bày thành Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP sang XML | Tạo bản trình bày PowerPoint XML dạng văn bản để kiểm tra, so sánh, khắc phục lỗi hoặc quy trình dựa trên XML. | [Chuyển đổi PowerPoint sang XML](/slides/vi/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX sang GIF động | Tạo GIF động từ các slide. | [Chuyển đổi PowerPoint sang GIF động](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX sang video | Xây dựng quy trình xuất video từ các slide của bản trình bày. | [Chuyển đổi PowerPoint sang Video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) |
| Bản trình bày sang XAML | Xuất các slide sang XAML cho các kịch bản UI JavaScript hoặc Java. | [Xuất Bản trình bày sang XAML](/slides/vi/nodejs-java/export-to-xaml/) |

Để xem danh sách đầy đủ hơn các định dạng đầu vào và đầu ra, xem [Các định dạng tệp được hỗ trợ](/slides/vi/nodejs-java/supported-file-formats/).

## **Chuyển đổi PowerPoint và OpenDocument**

Aspose.Slides for Node.js via Java hỗ trợ chuyển đổi từ các định dạng bản trình bày thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. Cùng một API chuyển đổi được sử dụng cho tập tin PowerPoint và OpenDocument, vì vậy một quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ bằng cách thay đổi tệp đầu vào.

Khi chuyển đổi tệp ODP, hãy nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi tính năng bố cục và định dạng một cách giống hệt nhau. Nếu tệp ODP được tạo bằng LibreOffice hoặc OpenOffice Impress, hãy kiểm tra kết quả và sử dụng các tùy chọn được mô tả trong [Chuyển đổi Bản trình bày OpenDocument](/slides/vi/nodejs-java/convert-openoffice-odp/) khi bạn cần hướng dẫn đặc thù cho định dạng.

## **Chuyển đổi PPT sang PPTX**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides for Node.js via Java hỗ trợ chuyển đổi PPT sang PPTX độ trung thực cao đồng thời bảo toàn các cấu trúc trình bày phức tạp như master, layout, slide, biểu đồ, hình dạng nhóm, placeholder, khung văn bản, texture và nền hình ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/nodejs-java/convert-ppt-to-pptx/) và [PPT vs PPTX](/slides/vi/nodejs-java/ppt-vs-pptx/).

## **Xuất bố cục cố định**

PDF, XPS và TIFF hữu ích khi kết quả cần giữ nguyên giao diện trên mọi thiết bị và không được chỉnh sửa như một bản trình bày. Các bài viết chuyên biệt về PDF, XPS và TIFF giải thích cách kiểm soát tuân thủ, slide ẩn, ghi chú, chất lượng hình ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, công bố trên web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide cần trở thành một bản xem trước, ảnh thu nhỏ hoặc tài sản raster riêng biệt. Sử dụng các bài viết về PNG, JPG và SVG để biết hướng dẫn render đặc thù cho từng định dạng.

## **Câu hỏi thường gặp**

**Có cần Microsoft PowerPoint để chuyển đổi bản trình bày không?**

Không. Aspose.Slides for Node.js via Java là một thư viện độc lập và không yêu cầu Microsoft PowerPoint hay tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều bản trình bày không?**

Có. Tải mỗi bản trình bày, lưu nó sang định dạng yêu cầu và giải phóng đối tượng bản trình bày sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện bản trình bày riêng biệt và tham khảo hướng dẫn về [đa luồng](/slides/vi/nodejs-java/multithreading/).

**Tôi có thể xuất chỉ những slide đã chọn không?**

Có. Một số phương pháp xuất cho phép bạn truyền chỉ mục slide hoặc render các slide riêng lẻ, tùy thuộc vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng các cài đặt xuất slide ẩn được mô tả trong các bài viết chuyển đổi [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) và [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn cho việc xuất PDF. Xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) để biết chi tiết.

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, dự phòng phông chữ và cài đặt thay thế phông chữ. Xem [Phông chữ Nhúng](/slides/vi/nodejs-java/embedded-font/), [Phông chữ Dự phòng](/slides/vi/nodejs-java/fallback-font/), và [Thay thế Phông chữ](/slides/vi/nodejs-java/font-substitution/).