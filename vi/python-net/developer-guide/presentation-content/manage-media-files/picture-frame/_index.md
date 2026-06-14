---
title: Thêm Khung Ảnh vào Bản Trình Bày với Python
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/python-net/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung ảnh
- thuộc tính khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Thêm khung ảnh vào các bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho Python qua .NET. Tối ưu quy trình làm việc và cải thiện thiết kế slide."
---
## **Giới thiệu**

Khung ảnh trong Aspose.Slides for Python cho phép bạn đặt và quản lý hình ảnh raster và vector như các hình dạng slide gốc. Bạn có thể chèn ảnh từ tệp hoặc luồng, định vị và thay đổi kích thước chúng với tọa độ chính xác, áp dụng quay, thiết lập độ trong suốt và điều khiển thứ tự z cùng với các hình dạng khác. API cũng hỗ trợ cắt, duy trì tỷ lệ khung hình, đặt viền và hiệu ứng, và thay thế hình ảnh nền mà không cần xây dựng lại bố cục. Vì khung ảnh hoạt động như các hình dạng thông thường, bạn có thể thêm hoạt ảnh, liên kết siêu văn bản và văn bản thay thế, giúp dễ dàng tạo các bản trình bày giàu hình ảnh và có khả năng truy cập.

## **Tạo khung ảnh**

Phần này trình bày cách chèn một hình ảnh vào slide bằng cách tạo một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) với Aspose.Slides for Python. Bạn sẽ học cách tải hình ảnh, đặt nó chính xác trên slide và điều khiển kích thước và định dạng của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy một slide theo chỉ mục của nó.
3. Tạo một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) bằng cách thêm hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/) của bản trình bày. Hình ảnh này sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của khung.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) với kích thước đó bằng phương pháp [add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) .
6. Lưu bản trình bày dưới dạng tệp PPTX.

Mã Python sau đây cho thấy cách tạo một khung ảnh:

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm hình ảnh vào bản trình bày.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Thêm một khung ảnh có kích thước bằng hình ảnh.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Lưu bản trình bày dưới dạng PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Khung ảnh cho phép bạn nhanh chóng tạo các slide trình bày từ hình ảnh. Khi kết hợp khung ảnh với các tùy chọn lưu của Aspose.Slides, bạn có thể kiểm soát các thao tác I/O để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể muốn xem các trang sau: convert [image to JPG](https://products.aspose.com/slides/vi/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/vi/python-net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/vi/python-net/conversion/png-to-svg/); convert [SVG to PNG](https://products.aspose.com/slides/vi/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Tạo khung ảnh với tỷ lệ tương đối**

Phần này minh họa cách đặt một hình ảnh có kích thước cố định, sau đó áp dụng tỷ lệ phần trăm độc lập cho chiều rộng và chiều cao của nó. Vì các phần trăm có thể khác nhau, tỷ lệ khung hình có thể thay đổi. Việc thay đổi kích thước được thực hiện tương đối so với kích thước gốc của hình ảnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy một slide theo chỉ mục của nó.
3. Tạo một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) bằng cách thêm hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/) .
4. Thêm một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) vào slide.
5. Đặt chiều rộng và chiều cao tương đối của khung ảnh.
6. Lưu bản trình bày dưới dạng tệp PPTX.

Mã Python sau đây cho thấy cách tạo một khung ảnh với tỷ lệ mở rộng tương đối:

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Thêm một khung ảnh vào slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Đặt tỷ lệ mở rộng chiều rộng và chiều cao tương đối.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Lưu bản trình bày.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Trích xuất hình ảnh raster từ khung ảnh**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu "sample.pptx" và lưu dưới định dạng PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Trích xuất hình ảnh SVG từ khung ảnh**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/), Aspose.Slides for Python qua .NET cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định mỗi [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/), kiểm tra xem [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) nền có chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Ví dụ mã sau đây minh họa cách trích xuất hình ảnh SVG từ một khung ảnh:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Lấy độ trong suốt của hình ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Mã Python này minh họa thao tác:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Tất cả các hiệu ứng áp dụng cho hình ảnh có thể được tìm thấy trong [aspose.slides.effects](https://reference.aspose.com/slides/vi/python-net/aspose.slides.effects/) .
{{% /alert %}}

## **Định dạng khung ảnh**

Aspose.Slides cung cấp nhiều tùy chọn định dạng mà bạn có thể áp dụng cho một khung ảnh. Với những tùy chọn này, bạn có thể điều chỉnh khung ảnh để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy một slide theo chỉ mục của nó.
3. Tạo một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) bằng cách thêm hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/) . Hình ảnh này sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của khung.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) với kích thước đó bằng phương pháp [add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/) .
6. Đặt màu viền của khung ảnh.
7. Đặt độ rộng viền của khung ảnh.
8. Xoay khung ảnh bằng cách cung cấp giá trị dương (theo chiều kim đồng hồ) hoặc giá trị âm (ngược chiều kim đồng hồ).
9. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Mã Python sau đây minh họa quá trình định dạng khung ảnh:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation để đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Thêm một khung ảnh có kích thước bằng hình ảnh.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Áp dụng định dạng cho khung ảnh.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Lưu bản trình bày dưới dạng PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose đã phát triển một công cụ tạo ảnh ghép miễn phí [Collage Maker](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [merge JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG images, hoặc [create photo grids](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này.
{{% /alert %}}

## **Thêm hình ảnh dưới dạng liên kết**

Để giữ kích thước tệp bản trình bày nhỏ, bạn có thể thêm hình ảnh hoặc video dưới dạng liên kết thay vì nhúng các tệp trực tiếp vào bản trình chiếu. Mã Python sau đây cho thấy cách chèn một hình ảnh và một video vào một trình giữ chỗ:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Cắt hình ảnh**

Trong phần này, bạn sẽ học cách cắt vùng hiển thị của hình ảnh trong một khung ảnh mà không làm thay đổi tệp nguồn. Bạn cũng sẽ học phương pháp cơ bản để áp dụng các lề cắt nhằm tạo ra một bố cục sạch sẽ, tập trung trực tiếp trên slide.

Mã Python sau đây cho thấy cách cắt một hình ảnh trên slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Thêm một khung ảnh vào slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Cắt hình ảnh (giá trị phần trăm).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Lưu kết quả.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa các khu vực đã cắt của hình ảnh**

Nếu bạn muốn xóa các khu vực đã cắt của một hình ảnh trong khung, hãy sử dụng phương pháp [delete_picture_cropped_areas](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) . Phương pháp này trả về hình ảnh đã cắt, hoặc hình ảnh gốc nếu không cần cắt.

Mã Python sau đây minh họa thao tác:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Lấy PictureFrame từ slide đầu tiên.
    picture_frame = slides.shape[0]

    # Lấy PictureFrame từ slide đầu tiên.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Lưu kết quả.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Phương pháp [delete_picture_cropped_areas](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của bản trình bày. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) đã xử lý, điều này có thể giảm kích thước bản trình bày; nếu không, số lượng hình ảnh trong bản trình bày kết quả có thể tăng.

Trong quá trình cắt, phương pháp này chuyển đổi các tệp metafile WMF/EMF thành hình ảnh PNG raster.
{{% /alert %}}

## **Nén hình ảnh**

Bạn có thể nén một hình ảnh trong bản trình bày bằng cách sử dụng phương pháp [PictureFillFormat.compress_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/compress_image/) . Phương pháp này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các khu vực đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format -> Compress Pictures -> Resolution** của PowerPoint.

Các ví dụ Python sau đây minh họa cách nén một hình ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các khu vực đã cắt:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các vùng đã cắt.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Kiểm tra kết quả của quá trình nén.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Hoặc sử dụng giá trị DPI tùy chỉnh trực tiếp:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Nén hình ảnh đến 150 DPI (độ phân giải web), xóa các vùng đã cắt.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Phương pháp này chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước của hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.
Nếu hình ảnh là tệp metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được duy trì hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao.
{{% /alert %}}

## **Khóa tỷ lệ khung hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ nguyên tỷ lệ khung hình sau khi thay đổi kích thước của hình ảnh, hãy đặt thuộc tính [aspect_ratio_locked](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) thành `True`.

Mã Python sau đây cho thấy cách khóa tỷ lệ khung hình của một hình dạng:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Khóa tỷ lệ khung hình khi thay đổi kích thước.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Cài đặt *Lock Aspect Ratio* này chỉ bảo toàn tỷ lệ khung hình của hình dạng, không phải tỷ lệ khung hình của hình ảnh bên trong.
{{% /alert %}}

## **Sử dụng thuộc tính Stretch Offset**

Bằng cách sử dụng các thuộc tính `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` và `stretch_offset_bottom` của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/) , bạn có thể định nghĩa một hình chữ nhật lấp đầy.

Khi kéo dãn được chỉ định cho một hình ảnh, hình chữ nhật nguồn sẽ được thu phóng để phù hợp với hình chữ nhật lấp đầy. Mỗi cạnh của hình chữ nhật lấp đầy được xác định bằng khoảng cách phần trăm so với cạnh tương ứng của hộp bao của hình dạng. Giá trị phần trăm dương chỉ ra một lề trong, trong khi giá trị phần trăm âm chỉ ra một lề ngoài.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến một slide theo chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật.
4. Đặt loại lấp đầy cho hình dạng.
5. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
6. Tải một hình ảnh.
7. Gán hình ảnh để lấp đầy hình dạng.
8. Xác định các offset của hình ảnh từ các cạnh tương ứng của hộp bao của hình dạng.
9. Lưu bản trình bày dưới dạng tệp PPTX.

Mã Python sau đây minh họa cách sử dụng các thuộc tính Stretch Offset:

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một AutoShape hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Đặt loại tô màu cho hình dạng.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Đặt chế độ tô ảnh cho hình dạng.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Tải hình ảnh và thêm nó vào bản trình bày.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Gán hình ảnh để lấp đầy hình dạng.
    shape.fill_format.picture_fill_format.picture.image = image

    # Xác định khoảng cách dịch chuyển của hình ảnh từ các cạnh tương ứng của hộp giới hạn của hình dạng.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Lưu tệp PPTX vào đĩa.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép bạn nhanh chóng tạo bản trình bày từ hình ảnh.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Làm sao tôi có thể biết những định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) . Danh sách các định dạng được hỗ trợ thường trùng lặp với khả năng của engine chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu suất của PPTX?**

Nhúng các hình ảnh lớn làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình bày nhưng đòi hỏi các tệp bên ngoài phải luôn khả dụng. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa một đối tượng hình ảnh tránh việc di chuyển/đổi kích thước nhầm?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/picture_frame_lock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá việc di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài bảo vệ](/slides/vi/python-net/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại hình dạng, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) .

**Độ trung thực vector SVG có được duy trì khi xuất bản trình bày sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [exporting to PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/) hoặc [raster formats](/slides/vi/python-net/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào thiết lập xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.