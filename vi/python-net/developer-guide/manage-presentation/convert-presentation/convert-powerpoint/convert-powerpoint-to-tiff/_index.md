---
title: Chuyển đổi Bản trình bày PowerPoint sang TIFF trong Python
titlelink: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/python-net/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình bày
- chuyển đổi slide
- PowerPoint sang TIFF
- OpenDocument sang TIFF
- bản trình bày sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- ODP sang TIFF
- Python
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang hình ảnh TIFF chất lượng cao bằng cách sử dụng Aspose.Slides cho Python qua .NET. Hướng dẫn từng bước kèm theo các ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster không mất dữ liệu được sử dụng rộng rãi, nổi tiếng với chất lượng vượt trội và khả năng lưu giữ chi tiết đồ họa. Các nhà thiết kế, nhiếp ảnh gia và nhà xuất bản máy tính để bàn thường chọn TIFF để giữ các lớp, độ chính xác màu và các cài đặt gốc trong ảnh của họ.

Sử dụng Aspose.Slides, bạn có thể dễ dàng chuyển đổi các slide PowerPoint (PPT, PPTX) và slide OpenDocument (ODP) trực tiếp thành hình ảnh TIFF chất lượng cao, đảm bảo bản trình bày của bạn giữ được độ trung thực hình ảnh tối đa.

## **Chuyển đổi bản trình bày sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/#methods) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. Các hình ảnh TIFF kết quả sẽ tương ứng với kích thước slide mặc định.

Đoạn mã Python sau đây minh họa cách chuyển đổi bản trình bày PowerPoint sang TIFF:

```py
import aspose.slides as slides

# Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
with slides.Presentation("presentation.pptx") as presentation:
    # Lưu bản trình bày dưới dạng TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Chuyển đổi bản trình bày sang TIFF Đen và Trắng**

Thuộc tính [bw_conversion_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen và trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi thuộc tính [compression_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/compression_type/) được đặt thành `CCITT4` hoặc `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) là một cài đặt ở cấp độ xuất khẩu cho phép chọn thuật toán chuyển đổi pixel cho toàn bộ ảnh TIFF. Để xác định cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen và trắng được bật, sử dụng [Shape.black_white_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/black_white_mode/). Xem [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.
{{% /alert %}}

Giả sử chúng ta có một tệp "sample.pptx" với slide sau:

![Slide trình bày](slide_black_and_white.png)

Đoạn mã Python sau đây minh họa cách chuyển đổi slide màu sang TIFF đen và trắng:

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

## **Chuyển đổi bản trình bày sang TIFF với kích thước tùy chỉnh**

Nếu bạn cần một hình ảnh TIFF có kích thước cụ thể, bạn có thể đặt các giá trị mong muốn bằng các thuộc tính có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/). Ví dụ, thuộc tính [image_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/image_size/) cho phép bạn định nghĩa kích thước của ảnh kết quả.

Đoạn mã Python sau đây minh họa cách chuyển đổi bản trình bày PowerPoint sang các hình ảnh TIFF với kích thước tùy chỉnh:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Đặt loại nén.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Các loại nén:
        Default - Chỉ định sơ đồ nén mặc định (LZW).
        None - Chỉ định không nén.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Đặt DPI của ảnh.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Đặt kích thước ảnh.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Lưu bản trình bày dưới dạng TIFF với kích thước đã chỉ định.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Chuyển đổi bản trình bày sang TIFF với Định dạng Pixel Ảnh Tùy chỉnh**

Sử dụng thuộc tính [pixel_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/pixel_format/) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/), bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Đoạn mã Python sau đây minh họa cách chuyển đổi bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```py
import aspose.slides as slides

# Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày (PPT, PPTX, ODP, v.v.).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat chứa các giá trị sau (theo tài liệu):
        FORMAT_1BPP_INDEXED - 1 bit mỗi pixel, dạng chỉ mục.
        FORMAT_4BPP_INDEXED - 4 bit mỗi pixel, dạng chỉ mục.
        FORMAT_8BPP_INDEXED - 8 bit mỗi pixel, dạng chỉ mục.
        FORMAT_24BPP_RGB    - 24 bit mỗi pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bit mỗi pixel, ARGB.
    """

    # Lưu bản trình bày dưới dạng TIFF với định dạng pixel đã chỉ định.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="info" %}}
Khám phá công cụ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online) miễn phí của Aspose.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các hình ảnh TIFF một cách riêng biệt.

**Có bất kỳ giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không, Aspose.Slides không áp đặt bất kỳ hạn chế nào về số lượng slide. Bạn có thể chuyển đổi bản trình bày có kích thước bất kỳ sang định dạng TIFF.

**Các hiệu ứng hoạt ảnh và chuyển tiếp của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là một định dạng ảnh tĩnh. Do đó, các hiệu ứng hoạt ảnh và chuyển tiếp không được giữ lại; chỉ có ảnh tĩnh của các slide được xuất.