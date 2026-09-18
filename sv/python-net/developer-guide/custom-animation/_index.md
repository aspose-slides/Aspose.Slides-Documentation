---
title: Skapa och ändra anpassade animationsbeteenden i Python
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/python-net/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsebana
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa, granska och ändra anpassade animationsbeteenden och redigerbara rörelsebanor i PowerPoint-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Anpassade animationsbeteenden låter dig styra enskilda operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsebana. Denna guide visar hur du skapar och kombinerar beteenden, konfigurerar deras tidsschema, granskar och ändrar befintliga animationer samt verifierar att deras egenskaper överlever sparande och återöppning av en presentation.

För fördefinierade effekter och klickutlösare, se [Shape Animation](/slides/sv/python-net/shape-animation/).

## **Förstå animationsmodellen**

En animation organiseras som **Timeline → Sequence → Effect → Behaviors**:

- Bildens [timeline](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/timeline/) innehåller dess huvudsekvens och interaktiva sekvenser.
- En [Sequence](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/) innehåller effekter, eventuellt med olika målformer.
- En [Effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/) identifierar målformen, förinställning, undertyp och effektens tidsschema.
- [Effect.behaviors](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/behaviors/) innehåller de operationer som implementerar effekten: färgändring, förflyttning, rotation, inställning av en egenskap osv.

## **Skapa enskilda beteenden**

Anropa [Sequence.add_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/sequence/add_effect/) för att skapa en effekt och få åtkomst till dess [behaviors](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/behaviors/)‑samling. En förinställning kan automatiskt fylla denna samling. Behåll dess operationer när du utökar förinställningen, eller använd [clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/clear/) när du avsiktligt ersätter dem.

[BehaviorFactory](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/) skapar de åtta beteendetyper som illustreras nedan. Rörelse behandlas i [Build a Motion Path](#build-a-motion-path). Varje skapelseexempel är ett komplett program; senare redigeringsexempel anger vilken utdatafil de använder.

### **Rotation**

Använd [create_rotation_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) för att skapa en rotation. [by](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/rotationeffect/by/) anger en relativ vinkel i grader; [from_address](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/rotationeffect/from_address/) och [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/rotationeffect/to/) anger ändpunkter.

Exemplet startar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende och ger den operationen en varaktighet på två sekunder. En relativ vinkel på 90 grader motsvarar ett kvarts varv från formens ursprungliga orientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, tidsschemat och rotationsredigeringsexemplen nedan använder denna fil.

### **Skala**

Använd [create_scale_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) med X/Y‑procent: [from_address](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/scaleeffect/from_address/) och [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/scaleeffect/to/) beskriver start‑ och slutstorlek, medan [by](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/scaleeffect/by/) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % under två sekunder. Att använda lika horisontella och vertikala procent håller formens proportioner; olika procent skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [create_color_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) för att ändra fyllningen från blå till orange. [from_address](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/coloreffect/from_address/) och [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/coloreffect/to/) är färger; [by](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/coloreffect/by/) är ett färgförskjutningsvärde. [Behavior.properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behavior/properties/) identifierar den egenskap som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllningsfärgegenskapen talar om för beteendet vilken del av formen som ska ändras; färgens ändpunkter ensam identifierar inte den egenskapen. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

Använd [create_filter_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) för att välja ett svep. [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/filtereffect/subtype/), och [reveal](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/filtereffect/reveal/) anger filtret, riktningen och huruvida formen ska visas eller döljas.

Detta exempel konfigurerar ett tvåsekunders svep som visar formen med subtype för höger‑riktning. Filterinställningarna tillhör beteendet i effekten, så de konfigureras efter att de ursprungliga operationerna i förinställningen har tagits bort.

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

### **Egenskap**

Använd [create_property_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) för att animera opacitet. [from_address](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/propertyeffect/to/), och [by](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/propertyeffect/by/) är strängar som tolkas med hjälp av [value_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/propertyeffect/value_type/) och [calc_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Välj antingen ändpunkter eller ett relativt förskjutningsvärde i stället för att ange alla tre oberoende.

Här är den valda egenskapen opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolering beskriver en gradvis förändring mellan dessa värden. När du anpassar exemplet till en annan egenskap, välj en värdetyp och ändpunktsvärden som är lämpliga för den egenskapen.

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

### **Sätt**

Använd [create_set_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) för att tilldela synlighet via [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/seteffect/to/). Ett set‑beteende interpolerar inte mellan ändpunkter.

Exemplet väljer synlighets‑egenskapen och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i denna minimala presentation, så tilldelningen kanske inte ger någon uppenbar visuell förändring på egen hand. En sådan operation är användbar som del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [create_command_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) och konfigurera [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/commandeffect/command_string/), och [shape_target](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/commandeffect/shape_target/). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [add_audio_frame_embedded](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) och fäster ett spela‑kommando på ljudramen.

Ljudramen är både effektens mål och kommandots mål. Detta kopplar spel‑begäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket mediaobjekt som ska styras. Effekten är konfigurerad att starta på ett klick under bildspelet.

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

Sparandet lagrar kommandot i `command.pptx`; det spelar inte upp inspelningen. Uppspelning kräver en bildspels‑spelare som stödjer kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[BehaviorCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/) stödjer [add](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/remove/), och [remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Detta exempel öppnar `rotation.pptx`, lägger till en skalning, flyttar den före rotationen och tar bort rotationen. Att ta bort och återinfoga samma objekt ändrar dess lagrade position utan att skapa en kopia.

Redigeringssekvensen ändrar samlingen från rotation‑skala till skala‑rotation och slutligen till endast skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den slutgiltiga uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Utdata är `ScaleEffect`: endast skalning återstår. Samlingsordning i sig schemalägger inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendetid**

[Behavior.timing](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behavior/timing/) exponerar [Timing](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/), oberoende av [Effect.timing](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/timing/). Effekttidsschemaläggning styr den omslutande effekten; beteendetid beskriver en operation inuti den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och ange [duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/duration/) samt [trigger_delay_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/trigger_delay_time/) i sekunder, konfigurera sedan [repeat_count](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/accelerate/) och [decelerate](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/decelerate/) är bråkdelar av varaktigheten; håll deras summa högst 1.

Indatafilen är den som skapades i rotations‑exemplet, där det första beteendet är känt som en rotation. Detta exempel ändrar endast det beteendets tidsschema; dess 90‑graders vinkel förblir intakt. Att hålla vinkel och tidsschema separata underlättar justering av hastigheten utan att behöva bygga om animationen.

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

Beteendet använder en varaktighet på två sekunder, en fördröjning på en halv sekund och en upprepningsräkning på 3. De första och sista 20 % av dess varaktighet används för acceleration respektive deceleration.

Andra upprepningspolicyer inkluderar [repeat_duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), och [repeat_until_next_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/repeat_until_next_click/); välj en policy i stället för att aktivera alla samtidigt. [auto_reverse](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/timing/auto_reverse/) spelar animationen baklänges efter framåtpasset. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Bygg en rörelsebana**

Använd [create_motion_effect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) för att skapa rörelse. Dess [from_address](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/to/), och [by](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/by/) beskriver procentbaserade koordinater eller förskjutningar. För en redigerbar bana, skapa en [MotionPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpath/) och tilldela den till [MotionEffect.path](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpath/) lagrar bankommandona.

[MotionCommandPathType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncommandpathtype/) väljer operationen:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Set the starting position. |
| LINE_TO | One | Move along a straight segment to its endpoint. |
| CURVE_TO | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CLOSE_LOOP | None | Return to the starting position. |
| END | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpathpointstype/) beskriver egenskaper för punktredigering, såsom hörn‑ eller mjuka punkter. Den ersätter inte kommandotypen. Använd en kurvpunkttyp för kurxemplet nedan, och en hörnpunkttyp för de raka segmenten.

Bankoordinater normaliseras till bildens dimensioner: en X‑förskjutning på 0,25 motsvarar en fjärdedel av bildbredden, inte 0,25 poäng. Positiv Y går nedåt. Absoluta kommandon specificerar positioner i bana‑koordinatsystemet; relativa kommandon specificerar förskjutningar från den aktuella positionen. Detta är separat från [origin](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/origin/), som väljer referensram för banan, och [path_edit_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak bana**

Skapa ett rörelsebeteende med en startpunkt, ett rakt segment och ett slut‑kommando. [MotionPath.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpath/add/) tar kommandotyp, dess punkter, punkt‑typ och en flagga för relativ koordinat.

Startkommandot etablerar (0, 0) och linjen avslutas vid (0.25, 0), vilket ger banan en horisontell förskjutning på en fjärdedel av bildbredden. Slut‑kommandot har inga koordinatpunkter. När banan är tilldelad kopplas rörelsebeteendet till rektangeln.

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

`motion.pptx` innehåller ett rörelsebeteende med tre bana‑kommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två bana‑objekt beskriver samma rutt. Det absoluta kommandot slutar vid (0.3, 0.1); det relativa kommandot lägger till (0.1, 0.1) på den aktuella positionen, (0.2, 0).

Båda banorna startar på samma position. För den relativa linjen adderas dess X‑ och Y‑förskjutningar till den aktuella positionen för att få slutpunkten; för den absoluta linjen läses slutpunkten direkt. Att bara byta flaggan utan att konvertera koordinaterna skulle beskriva en annan rutt.

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

Tilldela någon av banorna till ett rörelsebeteende för att använda den i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två kontrollpunkterna, följt av slutpunkten.

Startpositionen levereras av föregående kommando. De två första punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punkt‑array tillsammans håller segmentet i linje med dess nya geometri.

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

Banan i `curve.pptx` har fortfarande tre kommandon; dess mittkommando definierar nu en kurva.

## **Granska och redigera en sparad bana**

Varje [MotionCmdPath](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncmdpath/) exponerar [points](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncmdpath/points_type/), och [is_relative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Följande exempel använder den kända tre‑kommandonsbanan i `motion.pptx`. För godtycklig indata, lokalisera den avsedda effekten och kontrollera kommandotyper och punktantal innan du redigerar via index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en `None`‑punkt‑array.

Utdata parar varje kommando med dess relativa‑koordinat‑flagga innan punkterna listas. Detta låter dig skilja på en ändpunkt och ett förskjutningsvärde innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i denna fil listar endast en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0.25, 0), och ett slut‑kommando.

### **Ändra en ändpunkt**

Öppna `motion.pptx` och ersätt linjens punkt‑array för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt ändrar dess destination utan att ändra kommandotyp, tidsschema eller position i samlingen. Eftersom kommandot använder absoluta koordinater specificerar det nya paret en position snarare än ett tillagt förskjutningsvärde.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Linjen i `motion-endpoint.pptx` slutar vid (0.4, 0.1); originalfilen är oförändrad.

### **Ersätt ett segment**

Använd [insert](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpath/insert/) och [remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/motionpath/remove_at/) för att ersätta linjen i `motion.pptx`. Infogning flyttar den gamla linjen till index 2.

Detta demonstrerar att ersätta ett kommandobjekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slutkommandot. Att ta bort index 2 förkastar den gamla linjen och lämnar den nya banan på plats.

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

Den sparade banan har fortfarande tre kommandon, med den nya linjen som slutar vid (0.2, 0.1) och slut‑kommandot sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [RotationEffect](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/rotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter återöppning.

Typkontrollen gör att loopen kan hoppa över beteenden som inte är rotationer. Den andra laddningen läser den sparade filen i ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som fortfarande finns i minnet. Detta exempel förutsätter fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ hittar inte nödvändigtvis rätt effekt i en godtycklig presentation.

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

Utdata är `Rotation preserved: True`. Använd samma typ‑kontrollmönster för andra beteenden. För en fullständig bevarande‑kontroll, jämför målformen, effekt, beteendetyper och ordning, tidsschema samt ban‑kommandon. Använd en numerisk tolerans för flyttalsvärden. För en presentation med okänt animations‑layout, se [Read Shape Animations](/slides/sv/python-net/shape-animation/#read-shape-animations) för traversal av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [BehaviorCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behaviorcollection/) är den lagrade ordningen för en effekts operationer. Den är inte en spellista där varje beteende automatiskt väntar på det föregående. Tidsscheman och den omslutande effekten bestämmer planeringen. Beteenden kan överlappa, och operationer på samma egenskap kan samverka via [additive](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behavior/additive/) och [accumulate](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/behavior/accumulate/). Använd inte bara omordning av samlingen för att schemalägga “flytta, sedan rotera”; använd explicit tidsschema eller separata effekter enligt [Shape Animation](/slides/sv/python-net/shape-animation/).

Effektens [type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/type/) och [subtype](https://reference.aspose.com/slides/sv/python-net/aspose.slides.animation/effect/subtype/) beskriver dess förinställning. De är inte en fullständig beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att byta förinställning kan bygga om samlingen och ta bort dina anpassade operationer. Till exempel kan en modifierad Spin‑effekt som ändras till Fade ersätta dess rotationsbeteende med set‑ och filter‑beteenden. Granska samlingen igen efter att du bytt förinställning eller undertyp. Att rensa förinställda beteenden kan också ta bort synlighets‑ eller initierings‑operationer som förinställningen behöver. Exemplen använder medvetet synliga former och ersätter beteendena; de återuppbygger inte varje förinställnings implementation.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i alla visare eller exportrenderare. Kontrollera sparad data och den renderade utdata separat.

| Format eller utdata | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna igen för att verifiera det redigerbara beteendeträdet, kontrollera sedan uppspelning i den avsedda PowerPoint‑versionen. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; dra inte slutsatsen att alla egna kombinationer stöds bara för att PPTX‑utdata lyckas. |
| PDF, PNG, JPEG och andra statiska bildbilder | Innehåller en statisk bildrepresentation, inte en spelbar beteendetidslinje eller garanterad slut‑animationsram. |
| [HTML5](/slides/sv/python-net/export-to-html5/) | Kan spela stödda animationer när shape animation är aktiverat i exportalternativen. Testa egna kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/) | Lagrar renderade bildrutor, inte redigerbara beteenden eller klick‑utlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/python-net/convert-powerpoint-to-video/) | Renderar animations‑rutor och kodar dem som video. Stödet är begränsat till renderarens [supported animations and effects](/slides/sv/python-net/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte ett redigerbart tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden redan innan jag har lagt till några?**

Att skapa en fördefinierad effekt kan skapa dess underliggande operationer. Granska dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör det att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordning ersätter inte tidsschema. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slut‑kommando inga punkter?**

Det markerar banans slut och kräver inga koordinater. Kontrollera efter en `None`‑punkt‑array när du granskar en bana läst från en fil.

**Är en lyckad runda‑resa tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna igen bekräftar bara att de egenskaper du kontrollerade bevarades. Testa bildspelar‑programmet eller den animerade exporten separat för att bekräfta dess visuella beteende.