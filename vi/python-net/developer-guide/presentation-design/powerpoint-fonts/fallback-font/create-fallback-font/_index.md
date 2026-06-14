---
title: Chỉ định Phông chữ Dự phòng cho Bản trình chiếu trong Python
linktitle: Phông chữ Dự phòng
type: docs
weight: 10
url: /vi/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Làm chủ Aspose.Slides cho Python qua .NET để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, đảm bảo hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ dự phòng cho việc hiển thị và xuất bản trình chiếu. Phông chữ dự phòng được sử dụng khi phông chữ chính không chứa các glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình qua các quy tắc dự phòng. Mỗi quy tắc gắn một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và sắp xếp nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là thiết lập hiển thị thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Chỉ định Phông chữ Dự phòng**

Aspose.Slides hỗ trợ lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/FontFallBackRule/) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/FontFallBackRule/) đại diện cho một liên kết giữa phạm vi Unicode được chỉ định, được dùng để tìm kiếm các glyph bị thiếu, và danh sách các phông chữ có thể chứa các glyph thích hợp:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Sử dụng nhiều cách bạn có thể thêm danh sách phông chữ:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Cũng có thể [remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrule/remove/) phông chữ dự phòng hoặc [add_fall_back_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) vào đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/FontFallBackRule/) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrulescollection/) có thể được dùng để sắp xếp danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/FontFallBackRule/) khi cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="primary" title="Xem thêm" %}} 
- [Tạo Bộ sưu tập Phông chữ Dự phòng](/slides/vi/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/python-net/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/python-net/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như dự định.

**Phông chữ dự phòng có được áp dụng trong quá trình xuất như PDF, PNG hoặc SVG, hay chỉ khi hiển thị trên màn hình?**

Có. Phông chữ dự phòng ảnh hưởng tới tất cả các [rendering and export operations](/slides/vi/python-net/convert-presentation/) nơi các ký tự cần được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình phông chữ dự phòng có thay đổi tệp trình chiếu hay không, và thiết lập này có sẽ được lưu cho các lần mở sau không?**

Không. Các quy tắc dự phòng là thiết lập hiển thị thời gian chạy trong mã của bạn; chúng không được lưu trong .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và tập hợp các thư mục phông chữ có ảnh hưởng đến việc lựa chọn phông chữ dự phòng không?**

Có. Engine sẽ tìm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [additional paths](/slides/vi/python-net/custom-font/) nào bạn cung cấp. Nếu một phông chữ không có sẵn trên hệ thống, quy tắc tham chiếu đến nó sẽ không có hiệu lực.

**Phông chữ dự phòng có hoạt động cho WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cơ chế thay thế glyph tương tự sẽ được áp dụng để hiển thị các ký tự thiếu.