---
title: Chuyển đổi bản trình bày sang nhiều định dạng trong Java
linktitle: Chuyển đổi bản trình bày
type: docs
weight: 70
url: /vi/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và hơn thế nữa với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides cho Java có thể tải các bản trình bày PowerPoint và OpenDocument và lưu hoặc xuất chúng sang nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hoặc LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản trình bày sang các tài liệu bố cục cố định như PDF và XPS, công bố các slide dưới dạng HTML, hoặc xuất slide thành các tệp hình ảnh để xem trước, ảnh thu nhỏ và lưu trữ.

Hầu hết các chuyển đổi tài liệu sử dụng cùng một quy trình chung: tải tệp nguồn, chọn định dạng đầu ra yêu cầu và áp dụng các tùy chọn đặc thù cho định dạng khi cần. Đối với các định dạng hình ảnh, mỗi slide được kết xuất riêng biệt và sau đó được lưu dưới dạng ảnh raster hoặc vector. Các bài viết chuyên biệt được liên kết bên dưới cung cấp chi tiết triển khai cho mỗi trường hợp.

## **Chọn kịch bản chuyển đổi**

Sử dụng các bài viết dưới đây để có các ví dụ Java đầy đủ và các tùy chọn đặc thù cho định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP sang PPTX | Cập nhật các tệp PPT cũ, chuẩn hóa các tệp PPTX hiện có, hoặc chuyển đổi các bản trình bày OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/java/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/java/convert-odp-to-pptx/), [Lưu bản trình bày](/slides/vi/java/save-presentation/) |
| PPTX sang PPT | Lưu bản trình bày PowerPoint hiện đại sang định dạng nhị phân PPT cũ để tương thích với các quy trình làm việc cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP sang PDF | Tạo tài liệu di động, có thể tìm kiếm, bố cục cố định để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP sang PDF có ghi chú | Xuất ghi chú người thuyết trình cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF với Ghi chú](/slides/vi/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP sang HTML | Xuất bản bản trình bày dưới dạng trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục phản hồi. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP sang HTML5 | Xuất slide sang HTML5 để xem trên trình duyệt với định dạng và tính tương tác được giữ nguyên. | [Chuyển đổi bản trình bày sang HTML5](/slides/vi/java/export-to-html5/) |
| PPT/PPTX/ODP sang PNG | Kết xuất mỗi slide thành ảnh PNG để xem trước, ảnh thu nhỏ hoặc xuất ra web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP sang JPG | Kết xuất slide thành ảnh JPG và kiểm soát kích thước và chất lượng ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/java/convert-powerpoint-to-jpg/) |
| Slide sang SVG | Xuất slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Kết xuất Slide dưới dạng SVG](/slides/vi/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP sang XPS | Tạo tài liệu XPS với bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP sang TIFF | Lưu bản trình bày dưới dạng tệp TIFF đa trang cho in ấn, quét, fax hoặc lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP sang TIFF có ghi chú | Lưu slide cùng ghi chú người thuyết trình dưới dạng TIFF. | [Chuyển đổi PowerPoint sang TIFF với Ghi chú](/slides/vi/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX sang Word | Chuyển đổi slide sang tài liệu Word khi cần đầu ra dạng tài liệu. | [Chuyển đổi PowerPoint sang Word](/slides/vi/java/convert-powerpoint-to-word/) |
| PPT/PPTX sang Markdown | Trích xuất nội dung bản trình bày sang Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX sang GIF hoạt hình | Tạo GIF hoạt hình từ các slide. | [Chuyển đổi PowerPoint sang GIF Hoạt hình](/slides/vi/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX sang video | Xây dựng quy trình xuất video từ các slide bản trình bày. | [Chuyển đổi PowerPoint sang Video](/slides/vi/java/convert-powerpoint-to-video/) |
| Bản trình bày sang XAML | Xuất slide sang XAML cho các kịch bản giao diện Java. | [Xuất bản trình bày sang XAML](/slides/vi/java/export-to-xaml/) |

Để xem danh sách rộng hơn các định dạng đầu vào và đầu ra, xem [Định dạng tệp được hỗ trợ](/slides/vi/java/supported-file-formats/).

## **Chuyển đổi PowerPoint và OpenDocument**

Aspose.Slides cho Java hỗ trợ chuyển đổi từ các định dạng bản trình bày thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. Cùng một API chuyển đổi được dùng cho các tệp PowerPoint và OpenDocument, vì vậy một quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ cần thay đổi tệp đầu vào.

Khi chuyển đổi tệp ODP, nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi tính năng bố cục và định dạng theo cùng một cách. Nếu tệp ODP được tạo bằng LibreOffice hoặc OpenOffice Impress, hãy xem lại kết quả và sử dụng các tùy chọn được mô tả trong [Chuyển đổi bản trình bày OpenDocument](/slides/vi/java/convert-openoffice-odp/) khi cần hướng dẫn chi tiết cho định dạng.

## **Chuyển đổi PPT sang PPTX**

PPT là định dạng nhị phân PowerPoint cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides cho Java hỗ trợ chuyển đổi PPT sang PPTX với độ trung thực cao đồng thời giữ nguyên các cấu trúc phức tạp của bản trình bày như master, layout, slide, biểu đồ, nhóm hình dạng, placeholder, khung văn bản, texture và fill ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/java/convert-ppt-to-pptx/) và [PPT vs PPTX](/slides/vi/java/ppt-vs-pptx/).

## **Xuất bản bố cục cố định**

PDF, XPS và TIFF hữu ích khi đầu ra cần giống nhau trên mọi thiết bị và không được chỉnh sửa như một bản trình bày. Các bài viết chuyên biệt về PDF, XPS và TIFF giải thích cách kiểm soát tuân thủ, slide ẩn, ghi chú, chất lượng ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, công bố web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide phải trở thành một bản xem trước, ảnh thu nhỏ hoặc tài sản raster riêng biệt. Sử dụng các bài viết PNG, JPG và SVG để biết hướng dẫn kết xuất chi tiết cho từng định dạng.

## **Câu hỏi thường gặp**

**Bạn có cần Microsoft PowerPoint để chuyển đổi bản trình bày không?**

Không. Aspose.Slides cho Java là một thư viện độc lập và không yêu cầu Microsoft PowerPoint hay tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều bản trình bày không?**

Có. Tải mỗi bản trình bày, lưu nó sang định dạng yêu cầu và giải phóng đối tượng bản trình bày sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện bản trình bày riêng biệt và làm theo hướng dẫn [đa luồng](/slides/vi/java/multithreading/).

**Tôi có thể xuất chỉ các slide được chọn không?**

Có. Nhiều phương pháp xuất cho phép bạn truyền chỉ số slide hoặc kết xuất các slide riêng lẻ, tùy thuộc vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng các cài đặt xuất slide ẩn được mô tả trong các bài viết [PDF](/slides/vi/java/convert-powerpoint-to-pdf/) và [XPS](/slides/vi/java/convert-powerpoint-to-xps/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn cho việc xuất PDF. Xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/java/convert-powerpoint-to-pdf/) để biết chi tiết.

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, fallback và thay thế phông chữ. Xem [Phông chữ nhúng](/slides/vi/java/embedded-font/), [Phông chữ dự phòng](/slides/vi/java/fallback-font/) và [Thay thế phông chữ](/slides/vi/java/font-substitution/).