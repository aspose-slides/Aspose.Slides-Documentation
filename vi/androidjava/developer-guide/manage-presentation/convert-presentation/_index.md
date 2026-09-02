---
title: Chuyển đổi bản trình bày sang nhiều định dạng trên Android
linktitle: Chuyển đổi Bản Trình Bày
type: docs
weight: 70
url: /vi/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang PPTX, PDF, HTML, hình ảnh, XPS, TIFF và hơn nữa với Aspose.Slides cho Android thông qua Java."
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể tải các bản trình bày PowerPoint và OpenDocument và lưu hoặc render chúng ra nhiều định dạng khác mà không cần Microsoft PowerPoint, OpenOffice hoặc LibreOffice. Bạn có thể chuyển đổi các tệp PPT cũ sang PPTX hiện đại, xuất bản trình bày sang các tài liệu có bố cục cố định như PDF và XPS, công bố các slide dưới dạng HTML, hoặc render các slide thành file hình ảnh để xem trước, tạo thumbnail và lưu trữ.

Hầu hết các chuyển đổi tài liệu đều sử dụng cùng một quy trình chung: tải tệp nguồn, chọn định dạng đầu ra yêu cầu và áp dụng các tùy chọn riêng cho định dạng khi cần thiết. Đối với các định dạng hình ảnh, mỗi slide được render riêng biệt và sau đó được lưu dưới dạng hình raster hoặc vector. Các bài viết chuyên biệt được liên kết dưới đây cung cấp chi tiết triển khai cho từng trường hợp.

## **Chọn Kịch Bản Chuyển Đổi**

Sử dụng các bài viết dưới đây để có các ví dụ Java đầy đủ và các tùy chọn riêng cho từng định dạng.

| Kịch bản | Sử dụng khi bạn cần | Bài viết |
| --- | --- | --- |
| PPT/PPTX/ODP sang PPTX | Cập nhật các tệp PPT cũ, chuẩn hoá các tệp PPTX hiện có, hoặc chuyển đổi các bản trình bày OpenDocument sang PowerPoint PPTX. | [Chuyển đổi PPT sang PPTX](/slides/vi/androidjava/convert-ppt-to-pptx/), [Chuyển đổi ODP sang PPTX](/slides/vi/androidjava/convert-odp-to-pptx/), [Lưu Bản Trình Bày](/slides/vi/androidjava/save-presentation/) |
| PPTX sang PPT | Lưu bản trình bày PowerPoint hiện đại sang định dạng nhị phân PPT cũ để tương thích với các quy trình làm việc cũ. | [Chuyển đổi PPTX sang PPT](/slides/vi/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP sang PDF | Tạo các tài liệu có bố cục cố định, di động, có thể tìm kiếm để chia sẻ, in ấn hoặc lưu trữ. | [Chuyển đổi PowerPoint sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP sang PDF với ghi chú | Xuất ghi chú người thuyết trình cùng với nội dung slide. | [Chuyển đổi PowerPoint sang PDF với Ghi chú](/slides/vi/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP sang HTML | Công bố bản trình bày dưới dạng các trang HTML và kiểm soát hình ảnh, phông chữ, ghi chú và các tùy chọn bố cục đáp ứng. | [Chuyển đổi PowerPoint sang HTML](/slides/vi/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP sang HTML5 | Xuất slide sang HTML5 để xem trên trình duyệt với định dạng và tính tương tác được giữ nguyên. | [Chuyển đổi Bản Trình Bày sang HTML5](/slides/vi/androidjava/export-to-html5/) |
| PPT/PPTX/ODP sang PNG | Render mỗi slide thành hình PNG để xem trước, tạo thumbnail hoặc xuất ra web. | [Chuyển đổi PowerPoint sang PNG](/slides/vi/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP sang JPG | Render slide thành hình JPG và kiểm soát kích thước và chất lượng ảnh. | [Chuyển đổi PowerPoint sang JPG](/slides/vi/androidjava/convert-powerpoint-to-jpg/) |
| Slide sang SVG | Xuất các slide riêng lẻ dưới dạng đồ họa vector có thể mở rộng. | [Render Slide dưới dạng SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP sang XPS | Tạo tài liệu XPS có bố cục cố định. | [Chuyển đổi PowerPoint sang XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP sang TIFF | Lưu bản trình bày dưới dạng file TIFF đa trang để in, quét, fax hoặc quy trình lưu trữ. | [Chuyển đổi PowerPoint sang TIFF](/slides/vi/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP sang TIFF với ghi chú | Lưu slide cùng ghi chú người thuyết trình dưới dạng TIFF. | [Chuyển đổi PowerPoint sang TIFF với Ghi chú](/slides/vi/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX sang Word | Chuyển đổi slide sang tài liệu Word khi bạn cần đầu ra dạng tài liệu. | [Chuyển đổi PowerPoint sang Word](/slides/vi/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX sang Markdown | Trích xuất nội dung bản trình bày thành Markdown cho tài liệu và quy trình làm việc dựa trên văn bản. | [Chuyển đổi PowerPoint sang Markdown](/slides/vi/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP sang XML | Tạo bản trình bày PowerPoint XML dựa trên văn bản để kiểm tra, so sánh, khắc phục sự cố hoặc quy trình làm việc dựa trên XML. | [Chuyển đổi PowerPoint sang XML](/slides/vi/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX sang GIF động | Tạo GIF động từ các slide. | [Chuyển đổi PowerPoint sang GIF động](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX sang video | Xây dựng quy trình xuất video từ các slide của bản trình bày. | [Chuyển đổi PowerPoint sang Video](/slides/vi/androidjava/convert-powerpoint-to-video/) |
| Presentation sang XAML | Xuất slide sang XAML cho các kịch bản UI Android hoặc Java. | [Xuất Bản Trình Bày sang XAML](/slides/vi/androidjava/export-to-xaml/) |

Đối với danh sách rộng hơn các định dạng đầu vào và đầu ra, xem [Định dạng tệp được hỗ trợ](/slides/vi/androidjava/supported-file-formats/).

## **Chuyển Đổi PowerPoint và OpenDocument**

Aspose.Slides for Android via Java hỗ trợ chuyển đổi từ các định dạng bản trình bày thường dùng như PPT, PPTX, PPS, PPSX, POT, POTX và ODP. Cùng một API chuyển đổi được sử dụng cho các tệp PowerPoint và OpenDocument, vì vậy một quy trình lưu tệp PPTX sang PDF thường có thể áp dụng cho tệp ODP chỉ bằng cách thay đổi tệp đầu vào.

Khi chuyển đổi tệp ODP, nhớ rằng các ứng dụng PowerPoint và OpenDocument không hỗ trợ mọi tính năng bố cục và định dạng một cách hoàn toàn giống nhau. Nếu tệp ODP được tạo trong LibreOffice hoặc OpenOffice Impress, hãy kiểm tra đầu ra và sử dụng các tùy chọn được mô tả trong [Chuyển đổi Bản Trình Bày OpenDocument](/slides/vi/androidjava/convert-openoffice-odp/) khi bạn cần hướng dẫn riêng cho định dạng.

## **Chuyển Đổi PPT sang PPTX**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Office Open XML hiện đại. Aspose.Slides for Android via Java hỗ trợ chuyển đổi PPT sang PPTX với độ trung thực cao đồng thời bảo tồn các cấu trúc trình bày phức tạp như master, layout, slide, biểu đồ, nhóm hình dạng, placeholder, khung văn bản, kết cấu và nền ảnh.

Để biết chi tiết, xem [Chuyển đổi PPT sang PPTX](/slides/vi/androidjava/convert-ppt-to-pptx/) và [PPT vs PPTX](/slides/vi/androidjava/ppt-vs-pptx/).

## **Xuất Bố Cục Cố Định**

PDF, XPS và TIFF hữu ích khi đầu ra cần giữ nguyên giao diện trên mọi thiết bị và không được chỉnh sửa như một bản trình bày. Các bài viết chuyên biệt về PDF, XPS và TIFF giải thích cách kiểm soát tuân thủ, các slide ẩn, ghi chú, chất lượng ảnh, nén, định dạng pixel và kích thước đầu ra.

## **Xuất HTML và Hình Ảnh**

Xuất HTML và HTML5 hữu ích cho việc xem trên trình duyệt, công bố web và chia sẻ nhẹ. Xuất hình ảnh hữu ích khi mỗi slide cần chuyển thành một bản xem trước, thumbnail hoặc tài sản raster riêng biệt. Sử dụng các bài viết về PNG, JPG và SVG để biết hướng dẫn render riêng cho mỗi định dạng.

## **Câu hỏi thường gặp**

**Có cần Microsoft PowerPoint để chuyển đổi bản trình bày không?**

Không. Aspose.Slides for Android via Java là một thư viện độc lập và không yêu cầu Microsoft PowerPoint hoặc tự động hoá Office.

**Tôi có thể chuyển đổi hàng loạt nhiều bản trình bày không?**

Có. Tải mỗi bản trình bày, lưu nó sang định dạng yêu cầu và giải phóng đối tượng bản trình bày sau khi xử lý. Đối với xử lý song song, sử dụng các thể hiện bản trình bày riêng biệt và tuân theo hướng dẫn [đa luồng](/slides/vi/androidjava/multithreading/).

**Tôi có thể xuất chỉ các slide đã chọn không?**

Có. Một số phương pháp xuất cho phép bạn truyền chỉ mục slide hoặc render các slide riêng lẻ, tùy thuộc vào định dạng đầu ra. Xem bài viết chuyên biệt cho định dạng mục tiêu.

**Tôi có thể bao gồm các slide ẩn khi xuất sang PDF hoặc XPS không?**

Có. Sử dụng các cài đặt xuất slide ẩn được mô tả trong các bài viết chuyển đổi [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) và [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/).

**Tôi có thể tạo đầu ra PDF/A không?**

Có. Các cài đặt tuân thủ PDF có sẵn cho việc xuất PDF. Xem [Chuyển đổi PowerPoint sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) để biết chi tiết.

**Phông chữ được xử lý như thế nào trong quá trình chuyển đổi?**

Aspose.Slides có thể sử dụng phông chữ nhúng, phông chữ dự phòng và cài đặt thay thế phông chữ. Xem [Phông chữ nhúng](/slides/vi/androidjava/embedded-font/), [Phông chữ dự phòng](/slides/vi/androidjava/fallback-font/), và [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/).