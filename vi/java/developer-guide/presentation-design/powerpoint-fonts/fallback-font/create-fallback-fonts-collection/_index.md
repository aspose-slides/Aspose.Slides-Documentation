---
title: Cấu hình Bộ sưu tập Phông chữ Dự phòng trong Java
linktitle: Bộ sưu tập Phông chữ Dự phòng
type: docs
weight: 20
url: /vi/java/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- cài đặt phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Cài đặt bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho Java để giữ cho văn bản nhất quán và rõ ràng trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ sưu tập các quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được đại diện bởi lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp này triển khai giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó cho thuộc tính `FontFallBackRulesCollection` của `FontsManager` của bản trình chiếu. `FontsManager` kiểm soát phông chữ trên toàn bộ bản trình chiếu, và mỗi thể hiện `Presentation` có `FontsManager` riêng của mình.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule) có thể được tổ chức thành [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRulesCollection), lớp này triển khai giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFontFallBackRulesCollection). Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được gán cho phương thức [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager). FontsManager kiểm soát phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) có một phương thức [getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--) với một thể hiện riêng của lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager).

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán nó vào [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--) của một bản trình chiếu cụ thể:  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="info" %}} 
Đọc thêm cách [Render Bản trình chiếu với Phông chữ Dự phòng](/slides/vi/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được tuần tự hoá vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

### Dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho mọi văn bản trong các đối tượng này.

### Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm hoàn toàn.

### Có thể sử dụng đồng thời việc thay thế/phụ thay cho các phông chữ thiếu và dự phòng cho các glyph thiếu không?

Có. Chúng là các giai đoạn độc lập của cùng một quy trình giải quyết phông chữ: đầu tiên engine xác định khả năng có sẵn của phông chữ ([replacement](/slides/vi/java/font-replacement/)/[substitution](/slides/vi/java/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho các glyph thiếu trong các phông chữ có sẵn.