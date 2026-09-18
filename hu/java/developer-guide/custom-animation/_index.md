---
title: "Egyedi animációs viselkedések létrehozása és módosítása Java-ban"
linktitle: "Egyedi animáció"
type: docs
weight: 151
url: /hu/java/custom-animation/
keywords:
- "egyedi animáció"
- "animációs viselkedés"
- "mozgásútvonal"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Egyedi animációs viselkedések és szerkeszthető mozgásútvonalak létrehozása, vizsgálata és módosítása PowerPoint prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik, hogy egy animációs hatáson belül egyedi műveleteket vezéreljünk, például szín módosítását, alakzat forgatását vagy szerkeszthető mozgásútvonal követését. Ez az útmutató bemutatja, hogyan hozhatunk létre és kombinálhatunk viselkedéseket, hogyan állíthatjuk be azok időzítését, hogyan vizsgálhatjuk és módosíthatjuk a meglévő animációkat, valamint hogyan ellenőrizhetjük, hogy a tulajdonságaik megmaradnak-e a prezentáció mentése és újranyitása után.

Az előre definiált hatások és kattintásindítók tekinthetők a [Shape Animation](/slides/hu/java/shape-animation/) oldalán.

## **Értsük meg az animációs modellt**

Az animáció a **Timeline → Sequence → Effect → Behaviors** struktúrában szerveződik:

- A [getTimeline](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getTimeline--) metódus visszaadja a dia idővonalát, amely tartalmazza a fő szekvenciát és az interaktív szekvenciákat.
- Az [ISequence](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/) hatásokat tartalmaz, amelyek különböző alakzatokra is irányulhatnak.
- Az [IEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/) meghatározza a célalakzatot, az előre beállított hatást, az al típust és az animáció időzítését.
- Az [IEffect.getBehaviors](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getBehaviors--) által visszaadott gyűjtemény tartalmazza az effektus megvalósításához szükséges műveleteket: színváltoztatás, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyedi viselkedések létrehozása**

Hívja a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust egy effektus létrehozásához, és érje el a [getBehaviors](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getBehaviors--) gyűjteményt. Egy előre beállított hatás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteket a preset kibővítésekor, vagy használja a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/#clear--) metódust, ha szándékosan helyettesíti őket.

[IBehaviorFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/) a lent illusztrált nyolc viselkedéstípust hozza létre. A mozgás a [Build a Motion Path](#build-a-motion-path) részben kerül tárgyalásra. Minden kódrészlet tartalmazza az importokat; helyezze a végrehajtható utasításokat egy metódusba. A későbbi szerkesztési példák megadják, melyik kimeneti fájlt használják.

### **Forgatás**

Használja a [createRotationEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) metódust forgatás létrehozásához. A [getBy](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irotationeffect/#getBy--) relatív szöget ad meg fokban; a [getFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irotationeffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irotationeffect/#getTo--) a végpontokat határozzák meg.

A példa egy Spin hatással indul, helyettesíti annak preset műveleteit egy forgatás viselkedéssel, és két másodperces időtartamot ad ennek. A 90 fokos relatív szög a kiindulási tájolásból egy negyedfordulatot jelent, ezért nem szükséges explicite kezdőszöget megadni.

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

`rotation.pptx` egy alakzatot és egy forgatás viselkedést tartalmaz. Az alábbi példák a gyűjteményt, az időzítést és a forgatás szerkesztését e fájlra építik.

### **Méretezés**

Használja a [createScaleEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) metódust X/Y százalékokkal: a [getFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iscaleeffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iscaleeffect/#getTo--) a kezdő- és végméretet írják le, míg a [getBy](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iscaleeffect/#getBy--) egy relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa a két dimenziót 100 %‑ról 125 %‑ra növeli két másodperc alatt. Az egyenlő vízszintes és függőleges százalékok megőrzik az alakzat arányait; eltérő százalékok az egyik dimenziót jobban nyújtják, mint a másikat.

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

### **Szín**

Használja a [createColorEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) metódust a kitöltés kékből narancssárgába történő változtatásához. A [getFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icoloreffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icoloreffect/#getTo--) színek; a [getBy](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icoloreffect/#getBy--) egy színeltolást jelent. Az [IBehavior.getProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehavior/#getProperties--) az animált attribútumot azonosítja.

Az alakzat szilárd kitöltése kék, ami megegyezik az animáció kezdőszínével. A kitöltés‑szín attribútum kiválasztása megmondja a viselkedésnek, mely részt kell változtatni; a színvégpontok önmagukban nem határozzák meg ezt az attribútumot. A mentett effektus egy kétszekundumos átmenetet írt le narancssárgára.

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

### **Szűrő**

Használja a [createFilterEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) metódust egy törlés (wipe) kiválasztásához. A [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifiltereffect/#getType--), a [getSubtype](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifiltereffect/#getSubtype--) és a [getReveal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifiltereffect/#getReveal--) a szűrőt, az irányt és azt határozza meg, hogy a shape megjelenjen‑e vagy elrejtő‑e.

Ez a példa egy két másodperces törlést konfigurál, amely a jobb‑oldali al típussal jeleníti meg az alakzatot. A szűrő beállításai a viselkedésen belül vannak, ezért a preset eredeti műveleteinek eltávolítása után állítjuk be őket.

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

### **Tulajdonság**

Használja a [createPropertyEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) metódust az átlátszóság animálásához. A [getFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipropertyeffect/#getFrom--), a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipropertyeffect/#getTo--) és a [getBy](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipropertyeffect/#getBy--) karakterláncok, amelyeket a [getValueType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipropertyeffect/#getValueType--) és a [getCalcMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) értelmez. Válasszon végpontokat vagy relatív eltolást, ne állítsa be mindet egyszerre.

Itt a kiválasztott attribútum az átlátszóság, a numerikus karakterláncok 25 %‑os átlátszóságról teljes átlátszóságra változtatnak. A lineáris interpoláció fokozatos változást jelent ezen értékek között. Ha más attribútumra alkalmazza a példát, válassza ki a megfelelő értéktípust és végpontértékeket.

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

### **Beállítás**

Használja a [createSetEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) metódust a láthatóság hozzárendeléséhez a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iseteffect/#getTo--) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumot választja, és a `visible` karakterláncot rendeli hozzá, amikor a viselkedés fut. A téglalap már látható ebben a minimális prezentációban, ezért a hozzárendelés önmagában nem feltétlenül eredményez nyilvánvaló vizuális változást. Ilyen művelet nagyobb hatás részeként hasznos, amely a shape elrejtését vagy megjelenítését is vezérli.

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

### **Parancs**

Használja a [createCommandEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) metódust, és konfigurálja a [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommandeffect/#getType--), a [getCommandString](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommandeffect/#getCommandString--) és a [getShapeTarget](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommandeffect/#getShapeTarget--) beállításokat. Helyezze a `sample.wav` nevű WAV felvételt a munkakönyvtárba. Ez a példa a [addAudioFrameEmbedded](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) segítségével beágyazza, és egy lejátszási parancsot csatol az audio kerethez.

Az audio keret egyszerre az effektus és a parancs célja. Ez összekapcsolja a lejátszási kérést a beágyazott felvétellel; egy parancs karakterlánc önmagában nem határozza meg, mely médiát kell vezérelni. Az effektus úgy van konfigurálva, hogy a diavetítés során kattintásra induljon.

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

A mentés a parancsot a `command.pptx` fájlba írja; a felvétel nem játszódik le. Lejátszáshoz olyan diavetítőre van szükség, amely támogatja a parancsot és annak médiacélját.

## **A viselkedésgyűjtemény kezelése**

[IBehaviorCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), és a [removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) metódusokat. Ez a példa megnyitja a `rotation.pptx` fájlt, hozzáad egy méretezést, a forgatás előtt helyezi el, majd eltávolítja a forgatást. Egy objektum eltávolítása és újbóli beszúrása a tárolt pozíciót módosítja másolat készítése nélkül.

A szerkesztések sorozata a gyűjteményt a forgatás–méretezés kombinációról méretezés–forgatásra, majd csak méretezésre változtatja. Az indexek az aktuális gyűjteményre vonatkoznak, ezért az eltávolítás a forgatás új indexét használja az átrendezés után. A végső felsorolás megmutatja, melyik viselkedés kerül mentésre.

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

A kimenet `ScaleEffect`: csak a méretezés marad meg. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor tisztítsa, ha az összes műveletet felül akarja írni.

## **A viselkedés időzítésének beállítása**

[IBehavior.getTiming](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehavior/#getTiming--) az [ITiming](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/) objektumot adja vissza, függetlenül az [IEffect.getTiming](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getTiming--)‑től. Az effektus időzítése az egész effektust ütemezi; a viselkedés időzítése egy benne lévő műveletet ír le.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx` fájlt, és állítsa be a [getDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getDuration--) által meghatározott időtartamot és a [getTriggerDelayTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getTriggerDelayTime--) által meghatározott késleltetést másodpercben, majd a [setRepeatCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatCount-float-) segítségével adja meg az ismétlésszámot. A [getAccelerate](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getAccelerate--) és a [getDecelerate](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getDecelerate--) a teljes időtartam töredékei; a kettő összegének legfeljebb 1‑nek kell lennie.

A bemeneti fájl a forgatás példában létrehozott, ahol az első viselkedés ismert forgatás. Ez a példa csak az adott viselkedés időzítését módosítja; a 90‑fokos szög változatlan marad. A szög és az időzítés külön kezelése egyszerűbbé teszi a tempó finomhangolását anélkül, hogy újraépítené az animációt.

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

A viselkedés két másodperces időtartamot, fél másodperces késleltetést és 3‑as ismétlésszámot használ. Az időtartam első és utolsó 20 %-a a gyorsulásra és lassulásra van fenntartva.

Más ismétlési szabályok a [getRepeatDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatDuration--), a [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) és a [getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) metódusok. Válasszon egy szabályt, ahelyett, hogy mindet egyszerre engedélyezné. A [getAutoReverse](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getAutoReverse--) az animációt visszafelé játssza le a előrehaladás után. A gyorsulás és lassulás folytonos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgásútvonal létrehozása**

Használja a [createMotionEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) metódust mozgás létrehozásához. A [getFrom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#getFrom--), a [getTo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#getTo--) és a [getBy](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#getBy--) százalékos koordinátákat vagy eltolásokat írnak le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/motionpath/) objektumot, és rendelje hozzá az [IMotionEffect.setPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) metódussal. Az [IMotionPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotionpath/) tárolja az útparancsokat.

[MotionCommandPathType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/motioncommandpathtype/) a műveletet választja ki:

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | Állítsa be a kiindulási pozíciót. |
| LineTo | Egy | Mozogjon egy egyenes szakaszon a végpontjáig. |
| CurveTo | Három | Kövesse a két vezérlőpontot és egy végpontot tartalmazó köbös ívet. |
| CloseLoop | Nincs | Térjen vissza a kiindulási pozícióba. |
| End | Nincs | Fejezze be az útvonalat. |

[MotionPathPointsType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/motionpathpointstype/) a pontok szerkesztési jellemzőit írja le, például sarkos vagy sima pontokat. Nem helyettesíti a parancstípust. A görbe példához használjon curve ponttípust, a egyenes szakaszokhoz corner ponttípust.

Az útvonal koordinátái a dia méreteihez vannak normalizálva: a 0,25‑os X‑eltolás a dia szélességének egy negyedét jelenti, nem 0,25 pontot. A pozitív Y lefelé mutat. Az abszolút parancsok a path koordinátrendszerben lévő pozíciókat adnak meg; a relatív parancsok a jelenlegi pozícióhoz képest adnak eltolást. Ez különbözik a [getOrigin](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#getOrigin--)‑tól, amely a path referenciakeretét választja, és a [getPathEditMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioneffect/#getPathEditMode--)‑tól, amely azt szabályozza, hogyan mozog a path, amikor az alakzatot mozgatják.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgás viselkedést kiinduló ponttal, egy egyenes szakaszzal és egy befejező parancssal. Az [IMotionPath.add](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) a parancstípust, a pontjait, a ponttípust és a relatív‑koordináta‑jelzőt veszi fel.

A kezdő parancs (0, 0)-t állít be, a vonal (0, 0)‑ból (0,25, 0)-ba végződik, ami a dia szélességének egy negyedét adja meg vízszintesen. A befejező parancsnak nincs koordinátapontja. Miután az útvonal hozzárendelésre került, a mozgás viselkedés hozzáadása az effektushoz összeköti ezt az útvonalat a téglalappal.

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

`motion.pptx` egy mozgás viselkedést tartalmaz három útparancsával. Az alábbi fájl‑szerkesztő példák ezt a felépítést használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonal ugyanazt az útvonalat írja le. Az abszolút parancs (0,3, 0,1)-re végződik; a relatív parancs (0,1, 0,1)-et ad hozzá a jelenlegi pozícióhoz, amely (0,2, 0)-t jelent.

Mindkét útvonal ugyanott indul. Relatív vonal esetén adja hozzá az X és Y eltolásokat a jelenlegi pozícióhoz a végpont meghatározásához; abszolút vonal esetén közvetlenül olvassa le a végpontot. A jelző átkapcsolása koordináta‑konverzió nélkül más útvonalat eredményezne.

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

Rendelje az egyik vagy a másik útvonalat egy mozgás viselkedéshez, hogy prezentációban használja. Az utolsó Boolean argumentum a relatív koordinátákat választja ki az adott parancshoz.

### **Vonal cseréje görbére**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal parancsot egy köbös görbére. Előbb adja meg a két vezérlőpontot, majd a végpontot.

A kezdő pozíciót az előző parancs adja. Az első két pont alakítja a görbét, a harmadik a célpont; nem három egymást követő célpontról van szó. A parancstípus, a pont‑szerkesztési típus és a ponttömb egyidejű frissítése biztosítja, hogy a szegmens összhangban maradjon az új geometriával.

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

A `curve.pptx` útvonala még mindig három parancsból áll; a középső parancs most már egy görbét definiál.

## **Mentett útvonal vizsgálata és szerkesztése**

Minden [IMotionCmdPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioncmdpath/) a [getPoints](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioncmdpath/#getPoints--), a [getCommandType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioncmdpath/#getCommandType--), a [getPointsType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioncmdpath/#getPointsType--) és az [isRelative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotioncmdpath/#isRelative--) metódusokat biztosítja. Az alábbi példák a `motion.pptx` három‑parancsos útvonalra épülnek. Tetszőleges bemenetre előbb határozza meg a kívánt effektust, és ellenőrizze a parancstípusokat és a pontszámokat index szerint történő szerkesztés előtt.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat módosítás nélkül. A befejező és a close‑loop parancsoknak nincs pontja, ezért egy null ponttömböt kell kezelni.

A kimenet minden numerikus parancstípust párosít a relatív‑koordináta‑jelzőjével, mielőtt felsoroznák a pontokat. Ez lehetővé teszi a végpont és az eltolás megkülönböztetését az útvonal módosítása előtt. Egy görbe három pontot, egy egyenes vonal csak egyet tartalmaz.

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

A felsorolás egy kiinduló pontot, egy abszolút vonalat (0,25, 0) végződéssel és egy befejező parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal ponttömbjét, hogy a végpontot elmozdítsa.

A bemeneti fájlban a 0‑s index a kiindulási parancs, az 1‑es index a vonal. A vonal egyetlen pontjának cseréje megváltoztatja a célpontot anélkül, hogy a parancstípust, az időzítést vagy a gyűjteményben elfoglalt helyet módosítaná. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót ad meg, nem egy hozzáadott eltolást.

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

A `motion-endpoint.pptx` fájlban a vonal (0,4, 0,1)-re végződik; az eredeti fájl változatlan marad.

### **Szegmens cseréje**

Használja az [insert](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) és a [removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imotionpath/#removeAt-int-) metódusokat a `motion.pptx` vonalának cseréjéhez. Az beszúrás eltolja a régi vonalat a 2‑es indexre.

Ez azt mutatja be, hogy egy parancsobjektumot cserélünk, ahelyett, hogy a meglévő koordinátákat szerkesztenénk. Beszúrás után a gyűjtemény ideiglenesen a kiindulási parancsot, az új vonalat, a régi vonalat és a befejező parancsot tartalmazza. A 2‑es index eltávolítása a régi vonalat eldobja, és a új útvonal marad.

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

A mentett útvonal továbbra is három parancsból áll, az új vonal (0,2, 0,1)-re végződik, a befejező parancs pedig utoljára áll.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típus szerint. Ez a példa megnyitja a `rotation.pptx` fájlt, megtalálja az [IRotationEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irotationeffect/)‑t, módosítja a szöget, majd a megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgató viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációobjektumba olvassa be, így az összehasonlítás a tartós adatokat ellenőrzi, nem a memóriában még lévő értéket. A példa továbbra is azt feltételezi, hogy a ismert effektus az első a fő szekvenciában; típus szerint történő kiválasztás nem feltétlenül találja meg a helyes effektust tetszőleges prezentációban.

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

A kimenet `Rotation preserved: true`. Alkalmazza ugyanazt a típus‑ellenőrzési mintát más viselkedésekre is. Teljes megőrzés ellenőrzéséhez hasonlítsa össze a célalakzatot, az effektust, a viselkedéstípusokat és azok sorrendjét, az időzítést, valamint az útparancsokat. Lebegőpontos értékekhez használjon numerikus toleranciát. Ismeretlen animációs elrendezésű prezentáció esetén tekintse meg a [Read Shape Animations](/slides/hu/java/shape-animation/#read-shape-animations) útmutatót a fő és interaktív szekvenciák bejárásához.

## **Viselkedés sorrend, előre beállítottak és lejátszás**

Az [IBehaviorCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehaviorcollection/) sorrendje az effektus műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan vár a megelőzőre. Az időzítés és a körülötte lévő effektus határozza meg az ütemezést. A viselkedések átfedhetnek, és ugyanazon tulajdonságra vonatkozó műveletek [getAdditive](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehavior/#getAdditive--) és [getAccumulate](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibehavior/#getAccumulate--) révén kölcsönhatásba léphetnek. Ne csak a gyűjtemény újrarendezésével ütemezze a „mozgatás, majd forgatás” szekvenciát; használjon explicit időzítést vagy külön effektusokat, ahogyan a [Shape Animation](/slides/hu/java/shape-animation/) leírásában szerepel.

Az effektus [getType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getType--) és [getSubtype](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getSubtype--) a presetet írja le. Ezek nem adnak teljes leírást a szerkesztett viselkedésfáról. Válassza ki a presetet és az al típust, mielőtt testreszabná a viselkedéseket: a preset megváltoztatása újraépítheti a gyűjteményt, és eldobhatja az egyedi műveleteket. Például egy testreszabott Spin effektus Fade‑re módosítása felcserélheti a forgatás viselkedést set és filter viselkedésekkel. Módosítás után ellenőrizze újra a gyűjteményt. A preset viselkedések törlése eltávolíthatja a preset által igényelt láthatósági vagy inicializációs műveleteket. A példák szándékosan látható alakzatokat használnak, és a viselkedéseket helyettesítik; nem építik újra minden preset teljes megvalósítását.

## **Formátumkompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden megjelenítőben vagy exportálási renderelőben. Ellenőrizze a mentett adatokat és a renderelt kimenetet külön-külön.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Elsődleges formátumként használja ezeket a példákat. Nyissa meg újra a szerkeszthető viselkedésfát ellenőrizni, majd ellenőrizze a lejátszást a kívánt PowerPoint verzióban. |
| PPT | Az örökölt bináris reprezentáció eltérhet a PPTX‑től. Teszteljen külön mentés‑újranyitás ciklust és lejátszást; ne vonjon le általános támogatást minden egyedi kombinációra a sikeres PPTX‑kimenet alapján. |
| PDF, PNG, JPEG és egyéb statikus dia‑képek | Statikus diaábrázolást tartalmaznak, nem tartalmaznak lejátszható viselkedésidővonalat vagy garantált végső animációs képkockát. |
| [HTML5](/slides/hu/java/export-to-html5/) | Lejátszhatja a támogatott animációkat, ha a shape animation engedélyezve van az export beállításaiban. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/java/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑indított interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/java/convert-powerpoint-to-video/) | Animációs képkockákat renderel és videóként kódolja. A támogatás a renderelő [supported animations and effects](/slides/hu/java/convert-powerpoint-to-video/#supported-animations-and-effects) listájára korlátozódik; a parancsok és interaktív események nem válnak szerkeszthető idővonalákká. |

## **GYIK**

**Miért tartalmaz az effektus viselkedéseket, mielőtt én bármelyiket hozzáadnám?**  
Egy előre definiált effektus létrehozása létrehozhatja a mögöttes műveleteket. Vizsgálja meg őket, mielőtt eldöntené, hogy a presetet kibővíti vagy a viselkedéseket lecseréli.

**A viselkedés elejére helyezése biztosan elsőként játssza le?**  
Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, az időtartamokat és a műveletek közötti kölcsönhatásokat ugyanazon tulajdonságon.

**Miért nincs pontja a befejező (end) parancsnak?**  
Ez jelzi az útvonal végét, és nem igényel koordinátákat. Útvonal olvasásakor ellenőrizze, hogy a ponttömb null‑e.

**Elég-e egy sikeres körkörös mentés‑újranyitás a lejátszás megerősítéséhez?**  
Nem. A újranyitás csak a ellenőrzött tulajdonságok megőrzését igazolja. A diavetítő vagy az animált export külön tesztelése szükséges a vizuális viselkedés megerősítéséhez.