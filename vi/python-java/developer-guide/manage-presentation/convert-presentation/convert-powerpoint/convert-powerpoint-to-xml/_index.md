---
title: Chuyển đổi bản trình bày PowerPoint sang XML trong Python qua Java
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/python-java/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình bày sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- lưu bản trình bày dưới dạng XML
- xuất bản trình bày sang XML
- luồng XML
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang tệp XML PowerPoint hoặc luồng trong Python qua Java với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể chuyển đổi các bản trình bày PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dựa trên văn bản để kiểm tra cấu trúc bản trình bày, khắc phục sự cố tài liệu được tạo, so sánh kết quả trong các kiểm thử tự động, hoặc tích hợp với quy trình công việc tiêu thụ XML thay vì gói bản trình bày.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với giá trị [Xml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Xml) từ lớp [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Xml) tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.

{{% /alert %}}

## **Chuyển đổi bản trình bày sang tệp XML**

Tải một bản trình bày nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), sau đó truyền đường dẫn đầu ra và [SaveFormat.Xml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Xml) vào [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Nguồn có thể là bất kỳ định dạng bản trình bày nào được hỗ trợ để tải, chẳng hạn PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản trình bày PPTX sang tệp XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Ghi đầu ra XML vào luồng**

Sử dụng phiên bản overload của [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) khi XML phải ở trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn dịch vụ web, nhà cung cấp lưu trữ, hoặc quy trình xử lý XML. Ví dụ sau ghi kết quả vào một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) và lấy XML thu được dưới dạng đối tượng bytes của Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Truyền xml_data tới thành phần tiếp theo trong quy trình làm việc.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **So sánh XML với các định dạng bản trình bày và xuất**

Chọn định dạng đầu ra tùy theo cách kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Sử dụng điển hình |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản trình bày nhị phân cũ | Tương thích với quy trình công việc PowerPoint phiên bản cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình bày |
| PDF hoặc TIFF | Các trang bố cục cố định hoặc ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện đã render của một slide riêng lẻ | Ảnh thu nhỏ, bản xem trước và tài sản hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình bày hướng web | Xem trong trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu dành cho việc kiểm tra và quy trình công việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng ảnh slide, nó biểu diễn dữ liệu bản trình bày thay vì render slide thành các trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/python-java/supported-file-formats/) liệt kê PowerPoint XML Presentation chỉ là định dạng lưu, vì vậy không sử dụng nó khi một quy trình công việc cần tải lại tệp đã xuất để tiếp tục chỉnh sửa trong Aspose.Slides.

## **Câu hỏi thường gặp**

**Xuất XML có giống như lưu tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi [SaveFormat.Xml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Xml) tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng đầu ra Java có khả năng ghi vào [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Ví dụ, sử dụng một [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) cho xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu, không hỗ trợ tải lại. Hãy sử dụng PPTX hoặc một định dạng bản trình bày được hỗ trợ khác khi cần chỉnh sửa vòng vòng.

**Việc chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu cấu trúc của bản trình bày. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho ảnh slide riêng lẻ.