---
title: SmartArt
type: docs
weight: 140
url: /zh/python-java/examples/elements/smart-art/
keywords:
- 代码示例
- SmartArt
- 添加 SmartArt
- 访问 SmartArt
- 删除 SmartArt
- SmartArt 布局
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中使用 SmartArt：在 PowerPoint 和 OpenDocument 演示文稿中添加、访问、删除以及更改图表布局。"
---
本文演示如何使用 **Aspose.Slides for Python via Java** 添加 SmartArt 图形、访问它们、删除它们以及更改布局。

按照[安装](/slides/zh/python-java/installation/)中描述的方式安装包。每个示例在启动 JVM 之前导入 `asposeslides`，然后在 JVM 运行后导入 API。

## **添加 SmartArt**

使用内置布局之一插入 SmartArt 图形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **访问 SmartArt**

检索幻灯片上的第一个 SmartArt 对象。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **删除 SmartArt**

从幻灯片中删除 SmartArt 形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **更改 SmartArt 布局**

更新现有 SmartArt 图形的布局类型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```