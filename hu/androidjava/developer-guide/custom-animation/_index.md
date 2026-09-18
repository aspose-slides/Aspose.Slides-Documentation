---
title: Egyedi animációs viselkedések létrehozása és módosítása Androidon
linktitle: Egyedi animáció
type: docs
weight: 151
url: /hu/androidjava/custom-animation/
keywords:
- egyedi animáció
- animációs viselkedés
- mozgási útvonal
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Egyedi animációs viselkedések és szerkeszthető mozgási útvonalak létrehozása, ellenőrzése és módosítása PowerPoint prezentációkban az Aspose.Slides for Android for Java segítségével."
---
## **Áttekintés**

Az egyedi animációs viselkedések lehetővé teszik egy animációs hatás egyedi műveleteinek vezérlését, például egy szín megváltoztatását, egy alakzat forgatását vagy egy szerkeszthető mozgási útvonal követését. Ez az útmutató bemutatja, hogyan hozhatók létre és kombinálhatók a viselkedések, hogyan állítható be az időzítésük, hogyan ellenőrizhetők és módosíthatók a meglévő animációk, valamint hogyan ellenőrizhető, hogy a tulajdonságaik megmaradnak a prezentáció mentése és újranyitása után.

Az előre definiált hatások és kattintásindítók tekinthetők a [Shape Animation](/slides/hu/androidjava/shape-animation/) cikkben.

## **Ismerje meg az animációs modellt**

Egy animáció a **Timeline → Sequence → Effect → Behaviors** módon van szervezve:

- A [getTimeline](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) metódus visszaadja a dia idővonalát, amely tartalmazza a fő szekvenciát és az interaktív szekvenciákat.
- Az [ISequence](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/) hatásokat tartalmaz, amelyek esetleg különböző alakzatokra irányulnak.
- Az [IEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/) meghatározza a célalakzatot, előbeállítást, altípust és a hatás időzítését.
- Az [IEffect.getBehaviors](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getBehaviors--) által visszaadott gyűjtemény tartalmazza a hatást megvalósító műveleteket: színváltoztatás, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

Hívja a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust egy hatás létrehozásához, és érje el a [getBehaviors](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getBehaviors--) gyűjteményt. Egy előbeállítás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg a műveleteit, ha a presetet kibővíti, vagy használja a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) metódust, ha szándékosan helyettesíti őket.

[IBehaviorFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/) nyolc viselkedéstípust hoz létre az alább illusztráltak szerint. A mozgás részletezve van a [Build a Motion Path](#build-a-motion-path) szakaszban. Minden kódrészlet tartalmazza az importokat; helyezze a végrehajtható utasításokat egy metódusba. A későbbi szerkesztési példák megadják, melyik kimeneti fájlt használják. Androidon cserélje le a mintafájlok neveit teljes útvonalakra egy alkalmazás számára elérhető könyvtárban, például az alkalmazás fájlok könyvtárában.

### **Forgatás**

Használja a [createRotationEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) metódust forgatás létrehozásához. A [getBy](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irotationeffect/#getBy--) fokban megadott relatív szöget jelöl; a [getFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irotationeffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irotationeffect/#getTo--) a végpontokat határozza meg.

A példa egy Spin hatással indul, lecseréli a preset műveleteit egy forgatási viselkedésre, és a műveletnek két másodperces időtartamot ad meg. A 90 fokos relatív szög egy negyed fordulatot jelent a forma kiinduló tájolásából, így külön induló szög nem szükséges.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi példák a gyűjteményt, az időzítést és a forgatás szerkesztését használják ezzel a fájlval.

### **Méretezés**

Használja a [createScaleEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) metódust X/Y százalékokkal: a [getFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iscaleeffect/#getTo--) a kezdeti és a végső méretet írja le, míg a [getBy](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iscaleeffect/#getBy--) egy relatív változást ad meg. Itt a 100 az eredeti méretet jelenti.

A példa mindkét dimenziót 100 %-ról 125 %-ra növeli két másodperc alatt. Az egyenlő vízszintes és függőleges százalékok megőrzik az alakzat arányait; eltérő százalékok egy dimenziót jobban nyújtanak, mint a másikat.

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

### **Szín**

Használja a [createColorEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) metódust a kitöltés kékből narancssárgára változtatásához. A [getFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icoloreffect/#getFrom--) és a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icoloreffect/#getTo--) színek; a [getBy](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icoloreffect/#getBy--) színeltolás. Az [IBehavior.getProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehavior/#getProperties--) az animált tulajdonságot azonosítja.

Az alakzat szilárd kitöltése kék, ami egyezik az animáció kezdőszínével. A kitöltés-szín attribútum kiválasztása megmondja a viselkedésnek, hogy az alakzat mely részét kell változtatni; a színvégpontok egyedül nem határozzák meg ezt az attribútumot. A mentett hatás egy kétszsekundumos átmenetet ír le a narancssárga felé.

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

### **Szűrő**

Használja a [createFilterEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) metódust a wipe kiválasztásához. A [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifiltereffect/#getType--) , a [getSubtype](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--) és a [getReveal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) a szűrőt, az irányt és azt határozza meg, hogy a forma megjelenik-e vagy elrejtődik.

Ez a példa egy kétmásodperces wipe-et konfigurál, amely a jobb irányú altípussal jeleníti meg a formát. A szűrő beállításai a viselkedéshez tartoznak a hatáson belül, ezért a preset eredeti műveletei eltávolítása után kerülnek beállításra.

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

Használja a [createPropertyEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) metódust az átlátszóság animálásához. A [getFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--) , a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipropertyeffect/#getTo--) és a [getBy](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) karakterláncok, amelyeket a [getValueType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) és a [getCalcMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) értelmez. Válasszon végpontokat vagy relatív eltolást a három érték egyidejű beállítása helyett.

Itt a kiválasztott attribútum az átlátszóság, és a numerikus karakterláncok 25 %-os átlátszóságból a teljes átlátszóságra változást jelentenek. A lineáris interpoláció fokozatos változást ír le ezen értékek között. Ha más attribútumra adaptálja a példát, válasszon megfelelő értéktípust és végpont értékeket.

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

Használja a [createSetEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) metódust a láthatóság hozzárendeléséhez a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iseteffect/#getTo--) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatósági attribútumot választja, és a viselkedés futásakor a `visible` karakterláncot rendeli hozzá. A téglalap már látható ebben a minimális prezentációban, így a hozzárendelés önmagában nem feltétlenül eredményez nyilvánvaló vizuális változást. Az ilyen művelet hasznos egy nagyobb hatás részeként, amely szabályozza, mikor válik a forma rejtetté vagy láthatóvá.

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

Használja a [createCommandEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) metódust, és konfigurálja a [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommandeffect/#getType--), a [getCommandString](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommandeffect/#getCommandString--) és a [getShapeTarget](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) beállításait. Helyezzen egy `sample.wav` nevű WAV felvételt a munkakönyvtárba. Ez a példa a [addAudioFrameEmbedded](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) segítségével beágyazza, és egy lejátszási parancsot csatol az audio kerethez.

Az audio keret egyszerre a hatás és a parancs célja. Ez a lejátszási kérést az beágyazott felvételhez kapcsolja; egy parancs karakterlánc önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. A hatást úgy állítják be, hogy a diavetítés során egy kattintásra induljon.

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

A mentés a `command.pptx` fájlba tárolja a parancsot; a felvételt nem játssza le. A lejátszáshoz olyan diavetítőre van szükség, amely támogatja a parancsot és a média célját.

## **A viselkedésgyűjtemény kezelése**

[IBehaviorCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), és a [removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) metódusokat. Ez a példa megnyitja a `rotation.pptx`‑t, hozzáad egy skálázást, a forgatás előtt helyezi el, majd eltávolítja a forgatást. Azonos objektum eltávolítása és újbóli beszúrása megváltoztatja a tárolt pozíciót anélkül, hogy másolatot készítene.

A szerkesztések sorozata a gyűjmtényt a forgatás‑skálázás sorrendjéről skálázás‑forgatásra, majd csak skálázásra változtatja. Az indexek a jelenlegi gyűjteményre vonatkoznak, ezért a törlés a forgatás új indexét használja az átrendezés után. A végső felsorolás megmutatja, melyik viselkedés kerül mentésre.

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

A kimenet `ScaleEffect`: csak a skálázás marad meg. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor ürítse, ha az összes műveletet cseréli le.

## **A viselkedés időzítésének beállítása**

[IBehavior.getTiming](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehavior/#getTiming--) az [ITiming](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/) objektumot adja vissza, függetlenül az [IEffect.getTiming](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getTiming--)‑tól. A hatás időzítése ütemezi a környező hatást; a viselkedés időzítése egy műveletet ír le benne.

### **Állítsa be a hosszt, késleltetést, ismétlést és gyorsulást**

Nyissa meg a `rotation.pptx`‑t, és állítsa be a hosszt ([getDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getDuration--)), valamint a trigger késleltetési időt ([getTriggerDelayTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) másodpercben, majd a ismétlésszámot a [setRepeatCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) metódussal. A [getAccelerate](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getAccelerate--) és a [getDecelerate](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getDecelerate--) a teljes időtartam hányadosát adják meg; összegük legfeljebb 1 legyen.

A bemeneti fájl a forgatás példában létrehozott fájl, ahol az első viselkedés ismert, hogy forgatás. Ez a példa csak ennek a viselkedésnek az időzítését változtatja; a 90 fokos szög változatlan marad. A szög és az időzítés elkülönítése könnyebbé teszi a tempó módosítását anélkül, hogy újjáépítené az animációt.

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

A viselkedés két másodperces időtartamot, fél másodperces késleltetést és 3‑as ismétlésszámot használ. Időtartamának első és utolsó 20 %-a gyorsulásra és lassulásra szolgál.

Egyéb ismétlési szabályok: [getRepeatDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), és [getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); válasszon egy szabályt, ahelyett, hogy mindet egyszerre engedélyezné. A [getAutoReverse](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getAutoReverse--) a forwards áthaladás után visszafelé játssza le az animációt. A gyorsulás és lassulás folyamatos változásokra vonatkozik, nem pedig diszkrét hozzárendelésekre vagy parancsokra.

## **Mozgási útvonal létrehozása**

Használja a [createMotionEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) metódust mozgás létrehozásához. A [getFrom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#getFrom--), a [getTo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#getTo--), és a [getBy](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#getBy--) százalékos koordinátákat vagy eltolásokat ír le. Egy szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/motionpath/) objektumot, és rendelje hozzá az [IMotionEffect.setPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) metódussal. A [IMotionPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotionpath/) tárolja az útvonalkommandókat.

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | Állítsa be a kezdőpozíciót. |
| LineTo | Egy | Mozgassa egy egyenes szegmenst a végpontjáig. |
| CurveTo | Három | Kövesse a két vezérlőponttal és egy végponttal definiált köbös görbét. |
| CloseLoop | Nincs | Visszatér a kezdőpozícióba. |
| End | Nincs | Befejezi az útvonalat. |

A [MotionPathPointsType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/motionpathpointstype/) a pontok szerkesztési jellemzőit írja le, például sarok vagy sima pontok. Nem helyettesíti a parancstípust. Görbépont típust használjon a lentebb látható görbe példához, és sarokpont típust az egyenes szegmensekhez.

Az útvonal koordinátái a dia dimenzióihoz vannak normalizálva: egy 0.25‑es X eltolás a dia szélességének egynegyedét jelenti, nem 0.25 pontot. A pozitív Y lefelé mutat. Az abszolút parancsok a koordinátrendszerben határozzák meg a pozíciókat; a relatív parancsok a jelenlegi pozícióhoz képest eltolásokat adnak meg. Ez különbözik a [getOrigin](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#getOrigin--)‑tól, amely az útvonal referenciakeretét választja, illetve a [getPathEditMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--)‑tól, amely azt irányítja, hogyan mozog az útvonal a forma mozgatásakor.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgási viselkedést kiindulási ponttal, egy egyenes szegmenssel és egy befejező paranccsal. Az [IMotionPath.add](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) a parancs típusát, pontjait, ponttípusát és egy relatív‑koordináta jelzőt várja.

A kezdőparancs (0, 0)-t állít be, a vonal (0.25, 0)-ra végződik, így a útvonal a dia szélességének egynegyedével vízszintesen eltolódik. A befejező parancsnak nincs koordinátapontja. Az útvonal hozzárendelése után a mozgási viselkedés hozzáadása a hatáshoz összeköti a útvonalat a téglalappal.

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

`motion.pptx` egy mozgási viselkedést tartalmaz három útvonalkommandóval. Az alábbi fájlszerkesztő példák ezt a struktúrát használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonal-objektum ugyanazt az útvonalat írja le. Az abszolút parancs (0.3, 0.1)-nél ér véget; a relatív parancs (0.1, 0.1)-et ad hozzá a jelenlegi pozícióhoz, így (0.2, 0)-t eredményez.

Mindkét útvonal ugyanazon a pozíción indul. A relatív vonal esetén a X és Y eltolásokat a jelenlegi pozícióhoz adva kapjuk a végpontot; az abszolút vonal esetén a végpont közvetlenül leolvasható. A jelző megváltoztatása konverzió nélkül másik útvonalat eredményezne.

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

Rendelje hozzá valamelyik útvonalat egy mozgási viselkedéshez, hogy a prezentációban használja. Az utolsó logikai argumentum a relatív koordinátákat választja ki az adott parancshoz.

### **Vonal cseréje görbére**

Nyissa meg a `motion.pptx`‑t és cserélje le a vonalparancsot egy köbös görbére. Először adja meg a két vezérlőpontot, majd a végpontot.

A kiindulási pozíciót az előző parancs biztosítja. Az első két pont alakítja a görbét, a harmadik pedig a célpont; nem három egymást követő célpontokról van szó. A parancstípus, a pontszerkesztő típus és a ponttömb egyidejű frissítése biztosítja, hogy a szegmens összhangban legyen az új geometriával.

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

A `curve.pptx`‑ben lévő útvonal továbbra is három parancsot tartalmaz; középső parancsa most egy görbét definiál.

## **Mentett útvonal ellenőrzése és szerkesztése**

Az [IMotionCmdPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioncmdpath/) a [getPoints](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), a [getCommandType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), a [getPointsType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), és az [isRelative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) információkat nyújtja. Az alábbi példák a `motion.pptx`‑ben ismert háromparancsos útvonalat használják. Tetszőleges bemenetre először keresse meg a kívánt hatást, és a szerkesztés előtt ellenőrizze a parancstípusokat és a pontszámot index szerint.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat módosítás nélkül. Az end és close‑loop parancsok nem igényelnek pontokat, ezért engedélyezzen null ponttömböt.

A kimenet minden numerikus parancstípust párosít a relatív‑koordináta jelzővel, mielőtt felsorolja a pontokat. Ez segít megkülönböztetni a végpontot az eltolástól a módosítás előtt. Egy görbe három pontot sorol fel, míg ebben a fájlban az egyenes vonal csak egyet tartalmaz.

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

A listában egy kiindulási pont, egy abszolút vonal (0.25, 0) végponttal, és egy end parancs szerepel.

### **Végpont módosítása**

Nyissa meg a `motion.pptx`‑t és cserélje le a vonal ponttömbjét, hogy megváltoztassa a végpontot.

A bemeneti fájlban a 0‑s index a kezdőparancs, az 1‑s index a vonal. A vonal egyetlen pontjának cseréje a célpontot módosítja anélkül, hogy a parancstípust, az időzítést vagy a gyűjteményben elfoglalt helyét változtatná. Mivel a parancs abszolút koordinátákat használ, az új pár egy pozíciót ad meg, nem egy eltolást.

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

A `motion-endpoint.pptx`‑ben a vonal (0.4, 0.1)‑nél ér véget; az eredeti fájl változatlan marad.

### **Szegmens cseréje**

Használja a [insert](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) és a [removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) metódusokat a `motion.pptx` vonalának cseréjéhez. A beszúrás eltolja a régi vonalat a 2‑es indexre.

Ez bemutatja egy parancsobjektum cseréjét a meglévő koordináták szerkesztése helyett. Beszúrás után a gyűjtemény ideiglenesen a kezdőparancsot, az új vonalat, a régi vonalat és az end parancsot tartalmazza. A 2‑es index eltávolítása eldobja a régi vonalat, és a új útvonal marad helyben.

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

A mentett útvonal továbbra is három parancsot tartalmaz, az új vonal (0.2, 0.1)‑nél végződik, az end parancs az utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Amikor a viselkedés indexe ismeretlen, válassza ki típus alapján. Ez a példa megnyitja a `rotation.pptx`‑t, megtalálja az [IRotationEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irotationeffect/)‑et, megváltoztatja a szöget, és újra megnyitás után ellenőrzi a mentett értéket.

A típusellenőrzés lehetővé teszi, hogy a ciklus átugorja a nem forgatásos viselkedéseket. A második betöltés egy külön prezentációs objektumba olvassa be a mentett fájlt, így a összehasonlítás a megmaradt adatot ellenőrzi, nem a memóriában lévő értéket. Ez a példa továbbra is feltételezi, hogy a ismert hatás az első a fő szekvenciában; típus szerinti kiválasztás nem biztos, hogy egy tetszőleges prezentációban a helyes hatást találja meg.

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

A kimenet: `Rotation preserved: true`. Alkalmazza ugyanezt a típusellenőrzési mintát más viselkedésekre is. Teljes megőrzési ellenőrzéshez hasonlítsa össze a célalakzatot, a hatást, a viselkedéstípusokat és sorrendet, az időzítést, valamint az útvonalparancsokat. Lebegőpontos értékekhez használjon numerikus toleranciát. Ismeretlen animációs elrendezésű prezentációkhoz lásd a [Read Shape Animations](/slides/hu/androidjava/shape-animation/#read-shape-animations) oldalt a fő és interaktív szekvenciák bejárásához.

## **Viselkedés sorrend, előbeállítások és lejátszás**

Az [IBehaviorCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehaviorcollection/) sorrendje egy hatás műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan megvárja az előzőt. Az időzítés és a körülölelő hatás határozza meg az ütemezést. A viselkedések átfedhetnek, és ugyanazon tulajdonság műveletei kölcsönhatásba léphetnek a [getAdditive](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehavior/#getAdditive--) és a [getAccumulate](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) segítségével. Ne csak a gyűjtemény átrendezésével ütemezze a „mozgatás, majd forgatás” folyamatot; használjon explicit időzítést vagy külön hatásokat, ahogy a [Shape Animation](/slides/hu/androidjava/shape-animation/) leírja.

A hatás [getType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getType--) és [getSubtype](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getSubtype--) a presetet írja le. Nem egy komplett leírása a szerkesztett viselkedési fának. Válassza ki a presetet és az altípust a viselkedések testreszabása előtt: a preset módosítása újraépítheti a gyűjteményt és eldobhatja az egyedi műveleteket. Például egy testreszabott Spin hatás Fade‑re váltása felcserélheti a forgatási viselkedést set és filter viselkedésekkel. Ellenőrizze újra a gyűjteményt a preset vagy altípus módosítása után. A preset viselkedések törlése eltávolíthatja a láthatóságot vagy inicializálási műveleteket, amelyekre a presetnek szüksége van. A példák látható alakzatokat használnak, és a viselkedéseket lecserélik; nem építik újra minden preset implementációját.

## **Formátum kompatibilitás**

Egy megőrzött viselkedésfa nem garantálja az azonos lejátszást minden nézőben vagy exportálási renderelőben. Ellenőrizze külön a mentett adatokat és a megjelenített kimenetet.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Elsődleges formátumként használja ezeket a példákat. Nyissa meg újra a szerkeszthető viselkedésfát, majd ellenőrizze a lejátszást a cél PowerPoint verzióban. |
| PPT | A régi bináris ábrázolás eltérhet a PPTX‑től. Tesztelje a külön mentés‑újranyitás ciklust és a lejátszást; ne vonjon le támogatást minden egyéni kombinációra a sikeres PPTX kimenet alapján. |
| PDF, PNG, JPEG és egyéb statikus diaképek | Statikus diaképet tartalmaznak, nem lejátszható viselkedési idővonalat vagy garantált végső animációs képkockát. |
| [HTML5](/slides/hu/androidjava/export-to-html5/) | Képes lejátszani a támogatott animációkat, ha a shape animation be van kapcsolva az export beállításokban. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑indukált interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/androidjava/convert-powerpoint-to-video/) | Rendereli az animációs képkockákat és videóként kódolja. A támogatás korlátozott a renderelő [supported animations and effects](/slides/hu/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) szerint; a parancsok és interaktív események nem válnak szerkeszthető idővonalra. |

## **GYIK**

**Miért tartalmaz a hatásom viselkedéseket, mielőtt bármilyen hozzáadnám?**

Az előre definiált hatás létrehozása előállíthatja az alatta lévő műveleteket. Ellenőrizze ezeket, mielőtt eldöntené, hogy a presetet kiterjeszti vagy helyettesíti a viselkedéseket.

**Az, hogy egy viselkedést az elejére helyezek, elsőként lejátszódik?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és a ugyanazon tulajdonság műveletei közti kölcsönhatásokat.

**Miért nem tartalmaz pontokat egy end parancs?**

Az end parancs az útvonal végét jelöli, és koordinátákat nem igényel. A fájlból beolvasott útvonal ellenőrzésekor keresgéljen null ponttömböt.

**Elégséges-e egy sikeres körút a lejátszás megerősítéséhez?**

Nem. Az újranyitás csak a vizsgált tulajdonságok megőrzését erősíti meg. A diavetítő vagy az animált export külön tesztelése szükséges a vizuális viselkedés megerősítéséhez.