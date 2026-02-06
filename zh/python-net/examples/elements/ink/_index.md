---
title: 墨迹
type: docs
weight: 180
url: /zh/python-net/examples/elements/ink/
keywords:
- 墨迹
- 访问墨迹
- 删除墨迹
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 处理幻灯片上的数字墨迹：添加笔画、编辑路径、设置颜色和宽度，并将结果导出为 PowerPoint 和 OpenDocument。"
---
提供使用 **Aspose.Slides for Python via .NET** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意：** 墨迹形状表示来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取和修改现有墨迹。

## **访问墨迹**

获取幻灯片中的第一个墨迹形状。

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **删除墨迹**

从幻灯片中删除墨迹形状。

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 Ink 对象。
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```