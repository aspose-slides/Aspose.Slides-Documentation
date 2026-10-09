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
description: "使用 Aspose.Slides for Python via Java 以先進的形狀效果轉換您的 PPT 與 PPTX 檔案，於數秒內建立引人注目且專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀更突出，但它們不同於 [填色](/slides/zh-hant/python-java/shape-formatting/#gradient-fill) 或輪廓。利用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![陰影效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一種或多種效果。

某些效果組合看起來比其他組合更好。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項是已知外觀良好的兩種以上效果的組合。透過選取預設，您不必浪費時間測試或組合不同效果以找出良好組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Python via Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報設計。

### **套用外部陰影**

使用外部陰影讓卡片或面板於投影片背景中脫穎而出。陰影超出形狀邊緣，營造形狀抬升於投影片之上的印象。調整其顏色、方向、距離與模糊半徑，以匹配範本的光線與樣式。

此 Python 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用於長方形：

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

在重現範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來抬升；而內部陰影則在邊緣內側著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect)，再設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) 返還的陰影。較大的模糊半徑值會產生較柔和的邊緣。

此 Python 範例建立淡藍色卡片，內部具有深灰色陰影，並將其另存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

若要移除內部陰影，請對形狀的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **套用反射效果**

在 Aspose.Slides for Python via Java 中套用反射效果時，您可以為形狀加入鏡面般的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀更具精緻與高級感。透過簡單程式碼即可輕鬆實作，快速於多個元素間套用，保持設計一致性。

此 Python 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) 套用於形狀：

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

在 Aspose.Slides for Python via Java 中套用發光效果時，您可以在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀突顯，為簡報增添吸睛的視覺元素。只需少量程式碼即可實作，提升投影片的整體觀感。

此 Python 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) 套用於形狀：

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

在 Aspose.Slides for Python via Java 中套用柔和邊緣效果時，您可以為形狀的邊緣創建平滑、模糊的過渡。此效果增添更細膩、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報的各種形狀上實現理想效果。

此 Python 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用於形狀：

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

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以打造更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，您可以對群組形狀套用效果，該效果會套用至整個群組。