---
title: Tối ưu hoá việc thay thế phông chữ trong các bản trình bày bằng JavaScript
linktitle: Thay thế phông chữ
type: docs
weight: 60
url: /vi/nodejs-java/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong JavaScript bằng Aspose.Slides cho Node.js thông qua Java để đảm bảo kiểu chữ nhất quán trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình bày. Khi một phông chữ được thay thế, tất cả các trường hợp của phông chữ gốc sẽ được đổi thành phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình bày, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn muốn chuyển đổi có chủ đích từ một họ phông chữ sang họ khác trên toàn bộ bản trình bày.

## **Thay thế phông chữ**

Nếu bạn thay đổi ý định về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các trường hợp của phông chữ cũ sẽ được thay thế bằng phông chữ mới. 

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bản trình bày liên quan. 
2. Tải phông chữ sẽ được thay thế. 
3. Tải phông chữ mới. 
4. Thay thế phông chữ. 
5. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã JavaScript này minh họa việc thay thế phông chữ:

```javascript
// Tải một bản trình bày
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    var sourceFont = new aspose.slides.FontData("Arial");
    // Tải phông chữ mới
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Thay thế các phông chữ
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Lưu bản trình bày
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Để đặt các quy tắc xác định điều sẽ xảy ra trong những điều kiện nhất định (ví dụ, nếu không thể truy cập một phông chữ), xem [**Thay thế phông chữ**](/slides/vi/nodejs-java/font-substitution/). 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa “thay thế phông chữ”, “thay thế (substitution) phông chữ” và “phông chữ dự phòng” là gì?**

Thay thế là việc chuyển đổi có chủ đích từ một họ phông chữ sang một họ khác trên toàn tài liệu. [Thay thế](/slides/vi/nodejs-java/font-substitution/) là một quy tắc như “nếu phông chữ không có, sử dụng X”. [Phông chữ dự phòng](/slides/vi/nodejs-java/fallback-font/) được áp dụng một cách có chọn lọc cho các glyph bị thiếu riêng lẻ khi phông chữ cơ sở đã được cài nhưng không chứa các ký tự yêu cầu.

**Thay thế có áp dụng cho các slide mẫu, bố cục, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình bày sử dụng phông chữ gốc, bao gồm slide mẫu và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ xử lý phông chữ tính đến.

**Phông chữ có thay đổi bên trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. [Nội dung OLE](/slides/vi/nodejs-java/manage-ole/) được kiểm soát bởi ứng dụng riêng của nó. Việc thay thế trong bản trình bày không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế phông chữ chỉ ở một phần của bản trình bày (theo slide hoặc khu vực) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/phạm vi cần thiết thay vì áp dụng thay thế toàn cục cho toàn tài liệu. Logic lựa chọn phông chữ tổng thể trong quá trình render vẫn giữ nguyên.

**Làm sao tôi có thể xác định trước các phông chữ mà bản trình bày sử dụng?**

Sử dụng [trình quản lý phông chữ] (https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/) của bản trình bày: nó cung cấp danh sách các [họ đang được sử dụng] (https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) và thông tin về [các phông chữ “không xác định”/thay thế] (https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [chuỗi lựa chọn/phông chữ thay thế](/slides/vi/nodejs-java/font-selection-sequence/), vì vậy một thay thế đã thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ không?**

Không cần cài đặt: thư viện cho phép [tải phông chữ bên ngoài](/slides/vi/nodejs-java/custom-font/) từ thư mục người dùng để sử dụng trong quá trình [render và xuất](/slides/vi/nodejs-java/convert-powerpoint/).

**Việc thay thế có khắc phục được hiện tượng “tofu” (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, [cấu hình phông chữ dự phòng](/slides/vi/nodejs-java/fallback-font/) để bao phủ các ký tự bị thiếu.