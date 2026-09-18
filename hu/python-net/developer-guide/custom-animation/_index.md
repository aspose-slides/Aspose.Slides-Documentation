---
title: Egyéni animációs viselkedések létrehozása és módosítása Pythonban
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/python-net/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgási útvonal
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Egyéni animációs viselkedések és szerkeszthető mozgási útvonalak létrehozása, ellenőrzése és módosítása PowerPoint prezentációkban az Aspose.Slides for Python segítségével .NET környezetben."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik egy animációs hatás egyes műveleteinek vezérlését, például szín módosítását, alakzat forgatását vagy egy szerkeszthető mozgási útvonal követését. Ez az útmutató bemutatja, hogyan hozhatók létre és kombinálhatók a viselkedések, hogyan állítható be az időzítésük, hogyan ellenőrizhetők és módosíthatók a meglévő animációk, valamint hogyan ellenőrizhető, hogy a tulajdonságaik megmaradnak-e a bemutató mentése és újra megnyitása után.

For predefined effects and click triggers, see [Alakzat animáció](/slides/hu/python-net/shape-animation/).

## **Ismerje meg az animációs modellt**

Az animáció a következőképpen van szervezve: **Timeline → Sequence → Effect → Behaviors**:

- Az dián található [timeline](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/timeline/) tartalmazza a fő sorrendet és az interaktív sorozatokat.
- Egy [Sequence](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/) tartalmazza a hatásokat, amelyek különböző alakzatokat célozhatnak.
- Egy [Effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/) meghatározza a célt alakzatot, az előbeállítást, az al‑típust és az animáció időzítését.
- [Effect.behaviors](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/behaviors/) tartalmazza a műveleteket, amelyek megvalósítják a hatást: szín módosítása, mozgatás, forgatás, tulajdonság beállítása, stb.

## **Egyéni viselkedések létrehozása**

Hívja meg a [Sequence.add_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/add_effect/) metódust egy hatás létrehozásához, és érje el annak [behaviors](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/behaviors/) gyűjteményét. Egy előbeállítás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteket, ha kibővíti az előbeállítást, vagy használja a [clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/clear/) metódust szándékosan történő helyettesítéskor.

[BehaviorFactory](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/) létrehozza az alább illusztrált nyolc viselkedéstípust. A mozgásról a [Build a Motion Path](#build-a-motion-path) részben olvashat. Minden létrehozási példa teljes program; a későbbi szerkesztési példák jelzik, melyik kimeneti fájlt használják.

### **Forgatás**

Használja a [create_rotation_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) metódust forgatás létrehozásához. A [by](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/rotationeffect/by/) relatív szöget ad meg fokban; a [from_address](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/rotationeffect/from_address/) és a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/rotationeffect/to/) a végpontokat definiálják.

A példa egy Spin hatással kezd, lecseréli annak előbeállított műveleteit egy forgatási viselkedésre, és két másodperces időtartamot ad ennek. A 90 fokos relatív szög egy negyedfordulatot jelent a alakzat kiindulási tájolásához képest, ezért nincs szükség kifejezett kezdőszögre.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény‑, időzítés‑ és forgatás‑szerkesztési példák ezt a fájlt használják.

### **Méretezés**

Használja a [create_scale_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) metódust X/Y százalékokkal: a [from_address](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/scaleeffect/from_address/) és a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/scaleeffect/to/) a kezdeti és végső méretet írja le, míg a [by](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/scaleeffect/by/) egy relatív változást határoz meg. Itt a 100 az eredeti méretet jelenti.

A példa mindkét dimenziót 100 %‑ról 125 %‑ra növeli két másodperc alatt. Egyenlő vízszintes és függőleges százalékok megőrzik az alakzat arányait; eltérő százalékok egy dimenziót jobban nyújtanak, mint a másikat.

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

### **Szín**

Használja a [create_color_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) metódust a kitöltés kékből narancssárgára változtatásához. A [from_address](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/coloreffect/from_address/) és a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/coloreffect/to/) színek, a [by](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/coloreffect/by/) színeltolás. A [Behavior.properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behavior/properties/) határozza meg az animált attribútumot.

Az alakzat szilárd kitöltése kék színre van inicializálva, ami megegyezik az animáció kezdeti színével. A kitöltés‑szín attribútum kiválasztása azt mondja meg a viselkedésnek, melyik részt kell változtatni; a szín‑végpontok önmagukban nem határozzák meg az attribútumot. A mentett hatás egy két másodperces átmenetet ír le a narancssárga felé.

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

### **Szűrő**

Használja a [create_filter_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) metódust egy törlés (wipe) kiválasztásához. A [type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/filtereffect/type/), a [subtype](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/filtereffect/subtype/) és a [reveal](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/filtereffect/reveal/) határozzák meg a szűrőt, az irányt és hogy a alakzatot felfedje vagy elrejtse.

Ez a példa két másodperces törlést konfigurál, amely a jobb‑irányú al‑típussal fedi fel az alakzatot. A szűrő beállításai a hatáson belüli viselkedéshez tartoznak, ezért az előbeállított eredeti műveletek eltávolítása után kerülnek beállításra.

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

### **Tulajdonság**

Használja a [create_property_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) metódust az átlátszatlanság (opacity) animálásához. A [from_address](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/propertyeffect/from_address/), a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/propertyeffect/to/) és a [by](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/propertyeffect/by/) sztringek, amelyeket a [value_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/propertyeffect/value_type/) és a [calc_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/propertyeffect/calc_mode/) értelmez. Válasszon végpontokat vagy relatív eltolást, ahelyett, hogy mindhárom paramétert egyszerre állítaná be.

Itt a kiválasztott attribútum az átlátszatlanság, és a numerikus sztringek egy 25 %‑os átlátszatlanságból a teljes átlátszatlanságba történő változást jelentik. A lineáris interpoláció fokozatos változást ír le ezek között az értékek között. Ha a példát más attribútumra adaptálja, válasszon megfelelő értéktípust és végpont értékeket az adott attribútumhoz.

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

### **Beállítás**

Használja a [create_set_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) metódust láthatóság hozzárendeléséhez a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/seteffect/to/) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumát választja, és a viselkedés futásakor a `visible` sztringet rendeli hozzá. Az egyenes prezentációban a téglalap már látható, így a hozzárendelés önmagában nem feltétlenül eredményez nyilvánvaló vizuális változást. Az ilyen művelet nagyobb hatás részeként hasznos, amely egyúttal szabályozza, hogy az alakzat mikor válik rejtetté vagy láthatóvá.

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

### **Parancs**

Használja a [create_command_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) metódust, és állítsa be a [type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/commandeffect/type/), a [command_string](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/commandeffect/command_string/) és a [shape_target](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/commandeffect/shape_target/) paramétereket. Helyezzen egy `sample.wav` nevű WAV felvételt a munkakönyvtárba. Ez a példa a [add_audio_frame_embedded](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) segítségével ágyazza be, majd lejátszási parancsot csatol az audio kerethez.

Az audio keret egyszerre a hatás és a parancs célja. Ez összekapcsolja a lejátszási kérést a beágyazott felvétellel; egy parancssztring önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. A hatás úgy van konfigurálva, hogy a diavetítés során kattintásra induljon.

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

A mentés a `command.pptx` fájlba tárolja a parancsot; nem játsza le a felvételt. A lejátszáshoz olyan diavetítő‑lejátszóra van szükség, amely támogatja a parancsot és a hozzá tartozó médiacélpontot.

## **A viselkedésgyűjtemény kezelése**

[BehaviorCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/remove/) és a [remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/remove_at/) műveleteket. Ez a példa megnyitja a `rotation.pptx` fájlt, hozzáad egy méretezést, a forgatás elé helyezi, majd eltávolítja a forgatást. Ugyanannak az objektumnak a eltávolítása és újra‑beszúrása megváltoztatja a tárolt pozíciót anélkül, hogy másolat jönne létre.

A szerkesztések sorozata a gyűjteményt a forgatás‑méretezés → méretezés‑forgatás → csak méretezés állapotra változtatja. Az indexek az aktuális gyűjteményre vonatkoznak, így az eltávolítás a forgatás új indexét használja a rendezés után. A végső felsorolás megerősíti, melyik viselkedés lesz mentve.

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

A kimenet `ScaleEffect`: csak a méretezés maradt meg. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor törölje, ha minden műveletet helyettesít.

## **A viselkedés időzítésének beállítása**

[Behavior.timing](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behavior/timing/) felfedi a [Timing](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/)-et, függetlenül az [Effect.timing](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/timing/)-től. Az effektus időzítése a körülvevő hatást ütemezi; a viselkedés időzítése egy műveletet ír le benne.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx` fájlt, és állítsa be a [duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/duration/) és a [trigger_delay_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/trigger_delay_time/) értékeket másodpercben, majd konfigurálja a [repeat_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_count/)-ot. A [accelerate](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/accelerate/) és a [decelerate](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/decelerate/) az időtartam töredékei; összegük legfeljebb 1 legyen.

A bemeneti fájl a forgatás‑példában létrehozott, ahol az első viselkedés biztosan forgatás. Ez a példa csak annak a viselkedésnek az időzítését módosítja; a 90‑°‑os szög változatlan marad. A szög és az időzítés különválasztása könnyebbé teszi a tempó finomhangolását a hatás újraépítése nélkül.

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

A viselkedés két másodperces időtartamot, fél másodperces késleltetést és 3‑as ismétlésszámot használ. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra van fenntartva.

Egyéb ismétlési szabályok: [repeat_duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), és [repeat_until_next_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/repeat_until_next_click/); válasszon egy szabályt, ahelyett, hogy mindet egyszerre engedélyezné. Az [auto_reverse](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/timing/auto_reverse/) a forward áthaladást követően visszafelé játssza le az animációt. A gyorsulás és lassulás folytonos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgási útvonal létrehozása**

Használja a [create_motion_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) metódust mozgás létrehozásához. A [from_address](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/from_address/), a [to](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/to/) és a [by](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/by/) százalékos koordinátákat vagy eltolásokat ír le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpath/)-t, és rendelje hozzá a [MotionEffect.path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/path/)-hez. A [MotionPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpath/) tárolja az útvonalparancsokat.

[MotionCommandPathType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncommandpathtype/) a műveletet választja:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MOVE_TO | Egy | A kezdőpozíció beállítása. |
| LINE_TO | Egy | Egyenes szakaszon mozgatás a végpontjáig. |
| CURVE_TO | Három | Követ egy köbös görbét, amelyet két irányító pont és egy végpont határoz meg. |
| CLOSE_LOOP | Nincs | Visszatérés a kezdőpozícióba. |
| END | Nincs | Az útvonal befejezése. |

[MotionPathPointsType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpathpointstype/) leírja a pont‑szerkesztés jellemzőit, például sarkos vagy sima pontokat. Nem helyettesíti a parancs‑típust. Görbe példa esetén használjon curve ponttípust, egyenes szegmenseknél corner ponttípust.

Az útvonal koordinátái a dia méreteihez vannak normalizálva: egy 0,25‑os X‑eltolás a dia szélességének egy négyedét jelenti, nem 0,25 pontot. A pozitív Y lefelé fut. Az abszolút parancsok pozíciókat adnak meg az útvonal‑koordináta‑rendszerben; a relatív parancsok az aktuális pozícióhoz képest definiálnak eltolásokat. Ez külön van az [origin](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/origin/)-tól, amely az útvonal referenciarendszerét választja, és a [path_edit_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioneffect/path_edit_mode/)-tól, amely azt szabályozza, hogy az útvonal hogyan mozdul a forma mozgatásakor.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgási viselkedést egy kiindulási ponttal, egy egyenes szegmenssel és egy END parancssal. A [MotionPath.add](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpath/add/) a parancstípust, a pontokat, a ponttípust és egy relatív‑koordináta‑jelzőt veszi át.

A kezdőparancs (0, 0)-t állít be, a vonal (0,25, 0)-ra végződik, így a út egy vízszintes eltolást kap a dia szélességének egy négyedével. Az befejező parancsnak nincs koordinátapontja. Miután az út be lett rendelve, a mozgási viselkedés hozzáadása a hatáshoz összeköti ezt az útvonalat a téglalappal.

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

`motion.pptx` egy mozgási viselkedést és három útparancsot tartalmaz. A következő fájlszerkesztési példák ezt a felépítést használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ezek a két útobjektum ugyanazt az útvonalat írja le. Az abszolút parancs (0,3, 0,1)-nél ér véget; a relatív parancs (0,1, 0,1)-t ad az aktuális pozícióhoz, (0,2, 0)-hoz.

Mindkét út ugyanabban a pontban kezdődik. A relatív vonal esetén adja hozzá az X‑ és Y‑eltolást az aktuális pozícióhoz a végpont meghatározásához; az abszolút vonalnál a végpontot közvetlenül olvassa. A jelző átváltása a koordináták átalakítása nélkül másik útvonalat eredményezne.

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

Rendeljen bármelyik útvonalat egy mozgási viselkedéshez a prezentációban. A záró Boolean argumentum a relatív koordinátákat választja ki az adott parancshoz.

### **Vonal helyettesítése görbével**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonalparancsot egy köbös görbére. Először adja meg a két irányító pontot, majd a végpontot.

A kezdőpozíciót az előző parancs biztosítja. Az első két pont alakítja a görbét, míg a harmadik a célpont; nem három egymást követő célpontról van szó. A parancstípus, a pont‑szerkesztési típus és a ponttömb egyszerre történő frissítése következetesé teszi a szegmenst az új geometriával.

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

A `curve.pptx` útvonalában még mindig három parancs van; a középső parancs most egy görbét definiál.

## **Mentett útvonal ellenőrzése és szerkesztése**

Minden [MotionCmdPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncmdpath/) a [points](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncmdpath/points/), a [command_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncmdpath/command_type/), a [points_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncmdpath/points_type/) és az [is_relative](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motioncmdpath/is_relative/) attribútumokat teszi elérhetővé. Az alábbi példák a `motion.pptx` háromparancsos útvonalát használják. Tetszőleges bemenet esetén helyezze a kívánt hatást, és ellenőrizze a parancstípusokat és a pontszámokat, mielőtt index alapján szerkesztené.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat módosítás nélkül. A END és a CLOSE_LOOP parancsok nem igényelnek pontokat, ezért engedélyezzen egy `None` ponttömböt.

A kimenet minden parancshoz párosítja a relatív‑koordináta‑jelzőt, mielőtt a pontjait felsoroznátja. Ez lehetővé teszi, hogy a módosítás előtt megkülönböztesse a végpontot az eltolástól. A görbe három pontot sorol fel, míg a jelen fájlban a egyenes vonal csak egy pontot tartalmaz.

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

A felsorolás egy kezdőpontot, egy abszolút vonalat (0,25, 0) végződéssel és egy END parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal ponttömbjét a végpont áthelyezéséhez.

A bemeneti fájlban az index 0 a kezdőparancs, az index 1 a vonal. A vonal egyetlen pontjának cseréje a célpontot változtatja meg, anélkül, hogy a parancstípust, az időzítést vagy a gyűjteményben betöltött pozíciót módosítaná. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót jelöl, nem egy hozzáadott eltolást.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

A `motion-endpoint.pptx` fájlban a vonal (0,4, 0,1)-nél ér véget; az eredeti fájl változatlan.

### **Szegmens cseréje**

Használja a [insert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpath/insert/) és a [remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/motionpath/remove_at/) metódusokat a `motion.pptx` vonalának helyettesítéséhez. Beszúráskor a régi vonal az index 2‑re tolódik.

Ez azt mutatja, hogyan cserélhetünk egy parancsobjektumot a meglévő koordináták szerkesztése helyett. Beszúrás után a gyűjtemény ideiglenesen a kezdőparancsot, az új vonalat, a régi vonalat és az END parancsot tartalmazza. A 2‑es index eltávolítása eldobja a régi vonalat, és a új útvonal marad a helyén.

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

A mentett útvonal továbbra is három parancsot tartalmaz, a új vonal (0,2, 0,1)-nél ér véget, az END parancs az utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Amikor a viselkedés indexe ismeretlen, válassza ki típus szerint. Ez a példában megnyitja a `rotation.pptx` fájlt, megtalálja a [RotationEffect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/rotationeffect/)-et, megváltoztatja a szöget, majd újra megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgatás típusú viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációobjektumba olvassa be, így az összehasonlítás a perszisztált adatokat vizsgálja, nem a memóriában még élő értéket. Ez a példa továbbra is azt feltételezi, hogy a ismert hatás az első a fő sorozatban; típus szerinti kiválasztás nem feltétlenül helyezi el a helyes hatást egy tetszőleges prezentációban.

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

A kimenet `Rotation preserved: True`. Alkalmazza ugyanazt a típus‑ellenőrző mintát más viselkedésekre is. A teljes megőrzés ellenőrzéséhez hasonlítsa össze a célt alakzatot, a hatást, a viselkedéstípusokat és sorrendet, az időzítést, valamint az útparancsokat. Használjon numerikus toleranciát a lebegőpontos értékekhez. Ismeretlen animációs elrendezésű bemutató esetén tekintse meg a [Read Shape Animations](/slides/hu/python-net/shape-animation/#read-shape-animations) oldalt a fő és interaktív sorozatok bejárásához.

## **Viselkedés sorrendje, előbeállítások és lejátszás**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behaviorcollection/) sorrendje a hatás műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan a megelőzőre vár. Az időzítés és a körülvevő hatás határozza meg a menetrendet. A viselkedések átfedhetnek, és egyazon tulajdonságon végzett műveletek kölcsönhatásba léphetnek az [additive](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behavior/additive/) és [accumulate](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/behavior/accumulate/) segítségével. Ne használja a gyűjtemény újrarendezését egy “mozgatás, majd forgatás” ütemezéshez; használjon explicit időzítést vagy külön hatásokat, ahogyan a [Alakzat animáció](/slides/hu/python-net/shape-animation/) leírja.

A hatás [type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/type/) és [subtype](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effect/subtype/) az előbeállítást írja le. Ezek nem adnak teljes leírást egy szerkesztett viselkedésfáról. Válassza ki a presetet és az al‑típust a viselkedések testreszabása előtt: a preset megváltoztatása újraépítheti a gyűjteményt és eldobhatja az egyedi műveleteket. Például egy testreszabott Spin hatás Fade‑re változtatása helyettesítheti a forgatási viselkedést set és filter viselkedésekkel. A preset vagy al‑típus megváltoztatása után ellenőrizze újra a gyűjteményt. A preset viselkedések törlése eltávolíthatja a láthatóság vagy inicializálás műveleteket, amelyekre a presetnek szüksége van. A példák szándékosan látható alakzatokat használnak, és a viselkedéseket helyettesítik; nem rekonstruálják minden preset megvalósítását.

## **Formátum kompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden megjelenítőben vagy export‑renderelőben. A mentett adatokat és a renderelt kimenetet külön ellenőrizze.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Használja elsődleges formátumként a példákhoz. Nyissa újra, hogy ellenőrizze a szerkeszthető viselkedésfát, majd tesztelje a lejátszást a kívánt PowerPoint verzióval. |
| PPT | A régi bináris reprezentáció eltérhet a PPTX‑től. Végezzen külön mentés‑újra‑megnyitás ciklust és lejátszási tesztet; ne vonjon le következtetéseket minden egyedi kombináció támogatottságáról a sikeres PPTX‑kimenetből. |
| PDF, PNG, JPEG és egyéb statikus diaképek | Statikus dia reprezentációt tartalmaznak, nem lejátszható animációs idővonalat vagy garantált véganimációs képkockát. |
| [HTML5](/slides/hu/python-net/export-to-html5/) | Képes lejátszani a támogatott animációkat, ha az export beállításokban engedélyezve van a shape animation. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/python-net/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑indított interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/python-net/convert-powerpoint-to-video/) | Rendereli az animációs képkockákat és videóvá kódolja őket. A támogatás korlátozott a renderelő [supported animations and effects](/slides/hu/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) listájára; a parancsok és interaktív események nem válnak szerkeszthető idővonalra. |

## **GYIK**

**Miért tartalmaz az effektusom viselkedéseket, mielőtt hozzáadnék bármilyet?**

Az előre definiált hatás létrehozása a mögöttes műveleteket is generálhatja. Ellenőrizze ezeket, mielőtt eldöntené, hogy kibővíti a presetet vagy helyettesíti a viselkedéseket.

**A viselkedés elejére helyezése azt eredményezi, hogy először játszódik le?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, az időtartamokat és az ugyanazon tulajdonságon végzett műveletek közötti kölcsönhatásokat.

**Miért nem tartalmaz pontokat egy END parancs?**

Az END a útvonal végét jelöli, és nem igényel koordinátákat. Ellenőrizze, hogy `None` ponttömb van‑e, amikor egy fájlból beolvasott útvonalat vizsgál.

**Elégséges egy sikeres round‑trip a lejátszás megerősítéséhez?**

Nem. Az újra‑megnyitás csak a vizsgált tulajdonságok megmaradását igazolja. Tesztelje a diavetítő‑lejátszót vagy az animált exportot külön, hogy megerősítse a vizuális viselkedést.