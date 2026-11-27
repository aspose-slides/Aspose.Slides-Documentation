---
title: Vormeffecten toepassen in presentaties met Python via Java
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/python-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- effect met zachte randen
- effectformaat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Python via Java—maak in enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-java/shape-formatting/#gradient-fill) of randen. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm maken, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten die bekend staan als goed uitziend. Op deze manier hoef je door een preset te kiezen geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/)‑klasse die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Een schaduweffect toepassen**

Aspose.Slides voor Python via Java ondersteunt buiten- en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervaagstraal aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervaagstraal aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Python‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek toepast:

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

#### **Schaduwrichting regelen wanneer een vorm roteert**

Standaard roteert de buitenste schaduw mee met de vorm. Om vormen met verschillende rotaties dezelfde lichtinval te laten lijken, roep je [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) aan met `False` en gebruik je [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) om hun schaduwen dezelfde richting te geven.

Het voorbeeld maakt twee blauwe pijlen met grijze schaduwen die 42 punten naar rechts zijn verschoven (0°). Vervolgens wordt de dia gekopieerd en worden beide pijlen 90° met de klok mee geroteerd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Op de tweede dia werpt de linkerpijl zijn schaduw naar beneden, terwijl de rechterpijl zijn schaduw nog steeds naar rechts werpt. De geconfigureerde richting blijft 0° voor beide schaduwen.

![PowerPoint-weergave vóór en na een rotatie van 90°. Beide schaduwen beginnen rechts. Na rotatie beweegt de schaduw onder de linkerpijl en blijft rechts van de rechterpijl.](arrow-shadow-rotation.png)

### **Een binnenschaduw toepassen**

Wanneer je de visuele stijl van een sjabloon reproduceert, gebruik je een binnenschaduw om een kaart of paneel een verzonken uitstraling te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenschaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere vervaagstraalwaarden zorgen voor zachtere randen.

Dit Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de vervaagstraal is 6 punten:

```python
import jpace
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

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

### **Een preset‑schaduw toepassen, wijzigen en verwijderen**

Roep [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) aan en gebruik vervolgens [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) om een [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) te selecteren. Om stijlen te wisselen, wijzig je het preset op dezelfde vorm. Roep [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) aan om de schaduw te verwijderen terwijl de vulling en de omtrek behouden blijven.

Het voorbeeld kloont de rechthoek in elke fase zodat je alle vier de toestanden naast elkaar op één dia kunt vergelijken. Beide schaduwen zijn 10 punten verschoven. Een richting van 225° plaatst de eerste schaduw boven en links van de rechthoek. Een richting van 45° plaatst de tweede schaduw onder en rechts.

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
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Python via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze Python‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) op een vorm toepast:

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

Om een gloeieffect op een vorm toe te passen in Aspose.Slides voor Python via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, visueel opvallend element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia’s wordt verbeterd.

Deze Python‑code laat zien hoe je het [gloeieffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) op een vorm toepast:

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

![Gloeieffect](glow_effect.png)

## **Een effect met zachte randen toepassen**

Om een effect met zachte randen toe te passen in Aspose.Slides voor Python via Java, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachtere, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals de straal aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze Python‑code laat zien hoe je het [effect met zachte randen](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

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

![Effect met zachte randen](soft_edges_effect.png)

## **Een vervagings‑effect toepassen**

Gebruik vormvervaging om de vulling en omtrek van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging opleveren. Een straal van nul laat het uiterlijk onveranderd.

De [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow)‑instelling bepaalt de zichtbare grenzen van het effect. Met `False` wordt de vervaging begrensd tot de oorspronkelijke geschilderde grenzen, inclusief de omtrek. Met `True` kan de vervaging buiten die grenzen uitbreiden. Geen van beide instellingen wijzigt de positie of afmetingen van de vorm.

De vergelijking hieronder gebruikt dezelfde vulling, omtrek en vormafmetingen overal. De bovenste rij gebruikt `grow = False`; de onderste rij gebruikt `grow = True`.

![Originele rechthoek vergeleken met vervaagstraal van 5 en 15 punten, met groei uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Python‑voorbeeld maakt een oranje rechthoek met een donkerblauwe omtrek, past een vervaging van 5 punten toe en werkt vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan te roepen. Het slaat beide vervaagde toestanden op en roept daarna [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) aan om de vorm zonder vervaging op te slaan.

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

Vormvervaging beïnvloedt zowel de vulling als de omtrek. Een effect met zachte randen vervaagt de randen van de vorm, terwijl schaduwvervaging alleen de schaduw verzacht. Afbeeldingstransformaties werken op de afbeeldingsinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **Veelgestelde vragen**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, op één vorm combineren om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autosvormen, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de hele groep toegepast.