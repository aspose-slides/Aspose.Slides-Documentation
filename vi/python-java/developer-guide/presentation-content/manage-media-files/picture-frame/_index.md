---
title: Quản lý khung ảnh trong bài thuyết trình bằng Python
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/python-java/picture-frame/
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
- xóa các vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bài thuyết trình với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Khung hình ảnh là một hình dạng trên slide dùng để hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) sở hữu các tài nguyên ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) trả về, và sử dụng tài nguyên ảnh đó khi tạo các khung hình ảnh.

Khung hình ảnh có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu tới ảnh được liên kết thay vì lưu trữ dữ liệu ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất khẩu, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Ảnh Nhúng**

Đối với ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo một khung hình ảnh bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addPictureFrame). Ảnh sẽ trở thành một phần của gói bản trình chiếu, nên bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ dưới đây thêm một ảnh JPEG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền cũng như xoay:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Khung hình ảnh điều khiển hình học hiển thị; việc thay đổi kích thước khung không làm thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) cung cấp khả năng điều chỉnh tỷ lệ rộng và cao tương đối cho khung qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Giá trị `1.0` tương đương với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tỷ lệ tương đối thay đổi các cài đặt tỷ lệ của khung; nó không tái mẫu hoặc nén ảnh nhúng.

## **Ảnh Nhúng và Ảnh Liên kết**

Ảnh nhúng lưu trữ dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di động và việc render dự đoán được. Ảnh liên kết lưu trữ vị trí bên ngoài thông qua phương thức [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#setLinkPathLong) thay vì nhúng dữ liệu ảnh theo cách thông thường.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải luôn khả dụng đối với ứng dụng mở hoặc render bản trình chiếu. Nếu đường dẫn thay đổi, tệp được di chuyển, hoặc tài nguyên không có, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu phải được gửi email, lưu trữ, hoặc render trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên kết**

Ví dụ dưới đây tạo một khung ảnh và trỏ nó tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; việc liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường ít hữu ích hơn một bản trình chiếu tự chứa lớn hơn.

## **Trích xuất Ảnh từ Khung Hình ảnh**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, kiểm tra xem hình dạng thực sự là một [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) và nó có chứa ảnh nhúng không. Các khung ảnh liên kết có thể không chứa byte ảnh có thể được trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại làm việc trực tiếp với ảnh raster và không yêu cầu lớp bọc ảnh Java cũ. Ví dụ dưới đây tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Lưu ảnh raster sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần byte đã mã hóa được lưu trong bản trình chiếu thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh thay vì.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector trong bản trình chiếu. Các xuất khẩu raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất khẩu slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất ra không nên được xem như một bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/#getSvgData) khi cần tài nguyên vector gốc.

## **Cắt Ảnh**

Cắt ảnh thay đổi phần nào của ảnh sẽ hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/) là tỷ lệ phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi khu vực hiển thị.

Ví dụ dưới đây tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng đảo ngược, các khu vực đã cắt có thể bị loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) loại bỏ dữ liệu ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên ảnh mới. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã bị xóa không còn có thể phục hồi cho thao tác “uncrop” sau này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phương pháp này có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#compressImage) giảm độ phân giải ảnh raster tương ứng với kích thước mà ảnh được hiển thị. Nó cũng có thể loại bỏ các khu vực đã cắt trong cùng một thao tác. Phương pháp trả về `True` khi ảnh đã được thay đổi kích thước hoặc cắt và `False` khi không cần thay đổi nào.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturescompression/) được định trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Một giá trị DPI dương tùy chỉnh có thể được truyền vào thay vì giá trị định trước khi cần mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các khu vực đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất khẩu thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu Ứng Biến Đổi Ảnh**

Đối với quy trình đầy đủ bao gồm chỉnh sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác thực vòng quanh, xem [Image Transform Effects](/slides/vi/python-java/image-transform-effects/).

## **Khóa Hình Học Khung Ảnh**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframelock/) điều khiển các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) giữ tỉ lệ hình dạng khi nó được thay đổi kích thước.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỉ lệ.

## **Điều Chỉnh Giá Trị StretchOffset**

Khi chế độ lấp đầy ảnh là kéo dài, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Tỷ lệ phần trăm dương tạo một lề vào từ cạnh, trong khi tỷ lệ phần trăm âm tạo một lề ra ngoài.

Điều này khác với việc cắt. Giá trị cắt chọn phần nào của ảnh nguồn sẽ hiển thị; offset kéo dài thay đổi hình chữ nhật mà ảnh lấp đầy sẽ được kéo dài vào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sử dụng stretch offsets để đặt vị trí lấp đầy. Dùng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu Trữ, Kích Thước Tệp và Các Xem Xét Khi Xuất**

Các đánh đổi chính dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung ảnh được xem xét riêng biệt:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng ảnh raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài phải vẫn khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng nó đổi chác độ phân giải nguồn. Nên áp dụng sau khi đã biết kích thước thực tế trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector gốc. Các xuất khẩu slide dạng raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình bản trình chiếu.

Đối với các bản trình chiếu lớn, tối ưu hoá ảnh thường hiệu quả nhất khi được thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu Hỏi Thường Gặp**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

[PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) đại diện cho một tài nguyên ảnh gắn với bản trình chiếu. [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu cần di động, lưu trữ, hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc để ảnh ở ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn một phần ảnh nguồn nhưng giữ lại các pixel bên dưới. Sử dụng [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) hoặc nén ảnh với việc loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster đã lưu, và việc loại bỏ các khu vực đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) được nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh lỗi ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Kiểm tra `isinstance` đối với [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) tránh các ép kiểu không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.