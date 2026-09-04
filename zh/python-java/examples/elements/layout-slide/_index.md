---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/python-java/examples/elements/layout-slide/
keywords:
- 代码示例
- 布局幻灯片
- 添加布局幻灯片
- 访问布局幻灯片
- 删除布局幻灯片
- 未使用的布局幻灯片
- 克隆布局幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理布局幻灯片：在 PowerPoint 和 OpenDocument 演示文稿中添加、访问、删除、清理以及克隆布局。"
---
本文演示如何使用 Aspose.Slides for Python via Java 处理 **布局幻灯片**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，还可以清理未使用的布局以减小演示文稿的尺寸。

按 [Installation](/slides/zh/python-java/installation/) 中的说明安装包。每个示例都会在启动 JVM 前导入 `asposeslides`，然后在 JVM 运行后导入 API。

## **添加布局幻灯片**

创建自定义布局幻灯片，以定义可复用的格式。下面的示例向新布局中添加一个文本框，然后创建两个使用该布局的幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # 创建一个具有空白布局类型和自定义名称的布局幻灯片。
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # 向布局幻灯片添加一个文本框。
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # 添加两个继承布局文本的幻灯片。
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **注意 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义公共元素，并在多个幻灯片中重复使用它们。

> 💡 **注意 2:** 当您向布局幻灯片添加形状或文本时，所有基于该布局的幻灯片会自动显示共享内容。  
> 以下截图展示了两个幻灯片从同一布局幻灯片继承文本框的效果。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **访问布局幻灯片**

通过索引或布局类型（例如空白、标题或章节标题）访问布局幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 按索引访问布局幻灯片。
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # 按类型访问布局幻灯片。
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **删除布局幻灯片**

当不再需要时删除特定的布局幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **删除未使用的布局幻灯片**

删除未被任何普通幻灯片使用的布局幻灯片，以减小演示文稿的尺寸。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **克隆布局幻灯片**

复制布局幻灯片并将副本添加到布局幻灯片集合的末尾。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **摘要:** 布局幻灯片帮助在整个演示文稿中保持一致的格式。Aspose.Slides 让您能够根据需要创建、管理、复用和清理布局。