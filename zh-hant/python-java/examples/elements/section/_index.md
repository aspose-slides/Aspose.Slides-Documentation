---
title: 章節
type: docs
weight: 90
url: /zh-hant/python-java/examples/elements/section/
keywords:
- 程式碼範例
- 章節
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理簡報章節：以 Python 程式碼範例新增、存取、移除和重新命名章節。"
---
範例說明如何以程式方式使用 **Aspose.Slides for Python via Java** 來管理簡報的章節──新增、存取、移除及重新命名。

按照[Installation](/slides/zh-hant/python-java/installation/)中所述安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 正在執行時匯入 API。

## **Add a Section**

建立一個從特定投影片開始的章節。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 指定標示章節開始的投影片。
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Access a Section**

從簡報中讀取章節資訊。

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # 依索引存取章節。
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Remove a Section**

刪除先前新增的章節。

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

    # 移除第一個章節。
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Rename a Section**

變更既有章節的名稱。

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