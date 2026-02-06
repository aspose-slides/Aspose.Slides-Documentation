---
title: 页眉页脚
type: docs
weight: 220
url: /zh/python-net/examples/elements/header-footer/
keywords:
- 页眉页脚
- 添加页眉页脚
- 更新页眉页脚
- 设置日期和时间
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 控制页眉和页脚：添加或编辑日期/时间、幻灯片编号和页脚文本，在 PPT、PPTX 和 ODP 中显示或隐藏占位符。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 添加页脚并更新日期和时间占位符。

## **添加页脚**

向幻灯片的页脚区域添加文本并使其可见。

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```