---
title: Chuyển đổi các slide PowerPoint sang PNG trong Python
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/python-java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
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
description: "Chuyển đổi các slide PowerPoint sang hình ảnh PNG trong Python thông qua Java. Xuất bản trình chiếu PPT, PPTX và ODP với tỉ lệ tùy chỉnh hoặc kích thước ảnh chính xác."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide trình chiếu sang hình ảnh PNG bằng Aspose.Slides cho Python thông qua Java. Bạn có thể tải các bản trình chiếu ở các định dạng như PPT, PPTX và ODP, hiển thị mỗi slide và lưu nó thành một hình ảnh PNG riêng.

Các ví dụ dưới đây minh họa việc hiển thị ở tỉ lệ mặc định, tăng tỉ lệ, chỉ định kích thước đầu ra bằng pixel và chọn kiểu hiển thị gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và truy cập các slide của nó thông qua bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Ví dụ này hiển thị mỗi slide bằng [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) không có tham số để tạo thumbnail. Sau đó nó gọi [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) với [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) để lưu mỗi slide đã hiển thị thành một hình ảnh PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Phiên bản [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) không có tham số sẽ hiển thị ở tỉ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 điểm sẽ tạo ra một thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, hãy sử dụng các phiên bản có hệ số tỉ lệ hoặc kích thước hình ảnh rõ ràng được hiển thị bên dưới.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Chuyển các hệ số tỉ lệ chiều ngang và chiều dọc cho [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) để kiểm soát kích thước hiển thị. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide có kích thước 720 × 540 điểm sẽ tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỉ lệ bằng nhau giữ nguyên tỉ lệ khung hình của slide. Mỗi hình ảnh đã hiển thị được lưu ở định dạng PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra bằng pixel, truyền một kích thước cho [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) thay vì các hệ số tỉ lệ. Ví dụ này hiển thị mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả ở định dạng PNG. Chọn kích thước phù hợp với tỉ lệ khung hình của slide để tránh kéo dài hình ảnh.

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Chọn Kiểu Hiển thị Gradient**

Giả sử một slide chứa các màu gradient, nhưng các chuyển đổi trong PNG xuất ra trông nhẹ hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng phương thức [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) được kế thừa bởi [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) để chọn cách các gradient được hiển thị.

Tải xuống [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa hai gradient tuyến tính: từ xanh lục sang cam ở phần trên và từ xanh dương sang vàng ở phần dưới. Mỗi gradient có hai điểm dừng, tại 0% và 100%.

Ví dụ sau tải bản trình chiếu này và hiển thị slide đầu tiên giống nhau trong cả hai chế độ bằng [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Các hình ảnh dưới đây hiển thị kết quả từ cùng một slide, với cả hai gradient trong mỗi hình ảnh:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient từ xanh lơ sang cam và từ xanh dương sang vàng được hiển thị với Default](gradient-Default.png) | ![Các gradient tương tự được hiển thị với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian nhẹ hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào các màu và điểm dừng trong gradient.

Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không có chế độ nào là ưu tiên chung cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xuất một hình dạng cụ thể, chẳng hạn biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/python-java/create-shape-thumbnails/), cho phép bạn hiển thị một hình dạng dưới dạng hình ảnh PNG.

**Chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Đúng. Sử dụng một thể hiện presentation riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/python-java/multithreading/).

**Những giới hạn của chế độ đánh giá khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/python-java/licensing/) cho tới khi cấp phép.