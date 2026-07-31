---
title: Cấu hình Bộ sưu tập Phông chữ Dự phòng trong C++
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

Aspose.Slides cho phép bạn cấu hình một bộ quy tắc phông chữ dự phòng cho bài thuyết trình. Mỗi quy tắc dự phòng được đại diện bởi lớp `FontFallBackRule` và có thể được thêm vào `FontFallBackRulesCollection`, lớp thực thi giao diện `IFontFallBackRulesCollection`.

Sau khi tạo bộ sưu tập, bạn có thể gán nó bằng phương thức `set_FontFallBackRulesCollection` của `FontsManager` trong bài thuyết trình. `FontsManager` kiểm soát phông chữ trên toàn bộ bài thuyết trình, và mỗi đối tượng `Presentation` có `FontsManager` riêng.

Khi `FontsManager` được khởi tạo với bộ sưu tập phông chữ dự phòng, các phông chữ dự phòng được chỉ định sẽ được áp dụng trong quá trình render bài thuyết trình.

## **Áp dụng quy tắc dự phòng**

Các thể hiện của[FontFallBackRule](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrule/) có thể được tổ chức thành[FontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontfallbackrulescollection/), lớp thực thi[IFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifontfallbackrulescollection/) . Bạn có thể thêm hoặc xóa các quy tắc khỏi bộ sưu tập.

Sau đó bộ sưu tập này có thể được truyền vào[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) của lớp[FontsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsmanager/). FontsManager kiểm soát phông chữ trên toàn bộ bài thuyết trình.

Mỗi[Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) có một phương thức[get_FontsManager()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_fontsmanager/) với một thể hiện riêng của lớp FontsManager.

Dưới đây là ví dụ cách tạo bộ quy tắc phông chữ dự phòng và gán vào FontsManager của một bản trình chiếu cụ thể:  

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

**Các quy tắc dự phòng của tôi có được nhúng vào tập tin PPTX và hiển thị trong PowerPoint sau khi lưu không?**

Không. Các quy tắc dự phòng là cài đặt render thời gian chạy; chúng không được ghi vào PPTX và sẽ không xuất hiện trong giao diện PowerPoint.

**Quy tắc dự phòng có áp dụng cho văn bản trong SmartArt, WordArt, biểu đồ và bảng không?**

Có. Cơ chế thay thế glyph giống nhau được sử dụng cho mọi văn bản trong các đối tượng này.

**Aspose có phân phối bất kỳ phông chữ nào cùng thư viện không?**

Không. Bạn tự thêm và sử dụng phông chữ, chịu trách nhiệm hoàn toàn.

**Có thể sử dụng đồng thời việc thay thế/phông chữ thay thế cho phông chữ thiếu và dự phòng cho glyph thiếu không?**

Có. Hai bước này là các giai đoạn độc lập của cùng một pipeline giải quyết phông chữ: đầu tiên engine xác định tính khả dụng của phông chữ ([replacement](/slides/vi/cpp/font-replacement/)/[substitution](/slides/vi/cpp/font-substitution/)), sau đó dự phòng lấp đầy các glyph còn thiếu trong các phông chữ có sẵn.