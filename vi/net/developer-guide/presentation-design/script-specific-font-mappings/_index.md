---
title: Quản lý phông chữ theme theo script trong .NET
linktitle: Phông chữ theme theo script
type: docs
weight: 15
url: /vi/net/script-specific-font-mappings/
keywords:
- phông chữ theo script
- ánh xạ phông chữ theme
- bản trình chiếu đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Ả Rập
- phông chữ Nhật
- phông chữ Georgian
- phông chữ Thaana
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ theo script trong theme PowerPoint bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Một giao diện (theme) trình chiếu có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của giao diện và tuân theo một lược đồ phông chữ nhất quán, đồng thời sử dụng các phông chữ thích hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các chữ viết khác.

Theme chứa một bộ sưu tập phông chữ **major** thường dùng cho tiêu đề và một bộ sưu tập **minor** thường dùng cho nội dung văn bản. Ngoài các thuộc tính phông chữ Latin và Đông Á, cả hai bộ sưu tập đều cung cấp ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ thông qua giao diện [IFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/ifonts/).

Bài viết này cho thấy cách kiểm tra và sửa đổi các ánh xạ đó trong theme chính của bản trình chiếu và xác nhận rằng các thay đổi vẫn tồn tại sau một chu kỳ lưu‑và‑tải lại.

## **Hiểu các Thẻ Script**

Các phương thức phông chữ script sử dụng các phụ thẻ script BCP 47 có bốn ký tự để xác định hệ thống viết. Các giá trị thường gặp bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về **theme font scheme**, không phải các phần văn bản riêng lẻ. Một bản trình chiếu có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập major và minor, và có thể không định nghĩa ánh xạ cho một số script nhất định.

## **Truy cập và Kiểm tra Ánh xạ Phông chữ Script**

Sử dụng [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/) để truy cập theme ở mức bản trình chiếu. Các thuộc tính [FontScheme.Major](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/major/) và [FontScheme.Minor](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/minor/) trả về hai bộ sưu tập [IFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/ifonts/).

Gọi [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/getscriptfontmap/) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [IFonts.GetScriptFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/getscriptfont/) với thẻ script tương ứng. `GetScriptFont` trả về `null` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi Ánh xạ và Xác minh Tính Bền vững**

Sử dụng [IFonts.SetScriptFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/setscriptfont/) để tạo một ánh xạ hoặc thay thế họ phông chữ hiện tại. Sử dụng [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/removescriptfont/) để xóa một ánh xạ.

Ví dụ end‑to‑end dưới đây đọc tất cả các ánh xạ major và minor hiện có, tra cứu phông chữ Japanese trong major, thay đổi phông chữ Cyrillic trong major, xóa ánh xạ Thaana trong minor, lưu bản trình chiếu và mở lại để xác nhận cả hai thay đổi. Để bước xóa không phụ thuộc vào theme ban đầu, ví dụ sẽ tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào được định nghĩa.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Việc xác minh sử dụng cùng hành vi `null` như một tra cứu thông thường: sau khi lưu quá trình xóa, `GetScriptFont("Thaa")` trả về `null` cho bộ sưu tập minor.

## **Phân biệt Ánh xạ Theme với Các Cài đặt Phông chữ Khác**

Ánh xạ theme theo script tham gia vào việc lựa chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế và dự phòng:

| Cơ chế | Mục đích | Hiệu quả của việc thay đổi ánh xạ theme |
|---|---|---|
| Ánh xạ phông chữ theme theo script | Chọn phông chữ theme major hoặc minor cho một hệ thống viết. | Văn bản vẫn sử dụng theme font tương ứng có thể giải quyết thành họ phông chữ mới đã được ánh xạ. |
| Phông chữ được gán trực tiếp cho một đoạn văn bản | Cố định họ phông chữ yêu cầu trên đoạn đó thay vì dựa vào theme. | Đoạn văn có thể không thay đổi vì định dạng trực tiếp ghi đè lên lựa chọn của theme. |
| Thay thế phông chữ | Thay thế phông chữ yêu cầu khi phông chữ đó không khả dụng hoặc khi quy tắc thay thế áp dụng. | Nó hoạt động sau khi phông chữ đã được yêu cầu; nó không định nghĩa lại ánh xạ script của theme. |
| Phông chữ dự phòng | Cung cấp các glyph mà phông chữ đã chọn không có, thường cho các dải Unicode cụ thể. | Nó lấp đầy các glyph còn thiếu; nó không thay đổi ánh xạ theme đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối, xem [Font Substitution](/slides/vi/net/font-substitution/) và [Fallback Fonts](/slides/vi/net/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn phụ thuộc vào theme đó. Văn bản có thể kế thừa một theme override từ master, layout hoặc slide, hoặc sử dụng một phông chữ được gán trực tiếp. Kiểm tra các cấp này khi kết quả hiển thị không tuân theo ánh xạ ở mức bản trình chiếu.

## **Cung cấp Phông chữ Đã Ánh xạ và Xác nhận Kết quả**

Một ánh xạ script chỉ lưu trữ tên họ phông chữ; nó không cài đặt hoặc tải file phông chữ tương ứng. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, mỗi phông chữ đã ánh xạ phải được cài đặt trong môi trường hoặc được cung cấp cho Aspose.Slides qua một nguồn tùy chỉnh như [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/loadexternalfonts/) hoặc [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/documentlevelfontsources/). Xem [Custom Fonts](/slides/vi/net/custom-font/) để biết các tùy chọn tải.

Xác minh ánh xạ đã lưu chỉ chứng minh rằng định nghĩa theme đã được giữ lại. Nó không chứng minh rằng phông chữ có sẵn, chứa đầy đủ glyph cần thiết, hay tạo ra bố cục mong muốn. Hãy render văn bản đại diện cho mỗi hệ thống viết yêu cầu ra ảnh hoặc PDF và kiểm tra kết quả. Cách này sẽ phát hiện phông chữ thiếu, vùng glyph không đầy đủ, hành vi dự phòng và thay đổi bố cục trước khi bản trình chiếu được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/net/convert-powerpoint/) để biết các ví dụ về render và xuất.

## **Câu hỏi thường gặp**

**`GetScriptFont` trả về gì khi một script không được ánh xạ?**  
[IFonts.GetScriptFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/getscriptfont/) trả về `null` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập major hoặc minor tương ứng.

**`SetScriptFont` có tạo thêm một ánh xạ thứ hai khi script đã tồn tại không?**  
Không. [IFonts.SetScriptFont](https://reference.aspose.com/slides/vi/net/aspose.slides/fonts/setscriptfont/) tạo ánh xạ khi chưa có và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có mặt.

**Tại sao việc thay đổi một ánh xạ theme không thay đổi một số văn bản?**  
Văn bản có thể có phông chữ được gán trực tiếp, kế thừa theme khác thông qua một override, hoặc bị ảnh hưởng bởi cơ chế thay thế hoặc dự phòng khi render. Một ánh xạ script ở mức bản trình chiếu chỉ điều khiển các văn bản mà định dạng thực tế vẫn tham chiếu đến bộ phông chữ theme đó.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**  
Không. Mở lại chỉ xác minh tính bền vững của dữ liệu theme. Cũng cần render văn bản đại diện từ mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã ánh xạ có sẵn và chứa các glyph cần thiết.