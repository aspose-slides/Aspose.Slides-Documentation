---
title: Nhúng Phông Chữ trong Bản Trình Chiếu bằng Python qua Java
linktitle: Phông Chữ Được Nhúng
type: docs
weight: 40
url: /vi/python-java/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- việc nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý phông chữ được nhúng trong PowerPoint bằng Aspose.Slides cho Python qua Java. Thêm, lấy, xóa và nén phông chữ để giữ nguyên giao diện văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Embedding fonts lưu trữ dữ liệu phông chữ bên trong một bản trình chiếu PowerPoint. Khi người xem hỗ trợ phông chữ được nhúng, họ có thể hiển thị văn bản bằng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống mục tiêu. Điều này giúp giữ nguyên ngắt dòng, khoảng cách chữ và bố cục slide.

Aspose.Slides for Python via Java cho phép bạn truy xuất, thêm và xóa phông chữ được nhúng thông qua lớp [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) được trả về bởi [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getFontsManager). Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản trình chiếu không sử dụng.

Các ví dụ dưới đây làm việc với tệp PPTX. Trước khi nhúng một phông chữ, hãy chắc chắn dữ liệu phông chữ đó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông Chữ Được Nhúng**

Sử dụng [getEmbeddedFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) để liệt kê các phông chữ được lưu trong bản trình chiếu. Để xóa một phông chữ, truyền phông chữ từ danh sách đó vào [removeEmbeddedFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont), sau đó lưu bản trình chiếu.

Ví dụ dưới đây liệt kê các phông chữ được nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Việc xóa một phông chữ được nhúng sẽ loại bỏ dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ được cài đặt trên hệ thống mục tiêu, văn bản vẫn có thể sử dụng nó. Nếu không, quá trình render có thể yêu cầu thay thế phông chữ, điều này có thể ảnh hưởng đến bố cục.

## **Kiểm Tra Dữ Liệu Phông Chữ và Quyền Nhúng**

Sử dụng lớp [FontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/) để kiểm tra phông chữ trước khi nhúng. Gọi [FontsManager.getFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được dùng trong bản trình chiếu. Đối với mỗi phông chữ, truyền một đối tượng [FontData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontstyletype/) yêu cầu vào [FontsManager.getFontBytes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFontBytes). Phương thức trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `None` khi phông chữ hoặc kiểu yêu cầu không khả dụng. Đừng truyền kết quả `None` vào [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), vì phương thức này yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/embeddinglevel/) là một enumeration dạng cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép phông chữ.
- `Restricted` cấm nhúng trừ khi có sự cho phép từ chủ sở hữu pháp lý của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu lại.
- `NoSubsetting` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần của glyphs. Khi cờ này có mặt, hãy nhúng toàn bộ ký tự.
- `BitmapOnly` là một hạn chế bổ sung cho phép chỉ nhúng các bitmap strike, không nhúng dữ liệu outline. Nếu phông chữ không có bitmap strike, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể được kết hợp với chúng. Kiểm tra các bộ sửa đổi bằng các phép toán bitwise. Vì `Installable` có giá trị zero, hãy mask các bit quyền sử dụng và so sánh kết quả với `Installable` thay vì kiểm tra nó như một cờ. Các phông chữ hiện tại nên đặt nhiều nhất một bit quyền sử dụng. Đối với các phông chữ cũ hơn có thể đặt hơn một bit, helper dưới đây sẽ chọn quyền ít hạn chế nhất: `Editable`, sau đó `PreviewPrint`, rồi `Restricted`.

Ví dụ sau kiểm tra dữ liệu thường, in đậm, nghiêng và in đậm-nghiêng cho mỗi phông chữ trả về bởi `getFonts`. Nó bỏ qua các kiểu không khả dụng, phông chữ bị hạn chế, phông chữ chỉ bitmap, phông chữ chỉ cho preview và print vì đầu ra vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào khả dụng có `NoSubsetting`, nó sẽ nhúng toàn bộ ký tự cho họ/font family đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kiểm tra này báo cáo các hạn chế được mã hoá trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh bạn đã lấy phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao đã nhúng.

## **Thêm Phông Chữ Được Nhúng**

Sử dụng [addEmbeddedFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) để nhúng một phông chữ. Các overload của nó chấp nhận một đối tượng [FontData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. Enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/embedfontcharacters/) điều khiển các ký tự sẽ được bao gồm:

- [All](https://reference.aspose.com/slides/vi/python-java/aspose.slides/embedfontcharacters/) nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản trình chiếu và nhập văn bản mới.
- [OnlyUsed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/embedfontcharacters/) chỉ nhúng các ký tự được sử dụng trong bản trình chiếu để giảm kích thước tệp. Chọn tùy chọn này cho bản trình chiếu đã hoàn thiện và chủ yếu dành cho việc xem.

Ví dụ sau sử dụng [getFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được dùng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ đã nhúng sẽ giữ nguyên bộ ký tự hiện tại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nén Phông Chữ Được Nhúng**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#compressEmbeddedFonts) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không sử dụng. Nó hoạt động trên các phông chữ đã được nhúng, vì vậy mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không dùng trong bản trình chiếu.

Ví dụ dưới đây nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả thành một tệp riêng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Giữ tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ đã nhúng, ngay cả khi ban đầu bạn đã nhúng toàn bộ ký tự.

## **Câu Hỏi Thường Gặp**

**Làm sao để kiểm tra một phông chữ được nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [getSubstitutions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getSubstitutions) trong môi trường bạn render bản trình chiếu để xem Aspose.Slides sẽ thay thế phông chữ nào. Cũng hãy kiểm tra cài đặt thay thế phông chữ và quy tắc fallback. Fallback xử lý các ký tự thiếu, vì vậy việc nhúng phông chữ không giải quyết các ký tự mà chính phông chữ đó không chứa.

**Có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Quyết định dựa trên môi trường mục tiêu. Nếu các phông chữ cần thiết đã có trên mọi máy mở hoặc render bản trình chiếu, việc nhúng chúng có thể làm tăng kích thước tệp không cần. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ này, việc nhúng sẽ giúp bảo toàn giao diện mong muốn, với điều kiện giấy phép cho phép.