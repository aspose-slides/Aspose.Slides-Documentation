---
title: 使用 Python 在簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/python-net/shape-effect
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 軟化邊緣效果
- 效果格式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 轉換您的 PPT、PPTX 和 ODP 檔案，套用進階形狀效果——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用於讓形狀突出，但它們與 [填色](/slides/zh-hant/python-net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **預設** 下提供選項。預設選項本質上是兩種或更多效果的已知好看組合。這樣，選取預設後，您就不必浪費時間測試或組合不同效果以尋找理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您能將相同的效果套用於 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for Python via .NET 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可使卡片或面板在投影片背景上突出。陰影會延伸至形狀邊緣之外，營造形狀浮於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以符合模板的光線與樣式。

此 Python 程式碼示範如何將 [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 套用於矩形：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![陰影效果](shadow_effect.png)

### **套用內部陰影**

在重製模板的視覺樣式時，使用內部陰影可為卡片或面板帶來凹陷的外觀。外部陰影延伸至形狀之外，使其看起來凸起；而內部陰影則為其邊緣內部加色。

呼叫 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然後設定 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。較大的模糊半徑值會產生較柔和的邊緣。

此 Python 範例建立一個淡藍色卡片，附帶深灰色內部陰影，並將其儲存為 PPTX 檔案：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![帶有內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請對形狀的 effect format 呼叫 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

## **套用反射效果**

在 Aspose.Slides for Python via .NET 中套用反射效果時，您可以為形狀加入類似鏡面的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美觀度，使形狀呈現更精緻、專業的外觀。只需簡單程式碼即可輕鬆實作，讓多個元素快速套用，保持設計一致性。

此 Python 程式碼示範如何將 [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 套用於形狀：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![反射效果](reflection_effect.png)

## **套用發光效果**

在 Aspose.Slides for Python via .NET 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀突出，為簡報增添吸引人且引人注目的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

此 Python 程式碼示範如何將 [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 套用於形狀：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![發光效果](glow_effect.png)

## **套用軟化邊緣效果**

在 Aspose.Slides for Python via .NET 中套用軟化邊緣效果時，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果帶來更細膩、精緻的外觀，適合需要柔和外形的設計。您可輕鬆調整半徑等參數，以在簡報中各種形狀上取得理想效果。

此 Python 程式碼示範如何將 [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 套用於形狀：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![軟化邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可柔化形狀的填色與輪廓，同時保持形狀可編輯。對形狀的 effect format 呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)。半徑以點 (1/72 吋) 為單位：使用非負值，較大的值會產生更強的模糊。半徑為零則保持外觀不變。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定控制效果的可見範圍。設定為 `False` 時，模糊被裁切至原始繪製範圍（包括輪廓）。設定為 `True` 時，模糊可延伸超出該範圍。兩種設定皆不會改變形狀的位置或尺寸。

下方比較圖在所有情況下皆使用相同的填色、輪廓與形狀尺寸。上列使用 `grow = False`；下列使用 `grow = True`。

![原始矩形與 5 與 15 點模糊半徑的比較（grow 停用與啟用）](shape_blur_comparison.png)

此 Python 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 將其更新為 15 點模糊。它會儲存兩個模糊狀態，之後呼叫 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 並儲存未模糊的形狀。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

形狀模糊同時影響填色與輪廓。軟化邊緣效果會淡化形狀的邊緣，而陰影模糊僅使陰影變得柔和。影像轉換效果作用於影像內容；本範例直接對形狀的 effect format 套用模糊，未將形狀轉換為影像。

## **FAQ**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果會套用至整個群組。