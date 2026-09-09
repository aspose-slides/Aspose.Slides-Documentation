---
title: Quản lý các Placeholder trong Bản trình chiếu bằng Python
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/python-java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu về kế thừa placeholder với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Một placeholder là một hình dạng dành chỗ cho một loại nội dung cụ thể trong mẫu bản trình bày. Các ví dụ phổ biến là tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa năng. Khác với một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ một layout slide hoặc master slide.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [Shape.getPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getPlaceholder). Phương thức trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/) hoặc `None` cho một hình dạng bình thường. Sử dụng [Placeholder.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/#getType) để xác định placeholder dự định chứa gì.

Loại hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/).
- Placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/#getType) và loại hình dạng runtime thay vì giả định rằng mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/#getType) mô tả vai trò của một placeholder; nó không đảm bảo loại hình dạng runtime. Luôn kiểm tra loại trước khi truy cập các thành viên đặc thù của văn bản, hình ảnh, biểu đồ, bảng hoặc media.
{{% /alert %}}

## **Hiểu kế thừa Placeholder**

Placeholder tạo thành một cây phân cấp:

1. Một master slide định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Một layout slide định nghĩa bố cục được một hoặc nhiều slide bình thường sử dụng và có thể kế thừa từ master.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getBasePlaceholder) để di chuyển lên một cấp trong cây phân cấp này. Một placeholder trên slide thường trả về placeholder trên layout; một placeholder trên layout có thể trả về placeholder trên master. Phương thức trả về `None` khi hình dạng không có base placeholder.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo base placeholder của chúng:

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

Chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng tới tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có base placeholder và không bắt đầu kế thừa chỉ vì nó nằm ở cùng tọa độ.

## **Thay đổi Văn bản trong Placeholder**

Các placeholder tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và văn bản thường hỗ trợ văn bản. Kiểm tra [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#getTextFrame) của nó.

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

Mô hình này tránh việc xử lý các placeholder hình ảnh, biểu đồ, bảng hoặc media như một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào chỉ số hình dạng dễ vỡ.

## **Đặt Văn bản Gợi ý trên Layout**

Văn bản gợi ý là hướng dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Nhấp để thêm tiêu đề*. Đặt văn bản gợi ý tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout thông qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getLayoutSlide) và lặp qua bộ sưu tập trả về bởi [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getShapes).

Ví dụ sau đổi văn bản gợi ý tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

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

Văn bản gợi ý không phải là nội dung của slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, văn bản gợi ý sẽ không còn hiển thị. Thay đổi một gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/), thay thế ảnh qua [PictureFillFormat.getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [Picture.setImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#setImage).
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addPictureFrame) và loại bỏ placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình bày:

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

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape.getPlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getPlaceholder) không cung cấp setter. Nó giữ vị trí đã dành nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ mối quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù khác, xem mục [Manage Picture Frames](/slides/vi/python-java/picture-frame/). Các thao tác này thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/). Ví dụ này tìm một biểu đồ như vậy bằng cả loại placeholder và loại runtime, thay đổi tiêu đề và lưu tệp:

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

Một placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Object). Trong PowerPoint nó đóng vai trò là một launcher cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và media. Sau khi được điền, kiểm tra loại hình dạng thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Media) hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides không chuyển đổi một placeholder [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) trống thành một [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/) chỉ bằng cách thay đổi [Placeholder.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/#getType); loại không thể thay đổi qua API. Để lập chương trình một khu vực biểu đồ hoặc nội dung trống, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó loại bỏ placeholder trống. Ví dụ sau thực hiện việc này cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder của layout. Sử dụng các bài viết quản lý biểu đồ chuyên dụng [chart management articles](/slides/vi/python-java/powerpoint-charts/) khi bạn cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ Đầy đủ: Cập nhật Văn bản hoặc Nội dung Ảnh**

Ví dụ end-to-end sau mở một mẫu, tìm kiếm slide đầu tiên cho placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ này cố ý tránh giả định chỉ số hình dạng hoặc xử lý mọi placeholder như cùng một loại.

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

## **Câu hỏi thường gặp**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getBasePlaceholder) để truy xuất nó. Một hình dạng cục bộ bình thường trả về `None` vì nó không thuộc cây placeholder.

**Có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder trên layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình bày, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý tiêu đề và chân trang ở mức slide, layout, master, notes hoặc handout thích hợp. Xem mục [Manage Presentation Header and Footer](/slides/vi/python-java/presentation-header-and-footer/) để có các ví dụ đầy đủ.