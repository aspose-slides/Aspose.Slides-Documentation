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
description: "了解如何使用 Aspose.Slides for Python via .NET 以清晰的程式範例建立與編輯 PowerPoint SmartArt，加速投影片設計與自動化。"
---
## **概觀**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for Python via .NET，您可以建立 SmartArt、從其節點讀取文字、變更其版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。要讀取可見文字，請遍歷 [SmartArt.all_nodes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/all_nodes/)，然後讀取由 [SmartArtShape.text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartshape/text_frame/) 返回的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置控制節點的排列與連接方式。下列範例建立一個使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 值的 SmartArt 物件，將其變更為 `BASIC_PROCESS` 值，並儲存簡報。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **檢查 SmartArt 節點是否為隱藏狀態**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartnode/is_hidden/) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選版面配置未將它們顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

下列範例將一個節點加入使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 值的 SmartArt 物件，並檢查該節點的隱藏狀態。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

下列範例建立一個組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 值。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **建立圖片組織圖**

圖片組織圖是為包含圖像佔位符的階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 值。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是的。當所選 SmartArt 版面配置支援反轉時，屬性 [SmartArt.is_reversed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/is_reversed/) 會將圖表方向從左至右切換為右至左，或反之。

**如何在同一投影片或其他簡報中複製 SmartArt 同時保留格式？**

您可以使用 [ShapeCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_clone/) 來[複製 SmartArt 形狀](/slides/zh-hant/python-net/shape-manipulations/)，或[複製包含 SmartArt 的整個投影片](/slides/zh-hant/python-net/clone-slides/)。兩種方法皆會保留大小、位置與格式。

**如何將 SmartArt 渲染為光柵圖像以供預覽或網頁匯出？**

[將投影片](/slides/zh-hant/python-net/convert-powerpoint-to-png/)或整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt，如何找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定獨特的 [Shape.alternative_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/alternative_text/) 或 [Shape.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/name/) 值，在 [Slide.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/shapes/) 中搜尋該值，然後確認匹配的形狀是 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/)。