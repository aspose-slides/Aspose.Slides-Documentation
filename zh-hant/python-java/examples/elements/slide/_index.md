---
title: 投影片
type: docs
weight: 10
url: /zh-hant/python-java/examples/elements/slide/
keywords:
- 程式碼範例
- 投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理投影片：使用 Python 程式碼範例為 PowerPoint 與 OpenDocument 簡報新增、存取、複製、重新排序與移除投影片。"
---
本篇文章提供示範範例，說明如何使用 **Aspose.Slides for Python via Java** 新增、存取、複製、重新排序與移除投影片。

依照[Installation](/slides/zh-hant/python-java/installation/)中的說明安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **Add a Slide**
若要新增投影片，首先需選取版面配置。本範例使用空白版面配置，在簡報中加入空的投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}
每個投影片版面配置皆源自母片，母片定義整體設計與版位結構。下圖說明了母片與其相關版面配置在 PowerPoint 中的組織方式。
{{% /alert %}}

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**
可使用從 0 開始的索引存取投影片，或根據參照取得投影片的索引。此作法在遍歷或修改特定投影片時非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 新增另一張空白投影片。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # 依索引存取投影片。
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # 從參照取得投影片的索引，然後依索引存取投影片。
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Clone a Slide**
複製既有投影片。複製後的投影片會自動加入投影片集合的末端。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Reorder Slides**
透過將投影片移動至新索引來變更順序。本範例將複製的投影片移動到第一個位置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Remove a Slide**
將投影片參照傳入投影片集合即可移除投影片。本範例先加入第二張投影片，然後移除原始投影片，僅保留新加入的投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```