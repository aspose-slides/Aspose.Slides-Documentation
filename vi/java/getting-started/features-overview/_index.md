---
title: Tổng quan các tính năng
type: docs
weight: 104
url: /vi/java/features-overview/
keywords:
- tính năng
- nền tảng được hỗ trợ
- định dạng tệp
- chuyển đổi
- kết xuất
- nội dung bản thuyết trình
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Xem xét những gì Aspose.Slides for Java hỗ trợ trước khi bạn đánh giá nó: nền tảng được hỗ trợ, định dạng tệp, việc kết xuất slide và nội dung bạn có thể tạo và chỉnh sửa."
---
## **Tổng quan**

Aspose.Slides for Java là một thư viện lớp để tạo, đọc, chỉnh sửa, chuyển đổi và hiển thị các bản thuyết trình PowerPoint và OpenDocument. Nó không có giao diện người dùng riêng và không yêu cầu Microsoft PowerPoint hay Microsoft Office. Bài viết này tóm tắt các tính năng của thư viện và liên kết tới các bài viết mô tả từng lĩnh vực.

## **Nền tảng được hỗ trợ**

Aspose.Slides for Java là một file JAR duy nhất, được công bố trong kho Maven của Aspose với classifier `jdk16`. Nó được viết bằng Java thuần: file JAR không chứa thư viện gốc, và không phụ thuộc vào các gói khác.

- **Java:** Java 8 trở lên. Aspose.Slides for Java 26.9 và các phiên bản trước cũng chạy trên Java 6 và 7, phiên bản 26.10 không còn hỗ trợ; xem [ghi chú phát hành 26.9](https://releases.aspose.com/slides/vi/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Hệ điều hành:** bất kỳ hệ điều hành nào có runtime Java, chẳng hạn Windows, Linux và macOS. Trên Linux, cần cài đặt thư viện fontconfig và ít nhất một phông chữ.

[Cài đặt](/slides/vi/java/installation/) hướng dẫn cách thêm thư viện vào dự án và liệt kê các yêu cầu trước cho Linux. [Yêu cầu hệ thống](/slides/vi/java/system-requirements/) liệt kê chi tiết các nền tảng được hỗ trợ.

## **Định dạng tệp và chuyển đổi**

Aspose.Slides mở và lưu các bản thuyết trình PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP và PowerPoint XML. Nó nhập nội dung PDF và HTML vào các slide, và lưu bản thuyết trình dưới dạng PDF, XPS, HTML, HTML5, TIFF, GIF động, SWF, Markdown và XAML. [Định dạng tệp được hỗ trợ](/slides/vi/java/supported-file-formats/) liệt kê mọi định dạng cùng API đọc hoặc ghi tương ứng.

|**Tính năng**|**Mô tả**|
| :- | :- |
|[PPT và PPTX](/slides/vi/java/ppt-vs-pptx/)|Đọc và ghi cả định dạng PowerPoint nhị phân 97-2003 và định dạng Office Open XML.|
|[Chuyển đổi PPT sang PPTX](/slides/vi/java/convert-ppt-to-pptx/)|Chuyển đổi các bản thuyết trình PPT cũ sang PPTX.|
|[Chuyển đổi ODP sang PPTX](/slides/vi/java/convert-odp-to-pptx/)|Mở và lưu các bản thuyết trình ODP, OTP và FODP, và chuyển đổi ODP sang PPTX.|
|[Portable Document Format (PDF)](/slides/vi/java/convert-powerpoint-to-pdf/)|Xuất bản thuyết trình ra PDF, bao gồm tài liệu PDF/A và PDF/UA.|
|[XML Paper Specification (XPS)](/slides/vi/java/convert-powerpoint-to-xps/)|Xuất bản thuyết trình ra tài liệu XPS.|
|[Tagged Image File Format (TIFF)](/slides/vi/java/convert-powerpoint-to-tiff/)|Xuất bản thuyết trình ra hình ảnh TIFF đa trang, mỗi trang một slide.|
|[HTML](/slides/vi/java/convert-powerpoint-to-html/)|Xuất bản thuyết trình ra HTML và HTML5.|
|[Nhập PDF và HTML](/slides/vi/java/import-presentation/)|Tạo slide từ các trang PDF và nội dung HTML.|

## **Kết xuất bản thuyết trình**

Aspose.Slides kết xuất các slide và các hình dạng riêng lẻ dưới dạng ảnh PNG, JPEG, BMP, GIF, TIFF và SVG, và các slide dưới dạng metafile EMF. Xem [Chuyển đổi slide bản thuyết trình sang ảnh](/slides/vi/java/convert-slide/), [Kết xuất slide bản thuyết trình dưới dạng ảnh SVG](/slides/vi/java/render-a-slide-as-an-svg-image/) và [Tạo ảnh thu nhỏ của các hình dạng trong bản thuyết trình](/slides/vi/java/create-shape-thumbnails/).

## **Các tính năng nội dung**

Aspose.Slides cho phép bạn tạo, đọc và sửa đổi hầu hết nội dung của một bản thuyết trình:

|**Lĩnh vực**|**Bạn có thể làm gì**|
| :- | :- |
|[Slides](/slides/vi/java/presentation-slide/)|Thêm, sao chép, sắp xếp lại và xóa slide; áp dụng bố cục và master; tổ chức slide thành các phần; thay đổi kích thước slide.|
|[Design](/slides/vi/java/presentation-design/)|Đặt nền, màu theme, header và footer, và phông chữ.|
|[Text](/slides/vi/java/manage-text/)|Tạo và chỉnh sửa khung văn bản, đoạn văn và phần; đặt phông chữ, màu, dấu đầu dòng và căn chỉnh; tìm và thay thế văn bản.|
|[Shapes](/slides/vi/java/powerpoint-shapes/)|Tạo AutoShapes, đường thẳng, connector, nhóm hình dạng và khung ảnh; đặt vị trí, kích thước, đường viền và màu nền đặc, gradient hoặc mẫu; tìm một hình dạng theo văn bản thay thế.|
|[Tables](/slides/vi/java/powerpoint-table/), [charts](/slides/vi/java/powerpoint-charts/), và [SmartArt](/slides/vi/java/powerpoint-smartart/)|Tạo và chỉnh sửa bảng, biểu đồ Microsoft Office và sơ đồ SmartArt.|
|[Media](/slides/vi/java/manage-media-files/), [OLE objects](/slides/vi/java/manage-ole/), và [ActiveX controls](/slides/vi/java/activex/)|Thêm khung âm thanh và video nhúng hoặc liên kết, nhúng OLE objects, và thêm, sửa đổi hoặc xóa điều khiển ActiveX.|
|[Notes](/slides/vi/java/presentation-notes/) và [comments](/slides/vi/java/presentation-comments/)|Thêm, đọc và chỉnh sửa ghi chú người thuyết trình và nhận xét.|
|[Animation](/slides/vi/java/powerpoint-animation/) và [transitions](/slides/vi/java/slide-transition/)|Áp dụng hiệu ứng hoạt ảnh cho hình dạng, đặt chuyển đổi slide và cấu hình cài đặt trình chiếu.|
|[Security](/slides/vi/java/presentation-security/)|Mã hoá bản thuyết trình bằng mật khẩu, đặt bảo vệ ghi và làm việc với [chữ ký số](/slides/vi/java/digital-signature-in-powerpoint/).|
|[VBA macros](/slides/vi/java/presentation-via-vba/)|Thêm, trích xuất và xóa module VBA trong bản thuyết trình hỗ trợ macro.|
|[Properties](/slides/vi/java/presentation-properties/)|Đọc và chỉnh sửa thuộc tính tài liệu.|

## **FAQ**

**Tôi có cần cài đặt Microsoft PowerPoint trên máy chủ hoặc PC để thư viện hoạt động không?**

Không. PowerPoint không bắt buộc; Aspose.Slides là một engine độc lập để tạo, chỉnh sửa, chuyển đổi và kết xuất bản thuyết trình.

**Đa luồng hoạt động như thế nào? Có thể xử lý song song không?**

An toàn khi xử lý các tài liệu khác nhau trên các luồng riêng biệt; cùng một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) không được sử dụng bởi [nhiều luồng](/slides/vi/java/multithreading/) cùng một lúc.

**Có hỗ trợ mật khẩu tệp và mã hoá không?**

Có. [Bạn có thể](/slides/vi/java/password-protected-presentation/) mở các bản thuyết trình đã được mã hoá, đặt hoặc xóa mật khẩu mở và ghi, và kiểm tra trạng thái bảo vệ.

**Tôi có cần quan tâm đến phông chữ trong container Linux không?**

Có. Trên Linux, thư viện fontconfig và ít nhất một phông chữ phải được cài đặt, và các phông chữ được sử dụng trong bản thuyết trình của bạn, hoặc các phông chữ thay thế phù hợp, phải được cài đặt để văn bản được hiển thị đúng. Bạn cũng có thể [chỉ định thư mục phông chữ](/slides/vi/java/custom-font/) trong ứng dụng của mình. Xem [Cài đặt](/slides/vi/java/installation/#linux).

**Có hạn chế nào trong phiên bản đánh giá không?**

Có. Khi không có [giấy phép](/slides/vi/java/licensing/), Aspose.Slides thêm watermark đánh giá vào mỗi slide được lưu và cắt ngắn văn bản mà mã của bạn đọc qua API. Một [giấy phép tạm thời 30 ngày](https://purchase.aspose.com/temporary-license/) có sẵn để thử nghiệm đầy đủ tính năng.

**Có hỗ trợ nhập các định dạng bên ngoài vào bản thuyết trình (PDF hoặc HTML sang PPTX) không?**

Có. Bạn có thể thêm [trang PDF và nội dung HTML](/slides/vi/java/import-presentation/) vào bản thuyết trình, chuyển chúng thành các slide.