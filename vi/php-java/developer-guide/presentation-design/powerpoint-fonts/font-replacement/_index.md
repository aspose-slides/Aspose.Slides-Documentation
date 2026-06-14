---
title: Tối ưu hoá việc thay thế phông chữ trong bản trình bày bằng PHP
linktitle: Thay thế phông chữ
type: docs
weight: 60
url: /vi/php-java/font-replacement/
keywords:
- phông chữ
- thay thế phông chữ
- thay thế phông chữ
- đổi phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Thay thế phông chữ một cách liền mạch trong Aspose.Slides cho PHP qua Java để đảm bảo kiểu chữ nhất quán trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thay thế một phông chữ bằng phông chữ khác trên toàn bộ bản trình bày. Khi một phông chữ được thay thế, mọi trường hợp của phông chữ gốc sẽ được thay đổi thành phông chữ mới.

Để thực hiện việc thay thế phông chữ, tải bản trình bày, xác định phông chữ nguồn và phông chữ thay thế, gọi phương thức thay thế phông chữ, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. Cách tiếp cận này hữu ích khi bạn muốn có mục đích chuyển từ một họ phông chữ sang một họ khác trên toàn bộ bản trình bày.

## **Thay thế phông chữ**

Nếu bạn thay đổi quyết định về việc sử dụng một phông chữ, bạn có thể thay thế phông chữ đó bằng một phông chữ khác. Mọi trường hợp của phông chữ cũ sẽ được thay thế bằng phông chữ mới. 

Aspose.Slides cho phép bạn thay thế phông chữ theo cách này:

1. Tải bản trình bày liên quan. 
2. Tải phông chữ sẽ được thay thế. 
3. Tải phông chữ mới. 
4. Thay thế phông chữ. 
5. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã PHP này minh họa việc thay thế phông chữ:

```php
  # Tải một bản trình bày
  $pres = new Presentation("Fonts.pptx");
  try {
    # Tải phông chữ nguồn sẽ được thay thế
    $sourceFont = new FontData("Arial");
    # Tải phông chữ mới
    $destFont = new FontData("Times New Roman");
    # Thay thế các phông chữ
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Lưu bản trình bày
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Để thiết lập các quy tắc xác định những gì sẽ xảy ra trong một số điều kiện (ví dụ nếu một phông chữ không thể truy cập được), xem [**Font Substitution**](/slides/vi/php-java/font-substitution/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Sự khác nhau giữa “font replacement”, “font substitution” và “fallback fonts” là gì?**

Thay thế là việc chuyển đổi có chủ đích từ một họ phông chữ sang một họ khác trên toàn bộ tài liệu. [Substitution](/slides/vi/php-java/font-substitution/) là một quy tắc như “nếu phông chữ không khả dụng, sử dụng X”. [Fallback](/slides/vi/php-java/fallback-font/) được áp dụng một cách chính xác cho các glyph thiếu riêng lẻ khi phông chữ cơ bản đã được cài đặt nhưng không chứa các ký tự cần thiết.

**Thay thế có áp dụng cho các slide mẫu, bố cục, ghi chú và bình luận không?**

Có. Thay thế ảnh hưởng đến tất cả các đối tượng trong bản trình bày sử dụng phông chữ gốc, bao gồm cả các slide mẫu và ghi chú; bình luận cũng là một phần của tài liệu và được công cụ phông chữ tính đến.

**Phông chữ có thay đổi bên trong các đối tượng OLE nhúng (ví dụ, Excel) không?**

Không. [OLE content](/slides/vi/php-java/manage-ole/) được kiểm soát bởi ứng dụng riêng của nó. Việc thay thế trong bản trình bày không định dạng lại dữ liệu OLE nội bộ; nó có thể được hiển thị dưới dạng hình ảnh hoặc nội dung có thể chỉnh sửa bên ngoài.

**Tôi có thể thay thế phông chữ chỉ trong một phần của bản trình bày (theo slide hoặc khu vực) không?**

Việc thay thế có mục tiêu là khả thi nếu bạn thay đổi phông chữ ở mức các đối tượng/phạm vi cần thiết thay vì áp dụng thay thế toàn cục cho toàn bộ tài liệu. Logic lựa chọn phông chữ tổng thể trong quá trình render vẫn giữ nguyên.

**Làm thế nào để tôi xác định trước những phông chữ mà bản trình bày sử dụng?**

Sử dụng [font manager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/) của bản trình bày: nó cung cấp danh sách các [families in use](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getfonts/) và thông tin về [substitutions/"unknown"](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/), giúp lên kế hoạch thay thế.

**Thay thế phông chữ có hoạt động khi chuyển đổi sang PDF/hình ảnh không?**

Có. Khi xuất, Aspose.Slides áp dụng cùng một [font selection/substitution sequence](/slides/vi/php-java/font-selection-sequence/), vì vậy việc thay thế được thực hiện trước sẽ được tôn trọng trong quá trình chuyển đổi.

**Tôi có cần cài đặt phông chữ mục tiêu trên hệ thống, hay có thể đính kèm thư mục phông chữ không?**

Không cần cài đặt: thư viện cho phép [loading external fonts](/slides/vi/php-java/custom-font/) từ thư mục người dùng để sử dụng trong quá trình [rendering and export](/slides/vi/php-java/convert-powerpoint/).

**Việc thay thế có khắc phục hiện tượng “tofu” (hình vuông) thay vì ký tự không?**

Chỉ khi phông chữ mục tiêu thực sự chứa các glyph cần thiết. Nếu không, hãy [configure fallback](/slides/vi/php-java/fallback-font/) để bao phủ các ký tự còn thiếu.