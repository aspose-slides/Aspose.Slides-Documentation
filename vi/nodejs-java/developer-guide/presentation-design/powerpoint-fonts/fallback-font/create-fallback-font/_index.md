---
title: Xác định phông chữ dự phòng cho các bản trình chiếu trong JavaScript
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/nodejs-java/create-fallback-font/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- áp dụng phông chữ
- thay thế phông chữ
- phạm vi Unicode
- glyph bị thiếu
- glyph đúng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nắm vững Aspose.Slides cho Node.js để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP bằng JavaScript, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Phông chữ dự phòng được sử dụng khi phông chữ chính không chứa các glyph cho các ký tự nhất định.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc gắn một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Quy tắc dự phòng**

Aspose.Slides hỗ trợ lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule) đại diện cho một liên kết giữa phạm vi Unicode được chỉ định, được dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa các glyph đúng:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Bạn cũng có thể [remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) phông chữ dự phòng hoặc [addFallBackFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRulesCollection) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule), khi cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Create Fallback Fonts Collection](/slides/vi/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/nodejs-java/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/nodejs-java/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như dự định.

**Phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG hoặc SVG, hay chỉ khi hiển thị trên màn hình?**

Có. Phông chữ dự phòng ảnh hưởng đến tất cả các [rendering and export operations](/slides/vi/nodejs-java/convert-presentation/) nơi các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình phông chữ dự phòng có thay đổi tệp trình chiếu và thiết lập này có được lưu cho các lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông chữ dự phòng không?**

Có. Động cơ sẽ giải quyết phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/nodejs-java/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có sẵn về mặt vật lý, quy tắc tham chiếu tới nó sẽ không có hiệu lực.

**Phông chữ dự phòng có hoạt động cho WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cùng một cơ chế thay thế glyph sẽ được áp dụng để render các ký tự thiếu.