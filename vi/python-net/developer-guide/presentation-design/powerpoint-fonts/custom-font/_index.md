---
title: Tùy chỉnh phông chữ PowerPoint trong Python
linktitle: Phông chữ tùy chỉnh
type: docs
weight: 20
url: /vi/python-net/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Nhúng phông chữ tùy chỉnh vào các slide PowerPoint với Aspose.Slides cho Python qua .NET để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho Python cho phép bạn cung cấp các phông chữ tùy chỉnh ở thời gian chạy để các bản trình chiếu được hiển thị đúng ngay cả khi các phông chữ cần thiết không được cài đặt trên hệ thống máy chủ. Khi xuất ra PDF hoặc hình ảnh, bạn có thể cung cấp các thư mục phông chữ hoặc dữ liệu phông chữ trong bộ nhớ để duy trì bố cục văn bản, chỉ số glyph và kiểu chữ. Điều này giúp việc render phía máy chủ trở nên dự đoán được trên các môi trường khác nhau, loại bỏ phụ thuộc phông chữ ở mức hệ điều hành và ngăn ngừa việc thay thế không mong muốn hoặc việc thay đổi bố cục. Bài viết này cho thấy cách đăng ký nguồn phông chữ.

Aspose.Slides cho phép bạn tải các phông chữ sau bằng các phương thức `load_external_font` và `load_external_fonts` của lớp [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) và TrueType Collection (.ttc) fonts. Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) fonts. Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong một bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất — chẳng hạn như PDF, hình ảnh và các định dạng hỗ trợ khác — để các tài liệu tạo ra có giao diện nhất quán trên mọi môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/load_external_fonts/) để tải phông chữ từ các thư mục này.
3. Tải và render/ xuất bản trình chiếu.
4. Gọi [FontsLoader.clear_cache](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/clear_cache/) để xóa bộ nhớ đệm phông chữ.

Ví dụ mã sau minh họa quá trình tải phông chữ:

```py
import aspose.slides as slides

# Xác định các thư mục chứa tệp phông chữ tùy chỉnh.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Render/xuất bản trình chiếu (ví dụ: sang PDF, hình ảnh, hoặc các định dạng khác) bằng các phông chữ đã tải.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Xóa bộ nhớ đệm phông chữ sau khi công việc hoàn tất.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/load_external_fonts/) thêm các thư mục vào đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ. Các phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Lấy thư mục phông chữ tùy chỉnh**

Aspose.Slides cung cấp phương thức `get_font_folders` để truy xuất các thư mục phông chữ. Phương thức này trả về cả các thư mục đã được thêm bằng `load_external_fonts` và các thư mục phông chữ hệ thống.

Mã Python dưới đây cho thấy cách sử dụng `get_font_folders`:

```python
import aspose.slides as slides

# Lệnh này trả về các thư mục được kiểm tra cho tệp phông chữ.
# Những thư mục này bao gồm các thư mục được thêm qua phương thức load_external_fonts và các thư mục phông chữ hệ thống.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Chỉ định phông chữ tùy chỉnh cho một bản trình chiếu**

Aspose.Slides cung cấp thuộc tính `document_level_font_sources`, cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng cho một bản trình chiếu.

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
    # Làm việc với bản trình chiếu.
    # CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts và global\fonts (cùng các thư mục con) có sẵn cho bản trình chiếu.
    # ...
    print(len(presentation.slides))
```

## **Tải phông chữ bên ngoài từ dữ liệu nhị phân**

Aspose.Slides cung cấp phương thức `load_external_font` để tải các phông chữ bên ngoài từ dữ liệu nhị phân.

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
        # Phông chữ bên ngoài có sẵn trong suốt vòng đời của thể hiện bản trình chiếu này.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Câu hỏi thường gặp**

**Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất ra mọi định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông chữ đã kết nối được trình render sử dụng cho mọi định dạng xuất.

**Phông chữ tùy chỉnh có tự động được nhúng vào PPTX kết quả không?**

Không. Đăng ký một phông chữ để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang trong tệp bản trình chiếu, bạn phải sử dụng các [tính năng nhúng](/slides/vi/python-net/embedded-font/).

**Có thể kiểm soát hành vi fallback khi một phông chữ tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/python-net/font-substitution/), [replacement rules](/slides/vi/python-net/font-replacement/), và [fallback sets](/slides/vi/python-net/fallback-font/) để xác định chính xác phông chữ nào sẽ được sử dụng khi glyph yêu cầu không có.

**Có thể dùng phông chữ trong các container Linux/Docker mà không cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định các thư mục phông chữ riêng của bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong ảnh container.

**Về giấy phép—có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Các điều khoản khác nhau; một số giấy phép cấm việc nhúng hoặc sử dụng thương mại. Luôn xem xét EULA của phông chữ trước khi phân phối các kết quả.