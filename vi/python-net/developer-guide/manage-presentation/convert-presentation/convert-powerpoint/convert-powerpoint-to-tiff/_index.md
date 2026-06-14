---
title: Chuyển đổi Bản trình chiếu PowerPoint sang TIFF bằng Python
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/python-net/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- PowerPoint sang TIFF
- OpenDocument sang TIFF
- bản trình chiếu sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- ODP sang TIFF
- Python
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang hình ảnh TIFF chất lượng cao bằng Aspose.Slides cho Python qua .NET. Hướng dẫn từng bước kèm ví dụ mã nguồn."
---
## **Introduction**

TIFF (**Định dạng Tệp Hình ảnh có Thẻ**) là một định dạng hình ảnh raster không mất dữ liệu được sử dụng rộng rãi, nổi tiếng với chất lượng tuyệt vời và khả năng bảo toàn chi tiết của đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản máy tính để bàn thường chọn TIFF để duy trì các lớp, độ chính xác màu và cài đặt gốc trong hình ảnh của họ.

Với Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và các slide OpenDocument (ODP) trực tiếp thành hình ảnh TIFF chất lượng cao, đảm bảo các bản trình bày của bạn giữ nguyên độ trung thực hình ảnh tối đa.

## **Convert a Presentation to TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/#methods) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các hình ảnh TIFF kết quả sẽ tương ứng với kích thước slide mặc định.

Đoạn mã Python sau đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
with slides.Presentation("presentation.pptx") as presentation:
    # Lưu bản trình chiếu dưới dạng TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Convert a Presentation to Black-and-White TIFF**

Thuộc tính [bw_conversion_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc hình ảnh màu sang TIFF đen và trắng. Lưu ý rằng thiết lập này chỉ áp dụng khi thuộc tính [compression_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/compression_type/) được đặt thành `CCITT4` hoặc `CCITT3`.

Giả sử chúng ta có tệp "sample.pptx" với slide sau:

![Slide trình chiếu](slide_black_and_white.png)

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Kết quả:

![TIFF Đen và Trắng](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

Nếu bạn cần một hình ảnh TIFF với kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các thuộc tính có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/). Ví dụ, thuộc tính [image_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/image_size/) cho phép bạn xác định kích thước của hình ảnh kết quả.

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Đặt kiểu nén.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Đặt DPI cho hình ảnh.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Đặt kích thước hình ảnh.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Lưu bản trình chiếu dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

Sử dụng thuộc tính [pixel_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/pixel_format/) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho hình ảnh TIFF kết quả.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu (PPT, PPTX, ODP, v.v.).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # Lưu bản trình chiếu dưới dạng TIFF với kích thước hình ảnh đã chỉ định.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}
Khám phá [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) của Aspose.
{{% /alert %}}

## **FAQ**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành hình ảnh TIFF một cách độc lập.

**Có bất kỳ giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ giới hạn nào về số lượng slide. Bạn có thể chuyển đổi các bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hoạt ảnh và hiệu ứng chuyển đổi của PowerPoint có được bảo lưu khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng hình ảnh tĩnh. Do đó, các hiệu ứng hoạt ảnh và chuyển đổi không được bảo lưu; chỉ có các ảnh tĩnh của slide được xuất.