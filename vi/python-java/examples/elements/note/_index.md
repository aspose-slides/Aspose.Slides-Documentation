---
title: Ghi chú
type: docs
weight: 240
url: /vi/python-java/examples/elements/note/
keywords:
- ví dụ mã
- ghi chú
- ghi chú người nói
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Làm việc với ghi chú slide trong Aspose.Slides cho Python qua Java: thêm, đọc, xóa và cập nhật ghi chú người nói trong các bản trình bày PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm một slide ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Truy cập một slide ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Xóa một slide ghi chú**

Xóa slide ghi chú liên kết với một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Cập nhật văn bản ghi chú**

Thay đổi văn bản của một slide ghi chú.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```