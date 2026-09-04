---
title: 母版投影片
type: docs
weight: 30
url: /zh-hant/python-java/examples/elements/master-slide/
keywords:
- 程式碼範例
- 母版投影片
- 新增母版投影片
- 存取母版投影片
- 移除母版投影片
- 未使用的母版投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理母版投影片：在 PowerPoint 與 OpenDocument 簡報中建立、存取、移除及清理母版。"
---
母版投影片構成 PowerPoint 中投影片繼承階層的最高層級。**母版投影片** 定義背景、標誌與文字格式等通用設計元素。**版面投影片** 繼承自母版投影片，**一般投影片** 繼承自版面投影片。

本文示範如何使用 **Aspose.Slides for Python via Java** 來建立、修改與管理母版投影片。

按照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例在啟動 JVM 前先匯入 `asposeslides`，然後在 JVM 運行後匯入 API。

## **新增母版投影片**

此範例說明如何透過複製預設母版來建立新的母版投影片。接著透過版面繼承將公司名稱橫幅新增至所有投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 複製預設的母版投影片。
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # 在母版投影片頂部加入公司名稱橫幅。
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # 將新母版投影片指派給版面投影片。
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # 將版面投影片指派給簡報中的第一張投影片。
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
母版投影片提供在所有投影片上套用一致品牌或共享設計元素的方式。對母版所做的變更會自動反映在相依的版面與一般投影片上。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
新增至母版投影片的圖形與格式會被版面投影片繼承，進而被使用該版面的所有一般投影片繼承。下方圖片說明了在母版投影片中加入文字方塊會自動在最終投影片上呈現的方式。
{{% /alert %}}

![母版繼承範例](master-slide-banner.png)

## **存取母版投影片**

您可以透過簡報的母版集合來存取母版投影片。此範例取得第一個母版投影片並變更其背景類型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **移除母版投影片**

在不再使用後，母版投影片可以依索引或參考方式移除。此範例將複製的母版投影片指派給簡報，然後依索引移除原始母版。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # 依索引移除未使用的原始母版投影片。
    presentation.getMasters().removeAt(0)

    # 或者，依參考移除未使用的母版投影片：
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **移除未使用的母版投影片**

某些簡報包含未使用的母版投影片。移除這些投影片可協助減少檔案大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # 移除所有未使用的母版投影片，包括標記為保留的投影片。
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```