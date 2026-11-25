---
title: Toepassen van vormeffecten in presentaties met Python via Java
linktitle: Vorm effect
type: docs
weight: 30
url: /nl/python-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zachte‑randen‑effect
- effectformaat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Transformeer uw PPT‑ en PPTX‑bestanden met geavanceerde vormeffecten met Aspose.Slides voor Python via Java — maak in enkele seconden indrukwekkende, professionele dia's."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vorm effect](shape-effect.png)

PowerPoint levert zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Enkele combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten waarvan bekend is dat ze er goed uitzien. Op deze manier hoef je bij het selecteren van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Een schaduweffect toepassen**

Aspose.Slides for Python via Java ondersteunt buiten‑ en binnenhoeken voor vormen. Je kunt hun kleur, richting, afstand en vervagingsradius aanpassen aan het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw reikt verder dan de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsradius aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Python‑code toont hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek toepast:
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

![Schaduweffect](shadow_effect.png)

### **Een binnenste schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon nabootst, gebruik je een binnenste schaduw om een kaart of paneel een ingetrokken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenste schaduw de binnenkant van de randen schaduurt.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan, en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de vervagingsradius geven zachtere randen.

Dit Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de vervagingsradius is 6 punten:
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

![Lichtblauwe rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

### **Een preset‑schaduw toepassen, wijzigen en verwijderen**

Roep [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) aan, gebruik vervolgens [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) om een [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) te selecteren. Om stijlen te wisselen, wijzig je de preset op dezelfde vorm. Roep [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) aan om de schaduw te verwijderen terwijl de vulling en omtrek behouden blijven.

Het voorbeeld kloont de rechthoek in elke fase zodat je alle vier de toestanden naast elkaar op één dia kunt vergelijken. Beide schaduwen zijn 10 punten verschoven. Een richting van 225° plaatst de eerste schaduw boven en links van de rechthoek. Een richting van 45° plaatst de tweede onder en rechts.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Origineel | Eerste preset | Tweede preset | Na verwijdering |
| :---: | :---: | :---: | :---: |
| ![Geen schaduw](preset_shadow_original.png) | ![Schaduw linksboven](preset_shadow_top_left.png) | ![Schaduw rechtsonder](preset_shadow_bottom_right.png) | ![Geen schaduw na verwijdering](preset_shadow_removed.png) |

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides for Python via Java, kun je een spiegelachtige reflectie aan vormen toevoegen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze Python‑code toont hoe je het [reflectie‑effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) op een vorm toepast:
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

![Reflectie‑effect](reflection_effect.png)

## **Een gloed‑effect toepassen**

Om een gloed‑effect op een vorm toe te passen in Aspose.Slides for Python via Java, kun je een zachte, lichte aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia's wordt verbeterd.

Deze Python‑code toont hoe je het [gloed‑effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) op een vorm toepast:
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

![Gloed‑effect](glow_effect.png)

## **Een zacht‑randen‑effect toepassen**

Om een zacht‑randen‑effect toe te passen in Aspose.Slides for Python via Java, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze Python‑code toont hoe je het [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:
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

![Zachte randen‑effect](soft_edges_effect.png)

## **Een vervagings‑effect toepassen**

Gebruik vormvervaging om de vulling en omtrek van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging opleveren. Een radius van nul laat het uiterlijk onveranderd.

De instelling [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) bepaalt de zichtbare grenzen van het effect. Met `False` wordt de vervaging begrensd tot de oorspronkelijke geschilderde grenzen, inclusief de omtrek. Met `True` kan de vervaging zich buiten die grenzen uitbreiden. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De vergelijking hieronder gebruikt gedurende het hele exemplaar dezelfde vulling, omtrek en vormafmetingen. De bovenste rij gebruikt `grow = False`; de onderste rij gebruikt `grow = True`.

![Originele rechthoek vergeleken met vervagingsradius van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Python‑voorbeeld maakt een oranje rechthoek met een donkerblauwe omtrek, past een vervaging van 5 punten toe, en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) aan en slaat de vorm zonder vervaging op.
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

Vormvervaging beïnvloedt zowel de vulling als de omtrek. Een zacht‑randen‑effect vervaagt de randen van de vorm, terwijl schaduwvervaging alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op de beeldinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten combineren, zoals schaduw, reflectie en gloed, op één vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op verschillende vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de gehele groep toegepast.