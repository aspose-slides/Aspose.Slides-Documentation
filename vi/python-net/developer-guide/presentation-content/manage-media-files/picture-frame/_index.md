---
title: Quản lý khung hình trong bản trình chiếu với Python
linktitle: Khung hình
type: docs
weight: 10
url: /vi/python-net/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong bản trình chiếu với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Khung hình là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các thiết lập cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị hơn một lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại đối tượng PPImage trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung hình.

Khung hình có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu tới các ảnh liên kết thay vì lưu trữ byte ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng ảnh được nhúng**

Đối với ảnh được nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo một khung hình bằng cách gọi ShapeCollection.add_picture_frame. Ảnh sẽ trở thành một phần của gói bản trình chiếu, do đó bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền và xoay:

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

Khung hình điều khiển hình học được hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh được nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) cung cấp relative_scale_width và relative_scale_height cho khung. Giá trị `1.0` tương đương 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần giữ mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng bằng tay.

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

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không tái mẫu hoặc nén ảnh được nhúng.

## **Ảnh được nhúng và ảnh liên kết**

Ảnh được nhúng lưu trữ dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Ảnh liên kết lưu vị trí bên ngoài thông qua đường dẫn liên kết Picture thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu cần gửi qua email, lưu trữ, hoặc hiển thị trong môi trường cô lập, ảnh được nhúng thường đáng tin cậy hơn.

### **Thêm ảnh liên kết**

Ví dụ sau tạo một khung hình và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình media riêng và không được pha trộn trong ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài có mục đích. Không dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ có các phụ thuộc ảnh bị hỏng thường ít hữu ích hơn một bản trình chiếu lớn tự chứa.

## **Trích xuất ảnh từ khung hình**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, kiểm tra rằng một hình dạng thực sự là PictureFrame và nó chứa ảnh được nhúng. Các khung ảnh liên kết có thể không chứa byte ảnh có thể được trích xuất theo cùng cách.

### **Trích xuất ảnh raster**

API ảnh hiện đại sử dụng IImage trực tiếp. Ví dụ sau tìm ảnh raster được nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua IImage sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình chiếu thay vì một tệp raster đã chuyển đổi, hãy dùng thuộc tính PPImage.binary_data thay thế.

### **Trích xuất ảnh SVG**

Đối với ảnh SVG, PPImage cung cấp một đối tượng SvgImage. Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo lưu nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG bắt buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa được xuất không nên được coi là bản sao byte‑for‑byte của SVG được nhúng gốc; hãy sử dụng SvgImage.svg_data được nhúng khi cần tài nguyên vector gốc.

## **Cắt ảnh**

Cắt ảnh thay đổi phần nào của ảnh sẽ hiển thị bên trong khung. Các giá trị cắt trên PictureFillFormat là phần trăm của kích thước ảnh nguồn. Cắt ảnh không xóa ngay các pixel ẩn khỏi ảnh được nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung hình một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng khôi phục, các vùng đã cắt có thể được loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa dữ liệu ảnh đã cắt**

PictureFillFormat.delete_picture_cropped_areas xóa dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã xóa không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung hình khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén ảnh raster**

PictureFillFormat.compress_image giảm độ phân giải ảnh raster so với kích thước hiển thị của ảnh. Nó cũng có thể xóa các vùng đã cắt trong cùng một thao tác. Phương thức trả về `True` khi ảnh đã được thay đổi kích thước hoặc cắt và `False` khi không cần thay đổi.

Sử dụng giá trị PicturesCompression được định trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Giá trị DPI dương tùy chỉnh có thể được truyền thay cho giá trị enum khi yêu cầu mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các vùng đã xóa không thể phục hồi từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Kiểm tra hiệu ứng ảnh**

Hiệu ứng ảnh được lưu trên hình ảnh được khung sử dụng. Bộ sưu tập biến đổi ảnh có thể chứa các hiệu ứng như AlphaModulateFixed để điều chế độ trong suốt và Luminance để điều chỉnh độ sáng và độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ khung hình đầu tiên trên một slide:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

AlphaModulateFixed và Luminance thay đổi cách ảnh được render trong khung; chúng không ghi lại lại byte ảnh nhúng gốc.

## **Khóa hình học khung ảnh**

Các cài đặt PictureFrameLock kiểm soát những thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, thuộc tính aspect_ratio_locked giữ tỉ lệ của hình dạng khi nó được thay đổi kích thước.

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

Khóa này áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỉ lệ.

## **Điều chỉnh giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch-offset trên PictureFillFormat xác định hình chữ nhật lấp đầy tương đối với khung bao của khung ảnh. Phần trăm dương tạo khoảng inset từ cạnh, trong khi phần trăm âm tạo khoảng outset.

Điều này khác với cắt. Các giá trị crop chọn phần nào của ảnh nguồn sẽ hiển thị; stretch offsets thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dãn.

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

Sử dụng stretch offsets để đặt vị trí lấp đầy. Sử dụng các thuộc tính crop khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, kích thước tệp và cân nhắc khi xuất**

Các cân nhắc chính dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung ảnh được xem xét riêng biệt:

- **Ảnh được nhúng** làm cho bản trình chiếu tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng ảnh raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài vẫn khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt ảnh** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho tới khi các vùng đã cắt được xóa rõ ràng hoặc đã bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng đổi lại độ phân giải nguồn. Nó nên được áp dụng sau khi biết kích thước mong muốn trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo lưu vector quan trọng. Trích xuất SVG được nhúng trực tiếp khi bạn cần tài nguyên vector gốc. Các xuất slide raster luôn chuyển slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên PPImage hiện có khi có thể thay vì tải lại cùng tệp nhiều lần trong quy trình làm việc.

Đối với các bản trình chiếu lớn, tối ưu hoá ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp dựa trên kích thước hiển thị thực tế, chỉ xóa các pixel đã cắt khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

Một [PPImage] đại diện cho tài nguyên ảnh liên kết với bản trình chiếu. Một [PictureFrame] là một hình dạng trên slide hiển thị ảnh và lưu trữ các hình học và định dạng cấp khung như kích thước, xoay, giá trị crop, hiệu ứng và khóa.

**Tôi nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ, hoặc render mà không cần truy cập vào tài nguyên bên ngoài. Chỉ liên kết ảnh khi việc giữ các tệp ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước tệp PPTX không?**

Không phải tự nhiên. Cài đặt crop bình thường chỉ ẩn một phần ảnh nguồn nhưng vẫn giữ các pixel bên dưới. Sử dụng PictureFillFormat.delete_picture_cropped_areas hoặc nén ảnh với việc loại bỏ vùng đã cắt khi các pixel đó có thể được loại bỏ vĩnh viễn.

**Tôi có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster được lưu, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu sau này cần chỉnh sửa ở độ phân giải cao.

**Cách xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. SvgImage được nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh việc cast không an toàn khi đọc các slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của picture-frame. Sử dụng isinstance(shape, slides.PictureFrame) tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.