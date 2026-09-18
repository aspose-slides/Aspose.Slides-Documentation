---
title: Skapa och modifiera anpassade animationsbeteenden i PHP
linktitle: Anpassad animation
type: docs
weight: 151
url: /sv/php-java/custom-animation/
keywords:
- anpassad animation
- animationsbeteende
- rörelsebana
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa, inspektera och modifiera anpassade animationsbeteenden och redigerbara rörelsebanor i PowerPoint-presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Anpassade animationsbeteenden låter dig kontrollera individuella operationer inom en animationseffekt, såsom att ändra en färg, rotera en form eller följa en redigerbar rörelsestrategi. Denna guide visar hur du skapar och kombinerar beteenden, konfigurerar deras timing, inspekterar och modifierar befintliga animationer, samt verifierar att deras egenskaper överlever att spara och öppna en presentation igen.

För fördefinierade effekter och klicktriggers, se [Formanimation](/slides/sv/php-java/shape-animation/).

## **Förstå animationsmodellen**

En animation är organiserad som **Timeline → Sequence → Effect → Behaviors**:

- Varje bild har en tidslinje som innehåller dess huvudsekvens och interaktiva sekvenser.
- En [Sequence](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/) innehåller effekter, eventuellt riktade mot olika former.
- En [Effect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/) identifierar en målform, förinställning, undertyp och effektens timing.
- Samlingen som returneras av [Effect::getBehaviors](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getbehaviors/) innehåller de operationer som implementerar effekten: ändra färg, flytta, rotera, ställa in en egenskap osv.

## **Skapa enskilda beteenden**

Anropa [Sequence::addEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/addeffect/) för att skapa en effekt och komma åt samlingen [getBehaviors](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getbehaviors/). En förinställning kan fylla denna samling automatiskt. Behåll dess operationer när du utökar förinställningen, eller använd [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/clear/) när du avsiktligt ersätter dem.

[BehaviorFactory](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/) skapar de åtta beteendetyperna som illustreras nedan. Rörelse täcks i [Build a Motion Path](#build-a-motion-path). Varje kodsnutt inkluderar sina import‑uttalanden och förutsätter att PHP/Java‑bron och Aspose.Slides‑PHP‑biblioteket har laddats. Senare redigeringsexempel anger vilken utdatafil de använder.

### **Rotation**

Använd [createRotationEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createrotationeffect/) för att skapa en rotation. [getBy](https://reference.aspose.com/slides/sv/php-java/aspose.slides/rotationeffect/getby/) anger en relativ vinkel i grader; [getFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/rotationeffect/getfrom/) och [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/rotationeffect/getto/) anger ändpunkterna.

Exemplet börjar med en Spin‑effekt, ersätter dess förinställda operationer med ett rotationsbeteende, och ger den operationen en tvåsekunders varaktighet. En relativ vinkel på 90 grader motsvarar ett kvart varv från formens startorientering, så ingen explicit startvinkel behövs.

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

`rotation.pptx` innehåller en form och ett rotationsbeteende. Samlingen, tidsinställningarna och rotationsredigeringsexemplen nedan använder denna fil.

### **Skala**

Använd [createScaleEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createscaleeffect/) med X/Y‑procent: [getFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/scaleeffect/getfrom/) och [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/scaleeffect/getto/) beskriver start- och slutstorlek, medan [getBy](https://reference.aspose.com/slides/sv/php-java/aspose.slides/scaleeffect/getby/) beskriver en relativ förändring. Här betyder 100 den ursprungliga storleken.

Exemplet ökar båda dimensionerna från 100 % till 125 % över två sekunder. Att använda lika horisontella och vertikala procent bevarar formens proportioner; olika procenttal skulle sträcka en dimension mer än den andra.

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

### **Färg**

Använd [createColorEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createcoloreffect/) för att ändra fyllningen från blå till orange. [getFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/coloreffect/getfrom/) och [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/coloreffect/getto/) är färger; [getBy](https://reference.aspose.com/slides/sv/php-java/aspose.slides/coloreffect/getby/) är en färgförskjutning. Beteendets [BehaviorPropertyCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorpropertycollection/) identifierar attributet som animeras.

Formens solida fyllning initieras till blå, vilket matchar animationens startfärg. Att välja fyllnings‑färgattributet talar om för beteendet vilken del av formen som ska ändras; färgens ändpunkter ensamma identifierar inte det attributet. Den sparade effekten beskriver en tvåsekunders övergång till orange.

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

### **Filter**

Använd [createFilterEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createfiltereffect/) för att välja en svepning. [getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filtereffect/getsubtype/) och [getReveal](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filtereffect/getreveal/) specificerar filtret, riktningen och om formen ska visas eller döljas.

Detta exempel konfigurerar en tvåsekunders svepning som visar formen med undertypen för högerriktning. Filterinställningarna tillhör beteendet inom effekten, så de konfigureras efter att förinställningens ursprungliga operationer har tagits bort.

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

### **Egenskap**

Använd [createPropertyEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) för att animera opacitet. [getFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/propertyeffect/getto/) och [getBy](https://reference.aspose.com/slides/sv/php-java/aspose.slides/propertyeffect/getby/) är strängar som tolkas med [getValueType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/propertyeffect/getvaluetype/) och [getCalcMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/propertyeffect/getcalcmode/). Välj ändpunkter eller en relativ förskjutning snarare än att sätta alla tre godtyckligt.

Här är det valda attributet opacitet, och de numeriska strängarna representerar en förändring från 25 % opacitet till full opacitet. Linjär interpolation beskriver en gradvis förändring mellan dessa värden. När du anpassar detta exempel till ett annat attribut, välj en värdetyp och ändpunktsvärden som är lämpliga för det attributet.

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

### **Sätt**

Använd [createSetEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createseteffect/) för att tilldela synlighet via [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/seteffect/getto/). Ett set‑beteende interpolerar inte mellan ändpunkterna.

Exemplet väljer synlighetsattributet och tilldelar strängen `visible` när beteendet körs. Rektangeln är redan synlig i denna minimala presentation, så tilldelningen kanske inte ger någon uppenbar visuell förändring i sig. En sådan operation är användbar som en del av en större effekt som också styr när formen blir dold eller synlig.

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

### **Kommando**

Använd [createCommandEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createcommandeffect/) och konfigurera [getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commandeffect/getcommandstring/) och [getShapeTarget](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commandeffect/getshapetarget/). Placera en WAV‑inspelning med namnet `sample.wav` i arbetskatalogen. Detta exempel bäddar in den med [addAudioFrameEmbedded](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addaudioframeembedded/) och knyter ett spel‑kommando till ljud‑ramen.

Ljud‑ramen är både effektens mål och kommandots mål. Detta kopplar uppspelningsbegäran till den inbäddade inspelningen; en kommandosträng i sig identifierar inte vilket medieobjekt som ska styras. Effekten är konfigurerad att starta vid ett klick under bildspelet.

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

Sparandet lagrar kommandot i `command.pptx`; det spelar inte upp inspelningen. Uppspelning kräver en bildspels‑spelare som stödjer kommandot och dess mediamål.

## **Hantera beteendesamlingen**

[BehaviorCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/) stödjer [add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/remove/) och [removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/removeat/). Detta exempel öppnar `rotation.pptx`, lägger till en skalning, flyttar den före rotationen och tar bort rotationen. Att ta bort och återinfoga samma objekt förändrar dess lagrade position utan att skapa en kopia.

Redigeringssekvensen förändrar samlingen från rotation‑skala till skala‑rotation, och sedan till endast skala. Index refererar till den aktuella samlingen, så borttagningen använder rotationens nya index efter omordning. Den slutliga uppräkningen bekräftar vilket beteende som kommer att sparas.

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

Resultatet är `ScaleEffect`: endast skalning återstår. Samlingsordningen schemalägger i sig inte beteenden ett efter ett. Rensa samlingen endast när du ersätter alla dess operationer.

## **Konfigurera beteendets timing**

Ett beteende har sin egen [Timing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/), oberoende av den timing som returneras av [Effect::getTiming](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/gettiming/). Effekt‑timing schemalägger den omslutande effekten; beteende‑timing beskriver en operation inom den.

### **Ställ in varaktighet, fördröjning, upprepning och acceleration**

Öppna `rotation.pptx` och ställ in varaktigheten ([getDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getduration/)) och utlösningsfördröjningen ([getTriggerDelayTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/gettriggerdelaytime/)) i sekunder, konfigurera sedan upprepningsantalet via [setRepeatCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getaccelerate/) och [getDecelerate](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getdecelerate/) är bråkdelar av varaktigheten; håll deras summa högst 1.

Indatafilen är den som skapades i rotations‑exemplet, där det första beteendet är känt att vara en rotation. Detta exempel förändrar endast detta beteendes timing; dess 90‑graders vinkel förblir oförändrad. Att hålla vinkel och timing separata gör det enklare att justera takten utan att bygga om animationen.

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

Beteendet använder en tvåsekunders varaktighet, en halvsekunders fördröjning och ett upprepningsantal på 3. De första och sista 20 % av dess varaktighet används för acceleration och deceleration.

Andra upprepningspolicyer inkluderar [getRepeatDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatuntilendslide/) och [getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getrepeatuntilnextclick/); välj en policy i stället för att aktivera dem alla samtidigt. [getAutoReverse](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/getautoreverse/) spelar animationen bakåt efter den framåtriktade passagen. Acceleration och deceleration gäller kontinuerliga förändringar, inte diskreta tilldelningar eller kommandon.

## **Skapa en rörelsebana**

Använd [createMotionEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorfactory/createmotioneffect/) för att skapa rörelse. Dess [getFrom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/getto/) och [getBy](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/getby/) beskriver procentbaserade koordinater eller förskjutningar. För en redigerbar bana, skapa en [MotionPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpath/) och tilldela den med [MotionEffect::setPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpath/) lagrar bana‑kommandona.

[MotionCommandPathType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncommandpathtype/) väljer operationen:

| Kommando | Punkter | Betydelse |
| --- | --- | --- |
| MoveTo | En | Sätt startpositionen. |
| LineTo | En | Flytta längs ett rakt segment till dess slutpunkt. |
| CurveTo | Tre | Följ en kubisk kurva definierad av två kontrollpunkter och en slutpunkt. |
| CloseLoop | Ingen | Återgå till startpositionen. |
| End | Ingen | Avsluta banan. |

[MotionPathPointsType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpathpointstype/) beskriver egenskaper för punktredigering, såsom hörn‑ eller mjuka punkter. Den ersätter inte kommandotypen. Använd en kurvpunktstyp för kurvexemplet nedan, och en hörnpunktstyp för de raka segmenten.

Banakordinater normaliseras till bildens dimensioner: en X‑förskjutning på 0,25 representerar en fjärdedel av bildens bredd, inte 0,25 punkter. Positiv Y löper nedåt. Absoluta kommandon specificerar positioner i bana‑koordinatsystemet; relativa kommandon specificerar förskjutningar från den aktuella positionen. Detta är separat från [getOrigin](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/getorigin/), som väljer banans referensram, och [getPathEditMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioneffect/getpatheditmode/), som styr hur banan rör sig när formen flyttas.

### **Skapa en rak bana**

Skapa ett rörelsbeteende med en startpunkt, ett rakt segment och ett slut‑kommando. [MotionPath::add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpath/add/) tar kommandotypen, dess punkter, punkttypen och en flagga för relativ koordinat.

Start‑kommandot etablerar (0, 0) och linjen slutar vid (0,25, 0), vilket ger banan en horisontell förskjutning på en fjärdedel av bildens bredd. Slut‑kommandot har inga koordinatpunkter. När banan har tilldelats, kopplar tillägget av rörelsbeteendet till effekten den rutten till rektangeln.

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

`motion.pptx` innehåller ett rörelsbeteende med tre bana‑kommandon. Följande fil‑redigeringsexempel använder denna kända struktur.

### **Jämför absoluta och relativa koordinater**

Dessa två bana‑objekt beskriver samma rutt. Det absoluta kommandot slutar vid (0,3, 0,1); det relativa kommandot lägger till (0,1, 0,1) till den aktuella positionen, (0,2, 0). 

Båda banorna börjar på samma position. För den relativa linjen, addera dess X‑ och Y‑förskjutningar till den aktuella positionen för att få slutpunkten; för den absoluta linjen, läs slutpunkten direkt. Att byta flaggan utan att konvertera koordinaterna skulle beskriva en annan rutt.

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

Tilldela någon av banorna till ett rörelsbeteende för att använda det i en presentation. Det sista booleska argumentet väljer relativa koordinater för det kommandot.

### **Ersätt en linje med en kurva**

Öppna `motion.pptx` och ersätt dess linjekommando med en kubisk kurva. Ange först de två kontrollpunkterna, följt av slutpunkten.

Startpositionen levereras av föregående kommando. De första två punkterna formar kurvan, medan den tredje är dess destination; de är inte tre på varandra följande destinationer. Att uppdatera kommandotyp, punkt‑redigeringstyp och punkt‑array samtidigt håller segmentet i överensstämmelse med dess nya geometri.

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

Banan i `curve.pptx` har fortfarande tre kommandon; dess mellersta kommando definierar nu en kurva.

## **Inspektera och redigera en sparad bana**

Varje [MotionCmdPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncmdpath/) exponerar [getPoints](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncmdpath/getpointstype/) och [isRelative](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motioncmdpath/isrelative/). Följande exempel använder den kända tre‑kommandobanan i `motion.pptx`. För godtycklig indata, hitta den avsedda effekten och kontrollera kommandotyper och punktantal innan redigering efter index.

### **Läs kommandon och koordinater**

Läs banan utan att ändra den. Slut‑ och close‑loop‑kommandon kräver inga punkter, så tillåt en null‑punkt‑array.

Resultatet parar varje numerisk kommandotyp med dess flagga för relativ koordinat innan punkterna listas. Detta låter dig skilja en slutpunkt från en förskjutning innan du modifierar banan. En kurva skulle lista tre punkter, medan den raka linjen i den här filen listar endast en.

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

Listan innehåller en startpunkt, en absolut linje som slutar vid (0,25, 0), och ett slut‑kommando.

### **Ändra en slutpunkt**

Öppna `motion.pptx` och ersätt linjens punkt‑array för att flytta dess slutpunkt.

I indatafilen är index 0 startkommandot och index 1 linjen. Att ersätta linjens enda punkt ändrar dess destination utan att förändra kommandotyp, timing eller position i samlingen. Eftersom kommandot använder absoluta koordinater, specificerar det nya paret en position snarare än en tillagd förskjutning.

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

Linjen i `motion-endpoint.pptx` slutar vid (0,4, 0,1); originalfilen är oförändrad.

### **Ersätt ett segment**

Använd [insert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpath/insert/) och [removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/motionpath/removeat/) för att ersätta linjen i `motion.pptx`. Infogning förflyttar den gamla linjen till index 2.

Detta demonstrerar att ersätta ett kommandom objekt snarare än att redigera dess befintliga koordinater. Efter infogning innehåller samlingen tillfälligt startkommandot, den nya linjen, den gamla linjen och slut‑kommandot. Borttagning av index 2 kastar den gamla linjen och lämnar den nya rutten på plats.

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

Den sparade banan har fortfarande tre kommandon, där den nya linjen slutar vid (0,2, 0,1) och slut‑kommandet är sist.

## **Modifiera och verifiera ett befintligt beteende**

När beteendets index är okänt, välj det efter typ. Detta exempel öppnar `rotation.pptx`, hittar dess [RotationEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/rotationeffect/), ändrar vinkeln och kontrollerar det sparade värdet efter att ha öppnat filen igen.

Typkontrollen låter loopen hoppa över beteenden som inte är rotationer. Den andra inläsningen läser den sparade filen in i ett separat presentationsobjekt, så jämförelsen kontrollerar bestående data snarare än värdet som fortfarande hålls i minnet. Detta exempel antar fortfarande att den kända effekten är den första i huvudsekvensen; att välja ett beteende efter typ hittar inte den korrekta effekten i en godtycklig presentation.

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

Resultatet är `Rotation preserved: true`. Använd samma typ‑kontrollmönster för andra beteenden. För en fullständig bevarande‑kontroll, jämför målformen, effekten, beteendetyper och ordning, timing samt bana‑kommandon. Använd en numerisk tolerans för flyttalsvärden. För en presentation med okänt animationsupplägg, se [Read Shape Animations](/slides/sv/php-java/shape-animation/#read-shape-animations) för traversering av huvud‑ och interaktiva sekvenser.

## **Beteendeordning, förinställningar och uppspelning**

Ordningen i [BehaviorCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behaviorcollection/) är den lagrade ordningen för en effektens operationer. Det är inte en spellista där varje beteende automatiskt väntar på föregående. Timing och den omslutande effekten bestämmer schemaläggning. Beteenden kan överlappa, och operationer på samma egenskap kan interagera via [additive](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behavioradditivetype/) och [accumulation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/behavioraccumulatetype/)‑inställningar. Använd inte bara omordning av samlingen för att schemalägga ”flytta, sedan rotera”; använd explicit timing eller separata effekter som beskrivs i [Shape Animation](/slides/sv/php-java/shape-animation/).

Effektens [getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/gettype/) och [getSubtype](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/getsubtype/) beskriver dess förinställning. De är inte en fullständig beskrivning av ett redigerat beteendeträd. Välj förinställning och undertyp innan du anpassar beteenden: att ändra förinställningen kan bygga om samlingen och kasta dina anpassade operationer. Till exempel kan en ändring av en anpassad Spin‑effekt till Fade ersätta dess rotationsbeteende med set‑ och filter‑beteenden. Inspektera samlingen igen efter att du har ändrat en förinställning eller undertyp. Rensning av förinställningsbeteenden kan också ta bort synlighets‑ eller initieringsoperationer som förinställningen kräver. Exemplen använder medvetet synliga former och ersätter beteendena; de rekonstruerar inte varje förinställnings implementation.

## **Formatkompatibilitet**

Ett bevarat beteendeträd garanterar inte identisk uppspelning i varje visare eller export‑renderare. Kontrollera sparad data och den renderade outputen separat.

| Format eller output | Vad som ska verifieras |
| --- | --- |
| PPTX | Använd som primärt format för dessa exempel. Öppna den igen för att verifiera det redigerbara beteendeträdet, och testa sedan uppspelning i den avsedda PowerPoint‑versionen. |
| PPT | Äldre binär representation kan skilja sig från PPTX. Testa en separat spara‑och‑öppna‑cykel och uppspelning; anta inte stöd för varje anpassad kombination baserat på lyckad PPTX‑output. |
| PDF, PNG, JPEG och andra statiska bild‑bilder | Innehåller en statisk bildrepresentation, inte en spelbar beteende‑tidslinje eller en garanterad slut‑animationsram. |
| [HTML5](/slides/sv/php-java/export-to-html5/) | Kan spela stödjade animationer när formanimation är aktiverad i eksportalternativen. Testa anpassade kombinationer i webbläsaren. |
| [Animated GIF](/slides/sv/php-java/convert-powerpoint-to-animated-gif/) | Sparar renderade ramar, inte redigerbara beteenden eller klick‑utlösta interaktioner. Kontrollera den faktiska renderade rörelsen. |
| [Video](/slides/sv/php-java/convert-powerpoint-to-video/) | Renderar animationsramar och kodar dem som video. Stödet är begränsat till renderarens [supported animations and effects](/slides/sv/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); kommandon och interaktiva händelser blir inte en redigerbar tidslinje. |

## **FAQ**

**Varför innehåller min effekt beteenden innan jag har lagt till några?**

Att skapa en fördefinierad effekt kan skapa dess underliggande operationer. Inspektera dem innan du bestämmer dig för att utöka förinställningen eller ersätta dess beteenden.

**Gör det att flytta ett beteende till början att det spelas först?**

Inte nödvändigtvis. Samlingsordningen är ingen ersättning för timing. Kontrollera fördröjningar, varaktigheter och interaktioner mellan operationer på samma egenskap.

**Varför har ett slut‑kommando inga punkter?**

Det markerar slutet på banan och kräver inga koordinater. Kontrollera om punkt‑arrayen är null när du inspekterar en bana läst från en fil.

**Är en lyckad runda tillräcklig för att bekräfta uppspelning?**

Nej. Att öppna om bekräftar bevarandet av de egenskaper du kontrollerade. Testa bildspels‑spelaren eller den animerade exporten separat för att bekräfta dess visuella beteende.