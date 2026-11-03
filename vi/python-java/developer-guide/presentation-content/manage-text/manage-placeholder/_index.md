---
title: Quản lý Placeholder trong Bản trình chiếu bằng Python
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/python-java/manage-placeholder/
keywords:
- trình giữ chỗ
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- placeholder nội dung
- văn bản nhắc
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa placeholder văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu cách kế thừa placeholder với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Placeholder là một hình dạng dùng để giữ một vị trí cho một loại nội dung cụ thể trong mẫu bản trình chiếu. Các ví dụ phổ biến là placeholder tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa mục đích. Khác với một hình dạng thông thường, placeholder có thể thừa hưởng vị trí, kích thước, định dạng và các cài đặt khác từ một slide bố cục hoặc slide master.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Phương thức trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) hoặc `None` cho một hình dạng bình thường. Sử dụng [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) để xác định placeholder dự định chứa gì.

Kiểu hình dạng vẫn quan trọng ngay cả sau khi bạn biết kiểu placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu thị bằng một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu thị bằng một [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu thị bằng một [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) và kiểu hình dạng thời gian chạy thay vì giả định rằng mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) mô tả vai trò của một placeholder; nó không đảm bảo kiểu thời gian chạy của hình dạng. Luôn luôn kiểm tra kiểu trước khi truy cập các thành viên đặc thù cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu Kế thừa Placeholder**

Placeholder tạo thành một hệ thống phân cấp:

1. Một slide master định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Một slide bố cục định nghĩa cách sắp xếp được sử dụng bởi một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) để di chuyển lên một cấp trong hệ thống này. Một placeholder slide thường trả về placeholder bố cục của nó; một placeholder bố cục có thể trả về placeholder master. Phương thức trả về `None` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa bố cục hoặc master liên quan có thể ảnh hưởng tới tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa Trạng Thái Placeholder**

Khi tùy chỉnh một mẫu, sử dụng [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) để giữ một đối tượng hiện có như một hình dạng bình thường. Phương thức [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) của nó trả về `None`, nhưng hình dạng vẫn còn trong bộ sưu tập của slide. Ngược lại, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder với định dạng kế thừa từ bố cục hoặc master để xem hiệu quả của việc xóa quan hệ đó. Ví dụ kiểm tra rằng cùng một hình dạng vẫn còn, gọi lại phương thức trên hình dạng hiện đã trở thành bình thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Xóa trạng thái placeholder không tự động giữ nguyên các cài đặt hiển thị kế thừa. Ví dụ dưới đây cố tình để nguyên các cài đặt đó, vì vậy kết quả có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng 0 sau lời gọi và trở nên vô hình ngay cả khi nó vẫn còn trong bộ sưu tập.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Gọi phương thức trên một hình dạng bình thường không có hiệu lực.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Đối với một placeholder khớp, cả ba kiểm tra đều in `True`. Văn bản vẫn còn, nhưng vị trí, kích thước, góc quay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, màu nền và đường viền kế thừa có thể thay đổi khi quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề kế thừa có thể quay lại định dạng văn bản thường. Xem [Slide Layout](/slides/vi/python-java/slide-layout/) để biết thêm về bố cục.

Để giữ nguyên giao diện mong muốn, hãy ghi lại vị trí, kích thước và góc quay đã được giải quyết trước lời gọi, và sao chép các giá trị định dạng hiệu lực cần thiết vào các biến riêng. Lấy các giá trị đó qua [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) và [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Không dựa vào việc chỉ giữ các đối tượng định dạng hiệu lực, vì giá trị định dạng văn bản của chúng có thể thay đổi sau khi quan hệ bị xóa. Áp dụng rõ ràng các giá trị đã ghi lại cho hình dạng bình thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu, cài đặt đoạn văn, cài đặt khung văn bản, màu nền và đường viền được mẫu của bạn sử dụng.

Hình học kế thừa của hình dạng cũng có thể cần được gán một cách rõ ràng qua [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Đối với một placeholder văn bản hình chữ nhật, điều này đồng nghĩa với việc gán [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); chỉ khôi phục màu nền và đường viền có thể không khôi phục hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng yêu cầu xử lý các cài đặt đó.

## **Thay Đổi Văn Bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và placeholder văn bản thường hỗ trợ văn bản. Kiểm tra [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mẫu này tránh việc xử lý placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện như một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Nó cũng xác định placeholder theo mục đích thay vì dựa vào một chỉ số hình dạng dễ vỡ.

## **Đặt Văn Bản Gợi Ý trên Bố Cục**

Văn bản gợi ý là hướng dẫn thiết kế được hiển thị trong một placeholder trống, chẳng hạn *Click to add title*. Đặt văn bản gợi ý tùy chỉnh trên placeholder bố cục thay vì cố gắng tiếp cận nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập bố cục qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) và lặp qua bộ sưu tập trả về bởi [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Ví dụ sau thay đổi gợi ý tiêu đề và phụ đề trên bố cục được sử dụng bởi slide đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Văn bản gợi ý không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực tế, gợi ý sẽ không còn hiển thị. Thay đổi gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng bố cục đó.

## **Cập Nhật Placeholder Hình Ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu thị bằng một [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), thay thế hình ảnh thông qua [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) và [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) và xóa placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) không cung cấp setter. Nó giữ vị trí đã được dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ quan hệ placeholder là cần thiết, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù khác, xem [Manage Picture Frames](/slides/vi/python-java/picture-frame/). Các thao tác đó thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm Việc với Placeholder Biểu Đồ và Nội Dung**

Một placeholder biểu đồ đã được điền có thể được biểu thị bằng một [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Ví dụ này tìm một biểu đồ như vậy bằng cả kiểu placeholder và kiểu thời gian chạy, thay đổi tiêu đề của nó và lưu tệp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Một placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). Trong PowerPoint nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra kiểu hình dạng thực tế để biết nó chứa gì. Các bố cục chuyên biệt cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides không chuyển đổi một placeholder [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) trống thành một [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) chỉ bằng cách thay đổi [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); kiểu không thể thay đổi qua API. Để điền một biểu đồ hoặc khu vực nội dung trống bằng mã, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder trống. Ví dụ dưới đây thực hiện điều này cho một biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Biểu đồ được thêm là một biểu đồ cục bộ bình thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder bố cục. Sử dụng các [chart management articles](/slides/vi/python-java/powerpoint-charts/) khi cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví Dụ Hoàn Chỉnh: Cập Nhật Nội Dung Văn Bản hoặc Hình Ảnh**

Ví dụ end-to-end sau mở một mẫu, tìm kiếm slide đầu tiên cho placeholder tiêu đề hoặc hình ảnh, kiểm tra kiểu placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố tình tránh giả định chỉ số hình dạng hoặc xử lý mọi placeholder như cùng một kiểu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên bố cục hoặc master mà một placeholder khác kế thừa. Sử dụng [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) để lấy nó. Một hình dạng bình thường cục bộ trả về `None` vì nó không thuộc hệ thống placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder bố cục không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua bố cục, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng trình quản lý tiêu đề và chân trang ở phạm vi slide, bố cục, master, ghi chú hoặc tài liệu phát tay tương ứng. Xem [Manage Presentation Header and Footer](/slides/vi/python-java/presentation-header-and-footer/) để biết các ví dụ đầy đủ.