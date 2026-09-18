---
title: Vytváření a úprava vlastních animačních chování na Androidu
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/androidjava/custom-animation/
keywords:
- vlastní animace
- animační chování
- dráha pohybu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvářejte, prohlížejte a upravujte vlastní animační chování a editovatelné dráhy pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Vlastní animační chování vám umožňuje ovládat jednotlivé operace v rámci animačního efektu, například změnu barvy, otáčení objektu nebo sledování editovatelné dráhy pohybu. Tento průvodce ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich časování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přetrvávají po uložení a opětovném otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutím viz [Animace tvaru](/slides/cs/androidjava/shape-animation/).

## **Pochopení modelu animace**

Animace je organizována jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) vrací časovou osu snímku, která obsahuje hlavní sekvenci a interaktivní sekvence.
- [ISequence](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [IEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/) určuje cílový tvar, předvolbu, podtyp a časování efektu.
- Kolekce vrácená metodou [IEffect.getBehaviors](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getBehaviors--) obsahuje operace, které implementují efekt: změna barvy, přesun, otáčení, nastavení vlastnosti atd.

## **Vytvoření jednotlivých chování**

Zavolejte [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) k vytvoření efektu a přístupu ke kolekci [getBehaviors](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Předvolba může tuto kolekci naplnit automaticky. Uchovejte její operace při rozšiřování předvolby nebo použijte [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) při úmyslném nahrazení.

[IBehaviorFactory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/) vytváří osm typů chování znázorněných níže. Pohyb je pokryt v [Vytvoření dráhy pohybu](#build-a-motion-path). Každý úryvek zahrnuje své importy; vložte vykonávané příkazy do metody. Příklady úprav později uvádějí, který výstupní soubor používají. V Androidu nahraďte názvy souborů ukázky úplnými cestami do adresáře přístupného aplikaci, např. do adresáře souborů vaší aplikace.

### **Otáčení**

Použijte [createRotationEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) k vytvoření otáčení. [getBy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irotationeffect/#getBy--) určuje relativní úhel ve stupních; [getFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irotationeffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irotationeffect/#getTo--) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho přednastavené operace jedním otáčecím chováním a nastaví tomuto chování dvousekundovou dobu trvání. Relativní úhel 90 stupňů představuje čtvrtotoč s výchozí orientací tvaru, takže není potřeba explicitně uvádět počáteční úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno otáčecí chování. Kolekce, časování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [createScaleEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) s procenty X/Y: [getFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iscaleeffect/#getTo--) popisují počáteční a koncovou velikost, zatímco [getBy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iscaleeffect/#getBy--) popisuje relativní změnu. Zde 100 znamená původní velikost.

Příklad zvětší oba rozměry z 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachová proporce tvaru; odlišná procenta by protáhla jeden rozměr více než druhý.

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

### **Barva**

Použijte [createColorEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) ke změně výplně z modré na oranžovou. [getFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icoloreffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icoloreffect/#getTo--) jsou barvy; [getBy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icoloreffect/#getBy--) je barevný posun. [IBehavior.getProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehavior/#getProperties--) identifikuje atribut, který se animuje.

Pevná výplň tvaru je inicializována na modrou, což odpovídá počáteční barvě animace. Výběr atributu výplně říká chování, kterou část tvaru má měnit; samotné koncové barvy neurčují tento atribut. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [createFilterEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) k výběru setření. [getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), a [getReveal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové setření, které odhalí tvar pomocí podtypu směřujícího doprava. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována poté, co byly odstraněny původní operace předvolby.

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

### **Vlastnost**

Použijte [createPropertyEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) k animaci neprůhlednosti. [getFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), a [getBy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) jsou řetězce interpretované pomocí [getValueType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) a [getCalcMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Zvolte koncové body nebo relativní posun namísto nastavení všech tří bez rozlišování.

Zde je vybrán atribut neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje postupnou změnu mezi těmito hodnotami. Při přizpůsobení tohoto příkladu jinému atributu zvolte typ hodnoty a koncové hodnoty vhodné pro daný atribut.

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

### **Nastavení**

Použijte [createSetEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) k přiřazení viditelnosti pomocí [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iseteffect/#getTo--). Chování nastavení neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samo o sobě způsobit zřetelnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

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

### **Příkaz**

Použijte [createCommandEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) a nakonfigurujte [getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), a [getShapeTarget](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Umístěte WAV nahrávku pojmenovanou `sample.wav` do pracovního adresáře. Tento příklad ji vloží pomocí [addAudioFrameEmbedded](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) a připojí příkaz přehrání k audio rámci.

Audio rámec je jak cílem efektu, tak cílem příkazu. Tím se spojí požadavek na přehrání s vloženou nahrávkou; samotný řetězec příkazu neurčuje, který multimediální objekt ovládat. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení ukládá příkaz do `command.pptx`; nahrávka se nepřehraje. Přehrání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho multimediální cíl.

## **Správa kolekce chování**

[IBehaviorCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), a [removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odstraní otáčení. Odstranění a opětovné vložení stejného objektu změní jeho uloženou pozici, aniž by se vytvořila kopie.

Sekvence úprav mění kolekci z otáčení‑měřítka na měřítko‑otáčení, pak jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstranění používá nový index otáčení po přeuspořádání. Závěrečný výpis potvrzuje, které chování bude uloženo.

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

Výstupem je `ScaleEffect`: zůstává jen měřítko. Pořadí v kolekci samo o sobě neschraňuje chování jedno po druhém. Vyprázdnit kolekci jen při úplném nahrazení všech jejích operací.

## **Konfigurace časování chování**

[IBehavior.getTiming](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehavior/#getTiming--) odhaluje [ITiming](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/), nezávisle na [IEffect.getTiming](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getTiming--). Časování efektu plánuje obalující efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení trvání, zpoždění, opakování a zrychlení**

Otevřete `rotation.pptx` a nastavte trvání ([getDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getDuration--)) a zpoždění spouštěče ([getTriggerDelayTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) v sekundách, pak konfigurujte počet opakování pomocí [setRepeatCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getAccelerate--) a [getDecelerate](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getDecelerate--) jsou zlomky trvání; jejich součet udržujte maximálně na 1.

Vstupní soubor je ten, který byl vytvořen v příkladu otáčení, kde je první chování známo jako otáčení. Tento příklad mění jen časování toho chování; jeho úhel 90 ° zůstává zachován. Oddělení úhlu a časování usnadňuje úpravu tempa bez přestavby animace.

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

Chování používá dvousekundové trvání, půlsekundové zpoždění a počet opakování 3. Prvních a posledních 20 % trvání jsou použity pro zrychlení a zpomalení.

Další politiky opakování zahrnují [getRepeatDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), a [getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); zvolte jednu politiku místo povolení všech najednou. [getAutoReverse](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getAutoReverse--) přehraje animaci pozpátku po dopředném průchodu. Zrychlení a zpomalení se vztahují na plynulé změny, ne na diskrétní přiřazení nebo příkazy.

## **Vytvoření dráhy pohybu**

Použijte [createMotionEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) k vytvoření pohybu. Jeho [getFrom](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#getTo--), a [getBy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#getBy--) popisují souřadnice nebo posuny založené na procentech. Pro editovatelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/motionpath/) a přiřaďte ji pomocí [IMotionEffect.setPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotionpath/) ukládá příkazy cesty.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/motioncommandpathtype/) vybírá operaci:

| Příkaz | Počet bodů | Význam |
| --- | --- | --- |
| MoveTo | Jeden | Nastaví počáteční pozici. |
| LineTo | Jeden | Přesune se po přímém úseku k jeho koncovému bodu. |
| CurveTo | Tři | Následuje kubickou křivku definovanou dvěma řídícími body a koncovým bodem. |
| CloseLoop | Žádný | Vrátí se na počáteční pozici. |
| End | Žádný | Ukončí cestu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/motionpathpointstype/) popisuje charakteristiky úpravy bodů, jako jsou rohové nebo hladké body. Nenahrazuje typ příkazu. Pro příklad křivky níže použijte typ bodu křivky a pro přímé úseky typ rohový.

Souřadnice cesty jsou normalizovány na rozměry snímku: posun X 0,25 představuje čtvrtinu šířky snímku, ne 0,25 bodu. Kladná osa Y jde dolů. Absolutní příkazy určují pozice v souřadnicovém systému cesty; relativní příkazy určují posuny od aktuální pozice. To je oddělené od [getOrigin](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), který vybírá referenční rámec cesty, a [getPathEditMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), který řídí, jak se cesta pohybuje, když se tvar přesune.

### **Vytvoření přímé cesty**

Vytvořte chování pohybu s počátečním bodem, jedním přímým úsekem a koncovým příkazem. [IMotionPath.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz stanovuje (0, 0) a úsečka končí v (0.25, 0), čímž cesta získá horizontální posun o čtvrtinu šířky snímku. Koncový příkaz nemá žádné souřadnice. Po přiřazení cesty přidání chování pohybu k efektu spojuje tuto trasu s obdélníkem.

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

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy cesty. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty cesty popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přidá (0.1, 0.1) k aktuální pozici, tj. (0.2, 0).

Obě cesty začínají ve stejné pozici. Pro relativní úsečku přičtěte její X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní úsečku přečtěte koncový bod přímo. Přepnutí příznaku bez konverze souřadnic by popisovalo jinou trasu.

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

Přiřaďte libovolnou cestu k chování pohybu, aby se použila v prezentaci. Poslední logický argument volí relativní souřadnice pro daný příkaz.

### **Nahrazení úsečky křivkou**

Otevřete `motion.pptx` a nahraďte jeho úsečkový příkaz kubickou křivkou. Nejprve zadejte dva řídící body, následované koncovým bodem.

Počáteční pozice je určena předchozím příkazem. První dva body tvarují křivku, zatímco třetí je její cíl; nejsou to tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodu a pole bodů společně udržuje úsek v souladu s novou geometrií.

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

Cesta v `curve.pptx` stále obsahuje tři příkazy; její střední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené cesty**

Každý [IMotionCmdPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioncmdpath/) odhaluje [getPoints](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), a [isRelative](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Následující příklady používají známou třípříkazovou cestu v `motion.pptx`. Pro libovolný vstup najděte zamýšlený efekt a před úpravou podle indexu zkontrolujte typy příkazů a počet bodů.

### **Čtení příkazů a souřadnic**

Přečtěte cestu bez její změny. Příkazy End a CloseLoop nepotřebují body, takže umožněte nulové pole bodů.

Výstup spáruje každý číselný typ příkazu s jeho příznakem relativních souřadnic před výpisem bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou cesty. Křivka by vypsala tři body, zatímco přímá úsečka v tomto souboru pouze jeden.

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

Výpis obsahuje počáteční bod, absolutní úsečku končící v (0.25, 0) a koncový příkaz.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů úsečky, aby se posunul její koncový bod.

Ve vstupním souboru je index 0 počáteční příkaz a index 1 úsečka. Nahrazení jediného bodu úsečky změní její cíl, aniž by se změnil typ příkazu, časování nebo pozice v kolekci. Protože příkaz používá absolutní souřadnice, nový pár specifikuje pozici, nikoli přidaný offset.

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

Úsečka v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává nezměněn.

### **Nahrazení úseku**

Použijte [insert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) a [removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) k nahrazení úsečky v `motion.pptx`. Vložení posune starou úsečku na index 2.

Tím se demonstruje nahrazení objektu příkazu místo úpravy jeho stávajících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, novou úsečku, starou úsečku a koncový příkaz. Odstraněním indexu 2 se stará úsečka zahodí a nová trasa zůstane.

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

Uložená cesta stále má tři příkazy, přičemž nová úsečka končí v (0.2, 0.1) a koncový příkaz je poslední.

## **Úprava a ověření existujícího chování**

Když není známý index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [IRotationEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčením. Druhé načtení čte uložený soubor do samostatného objektu prezentace, takže srovnání kontroluje trvalá data, nikoli hodnotu stále drženou v paměti. Příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: true`. Použijte stejný vzor kontroly typu i pro další chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy cesty. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým rozvržením animací viz [Číst animace tvarů](/slides/cs/androidjava/shape-animation/#read-shape-animations) pro procházení hlavních i interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [IBehaviorCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Časování a obalující efekt určují plánování. Chování se mohou překrývat a operace na stejné vlastnosti mohou interagovat přes [getAdditive](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehavior/#getAdditive--) a [getAccumulate](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Nepoužívejte samotné přeuspořádání kolekce k naplánování „přesunout, pak otočit“; použijte explicitní časování nebo oddělené efekty, jak je popsáno v [Animace tvaru](/slides/cs/androidjava/shape-animation/).

[IEffect.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getType--) a [IEffect.getSubtype](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getSubtype--) popisují jeho předvolbu. Nejsou úplným popisem upraveného stromu chování. Zvolte předvolbu a podtyp před vlastním přizpůsobením chování: změna předvolby může přestavit kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného efektu Spin na Fade může nahradit jeho otáčecí chování chováními set a filter. Po změně předvolby nebo podtypu znovu prohlédněte kolekci. Vymazání přednastavených chování může také odstranit operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady úmyslně používají viditelné tvary a nahrazují chování; nekonstruují kompletní implementaci každé předvolby.

## **Kompatibilita formátů**

Uchování stromu chování nezaručuje identické přehrávání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a renderovaný výstup zvlášť.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Používejte jako primární formát pro tyto příklady. Znovu jej otevřete a ověřte editovatelný strom chování, poté zkontrolujte přehrávání ve požadované verzi PowerPointu. |
| PPT | Starší binární reprezentace se může lišit od PPTX. Otestujte samostatný cyklus uložení‑otevření a přehrávání; nevyvozujte podporu pro každou vlastní kombinaci z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické obrázky snímků | Obsahují statický obrázek snímku, nikoli přehrávatelnou časovou osu chování ani garantovaný finální animační snímek. |
| [HTML5](/slides/cs/androidjava/export-to-html5/) | Může přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvaru. Otestujte vlastní kombinace v prohlížeči. |
| [Animated GIF](/slides/cs/androidjava/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani interaktivní události spouštěné kliknutím. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/androidjava/convert-powerpoint-to-video/) | Vykresluje animační snímky a kóduje je jako video. Podpora je omezená na [podporované animace a efekty](/slides/cs/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) rendereru; příkazy a interaktivní události se nepromění na editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování, i když jsem žádné nepřidal?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte si je, než se rozhodnete, zda předvolbu rozšířit nebo její chování nahradit.

**Zda přesunutí chování na začátek způsobí jeho přehrání jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, trvání a interakce mezi operacemi na stejné vlastnosti.

**Proč má koncový příkaz žádné body?**

Označuje konec cesty a nepotřebuje souřadnice. Při prohlížení cesty načtené ze souboru kontrolujte, zda pole bodů není nulové.

**Je úspěšná zpětná cesta dostatečná pro potvrzení přehrávání?**

Ne. Opětovné otevření potvrzuje zachování kontrolovaných vlastností. Testujte přehrávač prezentací nebo animovaný export samostatně, abyste potvrdili jeho vizuální chování.