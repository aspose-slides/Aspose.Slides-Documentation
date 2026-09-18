---
title: Aanmaken en aanpassen van aangepaste animatiegedragingen in Java
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/java/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Aanmaken, inspecteren en aanpassen van aangepaste animatiegedragingen en bewerkbare bewegingspaden in PowerPoint-presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Aangepaste animatie‑gedragingen geven je controle over individuele bewerkingen binnen een animatie‑effect, zoals het veranderen van een kleur, het roteren van een vorm of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe je gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en aanpast, en verifieert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Shape Animation](/slides/nl/java/shape-animation/).

## **Begrijp het animatiemodel**

Een animatie is gestructureerd als **Timeline → Sequence → Effect → Behaviors**:

- De [getTimeline](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getTimeline--) methode levert de diavoorstelling‑timeline, die de hoofd‑sequence en interactieve sequenced bevat.
- Een [ISequence](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/) bevat effecten, mogelijk gericht op verschillende vormen.
- Een [IEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/) identificeert een doelvorm, preset, subtype en effect‑timing.
- De collectie die wordt geretourneerd door [IEffect.getBehaviors](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getBehaviors--) bevat de bewerkingen die het effect uitvoeren: kleur veranderen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aan om een effect te creëren en toegang te krijgen tot de [getBehaviors](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getBehaviors--)‑collectie. Een preset kan deze collectie automatisch vullen. Houd de bestaande bewerkingen wanneer je de preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/#clear--) bij het doelbewust vervangen ervan.

[IBehaviorFactory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/) maakt de acht hieronder geïllustreerde gedragstypen. Motion wordt behandeld in [Build a Motion Path](#build-a-motion-path). Elk fragment bevat de benodigde imports; plaats de uitvoerbare statements binnen een methode. Latere bewerkingsvoorbeelden vermelden welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [createRotationEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) om een rotatie te maken. [getBy](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irotationeffect/#getBy--) geeft een relatieve hoek in graden aan; [getFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irotationeffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irotationeffect/#getTo--) geven de eindpunten.

Het voorbeeld begint met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatie‑gedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden vertegenwoordigt een kwartslag vanaf de beginoriëntatie van de vorm, dus een expliciete starthoek is niet nodig.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` bevat één vorm en één rotatie‑gedrag. De collectie, timing en rotatie‑bewerkingsvoorbeelden hieronder gebruiken dit bestand.

### **Schalen**

Gebruik [createScaleEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) met X/Y‑percentages: [getFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iscaleeffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iscaleeffect/#getTo--) beschrijven de start‑ en eindgrootte, terwijl [getBy](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iscaleeffect/#getBy--) een relatieve wijziging beschrijft. Hier betekent 100 de oorspronkelijke grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % over twee seconden. Gelijke horizontale en verticale percentages behouden de verhoudingen van de vorm; verschillende percentages zouden één dimensie meer uitrekken dan de andere.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kleur**

Gebruik [createColorEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) om de vulling van blauw naar oranje te wijzigen. [getFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icoloreffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icoloreffect/#getTo--) zijn kleuren; [getBy](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icoloreffect/#getBy--) is een kleuroffset. [IBehavior.getProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehavior/#getProperties--) identificeert het attribuut dat wordt geanimeerd.

De solide vulling van de vorm wordt geïnitialiseerd op blauw, overeenkomend met de startkleur van de animatie. Het selecteren van het vulling‑kleurattribuut vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gebruik [createFilterEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) om een wipe te selecteren. [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifiltereffect/#getSubtype--), en [getReveal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifiltereffect/#getReveal--) geven respectievelijk het filter, de richting en of de vorm wordt onthuld of verborgen.

Dit voorbeeld configureert een wipe van twee seconden die de vorm onthult met het subtype “right”. De filter‑instellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van de preset zijn verwijderd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eigenschap**

Gebruik [createPropertyEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) om de opacity te animeren. [getFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipropertyeffect/#getTo--), en [getBy](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipropertyeffect/#getBy--) zijn strings die worden geïnterpreteerd via [getValueType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipropertyeffect/#getValueType--) en [getCalcMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribuut opacity, en de numerieke strings vertegenwoordigen een wijziging van 25 % opacity naar volledige opacity. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Wanneer je dit voorbeeld aanpast voor een ander attribuut, kies je een waarde‑type en eindwaarden die passen bij dat attribuut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Instellen**

Gebruik [createSetEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) om zichtbaarheid toe te wijzen via [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iseteffect/#getTo--). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheidsattribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing veroorzaakt mogelijk geen duidelijk visueel verschil op zichzelf. Zo’n bewerking is nuttig als onderdeel van een groter effect dat tevens regelt wanneer de vorm verborgen of zichtbaar wordt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Commando**

Gebruik [createCommandEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) en configureer [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icommandeffect/#getCommandString--), en [getShapeTarget](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Plaats een WAV‑opname genaamd `sample.wav` in de werkmap. Dit voorbeeld embedt de opname met [addAudioFrameEmbedded](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) en koppelt een afspeel‑commando aan het audiokader.

Het audiokader is zowel het doel van het effect als van het commando. Dit verbindt het afspeel‑verzoek met de embedde opname; een commando‑string alleen identificeert niet welk media‑object moet worden bediend. Het effect wordt geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Opslaan legt het commando vast in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstellings‑speler die het commando en het mediadoel ondersteunt.

## **Beheer de gedrag‑collectie**

[IBehaviorCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), en [removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst dit vóór rotatie, en verwijdert de rotatie. Het verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schalen naar schalen‑rotatie, daarna naar alleen schalen. Indexen hebben betrekking op de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na het herordenen. De uiteindelijke iteratie bevestigt welk gedrag wordt opgeslagen.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De uitvoer is `ScaleEffect`: alleen schalen blijft over. De volgorde van de collectie plant op zich geen gedragingen opeenvolgend in. Maak de collectie leeg alleen wanneer je alle bewerkingen vervangt.

## **Configureer gedrag‑timing**

[IBehavior.getTiming](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehavior/#getTiming--) geeft toegang tot [ITiming](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/), onafhankelijk van [IEffect.getTiming](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getTiming--). Effect‑timing plant het omvattende effect; gedrag‑timing beschrijft een bewerking binnen dat effect.

### **Duur, vertraging, herhaling en acceleratie instellen**

Open `rotation.pptx` en stel de duur ([getDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getDuration--)) en trigger‑vertraging ([getTriggerDelayTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) in seconden in, configureer vervolgens het aantal herhalingen via [setRepeatCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getAccelerate--) en [getDecelerate](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getDecelerate--) zijn breuken van de duur; houd hun som ≤ 1.

Het invoerbestand is het bestand dat in het rotatie‑voorbeeld is gemaakt, waarbij de eerste gedrag een rotatie is. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de hoek van 90 graden blijft ongewijzigd. Het scheiden van hoek en timing maakt het makkelijker om het tempo aan te passen zonder de animatie opnieuw op te bouwen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor acceleratie en deceleratie.

Andere herhalingsopties omvatten [getRepeatDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), en [getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); kies één beleid in plaats van ze allemaal tegelijk in te schakelen. [getAutoReverse](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getAutoReverse--) speelt de animatie achteruit af na de voorwaartse passage. Acceleratie en deceleratie gelden voor continue wijzigingen, niet voor discrete toewijzingen of commando’s.

## **Bouw een bewegingspad**

Gebruik [createMotionEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) om beweging te creëren. Zijn [getFrom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#getTo--), en [getBy](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#getBy--) beschrijven coördinaten of offsets op basis van percentages. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/motionpath/) en wijs deze toe met [IMotionEffect.setPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/motioncommandpathtype/) selecteert de bewerking:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Stel de startpositie in. |
| LineTo | One | Verplaats langs een rechte segment naar het eindpunt. |
| CurveTo | Three | Volg een kubieke curve gedefinieerd door twee controlepunten en een eindpunt. |
| CloseLoop | None | Keer terug naar de startpositie. |
| End | None | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/motionpathpointstype/) beschrijft kenmerken van puntbewerking, zoals hoek‑ of vloeiende punten. Het vervangt niet het commando‑type. Gebruik een curve‑punttype voor het curve‑voorbeeld hieronder, en een hoek‑punttype voor de rechte segmenten.

Pad‑coördinaten zijn genormaliseerd naar de afmetingen van de dia: een X‑verschuiving van 0,25 vertegenwoordigt een kwart van de dia‑breedte, niet 0,25 punten. Positieve Y loopt omlaag. Absolute commando’s geven posities op in het padcoördinatensysteem; relatieve commando’s geven offsets vanaf de huidige positie. Dit staat los van [getOrigin](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#getOrigin--), dat het referentiekader van het pad selecteert, en [getPathEditMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioneffect/#getPathEditMode--), die bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een recht pad**

Creëer een bewegings‑gedrag met een startpunt, één recht segment, en een einde‑commando. [IMotionPath.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) neemt het commando‑type, de punten, het punt‑type en een relatieve‑coördinaat‑vlag.

Het start‑commando legt (0, 0) vast, en de lijn eindigt op (0.25, 0), waardoor de route een horizontale verschuiving van een kwart van de dia‑breedte krijgt. Het eind‑commando heeft geen coördinaat‑punten. Zodra het pad is toegewezen, koppelt het toevoegen van het bewegings‑gedrag aan het effect die route aan de rechthoek.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` bevat één bewegings‑gedrag met drie pad‑commando’s. De volgende voorbeelden voor bestandsbewerking gebruiken deze bekende structuur.

### **Vergelijk absolute en relatieve coördinaten**

Deze twee pad‑objecten beschrijven dezelfde route. Het absolute commando eindigt op (0.3, 0.1); het relatieve commando voegt (0.1, 0.1) toe aan de huidige positie, (0.2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn moet je de X‑ en Y‑offsets optellen bij de huidige positie om het eindpunt te krijgen; voor de absolute lijn lees je het eindpunt direct. Het omwisselen van de vlag zonder de coördinaten te converteren zou een andere route beschrijven.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Wijs een van beide paden toe aan een bewegings‑gedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor dat commando.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang het lijn‑commando door een kubieke curve. Geef eerst de twee controlepunten, gevolgd door het eindpunt.

De startpositie wordt bepaald door het voorgaande commando. De eerste twee punten vormen de curve, terwijl het derde het eindpunt is; het zijn geen drie opeenvolgende bestemmingen. Het tegelijk bijwerken van het commando‑type, het punt‑bewerkingstype en de punt‑array houdt het segment consistent met de nieuwe geometrie.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het pad in `curve.pptx` heeft nog steeds drie commando’s; het middelste commando definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [IMotionCmdPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioncmdpath/) geeft toegang tot [getPoints](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioncmdpath/#getPointsType--), en [isRelative](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotioncmdpath/#isRelative--). De volgende voorbeelden gebruiken het bekende drie‑commando‑pad in `motion.pptx`. Voor willekeurige invoer, lokaliseer het beoogde effect en controleer commando‑typen en punt‑aantallen vóór bewerking op index.

### **Lees commando’s en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en close‑loop‑commando’s hebben geen punten nodig, dus houd rekening met een null‑punt‑array.

De uitvoer koppelt elk numeriek commando‑type aan zijn relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Dit stelt je in staat een eindpunt van een offset te onderscheiden vóór het pad te wijzigen. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één heeft.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een einde‑commando.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de punt‑array van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 het start‑commando en index 1 de lijn. Het vervangen van de enkele punt van de lijn verandert de bestemming zonder het commando‑type, de timing of de positie in de collectie aan te passen. Omdat het commando absolute coördinaten gebruikt, specificeert het nieuwe paar een positie in plaats van een toegevoegde offset.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het oorspronkelijke bestand blijft ongewijzigd.

### **Vervang een segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) en [removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imotionpath/#removeAt-int-) om de lijn in `motion.pptx` te vervangen. Invoegen schuift de oude lijn naar index 2.

Dit demonstreert het vervangen van een commando‑object in plaats van de bestaande coördinaten ervan te bewerken. Na invoegen bevat de collectie tijdelijk het start‑commando, de nieuwe lijn, de oude lijn en het einde‑commando. Het verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route intact.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het opgeslagen pad heeft nog steeds drie commando’s, waarbij de nieuwe lijn eindigt op (0.2, 0.1) en het einde‑commando als laatste staat.

## **Bewerk en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer je op type. Dit voorbeeld opent `rotation.pptx`, vindt de [IRotationEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na opnieuw openen.

De type‑controle laat de lus gedragssprongen die geen rotaties zijn overslaan. De tweede laadstap leest het opgeslagen bestand in een apart presentatie‑object, zodat de vergelijking de bewaarde gegevens controleert en niet de nog in het geheugen aanwezige waarde. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑sequence; selecteren op type vindt niet per se het juiste effect in een willekeurige presentatie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

De uitvoer is `Rotation preserved: true`. Pas hetzelfde type‑controlepatroon toe op andere gedragingen. Voor een volledige behouds‑check vergelijk je de doelvorm, het effect, de gedragstypen en -volgorde, de timing, en de pad‑commando’s. Gebruik een numerieke tolerantie voor zwevende‑kommagetallen. Voor een presentatie met een onbekende animatie‑structuur, zie [Read Shape Animations](/slides/nl/java/shape-animation/#read-shape-animations) voor het doorlopen van hoofd‑ en interactieve sequensen.

## **Gedragvolgorde, presets en afspelen**

De volgorde in [IBehaviorCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarbij elk gedrag automatisch wacht op het voorafgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interageren via [getAdditive](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehavior/#getAdditive--) en [getAccumulate](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibehavior/#getAccumulate--). Gebruik niet alleen herschikking van de collectie om “verplaatsen, dan roteren” te plannen; gebruik expliciete timing of afzonderlijke effecten zoals beschreven in [Shape Animation](/slides/nl/java/shape-animation/).

De [getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getType--) en [getSubtype](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getSubtype--) van het effect beschrijven de preset. Ze vormen geen volledige beschrijving van een bewerkt gedrag‑boom. Kies de preset en het subtype voordat je gedragingen aanpast: het wijzigen van de preset kan de collectie opnieuw opbouwen en je aangepaste bewerkingen verwijderen. Bijvoorbeeld, het veranderen van een aangepast Spin‑effect naar Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Inspecteer de collectie opnieuw na het wijzigen van een preset of subtype. Het wissen van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die de preset nodig heeft. De voorbeelden gebruiken bewust zichtbare vormen en vervangen de gedragingen; ze herbouwen niet elke preset‑implementatie.

## **Formaat‑compatibiliteit**

Een bewaarde gedrag‑boom garandeert geen identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen data en de gerenderde output afzonderlijk.

| Formaat of output | Wat te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedrag‑boom te verifiëren, controleer daarna de weergave in de beoogde PowerPoint‑versie. |
| PPT | Het legacy‑binaire formaat kan verschillen van PPTX. Test een aparte opslaan‑en‑heropen‑cyclus en weergave; concludeer niet dat elke aangepaste combinatie werkt op basis van een succesvolle PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische weergave van de dia, geen afspeelbare gedragstijdlijn of gegarandeerd eind‑animatie‑frame. |
| [HTML5](/slides/nl/java/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vorm‑animatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/java/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, niet bewerkbare gedragingen of klik‑geactiveerde interactie. Controleer de werkelijk gerenderde beweging. |
| [Video](/slides/nl/java/convert-powerpoint-to-video/) | Rendert animatie‑frames en codeert ze als video. Ondersteuning is beperkt tot de renderer‑[ondersteunde animaties en effecten](/slides/nl/java/convert-powerpoint-to-video/#supported-animations-and-effects); commando’s en interactieve gebeurtenissen worden geen bewerkbare tijdlijn. |

## **FAQ**

**Waarom bevat mijn effect gedragingen voordat ik er een heb toegevoegd?**

Het aanmaken van een vooraf gedefinieerd effect kan onderliggende bewerkingen genereren. Inspecteer ze voordat je beslist of je de preset uitbreidt of de gedragingen vervangt.

**Zorgt het verplaatsen van een gedrag naar het begin ervoor dat het als eerste wordt afgespeeld?**

Niet per se. De volgorde van de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op hetzelfde attribuut.

**Waarom heeft een eind‑commando geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Controleer op een null‑punt‑array bij het inspecteren van een pad gelezen uit een bestand.

**Is een succesvolle round‑trip voldoende om afspelen te bevestigen?**

Nee. Opnieuw openen bevestigt alleen de bewaarde eigenschappen die je hebt gecontroleerd. Test de diavoorstellings‑speler of de geanimeerde export afzonderlijk om het visuele gedrag te bevestigen.