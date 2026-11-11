---
title: Render các slide bài thuyết trình dưới dạng hình ảnh SVG trong Python
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bài thuyết trình sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- các tùy chọn xuất SVG
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong Python và kiểm soát phông chữ, văn bản và hình ảnh bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản trên web, trình xem slide, quy trình tiếp cận, và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các yếu tố SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) khi SVG được xuất cần gọn gàng, nhất quán trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất một Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng. Ví dụ sau xuất mỗi slide trong một bản trình bày ra một tệp SVG riêng.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Tên tệp sử dụng [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) xác định xem độ xoay khung có được áp dụng hay không. Đặt [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) thành `True` khi văn bản phải được render mà không có ligature.

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

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ nguyên dưới dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng sự nhất quán hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Vector hoá toàn bộ Văn bản**

Đặt [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) thành `True` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hay tìm kiếm được dưới dạng văn bản SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Chọn cách Xử lý Phông chữ Bên ngoài**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `ADD_LINKS_TO_FONT_FILES` để tham chiếu các tệp phông chữ riêng biệt, `EMBED` để bao gồm dữ liệu phông chữ trong SVG, hoặc `VECTORIZE` để render chỉ văn bản sử dụng phông chữ bên ngoài thành đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

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

## **Giảm kích thước Hình ảnh Nhúng**

Sử dụng [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) để bỏ qua các khu vực nguồn đã cắt, và [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là giảm độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát Độ phân giải Raster hóa Metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) đặt giới hạn độ phân giải thấp hơn cho việc raster hóa các metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hóa. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành hình raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), tệp chứa một hình ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster khác nhau thông qua [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Trong đầu ra, EMF đã trở thành một PNG nhúng trong mỗi SVG. Các phép đo sau dành cho bản trình bày được cung cấp; chúng không phải là công thức chung để chuyển đổi DPI thành kích thước pixel.

| DPI raster hóa Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây hiển thị cùng một khu vực raster nhúng với cùng kích thước hiển thị phóng to. Các đường chéo cho thấy hiện tượng pixel hoá rõ rệt ở 72 DPI và cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng kích thước. Tăng giá trị này không nhất thiết cải thiện mọi chi tiết hoặc thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) kiểm soát giảm độ phân giải hình ảnh và có thể che dấu hiệu quả của việc thay đổi độ phân giải raster hóa metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hóa metafile.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) thay vì [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng việc nén các hình ảnh nhúng, xóa các khu vực hình ảnh đã cắt, và chọn các tệp phông chữ được liên kết khi môi trường mục tiêu có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải hình ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản đã vector hoá mỗi đều có những đổi chác về chất lượng và kích thước.