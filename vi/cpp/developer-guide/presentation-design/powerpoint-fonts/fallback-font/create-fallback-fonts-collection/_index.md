---
title: Cấu hình bộ sưu tập phông chữ dự phòng trong C++
linktitle: Bộ sưu tập phông chữ dự phòng
type: docs
weight: 20
url: /vi/cpp/create-fallback-fonts-collection/
keywords:
- phông chữ dự phòng
- quy tắc dự phòng
- bộ sưu tập phông chữ
- cấu hình phông chữ
- thiết lập phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thiết lập một bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho C++ để giữ cho văn bản nhất quán và sắc nét trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho một bản trình chiếu. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp này triển khai giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó bằng phương thức `set_FontFallBackRulesCollection` của `FontsManager` trong bản trình chiếu. `FontsManager` kiểm soát phông chữ trên toàn bộ bản trình chiếu, và mỗi thể hiện `Presentation` có `FontsManager` riêng của nó.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng được chỉ định sẽ được áp dụng trong quá trình render bản trình chiếu.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) có thể được tổ chức vào [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/), lớp này triển khai giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrulescollection/). Có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được truyền vào phương thức [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) của lớp [FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/). FontsManager kiểm soát phông chữ trên toàn bộ bản trình chiếu.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) có một phương thức [get_FontsManager()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/) với một thể hiện riêng của lớp FontsManager.

Dưới đây là một ví dụ về cách tạo bộ sưu tập quy tắc phông chữ dự phòng và gán vào FontsManager của một bản trình chiếu nhất định:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bản trình chiếu.

{{% alert color="info" %}} 
Đọc thêm cách [Render Bản trình chiếu với Phông chữ Dự phòng](/slides/vi/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

### Các quy tắc dự phong của tôi có được nhúng vào tệp PPTX và hiển thị trong PowerPoint sau khi lưu không?

Không. Các quy tắc dự phòng là thiết lập render thời gian chạy; chúng không được tuần tự hoá vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

### Dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

### Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?

Không. Bạn tự thêm và sử dụng phông chữ phía của mình và chịu trách nhiệm riêng.

### Có thể sử dụng thay thế/phụ thay cho các phông chữ bị thiếu và dự phòng cho các glyph bị thiếu cùng lúc không?

Có. Chúng là các giai đoạn độc lập của cùng một pipeline giải quyết phông chữ: đầu tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/cpp/font-replacement/)/[substitution](/slides/vi/cpp/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho các glyph bị thiếu trong các phông chữ có sẵn.