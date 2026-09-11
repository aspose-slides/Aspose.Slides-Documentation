---
title: Định dạng các hình dạng PowerPoint trong Python qua Java
linktitle: Định dạng hình dạng
type: docs
weight: 20
url: /vi/python-java/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng sketch
- đường viền hình dạng sketch
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu hình ảnh
- đổ màu texture
- đổ màu đồng nhất
- độ trong suốt hình dạng
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng thang xám
- xoay hình dạng
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Python qua Java bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát toàn diện."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô màu.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường**

Với Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [line style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [dash style](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linedashstyle/) cho đường.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Đặt màu tô cho hình dạng hình chữ nhật.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Áp dụng định dạng cho các đường của hình chữ nhật.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Đặt màu cho đường viền của hình chữ nhật.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The formatted lines in the presentation](formatted-lines.png)

## **Áp dụng hiệu ứng Sketch cho Đường viền Hình dạng**

Một hiệu ứng sketch làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getLineFormat) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/lineformat/#getSketchFormat) để truy cập cài đặt sketch, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sketchformat/#setSketchType) để chọn giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linesketchtype/) .

Mã Python sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linesketchtype/#Curved), đọc giá trị đã được gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None_](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Truy cập định dạng đường của hình dạng và định dạng sketch của nó.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Áp dụng hiệu ứng sketch.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Đọc hiệu ứng sketch được gán trực tiếp cho hình dạng.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Xóa bỏ hiệu ứng sketch.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sketchformat/#getSketchType) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide mẫu hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/lineformat/#getEffective), truy cập `LineFormatEffectiveData.getSketchFormat`, và đọc `SketchFormatEffectiveData.getSketchType`. Giá trị effective phản ánh định dạng thực tế được áp dụng sau khi kế thừa được giải quyết:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Định dạng Kiểu Nối (Join Styles)**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường ở một góc (ví dụ ở góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng có các góc nhọn, bạn có thể muốn chọn tùy chọn **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Mã Python sau cho thấy cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt kiểu nối Miter, Bevel và Round:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

    # Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
    presentation = Presentation()
    try:
        # Lấy slide đầu tiên.
        slide = presentation.getSlides().get_Item(0)

        # Thêm ba auto shape loại Hình chữ nhật.
        miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
        bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
        round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

        # Đặt màu tô cho mỗi hình chữ nhật.
        miter_shape.getFillFormat().setFillType(FillType.Solid)
        miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        bevel_shape.getFillFormat().setFillType(FillType.Solid)
        bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        round_shape.getFillFormat().setFillType(FillType.Solid)
        round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        # Đặt độ rộng đường.
        miter_shape.getLineFormat().setWidth(15)
        bevel_shape.getLineFormat().setWidth(15)
        round_shape.getLineFormat().setWidth(15)

        # Đặt màu cho đường của mỗi hình chữ nhật.
        miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

        # Đặt kiểu nối.
        miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
        round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

        # Thêm văn bản vào mỗi hình chữ nhật.
        miter_shape.getTextFrame().setText("Miter Join Style")
        bevel_shape.getTextFrame().setText("Bevel Join Style")
        round_shape.getTextFrame().setText("Round Join Style")

        # Lưu tệp PPTX vào đĩa.
        presentation.save("join_styles.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Đổ màu Gradient**

Trong PowerPoint, Gradient Fill là một tùy chọn định dạng cho phép bạn áp dụng một pha màu liên tục vào một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Sau đây là cách áp dụng Gradient Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của hình dạng thành `Gradient`.
1. Thêm hai màu ưa thích của bạn với các vị trí đã xác định bằng phương thức [addPresetColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gradientstopcollection/#addPresetColor) của bộ sưu tập gradient stop được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/gradientformat/) .
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Áp dụng định dạng gradient cho ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Đặt hướng của gradient.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Thêm hai gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The ellipse with gradient fill](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Pattern Fill là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hoặc ô vuông—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và màu phía trước của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bài thuyết trình. Ngay cả sau khi chọn một mẫu được định sẵn, bạn vẫn có thể chỉ định màu chính xác mà nó sẽ sử dụng.

Đây là cách áp dụng Pattern Fill cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của hình dạng thành `Pattern`.
1. Chọn một kiểu mẫu từ các tùy chọn được định sẵn.
1. Đặt [Background Color](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternformat/#getBackColor) của mẫu.
1. Đặt [Foreground Color](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternformat/#getForeColor) của mẫu.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Đặt kiểu tô là Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Đặt kiểu mẫu.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Đặt màu nền và màu phía trước của mẫu.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The rectangle with pattern fill](pattern-fill.png)

## **Đổ màu Picture**

Trong PowerPoint, Picture Fill là một tùy chọn định dạng cho phép bạn chèn hình ảnh vào bên trong một hình dạng—hiệu quả như việc sử dụng hình ảnh làm nền của hình dạng.

Sau đây là cách sử dụng Aspose.Slides để áp dụng Picture Fill cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của hình dạng thành `Picture`.
1. Đặt chế độ Picture Fill thành `Tile` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Truyền hình ảnh cho phương thức `SlidesPicture.setImage`.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![The lotus picture](lotus.png)

Mã Python sau cho thấy cách đổ hình ảnh vào một hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Đặt kiểu tô là Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Đặt chế độ Picture Fill.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Đặt hình ảnh.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh dạng lát gạch làm texture và tùy chỉnh cách lát, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ Picture Fill—`Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định cách căn chỉnh các viên gạch trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ dịch chuyển ngang của gạch (đơn vị point) so với gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ dịch chuyển dọc của gạch (đơn vị point) so với gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ ngang của gạch dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỷ lệ dọc của gạch dưới dạng phần trăm.

Mã mẫu sau cho thấy cách thêm một hình chữ nhật với Picture Fill dạng lát và cấu hình các tùy chọn gạch:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    first_slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape hình chữ nhật.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Đặt kiểu tô của hình dạng thành Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Tải ảnh và thêm vào tài nguyên của bản trình chiếu.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Gán ảnh cho hình dạng.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Cấu hình chế độ Picture Fill và các thuộc tính lát gạch.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The tile options](tile-options.png)

## **Đổ màu Solid Color**

Trong PowerPoint, Solid Color Fill là một tùy chọn định dạng khiến hình dạng được tô bằng một màu đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, texture hay pattern nào.

Để áp dụng Solid Color Fill cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) của hình dạng thành `Solid`.
1. Gán màu tô ưa thích cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Đặt kiểu tô thành Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Đặt màu tô.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The shape with solid color fill](solid-color-fill.png)

## **Thiết lập Độ trong suốt (Transparency)**

Trong PowerPoint, khi bạn áp dụng Solid Color, Gradient, Picture hoặc Texture Fill cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của lớp tô. Giá trị trong suốt cao hơn làm cho hình dạng càng trong suốt, cho phép nền hoặc các đối tượng phía dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng cho lớp tô. Cách thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) thành `Solid`.
1. Sử dụng [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) để xác định một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape hình chữ nhật rắn.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng rắn.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The transparent shape](shape-transparency.png)

## **Xoay Hình dạng (Rotate Shapes)**

Aspose.Slides cho phép bạn xoay các hình dạng trong bài thuyết trình PowerPoint. Điều này hữu ích khi cần định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính xoay của hình dạng thành góc mong muốn.
1. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Xoay hình dạng 5 độ.
    shape.setRotation(5)

    # Lưu tệp PPTX vào đĩa.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The shape rotation](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D (Add 3D Bevel Effects)**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Bo 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/) của chúng.

Để thêm hiệu ứng Bo 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/) của hình dạng để xác định các cài đặt Bo.
1. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình dạng vào slide.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Đặt các thuộc tính ThreeDFormat cho hình dạng.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The 3D bevel effect](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D (Add 3D Rotation Effects)**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng Xoay 3D cho các hình dạng bằng cách cấu hình thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/) của chúng.

Để áp dụng Xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) vào slide.
1. Sử dụng các phương thức [setCameraType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/camera/#setCameraType) và [setLightType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/lightrig/#setLightType) để định nghĩa Xoay 3D.
1. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The 3D rotation effect](3D-rotation-effect.png)

## **Kiểm soát Hiển thị Đen‑Trắng cho Hình dạng (Control Black-and-White Rendering for Shapes)**

Phương thức [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setBlackWhiteMode) xác định cách một hình dạng riêng lẻ được render khi bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Phương thức này không tự động bật chế độ đen‑trắng và không thay đổi màu nền, đường viền hay định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng quyết định chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình dạng trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp cho hình dạng.

Mã Python sau tạo một hình dạng màu và khiến nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Giữ màu nền cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu nền cam. Trong quy trình hiển thị đen‑trắng, nó sử dụng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ slide đầy đủ màu trong khi định nghĩa cách hiển thị riêng cho in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt lại Định dạng (Reset Formatting)**

Mã Python sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/) về mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp (FAQ)**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của file bản trình bày không?**

Chỉ ảnh hưởng tối thiểu. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng file, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng metadata và gần như không làm tăng kích thước.

**Làm thế nào để phát hiện các hình dạng trên một slide có cùng định dạng để tôi có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi kiểu của chúng là giống nhau và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một file riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc trong file mẫu .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình dạng đã được định dạng và áp dụng lại định dạng của chúng ở nơi cần.