---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/python-java/examples/elements/slide-transition/
keywords:
- 程式碼範例
- 投影片轉場
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 的程式碼範例，套用與移除投影片轉場，並設定自動投影片前移的時間，適用於 PPT、PPTX 與 ODP 簡報。"
---
本文示範如何在 **Aspose.Slides for Python via Java** 中套用投影片轉場效果與時間設定。

依照[Installation](/slides/zh-hant/python-java/installation/)中的說明安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 執行後再匯入 API。

## **新增投影片轉場**

對第一張投影片套用淡出轉場效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 套用淡出轉場。
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **取得投影片轉場**

讀取目前指派給投影片的轉場類型。

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

    # 取得轉場類型。
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **移除投影片轉場**

清除任何轉場效果。JPype 會將 Java 常數 `None` 以 `None_` 形式公開，因為 `None` 在 Python 中是保留字。

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

    # 移除轉場效果。
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **設定轉場持續時間**

指定投影片在自動前往下一張前的顯示時間。此範例在兩秒後自動前進，同時也允許以滑鼠點擊前進。此計時控制投影片的切換時機，而非轉場效果的速度。

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # 以毫秒為單位。
finally:
    presentation.dispose()
```