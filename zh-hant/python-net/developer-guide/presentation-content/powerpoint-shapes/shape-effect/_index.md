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
description: "使用 Aspose.Slides for Python 以先進的形狀效果轉換您的 PPT、PPTX 和 ODP 檔案——在數秒內建立引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用來讓圖形突顯，但它們與[填充](/slides/zh-hant/python-net/shape-formatting/#gradient-fill)或輪廓不同。使用 PowerPoint 效果，您可以在圖形上創建逼真的反射、擴散圖形的發光等。

<img src="shape-effect.png" alt="形狀效果" style="zoom:50%;" />

* PowerPoint 提供六種可套用於圖形的效果。您可以對圖形套用一種或多種效果。 

* 某些效果組合看起來比其他的更好。基於此原因，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是一個已知的、外觀良好的兩種或多種效果的組合。透過選擇預設，您不必浪費時間測試或組合不同的效果來找出好的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/effectformat/) 類別中提供屬性和方法，讓您能將相同的效果套用於 PowerPoint 簡報中的圖形。

## **套用陰影效果**

以下 Python 程式碼示範如何將外部陰影效果 (`outer_shadow_effect`) 套用於矩形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **套用反射效果**

以下 Python 程式碼示範如何將反射效果套用於圖形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **套用發光效果**

以下 Python 程式碼示範如何將發光效果套用於圖形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **套用柔化邊緣效果**

以下 Python 程式碼示範如何將柔化邊緣套用於圖形：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以對同一圖形套用多個效果嗎？**

是的，您可以在單一圖形上結合不同的效果，例如陰影、反射與發光，以產生更具動感的外觀。

**我可以對哪些圖形套用效果？**

您可以對各種圖形套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組圖形套用效果嗎？**

是的，您可以對群組圖形套用效果。該效果會套用至整個群組。