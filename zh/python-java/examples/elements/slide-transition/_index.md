---
title: 幻灯片过渡
type: docs
weight: 110
url: /zh/python-java/examples/elements/slide-transition/
keywords:
- 代码示例
- 幻灯片过渡
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 的代码示例，对 PPT、PPTX 和 ODP 演示文稿应用和移除幻灯片过渡并设置自动切换时间。"
---
本文演示了如何使用 **Aspose.Slides for Python via Java** 应用幻灯片过渡效果和时间设置。

如[安装](/slides/zh/python-java/installation/)中所述安装该包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后再导入 API。

## **添加幻灯片过渡**

对第一张幻灯片应用淡入过渡效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 应用淡入过渡。
finally:
    presentation.dispose()
```

## **访问幻灯片过渡**

读取当前分配给幻灯片的过渡类型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # 访问过渡类型。
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **移除幻灯片过渡**

清除所有过渡效果。JPype 将 Java 常量 `None` 公开为 `None_`，因为 `None` 在 Python 中是保留字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # 删除过渡效果。
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **设置过渡持续时间**

指定幻灯片在自动切换前的显示时长。此示例将在两秒后自动切换，并且也支持通过鼠标点击切换。该时间控制的是幻灯片的切换时机，而不是过渡效果的速度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # 以毫秒为单位。
finally:
    presentation.dispose()
```