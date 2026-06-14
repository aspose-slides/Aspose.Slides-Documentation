---
title: Nhập Bản Trình Bày bằng Python
linktitle: Nhập Bản Trình Bày
type: docs
weight: 60
url: /vi/python-net/import-presentation/
keywords:
- nhập PowerPoint
- nhập bản trình bày
- nhập slide
- PDF sang bản trình bày
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản trình bày
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- Python
- Aspose.Slides
description: "Dễ dàng nhập tài liệu PDF và HTML vào các bản trình bày PowerPoint và OpenDocument trong Python bằng Aspose.Slides để xử lý slide mượt mà, hiệu suất cao."
---
## **Giới thiệu**

Với [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/vi/python-net/), bạn có thể nhập nội dung vào một bản trình bày từ các định dạng tệp khác. Lớp [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) cung cấp các phương thức để nhập các slide từ PDF, HTML và các nguồn khác.

## **Chuyển PDF sang Bản Trình Bày**

Phần này mô tả cách chuyển PDF thành bản trình bày bằng Aspose.Slides. Nó hướng dẫn bạn nhập PDF, chuyển các trang của nó thành slide và lưu kết quả dưới dạng tệp PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Gọi phương thức [add_from_pdf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_from_pdf/) và truyền tệp PDF.
3. Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để lưu bản trình bày dưới định dạng PowerPoint.

Ví dụ Python sau đây minh họa việc chuyển PDF sang bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Bạn có thể muốn thử **ứng dụng web miễn phí của Aspose** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) — đây là một triển khai thực tế của quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển HTML sang Bản Trình Bày**

Phần này mô tả cách nhập nội dung HTML vào bản trình bày bằng Aspose.Slides. Nó bao gồm việc tải HTML, chuyển đổi nó thành các slide với văn bản, hình ảnh và định dạng cơ bản được bảo lưu, và lưu kết quả dưới dạng tệp PPTX.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Gọi phương thức [add_from_html](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_from_html/) và truyền tệp HTML.
3. Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để lưu bản trình bày dưới định dạng PowerPoint.

Ví dụ Python sau đây minh họa việc chuyển HTML sang bản trình bày:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Có giữ lại bảng khi nhập PDF không, và có thể cải thiện khả năng phát hiện bảng không?**

Bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.importing/pdfimportoptions/) bao gồm tham số [detect_tables](https://reference.aspose.com/slides/vi/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.

{{% alert title="Note" color="info" %}}
Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác:

* [HTML sang hình ảnh](https://products.aspose.com/slides/vi/python-net/conversion/html-to-image/)
* [HTML sang JPG](https://products.aspose.com/slides/vi/python-net/conversion/html-to-jpg/)
* [HTML sang XML](https://products.aspose.com/slides/vi/python-net/conversion/html-to-xml/)
* [HTML sang TIFF](https://products.aspose.com/slides/vi/python-net/conversion/html-to-tiff/)

{{% /alert %}}