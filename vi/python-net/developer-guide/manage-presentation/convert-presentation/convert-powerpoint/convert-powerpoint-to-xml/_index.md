---
title: Chuyển đổi Bản trình chiếu PowerPoint sang XML trong Python
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/python-net/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- PowerPoint XML Presentation
- SaveFormat.XML
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- Python
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang tệp hoặc luồng PowerPoint XML trong Python với Aspose.Slides."
---
## **Tổng quan**

Aspose.Slides for Python via .NET có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần một biểu diễn dựa trên văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu được tạo, so sánh đầu ra trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói trình chiếu.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) với giá trị `XML` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.
{{% /alert %}}

## **Chuyển đổi một bản trình chiếu sang tệp XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), sau đó truyền đường dẫn đầu ra và `SaveFormat.XML` cho [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/). Nguồn có thể là bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ sau chuyển đổi một bản trình chiếu PPTX sang tệp XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Ghi đầu ra XML vào luồng**

Sử dụng overload luồng của [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) khi XML cần giữ trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn như dịch vụ web, nhà cung cấp lưu trữ, hoặc quy trình xử lý XML. Ví dụ sau ghi kết quả vào một luồng [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) và đưa con trỏ về đầu để đọc lại:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Truyền xml_stream tới thành phần tiếp theo trong quy trình làm việc.
```

## **So sánh XML với các định dạng Trình chiếu và Xuất**

Chọn định dạng đầu ra tùy theo cách sử dụng kết quả:

| Định dạng | Kết quả | Sử dụng điển hình |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một PowerPoint XML Presentation | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo, và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp bản trình chiếu nhị phân legacy | Tương thích với các quy trình PowerPoint cũ |
| PPTX (`.pptx`) | Gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Trang cố định hoặc hình ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện được render của một slide riêng lẻ | Hình thu nhỏ, bản xem trước và tài sản hình ảnh |
| HTML hoặc HTML5 | Đầu ra trình chiếu hướng web | Xem trong trình duyệt và xuất bản web |

Không giống như PPT và PPTX, đầu ra XML chủ yếu dành cho việc kiểm tra và quy trình làm việc dựa trên dữ liệu. Không giống như PDF, TIFF, HTML và các định dạng ảnh slide, nó biểu diễn dữ liệu trình chiếu thay vì render các slide thành trang hoặc tài sản hình ảnh. Bảng [định dạng tệp được hỗ trợ](/slides/vi/python-net/supported-file-formats/) danh sách PowerPoint XML Presentation chỉ là định dạng lưu, vì vậy không sử dụng nó khi quy trình phải tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat.XML` có giống như việc lưu thành tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.XML` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi được cho [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/). Ví dụ, sử dụng một luồng [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ hỗ trợ lưu mà không hỗ trợ tải. Sử dụng PPTX hoặc một định dạng trình chiếu được hỗ trợ khác khi cần chỉnh sửa vòng tròn.

**Quá trình chuyển đổi XML có tạo mỗi slide thành một trang hoặc hình ảnh không?**

Không. Quá trình chuyển đổi XML ghi dữ liệu trình chiếu có cấu trúc. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.