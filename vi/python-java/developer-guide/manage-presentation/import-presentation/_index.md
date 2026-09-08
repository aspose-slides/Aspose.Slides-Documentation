---
title: Nhập bản trình bày từ PDF hoặc HTML trong Python qua Java
linktitle: Nhập bản trình bày
type: docs
weight: 60
url: /vi/python-java/import-presentation/
keywords:
- nhập bản trình bày
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bản trình bày
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản trình bày
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhập nội dung PDF và HTML vào các bản trình bày PowerPoint trong Python qua Java bằng Aspose.Slides và lưu kết quả dưới dạng tệp PPTX."
---
## **Giới thiệu**

Aspose.Slides cho Python qua Java có thể chuyển các trang PDF hoặc nội dung HTML thành các slide PowerPoint mà không cần Microsoft PowerPoint. Lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp các phương thức [addFromPdf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromPdf) và [addFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromHtml) để thêm nội dung đã nhập vào một bản trình bày.

Để kiểm soát tốt hơn vị trí HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertFromHtml) có thể chèn các slide được tạo ra tại một chỉ mục của bộ sưu tập hoặc bắt đầu lấp đầy không gian có sẵn trên một slide hiện có. HTML dài sẽ được phân trang tự động sang các slide bổ sung, nguồn có thể được cung cấp dưới dạng chuỗi hoặc luồng, và các tài nguyên bên ngoài có thể được tải thông qua [ExternalResourceResolver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/externalresourceresolver/) với một URI cơ sở. Mảng [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) trả về xác định các slide bị ảnh hưởng và các slide mới được tạo.

## **Nhập từ PDF**

Để chuyển đổi tài liệu PDF sang bản trình bày PowerPoint, nhập nội dung của nó vào bộ sưu tập slide và lưu kết quả dưới dạng tệp PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) mới.
2. Gọi [addFromPdf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromPdf) với đường dẫn tới tệp PDF.
3. Gọi [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Pptx) để ghi bản trình bày ra tệp PPTX.

Ví dụ Python sau nhập một tài liệu PDF và lưu các slide được tạo thành một bản trình bày PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Slide trắng mặc định vẫn còn trong bản trình bày vì việc nhập thêm các slide vào cuối. Để chỉ giữ các trang đã nhập, hãy xóa bộ sưu tập slide bằng [SlideCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#clear) trước khi nhập.

Phương thức [addFromPdf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromPdf) trả về các slide mà nó thêm vào, điều này hữu ích khi bạn chỉ cần xử lý các slide đã nhập.

{{% alert title="Tip" color="success" %}}
Hãy thử ứng dụng web miễn phí [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) để thấy quy trình chuyển đổi này hoạt động.
{{% /alert %}}

## **Nhập từ HTML**

Aspose.Slides cũng có thể tạo các slide từ một tài liệu HTML. Nguồn có thể được cung cấp dưới dạng văn bản HTML hoặc một luồng. Các bước sau sử dụng một luồng tệp:

1. Tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) mới.
2. Mở tệp HTML để đọc và truyền luồng vào [addFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Gọi [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Pptx) để ghi kết quả ra tệp PPTX.

Ví dụ Python sau nhập một tài liệu HTML và lưu các slide được tạo thành một bản trình bày PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chèn nội dung HTML**

Sử dụng [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertFromHtml) khi các slide được tạo từ HTML phải được đặt ở vị trí cụ thể thay vì được thêm vào cuối. Chỉ mục bắt đầu từ 0 và xác định vị trí bắt đầu nhập.

Đối số `useSlideWithIndexAsStart` điều khiển cách trình nhập sử dụng vị trí đó:

- Khi nó là `False`, trình nhập tạo các slide mới tại chỉ mục đã chỉ định và đẩy các slide sau chúng sang phía sau.
- Khi nó là `True`, trình nhập bắt đầu đặt nội dung vào không gian có sẵn trên slide hiện có tại chỉ mục đó. Nếu HTML không vừa, Aspose.Slides sẽ tự động phân trang và chèn các slide bổ sung ngay sau slide bắt đầu.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertFromHtml) trả về một mảng các đối tượng [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/). Khi việc chèn bắt đầu trên các slide mới, mỗi mục trả về đều là slide mới được tạo. Khi một slide hiện có được dùng làm điểm bắt đầu, mảng sẽ bao gồm slide bị ảnh hưởng đó theo sau là bất kỳ slide tràn mới nào. Bạn có thể kiểm tra mảng này thay vì tính toán phạm vi bị ảnh hưởng dựa trên số lượng slide của bản trình bày.

### **Chèn HTML như các slide mới**

Ví dụ sau cung cấp HTML dưới dạng chuỗi và chèn các slide được tạo tại chỉ mục bộ sưu tập `1`. Truyền `False` sẽ giữ các slide hiện có không thay đổi ngoại trừ việc đẩy chúng sang để tạo chỗ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bắt đầu trên một Slide hiện có**

Ví dụ tiếp theo cung cấp HTML qua một luồng. Nó giữ lại một hình dạng tiêu đề trên slide mẫu hiện có, bắt đầu nhập dưới khu vực đã chiếm, và cho phép phần nội dung dài tiếp tục trên các slide mới.

HTML cũng chứa một URL hình ảnh tương đối. Một [ExternalResourceResolver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/externalresourceresolver/) sẽ lấy tài nguyên, trong khi URI cơ sở cho trình nhập biết cách giải quyết `images/logo.png`. Trong ví dụ này, tệp đó dự kiến nằm ở `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Một trình giải quyết tài nguyên bên ngoài không giới hạn có thể đọc các tài nguyên cục bộ hoặc mạng được HTML tham chiếu. Đối với đầu vào không tin cậy, hãy xác thực và làm sạch các URL tài nguyên dựa trên danh sách cho phép các scheme, thư mục và máy chủ được phép trước khi nhập HTML.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có thể phát hiện bảng khi nhập PDF không?**

Có. Tạo một đối tượng [PdfImportOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfimportoptions/), gọi [setDetectTables](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfimportoptions/#setDetectTables) với `True`, và truyền các tùy chọn này vào [addFromPdf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromPdf). Chất lượng nhận dạng bảng phụ thuộc vào cấu trúc và độ phức tạp của PDF nguồn.

{{% alert title="Note" color="info" %}}
Sau khi nhập HTML, bạn cũng có thể xuất các slide sang [images](/slides/vi/python-java/convert-powerpoint-to-png/), [TIFF](/slides/vi/python-java/convert-powerpoint-to-tiff/), hoặc [SVG](/slides/vi/python-java/render-slide-as-svg/).
{{% /alert %}}