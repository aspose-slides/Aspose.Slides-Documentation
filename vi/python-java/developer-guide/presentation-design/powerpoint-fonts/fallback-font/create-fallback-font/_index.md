---
title: Xác định Phông chữ Dự phòng cho Bài thuyết trình trong Python qua Java
linktitle: Phông chữ Dự phòng
type: docs
weight: 10
url: /vi/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Sử dụng thành thạo Aspose.Slides cho Python qua Java để thiết lập phông chữ dự phòng trong các tệp PPT, PPTX và ODP, bảo đảm việc hiển thị văn bản nhất quán trên mọi thiết bị hoặc hệ điều hành."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ dự phòng cho việc render và xuất bản trình chiếu. Phông chữ dự phòng được sử dụng khi phông chữ chính không chứa glyph cho các ký tự cụ thể.

Hành vi dự phòng được cấu hình thông qua các quy tắc dự phòng. Mỗi quy tắc liên kết một phạm vi Unicode với một hoặc nhiều phông chữ có thể chứa các glyph cần thiết. Bạn có thể định nghĩa các quy tắc cho các phạm vi ký tự khác nhau, thêm hoặc xóa phông chữ dự phòng khỏi các quy tắc hiện có, và sắp xếp nhiều quy tắc trong một bộ sưu tập quy tắc phông chữ dự phòng.

Các quy tắc dự phòng là cài đặt render thời gian chạy. Chúng không thay đổi tệp trình chiếu và không được lưu trong tệp PPTX.

## **Quy tắc dự phòng**

Aspose.Slides cung cấp lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/) để chỉ định các quy tắc áp dụng phông chữ dự phòng. Lớp này đại diện cho một mối liên kết giữa một phạm vi Unicode được dùng để tìm kiếm các glyph còn thiếu và một danh sách các phông chữ có thể chứa các glyph cần thiết:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Sử dụng nhiều cách để chỉ định danh sách phông chữ.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Bạn cũng có thể xóa một phông chữ dự phòng bằng cách sử dụng [remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/#remove) hoặc thêm phông chữ dự phòng bằng [addFallBackFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) trong một đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/) hiện có.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrulescollection/) có thể sắp xếp một danh sách các đối tượng [FontFallBackRule](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontfallbackrule/) khi bạn cần chỉ định các quy tắc thay thế phông chữ dự phòng cho nhiều phạm vi Unicode.

{{% alert color="info" title="See also" %}} 
- [Tạo Bộ sưu tập Phông chữ Dự phòng](/slides/vi/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa phông chữ dự phòng, thay thế phông chữ và nhúng phông chữ là gì?**

Phông chữ dự phòng chỉ được sử dụng cho các ký tự thiếu trong phông chữ chính. [Font substitution](/slides/vi/python-java/font-substitution/) thay thế toàn bộ phông chữ được chỉ định bằng một phông chữ khác. [Font embedding](/slides/vi/python-java/embedded-font/) đóng gói các phông chữ vào tệp đầu ra để người nhận có thể xem văn bản như dự định.

**Phông chữ dự phòng có được áp dụng khi xuất ra như PDF, PNG hoặc SVG, hay chỉ khi render trên màn hình?**

Có. Phông chữ dự phòng ảnh hưởng đến tất cả các [rendering and export operations](/slides/vi/python-java/convert-presentation/) nơi các ký tự phải được vẽ nhưng không có trong phông chữ nguồn.

**Việc cấu hình dự phòng có thay đổi tệp trình chiếu và cài đặt sẽ được lưu cho các lần mở sau không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy trong mã của bạn; chúng không được lưu trong tệp .pptx và sẽ không xuất hiện trong PowerPoint.

**Hệ điều hành (Windows/Linux/macOS) và tập hợp các thư mục phông chữ có ảnh hưởng đến việc lựa chọn dự phòng không?**

Có. Engine sẽ tìm phông chữ từ các thư mục hệ thống có sẵn và bất kỳ [đường dẫn bổ sung](/slides/vi/python-java/custom-font/) nào bạn cung cấp. Nếu một phông chữ không tồn tại thực tế, quy tắc tham chiếu tới nó sẽ không có hiệu lực.

**Phông chữ dự phòng có hoạt động với WordArt, SmartArt và biểu đồ không?**

Có. Khi các đối tượng này chứa văn bản, cùng một cơ chế thay thế glyph sẽ được áp dụng để render các ký tự thiếu.