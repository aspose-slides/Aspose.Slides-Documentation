---
title: Vytvoření a úprava vlastních animačních chování v JavaScriptu
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/nodejs-java/custom-animation/
keywords:
- vlastní animace
- animační chování
- dráha pohybu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte, prohlédněte a upravte vlastní animační chování a editovatelné dráhy pohybu v prezentacích PowerPoint s Aspose.Slides pro Node.js pomocí Java."
---
## **Přehled**

Vlastní animační chování vám umožňuje ovládat jednotlivé operace v rámci animačního efektu, jako je změna barvy, otáčení tvaru nebo sledování editovatelné dráhy pohybu. Tento průvodce ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich časování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přežijí uložení a znovuotevření prezentace.

Pro předdefinované efekty a spouštěče kliknutím viz [Animace tvaru](/slides/cs/nodejs-java/shape-animation/).

## **Pochopte model animace**

- Metoda [getTimeline](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getTimeline) vrací časovou osu snímku, která obsahuje jeho hlavní sekvenci a interaktivní sekvence.
- [Sequence](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [Effect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/) určuje cílový tvar, předvolbu, podtyp a časování efektu.
- Kolekce vrácená metodou [Effect.getBehaviors](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getBehaviors) obsahuje operace, které efekt realizují: změna barvy, posun, otočení, nastavení vlastnosti a další.

## **Vytvořte jednotlivé chování**

Zavolejte [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect) pro vytvoření efektu a přístup ke kolekci [getBehaviors](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getBehaviors). Předvolba může tuto kolekci naplnit automaticky. Zachovejte její operace při rozšiřování předvolby nebo použijte [clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/#clear), když je úmyslně nahrazujete.

[BehaviorFactory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v sekci [Build a Motion Path](#build-a-motion-path). Každý úryvek zahrnuje importy modulů a lze jej spustit jako Node.js skript s nainstalovanými balíčky `aspose.slides.via.java` a `java`. Spusťte příklady vytvářející soubory před příklady, které čtou jejich výstup. Příklady úprav později uvádějí, který výstupní soubor používají.

### **Rotace**

Použijte [createRotationEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) pro vytvoření otáčení. [getBy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/rotationeffect/#getBy) určuje relativní úhel ve stupních; [getFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/rotationeffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/rotationeffect/#getTo) specifikují koncové body.

Příklad začíná efektem Spin, nahradí jeho předdefinované operace jedním chováním otáčení a nastaví pro tuto operaci dvousekundovou dobu trvání. Relativní úhel 90 stupňů představuje čtvrt otáčky od výchozí orientace tvaru, takže není potřeba explicitně zadávat výchozí úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno chování otáčení. Kolekce, časování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [createScaleEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) s procenty X/Y: [getFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/scaleeffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/scaleeffect/#getTo) popisují počáteční a koncovou velikost, zatímco [getBy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/scaleeffect/#getBy) popisuje relativní změnu. Zde 100 znamená původní velikost.

Příklad zvětší oba rozměry ze 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachová proporce tvaru; různé procenta by roztáhla jeden rozměr více než druhý.

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

### **Barva**

Použijte [createColorEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) pro změnu výplně z modré na oranžovou. [getFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/coloreffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/coloreffect/#getTo) jsou barvy; [getBy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/coloreffect/#getBy) je posun barvy. [Behavior.getProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behavior/#getProperties) určuje, jaký atribut se animuje.

Plná výplň tvaru je inicializována na modrou, což odpovídá výchozí barvě animace. Výběr atributu výplně říká chování, kterou část tvaru má měnit; samotné koncové barvy neurčují tento atribut. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [createFilterEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) pro výběr výmazu. [getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filtereffect/#getSubtype) a [getReveal](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filtereffect/#getReveal) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundový výmaz, který odhalí tvar pomocí podtypu se směrem doprava. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována po odstranění původních operací předvolby.

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

### **Vlastnost**

Použijte [createPropertyEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) pro animaci neprůhlednosti. [getFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/propertyeffect/#getTo) a [getBy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/propertyeffect/#getBy) jsou řetězce interpretované pomocí [getValueType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/propertyeffect/#getValueType) a [getCalcMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Zvolte koncové body nebo relativní posun místo nastavení všech tří hodnot najednou.

Zde je vybraný atribut neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje postupnou změnu mezi těmito hodnotami. Při úpravě příkladu pro jiný atribut zvolte typ hodnoty a koncové hodnoty odpovídající tomuto atributu.

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

### **Nastavení**

Použijte [createSetEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) pro přiřazení viditelnosti pomocí [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/seteffect/#getTo). Chování nastavení neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samo o sobě vytvořit zřejmou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

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

### **Příkaz**

Použijte [createCommandEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) a nakonfigurujte [getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commandeffect/#getCommandString) a [getShapeTarget](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Umístěte WAV nahrávku pojmenovanou `sample.wav` do pracovního adresáře. Tento příklad ji vkládá pomocí [addAudioFrameEmbedded](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) a připojuje příkaz přehrát k audio rámečku.

Audio rámeček je jak cílem efektu, tak cílem příkazu. To spojuje požadavek na přehrání s vloženou nahrávkou; samotný řetězec příkazu neurčuje, který mediální objekt má ovládat. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení uloží příkaz do `command.pptx`; nahrávka se nepřehraje. Přehrávání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[BehaviorCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/#remove) a [removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odebere otáčení. Odstranění a opětovné vložení stejného objektu mění jeho uloženou pozici, aniž by vytvořilo kopii.

Sekvence úprav změní kolekci z otáčení–měřítko na měřítko–otáčení a nakonec jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstranění používá nový index otáčení po přeuspořádání. Konečný výčet potvrzuje, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstává jen měřítko. Pořadí v kolekci samo o sobě neschraňuje chování jedno po druhém. Vyprázdněte kolekci jen při nahrazování všech jejích operací.

## **Konfigurace časování chování**

[Behavior.getTiming](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behavior/#getTiming) zpřístupňuje [Timing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/), nezávisle na [Effect.getTiming](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getTiming). Časování efektu plánuje uzavřený efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení doby trvání, zpoždění, opakování a akcelerace**

Otevřete `rotation.pptx` a nastavte dobu trvání ([getDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getDuration)) a zpoždění spouštěče ([getTriggerDelayTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) v sekundách, pak nakonfigurujte počet opakování pomocí [setRepeatCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getAccelerate) a [getDecelerate](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getDecelerate) jsou zlomky doby trvání; jejich součet udržujte maximálně na 1.

Vstupní soubor je ten vytvořený v příkladu otáčení, kde je první chování známé jako otáčení. Tento příklad mění jen časování toho chování; úhel 90 ° zůstává nezměněn. Oddělení úhlu a časování usnadňuje úpravu tempa bez přestavby animace.

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

Chování používá dvousekundovou dobu trvání, půlsekundové zpoždění a počet opakování 3. Prvních a posledních 20 % doby trvání jsou použity pro akceleraci a deakceleraci.

Další politiky opakování zahrnují [getRepeatDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) a [getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); vyberte jednu politiku místo povolení všech najednou. [getAutoReverse](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getAutoReverse) přehraje animaci zpětně po dopředném průchodu. Akcelerace a deakcelerace se vztahují na plynulé změny, ne na diskrétní přiřazení nebo příkazy.

## **Vytvoření dráhy pohybu**

Použijte [createMotionEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) pro vytvoření pohybu. Jeho [getFrom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#getTo) a [getBy](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#getBy) popisují souřadnice nebo posuny založené na procentech. Pro editovatelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpath/) a přiřaďte ji pomocí [MotionEffect.setPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpath/) ukládá příkazy dráhy.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncommandpathtype/) vybírá operaci:

| Příkaz | Body | Význam |
| --- | --- | --- |
| MoveTo | One | Nastaví počáteční pozici. |
| LineTo | One | Pohne se po přímém úseku k jeho koncovému bodu. |
| CurveTo | Three | Následuje kubickou křivku definovanou dvěma řídícími body a koncovým bodem. |
| CloseLoop | None | Vrátí se na počáteční pozici. |
| End | None | Ukončí dráhu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpathpointstype/) popisuje charakteristiky úpravy bodů, jako jsou rohové nebo hladké body. Nenahrazuje typ příkazu. Použijte typ křivky pro příklad níže a rohový typ pro přímé úseky.

Souřadnice dráhy jsou normalizovány k rozměrům snímku: posun X o 0,25 představuje čtvrtinu šířky snímku, ne 0,25 bodu. Kladný Y běží dolů. Absolutní příkazy specifikují pozice v souřadnicovém systému dráhy; relativní příkazy specifikují posuny od aktuální pozice. To je odděleno od [getOrigin](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#getOrigin), který vybírá referenční rámec dráhy, a od [getPathEditMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), který řídí, jak se dráha pohybuje při přesunu tvaru.

### **Vytvoření přímé dráhy**

Vytvořte chování pohybu s počátečním bodem, jedním přímým úsekem a příkazem konce. [MotionPath.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpath/#add) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz ustanoví (0, 0) a úsek končí v (0,25, 0), což dává trase horizontální posun o čtvrt šířky snímku. Koncový příkaz nemá žádné souřadnicové body. Po přiřazení dráhy se přidání chování pohybu k efektu spojí s obdélníkem.

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

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy dráhy. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty dráhy popisují stejnou trasu. Absolutní příkaz končí v (0,3, 0,1); relativní příkaz přidá (0,1, 0,1) k aktuální pozici, (0,2, 0).

Obě dráhy startují ze stejné pozice. Pro relativní úsek přičtěte jeho X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní úsek přečtěte koncový bod přímo. Přepnutí příznaku bez převodu souřadnic by popisovalo jinou trasu.

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

Přiřaďte libovolnou dráhu k chování pohybu, aby byla použita v prezentaci. Poslední boolean argument vybírá relativní souřadnice pro tento příkaz.

### **Nahrazení úseku křivkou**

Otevřete `motion.pptx` a nahraďte jeho příkaz úseku kubickou křivkou. Nejprve uveďte dva řídící body, následovaný koncovým bodem.

Počáteční pozice je určena předchozím příkazem. První dva body tvarují křivku, třetí je její cíl; nejsou to tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodu a pole bodů současně udrží úsek v souladu s novou geometrií.

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

Dráha v `curve.pptx` stále má tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené dráhy**

Každý [MotionCmdPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncmdpath/) zpřístupňuje [getPoints](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) a [isRelative](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Následující příklady používají známou třípříkazovou dráhu v `motion.pptx`. Pro libovolný vstup nejprve najděte zamýšlený efekt a před úpravou ověřte typy příkazů a počet bodů podle indexu.

### **Čtení příkazů a souřadnic**

Přečtěte dráhu bez změny. Příkazy konce a uzavření smyčky nepotřebují body, takže počítejte s možným nulovým polem bodů.

Výstup spáruje každým číselným typem příkazu jeho příznak relativních souřadnic před výpisem bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou dráhy. Křivka by vypsala tři body, zatímco přímý úsek v tomto souboru vypíše pouze jeden.

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

Výpis obsahuje počáteční bod, absolutní úsek končící v (0,25, 0) a příkaz konce.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů úseku, aby se posunul jeho koncový bod.

Ve vstupním souboru je index 0 počáteční příkaz a index 1 úsek. Nahrazení jediného bodu úseku změní jeho cíl, aniž by se změnil typ příkazu, časování nebo pozice v kolekci. Protože příkaz používá absolutní souřadnice, nový pár určuje pozici místo přidaného offsetu.

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

Úsek v `motion-endpoint.pptx` končí v (0,4, 0,1); původní soubor zůstává nezměněn.

### **Nahrazení segmentu**

Použijte [insert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpath/#insert) a [removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/motionpath/#removeAt) pro nahrazení úseku v `motion.pptx`. Vložení posune starý úsek na index 2.

Tento příklad ukazuje nahrazení objektu příkazu místo úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, nový úsek, starý úsek a příkaz konce. Odstranění indexu 2 vyřadí starý úsek a ponechá novou trasu.

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

Uložená dráha stále má tři příkazy, nový úsek končí v (0,2, 0,1) a příkaz konce je poslední.

## **Úprava a ověření existujícího chování**

Když není znám index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [RotationEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/rotationeffect/), změní úhel a po znovuotevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčení. Druhé načtení přečte uložený soubor do samostatného objektu prezentace, takže srovnání ověřuje trvalá data, nikoli hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: true`. Použijte stejný vzor kontroly typu i pro ostatní chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy dráhy. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým rozvržením animací viz [Read Shape Animations](/slides/cs/nodejs-java/shape-animation/#read-shape-animations) pro procházení hlavních a interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [BehaviorCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Časování a uzavřený efekt určují plánování. Chování se mohou překrývat a operace na stejném atributu mohou interagovat přes [getAdditive](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behavior/#getAdditive) a [getAccumulate](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/behavior/#getAccumulate). Nepoužívejte jen přeuspořádání kolekce pro naplánování „přesun, pak otáčení“; použijte explicitní časování nebo oddělené efekty, jak je popsáno v [Animace tvaru](/slides/cs/nodejs-java/shape-animation/).

[Effect.getType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getType) a [Effect.getSubtype](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getSubtype) popisují jeho předvolbu. Nejsou kompletním popisem upraveného stromu chování. Zvolte předvolbu a podtyp před vlastním přizpůsobením chování: změna předvolby může přestavět kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného Spin efektu na Fade může nahradit otáčecí chování chováními nastavení a filtru. Po změně předvolby nebo podtypu znovu prozkoumejte kolekci. Vyprázdnění předdefinovaných chování může také odstranit viditelnost nebo inicializační operace, které předvolba potřebuje. Příklady úmyslně používají viditelné tvary a nahrazují chování; neprobíhá kompletní rekonstrukce implementace každé předvolby.

## **Kompatibilita formátů**

Uchování stromu chování nezaručuje identické přehrávání v každém prohlížeči nebo exportním rendereru. Zkontrolujte uložená data a vykreslený výstup odděleně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Použijte jako primární formát pro tyto příklady. Znovuotevřete jej pro ověření editovatelného stromu chování, poté zkontrolujte přehrávání v požadované verzi PowerPointu. |
| PPT | Starší binární reprezentace se může lišit od PPTX. Otestujte samostatný cyklus uložení‑znovuotevření a přehrávání; nevyvozujte podporu každé vlastní kombinace jen z úspěšného PPTX výstupu. |
| PDF, PNG, JPEG a další statické obrázky snímků | Obsahují statickou reprezentaci snímku, ne přehratelný časový řetězec chování ani garantovaný konečný animační snímek. |
| [HTML5](/slides/cs/nodejs-java/export-to-html5/) | Může přehrávat podporované animace, když je v možnostech exportu zapnuta animace tvaru. Testujte vlastní kombinace v prohlížeči. |
| [Animovaný GIF](/slides/cs/nodejs-java/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani klikací interakce. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) | Vykresluje animační snímky a kóduje je jako video. Podpora je omezena na [podporované animace a efekty](/slides/cs/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) rendereru; příkazy a interaktivní události se nepřevádějí na editovatelný časový řetězec. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování, i když jsem žádné nepřidal?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte si je před rozhodnutím, zda předvolbu rozšířit nebo její chování nahradit.

**Zda přesunutí chování na začátek způsobí, že se přehraje první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, doby trvání a interakce mezi operacemi na stejném atributu.

**Proč má příkaz konce žádné body?**

Značí konec dráhy a nevyžaduje souřadnice. Při prohlížení dráhy ze souboru kontrolujte nulové pole bodů.

**Je úspěšná zpětná cesta dostatečná pro potvrzení přehrávání?**

Ne. Znovuotevření potvrzuje zachování kontrolovaných vlastností. Otestujte přehrávač prezentací nebo animovaný export samostatně, abyste potvrdili jeho vizuální chování.