---
title: Chuyển đổi slide PowerPoint sang PNG bằng Python
linktitle: Slide sang PNG
type: docs
weight: 30
url: /vi/python-net/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint sang PNG
- chuyển đổi bản thuyết trình sang PNG
- chuyển đổi slide sang PNG
- chuyển đổi PPT sang PNG
- chuyển đổi PPTX sang PNG
- chuyển đổi ODP sang PNG
- PowerPoint sang PNG
- bản thuyết trình sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- ODP sang PNG
- Python
- Aspose.Slides
description: "Chuyển đổi các bản thuyết trình PowerPoint và OpenDocument sang hình ảnh PNG chất lượng cao nhanh chóng với Aspose.Slides cho Python qua .NET, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Aspose.Slides for Python via .NET giúp việc chuyển đổi các bản thuyết trình PowerPoint sang PNG trở nên đơn giản. Bạn tải một bản thuyết trình, duyệt qua các slide của nó, render mỗi slide thành một ảnh raster, và lưu kết quả dưới dạng các tệp PNG. Điều này rất phù hợp để tạo bản xem trước slide, nhúng slide vào trang web, hoặc tạo các tài sản tĩnh cho quy trình xử lý tiếp theo.

## **Chuyển đổi các slide sang PNG**

Phần này trình bày ví dụ đơn giản nhất để chuyển đổi một bản thuyết trình PowerPoint sang hình ảnh PNG bằng Aspose.Slides for Python via .NET.

Thực hiện các bước sau:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
1. Lấy một slide từ bộ sưu tập `Presentation.slides` (xem lớp [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/) ).
1. Sử dụng phương thức `Slide.get_image` để tạo một thumbnail của slide.
1. Sử dụng phương thức `Presentation.save` để lưu thumbnail slide ở định dạng PNG.

Đoạn mã Python sau minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Chuyển đổi các slide sang PNG với tỉ lệ tùy chỉnh**

Để xuất các slide sang PNG với tỉ lệ tùy chỉnh, gọi `Slide.get_image` với các hệ số tỉ lệ chiều ngang và chiều dọc. Các hệ số này thay đổi kích thước đầu ra so với kích thước gốc của slide — ví dụ, `2.0` sẽ nhân đôi cả chiều rộng và chiều cao. Sử dụng các giá trị bằng nhau cho `scale_x` và `scale_y` để giữ nguyên tỉ lệ khung hình.

Đoạn mã Python dưới đây thực hiện thao tác đã mô tả:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Chuyển đổi các slide sang PNG với kích thước tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với kích thước cụ thể, hãy truyền các giá trị `width` và `height` mong muốn. Đoạn mã dưới đây cho thấy cách chuyển đổi một PowerPoint sang PNG đồng thời chỉ định kích thước ảnh:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Bạn có thể thử các công cụ **chuyển đổi PowerPoint sang PNG** miễn phí của Aspose — [PPTX to PNG](https://products.aspose.app/slides/vi/conversion/pptx-to-png) và [PPT to PNG](https://products.aspose.app/slides/vi/conversion/ppt-to-png). Chúng cung cấp một triển khai trực tiếp của quy trình được mô tả trên trang này.
{{% /alert %}}

## **FAQ**

**Làm thế nào để xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc hình ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/python-net/create-shape-thumbnails/); bạn có thể render một hình dạng thành ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có, nhưng [không chia sẻ](/slides/vi/python-net/multithreading/) một instance của bản thuyết trình duy nhất giữa các luồng. Hãy sử dụng một instance riêng cho mỗi luồng hoặc tiến trình.

**Các giới hạn của phiên bản dùng thử khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/python-net/licensing/) cho đến khi có giấy phép.