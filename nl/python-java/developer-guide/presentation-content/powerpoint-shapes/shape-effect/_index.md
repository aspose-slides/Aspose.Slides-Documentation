---
title: Pas Vormeffecten toe in Presentaties met Python via Java
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/python-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachtrand-effect
- effectformaat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Python via Java - maak opvallende, professionele dia's in enkele seconden."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm maken, de gloed van een vorm verspreiden, enz.

![Shape effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten die bekend staan om hun goede uiterlijk. Op deze manier hoef je, door een preset te selecteren, geen tijd meer te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/)‑klasse die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Een schaduweffect toepassen**

Aspose.Slides voor Python via Java ondersteunt buiten- en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de verlichting en de stijl van je sjabloon.

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

![Shadow effect](shadow_effect.png)

### **Een binnenschaduw toepassen**

Wanneer je de visuele stijl van een sjabloon nabootst, gebruik je een binnenschaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich uit buiten de vorm en laat deze opgeheven lijken, terwijl een binnenschaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de vervagingsstraal geven zachtere randen.

Dit Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de vervagingsstraal is 6 punten:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Python via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect vergroot de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

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

![Reflection effect](reflection_effect.png)

## **Een gloeieffect toepassen**

Om een gloeieffect op een vorm toe te passen in Aspose.Slides voor Python via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia's wordt verbeterd.

Deze Python‑code toont hoe je het [gloeieffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) op een vorm toepast:

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

![Glow effect](glow_effect.png)

## **Een zachtrand‑effect toepassen**

Om een zachtrand‑effect toe te passen in Aspose.Slides voor Python via Java, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtieler en verfijnder uiterlijk, perfect voor ontwerpen die een zachte, subtiele uitstraling nodig hebben. Je kunt eenvoudig parameters zoals de radius aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze Python‑code toont hoe je het [zachtrand‑effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

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

![Soft edges effect](soft_edges_effect.png)

## **FAQ**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten combineren, zoals schaduw, reflectie en gloed, op één enkele vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder automatisch vormen, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.