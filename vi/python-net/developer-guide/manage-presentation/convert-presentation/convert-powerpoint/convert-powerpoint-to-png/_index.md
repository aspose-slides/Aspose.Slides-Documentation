---
title: Chuyển đổi các slide PowerPoint sang PNG trong Python
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/python-net/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint sang PNG
- chuyển đổi bản trình chiếu sang PNG
- chuyển đổi slide sang PNG
- chuyển đổi PPT sang PNG
- chuyển đổi PPTX sang PNG
- chuyển đổi ODP sang PNG
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- ODP sang PNG
- Python
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument thành hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho Python thông qua .NET, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide bản trình chiếu sang hình ảnh PNG bằng Aspose.Slides cho Python thông qua .NET. Bạn có thể tải bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render mỗi slide và lưu chúng dưới dạng hình ảnh PNG riêng biệt.

Các ví dụ bên dưới minh họa việc render ở tỉ lệ mặc định, tăng tỉ lệ, chỉ định kích thước đầu ra bằng pixel, và chọn kiểu render gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và truy cập các slide của nó thông qua bộ sưu tập [các slide](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Ví dụ này render mỗi slide bằng [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) không có tham số để tạo thumbnail. Sau đó nó gọi [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) với [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Phiên bản tải về không có tham số của [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) render ở tỉ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 điểm sẽ tạo thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, hãy sử dụng các phiên bản tải về với hệ số tỉ lệ hoặc kích thước ảnh cụ thể như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước tùy chỉnh**

Cung cấp các hệ số tỉ lệ ngang và dọc cho [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) để điều khiển kích thước đã render. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide kích thước 720 × 540 điểm sẽ tạo ra ảnh 1440 × 1080 pixel. Các hệ số tỉ lệ bằng nhau giữ tỷ lệ khung hình của slide. Mỗi ảnh được lưu ở định dạng PNG bằng [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước tùy chỉnh**

Để chỉ định kích thước đầu ra bằng pixel, truyền một kích thước cho [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) thay vì các hệ số tỉ lệ. Ví dụ này render mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Chọn kích thước phù hợp với tỷ lệ khung hình của slide để tránh kéo dãn ảnh.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Chọn Kiểu Render Gradient**

Giả sử một slide chứa các fill gradient, nhưng các chuyển tiếp trong PNG xuất ra trông nhẹ hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng thuộc tính [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) của [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) để chọn cách các gradient được render.

Tải về [gradient-styles.pptx](gradient-styles.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa hai gradient tuyến tính: màu lục lam sang cam ở trên và màu xanh dương sang vàng ở dưới. Mỗi gradient có hai điểm dừng, ở 0% và 100%.

Ví dụ sau tải bản trình chiếu này và render slide đầu tiên ở cả hai chế độ bằng [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Các hình ảnh dưới đây hiển thị đầu ra từ cùng một slide, với cả hai gradient trong mỗi hình ảnh:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient từ xanh lam sang cam và xanh dương sang vàng được render với Default](gradient-Default.png) | ![Các gradient giống nhau được render với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `DEFAULT` tạo ra màu trung gian nhẹ hơn, trong khi `POWER_POINT_UI` tạo ra màu trung gian tối hơn. Sự khác biệt phụ thuộc vào màu sắc và các điểm dừng trong gradient.

Chọn `DEFAULT` khi đầu ra tiêu chuẩn của Aspose.Slides phù hợp với nhu cầu của bạn. Thử `POWER_POINT_UI` khi ưu tiên của bạn là phù hợp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không chế độ nào là tốt nhất cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xuất một hình dạng cụ thể, chẳng hạn biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/python-net/create-shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có. Sử dụng một thể hiện presentation riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/python-net/multithreading/).

**Những hạn chế nào của chế độ evaluation khi xuất sang PNG?**

Chế độ evaluation sẽ thêm watermark vào các ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/python-net/licensing/) cho đến khi giấy phép được cấp.