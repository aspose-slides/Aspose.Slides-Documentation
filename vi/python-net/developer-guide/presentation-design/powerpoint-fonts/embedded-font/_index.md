---
title: Nhúng Phông Chữ trong Bản Trình Chiếu với Python
linktitle: Phông Chữ Nhúng
type: docs
weight: 40
url: /vi/python-net/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý phông chữ đã nhúng trong PowerPoint bằng Aspose.Slides cho Python qua .NET. Sử dụng Python để thêm, truy xuất, xóa và nén phông chữ nhằm bảo tồn giao diện văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Nhúng phông chữ lưu trữ dữ liệu phông chữ bên trong một bản trình chiếu PowerPoint. Khi một trình xem hỗ trợ phông chữ nhúng, nó có thể hiển thị văn bản bằng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống đích. Điều này giúp bảo toàn các ngắt dòng, khoảng cách văn bản và bố cục slide.

Aspose.Slides for Python qua .NET cho phép bạn truy xuất, thêm và xóa phông chữ nhúng thông qua thuộc tính [fonts_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/) của một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) . Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản trình chiếu không sử dụng.

Các ví dụ dưới đây hoạt động với các tệp PPTX. Trước khi nhúng phông chữ, hãy chắc chắn dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông Chữ Nhúng**

Sử dụng [get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) để liệt kê các phông chữ được lưu trong một bản trình chiếu. Để xóa một phông chữ, truyền phông chữ từ danh sách đó vào [remove_embedded_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/remove_embedded_font/), sau đó lưu bản trình chiếu.

Ví dụ sau liệt kê các phông chữ nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Việc xóa một phông chữ nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Nếu không, việc hiển thị có thể yêu cầu [font substitution](/slides/vi/python-net/font-substitution/), điều này có thể ảnh hưởng tới bố cục.

## **Kiểm Tra Dữ Liệu Phông Chữ và Quyền Nhúng**

Sử dụng lớp [FontsManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/) để kiểm tra các phông chữ trước khi nhúng chúng. Gọi [get_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để lấy các phông chữ được sử dụng trong bản trình chiếu. Đối với mỗi phông chữ, truyền một đối tượng [FontData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontstyletype/) cần thiết vào [get_font_bytes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_font_bytes/). Phương thức này trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `None` khi phông chữ hoặc kiểu được yêu cầu không khả dụng. Đừng truyền kết quả `None` vào [get_font_embedding_level](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), vì phương thức này yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/python-net/aspose.slides/embeddinglevel/) là một enum kiểu cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `INSTALLABLE` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép của phông chữ.
- `RESTRICTED` cấm nhúng trừ khi có sự cho phép từ chủ sở hữu pháp lý của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PREVIEW_PRINT` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `EDITABLE` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu.
- `NO_SUBSETTING` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần con của các glyph. Khi cờ này hiện diện, phải nhúng toàn bộ ký tự.
- `BITMAP_ONLY` là một hạn chế bổ sung chỉ cho phép nhúng các bitmap strike, không phải dữ liệu outline. Nếu phông chữ không có bitmap strike, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NO_SUBSETTING` và `BITMAP_ONLY` có thể được kết hợp với chúng. Kiểm tra các bộ sửa đổi bằng các phép toán bitwise. Vì `INSTALLABLE` bằng không, hãy tạo mask cho các bit quyền sử dụng và so sánh kết quả với `INSTALLABLE`. Các phông chữ hiện tại nên đặt tối đa một bit quyền sử dụng. Đối với tính tương thích với các phông chữ cũ hơn đặt hơn một bit, trợ giúp bên dưới sẽ chọn quyền ít hạn chế nhất: `EDITABLE`, sau đó `PREVIEW_PRINT`, cuối cùng `RESTRICTED`.

Ví dụ sau kiểm tra dữ liệu regular, bold, italic và bold-italic có sẵn cho mỗi phông chữ được trả về bởi `get_fonts`. Nó bỏ qua các kiểu không khả dụng, các phông chữ bị hạn chế, phông chữ chỉ bitmap, phông chữ chỉ giới hạn ở preview và print vì kết quả vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào khả dụng có `NO_SUBSETTING`, nó sẽ nhúng toàn bộ ký tự cho họ phông chữ đó.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Việc kiểm tra này báo cáo các hạn chế được mã hóa trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã nhận được phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao đã nhúng.

## **Thêm Phông Chữ Nhúng**

Sử dụng [add_embedded_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/add_embedded_font/) để nhúng một phông chữ. Các overload của nó chấp nhận hoặc một đối tượng [FontData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. Enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/embedfontcharacters/) kiểm soát các ký tự được bao gồm:

- [ALL](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/embedfontcharacters/) nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình chiếu và nhập văn bản mới.
- [ONLY_USED](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/embedfontcharacters/) chỉ nhúng các ký tự được sử dụng trong bản trình chiếu để giảm kích thước tệp. Chọn tùy chọn này cho bản trình chiếu đã hoàn thiện, chủ yếu để xem.

Ví dụ sau sử dụng [get_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để lấy các phông chữ được sử dụng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng hiện có giữ lại bộ ký tự hiện tại.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Nén Phông Chữ Nhúng**

[compress_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không sử dụng. Nó hoạt động trên các phông chữ đã được nhúng, do đó mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không sử dụng trong bản trình chiếu.

Ví dụ dưới đây nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả thành một tệp riêng:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Giữ tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ đã nhúng, ngay cả khi bạn đã nhúng toàn bộ ký tự ban đầu.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể kiểm tra xem một phông chữ đã nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [get_substitutions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_substitutions/) trong môi trường bạn render bản trình chiếu để xem Aspose.Slides sẽ thay thế các phông chữ nào. Cũng kiểm tra cài đặt [font substitution](/slides/vi/python-net/font-substitution/) và quy tắc [font fallback](/slides/vi/python-net/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết các ký tự mà phông chữ đó không chứa.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Căn cứ quyết định vào môi trường mục tiêu. Nếu các phông chữ cần thiết có sẵn trên mọi máy mở hoặc render bản trình chiếu, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc server có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp bảo toàn giao diện mong muốn, với điều kiện giấy phép cho phép.