---
title: Egyéni animációs viselkedések létrehozása és módosítása PHP-ben
linktitle: Egyéni animáció
type: docs
weight: 151
url: /hu/php-java/custom-animation/
keywords:
- egyéni animáció
- animációs viselkedés
- mozgásútvonal
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Egyéni animációs viselkedések és szerkeszthető mozgásútvonalak létrehozása, ellenőrzése és módosítása PowerPoint előadásokban az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az egyéni animációs viselkedések lehetővé teszik, hogy az animációs effekt egyes műveleteit irányítsa, például egy szín módosítását, egy alakzat elforgatását vagy egy szerkeszthető mozgási útvonal követését. Ez az útmutató bemutatja, hogyan hozhat létre és kombinálhat viselkedéseket, hogyan konfigurálhatja azok időzítését, hogyan vizsgálhatja és módosíthatja a meglévő animációkat, valamint hogyan ellenőrizheti, hogy azok tulajdonságai megmaradnak-e az előadás mentése és újranyitása után.

Előre definiált effektek és kattintási indítók esetén lásd a [Alakzat animáció](/slides/hu/php-java/shape-animation/) oldalt.

## **Ismerje meg az animációs modellt**

Az animáció a **Idővonal → Sorozat → Effekt → Viselkedések** struktúrába van szervezve:

- Minden dia egy idővonalat tartalmaz, amely a fő sorozatot és az interaktív sorozatokat tartalmazza.
- A [Sequence](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/) effektusokat tartalmaz, amelyek különböző alakzatokat célozhatnak.
- Egy [Effect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/) meghatározza a célt alakzatot, az előbeállítást, az al-típust és az effekt időzítését.
- Az [Effect::getBehaviors](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getbehaviors/) által visszaadott gyűjtemény tartalmazza az effektus végrehajtásához szükséges műveleteket: szín módosítása, mozgatás, forgatás, tulajdonság beállítása stb.

## **Egyéni viselkedések létrehozása**

A [Sequence::addEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/addeffect/) hívásával hozhat létre egy effektust, és hozzáférhet a [getBehaviors](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getbehaviors/) gyűjteményhez. Egy előbeállítás automatikusan feltöltheti ezt a gyűjteményt. Tartsa meg annak műveleteit a bővítés során, vagy használja a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/clear/) módszert, ha szándékosan cserélni szeretné őket.

[BehaviorFactory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/) nyolc viselkedéstípust hoz létre, amint az alább illusztrálva van. A mozgás a [Mozgásútvonal felépítése](#build-a-motion-path) részben kerül bemutatásra. Minden kódrészlet tartalmazza az importálásokat és feltételezi, hogy a PHP/Java Bridge és az Aspose.Slides PHP könyvtár már be van töltve. A későbbi szerkesztési példák feltüntetik, melyik kimeneti fájlt használják.

### **Forgatás**

A [createRotationEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createrotationeffect/) használatával hozhat létre forgatást. A [getBy](https://reference.aspose.com/slides/hu/php-java/aspose.slides/rotationeffect/getby/) relatív szöget ad meg fokban; a [getFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/rotationeffect/getfrom/) és a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/rotationeffect/getto/) a végpontokat határozzák meg.

A példa egy Spin effektussal kezd, lecseréli annak előbeállított műveleteit egy forgatási viselkedésre, és a műveletnek két másodperces időtartamot ad. A 90 fokos relatív szög a alakzat kiinduló tájolásának negyedfordulását jelenti, így nincs szükség külön kezdő szög megadására.

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

`rotation.pptx` egy alakzatot és egy forgatási viselkedést tartalmaz. Az alábbi gyűjtemény-, időzítés- és forgatás-szerkesztési példák ezt a fájlt használják.

### **Méretezés**

A [createScaleEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createscaleeffect/) X/Y százalékokkal használja: a [getFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/scaleeffect/getfrom/) és a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/scaleeffect/getto/) a kiinduló és végső méretet írják le, míg a [getBy](https://reference.aspose.com/slides/hu/php-java/aspose.slides/scaleeffect/getby/) egy relatív változást határoz meg. Itt a 100 az eredeti méretet jelenti.

A példa a két dimenziót 100%-ról 125%-ra növeli két másodperc alatt. Egyenlő vízszintes és függőleges százalékok megőrzik az alakzat arányait; eltérő százalékok egyik dimenziót erősebben nyújtják.

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

### **Szín**

A [createColorEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createcoloreffect/) használatával változtathatja a kitöltést kékről narancssárgára. A [getFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/coloreffect/getfrom/) és a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/coloreffect/getto/) színek; a [getBy](https://reference.aspose.com/slides/hu/php-java/aspose.slides/coloreffect/getby/) egy szín eltolást jelent. A viselkedés [BehaviorPropertyCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorpropertycollection/) határozza meg az animált attribútumot.

Az alakzat szilárd kitöltése kékre van inicializálva, ami egyezik az animáció kezdőszínével. A kitöltés-szín attribútum kiválasztása megmondja a viselkedésnek, hogy az alakzat mely részét kell módosítani; a szín végpontok önmagukban nem azonosítják az attribútumot. A mentett effektus egy kétszekundumos átmenetet ír le a narancssárgára.

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

### **Szűrő**

A [createFilterEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createfiltereffect/) használatával választhat ki egy áttörlést. A [getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filtereffect/gettype/), a [getSubtype](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filtereffect/getsubtype/), és a [getReveal](https://reference.aspose.com/slides/hu/php-java/aspose.slides/filtereffect/getreveal/) határozzák meg a szűrőt, az irányt és hogy az alakzatot láthatóvá vagy rejtetté tegyük-e.

Ez a példa egy kétszekundumos áttörlést állít be, amely a formát a jobb irányú al-típussal jeleníti meg. A szűrő beállításai az effektuson belüli viselkedéshez tartoznak, ezért az eredeti előbeállított műveletek eltávolítása után konfigurálják őket.

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

### **Tulajdonság**

A [createPropertyEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) segítségével animálhatja az átlátszatlanságot. A [getFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/propertyeffect/getfrom/), a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/propertyeffect/getto/), és a [getBy](https://reference.aspose.com/slides/hu/php-java/aspose.slides/propertyeffect/getby/) karakterláncok, amelyeket a [getValueType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/propertyeffect/getvaluetype/) és a [getCalcMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/propertyeffect/getcalcmode/) értelmez. Válasszon végpontokat vagy egy relatív eltolást a három egyidejű beállítása helyett.

Itt a kiválasztott attribútum az átlátszatlanság, és a numerikus karakterláncok egy 25%-os átlátszatlanságról teljes átlátszatlanságra való változást jelentenek. A lineáris interpoláció fokozatos változást ír le ezek között az értékek között. Ha ezt a példát más attribútumra alkalmazza, válasszon megfelelő értéktípust és végpont értékeket az adott attribútumhoz.

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

### **Beállítás**

A [createSetEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createseteffect/) használatával állíthatja be a láthatóságot a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/seteffect/getto/) segítségével. A set viselkedés nem interpolál a végpontok között.

A példa a láthatóság attribútumát választja ki, és a viselkedés futásakor a `visible` karakterláncot rendeli hozzá. A téglalap már látható ebben a minimális előadásban, így az értékadás önmagában nem biztos, hogy nyilvánvaló vizuális változást eredményez. Ilyen művelet hasznos lehet egy nagyobb effektus részeként, amely meghatározza, hogy az alakzat mikor legyen rejtett vagy látható.

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

### **Parancs**

A [createCommandEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createcommandeffect/) használatával és a [getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commandeffect/gettype/), a [getCommandString](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commandeffect/getcommandstring/), valamint a [getShapeTarget](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commandeffect/getshapetarget/) konfigurálásával. Helyezzen egy `sample.wav` nevű WAV felvételt a munkakönyvtárba. Ez a példa beágyazza a [addAudioFrameEmbedded](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addaudioframeembedded/) segítségével, és egy lejátszási parancsot társít a hangkerethez.

A hangkeret egyaránt az effektus célja és a parancs célja. Ez összekapcsolja a lejátszási kérést a beágyazott felvétellel; egy parancs karakterlánc önmagában nem határozza meg, melyik médiaobjektumot kell vezérelni. Az effektus úgy van beállítva, hogy a diavetítés közben kattintásra induljon.

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

A mentés a `command.pptx` fájlban tárolja a parancsot; nem játssza le a felvételt. A lejátszáshoz egy olyan diavetítőre van szükség, amely támogatja a parancsot és a hozzá tartozó média célpontot.

## **A viselkedésgyűjtemény kezelése**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/) támogatja a [add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/remove/), és a [removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/removeat/) műveleteket. Ez a példa megnyitja a `rotation.pptx` fájlt, hozzáad egy méretezést, a forgatás előtt helyezi el, majd eltávolítja a forgatást. Ugyanazon objektum eltávolítása és újraillesztése megváltoztatja a tárolt pozíciót anélkül, hogy másolatot készítene.

A szerkesztések sorozata a gyűjteményt a forgatás‑méretezésről méretezés‑forgatásra, majd csak méretezésre változtatja. Az indexek az aktuális gyűjteményre vonatkoznak, így az eltávolítás a forgatás új indexét használja átrendezés után. A végső felsorolás megerősíti, melyik viselkedés lesz mentve.

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

A kimenet `ScaleEffect`: csak a méretezés marad. A gyűjtemény sorrendje önmagában nem ütemezi a viselkedéseket egymás után. A gyűjteményt csak akkor törölje, ha az összes műveletet cserélni szeretné.

## **Viselkedés időzításának beállítása**

Egy viselkedésnek saját [Timing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/) objektuma van, amely független a [Effect::getTiming](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/gettiming/) által visszaadott időzítéstől. Az effektus időzítése ütemezi a körülötte lévő effektust; a viselkedés időzítése a benne lévő műveletet írja le.

### **Időtartam, késleltetés, ismétlés és gyorsulás beállítása**

Nyissa meg a `rotation.pptx` fájlt, és állítsa be a időtartamot ([getDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getduration/)) és a kiváltó késleltetést ([getTriggerDelayTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/gettriggerdelaytime/)) másodpercben, majd konfigurálja az ismétlésszámot a [setRepeatCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/setrepeatcount/) segítségével. A [getAccelerate](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getaccelerate/) és a [getDecelerate](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getdecelerate/) a időtartam részaránya; azok összegét legfeljebb 1‑re korlátozza.

A bemeneti fájl a forgatás példában létrehozott fájl, ahol az első viselkedés forgatásként ismert. Ez a példa csak ennek a viselkedésnek az időzítését módosítja; a 90 fokos szög változatlan marad. A szög és az időzítés szétválasztása megkönnyíti a tempó állítását az animáció újbóli felépítése nélkül.

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

A viselkedés két másodperces időtartamot, fél másodperces késleltetést és 3 ismétlést használ. Időtartamának az első és az utolsó 20%-a a gyorsulásra és lassulásra szolgál.

Más ismétlési politikák közé tartozik a [getRepeatDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatduration/), a [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilendslide/), és a [getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getrepeatuntilnextclick/); válasszon egy politikát, ahelyett, hogy mindet egyszerre engedélyezné. A [getAutoReverse](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/getautoreverse/) a animációt visszafelé játssza le a előrehaladást követően. A gyorsulás és lassulás folytonos változásokra vonatkozik, nem pedig diszkrét értékadásokra vagy parancsokra.

## **Mozgásútvonal felépítése**

A [createMotionEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorfactory/createmotioneffect/) használatával hozhat létre mozgást. A [getFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/getfrom/), a [getTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/getto/), és a [getBy](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/getby/) százalékos koordinátákat vagy eltolásokat írnak le. Szerkeszthető útvonalhoz hozza létre a [MotionPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpath/) objektumot, és rendelje hozzá a [MotionEffect::setPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/setpath/) segítségével. A [MotionPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpath/) tárolja az útvonal parancsait.

| Parancs | Pontok | Jelentés |
| --- | --- | --- |
| MoveTo | Egy | Állítsa be a kiindulási pozíciót. |
| LineTo | Egy | Mozogjon egy egyenes szakaszon a végpontjáig. |
| CurveTo | Három | Kövesse a két vezérlőpont és egy végpont által meghatározott köbös ívet. |
| CloseLoop | Nincs | Térjen vissza a kiindulási pozícióba. |
| End | Nincs | Fejezze be az útvonalat. |

A [MotionPathPointsType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpathpointstype/) pontszerkesztési jellemzőket ír le, mint például a sarok vagy a sima pontok. Nem helyettesíti a parancs típust. Használjon ív ponttípust az alábbi ív példához, és sarok ponttípust az egyenes szakaszokhoz.

Az útvonal koordinátái a dia méreteihez vannak normalizálva: egy 0.25 X eltolás a dia szélességének egy negyedét jelenti, nem 0.25 pontot. A pozitív Y lefelé halad. Az abszolút parancsok a koordináta rendszerben határozzák meg a pozíciókat; a relatív parancsok az aktuális pozícióhoz képest eltolásokat adnak meg. Ez elkülönül a [getOrigin](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/getorigin/) beállítástól, amely az útvonal referencia keretét választja ki, és a [getPathEditMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioneffect/getpatheditmode/) beállítástól, amely az útvonal mozgását szabályozza, amikor az alakzatot mozgatják.

### **Egyenes útvonal létrehozása**

Hozzon létre egy mozgásviselkedést egy kiindulási ponttal, egy egyenes szegmenkkel és egy befejező paranccsal. A [MotionPath::add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpath/add/) a parancs típusát, annak pontjait, a pont típust és egy relatív koordináta jelzőt vár.

A kiindulási parancs (0, 0)-t állapít meg, a vonal (0.25, 0)-nél végződik, így az útvonal vízszintes eltolása a dia szélességének egy negyedét adja. A befejező parancsnak nincs koordináta-pontja. Miután az útvonal hozzá van rendelve, a mozgásviselkedés hozzáadása az effektushoz összeköti az útvonalat a téglalappal.

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

`motion.pptx` egy mozgásviselkedést és három útparancsot tartalmaz. A következő fájlszerkesztési példák ezt a szerkezetet használják.

### **Abszolút és relatív koordináták összehasonlítása**

Ez a két útvonal objektum ugyanazt az útvonalat írja le. Az abszolút parancs (0.3, 0.1)-nél ér véget; a relatív parancs (0.1, 0.1)-et ad hozzá az aktuális pozícióhoz, ami (0.2, 0).

Mindkét útvonal ugyanonnan indul. A relatív vonal esetén adja hozzá az X és Y eltolásokat az aktuális pozícióhoz a végpont eléréséhez; az abszolút vonal esetén a végpontot közvetlenül olvassa. A jelző megváltoztatása a koordináták átalakítása nélkül más útvonalat eredményezne.

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

Rendeljen bármelyik útvonalat egy mozgásviselkedéshez a prezentációban való használathoz. Az utolsó logikai argumentum a relatív koordinátákat választja ki a parancshoz.

### **Vonal cseréje ívre**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonalparancsát egy köbös ívre. Először adja meg a két vezérlőpontot, majd a végpontot.

A kezdőpozíciót az előző parancs adja. Az első két pont alakítja az ívet, míg a harmadik a célpont; nem három egymást követő célpontról van szó. A parancs típusának, a pontszerkesztési típusnak és a ponttömbnek együttes frissítése biztosítja, hogy a szegmens új geometriai beállításokkal összhangban legyen.

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

`curve.pptx` útvonala továbbra is három parancsot tartalmaz; a középső parancs most egy ívet definiál.

## **Mentett útvonal vizsgálata és szerkesztése**

Minden [MotionCmdPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioncmdpath/) a [getPoints](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioncmdpath/getpoints/), a [getCommandType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioncmdpath/getcommandtype/), a [getPointsType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioncmdpath/getpointstype/), és az [isRelative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motioncmdpath/isrelative/) metódusokat teszi elérhetővé. A következő példák a `motion.pptx` háromparancsos útvonalát használják. Tetszőleges bemenet esetén, először keresse meg a kívánt effektust, és ellenőrizze a parancs típusokat és a pontok számát, mielőtt index alapján szerkesztené.

### **Parancsok és koordináták olvasása**

Olvassa be az útvonalat módosítás nélkül. A 'End' és a 'CloseLoop' parancsoknak nincs szükségük pontokra, így engedélyezzen egy null ponttömböt.

A kimenet minden numerikus parancs típust párosít a relatív koordináta jelzőjével, mielőtt felsorolja a pontokat. Ez lehetővé teszi, hogy a módosítás előtt megkülönböztesse a végpontot az eltolástól. Egy ív három pontot sorol fel, míg ebben a fájlban az egyenes vonal csak egyet.

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

A felsorolás egy kiindulási pontot, egy abszolút vonalat (0.25, 0)-nél végződően és egy befejező parancsot tartalmaz.

### **Végpont módosítása**

Nyissa meg a `motion.pptx` fájlt, és cserélje le a vonal ponttömbjét, hogy megváltoztassa annak végpontját.

A bemeneti fájlban a 0 index a kiindulási parancs, az 1 index a vonal. A vonal egyetlen pontjának cseréje megváltoztatja a célpontot anélkül, hogy módosítaná a parancs típusát, az időzítést vagy a gyűjteményben elfoglalt helyét. Mivel a parancs abszolút koordinátákat használ, az új páros egy pozíciót ad meg, nem egy hozzáadott eltolást.

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

`motion-endpoint.pptx` vonala (0.4, 0.1)-nél ér véget; az eredeti fájl változatlan marad.

### **Szegmens cseréje**

Használja a [insert](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpath/insert/) és a [removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/motionpath/removeat/) módszereket a `motion.pptx` vonalának cseréjéhez. Beszúrásnál a régi vonal a 2-es indexre kerül.

Ez azt mutatja, hogy egy parancsobjektumot cserélünk a meglévő koordináták szerkesztése helyett. Beszúrás után a gyűjtemény ideiglenesen a kiindulási parancsot, az új vonalat, a régi vonalat és a befejező parancsot tartalmazza. A 2-es index eltávolítása a régi vonalat eldobja, és az új útvonal marad.

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

A mentett útvonal továbbra is három parancsot tartalmaz, az új vonal (0.2, 0.1)-nél végződik, a befejező parancs pedig az utolsó.

## **Meglévő viselkedés módosítása és ellenőrzése**

Ha a viselkedés indexe ismeretlen, válassza ki típus alapján. Ez a példa megnyitja a `rotation.pptx` fájlt, megtalálja a [RotationEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/rotationeffect/), módosítja a szöget, és a megnyitás után ellenőrzi a mentett értéket.

A típus ellenőrzése lehetővé teszi, hogy a ciklus átugorja a nem forgatás viselkedéseket. A második betöltés a mentett fájlt egy külön prezentációs objektumba olvassa be, így az összehasonlítás a tárolt adatokat ellenőrzi, nem a memóriában még lévő értéket. Ez a példa továbbra is azt feltételezi, hogy a ismert effektus az első a fő sorozatban; típus szerint kiválasztott viselkedés nem biztos, hogy egy tetszőleges prezentációban a megfelelő effektust találja meg.

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

A kimenet `Rotation preserved: true`. Alkalmazza ugyanazt a típusellenőrző mintát más viselkedésekre is. Egy teljes megőrzési ellenőrzéshez hasonlítsa össze a célt alakzatot, az effektust, a viselkedéstípusokat és sorrendet, az időzítést és az útparancsokat. Használjon numerikus toleranciát a lebegőpontos értékekhez. Egy ismeretlen animációs elrendezésű prezentáció esetén lásd a [Alakzat animációjának olvasása](/slides/hu/php-java/shape-animation/#read-shape-animations) oldalt a fő és interaktív sorozatok bejárásához.

## **Viselkedés sorrend, előbeállítások és lejátszás**

A [BehaviorCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behaviorcollection/) sorrendje egy effektus műveleteinek tárolt sorrendje. Nem egy lejátszási lista, ahol minden viselkedés automatikusan vár az előzőre. Az időzítés és a körülhatároló effektus határozza meg a ütemezést. A viselkedések átfedhetnek, és ugyanazon tulajdonságon végzett műveletek kölcsönhatásba léphetnek a [additive](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behavioradditivetype/) és [accumulation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/behavioraccumulatetype/) beállítások révén. Ne csak a gyűjtemény átrendezésével ütemezze a „mozgatás, majd forgatás” sorrendet; használjon explicite időzítést vagy külön effektusokat, ahogy a [Alakzat animáció](/slides/hu/php-java/shape-animation/) leírásában szerepel.

Az effektus [getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/gettype/) és [getSubtype](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/getsubtype/) metódusai leírják az előbeállítást. Nem egy teljes leírást adnak egy szerkesztett viselkedésfáról. Válassza ki az előbeállítást és az al-típust a viselkedések testreszabása előtt: az előbeállítás megváltoztatása újraépítheti a gyűjteményt és eldobhatja az egyéni műveleteket. Például egy testreszabott Spin effektus Fade-re módosítása felcserélheti a forgatási viselkedést set és filter viselkedésekkel. Ellenőrizze újra a gyűjteményt az előbeállítás vagy al-típus módosítása után. Az előbeállítási viselkedések törlése eltávolíthatja a láthatóság vagy inicializálás műveleteket, amelyeket az előbeállítás igényel. A példák szándékosan látható alakzatokat használnak és lecserélik a viselkedéseket; nem építik újra minden előbeállítás megvalósítását.

## **Formátum kompatibilitás**

A megőrzött viselkedésfa nem garantálja az azonos lejátszást minden megjelenítőben vagy exportáló renderelőben. Ellenőrizze külön a mentett adatot és a renderelt kimenetet.

| Formátum vagy kimenet | Mit kell ellenőrizni |
| --- | --- |
| PPTX | Használja elsődleges formátumként ezekhez a példákhoz. Nyissa meg újra a szerkeszthető viselkedésfa ellenőrzéséhez, majd tesztelje a lejátszást a célzott PowerPoint verzióban. |
| PPT | Az örökölt bináris formátum eltérhet a PPTX-től. Teszteljen egy külön mentés‑újranyitás ciklust és lejátszást; ne feltételezze a minden egyedi kombináció támogatását a sikeres PPTX kimenet alapján. |
| PDF, PNG, JPEG és egyéb statikus dia képek | Statikus diavetítést tartalmaznak, nem játszható viselkedésidővonalat vagy garantált végső animációs képkockát. |
| [HTML5](/slides/hu/php-java/export-to-html5/) | Képes lejátszani a támogatott animációkat, ha az alakzat animáció engedélyezve van az export beállításaiban. Tesztelje az egyedi kombinációkat a böngészőben. |
| [Animated GIF](/slides/hu/php-java/convert-powerpoint-to-animated-gif/) | Renderelt képkockákat tárol, nem szerkeszthető viselkedéseket vagy kattintás‑indított interakciót. Ellenőrizze a tényleges renderelt mozgást. |
| [Video](/slides/hu/php-java/convert-powerpoint-to-video/) | Animációs képkockákat renderel és videóként kódolja. A támogatás a renderelő [supported animations and effects](/slides/hu/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) listájára korlátozódik; a parancsok és interaktív események nem válnak szerkeszthető idővonalá. |

## **GYIK**

**Miért tartalmazza az effektusom a viselkedéseket, mielőtt hozzáadnék bármilyet?**

Egy előre definiált effektus létrehozhatja a mögöttes műveleteket. Vizsgálja meg őket, mielőtt eldöntené, hogy kiterjeszti az előbeállítást vagy lecseréli a viselkedéseket.

**A viselkedés elejére helyezése azt eredményezi, hogy először lejátszódik?**

Nem feltétlenül. A gyűjtemény sorrendje nem helyettesíti az időzítést. Ellenőrizze a késleltetéseket, időtartamokat és az ugyanazon tulajdonság műveletei közötti kölcsönhatásokat.

**Miért nem tartalmaz pontot a befejező parancs?**

Ez az útvonal végét jelöli, és nem igényel koordinátákat. Ellenőrizze, hogy a fájlból beolvasott útvonal esetén a ponttömb null‑e.

**Elégséges egy sikeres körutazás a lejátszás megerősítéséhez?**

Nem. Az újranyitás csak a ellenőrzött tulajdonságok megőrzését igazolja. A diavetítő vagy az animált export külön tesztelése szükséges a vizuális viselkedés megerősítéséhez.