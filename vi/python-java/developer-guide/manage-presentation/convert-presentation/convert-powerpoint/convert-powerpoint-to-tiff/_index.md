---
title: Chuyển Đổi Bản Trình Bày PowerPoint Sang TIFF trong Python
linktitle: PowerPoint sang TIFF
type: docs
weight: 90
url: /vi/python-java/convert-powerpoint-to-tiff/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản trình bày sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách dễ dàng chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) sang ảnh TIFF chất lượng cao bằng Aspose.Slides cho Python thông qua Java, kèm ví dụ mã."
---
## **Giới thiệu**

TIFF (**Tagged Image File Format**) là một định dạng ảnh raster hỗ trợ nhiều trang và nén không mất dữ liệu. Nó hữu ích để lưu các slide đã render trong một tệp ảnh duy nhất.

Sử dụng Aspose.Slides for Python via Java, bạn có thể chuyển đổi các bản trình bày PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang TIFF. Mỗi ví dụ dưới đây sẽ khởi động máy ảo Java nếu cần và giải phóng bản trình bày sau khi sử dụng. 

## **Chuyển Đổi Bản Trình Bày Sang TIFF**

Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), bạn có thể nhanh chóng chuyển đổi toàn bộ bản trình bày PowerPoint sang TIFF. TIFF đa trang kết quả chứa một hình ảnh đã render của mỗi slide với kích thước mặc định.

Mã dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Lưu tất cả các slide vào một tệp TIFF đa trang.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Chuyển Đổi Bản Trình Bày Sang TIFF Đen‑Trắng**

Phương thức [setBwConversionMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) trong lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/) cho phép bạn chỉ định thuật toán được sử dụng khi chuyển đổi một slide hoặc ảnh màu sang TIFF đen‑trắng. Lưu ý rằng cài đặt này chỉ áp dụng khi phương thức [setCompressionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setCompressionType) được đặt thành [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) hoặc [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setBwConversionMode) là một cài đặt cấp xuất khẩu chọn thuật toán chuyển đổi pixel cho toàn bộ hình ảnh TIFF. Để định nghĩa cách một hình dạng riêng lẻ hiển thị khi chế độ hiển thị đen‑trắng được bật, hãy sử dụng [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setBlackWhiteMode). Xem [Control Black-and-White Rendering for Shapes](/slides/vi/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) để biết ví dụ.
{{% /alert %}}

Giả sử chúng ta có tệp **sample.pptx** với slide sau:

![A presentation slide](slide_black_and_white.png)

Mã dưới đây minh họa cách chuyển đổi slide màu sang TIFF đen‑trắng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Kết quả:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Chuyển Đổi Bản Trình Bày Sang TIFF Với Kích Thước Tùy Chỉnh**

Nếu bạn cần một hình ảnh TIFF có kích thước cụ thể, có thể đặt các giá trị mong muốn bằng các phương thức có sẵn trong [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/). Ví dụ, phương thức [setImageSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setImageSize) cho phép bạn xác định kích thước của hình ảnh kết quả.

Mã dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang ảnh TIFF với kích thước tùy chỉnh:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Đặt độ phân giải ngang và dọc.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Đặt kích thước đầu ra tính bằng pixel.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Bao gồm toàn bộ ghi chú người thuyết trình dưới mỗi slide.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Chuyển Đổi Bản Trình Bày Sang TIFF Với Định Dạng Pixel Ảnh Tùy Chỉnh**

Sử dụng phương thức [setPixelFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setPixelFormat) từ lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/) bạn có thể chỉ định định dạng pixel ưa thích cho ảnh TIFF kết quả.

Mã dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang ảnh TIFF với định dạng pixel tùy chỉnh:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}
Kiểm tra công cụ chuyển đổi **PowerPoint sang Poster** MIỄN PHÍ của Aspose tại [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Tôi có thể chuyển đổi một slide riêng lẻ thay vì toàn bộ bản trình bày PowerPoint sang TIFF không?**

Có. Aspose.Slides cho phép bạn chuyển đổi các slide riêng lẻ từ bản trình bày PowerPoint và OpenDocument thành các ảnh TIFF một cách độc lập.

**Có giới hạn nào về số lượng slide khi chuyển đổi bản trình bày sang TIFF không?**

Không có giới hạn cố định về số slide cho xuất khẩu TIFF. Bộ nhớ khả dụng, độ phức tạp của slide và kích thước đầu ra ảnh hưởng đến kích thước của bản trình bày bạn có thể xử lý.

**Các hiệu ứng hoạt hình và chuyển đổi của PowerPoint có được giữ lại khi chuyển đổi slide sang TIFF không?**

Không, TIFF là định dạng ảnh tĩnh. Do đó, các hoạt hình và hiệu ứng chuyển đổi không được giữ lại; chỉ có các ảnh tĩnh của slide được xuất khẩu.