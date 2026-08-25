---
title: Quản lý phông chữ theme đặc thù cho script trong C++
linktitle: Phông chữ Theme Đặc thù cho Script
type: docs
weight: 15
url: /vi/cpp/script-specific-font-mappings/
keywords:
- phông chữ đặc thù cho script
- ánh xạ phông chữ theme
- bản trình chiếu đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Arabic
- phông chữ Japanese
- phông chữ Georgian
- phông chữ Thaana
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ đặc thù cho script trong các theme PowerPoint bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Một chủ đề bản trình chiếu có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ chủ đề để tuân theo một lược đồ phông chữ phối hợp trong khi sử dụng các phông chữ phù hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các chữ viết khác.

Theme của [IFontScheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ifontscheme/) chứa một bộ sưu tập phông chữ chính, thường được sử dụng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường được sử dụng cho nội dung văn bản. Ngoài các thuộc tính phông chữ Latin và Đông Á, cả hai bộ sưu tập đều phơi bày các ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ thông qua giao diện [IFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifonts/).

Bài viết này trình bày cách kiểm tra và sửa đổi các ánh xạ đó trong theme chính của bản trình chiếu và xác minh rằng các thay đổi tồn tại qua vòng lưu và tải lại.

## **Hiểu Thẻ Script**

Các phương thức phông chữ script sử dụng các phụ thẻ script BCP 47 gồm bốn ký tự để xác định hệ thống viết. Các giá trị thường gặp bao gồm:

| Script tag | Writing system |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về scheme phông chữ của theme, không phải cho các đoạn văn bản cá nhân. Một bản trình chiếu có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể bỏ qua các ánh xạ cho một số script.

## **Truy cập và Kiểm tra các Ánh xạ Phông chữ Script**

Sử dụng [Presentation::get_MasterTheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_mastertheme/) để truy cập theme ở cấp bản trình chiếu. Các phương thức [FontScheme::get_Major](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/fontscheme/get_major/) và [FontScheme::get_Minor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/fontscheme/get_minor/) trả về hai bộ sưu tập [IFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifonts/).

Gọi [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/getscriptfontmap/) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [Fonts::GetScriptFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/getscriptfont/) với thẻ script của nó. `GetScriptFont` trả về một chuỗi null khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi các Ánh xạ và Xác minh Tính Bền vững**

Sử dụng [Fonts::SetScriptFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/setscriptfont/) để tạo một ánh xạ hoặc thay thế họ phông chữ hiện tại. Sử dụng [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/removescriptfont/) để xóa một ánh xạ.

Ví dụ toàn diện sau đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho tiếng Nhật, thay đổi phông chữ chính cho Cyrillic, xóa ánh xạ phụ cho Thaana, lưu bản trình chiếu và mở lại để xác minh cả hai thay đổi. Để làm bước xóa không phụ thuộc vào theme ban đầu, ví dụ đầu tiên tạo một ánh xạ Thaana chỉ khi chưa có định nghĩa.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Quá trình xác minh sử dụng cùng hành vi trả về chuỗi null như một tra cứu thông thường: sau khi việc xóa được lưu, `GetScriptFont(u"Thaa")` trả về một chuỗi null cho bộ sưu tập phụ.

## **Phân biệt các Ánh xạ Theme với Các Cài đặt Phông chữ Khác**

Các ánh xạ theme đặc thù cho script tham gia vào việc chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế và dự phòng:

| Cơ chế | Mục đích | Hiệu quả khi thay đổi ánh xạ theme |
|---|---|---|
| Ánh xạ phông chữ theme đặc thù cho script | Chọn phông chữ theme chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng theme font tương ứng có thể giải quyết tới họ phông chữ mới được ánh xạ. |
| Phông chữ được gán một cách rõ ràng cho một đoạn văn bản | Cố định họ phông chữ được yêu cầu cho đoạn đó thay vì dựa vào theme. | Đoạn có thể không thay đổi vì định dạng trực tiếp của nó ghi đè lên lựa chọn theme. |
| Thay thế phông chữ | Thay thế phông chữ được yêu cầu khi phông chữ đó không khả dụng hoặc khi có quy tắc thay thế áp dụng. | Nó hoạt động sau khi phông chữ đã được yêu cầu; nó không định nghĩa lại ánh xạ script của theme. |
| Phông chữ dự phòng | Cung cấp các glyph mà phông chữ đã chọn không có, thường cho các dải Unicode cụ thể. | Nó lấp đầy các glyph thiếu; nó không thay đổi ánh xạ theme đã lưu. |

For more information about the last two mechanisms, see [Font Substitution](/slides/vi/cpp/font-substitution/) and [Fallback Fonts](/slides/vi/cpp/fallback-font/).

Thay đổi một ánh xạ trong [Presentation::get_MasterTheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_mastertheme/) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn phụ thuộc vào theme đó. Văn bản có thể kế thừa một ghi đè theme từ master, layout hoặc slide, hoặc sử dụng một phông chữ được gán rõ ràng. Kiểm tra các cấp độ này khi kết quả hiển thị không tuân theo ánh xạ ở cấp bản trình chiếu.

## **Cung cấp các Phông chữ Được Ánh xạ và Xác thực Kết quả**

Một ánh xạ script lưu trữ tên họ phông chữ; nó không cài đặt hay tải tệp phông chữ tương ứng. Để hiển thị và xuất khẩu nhất quán, mọi phông chữ đã được ánh xạ phải được cài đặt trong môi trường hoặc cung cấp cho Aspose.Slides qua một nguồn tùy chỉnh như [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/loadexternalfonts/) hoặc [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Xem [Custom Fonts](/slides/vi/cpp/custom-font/) để biết các tùy chọn tải sẵn có.

Xác minh ánh xạ đã lưu chỉ khẳng định rằng định nghĩa theme đã được giữ lại. Nó không chứng minh rằng phông chữ có sẵn, chứa tất cả glyph cần thiết, hoặc tạo ra bố cục mong muốn. Render văn bản mẫu cho mỗi hệ thống viết yêu cầu thành hình ảnh hoặc PDF và kiểm tra kết quả. Điều này bắt gặp các phông chữ thiếu, phạm vi glyph không đầy đủ, hành vi dự phòng và thay đổi bố cục trước khi bản trình chiếu được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/cpp/convert-powerpoint/) để biết ví dụ về render và xuất.

## **Câu hỏi thường gặp**

**`GetScriptFont` trả về gì khi một script không được ánh xạ?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/getscriptfont/) trả về một chuỗi null khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ.

**`SetScriptFont` có thêm một ánh xạ thứ hai khi script đã tồn tại không?**

Không. [Fonts::SetScriptFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fonts/setscriptfont/) tạo ánh xạ khi nó thiếu và thay thế họ phông chữ đã ánh xạ khi thẻ script giống đã có.

**Tại sao việc thay đổi một ánh xạ theme lại không thay đổi một số văn bản?**

Văn bản có thể có phông chữ được gán rõ ràng, kế thừa theme khác thông qua một ghi đè, hoặc bị ảnh hưởng bởi việc thay thế hoặc dự phòng trong quá trình render. Một ánh xạ script ở mức bản trình chiếu chỉ kiểm soát văn bản mà định dạng thực tế vẫn tham chiếu tới bộ sưu tập phông chữ theme đó.

**Việc lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác minh tính bền vững của dữ liệu theme. Ngoài ra cần render văn bản mẫu từ mỗi hệ thống viết yêu cầu để xác nhận các phông chữ đã ánh xạ có sẵn và chứa các glyph cần thiết.