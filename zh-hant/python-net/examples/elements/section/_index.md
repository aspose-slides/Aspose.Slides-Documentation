---
title: 節
type: docs
weight: 90
url: /zh-hant/python-net/examples/elements/section/
keywords:
- 節
- 投影片節
- 新增節
- 存取節
- 移除節
- 重新命名節
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理投影片節：輕鬆建立、重新命名、重新排序，將投影片在節之間移動，並控制 PPT、PPTX 與 ODP 的可見性。"
---
示範如何以程式方式使用 **Aspose.Slides for Python via .NET** 來管理簡報的節──新增、存取、移除與重新命名。

## **新增節**

建立一個從特定投影片開始的節。

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增一個節並指定標示該節開始的投影片。
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **存取節**

從簡報中取得節。

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # 依索引存取節。
        section = presentation.sections[0]
```

## **移除節**

刪除先前新增的節。

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 移除節。
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **重新命名節**

變更現有節的名稱。

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 重新命名節。
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```