---
title: Tối ưu hoá quá trình thay thế phông chữ trong các bài thuyết trình bằng .NET
linktitle: Thay thế phông chữ
type: docs
weight: 60
url: /vi/net/font-replacement/
keywords:
- phông chữ
- thay phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides cho .NET để đảm bảo kiểu chữ đồng nhất trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình chiếu. Khi một phông chữ được thay thế, mọi lần xuất hiện của phông chữ gốc sẽ được đổi sang phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình chiếu, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX. Cách này hữu ích khi bạn muốn chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trong toàn bộ bản trình chiếu.

## **Thay thế phông chữ**

Nếu bạn thay đổi quyết định về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các lần xuất hiện của phông chữ cũ sẽ được thay bằng phông chữ mới.

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bản trình chiếu liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thay thế phông chữ.  
5. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Đoạn mã C# sau minh họa việc thay thế phông chữ:

```c#
// Tải một bản trình chiếu
Presentation presentation = new Presentation("Fonts.pptx");

// Tải phông chữ nguồn sẽ được thay thế
IFontData sourceFont = new FontData("Arial");

// Tải phông chữ mới
IFontData destFont = new FontData("Times New Roman");

// Thay thế các phông chữ
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Lưu bản trình chiếu
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Để thiết lập các quy tắc xác định hành vi trong điều kiện nhất định (ví dụ khi không thể truy cập một phông chữ), xem [**Thay thế phông chữ**](/slides/vi/net/font-substitution/). 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa "thay thế phông chữ", "thay thế phông chữ" và "phông chữ dự phòng" là gì?**

Thay thế là việc chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Thay thế](/slides/vi/net/font-substitution/) là quy tắc dạng "nếu phông chữ không khả dụng, sử dụng X". [Dự phòng](/slides/vi/net/fallback-font/) được áp dụng một cách có chọn lọc cho các glyph thiếu khi phông chữ cơ sở đã được cài đặt nhưng không chứa ký tự cần thiết.

**Việc thay thế có áp dụng cho các slide master, layout, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình chiếu sử dụng phông chữ gốc, bao gồm slide master và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ phông chữ xử lý.

**Phông chữ có thay đổi bên trong các đối tượng OLE nhúng (ví dụ Excel) không?**

Không. [Nội dung OLE](/slides/vi/net/manage-ole/) được điều khiển bởi ứng dụng riêng của nó. Việc thay thế trong bản trình chiếu không định dạng lại dữ liệu OLE bên trong; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế phông chữ chỉ trong một phần của bản trình chiếu (theo slide hoặc vùng) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng hoặc phạm vi cần thiết thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ chung trong quá trình render vẫn giữ nguyên.

**Làm sao tôi có thể xác định trước các phông chữ mà bản trình chiếu đang sử dụng?**

Sử dụng [font manager] của bản trình chiếu (https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/): nó cung cấp danh sách các [họ đang được dùng] (https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getfonts/) và thông tin về [các phông chữ thay thế/“không xác định”] (https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getsubstitutions/), giúp lập kế hoạch thay thế.

**Việc thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [chuỗi lựa chọn/phông chữ thay thế](/slides/vi/net/font-selection-sequence/), vì vậy một lần thay thế đã thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ?**

Không cần cài đặt: thư viện cho phép [tải phông chữ bên ngoài](/slides/vi/net/custom-font/) từ các thư mục người dùng để sử dụng trong [quá trình render và xuất](/slides/vi/net/convert-powerpoint/).

**Việc thay thế có khắc phục được hiện tượng “tofu” (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, [cấu hình phông chữ dự phòng](/slides/vi/net/fallback-font/) để bao phủ các ký tự thiếu.