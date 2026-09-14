---
title: Tối ưu hoá việc thay thế phông chữ trong bản trình bày bằng Python qua Java
linktitle: Thay thế phông chữ
type: docs
weight: 60
url: /vi/python-java/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides cho Python qua Java để đảm bảo kiểu chữ nhất quán trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng một phông chữ khác trong toàn bộ bản trình bày. Khi một phông chữ được thay thế, tất cả các trường hợp của phông chữ gốc sẽ được thay đổi sang phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình bày, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn có ý định chuyển đổi từ một họ phông chữ sang một họ khác trong toàn bộ bản trình bày.

## **Thay thế phông chữ**

Nếu bạn đổi ý về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các trường hợp của phông chữ cũ sẽ được thay thế bằng phông chữ mới. 

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bản trình bày liên quan. 
2. Tải phông chữ sẽ được thay thế. 
3. Tải phông chữ mới. 
4. Thay thế phông chữ. 
5. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX. 

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Tải một bản trình bày.
presentation = Presentation("Fonts.pptx")
try:
    # Tải phông chữ nguồn sẽ được thay thế.
    source_font = FontData("Arial")

    # Tải phông chữ mới.
    destination_font = FontData("Times New Roman")

    # Thay thế phông chữ.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Lưu bản trình bày.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Ghi chú" color="info" %}} 

Để đặt quy tắc xác định những gì sẽ xảy ra trong một số điều kiện (ví dụ nếu không thể truy cập phông chữ), hãy xem [Thay thế phông chữ](/slides/vi/python-java/font-substitution/). 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa “font replacement”, “font substitution” và “fallback fonts” là gì?**

Thay thế là việc chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Substitution](/slides/vi/python-java/font-substitution/) là một quy tắc như “nếu phông chữ không khả dụng, sử dụng X”. [Fallback](/slides/vi/python-java/fallback-font/) được áp dụng cho các glyph bị thiếu riêng lẻ khi phông chữ cơ sở đã được cài đặt nhưng không chứa các ký tự yêu cầu. 

**Thay thế có áp dụng cho các slide mẫu, bố cục, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình bày sử dụng phông chữ gốc, bao gồm các slide mẫu và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ phông chữ tính đến. 

**Phông chữ có thay đổi trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. [OLE content](/slides/vi/python-java/manage-ole/) được điều khiển bởi ứng dụng riêng của nó. Việc thay thế trong bản trình bày không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài. 

**Tôi có thể thay thế phông chữ chỉ trong một phần của bản trình bày (theo slide hoặc vùng) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/đoạn cần thiết thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ chung trong quá trình render vẫn giữ nguyên. 

**Làm sao tôi có thể xác định trước các phông chữ mà bản trình bày sử dụng?**

Sử dụng [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/): nó cung cấp danh sách các [các họ đang sử dụng](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFonts) và thông tin về [các phông chữ thay thế/"unknown"](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions), giúp lên kế hoạch thay thế. 

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [font selection/substitution sequence](/slides/vi/python-java/font-selection-sequence/), vì vậy một lần thay thế được thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi. 

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ?**

Không cần cài đặt: thư viện cho phép [loading external fonts](/slides/vi/python-java/custom-font/) từ thư mục người dùng để sử dụng trong quá trình [rendering and export](/slides/vi/python-java/convert-powerpoint/). 

**Thay thế có khắc phục hiện tượng “tofu” (ô vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, hãy [configure fallback](/slides/vi/python-java/fallback-font/) để bổ sung các ký tự thiếu.