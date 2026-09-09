---
title: Tiêu đề và chân trang
type: docs
weight: 220
url: /vi/python-java/examples/elements/header-footer/
keywords:
- ví dụ mã
- đầu trang
- chân trang
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Kiểm soát tiêu đề và chân trang của slide bằng Aspose.Slides cho Python qua Java: thêm ngày tháng, số slide và văn bản tùy chỉnh trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách thêm phần chân trang và cập nhật các trình giữ chỗ ngày và giờ bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ đều nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm phần Chân Trang**

Thêm văn bản vào vùng chân trang của một slide và hiển thị nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Cập nhật Ngày và Giờ**

Sửa đổi trình giữ chỗ ngày và giờ trên một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```