---
title: Chuyển đổi bản trình chiếu PowerPoint sang tài liệu Word trong Python
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint sang DOCX
- OpenDocument sang DOCX
- bản trình chiếu sang DOCX
- slide sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- ODP sang DOCX
- PowerPoint sang DOC
- OpenDocument sang DOC
- bản trình chiếu sang DOC
- slide sang DOC
- PPT sang DOC
- PPTX sang DOC
- ODP sang DOC
- PowerPoint sang Word
- OpenDocument sang Word
- bản trình chiếu sang Word
- slide sang Word
- PPT sang Word
- PPTX sang Word
- ODP sang Word
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- chuyển đổi ODP
- Python
- Aspose.Slides
description: "Tìm hiểu cách chuyển đổi một cách dễ dàng các bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word bằng cách sử dụng Aspose.Slides cho Python thông qua .NET. Hướng dẫn từng bước của chúng tôi cùng mã Python mẫu cung cấp giải pháp cho các nhà phát triển muốn tối ưu hóa quy trình làm việc với tài liệu."
---
## **Tổng quan**

Bài viết này cung cấp giải pháp cho các nhà phát triển về việc chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word bằng cách sử dụng Aspose.Slides for Python via .NET và Aspose.Words for Python via .NET. Hướng dẫn từng bước sẽ đưa bạn qua mọi giai đoạn của quá trình chuyển đổi.

## **Chuyển đổi bản trình chiếu sang tài liệu Word**

Thực hiện các hướng dẫn dưới đây để chuyển đổi bản trình chiếu PowerPoint hoặc OpenDocument sang tài liệu Word:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải tệp bản trình chiếu.
2. Tạo các thể hiện của lớp [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) và [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) để tạo tài liệu Word.
3. Đặt kích thước trang cho tài liệu Word sao cho khớp với bản trình chiếu bằng cách sử dụng thuộc tính [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Đặt lề cho tài liệu Word bằng cách sử dụng thuộc tính [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Duyệt qua tất cả các slide trong bản trình chiếu bằng thuộc tính [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/).
    - Tạo ảnh slide bằng phương thức `get_image` từ lớp [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) và lưu nó vào một luồng bộ nhớ.
    - Thêm ảnh slide vào tài liệu Word bằng phương thức `insert_image` từ lớp [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).
6. Lưu tài liệu Word vào tệp.

Giả sử chúng ta có một bản trình chiếu "sample.pptx" trông như sau:

![Bản trình chiếu PowerPoint](PowerPoint.png)

```py
import aspose.slides as slides
import aspose.words as words

# Tải tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:

    # Tạo các đối tượng Document và DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Đặt kích thước trang trong tài liệu Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Đặt lề trong tài liệu Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Duyệt qua tất cả các slide của bản trình chiếu.
    for slide in presentation.slides:

        # Tạo ảnh slide và lưu nó vào luồng bộ nhớ.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Thêm ảnh slide vào tài liệu Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Lưu tài liệu Word vào tệp.
    document.save("output.docx")
```

Kết quả:

![Tài liệu Word](Word.png)

{{% alert color="primary" %}} 
Hãy thử công cụ [**Online PPT to Word Converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-word) của chúng tôi để xem bạn có thể thu được gì khi chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word. 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Cần cài đặt những thành phần nào để chuyển đổi bản trình chiếu PowerPoint và OpenDocument sang tài liệu Word?**

Bạn chỉ cần thêm các gói tương ứng cho [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) và [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) vào dự án Python của mình. Cả hai gói hoạt động như các API độc lập và không yêu cầu cài đặt Microsoft Office.

**Có hỗ trợ tất cả các định dạng bản trình chiếu PowerPoint và OpenDocument không?**

Aspose.Slides for Python .NET [hỗ trợ tất cả các định dạng bản trình chiếu](/slides/vi/python-net/supported-file-formats/), bao gồm PPT, PPTX, ODP và các loại tệp phổ biến khác. Điều này đảm bảo bạn có thể làm việc với các bản trình chiếu được tạo trong nhiều phiên bản khác nhau của Microsoft PowerPoint.