---
title: Vytváření a úprava vlastních animačních chování v Pythonu
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/python-net/custom-animation/
keywords:
- vlastní animace
- chování animace
- dráha pohybu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte, prohlížejte a upravujte vlastní animační chování a editovatelné dráhy pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro Python na platformě .NET."
---
## **Přehled**

Vlastní animační chování vám umožňují ovládat jednotlivé operace v rámci animačního efektu, jako je změna barvy, otáčení objektu nebo sledování editovatelné dráhy pohybu. Tento průvodce ukazuje, jak vytvářet a kombinovat chování, nastavit jejich časování, prohlížet a upravovat existující animace a ověřovat, že jejich vlastnosti přežijí uložení a opětovné otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutí viz [Animace tvaru](/slides/cs/python-net/shape-animation/).

## **Pochopení animačního modelu**

Animace je organizována jako **Timeline → Sequence → Effect → Behaviors**:

- Časová osa [timeline](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/timeline/) snímku obsahuje hlavní sekvenci a interaktivní sekvence.
- [Sequence](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [Effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/) identifikuje cílový tvar, předvolbu, podtyp a časování efektu.
- [Effect.behaviors](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/behaviors/) obsahuje operace, které efekt implementují: změna barvy, přesun, otáčení, nastavení vlastnosti a podobně.

## **Vytvoření jednotlivých chování**

Voláním [Sequence.add_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/add_effect/) vytvoříte efekt a získáte jeho kolekci [behaviors](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/behaviors/). Předvolba může tuto kolekci naplnit automaticky. Ponechte její operace při rozšiřování předvolby, nebo použijte [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/clear/) při záměrném nahrazení.

[BehaviorFactory](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v kapitole [Vytvoření dráhy pohybu](#build-a-motion-path). Každý příklad vytvoření je kompletní program; pozdější příklady úprav uvádějí, který výstupní soubor používají.

### **Otáčení**

Použijte [create_rotation_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) k vytvoření otáčení. [by](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/rotationeffect/by/) určuje úhel relativně ve stupních; [from_address](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/rotationeffect/from_address/) a [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/rotationeffect/to/) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho operace předvolby jedním otáčecím chováním a nastaví této operaci dvousekundovou dobu trvání. Relativní úhel 90 stupňů představuje čtvrtotoč, takže není potřeba explicitně uvádět výchozí úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno otáčecí chování. Kolekce, časování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [create_scale_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) s procenty X/Y: [from_address](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/scaleeffect/from_address/) a [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/scaleeffect/to/) popisují počáteční a koncovou velikost, zatímco [by](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/scaleeffect/by/) popisuje relativní změnu. Zde 100 znamená původní velikost.

Příklad zvětšuje oba rozměry ze 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachovává proporce tvaru; odlišná procenta by natahovala jeden rozměr více než druhý.

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

### **Barva**

Použijte [create_color_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) ke změně výplně z modré na oranžovou. [from_address](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/coloreffect/from_address/) a [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/coloreffect/to/) jsou barvy; [by](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/coloreffect/by/) je posun barvy. [Behavior.properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behavior/properties/) určuje, který atribut je animován.

Výplň tvaru je inicializována na modrou, což odpovídá výchozí barvě animace. Výběrem atributu výplně říkáte chování, kterou část tvaru má měnit; samotné koncové barvy atribut neurčují. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [create_filter_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) k výběru setření. [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/filtereffect/subtype/) a [reveal](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/filtereffect/reveal/) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad nastavuje dvousekundové setření, které odhalí tvar pomocí podtypu pravého směru. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována po odstranění původních operací předvolby.

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

### **Vlastnost**

Použijte [create_property_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) k animaci neprůhlednosti. [from_address](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/to/) a [by](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/by/) jsou řetězce interpretované pomocí [value_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/value_type/) a [calc_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Zvolte koncové body nebo relativní posun místo nastavení všech tří najednou.

Zde je vybraná vlastnost neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje postupnou změnu mezi těmito hodnotami. Při přizpůsobení tohoto příkladu jiné vlastnosti zvolte odpovídající typ hodnoty a koncové hodnoty.

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

### **Nastavení**

Použijte [create_set_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) k přiřazení viditelnosti pomocí [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/seteffect/to/). Chování typu set neinterpoluje mezi koncovými body.

Příklad vybírá atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samo o sobě produkovat zjevnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

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

### **Příkaz**

Použijte [create_command_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) a nastavte [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/commandeffect/command_string/) a [shape_target](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/commandeffect/shape_target/). Umístěte záznam WAV pojmenovaný `sample.wav` do pracovního adresáře. Tento příklad jej vloží pomocí [add_audio_frame_embedded](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) a připojí příkaz přehrát k audio rámci.

Audio rámec je zároveň cílem efektu i cílem příkazu. To spojuje požadavek na přehrání s vloženým záznamem; samotný řetězec příkazu neidentifikuje, který mediální objekt má ovládat. Efekt je nastaven tak, aby startoval po kliknutí během prezentace.

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

Uložení ukládá příkaz do `command.pptx`; záznam se nepřehraje. Přehrání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[BehaviorCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/remove/), a [remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Tento příklad otevírá `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odstraní otáčení. Odstranění a opětovné vložení stejného objektu mění jeho uloženou pozici bez vytvoření kopie.

Pořadí úprav mění kolekci z otáčení–měřítko na měřítko–otáčení a nakonec jen na měřítko. Indexy se vztahují k aktuální kolekci, takže odstranění používá nový index otáčení po přeuspořádání. Konečné výčtování potvrzuje, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstává jen měřítko. Pořadí v kolekci samo o sobě neplánuje chování jedna po druhé. Vyčistěte kolekci jen při nahrazování všech jejích operací.

## **Nastavení časování chování**

[Behavior.timing](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behavior/timing/) vystavuje [Timing](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/), nezávisle na [Effect.timing](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/timing/). Časování efektu plánuje obklopující efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení doby trvání, zpoždění, opakování a akcelerace**

Otevřete `rotation.pptx` a nastavte [duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/duration/) a [trigger_delay_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/trigger_delay_time/) v sekundách, pak nakonfigurujte [repeat_count](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/accelerate/) a [decelerate](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/decelerate/) jsou podíly doby trvání; jejich součet nesmí přesáhnout 1.

Vstupní soubor je ten vytvořený v příkladu otáčení, kde je první chování známé jako otáčení. Tento příklad mění jen časování tohoto chování; úhel 90 ° zůstává nedotčen. Oddělení úhlu a časování usnadňuje úpravu tempa bez nutnosti přestavovat animaci.

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

Chování používá dvousekundovou dobu trvání, půlsekundové zpoždění a počet opakování 3. Prvních a posledních 20 % doby trvání jsou použity pro akceleraci a deakceleraci.

Další politiky opakování zahrnují [repeat_duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), a [repeat_until_next_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/repeat_until_next_click/); vyberte jednu politiku místo povolení všech najednou. [auto_reverse](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/timing/auto_reverse/) přehraje animaci zpětně po dopředném průchodu. Akcelerace a deakcelerace se vztahují na plynulé změny, nikoli na diskrétní přiřazení nebo příkazy.

## **Vytvoření dráhy pohybu**

Použijte [create_motion_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) k vytvoření pohybu. Jeho [from_address](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/to/) a [by](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/by/) popisují souřadnice nebo posuny založené na procentech. Pro editovatelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpath/) a přiřaďte ji k [MotionEffect.path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpath/) ukládá příkazy cesty.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncommandpathtype/) vybírá operaci:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Nastaví počáteční pozici. |
| LINE_TO | One | Přesune se podél úseku k jeho koncovému bodu. |
| CURVE_TO | Three | Následuje kubickou křivku definovanou dvěma řídicími body a koncovým bodem. |
| CLOSE_LOOP | None | Vrátí se na počáteční pozici. |
| END | None | Ukončí cestu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpathpointstype/) popisuje charakteristiky úpravy bodů, jako jsou rohové nebo hladké body. Nenahrazuje typ příkazu. Použijte typ bodu křivky pro níže uvedený příklad křivky a typ rohového bodu pro přímé úseky.

Souřadnice cesty jsou normalizovány na rozměry snímku: posun X o 0,25 představuje čtvrtinu šířky snímku, ne 0,25 bodu. Kladné Y směřuje dolů. Absolutní příkazy určují pozice v souřadnicovém systému cesty; relativní příkazy určují posuny od aktuální pozice. To je oddělené od [origin](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/origin/), který vybírá referenční rámec cesty, a [path_edit_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), který řídí, jak se cesta pohybuje při přesunu tvaru.

### **Vytvoření přímé cesty**

Vytvořte chování pohybu s počátečním bodem, jedním přímým úsekem a koncovým příkazem. [MotionPath.add](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpath/add/) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz stanoví (0, 0) a úsek končí v (0.25, 0), což dává trase horizontální posun o čtvrtinu šířky snímku. Koncový příkaz nemá žádné souřadnicové body. Po přiřazení cesty se přidáním chování pohybu k efektu propojí tato trasa s obdélníkem.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
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

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy cesty. Následující příklady úpravy souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty cesty popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přidá (0.1, 0.1) k aktuální pozici, tedy (0.2, 0).

Obě cesty začínají ve stejné pozici. Pro relativní úsek přidejte jeho X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní úsek přečtěte koncový bod přímo. Přepnutí příznaku bez převodu souřadnic by popisovalo jinou trasu.

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

Přiřaďte kteroukoliv cestu k chování pohybu, abyste ji použili v prezentaci. Poslední Booleovský argument volí relativní souřadnice pro daný příkaz.

### **Nahrazení úseku křivkou**

Otevřete `motion.pptx` a nahraďte jeho příkaz úseku kubickou křivkou. Nejprve zadejte dva řídicí body, následované koncovým bodem.

Počáteční pozice je dána předchozím příkazem. První dva body tvarují křivku, zatímco třetí je její cíl; nejde o tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodů a pole bodů najednou zachovává úsek v souladu s novou geometrií.

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

Cesta v `curve.pptx` stále má tři příkazy; její střední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené cesty**

Každý [MotionCmdPath](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncmdpath/) vystavuje [points](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncmdpath/points_type/), a [is_relative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Následující příklady používají známou třípříkazovou cestu v `motion.pptx`. Pro libovolný vstup najděte zamýšlený efekt a před úpravou podle indexu zkontrolujte typy příkazů a počet bodů.

### **Čtení příkazů a souřadnic**

Přečtěte cestu bez změny. Příkazy konce a uzavření smyčky nepotřebují body, takže umožněte `None` pole bodů.

Výstup spáruje každý příkaz s jeho příznakem relativních souřadnic před výpisem jeho bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou cesty. Křivka vypíše tři body, zatímco přímý úsek v tomto souboru vypíše jen jeden.

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

Výpis obsahuje počáteční bod, absolutní úsek končící v (0.25, 0) a příkaz END.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů úseku, aby se posunul jeho koncový bod.

Ve vstupním souboru je index 0 počáteční příkaz a index 1 úsek. Nahrazení jediného bodu úseku mění jeho cíl bez změny typu příkazu, časování nebo pozice v kolekci. Vzhledem k tomu, že příkaz používá absolutní souřadnice, nový pár určuje pozici místo přidaného offsetu.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Úsek v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává nezměněn.

### **Nahrazení úseku**

Použijte [insert](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpath/insert/) a [remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motionpath/remove_at/) k nahrazení úseku v `motion.pptx`. Vložení posune starý úsek na index 2.

Tím se demonstruje nahrazení objektu příkazu namísto úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, nový úsek, starý úsek a příkaz END. Odstraněním indexu 2 se starý úsek zruší a nová trasa zůstane.

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

Uložená cesta stále má tři příkazy, přičemž nový úsek končí v (0.2, 0.1) a poslední příkaz je END.

## **Úprava a ověření existujícího chování**

Když není index chování známý, vyberte ho podle typu. Tento příklad otevírá `rotation.pptx`, najde jeho [RotationEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/rotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčení. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže porovnání kontroluje trvalá data, nikoli hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: True`. Použijte stejný vzor kontroly typu i pro další chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy cesty. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým rozložením animací viz [Čtení animací tvarů](/slides/cs/python-net/shape-animation/#read-shape-animations) pro procházení hlavních a interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [BehaviorCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém by každé chování automaticky čekalo na předchozí. Časování a obklopující efekt určují plánování. Chování mohou překrývat a operace na stejné vlastnosti mohou interagovat přes [additive](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behavior/additive/) a [accumulate](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behavior/accumulate/). Nepoužívejte pouhé přeuspořádání kolekce k naplánování „přesun, pak otáčení“; použijte explicitní časování nebo samostatné efekty, jak je popsáno v [Animace tvaru](/slides/cs/python-net/shape-animation/).

Typ [effect.type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/type/) a [effect.subtype](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effect/subtype/) popisují jeho předvolbu. Nejsou kompletním popisem upraveného stromu chování. Vyberte předvolbu a podtyp před přizpůsobením chování: změna předvolby může obnovit kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného Spin efektu na Fade může nahradit otáčivé chování nastavením a filtračními chováními. Po změně předvolby nebo podtypu znovu prohlédněte kolekci. Vymazání předvolených chování může také odebrat operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady úmyslně používají viditelné tvary a nahrazují chování; neopakují kompletní implementaci každé předvolby.

## **Kompatibilita formátů**

Uchování stromu chování negarantuje totožné přehrávání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a renderovaný výstup zvlášť.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Používejte jako primární formát pro tyto příklady. Otevřete jej znovu k ověření editovatelného stromu chování a poté zkontrolujte přehrávání v požadované verzi PowerPointu. |
| PPT | Legacy binární reprezentace se může lišit od PPTX. Proveďte samostatný cyklus uložení‑otevření a přehrávání; nevyvozujte podporu pro každou kombinaci z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické snímky | Obsahují statickou reprezentaci snímku, ne přehratelnou časovou osu chování ani garantovaný konečný animační rámec. |
| [HTML5](/slides/cs/python-net/export-to-html5/) | Umí přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvaru. Otestujte vlastní kombinace v prohlížeči. |
| [Animovaný GIF](/slides/cs/python-net/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, nikoli editovatelné chování nebo interakci při kliknutí. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/python-net/convert-powerpoint-to-video/) | Vykreslí animační snímky a zakóduje je jako video. Podpora je omezena na [podporované animace a efekty](/slides/cs/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; příkazy a interaktivní události se nepromění v editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování, i když jsem žádná nepřidal?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte je, než se rozhodnete, zda předvolbu rozšířit nebo její chování nahradit.

**Zda přesunutí chování na začátek způsobí jeho první přehrání?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, doby trvání a interakce mezi operacemi na stejné vlastnosti.

**Proč má koncový příkaz žádné body?**

Označuje konec cesty a nepotřebuje žádné souřadnice. Při prohlížení cesty načtené ze souboru kontrolujte, zda pole bodů je `None`.

**Je úspěšný cyklus uložení‑otevření dostatečný k potvrzení přehrávání?**

Ne. Otevření jen potvrzuje zachování kontrolovaných vlastností. Otestujte přehrávač prezentací nebo animovaný export samostatně, abyste ověřili jeho vizuální chování.