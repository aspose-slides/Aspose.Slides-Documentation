---
title: 墨迹
type: docs
weight: 180
url: /zh/python-java/examples/elements/ink/
keywords:
- 代码示例
- 墨迹
- 访问墨迹
- 删除墨迹
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 演示文稿中访问和删除墨迹形状，包括 PPT、PPTX 和 ODP 文件。"
---
本文提供了使用 **Aspose.Slides for Python via Java** 访问现有墨迹形状并将其删除的示例。

按照 [Installation](/slides/zh/python-java/installation/) 中的描述安装该包。每个示例在启动 JVM 之前导入 `asposeslides`，在 JVM 运行后再导入 API。

{{% alert color="info" title="Note" %}}
墨迹形状代表来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取并修改已有的墨迹。
{{% /alert %}}

## **访问墨迹**

读取幻灯片上第一个墨迹形状的标签。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # 根据需要使用 tag_name。
finally:
    presentation.dispose()
```

## **删除墨迹**

如果幻灯片中存在墨迹形状，则将其删除。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```