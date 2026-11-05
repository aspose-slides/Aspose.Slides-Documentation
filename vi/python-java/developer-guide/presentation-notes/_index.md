---
title: Quản lý ghi chú bài thuyết trình trong Python qua Java
linktitle: Ghi chú bài thuyết trình
type: docs
weight: 110
url: /vi/python-java/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chủ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh ghi chú bài thuyết trình với Aspose.Slides cho Python qua Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bản trình bày. Chủ đề này giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển hướng, và kiểm tra hành vi xuất, hãy xem [Notes Page Size](/slides/vi/python-java/notes-size/).

## **Xóa ghi chú khỏi một slide**

Ghi chú từ một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình.
presentation = Presentation("presWithNotes.pptx")
try:
    # Xóa ghi chú khỏi slide đầu tiên.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Lưu bài thuyết trình vào đĩa.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa ghi chú khỏi một bản trình bày**

Ghi chú từ tất cả các slide trong một bản trình bày có thể được xóa như trong ví dụ dưới đây:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình.
presentation = Presentation("presWithNotes.pptx")
try:
    # Xóa ghi chú khỏi tất cả các slide.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Lưu bài thuyết trình vào đĩa.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm kiểu ghi chú**

Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslide/#getNotesStyle) của lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslide/) cung cấp quyền truy cập vào kiểu của văn bản ghi chú. Việc triển khai được minh họa trong ví dụ dưới đây.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Lấy kiểu văn bản của slide ghi chú chủ.
        notes_style = notes_master.getNotesStyle()

        # Đặt ký hiệu bullet cho các đoạn văn cấp một.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslidemanager/) và một phương thức [getNotesSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslidemanager/#getNotesSlide) trả về đối tượng ghi chú, hoặc `None` nếu không có ghi chú.

**Có sự khác biệt nào trong hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện nhắm tới một loạt các định dạng Microsoft PowerPoint (từ 97 trở đi) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc có cài đặt PowerPoint.