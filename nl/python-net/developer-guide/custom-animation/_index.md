---
title: "Aanmaken en wijzigen van aangepaste animatiegedragingen in Python"
linktitle: "Aangepaste animatie"
type: docs
weight: 151
url: /nl/python-net/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Aanmaken, inspecteren en wijzigen van aangepaste animatiegedragingen en bewerkbare bewegingspaden in PowerPoint-presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aangepaste animatiegedragingen stellen je in staat individuele bewerkingen binnen een animatie‑effect te regelen, zoals een kleur wijzigen, een vorm roteren of een bewerkbaar bewegingspad volgen. Deze gids laat zien hoe je gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en controleert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Shape Animation](/slides/nl/python-net/shape-animation/).

## **Begrijp het animatiemodel**

Een animatie is georganiseerd als **Timeline → Sequence → Effect → Behaviors**:

- De dia's [timeline](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/timeline/) bevat haar hoofdreeks en interactieve reeksen.
- Een [Sequence](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/) bevat effecten, die mogelijk verschillende vormen targeten.
- Een [Effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/) identificeert een doelvorm, preset, subtype en de timing van het effect.
- [Effect.behaviors](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/behaviors/) bevat de bewerkingen die het effect uitvoeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [Sequence.add_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/sequence/add_effect/) aan om een effect te maken en toegang te krijgen tot de [behaviors](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/behaviors/) collectie. Een preset kan deze collectie automatisch vullen. Houd de bewerkingen wanneer je het preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/clear/) wanneer je ze doelbewust vervangt.

BehaviorFactory maakt de acht gedragstypen die hieronder geïllustreerd worden. Beweging wordt behandeld in [Build a Motion Path](#build-a-motion-path). Elk voorbeeld van creatie is een compleet programma; latere bewerkingsvoorbeelden vermelden welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [create_rotation_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) om een rotatie te maken. [by](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/rotationeffect/by/) specificeert een relatieve hoek in graden; [from_address](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/rotationeffect/from_address/) en [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/rotationeffect/to/) geven de eindpunten aan.

Het voorbeeld begint met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatiegedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden vertegenwoordigt een kwartrotatie vanaf de beginnende oriëntatie van de vorm, dus een expliciete starthoek is niet nodig.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` bevat één vorm en één rotatiegedrag. De collectie-, timing- en rotatie‑bewerkingsvoorbeelden hieronder gebruiken dit bestand.

### **Schalen**

Gebruik [create_scale_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) met X/Y‑percentages: [from_address](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/scaleeffect/from_address/) en [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/scaleeffect/to/) beschrijven de start‑ en eindgrootte, terwijl [by](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/scaleeffect/by/) een relatieve wijziging beschrijft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % over twee seconden. Het gebruik van gelijke horizontale en verticale percentages behoudt de verhoudingen van de vorm; verschillende percentages zouden één dimensie meer uitrekken dan de andere.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Kleur**

Gebruik [create_color_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) om de vulling van blauw naar oranje te wijzigen. [from_address](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/coloreffect/from_address/) en [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/coloreffect/to/) zijn kleuren; [by](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/coloreffect/by/) is een kleuroffset. [Behavior.properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/properties/) identificeert het attribuut dat geanimeerd wordt.

De solide vulling van de vorm is initieel blauw, overeenkomend met de startkleur van de animatie. Het selecteren van het vulkleur‑attribuut vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filter**

Gebruik [create_filter_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) om een veeg‑effect te selecteren. [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/filtereffect/subtype/) en [reveal](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/filtereffect/reveal/) geven respectievelijk het filter, de richting en of de vorm wordt onthuld of verborgen aan.

Dit voorbeeld configureert een twee‑seconden veeg die de vorm onthult met het subtype rechtsrichting. De filterinstellingen behoren tot het gedrag binnen het effect, zodat ze worden ingesteld nadat de oorspronkelijke bewerkingen van het preset verwijderd zijn.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Eigenschap**

Gebruik [create_property_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) om de doorzichtigheid te animeren. [from_address](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/to/), en [by](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/by/) zijn strings die worden geïnterpreteerd met behulp van [value_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/value_type/) en [calc_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribuut doorzichtigheid, en de numerieke strings vertegenwoordigen een wijziging van 25 % doorzichtigheid naar volledige doorzichtigheid. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Bij het aanpassen van dit voorbeeld aan een ander attribuut, kies een waarde‑type en eindwaarden die passen bij dat attribuut.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Instellen**

Gebruik [create_set_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) om zichtbaarheid toe te wijzen via [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/seteffect/to/). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. Het vierkant is al zichtbaar in deze minimale presentatie, dus de toewijzing levert mogelijk geen duidelijke visuele verandering op. Zo’n bewerking is nuttig als onderdeel van een groter effect dat ook bepaalt wanneer de vorm verborgen of zichtbaar wordt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Opdracht**

Gebruik [create_command_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) en configureer [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/commandeffect/command_string/), en [shape_target](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/commandeffect/shape_target/). Plaats een WAV‑opname met de naam `sample.wav` in de werkmap. Dit voorbeeld embeddert deze met [add_audio_frame_embedded](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) en koppelt een afspeel‑opdracht aan het audio‑frame.

Het audio‑frame is zowel het doel van het effect als het doel van de opdracht. Dit verbindt het afspeel‑verzoek met de ingesloten opname; een opdracht‑string alleen identificeert niet welk mediobject moet worden aangestuurd. Het effect is geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Opslaan slaat de opdracht op in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstelling‑speler die de opdracht en het bijbehorende mediadoel ondersteunt.

## **Beheer de gedragcollectie**

[BehaviorCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/remove/), en [remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Dit voorbeeld opent `rotation.pptx`, voegt een schaaltoevoeging toe, verplaatst deze vóór de rotatie, en verwijdert de rotatie. Het verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schaling naar schaal‑rotatie, daarna naar alleen schaal. Indexen verwijzen naar de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na het herschikken. De uiteindelijke opsomming bevestigt welk gedrag wordt opgeslagen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

De uitvoer is `ScaleEffect`: alleen schalen blijft over. De volgorde van de collectie plant op zichzelf geen gedragingen na elkaar in. Maak de collectie alleen leeg wanneer je alle bewerkingen vervangt.

## **Configureer gedragstiming**

[Behavior.timing](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/timing/) toont [Timing](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/), onafhankelijk van [Effect.timing](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/timing/). Effect‑timing plant het omvattende effect; gedragstiming beschrijft een bewerking binnen dat effect.

### **Stel duur, vertraging, herhaling en versnelling in**

Open `rotation.pptx` en stel [duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/duration/) en [trigger_delay_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/trigger_delay_time/) in seconden in, waarna je [repeat_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_count/) configureert. [accelerate](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/accelerate/) en [decelerate](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/decelerate/) zijn breuken van de duur; hou hun som maximaal 1.

Het invoerbestand is het bestand dat in het rotatie‑voorbeeld is aangemaakt, waarbij het eerste gedrag bekend is als een rotatie. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de hoek van 90 graden blijft ongewijzigd. Het gescheiden houden van hoek en timing maakt het makkelijker om het tempo aan te passen zonder de animatie opnieuw op te bouwen.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhaal‑policies omvatten [repeat_duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), en [repeat_until_next_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/repeat_until_next_click/); kies één policy in plaats van ze allemaal tegelijk in te schakelen. [auto_reverse](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/timing/auto_reverse/) speelt de animatie achterwaarts af na de voorwaartse doorgang. Versnelling en vertraging gelden voor continue wijzigingen, niet voor discrete toewijzingen of opdrachten.

## **Bouw een bewegingspad**

Gebruik [create_motion_effect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) om beweging te maken. De [from_address](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/to/), en [by](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/by/) beschrijven op percentages gebaseerde coördinaten of offsets. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpath/) aan en wijs deze toe aan [MotionEffect.path](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpath/) slaat de pad‑opdrachten op.

| Opdracht | Punten | Betekenis |
| --- | --- | --- |
| MOVE_TO | One | Stel de startpositie in. |
| LINE_TO | One | Verplaats langs een rechte segment naar het eindpunt. |
| CURVE_TO | Three | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CLOSE_LOOP | None | Keer terug naar de startpositie. |
| END | None | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpathpointstype/) beschrijft kenmerken van puntbewerking, zoals hoek‑ of vloeiende punten. Het vervangt niet het type opdracht. Gebruik een curve‑punt‑type voor het curve‑voorbeeld hieronder, en een hoek‑punt‑type voor de rechte segmenten.

Paddcoördinaten zijn genormaliseerd ten opzichte van de afmetingen van de dia: een X‑verplaatsing van 0,25 staat voor een kwart van de dia‑breedte, niet voor 0,25 punten. Positieve Y loopt naar beneden. Absolute opdrachten specificeren posities in het pad‑coördinatensysteem; relatieve opdrachten specificeren offsets ten opzichte van de huidige positie. Dit staat los van [origin](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/origin/), die het referentiekader van het pad selecteert, en [path_edit_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), die bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een recht pad**

Maak een bewegingsgedrag met een startpunt, één recht segment en een eind‑opdracht. [MotionPath.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpath/add/) neemt het opdrachttype, de bijbehorende punten, het punt‑type en een vlag voor relatieve coördinaten.

De start‑opdracht stelt (0, 0) in, en de lijn eindigt op (0,25, 0), waardoor het parcours een horizontale verplaatsing van een kwart van de dia‑breedte krijgt. De eind‑opdracht heeft geen coördinaten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegingsgedrag aan het effect dit traject met het rechthoekige object.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` bevat één bewegingsgedrag met drie pad‑opdrachten. De volgende bewerking‑voorbeelden gebruiken deze bekende structuur.

### **Vergelijk absolute en relatieve coördinaten**

Deze twee padobjecten beschrijven dezelfde route. De absolute opdracht eindigt op (0,3, 0,1); de relatieve opdracht voegt (0,1, 0,1) toe aan de huidige positie, (0,2, 0).

Beide paden beginnen op dezelfde positie. Voor de relatieve lijn, tel de X‑ en Y‑offsets op bij de huidige positie om het eindpunt te krijgen; voor de absolute lijn, lees het eindpunt direct. Het omwisselen van de vlag zonder de coördinaten om te zetten resulteert in een andere route.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Wijs een van beide paden toe aan een bewegingsgedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor die opdracht.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang de lijn‑opdracht door een kubieke curve. Geef eerst de twee controlepunten op, gevolgd door het eindpunt.

De startpositie wordt geleverd door de voorgaande opdracht. De eerste twee punten vormen de curve, terwijl het derde punt de bestemming is; het zijn geen drie opeenvolgende bestemmingen. Het tegelijk bijwerken van het opdrachttype, het punt‑bewerkingstype en de puntarray houdt het segment in overeenstemming met de nieuwe geometrie.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Het pad in `curve.pptx` heeft nog steeds drie opdrachten; de middelste opdracht definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [MotionCmdPath](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioncmdpath/) toont [points](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioncmdpath/points_type/), en [is_relative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motioncmdpath/is_relative/). De volgende voorbeelden gebruiken het bekende pad met drie opdrachten in `motion.pptx`. Voor willekeurige invoer, zoek het beoogde effect en controleer opdrachttypes en het aantal punten voordat je op index bewerkt.

### **Lees opdrachten en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en close‑loop‑opdrachten hebben geen punten nodig, dus houd rekening met een `None` puntarray.

De uitvoer koppelt elke opdracht aan de relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Dit maakt het mogelijk om een eindpunt van een offset te onderscheiden vóór het pad te wijzigen. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één opsomt.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

De lijst bevat een startpunt, een absolute lijn die eindigt op (0,25, 0), en een eind‑opdracht.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de puntarray van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 de start‑opdracht en index 1 de lijn. Het vervangen van het enkele punt van de lijn wijzigt de bestemming zonder het opdrachttype, de timing of de positie in de collectie te wijzigen. Omdat de opdracht absolute coördinaten gebruikt, specificeert het nieuwe paar een positie in plaats van een toegevoegde offset.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

De lijn in `motion-endpoint.pptx` eindigt op (0,4, 0,1); het originele bestand blijft ongewijzigd.

### **Vervang een segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpath/insert/) en [remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/motionpath/remove_at/) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit toont het vervangen van een opdrachtobject in plaats van het bewerken van de bestaande coördinaten. Na invoegen bevat de collectie tijdelijk de start‑opdracht, de nieuwe lijn, de oude lijn en de eind‑opdracht. Het verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route over.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Het opgeslagen pad heeft nog steeds drie opdrachten, waarbij de nieuwe lijn eindigt op (0,2, 0,1) en de eind‑opdracht als laatste staat.

## **Wijzig en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt het [RotationEffect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/rotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na het opnieuw openen.

De type‑controle zorgt ervoor dat de lus gedragingen die geen rotaties zijn overslaat. De tweede laadoperatie leest het opgeslagen bestand in een apart presentatie‑object, zodat de vergelijking de persistente data controleert in plaats van de nog in het geheugen aanwezige waarde. Dit voorbeeld gaat er nog steeds van uit dat het bekende effect als eerste in de hoofd‑reeks staat; selecteren op type vindt niet per se het juiste effect in een willekeurige presentatie.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

De uitvoer is `Rotation preserved: True`. Pas hetzelfde type‑controlepatroon toe op andere gedragingen. Voor een volledige behoud‑controle, vergelijk de doelvorm, het effect, de gedragstypen en -volgorde, de timing en de pad‑opdrachten. Gebruik een numerieke tolerantie voor float‑waarden. Voor een presentatie met een onbekende animatie‑indeling, zie [Read Shape Animations](/slides/nl/python-net/shape-animation/#read-shape-animations) voor het doorlopen van hoofd‑ en interactieve reeksen.

## **Gedragvolgorde, presets en afspelen**

De volgorde in [BehaviorCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarin elk gedrag automatisch wacht op het voorgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen via [additive](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/additive/) en [accumulate](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/behavior/accumulate/) met elkaar interageren. Gebruik het herschikken van de collectie niet alleen om “verplaatsen, dan roteren” in te plannen; gebruik expliciete timing of afzonderlijke effecten zoals beschreven in [Shape Animation](/slides/nl/python-net/shape-animation/).

Het [type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/type/) en [subtype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.animation/effect/subtype/) van het effect beschrijven het preset. Ze geven geen volledige beschrijving van een bewerkte gedragboom. Kies het preset en subtype voordat je gedragingen aanpast: het wijzigen van het preset kan de collectie opnieuw opbouwen en je aangepaste bewerkingen verwijderen. Bijvoorbeeld, het wijzigen van een aangepast Spin‑effect naar Fade kan het rotatiegedrag vervangen door set‑ en filter‑gedragingen. Inspecteer de collectie opnieuw na het wijzigen van een preset of subtype. Het wissen van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die het preset nodig heeft. De voorbeelden gebruiken bewust zichtbare vormen en vervangen de gedragingen; ze reconstrueren niet elke implementatie van het preset.

## **Formaatcompatibiliteit**

Een bewaarde gedragboom garandeert niet identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen data en de gerenderde output afzonderlijk.

| Formaat of output | Wat te verifiëren |
| --- | --- |
| PPTX | Gebruik als het primaire formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedragboom te verifiëren, controleer vervolgens de weergave in de beoogde PowerPoint‑versie. |
| PPT | De verouderde binaire weergave kan verschillen van PPTX. Test een afzonderlijke opslaan‑open‑cyclus en weergave; trek geen conclusie over ondersteuning voor elke aangepaste combinatie op basis van een succesvolle PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevat een statische weergave van de dia, geen afspeelbare gedragstijdlijn of gegarandeerd eindframe van de animatie. |
| [HTML5](/slides/nl/python-net/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vormanimatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/python-net/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, niet bewerkbare gedragingen of klik‑geïnitieerde interactie. Controleer de daadwerkelijk gerenderde beweging. |
| [Video](/slides/nl/python-net/convert-powerpoint-to-video/) | Render animatie‑frames en codeer ze als video. Ondersteuning is beperkt tot de [supported animations and effects] van de renderer; opdrachten en interactieve gebeurtenissen worden geen bewerkbare tijdlijn. |

## **Veelgestelde vragen**

**Waarom bevat mijn effect gedragingen voordat ik er een toevoeg?**

Het maken van een vooraf gedefinieerd effect kan de onderliggende bewerkingen aanmaken. Inspecteer ze voordat je beslist of je het preset wilt uitbreiden of de gedragingen wilt vervangen.

**Maakt het verplaatsen van een gedrag naar het begin dat het als eerste wordt afgespeeld?**

Niet per se. De volgorde van de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op dezelfde eigenschap.

**Waarom heeft een eind‑opdracht geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Controleer op een `None` puntarray bij het inspecteren van een pad dat uit een bestand is gelezen.

**Is een geslaagde round‑trip voldoende om de weergave te bevestigen?**

Nee. Het opnieuw openen bevestigt alleen de behoud van de eigenschappen die je hebt gecontroleerd. Test de diavoorbeeldspeler of de geanimeerde export afzonderlijk om het visuele gedrag te bevestigen.