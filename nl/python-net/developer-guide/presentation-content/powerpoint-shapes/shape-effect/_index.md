---
title: Toepassen van vormeffecten in presentaties met Python
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/python-net/shape-effect
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen effect
- effectformaat
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Transformeer uw PPT-, PPTX- en ODP-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Python—creëer verbluffende, professionele dia's in enkele seconden."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/python-net/shape-formatting/#gradient-fill) of omlijningen. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, een gloed rond een vorm verspreiden, enz.

![Vormeffect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Preset**. De Preset‑opties vormen in feite een bekende, goed uitziende combinatie van twee of meer effecten. Op deze manier hoef je, door een preset te selecteren, geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/)‑klasse die je toelaten dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Toepassen van een schaduweffect**

Aspose.Slides for Python via .NET ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Toepassen van een buitenschaduw**

Gebruik een buitenschaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich buiten de randen van de vorm uit, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Python‑code laat zien hoe je het [buitenschaduweffect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) op een rechthoek toepast:

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

### **Toepassen van een binnenschaduw**

Wanneer je de visuele stijl van een sjabloon reproduceert, kun je een binnenschaduw gebruiken om een kaart of paneel een verzonken uiterlijk te geven. Een buitenschaduw strekt zich buiten de vorm uit en maakt deze verhoogd, terwijl een binnenschaduw de binnenkant van de randen verkleurt.

Roep [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) aan en configureer vervolgens [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Grotere waarden voor de vervagingsstraal geven zachtere randen.

Deze Python‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand:

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

### **Toepassen, wijzigen en verwijderen van een preset‑schaduw**

Roep [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) aan en stel de [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/)‑eigenschap van de schaduw in op een [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/)‑waarde. Om stijlen te wisselen, wijzig je de preset op dezelfde vorm. Roep [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) aan om de schaduw te verwijderen terwijl de vulling en omlijning behouden blijven.

Dit voorbeeld toont vier fasen naast elkaar op één dia. Het kloont de rechthoek vóór elke wijziging zodat je de resultaten kunt vergelijken. Beide schaduwen zijn met 10 punten offset. Een richting van 225° plaatst de eerste schaduw boven en links van de rechthoek, en 45° plaatst de tweede onder en rechts.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Origineel | Eerste preset | Tweede preset | Na verwijdering |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![Top-left drop shadow](preset_shadow_top_left.png) | ![Bottom-right drop shadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Toepassen van een reflectie‑effect**

Om een reflectie‑effect toe te passen in Aspose.Slides for Python via .NET, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistente vormgeving.

Deze Python‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) op een vorm toepast:

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

## **Toepassen van een gloeieffect**

Om een gloeieffect op een vorm toe te passen in Aspose.Slides for Python via .NET, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen te laten opvallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor de algehele uitstraling van je dia’s verbetert.

Deze Python‑code laat zien hoe je het [gloeieffect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) op een vorm toepast:

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

![Gloeieffect](glow_effect.png)

## **Toepassen van een zacht rand‑effect**

Om een zacht rand‑effect toe te passen in Aspose.Slides for Python via .NET, kun je een vloeiende, vervaagde overgang rondom de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect over diverse vormen in je presentatie te bereiken.

Deze Python‑code laat zien hoe je de [zachte randen](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) op een vorm toepast:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Zacht rand‑effect](soft_edges_effect.png)

## **Toepassen van een vervagingseffect**

Gebruik vormvervaging om de vulling en omlijning van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging opleveren. Een radius van nul laat het uiterlijk ongewijzigd.

De [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/)‑instelling bepaalt de zichtbare grenzen van het effect. Met `False` wordt de vervaging begrensd tot de oorspronkelijke geschilderde grenzen, inclusief de omlijning. Met `True` kan de vervaging zich buiten die grenzen uitbreiden. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De vergelijking hieronder gebruikt overal dezelfde vulling, omlijning en vormafmetingen. De bovenste rij gebruikt `grow = False`; de onderste rij gebruikt `grow = True`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Python‑voorbeeld maakt een oranje rechthoek met een donkerblauwe omlijning, past een vervaging van 5 punten toe, en werkt vervolgens bij naar een vervaging van 15 punten door opnieuw [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) aan en slaat de vorm zonder vervaging op.

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

Vormvervaging beïnvloedt de vulling en omlijning gezamenlijk. Een zacht rand‑effect doet de randen van de vorm vervagen, terwijl schaduwvervaging alleen de schaduw verzacht. Beeldtransformatieteffecten werken op de beeldinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm om te zetten naar een afbeelding.

## **Veelgestelde vragen**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, op één vorm combineren om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autoshapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de volledige groep.