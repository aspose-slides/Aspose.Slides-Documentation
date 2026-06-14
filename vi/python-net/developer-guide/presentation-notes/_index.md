---
title: Quản lý ghi chú bài thuyết trình trong Python
linktitle: Ghi chú bài thuyết trình
type: docs
weight: 110
url: /vi/python-net/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chủ đề
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tùy chỉnh ghi chú bài thuyết trình với Aspose.Slides cho Python qua .NET. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bài thuyết trình. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong một bài thuyết trình. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bài thuyết trình.
- Xóa ghi chú khỏi tất cả các slide trong bài thuyết trình.

## **Xóa ghi chú khỏi Slide**
Ghi chú của một slide cụ thể có thể được xóa như minh họa trong ví dụ dưới đây:

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Xóa ghi chú của slide đầu tiên
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # lưu bài thuyết trình vào ổ đĩa
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa ghi chú khỏi Tất cả các Slide**
Ghi chú của tất cả các slide trong một bài thuyết trình có thể được xóa như minh họa trong ví dụ dưới đây:

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Xóa ghi chú của tất cả các slide
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # lưu bài thuyết trình vào ổ đĩa
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm NotesStyle**
Thuộc tính [notes_style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslide/notes_style/) đã được thêm vào lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslide/). Thuộc tính này xác định kiểu của văn bản ghi chú. Việc triển khai được minh họa trong ví dụ dưới đây.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Lấy kiểu văn bản MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set biểu tượng bullet cho các đoạn văn mức độ đầu tiên
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # lưu tệp PPTX vào ổ đĩa
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslidemanager/) và một [property](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslidemanager/notes_slide/) trả về đối tượng ghi chú, hoặc `None` nếu không có ghi chú.

**Có sự khác biệt nào trong hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện làm việc không?**

Thư viện hướng tới một loạt rộng các định dạng Microsoft PowerPoint (97‑mới hơn) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc có cài đặt PowerPoint hay không.