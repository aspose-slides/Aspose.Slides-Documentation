---
title: Tạo Hình Thu Nhỏ cho Các Hình Dạng trong Bài Trình chiếu bằng Python
linktitle: Hình Thu Nhỏ Hình Dạng
type: docs
weight: 70
url: /vi/python-net/create-shape-thumbnails/
keywords:
- hình thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- render hình dạng
- PowerPoint
- bài trình chiếu
- Python
- Aspose.Slides
description: "Tạo hình thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint và OpenDocument bằng Aspose.Slides for Python via .NET – dễ dàng tạo và xuất hình thu nhỏ cho bài trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET được sử dụng để tạo các tệp trình chiếu trong đó mỗi trang là một slide. Bạn có thể xem các slide này trong Microsoft PowerPoint bằng cách mở tệp trình chiếu. Tuy nhiên, các nhà phát triển đôi khi có thể cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong các trường hợp như vậy, Aspose.Slides có thể tạo ra các hình ảnh thumbnail cho các hình dạng trên slide. Bài viết này giải thích cách sử dụng tính năng này.

## **Tạo Thumbnail Hình Dạng Từ Slide**

Khi bạn cần bản xem trước của một đối tượng cụ thể thay vì toàn bộ slide, bạn có thể tạo thumbnail cho một hình dạng riêng lẻ. Aspose.Slides cho phép bạn xuất bất kỳ hình dạng nào ra hình ảnh, giúp dễ dàng tạo các bản xem trước nhẹ, biểu tượng hoặc tài sản cho quá trình xử lý tiếp theo.

Để tạo thumbnail từ bất kỳ hình dạng nào:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng ID hoặc chỉ mục của nó.
1. Lấy tham chiếu tới một hình dạng trên slide đó.
1. Kết xuất hình ảnh thumbnail của hình dạng.
1. Lưu hình ảnh thumbnail ở định dạng mong muốn.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tạo một hình ảnh với tỷ lệ mặc định.
    with shape.get_image() as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Tạo Thumbnail Với Hệ Số Thu Phóng Tùy Chỉnh**

Phần này cho thấy cách tạo thumbnail hình dạng với hệ số thu phóng do người dùng xác định trong Aspose.Slides. Bằng cách kiểm soát tỷ lệ, bạn có thể tinh chỉnh kích thước thumbnail để phù hợp với bản xem trước, xuất dữ liệu hoặc màn hình có DPI cao.

Để tạo thumbnail cho bất kỳ hình dạng nào trên một slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy một slide bằng ID hoặc chỉ mục của nó.
1. Lấy hình dạng mục tiêu trên slide đó.
1. Kết xuất hình ảnh thumbnail của hình dạng với tỷ lệ đã chỉ định.
1. Lưu hình ảnh thumbnail ở định dạng mong muốn.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Khởi tạo lớp Presentation để mở tệp trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tạo một hình ảnh với tỷ lệ đã định nghĩa.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Tạo Thumbnail Sử Dụng Giới Hạn Hiển Thị Của Hình Dạng**

Phần này cho thấy cách tạo thumbnail trong giới hạn hiển thị của một hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Thumbnail được tạo sẽ bị giới hạn bởi kích thước slide.

Để tạo thumbnail cho bất kỳ hình dạng slide nào trong giới hạn hiển thị của nó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy một slide bằng ID hoặc chỉ mục của nó.
1. Lấy hình dạng mục tiêu trên slide đó.
1. Kết xuất hình ảnh thumbnail của hình dạng với giới hạn đã chỉ định.
1. Lưu hình ảnh thumbnail ở định dạng ảnh mong muốn.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Khởi tạo lớp Presentation để mở tệp trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Tạo một hình ảnh cho hình dạng dựa trên giới hạn hiển thị.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu thumbnail của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất dưới dạng SVG vectơ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác nhau giữa giới hạn SHAPE và APPEARANCE khi kết xuất thumbnail là gì?**

`SHAPE` sử dụng hình học của hình dạng; `APPEARANCE` tính đến [hiệu ứng trực quan](/slides/vi/python-net/shape-effect/) (bóng, hào quang, v.v.).

**Điều gì xảy ra nếu một hình dạng được đánh dấu là ẩn? Nó vẫn sẽ được kết xuất thành thumbnail không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được kết xuất; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Các hình dạng nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/)) đều có thể được lưu dưới dạng thumbnail hoặc dưới dạng SVG.

**Các phông chữ được cài đặt hệ thống có ảnh hưởng đến chất lượng thumbnail cho các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/python-net/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/python-net/font-substitution/)) để tránh các trường hợp thay thế không mong muốn và việc thay đổi bố cục văn bản.