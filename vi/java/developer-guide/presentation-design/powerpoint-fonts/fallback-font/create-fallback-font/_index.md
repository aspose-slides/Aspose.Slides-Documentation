---
title: Chỉ định phông chữ dự phòng cho bản trình chiếu trong Java
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/java/create-fallback-font/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- áp dụng phông chữ
- thay thế phông chữ
- dải Unicode
- glyph bị thiếu
- glyph đúng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Thành thạo Aspose.Slides cho Java để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ dự phòng cho việc render và xuất bản trình chiếu. Phông chữ dự phòng được sử dụng khi phông chữ chính không chứa các glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc liên kết một dải Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa các quy tắc cho các dải ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập các quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Các quy tắc dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFontFallBackRule) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule) đại diện cho một mối liên kết giữa dải Unicode được chỉ định, dùng để tìm kiếm các glyph thiếu, và danh sách các phông chữ có thể chứa các glyph thích hợp:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Sử dụng nhiều cách khác nhau bạn có thể thêm danh sách phông chữ:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Cũng có thể [remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) phông chữ dự phòng hoặc [addFallBackFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRulesCollection) có thể được dùng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule), khi cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều dải Unicode.

{{% alert color="info" title="Xem thêm" %}} 
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

### Sự khác biệt giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/java/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/java/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như dự định.

### Phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG hoặc SVG, hay chỉ trong việc render trên màn hình?

Có. Phông chữ dự phòng ảnh hưởng đến tất cả [rendering and export operations](/slides/vi/java/convert-presentation/) nơi các ký tự cần được vẽ nhưng không có trong phông chữ nguồn.

### Việc cấu hình phông chữ dự phòng có thay đổi tệp trình chiếu không, và cài đặt này có được lưu lại cho các lần mở tiếp theo không?

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong file .pptx và sẽ không xuất hiện trong PowerPoint.

### Hệ điều hành (Windows/Linux/macOS) và tập hợp các thư mục phông chữ có ảnh hưởng đến việc chọn phông chữ dự phòng không?

Có. Engine tìm kiếm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/java/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có sẵn thực sự, quy tắc tham chiếu tới nó sẽ không có hiệu lực.

### Phông chữ dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?

Có. Khi các đối tượng này chứa văn bản, cùng cơ chế thay thế glyph sẽ được áp dụng để render các ký tự thiếu.