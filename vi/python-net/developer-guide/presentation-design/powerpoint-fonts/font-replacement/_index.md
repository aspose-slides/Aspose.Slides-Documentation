---
title: Tối ưu hoá việc thay thế phông chữ trong các bản thuyết trình bằng Python
linktitle: Thay thế phông chữ
type: docs
weight: 60
url: /vi/python-net/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides Python qua .NET để đảm bảo kiểu chữ nhất quán trong các bản PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình chiếu. Khi một phông chữ được thay thế, tất cả các lần xuất hiện của phông chữ gốc sẽ được đổi sang phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình chiếu, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn muốn chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trên toàn bộ bản trình chiếu.

## **Thay thế phông chữ**

Nếu bạn thay đổi ý định sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các lần xuất hiện của phông chữ cũ sẽ được thay thế bằng phông chữ mới.

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bản trình chiếu liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thay thế phông chữ.  
5. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau đây minh họa việc thay thế phông chữ:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Tải một bản trình chiếu
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Tải phông chữ nguồn sẽ được thay thế
    sourceFont = slides.FontData("Arial")

    # Tải phông chữ mới
    destFont = slides.FontData("Times New Roman")

    # Thay thế các phông chữ
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Lưu bản trình chiếu
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Để thiết lập các quy tắc xác định những gì sẽ xảy ra trong một số điều kiện (ví dụ: nếu không thể truy cập một phông chữ), xem [**Font Substitution**](/slides/vi/python-net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Sự khác nhau giữa “thay thế phông chữ”, “thay thế phông chữ (font substitution)” và “phông chữ dự phòng (fallback fonts)” là gì?**

Thay thế là việc chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Substitution](/slides/vi/python-net/font-substitution/) là quy tắc dạng “nếu phông chữ không có sẵn, sử dụng X”. [Fallback](/slides/vi/python-net/fallback-font/) được áp dụng riêng lẻ cho các glyph thiếu khi phông chữ cơ bản đã được cài đặt nhưng không chứa các ký tự cần thiết.

**Thay thế có áp dụng cho các slide master, layout, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng tới tất cả các đối tượng trong bản trình chiếu sử dụng phông chữ gốc, bao gồm slide master và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ phông chữ tính đến.

**Phông chữ có thay đổi trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. [OLE content](/slides/vi/python-net/manage-ole/) được điều khiển bởi ứng dụng riêng của nó. Việc thay thế trong bản trình chiếu không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Có thể chỉ thay thế một phông chữ trong một phần của bản trình chiếu (theo slide hoặc vùng) không?**

Thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/phạm vi yêu cầu thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Luồng logic lựa chọn phông chữ khi render vẫn giữ nguyên.

**Làm sao để xác định trước các phông chữ mà bản trình chiếu sử dụng?**

Sử dụng [font manager] của bản trình chiếu (https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/): nó cung cấp danh sách các [họ đang được sử dụng] (https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) và thông tin về [các phông chữ “unknown”/thay thế] (https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [font selection/substitution sequence](/slides/vi/python-net/font-selection-sequence/), vì vậy một lần thay thế thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Có cần cài đặt phông chữ mục tiêu trong hệ thống, hay có thể đính kèm thư mục phông chữ?**

Không cần cài đặt: thư viện cho phép [tải phông chữ bên ngoài](/slides/vi/python-net/custom-font/) từ thư mục người dùng để sử dụng trong [render và export](/slides/vi/python-net/convert-powerpoint/).

**Thay thế có khắc phục được hiện tượng “tofu” (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, [cấu hình fallback](/slides/vi/python-net/fallback-font/) để bao phủ các ký tự bị thiếu.