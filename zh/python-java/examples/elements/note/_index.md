---
title: 备注
type: docs
weight: 240
url: /zh/python-java/examples/elements/note/
keywords:
- 代码示例
- 备注
- 演讲者备注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中处理幻灯片备注：在 PowerPoint 和 OpenDocument 演示文稿中添加、读取、删除和更新演讲者备注。"
---
本文演示如何使用 **Aspose.Slides for Python via Java** 添加、读取、删除和更新备注幻灯片。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装该包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后再导入 API。

## **添加备注幻灯片**

创建一个备注幻灯片并为其分配文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **访问备注幻灯片**

读取现有备注幻灯片中的文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **删除备注幻灯片**

删除与幻灯片关联的备注幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **更新备注文本**

更改备注幻灯片的文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```