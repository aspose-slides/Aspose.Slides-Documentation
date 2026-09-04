---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/python-java/examples/elements/ink/
keywords:
- 程式碼範例
- 墨跡
- 存取墨跡
- 移除墨跡
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 簡報中存取並移除墨跡形狀，支援 PPT、PPTX 以及 ODP 檔案。"
---
本文提供了使用 **Aspose.Slides for Python via Java** 存取現有墨跡形狀並將其移除的範例。

如同在 [Installation](/slides/zh-hant/python-java/installation/) 中描述的那樣安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

{{% alert color="info" title="Note" %}}
墨跡形狀代表來自專用設備的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。
{{% /alert %}}

## **存取墨跡**

讀取投影片上第一個墨跡形狀的標籤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # 根據需要使用 tag_name。
finally:
    presentation.dispose()
```

## **移除墨跡**

如果投影片上存在墨跡形狀，將其刪除。

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