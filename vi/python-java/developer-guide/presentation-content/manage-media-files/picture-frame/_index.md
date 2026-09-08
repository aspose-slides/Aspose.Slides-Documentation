---
title: Quản lý Khung Hình trong Bản Trình Bày Sử dụng Python
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/python-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình ảnh raster
- SVG image
- cắt hình ảnh
- xóa vùng đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khía cạnh
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong bản trình bày với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Khung hình là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation] sở hữu các tài nguyên hình ảnh được nhúng thông qua [ImageCollection] của nó, trong khi một [PictureFrame] kiểm soát vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các thiết lập cấp khung khác.

Sự phân tách này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại [PPImage] trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung hình.

Các khung hình có thể chứa hình ảnh raster như PNG hoặc JPEG và hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo một khung hình bằng [ShapeCollection.addPictureFrame]. Hình ảnh trở thành một phần của gói bản trình bày, vì vậy bản trình bày vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình ảnh JPEG, tạo khung với kích thước gốc của hình ảnh và áp dụng định dạng đường viền cũng như xoay:

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

Khung hình kiểm soát hình học hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame] cung cấp khả năng tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth] và [setRelativeScaleHeight]. Giá trị `1.0` tương đương với 100% kích thước hình ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần duy trì mối quan hệ với kích thước nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không tái mẫu hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu trữ dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Một hình ảnh liên kết lưu trữ vị trí bên ngoài thông qua phương thức [Picture.setLinkPathLong] thay vì nhúng dữ liệu hình ảnh cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được đối với ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày cần gửi qua email, lưu trữ hoặc hiển thị trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung hình và trỏ nó tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng sử dụng chúng chỉ để thay thế nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường kém hữu ích hơn so với một bản trình bày tự chứa lớn hơn.

## **Trích xuất Hình ảnh từ Khung Hình**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, hãy kiểm tra xem một hình dạng thực sự là [PictureFrame] và nó có chứa hình ảnh nhúng hay không. Các khung hình liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại làm việc trực tiếp với hình ảnh raster và không cần wrapper Java cũ. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu hình ảnh raster chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình bày thay vì một tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

### **Trích xuất Hình ảnh SVG**

Đối với ảnh SVG, [PPImage] cung cấp một đối tượng [SvgImage]. Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo toàn nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide thành PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [SvgImage.getSvgData] khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần nào của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat] là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung hình một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng đảo ngược, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[PictureFillFormat.deletePictureCroppedAreas] loại bỏ dữ liệu hình ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình bày được lưu, các pixel đã bị xóa không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình bày. Nếu hình ảnh gốc cũng được các khung hình khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa vùng đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này raster hoá kết quả đã cắt thành PNG.

## **Nén Hình ảnh Raster**

[PictureFillFormat.compressImage] giảm độ phân giải hình ảnh raster tương ứng với kích thước hiển thị của ảnh. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `True` khi ảnh đã được thay đổi kích thước hoặc cắt và `False` khi không có thay đổi nào cần thiết.

Sử dụng một giá trị [PicturesCompression] đã định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị đã định sẵn khi cần mục tiêu cụ thể.

Nén được dự định cho hình ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh sẽ thực sự được xem hoặc xuất thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Hình ảnh**

Đối với một quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, mờ, hiệu ứng alpha, chuỗi đặt thứ tự, kiểm tra, loại bỏ và xác minh vòng lặp, xem [Image Transform Effects](/slides/vi/python-java/image-transform-effects/).

## **Khóa Hình học Khung Hình**

Cài đặt [PictureFrameLock] kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung hình. Ví dụ, [setAspectRatioLocked] bảo toàn tỉ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung hình. Nó không buộc hình ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn theo cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [PictureFillFormat] xác định hình chữ nhật lấp đầy tương đối với khung hình. Phần trăm dương tạo ra một khoảng vào từ cạnh, trong khi phần trăm âm tạo ra một khoảng ra.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dãn vào.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các đánh đổi chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng khung hình được tách rời:

- **Hình ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài vẫn phải khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng đổi lại độ phân giải nguồn. Nó nên được áp dụng sau khi đã biết kích thước thực tế trên slide.
- **Hình ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng tài nguyên [PPImage] hiện có khi có thể thay vì tải lại cùng một tệp nhiều lần trong quy trình làm việc.

Đối với các bản trình bày lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa khung hình và tài nguyên hình ảnh là gì?**

[PPImage] đại diện cho một tài nguyên hình ảnh liên kết với bản trình bày. [PictureFrame] là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tệp ảnh ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì đáng tin cậy.

**Cắt có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn phần của ảnh nguồn nhưng giữ lại pixel bên dưới. Sử dụng [PictureFillFormat.deletePictureCroppedAreas] hoặc nén ảnh với việc loại bỏ vùng đã cắt khi những pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc loại bỏ các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ bản gốc ngoài bản trình bày nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Cần xử lý hình ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage] nhúng có thể được trích xuất trực tiếp. Rendering slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh cast không an toàn khi đọc các slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên đặc thù cho picture frame. Kiểm tra `isinstance` đối với [PictureFrame] tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa picture frame.