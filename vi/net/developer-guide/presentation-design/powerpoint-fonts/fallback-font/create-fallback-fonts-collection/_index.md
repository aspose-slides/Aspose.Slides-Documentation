---
title: Cấu hình Bộ sưu tập Phông chữ Dự phòng trong .NET
linktitle: Bộ sưu tập Phông chữ Dự phòng
type: docs
weight: 20
url: /vi/net/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- thiết lập phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thiết lập một bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho .NET để giữ cho văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp này triển khai giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó cho thuộc tính `FontFallBackRulesCollection` của `FontsManager` của bản trình chiếu. `FontsManager` kiểm soát phông chữ trên toàn bộ bản trình chiếu, và mỗi thể hiện `Presentation` có `FontsManager` riêng.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/net/aspose.slides/FontFallBackRule) có thể được tổ chức thành [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/fontfallbackrulescollection), lớp này triển khai giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ifontfallbackrulescollection). Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được gán cho thuộc tính [FontFallBackRulesCollection ](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) của lớp [FontsManager](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager). FontsManager kiểm soát phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) có một thuộc tính [FontsManager ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/properties/fontsmanager) với một thể hiện riêng của lớp FontsManager.

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán nó vào FontsManager của một bản trình chiếu cụ thể:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="info" %}} 
Đọc thêm cách [Render Presentation with Fallback Font](/slides/vi/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Các quy tắc dự phòng của tôi có được nhúng vào file PPTX và hiển thị trong PowerPoint sau khi lưu không?

Không. Các quy tắc dự phòng là thiết lập render thời gian chạy; chúng không được ghi vào file PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

### Quy tắc dự phòng có áp dụng cho văn bản bên trong SmartArt, WordArt, biểu đồ và bảng không?

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

### Aspose có phân phối bất kỳ phông chữ nào kèm theo thư viện không?

Không. Bạn thêm và sử dụng phông chữ ở phía của mình và chịu trách nhiệm cá nhân.

### Có thể sử dụng đồng thời việc thay thế/đổi chỗ cho các phông chữ thiếu và dự phòng cho các glyph thiếu không?

Có. Chúng là các giai đoạn độc lập của cùng một quy trình giải quyết phông chữ: trước tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/net/font-replacement/)/[substitution](/slides/vi/net/font-substitution/)), sau đó dự phòng lấp đầy khoảng trống cho các glyph thiếu trong các phông chữ có sẵn.