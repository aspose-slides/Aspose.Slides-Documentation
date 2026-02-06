---
title: SmartArt
type: docs
weight: 140
url: /zh/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- 添加 SmartArt
- 访问 SmartArt
- 删除 SmartArt
- SmartArt 布局
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中构建和编辑 SmartArt：添加节点、更改布局和样式、精准转换为形状，并导出为 PPT、PPTX 和 ODP。"
---
演示如何使用 **Aspose.Slides for Python via .NET** 添加 SmartArt 图形、访问它们、删除它们以及更改布局。

## **添加 SmartArt**

使用内置布局之一插入 SmartArt 图形。

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **访问 SmartArt**

检索幻灯片上的第一个 SmartArt 对象。

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问第一个 SmartArt 形状。
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **删除 SmartArt**

从幻灯片中删除 SmartArt 形状。

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 SmartArt 对象。
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更改 SmartArt 布局**

更新现有 SmartArt 图形的布局类型。

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 SmartArt 对象。
        smart_art = slide.shapes[0]

        # 更改 SmartArt 布局。
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```