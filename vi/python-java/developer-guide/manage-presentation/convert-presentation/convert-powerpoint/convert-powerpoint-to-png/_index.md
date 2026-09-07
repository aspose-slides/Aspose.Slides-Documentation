---
title: Chuyển đổi các slide PowerPoint sang PNG trong Python
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/python-java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bài thuyết trình sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint sang ảnh PNG trong Python thông qua Java. Xuất các bài thuyết trình PPT, PPTX và ODP với tỉ lệ tùy chỉnh hoặc kích thước ảnh chính xác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint sang ảnh PNG bằng Aspose.Slides cho Python thông qua Java. Bạn có thể tải các tệp PPT, PPTX và ODP, vẽ lại mỗi slide và lưu nó thành ảnh PNG riêng biệt.

Các ví dụ cũng cho thấy cách kiểm soát kích thước đầu ra bằng các hệ số tỉ lệ hoặc chiều rộng và chiều cao cố định. Mỗi ví dụ sẽ khởi động máy ảo Java nếu cần và giải phóng tài nguyên bản trình chiếu và ảnh sau khi sử dụng.

## **Chuyển đổi PowerPoint sang PNG**

1. Tải tệp đầu vào bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy danh sách các slide bằng cách sử dụng [Presentation.getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides).
3. Vẽ lại mỗi slide bằng cách sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage).
4. Lưu mỗi ảnh đã vẽ bằng [ImageFormat.Png](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/#Png), sau đó giải phóng tài nguyên của nó.

Ví dụ Python sau đây xuất tất cả các slide với kích thước mặc định của chúng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PNG với Tỷ lệ Tùy chỉnh**

Chuyển các hệ số tỉ lệ ngang và dọc vào [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) để tăng hoặc giảm kích thước đầu ra. Ví dụ, một slide có kích thước 720 × 540 điểm được vẽ lại với hệ số tỉ lệ 2 trên cả hai trục sẽ tạo ra ảnh có kích thước 1440 × 1080 pixel.

Sử dụng các hệ số tỉ lệ bằng nhau để duy trì tỉ lệ khung hình của slide. Các hệ số khác nhau sẽ kéo dãn slide theo chiều ngang hoặc chiều dọc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước pixel chính xác, chuyển một đối tượng Java `Dimension` với chiều rộng và chiều cao mong muốn vào [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage). Chọn kích thước có cùng tỉ lệ khung hình với slide nguồn để tránh biến dạng.

Ví dụ sau lưu mỗi slide dưới dạng ảnh PNG có kích thước 960 × 720 pixel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể xuất một hình dạng riêng lẻ, chẳng hạn như biểu đồ hoặc hình ảnh, thay vì toàn bộ slide không?**

Có. Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/python-java/create-shape-thumbnails/), bạn có thể lưu chúng dưới dạng ảnh PNG.

**Tôi có thể chuyển đổi các bản trình chiếu song song trên máy chủ không?**

Sử dụng một thể hiện Presentation riêng cho mỗi luồng hoặc tiến trình, và sử dụng các đường dẫn đầu ra duy nhất để tránh việc ghi đè tệp. Không chia sẻ một thể hiện Presentation giữa các luồng. Xem [Multithreading](/slides/vi/python-java/multithreading/).

**Các hạn chế của phiên bản dùng thử khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/python-java/licensing/). Cài đặt giấy phép để loại bỏ các hạn chế này.