---
title: Xuất các slide trình chiếu dưới dạng hình ảnh SVG trong Python qua Java
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
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- Python
- Java
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong Python qua Java và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng ảnh dựa trên XML có khả năng mở rộng, phù hợp cho việc xuất bản web, trình xem slide, quy trình tiếp cận và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách viết văn bản, phông chữ, hình ảnh và các yếu tố SVG.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) khi SVG được xuất cần gọn gàng, nhất quán trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất một slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Các ví dụ yêu cầu có sẵn tệp `presentation.pptx`. Mỗi ví dụ khởi động JVM nếu cần và đóng các luồng đầu ra. Ví dụ sau xuất mỗi slide trong một bản trình chiếu thành một tệp SVG riêng.

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

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một shape riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) khi trình xem slide hoặc trang web chỉ cần shape đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) điều khiển việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) xác định liệu việc quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `True` khi văn bản phải được render mà không có ligature.

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

## **Kiểm soát cắt đầu dòng tại đầu mũi tên**

SVG 1.1 không có thiết lập marker inset để chỉ định nơi một đường nên dừng dưới đầu mũi tên. Theo mặc định, Aspose.Slides rút ngắn đường xuất để nét vẽ không vượt qua marker. Gọi [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) với `True` để vẽ nét vẽ tới điểm cuối gốc của đường. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường giữ nguyên vị trí và chiều dài trên slide.

Ví dụ vẽ các đầu mũi tên tam giác và hình thoi trên các đường rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

So sánh cho thấy đầu mũi tên tam giác trên đường 10 điểm. Khi bật cắt, đầu mũi tên sắc nhọn. Khi tắt cắt, nét vẽ vượt qua các mặt nghiêng của marker và để lại một đầu phẳng.

![Tam giác 10 điểm được phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét vẽ vượt ra ít thấy hơn trên tam giác 2 điểm. Hình thoi được tô đầy phủ hết đầu nét ở cả hai độ rộng.

## **Kiểm soát văn bản và phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát xem văn bản có giữ dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng tính nhất quán về hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Biểu diễn toàn bộ văn bản dưới dạng vector**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) thành `True` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm kết quả hiển thị đồng nhất hơn trên các trình duyệt, nhưng văn bản không còn có thể được chọn hoặc tìm kiếm dưới dạng văn bản SVG.

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

### **Chọn cách xử lý phông chữ bên ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ những đoạn văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

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

## **Giảm kích thước hình ảnh được nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) để giảm độ phân giải của các hình ảnh được nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) để bỏ qua các khu vực đã cắt của nguồn ảnh, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là giảm độ trung thực hình ảnh hoặc dữ liệu ảnh được giữ lại.

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

## **Kiểm soát độ phân giải raster hoá Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) đặt giới hạn độ phân giải thấp nhất cho việc raster hoá metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một ảnh EMF hoặc WMF được raster hoá. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành ảnh raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), chứa một ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster hoá khác nhau thông qua [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Tất cả các cài đặt xuất khác giữ nguyên để kết quả có thể so sánh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()

```

Trong output, EMF trở thành một PNG được nhúng trong mỗi SVG. Các đo lường sau dành cho bản trình chiếu được cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hoá Metafile | Kích thước PNG được nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây cho thấy cùng một vùng raster được nhúng ở cùng kích thước hiển thị phóng to. Các đường chéo hiện hiện tượng pixel hoá ở DPI 72 và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng kích thước. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hoặc thay đổi mọi ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở DPI 72, 150 và 300](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) kiểm soát việc giảm độ phân giải ảnh và có thể che đi ảnh hưởng của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID ổn định cho Shapes và Text**

Sử dụng một bộ điều khiển định dạng Python được đăng ký qua `jpype.JProxy` để gán giá trị [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) cho các shape và giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) cho các phần tử `tspan` trong văn bản. Gán proxy bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Bộ điều khiển sau sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), giá trị này ổn định trong suốt vòng đời của shape, và một bộ đếm lặp lại cho các span văn bản của nó. Điều này khiến các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình chiếu không thay đổi.

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

## **Thêm bộ xử lý sự kiện SVG**

Trong bộ điều khiển định dạng Python, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) với một giá trị [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) để thêm bộ xử lý sự kiện JavaScript vào một shape đã xuất. Đăng ký bộ điều khiển qua `jpype.JProxy` và gán nó bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG lưu kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript được bộ xử lý tham chiếu. Gán ID và bộ xử lý sự kiện cho phép trình xem slide, cải thiện khả năng tiếp cận và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) khi chỉ những đoạn văn bản dùng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén các hình ảnh được nhúng, xóa các khu vực ảnh đã cắt, và chọn liên kết tới tệp phông chữ khi môi trường mục tiêu có thể phục vụ chúng. Kiểm tra kết quả vì giảm độ phân giải ảnh, giảm chất lượng JPEG và vector hoá văn bản mỗi yếu tố đều có sự cân bằng khác nhau giữa chất lượng và kích thước.

**Tôi có thể sửa đổi các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua bộ điều khiển định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.