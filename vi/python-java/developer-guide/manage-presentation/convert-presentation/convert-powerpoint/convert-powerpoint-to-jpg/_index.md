---
title: Chuyển đổi PPT và PPTX sang JPG trong Python
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/python-java/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- PowerPoint sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu slide dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang hình ảnh JPG trong Python qua Java. Đặt kích thước ảnh tùy chỉnh và hiển thị ghi chú cũng như bình luận với Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cho phép bạn chuyển đổi các bài thuyết trình PowerPoint và OpenDocument (PPT, PPTX và ODP) thành hình ảnh JPEG. Bạn có thể xuất tất cả các slide hoặc một slide được chọn để tạo ảnh thu nhỏ, xây dựng một trình xem bài thuyết trình, hoặc nhúng các bản xem trước slide trong trang web hoặc ứng dụng.

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG**

1. Tải bài thuyết trình bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy danh sách các slide bằng [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides).
3. Gọi [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) với các hệ số tỉ lệ chiều ngang và chiều dọc để hiển thị mỗi slide.
4. Lưu mỗi hình đã hiển thị dưới dạng JPEG bằng [ImageFormat.Jpeg](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/#Jpeg), sau đó giải phóng tài nguyên hình ảnh.

{{% alert color="info" title="Note" %}}
Xuất sang JPG tạo ra một hình ảnh riêng cho mỗi slide. Lưu hình đã hiển thị thay vì lưu trực tiếp bài thuyết trình dưới dạng định dạng hình ảnh.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG với Kích thước Tùy chỉnh**

Tính các hệ số tỉ lệ chiều ngang và chiều dọc dựa trên kích thước pixel mong muốn và kích thước slide gốc, sau đó truyền chúng vào [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage). Ví dụ dưới đây hướng tới một hình 1200 × 800 cho mỗi slide.

Sử dụng các hệ số tỉ lệ khác nhau có thể kéo dài slide. Để giữ nguyên tỉ lệ khung hình, hãy sử dụng cùng một hệ số cho cả hai trục; chiều rộng và chiều cao kết quả sẽ tuân theo tỷ lệ gốc của slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Hiển thị Bình luận Khi Lưu Slide dưới dạng Hình ảnh**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) để cấu hình ghi chú và bình luận, và áp dụng bố cục qua [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Ví dụ này đặt ghi chú ở cuối, cắt ngắn các ghi chú không vừa, và hiển thị bình luận ở phía bên phải trong vùng rộng 200 pixel. Nó lưu mỗi slide đã hiển thị dưới dạng ảnh JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều slide hoặc bài thuyết trình sang JPG không?**

Có. Các ví dụ lặp qua tất cả các slide và lưu một JPG cho mỗi slide. Để xử lý nhiều bài thuyết trình, lặp lại quá trình chuyển đổi cho mỗi tệp đầu vào và sử dụng các thư mục đầu ra riêng biệt hoặc tên tệp duy nhất để tránh ghi đè lên các hình ảnh.

**Biểu đồ, SmartArt, bảng và hình dạng có được đưa vào hình ảnh không?**

Những đối tượng này được hiển thị như một phần của slide. Đảm bảo các phông chữ được sử dụng trong bài thuyết trình có sẵn trong môi trường chuyển đổi để giảm sự khác biệt do thay thế phông chữ.

**Làm sao tôi có thể giảm lượng bộ nhớ khi xuất các bài thuyết trình lớn?**

Xử lý từng hình ảnh một, giải phóng mỗi hình sau khi lưu, và tránh các kích thước đầu ra quá lớn không cần thiết. Yêu cầu bộ nhớ phụ thuộc vào nội dung slide và kích thước hình ảnh.

## **Xem Thêm**

- [Chuyển đổi PowerPoint sang PNG](/slides/vi/python-java/convert-powerpoint-to-png/).
- [Hiển thị một slide dưới dạng hình ảnh SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/).