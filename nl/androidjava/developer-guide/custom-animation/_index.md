---
title: Aanmaken en aanpassen van aangepaste animatie‑gedragingen op Android
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/androidjava/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Aanmaken, inspecteren en wijzigen van aangepaste animatie‑gedragingen en bewerkbare bewegingspaden in PowerPoint‑presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aangepaste animatie‑gedragingen geven je controle over afzonderlijke bewerkingen binnen een animatie‑effect, zoals het wijzigen van een kleur, het roteren van een vorm of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe je gedragselementen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en verifieert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/androidjava/shape-animation/).

## **Begrijp het animatiemodel**

Een animatie is georganiseerd als **Timeline → Sequence → Effect → Behaviors**:

- De [getTimeline](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) methode geeft de dia‑timeline terug, die de hoofd‑sequence en interactieve sequences bevat.
- Een [ISequence](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/) bevat effecten, eventueel gericht op verschillende vormen.
- Een [IEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/) identificeert een doel‑vorm, preset, subtype en effect‑timing.
- De collectie die wordt geretourneerd door [IEffect.getBehaviors](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getBehaviors--) bevat de bewerkingen die het effect uitvoeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragselementen**

Roep [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aan om een effect te maken en toegang te krijgen tot de [getBehaviors](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getBehaviors--) collectie. Een preset kan deze collectie automatisch vullen. Houd de bestaande bewerkingen wanneer je de preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) bij het opzettelijk vervangen ervan.

[IBehaviorFactory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/) maakt de acht gedragstypen die hieronder worden geïllustreerd. Beweging wordt behandeld in [Bouw een bewegingspad] (#build-a-motion-path). Elk fragment bevat de benodigde imports; plaats de uitvoerbare statements binnen een methode. Later bewerkingen geven aan welk uitvoerbestand ze gebruiken. Op Android vervang je de voorbeeld‑bestandnamen door volledige paden in een map die toegankelijk is voor de app, bijvoorbeeld de bestandsmap van je app.

### **Rotatie**

Gebruik [createRotationEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) om een rotatie te maken. [getBy](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irotationeffect/#getBy--) specificeert een relatieve hoek in graden; [getFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irotationeffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irotationeffect/#getTo--) geven de eindpunten aan.

Het voorbeeld begint met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatie‑gedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden betekent een kwart‑draai ten opzichte van de beginnende oriëntatie van de vorm, dus een expliciete starthoek is niet nodig.

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

`rotation.pptx` bevat één vorm en één rotatie‑gedrag. De collectie, timing en rotatie‑bewerkingsvoorbeelden hieronder maken gebruik van dit bestand.

### **Schaal**

Gebruik [createScaleEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) met X/Y‑percentages: [getFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iscaleeffect/#getTo--) beschrijven de begin‑ en eindgrootte, terwijl [getBy](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iscaleeffect/#getBy--) een relatieve wijziging aangeeft. Hier betekent 100 de originele grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % gedurende twee seconden. Gelijke horizontale en verticale percentages behouden de proporties van de vorm; verschillende percentages zouden de ene dimensie meer uitrekken dan de andere.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kleur**

Gebruik [createColorEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) om de vulling van blauw naar oranje te wijzigen. [getFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icoloreffect/#getFrom--) en [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icoloreffect/#getTo--) zijn kleuren; [getBy](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icoloreffect/#getBy--) is een kleurafwijking. [IBehavior.getProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehavior/#getProperties--) identificeert het attribuut dat geanimeerd wordt.

De solide vulling van de vorm wordt geïnitieerd als blauw, zodat deze overeenkomt met de startkleur van de animatie. Het selecteren van het vulling‑kleurattribuut vertelt het gedrag welk deel van de vorm moet worden aangepast; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gebruik [createFilterEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) om een veeg‑filter te selecteren. [getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), en [getReveal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) specificeren het filter, de richting en of de vorm wordt getoond of verborgen.

Dit voorbeeld configureert een veeg van twee seconden die de vorm toont met het subtype rechts‑richting. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke preset‑bewerkingen zijn verwijderd.

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

Gebruik [createPropertyEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) om de opacity te animeren. [getFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), en [getBy](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) zijn strings die worden geïnterpreteerd met [getValueType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) en [getCalcMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Kies eindpunten of een relatieve afwijking in plaats van alle drie willekeurig in te stellen.

Hier is het geselecteerde attribuut opacity, en de numerieke strings geven een wijziging van 25 % opacity naar volledige opacity weer. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Wanneer je dit voorbeeld aanpast voor een ander attribuut, kies je een value‑type en eindpuntwaarden die geschikt zijn voor dat attribuut.

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

### **Set**

Gebruik [createSetEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) om zichtbaarheid toe te wijzen via [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iseteffect/#getTo--). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing levert mogelijk niet direct een opvallende visuele wijziging op. Een dergelijke bewerking is nuttig als onderdeel van een groter effect dat ook bepaalt wanneer de vorm verborgen of zichtbaar wordt.

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

### **Command**

Gebruik [createCommandEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) en configureer [getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), en [getShapeTarget](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Plaats een WAV‑opname genaamd `sample.wav` in de werkmap. Dit voorbeeld embedt deze opname met [addAudioFrameEmbedded](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) en koppelt een afspeel‑commando aan het audio‑frame.

Het audio‑frame is zowel het doel van het effect als van het commando. Dit verbindt het afspeel‑verzoek aan de ingebedde opname; een commando‑string alleen identificeert niet welk media‑object moet worden bestuurd. Het effect wordt geconfigureerd om te starten bij een klik tijdens de diavoorstelling.

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

Opslaan legt het commando vast in `command.pptx`; het speelt de opname niet af. Afspelen vereist een diavoorstellings‑speler die het commando en het bijbehorende media‑doel ondersteunt.

## **Beheer de gedragscollectie**

[IBehaviorCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), en [removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst deze vóór rotatie, en verwijdert de rotatie. Verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schaling naar schaling‑rotatie, en vervolgens naar alleen schaling. Indexen verwijzen naar de huidige collectie, dus de verwijdering gebruikt de nieuwe index van de rotatie na het herschikken. De uiteindelijke enumeratie bevestigt welk gedrag wordt opgeslagen.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

De uitvoer is `ScaleEffect`: alleen schaling blijft over. De volgorde van de collectie plant gedrag niet automatisch achter elkaar in. Maak de collectie leeg alleen wanneer je al haar bewerkingen vervangt.

## **Configureer gedragstiming**

[IBehavior.getTiming](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehavior/#getTiming--) exposeert [ITiming](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/), onafhankelijk van [IEffect.getTiming](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getTiming--). Effect‑timing plant het omsluitende effect; gedragstiming beschrijft een bewerking binnen dat effect.

### **Duur, vertraging, herhaling en versnelling instellen**

Open `rotation.pptx` en stel de duur ([getDuration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getDuration--)) en trigger‑vertraging ([getTriggerDelayTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) in seconden in, waarna je het aantal herhalingen configureert via [setRepeatCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getAccelerate--) en [getDecelerate](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getDecelerate--) zijn fracties van de duur; houd hun som maximaal 1.

Het invoerbestand is het bestand dat in het rotatie‑voorbeeld is aangemaakt, waarbij het eerste gedrag een rotatie is. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de hoek van 90 graden blijft behouden. Het gescheiden houden van hoek en timing maakt het makkelijker om het tempo aan te passen zonder de animatie opnieuw op te bouwen.

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

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalingsaantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhalings‑policy’s omvatten [getRepeatDuration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), en [getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); kies één policy in plaats van ze allemaal tegelijk aan te zetten. [getAutoReverse](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getAutoReverse--) speelt de animatie terug na de voorwaartse passage. Versnelling en vertraging gelden voor continue wijzigingen, niet voor discrete toewijzingen of commando’s.

## **Bouw een bewegingspad**

Gebruik [createMotionEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) om beweging te creëren. Zijn [getFrom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#getTo--), en [getBy](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#getBy--) beschrijven percentag gebaseerde coördinaten of offsets. Voor een bewerkbare route, maak een [MotionPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/motionpath/) en wijs deze toe met [IMotionEffect.setPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/motioncommandpathtype/) selecteert de bewerking:

| Commando | Punten | Betekenis |
| --- | --- | --- |
| MoveTo | One | Stel de beginnende positie in. |
| LineTo | One | Beweeg langs een rechte segment naar het eindpunt. |
| CurveTo | Three | Volg een kubieke curve gedefinieerd door twee controle‑punten en een eindpunt. |
| CloseLoop | None | Keer terug naar de beginnende positie. |
| End | None | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/motionpathpointstype/) beschrijft eigenschappen van puntbewerking, zoals hoek‑ of gladde punten. Het vervangt niet het commando‑type. Gebruik een curve‑punttype voor het curve‑voorbeeld hieronder, en een hoek‑punttype voor de rechte segmenten.

Pad‑coördinaten zijn genormaliseerd naar de afmetingen van de dia: een X‑verschuiving van 0.25 betekent een kwart van de dia‑breedte, niet 0.25 punten. Positieve Y loopt naar beneden. Absolute commando’s geven posities op in het pad‑coördinatensysteem; relatieve commando’s geven offsets ten opzichte van de huidige positie. Dit staat los van [getOrigin](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), die het referentiekader van het pad selecteert, en [getPathEditMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), die bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een rechte pad**

Creëer een bewegings‑gedrag met een startpunt, één rechte segment, en een eind‑commando. [IMotionPath.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) neemt het commando‑type, de punten, het punt‑type en een vlag voor relatieve coördinaten.

Het start‑commando legt (0, 0) vast, en de lijn eindigt op (0.25, 0), waardoor de route een horizontale verschuiving van een kwart van de dia‑breedte krijgt. Het eind‑commando heeft geen coördinaatpunten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegings‑gedrag aan het effect die route met de rechthoek.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

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

Beide paden starten op dezelfde positie. Voor de relatieve lijn, tel je de X‑ en Y‑offsets bij de huidige positie op om het eindpunt te verkrijgen; voor de absolute lijn lees je het eindpunt direct. Het wisselen van de vlag zonder de coördinaten te converteren zou een andere route beschrijven.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Ken één van de paden toe aan een bewegings‑gedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor dat commando.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang het lijn‑commando door een kubieke curve. Lever eerst de twee controle‑punten, gevolgd door het eindpunt.

De startpositie wordt geleverd door het voorafgaande commando. De eerste twee punten vormen de curve, terwijl het derde punt de bestemming is; het zijn geen drie opeenvolgende bestemmingen. Het tegelijk bijwerken van het commando‑type, het punt‑bewerkingstype en de punt‑array houdt het segment consistent met de nieuwe geometrie.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het pad in `curve.pptx` heeft nog steeds drie commando’s; het middelste commando definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [IMotionCmdPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioncmdpath/) exposeert [getPoints](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), en [isRelative](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). De volgende voorbeelden gebruiken het bekende drie‑commando‑pad in `motion.pptx`. Voor willekeurige input, lokaliseer het doel‑effect en controleer de commando‑types en punt‑aantallen vóór bewerking op index.

### **Lees commando’s en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en close‑loop‑commando’s hebben geen punten, dus houd rekening met een null‑punt‑array.

De uitvoer koppelt elk numeriek commando‑type aan zijn relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Dit laat je een eindpunt onderscheiden van een offset vóór het pad aan te passen. Een curve zou drie punten tonen, terwijl de rechte lijn in dit bestand er slechts één toont.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een eind‑commando.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de punt‑array van de lijn om het eindpunt te verplaatsen.

In het invoerbestand is index 0 het start‑commando en index 1 de lijn. Het vervangen van de enkele punt van de lijn verandert de bestemming zonder het commando‑type, de timing, of de positie in de collectie te wijzigen. Omdat het commando absolute coördinaten gebruikt, specificeert het nieuwe paar een positie in plaats van een toegevoegde offset.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het origineel blijft ongewijzigd.

### **Vervang een segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) en [removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit demonstreert het vervangen van een commando‑object in plaats van het bewerken van de bestaande coördinaten. Na invoegen bevat de collectie tijdelijk het start‑commando, de nieuwe lijn, de oude lijn, en het eind‑commando. Het verwijderen van index 2 verwijdert de oude lijn en laat de nieuwe route behouden.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het opgeslagen pad heeft nog steeds drie commando’s, met de nieuwe lijn die eindigt op (0.2, 0.1) en het eind‑commando als laatste.

## **Wijzig en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer je het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [IRotationEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na opnieuw openen.

De type‑controle laat de lus gedragselementen die geen rotaties zijn overslaan. De tweede laad bewerkt het opgeslagen bestand in een separate presentatie‑object, zodat de vergelijking de gepersisteerde data controleert in plaats van de waarde die nog in het geheugen staat. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑sequence; selecteren op type vindt niet per se het juiste effect in een willekeurige presentatie.

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

De uitvoer is `Rotation preserved: true`. Pas hetzelfde type‑check‑patroon toe op andere gedragselementen. Voor een volledige bewaar‑controle, vergelijk de doel‑vorm, het effect, gedragstypen en -volgorde, timing, en pad‑commando’s. Gebruik een numerieke tolerantie voor floating‑point waarden. Voor een presentatie met een onbekende animatie‑structuur, zie [Lees vorm‑animaties](/slides/nl/androidjava/shape-animation/#read-shape-animations) voor traversatie van hoofd‑ en interactieve sequences.

## **Gedragvolgorde, presets en weergave**

De volgorde in [IBehaviorCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarbij elk gedrag automatisch wacht op het vorige. Timing en het omsluitende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interageren via [getAdditive](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehavior/#getAdditive--) en [getAccumulate](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Gebruik niet alleen herschikking van de collectie om “verplaats, daarna roteer” te plannen; gebruik expliciete timing of gescheiden effecten zoals beschreven in [Vormanimatie](/slides/nl/androidjava/shape-animation/).

Het [getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getType--) en [getSubtype](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getSubtype--) van het effect beschrijven de preset. Ze vormen geen volledige beschrijving van een bewerkte gedrag‑boom. Kies de preset en het subtype vóór je gedragselementen aanpast: het wijzigen van de preset kan de collectie opnieuw opbouwen en jouw aangepaste bewerkingen verwijderen. Bijvoorbeeld, het wijzigen van een aangepast Spin‑effect naar Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedrag. Inspecteer de collectie opnieuw na het wijzigen van een preset of subtype. Het verwijderen van preset‑gedrag kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die de preset nodig heeft. De voorbeelden gebruiken opzettelijk zichtbare vormen en vervangen de gedragselementen; ze herbouwen niet elke preset‑implementatie.

## **Formaat‑compatibiliteit**

Een bewaarde gedrag‑boom garandeert niet identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen data en de gerenderde output apart.

| Formaat of output | Wat te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedrag‑boom te verifiëren, controleer daarna de weergave in de beoogde PowerPoint‑versie. |
| PPT | De legacy‑binaire representatie kan verschillen van PPTX. Test een aparte opsla‑en‑heropen‑cyclus en weergave; baseer je geen conclusies over elke aangepaste combinatie alleen op succesvolle PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische weergave van de dia, geen afspeelbare gedrag‑timeline of gegarandeerd eind‑animatie‑frame. |
| [HTML5](/slides/nl/androidjava/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vorm‑animatie is ingeschakeld in de export‑opties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/androidjava/convert-powerpoint-to-animated-gif/) | Opslag van gerenderde frames, geen bewerkbare gedragselementen of klik‑gestuurde interactie. Controleer de werkelijk gerenderde beweging. |
| [Video](/slides/nl/androidjava/convert-powerpoint-to-video/) | Render animatie‑frames en codeer ze als video. Ondersteuning is beperkt tot de renderer’s [ondersteunde animaties en effecten](/slides/nl/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); commando’s en interactieve gebeurtenissen worden niet een bewerkbare timeline. |

## **FAQ**

**Waarom bevat mijn effect gedragselementen voordat ik er een toevoeg?**

Het creëren van een vooraf gedefinieerd effect kan de onderliggende bewerkingen aanmaken. Inspecteer ze voordat je beslist of je de preset wilt uitbreiden of de gedragselementen wilt vervangen.

**Zet het verplaatsen van een gedrag naar het begin het eerst in de afspeellijst?**

Niet per se. De volgorde van de collectie is geen vervanging voor timing. Controleer vertragingen, duur, en interacties tussen bewerkingen op dezelfde eigenschap.

**Waarom heeft een eind‑commando geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Controleer op een null‑punt‑array wanneer je een pad inspecteert dat uit een bestand is gelezen.

**Is een succesvolle round‑trip voldoende om de weergave te bevestigen?**

Nee. Heropenen bevestigt alleen de bewaarde eigenschappen die je gecontroleerd hebt. Test de diavoorstellings‑speler of de animated export apart om het visuele gedrag te bevestigen.