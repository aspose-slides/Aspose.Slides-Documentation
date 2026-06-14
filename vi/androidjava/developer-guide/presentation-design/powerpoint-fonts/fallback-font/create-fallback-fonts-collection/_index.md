---
title: Cấu hình bộ sưu tập phông chữ dự phòng trên Android
linktitle: Bộ sưu tập Phông chữ Dự phòng
type: docs
weight: 20
url: /vi/androidjava/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- cài đặt phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thiết lập bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho Android bằng Java để giữ cho văn bản nhất quán và sắc nét trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ sưu tập các quy tắc phông chữ dự phòng cho một bài thuyết trình. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp thực hiện giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó cho thuộc tính `FontFallBackRulesCollection` của `FontsManager` trong bài thuyết trình. `FontsManager` điều khiển phông chữ trên toàn bộ bài thuyết trình, và mỗi thể hiện `Presentation` có `FontsManager` riêng.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bài thuyết trình.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRule) có thể được sắp xếp vào [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRulesCollection), lớp thực hiện giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Bạn có thể thêm hoặc xóa các quy tắc trong bộ sưu tập.

Sau đó bộ sưu tập này có thể được gán cho phương thức [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontFallBackRulesCollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager). FontsManager điều khiển phông chữ trên toàn bộ bài thuyết trình.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) có một phương thức [getFontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getFontsManager--) với một thể hiện riêng của lớp [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FontsManager).

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán vào [FontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#getFontsManager--) của một bài thuyết trình cụ thể:
  
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

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bài thuyết trình.

{{% alert color="primary" %}} 
Đọc thêm cách [Kết xuất Bài thuyết trình với Phông chữ Dự phòng](/slides/vi/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là thiết lập render thời gian chạy; chúng không được tuần tự hoá vào PPTX và sẽ không xuất hiện trong giao diện người dùng của PowerPoint.

**Quy tắc dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm hoàn toàn.

**Có thể sử dụng đồng thời việc thay thế/phụ trợ cho các phông chữ thiếu và dự phòng cho các glyph thiếu không?**

Có. Chúng là các giai đoạn độc lập của cùng một pipeline giải quyết phông chữ: đầu tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/androidjava/font-replacement/)/[substitution](/slides/vi/androidjava/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho các glyph thiếu trong các phông chữ có sẵn.