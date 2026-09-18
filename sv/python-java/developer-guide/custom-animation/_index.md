---
title: Skapa och ändra anpassade animationsbeteenden i Python via Java
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/python-java/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsebana
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa, inspektera och ändra anpassade animationsbeteenden och redigerbara rörelsebanor i PowerPoint-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Anpassade animationsbeteenden låter dig styra enskilda operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsestrategi. Denna guide visar hur du skapar och kombinerar beteenden, konfigurerar deras timing, inspekterar och ändrar befintliga animationer samt verifierar att deras egenskaper överlever vid sparande och återöppning av en presentation.

För fördefinierade effekter och klickutlösare, se [Formanimation](/slides/sv/python-java/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Metoden [getTimeline](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#getTimeline) returnerar bildens tidslinje, som innehåller dess huvudssekvens och interaktiva sekvenser.
- En [Sequence](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [Effect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/) identifierar målformen, förinställningen, undertypen och effektens timing.
- Samlingen som returneras av [Effect.getBehaviors](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getBehaviors) innehåller de operationer som implementerar effekten: färgändring, förflyttning, rotation, egenskapsinställning med mera.

## **Skapa enskilda beteenden**

Anropa [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) för att skapa en effekt och få åtkomst till samlingen [getBehaviors](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getBehaviors). En förinställning kan automatiskt fylla denna samling. Behåll dess operationer när du utökar förinställningen, eller använd [clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/#clear) när du medvetet ersätter dem.

[BehaviorFactory](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse behandlas i [Bygg en rörelsebana](#build-a-motion-path). Varje kodsnutt inkluderar sina importeringar och startar JVM:n om nödvändigt. Java‑punktobjekt och arrayer skapas via JPype där API‑et kräver dem. Senare redigeringsexempel anger vilken utdatfil de använder.

### **Rotation**

Använd [createRotationEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createRotationEffect) för att skapa en rotation. [getBy](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotationeffect/#getBy) specificerar en relativ vinkel i grader; [getFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotationeffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotationeffect/#getTo) specificerar start‑ och slutpunkter.

Exemplet börjar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en varaktighet på två sekunder. En relativ vinkel på 90 grader motsvarar en fjärdedels vridning från formens ursprungliga orientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, timingen och rotations‑redigeringsexemplen nedan använder denna fil.

### **Skala**

Använd [createScaleEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createScaleEffect) med X/Y‑procent: [getFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/scaleeffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/scaleeffect/#getTo) beskriver start‑ och slutstorlek, medan [getBy](https://reference.aspose.com/slides/sv/python-java/aspose.slides/scaleeffect/#getBy) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procent håller formens proportioner; olika procent skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [createColorEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createColorEffect) för att ändra fyllning från blå till orange. [getFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/coloreffect/#getFrom) och [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/coloreffect/#getTo) är färger; [getBy](https://reference.aspose.com/slides/sv/python-java/aspose.slides/coloreffect/#getBy) är en färgoffset. [Behavior.getProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behavior/#getProperties) identifierar attributet som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllnings‑färgattributet talar om för beteendet vilken del av formen som ska ändras; färgens slutpunkter identifierar inte själva attributet. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

Använd [createFilterEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createFilterEffect) för att välja en svepning. [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filtereffect/#getSubtype) och [getReveal](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filtereffect/#getReveal) specificerar filtret, riktningen och huruvida formen ska visas eller döljas.

Detta exempel konfigurerar en tvåsekunders svepning som visar formen med subtypen för höger‑riktning. Filterinställningarna tillhör beteendet inuti effekten, så de konfigureras efter att de ursprungliga operationerna i förinställningen har tagits bort.

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

### **Egenskap**

Använd [createPropertyEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) för att animera opacitet. [getFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/propertyeffect/#getTo) och [getBy](https://reference.aspose.com/slides/sv/python-java/aspose.slides/propertyeffect/#getBy) är strängar som tolkas med [getValueType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/propertyeffect/#getValueType) och [getCalcMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/propertyeffect/#getCalcMode). Välj slutpunkter eller en relativ offset snarare än att ange alla tre utan tankar.

Här är det valda attributet opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolation beskriver en gradvis förändring mellan dessa värden. När du anpassar detta exempel till ett annat attribut, välj en värdetyp och slutvärden som är lämpliga för det attributet.

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

### **Sätt**

Använd [createSetEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createSetEffect) för att tilldela synlighet via [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/seteffect/#getTo). Ett set‑beteende interpolerar inte mellan slutpunkter.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i denna minimala presentation, så tilldelningen kanske inte ger någon uppenbar visuell förändring på egen hand. En sådan operation är användbar som del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [createCommandEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createCommandEffect) och konfigurera [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commandeffect/#getCommandString) och [getShapeTarget](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commandeffect/#getShapeTarget). Placera en WAV‑inspelning med namn `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [addAudioFrameEmbedded](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) och kopplar ett spela‑kommando till ljudramen.

Ljudramen är både effektens mål och kommandots mål. Detta kopplar uppspelningsbegäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket mediaobjekt som ska styras. Effekten är konfigurerad att starta vid ett klick under bildspelet.

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

Sparning lagrar kommandot i `command.pptx`; det spelar inte upp inspelningen. Uppspelning kräver en bildspelsvisare som stödjer kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[BehaviorCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/) stödjer [add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/#remove) och [removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/#removeAt). Detta exempel öppnar `rotation.pptx`, lägger till skalning, flyttar den före rotation och tar bort rotationen. Att ta bort och återinföra samma objekt ändrar dess lagrade position utan att skapa en kopia.

Redigeringssekvensen ändrar samlingen från rotation–skala till skala–rotation, och sedan till endast skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den slutgiltiga uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Utdata är `ScaleEffect`: endast skalning återstår. Samlingsordning i sig schemalägger inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetiming**

[Behavior.getTiming](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behavior/#getTiming) exponerar [Timing](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/), oberoende av [Effect.getTiming](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getTiming). Effekt‑timing schemalägger den omgivande effekten; beteende‑timing beskriver en operation inuti den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och sätt varaktigheten ([getDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getDuration)) samt trigger‑fördröjning ([getTriggerDelayTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getTriggerDelayTime)) i sekunder, konfigurera sedan repetitionsantalet via [setRepeatCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getAccelerate) och [getDecelerate](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getDecelerate) är bråkdelar av varaktigheten; håll deras summa högst 1.

Inmatningsfilen är den som skapades i rotationsexemplet, där det första beteendet är känt som en rotation. Detta exempel ändrar endast den beteendets timing; dess 90‑graders vinkel förblir intakt. Att hålla vinkel och timing separata gör det enklare att justera takten utan att bygga om animationen.

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

Beteendet använder en tvåsekunders varaktighet, en halvt sekunders fördröjning och ett repetitionsantal på 3. De första och sista 20 % av varaktigheten används för acceleration och deceleration.

Andra repetitionspolicyer inkluderar [getRepeatDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) och [getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getRepeatUntilNextClick); välj en policy istället för att aktivera dem alla samtidigt. [getAutoReverse](https://reference.aspose.com/slides/sv/python-java/aspose.slides/timing/#getAutoReverse) spelar animationen baklänges efter den framåtriktade passagen. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Bygg en rörelsebana**

Använd [createMotionEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorfactory/#createMotionEffect) för att skapa rörelse. Dess [getFrom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#getTo) och [getBy](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#getBy) beskriver procentbaserade koordinater eller offsetar. För en redigerbar bana, skapa en [MotionPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpath/) och tilldela den med [MotionEffect.setPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpath/) lagrar bankommandona.

[MotionCommandPathType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncommandpathtype/) väljer operationen:

| Kommando | Punkter | Betydelse |
| --- | --- | --- |
| MoveTo | En | Sätt startpositionen. |
| LineTo | En | Flytta längs ett rakt segment till dess slutpunkt. |
| CurveTo | Tre | Följ en kubisk kurva definierad av två kontrollpunkter och en slutpunkt. |
| CloseLoop | Ingen | Återvänd till startpositionen. |
| End | Ingen | Avsluta banan. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpathpointstype/) beskriver egenskaper för punktredigering, såsom hörn‑ eller släta punkter. Den ersätter inte kommandotypen. Använd en kurvpunkttyp för kurvexemplet nedan, och en hörnpunkttyp för de raka segmenten.

Bankoordinater normaliseras till bilddimensionerna: en X‑förskjutning på 0,25 motsvarar en fjärdedel av bildens bredd, inte 0,25 punkter. Positiv Y löper nedåt. Absoluta kommandon specificerar positioner i banans koordinatsystem; relativa kommandon specificerar offsetar från aktuell position. Detta är separat från [getOrigin](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#getOrigin), som väljer banans referensram, och [getPathEditMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioneffect/#getPathEditMode), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak bana**

Skapa ett rörelsebeteende med en startpunkt, ett rakt segment och ett slutkommandon. [MotionPath.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpath/#add) tar kommandotypen, dess punkter, punkttypen och en flagga för relativ koordinat.

Startkommandot fastställer (0, 0), och linjen slutar vid (0.25, 0), vilket ger banan en horisontell förflyttning på en fjärdedel av bildens bredd. Slutkommandot har inga koordinatpunkter. När banan har tilldelats, kopplas rörelsebeteendet till effekten och förenar den rutten med rektangeln.

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

`motion.pptx` innehåller ett rörelsebeteende med tre ban-kommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två ban‑objekt beskriver samma rutt. Det absoluta kommandot slutar vid (0.3, 0.1); det relativa kommandot adderar (0.1, 0.1) till den aktuella positionen, (0.2, 0).

Båda banorna startar på samma position. För den relativa linjen adderas X‑ och Y‑offsetarna till den aktuella positionen för att få slutpunkten; för den absoluta linjen läses slutpunkten direkt. Att byta flaggan utan att konvertera koordinaterna skulle beskriva en annan bana.

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

Tilldela någon av banorna till ett rörelsebeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två kontrollpunkterna, följt av slutpunkten.

Startpositionen tillhandahålls av föregående kommando. De första två punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punktarray tillsammans håller segmentet i linje med den nya geometrin.

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

Banan i `curve.pptx` har fortfarande tre kommandon; dess mellersta kommando definierar nu en kurva.

## **Inspektera och redigera en sparad bana**

Varje [MotionCmdPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncmdpath/) exponerar [getPoints](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncmdpath/#getPointsType) och [isRelative](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motioncmdpath/#isRelative). Följande exempel använder den kända tre‑kommandobanan i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och punktantal innan redigering via index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punktarray.

Utdata parar varje numerisk kommandotyp med dess relativa‑koordinat‑flagga innan punkterna listas. Detta låter dig skilja en slutpunkt från en offset innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i denna fil bara listar en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0.25, 0) och ett slutkommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punktarray för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt förändrar dess destination utan att ändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än en tillagd offset.

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

Linjen i `motion-endpoint.pptx` slutar vid (0.4, 0.1); originalfilen är oförändrad.

### **Ersätt ett segment**

Använd [insert](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpath/#insert) och [removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/motionpath/#removeAt) för att ersätta linjen i `motion.pptx`. Infogning flyttar den gamla linjen till index 2.

Detta demonstrerar att ersätta ett kommandobjekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slutkommandot. Att ta bort index 2 kastar den gamla linjen och lämnar den nya rutten på plats.

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

Den sparade banan har fortfarande tre kommandon, med den nya linjen som slutar vid (0.2, 0.1) och slutkommandot sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [RotationEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/rotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter att presentationen har öppnats igen.

Typkontrollen gör att loopen hoppar över beteenden som inte är rotationer. Den andra inläsningen läser den sparade filen i ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som ännu finns i minnet. Detta exempel förutsätter fortfarande att den kända effekten är först i huvudsekvensen; att välja ett beteende efter typ hittar inte rätt effekt i en godtycklig presentation.

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

Utdata är `Rotation preserved: True`. Tillämpa samma typkontrollsmönster på andra beteenden. För en fullständig bevarandekontroll, jämför målformen, effekten, beteendetyper och -ordning, timing samt ban‑kommandon. Använd en numerisk tolerans för flyttalsvärden. För en presentation med okänt animationslayout, se [Läs formanimationer](/slides/sv/python-java/shape-animation/#read-shape-animations) för traversering av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [BehaviorCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behaviorcollection/) är den lagrade ordningen för en effektens operationer. Det är inte en spellista där varje beteende automatiskt väntar på det föregående. Timing och den omgivande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan interagera via [getAdditive](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behavior/#getAdditive) och [getAccumulate](https://reference.aspose.com/slides/sv/python-java/aspose.slides/behavior/#getAccumulate). Använd inte bara omordning av samlingen för att schemalägga ”flytta, sedan rotera”; använd explicit timing eller separata effekter enligt beskrivningen i [Formanimation](/slides/sv/python-java/shape-animation/).

Effektens [getType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getType) och [getSubtype](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effect/#getSubtype) beskriver dess förinställning. De är inte en komplett beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och kasta dina anpassade operationer. Till exempel kan en anpassad Spin‑effekt som ändras till Fade ersätta rotationsbeteendet med set‑ och filter‑beteenden. Inspektera samlingen igen efter att du ändrat förinställning eller undertyp. Att rensa förinställda beteenden kan också ta bort synlighets‑ eller initieringsoperationer som förinställningen behöver. Exemplen använder medvetet synliga former och ersätter beteendena; de rekonstruerar inte varje förinställnings implementation.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i varje visare eller exportrenderare. Kontrollera sparade data och den renderade utdata separat.

| Format eller utdata | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna igen för att verifiera det redigerbara beteendeträdet, kontrollera sedan uppspelning i avsedd PowerPoint‑version. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; dra inte slutsatsen att varje anpassad kombination stöds bara för att PPTX‑utdata lyckas. |
| PDF, PNG, JPEG och andra statiska bild‑bilder | Innehåller en statisk bildrepresentation, inte en spelbar beteendetidslinje eller en garanterad slutanimationsram. |
| [HTML5](/slides/sv/python-java/export-to-html5/) | Kan spela stödjade animationer när formanimation är aktiverad i exportalternativen. Testa anpassade kombinationer i webbläsaren. |
| [Animera GIF](/slides/sv/python-java/convert-powerpoint-to-animated-gif/) | Sparar renderade ramar, inte redigerbara beteenden eller klick‑utlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/python-java/convert-powerpoint-to-video/) | Renderar animationsramar och kodar dem som video. Stödet är begränsat till renderarens [stödda animationer och effekter](/slides/sv/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte en redigerbar tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag har lagt till några?**

Att skapa en fördefinierad effekt kan skapa dess underliggande operationer. Inspektera dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör det att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning är ingen ersättning för timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slut‑kommando inga punkter?**

Det markerar banans slut och kräver inga koordinater. Kontrollera en null‑punktarray när du inspekterar en bana som lästs från en fil.

**Är en lyckad runda resa tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna igen bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspelsvisaren eller den animerade exporten separat för att bekräfta dess visuella beteende.