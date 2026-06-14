---
title: Cấu hình các Bộ sưu tập Phông chữ Dự phòng trong C++
linktitle: Bộ sưu tập Phông chữ Dự phòng
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
- bài thuyết trình
- C++
- Aspose.Slides
description: "Thiết lập một bộ sưu tập phông chữ dự phòng trong Aspose.Slides cho C++ để giữ cho văn bản nhất quán và sắc nét trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho bài thuyết trình. Mỗi quy tắc dự phòng được biểu diễn bằng lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp này triển khai giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó bằng phương thức `set_FontFallBackRulesCollection` của `FontsManager` trong bài thuyết trình. `FontsManager` điều khiển phông chữ trên toàn bộ bài thuyết trình, và mỗi thể hiện `Presentation` có `FontsManager` riêng của nó.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng đã chỉ định sẽ được áp dụng trong quá trình render bài thuyết trình.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của lớp [FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) có thể được tổ chức thành [FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/), lớp này triển khai giao diện [IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrulescollection/). Có thể thêm hoặc xóa các quy tắc trong bộ sưu tập.

Sau đó bộ sưu tập này có thể được truyền vào phương thức [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) của lớp [FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/). FontsManager điều khiển phông chữ trên toàn bộ bài thuyết trình.

Mỗi [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) có một phương thức [get_FontsManager()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/) với một thể hiện riêng của lớp FontsManager.

Dưới đây là một ví dụ về cách tạo bộ quy tắc phông chữ dự phòng và gán nó vào FontsManager của một bài thuyết trình cụ thể:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Sau khi FontsManager được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng sẽ được áp dụng trong quá trình render bài thuyết trình.

{{% alert color="primary" %}} 
Đọc thêm cách [Render Presentation with Fallback Font](/slides/vi/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các quy tắc dự phòng của tôi có được nhúng vào file PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được ghi vào file PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

**Có áp dụng dự phòng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cùng một cơ chế thay thế glyph được sử dụng cho bất kỳ văn bản nào trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào cùng với thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ và chịu trách nhiệm hoàn toàn.

**Có thể sử dụng đồng thời việc thay thế/phông chữ thay thế cho các phông chữ thiếu và dự phòng cho các glyph thiếu không?**

Có. Chúng là các giai đoạn độc lập của cùng một quy trình giải quyết phông chữ: đầu tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/cpp/font-replacement/)/[substitution](/slides/vi/cpp/font-substitution/)), sau đó dự phòng lấp đầy các khoảng trống cho glyph thiếu trong các phông chữ có sẵn.