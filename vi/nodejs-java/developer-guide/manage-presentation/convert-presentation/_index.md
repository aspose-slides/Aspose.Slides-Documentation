---
title: Chuyển đổi bản thuyết trình sang nhiều định dạng trong JavaScript
linktitle: Chuyển đổi bản thuyết trình
type: docs
weight: 70
url: /vi/nodejs-java/convert-presentation/
keywords:
- chuyển đổi bản thuyết trình
- xuất bản thuyết trình
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
description: "Chuyển đổi các bản thuyết trình PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và nhiều định dạng khác với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js qua Java có thể tải các bản thuyết trình PowerPoint và OpenDocument và lưu hoặc render chúng ra nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hoặc LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản thuyết trình thành các tài liệu bố cục cố định như PDF và XPS, công bố các slide dưới dạng HTML, hoặc render slide thành các tệp hình ảnh cho bản xem trước, ảnh thu nhỏ và lưu trữ.

Hầu hết các chuyển đổi tài liệu sử dụng cùng một quy trình chung: tải tệp nguồn, chọn định dạng đầu ra cần thiết và áp dụng các tùy chọn đặc thù cho định dạng khi cần. Đối với các định dạng hình ảnh, mỗi slide được render riêng biệt và sau đó lưu dưới dạng ảnh raster hoặc vector. Các bài viết chuyên đề được liên kết bên dưới cung cấp chi tiết thực hiện cho từng trường hợp.

## **Chọn kịch bản chuyển đổi**

Sử dụng các bài viết bên dưới để có các ví dụ JavaScript hoàn chỉnh và các tùy chọn đặc thù cho từng định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP sang PPTX | Cập nhật các tệp PPT cũ, chuẩn hóa các tệp PPTX hiện có, hoặc chuyển đổi các bản thuyết trình OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/nodejs-java/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/nodejs-java/convert-odp-to-pptx/), [Lưu bản thuyết trình](/slides/vi/nodejs-java/save-presentation/) |
| PPTX sang PPT | Lưu một bản thuyết trình PowerPoint hiện đại sang định dạng nhị phân PPT cũ để tương thích với quy trình cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP sang PDF | Tạo tài liệu bố cục cố định, có thể di động, tìm kiếm được để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP sang PDF có ghi chú | Xuất ghi chú diễn giả cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF có Ghi chú](/slides/vi/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP sang HTML | Công bố bản thuyết trình dưới dạng trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục đáp ứng. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP sang HTML5 | Xuất slide sang HTML5 để xem trên trình duyệt với định dạng và tính tương tác được bảo tồn. | [Chuyển đổi bản thuyết trình sang HTML5](/slides/vi/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP sang PNG | Render mỗi slide thành ảnh PNG cho bản xem trước, ảnh thu nhỏ hoặc đầu ra web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP sang JPG | Render slide thành ảnh JPG và kiểm soát kích thước và chất lượng ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide sang SVG | Xuất các slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Render Slide dưới dạng SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP sang XPS | Tạo tài liệu XPS có bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP sang TIFF | Lưu bản thuyết trình dưới dạng tệp TIFF đa trang cho in ấn, quét, fax hoặc quy trình lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP sang TIFF có ghi chú | Lưu slide cùng với ghi chú diễn giả dưới dạng TIFF. | [Chuyển đổi PowerPoint sang TIFF có Ghi chú](/slides/vi/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX sang Markdown | Trích xuất nội dung bản thuyết trình sang Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX sang GIF động | Tạo GIF động từ các slide. | [Chuyển đổi PowerPoint sang GIF động](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX sang video | Xây dựng quy trình xuất video từ các slide bản thuyết trình. | [Chuyển đổi PowerPoint sang Video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) |
| Bản thuyết trình sang XAML | Xuất slide sang XAML cho các kịch bản giao diện JavaScript hoặc Java. | [Xuất bản thuyết trình sang XAML](/slides/vi/nodejs-java/export-to-xaml/) |

Để xem danh sách đầy đủ hơn các định dạng đầu vào và đầu ra, xem [Định dạng tệp được hỗ trợ](/slides/vi/nodejs-java/supported-file-formats/).

## **Chuyển đổi PowerPoint và OpenDocument**

Aspose.Slides cho Node.js qua Java hỗ trợ chuyển đổi từ các định dạng bản thuyết trình thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. Cùng một API chuyển đổi được sử dụng cho các tệp PowerPoint và OpenDocument, vì vậy quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ bằng cách thay đổi tệp đầu vào.

Khi chuyển đổi các tệp ODP, hãy nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi tính năng bố cục và định dạng một cách hoàn toàn giống nhau. Nếu một tệp ODP được tạo trong LibreOffice hoặc OpenOffice Impress, hãy xem lại kết quả và sử dụng các tùy chọn được mô tả trong [Chuyển đổi Bản thuyết trình OpenDocument](/slides/vi/nodejs-java/convert-openoffice-odp/) khi bạn cần hướng dẫn đặc thù cho định dạng.

## **Chuyển đổi PPT sang PPTX**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides cho Node.js qua Java hỗ trợ chuyển đổi PPT sang PPTX với độ trung thực cao đồng thời bảo tồn các cấu trúc bản thuyết trình phức tạp như master, layout, slide, biểu đồ, nhóm hình dạng, placeholder, khung văn bản, kết cấu và nền hình ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/nodejs-java/convert-ppt-to-pptx/) và [PPT vs PPTX](/slides/vi/nodejs-java/ppt-vs-pptx/).

## **Xuất định dạng bố cục cố định**

PDF, XPS và TIFF hữu ích khi đầu ra cần giống nhau trên mọi thiết bị và không được chỉnh sửa như một bản thuyết trình. Các bài viết chuyên về PDF, XPS và TIFF giải thích cách kiểm soát tuân thủ, slide ẩn, ghi chú, chất lượng ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, công bố web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide cần trở thành một bản xem trước, ảnh thu nhỏ hoặc tài sản raster riêng biệt. Sử dụng các bài viết PNG, JPG và SVG để có hướng dẫn render riêng cho từng định dạng.

## **Câu hỏi thường gặp**

**Tôi có cần Microsoft PowerPoint để chuyển đổi bản thuyết trình không?**

Không. Aspose.Slides cho Node.js qua Java là một thư viện độc lập và không yêu cầu Microsoft PowerPoint hay tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều bản thuyết trình không?**

Có. Tải mỗi bản thuyết trình, lưu nó sang định dạng yêu cầu và giải phóng đối tượng bản thuyết trình sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện bản thuyết trình riêng biệt và tuân theo hướng dẫn [đa luồng](/slides/vi/nodejs-java/multithreading/).

**Tôi có thể xuất chỉ các slide đã chọn không?**

Có. Một số phương pháp xuất cho phép bạn truyền chỉ mục slide hoặc render từng slide riêng lẻ, tùy thuộc vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng cài đặt xuất slide ẩn được mô tả trong các bài viết chuyển đổi [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) và [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn cho xuất PDF. Xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) để biết chi tiết.

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, phông chữ dự phòng và cài đặt thay thế phông chữ. Xem [Phông chữ nhúng](/slides/vi/nodejs-java/embedded-font/), [Phông chữ dự phòng](/slides/vi/nodejs-java/fallback-font/), và [Thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/).