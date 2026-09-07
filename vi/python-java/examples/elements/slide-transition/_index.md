---
title: "Chuyển đổi Slide"
type: docs
weight: 110
url: /vi/python-java/examples/elements/slide-transition/
keywords:
- "ví dụ mã"
- "chuyển đổi slide"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Áp dụng và xóa chuyển đổi slide, đồng thời thiết lập thời gian tự động chuyển slide với các ví dụ mã Aspose.Slides cho Python qua Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển đổi slide và thời gian với **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm chuyển đổi Slide**

Áp dụng hiệu ứng chuyển đổi mờ (fade) cho slide đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Áp dụng hiệu ứng chuyển đổi mờ.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Truy cập chuyển đổi Slide**

Đọc loại chuyển đổi hiện đang được gán cho một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Truy cập loại chuyển đổi.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Xóa chuyển đổi Slide**

Xóa bất kỳ hiệu ứng chuyển đổi nào. JPype cung cấp hằng số Java có tên `None` dưới dạng `None_` vì `None` là từ khóa được dành riêng trong Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Xóa hiệu ứng chuyển đổi.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Đặt thời lượng chuyển đổi**

Xác định thời gian slide được hiển thị trước khi tự động chuyển sang slide tiếp theo. Ví dụ này chuyển sang sau hai giây và cũng cho phép chuyển bằng cú nhấp chuột. Thời gian này điều khiển việc chuyển slide, không phải tốc độ của hiệu ứng chuyển đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # Tính bằng mili giây.
finally:
    presentation.dispose()
```