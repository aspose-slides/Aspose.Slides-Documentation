---
title: Vytvoření a úprava vlastních animačních chování v PHP
linktitle: Vlastní animace
type: docs
weight: 151
url: /cs/php-java/custom-animation/
keywords:
- vlastní animace
- chování animace
- dráha pohybu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte, prohlédněte a upravte vlastní animační chování a editovatelnou dráhu pohybu v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Vlastní animační chování vám umožňuje řídit jednotlivé operace v rámci animačního efektu, jako je změna barvy, otáčení objektu nebo sledování upravitelné dráhy pohybu. Tento návod ukazuje, jak vytvářet a kombinovat chování, konfigurovat jejich načasování, prohlížet a upravovat existující animace a ověřit, že jejich vlastnosti přežijí uložení a opětovné otevření prezentace.

Pro předdefinované efekty a spouštěče kliknutí viz [Animace tvaru](/slides/cs/php-java/shape-animation/).

## **Pochopte model animace**

Animace je organizována jako **Timeline → Sequence → Effect → Behaviors**:

- Každý snímek má časovou osu obsahující hlavní sekvenci a interaktivní sekvence.
- Sekvence ([Sequence](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/)) obsahuje efekty, které mohou cílit na různé tvary.
- Efekt ([Effect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/)) identifikuje cílový tvar, předvolbu, podtyp a načasování efektu.
- Kolekce vrácená metodou [Effect::getBehaviors](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getbehaviors/) obsahuje operace implementující efekt: změna barvy, pohyb, otáčení, nastavení vlastnosti a další.

## **Vytvořte jednotlivá chování**

Vyvolejte [Sequence::addEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/addeffect/) pro vytvoření efektu a přístup ke kolekci [getBehaviors](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getbehaviors/). Předvolba může tuto kolekci naplnit automaticky. Uchovejte její operace při rozšiřování předvolby nebo použijte [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/clear/) při záměrném nahrazení.

[BehaviorFactory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/) vytváří osm typů chování ilustrovaných níže. Pohyb je popsán v sekci [Vytvoření dráhy pohybu](#vytvoření-dráhy-pohybu). Každý úryvek obsahuje potřebné importy a předpokládá, že byl načten PHP/Java Bridge a knihovna Aspose.Slides pro PHP. Příklady pozdější úpravy uvádějí, který výstupní soubor používají.

### **Otáčení**

Použijte [createRotationEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createrotationeffect/) pro vytvoření otáčení. [getBy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/rotationeffect/getby/) určuje relativní úhel ve stupních; [getFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/rotationeffect/getfrom/) a [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/rotationeffect/getto/) určují koncové body.

Příklad začíná efektem Spin, nahradí jeho přednastavené operace jedním otáčecím chováním a přiřadí mu dvousekundovou dobu trvání. Relativní úhel 90° vyjadřuje čtvrt otáčky od výchozí orientace tvaru, takže není potřeba explicitně zadávat výchozí úhel.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` obsahuje jeden tvar a jedno otáčecí chování. Kolekce, načasování a příklady úprav otáčení níže používají tento soubor.

### **Měřítko**

Použijte [createScaleEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createscaleeffect/) s procenty X/Y: [getFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/scaleeffect/getfrom/) a [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/scaleeffect/getto/) popisují počáteční a koncovou velikost, zatímco [getBy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/scaleeffect/getby/) popisuje relativní změnu. Zde 100 % znamená původní velikost.

Příklad zvětší oba rozměry z 100 % na 125 % během dvou sekund. Použití stejných horizontálních i vertikálních procent zachová proporce tvaru; různé procenta by natáhly jeden rozměr více než druhý.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Barva**

Použijte [createColorEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createcoloreffect/) pro změnu výplně z modré na oranžovou. [getFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/coloreffect/getfrom/) a [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/coloreffect/getto/) jsou barvy; [getBy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/coloreffect/getby/) je posun barvy. [BehaviorPropertyCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorpropertycollection/) identifikuje atribut, který je animován.

Výplň tvaru je inicializována na modrou, což odpovídá počáteční barvě animace. Výběr atributu výplně říká chování, kterou část tvaru má změnit; samotné koncové barvy neidentifikují tento atribut. Uložený efekt popisuje dvousekundový přechod na oranžovou.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filtr**

Použijte [createFilterEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createfiltereffect/) pro výběr stírání. [getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filtereffect/getsubtype/) a [getReveal](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filtereffect/getreveal/) určují filtr, směr a zda má tvar odhalit nebo skrýt.

Tento příklad konfiguruje dvousekundové odhalení tvaru pomocí podtypu pravého směru. Nastavení filtru patří k chování uvnitř efektu, a proto je konfigurováno po odstranění původních operací předvolby.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Vlastnost**

Použijte [createPropertyEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) pro animaci neprůhlednosti. [getFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/propertyeffect/getto/) a [getBy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/propertyeffect/getby/) jsou řetězce interpretované pomocí [getValueType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/propertyeffect/getvaluetype/) a [getCalcMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/propertyeffect/getcalcmode/). Zvolte koncové hodnoty nebo relativní posun místo nastavení všech tří najednou.

Zde je vybraný atribut neprůhlednost a číselné řetězce představují změnu z 25 % neprůhlednosti na plnou neprůhlednost. Lineární interpolace popisuje plynulou změnu mezi těmito hodnotami. Při úpravě tohoto příkladu na jiný atribut zvolte typ hodnoty a koncové hodnoty vhodné pro daný atribut.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Nastavení**

Použijte [createSetEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createseteffect/) pro přiřazení viditelnosti pomocí [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/seteffect/getto/). Chování typu set neinterpoluje mezi koncovými body.

Příklad vybere atribut viditelnosti a při spuštění chování přiřadí řetězec `visible`. Obdélník je v této minimální prezentaci již viditelný, takže přiřazení nemusí samostatně vytvořit zřetelnou vizuální změnu. Taková operace je užitečná jako součást většího efektu, který také řídí, kdy se tvar skryje nebo zobrazí.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Příkaz**

Použijte [createCommandEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createcommandeffect/) a nakonfigurujte [getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commandeffect/getcommandstring/) a [getShapeTarget](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commandeffect/getshapetarget/). Umístěte zvukový záznam WAV pojmenovaný `sample.wav` do pracovního adresáře. Tento příklad jej vloží pomocí [addAudioFrameEmbedded](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addaudioframeembedded/) a připojí příkaz přehrání k audio‑rámci.

Audio‑rámec je zároveň cílem efektu i cílem příkazu. Tímto se propojí požadavek na přehrání se zabudovaným záznamem; samotný řetězec příkazu neurčuje, který mediální objekt ovládat. Efekt je nastaven tak, aby se spustil kliknutím během prezentace.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Uložení uloží příkaz do `command.pptx`; nepřehraje záznam. Přehrávání vyžaduje přehrávač prezentací, který podporuje příkaz i jeho mediální cíl.

## **Správa kolekce chování**

[BehaviorCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/) podporuje [add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/remove/), a [removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/removeat/). Tento příklad otevře `rotation.pptx`, přidá měřítko, přesune jej před otáčení a odstraní otáčení. Odstranění a opětovné vložení stejného objektu změní jeho uloženou pozici, aniž by došlo k vytvoření kopie.

Postup úprav mění kolekci z otáčení–měřítka na měřítko–otáčení a nakonec jen na měřítko. Indexy odkazují na aktuální kolekci, takže odstraňování používá nový index otáčení po přeuspořádání. Konečné vyjmenování potvrdí, které chování bude uloženo.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výstup je `ScaleEffect`: zůstane jen měřítko. Pořadí v kolekci samo o sobě neplánuje chování jedno po druhém. Vyčistěte kolekci pouze při úplném nahrazení všech jejích operací.

## **Konfigurace načasování chování**

Chování má své vlastní [Timing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/), nezávislé na načasování vráceném metodou [Effect::getTiming](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/gettiming/). Načasování efektu řídí obalující efekt; načasování chování popisuje operaci uvnitř něj.

### **Nastavení doby trvání, zpoždění, opakování a zrychlení**

Otevřete `rotation.pptx` a nastavte dobu trvání ([getDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getduration/)) a zpoždění spouštěče ([getTriggerDelayTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/gettriggerdelaytime/)) v sekundách, poté nastavte počet opakování pomocí [setRepeatCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getaccelerate/) a [getDecelerate](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getdecelerate/) jsou zlomky doby trvání; jejich součet udržujte nejvýše na 1.

Vstupní soubor je ten vytvořený v příkladu otáčení, kde je první chování známé jako otáčení. Tento příklad mění jen načasování tohoto chování; jeho úhel 90° zůstává nedotčen. Udržování úhlu a načasování odděleně usnadňuje úpravu tempa bez nutnosti přestavovat animaci.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Chování používá dvousekundovou dobu trvání, půlsekundové zpoždění a počet opakování 3. Prvních a posledních 20 % jeho doby trvání je vyhrazeno pro zrychlení a zpomalení.

Další politiky opakování zahrnují [getRepeatDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatuntilendslide/), a [getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getrepeatuntilnextclick/); zvolte jednu politiku místo povolení všech najednou. [getAutoReverse](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/getautoreverse/) přehraje animaci pozpátku po dopředném průchodu. Zrychlení a zpomalení se vztahují na plynulé změny, ne na diskrétní přiřazení nebo příkazy.

## **Vytvoření dráhy pohybu**

Použijte [createMotionEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorfactory/createmotioneffect/) pro vytvoření pohybu. Jeho [getFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/getto/), a [getBy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/getby/) popisují koordináty nebo offsety založené na procentech. Pro upravitelnou trasu vytvořte [MotionPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpath/) a přiřaďte ji pomocí [MotionEffect::setPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpath/) ukládá příkazy cesty.

[MotionCommandPathType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncommandpathtype/) vybírá operaci:

| Příkaz | Body | Význam |
| --- | --- | --- |
| MoveTo | One | Nastaví počáteční pozici. |
| LineTo | One | Pohne se po přímém úseku k jeho koncovému bodu. |
| CurveTo | Three | Následuje kubickou křivku definovanou dvěma řídícími body a koncovým bodem. |
| CloseLoop | None | Vrátí se na počáteční pozici. |
| End | None | Ukončí cestu. |

[MotionPathPointsType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpathpointstype/) popisuje charakteristiky úprav bodů, např. roh nebo hladký bod. Nepřepisuje typ příkazu. Použijte typ bodu křivky pro příklad křivky níže a typ rohového bodu pro přímé segmenty.

Souřadnice cesty jsou normalizovány na rozměry snímku: posun X = 0.25 představuje čtvrtinu šířky snímku, nikoli 0.25 pt. Kladné Y běží dolů. Absolutní příkazy určují pozice v souřadnicovém systému cesty; relativní příkazy určují offsety od aktuální pozice. To je oddělené od [getOrigin](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/getorigin/), který vybírá referenční rámec cesty, a [getPathEditMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioneffect/getpatheditmode/), který řídí, jak se cesta pohybuje při pohybu tvaru.

### **Vytvoření přímé cesty**

Vytvořte chování pohybu s počátečním bodem, jedním přímým segmentem a koncovým příkazem. [MotionPath::add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpath/add/) přijímá typ příkazu, jeho body, typ bodu a příznak relativních souřadnic.

Počáteční příkaz stanoví (0, 0) a čára končí v (0.25, 0), což dává trase horizontální posun o čtvrtinu šířky snímku. Koncový příkaz nemá žádné souřadnicové body. Jakmile je cesta přiřazena, přidání chování pohybu k efektu propojí tuto trasu s obdélníkem.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` obsahuje jedno chování pohybu se třemi příkazy cesty. Následující příklady úprav souboru používají tuto známou strukturu.

### **Porovnání absolutních a relativních souřadnic**

Tyto dva objekty cesty popisují stejnou trasu. Absolutní příkaz končí v (0.3, 0.1); relativní příkaz přidá (0.1, 0.1) k aktuální pozici, (0.2, 0).

Obě cesty začínají na stejné pozici. Pro relativní čáru přidejte její X a Y offsety k aktuální pozici a získáte koncový bod; pro absolutní čáru přečtěte koncový bod přímo. Změna příznaku bez konverze souřadnic by popisovala jinou trasu.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Přiřaďte libovolnou cestu chování pohybu a použijte ji v prezentaci. Poslední boolovský parametr vybírá relativní souřadnice pro daný příkaz.

### **Nahrazení čáry křivkou**

Otevřete `motion.pptx` a nahraďte její příkaz čáry kubickou křivkou. Nejprve zadejte dva řídící body, poté koncový bod.

Počáteční pozice je určena předchozím příkazem. První dva body tvarují křivku, zatímco třetí je její cíl; nejedná se o tři po sobě jdoucí cíle. Aktualizace typu příkazu, typu úpravy bodu a pole bodů najednou udržuje segment v souladu s novou geometrií.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cesta v `curve.pptx` stále obsahuje tři příkazy; její prostřední příkaz nyní definuje křivku.

## **Prohlížení a úprava uložené cesty**

Každý [MotionCmdPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncmdpath/) zveřejňuje [getPoints](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncmdpath/getpointstype/), a [isRelative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motioncmdpath/isrelative/). Následující příklady používají známou třípříkazovou cestu v `motion.pptx`. Pro libovolný vstup najděte požadovaný efekt a před úpravou indexu zkontrolujte typy příkazů a počet bodů.

### **Čtení příkazů a souřadnic**

Přečtěte cestu bez změny. Příkazy End a CloseLoop nevyžadují body, proto umožněte nulové pole bodů.

Výstup spáruje každé číselné ID příkazu s příznakem relativních souřadnic před výpisem jeho bodů. To vám umožní rozlišit koncový bod od offsetu před úpravou cesty. Křivka by vypsala tři body, zatímco přímá čára v tomto souboru pouze jeden.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Výpis obsahuje počáteční bod, absolutní čáru končící v (0.25, 0) a příkaz End.

### **Změna koncového bodu**

Otevřete `motion.pptx` a nahraďte pole bodů čáry, aby se změnil její koncový bod.

Ve vstupním souboru je index 0 počáteční příkaz a index 1 čára. Nahrazením jediného bodu čáry změníte její cíl, aniž byste měnili typ příkazu, načasování nebo pozici v kolekci. Protože příkaz používá absolutní souřadnice, nový pár udává pozici, nikoli přidaný offset.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Čára v `motion-endpoint.pptx` končí v (0.4, 0.1); původní soubor zůstává nezměněn.

### **Nahrazení segmentu**

Použijte [insert](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpath/insert/) a [removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/motionpath/removeat/) pro nahrazení čáry v `motion.pptx`. Vkládání posune starou čáru na index 2.

Toto demonstruje nahrazení objektu příkazu místo úpravy jeho existujících souřadnic. Po vložení kolekce dočasně obsahuje počáteční příkaz, novou čáru, starou čáru a příkaz End. Odstraněním indexu 2 se stará čára zahodí a nová trasa zůstane.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uložená cesta stále má tři příkazy, nová čára končí v (0.2, 0.1) a poslední příkaz je End.

## **Úprava a ověření existujícího chování**

Když není známý index chování, vyberte jej podle typu. Tento příklad otevře `rotation.pptx`, najde jeho [RotationEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/rotationeffect/), změní úhel a po opětovném otevření zkontroluje uloženou hodnotu.

Kontrola typu umožňuje smyčce přeskočit chování, která nejsou otáčením. Druhé načtení načte uložený soubor do samostatného objektu prezentace, takže srovnání kontroluje trvalá data, nikoli hodnotu stále drženou v paměti. Tento příklad stále předpokládá, že známý efekt je první v hlavní sekvenci; výběr chování podle typu nevyhledá správný efekt v libovolné prezentaci.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Výstup je `Rotation preserved: true`. Použijte stejný vzor kontroly typu i pro další chování. Pro úplnou kontrolu zachování porovnejte cílový tvar, efekt, typy a pořadí chování, načasování a příkazy cesty. Použijte číselnou toleranci pro hodnoty s plovoucí řádovou čárkou. Pro prezentaci s neznámým rozvržením animací viz [Read Shape Animations](/slides/cs/php-java/shape-animation/#read-shape-animations) pro procházení hlavních i interaktivních sekvencí.

## **Pořadí chování, předvolby a přehrávání**

Pořadí v [BehaviorCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behaviorcollection/) je uložené pořadí operací efektu. Není to playlist, ve kterém každé chování automaticky čeká na předchozí. Načasování a obalující efekt určují plánování. Chování se mohou překrývat a operace na stejné vlastnosti mohou spolupracovat prostřednictvím nastavení [additive](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behavioradditivetype/) a [accumulation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/behavioraccumulatetype/). Nepoužívejte pouhé přeuspořádání kolekce k naplánování „přesun, pak otáčení“; použijte explicitní načasování nebo samostatné efekty, jak je popsáno v [Animace tvaru](/slides/cs/php-java/shape-animation/).

Metoda [getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/gettype/) a [getSubtype](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/getsubtype/) efektu popisují jeho předvolbu. Nejsou kompletním popisem upraveného stromu chování. Vyberte předvolbu a podtyp před přizpůsobením chování: změna předvolby může přestavět kolekci a zahodit vaše vlastní operace. Například změna přizpůsobeného efektu Spin na Fade může nahradit otáčecí chování chováním set a filter. Po změně předvolby nebo podtypu kolekci znovu prohlédněte. Vymazání přednastavených chování může také odstranit operace viditelnosti nebo inicializace, které předvolba potřebuje. Příklady úmyslně používají viditelné tvary a nahrazují chování; nepřestavují úplnou implementaci každé předvolby.

## **Kompatibilita formátů**

Uchovaný strom chování nezaručuje identické přehrávání ve všech prohlížečích nebo exportních rendererech. Zkontrolujte uložená data a renderovaný výstup odděleně.

| Formát nebo výstup | Co ověřit |
| --- | --- |
| PPTX | Použijte jako primární formát pro tyto příklady. Otevřete jej znovu pro ověření editovatelného stromu chování, poté zkontrolujte přehrávání ve požadované verzi PowerPointu. |
| PPT | Dědictví binárního formátu může být odlišné od PPTX. Otestujte samostatný cyklus ulož‑a‑znovu‑otevři a přehrávání; nevyvozuje se podpora pro každou vlastní kombinaci z úspěšného výstupu PPTX. |
| PDF, PNG, JPEG a další statické obrázky snímků | Obsahují statický snímek, ne přehratelnou časovou osu chování ani garantovaný finální animační snímek. |
| [HTML5](/slides/cs/php-java/export-to-html5/) | Může přehrávat podporované animace, pokud je v možnostech exportu povolena animace tvaru. Otestujte vlastní kombinace v prohlížeči. |
| [Animovaný GIF](/slides/cs/php-java/convert-powerpoint-to-animated-gif/) | Ukládá vykreslené snímky, ne editovatelné chování ani interaktivní události na kliknutí. Zkontrolujte skutečný vykreslený pohyb. |
| [Video](/slides/cs/php-java/convert-powerpoint-to-video/) | Vykreslí animační snímky a zakóduje je jako video. Podpora je omezena na [podporované animace a efekty](/slides/cs/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) rendereru; příkazy a interaktivní události se nestanou editovatelnou časovou osou. |

## **Často kladené otázky**

**Proč můj efekt obsahuje chování před tím, než něco přidám?**

Vytvoření předdefinovaného efektu může vytvořit jeho podkladové operace. Prohlédněte je před tím, než se rozhodnete, zda rozšířit předvolbu nebo nahradit její chování.

**Způsobí přesunutí chování na začátek, že se přehraje jako první?**

Ne nutně. Pořadí v kolekci nenahrazuje načasování. Zkontrolujte zpoždění, dobu trvání a interakce mezi operacemi na stejné vlastnosti.

**Proč má příkaz End žádné body?**

Označuje konec cesty a nevyžaduje souřadnice. Při prohlížení cesty načtené ze souboru kontrolujte, zda pole bodů není null.

**Je úspěšná round‑trip dostatečná k potvrzení přehrávání?**

Ne. Opětovné otevření potvrzuje zachování vlastností, které jste zkontrolovali. Přehrajte prezentaci nebo animovaný export zvlášť, abyste potvrdili vizuální chování.