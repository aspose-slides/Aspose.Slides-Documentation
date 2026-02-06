---
title: 备注
type: docs
weight: 240
url: /zh/python-net/examples/elements/note/
keywords:
- 备注
- 添加备注幻灯片
- 访问备注幻灯片
- 删除备注幻灯片
- 更新备注文本
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中添加、读取、编辑和导出演讲者备注：格式化文本、按幻灯片管理备注，并在 PowerPoint 和 OpenDocument 中控制可见性。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 添加、读取、删除和更新备注幻灯片。

## **添加备注幻灯片**

创建一个备注幻灯片并为其分配文本。

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **访问备注幻灯片**

读取现有备注幻灯片中的文本。

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **删除备注幻灯片**

删除与幻灯片关联的备注幻灯片。

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 删除备注幻灯片。
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新备注文本**

更改备注幻灯片的文本。

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # 更新备注文本。
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```