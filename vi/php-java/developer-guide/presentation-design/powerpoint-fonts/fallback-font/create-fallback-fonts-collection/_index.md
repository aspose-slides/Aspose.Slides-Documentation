---
title: Cấu hình bộ sưu tập phông chữ dự phòng trong PHP
linktitle: Bộ sưu tập phông chữ dự phòng
type: docs
weight: 20
url: /vi/php-java/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- thiết lập phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Thiết lập bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho PHP qua Java để giữ văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một tập hợp các quy tắc phông chữ dự phòng cho bản trình chiếu. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`.

Sau khi tạo tập hợp, bạn có thể gán nó bằng cách sử dụng phương thức `setFontFallBackRulesCollection` của `FontsManager` trong bản trình chiếu. `FontsManager` quản lý phông chữ trên toàn bộ bản trình chiếu, và mỗi thể hiện `Presentation` đều có `FontsManager` riêng.

Khi `FontsManager` được khởi tạo với tập hợp phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule) có thể được tổ chức vào [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRulesCollection). Có thể thêm hoặc xóa các quy tắc khỏi tập hợp.

Sau đó, tập hợp này có thể được gán cho phương thức [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager). FontsManager kiểm soát phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) có phương thức [getFontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#getFontsManager) với một thể hiện riêng của lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager).

Dưới đây là một ví dụ về cách tạo tập hợp quy tắc phông chữ dự phòng và gán nó vào [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#getFontsManager) của một bản trình chiếu cụ thể:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Sau khi FontsManager được khởi tạo với tập hợp phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="primary" %}} 
Đọc thêm về cách [Render Bản trình chiếu với Phông chữ Dự phòng](/slides/vi/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được tuần tự hoá vào PPTX và sẽ không xuất hiện trong giao diện người dùng của PowerPoint.

**Quy tắc dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm riêng.

**Có thể sử dụng đồng thời thay thế/phụ thay phông chữ thiếu và dự phòng cho glyph thiếu không?**

Có. Chúng là các giai đoạn độc lập của cùng một quy trình phân giải phông chữ: trước tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/php-java/font-replacement/)/[substitution](/slides/vi/php-java/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho glyph thiếu trong các phông chữ hiện có.