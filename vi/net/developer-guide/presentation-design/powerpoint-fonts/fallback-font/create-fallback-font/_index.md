---
title: Xác định Phông Dự Phòng cho Bài Thuyết Trình trong .NET
linktitle: Phông Dự Phòng
type: docs
weight: 10
url: /vi/net/create-fallback-font/
keywords:
- phông dự phòng
- quy tắc dự phòng
- áp dụng phông
- thay thế phông
- dải Unicode
- glyph bị thiếu
- glyph phù hợp
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Sử dụng thành thạo Aspose.Slides cho .NET để thiết lập phông dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông dự phòng cho việc hiển thị và xuất bản trình chiếu. Phông dự phòng được sử dụng khi phông chính không chứa các glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình bằng các quy tắc dự phòng. Mỗi quy tắc liên kết một dải Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các dải ký tự khác nhau, thêm hoặc xóa phông dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông dự phòng.

Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Quy Tắc Dự Phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/iFontFallBackRule) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) để chỉ định các quy tắc áp dụng phông dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) đại diện cho một liên kết giữa dải Unicode được chỉ định, dùng để tìm kiếm các glyph thiếu, và danh sách các phông chữ có thể chứa các glyph phù hợp:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Bạn cũng có thể [Remove()](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontfallbackrule/methods/remove) phông dự phòng hoặc [AddFallBackFonts()](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrulescollection) có thể được sử dụng để tổ chức một danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) khi cần định nghĩa các quy tắc thay thế phông dự phòng cho nhiều dải Unicode.

{{% alert color="primary" title="See also" %}} 
- [Tạo Bộ Sưu Tập Phông Dự Phòng](/slides/vi/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa phông dự phòng, thay thế phông và nhúng phông là gì?**

Phông dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chính. [Font substitution](/slides/vi/net/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông khác. [Font embedding](/slides/vi/net/embedded-font/) đóng gói các phông chữ vào trong tệp đầu ra để người nhận có thể xem văn bản đúng như dự định.

**Phông dự phòng có được áp dụng khi xuất dưới dạng PDF, PNG hoặc SVG, hay chỉ khi hiển thị trên màn hình?**

Có. Phông dự phòng ảnh hưởng đến tất cả các [rendering and export operations](/slides/vi/net/convert-presentation/) nơi các ký tự cần được vẽ nhưng không có trong phông nguồn.

**Việc cấu hình phông dự phòng có thay đổi tệp trình chiếu không, và cài đặt này có được lưu lại cho các lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy trong mã của bạn; chúng không được lưu trong tệp .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và tập hợp các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông dự phòng không?**

Có. Công cụ giải quyết phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/net/custom-font/) nào bạn cung cấp. Nếu một phông chữ không tồn tại thực tế, quy tắc tham chiếu đến nó sẽ không có hiệu lực.

**Phông dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cùng cơ chế thay thế glyph sẽ được áp dụng để hiển thị các ký tự thiếu.