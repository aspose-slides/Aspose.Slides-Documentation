---
title: 超連結
type: docs
weight: 130
url: /zh-hant/python-net/examples/elements/hyperlink/
keywords:
- 超連結
- 新增超連結
- 存取超連結
- 移除超連結
- 更新超連結
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 新增、編輯和移除超連結：文字、形狀、投影片、URL 與電子郵件；為 PPT、PPTX 與 ODP 設定目標與動作。"
---
示範如何在形狀上使用 **Aspose.Slides for Python via .NET** 添加、存取、移除和更新超連結。

## **新增超連結**

建立一個矩形形狀，並設定指向外部網站的超連結。

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **存取超連結**

從形狀的文字部份讀取超連結資訊。

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **移除超連結**

清除形狀文字中的超連結。

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新超連結**

變更現有超連結的目標。使用 `HyperlinkManager` 來修改已包含超連結的文字，模擬 PowerPoint 安全更新超連結的方式。

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # 在現有文字中變更超連結應透過
        # 使用 HyperlinkManager 而不是直接設定屬性。
        # 這模擬了 PowerPoint 安全更新超連結的方式。
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```