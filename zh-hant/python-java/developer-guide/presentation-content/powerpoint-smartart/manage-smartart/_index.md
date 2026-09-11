---
title: 使用 Python 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面配置類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習使用 Aspose.Slides for Python via Java 透過清晰的程式碼範例，建立與編輯 PowerPoint SmartArt，加速簡報設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for Python via Java，您可以建立 SmartArt、讀取其節點中的文字、變更版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見文字，請遍歷 [SmartArt.getAllNodes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#getAllNodes)，然後讀取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartshape/#getTextFrame) 返回的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/) 的 `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#isHidden) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使選取的版面配置未將其顯示為可見圖表元素，隱藏的節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件添加節點，並檢查該節點的隱藏狀態。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) 定義子節點在父節點下的排列方式。例如，您可以根據選取的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/organizationchartlayouttype/) 將子節點掛在左側、右側或兩側。

以下範例建立組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **建立圖片組織圖**

圖片組織圖是一種為包含圖像佔位符的階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件加入投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是的。當所選的 SmartArt 版面配置支援反轉時，[SmartArt.setReversed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/#setReversed) 方法可將圖表方向從左至右切換為右至左，或反向切換回來。

**如何在保留格式的情況下，將 SmartArt 複製到同一投影片或其他簡報中？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addClone) 來 [clone the SmartArt shape](/slides/zh-hant/python-java/shape-manipulations/)，或 [clone the whole slide](/slides/zh-hant/python-java/clone-slides/) 以複製包含 SmartArt 的整張投影片。兩種方式皆會保留大小、位置與格式。

**如何將 SmartArt 渲染為點陣圖以供預覽或網路匯出？**

將投影片或整個簡報[Render the slide](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片中有多個 SmartArt，如何找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定唯一的 [Shape.getAlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 或 [Shape.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getName) 值，於 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後確認匹配的形狀是 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/)。