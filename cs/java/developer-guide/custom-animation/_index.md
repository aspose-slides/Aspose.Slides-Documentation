---
title: Vytvoření a úprava vlastních animačních chování v Javě
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/java/custom-animation/
keywords:
- vlastní animace
- animační chování
- dráha pohybu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte, prohlédněte a upravte vlastní animační chování a editovatelné dráhy pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Vlastní animační chování vám umožňují řídit jednotlivé operace v rámci animačního efektu, například změnu barvy, otáčení tvaru nebo sledování editovatelné dráhy pohybu. Tento průvodce ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich časování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přežijí uložení a opětovné otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutím viz [Shape Animation](/slides/cs/java/shape-animation/).

## **Pochopení animačního modelu**

Animace je organizována jako **Timeline → Sequence → Effect → Behaviors**:

- Metoda [getTimeline](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getTimeline--) vrací časovou osu snímku, která obsahuje hlavní sekvenci i interaktivní sekvence.
- [ISequence](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/) obsahuje efekty, které mohou cílit na různé tvary.
- [IEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/) identifikuje cílový tvar, předvolbu, podtyp a časování efektu.
- Kolekce vrácená metodou [IEffect.getBehaviors](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getBehaviors--) obsahuje operace, které implementují efekt: změna barvy, přesun, otáčení, nastavení vlastnosti a podobně.

## **Vytvoření jednotlivých chování**

Voláním [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) vytvoříte efekt a získáte přístup ke kolekci [getBehaviors](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getBehaviors--). Předvolba může tuto kolekci naplnit automaticky. Uchovejte její operace při rozšiřování předvolby, nebo použijte [clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/#clear--) když je záměrně nahrazujete.

[IBehaviorFactory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v sekci [Build a Motion Path](#build-a-motion-path). Každý úryvek obsahuje své importy; vkládejte spustitelné příkazy do metody. Příklady úprav později uvádějí, který výstupní soubor používají.

### **Rotace**

Použijte [createRotationEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) k vytvoření rotace. [getBy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irotationeffect/#getBy--) určuje relativní úhel ve stupních; [getFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irotationeffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irotationeffect/#getTo--) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho předvolené operace jedním chováním rotace a nastaví tomuto chování dvousekundovou dobu trvání. Relativní úhel 90 stupňů představuje čtvrtotoč, takže není třeba explicitně zadávat počáteční úhel.

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

`rotation.pptx` obsahuje jeden tvar a jedno chování rotace. Kolekce, časování a příklady úprav rotace níže používají tento soubor.

### **Měřítko**

Použijte [createScaleEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) s procenty X/Y: [getFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iscaleeffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iscaleeffect/#getTo--) popisují počáteční a koncovou velikost, zatímco [getBy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iscaleeffect/#getBy--) popisuje relativní změnu. Zde 100 % znamená původní velikost.

Příklad zvětšuje oba rozměry z 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachovává proporce tvaru; odlišná procenta by protáhla jeden rozměr více než druhý.

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

### **Barva**

Použijte [createColorEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) ke změně výplně z modré na oranžovou. [getFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icoloreffect/#getFrom--) a [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icoloreffect/#getTo--) jsou barvy; [getBy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icoloreffect/#getBy--) je posun barvy. [IBehavior.getProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehavior/#getProperties--) identifikuje atribut, který je animován.

Výplň tvaru je inicializována na modrou, což odpovídá počáteční barvě animace. Výběr atributu výplně říká chování, kterou část tvaru má měnit; samotné koncové barvy neidentifikují tento atribut. Uložený efekt popisuje dvousekundový přechod na oranžovou.

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

### **Filtr**

Použijte [createFilterEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) k výběru setření. [getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifiltereffect/#getSubtype--), a [getReveal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifiltereffect/#getReveal--) určují typ filtru, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové setření, které odhalí tvar pomocí podtypu pravý směr. Nastavení filtru patří k chování uvnitř efektu, takže jsou konfigurována po odstranění původních operací předvolby.

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

Použijte [createPropertyEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) k animaci neprůhlednosti. [getFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipropertyeffect/#getTo--), a [getBy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipropertyeffect/#getBy--) jsou řetězce interpretované pomocí [getValueType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipropertyeffect/#getValueType--) a [getCalcMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Zvolte koncové hodnoty nebo relativní posun místo náhodného nastavení všech tří parametrů.

Zde je vybrán atribut neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje plynulou změnu mezi těmito hodnotami. Při úpravě příkladu na jiný atribut zvolte typ hodnoty a koncové hodnoty odpovídající danému atributu.

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

Použijte [createSetEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) k přiřazení viditelnosti pomocí [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iseteffect/#getTo--). Chování typu set neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. Obdélník je již v této minimální prezentaci viditelný, takže přiřazení nemusí samo o sobě vytvářet jasnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také určuje, kdy se tvar skryje nebo zobrazí.

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

Použijte [createCommandEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) a nakonfigurujte [getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommandeffect/#getCommandString--), a [getShapeTarget](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Umístěte WAV nahrávku pojmenovanou `sample.wav` do pracovního adresáře. Tento příklad ji vloží pomocí [addAudioFrameEmbedded](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) a připojí příkaz přehrát k audio rámci.

Audio rámec je jak cílem efektu, tak cílem příkazu. Toto propojuje požadavek na přehrání s vloženou nahrávkou; samotný řetězec příkazu neidentifikuje, který mediální objekt má být ovládán. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

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

Uložení uloží příkaz do `command.pptx`; nahrávka se neprohraje. Přehrání vyžaduje přehrávač prezentací, který podporuje příkaz a jeho mediální cíl.

## **Správa kolekce chování**

[IBehaviorCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), a [removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před rotaci a odstraní rotaci. Odstranění a opětovné vložení stejného objektu změní jeho uloženou pozici, aniž by se vytvořila kopie.

Pořadí úprav mění kolekci z rotace‑měřítka na měřítko‑rotaci a nakonec jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstranění používá nový index rotace po přeuspořádání. Závěrečné výčty potvrzují, které chování bude uloženo.

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

Výstup je `ScaleEffect`: zůstává jen měřítko. Pořadí v kolekci samo o sobě neplánuje chování za sebou. Vyprázdněte kolekci jen při nahrazování všech jejích operací.

## **Konfigurace časování chování**

[IBehavior.getTiming](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehavior/#getTiming--) zveřejňuje [ITiming](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/), nezávisle na [IEffect.getTiming](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getTiming--). Časování efektu plánuje obalující efekt; časování chování popisuje operaci uvnitř něj.

### **Nastavení doby trvání, zpoždění, opakování a zrychlení**

Otevřete `rotation.pptx` a nastavte dobu trvání ([getDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getDuration--)) a zpoždění spouštěče ([getTriggerDelayTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) v sekundách, pak nakonfigurujte počet opakování pomocí [setRepeatCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getAccelerate--) a [getDecelerate](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getDecelerate--) jsou zlomky doby trvání; jejich součet udržujte nejvýše na 1.

Vstupní soubor je ten, který byl vytvořen v příkladu rotace, kde je první chování známé jako rotace. Tento příklad mění jen časování tohoto chování; úhel 90 stupňů zůstává nedotčen. Udržení úhlu a časování odděleně usnadňuje úpravu tempa, aniž byste museli znovu stavět animaci.

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

Chování používá dvousekundovou dobu trvání, půlsekundové zpoždění a opakování 3. Prvních a posledních 20 % doby trvání se používá pro zrychlení a zpomalení.

Jiné politiky opakování zahrnují [getRepeatDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), a [getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); zvolte jednu politiku namísto povolení všech najednou. [getAutoReverse](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getAutoReverse--) přehraje animaci zpětně po dopředu. Zrychlení a zpomalení se vztahují na plynulé změny, ne na diskrétní přiřazení nebo příkazy.

## **Sestavení dráhy pohybu**

Použijte [createMotionEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) k vytvoření pohybu. Jeho [getFrom](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#getTo--), a [getBy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#getBy--) popisují souřadnice nebo offsety založené na procentech. Pro editovatelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/motionpath/) a přiřaďte ji pomocí [IMotionEffect.setPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotionpath/) ukládá příkazy dráhy.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/motioncommandpathtype/) vybírá operaci:

| Příkaz | Body | Význam |
| --- | --- | --- |
| MoveTo | One | Nastaví počáteční pozici. |
| LineTo | One | Pohne se podél přímého úseku do koncového bodu. |
| CurveTo | Three | Následuje kubickou křivku definovanou dvěma řídícími body a koncovým bodem. |
| CloseLoop | None | Vrátí se na počáteční pozici. |
| End | None | Dokončí dráhu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/motionpathpointstype/) popisuje charakteristiky úpravy bodů, např. rohové nebo hladké body. Nenahrazuje typ příkazu. Použijte typ křivkového bodu pro příklad křivky níže a rohový typ pro přímé segmenty.

Souřadnice dráhy jsou normalizovány na rozměry snímku: posun X = 0.25 představuje čtvrtinu šířky snímku, ne 0.25 bodů. Kladné Y směřuje dolů. Absolutní příkazy určují pozice v souřadnicovém systému dráhy; relativní příkazy určují offsety od aktuální pozice. To je oddělené od [getOrigin](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#getOrigin--), který vybírá referenční rámec dráhy, a [getPathEditMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioneffect/#getPathEditMode--), který řídí, jak se dráha pohybuje při přesunu tvaru.

### **Vytvoření přímé dráhy**

Vytvořte chování pohybu se startovacím bodem, jedním přímým segmentem a koncovým příkazem. [IMotionPath.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Startovací příkaz stanoví (0, 0) a čára končí v (0.25, 0), čímž dráze dodá vodorovný posun o čtvrtinu šířky snímku. Koncový příkaz nemá žádné souřadnicové body. Po přiřazení dráhy se přidáním chování pohybu k efektu propojí tato trasa s obdélníkem.

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

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy dráhy. Následující příklady úprav souborů používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty dráhy popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přičte (0.1, 0.1) k aktuální pozici, tedy (0.2, 0).

Obě dráhy začínají ve stejné pozici. Pro relativní čáru přidejte její X a Y offsety k aktuální pozici, abyste získali koncový bod; pro absolutní čáru přečtěte koncový bod přímo. Přepnutí příznaku bez konverze souřadnic by popisovalo jinou trasu.

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

Přiřaďte libovolnou dráhu k chování pohybu a použijte ji v prezentaci. Poslední Boolean argument určuje, zda jsou souřadnice pro daný příkaz relativní.

### **Nahrazení čáry křivkou**

Otevřete `motion.pptx` a nahraďte jeho čárový příkaz kubickou křivkou. Nejprve zadejte dva řídicí body, pak koncový bod.

Startovací pozice je určena předchozím příkazem. První dva body utvářejí křivku, třetí je její cíl; nejde o tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodu a pole bodů najednou udržuje segment v souladu s novou geometrií.

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

Dráha v `curve.pptx` stále má tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené dráhy**

Každý [IMotionCmdPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioncmdpath/) zveřejňuje [getPoints](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioncmdpath/#getPointsType--), a [isRelative](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotioncmdpath/#isRelative--). Následující příklady používají známou třípříkazovou dráhu v `motion.pptx`. Pro libovolný vstup nejprve najděte požadovaný efekt a zkontrolujte typy příkazů a počet bodů před úpravou podle indexu.

### **Čtení příkazů a souřadnic**

Přečtěte dráhu bez změny. Příkazy konce a uzavření smyčky nepotřebují body, takže připravte možnost nulového pole bodů.

Výstup spojuje každý číselný typ příkazu s jeho příznakem relativních souřadnic před vyjmenováním bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou dráhy. Křivka by vypsala tři body, zatímco přímá čára v tomto souboru vypíše jen jeden.

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

Výpis obsahuje startovní bod, absolutní čáru končící v (0.25, 0) a příkaz konce.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů čáry, aby se posunul její koncový bod.

Ve vstupním souboru je index 0 startovací příkaz a index 1 čára. Nahrazení jediného bodu čáry změní její cíl bez změny typu příkazu, časování nebo pozice v kolekci. Protože příkaz používá absolutní souřadnice, nový pár určuje pozici, nikoli přidaný offset.

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

Čára v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává nezměněn.

### **Nahrazení segmentu**

Použijte [insert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) a [removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imotionpath/#removeAt-int-) k nahrazení čáry v `motion.pptx`. Vložení posune starou čáru na index 2.

Toto ukazuje nahrazení objektu příkazu místo úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje startovací příkaz, novou čáru, starou čáru a koncový příkaz. Odstraněním indexu 2 se stará čára zahodí a místo ní zůstane nová trasa.

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

Uložená dráha má stále tři příkazy, přičemž nová čára končí v (0.2, 0.1) a poslední je příkaz konce.

## **Úprava a ověření existujícího chování**

Když není známý index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [IRotationEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou rotace. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže porovnání kontroluje přetrvávající data, nikoli hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

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

Výstup je `Rotation preserved: true`. Použijte stejný vzor kontroly typu i pro ostatní chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, časování a příkazy dráhy. Použijte číselnou toleranci pro hodnoty s plovoucí desetinnou čárkou. Pro prezentaci s neznámým rozložením animací viz [Read Shape Animations](/slides/cs/java/shape-animation/#read-shape-animations) pro procházení hlavních i interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [IBehaviorCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehaviorcollection/) je uložené pořadí operací efektu. Nejedná se o playlist, ve kterém každé chování automaticky čeká na předchozí. Časování a obalující efekt určují plánování. Chování se může překrývat a operace na stejné vlastnosti mohou interagovat přes [getAdditive](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehavior/#getAdditive--) a [getAccumulate](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibehavior/#getAccumulate--). Nepoužívejte jen přeuspořádání kolekce k naplánování „přesun, pak otáčení“; použijte explicitní časování nebo samostatné efekty, jak je popsáno v [Shape Animation](/slides/cs/java/shape-animation/).

[IEffect.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getType--) a [IEffect.getSubtype](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getSubtype--) popisují jeho předvolbu. Nejsou úplným popisem upraveného stromu chování. Vyberte předvolbu a podtyp před vlastním přizpůsobením chování: změna předvolby může znovu vytvořit kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného efektu Spin na Fade může nahradit jeho rotaci chováním set a filter. Po změně předvolby nebo podtypu znovu zkontrolujte kolekci. Vyprázdnění předvolených chování může také odstranit viditelnost nebo inicializační operace, které předvolba potřebuje. Příklady záměrně používají viditelné tvary a nahrazují chování; nerekonstruují každou implementaci předvolby.

## **Kompatibilita formátů**

Uchování stromu chování nezaručuje identické přehrání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a renderovaný výstup odděleně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Používejte jako primární formát pro tyto příklady. Otevřete jej znovu a ověřte editovatelný strom chování, pak zkontrolujte přehrání v požadované verzi PowerPointu. |
| PPT | Starší binární reprezentace se může lišit od PPTX. Otestujte samostatný cyklus uložení‑otevření a přehrání; nevyvozujte podporu pro každou vlastní kombinaci jen z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické snímky | Obsahují statický obrázek snímku, ne přehratelnou časovou osu chování ani zaručený finální animační snímek. |
| [HTML5](/slides/cs/java/export-to-html5/) | Může přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvaru. Otestujte vlastní kombinace v prohlížeči. |
| [Animated GIF](/slides/cs/java/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani interakci spouštěnou kliknutím. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/java/convert-powerpoint-to-video/) | Vykreslí animační snímky a zakóduje je jako video. Podpora je omezena na [supported animations and effects](/slides/cs/java/convert-powerpoint-to-video/#supported-animations-and-effects) renderera; příkazy a interaktivní události se nepřevádějí na editovatelnou časovou osu. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování ještě před tím, než něco přidám?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prozkoumejte je, než se rozhodnete rozšířit předvolbu nebo nahradit její chování.

**Způsobí přesunutí chování na začátek, že se přehraje jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje časování. Zkontrolujte zpoždění, dobu trvání a interakce mezi operacemi na stejné vlastnosti.

**Proč má příkaz End žádné body?**

Označuje konec dráhy a nepotřebuje souřadnice. Při prohlížení dráhy načtené ze souboru kontrolujte, zda není pole bodů null.

**Je úspěšná zpětná cesta dostačující k potvrzení přehrání?**

Ne. Otevření potvrzuje zachování vlastností, které jste zkontrolovali. Otestujte přehrávač prezentací nebo animovaný export samostatně, abyste potvrdili jeho vizuální chování.