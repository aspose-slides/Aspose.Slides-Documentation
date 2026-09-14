---
title: Quản lý nền bản trình chiếu bằng Python qua Java
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/python-java/presentation-background/
keywords:
- nền bản trình chiếu
- nền slide
- màu đồng nhất
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thiết lập nền động trong tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java, kèm các mẹo mã giúp nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đồng nhất, gradient và hình ảnh thường được sử dụng cho nền slide. Bạn có thể đặt nền cho một **slide thường** (một slide duy nhất) hoặc một **slide mẫu** (áp dụng cho nhiều slide cùng lúc).

![Nền PowerPoint](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho Slide thường**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho một slide cụ thể trong bản trình chiếu — ngay cả khi bản trình chiếu sử dụng slide mẫu. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getsolidfillcolor) trên [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python sau cho thấy cách đặt màu xanh đậm làm nền đồng nhất cho một slide thường:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

    # Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Đặt màu nền của slide thành màu xanh.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt nền màu đồng nhất cho Slide mẫu**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho slide mẫu trong bản trình chiếu. Slide mẫu hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu đồng nhất cho nền của slide mẫu, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/backgroundtype/) của slide mẫu (bằng cách sử dụng [getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getmasters)) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của nền slide mẫu thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getsolidfillcolor) để chỉ định màu nền đồng nhất.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python sau cho thấy cách đặt màu xanh lá cây làm nền đồng nhất cho một slide mẫu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Đặt màu nền cho slide mẫu thành màu xanh lá.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt nền Gradient cho Slide**

Gradient là một hiệu ứng đồ họa được tạo ra bởi sự thay đổi dần dần của màu sắc. Khi được sử dụng làm nền slide, gradient có thể làm cho bản trình chiếu trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getgradientformat) trên [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python sau cho thấy cách đặt màu gradient làm nền cho một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Áp dụng hiệu ứng gradient cho nền.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Thêm các màu gradient. Không có điểm dừng gradient, nền sẽ quay lại dải màu mặc định từ đen đến trắng.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt hình ảnh làm nền Slide**

Ngoài các nền đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn sử dụng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getpicturefillformat) trên [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python sau cho thấy cách đặt hình ảnh làm nền cho một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Đặt thuộc tính hình ảnh nền.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Tải hình ảnh.
    image = Images.fromFile("Tulips.jpg")
    # Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đoạn mã mẫu sau cho thấy cách đặt kiểu fill nền thành hình ảnh lát và chỉnh sửa các thuộc tính lật:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Đặt hình ảnh được sử dụng cho việc điền nền.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Đặt chế độ lấp đầy hình ảnh thành Lát và điều chỉnh các thuộc tính lát.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Đọc thêm: [Tile Picture as Texture](/slides/vi/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi độ trong suốt của hình ảnh nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình ảnh nền slide để làm nổi bật nội dung của slide. Đoạn mã Python sau cho thấy cách thay đổi độ trong suốt cho hình ảnh nền slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Ví dụ.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Lấy tập hợp các phép biến đổi hình ảnh.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Tìm hiệu ứng trong suốt cố định theo phần trăm hiện có.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Đặt giá trị trong suốt mới.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy giá trị nền slide**

Aspose.Slides cho phép bạn lấy các giá trị nền thực tế của một slide bằng cách sử dụng phương thức [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/background/#geteffective) trên [Background](https://reference.aspose.com/slides/vi/python-java/aspose.slides/background/). Dữ liệu trả về tiết lộ các định dạng fill và effect thực tế.

Bằng cách sử dụng phương thức [getBackground](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getbackground) của lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/), bạn có thể lấy nền của một slide.

Ví dụ Python sau cho thấy cách lấy giá trị nền thực tế của một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Lấy nền thực tế, tính đến master, layout và theme.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền chủ đề/bố cục không?**

Có. Xóa fill tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/python-java/slide-layout/)/[master](/slides/vi/python-java/slide-master/) tương ứng (tức là [theme background](/slides/vi/python-java/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi chủ đề của bản trình chiếu sau này?**

Nếu một slide có fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/python-java/slide-layout/)/[master](/slides/vi/python-java/slide-master/), nó sẽ cập nhật để phù hợp với [new theme](/slides/vi/python-java/presentation-theme/).