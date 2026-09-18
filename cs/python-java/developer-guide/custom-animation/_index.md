---
title: Vytvoření a úprava vlastních animačních chování v Pythonu přes Java
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/python-java/custom-animation/
keywords:
- vlastní animace
- animační chování
- pohybová dráha
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte, prohlédněte a upravte vlastní animační chování a editovatelné pohybové dráhy v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Vlastní animační chování vám umožňují řídit jednotlivé operace v rámci animačního efektu, jako je změna barvy, otáčení tvaru nebo sledování upravitelných pohybových drah. Tento návod ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich načasování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přetrvávají po uložení a opětovném otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutí viz [Shape Animation](/slides/cs/python-java/shape-animation/).

## **Pochopení modelu animace**

Animace je uspořádána jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getTimeline) vrací časovou osu snímku, která obsahuje hlavní sekvenci a interaktivní sekvence.
- [Sequence](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [Effect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/) identifikuje cílový tvar, předvolbu, podtyp a časování efektu.
- Kolekce vrácená metodou [Effect.getBehaviors](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getBehaviors) obsahuje operace, které implementují efekt: změna barvy, přesun, otáčení, nastavení vlastnosti atd.

## **Vytvoření jednotlivých chování**

Zavolejte [Sequence.addEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sequence/#addEffect) pro vytvoření efektu a přístup ke kolekci [getBehaviors](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getBehaviors). Předvolba může tuto kolekci naplnit automaticky. Ponechte její operace při rozšiřování předvolby, nebo použijte [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/#clear) při úmyslné náhradě.

[BehaviorFactory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v [Build a Motion Path](#build-a-motion-path). Každý úryvek zahrnuje své importy a v případě potřeby spouští JVM. Java objekty bodů a pole jsou vytvářeny přes JPype tam, kde API vyžaduje. Příklady pozdější úpravy uvádějí, který výstupní soubor používají.

### **Otáčení**

Použijte [createRotationEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createRotationEffect) pro vytvoření otáčení. [getBy](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotationeffect/#getBy) určuje relativní úhel ve stupních; [getFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotationeffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotationeffect/#getTo) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho operace předvolby jedním otáčovacím chováním a nastaví tomuto chování dvousekundovou dobu trvání. Relativní úhel 90 stupňů představuje čtvrt otáčky od výchozí orientace tvaru, takže není potřeba explicitní výchozí úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno otáčovací chování. Kolekce, časování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [createScaleEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createScaleEffect) s procenty X/Y: [getFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/scaleeffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/scaleeffect/#getTo) popisují výchozí a koncovou velikost, zatímco [getBy](https://reference.aspose.com/slides/cs/python-java/aspose.slides/scaleeffect/#getBy) popisuje relativní změnu. Zde 100 % znamená původní velikost.

Příklad zvětšuje oba rozměry z 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachovává proporce tvaru; rozdílná procenta by rozměr natáhla více v jedné ose.

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

### **Barva**

Použijte [createColorEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createColorEffect) pro změnu výplně z modré na oranžovou. [getFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/coloreffect/#getFrom) a [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/coloreffect/#getTo) jsou barvy; [getBy](https://reference.aspose.com/slides/cs/python-java/aspose.slides/coloreffect/#getBy) je posun barvy. [Behavior.getProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behavior/#getProperties) určuje atribut, který se animuje.

Výplň tvaru je inicializována na modrou, což odpovídá výchozí barvě animace. Výběrem atributu výplně barvy říkáte chování, kterou část tvaru má měnit; samotné koncové barvy atribut neurčují. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [createFilterEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createFilterEffect) pro výběr setření. [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filtereffect/#getSubtype) a [getReveal](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filtereffect/#getReveal) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové setření, které odhalí tvar pomocí podtypu pravý směr. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována po odstranění původních operací předvolby.

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

### **Vlastnost**

Použijte [createPropertyEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) pro animaci neprůhlednosti. [getFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/propertyeffect/#getTo) a [getBy](https://reference.aspose.com/slides/cs/python-java/aspose.slides/propertyeffect/#getBy) jsou řetězce interpretované pomocí [getValueType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/propertyeffect/#getValueType) a [getCalcMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/propertyeffect/#getCalcMode). Zvolte koncové body nebo relativní posun místo nastavení všech tří najednou.

Zde je vybraná vlastnost neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje plynulou změnu mezi těmito hodnotami. Při adaptaci příkladu na jinou vlastnost zvolte typ hodnoty a koncové hodnoty odpovídající této vlastnosti.

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

### **Nastavení**

Použijte [createSetEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createSetEffect) pro přiřazení viditelnosti pomocí [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/seteffect/#getTo). Chování nastavení neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při běhu chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samo o sobě způsobit zřetelnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje či zobrazí.

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

### **Příkaz**

Použijte [createCommandEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createCommandEffect) a nakonfigurujte [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commandeffect/#getCommandString) a [getShapeTarget](https://reference.aspose.com/slides/cs/python-java/aspose.slides/commandeffect/#getShapeTarget). V pracovní složce umístěte zvukový záznam WAV pojmenovaný `sample.wav`. Tento příklad jej vloží pomocí [addAudioFrameEmbedded](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) a připojí příkaz přehrát k audio rámci.

Audio rám je zároveň cílem efektu i cílem příkazu. Tím se spojí požadavek na přehrání s vloženým záznamem; samotný řetězec příkazu neurčuje, který mediální objekt má ovládat. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení ukládá příkaz do `command.pptx`; záznam se nepřehraje. Přehrávání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[BehaviorCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/#remove) a [removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/#removeAt). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odstraní otáčení. Odstranění a opětovné vložení stejného objektu mění jeho uloženou pozici, aniž by vznikla kopie.

Pořadí úprav mění kolekci z otáčení‑měřítka na měřítko‑otáčení a nakonec jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstranění používá nový index otáčení po přeuspořádání. Konečné výčty potvrzují, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstává jen měřítko. Pořadí v kolekci samo o sobě neplánuje chování za sebou. Vyprázdněte kolekci pouze při nahrazení všech jejích operací.

## **Konfigurace načasování chování**

[Behavior.getTiming](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behavior/#getTiming) odhaluje [Timing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/), nezávisle na [Effect.getTiming](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getTiming). Časování efektu plánuje zahrnující efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení trvání, prodlevy, opakování a akcelerace**

Otevřete `rotation.pptx` a nastavte trvání ([getDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getDuration)) a zpoždění spouštění ([getTriggerDelayTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getTriggerDelayTime)) v sekundách, pak konfigurujte počet opakování pomocí [setRepeatCount](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getAccelerate) a [getDecelerate](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getDecelerate) jsou zlomky trvání; jejich součet udržujte nejvýše na 1.

Vstupní soubor je ten vytvořený v příkladu otáčení, kde je první chování známo jako otáčení. Tento příklad mění pouze časování toho chování; úhel 90 stupňů zůstává nedotčen. Oddělený úhel a časování usnadňuje úpravu tempa bez nutnosti přestavovat animaci.

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

Chování používá dvousekundové trvání, půlsekundovou prodlevu a počet opakování 3. Prvních a posledních 20 % trvání jsou vyhrazeny pro akceleraci a deakceleraci.

Další politiky opakování zahrnují [getRepeatDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) a [getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getRepeatUntilNextClick); vyberte jednu politiku místo jejich současného zapnutí. [getAutoReverse](https://reference.aspose.com/slides/cs/python-java/aspose.slides/timing/#getAutoReverse) přehraje animaci pozpátku po dopředu. Akcelerace a deakcelerace se vztahují na plynulé změny, nikoli na diskrétní přiřazení nebo příkazy.

## **Vytvoření pohybové dráhy**

Použijte [createMotionEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorfactory/#createMotionEffect) pro vytvoření pohybu. Jeho [getFrom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#getTo) a [getBy](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#getBy) popisují souřadnice nebo posuny v procentech. Pro upravitelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpath/) a přiřaďte ji pomocí [MotionEffect.setPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpath/) ukládá příkazy dráhy.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncommandpathtype/) vybírá operaci:

| Příkaz | Body | Význam |
| --- | --- | --- |
| MoveTo | Jeden | Nastaví výchozí pozici. |
| LineTo | Jeden | Přesune se po přímém úseku na jeho koncový bod. |
| CurveTo | Tři | Následuje kubickou křivku definovanou dvěma řídicími body a koncovým bodem. |
| CloseLoop | Žádné | Vrátí se na výchozí pozici. |
| End | Žádné | Ukončí dráhu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpathpointstype/) popisuje charakteristiky úprav bodů, např. rohové nebo hladké body. Nepřepisuje typ příkazu. Použijte typ bodu křivky pro příklad níže a typ rohového bodu pro přímé úseky.

Souřadnice dráhy jsou normalizovány na rozměry snímku: posun X 0.25 představuje čtvrtinu šířky snímku, ne 0.25 bodu. Kladné Y běží dolů. Absolutní příkazy udávají pozice v souřadnicovém systému dráhy; relativní příkazy udávají posuny od aktuální pozice. Toto je oddělené od [getOrigin](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#getOrigin), který vybírá referenční rámec dráhy, a od [getPathEditMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioneffect/#getPathEditMode), který řídí, jak se dráha pohybuje při přesunu tvaru.

### **Vytvoření přímé dráhy**

Vytvořte pohybové chování s výchozím bodem, jedním přímým segmentem a koncovým příkazem. [MotionPath.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpath/#add) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz stanoví (0, 0) a čára končí v (0.25, 0), což dává trase horizontální posun o čtvrt šířky snímku. Koncový příkaz nemá žádné bodové souřadnice. Po přiřazení dráhy se přidáním pohybového chování k efektu propojí tato trasa s obdélníkem.

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

`motion.pptx` obsahuje jedno pohybové chování se třemi příkazy dráhy. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty dráhy popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přičte (0.1, 0.1) k aktuální pozici, tedy (0.2, 0).

Obě dráhy začínají na stejné pozici. Pro relativní čáru přičtěte její X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní čáru přečtěte koncový bod přímo. Přepnutí příznaku bez konverze souřadnic by popisovalo jinou trasu.

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

Přiřaďte kteroukoliv dráhu pohybovému chování, aby se použila v prezentaci. Poslední logický argument volí relativní souřadnice pro daný příkaz.

### **Nahrazení čáry křivkou**

Otevřete `motion.pptx` a nahraďte jeho čárový příkaz kubickou křivkou. Nejprve zadejte dva řídicí body, následovaný koncovým bodem.

Výchozí pozice je dána předchozím příkazem. První dva body určují tvar křivky, třetí je její cíl; nejsou to tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodů a pole bodů najednou udržuje segment v souladu s novou geometrií.

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

Dráha v `curve.pptx` má stále tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené dráhy**

Každý [MotionCmdPath](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncmdpath/) odhaluje [getPoints](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncmdpath/#getPointsType) a [isRelative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motioncmdpath/#isRelative). Následující příklady používají známou třípříkazovou dráhu v `motion.pptx`. Pro libovolný vstup nejprve najděte zamýšlený efekt a před úpravou indexu zkontrolujte typy příkazů a počet bodů.

### **Čtení příkazů a souřadnic**

Přečtěte dráhu bez změny. Příkazy end a close‑loop nepotřebují body, takže počítejte s null polem bodů.

Výstup spojuje každý číselný typ příkazu s jeho příznakem relativních souřadnic před výpisem jeho bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou dráhy. Křivka by vypsala tři body, zatímco přímá čára v tomto souboru pouze jeden.

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

Výpis obsahuje výchozí bod, absolutní čáru končící v (0.25, 0) a koncový příkaz.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů čáry, aby se změnil její koncový bod.

Ve vstupním souboru je index 0 výchozí příkaz a index 1 je čára. Nahrazením jediného bodu čáry změníte její cíl, aniž byste změnili typ příkazu, časování nebo pozici v kolekci. Protože příkaz používá absolutní souřadnice, nový pár určuje pozici, nikoli přidaný offset.

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

Čára v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává nezměněn.

### **Nahrazení segmentu**

Použijte [insert](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpath/#insert) a [removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/motionpath/#removeAt) k nahrazení čáry v `motion.pptx`. Vložení posune starou čáru na index 2.

Tím se ukazuje nahrazení objektu příkazu místo editace jeho stávajících souřadnic. Po vložení kolekce dočasně obsahuje výchozí příkaz, novou čáru, starou čáru a koncový příkaz. Odebráním indexu 2 se stará čára odstraní a nová trasa zůstane.

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

Uložená dráha má stále tři příkazy, přičemž nová čára končí v (0.2, 0.1) a koncový příkaz zůstává poslední.

## **Úprava a ověření existujícího chování**

Když není znám index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [RotationEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/rotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčení. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže porovnání kontroluje perzistentní data místo hodnoty stále držené v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: True`. Použijte stejný vzor kontroly typu i pro další chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování i příkazy dráhy. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým uspořádáním animací viz [Read Shape Animations](/slides/cs/python-java/shape-animation/#read-shape-animations) pro průchod hlavními i interaktivními sekvencemi.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [BehaviorCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Načasování a zahrnující efekt určují plánování. Chování se mohou překrývat a operace na stejné vlastnosti mohou navzájem interagovat pomocí [getAdditive](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behavior/#getAdditive) a [getAccumulate](https://reference.aspose.com/slides/cs/python-java/aspose.slides/behavior/#getAccumulate). Nepoužívejte samotné přeuspořádání kolekce k plánování „přesun, pak otáčení“; použijte explicitní časování nebo oddělené efekty, jak je popsáno v [Shape Animation](/slides/cs/python-java/shape-animation/).

[Effect.getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getType) a [Effect.getSubtype](https://reference.aspose.com/slides/cs/python-java/aspose.slides/effect/#getSubtype) popisují jeho předvolbu. Nejsou však úplným popisem upraveného stromu chování. Zvolte předvolbu a podtyp před přizpůsobením chování: změna předvolby může přestavět kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného Spin efektu na Fade může nahradit otáčovací chování chováním set a filter. Po změně předvolby nebo podtypu kolekci znovu prozkoumejte. Vyprázdnění přednastavených chování může také odstranit operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady úmyslně používají viditelné tvary a nahrazují chování; nepřestavují kompletní implementaci každé předvolby.

## **Kompatibilita formátů**

Uchovaný strom chování nezaručuje identické přehrávání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a renderovaný výstup samostatně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Použijte jako primární formát pro tyto příklady. Otevřete jej znovu pro ověření editovatelného stromu chování, pak zkontrolujte přehrávání v cílové verzi PowerPointu. |
| PPT | Děděný binární formát se může lišit od PPTX. Otestujte samostatný cyklus uložení‑opětovného‑otevření a přehrávání; nevyvozuji podporu každé vlastní kombinace z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické obrázky snímků | Obsahují statickou reprezentaci snímku, nikoli přehratelnou časovou osu chování nebo garantovaný konečný animační snímek. |
| [HTML5](/slides/cs/python-java/export-to-html5/) | Může přehrávat podporované animace, pokud je v exportních možnostech povolena animace tvaru. Otestujte vlastní kombinace v prohlížeči. |
| [Animated GIF](/slides/cs/python-java/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani interakci spouštěnou kliknutím. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/python-java/convert-powerpoint-to-video/) | Vykreslí animační snímky a zakóduje je jako video. Podpora je omezena na [supported animations and effects](/slides/cs/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) rendereru; příkazy a interaktivní události se nepromění v editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování předtím, než něco přidám?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prozkoumejte je před tím, než se rozhodnete rozšířit předvolbu nebo nahradit její chování.

**Zda přesunutí chování na začátek způsobí, že se přehraje jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte prodlevy, trvání a interakce mezi operacemi na stejné vlastnosti.

**Proč má příkaz end žádné body?**

Označuje konec dráhy a nepotřebuje souřadnice. Při prohlížení dráhy načtené ze souboru kontrolujte null pole bodů.

**Je úspěšný round‑trip dostačující k potvrzení přehrávání?**

Ne. Opětovné otevření potvrzuje zachování kontrolovaných vlastností. Animaci v prezentačním přehrávači nebo animovaný export otestujte zvlášť, abyste potvrdili její vizuální chování.