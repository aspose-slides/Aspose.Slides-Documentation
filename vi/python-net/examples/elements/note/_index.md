---
title: Ghi chú
type: docs
weight: 240
url: /vi/python-net/examples/elements/note/
keywords:
- ghi chú
- thêm slide ghi chú
- truy cập slide ghi chú
- xóa slide ghi chú
- cập nhật văn bản ghi chú
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Thêm, đọc, chỉnh sửa và xuất ghi chú diễn giả trong Python bằng Aspose.Slides: định dạng văn bản, quản lý ghi chú cho mỗi slide và kiểm soát khả năng hiển thị trong PowerPoint và OpenDocument."
---
Hiển thị cách thêm, đọc, xóa và cập nhật các slide ghi chú bằng **Aspose.Slides for Python via .NET**.

## **Thêm một slide ghi chú**

Tạo một slide ghi chú và gán văn bản cho nó.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập slide ghi chú**

Đọc văn bản từ một slide ghi chú hiện có.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Xóa một slide ghi chú**

Xóa slide ghi chú liên kết với một slide.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Xóa slide ghi chú.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập nhật văn bản ghi chú**

Thay đổi văn bản của một slide ghi chú.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Cập nhật văn bản ghi chú.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```