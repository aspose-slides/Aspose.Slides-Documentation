---
title: Chỉ định phông chữ dự phòng cho bài thuyết trình trong C++
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/cpp/create-fallback-font/
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
  - bài thuyết trình
  - C++
  - Aspose.Slides
description: "Nắm vững Aspose.Slides cho C++ để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo vệ việc hiển thị văn bản nhất quán trên bất kỳ thiết bị hoặc hệ điều hành nào."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Các phông chữ dự phòng được sử dụng khi phông chữ chính không chứa glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc gắn một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không sửa đổi file trình chiếu và không được lưu bên trong file PPTX.

## **Quy tắc Dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) đại diện cho một liên kết giữa phạm vi Unicode được chỉ định, dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa glyph đúng:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Ngoài ra, bạn cũng có thể [Remove()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/remove/) phông chữ dự phòng hoặc [AddFallBackFonts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) khi cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Create Fallback Fonts Collection](/slides/vi/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**What is the difference between a fallback font, font substitution, and font embedding?**  
Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/cpp/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/cpp/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như mong muốn.

**Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?**  
Có. Dự phòng ảnh hưởng đến tất cả các [rendering and export operations](/slides/vi/cpp/convert-presentation/) nơi các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

**Does configuring fallback change the presentation file itself, and will the setting persist for future openings?**  
Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong file .pptx và sẽ không xuất hiện trong PowerPoint.

**Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?**  
Có. Công cụ giải quyết phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/cpp/custom-font/) nào mà bạn cung cấp. Nếu một phông chữ không có sẵn trên máy, quy tắc tham chiếu tới nó sẽ không thể hoạt động.

**Does fallback work for WordArt, SmartArt, and charts?**  
Có. Khi các đối tượng này chứa văn bản, cơ chế thay thế glyph tương tự được áp dụng để hiển thị các ký tự thiếu.