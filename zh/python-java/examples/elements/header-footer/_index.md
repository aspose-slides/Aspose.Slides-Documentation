---
title: 页眉页脚
type: docs
weight: 220
url: /zh/python-java/examples/elements/header-footer/
keywords:
- 代码示例
- 页眉
- 页脚
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 控制幻灯片的页眉和页脚：在 PPT、PPTX 和 ODP 演示文稿中添加日期、幻灯片编号和自定义文本。"
---
本文演示如何使用 **Aspose.Slides for Python via Java** 添加页脚以及更新日期和时间占位符。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装包。每个示例在启动 JVM 之前导入 `asposeslides`，然后在 JVM 运行后导入 API。

## **添加页脚**

在幻灯片的页脚区域添加文本并使其可见。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```