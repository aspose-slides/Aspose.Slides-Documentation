---
title: Thay đổi Kích thước và Hướng Trang Ghi chú trong Python qua Java
linktitle: Kích thước Trang Ghi chú
type: docs
weight: 10
url: /vi/python-java/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước handout
- PowerPoint
- bản trình chiếu
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho Python qua Java, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc handout sang PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getNotesSize) để truy cập cài đặt trang ghi chú của bản trình chiếu. Nó trả về một đối tượng [NotesSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notessize/) mà phương thức [setSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notessize/#setSize) thiết lập kích thước trang. Mặc dù đối tượng cài đặt không thể được thay thế, bạn vẫn có thể gán kích thước mới thông qua phương thức này.

Chiều rộng và chiều cao được chỉ định bằng **points**, với 72 points mỗi inch. Ví dụ, 900 × 600 points tương đương 12,5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình chiếu, chứ không phải cho ghi chú của từng slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getNotesSize) | Kiểm soát kích thước trang ghi chú và kích thước trang được sử dụng cho xuất bản handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlideSize) | Kiểm soát kích thước các slide thông thường của bản trình chiếu thông qua [SlideSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/). |

Việc thay đổi bất kỳ cài đặt nào cũng không tự động thay đổi cài đặt còn lại. Thay đổi hướng của trang ghi chú cũng không làm quay các slide thông thường. Xem [Kích thước Slide](/slides/vi/python-java/slide-size/) để thay đổi kích thước các slide thông thường.

Các ví dụ dưới đây sử dụng tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy sử dụng một bản trình chiếu có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể được chạy độc lập.

## **Đọc Kích Thước và Hướng của Trang Ghi Chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là ngang (landscape), trang cao hơn là dọc (portrait), và các kích thước bằng nhau mô tả trang vuông. Ví dụ này in ra kích thước thực tế tính bằng points, mà không giả định kích thước giấy tiêu chuẩn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Chuyển sang Ngang mà Không Thay Đổi Kích Thước Giấy**

Để chỉ thay đổi hướng, hoán đổi chiều rộng và chiều cao hiện có. Điều này giữ nguyên độ dài của cả hai phía, bao gồm cả kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và để trang vuông không bị thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `size.getWidth() > size.getHeight()`. Không thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và Xác Minh Kích Thước Trang Ghi Chú Tùy Chỉnh**

Gán cả hai kích thước đồng thời, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi bản trình chiếu. Ví dụ này thiết lập một trang ngang 900 × 600 point, lưu dưới dạng PPTX, và mở lại tệp đã lưu để kiểm tra các giá trị được lưu giữ. So sánh cho phép sai số 0,01 point đối với các giá trị số thực; đây không phải là đảm bảo độ chính xác cho mọi định dạng tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Kết quả mong đợi là `900.0 x 600.0 points` và `Size preserved: True`. Kiểm tra một bản trình chiếu vừa mở lại xác nhận tệp đã lưu, thay vì chỉ các cài đặt trong bộ nhớ.

## **Xuất Ghi Chú và Handout**

Kích thước trang xác định khu vực khả dụng cho bố cục ghi chú hoặc handout. Chúng không tự động kích hoạt các bố cục này: cần cấu hình các tùy chọn xuất. Xuất slide thông thường vẫn sử dụng kích thước slide.

### **Xuất Ghi Chú ra PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) vào [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú thành PNG bằng cách sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) và [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa có thể bị cắt ngắn. PDF sử dụng các trang 900 × 600 point. Với tỷ lệ ảnh 1 × 1 được dùng dưới đây, PNG có kích thước 900 × 600 pixel. Points mô tả hình học trang; pixels mô tả đầu ra raster, kích thước của nó cũng phụ thuộc vào tỷ lệ render.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/) cho phép thêm các trang khi cần. Không sử dụng chế độ này với lời gọi ảnh một slide duy nhất ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra kết quả để xem ghi chú có bị cắt không và vị trí của các đối tượng notes‑master hiện có; việc chỉ thay đổi kích thước trang không nên được coi là đảm bảo mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/python-java/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Handout ra PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handoutlayoutingoptions/) cho nhiều hình thu nhỏ slide trên một trang. Ví dụ sau thiết lập một trang 900 × 600 point và sử dụng [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handouttype/) để sắp xếp tối đa bốn slide trên mỗi trang. Cài đặt ngang điều khiển thứ tự slide; hướng trang được lấy từ chiều rộng và chiều cao của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Thay đổi kích thước trang thay đổi khu vực khả dụng cho lưới handout mà không thay đổi kích thước slide nguồn. Đối với ảnh handout, sử dụng [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) với bố cục handout, thay vì phương thức ảnh của từng slide riêng lẻ. Trong Aspose.Slides, việc render handout ở mức bản trình chiếu sử dụng kích thước trang ghi chú, trong khi lời gọi ảnh của slide riêng lẻ không tạo trang handout. Xem [Handout Mode](/slides/vi/python-java/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích Thước Trang trong Trình Xem, Xuất và In**

Giữ kích thước bản trình chiếu đã lưu, kích thước trang xuất và kích thước giấy in riêng biệt:

- **Presentation viewers:** Một trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng của nó. Nếu một ứng dụng khác lưu tệp, hãy mở lại và kiểm tra kích thước một lần nữa; quá trình chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Export formats:** Các ví dụ PDF ghi chú và handout ở trên sử dụng kích thước trang đã cấu hình. Hình raster sử dụng kích thước pixel nguyên và tỷ lệ render, vì vậy các giá trị point thập phân có thể được làm tròn trong đầu ra ảnh. Xuất các slide thông thường không áp dụng kích thước trang ghi chú.
- **Printer drivers:** Lựa chọn giấy, tự động xoay và cài đặt vừa trang có thể thay đổi kết quả vật lý mà không thay đổi kích thước lưu trong bản trình chiếu hoặc PDF. Đối với một kích thước giấy cụ thể, hãy khớp cài đặt máy in và kiểm tra bản xem trước khi in.

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước ghi chú cho một slide duy nhất không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình chiếu. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không làm thay đổi các slide của tôi?**

Các trang ghi chú và các slide thông thường có kích thước độc lập. Sử dụng cài đặt kích thước slide thông thường khi bạn muốn thay đổi kích thước các slide.

**Tại sao kết quả lưu hoặc in của tôi có kích thước khác?**

Đầu tiên mở lại bản trình chiếu đã lưu và so sánh kích thước ghi chú của nó. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong ứng dụng khác có thay đổi cài đặt trang không. Nếu không, kiểm tra bố cục xuất, tỷ lệ ảnh, cài đặt trình xem và lựa chọn giấy của máy in.