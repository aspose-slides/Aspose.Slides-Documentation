---
title: Tạo ảnh thu nhỏ cho các hình dạng trong bản trình chiếu bằng Python
linktitle: Ảnh thu nhỏ hình dạng
type: docs
weight: 70
url: /vi/python-net/create-shape-thumbnails/
keywords:
- ảnh thu nhỏ hình dạng
- hình ảnh hình dạng
- render hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo ảnh thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET – dễ dàng tạo và xuất ảnh thu nhỏ cho bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET được sử dụng để tạo các tệp trình chiếu, trong đó mỗi trang là một slide. Bạn có thể xem các slide này trong Microsoft PowerPoint bằng cách mở tệp trình chiếu. Tuy nhiên, đôi khi các nhà phát triển cần xem hình ảnh của các hình dạng riêng rẽ trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides có thể tạo ra các ảnh thu nhỏ cho các hình dạng trong slide. Bài viết này giải thích cách sử dụng tính năng này.

## **Tạo ảnh thu nhỏ hình dạng từ slide**

Khi bạn cần xem trước một đối tượng cụ thể thay vì toàn bộ slide, bạn có thể render một ảnh thu nhỏ cho một hình dạng riêng lẻ. Aspose.Slides cho phép bạn xuất bất kỳ hình dạng nào ra ảnh, giúp dễ dàng tạo các bản xem trước nhẹ, biểu tượng hoặc tài sản cho các quy trình xử lý tiếp theo.

Để tạo ảnh thu nhỏ từ bất kỳ hình dạng nào:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide bằng ID hoặc chỉ mục của nó.
3. Lấy tham chiếu tới một hình dạng trên slide đó.
4. Render ảnh thu nhỏ của hình dạng.
5. Lưu ảnh thu nhỏ ở định dạng mong muốn.

Ví dụ dưới đây tạo một ảnh thu nhỏ cho hình dạng.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp bản trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tạo một hình ảnh với tỷ lệ mặc định.
    with shape.get_image() as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Tạo ảnh thu nhỏ với hệ số phóng tỷ lệ tùy chỉnh**

Phần này trình bày cách tạo ảnh thu nhỏ cho hình dạng với hệ số phóng tỷ lệ do người dùng xác định trong Aspose.Slides. Bằng cách kiểm soát tỉ lệ, bạn có thể tinh chỉnh kích thước ảnh thu nhỏ để phù hợp với việc xem trước, xuất file hoặc màn hình có độ phân giải cao.

Để tạo ảnh thu nhỏ cho bất kỳ hình dạng nào trên một slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy một slide bằng ID hoặc chỉ mục của nó.
3. Lấy hình dạng mục tiêu trên slide đó.
4. Render ảnh thu nhỏ của hình dạng với tỉ lệ đã chỉ định.
5. Lưu ảnh thu nhỏ ở định dạng mong muốn.

Ví dụ dưới đây tạo một ảnh thu nhỏ với hệ số phóng tùy chỉnh.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Khởi tạo lớp Presentation để mở tệp bản trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tạo một hình ảnh với tỷ lệ đã định nghĩa.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Tạo ảnh thu nhỏ bằng giới hạn hiển thị của hình dạng**

Phần này mô tả cách tạo ảnh thu nhỏ trong phạm vi giới hạn hiển thị của một hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Ảnh thu nhỏ được tạo ra sẽ bị giới hạn bởi giới hạn của slide.

Để tạo ảnh thu nhỏ cho bất kỳ hình dạng nào trong slide trong phạm vi hiển thị của nó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy một slide bằng ID hoặc chỉ mục của nó.
3. Lấy hình dạng mục tiêu trên slide đó.
4. Render ảnh thu nhỏ của hình dạng với giới hạn đã chỉ định.
5. Lưu ảnh thu nhỏ ở định dạng ảnh mong muốn.

Ví dụ dưới đây tạo một ảnh thu nhỏ với giới hạn do người dùng xác định.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Khởi tạo lớp Presentation để mở tệp bản trình chiếu.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Tạo một hình ảnh hình dạng theo giới hạn hiển thị.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Lưu hình ảnh vào đĩa ở định dạng PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Lấy giới hạn trực quan thực tế của một hình dạng**

Các thuộc tính khung của một [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/)—`Shape.x`, `Shape.y`, `Shape.width` và `Shape.height`—mô tả hình chữ nhật được lưu trong mô hình trình chiếu. Nội dung thực tế được render có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật căn trục khác. Việc quay, viền, mũi tên, bố cục và tràn văn bản, geometry của SmartArt được tạo ra và các hiệu ứng render khác đều có thể thay đổi khu vực chiếm dụng.

Sử dụng [Shape.get_visual_bounds](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_visual_bounds/) để tính toán khu vực chiếm dụng mà không cần tạo ảnh. Phương thức trả về một hình chữ nhật dạng số thực trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ của nó có thể là số âm khi nội dung vượt ra ngoài nguồn gốc của slide.

Ví dụ sau lấy và so sánh khung và giới hạn trực quan:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Cùng một hình chữ nhật có thể được sử dụng để căn chỉnh các hình dạng gần đó theo cạnh `left`, `right`, `top` hoặc `bottom`; giữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Giới hạn trực quan đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, hình dạng đã quay và nhóm hình dạng, nơi khung lưu trữ có thể không phản ánh đầy đủ kết quả render.

Sử dụng [Shape.get_visual_bounds](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_visual_bounds/) khi bạn cần tọa độ cho bố cục hoặc xác thực và không cần bitmap. Sử dụng [Shape.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/) khi bạn cần render hình dạng. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` kích thước ảnh dựa trên giới hạn của hình dạng, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds.APPEARANCE` kích thước ảnh dựa trên hiển thị của hình dạng và giới hạn kết quả trong phạm vi slide. Ngược lại, `Shape.get_visual_bounds` chỉ trả về hình chữ nhật đã tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Các định dạng ảnh nào có thể được sử dụng khi lưu ảnh thu nhỏ của hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất ra dạng vector SVG](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác nhau giữa giới hạn SHAPE và APPEARANCE khi render ảnh thu nhỏ là gì?**

`SHAPE` sử dụng geometry của hình dạng; `APPEARANCE` tính đến [các hiệu ứng trực quan](/slides/vi/python-net/shape-effect/) (bóng, phát sáng, v.v.).

**Nếu một hình dạng được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn được render thành ảnh thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu mà không ngăn việc tạo ảnh của hình dạng.

**Các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/)) đều có thể được lưu thành ảnh thu nhỏ hoặc SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng ảnh thu nhỏ của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/python-net/custom-font/) (hoặc [cấu hình việc thay thế phông chữ](/slides/vi/python-net/font-substitution/)) để tránh việc fallback không mong muốn và thay đổi bố cục văn bản.