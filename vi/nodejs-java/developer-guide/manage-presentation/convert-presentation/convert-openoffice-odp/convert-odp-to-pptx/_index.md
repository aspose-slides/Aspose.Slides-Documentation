---
title: Chuyển đổi ODP sang PPTX trong JavaScript
linktitle: ODP sang PPTX
type: docs
weight: 10
url: /vi/nodejs-java/convert-odp-to-pptx/
keywords:
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi ODP
- OpenDocument sang PPTX
- ODP sang PPTX
- lưu ODP dưới dạng PPTX
- xuất ODP sang PPTX
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi ODP sang PPTX với Aspose.Slides cho Node.js. Các ví dụ mã JavaScript sạch sẽ, mẹo xử lý hàng loạt và kết quả chất lượng cao—không cần PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu ODP sang định dạng PPTX bằng Aspose.Slides.

## **Chuyển đổi ODP sang PPTX/PPT Presentation**
Aspose.Slides cho Node.js thông qua Java cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) đại diện cho tệp bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) hiện cũng có thể truy cập ODP thông qua hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) khi đối tượng được khởi tạo. Ví dụ sau đây cho thấy cách chuyển đổi một ODP Presentation sang PPTX Presentation.

```javascript
// Mở tệp ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Lưu bản trình chiếu ODP sang định dạng PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Ví dụ trực tiếp**
Bạn có thể truy cập ứng dụng web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/vi/conversion/) được xây dựng với **Aspose.Slides API.** Ứng dụng này minh họa cách thực hiện việc chuyển đổi ODP sang PPTX bằng Aspose.Slides API.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint hoặc LibreOffice để chuyển đổi ODP sang PPTX không?**

Không. Aspose.Slides hoạt động độc lập và không yêu cầu các ứng dụng bên thứ ba để đọc hoặc ghi ODP/PPTX.

**Các slide mẫu, bố cục và giao diện có được giữ nguyên trong quá trình chuyển đổi không?**

Có. Thư viện sử dụng mô hình đối tượng bản trình chiếu đầy đủ và giữ lại cấu trúc, bao gồm các slide mẫu và bố cục, do đó thiết kế vẫn chính xác sau khi chuyển đổi.

**Tôi có thể chuyển đổi các tệp ODP được bảo vệ bằng mật khẩu không?**

Có. Aspose.Slides hỗ trợ phát hiện bảo vệ, mở và làm việc với [protected presentations](/slides/vi/nodejs-java/password-protected-presentation/) (bao gồm ODP) khi bạn cung cấp mật khẩu, cũng như cấu hình mã hóa và truy cập vào các thuộc tính tài liệu.

**Aspose.Slides có phù hợp cho các dịch vụ chuyển đổi dựa trên đám mây hoặc REST không?**

Có. Bạn có thể sử dụng thư viện cục bộ trong backend của mình hoặc [Aspose.Slides Cloud](https://products.aspose.cloud/slides/vi/family/) (REST API); cả hai tùy chọn đều hỗ trợ chuyển đổi ODP → PPTX.