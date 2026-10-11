---
title: 使用 Java 的 Python 管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/python-java/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 母版备注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高您的工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。本主题介绍此功能，包括如何删除备注以及如何对演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您从任意幻灯片删除备注并对现有备注应用样式。开发人员可以通过以下方式删除备注：

- 从演示文稿的特定幻灯片中删除备注。
- 从演示文稿的所有幻灯片中删除备注。

要读取或更改备注页面尺寸、切换方向并检查导出行为，请参阅[Notes Page Size](/slides/zh/python-java/notes-size/)。

## **从幻灯片中删除备注**

可以按如下示例从特定幻灯片中删除备注：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化一个表示演示文稿文件的 Presentation 对象。
presentation = Presentation("presWithNotes.pptx")
try:
    # 从第一张幻灯片中删除备注。
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # 将演示文稿保存到磁盘。
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **从演示文稿中删除备注**

可以按如下示例从演示文稿的所有幻灯片中删除备注：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 实例化一个表示演示文稿文件的 Presentation 对象。
presentation = Presentation("presWithNotes.pptx")
try:
    # 从所有幻灯片中删除备注。
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # 将演示文稿保存到磁盘。
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **添加备注样式**

[MasterNotesSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslide/) 类的 [getNotesStyle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/masternotesslide/#getNotesStyle) 方法提供对备注文本样式的访问。下面的示例演示了实现方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# 实例化一个表示演示文稿文件的 Presentation 对象。
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # 获取母版备注幻灯片的文本样式。
        notes_style = notes_master.getNotesStyle()

        # 为第一级段落设置符号项目符号。
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：幻灯片具有一个 [NotesSlideManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslidemanager/) 并且有一个 [getNotesSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notesslidemanager/#getNotesSlide) 方法，该方法返回备注对象，如果没有备注则返回 `None`。

**库在不同 PowerPoint 版本的备注支持上有差异吗？**

该库面向广泛的 Microsoft PowerPoint 格式（97 及以后版本）以及 ODP；这些格式内均支持备注，无需依赖已安装的 PowerPoint 副本。