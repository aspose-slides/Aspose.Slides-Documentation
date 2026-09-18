---
title: Skapa och ändra anpassade animationsbeteenden på Android
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/androidjava/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsebana
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa, granska och ändra anpassade animationsbeteenden och redigerbara rörelsebanor i PowerPoint-presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Anpassade animationsbeteenden låter dig styra enskilda operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsebana. Denna guide visar hur du skapar och kombinerar beteenden, konfigurerar deras tidpunkter, granskar och ändrar befintliga animationer samt verifierar att deras egenskaper överlever sparande och återöppning av en presentation.

För fördefinierade effekter och klickutlösare, se [Formanimation](/slides/sv/androidjava/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Metoden [getTimeline](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) returnerar bildens tidslinje, som innehåller dess huvudsekvens och interaktiva sekvenser.
- En [ISequence](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [IEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/) identifierar en målassform, förinställning, undertyp och effektens timing.
- Samlingen som returneras av [IEffect.getBehaviors](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#getBehaviors--) innehåller de operationer som implementerar effekten: färgändring, förflyttning, rotation, inställning av en egenskap osv.

## **Skapa enskilda beteenden**

Anropa [ISequence.addEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) för att skapa en effekt och få åtkomst till samlingen [getBehaviors](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#getBehaviors--). En förinställning kan fylla i denna samling automatiskt. Behåll dess operationer när du utökar förinställningen, eller använd [clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) när du medvetet ersätter dem.

[IBehaviorFactory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse behandlas i [Bygg en rörelsebana](#build-a-motion-path). Varje kodsnutt inkluderar sina import‑satser; placera dess körbara satser i en metod. Senare redigeringsexempel anger vilken utdatafil de använder. På Android, ersätt exempelfilnamnen med fullständiga sökvägar i en app‑åtkomlig katalog, t.ex. din apps filkatalog.

### **Rotation**

Använd [createRotationEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) för att skapa en rotation. [getBy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irotationeffect/#getBy--) specificerar en relativ vinkel i grader; [getFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irotationeffect/#getFrom--) och [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irotationeffect/#getTo--) specificerar start‑ respektive slutpunkt.

Exemplet startar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en varaktighet på två sekunder. En relativ vinkel på 90 grader uttrycker ett kvartsvarv från formens ursprungliga orientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, tidpunkterna och exemplen för rotationsredigering nedan använder denna fil.

### **Skala**

Använd [createScaleEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) med X/Y‑procent: [getFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) och [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iscaleeffect/#getTo--) beskriver start‑ respektive sluttstorlek, medan [getBy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iscaleeffect/#getBy--) beskriver en relativ förändring. Här betyder 100 originalstorleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procentsatser behåller formens proportioner; olika procentsatser skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [createColorEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) för att ändra fyllningen från blå till orange. [getFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icoloreffect/#getFrom--) och [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icoloreffect/#getTo--) är färger; [getBy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icoloreffect/#getBy--) är en färgoffset. [IBehavior.getProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehavior/#getProperties--) identifierar attributet som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllnings‑färgattributet talar om för beteendet vilken del av formen som ska ändras; färgändpunkterna ensam identifierar inte attributet. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

Använd [createFilterEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) för att välja ett svep. [getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), och [getReveal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) specificerar filtret, riktningen och om formen ska visas eller döljas.

Detta exempel konfigurerar ett tvåsekunders svep som visar formen med undertypen för riktning åt höger. Filterinställningarna tillhör beteendet i effekten, så de konfigureras efter att den förinställda operationen har tagits bort.

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

### **Egenskap**

Använd [createPropertyEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) för att animera opacitet. [getFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), och [getBy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) är strängar som tolkas med [getValueType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) och [getCalcMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Välj slutpunkter eller en relativ offset snarare än att sätta alla tre utan åtskillnad.

Här är det valda attributet opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolation beskriver en gradvis förändring mellan dessa värden. När du anpassar detta exempel till ett annat attribut, välj en värdetyp och slutvärden som passar det attributet.

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

### **Sätt**

Använd [createSetEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) för att tilldela synlighet via [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iseteffect/#getTo--). Ett set‑beteende interpolerar inte mellan slutpunkterna.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i denna minimalpresentation, så tilldelningen kanske inte ger någon uppenbar visuell förändring på egen hand. En sådan operation är användbar som del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [createCommandEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) och konfigurera [getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), och [getShapeTarget](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [addAudioFrameEmbedded](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) och fäster ett spela‑kommando på ljudramen.

Ljudramen är både effektens mål och kommandots mål. Detta kopplar spelbegäran till den inbäddade inspelningen; en kommandosträng ensam identifierar inte vilket mediaobjekt som ska styras. Effekten är konfigurerad att starta vid ett klick under bildspelet.

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

Att spara lagrar kommandot i `command.pptx`; det spelar inte upp inspelningen. Uppspelning kräver en bildspelar‑applikation som stödjer kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[IBehaviorCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/) stödjer [add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), och [removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Detta exempel öppnar `rotation.pptx`, lägger till skalning, flyttar den före rotation och tar bort rotationen. Att ta bort och återinföra samma objekt ändrar dess lagrade position utan att göra en kopia.

Redigeringssekvensen ändrar samlingen från rotation‑skala till skala‑rotation, sedan till enbart skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omsortering. Den slutgiltiga uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Utdata blir `ScaleEffect`: bara skalning återstår. Samlingsordning i sig schemalägger inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetiming**

[IBehavior.getTiming](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehavior/#getTiming--) exponerar [ITiming](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/), oberoende av [IEffect.getTiming](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#getTiming--). Effekt‑timing schemalägger den omgivande effekten; beteendetiming beskriver en operation inom den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och sätt varaktigheten ([getDuration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getDuration--)) samt utlösningsfördröjning ([getTriggerDelayTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) i sekunder, konfigurera sedan repetitionsantalet via [setRepeatCount](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getAccelerate--) och [getDecelerate](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getDecelerate--) är bråkdelar av varaktigheten; håll deras summa högst 1.

Indatafilen är den som skapades i rotations‑exemplet, där det första beteendet är känt som en rotation. Detta exempel ändrar endast den beteendets timing; dess 90‑graders vinkel förblir intakt. Att hålla vinkel och timing separata gör det enklare att justera takten utan att bygga om animationen.

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

Beteendet använder en varaktighet på två sekunder, en halvsekunders fördröjning och ett repetitionsantal på 3. De första och sista 20 % av varaktigheten används för acceleration respektive deceleration.

Andra repetitionspolicyer inkluderar [getRepeatDuration](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), och [getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); välj en policy istället för att aktivera dem alla samtidigt. [getAutoReverse](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiming/#getAutoReverse--) spelar animationen baklänges efter den framåtgående passagen. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Bygg en rörelsebana**

Använd [createMotionEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) för att skapa rörelse. Dess [getFrom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#getTo--), och [getBy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#getBy--) beskriver procentbaserade koordinater eller offsetar. För en redigerbar bana, skapa ett [MotionPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/motionpath/) och tilldela det med [IMotionEffect.setPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotionpath/) lagrar bankommandona.

[MotionCommandPathType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/motioncommandpathtype/) väljer operationen:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/motionpathpointstype/) beskriver punkt‑redigeringskaraktäristika, såsom hörn‑ eller släta punkter. Den ersätter inte kommandotypen. Använd en kurvpunktstyp för kurvexemplet nedan, och en hörnpunktstyp för de raka segmenten.

Bananormeringar är relativt bildens dimensioner: en X‑förskjutning på 0,25 representerar en fjärdedel av bildbredden, inte 0,25 punkter. Positiv Y går nedåt. Absoluta kommandon anger positioner i banans koordinatsystem; relativa kommandon anger offsetar från den aktuella positionen. Detta är separat från [getOrigin](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), som väljer banans referensram, och [getPathEditMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak bana**

Skapa ett rörelsebeteende med en startpunkt, ett rakt segment och ett slut‑kommando. [IMotionPath.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) tar kommandotyp, dess punkter, punktstyp och en flagga för relativkoordinat.

Startkommandot etablerar (0, 0) och linjen slutar vid (0.25, 0), vilket ger banan en horisontell förskjutning på en fjärdedel av bildbredden. Slutkommandot har inga koordinatpunkter. När banan är tilldelad kopplar tillägget av rörelsebeteendet till effekten den rutten till rektangeln.

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

`motion.pptx` innehåller ett rörelsebeteende med tre bankommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två banaobjekt beskriver samma rutt. Det absoluta kommandot slutar vid (0.3, 0.1); det relativa kommandot adderar (0.1, 0.1) till den nuvarande positionen, (0.2, 0).

Båda banorna startar på samma position. För den relativa linjen, addera dess X‑ och Y‑offsetar till den nuvarande positionen för att erhålla slutpunkten; för den absoluta linjen, läs slutpunkten direkt. Att bara byta flaggan utan att konvertera koordinaterna skulle beskriva en annan rutt.

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

Tilldela antingen bana till ett rörelsebeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två kontrollpunkterna, följt av slutpunkten.

Startpositionen tillhandahålls av det föregående kommandot. De två första punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punktarray tillsammans håller segmentet konsekvent med dess nya geometri.

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

Banan i `curve.pptx` har fortfarande tre kommandon; mittkommandot definierar nu en kurva.

## **Granska och redigera en sparad bana**

Varje [IMotionCmdPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioncmdpath/) exponerar [getPoints](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), och [isRelative](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Följande exempel använder den kända tre‑kommandobanan i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och punktantal innan redigering via index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punktarray.

Utdata parar varje numerisk kommandotyp med dess relativ‑koordinat‑flagga innan punkterna listas. Detta låter dig särskilja en slutpunkt från en offset innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i den här filen bara listar en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0.25, 0), och ett slut‑kommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punktarray för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt ändrar dess destination utan att ändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än en tillagd offset.

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

Linjen i `motion-endpoint.pptx` slutar vid (0.4, 0.1); originalfilen förblir oförändrad.

### **Ersätt ett segment**

Använd [insert](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) och [removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) för att ersätta linjen i `motion.pptx`. Infogning flyttar den gamla linjen till index 2.

Detta visar hur man ersätter ett kommandobjekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slut‑kommandot. Att ta bort index 2 förkastar den gamla linjen och lämnar den nya rutten på plats.

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

Den sparade banan har fortfarande tre kommandon, med den nya linjen som slutar vid (0.2, 0.1) och slut‑kommandot sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [IRotationEffect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter att ha öppnat filen igen.

Typkontrollen låter loopen hoppa över beteenden som inte är rotationer. Den andra laddningen läser den sparade filen i ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som fortfarande hålls i minnet. Detta exempel förutsätter fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ hittar inte nödvändigtvis rätt effekt i en godtycklig presentation.

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

Utdata blir `Rotation preserved: true`. Applicera samma typ‑kontrollsmönster på andra beteenden. För en komplett bevarandekontroll, jämför målformen, effekt, beteendetyper och ordning, timing samt ban‑kommandon. Använd en numerisk tolerans för flyttal. För en presentation med okänt animationslayout, se [Läs formanimationer](/slides/sv/androidjava/shape-animation/#read-shape-animations) för traversering av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [IBehaviorCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehaviorcollection/) är den lagrade ordningen för en effekts operationer. Det är inte en spellista där varje beteende automatiskt väntar på det föregående. Timing och den omgivande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan interagera via [getAdditive](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehavior/#getAdditive--) och [getAccumulate](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Använd inte enbart omsortering av samlingen för att schemalägga “flytta, sedan rotera”; använd explicit timing eller separata effekter som beskrivs i [Formanimation](/slides/sv/androidjava/shape-animation/).

Effektens [getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#getType--) och [getSubtype](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ieffect/#getSubtype--) beskriver dess förinställning. De är inte en komplett beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och kassera dina anpassade operationer. Till exempel kan en förändring från en anpassad Spin‑effekt till Fade ersätta rotationsbeteendet med set‑ och filter‑beteenden. Granska samlingen igen efter att ha ändrat förinställning eller undertyp. Att rensa förinställda beteenden kan också ta bort synlighets‑ eller initieringsoperationer som förinställningen behöver. Exemplen använder medvetet synliga former och ersätter beteendena; de rekonstruerar inte varje förinställnings implementation.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i varje visare eller exportrenderare. Kontrollera sparad data och den renderade utdata separat.

| Format eller utdata | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna igen för att verifiera det redigerbara beteendeträdet, testa sedan uppspelning i avsedd PowerPoint‑version. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; anta inte stöd för varje anpassad kombination enbart utifrån lyckad PPTX‑utdata. |
| PDF, PNG, JPEG och andra statiska bild‑format | Innehåller en statisk bild av sliden, inte en spelbar beteendetidslinje eller garanterad slut‑animationsram. |
| [HTML5](/slides/sv/androidjava/export-to-html5/) | Kan spela stödjade animationer när formanimation är aktiverat i exportalternativen. Testa anpassade kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/) | Lagrar renderade bildrutor, inte redigerbara beteenden eller klick‑utlösande interaktion. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/androidjava/convert-powerpoint-to-video/) | Renderar animationsramar och kodar dem som video. Stödet är begränsat till renderarens [stödda animationer och effekter](/slides/sv/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte en redigerbar tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag har lagt till några?**

Att skapa en förinställd effekt kan generera dess underliggande operationer. Granska dem innan du beslutar om du ska utöka förinställningen eller ersätta dess beteenden.

**Gör det att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning är ingen ersättning för timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slut‑kommando inga punkter?**

Det markerar banans slut och kräver inga koordinater. Kontrollera en null‑punktarray när du granskar en bana läst från en fil.

**Är en lyckad rundresa tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna igen bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspelar‑programmet eller den animerade exporten separat för att bekräfta dess visuella beteende.