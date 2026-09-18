---
title: Skapa och ändra anpassade animeringsbeteenden i JavaScript
linktitle: Anpassad animering
type: docs
weight: 151
url: /sv/nodejs-java/custom-animation/
keywords:
- anpassad animering
- animeringsbeteende
- rörelsebana
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa, inspektera och ändra anpassade animeringsbeteenden och redigerbara rörelsebanor i PowerPoint-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Anpassade animeringsbeteenden låter dig styra enskilda operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsebana. Den här guiden visar hur du skapar och kombinerar beteenden, konfigurerar deras timing, inspekterar och modifierar befintliga animationer samt verifierar att deras egenskaper överlever när en presentation sparas och öppnas igen.

För fördefinierade effekter och klicktriggar, se [Shape Animation](/slides/sv/nodejs-java/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Metoden [getTimeline](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getTimeline) returnerar bildens tidslinje, som innehåller dess huvudsekvens och interaktiva sekvenser.
- En [Sequence](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [Effect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/) identifierar en målform, förinställning, undertyp och effektens timing.
- Samlingen som returneras av [Effect.getBehaviors](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getBehaviors) innehåller de operationer som implementerar effekten: ändra färg, flytta, rotera, sätta en egenskap osv.

## **Skapa enskilda beteenden**

Anropa [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect) för att skapa en effekt och komma åt samlingen [getBehaviors](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getBehaviors). En förinställning kan automatiskt fylla denna samling. Behåll dess operationer när du utökar förinställningen, eller använd [clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/#clear) när du avsiktligt ersätter dem.

[BehaviorFactory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse behandlas i [Build a Motion Path](#build-a-motion-path). Varje kodsnutt inkluderar sina modulimporter och kan köras som ett Node.js‑skript med paketen `aspose.slides.via.java` och `java` installerade. Kör fil‑skapande exemplen innan exemplen som läser deras utdata. Senare redigeringsexempel anger vilken utdatafil de använder.

### **Rotation**

Använd [createRotationEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) för att skapa en rotation. [getBy](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/rotationeffect/#getBy) anger en relativ vinkel i grader; [getFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/rotationeffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/rotationeffect/#getTo) specificerar slutpunkter.

Exemplet börjar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en varaktighet på två sekunder. En relativ vinkel på 90 grader motsvarar ett kvartsväng från figurens startorientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, timingen och rotations‑redigerings exemplen nedan använder den här filen.

### **Skala**

Använd [createScaleEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) med X/Y‑procent: [getFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/scaleeffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/scaleeffect/#getTo) beskriver start‑ och slutstorlek, medan [getBy](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/scaleeffect/#getBy) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procentsatser behåller figurens proportioner; olika procentsatser skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [createColorEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) för att ändra fyllningen från blå till orange. [getFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/coloreffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/coloreffect/#getTo) är färger; [getBy](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/coloreffect/#getBy) är en färgförskjutning. [Behavior.getProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behavior/#getProperties) identifierar attributet som animeras.

Figurens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllnings‑färg‑attributet talar om för beteendet vilken del av figuren som ska ändras; färg‑slutpunkterna ensamma identifierar inte attributet. Den sparade effekten beskriver en två sekunders övergång till orange.

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

Använd [createFilterEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) för att välja en svepning. [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filtereffect/#getSubtype) och [getReveal](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filtereffect/#getReveal) specificerar filtret, riktningen och om figuren ska avslöjas eller döljas.

Detta exempel konfigurerar en två sekunders svepning som avslöjar figuren med undertypen för riktning åt höger. Filterinställningarna tillhör beteendet i effekten, så de konfigureras efter att förinställningens ursprungliga operationer har tagits bort.

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

### **Egenskap**

Använd [createPropertyEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) för att animera opacitet. [getFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/propertyeffect/#getTo) och [getBy](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/propertyeffect/#getBy) är strängar som tolkas med [getValueType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/propertyeffect/#getValueType) och [getCalcMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Välj slutpunkter eller en relativ förskjutning istället för att sätta alla tre godtyckligt.

Här är det valda attributet opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolation beskriver en gradvis förändring mellan dessa värden. När du anpassar detta exempel till ett annat attribut, välj en värdetyp och slutvärden som är lämpliga för det attributet.

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

### **Set**

Använd [createSetEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) för att tilldela synlighet via [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/seteffect/#getTo). Ett set‑beteende interpolerar inte mellan slutpunkterna.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i den här minimala presentationen, så tilldelningen kanske inte ger någon uppenbar visuell förändring på egen hand. En sådan operation är användbar som en del av en större effekt som också styr när figuren blir dold eller synlig.

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

### **Kommando**

Använd [createCommandEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) och konfigurera [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commandeffect/#getCommandString) och [getShapeTarget](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [addAudioFrameEmbedded](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) och bifogar ett spel‑kommando till ljud‑ramen.

Ljud‑ramen är både effektens mål och kommandots mål. Detta kopplar uppspelningsbegäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket medieobjekt som ska kontrolleras. Effekten konfigureras att starta vid ett klick under bildspelet.

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

Sparande lagrar kommandot i `command.pptx`; det spelar inte upp inspelningen. Uppspelning kräver en bildspels‑spelare som stödjer kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[BehaviorCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/) stöder [add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/#remove) och [removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Detta exempel öppnar `rotation.pptx`, lägger till skalning, flyttar den före rotation och tar bort rotationen. Att ta bort och återinfoga samma objekt ändrar dess lagrade position utan att göra en kopia.

Redigeringssekvensen ändrar samlingen från rotation–skala till skala–rotation och sedan till endast skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den sista uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Utdata är `ScaleEffect`: endast skalning kvarstår. Samlingsordning schemalägger i sig inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetiming**

[Behavior.getTiming](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behavior/#getTiming) visar [Timing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/), oberoende av [Effect.getTiming](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getTiming). Effekt‑timing schemalägger den omslutande effekten; beteende‑timing beskriver en operation inuti den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och ange varaktigheten ([getDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getDuration)) och trigger‑fördröjningen ([getTriggerDelayTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) i sekunder, konfigurera sedan repetitionsantalet via [setRepeatCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getAccelerate) och [getDecelerate](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getDecelerate) är bråkdelar av varaktigheten; håll deras summa högst 1.

Indatafilen är den som skapades i rotations‑exemplet, där det första beteendet är känt att vara en rotation. Detta exempel ändrar endast det beteendets timing; dess 90‑graders vinkel förblir intakt. Att hålla vinkel och timing separata gör det lättare att justera takten utan att bygga om animationen.

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

Beteendet använder en varaktighet på två sekunder, en fördröjning på en halv sekund och ett repetitionsantal på 3. De första och sista 20 % av varaktigheten används för acceleration och retardation.

Andra repetitionspolicyer inkluderar [getRepeatDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) och [getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); välj en policy istället för att aktivera dem alla samtidigt. [getAutoReverse](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getAutoReverse) spelar animationen baklänges efter den framåtgående passagen. Acceleration och retardation gäller för kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Skapa en rörelsebana**

Använd [createMotionEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) för att skapa rörelse. Dess [getFrom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#getTo) och [getBy](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#getBy) beskriver procentbaserade koordinater eller förskjutningar. För en redigerbar rutt, skapa en [MotionPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpath/) och tilldela den med [MotionEffect.setPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpath/) lagrar ban‑kommandona.

| Kommando | Punkter | Betydelse |
| --- | --- | --- |
| MoveTo | En | Ange startpositionen. |
| LineTo | En | Flytta längs ett rakt segment till dess slutpunkt. |
| CurveTo | Tre | Följ en kubisk kurva definierad av två kontrollpunkter och en slutpunkt. |
| CloseLoop | Ingen | Återgå till startpositionen. |
| End | Ingen | Avsluta banan. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpathpointstype/) beskriver egenskaper för punktredigering, såsom hörnpunkter eller släta punkter. Den ersätter inte kommandotypen. Använd en kurvpunkttyp för kurvexemplet nedan och en hörnpunkttyp för de raka segmenten.

Bannkoordinater normaliseras till bildens dimensioner: en X‑förskjutning på 0,25 motsvarar en fjärdedel av bildens bredd, inte 0,25 punkter. Positiv Y går nedåt. Absoluta kommandon specificerar positioner i ban‑koordinatsystemet; relativa kommandon specificerar förskjutningar från den aktuella positionen. Detta är separat från [getOrigin](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#getOrigin), som väljer banans referensram, och [getPathEditMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), som styr hur banan rör sig när figuren flyttas.

### **Skapa en rak bana**

Skapa ett rörelsesbeteende med en startpunkt, ett rakt segment och ett slutkommando. [MotionPath.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpath/#add) tar kommandotypen, dess punkter, punkttypen och en flagga för relativ koordinat.

Startkommandot fastställer (0, 0) och linjen slutar vid (0,25, 0), vilket ger rutten en horisontell förskjutning på en fjärdedel av bildens bredd. Slutkommandot har inga koordinatpunkter. När banan har tilldelats, kopplar tillägg av rörelsesbeteendet till effekten den rutten till rektangeln.

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

`motion.pptx` innehåller ett rörelsesbeteende med tre ban‑kommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två ban‑objekt beskriver samma rutt. Det absoluta kommandot slutar vid (0,3, 0,1); det relativa kommandot lägger till (0,1, 0,1) till den aktuella positionen, (0,2, 0).

Båda banorna startar på samma position. För den relativa linjen, lägg till dess X‑ och Y‑förskjutningar till den aktuella positionen för att få slutpunkten; för den absoluta linjen, läs slutpunkten direkt. Att byta flaggan utan att konvertera koordinaterna skulle beskriva en annan rutt.

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

Tilldela antingen banan till ett rörelsesbeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två kontrollpunkterna, följt av slutpunkten.

Startpositionen levereras av föregående kommando. De två första punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkttyp och punktarray samtidigt håller segmentet konsekvent med dess nya geometri.

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

Banan i `curve.pptx` har fortfarande tre kommandon; dess mellersta kommando definierar nu en kurva.

## **Inspektera och redigera en sparad bana**

Varje [MotionCmdPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioncmdpath/) visar [getPoints](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) och [isRelative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Följande exempel använder den kända tre‑kommandonsbanan i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och punktantal innan du redigerar efter index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punktarray.

Utdata parar ihop varje numerisk kommandotyp med dess flagga för relativ koordinat innan punkterna listas. Detta låter dig särskilja en slutpunkt från en förskjutning innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i den här filen listar endast en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0,25, 0) och ett slutkommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punktarray för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt ändrar dess destination utan att ändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än en tillagd förskjutning.

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

Linjen i `motion-endpoint.pptx` slutar vid (0,4, 0,1); den ursprungliga filen är oförändrad.

### **Ersätt ett segment**

Använd [insert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpath/#insert) och [removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/motionpath/#removeAt) för att ersätta linjen i `motion.pptx`. Infogning förskjuter den gamla linjen till index 2.

Detta demonstrerar att ersätta ett kommandobjekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slutkommandot. Borttagning av index 2 kastar den gamla linjen och lämnar den nya rutten på plats.

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

Den sparade banan har fortfarande tre kommandon, där den nya linjen slutar vid (0,2, 0,1) och slutkommandet är sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [RotationEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/rotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter att filen öppnats igen.

Typkontrollen låter loopen hoppa över beteenden som inte är rotationer. Den andra inläsningen läser den sparade filen till ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som fortfarande ligger i minnet. Detta exempel förutsätter fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ hittar inte rätt effekt i en godtycklig presentation.

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

Utdata är `Rotation preserved: true`. Applicera samma typ‑kontrollmönster på andra beteenden. För en fullständig bevarande‑kontroll, jämför målformen, effekten, beteendetyperna och ordningen, timing och ban‑kommandon. Använd ett numeriskt toleransintervall för flyttal. För en presentation med okänt animations‑layout, se [Read Shape Animations](/slides/sv/nodejs-java/shape-animation/#read-shape-animations) för genomgång av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [BehaviorCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behaviorcollection/) är den lagrade ordningen för en effektens operationer. Det är inte en spellista där varje beteende automatiskt väntar på föregående. Timing och den omslutande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan samverka via [getAdditive](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behavior/#getAdditive) och [getAccumulate](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/behavior/#getAccumulate). Använd inte endast omläggning av samlingen för att schemalägga ”flytta, sedan rotera”; använd explicit timing eller separata effekter som beskrivs i [Shape Animation](/slides/sv/nodejs-java/shape-animation/).

Effektens [getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getType) och [getSubtype](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getSubtype) beskriver dess förinställning. De är inte en fullständig beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och kassera dina egna operationer. Till exempel kan byte av en anpassad Spin‑effekt till Fade ersätta dess rotationsbeteende med set‑ och filter‑beteenden. Inspektera samlingen igen efter att du ändrat en förinställning eller undertyp. Rensning av förinställnings‑beteenden kan också ta bort synlighets‑ eller initierings‑operationer som förinställningen kräver. Exemplen använder avsiktligt synliga former och ersätter beteendena; de rekonstruerar inte varje förinställnings implementering.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i varje visare eller export‑renderare. Kontrollera sparade data och den renderade utdata separat.

| Format eller output | Vad att verifiera |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna den igen för att verifiera det redigerbara beteendeträdet, och kontrollera sedan uppspelning i den avsedda PowerPoint‑versionen. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; dra inte slutsatsen att alla anpassade kombinationer stöds bara för att PPTX‑utdata lyckas. |
| PDF, PNG, JPEG och andra statiska bild‑bilder | Innehåller en statisk bildrepresentation, inte en spelbar beteendetidslinje eller en garanterad slut‑animationsram. |
| [HTML5](/slides/sv/nodejs-java/export-to-html5/) | Kan spela stödjade animationer när form‑animation är aktiverad i exportalternativen. Testa anpassade kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/nodejs-java/convert-powerpoint-to-animated-gif/) | Lagras renderade ramar, inte redigerbara beteenden eller klick‑utlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) | Renderar animationsramar och kodar dem som video. Stödet är begränsat till renderarens [supported animations and effects](/slides/sv/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte en redigerbar tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag har lagt till några?**

Att skapa en fördefinierad effekt kan skapa dess underliggande operationer. Inspektera dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning är ingen ersättning för timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slutkommando inga punkter?**

Det markerar slutet på banan och kräver inga koordinater. Kontrollera en null‑punktarray när du inspekterar en bana läst från en fil.

**Är en lyckad rundresa tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna igen bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspelar‑programmet eller den animerade exporten separat för att bekräfta dess visuella beteende.