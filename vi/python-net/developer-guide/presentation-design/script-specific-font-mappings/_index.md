---
title: Quản lý phông chữ Theme theo script trong Python
linktitle: Phông chữ Theme theo script
type: docs
weight: 15
url: /vi/python-net/script-specific-font-mappings/
keywords:
- phông chữ theo script
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
- Python
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ theo script trong các theme PowerPoint bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Một chủ đề trình chiếu có thể chọn các bộ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của chủ đề để tuân theo một sơ đồ phông chữ phối hợp trong khi sử dụng các phông chữ phù hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các script khác.

Chủ đề của theme chứa một bộ sưu tập phông chữ chính, thường được dùng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường được dùng cho nội dung văn bản. Ngoài các thuộc tính phông chữ Latin và Đông Á, cả hai bộ sưu tập đều cung cấp ánh xạ từ các thẻ hệ thống viết tới tên bộ phông chữ thông qua lớp [Fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/).

Bài viết này chỉ ra cách kiểm tra và sửa đổi các ánh xạ đó trong theme master của bản trình chiếu và xác nhận rằng các thay đổi vẫn tồn tại sau một vòng lưu và tải lại.

## **Hiểu các thẻ script**

Các phương thức phông chữ script sử dụng các thẻ phụ script BCP 47 gồm bốn ký tự để xác định hệ thống viết. Các giá trị phổ biến bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Tiếng Trung giản thể |
| `Jpan` | Tiếng Nhật |
| `Geor` | Tiếng Georgia |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về theme font scheme, không phải từng phần văn bản riêng lẻ. Một bản trình chiếu có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể không có ánh xạ cho một số script.

## **Truy cập và Kiểm tra ánh xạ phông chữ Script**

Sử dụng [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/) để truy cập theme ở mức bản trình chiếu. Các thuộc tính [FontScheme.major](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/major/) và [FontScheme.minor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/minor/) trả về hai bộ sưu tập [Fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/).

Gọi [Fonts.get_script_font_map](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/get_script_font_map/) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết cụ thể, gọi [Fonts.get_script_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/get_script_font/) với thẻ script của nó. `get_script_font` trả về `None` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi ánh xạ và Xác nhận tính bền vững**

Sử dụng [Fonts.set_script_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/set_script_font/) để tạo một ánh xạ mới hoặc thay thế bộ phông chữ hiện tại. Sử dụng [Fonts.remove_script_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/remove_script_font/) để xóa một ánh xạ.

Ví dụ toàn diện dưới đây đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính của Japanese, thay đổi phông chữ chính của Cyrillic, xóa ánh xạ phụ của Thaana, lưu bản trình chiếu và mở lại để xác minh cả hai thay đổi. Để bước xóa không phụ thuộc vào theme ban đầu, ví dụ đầu tiên tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào được định nghĩa.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Việc xác minh sử dụng cùng hành vi trả về `None` như một tra cứu thông thường: sau khi lưu bước xóa, `get_script_font("Thaa")` trả về `None` cho bộ sưu tập phụ.

## **Phân biệt ánh xạ chủ đề với các cài đặt phông chữ khác**

Ánh xạ phông chữ theme theo script tham gia vào việc lựa chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế và fallback:

| Cơ chế | Mục đích | Ảnh hưởng khi thay đổi một ánh xạ theme |
|---|---|---|
| Ánh xạ phông chữ theme theo script | Chọn phông chữ theme chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ theme tương ứng sẽ được giải quyết thành họ phông chữ mới được ánh xạ. |
| Phông chữ được gán trực tiếp cho một đoạn văn bản | Đặt cố định họ phông chữ yêu cầu cho đoạn đó thay vì dựa vào theme. | Đoạn văn có thể không thay đổi vì định dạng trực tiếp ghi đè lựa chọn theme. |
| Thay thế phông chữ | Thay thế phông chữ yêu cầu khi phông chữ đó không khả dụng hoặc khi quy tắc thay thế áp dụng. | Hoạt động sau khi phông chữ đã được yêu cầu; không định nghĩa lại ánh xạ script của theme. |
| Fallback phông chữ | Cung cấp các glyph mà phông chữ đã chọn không có, thường cho các dải Unicode cụ thể. | Bổ sung các glyph thiếu; không thay đổi ánh xạ theme đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối cùng, xem [Font Substitution](/slides/vi/python-net/font-substitution/) và [Fallback Fonts](/slides/vi/python-net/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn phụ thuộc vào theme đó. Văn bản có thể kế thừa một theme override từ master, layout hoặc slide, hoặc sử dụng phông chữ được gán trực tiếp. Kiểm tra các mức này khi kết quả hiển thị không theo ánh xạ ở mức bản trình chiếu.

## **Cung cấp các phông chữ đã ánh xạ và Xác thực kết quả**

Một ánh xạ script chỉ lưu tên họ phông chữ; nó không cài đặt hay tải file phông chữ tương ứng. Để đảm bảo việc render và xuất khẩu đồng nhất, mỗi phông chữ đã ánh xạ phải được cài đặt trong môi trường hoặc cung cấp cho Aspose.Slides thông qua nguồn tùy chỉnh như [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/load_external_fonts/) hoặc [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/document_level_font_sources/). Xem [Custom Fonts](/slides/vi/python-net/custom-font/) để biết các tùy chọn tải.

Xác thực ánh xạ đã lưu chỉ chứng minh rằng định nghĩa theme đã được giữ lại. Nó không chứng minh phông chữ có sẵn, chứa đầy đủ glyph cần thiết, hay tạo ra bố cục mong muốn. Hãy render văn bản mẫu cho mỗi hệ thống viết yêu cầu thành hình ảnh hoặc PDF và kiểm tra đầu ra. Cách này sẽ phát hiện phông chữ thiếu, coverage glyph không đầy đủ, hành vi fallback và thay đổi bố cục trước khi bản trình chiếu được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/python-net/convert-powerpoint/) để biết ví dụ render và xuất.

## **Câu hỏi thường gặp**

**`get_script_font` trả về gì khi một script không được ánh xạ?**

[Fonts.get_script_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/get_script_font/) trả về `None` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ tương ứng.

**`set_script_font` có thêm một ánh xạ thứ hai khi script đã tồn tại không?**

Không. [Fonts.set_script_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fonts/set_script_font/) tạo ánh xạ khi chưa có và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có trong bộ sưu tập.

**Tại sao việc thay đổi một ánh xạ theme không thay đổi một số văn bản?**

Văn bản có thể đã được gán phông chữ trực tiếp, kế thừa một theme khác qua override, hoặc bị ảnh hưởng bởi cơ chế thay thế hoặc fallback trong quá trình render. Ánh xạ script ở mức bản trình chiếu chỉ điều khiển những văn bản mà định dạng thực tế vẫn tham chiếu đến bộ sưu tập phông chữ của theme.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác nhận tính bền vững của dữ liệu theme. Cũng cần render văn bản mẫu từ mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã ánh xạ có sẵn và chứa các glyph cần thiết.