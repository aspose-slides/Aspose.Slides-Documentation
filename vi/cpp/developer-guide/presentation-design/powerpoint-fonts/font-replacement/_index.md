---
title: "Tối ưu hoá việc thay thế phông chữ trong bản trình chiếu bằng C++"
linktitle: "Thay thế phông chữ"
type: docs
weight: 60
url: /vi/cpp/font-replacement/
keywords:
- "phông chữ"
- "thay thế phông chữ"
- "thay thế phông chữ"
- "đổi phông chữ"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "C++"
- "Aspose.Slides"
description: "Thay thế phông chữ trong Aspose.Slides cho C++ một cách liền mạch để đảm bảo kiểu chữ nhất quán trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng một phông chữ khác trên toàn bộ bản trình chiếu. Khi một phông chữ được thay thế, tất cả các trường hợp của phông chữ gốc sẽ được đổi thành phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình chiếu, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn có ý định chuyển đổi toàn bộ họ phông chữ trong bản trình chiếu.

## **Thay thế phông chữ**

Nếu bạn thay đổi quyết định về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các trường hợp của phông chữ cũ sẽ được thay thế bằng phông chữ mới. 

Aspose.Slides cho phép bạn thay thế một phông chữ theo cách này:

1. Tải bản trình chiếu liên quan. 
2. Tải phông chữ sẽ được thay thế. 
3. Tải phông chữ mới. 
4. Thay thế phông chữ. 
5. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

``` cpp
// Tải một bản trình chiếu
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Tải phông chữ nguồn sẽ được thay thế
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Tải phông chữ mới
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Thay thế các phông chữ
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Lưu bản trình chiếu
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Để đặt các quy tắc quyết định những gì xảy ra trong các điều kiện nhất định (ví dụ như phông chữ không thể truy cập), xem [**Thay thế phông chữ**](/slides/vi/cpp/font-substitution/). 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa “thay thế phông chữ”, “thay thế phông chữ” và “phông chữ dự phòng” là gì?**

Thay thế là việc chuyển đổi có chủ ý từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Thay thế](/slides/vi/cpp/font-substitution/) là một quy tắc như “nếu phông chữ không khả dụng, sử dụng X.” [Phông chữ dự phòng](/slides/vi/cpp/fallback-font/) được áp dụng riêng lẻ cho các glyph bị thiếu khi phông chữ cơ bản đã được cài đặt nhưng không chứa các ký tự cần thiết.

**Thay thế có áp dụng cho các slide chủ, bố cục, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình chiếu sử dụng phông chữ gốc, bao gồm các slide chủ và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ phông chữ tính đến.

**Phông chữ có thay đổi bên trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. Nội dung [OLE](/slides/vi/cpp/manage-ole/) được kiểm soát bởi ứng dụng riêng của nó. Việc thay thế trong bản trình chiếu không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng ảnh hoặc dưới dạng nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế một phông chữ chỉ trong một phần của bản trình chiếu (theo slide hoặc khu vực) không?**

Thay thế theo mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/khối cần thiết thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ tổng thể trong quá trình render vẫn giữ nguyên.

**Làm thế nào để tôi xác định trước những phông chữ mà bản trình chiếu sử dụng?**

Sử dụng [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/) của bản trình chiếu: nó cung cấp danh sách [các họ đang sử dụng](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getfonts/) và thông tin về [các phông chữ thay thế/“không xác định”](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/getsubstitutions/), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [dòng tuần tự lựa chọn/phông chữ thay thế](/slides/vi/cpp/font-selection-sequence/), vì vậy việc thay thế được thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ không?**

Không cần cài đặt: thư viện cho phép [tải phông chữ bên ngoài](/slides/vi/cpp/custom-font/) từ các thư mục người dùng để sử dụng trong quá trình [render và xuất](/slides/vi/cpp/convert-powerpoint/).

**Thay thế có khắc phục hiện tượng “tofu” (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, [cấu hình phông chữ dự phòng](/slides/vi/cpp/fallback-font/) để bao phủ các ký tự bị thiếu.