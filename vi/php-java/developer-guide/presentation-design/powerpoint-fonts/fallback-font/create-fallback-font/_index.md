---
title: Chỉ định phông chữ dự phòng cho bài thuyết trình trong PHP
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/php-java/create-fallback-font/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- áp dụng phông chữ
- thay thế phông chữ
- phạm vi Unicode
- glyph bị thiếu
- glyph phù hợp
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Thành thạo Aspose.Slides cho PHP thông qua Java để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ dự phòng cho việc render và xuất bản trình chiếu. Các phông chữ dự phòng được sử dụng khi phông chữ chính không chứa glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình qua các quy tắc dự phòng. Mỗi quy tắc liên kết một dải Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa các quy tắc cho các dải ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và sắp xếp nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Các quy tắc thay thế phông chữ**

Aspose.Slides hỗ trợ lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule) đại diện cho một liên kết giữa dải Unicode được chỉ định, dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa các glyph phù hợp:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Sử dụng nhiều cách khác nhau bạn có thể thêm danh sách phông chữ:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Cũng có thể [remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontfallbackrule/remove/) phông chữ dự phòng hoặc [addFallBackFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRulesCollection) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule), khi cần xác định các quy tắc thay thế phông chữ dự phòng cho nhiều dải Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/php-java/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/php-java/embedded-font/) đóng gói các phông chữ bên trong tệp đầu ra để người nhận có thể xem văn bản như dự định.

**Phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG, hoặc SVG, hay chỉ trong việc render trên màn hình không?**

Có. Dự phòng ảnh hưởng đến tất cả các [rendering and export operations](/slides/vi/php-java/convert-presentation/) nơi các ký tự cần được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình dự phòng có thay đổi tệp trình chiếu không, và thiết lập sẽ được giữ lại cho các lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và tập các thư mục phông chữ có ảnh hưởng đến việc lựa chọn dự phòng không?**

Có. Engine tìm kiếm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/php-java/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có sẵn về mặt vật lý, quy tắc tham chiếu tới nó sẽ không có hiệu lực.

**Dự phòng có hoạt động cho WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cùng cơ chế thay thế glyph được áp dụng để render các ký tự bị thiếu.