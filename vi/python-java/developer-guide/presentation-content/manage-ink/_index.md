---
title: "Quản lý các đối tượng mực trong PowerPoint bằng Python qua Java"
linktitle: "Quản lý Mực"
type: docs
weight: 95
url: /vi/python-java/manage-ink/
keywords:
- "mực"
- "đối tượng mực"
- "dấu vết mực"
- "quản lý mực"
- "vẽ mực"
- "vẽ"
- "xuất mực"
- "kết xuất mực"
- "ẩn mực"
- InkOptions
- PowerPoint
- "bản trình chiếu"
- Python
- Java
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint, chỉnh sửa dấu vết và thuộc tính cọ, và kiểm soát cách hiển thị mực khi xuất PDF, HTML, SVG, TIFF và hình ảnh với Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được dùng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Aspose.Slides cung cấp các kiểu cần thiết để làm việc với các đối tượng mực. Ví dụ, lớp [Ink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng hình dạng. Ở dạng đơn giản nhất, một hình dạng là một container xác định vùng của chính đối tượng (khung) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Định dạng bố cục hình dạng](/slides/vi/python-java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của vùng container được xác định bằng các phương thức tiêu chuẩn [Shape.getWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getWidth) và [Shape.getHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Mực**

Một dấu vết mực là thành phần cơ bản được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết mực số. Một dấu vết lưu trữ một chuỗi các điểm được kết nối.

Dạng mã hóa đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm được kết nối và hiển thị, chúng tạo thành một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Cọ để Vẽ**

Cọ được sử dụng để vẽ các đường nối các điểm của một dấu vết mực. Cọ có màu và kích thước riêng, được đại diện bởi các phương thức [InkBrush.getColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkbrush/#getColor) và [InkBrush.getSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkbrush/#getSize).

### **Đặt Màu Cọ Mực**

Đoạn mã Python sau cho thấy cách đặt màu cho một cọ mực:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Đặt Kích thước Cọ Mực**

Đoạn mã Python sau cho thấy cách đặt kích thước cho một cọ mực:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Thông thường, chiều rộng và chiều cao của cọ không bằng nhau, vì vậy PowerPoint không hiển thị kích thước cọ (phần dữ liệu tương ứng bị làm mờ). Khi chiều rộng và chiều cao của cọ bằng nhau, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của các cọ — nó luôn giả định độ dày đường nét bằng 0 (xem hình ảnh trước).

Do đó, để xác định vùng hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước cọ của các dấu vết. ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được mở rộng tới kích thước của container (khung). Khi kích thước container thay đổi, kích thước cọ vẫn không đổi, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint sử dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Mực Khi Xuất và Khi Kết xuất**

Aspose.Slides cung cấp lớp [InkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong đầu ra đã xuất hoặc đã kết xuất. Bạn có thể sử dụng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các phép vận hành mặt nạ cọ mực được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc kết xuất cho một số loại đầu ra:

| Đầu ra | Thuộc tính tùy chọn mực |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Ảnh slide | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Các phương thức [InkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/) sau công bố hai cài đặt giống nhau:

- [getHideInk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#getHideInk) xác định liệu các đối tượng mực có được bao gồm trong đầu ra hay không. Giá trị mặc định là `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) xác định liệu một phép vận hành mặt nạ có được diễn giải là độ mờ khi kết xuất cọ mực hay không. Giá trị mặc định là `True`; gọi [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) với `False` để sử dụng phép ROP thay thế.

### **Ẩn Đối tượng Mực trong Đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Để tạo ra đầu ra sạch sẽ không có các chú thích viết tay hay nội dung mực khác, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#setHideInk) với `True`.

Ví dụ Python sau xuất một bản trình chiếu ra PDF đồng thời ẩn tất cả các đối tượng mực:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ẩn Đối tượng Mực Khi Kết xuất Slide thành Ảnh**

Để ẩn các đối tượng mực khi kết xuất các slide thành ảnh bitmap, cấu hình [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/#getInkOptions) và truyền các tùy chọn kết xuất cho [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage).

Ví dụ Python dưới đây kết xuất slide đầu tiên thành ảnh PNG mà không có đối tượng mực:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Kiểm soát Kết xuất Mặt nạ Mực**

Cài đặt [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) kiểm soát cách các phép vận hành mặt nạ được diễn giải khi kết xuất cọ mực. Giá trị mặc định là `True`, tức là sử dụng độ mờ. Để dùng phép ROP thay thế, gọi [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) với `False`.

Ví dụ Python sau xuất một slide ra SVG và sử dụng kết xuất dựa trên ROP cho các phép vận hành mặt nạ mực:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Cài đặt tương tự cũng có thể được áp dụng qua [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#getInkOptions) khi xuất bản trình chiếu hoặc kết xuất slide thành TIFF.

### **Chọn Ẩn hay Giữ lại Mực**

Khi bạn cần một phiên bản sạch sẽ của bản trình chiếu có chú thích để phân phối mà không có dấu đánh giá, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#setHideInk) với `True` trong quá trình xuất.

Giữ [InkOptions.getHideInk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#getHideInk) ở giá trị mặc định `False` khi các chú thích mực là một phần của nội dung dự định, chẳng hạn như bình luận đánh giá, ghi chú viết tay, tô sáng hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra đánh giá và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không cần sửa đổi các đối tượng mực nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét mực đã tồn tại không?**

Có. Lấy dấu vết từ [Ink.getTraces](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ink/#getTraces), sau đó thay đổi [InkTrace.getBrush](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inktrace/#getBrush). Gọi [InkBrush.setColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkbrush/#setColor) hoặc [InkBrush.setSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkbrush/#setSize) để thay đổi cọ.

**Việc ẩn mực có thay đổi bản trình chiếu nguồn không?**

Không. Gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/python-java/aspose.slides/inkoptions/#setHideInk) chỉ ảnh hưởng đến kết quả đã xuất hoặc đã kết xuất; nó không loại bỏ hay sửa đổi các đối tượng mực trong bản trình chiếu nguồn.

**Định dạng xuất nào hỗ trợ các tùy chọn mực?**

Bạn có thể cấu hình tùy chọn mực cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc kết xuất tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để tìm hiểu về các hình dạng nói chung, xem phần [PowerPoint Shapes](/slides/vi/python-java/powerpoint-shapes/).
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](/slides/vi/python-java/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](/slides/vi/python-java/convert-powerpoint-to-html/).
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](/slides/vi/python-java/render-a-slide-as-an-svg-image/).
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](/slides/vi/python-java/convert-powerpoint-to-tiff/).
* Để biết chi tiết về kết xuất slide thành ảnh, xem [Convert Presentation Slides to Images](/slides/vi/python-java/convert-slide/).