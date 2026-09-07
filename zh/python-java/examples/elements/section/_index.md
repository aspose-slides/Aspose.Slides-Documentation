---
title: 章节
type: docs
weight: 90
url: /zh/python-java/examples/elements/section/
keywords:
- 代码示例
- 章节
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理演示文稿章节：使用 Python 代码示例添加、访问、删除和重命名章节。"
---
使用 **Aspose.Slides for Python via Java** 以编程方式管理演示文稿章节的示例——添加、访问、删除和重命名。

按照 [Installation](/slides/zh/python-java/installation/) 中的说明安装软件包。每个示例在启动 JVM 之前导入 `asposeslides`，在 JVM 运行后再导入 API。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 指定标记章节开始的幻灯片。
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **访问章节**

读取演示文稿中的章节信息。

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # 通过索引访问章节。
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **删除章节**

删除先前添加的章节。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # 删除第一个章节。
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **重命名章节**

更改现有章节的名称。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```