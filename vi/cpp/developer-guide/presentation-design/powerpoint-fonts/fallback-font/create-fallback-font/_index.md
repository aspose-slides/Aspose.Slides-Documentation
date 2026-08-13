---
title: Chỉ định phông chữ dự phòng cho bản trình chiếu trong C++
linktitle: Phông chữ dự phòng
type: docs
weight: 10
url: /vi/cpp/create-fallback-font/
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
- C++
- Aspose.Slides
description: "Sử dụng thành thạo Aspose.Slides cho C++ để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Các phông chữ dự phòng được sử dụng khi phông chữ chính không chứa glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc gắn một dải Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các dải ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và tổ chức nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Quy tắc dự phòng**

Aspose.Slides hỗ trợ giao diện [IFontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/) và lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) đại diện cho một liên kết giữa dải Unicode được chỉ định, dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa các glyph đúng:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Cũng có thể [Remove()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/remove/) phông chữ dự phòng hoặc [AddFallBackFonts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/) có thể được sử dụng để tổ chức danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) khi cần định nghĩa các quy tắc thay thế phông chữ dự phòng cho nhiều dải Unicode.

{{% alert color="info" title="Xem thêm" %}} 
- [Tạo bộ sưu tập phông chữ dự phòng](/slides/vi/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

### Phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ có gì khác nhau?

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Thay thế phông chữ](/slides/vi/cpp/font-substitution/) thay toàn bộ phông chữ đã chỉ định bằng một phông chữ khác. [Nhúng phông chữ](/slides/vi/cpp/embedded-font/) đóng gói phông chữ vào tệp đầu ra để người nhận có thể xem văn bản đúng như mong muốn.

### Các phông chữ dự phòng có được áp dụng khi xuất ra như PDF, PNG hoặc SVG không, hay chỉ khi hiển thị trên màn hình?

Có. Phông chữ dự phòng ảnh hưởng tới tất cả [các hoạt động hiển thị và xuất](/slides/vi/cpp/convert-presentation/) nơi các ký tự phải được vẽ nhưng lại không có trong phông chữ nguồn.

### Cấu hình dự phòng có thay đổi tệp trình chiếu không, và cài đặt này có được lưu lại cho các lần mở sau không?

Không. Các quy tắc dự phòng là cài đặt hiển thị thời gian chạy trong mã của bạn; chúng không được lưu trong tệp .pptx và sẽ không xuất hiện trong PowerPoint.

### Hệ điều hành (Windows/Linux/macOS) và các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông chữ dự phòng không?

Có. Engine tìm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [đường dẫn bổ sung](/slides/vi/cpp/custom-font/) nào bạn cung cấp. Nếu một phông chữ không tồn tại thực tế, quy tắc tham chiếu đến nó sẽ không có hiệu lực.

### Phông chữ dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?

Có. Khi các đối tượng này chứa văn bản, cùng một cơ chế thay thế glyph được áp dụng để hiển thị các ký tự thiếu.