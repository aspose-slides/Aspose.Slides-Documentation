---
title: Chuyển đổi bản trình bày PowerPoint sang tài liệu Word trong Python qua Java
linktitle: PowerPoint sang Word
type: docs
weight: 110
url: /vi/python-java/convert-powerpoint-to-word/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- PowerPoint sang Word
- bản trình bày sang Word
- PPT sang Word
- PPTX sang Word
- ODP sang Word
- PowerPoint sang DOCX
- PPT sang DOCX
- PPTX sang DOCX
- PowerPoint sang DOC
- lưu PPT dưới dạng DOCX
- lưu PPTX dưới dạng DOCX
- xuất PPT sang DOCX
- xuất PPTX sang DOCX
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang Word trong Python qua Java với Aspose.Slides và Aspose.Words, kết hợp hình ảnh slide với văn bản có thể chỉnh sửa."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình bày PowerPoint và OpenDocument sang tài liệu Word bằng cách sử dụng Aspose.Slides cho Python qua Java cùng với Aspose.Words cho Java. Aspose.Slides tạo hình ảnh cho mỗi slide và đọc văn bản của nó, trong khi Aspose.Words tạo tài liệu Word thông qua JPype. Không cần cài đặt Microsoft Office.

Tài liệu kết quả chứa một hình ảnh slide tiếp theo là văn bản có thể chỉnh sửa được trích xuất từ các auto shape cấp cao nhất của slide đó. Hình ảnh giữ nguyên giao diện trực quan của slide; các hình dạng, biểu đồ và bảng riêng lẻ không được chuyển đổi thành các đối tượng Word có thể chỉnh sửa. Văn bản đã trích xuất không giữ định dạng hoặc vị trí ban đầu của văn bản.

## **Chuyển đổi PowerPoint sang Word**

1. Cài đặt [Aspose.Slides for Python via Java](/slides/vi/python-java/installation/) và một môi trường chạy Java tương thích.
2. Tải xuống [Aspose.Words for Java](https://releases.aspose.com/words/java/). Đặt file JAR chính của nó vào thư mục `lib` bên cạnh script của bạn và đổi tên thành `aspose-words.jar`, hoặc điều chỉnh đường dẫn trong ví dụ để phù hợp với file bạn đã tải.
3. Đặt bản trình bày đầu vào, `sample.pptx`, vào thư mục làm việc. Đường dẫn `lib/aspose-words.jar` cũng tương đối với thư mục đó.
4. Chạy đoạn mã Python sau để tạo `output.docx`.

Ví dụ tải nguồn bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tạo hình ảnh các slide bằng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage). Nó sử dụng [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) từ Aspose.Words để chèn hình ảnh và văn bản vào tài liệu Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Điều chỉnh kích thước hình ảnh slide cho độ rộng vùng văn bản, giữ nguyên tỷ lệ khung hình.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Thêm văn bản thuần từ các auto shape cấp cao nhất, bao gồm các hộp văn bản.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Mỗi slide bắt đầu trên một trang mới. Văn bản trích xuất dài hoặc hình ảnh slide bất thường cao có thể yêu cầu thêm trang. Đoạn mã chỉ chèn ngắt trang giữa các slide và giải phóng bản trình bày và các hình ảnh đã tạo trong các khối `finally`. JVM vẫn còn sẵn sàng cho các chuyển đổi tiếp theo trong cùng một tiến trình Python.

## **Câu hỏi thường gặp**

**Các thư viện nào được yêu cầu?**

Sử dụng Aspose.Slides for Python via Java, JPype, một môi trường chạy Java tương thích, và Aspose.Words cho Java. Cả hai thư viện Aspose chạy trong cùng một JVM. Aspose.Slides xử lý bản trình bày; Aspose.Words ghi tài liệu Word.

**Tôi có thể chuyển đổi các tệp PPT và ODP cũng như PPTX không?**

Có. Thay `sample.pptx` bằng tệp PPT hoặc ODP. Xem [Supported File Formats](/slides/vi/python-java/supported-file-formats/) để biết các định dạng file đầu vào cho bản trình bày.

**Tất cả nội dung slide có thể chỉnh sửa được trong Word không?**

Không. Mỗi slide được chèn dưới dạng hình ảnh tĩnh, với văn bản thuần từ các auto shape cấp cao nhất được thêm vào phía dưới. Văn bản trong nhóm, bảng, SmartArt và biểu đồ, cũng như ghi chú người thuyết trình, không được ví dụ này trích xuất. Các hoạt ảnh và chuyển tiếp cũng không được tái tạo trong tài liệu Word.

**Tôi có thể lưu dưới dạng DOC thay vì DOCX không?**

Có. Đổi tên tệp đầu ra thành `output.doc`. Aspose.Words chọn định dạng đầu ra dựa trên phần mở rộng của tên tệp khi sử dụng phương thức lưu này.