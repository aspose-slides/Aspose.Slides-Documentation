---
title: Tinh giản việc Thay thế Phông chữ trong Bài thuyết trình trên Android
linktitle: Thay thế Phông chữ
type: docs
weight: 60
url: /vi/androidjava/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides cho Android bằng Java để đảm bảo typography nhất quán trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trong toàn bộ bài thuyết trình. Khi một phông chữ được thay thế, tất cả các trường hợp của phông chữ gốc sẽ được đổi thành phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bài thuyết trình, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn muốn có chủ ý chuyển đổi từ một họ phông chữ sang một họ khác trong toàn bộ bài thuyết trình.

## **Thay thế phông chữ**

Nếu bạn đổi ý về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Tất cả các trường hợp của phông chữ cũ sẽ được thay bằng phông chữ mới. 

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bài thuyết trình liên quan. 
2. Tải phông chữ sẽ được thay thế. 
3. Tải phông chữ mới. 
4. Thay thế phông chữ. 
5. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này minh họa việc thay thế phông chữ:

```java
// Tải một bài thuyết trình
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Tải phông chữ nguồn sẽ được thay thế
    IFontData sourceFont = new FontData("Arial");
    
    // Tải phông chữ mới
    IFontData destFont = new FontData("Times New Roman");
    
    // Thay thế các phông chữ
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Lưu bài thuyết trình
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Để đặt quy tắc xác định những gì sẽ xảy ra trong các điều kiện nhất định (ví dụ nếu không thể truy cập một phông chữ), xem [**Thay thế phông chữ**](/slides/vi/androidjava/font-substitution/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa "font replacement", "font substitution" và "fallback fonts" là gì?**

Thay thế là một sự chuyển đổi có chủ đích từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Thay thế](/slides/vi/androidjava/font-substitution/) là một quy tắc như “nếu phông chữ không khả dụng, sử dụng X.” [Dự phòng](/slides/vi/androidjava/fallback-font/) được áp dụng một cách chính xác cho các glyph thiếu riêng lẻ khi phông chữ cơ bản đã được cài đặt nhưng không chứa các ký tự yêu cầu.

**Thay thế có áp dụng cho các slide master, bố cục, ghi chú và nhận xét không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bài thuyết trình sử dụng phông chữ gốc, bao gồm cả slide master và ghi chú; nhận xét cũng là một phần của tài liệu và được công cụ phông chữ tính đến.

**Phông chữ có thay đổi bên trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. [Nội dung OLE](/slides/vi/androidjava/manage-ole/) được điều khiển bởi ứng dụng riêng của nó. Việc thay thế trong bài thuyết trình không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế phông chữ chỉ trong một phần của bài thuyết trình (theo slide hoặc vùng) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở cấp độ các đối tượng/phạm vi cần thiết thay vì áp dụng việc thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ tổng thể trong quá trình render vẫn giữ nguyên.

**Làm thế nào tôi có thể xác định trước các phông chữ mà bài thuyết trình sử dụng?**

Sử dụng [trình quản lý phông chữ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/): nó cung cấp danh sách các [họ phông chữ đang dùng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getFonts--) và thông tin về [các phông chữ thay thế/"không xác định"] (https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Trong quá trình xuất, Aspose.Slides áp dụng cùng một [dòng tuần tự lựa chọn/phông chữ thay thế](/slides/vi/androidjava/font-selection-sequence/), vì vậy việc thay thế được thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Tôi có cần cài đặt phông chữ đích trên hệ thống, hay có thể đính kèm thư mục phông chữ không?**

Không cần cài đặt: thư viện cho phép [tải phông chữ bên ngoài](/slides/vi/androidjava/custom-font/) từ thư mục người dùng để sử dụng trong quá trình [render và xuất](/slides/vi/androidjava/convert-powerpoint/).

**Việc thay thế có khắc phục hiện tượng "tofu" (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ đích thực sự chứa các glyph cần thiết. Nếu không, [cấu hình phông chữ dự phòng](/slides/vi/androidjava/fallback-font/) để bao phủ các ký tự thiếu.