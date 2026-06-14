---
title: Cấu hình bộ sưu tập phông chữ dự phòng trong JavaScript
linktitle: Bộ sưu tập phông chữ dự phòng
type: docs
weight: 20
url: /vi/nodejs-java/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- cài đặt phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Thiết lập bộ sưu tập phông chữ dự phòng trong JavaScript với Aspose.Slides cho Node.js để giữ cho văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được đại diện bởi lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó bằng phương thức `setFontFallBackRulesCollection` của `FontsManager` trong bản trình chiếu. `FontsManager` điều khiển phông chữ trên toàn bộ bản trình chiếu, và mỗi đối tượng `Presentation` có `FontsManager` riêng của mình.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của [FontFallBackRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRule) có thể được tổ chức thành [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRulesCollection), mà triển khai [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRulesCollection) lớp. Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó, bộ sưu tập này có thể được gán cho phương thức [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager). FontsManager kiểm soát các phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) có một phương thức [getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getFontsManager--) với một thể hiện riêng của lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FontsManager).

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán vào [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getFontsManager--) của một bản trình chiếu cụ thể:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="primary" %}} 
Đọc thêm cách [Kết xuất bản trình chiếu với phông chữ dự phòng](/slides/vi/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

Không. Các quy tắc dự phòng là thiết lập render trong thời gian chạy; chúng không được ghi vào PPTX và sẽ không xuất hiện trong giao diện người dùng của PowerPoint.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Có. Cơ chế thay thế glyph tương tự được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

**Does Aspose distribute any fonts with the library?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm hoàn toàn.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Có. Chúng là các giai đoạn độc lập của cùng một pipeline giải quyết phông chữ: đầu tiên engine giải quyết khả năng sẵn có của phông chữ ([replacement](/slides/vi/nodejs-java/font-replacement/)/[substitution](/slides/vi/nodejs-java/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho glyph thiếu trong các phông chữ có sẵn.