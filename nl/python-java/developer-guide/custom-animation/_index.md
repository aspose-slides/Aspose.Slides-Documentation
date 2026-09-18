---
title: Maak en wijzig aangepaste animatie-gedragingen in Python via Java
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/python-java/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak, inspecteer en wijzig aangepaste animatie-gedragingen en bewerkbare bewegingspaden in PowerPoint-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aangepaste animatie‑gedragingen stellen je in staat individuele bewerkingen binnen een animatie‑effect te beheersen, zoals het wijzigen van een kleur, het roteren van een vorm, of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe je gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en controleert of hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/python-java/shape-animation/).

## **Begrijp het animatiemodel**

Een animatie is georganiseerd als **Timeline → Sequence → Effect → Behaviors**:

- De [getTimeline](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseslide/#getTimeline)‑methode retourneert de tijdlijn van de dia, die de hoofd‑sequentie en interactieve sequenties bevat.
- Een [Sequence](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/) bevat effecten, mogelijk gericht op verschillende vormen.
- Een [Effect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/) identificeert de doelvorm, preset, subtype en de timing van het effect.
- De collectie die wordt geretourneerd door [Effect.getBehaviors](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getBehaviors) bevat de bewerkingen die het effect implementeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect) aan om een effect te maken en toegang te krijgen tot de [getBehaviors](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getBehaviors)‑collectie. Een preset kan deze collectie automatisch vullen. Houd de bewerkingen bij wanneer je de preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/#clear) wanneer je ze bewust vervangt.

[BehaviorFactory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/) maakt de acht gedragstypen die hieronder worden geïllustreerd. Beweging wordt behandeld in [Bouw een bewegingspad](#build-a-motion-path). Elk fragment bevat de benodigde imports en start de JVM indien nodig. Java‑puntobjecten en arrays worden via JPype aangemaakt wanneer de API dit vereist. Latere bewerkingsvoorbeelden geven aan welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [createRotationEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createRotationEffect) om een rotatie te maken. [getBy](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotationeffect/#getBy) geeft een relatieve hoek in graden op; [getFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotationeffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotationeffect/#getTo) geven de eindpunten op.

Het voorbeeld start met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatie‑gedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden betekent een kwartslag ten opzichte van de startoriëntatie van de vorm, dus een expliciete starthoek is niet nodig.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` bevat één vorm en één rotatie‑gedrag. De collectie, timing en rotatie‑bewerkingsvoorbeelden hieronder maken gebruik van dit bestand.

### **Schalen**

Gebruik [createScaleEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createScaleEffect) met X/Y‑percentages: [getFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/scaleeffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/scaleeffect/#getTo) beschrijven de begin‑ en eindgrootte, terwijl [getBy](https://reference.aspose.com/slides/nl/python-java/aspose.slides/scaleeffect/#getBy) een relatieve verandering beschrijft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld laat beide dimensies groeien van 100 % naar 125 % gedurende twee seconden. Gelijke horizontale en verticale percentages behouden de verhoudingen van de vorm; verschillende percentages zouden de ene dimensie meer uitrekken dan de andere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kleur**

Gebruik [createColorEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createColorEffect) om de vulling van blauw naar oranje te wijzigen. [getFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/coloreffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/coloreffect/#getTo) zijn kleuren; [getBy](https://reference.aspose.com/slides/nl/python-java/aspose.slides/coloreffect/#getBy) is een kleurverschuiving. [Behavior.getProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behavior/#getProperties) identificeert het attribuut dat geanimeerd wordt.

De solide vulling van de vorm wordt geïnitialiseerd als blauw, passend bij de startkleur van de animatie. Het selecteren van het vullings‑kleurattribuut vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filter**

Gebruik [createFilterEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createFilterEffect) om een wipe‑filter te selecteren. [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filtereffect/#getSubtype) en [getReveal](https://reference.aspose.com/slides/nl/python-java/aspose.slides/filtereffect/#getReveal) geven respectievelijk het filter, de richting en of het shape moet worden onthuld of verborgen op.

Dit voorbeeld configureert een wipe van twee seconden die de vorm onthult met het subtype “right‑direction”. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van de preset zijn verwijderd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eigenschap**

Gebruik [createPropertyEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) om de dekking (opacity) te animeren. [getFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/propertyeffect/#getTo) en [getBy](https://reference.aspose.com/slides/nl/python-java/aspose.slides/propertyeffect/#getBy) zijn strings die geïnterpreteerd worden met behulp van [getValueType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/propertyeffect/#getValueType) en [getCalcMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/propertyeffect/#getCalcMode). Kies eindpunten of een relatieve verschuiving in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribuut dekking, en de numerieke strings vertegenwoordigen een verandering van 25 % dekking naar volledige dekking. Lineaire interpolatie beschrijft een geleidelijke verandering tussen die waarden. Wanneer je dit voorbeeld aanpast voor een ander attribuut, kies dan een waardetype en eindwaarden die bij dat attribuut passen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Instellen**

Gebruik [createSetEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createSetEffect) om zichtbaarheid toe te wijzen via [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/seteffect/#getTo). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. Het rechthoekige object is al zichtbaar in deze minimale presentatie, dus de toewijzing levert mogelijk geen duidelijke visuele wijziging op. Zo’n bewerking is nuttig als onderdeel van een groter effect dat ook regelt wanneer de vorm wordt verborgen of zichtbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Opdracht**

Gebruik [createCommandEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createCommandEffect) en configureer [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commandeffect/#getCommandString) en [getShapeTarget](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commandeffect/#getShapeTarget). Plaats een WAV‑opname met de naam `sample.wav` in de werkmap. Dit voorbeeld embedt de opname met [addAudioFrameEmbedded](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) en koppelt een afspeel‑opdracht aan het audio‑frame.

Het audio‑frame is zowel het doel van het effect als het doel van de opdracht. Dit verbindt het afspeel‑verzoek met de ingebedde opname; een opdracht‑string op zichzelf identificeert niet welk media‑object moet worden aangestuurd. Het effect is zo ingesteld dat het start bij een klik tijdens de diavoorstelling.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Opslaan legt de opdracht vast in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstellingsspeler die de opdracht en het mediadoel ondersteunt.

## **Beheer de gedragcollectie**

[BehaviorCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/#remove) en [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/#removeAt). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst het vóór de rotatie, en verwijdert de rotatie. Verwijderen en opnieuw invoegen van hetzelfde object verandert de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schalen naar schaal‑rotatie en vervolgens naar alleen schaal. Indexen verwijzen naar de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na herordening. De definitieve enumeratie bevestigt welk gedrag wordt opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De uitvoer is `ScaleEffect`: alleen schalen blijft over. De volgorde van de collectie veroorzaakt op zichzelf geen opeenvolgende uitvoering van gedragingen. Maak de collectie alleen leeg wanneer je al zijn bewerkingen vervangt.

## **Configureer timing van gedrag**

[Behavior.getTiming](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behavior/#getTiming) onthult [Timing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/), onafhankelijk van [Effect.getTiming](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getTiming). Effect‑timing plant het omvattende effect; gedrag‑timing beschrijft een bewerking binnen dat effect.

### **Stel duur, vertraging, herhaling en versnelling in**

Open `rotation.pptx` en stel de duur ([getDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getDuration)) en trigger‑vertraging ([getTriggerDelayTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getTriggerDelayTime)) in seconden in, waarna je het aantal herhalingen configureert via [setRepeatCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getAccelerate) en [getDecelerate](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getDecelerate) zijn fracties van de duur; houd hun som maximaal 1.

Het invoerbestand is het bestand dat in het rotatie‑voorbeeld is gemaakt, waarbij de eerste gedrag bekend is als een rotatie. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de 90‑graden‑hoek blijft ongewijzigd. Het gescheiden houden van hoek en timing maakt het makkelijker het tempo aan te passen zonder de animatie opnieuw te bouwen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhalings‑strategieën omvatten [getRepeatDuration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) en [getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getRepeatUntilNextClick); kies één beleid in plaats van ze allemaal tegelijk in te schakelen. [getAutoReverse](https://reference.aspose.com/slides/nl/python-java/aspose.slides/timing/#getAutoReverse) speelt de animatie achterwaarts af na de voorwaartse pass. Versnelling en vertraging gelden voor doorlopende veranderingen, niet voor losse toewijzingen of opdrachten.

## **Bouw een bewegingspad**

Gebruik [createMotionEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorfactory/#createMotionEffect) om beweging te creëren. Zijn [getFrom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#getTo) en [getBy](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#getBy) beschrijven op percentages gebaseerde coördinaten of verschuivingen. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpath/) en wijs deze toe met [MotionEffect.setPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpath/) slaat de pad‑commando’s op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncommandpathtype/) selecteert de bewerking:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Stel de startpositie in. |
| LineTo | One | Verplaats zich langs een rechte segment naar het eindpunt. |
| CurveTo | Three | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CloseLoop | None | Keer terug naar de startpositie. |
| End | None | Voltooi het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpathpointstype/) beschrijft de eigenschappen van puntbewerking, zoals hoek‑ of vloeiende punten. Het vervangt niet het type commando. Gebruik een curve‑puntype voor het curve‑voorbeeld hieronder, en een hoek‑puntype voor de rechte segmenten.

Pad‑coördinaten worden genormaliseerd naar de dia‑afmetingen: een X‑verschuiving van 0,25 staat voor een kwart van de dia‑breedte, niet 0,25 punten. Positieve Y loopt naar beneden. Absolute commando’s geven posities in het pad‑coördinatensysteem; relatieve commando’s geven verschuivingen vanaf de huidige positie. Dit staat los van [getOrigin](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#getOrigin), dat het referentiekader van het pad selecteert, en [getPathEditMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioneffect/#getPathEditMode), dat bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een recht pad**

Creëer een bewegings‑gedrag met een startpunt, één recht segment en een eind‑commando. [MotionPath.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpath/#add) neemt het commando‑type, de punten, het punt‑type en een relatieve‑coördinaat‑vlag.

Het start‑commando legt (0, 0) vast, en de lijn eindigt op (0.25, 0), waardoor het pad een horizontale verschuiving van een kwart van de dia‑breedte krijgt. Het eind‑commando heeft geen coördinaatpunten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegings‑gedrag aan het effect dat pad met de rechthoek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` bevat één bewegings‑gedrag met drie pad‑commando’s. De volgende voorbeelden voor bestand‑bewerking gebruiken deze bekende structuur.

### **Vergelijk absolute en relatieve coördinaten**

Deze twee pad‑objecten beschrijven dezelfde route. Het absolute commando eindigt op (0.3, 0.1); het relatieve commando voegt (0.1, 0.1) toe aan de huidige positie, (0.2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn tel je de X‑ en Y‑verschuivingen op bij de huidige positie om het eindpunt te verkrijgen; voor de absolute lijn lees je het eindpunt direct. Het wisselen van de vlag zonder de coördinaten te converteren zou een andere route beschrijven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Wijs een van beide paden toe aan een bewegings‑gedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor dat commando.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang het lijn‑commando door een kubieke curve. Geef eerst de twee controlepunten op, gevolgd door het eindpunt.

De startpositie wordt geleverd door het voorafgaande commando. De eerste twee punten vormen de curve, terwijl het derde het eindpunt is; het zijn geen drie opeenvolgende eindpunten. Het tegelijk bijwerken van het commando‑type, het punt‑bewerkingstype en de punt‑array houdt het segment consistent met zijn nieuwe geometrie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het pad in `curve.pptx` heeft nog steeds drie commando’s; het middelste commando definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [MotionCmdPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncmdpath/) onthult [getPoints](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncmdpath/#getPointsType) en [isRelative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motioncmdpath/#isRelative). De volgende voorbeelden gebruiken het bekende drie‑commando‑pad in `motion.pptx`. Voor willekeurige invoer, lokaliseer het beoogde effect en controleer commando‑typen en aantallen punten vóór bewerking op index.

### **Lees commando’s en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en close‑loop‑commando’s hebben geen punten nodig, dus houd rekening met een null‑punt‑array.

De uitvoer koppelt elk numeriek commando‑type aan zijn relatieve‑coördinaat‑vlag alvorens de punten te vermelden. Dit stelt je in staat een eindpunt van een offset te onderscheiden vóór wijziging van het pad. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één vermeldt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een eind‑commando.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de punt‑array van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 het start‑commando en index 1 de lijn. Het vervangen van het enkele punt van de lijn wijzigt de bestemming zonder het commando‑type, de timing of de positie in de collectie te veranderen. Omdat het commando absolute coördinaten gebruikt, specificeert het nieuwe paar een positie in plaats van een toegevoegde offset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het oorspronkelijke bestand blijft ongewijzigd.

### **Vervang een segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpath/#insert) en [removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/motionpath/#removeAt) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit toont het vervangen van een commando‑object in plaats van het bewerken van de bestaande coördinaten. Na invoeging bevat de collectie tijdelijk het start‑commando, de nieuwe lijn, de oude lijn en het eind‑commando. Het verwijderen van index 2 gooit de oude lijn weg en laat de nieuwe route achter.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het opgeslagen pad heeft nog steeds drie commando’s, waarbij de nieuwe lijn eindigt op (0.2, 0.1) en het eind‑commando laatste staat.

## **Wijzig en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [RotationEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/rotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na het opnieuw openen.

De type‑controle laat de lus gedragingen die geen rotaties zijn overslaan. De tweede lading leest het opgeslagen bestand in een apart presentatie‑object, zodat de vergelijking gecontroleerde data verifieert in plaats van de waarde die nog in het geheugen zit. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑sequentie; selecteren op type vindt niet noodzakelijk het juiste effect in een willekeurige presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

De uitvoer is `Rotation preserved: True`. Pas hetzelfde type‑controlepatroon toe op andere gedragingen. Voor een volledige preservatie‑controle vergelijk je de doelvorm, het effect, gedragstypen en -volgorde, timing en pad‑commando’s. Gebruik een numerieke toleranties voor floating‑point‑waarden. Voor een presentatie met een onbekende animatie‑lay-out, zie [Lees Vormanimaties](/slides/nl/python-java/shape-animation/#read-shape-animations) voor traversering van hoofd‑ en interactieve sequenties.

## **Gedragsvolgorde, presets en weergave**

De volgorde in [BehaviorCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarbij elk gedrag automatisch wacht op het voorgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interacteren via [getAdditive](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behavior/#getAdditive) en [getAccumulate](https://reference.aspose.com/slides/nl/python-java/aspose.slides/behavior/#getAccumulate). Gebruik herordening van de collectie niet alleen om “verplaats, dan roteer” te plannen; gebruik expliciete timing of afzonderlijke effecten zoals beschreven in [Vormanimatie](/slides/nl/python-java/shape-animation/).

De [getType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getType) en [getSubtype](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effect/#getSubtype) van het effect beschrijven de preset. Ze vormen geen volledige beschrijving van een bewerkte gedragstboom. Kies de preset en het subtype voordat je gedragingen aanpast: het wijzigen van de preset kan de collectie opnieuw opbouwen en je aangepaste bewerkingen verwijderen. Bijvoorbeeld, het wijzigen van een aangepaste Spin‑effect naar Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Inspecteer de collectie opnieuw na het wijzigen van een preset of subtype. Het legen van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die de preset nodig heeft. De voorbeelden gebruiken bewust zichtbare vormen en vervangen de gedragingen; ze reconstrueren niet de implementatie van elke preset.

## **Formaatcompatibiliteit**

Een bewaarde gedragstboom garandeert geen identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen data en de gerenderde uitvoer apart.

| Format of output | What to verify |
| --- | --- |
| PPTX | Gebruik dit als het primaire formaat voor deze voorbeelden. Open het opnieuw om de bewerkbare gedragstboom te verifiëren, en controleer vervolgens de weergave in de beoogde PowerPoint‑versie. |
| PPT | Het legacy‑binaire formaat kan afwijken van PPTX. Test een aparte opslaan‑en‑opnieuw‑open‑cyclus en weergave; trek geen conclusie over ondersteuning van elke aangepaste combinatie op basis van een succesvolle PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische weergave van de dia, geen afspeelbare gedragstijdlijn of gegarandeerd eind‑animatie‑frame. |
| [HTML5](/slides/nl/python-java/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vormanimatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/python-java/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, geen bewerkbare gedragingen of klik‑gestuurde interactie. Controleer de daadwerkelijk gerenderde beweging. |
| [Video](/slides/nl/python-java/convert-powerpoint-to-video/) | Rendert animatief frames en codeert ze als video. Ondersteuning is beperkt tot de renderer’s [ondersteunde animaties en effecten](/slides/nl/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); opdrachten en interactieve gebeurtenissen worden niet een bewerkbare tijdlijn. |

## **FAQ**

**Waarom bevat mijn effect gedragingen voordat ik er een toevoeg?**

Het creëren van een vooraf gedefinieerd effect kan de onderliggende bewerkingen aanmaken. Inspecteer ze voordat je besluit de preset uit te breiden of de gedragingen te vervangen.

**Zorgt het verplaatsen van een gedrag naar het begin ervoor dat het als eerste wordt afgespeeld?**

Niet per se. De volgorde in de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op dezelfde eigenschap.

**Waarom heeft een eind‑commando geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Houd rekening met een null‑punt‑array bij het inspecteren van een pad dat uit een bestand is gelezen.

**Is een succesvolle round‑trip voldoende om weergave te bevestigen?**

Nee. Het opnieuw openen bevestigt alleen dat de eigenschappen die je controleerde behouden blijven. Test de diavoorstellingsspeler of geanimeerde export afzonderlijk om het visuele gedrag te bevestigen.