---
title: Vytvořit a aplikovat efekty WordArt v Pythonu přes Java
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
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro Python přes Java. Tento podrobný návod pomáhá vývojářům vylepšit prezentace profesionálním textem v Pythonu přes Java."
---
## **Přehled**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint—bez nutnosti mít nainstalovaný Office. Tento článek poskytuje přehled o práci s WordArt, včetně toho, jak použít textové transformace, styly výplní, obrysy, stíny a další možnosti formátování, aby byl obsah vaší prezentace výraznější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

**Použití Aspose.Slides**

Nejprve vytvoříme jednoduchý text pomocí tohoto kódu v Pythonu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Dále zvětšíme velikost písma, aby byl efekt viditelnější:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Použití Microsoft PowerPoint**

Přejděte do nabídky efektů WordArt v Microsoft PowerPoint:

![Nabídka efektů WordArt v PowerPointu](image-20200930113926-1.png)

V pravém sloupci můžete vybrat předdefinovaný efekt WordArt. V levém sloupci můžete zadat nastavení pro nový WordArt.

Níže jsou některé dostupné parametry nebo možnosti:

![Možnosti formátování WordArt](image-20200930114015-3.png)

**Použití Aspose.Slides**

Zde použijeme vzorové vyplnění [PatternStyle.SmallGrid](https://reference.aspose.com/slides/cs/python-java/aspose.slides/patternstyle/#SmallGrid) pro text a přidáme černý okraj textu pomocí tohoto kódu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Výsledný text:

![Text s vzorem výplně a černým obrysem](image-20200930114108-4.png)

## **Použití dalších efektů WordArt**

**Použití Microsoft PowerPoint**

Z rozhraní aplikace můžete tyto efekty aplikovat na text, textový blok, tvar nebo podobný prvek:

![Efekty textu a tvaru v PowerPointu](image-20200930114129-5.png)

Například efekty Stín, Odraz a Záření lze použít na text; Formát 3D a Rotace 3D lze použít na textový blok; Efekt Měkké hrany lze použít na tvar (stále funguje, i když není nastaven efekt Formát 3D).

### **Aplikace stínových efektů**

Následující kód v Pythonu aplikuje stín pouze na text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

API Aspose.Slides podporuje tři typy stínů: [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/innershadow/) a [PresetShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presetshadow/).

S [PresetShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presetshadow/) můžete aplikovat stín na text pomocí předdefinovaných hodnot.

**Použití Microsoft PowerPoint**

V PowerPointu můžete použít jen jeden typ stínu. Zde je příklad:

![Nastavení stínu v PowerPointu](image-20200930114225-6.png)

**Použití Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: [InnerShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/innershadow/) a [PresetShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presetshadow/).

**Poznámky:**

- Když jsou použity současně [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/) a [PresetShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presetshadow/), použije se pouze efekt [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/).
- Pokud jsou použity současně [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/) a [InnerShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/innershadow/), výsledný či aplikovaný efekt závisí na verzi PowerPointu. Například ve verzi PowerPoint 2013 je efekt zdvojený, zatímco ve verzi PowerPoint 2007 se použije efekt [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/).

### **Aplikace odrazu na text**

Přidáme odraz k textu pomocí tohoto příkladu kódu v Pythonu přes Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Aplikace zářivého efektu na text**

Aplikujeme zářivý efekt na text, aby zazářil nebo vynikl, pomocí tohoto kódu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Výsledek operace:

![Text se zářivým efektem](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Můžete měnit parametry stínu, odrazu a záře. Vlastnosti efektů se nastavují samostatně pro každou část textu.
{{% /alert %}}

### **Použití transformací ve WordArt**

Použijte [TextFrameFormat.setTransform](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTransform) k transformaci celého textového bloku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Výsledek:

![Text s oblou transformací](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Microsoft PowerPoint i Aspose.Slides pro Python přes Java poskytují určitý počet předdefinovaných typů transformací.
{{% /alert %}}

**Použití PowerPoint**

Pro přístup k předdefinovaným typům transformací přejděte na: **Formát** → **TextEffect** → **Transform**

**Použití Aspose.Slides**

Pro výběr typu transformace použijte výčtový typ [TextShapeType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textshapetype/).

### **Aplikace 3D efektů na text a tvary**

Aplikujeme 3D efekt na textový tvar pomocí tohoto ukázkového kódu:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Výsledný text a jeho tvar:

![Textový tvar s 3D efekty](image-20200930114816-9.png)

Aplikujeme 3D efekt na text pomocí tohoto kódu v Pythonu:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Výsledek operace:

![Text s 3D efekty](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Aplikace 3D efektů na text nebo jeho tvary a interakce mezi efekty jsou založeny na určitých pravidlech.

Zvažte scénu pro text a tvar, ve kterém je text umístěn. 3D efekt obsahuje reprezentaci 3D objektu a scénu, ve které je objekt umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, má prioritu scéna tvaru — scéna textu se ignoruje.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- V opačném případě — když tvar původně nemá 3D efekt — tvar je plochý a 3D efekt se aplikuje jen na text.

Tato pravidla se vztahují k metodám [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getLightRig) a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Aplikace vnějšího stínu na text**

Aspose.Slides pro Python přes Java poskytuje třídy [OuterShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/outershadow/) a [InnerShadow](https://reference.aspose.com/slides/cs/python-java/aspose.slides/innershadow/), které umožňují aplikovat stínové efekty na text v [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/). Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte na snímek obdélníkový tvar.
4. Získejte textový rámec přidružený k tvaru.
5. Zakážte výplň tvaru.
6. Aktivujte efekt vnějšího stínu.
7. Nastavte poloměr rozostření stínu.
8. Nastavte směr stínu.
9. Nastavte vzdálenost stínu.
10. Zarovnejte stín do levého horního rohu.
11. Nastavte barvu stínu na černou.
12. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

Tento ukázkový kód v Pythonu přes Java — implementace výše uvedených kroků — ukazuje, jak aplikovat efekt vnějšího stínu na text:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Získat referenci na snímek
    slide = presentation.getSlides().get_Item(0)

    # Přidat AutoShape typu Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Přidat TextFrame k obdélníku
    auto_shape.addTextFrame("Aspose TextBox")

    # Zakázat výplň tvaru pro případ, že chceme získat stín textu
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Přidat vnější stín a nastavit všechny potřebné parametry
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Uložit prezentaci na disk
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aplikace vnitřního stínu na tvary**

Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek.
3. Přidejte obdélníkový tvar.
4. Aktivujte efekt vnitřního stínu.
5. Nastavte všechny potřebné parametry.
6. Nastavte typ barvy stínu na použití barvy motivu.
7. Zvolte barvu motivu.
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

Tento ukázkový kód (na základě výše uvedených kroků) ukazuje, jak aplikovat efekt vnitřního stínu na text v tvaru v Pythonu přes Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Získat referenci na snímek
    slide = presentation.getSlides().get_Item(0)

    # Přidat AutoShape typu Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Přidat TextFrame k obdélníku
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Povolit efekt vnitřního stínu
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Nastavit všechny potřebné parametry
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Nastavit ColorType jako Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Nastavit schématickou barvu
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Uložit prezentaci
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu použít efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako jsou stín, výplň a obrys, lze aplikovat bez ohledu na jazyk, i když dostupnost písma a vykreslování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky masteru snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v master‑snímku, včetně zástupných textů titulku, zápatí nebo pozadí. Změny provedené v master rozložení se projeví ve všech přidružených snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientní výplně, mohou mírně zvětšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu zobrazit výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [Shape.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) nebo [Slide.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/#getImage). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.