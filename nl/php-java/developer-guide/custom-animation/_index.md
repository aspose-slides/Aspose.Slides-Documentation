---
title: Aanmaken en wijzigen van aangepaste animatiegedragingen in PHP
linktitle: Aangepaste animatie
type: docs
weight: 151
url: /nl/php-java/custom-animation/
keywords:
- aangepaste animatie
- animatiegedrag
- bewegingspad
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak, inspecteer en wijzig aangepaste animatiegedragingen en bewerkbare bewegingspaden in PowerPoint-presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aangepaste animatiegedragingen laten je individuele bewerkingen binnen een animatie‑effect regelen, zoals het wijzigen van een kleur, het roteren van een vorm of het volgen van een bewerkbaar bewegingspad. Deze gids laat zien hoe je gedragingen maakt en combineert, hun timing configureert, bestaande animaties inspecteert en wijzigt, en verifieert dat hun eigenschappen behouden blijven bij het opslaan en opnieuw openen van een presentatie.

Voor vooraf gedefinieerde effecten en klik‑triggers, zie [Vormanimatie](/slides/nl/php-java/shape-animation/).

## **Begrijp het animatiemodel**

Een animatie is georganiseerd als **Timeline → Sequence → Effect → Behaviors**:

- Elke dia heeft een tijdlijn die de hoofd‑reeks en interactieve reeksen bevat.
- Een [Sequence](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/) bevat effecten, die mogelijk verschillende vormen targeten.
- Een [Effect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/) identificeert een doelvorm, preset, subtype en de timing van het effect.
- De collectie die wordt geretourneerd door [Effect::getBehaviors](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getbehaviors/) bevat de bewerkingen die het effect implementeren: kleur wijzigen, verplaatsen, roteren, een eigenschap instellen, enzovoort.

## **Maak individuele gedragingen**

Roep [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/addeffect/) aan om een effect te creëren en de [getBehaviors](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getbehaviors/)‑collectie te benaderen. Een preset kan deze collectie automatisch vullen. Houd de bewerkingen wanneer je het preset uitbreidt, of gebruik [clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/clear/) wanneer je ze doelbewust wilt vervangen.

[BehaviorFactory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/) maakt de acht hieronder geïllustreerde gedragstypen. Beweging wordt behandeld in [Maak een bewegingspad](#maak-een-bewegingspad). Elk fragment bevat de benodigde imports en gaat ervan uit dat de PHP/Java Bridge en de Aspose.Slides PHP‑bibliotheek zijn geladen. Later bewerkingsvoorbeelden vermelden welk uitvoerbestand ze gebruiken.

### **Rotatie**

Gebruik [createRotationEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createrotationeffect/) om een rotatie te maken. [getBy](https://reference.aspose.com/slides/nl/php-java/aspose.slides/rotationeffect/getby/) geeft een relatieve hoek in graden aan; [getFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/rotationeffect/getfrom/) en [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/rotationeffect/getto/) geven de eindpunten aan.

Het voorbeeld start met een Spin‑effect, vervangt de preset‑bewerkingen door één rotatiegedrag, en geeft die bewerking een duur van twee seconden. Een relatieve hoek van 90 graden geeft een kwartslag ten opzichte van de beg orientation van de vorm, dus een expliciete starthoek is niet nodig.

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

`rotation.pptx` bevat één vorm en één rotatiegedrag. De collectie, timing en rotatie‑bewerkingsvoorbeelden hieronder gebruiken dit bestand.

### **Schalen**

Gebruik [createScaleEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createscaleeffect/) met X/Y‑percentages: [getFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/scaleeffect/getfrom/) en [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/scaleeffect/getto/) beschrijven de begin‑ en eindgrootte, terwijl [getBy](https://reference.aspose.com/slides/nl/php-java/aspose.slides/scaleeffect/getby/) een relatieve wijziging beschrijft. Hier staat 100 voor de originele grootte.

Het voorbeeld vergroot beide dimensies van 100 % naar 125 % gedurende twee seconden. Gelijke horizontale en verticale percentages behouden de proporties van de vorm; verschillende percentages zouden één dimensie meer uitrekken dan de andere.

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

### **Kleur**

Gebruik [createColorEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createcoloreffect/) om de vulling van blauw naar oranje te wijzigen. [getFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/coloreffect/getfrom/) en [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/coloreffect/getto/) zijn kleuren; [getBy](https://reference.aspose.com/slides/nl/php-java/aspose.slides/coloreffect/getby/) is een kleuroffset. De [BehaviorPropertyCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorpropertycollection/) van het gedrag identificeert het geanimeerde attribuut.

De solide vulling van de vorm wordt geïnitialiseerd op blauw, zodat deze overeenkomt met de startkleur van de animatie. Het selecteren van het vulling‑kleurattribuut vertelt het gedrag welk deel van de vorm moet worden gewijzigd; de kleur‑eindpunten alleen identificeren dat attribuut niet. Het opgeslagen effect beschrijft een overgang van twee seconden naar oranje.

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

Gebruik [createFilterEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createfiltereffect/) om een veeg‑filter te kiezen. [getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filtereffect/getsubtype/), en [getReveal](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filtereffect/getreveal/) geven het filter, de richting, en of de vorm wordt onthuld of verborgen aan.

Dit voorbeeld configureert een veeg van twee seconden die de vorm onthult met het subtype rechts‑richting. De filterinstellingen behoren tot het gedrag binnen het effect, dus ze worden geconfigureerd nadat de oorspronkelijke bewerkingen van het preset zijn verwijderd.

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

### **Eigenschap**

Gebruik [createPropertyEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) om de dekking te animeren. [getFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/propertyeffect/getto/), en [getBy](https://reference.aspose.com/slides/nl/php-java/aspose.slides/propertyeffect/getby/) zijn strings die worden geïnterpreteerd via [getValueType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/propertyeffect/getvaluetype/) en [getCalcMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/propertyeffect/getcalcmode/). Kies eindpunten of een relatieve offset in plaats van alle drie ondoordacht in te stellen.

Hier is het geselecteerde attribuut dekking, en de numerieke strings vertegenwoordigen een wijziging van 25 % dekking naar volledige dekking. Lineaire interpolatie beschrijft een geleidelijke wijziging tussen die waarden. Wanneer je dit voorbeeld aanpast naar een ander attribuut, kies dan een waardetype en eindpuntwaarden die passend zijn voor dat attribuut.

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

### **Instellen**

Gebruik [createSetEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createseteffect/) om zichtbaarheid toe te wijzen via [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/seteffect/getto/). Een set‑gedrag interpoleert niet tussen eindpunten.

Het voorbeeld selecteert het zichtbaarheid‑attribuut en kent de string `visible` toe wanneer het gedrag wordt uitgevoerd. De rechthoek is al zichtbaar in deze minimale presentatie, dus de toewijzing veroorzaakt mogelijk geen duidelijke visuele wijziging op zichzelf. Een dergelijke bewerking is bruikbaar als onderdeel van een groter effect dat ook regelt wanneer de vorm verborgen of zichtbaar wordt.

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

### **Opdracht**

Gebruik [createCommandEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createcommandeffect/) en configureer [getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commandeffect/getcommandstring/), en [getShapeTarget](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commandeffect/getshapetarget/). Plaats een WAV‑opname met de naam `sample.wav` in de werkmap. Dit voorbeeld embedt deze via [addAudioFrameEmbedded](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addaudioframeembedded/) en koppelt een afspeelopdracht aan het audiokader.

Het audiokader is zowel het doel van het effect als van de opdracht. Dit verbindt het afspeel‑verzoek met de ingebedde opname; een opdracht‑string op zichzelf geeft niet aan welk media‑object moet worden bediend. Het effect wordt ingesteld om te starten bij een klik tijdens de diavoorstelling.

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

Opslaan legt de opdracht vast in `command.pptx`; de opname wordt niet afgespeeld. Afspelen vereist een diavoorstelling‑speler die de opdracht en het media‑doel ondersteunt.

## **Beheer de gedragscollectie**

[BehaviorCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/) ondersteunt [add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/remove/), en [removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/removeat/). Dit voorbeeld opent `rotation.pptx`, voegt schalen toe, verplaatst het vóór rotatie, en verwijdert de rotatie. Het verwijderen en opnieuw invoegen van hetzelfde object wijzigt de opgeslagen positie zonder een kopie te maken.

De reeks bewerkingen verandert de collectie van rotatie‑schalen naar schaal‑rotatie, daarna naar alleen schaal. Indexen verwijzen naar de huidige collectie, dus bij het verwijderen wordt de nieuwe index van de rotatie na het herschikken gebruikt. De uiteindelijke enumeratie bevestigt welk gedrag wordt opgeslagen.

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

De uitvoer is `ScaleEffect`: alleen schalen blijft over. De volgorde van de collectie bepaalt op zich niet dat gedragingen na elkaar worden uitgevoerd. Maak de collectie alleen leeg wanneer je alle bewerkingen vervangt.

## **Configureer gedragstiming**

Een gedrag heeft een eigen [Timing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/), onafhankelijk van de timing die wordt geretourneerd door [Effect::getTiming](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/gettiming/). Effect‑timing plant het omvattende effect; gedragstiming beschrijft een bewerking binnen dat effect.

### **Duur, vertraging, herhaling en versnelling instellen**

Open `rotation.pptx` en stel de duur ([getDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getduration/)) en trigger‑vertraging ([getTriggerDelayTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/gettriggerdelaytime/)) in seconden in, daarna configureer je het aantal herhalingen via [setRepeatCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getaccelerate/) en [getDecelerate](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getdecelerate/) zijn fracties van de duur; houd hun som ≤ 1.

Het invoer‑bestand is het bestand dat in het rotatie‑voorbeeld is aangemaakt, waarbij het eerste gedrag bekend is als een rotatie. Dit voorbeeld wijzigt alleen de timing van dat gedrag; de 90‑graden‑hoek blijft ongewijzigd. Het gescheiden houden van hoek en timing maakt het makkelijker het tempo aan te passen zonder de animatie opnieuw op te bouwen.

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

Het gedrag gebruikt een duur van twee seconden, een vertraging van een halve seconde, en een herhalings‑aantal van 3. De eerste en laatste 20 % van de duur worden gebruikt voor versnelling en vertraging.

Andere herhalings‑beleid zijn onder andere [getRepeatDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatuntilendslide/), en [getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getrepeatuntilnextclick/); kies één beleid in plaats van ze allemaal tegelijk in te schakelen. [getAutoReverse](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/getautoreverse/) speelt de animatie achterwaarts af na de voorwaartse fase. Versnelling en vertraging gelden voor continue veranderingen, niet voor discrete toewijzingen of opdrachten.

## **Maak een bewegingspad**

Gebruik [createMotionEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorfactory/createmotioneffect/) om beweging te creëren. Zijn [getFrom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/getto/), en [getBy](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/getby/) beschrijven procent‑gebaseerde coördinaten of offsets. Voor een bewerkbare route, creëer een [MotionPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpath/) en wijs deze toe met [MotionEffect::setPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpath/) slaat de pad‑opdrachten op.

[MotionCommandPathType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncommandpathtype/) selecteert de bewerking:

| Opdracht | Punten | Betekenis |
| --- | --- | --- |
| MoveTo | One | Stel de startpositie in. |
| LineTo | One | Beweeg langs een rechte segment naar het eindpunt. |
| CurveTo | Three | Volg een kubieke kromme gedefinieerd door twee controle‑punten en een eindpunt. |
| CloseLoop | None | Keer terug naar de startpositie. |
| End | None | Beëindig het pad. |

[MotionPathPointsType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpathpointstype/) beschrijft de karakteristieken van punt‑bewerking, zoals hoek‑ of soepele punten. Het vervangt niet het opdrachttype. Gebruik een curve‑punttype voor het curve‑voorbeeld hieronder, en een hoek‑punttype voor de rechte segmenten.

Padcoördinaten zijn genormaliseerd naar de dia‑afmetingen: een X‑verplaatsing van 0.25 staat voor een kwart van de dia‑breedte, niet voor 0.25 punten. Positieve Y loopt naar beneden. Absolute opdrachten geven posities in het padcoördinatensysteem; relatieve opdrachten geven offsets ten opzichte van de huidige positie. Dit staat los van [getOrigin](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/getorigin/), dat het referentiekader van het pad selecteert, en [getPathEditMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioneffect/getpatheditmode/), dat bepaalt hoe het pad beweegt wanneer de vorm wordt verplaatst.

### **Maak een rechte pad**

Creëer een bewegingsgedrag met een startpunt, één recht segment, en een eind‑opdracht. [MotionPath::add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpath/add/) neemt het opdrachttype, zijn punten, het punttype, en een relatieve‑coördinaat‑vlag.

De start‑opdracht legt (0, 0) vast, en de lijn eindigt op (0.25, 0), waardoor het pad een horizontale verplaatsing van een kwart van de dia‑breedte krijgt. De eind‑opdracht heeft geen coördinaten. Zodra het pad is toegewezen, verbindt het toevoegen van het bewegingsgedrag aan het effect dat pad met de rechthoek.

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

`motion.pptx` bevat één bewegingsgedrag met drie pad‑opdrachten. De volgende bewerkingsvoorbeelden gebruiken deze bekende structuur.

### **Vergelijk absolute en relatieve coördinaten**

Deze twee padobjecten beschrijven dezelfde route. De absolute opdracht eindigt op (0.3, 0.1); de relatieve opdracht voegt (0.1, 0.1) toe aan de huidige positie, (0.2, 0).

Beide paden starten op dezelfde positie. Voor de relatieve lijn voeg je de X‑ en Y‑offsets toe aan de huidige positie om het eindpunt te verkrijgen; voor de absolute lijn lees je het eindpunt rechtstreeks. Het omwisselen van de vlag zonder de coördinaten te converteren zou een andere route beschrijven.

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

Ken een van beide paden toe aan een bewegingsgedrag om het in een presentatie te gebruiken. Het laatste Booleaanse argument selecteert relatieve coördinaten voor die opdracht.

### **Vervang een lijn door een curve**

Open `motion.pptx` en vervang de lijn‑opdracht door een kubieke curve. Geef eerst de twee controle‑punten op, daarna het eindpunt.

De startpositie wordt geleverd door de vorige opdracht. De eerste twee punten vormen de curve, terwijl het derde het eindpunt is; ze zijn geen drie opeenvolgende bestemmingen. Het tegelijk bijwerken van het opdrachttype, het punt‑bewerkings­type en de puntarray houdt het segment consistent met zijn nieuwe geometrie.

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

Het pad in `curve.pptx` heeft nog steeds drie opdrachten; de middelste opdracht definieert nu een curve.

## **Inspecteer en bewerk een opgeslagen pad**

Elke [MotionCmdPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncmdpath/) geeft [getPoints](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncmdpath/getpointstype/), en [isRelative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motioncmdpath/isrelative/) bloot. De volgende voorbeelden gebruiken het bekende drie‑opdracht‑pad in `motion.pptx`. Voor willekeurige invoer, lokaliseer het beoogde effect en controleer opdrachttypes en punt‑aantallen vóór bewerking op index.

### **Lees opdrachten en coördinaten**

Lees het pad zonder het te wijzigen. Eind‑ en sluit‑lus‑opdrachten hebben geen punten nodig, dus sta een null‑puntarray toe.

De uitvoer koppelt elk numeriek opdrachttype aan zijn relatieve‑coördinaat‑vlag voordat de punten worden opgesomd. Dit laat je een eindpunt onderscheiden van een offset voordat je het pad aanpast. Een curve zou drie punten opsommen, terwijl de rechte lijn in dit bestand er slechts één list.

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

De lijst bevat een startpunt, een absolute lijn die eindigt op (0.25, 0), en een eind‑opdracht.

### **Wijzig een eindpunt**

Open `motion.pptx` en vervang de puntarray van de lijn om het eindpunt te verplaatsen.

In het invoer‑bestand is index 0 de start‑opdracht en index 1 de lijn. Het vervangen van het enkele punt van de lijn wijzigt de bestemming zonder het opdrachttype, de timing, of de positie in de collectie te wijzigen. Omdat de opdracht absolute coördinaten gebruikt, specificeert het nieuwe paar een positie i.p.v. een toegevoegde offset.

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

De lijn in `motion-endpoint.pptx` eindigt op (0.4, 0.1); het originele bestand blijft ongewijzigd.

### **Vervang een segment**

Gebruik [insert](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpath/insert/) en [removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/motionpath/removeat/) om de lijn in `motion.pptx` te vervangen. Invoegen verschuift de oude lijn naar index 2.

Dit demonstreert het vervangen van een opdrachtobject in plaats van het bewerken van de bestaande coördinaten. Na invoegen bevat de collectie tijdelijk de start‑opdracht, de nieuwe lijn, de oude lijn, en de eind‑opdracht. Het verwijderen van index 2 gooit de oude lijn weg en laat de nieuwe route intact.

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

Het opgeslagen pad heeft nog steeds drie opdrachten, met de nieuwe lijn die eindigt op (0.2, 0.1) en de eind‑opdracht als laatste.

## **Wijzig en verifieer een bestaand gedrag**

Wanneer de index van het gedrag onbekend is, selecteer het op type. Dit voorbeeld opent `rotation.pptx`, vindt de [RotationEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/rotationeffect/), wijzigt de hoek, en controleert de opgeslagen waarde na opnieuw te hebben geopend.

De type‑controle laat de lus gedragss die geen rotaties zijn overslaan. De tweede laad bewerkt het opgeslagen bestand in een aparte presentatie‑object, zodat de vergelijking de persistente data controleert in plaats van de nog in het geheugen aanwezige waarde. Dit voorbeeld gaat nog steeds uit van het bekende effect als eerste in de hoofd‑reeks; selecteren op type lokt het correcte effect niet op in een willekeurige presentatie.

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

De uitvoer is `Rotation preserved: true`. Pas hetzelfde type‑checkpatroon toe op andere gedragingen. Voor een volledige behouds‑controle, vergelijk de doelvorm, het effect, de gedragstypen en -volgorde, timing, en padopdrachten. Gebruik een numerieke toleranties voor zwevend‑kommagetallen. Voor een presentatie met een onbekende animatie‑structuur, zie [Lees vorm‑animaties](/slides/nl/php-java/shape-animation/#read-shape-animations) voor doorlopen van hoofd‑ en interactieve reeksen.

## **Gedrag volgorde, presets en afspelen**

De volgorde in [BehaviorCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behaviorcollection/) is de opgeslagen volgorde van de bewerkingen van een effect. Het is geen afspeellijst waarin elk gedrag automatisch wacht op het voorgaande. Timing en het omvattende effect bepalen de planning. Gedragingen kunnen overlappen, en bewerkingen op dezelfde eigenschap kunnen interacteren via [additive](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behavioradditivetype/) en [accumulation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/behavioraccumulatetype/) instellingen. Gebruik niet alleen herschikking van de collectie om “verplaatsen, dan roteren” te plannen; gebruik expliciete timing of gescheiden effecten zoals beschreven in [Vormanimatie](/slides/nl/php-java/shape-animation/).

De [getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/gettype/) en [getSubtype](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/getsubtype/) van het effect beschrijven het preset. Ze vormen geen volledige beschrijving van een bewerkt gedrag‑boom. Kies het preset en subtype vóór het aanpassen van gedragingen: het wijzigen van het preset kan de collectie opnieuw opbouwen en je aangepaste bewerkingen verwijderen. Bijvoorbeeld, het wijzigen van een aangepast Spin‑effect naar Fade kan het rotatie‑gedrag vervangen door set‑ en filter‑gedragingen. Inspecteer de collectie opnieuw na het wijzigen van een preset of subtype. Het leegmaken van preset‑gedragingen kan ook zichtbaarheid‑ of initialisatie‑bewerkingen verwijderen die het preset nodig heeft. De voorbeelden gebruiken opzettelijk zichtbare vormen en vervangen de gedragingen; ze herbouwen niet elk preset‑implementatie.

## **Formaatcompatibiliteit**

Een bewaarde gedrag‑boom garandeert geen identieke weergave in elke viewer of export‑renderer. Controleer de opgeslagen data en de gerenderde uitvoer afzonderlijk.

| Formaat of output | Te verifiëren |
| --- | --- |
| PPTX | Gebruik als primair formaat voor deze voorbeelden. Open opnieuw om de bewerkbare gedrag‑boom te verifiëren, en controleer vervolgens het afspelen in de beoogde PowerPoint‑versie. |
| PPT | Het legacy‑binaire formaat kan afwijken van PPTX. Test een afzonderlijke opslaan‑en‑opnieuw‑open‑cyclus en het afspelen; concludeer niet dat elke aangepaste combinatie wordt ondersteund op basis van een geslaagde PPTX‑output. |
| PDF, PNG, JPEG en andere statische dia‑afbeeldingen | Bevatten een statische dia‑representatie, geen afspeelbare gedragstijdlijn of gegarandeerd definitief animatie‑frame. |
| [HTML5](/slides/nl/php-java/export-to-html5/) | Kan ondersteunde animaties afspelen wanneer vorm‑animatie is ingeschakeld in de exportopties. Test aangepaste combinaties in de browser. |
| [Animated GIF](/slides/nl/php-java/convert-powerpoint-to-animated-gif/) | Slaat gerenderde frames op, niet bewerkbare gedragingen of klik‑gestuurde interactie. Controleer de werkelijk gerenderde beweging. |
| [Video](/slides/nl/php-java/convert-powerpoint-to-video/) | Rendert animatie‑frames en codeert ze als video. Ondersteuning is beperkt tot de renderer‑[ondersteunde animaties en effecten](/slides/nl/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); opdrachten en interactieve gebeurtenissen worden geen bewerkbare tijdlijn. |

## **FAQ**

**Waarom bevat mijn effect gedragingen voordat ik er een toevoeg?**

Het aanmaken van een vooraf gedefinieerd effect kan de onderliggende bewerkingen genereren. Inspecteer ze voordat je beslist of je het preset wilt uitbreiden of de gedragingen wilt vervangen.

**Zorgt het verplaatsen van een gedrag naar het begin ervoor dat het als eerste wordt afgespeeld?**

Niet per se. De volgorde van de collectie is geen vervanging voor timing. Controleer vertragingen, duur en interacties tussen bewerkingen op dezelfde eigenschap.

**Waarom heeft een eind‑opdracht geen punten?**

Het markeert het einde van het pad en heeft geen coördinaten nodig. Let op een null‑puntarray bij het inspecteren van een pad dat uit een bestand is gelezen.

**Is een succesvolle ronde‑trip voldoende om het afspelen te bevestigen?**

Nee. Opnieuw openen bevestigt alleen de behoud van de eigenschappen die je hebt gecontroleerd. Test de diavoorstelling‑speler of de geanimeerde export apart om het visuele gedrag te bevestigen.