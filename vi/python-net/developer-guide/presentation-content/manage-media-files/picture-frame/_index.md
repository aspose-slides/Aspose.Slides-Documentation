---
title: Quản lý Khung Ảnh trong Bản Trình Chiếu bằng Python
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/python-net/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa các khu vực đã cắt
- nén ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) sở hữu các tài nguyên ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) kiểm soát vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) trả về và sử dụng tài nguyên hình ảnh đó khi tạo khung ảnh.

Khung ảnh có thể chứa các hình ảnh raster như PNG hoặc JPEG và các hình ảnh vector SVG. Chúng cũng có thể tham chiếu đến các hình ảnh được liên kết thay vì lưu trữ dữ liệu ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy việc quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu là cần thiết.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo một khung ảnh bằng [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_picture_frame/). Hình ảnh sẽ trở thành một phần của gói bản trình chiếu, do đó bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình ảnh JPEG, tạo khung ở kích thước gốc của ảnh, và áp dụng định dạng đường viền cùng việc xoay:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Khung ảnh kiểm soát hình học được hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) cung cấp [relative_scale_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/relative_scale_width/) và [relative_scale_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/relative_scale_height/) cho khung. Giá trị `1.0` tương đương với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình công việc cần giữ mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Tỷ lệ tương đối thay đổi cài đặt tỉ lệ của khung; nó không thực hiện lấy mẫu lại hoặc nén ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu trữ dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho tính di động và việc hiển thị dự đoán được. Một hình ảnh liên kết lưu trữ vị trí bên ngoài thông qua đường dẫn liên kết [Picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picture/) thay vì nhúng dữ liệu ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được đối với ứng dụng mở hoặc render bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi qua email, lưu trữ, hoặc render trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và trỏ nó tới tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; việc liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ ý. Đừng sử dụng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu lớn tự chứa.

## **Trích xuất Hình ảnh từ Khung Ảnh**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, kiểm tra xem hình dạng thực sự là một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) và rằng nó chứa một ảnh nhúng. Các khung ảnh liên kết có thể không chứa dữ liệu ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) trực tiếp. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Lưu qua [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) chuyển đổi ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần các byte đã mã hoá được lưu trong bản trình chiếu thay vì tệp raster đã chuyển đổi, hãy sử dụng thuộc tính [PPImage.binary_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/binary_data/) thay thế.

### **Trích xuất Hình ảnh SVG**

Đối với ảnh SVG, [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG bắt buộc phải render nội dung vector thành pixel. Xuất slide sang PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa đã xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng [SvgImage.svg_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/svg_data/) khi cần tài nguyên vector gốc.

## **Cắt Ảnh**

Cắt thay đổi phần ảnh nào hiển thị trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả dụng lại, các vùng đã cắt có thể được loại bỏ thực sự như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) loại bỏ dữ liệu ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu phá hủy: sau khi bản trình chiếu được lưu, các pixel đã xóa không còn khả dụng cho thao tác hủy cắt sau này.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này raster hoá kết quả đã cắt thành PNG.

## **Nén Hình ảnh Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/compress_image/) giảm độ phân giải ảnh raster so với kích thước mà ảnh được hiển thị. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `True` khi ảnh đã được thay đổi kích thước hoặc cắt và `False` khi không có thay đổi nào cần thiết.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/picturescompression/) định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Một giá trị DPI dương tùy chỉnh có thể được truyền vào thay cho giá trị enum khi cần mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm qua quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các khu vực đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Ảnh**

Đối với một quy trình đầy đủ bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác minh vòng lại, xem [Image Transform Effects](/slides/vi/python-net/image-transform-effects/).

## **Khóa Hình học Khung Ảnh**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframelock/) điều khiển các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, thuộc tính [aspect_ratio_locked](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) giữ tỷ lệ hình dạng khi nó được thay đổi kích thước.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được lấy mẫu lại hoặc thay đổi vĩnh viễn thành cùng tỷ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo ra một phần lùi vào từ cạnh, trong khi phần trăm âm tạo ra một phần mở rộng ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần ảnh nguồn nào được hiển thị; các offset stretch thay đổi hình chữ nhật mà phần ảnh lấp đầy được kéo dãn vào.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Sử dụng stretch offsets để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Lưu ý Khi Xuất**

Những cân nhắc chính dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung ảnh được xem xét riêng biệt:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các ảnh raster lớn làm tăng kích thước PPTX và nhu cầu bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài phải vẫn khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt ảnh** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho tới khi các khu vực đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng nó hy sinh độ phân giải nguồn. Nên áp dụng sau khi biết kích thước cuối cùng trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) hiện có khi có thể thay vì tải cùng tệp nhiều lần vào quy trình làm việc.

Đối với các bản trình chiếu lớn, tối ưu hóa ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **FAQ**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

Một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) đại diện cho tài nguyên ảnh liên kết với bản trình chiếu. Một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Tôi nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh bên ngoài PPTX là có chủ ý và các vị trí bên ngoài có thể được duy trì đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt thông thường ẩn một phần ảnh nguồn nhưng giữ các pixel bên dưới. Sử dụng [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) hoặc nén ảnh kèm loại bỏ vùng đã cắt khi có thể xóa các pixel đó vĩnh viễn.

**Tôi có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster đã lưu và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu cần chỉnh sửa độ phân giải cao sau này.

**Ảnh SVG nên được xử lý như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/svgimage/) nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Sử dụng `isinstance(shape, slides.PictureFrame)` tránh các ép kiểu không hợp lệ và cho phép code xử lý các slide không chứa khung ảnh.