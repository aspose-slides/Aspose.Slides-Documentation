---
title: Xuất slide trình chiếu thành ảnh SVG trong Python qua Java
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- các tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- Python
- Java
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng ảnh SVG trong Python thông qua Java và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là một định dạng ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình hỗ trợ truy cập, và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/) khi SVG xuất ra cần gọn gàng, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), chọn một slide, và ghi nó vào một luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/). Các ví dụ yêu cầu một tệp `presentation.pptx` tồn tại. Mỗi ví dụ sẽ khởi động JVM nếu cần và đóng các luồng đầu ra. Ví dụ sau đây xuất mỗi slide trong một bản trình chiếu ra một tệp SVG riêng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getSlideNumber) thay vì chỉ mục vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/) điều khiển việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setUseFrameSize) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setUseFrameRotation) quyết định liệu phép quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `True` khi văn bản phải được render mà không có ligature.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Kiểm soát Văn bản và Phông chữ**

### **Biến thành vector toàn bộ Văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setVectorizeText) thành `True` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm được dưới dạng văn bản SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Chọn cách xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải ngoại vi. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ những văn bản dùng phông chữ ngoại vi thành đồ họa. Hãy kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Giảm kích thước ảnh được nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setPicturesCompression) để giảm độ phân giải của ảnh được nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) để bỏ qua các khu vực ảnh đã cắt, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setJpegQuality) để kiểm soát chất lượng mã hoá JPEG. Các thiết lập này làm giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu ảnh được giữ lại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Gán ID ổn định cho hình dạng và văn bản**

Sử dụng một bộ điều khiển định dạng Python được đăng ký qua `jpype.JProxy` để gán giá trị [SvgShape.setId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgshape/#setId) cho các hình dạng và giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgtspan/#setId) cho các phần tử `tspan` của văn bản. Gán proxy này bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Bộ điều khiển sau sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getOfficeInteropShapeId), một giá trị ổn định trong suốt vòng đời của hình dạng, và một bộ đếm có thể lặp lại cho các span văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc hậu xử lý một bản trình chiếu không thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Thêm Trình xử lý Sự kiện SVG**

Trong một bộ điều khiển định dạng Python, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgshape/#setEventHandler) với một giá trị [SvgEvent](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Đăng ký bộ điều khiển qua `jpype.JProxy` và gán nó bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Trang chủ có thể định nghĩa hàm JavaScript được trình xử lý tham chiếu. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải tiến khả năng truy cập và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setVectorizeText) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#setVectorizeText) khi toàn bộ văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) khi chỉ văn bản dùng phông chữ ngoại vi cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các ảnh được nhúng, xóa các khu vực ảnh đã cắt, và chọn liên kết tới các tệp phông chữ khi môi trường mục tiêu có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG giảm và văn bản vector hoá đều có những cân bằng khác nhau giữa chất lượng và kích thước.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua bộ điều khiển định dạng, sau đó chọn các phần tử SVG phù hợp trong công cụ hậu xử lý hoặc trong script trình duyệt của bạn.