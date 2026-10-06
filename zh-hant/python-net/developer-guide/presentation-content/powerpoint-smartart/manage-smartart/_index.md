---
title: 使用 Python 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/python-net/manage-smartart/
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
description: "學習使用 Aspose.Slides for Python via .NET 來建立與編輯 PowerPoint SmartArt，透過清晰的程式碼範例加速投影片設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for Python via .NET，您可以建立 SmartArt、從其節點讀取文字、變更其版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。若要從節點形狀讀取文字，請遍歷 [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/)，然後讀取由 [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) 回傳的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。

此範例需要一個至少包含一張投影片且在該投影片上第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框輸出至主控台。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 的版面配置控制節點的排列與連接方式。下列範例建立一個使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 值的 SmartArt 物件，將其變更為 `BASIC_PROCESS` 值，並儲存簡報。傳遞給 [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) 的位置與大小以點為單位。設定 [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) 以變更版面配置。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) 指示節點在 SmartArt 資料模型中是否為隱藏。即使所選版面配置未顯示它們為可見圖表元素，隱藏節點仍可能存在於結構中。

下列範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 值的 SmartArt 物件新增一個節點，並檢查該新增節點的隱藏狀態。若節點為隱藏，則會印出訊息並儲存圖表。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) 定義子節點在父節點底下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) 將子節點懸掛於左側、右側或兩側。

下列範例建立一個組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 值。零基索引 `0` 代表第一個最高層節點；其子節點會使用所選的排列方式。最後儲存已修改的簡報。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **建立圖片組織圖**

圖片組織圖是為包含圖像佔位符的階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 值。本範例會儲存含圖像佔位符的圖表；不會將圖像填入佔位符。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **將舊版圖表轉換為形狀群組**

在升級現有簡報時，您可能需要更新最初於 PowerPoint 97–2003 建立的組織圖。Aspose.Slides 將這些舊版圖表表示為 [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) 物件。使用 [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) 將圖表轉換為形狀群組，以便編輯個別視覺元素。詳情請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)。

轉換會在形狀集合中加入新群組，而不移除原始圖表。成功轉換後，請使用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) 移除原始圖表，以免產生重複內容。於轉換前先將舊版圖表收集到清單中，避免在增刪形狀時中斷遍歷。

下列範例開啟簡報、搜尋每張投影片、將圖表轉換為形狀群組，並將更新後的簡報另存為 PPTX。

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

已儲存的簡報在原本已轉換的舊版圖表位置上包含可編輯的形狀群組，且不會留下原始圖表。於 PowerPoint 開啟 PPTX 即可編輯每個群組內的個別元素，例如其文字、填色或位置。

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是的。當所選 SmartArt 版面配置支援反轉時，[SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) 屬性會將圖表方向由左至右切換為右至左，或反向切換。

**如何在保留格式的情況下，將 SmartArt 複製到相同投影片或其他簡報？**

您可以使用 [複製 SmartArt 形狀](/slides/zh-hant/python-net/shape-manipulations/) 搭配 [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) 或 [複製整張投影片](/slides/zh-hant/python-net/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方法皆能保留大小、位置與格式。

**如何將 SmartArt 轉換為點陣圖以供預覽或網路匯出？**

[渲染投影片](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 或將整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt 物件，如何找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定唯一的 [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) 或 [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) 值，於 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 中搜尋該值，然後確認相符的形狀為 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)。