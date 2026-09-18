---
title: Egyéni animációs viselkedések létrehozása és módosítása Pythonban Java segítségével
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/python-java/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgásútvonal
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Egyéni animációs viselkedések és szerkeszthető mozgásútvonalak létrehozása, ellenőrzése és módosítása PowerPoint prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik, hogy egy animációs hatás egyes műveleteit szabályozza, például szín módosítását, alakzat forgatását vagy egy szerkeszthető mozgásútvonal követését. Ez az útmutató bemutatja, hogyan hozhat létre és kombinálhat viselkedéseket, konfigurálhatja azok időzítését, ellenőrizheti és módosíthatja a meglévő animációkat, valamint ellenőrizheti, hogy a tulajdonságaik megmaradnak‑e a prezentáció mentése és újranyitása után.

Előre definiált hatások és kattintásindítók esetén lásd a [Alakzat animáció](/slides/hu/python-java/shape-animation/).

## **Az animációs modell megértése**

Egy animáció a **Timeline → Sequence → Effect → Behaviors** struktúrába van szervezve:

- A [getTimeline](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getTimeline) metódus visszaadja a dia idővonalát, amely tartalmazza a fő sorozatát és az interaktív sorozatokat.
- A [Sequence](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/) tartalmaz hatásokat, esetleg különböző alakzatokra mutatva.
- Az [Effect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/) meghatározza a célalakzatot, az előbeállítást, az alcsaládot és a hatás időzítését.
- Az [Effect.getBehaviors](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getBehaviors) által visszaadott gyűjtemény tartalmazza a hatás megvalósításához szükséges műveleteket: színváltoztatás, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

Hívja a [Sequence.addEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sequence/#addEffect) metódust egy hatás létrehozásához, és érje el a [getBehaviors](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getBehaviors) gyűjteményt. Egy előbeállítás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteket az előbeállítás bővítésekor, vagy használja a [clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/#clear) metódust, ha szándékosan felül szeretné írni őket.

[BehaviorFactory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/) létrehozza az alább illusztrált nyolc viselkedéstípust. A mozgás a [Build a Motion Path](#build-a-motion-path) című szakaszban kerül tárgyalásra. Minden kódrészlet tartalmazza a szükséges importokat, és ha kell, elindítja a JVM‑et. A Java pontobjektumok és tömbök JPype‑on keresztül jönnek létre, ahol az API megköveteli őket. A későbbi szerkesztési példák jelzik, melyik kimeneti fájlt használják.

### **Forgatás**

Használja a [createRotationEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createRotationEffect) metódust egy forgatás létrehozásához. A [getBy](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotationeffect/#getBy) relatív szöget ad meg fokban; a [getFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotationeffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotationeffect/#getTo) a végpontokat határozzák meg.

A példa egy Spin hatással kezd, lecseréli annak előbeállítási műveleteit egy forgatási viselkedésre, és két másodperces időtartamot ad ennek. A 90 fokos relatív szög egy negyedfordulatot jelent a kiinduló tájolásból, így nem szükséges explicit kezdőszög.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény‑, időzítés‑ és forgatás‑szerkesztési példák ezt a fájlt használják.

### **Skálázás**

Használja a [createScaleEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createScaleEffect) metódust X/Y százalékokkal: a [getFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/scaleeffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/scaleeffect/#getTo) a kezdeti és végső méretet írja le, míg a [getBy](https://reference.aspose.com/slides/hu/python-java/aspose.slides/scaleeffect/#getBy) relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa mindkét dimenziót 100 %‑ról 125 %‑ra növeli két másodperc alatt. Azonos vízszintes és függőleges százalékok megőrzik az alakzat arányait; eltérő százalékok az egyik dimenziót erősebben nyújtják.

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

### **Szín**

Használja a [createColorEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createColorEffect) metódust a kitöltés kékből narancssárgára változtatásához. A [getFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/coloreffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/coloreffect/#getTo) színek, a [getBy](https://reference.aspose.com/slides/hu/python-java/aspose.slides/coloreffect/#getBy) színeltolás. A [Behavior.getProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behavior/#getProperties) határozza meg az animált attribútumot.

Az alakzat szilárd kitöltése kék, ami megegyezik a animáció kezdőszínével. A kitöltő‑szín attribútum kiválasztása meghatározza, melyik részt kell módosítani; a szín‑végpontok önmagukban nem határozzák meg az attribútumot. A mentett hatás két másodperces átmenetet ír le a narancssárga felé.

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

### **Szűrő**

Használja a [createFilterEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createFilterEffect) metódust egy törlés (wipe) kiválasztásához. A [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filtereffect/#getType), a [getSubtype](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filtereffect/#getSubtype) és a [getReveal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filtereffect/#getReveal) határozza meg a szűrőt, az irányt és azt, hogy a forma megjelenik‑e vagy elrejtő‑e.

Ez a példa egy jobb‑irányú alcsaládú két másodperces törlést konfigurál, amely a formát megjeleníti. A szűrőbeállítások a hatáson belüli viselkedéshez tartoznak, ezért a preset eredeti műveletei eltávolítása után kerülnek beállításra.

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

### **Tulajdonság**

Használja a [createPropertyEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) metódust az átlátszóság animálásához. A [getFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/propertyeffect/#getFrom), a [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/propertyeffect/#getTo) és a [getBy](https://reference.aspose.com/slides/hu/python-java/aspose.slides/propertyeffect/#getBy) karakterláncok, amelyeket a [getValueType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/propertyeffect/#getValueType) és a [getCalcMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/propertyeffect/#getCalcMode) értelmez. Válasszon végpontokat vagy relatív eltolást, a háromat egyszerre nem kell mind beállítani.

Itt a kiválasztott attribútum az átlátszóság, a szám‑karakterláncok pedig a 25 %‑os átlátszóságtól a teljes átlátszóságig tartó változást jelölik. A lineáris interpoláció fokozatos változást ír le ezen értékek között. Más attribútum esetén válasszon megfelelő értéktípust és végpontértékeket.

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

### **Beállítás**

Használja a [createSetEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createSetEffect) metódust a láthatóság [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/seteffect/#getTo) segítségével történő hozzárendeléséhez. A beállítási viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumot választja, és a viselkedés futásakor a `visible` karakterláncot rendeli hozzá. A téglalap már látható ebben a minimális prezentációban, így a hozzárendelés önmagában nem biztos, hogy nyilvánvaló vizuális változást eredményez. Az ilyen művelet egy nagyobb hatás részeként hasznos, amely egyúttal szabályozza, mikor legyen a forma rejtett vagy látható.

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

### **Parancs**

Használja a [createCommandEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createCommandEffect) metódust, és állítsa be a [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commandeffect/#getType), a [getCommandString](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commandeffect/#getCommandString) és a [getShapeTarget](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commandeffect/#getShapeTarget) értékeket. Egy `sample.wav` nevű WAV‑felvételt helyezzen a munkakönyvtárba. A példa ezt beágyazza a [addAudioFrameEmbedded](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) segítségével, és egy lejátszó parancsot kapcsol az audio‑kerethez.

Az audio‑keret egyszerre a hatás és a parancs célpontja. Így a lejátszási kérelem az beágyazott felvételhez kapcsolódik; egy puszta parancs‑sztring önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. A hatás úgy van beállítva, hogy a diavetítés során kattintásra induljon.

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

A mentés a parancsot a `command.pptx` fájlba menti; nem játssza le a felvételt. Lejátszáshoz olyan diavetítő lejátszóra van szükség, amely támogatja a parancsot és annak média‑célpontját.

## **A viselkedésgyűjtemény kezelése**

[BehaviorCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/#remove) és a [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/#removeAt) műveleteket. Ez a példa megnyitja a `rotation.pptx`‑t, hozzáad egy skálázást, a forgatás elé helyezi, majd eltávolítja a forgatást. Ugyanazon objektum eltávolítása és újbóli beszúrása módosítja a tárolt pozíciót anélkül, hogy másolatot készítene.

A szerkesztési sorozat a gyűjteményt forgatás–skálázásról skálázás–forgatásra, végül csak skálázásra változtatja. Az indexek a aktuális gyűjteményre vonatkoznak, ezért a törlés a forgatás új indexét használja az átrendezés után. A végső felsorolás megerősíti, melyik viselkedés kerül mentésre.

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

Az eredmény `ScaleEffect`: csak a skálázás maradt. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor törölje, ha az összes műveletet fel akarja cserélni.

## **A viselkedés időzítésének konfigurálása**

[Behavior.getTiming](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behavior/#getTiming) a [Timing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/) objektumot adja vissza, függetlenül az [Effect.getTiming](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getTiming)-tól. A hatás időzítése az egész hatást ütemezi; a viselkedés időzítése a benne lévő műveletet írja le.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx`‑t, és állítsa be az időtartamot ([getDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getDuration)) valamint a trigger‑késleltetést ([getTriggerDelayTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getTriggerDelayTime)) másodpercben, majd konfigurálja az ismétlésszámot a [setRepeatCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#setRepeatCount) segítségével. A [getAccelerate](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getAccelerate) és a [getDecelerate](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getDecelerate) a teljes időtartam tört részei; összegük legfeljebb 1 legyen.

A bemeneti fájl a forgatás példában létrehozott fájl, ahol az első viselkedés ismert, hogy forgatás. Ez a példa csak ennek a viselkedésnek az időzítését módosítja; a 90 fokos szög érintetlen marad. Az időzítés és a szög különválasztása megkönnyíti a tempó módosítását a teljes animáció újjáépítése nélkül.

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

A viselkedés két másodperces időtartamot, fél másodperces késleltetést és 3‑as ismétlésszámot használ. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra szolgál.

Egyéb ismétlési politikák: [getRepeatDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) és [getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getRepeatUntilNextClick); válasszon egy politikát, ahelyett, hogy mindet egyszerre engedélyezné. A [getAutoReverse](https://reference.aspose.com/slides/hu/python-java/aspose.slides/timing/#getAutoReverse) a forward lépés után visszafelé játssza le az animációt. A gyorsulás és lassulás folytonos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgásútvonal létrehozása**

Használja a [createMotionEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorfactory/#createMotionEffect) metódust a mozgás létrehozásához. A [getFrom](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#getFrom), a [getTo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#getTo) és a [getBy](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#getBy) százalékos koordinátákat vagy eltolásokat ír le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpath/) objektumot, és rendelje hozzá a [MotionEffect.setPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#setPath) metódussal. A [MotionPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpath/) tárolja az útvonalkommandókat.

[MotionCommandPathType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncommandpathtype/) választja ki a műveletet:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | Beállítja a kezdőpozíciót. |
| LineTo | Egy | Egyenes szakaszon mozog a végpontig. |
| CurveTo | Három | Követ egy köbös görbét, amelyet két irányító pont és egy végpont definiál. |
| CloseLoop | Nincs | Visszatér a kiinduló pozícióba. |
| End | Nincs | Befejezi az útvonalat. |

[MotionPathPointsType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpathpointstype/) leírja a pont‑szerkesztési jellemzőket, például sarok‑ vagy sima pontokat. Nem helyettesíti a parancstípust. A görbe példához használjon curve‑point típust, a egyenes szakaszokhoz corner‑point típust.

Az útvonal koordinátáit a dia méreteihez viszonyítva normalizálják: a 0.25 X‑eltolás a dia szélességének egynegyedét jelenti, nem 0.25 pontot. A pozitív Y lefelé halad. Az abszolút parancsok a koordináta‑rendszerben adják meg a pozíciót, a relatív parancsok a jelenlegi pozícióhoz képest adják meg az eltolást. Ez különbözik a [getOrigin](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#getOrigin) által kiválasztott referenciaképrendszertől, valamint a [getPathEditMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioneffect/#getPathEditMode) által szabályozott útvonal‑mozgatási módoktól.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgás‑viselkedést egy kezdőponttal, egy egyenes szegmessel és egy végparancssal. A [MotionPath.add](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpath/#add) a parancstípust, a pontokat, a pont‑típust és a relatív‑koordináta‑jelzőt veszi fel.

A kezdőparancs (0, 0)-t állít be, a vonal (0.25, 0)-ra végződik, így az útvonal a dia szélességének egynegyedével vízszintesen eltolódik. A befejező parancsnak nincs koordinátapontja. Amint az útvonalat hozzárendeljük, a mozgás‑viselkedés hozzáadása az effektushoz ezt az útvonalat a téglalaphoz kötja.

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

`motion.pptx` egy mozgás‑viselkedést három útvonalkommandóval tartalmaz. A következő fájlszerkesztési példák ezt a struktúrát használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonal‑objektum ugyanazt az útvonalat írja le. Az abszolút parancs (0.3, 0.1)-re ér véget; a relatív parancs (0.1, 0.1)-et ad a jelenlegi pozícióhoz, így (0.2, 0) lesz a végpont.

Mindkét útvonal ugyanazzal a kezdőpozícióval indul. Relatív vonal esetén adja hozzá az X és Y eltolást a jelenlegi pozícióhoz a végpont meghatározásához; abszolút vonal esetén a végpont közvetlenül olvasható. A jelző megváltoztatása a koordináták átalakítása nélkül más útvonalat eredményezne.

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

Az egyik útvonalat hozzárendelheti egy mozgás‑viselkedéshez a prezentációban való használathoz. Az utolsó logikai argumentum a relatív koordinátákat állítja be az adott parancshoz.

### **Vonal helyettesítése görbével**

Nyissa meg a `motion.pptx`‑t, és cserélje le a vonal‑parancsot egy köbös görbére. Először adja meg a két irányító pontot, majd a végpontot.

A kezdőpozíciót az előző parancs biztosítja. Az első két pont a görbét formálja, a harmadik a célpont; nem három egymást követő célpontokról van szó. A parancstípus, a pont‑szerkesztési típus és a ponttömb egyidejű frissítése biztosítja, hogy a szegmens új geometriája konzisztens legyen.

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

A `curve.pptx` útvonalában továbbra is három parancs van; középső parancs most egy görbét definiál.

## **Mentett útvonal megtekintése és szerkesztése**

Minden [MotionCmdPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncmdpath/) a [getPoints](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncmdpath/#getPoints), a [getCommandType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncmdpath/#getCommandType), a [getPointsType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncmdpath/#getPointsType) és az [isRelative](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motioncmdpath/#isRelative) metódusokat teszi elérhetővé. Az alábbi példák a `motion.pptx`‑ben ismert három‑parancsos útvonalat használják. Tetszőleges bemenet esetén előbb keresse meg a kívánt hatást, és ellenőrizze a parancstípusokat és a pontszámokat, mielőtt index szerint szerkesztené.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat anélkül, hogy módosítaná. A vég‑ és a close‑loop parancsoknak nincs szükségük pontokra, ezért engedje meg a null‑ponttömböt.

A kimenet minden numerikus parancstípust a relatív‑koordináta‑jelzővel együtt jelenít meg, mielőtt a pontokat felsorolná. Ez lehetővé teszi, hogy a módosítás előtti lépésben megkülönböztesse a végpontot az eltolástól. Egy görbe három pontot listáz, míg ebben a fájlban a egyenes vonal csak egy pontot tartalmaz.

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

A felsorolás egy kezdőpontot, egy abszolút vonalat (0.25, 0) végponttal, és egy befejező parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx`‑t, és cserélje le a vonal ponttömbjét, hogy elmozdítsa a végpontot.

A bemeneti fájlban az index 0 a kezdőparancs, az index 1 a vonal. A vonal egyetlen pontjának cseréje a célpontot módosítja anélkül, hogy a parancs típusát, időzítését vagy a gyűjteményben való pozícióját változtatná. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót ad meg, nem egy hozzáadott eltolást.

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

A `motion-endpoint.pptx`‑ben a vonal (0.4, 0.1)‑re végződik; az eredeti fájl változatlan maradt.

### **Szegmens helyettesítése**

Használja a [insert](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpath/#insert) és a [removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/motionpath/#removeAt) metódusokat a `motion.pptx`‑ben lévő vonal helyettesítéséhez. Beszúráskor a régi vonal a 2‑es indexre kerül.

Ez demonstrálja egy parancsobjektum helyettesítését a meglévő koordináták szerkesztése helyett. Beszúrás után a gyűjtemény ideiglenesen a kezdőparancsot, az új vonalat, a régi vonalat és a végparancsot tartalmazza. A 2‑es index eltávolítása eldobja a régi vonalat, és az új útvonal marad helyben.

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

A mentett útvonal továbbra is három parancsot tartalmaz, az új vonal (0.2, 0.1)‑re végződik, a befejező parancs pedig marad az utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típusa szerint. Ez a példa megnyitja a `rotation.pptx`‑t, megtalálja a [RotationEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotationeffect/)‑et, megváltoztatja a szöget, és a újranyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átlépje azokat a viselkedéseket, amelyek nem forgatások. A második betöltés a mentett fájlt egy külön prezentációobjektumba olvassa be, ezért az összehasonlítás a tartós adatot ellenőrzi, nem a memóriában még lévő értéket. Ez a példa továbbra is feltételezi, hogy a ismert hatás az első a fő sorozatban; típus alapján való kiválasztás nem helyezi el a megfelelő hatást egy tetszőleges prezentációban.

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

A kimenet `Rotation preserved: True`. Alkalmazza ugyanazt a típusellenőrzési mintát más viselkedésekre is. Teljes megőrzés ellenőrzéséhez hasonlítsa össze a célalakzatot, a hatást, a viselkedéstípusokat és sorrendet, az időzítést, valamint az útvonal‑parancsokat. Lebegőpontos értékek esetén használjon numerikus toleranciát. Ismeretlen animációs elrendezésű prezentáció esetén tekintse meg a [Read Shape Animations](/slides/hu/python-java/shape-animation/#read-shape-animations) szakaszt a fő és interaktív sorozatok bejárásához.

## **Viselkedés sorrend, előbeállítások és lejátszás**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behaviorcollection/) sorrendje egy hatás műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan vár az előzőre. Az időzítés és a befoglaló hatás határozza meg a ütemezést. A viselkedések átlapolhatnak, és ugyanazon tulajdonságra vonatkozó műveletek kölcsönhatásba léphetnek a [getAdditive](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behavior/#getAdditive) és a [getAccumulate](https://reference.aspose.com/slides/hu/python-java/aspose.slides/behavior/#getAccumulate) által. Ne használja a gyűjtemény újrarendezését önmagában a „mozgatás, majd forgatás” ütemezéséhez; használjon kifejezett időzítést vagy külön hatásokat, ahogy azt a [Shape Animation](/slides/hu/python-java/shape-animation/) leírja.

A hatás [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getType) és [getSubtype](https://reference.aspose.com/slides/hu/python-java/aspose.slides/effect/#getSubtype) leírja az előbeállítást, de nem ad teljes képet egy szerkesztett viselkedésfáról. Válassza ki az előbeállítást és alcsaládot, mielőtt testre szabná a viselkedéseket: az előbeállítás módosítása újraépítheti a gyűjteményt és elvetheti az egyéni műveleteket. Például egy testre szabott Spin hatás Fade‑re cserélése helyettesítheti a forgatási viselkedést set‑ és filter‑viselkedésekkel. Módosítás után ellenőrizze újra a gyűjteményt. Az előbeállítás viselkedéseinek törlése eltávolíthatja a láthatóságot vagy inicializálást biztosító műveleteket is, amelyeket a preset igényel. A példák szándékosan látható alakzatokat használnak, és a viselkedéseket felülírják; nem rekonstruálják minden preset teljes megvalósítását.

## **Formátum kompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden nézőben vagy export‑renderelőben. Ellenőrizze a mentett adatokat és a renderelt kimenetet külön‑külön.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Az ebben a példában elsődleges formátumként használatos. Nyissa újra a fájlt, hogy ellenőrizze a szerkeszthető viselkedésfát, majd ellenőrizze a lejátszást a célzott PowerPoint‑verzióban. |
| PPT | Az örökölt bináris ábrázolás eltérhet a PPTX‑től. Végezzen külön mentés‑újranyitás‑ciklust és lejátszási tesztet; ne vonjon le támogatási következtetéseket minden egyéni kombinációról a sikeres PPTX‑kimenet alapján. |
| PDF, PNG, JPEG és egyéb statikus dia‑képek | Statikus diaképet tartalmaznak, nem játszható viselkedés‑idővonalat vagy garantált véganimációs képkockát. |
| [HTML5](/slides/hu/python-java/export-to-html5/) | Támogatott animációkat tud lejátszani, ha az export‑opciókban engedélyezve van a shape animation. Tesztelje az egyéni kombinációkat böngészőben. |
| [Animated GIF](/slides/hu/python-java/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedést vagy kattintás‑indított interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/python-java/convert-powerpoint-to-video/) | Animációs képkockákat renderel és videóvá kódolja. A támogatás a renderelő [támogatott animációi és hatásai](/slides/hu/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) szerint korlátozott; a parancsok és interaktív események nem válnak szerkeszthető idővonalá. |

## **GYIK**

**Miért tartalmaz a hatásom viselkedéseket már a hozzáadás előtt?**

Egy előre definiált hatás létrehozhatja a mögöttes műveleteket. Ellenőrizze őket, mielőtt úgy dönt, hogy a presetet bővíti vagy a viselkedéseket felülírja.

**A viselkedés elejére helyezése garantálja, hogy először fusson?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és a műveletek közti kölcsönhatásokat ugyanazon tulajdonságon.

**Miért nem rendelkezik a befejező parancs pontokkal?**

Ez a parancs a path végét jelöli, és nem igényel koordinátákat. A fájlból beolvasott path ellenőrzésekor vizsgálja, hogy van‑e null‑ponttömb.

**Elég egy sikeres round‑trip a lejátszás megerősítéséhez?**

Nem. Az újranyitás csak a ellenőrzött tulajdonságok megmaradását igazolja. A diavetítő lejátszót vagy az animált exportot külön kell tesztelni a vizuális viselkedés megerősítéséhez.