---
title: Các thao tác trình chiếu low-code trong Python thông qua Java
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/python-java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua slide
- lặp qua shape
- lặp qua văn bản
- thu thập shape
- nén trình chiếu
- xóa master slide không sử dụng
- xóa layout slide không sử dụng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Python
- Java
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong Python thông qua Java để chuyển đổi và hợp nhất các trình chiếu, lặp qua nội dung, thu thập shape và giảm kích thước trình chiếu."
---
## **Tổng quan**

API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/vi/python-java/aspose.slides/) cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu phổ biến. Các trợ giúp này bọc các quy trình mô hình đối tượng thường dùng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các yếu tố trình chiếu, thu thập shape và loại bỏ nội dung không sử dụng với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng toàn bộ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/python-java/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất hoặc quan hệ giữa các yếu tố trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/python-java/aspose.slides/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng lời gọi trực tiếp file-to-file. |
| [Merger](https://reference.aspose.com/slides/vi/python-java/aspose.slides/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh có cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/) | Thực hiện một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/) | Xóa các master và layout không sử dụng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một bản trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/python-java/aspose.slides/convert/#autoByExtension) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở bản trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Lớp [Convert](https://reference.aspose.com/slides/vi/python-java/aspose.slides/convert/) cũng cung cấp các phương thức riêng cho xuất PDF, SVG, JPEG, PNG và TIFF. Sử dụng toàn bộ mô hình đối tượng khi bạn cần kiểm tra hoặc chỉnh sửa bản trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất mà trợ giúp không cung cấp. Xem [Convert Presentation](/slides/vi/python-java/convert-presentation/) để biết quy trình và tùy chọn theo định dạng.

## **Hợp nhất các bản trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/python-java/aspose.slides/merger/#process) để kết hợp các tệp bản trình chiếu hoàn chỉnh trong một lời gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Trợ giúp này phù hợp khi tất cả các slide phải được thêm vào một kết quả duy nhất mà không cần chọn hoặc ánh xạ lại từng slide. Sử dụng toàn bộ mô hình đối tượng khi bạn cần hợp nhất các slide được chọn, áp dụng master hoặc layout đích, bảo lưu các phần một cách rõ ràng, hoặc điều chỉnh các kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/python-java/merge-presentation/) cho những kịch bản đó.

## **Lặp qua các yếu tố của bản trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/) gọi một callback cho mỗi loại yếu tố trình chiếu được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ bản trình chiếu.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#portion) để kiểm tra các yếu tố tương ứng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Mặc định, việc duyệt shape và văn bản trên toàn bộ bản trình chiếu bao gồm các slide thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback hoặc điều khiển chi tiết quan hệ cha‑con là quan trọng.

## **Thu thập Shapes**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/collect/#shapes) khi bạn cần một bộ sưu tập tất cả các shape trong bản trình chiếu thay vì callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#shape) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/) có thể loại bỏ các phần tử cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) loại bỏ các layout slide mà không có slide bình thường nào tham chiếu.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#removeUnusedMasterSlides) loại bỏ các master slide không còn được sử dụng.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/#compressEmbeddedFonts) loại bỏ các ký tự không dùng khỏi phông chữ nhúng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Xóa các layout không dùng trước các master không dùng để một master trở nên không được tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/python-java/slide-master/) và [Embedded Font](/slides/vi/python-java/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì toàn bộ mô hình đối tượng?**

Sử dụng các trợ giúp low-code khi một thao tác chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng toàn bộ mô hình đối tượng khi bạn cần chọn các slide cụ thể, điều khiển quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu ở định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/python-java/aspose.slides/merger/#process) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/python-java/aspose.slides/convert/#autoByExtension), rồi mới hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#slide) duyệt các slide trình chiếu bình thường. Các hoạt động [ForEach.shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#portion) trên toàn bộ bản trình chiếu bao gồm slide bình thường, master và layout theo mặc định. Sử dụng các overload của chúng với `includeNotes` đặt thành `True` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/#shape) để xử lý mỗi shape ngay lập tức thông qua callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/collect/#shapes) khi bạn cần một kết quả có thể lặp lại, giữ lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm cho tệp bản trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout không dùng, master không dùng hoặc phông chữ nhúng với ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) đã tải vào bộ nhớ. Sau khi thay đổi các yếu tố trong callback của [ForEach](https://reference.aspose.com/slides/vi/python-java/aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compress/), gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi bản trình chiếu](/slides/vi/python-java/convert-presentation/)
- [Hợp nhất các bản trình chiếu](/slides/vi/python-java/merge-presentation/)
- [Slide Master](/slides/vi/python-java/slide-master/)
- [Quản lý ô văn bản](/slides/vi/python-java/manage-textbox/)
- [Phông chữ nhúng](/slides/vi/python-java/embedded-font/)