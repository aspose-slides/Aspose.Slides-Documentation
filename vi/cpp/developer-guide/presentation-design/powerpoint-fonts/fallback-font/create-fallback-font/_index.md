---
title: Xác định phông chữ dự phòng cho bản trình chiếu trong C++
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
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thành thập Aspose.Slides cho C++ để đặt phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Các phông chữ dự phòng sẽ được sử dụng khi phông chữ chính không có glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình qua các quy tắc dự phòng. Mỗi quy tắc gắn một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt hiển thị tại thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trữ bên trong tệp PPTX.

## **Quy tắc dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) đại diện cho mối liên kết giữa phạm vi Unicode đã chỉ định, dùng để tìm kiếm các glyph còn thiếu, và danh sách các phông chữ có thể chứa glyph phù hợp:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Bạn cũng có thể [Remove()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/remove/) phông chữ dự phòng hoặc [AddFallBackFonts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) khi cần định nghĩa các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Tạo Bộ Sưu Tập Phông Thư Dự Phòng](/slides/vi/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/cpp/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/cpp/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như mong muốn.

**Các phông chữ dự phòng có được áp dụng khi xuất ra PDF, PNG hoặc SVG, hay chỉ khi hiển thị trên màn hình?**

Có. Dự phòng ảnh hưởng đến tất cả các [hoạt động hiển thị và xuất](/slides/vi/cpp/convert-presentation/) mà các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình dự phòng có thay đổi tệp trình chiếu hay không, và cài đặt này có được lưu cho các lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt hiển thị tại thời gian chạy trong mã của bạn; chúng không được lưu trong .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và các thư mục phông chữ có ảnh hưởng đến việc lựa chọn dự phòng không?**

Có. Engine sẽ giải quyết phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [đường dẫn bổ sung](/slides/vi/cpp/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có thực tế, quy tắc tham chiếu đến nó sẽ không có hiệu lực.

**Phông chữ dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cơ chế thay thế glyph tương tự sẽ được áp dụng để hiển thị các ký tự thiếu.