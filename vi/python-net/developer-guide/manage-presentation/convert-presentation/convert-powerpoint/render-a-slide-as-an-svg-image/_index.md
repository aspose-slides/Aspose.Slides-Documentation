---
title: Kết xuất các slide trình chiếu thành hình ảnh SVG trong Python
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- các tùy chọn xuất SVG
- PowerPoint
- trình chiếu
- Python
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong Python và kiểm soát phông chữ, văn bản và hình ảnh bằng Aspose.Slides."
---
## **Tổng quan**

SVG là một định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình làm việc hỗ trợ truy cập, và xử lý tự động sau khi xuất. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các thành phần SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/) khi SVG được xuất cần gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng. Ví dụ sau xuất mỗi slide trong một bản trình chiếu thành một tệp SVG riêng.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Tên tệp sử dụng [Slide.slide_number](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_number/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.write_as_svg](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/use_frame_size/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) quyết định liệu việc xoay khung có được áp dụng hay không. Đặt [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) thành `True` khi văn bản phải được render mà không có ligature.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Kiểm soát Văn bản và Phông chữ**

### **Biểu diễn Văn bản dưới dạng Vector**

Đặt [SVGOptions.vectorize_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/vectorize_text/) thành `True` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc vào phông chữ và làm cho kết quả hình ảnh đồng nhất hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể được chọn hoặc tìm kiếm dưới dạng văn bản SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Chọn Cách Xử lý Phông chữ Ngoài**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải ngoại vi. Chọn `ADD_LINKS_TO_FONT_FILES` để tham chiếu các tệp phông chữ riêng biệt, `EMBED` để nhúng dữ liệu phông chữ vào SVG, hoặc `VECTORIZE` để render chỉ văn bản sử dụng phông chữ ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Giảm kích thước hình ảnh nhúng**

Sử dụng [SVGOptions.pictures_compression](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/pictures_compression/) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) để bỏ qua các vùng ảnh đã cắt, và [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/jpeg_quality/) để kiểm soát chất lượng mã hoá JPEG. Các thiết lập này giảm kích thước tệp nhưng có thể ảnh hưởng đến độ trung thực của hình ảnh hoặc dữ liệu ảnh được giữ lại.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/vectorize_text/) thay vì [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/vectorize_text/) khi mọi văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xoá các vùng ảnh đã cắt, và chọn các tệp phông chữ được liên kết khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản vector hoá đều có các cân bằng giữa chất lượng và kích thước khác nhau.