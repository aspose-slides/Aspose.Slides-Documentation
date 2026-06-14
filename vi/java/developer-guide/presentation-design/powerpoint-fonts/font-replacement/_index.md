---
title: Tối ưu hoá Thay thế Phông chữ trong Bản trình chiếu bằng Java
linktitle: Thay thế Phông chữ
type: docs
weight: 60
url: /vi/java/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides cho Java để đảm bảo kiểu chữ đồng nhất trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình chiếu. Khi một phông chữ được thay thế, mọi trường hợp của phông chữ gốc sẽ được đổi sang phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình chiếu, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn có ý định chuyển đổi từ một họ phông chữ sang họ khác trên toàn bộ bản trình chiếu.

## **Thay thế phông chữ**

Nếu bạn thay đổi quyết định về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các trường hợp của phông chữ cũ sẽ được thay thế bằng phông chữ mới.

Aspose.Slides cho phép bạn thay thế một phông chữ theo cách này:

1. Tải bản trình chiếu liên quan.  
2. Tải phông chữ sẽ được thay thế.  
3. Tải phông chữ mới.  
4. Thay thế phông chữ.  
5. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này minh họa việc thay thế phông chữ:

```java
// Tải một bản trình chiếu
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    IFontData sourceFont = new FontData("Arial");
    
    // Tải phông chữ mới
    IFontData destFont = new FontData("Times New Roman");
    
    // Thay thế các phông chữ
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Lưu bản trình chiếu
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Để đặt quy tắc xác định những gì sẽ xảy ra trong các điều kiện nhất định (ví dụ nếu không thể truy cập phông chữ), xem [**Font Substitution**](/slides/vi/java/font-substitution/). 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác biệt giữa "font replacement", "font substitution" và "fallback fonts" là gì?**

Replacement là việc chuyển đổi có chủ định từ một họ phông chữ sang họ khác trên toàn bộ tài liệu. [Substitution](/slides/vi/java/font-substitution/) là một quy tắc như "nếu phông chữ không khả dụng, sử dụng X." [Fallback](/slides/vi/java/fallback-font/) được áp dụng một cách có mục tiêu cho các glyph thiếu riêng lẻ khi phông chữ nền đã được cài đặt nhưng không chứa các ký tự yêu cầu.

**Thay thế có áp dụng cho master slides, layouts, notes và comments không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình chiếu sử dụng phông chữ gốc, bao gồm master slides và notes; comments cũng là một phần của tài liệu và được engine phông chữ tính đến.

**Phông chữ có thay đổi bên trong các đối tượng OLE được nhúng (ví dụ, Excel) không?**

Không. [OLE content](/slides/vi/java/manage-ole/) được kiểm soát bởi ứng dụng riêng của nó. Việc thay thế trong bản trình chiếu không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế phông chữ chỉ trong một phần của bản trình chiếu (theo slide hoặc khu vực) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/khoảng cần thiết thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ tổng thể trong quá trình render vẫn giữ nguyên.

**Làm thế nào để tôi xác định trước các phông chữ mà bản trình chiếu sử dụng?**

Sử dụng [font manager] của bản trình chiếu (https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/): nó cung cấp danh sách các [families in use](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getFonts--) và thông tin về [substitutions/"unknown" fonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getSubstitutions--), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Trong quá trình xuất, Aspose.Slides áp dụng cùng một [font selection/substitution sequence](/slides/vi/java/font-selection-sequence/), vì vậy việc thay thế được thực hiện trước sẽ được áp dụng khi chuyển đổi.

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ?**

Không cần cài đặt: thư viện cho phép [loading external fonts](/slides/vi/java/custom-font/) từ thư mục người dùng để sử dụng trong quá trình [rendering and export](/slides/vi/java/convert-powerpoint/).

**Việc thay thế có khắc phục hiện tượng "tofu" (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, [configure fallback](/slides/vi/java/fallback-font/) để bao phủ các ký tự thiếu.