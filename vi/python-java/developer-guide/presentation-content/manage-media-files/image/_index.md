---
title: Tối ưu hóa quản lý hình ảnh trong bản trình bày bằng Python
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/python-java/image/
keywords:
- thêm hình ảnh
- thêm hình
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung hình
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành shape
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cung cấp một số cách làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ hình ảnh trong bản trình bày, hiển thị nó trong một khung hình, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh chia sẻ, hoặc chuyển đổi nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào các tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình bày. Đối với việc cắt, trong suốt, hiệu ứng, kéo dài và các định dạng khác được áp dụng cho một khung hình cá nhân, xem [Khung Hình](/slides/vi/python-java/picture-frame/).

## **Hiểu Mô Hình Hình Ảnh**

Các khái niệm API sau đây có liên quan chặt chẽ nhưng không thay thế cho nhau:

- The [presentation image collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/) stores image resources used by the presentation. Use [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage) to add image data and obtain a [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) resource.
- A [picture frame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) is a shape that displays an image on a slide, layout, or master. Use [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addPictureFrame) to place an image resource on a slide.
- A slide background uses an image as part of the slide fill rather than as a shape. It therefore does not behave like a picture frame.
- [PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage) replaces an image resource. If several presentation elements use that resource, they all use the replacement.
- Converting an SVG to shapes creates editable slide shapes. After conversion, the content is no longer managed as one picture resource.

A typical workflow is therefore: add image data to the image collection, receive a [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/), and then use that resource in one or more picture frames or fills.

## **Thêm Hình Ảnh Nhúng**

Để chèn một hình ảnh cục bộ, tải tệp, thêm nó vào bộ sưu tập hình ảnh, và tạo một khung hình sử dụng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) đã trả về.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hình ảnh được thêm theo cách này được nhúng trong bản trình bày, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm Hình Ảnh Từ Web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình bày, và sử dụng tài nguyên hình ảnh đã trả về tương tự như hình ảnh cục bộ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong các ứng dụng chạy lâu dài, hãy tái sử dụng một client HTTP hoặc chiến lược quản lý kết nối phù hợp với ứng dụng thay vì liên tục tạo cơ sở hạ tầng mạng không cần thiết. Ngoài ra, hãy xác thực URL từ xa, kích thước phản hồi và loại nội dung khi nguồn không đáng tin cậy.

## **Tái Sử Dụng Hình Ảnh Trên Nhiều Slide**

Nếu cùng một hình ảnh cần được sử dụng nhiều lần, hãy thêm nó vào bản trình bày một lần và tái sử dụng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) đã trả về khi tạo các khung hình bổ sung. Điều này tránh việc tải lại cùng dữ liệu nguồn và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung hình trên một [bố cục slide](/slides/vi/python-java/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử Dụng Hình Ảnh làm Nền Slide**

Một hình ảnh nền được gán cho phần fill của slide; nó không được thêm như một shape dạng khung hình. Điều này hữu ích khi hình ảnh cần bao phủ toàn bộ nền slide và không nên được thao tác giống như một đối tượng slide bình thường.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, xem [Nền Bản Trình Bày](/slides/vi/python-java/presentation-background/).

## **Hình Ảnh Nhúng và Hình Ảnh Liên Kết**

Hình ảnh nhúng và hình ảnh liên kết có các thỏa hiệp về tính di động và kích thước tệp khác nhau:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu bên trong bản trình bày. Bản trình bày là tự chứa, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình bày lưu một đường dẫn hoặc URL tới một hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình bày, nhưng tài nguyên bên ngoài phải vẫn khả dụng khi bản trình bày được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài qua [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#setLinkPathLong) thay vì nhúng dữ liệu hình ảnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể tin cậy truy cập tài nguyên bên ngoài. Đối với các bản trình bày phải hoạt động offline hoặc được di chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với Hình Ảnh SVG**

SVG là định dạng vector, vì vậy nó có thể hữu ích cho các biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như ảnh raster. Aspose.Slides hỗ trợ SVG cả như một tài nguyên hình ảnh và như nguồn cho các shape slide có thể chỉnh sửa.

### **Thêm SVG làm Hình Ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh, và đặt tài nguyên hình ảnh kết quả vào một khung hình.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tệp SVG với Tài Nguyên Bên Ngoài**

Một SVG có thể tham chiếu đến các hình ảnh, stylesheet hoặc phông chữ bên ngoài. Trong các trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) cung cấp các constructor nhận một [ExternalResourceResolver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/externalresourceresolver/) và một URI cơ sở. Resolver có thể ánh xạ một URI tương đối tới một URI tuyệt đối được phép và trả về một stream cho tài nguyên được yêu cầu.

Resolver làm cho các tài nguyên bên ngoài khả dụng trong khi Aspose.Slides xử lý SVG, nhưng không ghi lại lại SVG thành một tài liệu tự chứa. Nếu SVG phải vẫn có tính di động, hãy nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI dạng `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ nguồn không đáng tin cậy, hãy hạn chế các scheme, vị trí tệp và máy chủ mà resolver có thể truy cập. Các resolver mạng cũng nên áp dụng timeout, giới hạn kích thước phản hồi và kiểm tra nội dung.

### **Chuyển Đổi SVG thành Các Hình Dạng Có Thể Chỉnh Sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các shape slide có thể chỉnh sửa, tương tự như lệnh tương ứng trong PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng overload [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addGroupShape) chấp nhận một [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) để thực hiện chuyển đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sử dụng chuyển đổi SVG‑to‑shapes khi các yếu tố vector riêng lẻ cần được chỉnh sửa như các shape PowerPoint. Nếu SVG chỉ cần hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh việc tạo ra nhiều shape riêng biệt.

## **Thay Thế Tài Nguyên Hình Ảnh Đã Tồn Tại**

Sử dụng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage) khi bạn muốn thay thế một tài nguyên hình ảnh đã tồn tại. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu nhiều khung hình, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng đó. Nếu chỉ một khung hình cần thay đổi, hãy gán một hình ảnh khác cho khung hình đó thay vì thay thế tài nguyên chung.

[PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage) cũng cung cấp các overload chấp nhận một mảng byte hoặc một [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) khác.

## **Hướng Dẫn Quản Lý Hình Ảnh Thực Tiễn**

### **Kiểm Soát Kích Thước Bản Trình Bày**

Các ảnh raster lớn có thể làm cho bản trình bày trở nên không cần thiết lớn. Sử dụng các ảnh nguồn có kích thước phù hợp với kích thước hiển thị dự kiến, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải đầy đủ.

Đối với các ảnh raster đã được đặt trong khung hình, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#compressImage) có thể giảm dữ liệu hình ảnh theo độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung hình chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy hãy xem [Khung Hình](/slides/vi/python-java/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn Giữa Nội Dung Nhúng và Liên Kết**

Nhúng làm cho bản trình bày dễ di chuyển vì tất cả dữ liệu hình ảnh cần thiết đi cùng tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái Sử Dụng Nhãn Hiệu Chung**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, hãy sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình bày hơn là nội dung slide, hãy đặt nó trên một master hoặc layout để nó được thừa hưởng bởi các slide tương ứng.

### **Giữ Tài Nguyên SVG Có Thể Di Chuyển**

Một SVG tự chứa dễ di chuyển và render nhất quán hơn so với một SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành shape chỉ nên thực hiện khi các yếu tố vector riêng lẻ cần được chỉnh sửa.

### **Sử Dụng API Hình Ảnh Đa Nền Tảng Hiện Đại**

Đối với mã Python via Java mới, hãy sử dụng các đối tượng hình ảnh đa nền tảng của Aspose.Slides và API [Images](https://reference.aspose.com/slides/vi/python-java/aspose.slides/images/) thay vì API công cộng kế thừa dựa trên `java.awt.image.BufferedImage`. Xem [API Hiện Đại](/slides/vi/python-java/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần xem xét đặc biệt. Khi các định dạng này được truyền qua một đối tượng hình ảnh đa nền tảng, [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage) chuyển đổi metafile thành biểu diễn PNG raster trước khi chèn. Nếu việc bảo tồn dữ liệu metafile quan trọng, hãy sử dụng overload dựa trên stream của [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage). Tạo nội dung EMF từ bảng tính hoặc sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và khung hình là gì?**

Bộ sưu tập hình ảnh lưu các tài nguyên hình ảnh có thể tái sử dụng. Khung hình là một shape slide hiển thị một trong những tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#replaceImage). Đối với việc branding toàn bộ bản trình bày, việc đặt logo trên một master hoặc layout cũng có thể giảm việc lặp lại nội dung slide.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết sẽ không khả dụng. Hãy nhúng hình ảnh khi bản trình bày phải tự chứa.

**Một SVG được chèn có thể chỉnh sửa thành các shape PowerPoint không?**

Có. Chuyển đổi SVG bằng [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addGroupShape); nhóm kết quả chứa các shape slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm sao để giữ bản trình bày có nhiều hình ảnh luôn nhỏ gọn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh các nguồn raster không cần thiết lớn, nén các ảnh raster phù hợp khi cần, giữ branding lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài được chấp nhận.