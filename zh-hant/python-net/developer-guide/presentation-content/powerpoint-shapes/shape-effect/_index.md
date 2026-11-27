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
- 柔化邊緣效果
- 效果格式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 以先進的形狀效果轉換您的 PPT、PPTX 與 ODP 檔案——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們與 [填色](/slides/zh-hant/python-net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立真實的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一種或多種效果。

某些效果組合比其他組合更好看。基於此，PowerPoint 在 **預設** 下提供選項。預設選項本質上是兩種或多種效果的已知好看組合。這樣，選取預設後，您就不必浪費時間測試或組合不同效果來尋找好看的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Python via .NET 支援形狀的外部與內部陰影。您可以自訂顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上更突出。陰影超出形狀邊緣，營造形狀懸浮於投影片之上的感覺。調整顏色、方向、距離與模糊半徑，以配合範本的光源與樣式。

此 Python 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 套用至矩形：

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

#### **控制形狀旋轉時的陰影方向**

預設情況下，[OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) 為 `True`，因此陰影會隨形狀一起旋轉。若希望不同旋轉角度的形狀皆由相同方向受光，請將此屬性設為 `False` 並為它們的陰影設定相同的 [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/)。

範例建立兩個帶有灰色陰影、向右偏移 42 點 (`direction = 0`) 的箭頭。接著複製投影片，將兩個箭頭同時順時針旋轉 90°。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

在第二張投影片中，左側箭頭的陰影向下投射，而右側箭頭仍向右投射。兩個陰影的設定方向皆保持 0°。

![PowerPoint 在 90° 旋轉前後的渲染。兩個陰影最初都在右側。旋轉後，左側箭頭的陰影移至下方，右側箭頭的陰影仍保持在右側。](arrow-shadow-rotation.png)

### **套用內部陰影**

在還原範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹進的外觀。外部陰影延伸至形狀外，使其看起來抬升；內部陰影則在形狀邊緣內部著色。

呼叫 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，再設定 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。較大的模糊半徑會產生較柔和的邊緣。

此 Python 範例建立一個淡藍色卡片，套用深灰色內部陰影，並將結果儲存為 PPTX 檔案：

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

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請對形狀的 EffectFormat 呼叫 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

### **套用、變更與移除預設陰影**

呼叫 [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) 並將陰影的 [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) 屬性設為 [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) 的值。若要切換樣式，只需在同一形狀上變更預設。呼叫 [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) 可在保留填色與輪廓的情況下移除陰影。

此範例在同一投影片上並排顯示四個階段。每次變更前都會複製矩形，以便比較結果。兩個陰影皆偏移 10 點。225° 的方向將第一個陰影置於矩形左上方，45° 的方向則將第二個陰影置於右下方。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| 原始 | 第一個預設 | 第二個預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上投影陰影](preset_shadow_top_left.png) | ![右下投影陰影](preset_shadow_bottom_right.png) | ![移除後無陰影](preset_shadow_removed.png) |

## **套用反射效果**

要在 Aspose.Slides for Python via .NET 中套用反射效果，您可以為形狀新增鏡面反射，調整距離、透明度與大小等參數。此效果可提升簡報的美感，使形狀看起來更精緻、專業。只需簡單程式碼，即可快速在多個元素上套用，確保設計一致性。

此 Python 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 套用至形狀：

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

要在 Aspose.Slides for Python via .NET 中為形狀套用發光效果，您可以在形狀周圍添加柔和的光暈，調整顏色與大小等屬性。此效果有助於讓形狀突顯，為簡報增添吸睛的視覺元素。實作簡單，只需少量程式碼，即可提升投影片的整體觀感。

此 Python 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 套用至形狀：

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

## **套用柔化邊緣效果**

要在 Aspose.Slides for Python via .NET 中套用柔化邊緣效果，您可以在形狀的邊緣周圍建立平滑、模糊的過渡。此效果為設計增添細膩、精緻的外觀，非常適合需要柔和外觀的版面。您可以輕鬆調整半徑等參數，以在簡報的各種形狀上獲得理想效果。

此 Python 程式碼示範如何將 [柔化邊緣](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 套用至形狀：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![柔化邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可在保持形狀可編輯的前提下，使填色與輪廓變得柔和。對形狀的 EffectFormat 呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)。半徑以點 (1/72 吋) 為單位：使用非負值，數值越大模糊程度越強。半徑為 0 時外觀不變。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定控制效果的可視範圍。設定為 `False` 時，模糊會被裁切至原始繪製範圍（包含輪廓）。設定為 `True` 時，模糊可延伸至該範圍之外。此設定不會改變形狀的位置或尺寸。

以下比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = False`；下排使用 `grow = True`。

![原始矩形與模糊半徑 5 與 15 點的比較，分別在關閉與啟用 grow 時的效果](shape_blur_comparison.png)

此 Python 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，之後再次呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 改為 15 點模糊，兩個模糊狀態皆另存。最後呼叫 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 並保存未模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔化邊緣效果僅淡化形狀邊緣，而陰影模糊僅軟化陰影。圖像轉換效果作用於圖像內容；此範例直接對形狀的 EffectFormat 套用模糊，而不需先將形狀轉為圖像。

## **常見問題**

**我可以將多個效果套用到同一個形狀嗎？**

可以，您可以將陰影、反射、發光等不同效果組合於同一形狀，以打造更具動態感的外觀。

**哪些形狀可以套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用到整個群組。