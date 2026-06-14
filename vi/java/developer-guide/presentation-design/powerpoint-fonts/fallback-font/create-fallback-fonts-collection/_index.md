---
title: Cấu hình bộ sưu tập phông chữ dự phòng trong Java
linktitle: Bộ sưu tập phông chữ dự phòng
type: docs
weight: 20
url: /vi/java/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- thiết lập phông chữ
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Thiết lập bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho Java để giữ văn bản nhất quán và sắc nét trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho bản trình bày. Mỗi quy tắc dự phòng được đại diện bởi lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp thực thi giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó cho thuộc tính `FontFallBackRulesCollection` của `FontsManager` trong bản trình bày. `FontsManager` kiểm soát phông chữ trên toàn bộ bản trình bày, và mỗi thể hiện `Presentation` có `FontsManager` riêng của nó.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bản trình bày.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRule) có thể được sắp xếp vào [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRulesCollection), lớp này thực thi giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFontFallBackRulesCollection). Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được gán cho phương thức [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager). FontsManager kiểm soát phông chữ trên toàn bộ bản trình bày.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) có phương thức [getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--) với một thể hiện riêng của lớp [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FontsManager).

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán nó vào [FontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#getFontsManager--) của một bản trình bày cụ thể:  

```java
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

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình bày.

{{% alert color="primary" %}} 
Đọc thêm về cách [Render Presentation with Fallback Font](/slides/vi/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Liệu các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là thiết lập render thời gian chạy; chúng không được ghi vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

**Phần dự phòng có áp dụng cho văn bản bên trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho mọi văn bản trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm về chúng.

**Có thể sử dụng cả thay thế/phụ thay cho các phông chữ thiếu và dự phòng cho các glyph thiếu đồng thời không?**

Có. Chúng là các giai đoạn độc lập của cùng một quy trình giải quyết phông chữ: đầu tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/java/font-replacement/)/[substitution](/slides/vi/java/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống của glyph thiếu trong các phông chữ có sẵn.