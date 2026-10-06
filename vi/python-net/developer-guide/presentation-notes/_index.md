---
title: Quản lý ghi chú trình bày trong Python
linktitle: Ghi chú trình bày
type: docs
weight: 110
url: /vi/python-net/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- trình bày
- Python
- Aspose.Slides
description: "Tùy chỉnh ghi chú trình bày với Aspose.Slides cho Python qua .NET. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc xóa các slide ghi chú khỏi một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển hướng, và kiểm tra hành vi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/python-net/notes-size/).

## **Xóa Ghi chú khỏi Slide**
Ghi chú từ một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp trình chiếu 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Xóa ghi chú của slide đầu tiên
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Lưu trình chiếu vào đĩa
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa Ghi chú khỏi Tất cả các Slide**
Ghi chú từ tất cả các slide trong bản trình bày có thể được xóa như trong ví dụ dưới đây:

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp trình chiếu 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Xóa ghi chú của tất cả các slide
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # Lưu trình chiếu vào đĩa
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng Kiểu Ghi chú**
Thuộc tính [notes_style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslide/notes_style/) đã được thêm vào lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masternotesslide/). Thuộc tính này xác định kiểu của văn bản ghi chú. Việc thực thi được trình bày trong ví dụ dưới đây.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Lấy kiểu văn bản MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Đặt ký hiệu dấu đầu dòng cho các đoạn văn cấp độ đầu tiên
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # Lưu tệp PPTX vào đĩa
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslidemanager/) và một [property](https://reference.aspose.com/slides/vi/python-net/aspose.slides/notesslidemanager/notes_slide/) trả về đối tượng ghi chú, hoặc `None` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hoạt động không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 đến các bản mới hơn) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.