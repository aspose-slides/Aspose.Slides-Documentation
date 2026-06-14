---
title: Cấu hình Bộ sưu tập Phông chữ Dự phòng trong Python
linktitle: Bộ sưu tập Phông chữ Dự phòng
type: docs
weight: 20
url: /vi/python-net/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- cài đặt phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Cài đặt một bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho Python qua .NET để giữ cho văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Overview**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó cho thuộc tính `font_fall_back_rules_collection` của `fonts_manager` trong bản trình chiếu. `fonts_manager` kiểm soát phông chữ trên toàn bộ bản trình chiếu, và mỗi thể hiện `Presentation` có `FontsManager` riêng.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/python-net/aspose.slides/FontFallBackRule/) có thể được sắp xếp vào [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontfallbackrulescollection/). Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được gán cho thuộc tính [font_fall_back_rules_collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) của lớp [FontsManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/). FontsManager điều khiển phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) có thuộc tính [fonts_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/) với một thể hiện riêng của lớp FontsManager.

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán vào FontsManager của một bản trình chiếu nhất định:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="primary" %}} 
Đọc thêm cách [Render Presentation with Fallback Font](/slides/vi/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các quy tắc dự phòng của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được ghi vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

**Quy tắc dự phòng có áp dụng cho văn bản bên trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho mọi văn bản trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm tự mình.

**Có thể sử dụng đồng thời việc thay thế/phụ thay cho phông chữ thiếu và dự phòng cho glyph thiếu không?**

Có. Chúng là các giai đoạn độc lập của cùng một pipeline giải quyết phông chữ: trước tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/python-net/font-replacement/)/[substitution](/slides/vi/python-net/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho glyph thiếu trong các phông chữ có sẵn.