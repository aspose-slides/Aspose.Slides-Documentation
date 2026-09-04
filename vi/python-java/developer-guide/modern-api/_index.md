---
title: Nâng cao Xử lý Hình ảnh với API Hiện đại trong Python
linktitle: API Hiện đại
type: docs
weight: 237
url: /vi/python-java/modern-api/
keywords:
- API hiện đại
- vẽ
- hình thu nhỏ slide
- slide thành ảnh
- hình thu nhỏ hình dạng
- hình dạng thành ảnh
- hình thu nhỏ bản trình chiếu
- bản trình chiếu thành ảnh
- thêm ảnh
- thêm hình ảnh
- Python
- Java
- Aspose.Slides
description: "Hiện đại hoá xử lý hình ảnh trong Python qua Java: render slide và shape, thêm hình ảnh, và di chuyển các lời gọi xử lý ảnh đã lỗi thời sang API Hiện đại của Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via Java truy cập thư viện Java thông qua JPype. API xử lý ảnh kế thừa của nó đã sử dụng [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) và [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) từ `java.awt`.

Thư viện Java đã ngừng hỗ trợ các API xử lý ảnh này bắt đầu từ phiên bản 24.4. API Hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) để tải, render và lưu ảnh. Hãy sử dụng nó cho mã Python mới và khi di chuyển các quy trình xử lý ảnh hiện có.

{{% alert color="info" title="Note" %}}
Các tên phương thức cũ dưới đây chỉ dùng làm tham chiếu di chuyển. Chúng không còn có trong các phiên bản hiện tại. Các ví dụ thực thi sử dụng API Hiện đại.
{{% /alert %}}

## **API Hiện đại**

Các kiểu xử lý ảnh chính là:

- [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) — đại diện cho ảnh raster hoặc vector.
- [ImageFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/) — cung cấp các hằng số định dạng file ảnh.
- [Images](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/) — tạo ảnh, ví dụ với [Images.fromFile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/#fromFile).

Sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) hoặc [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) để render một slide hoặc shape. Sử dụng [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) với các tùy chọn render để render nhiều slide. Phương thức không có đối số trả về bộ sưu tập ảnh của bản trình chiếu.

Tải ảnh bằng [Images.fromFile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/#fromFile), thêm nó bằng [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage), hoặc cập nhật ảnh của bản trình chiếu hiện có bằng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage). Cả hai thao tác bộ sưu tập ảnh đều chấp nhận [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/).

Giải phóng mỗi ảnh bạn tải hoặc render bằng cách gọi phương thức `dispose` của nó trong một khối `finally`. Giải phóng bản trình chiếu bằng [Presentation.dispose](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#dispose).

### **Chuẩn bị môi trường Python**

Cài đặt các gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi chạy JVM, sau đó nhập API sau khi JVM đang chạy. Các ví dụ để JVM chạy liên tục để có thể tái sử dụng. Xem [Limitations and API Differences](/slides/vi/python-java/limitations-and-api-differences/#import-the-library) để biết hướng dẫn về vòng đời notebook và JVM.

Các ví dụ mở `pres.pptx` yêu cầu có một bản trình chiếu trong thư mục làm việc. Các ví dụ tải `image.png` yêu cầu một tệp ảnh tồn tại.

### **Tải hình ảnh và Render một Slide**

Ví dụ này thêm một hình ảnh vào slide đầu tiên và lưu slide dưới dạng ảnh JPEG. [IImage.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/#save) ghi ảnh đã render ở định dạng được chỉ định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Thay thế mã cũ bằng API Hiện đại**

Thay thế các lời gọi thumbnail kế thừa bằng các phương thức trả về [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/), sau đó lưu kết quả bằng [IImage.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/#save). Điều này loại bỏ nhu cầu truyền ảnh đã render cho [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Render một Slide với Kích thước Được chỉ định**

Thay thế lời gọi kế thừa `slide.getThumbnail(image_size)` bằng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) sử dụng cùng kích thước ảnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Lấy Thumbnail của Slide**

Thay thế lời gọi kế thừa `slide.getThumbnail()` bằng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) không có đối số.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Lấy Thumbnail của Shape**

Thay thế lời gọi kế thừa `shape.getThumbnail()` bằng [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage). Kiểm tra rằng slide chứa shape trước khi truy cập.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Lấy Thumbnail của Presentation**

Thay thế lời gọi kế thừa `presentation.getThumbnails(options, image_size)` bằng [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages). Sử dụng [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/) để cấu hình render.

Duyệt trực tiếp mảng trả về bằng `enumerate` của Python. Giải phóng mọi ảnh trả về trong một khối `finally` để việc lưu thất bại không để lại các ảnh chưa giải phóng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Thêm Hình ảnh vào Presentation**

Thay thế việc tải qua [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) bằng [Images.fromFile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/#fromFile), sau đó truyền ảnh đã tạo cho [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage). Thêm hình ảnh vào slide và lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Các phương thức bị Deprecate và Thay thế trong API Hiện đại**

Các bảng sử dụng cú pháp gọi Python. Các tên trong cột legacy xác định API đã bị xóa; sử dụng các phương thức thay thế được liên kết. Các phương thức render ảnh hiện đại trả về đối tượng [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) thay vì ảnh Java buffered.

### **Presentation**

`Presentation.getImages` trả về một mảng các ảnh đã render khi được gọi với các tùy chọn render.

| Legacy call | Modern replacement |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

Ở đây, `slides` là một mảng Java `int[]` chứa các số slide bắt đầu từ 1; tạo nó bằng `jpype.JArray(jpype.JInt)([1, 3])` để chọn slide 1 và 3. `image_size` là một [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Legacy call | Modern replacement |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slide**

| Legacy call | Modern replacement |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, image_size)` | No direct replacement; render to an image instead |

Ở đây, `options` là [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/), và `tiff_options` là [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/).

### **Output**

| Legacy call | Modern replacement |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Legacy call | Modern replacement |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy call | Modern replacement |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getImage) |

Để thay thế nội dung của một ảnh trình chiếu hiện có, sử dụng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage) với một [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Legacy call | Modern replacement |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

Các đối số màu vẫn là các đối tượng Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

| Legacy call | Modern replacement |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returning [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/) |

## **Hỗ trợ API cho Graphics2D**

Các overload `renderToGraphics` kế thừa đã vẽ vào ngữ cảnh [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) do người gọi cung cấp. API Hiện đại không có thay thế trực tiếp để vẽ vào ngữ cảnh đó.

Sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) để render một slide hoặc [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) để render nhiều slide, sau đó lưu các ảnh trả về bằng [IImage.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/#save). Các ứng dụng kết hợp render slide với việc vẽ Java tùy chỉnh cần điều chỉnh bước tổng hợp.

## **FAQ**

**Tại sao API ảnh Java cũ bị thay thế?**

API Hiện đại chuyển việc tải, render và lưu ảnh sang [IImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/iimage/). Điều này cung cấp một abstraction ảnh chung thay vì phơi bày ảnh Java buffered hoặc ngữ cảnh đồ họa Java.

**Tôi vẫn cần Java và JPype không?**

Có. Aspose.Slides for Python via Java vẫn chạy trên JVM. API Hiện đại chỉ thay đổi các lời gọi xử lý ảnh, không thay đổi yêu cầu môi trường. Xem [System Requirements](/slides/vi/python-java/system-requirements/).

**Làm sao tôi giải phóng ảnh trong Python?**

Gọi `dispose` trên mỗi ảnh bạn tải hoặc render trong một khối `finally`. Nếu bạn render nhiều slide, giải phóng mọi ảnh trong mảng trả về. Giải phóng bản trình chiếu riêng biệt bằng [Presentation.dispose](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#dispose).

**Việc chuyển sang API Hiện đại có đảm bảo tạo thumbnail nhanh hơn không?**

Không có cải thiện hiệu suất nào được đảm bảo. Các thay thế hỗ trợ tùy chọn render, scaling và kích thước ảnh; hãy đo hiệu suất với bản trình chiếu và cài đặt xuất của bạn.

**Tại sao hàm lấy ảnh đôi khi trả về một bộ sưu tập?**

[Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) không có đối số trả về các ảnh nhúng trong bản trình chiếu. Các overload có tùy chọn render trả về các ảnh slide đã render.