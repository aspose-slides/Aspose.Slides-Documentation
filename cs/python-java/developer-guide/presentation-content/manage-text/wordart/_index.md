---
title: Vytvořte a použijte efekty WordArt v Pythonu přes Java
linktitle: WordArt
type: docs
weight: 110
url: /cs/python-java/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt odrazu
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro Python přes Java. Tento podrobný průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v Pythonu přes Java."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvořit a přizpůsobit tyto efekty v prezentacích PowerPointu pomocí Aspose.Slides pro Python přes Java, bez nainstalovaného Microsoft Office.

## **Vytvoření jednoduché šablony WordArt a její použití na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, výplně vzorem a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Nastavte písmo na Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternstyle/#SmallGrid) s tmavě oranžovým popředím a bílým pozadím a poté přidejte černý obrys textu o šířce 1 bod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Výsledný text:

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použití dalších efektů WordArt**

Následující příklady ukazují, jak aplikovat stíny, odrazy, záři, transformace a 3D efekty na text.

### **Použití vnějších stínů**

Vnější stín přidává hloubku umístěním stínu za text. Můžete upravit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enableOuterShadowEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) a nastavuje černý stín s poloměrem rozostření 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnoty měřítka 100 zachovávají velikost stínu, zatímco horizontální zkosení ho naklání o 20 stupňů. Alfa transformace nastaví jeho neprůhlednost na 32 %:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Výsledný text:

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Poznámka" %}}
- Když jsou použity současně vnější a předdefinované stíny, použije se pouze vnější stín.
- Pokud jsou použity současně vnější a vnitřní stíny, výsledný efekt závisí na verzi PowerPointu. Například v PowerPointu 2013 se efekt zdvojnásobí, zatímco v PowerPointu 2007 se použije jen vnější stín.
{{% /alert %}}

### **Použití odrazových efektů**

Odraz vytvoří zrcadlovou kopii textu. Upravením jeho polohy, měřítka, rozostření a neprůhlednosti můžete kontrolovat vzhled.

Tento příklad volá [enableReflectionEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effectformat/#enableReflectionEffect) a otočí odraz vertikálně se škálou -100 %. Používá poloměr rozostření 0,5 bodu a vzdálenost 4,72 bodu. Neprůhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Výsledný text:

![Efekt odrazu](reflection_effect.png)

### **Použití efektu záře**

Záře přidává kolem textu měkký barevný obrys. Upravením barvy, neprůhlednosti a poloměru můžete efekt řídit.

Tento příklad volá [enableGlowEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effectformat/#enableGlowEffect) a použije červenou záři s neprůhledností 54 % a poloměrem 7 bodů:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Výsledný text:

![Efekt záře](glow_effect.png)

### **Použití transformací WordArt**

Transformace WordArt ohýbají, roztačují nebo deformují blok textu.

Nastavte [setTransform](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTransform) na [ArchUpPour](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textshapetype/#ArchUpPour), aby se celý rámec textu zakřivil směrem vzhůru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Výsledný text:

![Transformace WordArt](transform_effect.png)

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides pro Python přes Java poskytuje sadu předdefinovaných [transformation types](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Použití 3D efektů na tvary a text**

Můžete aplikovat 3D efekty na tvar nebo na jeho text. Šikmé řezy, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/) k přidání kulatých šikmých řezů, oranžové extruze a tmavě červeného konturu k obdélníku. Rozměry šikmých řezů, výška extruze, šířka konturu a hloubka jsou měřeny v bodech. Plastový materiál, vyvážené osvětlení otočené o 40 stupňů kolem osy Z a perspektivní kamera definují jeho vzhled:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Výsledný tvar:

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#getThreeDFormat). Menší šikmé řezy tvarují okraje písmen, zatímco extruze a osvětlení dodávají textu hloubku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Výsledný text:

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Poznámka" %}}
Aplikace 3D efektů na text nebo jejich tvary – a interakce mezi těmito efekty – je řízena konkrétními pravidly. Uvažujte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, scéna tvaru má přednost a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se použije jen na text.

Tyto chování souvisejí s metodami [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getLightRig) a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Pro zachování plochého a čitelného textu při zachování 3D formátování tvaru, viz [Udržet text plochý na 3D tvaru](/slides/cs/python-java/3d-presentation/) pro srovnání obou nastavení a kompletní Python příklad.

## **Často kladené otázky**

**Mohu použít efekty WordArt s různými fonty nebo písmy (např. arabské, čínské)?**

Ano, Aspose.Slides pro Python přes Java podporuje Unicode a funguje se všemi hlavními fonty a písmy. Efekty WordArt, jako jsou stín, výplň a obrys, lze použít bez ohledu na jazyk, i když dostupnost fontu a rendering mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky hlavní snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v hlavních snímcích, včetně zástupných symbolů názvu, zápatí nebo textu na pozadí. Změny provedené v rozložení hlavního snímku se projeví na všech souvisejících snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientové výplně, mohou mírně zvětšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu náhlednout výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage) nebo vykreslit samostatné tvary pomocí [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage). To vám umožní náhlednout výsledek v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.