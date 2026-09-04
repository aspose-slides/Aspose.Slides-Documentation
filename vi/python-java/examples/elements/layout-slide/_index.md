---
title: Slide bố cục
type: docs
weight: 20
url: /vi/python-java/examples/elements/layout-slide/
keywords:
- ví dụ mã
- slide bố cục
- thêm slide bố cục
- truy cập slide bố cục
- xóa slide bố cục
- slide bố cục không dùng
- sao chép slide bố cục
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Quản lý slide bố cục với Aspose.Slides cho Python thông qua Java: thêm, truy cập, xóa, dọn dẹp và sao chép bố cục trong các bản trình bày PowerPoint và OpenDocument."
---
Bài viết này trình bày cách làm việc với **layout slides** bằng Aspose.Slides cho Python thông qua Java. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các layout không dùng để giảm kích thước bản trình bày.

Cài đặt gói theo mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ đều nhập `asposeslides` trước khi khởi động JVM, rồi nhập API sau khi JVM đang chạy.

## **Thêm một layout slide**

Tạo một layout slide tùy chỉnh để định nghĩa định dạng có thể tái sử dụng. Ví dụ sau thêm một hộp văn bản vào một layout mới và sau đó tạo hai slide sử dụng layout đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Tạo một layout slide với kiểu layout trống và tên tùy chỉnh.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Thêm một hộp văn bản vào layout slide.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Thêm hai slide kế thừa văn bản từ layout.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Note 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể xác định các yếu tố chung một lần và tái sử dụng chúng trong nhiều slide.

> 💡 **Note 2:** Khi bạn thêm các hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung.  
> Bức ảnh chụp màn hình bên dưới hiển thị hai slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Truy cập một layout slide**

Truy cập layout slides bằng chỉ mục hoặc bằng loại layout, chẳng hạn như trống, tiêu đề hoặc tiêu đề phần.

```python
import jpipe
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Truy cập một layout slide theo chỉ mục.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Truy cập một layout slide theo kiểu.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Xóa một layout slide**

Xóa một layout slide cụ thể khi không còn cần thiết.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Xóa các layout slide không sử dụng**

Xóa các layout slide không được bất kỳ slide nào sử dụng để giảm kích thước bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Sao chép một layout slide**

Sao chép một layout slide và thêm bản sao vào cuối bộ sưu tập layout slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Summary:** Layout slides giúp duy trì định dạng nhất quán trong toàn bộ bản trình bày. Aspose.Slides cho phép bạn tạo, quản lý, tái sử dụng và dọn dẹp các layout khi cần.