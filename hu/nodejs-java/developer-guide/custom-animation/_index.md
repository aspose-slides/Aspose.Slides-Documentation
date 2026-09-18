---
title: Egyéni animációs viselkedések létrehozása és módosítása JavaScriptben
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/nodejs-java/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgási útvonal
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Egyéni animációs viselkedések és szerkeszthető mozgási útvonalak létrehozása, vizsgálata és módosítása PowerPoint prezentációkban az Aspose.Slides for Node.js Java segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik, hogy az animációs hatáselemek egyes műveleteit irányítsuk, például egy szín módosítását, egy alakzat forgatását vagy egy szerkeszthető mozgási útvonal követését. Ez az útmutató bemutatja, hogyan hozhatunk létre és kombinálhatunk viselkedéseket, hogyan konfigurálhatjuk azok időzítését, hogyan ellenőrizhetjük és módosíthatjuk a meglévő animációkat, valamint hogyan ellenőrizhetjük, hogy a tulajdonságaik megmaradnak‑e a prezentáció mentése és újra megnyitása után.

Az előre meghatározott hatások és kattintási aktiválók tekintetében lásd a [Alakzat animáció](/slides/hu/nodejs-java/shape-animation/) cikket.

## **A animációs modell megértése**

Az animáció a **Timeline → Sequence → Effect → Behaviors** szerkezetben van felépítve:

- A [getTimeline](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getTimeline) metódus visszaadja a dia idővonalát, amely tartalmazza a fő sorozatot és az interaktív sorozatokat.
- Egy [Sequence](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/) hatásokat tartalmaz, amelyek különböző alakzatokra irányulhatnak.
- Egy [Effect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/) azonosítja a célalakzatot, az alapbeállítást, az alosztályt és az effektus időzítését.
- Az [Effect.getBehaviors](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getBehaviors) által visszaadott gyűjtemény tartalmazza a hatást megvalósító műveleteket: színváltoztatás, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

A [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) meghívásával hozhatunk létre egy hatást, majd elérhetjük a [getBehaviors](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getBehaviors) gyűjteményt. Egy alapbeállítás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteket a preset kibővítésekor, vagy használja a [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/#clear) metódust, ha szándékosan helyettesíti őket.

A [BehaviorFactory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/) nyolc viselkedéstípust hoz létre az alább illusztráltak szerint. A mozgás a [Build a Motion Path](#build-a-motion-path) szekcióban kerül tárgyalásra. Minden kódrészlet tartalmazza a modulimportot, és Node.js‑ként futtatható a `aspose.slides.via.java` és `java` csomagok telepítése után. Futtassa a fájl‑létrehozó példákat a kimenetet olvasó példák előtt. A későbbi szerkesztési példák megadják, melyik kimeneti fájlt használják.

### **Forgatás**

Használja a [createRotationEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) metódust forgatás létrehozásához. A [getBy](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/rotationeffect/#getBy) relatív szöget fokban ad meg; a [getFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/rotationeffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/rotationeffect/#getTo) a végpontokat.

A példa egy Spin hatással indul, lecseréli annak előre beállított műveleteit egy forgatási viselkedésre, és két másodperces időtartamot ad ennek. A 90 fokos relatív szög egy negyedfordulatot jelent a alakzat kiinduló orientációjához képest, így nem szükséges külön kezdőszöget megadni.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény‑, időzítés‑ és forgatás‑szerkesztési példák ezt a fájlt használják.

### **Méretezés**

Használja a [createScaleEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) metódust X/Y százalékokkal: a [getFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/scaleeffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/scaleeffect/#getTo) a kiinduló és a végső méretet írja le, míg a [getBy](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/scaleeffect/#getBy) egy relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa a két dimenziót 100 %‑ról 125 %-ra növeli két másodperc alatt. A vízszintes és függőleges százalékok egyenlő megadása megőrzi az alakzat arányait; eltérő értékek esetén egyik dimenzió nyújtva lesz a másiknál.

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

### **Szín**

Használja a [createColorEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) metódust a kitöltés kékből narancssárgára változtatásához. A [getFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/coloreffect/#getFrom) és a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/coloreffect/#getTo) színek; a [getBy](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/coloreffect/#getBy) színeltolás. A [Behavior.getProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behavior/#getProperties) határozza meg, mely attribútumot animálja.

Az alakzat szilárd kitöltése kék színűre van inicializálva, ami megegyezik az animáció kezdőszínével. A kitöltő‑szín attribútum kiválasztása meghatározza, melyik részt kell módosítani; a színegyenletek önmagukban nem azonosítják azt az attribútumot. A mentett hatás két másodperces átmenetet ír le a narancssárgára.

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

### **Szűrő**

Használja a [createFilterEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) metódust egy tisztításhoz. A [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filtereffect/#getType), a [getSubtype](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filtereffect/#getSubtype) és a [getReveal](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filtereffect/#getReveal) határozzák meg a szűrőt, az irányt és azt, hogy a alakzatot felfedje vagy elrejtse.

Ez a példa egy két másodperces tisztítást konfigurál, amely a jobb irányú alosztály segítségével fedi fel az alakzatot. A szűrőbeállítások a viselkedésen belül vannak, így a preset eredeti műveleteinek eltávolítása után kerülnek konfigurálásra.

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

### **Tulajdonság**

Használja a [createPropertyEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) metódust az átlátszóság animálásához. A [getFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/propertyeffect/#getFrom), a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/propertyeffect/#getTo) és a [getBy](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/propertyeffect/#getBy) karakterláncok, amelyeket a [getValueType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/propertyeffect/#getValueType) és a [getCalcMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) értelmez. Válasszon végpontokat vagy relatív eltolást, ne állítsa be mindhárom értéket egyszerre.

Itt a kiválasztott attribútum az átlátszóság, és a numerikus karakterláncok a 25 %‑os átlátszóságtól a teljes átlátszóságig terjedő változást jelentik. A lineáris interpoláció fokozatos változást ír le ezek között az értékek között. Ha ezt a példát más attribútumra alkalmazza, válasszon a tulajdonságnak megfelelő értéktípust és végértékeket.

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

### **Beállítás**

Használja a [createSetEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) metódust a láthatóság hozzárendeléséhez a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/seteffect/#getTo) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumot választja, és a viselkedés futásakor a `visible` karakterláncot rendeli hozzá. A téglalap már látható ebben a minimális prezentációban, ezért a hozzárendelés önmagában nem biztos, hogy nyilvánvaló vizuális változást eredményez. Ilyen művelet hasznos nagyobb hatás részeként, amely szabályozza, mikor válik az alakzat rejtett vagy látható állapotba.

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

### **Parancs**

Használja a [createCommandEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) metódust, és konfigurálja a [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commandeffect/#getType), a [getCommandString](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commandeffect/#getCommandString) és a [getShapeTarget](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commandeffect/#getShapeTarget) értékeket. Helyezze a `sample.wav` nevű WAV‑felvételt a munkakönyvtárba. Ez a példa a [addAudioFrameEmbedded](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) segítségével beágyazza, és lejátszási parancsot csatol a hang kerethez.

A hangkeret egyszerre a hatás és a parancs célja. Ez összekapcsolja a lejátszási kérést a beágyazott felvétellel; egy parancs karakterlánc önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. A hatás úgy van konfigurálva, hogy a diavetítés közben kattintásra induljon.

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

A mentés a `command.pptx` fájlba helyezi a parancsot; a felvételt nem játssza le. Lejátszáshoz olyan diavetítőre van szükség, amely támogatja a parancsot és annak média‑célját.

## **A viselkedésgyűjtemény kezelése**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/#remove) és a [removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/#removeAt) műveleteket. Ez a példa megnyitja a `rotation.pptx`‑t, hozzáad egy méretezést, a forgatás elé helyezi, majd eltávolítja a forgatást. Egy objektum eltávolítása és újra beszúrása módosítja a tárolt pozíciót anélkül, hogy másolatot készítene.

A szerkesztések sorozata a gyűjteményt a forgatás–méretezés sorrendról méretezés–forgatásra, majd csak méretezésre változtatja. Az indexek az aktuális gyűjteményre vonatkoznak, ezért az eltávolítás a forgatás új indexét használja az átrendezés után. A végső felsorolás megerősíti, melyik viselkedés lesz mentve.

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

A kimenet `ScaleEffect`: csak a méretezés marad meg. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor tisztítsa, ha az összes műveletet helyettesíti.

## **Viselkedés időzítésének konfigurálása**

A [Behavior.getTiming](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behavior/#getTiming) visszaadja a [Timing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/) objektumot, függetlenül az [Effect.getTiming](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getTiming)‑tól. Az effektus időzítése az egész hatást ütemezi; a viselkedés időzítése egy műveletet ír le benne.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx`‑t, és állítsa be a másodpercben megadott időtartamot ([getDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getDuration)) és a trigger késleltetést ([getTriggerDelayTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)). Ezután konfigurálja az ismétlésszámot a [setRepeatCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatCount) segítségével. A [getAccelerate](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getAccelerate) és a [getDecelerate](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getDecelerate) a teljes időtartam tört részét jelentik; a két érték összege legfeljebb 1 legyen.

A bemeneti fájl a forgatás példában létrehozott fájl, ahol az első viselkedés egy forgatás. Ez a példa csak ennek a viselkedésnek az időzítését módosítja; a 90‑fokos szög változatlan marad. A szög és az időzítés szétválasztása megkönnyíti a sebesség beállítását anélkül, hogy újraépítené az animációt.

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

A viselkedés két másodperces időtartamot, félmásodperces késleltetést és 3‑as ismétlésszámot használ. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra van fenntartva.

Az egyéb ismétlési politikák közé tartozik a [getRepeatDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatDuration), a [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) és a [getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); válasszon egy politikát ahelyett, hogy egyszerre mindet engedélyezné. A [getAutoReverse](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getAutoReverse) a folyamatot visszafelé játssza le a előrehaladás után. A gyorsulás és lassulás folytonos változásokra, nem pedig diszkrét hozzárendelésekre vagy parancsokra vonatkozik.

## **Mozgásútvonal felépítése**

Használja a [createMotionEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) metódust mozgás létrehozásához. A [getFrom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#getFrom), a [getTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#getTo) és a [getBy](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#getBy) százalékos koordinátákat vagy eltolásokat ír le. Szerkeszthető útvonalhoz hozzon létre egy [MotionPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpath/) objektumot, és rendelje hozzá a [MotionEffect.setPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#setPath)‑el. A [MotionPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpath/) tárolja az útvonalparancsokat.

A [MotionCommandPathType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncommandpathtype/) választja ki a műveletet:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | One | Beállítja a kiindulási pozíciót. |
| LineTo | One | Egy egyenes szakaszon mozog a végpontjáig. |
| CurveTo | Three | Követ egy köbikus ívet, amelyet két irányító pont és egy végpont definiál. |
| CloseLoop | None | Visszatér a kiindulási pozícióba. |
| End | None | Befejezi az útvonalat. |

A [MotionPathPointsType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpathpointstype/) leírja a pontszerkesztési jellemzőket, például sarok‑ vagy sima pontokat. Nem helyettesíti a parancstípust. A görbe példa alatti görbeponttípust, a egyenes szakaszokhoz pedig sarokponttípust használja.

Az útvonal koordinátái a dia méreteihez vannak normalizálva: egy 0,25‑ös X‑elmozdulás a dia szélességének egynegyedét jelenti, nem 0,25 pontot. A pozitív Y lefelé mutat. Az abszolút parancsok a koordináta‑rendszerben adnak meg pozíciókat; a relatív parancsok az aktuális pozícióhoz képest adnak eltolást. Ez különbözik a [getOrigin](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#getOrigin)‑tól, amely az útvonal referenciakeretét választja, és a [getPathEditMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioneffect/#getPathEditMode)‑tól, amely azt szabályozza, hogyan mozog az útvonal, ha az alakzatot mozgatják.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgási viselkedést egy kiinduló ponttal, egy egyenes szegmenssel és egy befejező paranccsal. A [MotionPath.add](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpath/#add) a parancs típusát, a pontjait, a ponttípust és a relatív‑koordináta‑jelzőt veszi fel.

A kiinduló parancs (0, 0)-t állít be, a vonal pedig (0.25, 0)-ra végződik, így a útvonal a dia szélességének egynegyedét teszi ki vízszintesen. A befejező parancsnak nincs koordinátapontja. Miután az útvonal hozzá van rendelve, a mozgási viselkedés hozzáadása az effektushoz összekapcsolja ezt az útvonalat a téglalappal.

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

`motion.pptx` egy mozgási viselkedést három útvonalkommandóval tartalmaz. Az alábbi fájlszerkesztési példák ezt a struktúrát használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonal‑objektum ugyanazt a szakaszt írja le. Az abszolút parancs (0.3, 0.1)-nél ér véget; a relatív parancs (0.1, 0.1)-et ad hozzá a jelenlegi pozícióhoz, amely (0.2, 0).

Mindkét útvonal ugyanott kezdődik. A relatív vonal esetén az X és Y eltolást hozzá kell adni a jelenlegi pozícióhoz, hogy megkapjuk a végpontot; az abszolút vonalnál a végpont közvetlenül olvasható. A jelző megcserélése anélkül, hogy a koordinátákat átalakítanánk, egy eltérő útvonalat eredményezne.

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

Rendeljen az egyik útvonalat egy mozgási viselkedéshez, hogy prezentációban használja. A végső logikai argumentum a relatív koordinátákat választja ki ehhez a parancshoz.

### **Vonal cseréje görbére**

Nyissa meg a `motion.pptx`‑t, és cserélje le a vonalparancsát egy köbös görbére. Előbb adja meg a két irányító pontot, majd a végpontot.

A kiinduló pozíciót az előző parancs biztosítja. Az első két pont alakítja a görbét, míg a harmadik a célpont; nem három egymást követő célpontról van szó. A parancstípus, a pontszerkesztési típus és a ponttömb egyidejű módosítása biztosítja a szegmens konzisztenciáját az új geometriai alakzattal.

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

A `curve.pptx` útvonal továbbra is három parancsot tartalmaz; a középső parancs most már egy görbét definiál.

## **Mentett útvonal ellenőrzése és szerkesztése**

Minden [MotionCmdPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncmdpath/) kiadja a [getPoints](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncmdpath/#getPoints), a [getCommandType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), a [getPointsType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) és az [isRelative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motioncmdpath/#isRelative) információkat. Az alábbi példák a `motion.pptx`‑ben ismert háromparancsos útvonalat használják. Általános bemenet esetén keresse meg a célhatást, és szerkesztés előtt ellenőrizze a parancstípusokat és pontszámokat index szerint.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat módosítás nélkül. A befejező és a záró‑ciklus parancsoknak nincs pontjuk, ezért engedje meg a null ponttömböt.

A kimenet minden numerikus parancstípust a relatív‑koordináta‑jelzővel párosít, mielőtt felsoroznák a pontokat. Ez lehetővé teszi, hogy a pontok módosítása előtt megkülönböztesse a végpontot az eltolástól. A görbe három pontot sorol fel, míg ebben a fájlban az egyenes csak egyet.

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

A lista egy kiindulási pontot, egy abszolút vonalat (0.25, 0) és egy befejező parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx`‑t, és cserélje le a vonal ponttömbjét a végpont eltolására.

A bemeneti fájlban a 0‑s index a kiindulási parancs, az 1‑es index a vonal. A vonal egyetlen pontjának cseréje megváltoztatja a célpontot anélkül, hogy módosítaná a parancstípust, az időzítést vagy a gyűjteményben elfoglalt helyet. Mivel a parancs abszolút koordinátákat használ, az új páros egy pozíciót ad meg, nem egy hozzáadott eltolást.

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

A `motion-endpoint.pptx`‑ben a vonal (0.4, 0.1)‑nél végződik; az eredeti fájl változatlan marad.

### **Szegmens cseréje**

Használja a [insert](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpath/#insert) és a [removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/motionpath/#removeAt) metódusokat a `motion.pptx` vonalának cseréjéhez. Beszúráskor a régi vonal a 2‑es indexre kerül.

Ez a módszer egy parancsobjektus helyettesítését mutatja, nem a meglévő koordináták szerkesztését. Beszúrás után a gyűjtemény ideiglenesen a kiindulási parancsot, az új vonalat, a régi vonalat és a befejező parancsot tartalmazza. A 2‑es index eltávolítása eldobja a régi vonalat, a új útvonal pedig a helyén marad.

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

A mentett útvonal továbbra is három parancsot tartalmaz; az új vonal (0.2, 0.1)‑nél végződik, a befejező parancs marad utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típusa alapján. Ez a példa megnyitja a `rotation.pptx`‑t, megtalálja a [RotationEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/rotationeffect/)‑et, módosítja a szöget, majd a újbóli megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgatási viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációs objektumba olvassa be, így az összehasonlítás a megőrzött adatokat ellenőrzi, nem a memóriában lévő aktuális értéket. Ez a példa továbbra is feltételezi, hogy a ismert hatás az első a fő sorozatban; típus szerinti választás nem találja meg a helyes hatást egy tetszőleges prezentációban.

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

A kimenet: `Rotation preserved: true`. Alkalmazza ugyanazt a típusellenőrző mintát más viselkedésekre is. Teljes megőrzés ellenőrzéséhez hasonlítsa össze a célalakzatot, az effektust, a viselkedéstípusokat és azok sorrendjét, az időzítést és az útvonalparancsokat. Lebegőpontos értékekhez használjon numerikus toleranciát. Ismeretlen animációs elrendezésű prezentáció esetén lásd a [Olvasd el az alakzat animációkat](/slides/hu/nodejs-java/shape-animation/#read-shape-animations) útmutatót a fő és interaktív sorozatok bejárásához.

## **Viselkedés sorrend, presetek és lejátszás**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behaviorcollection/) sorrendje az effektus műveleteinek tárolt sorrendje. Nem egy lejátszási lista, amelyben minden viselkedés automatikusan megvárja az előzőt. Az időzítés és a körülötte lévő effektus határozza meg a ütemezést. A viselkedések átfedhetnek, és az ugyanazon tulajdonságon végzett műveletek kölcsönhatásba léphetnek a [getAdditive](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behavior/#getAdditive) és a [getAccumulate](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/behavior/#getAccumulate) segítségével. Ne csak a gyűjtemény átrendezésével ütemezze a „mozgatás, majd forgatás” sorrendet; használjon explicit időzítést vagy külön hatásokat, ahogy a [Alakzat animáció](/slides/hu/nodejs-java/shape-animation/) leírja.

Az effektus [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getType) és [getSubtype](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getSubtype) a presetet írja le. Ezek nem adnak teljes leírást egy szerkesztett viselkedésfáról. Válassza ki a presetet és az alosztályt, mielőtt testre szabná a viselkedéseket: a preset megváltoztatása újraépítheti a gyűjteményt, és eldobhatja az egyedi műveleteket. Például egy testreszabott Spin hatás Fade‑re változtatása lecserélheti a forgatási viselkedést set‑ és filter‑viselkedésekre. A preset vagy alosztály módosítása után ellenőrizze újra a gyűjteményt. A preset viselkedéseinek törlése is eltávolíthatja a láthatóságot vagy az inicializációs műveleteket, amelyekre a presetnek szüksége van. A példák szándékosan látható alakzatokat használnak, és a viselkedéseket helyettesítik; nem rekonstruálják minden preset teljes implementációját.

## **Formátum kompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden megjelenítőben vagy export‑renderelőben. Vizsgálja meg a mentett adatokat és a renderelt kimenetet külön-külön.

| Formátum vagy kimenet | Ellenőrzendő |
| --- | --- |
| PPTX | Használja elsődleges formátumként a példákhoz. Nyissa meg újból a szerkeszthető viselkedésfa ellenőrzéséhez, majd ellenőrizze a lejátszást a célzott PowerPoint‑verzióban. |
| PPT | A régi bináris reprezentáció eltérhet a PPTX‑től. Végezzen külön mentés‑újra‑megnyitás ciklust és lejátszási tesztet; ne vonjon le következtetést a PPTX‑sikeres kimenetből minden egyedi kombináció támogatásáról. |
| PDF, PNG, JPEG és egyéb statikus diaképek | Statikus diaképet tartalmaznak, nem lejátszható viselkedésidővonalat vagy garantált véganimációs képkockát. |
| [HTML5](/slides/hu/nodejs-java/export-to-html5/) | Lejátszhatja a támogatott animációkat, ha az exportopciókban engedélyezve van az alakzat‑animáció. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑vezérelt interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/nodejs-java/convert-powerpoint-to-video/) | Rendereli az animációs képkockákat és videóként kódolja őket. A támogatás korlátozott a renderelő [támogatott animációi és effektusai](/slides/hu/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) szerint; a parancsok és interaktív események nem válnak szerkeszthető idővonalra. |

## **GYIK**

**Miért tartalmaz egy hatás viselkedéseket, még mielőtt hozzáadnék bármit?**

Egy előre meghatározott hatás létrehozhatja az alapvető műveleteket. Vizsgálja meg őket, mielőtt eldönti, hogy a presetet kibővíti vagy a viselkedéseket helyettesíti.

**A viselkedés elejére helyezése garantálja, hogy először játssza le?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és az ugyanazon tulajdonságon végzett műveletek kölcsönhatását.

**Miért nincs pontja a befejező parancsnak?**

Ez a parancs az útvonal végét jelöli, és nem igényel koordinátákat. Útvonal olvasásakor ellenőrizze, hogy a ponttömb null‑e.

**Elég egy sikeres körút a lejátszás megerősítésére?**

Nem. Az újbóli megnyitás csak a vizsgált tulajdonságok megőrzését igazolja. A diavetítő vagy az animált export külön tesztelése szükséges a vizuális viselkedés megerősítéséhez.