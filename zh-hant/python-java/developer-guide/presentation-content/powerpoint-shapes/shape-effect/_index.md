---
title: 使用 Python 透過 Java 在簡報中套用形狀效果
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
description: "使用 Aspose.Slides for Python via Java 以先進的形狀效果轉換您的 PPT 和 PPTX 檔案——在幾秒鐘內打造引人注目、專業的投影片。"
---
## **介紹**

雖然 PowerPoint 中的效果可用於使形狀突出，但它們不同於 [fills](/slides/zh-hant/python-java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上創建逼真的反射、擴散形狀的發光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

* 某些效果組合比其他組合更好看。為此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是兩個或多個已知好看的效果組合。這樣，透過選取預設，您就不必浪費時間測試或組合不同的效果以找到理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

以下 Python 程式碼示範如何將外部陰影效果（[EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effectformat/#getOuterShadowEffect)）套用於矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **套用反射效果**

以下 Python 程式碼示範如何將反射效果套用於形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **套用發光效果**

以下 Python 程式碼示範如何將發光效果套用於形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **套用柔和邊緣效果**

以下 Python 程式碼示範如何將柔和邊緣效果套用於形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態感的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果將套用於整個群組。