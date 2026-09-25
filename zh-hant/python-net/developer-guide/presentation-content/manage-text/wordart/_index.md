---
title: 在 Python 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/python-net/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 反射效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中建立與自訂 WordArt 效果。此逐步指南協助開發者使用 Python 在簡報中加入專業文字效果。"
---
## **概觀**

WordArt 效果讓您可以使用填充、輪廓、陰影、反射、發光、變形和 3D 格式來設定文字樣式。本文說明如何在未安裝 Microsoft Office 的情況下，使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中建立和自訂這些效果。

## **建立簡單的 WordArt 範本並套用至文字**

以下範例透過設定文字、字型、圖案填充與輪廓來建立簡單的 WordArt 風格。

每個範例都會建立新的簡報，並在第一張投影片加入一個矩形；不需要輸入檔案。第一個範例將文字設定為「Aspose.Slides」。形狀的位置與尺寸以點為單位測量：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

將字型設定為 36 點的 Arial Black，以使格式更明顯：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

套用 [SMALL_GRID](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/patternstyle/) 圖案，前景為深橙色、背景為白色，然後加上寬度為 1 點的黑色文字輪廓：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

產生的文字：

![簡單的 WordArt 範本](WordArt_template.png)

## **套用其他 WordArt 效果**

以下範例示範如何對文字套用陰影、反射、發光、變形和 3D 效果。

### **套用外部陰影效果**

外部陰影透過在文字後方放置陰影來增加深度。您可以自訂其顏色、方向、距離、模糊半徑、比例與斜切。

此範例呼叫 [enable_outer_shadow_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) 並設定黑色陰影，模糊半徑為 4 點、方向為 230 度、距離為 30 點。比例值為 100 可保留陰影大小，而水平斜切使其傾斜 20 度。alpha 變換將不透明度設為 32%：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

產生的文字：

![外部陰影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 當同時使用外部陰影和預設陰影時，僅套用外部陰影。
- 若同時使用外部陰影和內部陰影，最終效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；而在 PowerPoint 2007 中，僅套用外部陰影。
{{% /alert %}}

### **套用反射效果**

反射會產生文字的鏡像複本。調整其位置、比例、模糊與不透明度即可控制外觀。

此範例呼叫 [enable_reflection_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/effectformat/enable_reflection_effect/) 並以 -100% 的比例垂直翻轉反射。使用 0.5 點的模糊半徑與 4.72 點的距離。沿反射的 0% 至 60% 位置，不透明度從 60% 降至 0.9%：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

產生的文字：

![反射效果](reflection_effect.png)

### **套用發光效果**

發光會在文字周圍添加柔和的彩色輪廓。調整顏色、不透明度與半徑即可控制此效果。

此範例呼叫 [enable_glow_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/effectformat/enable_glow_effect/) 並套用 54% 不透明度、半徑為 7 點的紅色發光：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

產生的文字：

![發光效果](glow_effect.png)

### **套用 WordArt 變形**

WordArt 變形會彎曲、拉伸或扭曲文字區塊。

將 [transform](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/transform/) 設為 [ARCH_UP_POUR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textshapetype/) 以使整個文字框向上彎曲：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

產生的文字：

![WordArt 變形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET 提供一組預定義的 [變形類型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textshapetype/)。
{{% /alert %}}

### **套用 3D 效果於圖形與文字**

您可以對圖形或其文字套用 3D 效果。斜角、擠出、光照與相機設定會決定最終外觀。

以下範例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 為矩形加入圓形斜角、橙色擠出與深紅色輪廓。斜角尺寸、擠出高度、輪廓寬度與深度皆以點為單位。塑膠材質、繞 Z 軸旋轉 40 度的均衡光照，以及透視相機共同定義其外觀：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![圖形 3D 效果](shape_3D_effect.png)

此範例透過 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/three_d_format/) 為文字套用類似的 3D 格式。較小的斜角塑造字母邊緣，而擠出與光照則為文字提供深度：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

![文字 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
將 3D 效果套用於文字或其圖形——以及這些效果之間的互動——受到特定規則的約束。請考慮同時包含文字與其所在圖形的場景。3D 效果包括物件的 3D 表示以及其所在的場景。

- 若同時對圖形與文字設定場景，則以圖形的場景為主，文字的場景會被忽略。
- 若圖形沒有自己的場景但具有 3D 表示，則使用文字的場景。
- 若圖形根本沒有 3D 效果，則視為平面，僅對文字套用 3D 效果。

這些行為與 [ThreeDFormat.light_rig](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/light_rig/) 與 [ThreeDFormat.camera](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/camera/) 屬性相關。
{{% /alert %}}

若要在保留圖形 3D 格式的同時讓文字保持平面且易讀，請參閱 [Keep Text Flat on a 3D Shape](/slides/zh-hant/python-net/3d-presentation/) 以比較兩種設定並取得完整的 Python 範例。

## **常見問題**

**我能在不同字型或文字系統（例如阿拉伯文、中文）中使用 WordArt 效果嗎？**

是的，Aspose.Slides for Python via .NET 支援 Unicode，且可與所有主流字型與文字系統一起使用。無論語言為何，都可以套用如陰影、填充與輪廓等 WordArt 效果，但字型的可用性與呈現可能取決於系統字型。

**我可以將 WordArt 效果套用於投影片母片元素嗎？**

是的，您可以將 WordArt 效果套用於母片投影片上的圖形，包括標題佔位符、頁腳或背景文字。對母片版面的變更會反映至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會有少許影響。陰影、發光與漸層填充等 WordArt 效果會因新增格式資訊而略微增加檔案大小，但差異通常可忽略不計。

**我能在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

是的，您可以使用 [Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/) 將包含 WordArt 的投影片轉換為圖片（例如 PNG、JPEG），或使用 [Shape.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/) 轉換單一圖形。這樣即可在記憶體或螢幕上預覽結果，無需先儲存或匯出完整簡報。