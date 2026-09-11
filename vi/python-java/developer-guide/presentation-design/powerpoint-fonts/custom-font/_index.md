---
title: Tùy chỉnh phông chữ PowerPoint trong Python qua Java
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/python-java/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho Python qua Java để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bản trình chiếu mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình chiếu cụ thể thông qua nguồn phông chữ cấp tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình chiếu được render hoặc xuất, chẳng hạn thành PDF, hình ảnh và các định dạng được hỗ trợ khác. Điều này giúp duy trì đầu ra của bản trình chiếu nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ được Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để render là một quy trình riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ phải được lưu trong bản trình chiếu, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

Một chủ đề bản trình chiếu có thể tham chiếu các họ phông chữ khác nhau cho các hệ thống viết riêng lẻ. Các ánh xạ này lưu trữ tên phông chữ nhưng không cài đặt hoặc tải tệp phông chữ. Xem [Script-Specific Theme Fonts](/slides/vi/python-java/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải bên dưới để làm cho các phông chữ được tham chiếu sẵn sàng cho việc render nhất quán.

{{% alert color="info" title="Note" %}}
Aspose.Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra khi xuất — chẳng hạn PDF, hình ảnh và các định dạng được hỗ trợ khác — để các tài liệu kết quả trông nhất quán trên các môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFonts) để tải phông chữ từ các thư mục đó.
3. Tải và render/​xuất bản trình chiếu.
4. Gọi [FontsLoader.clearCache](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#clearCache) để xóa bộ nhớ cache phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Xác định các thư mục chứa các tệp phông chữ tùy chỉnh.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Render/​xuất bản trình chiếu sử dụng các phông chữ đã tải.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Xóa bộ nhớ cache phông chữ sau khi công việc hoàn thành.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFonts) thêm các thư mục bổ sung vào các đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Các phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải thông qua [FontsLoader](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**
Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#getFontFolders) cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFonts) và các thư mục phông chữ hệ thống.

Đoạn mã Python sau cho bạn cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Lấy các thư mục được thêm thông qua loadExternalFonts và các thư mục phông chữ hệ thống.
font_folders = FontsLoader.getFontFolders()
```

## **Chỉ định phông chữ tùy chỉnh được sử dụng trong bản trình chiếu**
Aspose.Slides cung cấp phương thức [getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng với bản trình chiếu. 

Đoạn mã Python dưới đây cho bạn cách sử dụng phương thức [getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Làm việc với bản trình chiếu.
    # CustomFont1, CustomFont2, và các phông chữ từ assets/fonts và global/fonts
    # và các thư mục con của chúng có sẵn cho bản trình chiếu.
    pass
finally:
    presentation.dispose()
```

## **Quản lý phông chữ bên ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadExternalFont) cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Đoạn mã Python sau minh họa quy trình tải phông chữ từ mảng byte:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Phông chữ bên ngoài được tải trong suốt thời gian tồn tại của bản trình chiếu.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **Câu hỏi thường gặp**

**Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang mọi định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ đã kết nối được trình render sử dụng cho tất cả các định dạng xuất.

**Phông chữ tùy chỉnh có tự động được nhúng vào file PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang bên trong tệp bản trình chiếu, bạn phải sử dụng các [tính năng nhúng](/slides/vi/python-java/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/python-java/font-substitution/), [replacement rules](/slides/vi/python-java/font-replacement/), và [fallback sets](/slides/vi/python-java/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào các thư mục phông chữ hệ thống trong ảnh container.

**Còn về bản quyền—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?**

Bạn chịu trách nhiệm tuân thủ các quy định bản quyền phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn kiểm tra EULA của phông chữ trước khi phân phối kết quả.