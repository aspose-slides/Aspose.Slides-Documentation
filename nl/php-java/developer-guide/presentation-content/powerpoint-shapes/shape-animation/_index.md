---
title: Shape-animaties toepassen in presentaties met PHP
linktitle: Shape-animatie
type: docs
weight: 60
url: /nl/php-java/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe je vormanimaties kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java. Val op!"
---
## **Inleiding**

Animaties zijn visuele effecten die kunnen worden toegepast op tekst, afbeeldingen, vormen of [grafieken](https://docs.aspose.com/slides/nl/php-java/animated-charts/). Ze geven levensenergie aan presentaties of hun onderdelen.

## **Waarom animaties gebruiken in presentaties?**

Met animaties kun je  

* de informatiestroom beheersen  
* belangrijke punten benadrukken  
* de belangstelling of deelname van je publiek vergroten  
* de inhoud makkelijker leesbaar, verteerbaar of verwerkbaar maken  
* de aandacht van je lezers of kijkers vestigen op belangrijke delen in een presentatie  

PowerPoint biedt veel opties en tools voor animaties en animatie‑effecten binnen de categorieën **ingang**, **exit**, **accent** en **bewegingspaden**.

## **Animaties in Aspose.Slides**

* Aspose.Slides levert de klassen en types die je nodig hebt om met animaties te werken onder de `Aspose.Slides.Animation` namespace,  
* Aspose.Slides biedt meer dan **150 animatie‑effecten** via de [EffectType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effecttype) enumeratie. Deze effecten zijn in feite dezelfde (of equivalente) effecten die in PowerPoint worden gebruikt.

## **Animatie toepassen op een TextBox**

Aspose.Slides for PHP via Java stelt je in staat om animatie toe te passen op de tekst in een vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Verkrijg een dia‑referentie via de index.  
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe.  
4. Voeg tekst toe aan `AutoShape`‑s [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/#getTextFrame).  
5. Haal de hoofd­reeks van effecten op.  
6. Voeg een animatie‑effect toe aan [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/).  
7. Gebruik de `TextAnimation.setBuildType`‑methode en de waarde uit de `BuildType`‑enumeratie.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze PHP‑code laat zien hoe je het `Fade`‑effect op AutoShape toepast en de tekstanimatie instelt op *By 1st Level Paragraphs*:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Voegt een nieuwe AutoShape toe met tekst
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Haalt de hoofdrij van de dia op.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Voegt een Fade animatie effect toe aan vorm
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Animeert vormtekst per eerste niveau alinea's
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Slaat het PPTX bestand op schijf
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Naast het toepassen van animaties op tekst kun je ook animaties toepassen op een enkele [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/). Zie **[Geanimeerde tekst](/slides/nl/php-java/animated-text/)**.

{{% /alert %}} 

## **Animatie toepassen op een PictureFrame**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Verkrijg een dia‑referentie via de index.  
3. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe) toe aan de dia of haal er één op.  
4. Haal de hoofd­reeks van effecten op.  
5. Voeg een animatie‑effect toe aan [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe).  
6. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze PHP‑code laat zien hoe je het `Fly`‑effect op een picture frame toepast:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
  $pres = new Presentation();
  try {
    # Laadt afbeelding die moet worden toegevoegd aan de afbeeldingscollectie van de presentatie
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt picture frame toe aan de dia
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Haalt de hoofdrij van de dia op.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Voegt een Fly‑van‑links‑animatie‑effect toe aan picture frame
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Slaat het PPTX‑bestand op schijf
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animatie toepassen op een Shape**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Verkrijg een dia‑referentie via de index.  
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe.  
4. Voeg een schuine [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe (wanneer dit object wordt aangeklikt, wordt de animatie afgespeeld).  
5. Maak een reeks effecten voor de schuine vorm.  
6. Maak een aangepaste `UserPath`.  
7. Voeg commando’s toe om naar de `UserPath` te bewegen.  
8. Schrijf de presentatie naar schijf als een PPTX‑bestand.  

Deze PHP‑code laat zien hoe je het `PathFootball`‑effect (voetbalpad) op een vorm toepast:

```php
  # Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Maakt PathFootball-effect voor bestaande vorm vanaf nul.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Voegt het PathFootBall-animatie-effect toe
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Maakt een soort "knop".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Maakt een reeks effecten voor deze knop.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Maakt een aangepast gebruikerspad. Ons object wordt alleen verplaatst nadat de knop wordt aangeklikt.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Voegt opdrachten toe voor verplaatsen omdat het aangemaakte pad leeg is.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Schrijft het PPTX-bestand naar schijf
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **De animatie‑effecten op een vorm opvragen**

De volgende voorbeelden laten zien hoe je de `getEffectsByShape`‑methode van de [Sequence](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/) klasse gebruikt om alle animatie‑effecten op te halen die op een vorm zijn toegepast.

**Voorbeeld 1: Animatie‑effecten opvragen die op een vorm op een normale dia zijn toegepast**

Eerder leerde je hoe je animatie‑effecten aan vormen in PowerPoint‑presentaties kunt toevoegen. De volgende voorbeeldcode laat zien hoe je de effecten opvraagt die op de eerste vorm op de eerste normale dia in de presentatie `AnimExample_out.pptx` zijn toegepast.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Haalt de hoofd‑animatierij van de dia op.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Haalt de eerste vorm op van de eerste dia.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Haalt de animatie‑effecten op die op de vorm zijn toegepast.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Voorbeeld 2: Alle animatie‑effecten opvragen, inclusief die van aanduidingsobjecten**

Als een vorm op een normale dia aanduidingsobjecten heeft die zich op de layout‑dia en/of master‑dia bevinden, en er zijn animatie‑effecten aan deze aanduidingsobjecten toegevoegd, dan worden alle effecten van de vorm afgespeeld tijdens de diavoorstelling, inclusief de geërfde effecten van de aanduidingsobjecten.

Stel, we hebben een PowerPoint‑presentatiebestand `sample.pptx` met één dia die alleen een voettekst‑vorm bevat met de tekst “Made with Aspose.Slides” en het **Random Bars**‑effect is op die vorm toegepast.

![Dia‑vorm animatie‑effect](slide-shape-animation.png)

Stel bovendien dat het **Split**‑effect op de voettekst‑placeholder op de **layout**‑dia is toegepast.

![Layout‑vorm animatie‑effect](layout-shape-animation.png)

En tenslotte is het **Fly In**‑effect op de voettekst‑placeholder op de **master**‑dia toegepast.

![Master‑vorm animatie‑effect](master-shape-animation.png)

De volgende voorbeeldcode laat zien hoe je de `getBasePlaceholder`‑methode van de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) klasse gebruikt om de placeholders van de vorm te benaderen en de animatie‑effecten op de voettekst‑vorm op te halen, inclusief de geërfde effecten van placeholders op de layout‑ en master‑dia’s.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Haal de animatie-effecten op van de vorm op de normale dia.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Haal de animatie-effecten op van de placeholder op de layout-dia.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Haal de animatie-effecten op van de placeholder op de master-dia.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vliegen, Onderkant
Type: 134, subtype: 45            // Splitsen, VerticaalIn
Type: 126, subtype: 22            // RandomBars, Horizontaal
```

## **Methoden om de timing van animatie‑effecten te wijzigen**

Aspose.Slides for PHP via Java laat je toe de Timing‑eigenschappen van een animatie‑effect te wijzigen.

Dit is het Animation Timing‑paneel in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Dit zijn de overeenkomsten tussen PowerPoint Timing en de eigenschappen van [Effect Timing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#getTiming):

- De PowerPoint Timing **Start**‑keuzelijst komt overeen met de methode [Timing::getTriggerType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/#getTriggerType).  
- De PowerPoint Timing **Duration** komt overeen met de methode [Timing::getDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/#getDuration). De duur van een animatie (in seconden) is de totale tijd die een animatie nodig heeft om één cyclus te voltooien.  
- De PowerPoint Timing **Delay** komt overeen met de methode [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/timing/#getTriggerDelayTime).

Zo wijzig je de Effect Timing‑eigenschappen:

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Stel nieuwe waarden in via de methode [Effect::getTiming](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#getTiming).  
3. Sla het gewijzigde PPTX‑bestand op.  

Deze PHP‑code demonstreert de bewerking:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Haalt de hoofdrij van de dia op.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Haalt het eerste effect van de hoofdrij op.
    $effect = $sequence->get_Item(0);
    # Verandert effect TriggerType zodat het start bij klik
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Verandert effect Duur
    $effect->getTiming()->setDuration(3.0);
    # Verandert effect TriggerDelayTime
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Slaat het PPTX‑bestand op schijf
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animatie‑effect‑geluid**

Aspose.Slides biedt de volgende methoden om met geluiden in animatie‑effecten te werken:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Een animatie‑effect‑geluid toevoegen**

Deze PHP‑code laat zien hoe je een animatie‑effect‑geluid toevoegt en stopt wanneer het volgende effect begint:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Voegt audio toe aan de audio‑collectie van de presentatie
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Haalt de hoofdrij van de dia op.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Haalt het eerste effect van de hoofdrij op
    $firstEffect = $sequence->get_Item(0);
    # Controleert het effect op "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Voegt geluid toe aan het eerste effect
      $firstEffect->setSound($effectSound);
    }
    # Haalt de eerste interactieve reeks van de dia op.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Stelt de vlag "Stop previous sound" van het effect in
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Slaat het PPTX‑bestand op schijf
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Een animatie‑effect‑geluid extraheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.  
2. Verkrijg een dia‑referentie via de index.  
3. Haal de hoofd­reeks van effecten op.  
4. Extraheer het ingebedde [setSound(IAudio value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) uit elk animatie‑effect.  

Deze PHP‑code laat zien hoe je het geluid dat in een animatie‑effect is ingebed, extraheert:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Haalt de hoofdrij van de dia op.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extraheert het effectgeluid in een byte-array
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Na de animatie**

Aspose.Slides for PHP via Java laat je de eigenschap After animation van een animatie‑effect wijzigen.

Dit is het Animation Effect‑paneel en het uitgebreide menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

De PowerPoint **After animation**‑keuzelijst komt overeen met de volgende methoden:  

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setAfterAnimationType) methode die het type After animation beschrijft:  
  * PowerPoint **More Colors** komt overeen met het type [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** komt overeen met het type [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/#DoNotDim) (standaard after‑animation‑type);  
  * PowerPoint **Hide After Animation** komt overeen met het type [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** komt overeen met het type [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setAfterAnimationColor) methode die een kleurformaat voor after‑animation definieert. Deze methode werkt samen met het type [AfterAnimationType::Color](https://reference.aspose.com/slides/nl/php-java/aspose.slides/afteranimationtype/#Color). Als je het type wijzigt, wordt de after‑animation‑kleur gewist.

Deze PHP‑code laat zien hoe je een after‑animation‑effect wijzigt:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Haalt het eerste effect van de hoofdrij op
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Verandert het after animation type naar Kleur
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Stelt de after animation dimkleur in
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Slaat het PPTX bestand op schijf
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tekst animeren**

Aspose.Slides biedt de volgende methoden om met het *Animate text*‑blok van een animatie‑effect te werken:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setAnimateTextType) die het type tekstanimatie van het effect beschrijft. De vormtekst kan geanimeerd worden:  
  - Alles tegelijk ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/nl/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Per woord ([AnimateTextType::ByWord](https://reference.aspose.com/slides/nl/php-java/aspose.slides/animatetexttype/#ByWord))  
  - Per letter ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setDelayBetweenTextParts) stelt een vertraging in tussen de geanimate tekstonderdelen (woorden of letters). Een positieve waarde geeft een percentage van de effectduur aan. Een negatieve waarde geeft de vertraging in seconden aan.

Zo wijzig je de Effect Animate‑text‑eigenschappen:

1. [Pas](#apply-animation-to-shape) het animatie‑effect toe of haal het op.  
2. Gebruik de [setBuildType(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textanimation/#setBuildType) methode en de waarde [BuildType::AsOneObject](https://reference.aspose.com/slides/nl/php-java/aspose.slides/buildtype/#AsOneObject) om de *By Paragraphs*‑animatiemodus uit te schakelen.  
3. Stel nieuwe waarden in via de methoden [setAnimateTextType(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setAnimateTextType) en [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Sla het gewijzigde PPTX‑bestand op.  

Deze PHP‑code demonstreert de bewerking:

```php
  # Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Haalt het eerste effect van de hoofdrij op
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Verandert het effect Tekstanimatie‑type naar "Als één object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Verandert het effect Animeren‑tekst type naar "Per woord"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Stelt de vertraging tussen woorden in op 20% van de effectduur
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Slaat het PPTX‑bestand op schijf
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hoe zorg ik ervoor dat animaties behouden blijven bij het publiceren van de presentatie op het web?**

[Export to HTML5](/slides/nl/php-java/export-to-html5/) en schakel de [opties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/html5options/) in die verantwoordelijk zijn voor animaties van [shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/html5options/setanimateshapes/) en [transition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/html5options/setanimatetransitions/). eenvoudige HTML speelt geen dia‑animaties af, terwijl HTML5 dat wel doet.

**Hoe beïnvloedt het wijzigen van de z‑order (laagvolgorde) van vormen de animatie?**

Animatie‑ en tekenvolgorde zijn onafhankelijk: een effect bepaalt het tijdstip en het type verschijnen/verdwijnen, terwijl [z‑order](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getzorderposition/) bepaalt wat wat bedekt. Het zichtbare resultaat wordt bepaald door hun combinatie. (Dit is het algemene PowerPoint‑gedrag; het Aspose.Slides‑effect‑en‑vormmodel volgt dezelfde logica.)

**Zijn er beperkingen bij het omzetten van animaties naar video voor bepaalde effecten?**

In het algemeen worden [animaties ondersteund](/slides/nl/php-java/convert-powerpoint-to-video/), maar zeldzame gevallen of specifieke effecten kunnen anders gerenderd worden. Het wordt aanbevolen om de door jou gebruikte effecten en de bibliotheekversie eerst te testen.