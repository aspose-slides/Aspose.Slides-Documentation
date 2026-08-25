---
title: "Tùy chỉnh phông chữ PowerPoint trong Python"
linktitle: "Phông chữ tùy chỉnh"
type: docs
weight: 20
url: /vi/python-net/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Nhúng phông chữ tùy chỉnh vào các slide PowerPoint với Aspose.Slides for Python qua .NET để giữ cho bài thuyết trình của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides for Python cho phép bạn cung cấp phông chữ tùy chỉnh tại thời gian chạy để các bài thuyết trình hiển thị chính xác ngay cả khi các phông chữ cần thiết không được cài đặt trên hệ thống máy chủ. Khi xuất ra PDF hoặc ảnh, bạn có thể cung cấp các thư mục phông chữ hoặc dữ liệu phông chữ trong bộ nhớ để bảo toàn bố cục văn bản, chỉ số glyph và kiểu chữ. Điều này làm cho việc render phía máy chủ dự đoán được trên các môi trường khác nhau, loại bỏ phụ thuộc phông chữ ở mức hệ điều hành và ngăn ngừa việc thay thế hoặc thay đổi bố cục không mong muốn. Bài viết này trình bày cách đăng ký nguồn phông chữ.

Một chủ đề bài thuyết trình có thể tham chiếu các họ phông chữ khác nhau cho từng hệ thống viết riêng biệt. Những ánh xạ này chỉ lưu tên phông chữ mà không cài đặt hoặc tải các tệp phông chữ. Xem [Script-Specific Theme Fonts](/slides/vi/python-net/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải bên dưới để làm cho các phông chữ được tham chiếu sẵn sàng cho việc render nhất quán.

Aspose.Slides cho phép bạn tải các phông chữ sau bằng các phương thức `load_external_font` và `load_external_fonts` của lớp [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/):

- Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Tải Phông chữ Tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bài thuyết trình mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng tới đầu ra khi xuất—như PDF, hình ảnh và các định dạng hỗ trợ khác—để tài liệu tạo ra có giao diện nhất quán trên các môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Chỉ định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/load_external_fonts/) để tải phông chữ từ các thư mục đó.
3. Tải và render/​xuất bài thuyết trình.
4. Gọi [FontsLoader.clear_cache](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/clear_cache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```py
import aspose.slides as slides

# Định nghĩa các thư mục chứa các tệp phông chữ tùy chỉnh.
font_folders = ["fonts", "external_fonts"]

# Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/​xuất bài thuyết trình (ví dụ: sang PDF, hình ảnh, hoặc các định dạng khác) bằng các phông chữ đã tải.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn thành.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/load_external_fonts/) thêm các thư mục vào đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy Thư Mục Phông chữ Tùy chỉnh**

Aspose.Slides cung cấp phương thức `get_font_folders` để lấy các thư mục phông chữ. Nó trả về cả các thư mục được thêm thông qua `load_external_fonts` và các thư mục phông chữ hệ thống.

Đoạn mã Python sau cho thấy cách sử dụng `get_font_folders`:

```python
import aspose.slides as slides

# Lệnh này trả về các thư mục được kiểm tra cho các tệp phông chữ.
# Các thư mục này bao gồm các thư mục được thêm qua phương thức load_external_fonts và các thư mục phông chữ hệ thống.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Xác Định Phông chữ Tùy chỉnh Cho Một Bài Thuyết Trình**

Aspose.Slides cung cấp thuộc tính `document_level_font_sources`, cho phép bạn chỉ định các phông chữ bên ngoài để sử dụng trong một bài thuyết trình.

Ví dụ Python sau cho thấy cách sử dụng `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Làm việc với bài thuyết trình.
    # CustomFont1, CustomFont2 và các phông chữ từ các thư mục assets\fonts và global\fonts (cũng như các thư mục con của chúng) có sẵn cho bài thuyết trình.
    # ...
    print(len(presentation.slides))
```

## **Tải Phông chữ Bên Ngoài Từ Dữ liệu Nhị phân**

Aspose.Slides cung cấp phương thức `load_external_font` để tải phông chữ bên ngoài từ dữ liệu nhị phân.

Ví dụ Python sau minh họa việc tải một phông chữ từ một mảng byte:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Tải phông chữ bên ngoài từ các mảng byte.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Phông chữ bên ngoài có sẵn trong suốt thời gian tồn tại của instance Presentation này.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Câu Hỏi Thường Gặp**

### Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất sang tất cả các định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông chữ được kết nối sẽ được bộ render sử dụng cho mọi định dạng xuất.

### Phông chữ tùy chỉnh có tự động được nhúng vào file PPTX kết quả không?

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong file bài thuyết trình, bạn phải sử dụng các [tính năng nhúng](/slides/vi/python-net/embedded-font/).

### Tôi có thể kiểm soát hành vi fallback khi một phông chữ tùy chỉnh thiếu một số glyph không?

Có. Hãy cấu hình [font substitution](/slides/vi/python-net/font-substitution/), [replacement rules](/slides/vi/python-net/font-replacement/), và [fallback sets](/slides/vi/python-net/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cần cài đặt chúng trên hệ thống không?

Có. Chỉ định các thư mục phông chữ của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào thư mục phông chữ hệ thống trong image container.

### Về bản quyền—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không bị hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép sử dụng phông chữ. Các điều khoản khác nhau; một số giấy phép cấm nhúng hoặc sử dụng thương mại. Luôn xem xét EULA của phông chữ trước khi phân phối các kết quả.