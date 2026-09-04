---
title: 頁首與頁腳
type: docs
weight: 220
url: /zh-hant/python-java/examples/elements/header-footer/
keywords:
- 程式碼範例
- 頁首
- 頁腳
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 控制投影片的頁首與頁腳：在 PPT、PPTX 與 ODP 簡報中新增日期、投影片編號和自訂文字。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 新增頁腳並更新日期與時間佔位符。

依照[Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後再匯入 API。

## **新增頁腳**

在投影片的頁腳區域加入文字並使其可見。

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

## **更新日期與時間**

修改投影片上的日期與時間佔位符。

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