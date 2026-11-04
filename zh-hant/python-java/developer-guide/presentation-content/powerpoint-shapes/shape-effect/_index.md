---
title: 使用 Python via Java 在簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/python-java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將您的 PPT 與 PPTX 檔案轉換為高級形狀效果——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於使形狀突出，但它們與 [填色](/slides/zh-hant/python-java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果的組合比其他組合更好看。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項是已知外觀良好的兩種或多種效果的組合。透過選取預設，您不必浪費時間測試或組合不同的效果以找到合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您能將相同的效果套用至 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for Python via Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可使卡片或面板在投影片背景上突出。陰影延伸至形狀邊緣之外，產生形狀浮於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以符合模板的光線與樣式。

此 Python 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用到矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![陰影效果](shadow_effect.png)

### **套用內部陰影**

在重現模板的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來抬起；而內部陰影則在其邊緣內側著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) 回傳的陰影。較大的模糊半徑值會產生較柔和的邊緣。

此 Python 範例建立一張淡藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **套用反射效果**

在 Aspose.Slides for Python via Java 中套用反射效果時，您可以為形狀新增鏡面般的反射，並調整距離、透明度與尺寸等參數。此效果能提升簡報的美感，使形狀更具精緻與高雅的外觀。透過簡單的程式碼即可輕鬆實作，快速套用於多個元素以維持設計的一致性。

此 Python 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) 套用到形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![反射效果](reflection_effect.png)

## **套用發光效果**

在 Aspose.Slides for Python via Java 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，並調整顏色與尺寸等屬性。此效果有助於凸顯形狀，為簡報增添吸睛且具吸引力的視覺元素。透過極少的程式碼即可輕鬆實作，提升投影片的整體外觀。

此 Python 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) 套用到形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![發光效果](glow_effect.png)

## **套用柔和邊緣效果**

在 Aspose.Slides for Python via Java 中套用柔和邊緣效果時，您可以在形狀的邊緣產生平滑、模糊的過渡。此效果帶來更細緻且精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種形狀上達到理想的效果。

此 Python 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用到形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![柔和邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可柔化形狀的填色與輪廓，同時保持形狀可編輯。對形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 吋) 為單位：使用非負值，較大的值會產生更強的模糊。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) 設定控制效果的可見範圍。設為 `False` 時，模糊會被裁剪至原始繪製範圍，包括輪廓。設為 `True` 時，模糊可延伸超出該範圍。這兩種設定皆不會更改形狀的位置或尺寸。

以下比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = False`；下排使用 `grow = True`。

![原始矩形與模糊半徑 5 與 15 點比較，grow 停用與啟用](shape_blur_comparison.png)

此 Python 範例建立一個橙色矩形並加上深藍色輪廓，先套用 5 點的模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) 將其更新為 15 點的模糊。它會將兩個模糊狀態儲存，之後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未模糊的形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊僅使陰影變軟。影像轉換效果作用於影像內容；此範例直接對形狀的 effect format 套用模糊，未將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，如陰影、反射和發光，以打造更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。效果會套用至整個群組。