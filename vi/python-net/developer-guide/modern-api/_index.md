---
title: Nâng cao xử lý hình ảnh với API Hiện Đại
linktitle: API Hiện Đại
type: docs
weight: 280
url: /vi/python-net/modern-api/
keywords:
- API hiện đại
- vẽ
- hình thu nhỏ slide
- slide thành ảnh
- hình thu nhỏ hình dạng
- hình dạng thành ảnh
- hình thu nhỏ bản trình chiếu
- bản trình chiếu sang ảnh
- thêm ảnh
- thêm hình
- Python
- Aspose.Slides
description: "Hiện đại hoá xử lý hình ảnh slide bằng cách thay thế các API ảnh đã lỗi thời bằng API Hiện Đại cho Python, cho việc tự động hoá PowerPoint và OpenDocument liền mạch."
---
## **Giới thiệu**

API công cộng Aspose.Slides cho Python hiện đang phụ thuộc vào các kiểu `aspose.pydrawing` sau:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Kể từ phiên bản 24.4, API công cộng này đã **bị lỗi thời** do [các thay đổi](https://releases.aspose.com/slides/vi/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) trong API công cộng Aspose.Slides cho Python.

Để loại bỏ `aspose.pydrawing` khỏi API công cộng, chúng tôi đã giới thiệu **API Hiện Đại**. Các phương thức sử dụng `aspose.pydrawing.Image` và `aspose.pydrawing.Bitmap` đã bị lỗi thời và nên được thay thế bằng các tương đương trong API Hiện Đại. Các phương thức sử dụng `aspose.pydrawing.Graphics` đã bị lỗi thời và không có thay thế trực tiếp trong API Hiện Đại.

Trong các phiên bản hiện tại, hãy coi API công cộng phụ thuộc vào `aspose.pydrawing` là cũ/được lỗi thời. Sử dụng API Hiện Đại cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **API Hiện Đại**

Các lớp và enum sau đã được thêm vào API công cộng:

- [aspose.slides.IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) - đại diện cho ảnh raster hoặc vector.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/) - đại diện cho định dạng file ảnh.
- [aspose.slides.Images](https://reference.aspose.com/slides/vi/python-net/aspose.slides/images/) - cung cấp các phương thức để tạo và làm việc với [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/).

Sử dụng `get_image` để render một slide hoặc shape duy nhất. Sử dụng `get_images` để render nhiều slide của bản trình chiếu. Sử dụng các phương thức của [Images](https://reference.aspose.com/slides/vi/python-net/aspose.slides/images/) để tải ảnh, `add_image` với [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) để thêm chúng vào bản trình chiếu, và `replace_image` với [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) để cập nhật ảnh hiện có trong bản trình chiếu.

Một kịch bản sử dụng điển hình cho API mới như sau:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Thay Thế Mã Cũ Bằng API Hiện Đại**

Để chuyển đổi dễ dàng hơn, lớp [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) mới phản chiếu các API riêng biệt của các lớp `aspose.pydrawing.Image` và `aspose.pydrawing.Bitmap`. Trong hầu hết các trường hợp, bạn chỉ cần thay thế các lời gọi tới các phương thức sử dụng `aspose.pydrawing` bằng các tương đương trong API Hiện Đại.

### **Lấy Thumbnail của Slide**

**API lỗi thời:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API Hiện Đại:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Lấy Thumbnail của Shape**

**API lỗi thời:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API Hiện Đại:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Lấy Thumbnail của Bản Trình Chiếu**

**API lỗi thời:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API Hiện Đại:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Thêm Ảnh Vào Bản Trình Chiếu**

**API lỗi thời:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API Hiện Đại:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Các Phương Thức và Thuộc Tính sẽ Bị Loại Bỏ và Thay Thế Bằng API Hiện Đại**

### **Lớp Presentation**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Không có thay thế trong API Hiện Đại|
|save(fname, format, options, response, show_inline)|Không có thay thế trong API Hiện Đại|
|print()|Không có thay thế trong API Hiện Đại|
|print(printer_settings)|Không có thay thế trong API Hiện Đại|
|print(printer_name)|Không có thay thế trong API Hiện Đại|
|print(printer_settings, pres_name)|Không có thay thế trong API Hiện Đại|

### **Lớp Slide**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Không có thay thế trong API Hiện Đại|
|render_to_graphics(options, graphics, scale_x, scale_y)|Không có thay thế trong API Hiện Đại|
|render_to_graphics(options, graphics, rendering_size)|Không có thay thế trong API Hiện Đại|

### **Lớp Shape**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Lớp ImageCollection**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Lớp PPImage**

|Chữ ký Phương thức/Tài sản|Chữ ký Phương thức/Tài sản Thay thế|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/image/)|

### **Lớp ImageWrapperFactory**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Lớp PatternFormat**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Lớp IPatternFormatEffectiveData**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Lớp Output**

|Chữ ký Phương thức|Chữ ký Phương thức Thay thế|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Hỗ Trợ API cho aspose.pydrawing.Graphics**

Các phương thức sử dụng `aspose.pydrawing.Graphics` đã bị lỗi thời và không có thay thế trực tiếp trong API Hiện Đại.

Sử dụng các phương thức render ảnh của API Hiện Đại thay vì API render tới `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **Câu Hỏi Thường Gặp**

**Tại sao `aspose.pydrawing.Graphics` bị loại bỏ?**

Hỗ trợ `aspose.pydrawing.Graphics` đã bị lỗi thời trong API công cộng để thống nhất công việc render và ảnh, loại bỏ các phụ thuộc nền tảng cụ thể, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/). Sử dụng `get_image` hoặc `get_images` thay vì render tới `aspose.pydrawing.Graphics`.

**Lợi ích thực tế của [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) so với `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap` là gì?**

[IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) hợp nhất việc làm việc với cả ảnh raster và vector, đơn giản hoá việc lưu vào các định dạng khác nhau qua [ImageFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/), giảm phụ thuộc vào pydrawing, và làm cho mã dễ di chuyển giữa các môi trường.

**API Hiện Đại có ảnh hưởng tới hiệu năng tạo thumbnail không?**

Việc chuyển từ `get_thumbnail` sang `get_image` không làm giảm hiệu năng: các phương thức mới cung cấp cùng khả năng tạo ảnh với các tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi ích hoặc giảm hiệu năng cụ thể phụ thuộc vào kịch bản, nhưng về chức năng các thay thế là tương đương.