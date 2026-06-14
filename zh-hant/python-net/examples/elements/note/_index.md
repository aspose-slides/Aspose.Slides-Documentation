---
title: 備註
type: docs
weight: 240
url: /zh-hant/python-net/examples/elements/note/
keywords:
- 備註
- 新增備註投影片
- 存取備註投影片
- 移除備註投影片
- 更新備註文字
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 新增、讀取、編輯及匯出講者備註：格式化文字、管理每張投影片的備註，並在 PowerPoint 與 OpenDocument 中控制可見性。"
---
示範如何使用 **Aspose.Slides for Python via .NET** 新增、讀取、移除及更新備註投影片。

## **新增備註投影片**

建立一個備註投影片並為其指派文字。

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **存取備註投影片**

從現有的備註投影片讀取文字。

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **移除備註投影片**

移除與投影片關聯的備註投影片。

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 移除備註投影片。
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新備註文字**

變更備註投影片的文字。

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 更新備註文字。
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```