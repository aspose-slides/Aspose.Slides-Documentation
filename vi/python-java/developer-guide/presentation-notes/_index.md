---
title: Quản lý Ghi chú Bản trình bày trong Python qua Java
linktitle: Ghi chú Bản trình bày
type: docs
weight: 110
url: /vi/python-java/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xoá ghi chú
- kiểu dáng ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình bày với Aspose.Slides cho Python qua Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xoá các slide ghi chú khỏi một bản trình bày. Chủ đề này giới thiệu tính năng này, bao gồm cách xoá ghi chú và cách áp dụng kiểu dáng cho các slide ghi chú trong một bản trình bày. Aspose.Slides cho phép bạn xoá ghi chú khỏi bất kỳ slide nào và áp dụng kiểu dáng cho các ghi chú hiện có. Các nhà phát triển có thể xoá ghi chú theo các cách sau:

- Xoá ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xoá ghi chú khỏi tất cả các slide trong bản trình bày.

## **Xoá Ghi chú khỏi một Slide**

Ghi chú từ một slide cụ thể có thể được xoá như minh họa trong ví dụ dưới đây:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày.
presentation = Presentation("presWithNotes.pptx")
try:
    # Xoá ghi chú khỏi slide đầu tiên.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Lưu bản trình bày vào ổ đĩa.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xoá Ghi chú khỏi một Bản Trình Bày**

Ghi chú từ tất cả các slide trong một bản trình bày có thể được xoá như minh họa trong ví dụ dưới đây:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày.
presentation = Presentation("presWithNotes.pptx")
try:
    # Xoá ghi chú khỏi tất cả các slide.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Lưu bản trình bày vào ổ đĩa.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Kiểu Dáng Ghi chú**

Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslide/#getNotesStyle) của lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslide/) cung cấp quyền truy cập vào kiểu dáng của văn bản ghi chú. Cài đặt được minh họa trong ví dụ dưới đây.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Lấy kiểu văn bản của slide ghi chú chính.
        notes_style = notes_master.getNotesStyle()

        # Đặt ký hiệu đầu mục cho các đoạn văn cấp một.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslidemanager/) và một phương thức [getNotesSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notesslidemanager/#getNotesSlide) trả về đối tượng ghi chú, hoặc `None` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện nhắm tới một loạt các định dạng Microsoft PowerPoint (phiên bản 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc có cài đặt PowerPoint hay không.