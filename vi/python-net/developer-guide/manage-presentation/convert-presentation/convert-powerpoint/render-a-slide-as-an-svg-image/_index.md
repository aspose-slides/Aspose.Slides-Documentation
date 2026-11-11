---
title: Xuất slide trình chiếu dưới dạng ảnh SVG trong Python
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
- tùy chọn xuất SVG
- PowerPoint
- trình chiếu
- Python
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng ảnh SVG trong Python và kiểm soát phông chữ, văn bản và hình ảnh bằng Aspose.Slides."
---
## **Tổng quan**

SVG là một định dạng ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình tiếp cận và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) khi SVG xuất ra cần gọn gàng, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất một slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng. Ví dụ sau xuất mỗi slide trong một bản trình chiếu dưới dạng một tệp SVG riêng.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Tên tệp sử dụng [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) xác định liệu việc xoay khung có được áp dụng hay không. Đặt [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) thành `True` khi văn bản phải được render mà không có ligature.

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

## **Kiểm soát việc cắt đầu dòng ở mũi tên**

SVG 1.1 không có thiết lập chèn marker để chỉ định vị trí line nên dừng dưới mũi tên. Theo mặc định, Aspose.Slides rút ngắn đường line đã xuất để nét không vượt ra ngoài marker. Đặt [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) thành `True` để vẽ nét tới điểm cuối gốc của đường line. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường line giữ nguyên vị trí và độ dài trên slide.

Ví dụ vẽ các mũi tên tam giác và kim cương trên các đường có độ rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

So sánh cho thấy mũi tên tam giác trên đường 10 điểm. Khi bật cắt, đầu mũi tên sắc. Khi tắt cắt, nét vượt ra ngoài các cạnh nghiêng của marker và để lại một đầu phẳng.

![Tam giác 10 điểm được phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét vượt ra ngoài ít thấy hơn trên tam giác 2 điểm. Kim cương đặc phủ hết đầu nét ở cả hai độ rộng.

## **Kiểm soát văn bản và phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ nguyên dạng text hay được chuyển thành đồ họa vector, và cách phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng độ nhất quán về hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG xuất ra.

### **Vector hoá toàn bộ văn bản**

Đặt [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) thành `True` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh đồng nhất hơn trên các trình duyệt, nhưng văn bản không còn có thể chọn hoặc tìm kiếm dưới dạng SVG text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Chọn cách xử lý phông chữ bên ngoài**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải bên ngoài. Chọn `ADD_LINKS_TO_FONT_FILES` để tham chiếu các tệp phông chữ riêng biệt, `EMBED` để bao gồm dữ liệu phông chữ trong SVG, hoặc `VECTORIZE` để render chỉ những văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông.

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

## **Giảm kích thước ảnh nhúng**

Sử dụng [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) để giảm độ phân giải của ảnh nhúng, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) để bỏ các vùng ảnh đã cắt, và [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) để kiểm soát chất lượng mã hóa JPEG. Các cài đặt này giảm kích thước tệp bằng cách hi sinh độ trung thực hoặc dữ liệu ảnh được giữ lại.

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

## **Kiểm soát độ phân giải raster hóa Metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) đặt giới hạn độ phân giải tối thiểu cho việc raster hóa metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một ảnh EMF hoặc WMF được raster hóa. Nó không định nghĩa DPI toàn cục cho SVG hay buộc mọi đối tượng trên slide trở thành ảnh raster.

Tải về [metafile-rasterization.pptx](metafile-rasterization.pptx), trong đó chứa một ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster hóa khác nhau thông qua [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

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

Trong đầu ra, EMF trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau áp dụng cho bản trình chiếu được cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hóa Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây cho thấy cùng một khu vực raster nhúng ở cùng kích thước hiển thị phóng to. Các đường chéo hiển thị hiện tượng pixel hoá ở 72 DPI và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng lên. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hay thay đổi mọi ảnh được xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) kiểm soát việc giảm độ phân giải ảnh và có thể che giấu ảnh hưởng của việc thay đổi độ phân giải raster hóa metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) kiểm soát chất lượng mã hóa JPEG, không phải độ phân giải raster hóa metafile.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) thay vì [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) khi toàn bộ văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản dùng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các ảnh nhúng, xoá các vùng ảnh đã cắt, và chọn các tệp phông chữ được liên kết khi môi trường đích có thể cung cấp chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản vector hoá mỗi thứ đều có các cân nhắc về chất lượng và kích thước.