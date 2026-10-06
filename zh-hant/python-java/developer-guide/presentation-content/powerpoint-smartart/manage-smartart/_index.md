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
description: "學習使用 Aspose.Slides for Python via Java 建立與編輯 PowerPoint SmartArt，透過清晰的程式碼範例加速投影片設計與自動化。"
---
## **概覽**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for Python via Java，您可以建立 SmartArt、從其節點讀取文字、更改其版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。若要從節點形狀讀取文字，請遍歷 [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes)，然後讀取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) 回傳的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。

此範例需要一個至少包含一張投影片且在該投影片上第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框列印到主控台。

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

SmartArt 版面配置決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。傳遞給 [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) 的位置和尺寸以點 (points) 計算。使用 [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) 來變更版面配置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選版面配置未將其顯示為可見圖表元素，隱藏的節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件加入節點，並檢查該新增節點的隱藏狀態。如果節點為隱藏，會列印訊息並儲存圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) 與 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。以零為起始的索引 `0` 代表第一個頂層節點；其子節點將使用所選的排列方式。然後儲存已修改的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **建立圖片組織圖**

圖片組織圖是一種設計用於包含影像佔位符的階層圖表的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。本範例會儲存包含影像佔位符的圖表，但不會將影像填入佔位符。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將舊版圖表轉換為形狀群組**

在升級現有簡報時，您可能需要更新最初在 PowerPoint 97–2003 中建立的組織圖。Aspose.Slides 將這些舊版圖表表示為 [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) 物件。使用 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) 將圖表轉換為形狀群組，以便編輯個別視覺元素。更多細節請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)。

轉換會在形狀集合中新增一個群組，而不會移除原始圖表。成功轉換後，請使用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) 移除原圖表，以免產生重複內容。在轉換之前，先將舊版圖表收集到清單中，這樣在新增或移除形狀時不會干擾迭代。

以下範例開啟一個簡報，搜尋每張投影片，將圖表轉換為形狀群組，並將更新後的簡報儲存為 PPTX。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

儲存的簡報在原本已轉換的舊版圖表位置上包含可編輯的形狀群組，不再保留原始圖表。於 PowerPoint 開啟 PPTX，即可編輯每個群組內的個別元素，例如文字、填色或位置。

## **常見問題**

**SmartArt 是否支援針對 RTL（從右到左）語言的鏡像或反轉？**

是的。當所選的 SmartArt 版面配置支援反轉時，[SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) 方法會將圖表方向從左至右切換為右至左，或反之。

**如何在保留格式的前提下，將 SmartArt 複製到同一投影片或其他簡報中？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) 來 [clone the SmartArt shape](/slides/zh-hant/python-java/shape-manipulations/)，或 [clone the whole slide](/slides/zh-hant/python-java/clone-slides/) 以複製包含 SmartArt 的整張投影片。兩種方法皆會保留大小、位置與格式。

**如何將 SmartArt 呈現在點陣圖以供預覽或網頁匯出？**

可將 [Render the slide](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 或整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt，如何找到特定的 SmartArt 物件？**

使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) 或 [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) 為 SmartArt 形狀指定獨特的替代文字或名稱，於 [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後確認匹配的形狀是 [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/)。