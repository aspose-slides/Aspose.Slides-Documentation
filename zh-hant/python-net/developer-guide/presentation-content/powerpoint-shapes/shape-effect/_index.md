---
title: 在 Python 中於簡報套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/python-net/shape-effect
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 暈光效果
- 柔化邊緣效果
- 效果格式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: 使用 Aspose.Slides for Python 以進階形狀效果轉換您的 PPT、PPTX 與 ODP 檔案——在數秒內打造引人注目、專業的投影片。
---
## **簡介**

雖然在 PowerPoint 中可以使用效果讓圖形更突出，但它們與 [填色](/slides/zh-hant/python-net/shape-formatting/#gradient-fill) 或外框不同。使用 PowerPoint 效果，您可以為圖形建立逼真的反射、擴散圖形的暈光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於圖形的效果。您可以對圖形套用一個或多個效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **Preset** 之下提供了選項。預設選項本質上是兩種或以上效果的已知好看組合。這樣，選取預設後，您就不必花時間測試或組合不同效果以找出不錯的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您在 PowerPoint 簡報中對圖形套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Python via .NET 支援圖形的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影讓卡片或面板在投影片背景上更醒目。陰影延伸至圖形邊緣之外，產生圖形高於投影片的感覺。調整顏色、方向、距離與模糊半徑，以配合範本的光源與樣式。

以下 Python 程式碼示範如何套用 [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 到矩形：

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

在重現範本的視覺樣式時，使用內部陰影讓卡片或面板呈現凹陷外觀。外部陰影會向圖形外側延伸，使其看起來突起；而內部陰影則在其邊緣內側著色。

呼叫 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，再設定 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。較大的模糊半徑會產生較柔和的邊緣。

此 Python 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後儲存為 PPTX 檔案：

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

若要移除內部陰影，請對圖形的 effect format 呼叫 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

### **套用、變更與移除預設陰影**

呼叫 [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) 並將陰影的 [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) 屬性設定為 [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) 的值。若要切換樣式，只需在相同圖形上變更預設。呼叫 [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) 即可在保留填色與外框的同時移除陰影。

此範例在同一投影片上並排顯示四個階段。每次變更前都會複製矩形，以便比較結果。兩個陰影皆偏移 10 點。225° 方向將第一個陰影放置在矩形的左上方，45° 方向則將第二個陰影放置在右下方。

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
| ![No shadow](preset_shadow_original.png) | ![Top-left drop shadow](preset_shadow_top_left.png) | ![Bottom-right drop shadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **套用反射效果**

要在 Aspose.Slides for Python via .NET 中套用反射效果，您可以為圖形新增鏡面式反射，調整距離、透明度與尺寸等參數。此效果可提升簡報的美感，使圖形看起來更精緻且具專業感。只需簡單程式碼，即可快速在多個元素間一致套用。

以下 Python 程式碼示範如何套用 [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 到圖形：

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

## **套用暈光效果**

要在 Aspose.Slides for Python via .NET 中為圖形套用暈光效果，您可以在圖形周圍添加柔和的發光光環，調整顏色與大小等屬性。此效果可讓圖形更突出，為簡報增添吸睛的視覺元素。只需少量程式碼，即可提升投影片的整體外觀。

以下 Python 程式碼示範如何套用 [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 到圖形：

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

![暈光效果](glow_effect.png)

## **套用柔化邊緣效果**

要在 Aspose.Slides for Python via .NET 中套用柔化邊緣效果，您可以在圖形的邊緣周圍創建平滑、模糊的過渡。此效果為設計增添更精緻、柔和的外觀，非常適合需要細緻呈現的版面。您可以輕鬆調整半徑等參數，在簡報的各種圖形上達到理想效果。

以下 Python 程式碼示範如何套用 [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 到圖形：

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

使用圖形模糊可柔化圖形的填色與外框，同時保持圖形可編輯。對圖形的 effect format 呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)。半徑以點為單位 (1/72 吋)：使用非負值，值越大模糊越強。半徑為零時外觀保持不變。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定控制效果的可見範圍。設定為 `False` 時，模糊會被裁切至原始繪製範圍（包括外框）。設定為 `True` 時，模糊可延伸至該範圍之外。兩種設定皆不會改變圖形的位置或尺寸。

以下比較使用相同的填色、外框與圖形尺寸。上排使用 `grow = False`；下排使用 `grow = True`。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

此 Python 範例建立一個橙色矩形，套用深藍色外框，先套用 5 點模糊，然後再次呼叫 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 變更為 15 點模糊，並分別儲存兩個模糊狀態；最後呼叫 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 並儲存未模糊的圖形。

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

圖形模糊同時影響填色與外框。柔化邊緣效果只淡化圖形的邊緣，而陰影模糊則只柔化陰影。影像轉換效果作用於影像內容；本範例直接對圖形的 effect format 套用模糊，未將圖形轉換為影像。

## **常見問題**

**我可以對同一個圖形套用多個效果嗎？**

可以，您可以將陰影、反射、暈光等不同效果組合在同一個圖形上，以建立更具動感的外觀。

**哪些圖形可以套用效果？**

您可以對各種圖形套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組圖形套用效果嗎？**

可以，您可以對群組圖形套用效果，效果會套用於整個群組。