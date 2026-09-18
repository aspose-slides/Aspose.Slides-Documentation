---
title: Aanmaken en wijzigen van aangepaste animatie‑gedragingen in JavaScript
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/nodejs-java/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Aanmaken, inspecteren en aanpassen van aangepaste animatie‑gedragingen en bewerkbare bewegingspaden in PowerPoint‑presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aangepaste animatie‑gedragingen laten u individuele bewerkingen binnen een animatie‑effect beheersen, zoals het wijzigen van een kleur, het roteren van een vorm of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe u gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en verifieert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/nodejs-java/shape-animation/)​.

## **Begrijp het animatiemodel**

Een animatie is georganiseerd als **Timeline → Sequence → Effect → Behaviors**:

- De [getTimeline](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getTimeline)‑methode geeft de diavoorstelling‑timeline terug, die de hoofd‑sequentie en interactieve sequenties bevat.
- Een [Sequence](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/) bevat effecten, eventueel gericht op verschillende vormen.
- Een [Effect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/) identificeert een doel­vorm, preset, subtype en effect‑timing.
- De collectie die wordt geretourneerd door [Effect.getBehaviors](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getBehaviors) bevat de bewerkingen die het effect implementeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) aan om een effect te maken en de [getBehaviors](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getBehaviors)‑collectie te benaderen. Een preset kan deze collectie automatisch vullen. Houd de bewerkingen wanneer u de preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/#clear) wanneer u ze bewust vervangt.

[BehaviorFactory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/) maakt de acht hieronder geïllustreerde gedragingstypen. Beweging wordt behandeld in [Bouw een bewegingspad]#build-a-motion-path​. Elk fragment bevat de benodigde module‑imports en kan als Node.js‑script worden uitgevoerd met de pakketten `aspose.slides.via.java` en `java` geïnstalleerd. Voer de voorbeelden voor bestand‑creatie eerst uit, daarna de voorbeelden die hun output lezen. Latere bewerkingsvoorbeelden geven aan welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [createRotationEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) om een rotatie te maken. [getBy](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/rotationeffect/#getBy) specificeert een relatieve hoek in graden; [getFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/rotationeffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/rotationeffect/#getTo) geven de eindpunten aan.

Het voorbeeld begint met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatie‑gedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graad betekent een kwart draai vanaf de beginnende oriëntatie van de vorm, dus er is geen expliciete start‑hoek nodig.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` bevat één vorm en één rotatie‑gedrag. De collectie, timing‑ en rotatie‑bewerkingsvoorbeelden hieronder gebruiken dit bestand.

### **Schaal**

Gebruik [createScaleEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) met X/Y‑percentages: [getFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/scaleeffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/scaleeffect/#getTo) beschrijven de start‑ en eindgrootte, terwijl [getBy](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/scaleeffect/#getBy) een relatieve wijziging beschrijft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % gedurende twee seconden. Het gebruik van gelijke horizontale en verticale percentages behoudt de verhoudingen van de vorm; verschillende percentages zouden één dimensie meer rekken dan de andere.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kleur**

Gebruik [createColorEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) om de vulling van blauw naar oranje te veranderen. [getFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/coloreffect/#getFrom) en [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/coloreffect/#getTo) zijn kleuren; [getBy](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/coloreffect/#getBy) is een kleur‑offset. [Behavior.getProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behavior/#getProperties) identificeert het geanimeerde attribuut.

De solide vulling van de vorm wordt geïnitialiseerd op blauw, passend bij de startkleur van de animatie. Het selecteren van het vulling‑kleur‑attribuut vertelt het gedrag welk deel van de vorm gewijzigd moet worden; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gebruik [createFilterEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) om een veeg‑effect te selecteren. [getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filtereffect/#getSubtype) en [getReveal](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filtereffect/#getReveal) specificeren het filter, de richting en of de vorm onthuld of verborgen wordt.

Dit voorbeeld configureert een veeg van twee seconden die de vorm onthult met het subtype “right‑direction”. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van de preset zijn verwijderd.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eigenschap**

Gebruik [createPropertyEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) om de opacity te animeren. [getFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/propertyeffect/#getTo) en [getBy](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/propertyeffect/#getBy) zijn strings die worden geïnterpreteerd via [getValueType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/propertyeffect/#getValueType) en [getCalcMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribuut opacity, en de numerieke strings vertegenwoordigen een wijziging van 25 % opacity naar volledige opacity. Lineaire interpolatie beschrijft een geleidelijke overgang tussen die waarden. Wanneer u dit voorbeeld aanpast voor een ander attribuut, kies dan een waardetype en eindwaarden die passend zijn voor dat attribuut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Instellen**

Gebruik [createSetEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) om zichtbaarheid toe te wijzen via [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/seteffect/#getTo). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing veroorzaakt mogelijk geen duidelijke visuele wijziging op zich. Zo’n bewerking is nuttig als onderdeel van een groter effect dat ook regelt wanneer de vorm verborgen of zichtbaar wordt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Opdracht**

Gebruik [createCommandEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) en configureer [getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commandeffect/#getCommandString) en [getShapeTarget](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Plaats een WAV‑opname genaamd `sample.wav` in de werkmap. Dit voorbeeld embedt het via [addAudioFrameEmbedded](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) en koppelt een afspeelopdracht aan het audio‑frame.

Het audio‑frame is zowel het doel van het effect als van de opdracht. Dit verbindt de afspeel‑request met de ingebedde opname; een opdracht‑string op zichzelf bepaalt niet welk media‑object besturing krijgt. Het effect wordt geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Opslaan legt de opdracht vast in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstellings‑speler die de opdracht en het mediadoel ondersteunt.

## **Beheer de Gedragscollectie**

[BehaviorCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/#remove) en [removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Dit voorbeeld opent `rotation.pptx`, voegt schaling toe, verplaatst deze vóór de rotatie, en verwijdert de rotatie. Het verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schaal naar schaal‑rotatie, vervolgens naar alleen schaal. Indexen verwijzen naar de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na herordening. De definitieve enumeratie bevestigt welk gedrag wordt opgeslagen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De output is `ScaleEffect`: alleen schaal blijft over. De volgorde van de collectie plant gedragingen niet automatisch één na één. Maak de collectie leeg alleen wanneer u al haar bewerkingen vervangt.

## **Configureer de Timing van Gedrag**

[Behavior.getTiming](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behavior/#getTiming) onthult [Timing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/), onafhankelijk van [Effect.getTiming](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getTiming). Effect‑timing plant het omvattende effect; gedrag‑timing beschrijft een bewerking binnen dat effect.

### **Stel Duur, Vertraging, Herhaling en Versnelling in**

Open `rotation.pptx` en stel de duur ([getDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getDuration)) en trigger‑vertraging ([getTriggerDelayTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) in seconden in, waarna u het herhalingsaantal configureert via [setRepeatCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getAccelerate) en [getDecelerate](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getDecelerate) zijn fracties van de duur; hun som mag maximaal 1 bedragen.

Het invoerbestand is datgene dat in het rotatie‑voorbeeld werd aangemaakt, waarbij het eerste gedrag bekend is als een rotatie. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de 90‑graden rotatie blijft ongewijzigd. Het gescheiden houden van hoek en timing maakt het makkelijker het tempo aan te passen zonder de animatie opnieuw te bouwen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhalingsopties omvatten [getRepeatDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) en [getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); kies één beleid in plaats van ze allen tegelijk in te schakelen. [getAutoReverse](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getAutoReverse) speelt de animatie achterwaarts af na de voorwaartse fase. Versnelling en vertraging gelden voor continue wijzigingen, niet voor discrete toewijzingen of opdrachten.

## **Bouw een Bewegingspad**

Gebruik [createMotionEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) om beweging te creëren. Zijn [getFrom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#getTo) en [getBy](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#getBy) beschrijven op percentages gebaseerde coördinaten of offsets. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpath/) aan en wijs deze toe met [MotionEffect.setPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncommandpathtype/) selecteert de bewerking:

| Opdracht | Punten | Betekenis |
| --- | --- | --- |
| MoveTo | Eén | Stel de startpositie in. |
| LineTo | Eén | Verplaats langs een rechte segment naar het eindpunt. |
| CurveTo | Drie | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CloseLoop | Geen | Keer terug naar de startpositie. |
| End | Geen | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpathpointstype/) beschrijft de bewerkingskenmerken van een punt, zoals hoek‑ of vloeiende punten. Het vervangt niet het type opdracht. Gebruik een curve‑punt‑type voor het curve‑voorbeeld hieronder, en een hoek‑punt‑type voor de rechte segmenten.

Pad‑coördinaten worden genormaliseerd naar de dia‑afmetingen: een X‑verplaatsing van 0,25 staat voor een kwart van de dia‑breedte, niet voor 0,25 punten. Positieve Y loopt naar beneden. Absolute opdrachten geven posities in het pad‑coördinatensysteem; relatieve opdrachten geven offsets ten opzichte van de huidige positie. Dit staat los van [getOrigin](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#getOrigin), dat het referentiekader van het pad selecteert, en [getPathEditMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), dat regelt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een Rechte Route**

Creëer een bewegingsgedrag met een startpunt, één recht segment en een eind‑opdracht. [MotionPath.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpath/#add) neemt het opdrachttype, de punten, het punt‑type en een relatieve‑coördinaat‑vlag.

De start‑opdracht zet (0, 0), en de lijn eindigt op (0.25, 0), waardoor de route een horizontale verplaatsing krijgt van een kwart van de dia‑breedte. De eind‑opdracht heeft geen coördinaat‑punten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegingsgedrag aan het effect die route met de rechthoek.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` bevat één bewegingsgedrag met drie pad‑opdrachten. De volgende bewerkingsvoorbeelden gebruiken deze bekende structuur.

### **Vergelijk Absolute en Relatieve Coördinaten**

Deze twee pad‑objecten beschrijven dezelfde route. De absolute opdracht eindigt op (0.3, 0.1); de relatieve opdracht voegt (0.1, 0.1) toe aan de huidige positie, (0.2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn voeg je de X‑ en Y‑offsets toe aan de huidige positie om het eindpunt te krijgen; voor de absolute lijn lees je het eindpunt direct. Het omwisselen van de vlag zonder de coördinaten om te rekenen, zou een andere route beschrijven.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Wijs één van de paden toe aan een bewegingsgedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor die opdracht.

### **Vervang een Lijn door een Curve**

Open `motion.pptx` en vervang de lijn‑opdracht door een kubieke curve. Geef eerst de twee controlepunten op, gevolgd door het eindpunt.

De startpositie wordt geleverd door de voorafgaande opdracht. De eerste twee punten vormen de curve, terwijl het derde punt de bestemming is; het zijn geen drie opeenvolgende bestemmingen. Het aanpassen van het opdrachttype, het punt‑bewerkings‑type en de punt‑array tegelijk houdt het segment consistent met de nieuwe geometrie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het pad in `curve.pptx` heeft nog steeds drie opdrachten; de middelste opdracht definieert nu een curve.

## **Inspecteer en Bewerk een Opgeslagen Pad**

Elke [MotionCmdPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncmdpath/) onthult [getPoints](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) en [isRelative](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motioncmdpath/#isRelative). De volgende voorbeelden gebruiken het bekende drie‑opdrachten‑pad in `motion.pptx`. Voor willekeurige input, lokaliseer het bedoelde effect en controleer opdracht‑types en punt‑aantallen vóór bewerking op index.

### **Lees Opdrachten en Coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en sluit‑loop‑opdrachten hebben geen punten, dus houd rekening met een null‑punt‑array.

De output koppelt elk numeriek opdrachttype aan zijn relatieve‑coördinaat‑vlag vóór het opsommen van de punten. Dit laat u een eindpunt onderscheiden van een offset voordat u het pad wijzigt. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één heeft.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een eind‑opdracht.

### **Wijzig een Eindpunt**

Open `motion.pptx` en vervang de punt‑array van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 de start‑opdracht en index 1 de lijn. Het vervangen van het enkele punt van de lijn verandert de bestemming zonder het opdrachttype, de timing of de positie in de collectie te wijzigen. Omdat de opdracht absolute coördinaten gebruikt, geeft het nieuwe paar een positie aan in plaats van een toegevoegde offset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het oorspronkelijke bestand blijft ongewijzigd.

### **Vervang een Segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpath/#insert) en [removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/motionpath/#removeAt) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit laat zien hoe u een opdracht‑object vervangt in plaats van de bestaande coördinaten te bewerken. Na invoeging bevat de collectie tijdelijk de start‑opdracht, de nieuwe lijn, de oude lijn en de eind‑opdracht. Het verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route achter.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het opgeslagen pad heeft nog steeds drie opdrachten, waarbij de nieuwe lijn eindigt op (0.2, 0.1) en de eind‑opdracht als laatste staat.

## **Wijzig en Verifieer een Bestaand Gedrag**

Wanneer de index van een gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [RotationEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/rotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na opnieuw openen.

De type‑check laat de lus gedragingen die geen rotaties zijn overslaan. De tweede lading leest het opgeslagen bestand in een apart presentatie‑object, zodat de vergelijking de persistente gegevens controleert en niet de nog in het geheugen aanwezige waarde. Dit voorbeeld gaat nog steeds uit van het feit dat het bekende effect eerst in de hoofd‑sequentie staat; selecteren op type vindt niet per se het juiste effect in een willekeurige presentatie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

De output is `Rotation preserved: true`. Pas hetzelfde type‑checkpatroon toe op andere gedragingen. Voor een volledige behoud‑check, vergelijk de doel‑vorm, effect, gedragstypen en -volgorde, timing en pad‑opdrachten. Gebruik een numerieke tolerantie voor floating‑point‑waarden. Voor een presentatie met een onbekende animatie‑indeling, zie [Lees Vormanimaties](/slides/nl/nodejs-java/shape-animation/#read-shape-animations) voor doorlopen van hoofd‑ en interactieve sequenties.

## **Gedragsvolgorde, Presets en Afspeelgedrag**

De volgorde in [BehaviorCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarbij elk gedrag automatisch wacht op het voorgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interageren via [getAdditive](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behavior/#getAdditive) en [getAccumulate](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/behavior/#getAccumulate). Gebruik geen herordening van de collectie alleen om “verplaats, dan roteer” te plannen; gebruik expliciete timing of aparte effecten zoals beschreven in [Vormanimatie](/slides/nl/nodejs-java/shape-animation/)​.

Het [getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getType) en [getSubtype](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getSubtype) van het effect beschrijven de preset. Ze vormen geen volledige beschrijving van een bewerkte gedragsboom. Kies eerst preset en subtype voordat u gedragingen aanpast: het wijzigen van de preset kan de collectie opnieuw bouwen en uw aangepaste bewerkingen verwijderen. Bijvoorbeeld, een aangepaste Spin‑effect veranderen in Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Controleer de collectie opnieuw na het wijzigen van een preset of subtype. Het leegmaken van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die de preset nodig heeft. De voorbeelden gebruiken bewust zichtbare vormen en vervangen de gedragingen; ze reconstrueren niet elke implementatie van een preset.

## **Formaatcompatibiliteit**

Een bewaarde gedragsboom garandeert geen identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen gegevens en de gerenderde output afzonderlijk.

| Formaat of output | Te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedragsboom te verifiëren, en controleer daarna de weergave in de beoogde PowerPoint‑versie. |
| PPT | Het oudere binaire formaat kan verschillen van PPTX. Test een aparte opslaan‑en‑heropen‑cyclus en weergave; concludeer niet dat elke aangepaste combinatie werkt alleen omdat PPTX slaagt. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische dia‑weergave, niet een afspeelbare gedrag‑tijdlijn of een gegarandeerd eind‑animatieframe. |
| [HTML5](/slides/nl/nodejs-java/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vormanimatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/nodejs-java/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, niet bewerkbare gedragingen of klik‑gestuurde interactie. Controleer de feitelijke gerenderde beweging. |
| [Video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) | Rendert animatie‑frames en codeert ze als video. De ondersteuning is beperkt tot de renderer‑[ondersteunde animaties en effecten](/slides/nl/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); opdrachten en interactieve events worden niet een bewerkbare tijdlijn. |

## **FAQ**

**Waarom bevat mijn effect gedragingen voordat ik er een toevoeg?**

Het maken van een vooraf gedefinieerd effect kan de onderliggende bewerkingen genereren. Inspecteer ze voordat u beslist of u de preset uitbreidt of de gedragingen vervangt.

**Zorgt het verplaatsen van een gedrag naar het begin ervoor dat het als eerste wordt afgespeeld?**

Niet per se. De volgorde van de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op dezelfde eigenschap.

**Waarom heeft een eind‑opdracht geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Houd rekening met een null‑punt‑array bij het inspecteren van een pad dat uit een bestand is gelezen.

**Is een succesvolle round‑trip voldoende om weergave te bevestigen?**

Nee. Het opnieuw openen bevestigt alleen de behoud van de gecontroleerde eigenschappen. Test de diavoorstellings‑speler of geanimeerde export apart om het visuele gedrag te bevestigen.