---
title: Slide Master
type: docs
weight: 30
url: /vi/python-java/examples/elements/master-slide/
keywords:
- ví dụ mã
- slide master
- thêm slide master
- truy cập slide master
- xóa slide master
- slide master không sử dụng
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Quản lý slide master với Aspose.Slides cho Python qua Java: tạo, truy cập, xóa và dọn dẹp các master trong các bản trình bày PowerPoint và OpenDocument."
---
Các slide master tạo thành cấp cao nhất của hệ thống kế thừa slide trong PowerPoint. Một **slide master** xác định các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Slide bố cục** kế thừa từ slide master, và **slide bình thường** kế thừa từ slide bố cục.

Bài viết này trình bày cách tạo, chỉnh sửa và quản lý slide master bằng **Aspose.Slides for Python via Java**.

Cài đặt gói theo mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm Slide Master**

Ví dụ này cho thấy cách tạo một slide master mới bằng cách nhân bản slide mặc định. Sau đó nó thêm một biểu ngữ tên công ty vào tất cả các slide thông qua việc kế thừa bố cục.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Sao chép slide master mặc định.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Thêm biểu ngữ với tên công ty vào phần trên cùng của slide master.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Gán slide master mới cho một slide bố cục.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Gán slide bố cục cho slide đầu tiên trong bản trình bày.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Lưu ý" %}}
Slide master cung cấp cách áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chia sẻ trên tất cả các slide. Các thay đổi thực hiện trên một master sẽ tự động được phản ánh trên các slide bố cục và slide bình thường phụ thuộc.
{{% /alert %}}

{{% alert color="info" title="Lưu ý" %}}
Các hình dạng và định dạng được thêm vào một slide master sẽ được kế thừa bởi các slide bố cục và, tiếp đó, bởi tất cả các slide bình thường sử dụng các bố cục đó. Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào slide master sẽ tự động được hiển thị trên slide cuối cùng.
{{% /alert %}}

![Ví dụ Kế thừa Master](master-slide-banner.png)

## **Truy cập Slide Master**

Bạn có thể truy cập các slide master thông qua bộ sưu tập master của bản trình bày. Ví dụ này lấy slide master đầu tiên và thay đổi kiểu nền của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Xóa Slide Master**

Một slide master có thể bị xóa bằng chỉ mục hoặc bằng tham chiếu khi không còn được sử dụng. Ví dụ này gán một slide master đã được nhân bản vào bản trình bày và sau đó xóa master gốc bằng chỉ mục.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Xóa slide master gốc không sử dụng bằng chỉ mục.
    # Hoặc, xóa một slide master không sử dụng bằng tham chiếu:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Xóa Các Slide Master Không Sử Dụng**

Một số bản trình bày chứa các slide master không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Xóa tất cả các slide master không sử dụng, bao gồm cả những slide được đánh dấu Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```