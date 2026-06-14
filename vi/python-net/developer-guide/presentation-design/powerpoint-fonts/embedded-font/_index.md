---
title: Nhúng Phông chữ trong Bài thuyết trình bằng Python
linktitle: Nhúng Phông chữ
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
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Nhúng phông chữ TrueType trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Nhúng phông chữ trong PowerPoint** đảm bảo bản trình chiếu của bạn giữ nguyên giao diện dự kiến trên các hệ thống khác nhau. Dù sử dụng phông chữ độc đáo để sáng tạo hay các phông chuẩn, việc nhúng phông chữ ngăn ngừa hiện tượng văn bản và bố cục bị gián đoạn.

Nếu bạn đã dùng phông chữ của bên thứ ba hoặc phông không chuẩn vì muốn sáng tạo trong công việc, thì bạn có thêm nhiều lý do để nhúng phông chữ của mình. Ngược lại (không nhúng phông chữ), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể bị thay đổi hoặc biến thành các hình chữ nhật gây khó hiểu.

Sử dụng các lớp [FontsManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontdata/), và [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) để quản lý phông chữ đã nhúng.

## **Lấy và Xóa Phông chữ Đã Nhúng**

Lấy hoặc xóa phông chữ đã nhúng khỏi bản trình chiếu một cách dễ dàng bằng các phương thức [get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) và [remove_embedded_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Đoạn mã Python này cho bạn thấy cách lấy và xóa phông chữ đã nhúng khỏi bản trình chiếu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Kết xuất slide chứa khung văn bản sử dụng phông chữ 'FunSized' đã được nhúng.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Lấy tất cả các phông chữ đã nhúng.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Tìm phông chữ 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Xóa phông chữ 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Kết xuất slide; phông chữ 'Calibri' sẽ được thay thế bằng một phông có sẵn.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Lưu bản trình chiếu mà không có phông chữ 'Calibri' đã nhúng vào đĩa.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Thêm Phông chữ Đã Nhúng**

Sử dụng enum [EmbedFontCharacters](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/embedfontcharacters/) và hai phiên bản quá tải của phương thức [add_embedded_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/add_embedded_font/) bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ vào bản trình chiếu. Đoạn mã Python này cho bạn thấy cách nhúng và thêm phông chữ vào bản trình chiếu:

```python
import aspose.slides as slides

# Tải một bản trình chiếu.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Nén Phông chữ Đã Nhúng**

Tối ưu kích thước tệp bằng cách nén phông chữ đã nhúng sử dụng [compress_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Ví dụ mã cho nén:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết rằng một phông chữ cụ thể trong bản trình chiếu vẫn sẽ bị thay thế trong quá trình render dù đã nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/python-net/font-substitution/) trong trình quản lý phông chữ và [các quy tắc dự phòng/đổi chỗ](/slides/vi/python-net/fallback-font/): nếu phông chữ không có hoặc bị hạn chế, một phông dự phòng sẽ được sử dụng.

**Có đáng để nhúng các phông "hệ thống" như Arial/Calibri không?**

Thông thường không—chúng hầu như luôn có sẵn. Nhưng để đảm bảo tính di động hoàn toàn trong các môi trường "nhẹ" (Docker, máy chủ Linux không cài sẵn phông), việc nhúng phông hệ thống có thể loại bỏ rủi ro bị thay thế bất ngờ.