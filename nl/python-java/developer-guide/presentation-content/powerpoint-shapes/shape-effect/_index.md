---
title: Vormeffecten toepassen in presentaties met Python via Java
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/python-java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zachte randen‑effect
- effectformaat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten via Aspose.Slides voor Python via Java - maak binnen enkele seconden opvallende, professionele dia's."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [opvullingen](/slides/nl/python-java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Voorinstelling**. De opties voor voorinstellingen zijn combinaties van twee of meer effecten die bekend staan om er goed uit te zien. Op deze manier hoef je, door een voorinstelling te selecteren, geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) klasse die je toestaan dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides voor Python via Java ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en onscherpte‑straal aanpassen aan het ontwerp van je presentatie.

### **Een buitenschaduw toepassen**

Gebruik een buitenschaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en onscherpte‑straal aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Python‑code laat zien hoe je het [buitenschaduweffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) op een rechthoek toepast:

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

### **Een binnenschaduw toepassen**

Bij het reproduceren van de visuele stijl van een sjabloon, gebruik je een binnenschaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenschaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenschaduw de binnenkant van de randen verduistert.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) aan, configureer daarna de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Grotere waarden voor de onscherpte‑straal geven zachtere randen.

Dit Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten, en de onscherpte‑straal is 6 punten:

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

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Python via Java, kun je een spiegelachtige reflectie toevoegen aan vormen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepassing over meerdere elementen mogelijk is voor een consistent ontwerp.

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

## **Een gloeieffect toepassen**

Om een gloeieffect toe te passen op een vorm in Aspose.Slides voor Python via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algemene uiterlijk van je dia's wordt verbeterd.

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

## **Een zacht‑randen‑effect toepassen**

Om een zacht‑randen‑effect toe te passen in Aspose.Slides voor Python via Java, kun je een gladde, onscherpe overgang rond de randen van een vorm creëren. Dit effect geeft een subtieler en verfijnder uiterlijk, perfect voor ontwerpen die een zachte, subtiele uitstraling nodig hebben. Je kunt eenvoudig parameters zoals straal aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze Python‑code laat zien hoe je het [zacht‑randen‑effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) op een vorm toepast:

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

![Zacht‑randen‑effect](soft_edges_effect.png)

## **Een vervagings‑effect toepassen**

Gebruik vorm‑vervaging om de opvulling en contour van een vorm zachter te maken terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging opleveren. Een straal van nul laat het uiterlijk ongewijzigd.

De [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) instelling regelt de zichtbare grenzen van het effect. Met `False` wordt de vervaging bijgesneden tot de oorspronkelijk geschilderde grenzen, inclusief de contour. Met `True` kan de vervaging zich buiten die grenzen uitstrekken. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt doorlopend dezelfde opvulling, contour en vormafmetingen. De bovenste rij gebruikt `grow = False`; de onderste rij gebruikt `grow = True`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met uitgroei uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Python‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe, en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) aan te roepen. Het slaat beide vervaagde toestanden op, roept vervolgens [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) aan en slaat de vorm zonder vervaging op.

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

Vorm‑vervaging beïnvloedt zowel de opvulling als de contour tegelijk. Een zacht‑randen‑effect doet de randen van de vorm vervagen, terwijl schaduw‑vervaging alleen de schaduw zachter maakt. Beeld‑transformatieteffecten werken op de afbeeldingsinhoud; dit voorbeeld past vervaging rechtstreeks toe op het effectformaat van de vorm zonder de vorm naar een afbeelding om te zetten.

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten combineren, zoals schaduw, reflectie en gloed, op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autosjablonen, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.