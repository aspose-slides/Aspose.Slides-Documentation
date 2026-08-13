---
title: Xác định Phông chữ Dự phòng cho Bản trình chiếu trong .NET
linktitle: Phông chữ Dự phòng
type: docs
weight: 10
url: /vi/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho .NET để đặt phông chữ dự phòng trong các tệp PPT, PPTX và ODP, đảm bảo hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Phông chữ dự phòng được sử dụng khi phông chữ chính không chứa glyph cho các ký tự nhất định.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc liên kết một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Quy tắc dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/iFontFallBackRule) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) đại diện cho một liên kết giữa phạm vi Unicode được chỉ định, dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa glyph đúng:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Cũng có thể [Remove()](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontfallbackrule/methods/remove) phông chữ dự phòng hoặc [AddFallBackFonts()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrulescollection) có thể được dùng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule), khi cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="info" title="Xem thêm" %}} 
- [Tạo Bộ sưu tập Phông chữ Dự phòng](/slides/vi/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

### Sự khác nhau giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/net/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/net/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản đúng như dự định.

### Phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG hoặc SVG, hay chỉ trong việc hiển thị trên màn hình không?

Có. Phông chữ dự phòng ảnh hưởng đến tất cả các [các hoạt động hiển thị và xuất](/slides/vi/net/convert-presentation/) nơi các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

### Việc cấu hình phông chữ dự phòng có thay đổi tệp trình chiếu hay không, và cài đặt có được lưu cho lần mở sau không?

Không. Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy trong mã của bạn; chúng không được lưu trong tệp .pptx và sẽ không xuất hiện trong PowerPoint.

### Hệ điều hành (Windows/Linux/macOS) và tập hợp các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông chữ dự phòng không?

Có. Engine tìm kiếm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [đường dẫn bổ sung](/slides/vi/net/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có sẵn trên máy, quy tắc tham chiếu đến nó sẽ không có hiệu lực.

### Phông chữ dự phòng có hoạt động cho WordArt, SmartArt và biểu đồ không?

Có. Khi các đối tượng này chứa văn bản, cùng cơ chế thay thế glyph sẽ được áp dụng để hiển thị các ký tự thiếu.