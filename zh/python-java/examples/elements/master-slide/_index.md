---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/python-java/examples/elements/master-slide/
keywords:
- 代码示例
- 母版幻灯片
- 添加母版幻灯片
- 访问母版幻灯片
- 删除母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理母版幻灯片：在 PowerPoint 和 OpenDocument 演示文稿中创建、访问、删除并清理母版。"
---
母版幻灯片构成 PowerPoint 幻灯片继承层次结构的顶层。**母版幻灯片**定义公共设计元素，例如背景、标志和文本格式。**布局幻灯片**继承自母版幻灯片，**普通幻灯片**继承自布局幻灯片。

本文演示如何使用 **Aspose.Slides for Python via Java** 创建、修改和管理母版幻灯片。

按照[Installation](/slides/zh/python-java/installation/)中的说明安装该包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加母版幻灯片**

此示例展示了如何通过克隆默认母版来创建新的母版幻灯片。随后，它通过布局继承向所有幻灯片添加公司名称横幅。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 克隆默认母版幻灯片。
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # 在母版幻灯片顶部添加包含公司名称的横幅。
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # 将新母版幻灯片分配给布局幻灯片。
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # 将布局幻灯片分配给演示文稿中的第一张幻灯片。
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
母版幻灯片提供了一种在所有幻灯片中应用一致品牌或共享设计元素的方式。对母版所做的更改会自动反映在依赖的布局幻灯片和普通幻灯片上。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
添加到母版幻灯片的形状和格式会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。下图展示了添加到母版幻灯片的文本框如何自动在最终幻灯片中呈现。
{{% /alert %}}

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以通过演示文稿的母版集合访问母版幻灯片。此示例检索第一张母版幻灯片并更改其背景类型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **删除母版幻灯片**

当母版幻灯片不再使用时，可以通过索引或引用将其删除。此示例将克隆的母版幻灯片分配给演示文稿，然后通过索引删除原始母版。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # 按索引删除未使用的原始母版幻灯片。
    presentation.getMasters().removeAt(0)

    # 或者，按引用删除未使用的母版幻灯片：
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **删除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # 删除所有未使用的母版幻灯片，包括标记为 Preserve 的幻灯片。
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```