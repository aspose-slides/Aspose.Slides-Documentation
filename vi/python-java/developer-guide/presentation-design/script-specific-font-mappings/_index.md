---
title: Quản lý phông chữ chủ đề riêng cho script trong Python qua Java
linktitle: Phông chữ chủ đề riêng cho script
type: docs
weight: 15
url: /vi/python-java/script-specific-font-mappings/
keywords:
- phông chữ riêng cho script
- ánh xạ phông chữ chủ đề
- bài thuyết trình đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Ả Rập
- phông chữ Nhật
- phông chữ Gruzia
- phông chữ Thaana
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ riêng cho script trong các chủ đề PowerPoint bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Một chủ đề bài thuyết trình có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của chủ đề để tuân theo một sơ đồ phông chữ thống nhất trong khi dùng các phông chữ phù hợp cho Cyrillic, Ả Rập, Nhật, Gruzia, Thaana và các chữ viết khác.

[FontScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontscheme/) của chủ đề chứa một bộ sưu tập phông chữ chính, thường dùng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường dùng cho nội dung. Ngoài các cài đặt phông chữ Latin và Đông Á, cả hai bộ sưu tập đều cung cấp các ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ thông qua lớp [Fonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/).

Bài viết này minh họa cách kiểm tra và sửa đổi các ánh xạ đó trong chủ đề master của bài thuyết trình và xác minh rằng các thay đổi vẫn tồn tại sau một chu kỳ lưu‑và‑tải lại.

## **Hiểu các thẻ script**

Các phương thức phông chữ script sử dụng các thẻ phụ script BCP 47 gồm bốn ký tự để xác định hệ thống viết. Các giá trị phổ biến bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Ả Rập |
| `Hans` | Tiếng Trung giản thể |
| `Jpan` | Tiếng Nhật |
| `Geor` | Tiếng Gruzia |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về sơ đồ phông chữ của chủ đề, không phải của các phần văn bản riêng lẻ. Một bài thuyết trình có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể không có ánh xạ cho một số script nào đó.

## **Truy cập và kiểm tra ánh xạ phông chữ script**

Sử dụng [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasterTheme) để truy cập chủ đề ở mức bài thuyết trình. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontscheme/#getMajor) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontscheme/#getMinor) trả về hai bộ sưu tập [Fonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/) tương ứng.

Gọi [Fonts.getScriptFontMap](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#getScriptFontMap) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [Fonts.getScriptFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#getScriptFont) với thẻ script của nó. `getScriptFont` trả về `None` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi ánh xạ và xác minh độ bền**

Sử dụng [Fonts.setScriptFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#setScriptFont) để tạo một ánh xạ hoặc thay thế họ phông chữ hiện tại. Sử dụng [Fonts.removeScriptFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#removeScriptFont) để xóa một ánh xạ.

Ví dụ toàn diện dưới đây đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho Nhật, thay đổi phông chữ chính cho Cyrillic, xóa ánh xạ phụ cho Thaana, lưu bài thuyết trình và mở lại để xác minh cả hai thay đổi. Để bước xóa không phụ thuộc vào chủ đề ban đầu, ví dụ đầu tiên tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào được định nghĩa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Việc xác minh sử dụng cùng hành vi `None` như một tra cứu thông thường: sau khi lưu xong, `getScriptFont("Thaa")` trả về `None` cho bộ sưu tập phụ.

## **Phân biệt ánh xạ chủ đề với các cài đặt phông chữ khác**

Ánh xạ chủ đề riêng cho script tham gia vào việc lựa chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế phông chữ và fallback:

| Cơ chế | Mục đích | Ảnh hưởng khi thay đổi ánh xạ chủ đề |
|---|---|---|
| Ánh xạ phông chữ chủ đề riêng cho script | Chọn phông chữ chủ đề chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ chủ đề tương ứng có thể được ánh xạ tới họ mới. |
| Phông chữ được gán trực tiếp cho một phần văn bản | Ghi cố định họ phông chữ yêu cầu cho phần đó thay vì dựa vào chủ đề. | Phần văn bản có thể không thay đổi vì định dạng trực tiếp ghi đè lên lựa chọn chủ đề. |
| Thay thế phông chữ | Thay thế phông chữ yêu cầu khi phông chữ đó không khả dụng hoặc khi quy tắc thay thế áp dụng. | Thực hiện sau khi đã yêu cầu phông chữ; không định nghĩa lại ánh xạ script của chủ đề. |
| Fallback phông chữ | Cung cấp các glyph mà phông chữ đã chọn không chứa, thường cho các dải Unicode cụ thể. | Điền vào các glyph còn thiếu; không thay đổi ánh xạ chủ đề đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối, xem [Font Substitution](/slides/vi/python-java/font-substitution/) và [Fallback Fonts](/slides/vi/python-java/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasterTheme) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn phụ thuộc vào chủ đề đó. Văn bản có thể thay vì đó kế thừa một ghi đè chủ đề từ master, layout hoặc slide, hoặc sử dụng phông chữ được gán trực tiếp. Kiểm tra các cấp này khi kết quả hiển thị không theo ánh xạ ở mức bài thuyết trình.

## **Cung cấp phông chữ đã ánh xạ và xác thực kết quả**

Một ánh xạ script chỉ lưu trữ tên họ phông chữ; nó không cài đặt hay tải tệp phông chữ tương ứng. Để hiển thị nhất quán và xuất file, mọi phông chữ đã ánh xạ phải được cài đặt trong môi trường hoặc được cung cấp cho Aspose.Slides qua một nguồn tùy chỉnh như [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFonts) hoặc [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Xem [Custom Fonts](/slides/vi/python-java/custom-font/) để biết các tùy chọn tải.

Xác minh ánh xạ đã lưu chỉ chứng minh rằng định nghĩa chủ đề được giữ lại. Nó không chứng minh rằng phông chữ khả dụng, chứa đầy đủ glyph cần thiết, hay tạo ra bố cục mong muốn. Hãy render văn bản mẫu cho mỗi hệ thống viết yêu cầu thành hình ảnh hoặc PDF và kiểm tra đầu ra. Điều này giúp phát hiện phông chữ thiếu, phạm vi glyph không đầy đủ, hành vi fallback và thay đổi bố cục trước khi phân phối bài thuyết trình. Xem [Convert PowerPoint Presentations](/slides/vi/python-java/convert-powerpoint/) để biết các ví dụ về render và xuất.

## **Câu hỏi thường gặp**

**`getScriptFont` trả về gì khi một script không được ánh xạ?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#getScriptFont) trả về `None` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ tương ứng.

**`setScriptFont` có tạo ánh xạ thứ hai khi script đã tồn tại không?**

Không. [Fonts.setScriptFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fonts/#setScriptFont) tạo ánh xạ khi nó thiếu và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có trong bộ sưu tập.

**Tại sao việc thay đổi ánh xạ chủ đề không làm thay đổi một số văn bản?**

Văn bản có thể có phông chữ được gán trực tiếp, kế thừa một chủ đề khác thông qua ghi đè, hoặc bị ảnh hưởng bởi việc thay thế hoặc fallback khi render. Ánh xạ script ở mức bài thuyết trình chỉ điều khiển những văn bản mà định dạng thực tế vẫn tham chiếu tới bộ phông chữ của chủ đề đó.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác minh độ bền của dữ liệu chủ đề. Cũng cần render văn bản mẫu từ mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã ánh xạ khả dụng và chứa các glyph cần thiết.