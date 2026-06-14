---
title: Chỉ định phông chữ dự phòng cho bản trình chiếu trên Android
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/androidjava/create-fallback-font/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- áp dụng phông chữ
- thay thế phông chữ
- dải Unicode
- glyph thiếu
- glyph đúng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Nắm vững Aspose.Slides cho Android bằng Java để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Phông chữ dự phòng được dùng khi phông chữ chính không chứa glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc gắn một dải Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các dải ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Các quy tắc dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IFontFallBackRule) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule) đại diện cho một kết nối giữa dải Unicode được chỉ định, dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa glyph phù hợp:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Bạn cũng có thể [remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) phông chữ dự phòng hoặc [addFallBackFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRulesCollection) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule), khi cần xác định các quy tắc thay thế phông chữ dự phòng cho nhiều dải Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Nhúng phông chữ](/slides/vi/androidjava/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như dự định.

**Các phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG hoặc SVG, hay chỉ khi hiển thị trên màn hình?**

Có. Phông chữ dự phòng ảnh hưởng tới tất cả các [hoạt động render và xuất](/slides/vi/androidjava/convert-presentation/) nơi các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình phông chữ dự phòng có thay đổi tệp trình chiếu và cài đặt này có được lưu cho lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông chữ dự phòng không?**

Có. Động cơ giải quyết phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [đường dẫn bổ sung](/slides/vi/androidjava/custom-font/) nào bạn cung cấp. Nếu một phông chữ không tồn tại thực tế, một quy tắc tham chiếu tới nó sẽ không có hiệu lực.

**Phông chữ dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cùng một cơ chế thay thế glyph được áp dụng để render các ký tự thiếu.