---
title: 超链接
type: docs
weight: 130
url: /zh/python-net/examples/elements/hyperlink/
keywords:
- 超链接
- 添加超链接
- 访问超链接
- 删除超链接
- 更新超链接
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 添加、编辑和删除超链接：链接文本、形状、幻灯片、URL 和电子邮件；为 PPT、PPTX 和 ODP 设置目标和操作。"
---
演示如何在形状上添加、访问、删除和更新超链接，使用 **Aspose.Slides for Python via .NET**。

## **添加超链接**

创建一个矩形形状，并为其添加指向外部网站的超链接。

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

## **访问超链接**

读取形状文本部分的超链接信息。

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **删除超链接**

从形状的文本中清除超链接。

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新超链接**

更改现有超链接的目标。使用 `HyperlinkManager` 修改已包含超链接的文本，这模拟了 PowerPoint 安全更新超链接的方式。

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # 更改现有文本中的超链接应通过
        # HyperlinkManager 而不是直接设置属性来完成。
        # 这模拟了 PowerPoint 安全更新超链接的方式。
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```