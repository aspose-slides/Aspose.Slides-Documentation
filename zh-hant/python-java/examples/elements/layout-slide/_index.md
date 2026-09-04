---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/python-java/examples/elements/layout-slide/
keywords:
- 程式碼範例
- 版面投影片
- 新增版面投影片
- 存取版面投影片
- 移除版面投影片
- 未使用的版面投影片
- 複製版面投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 來管理版面投影片：在 PowerPoint 與 OpenDocument 簡報中新增、存取、移除、清理與複製版面。"
---
本篇文章示範如何使用 Aspose.Slides for Python via Java 來操作 **版面投影片**。版面投影片定義了普通投影片繼承的設計與格式。您可以新增、存取、複製以及移除版面投影片，亦可清理未使用的版面以減小簡報大小。

如需安裝套件，請參考 [Installation](/slides/zh-hant/python-java/installation/)。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **新增版面投影片**

建立自訂版面投影片以定義可重複使用的格式。以下範例在新的版面中加入文字方塊，然後建立兩張使用該版面的投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # 建立一個使用空白版面類型且具有自訂名稱的版面投影片。
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # 在版面投影片上新增文字方塊。
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # 新增兩張繼承該版面文字的投影片。
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **注意 1:** 版面投影片充當單一投影片的範本。您可以一次定義共同元素，並在多張投影片中重複使用。

> 💡 **注意 2:** 當您在版面投影片中加入形狀或文字時，所有基於該版面的投影片會自動顯示共享內容。  
> 以下螢幕擷圖顯示兩張從同一版面投影片繼承文字方塊的投影片。

![繼承版面內容的投影片](layout-slide-result.png)

## **存取版面投影片**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 依索引存取版面投影片。
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # 依類型存取版面投影片。
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **移除版面投影片**

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

## **移除未使用的版面投影片**

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

## **複製版面投影片**

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

> ✅ **摘要:** 版面投影片有助於在整個簡報中維持一致的格式。Aspose.Slides 讓您能依需求建立、管理、重複使用與清理版面。