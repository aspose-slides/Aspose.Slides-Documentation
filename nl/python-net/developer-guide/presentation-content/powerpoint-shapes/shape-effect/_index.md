---
title: Pas vormeffecten toe in presentaties met Python
linktitle: Vorm effect
type: docs
weight: 30
url: /nl/python-net/shape-effect
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen-effect
- effectformaat
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Transformeer uw PPT-, PPTX- en ODP-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Python—creëer opvallende, professionele dia's in enkele seconden."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-net/shape-formatting/#gradient-fill) of contouren. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enzovoort.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden heeft PowerPoint opties onder **Voorinstelling**. De Voorinstelling‑opties zijn in wezen een bekende goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je, door een voorinstelling te selecteren, geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Schaduweffect toepassen**

Aspose.Slides voor Python via .NET ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en onscherpte‑straal aanpassen aan het ontwerp van je presentatie.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de dia‑achtergrond. De schaduw strekt zich uit buiten de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en onscherpte‑straal aan om te passen bij de verlichting en stijl van je sjabloon.

Deze Python‑code toont hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) op een rechthoek toepast:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Schaduweffect](shadow_effect.png)

### **Binnenschaduw toepassen**

Wanneer je de visuele stijl van een sjabloon nabootst, gebruik je een binnenschaduw om een kaart of paneel een verzonken uitstraling te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenschaduw de binnenkant van de randen verduistert.

Roep [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) aan en configureer daarna [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Grotere waarden voor de onscherpte‑straal geven zachtere randen.

Dit Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) aan op het effectformaat van de vorm.

## **Reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Python via .NET, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepassing over meerdere elementen mogelijk is voor een consistent ontwerp.

Deze Python‑code toont hoe je het [reflectie‑effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) op een vorm toepast:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Reflectie‑effect](reflection_effect.png)

## **Glo‑effect toepassen**

Om een gloweffect op een vorm toe te passen in Aspose.Slides voor Python via .NET, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen te laten opvallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algemene uiterlijk van je dia’s wordt verbeterd.

Deze Python‑code toont hoe je het [glo‑effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) op een vorm toepast:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glo‑effect](glow_effect.png)

## **Zachte randen‑effect toepassen**

Om een zachte randen‑effect toe te passen in Aspose.Slides voor Python via .NET, kun je een vloeiende, onscherpe overgang rond de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, milde look nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te verkrijgen bij verschillende vormen in je presentatie.

Deze Python‑code toont hoe je de [zachte randen](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) op een vorm toepast:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Zachte randen‑effect](soft_edges_effect.png)

## **Vervaging‑effect toepassen**

Gebruik vormvervaging om de vulling en contour van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging geven. Een radius van nul laat het uiterlijk onveranderd.

De instelling [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) bepaalt de zichtbare grenzen van het effect. Met `False` wordt de vervaging afgeknipt tot de oorspronkelijke geschilderde grenzen, inclusief de contour. Met `True` kan de vervaging zich buiten die grenzen uitstrekken. Geen van beide instellingen wijzigt de positie of afmetingen van de vorm.

De vergelijking hieronder gebruikt doorlopend dezelfde vulling, contour en vormafmetingen. De bovenste rij gebruikt `grow = False`; de onderste rij gebruikt `grow = True`.

![Originele rechthoek vergeleken met vervagingsradii van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Python‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe en werkt vervolgens bij naar een vervaging van 15 punten door opnieuw [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) aan en slaat de vorm op zonder vervaging.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Vormvervaging beïnvloedt zowel de vulling als de contour tegelijk. Een zachte randen‑effect vervaagt de randen van de vorm, terwijl schaduwvervaging alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op de afbeelding zelf; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm om te zetten naar een afbeelding.

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten combineren, zoals schaduw, reflectie en glo, op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt op de hele groep toegepast.