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
- 柔和邊緣效果
- 效果格式
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 以進階的形狀效果轉換您的 PPT、PPTX 與 ODP 檔案——只需數秒即可打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓圖形凸顯，但它們與 [填色](/slides/zh-hant/python-net/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在圖形上創建逼真的反射、擴散圖形的發光等。

![圖形效果](shape-effect.png)

PowerPoint 提供六種可套用於圖形的效果。您可以對一個圖形套用一種或多種效果。

某些效果組合看起來比其他組合更好。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是兩種或以上效果的已知美觀組合。這樣，選擇預設後，您就不必浪費時間測試或組合不同效果以找尋漂亮的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 類別提供屬性和方法，讓您可在 PowerPoint 簡報中對圖形套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Python via .NET 支援圖形的外部和內部陰影。您可以自訂其顏色、方向、距離和模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可使卡片或面板在投影片背景中突顯。陰影延伸至圖形邊緣之外，產生圖形抬升於投影片之上的感覺。調整其顏色、方向、距離和模糊半徑，以符合模板的光線和樣式。

以下 Python 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) 套用到矩形上：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![陰影效果](shadow_effect.png)

### **套用內部陰影**

在還原模板的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至圖形外部，使其看起來抬升，而內部陰影則在其邊緣內側著色。

呼叫 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)，然後設定 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)。較大的 blur-radius 值會產生較柔和的邊緣。

以下 Python 範例建立一個淺藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![帶有內部陰影的淺藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在圖形的 effect format 上呼叫 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)。

## **套用反射效果**

在 Aspose.Slides for Python via .NET 中套用反射效果時，您可以為圖形新增類似鏡面的反射，並調整距離、透明度和大小等參數。此效果可提升簡報的美感，使圖形呈現更精緻、專業的外觀。只需簡單程式碼即可輕鬆實作，讓多個元件快速套用，以維持一致的設計。

以下 Python 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) 套用到圖形上：

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

在 Aspose.Slides for Python via .NET 中對圖形套用發光效果時，您可以在圖形周圍添加柔和、亮麗的光暈，調整顏色與大小等屬性。此效果有助於讓圖形突顯，並為簡報增添吸引人、引人注目的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 Python 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) 套用到圖形上：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![發光效果](glow_effect.png)

## **套用柔和邊緣效果**

在 Aspose.Slides for Python via .NET 中套用柔和邊緣效果時，您可以在圖形的邊緣建立平滑、模糊的過渡。此效果增添更細緻、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種圖形上實現理想的效果。

以下 Python 程式碼示範如何將 [柔和邊緣](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) 套用到圖形上：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![柔和邊緣效果](soft_edges_effect.png)

## **常見問題**

**我可以將多個效果套用到同一個圖形嗎？**

是的，您可以在單一圖形上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些圖形套用效果？**

您可以對各種圖形套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組圖形套用效果嗎？**

是的，您可以對群組圖形套用效果。效果會套用到整個群組。