---
title: Tillämpa formanimationer i presentationer med PHP
linktitle: Formanimation
type: docs
weight: 60
url: /sv/php-java/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägg till animation
- hämta animation
- extrahera animation
- lägg till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan appliceras på texter, bilder, former eller [diagram](https://docs.aspose.com/slides/sv/php-java/animated-charts/). De ger liv åt presentationer eller deras beståndsdelar.

## **Varför använda animationer i presentationer?**

* kontrollera informationsflödet
* betona viktiga punkter
* öka intresse eller engagemang hos din publik
* göra innehållet lättare att läsa, ta in eller bearbeta
* rikta dina läsares eller tittares uppmärksamhet mot viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter i kategorierna **entrance**, **exit**, **emphasis** och **motion paths**.

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer under namnrymden `Aspose.Slides.Animation`,
* Aspose.Slides erbjuder över **150 animationseffekter** under enumen [EffectType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effecttype). Dessa effekter är i princip samma (eller motsvarande) effekter som används i PowerPoint.

## **Applicera animation på en textruta**

Aspose.Slides för PHP via Java låter dig applicera animation på texten i en form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en referens till en bild via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
4. Lägg till text till `AutoShape`'s [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/#getTextFrame).
5. Hämta en huvudsekvens av effekter.
6. Lägg till en animationseffekt till [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
7. Använd metoden `TextAnimation.setBuildType` och värdet från `BuildType`-enumerationen.
8. Skriv presentationen till disk som en PPTX-fil.

Den här PHP-koden visar hur du applicerar `Fade`-effekten på AutoShape och ställer in textanimationen till värdet *By 1st Level Paragraphs*:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Lägger till ny AutoShape med text
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Hämtar huvudsekvensen för bilden.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Lägger till Fade-animeringseffekt på formen
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Animerar formens text efter första nivåens stycken
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Sparar PPTX-filen till disk
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 
Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/). Se [**Animerad Text**](/slides/sv/php-java/animated-text/).
{{% /alert %}} 

## **Applicera animation på en PictureFrame**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en bildreferens via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe) på bilden.
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt till [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe).
6. Skriv presentationen till disk som en PPTX-fil.

Den här PHP-koden visar hur du applicerar `Fly`-effekten på en bildram:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil.
  $pres = new Presentation();
  try {
    # Laddar bild som ska läggas till i presentationens bildsamling
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Lägger till bildram på bilden
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Hämtar huvudsekvensen för bilden.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Lägger till Fly Från Vänster-animeringseffekt på bildramen
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Sparar PPTX-filen till disk
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicera animation på en form**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klassen.
2. Hämta en bildreferens via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
4. Lägg till en snedkantad [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) (när detta objekt klickas spelas animationen upp).
5. Skapa en sekvens av effekter på snedkantformen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX-fil.

Den här PHP-koden visar hur du applicerar `PathFootball` (path football)-effekten på en form:

```php
  # Instansierar en Presentation-klass som representerar en PPTX-fil.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Skapar PathFootball-effekt för befintlig form från början.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Lägger till PathFootBall-animeringseffekt
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Skapar någon form av "button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Skapar en sekvens av effekter för denna knapp.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Skapar en anpassad användarväg. Vårt objekt kommer endast att flyttas efter att knappen har klickats.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Lägger till kommandon för förflyttning eftersom den skapade vägen är tom.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Skriver PPTX-filen till disk
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hämta animationseffekterna som applicerats på en form**

Följande exempel visar hur du använder metoden `getEffectsByShape` från klassen [Sequence](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sequence/) för att hämta alla animationseffekter som applicerats på en form.

**Exempel 1: Hämta animationseffekter som applicerats på en form på en normal bild**

Tidigare lärde du dig hur man lägger till animationseffekter på former i PowerPoint-presentationer. Följande exempel kod visar hur du hämtar effekterna som applicerats på den första formen på den första normala bilden i presentationen `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Hämtar huvudanimationsekvensen för bilden.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Hämtar den första formen på den första bilden.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Hämtar animationseffekter som applicerats på formen.
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

**Exempel 2: Hämta alla animationseffekter, inklusive de som ärvs från platshållare**

Om en form på en normal bild har platshållare som finns på layoutbilden och/eller mastern, och animationseffekter har lagts till dessa platshållare, så kommer alla effekter för formen att spelas upp under bildspelet, inklusive de som ärvs från platshållarna.

Anta att vi har en PowerPoint-presentationfil `sample.pptx` med en bild som endast innehåller en sidfotform med texten "Made with Aspose.Slides" och effekten **Random Bars** är applicerad på formen.

![Bildform animationseffekt](slide-shape-animation.png)

Anta också att effekten **Split** är applicerad på sidfotens platshållare på **layout**-bilden.

![Layoutform animationseffekt](layout-shape-animation.png)

Och slutligen är **Fly In**-effekten applicerad på sidfotens platshållare på **master**-bilden.

![Masterform animationseffekt](master-shape-animation.png)

Följande exempel kod visar hur du använder metoden `getBasePlaceholder` från klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) för att komma åt formens platshållare och hämta animationseffekterna som applicerats på sidfotformen, inklusive de som ärvs från platshållare placerade på layout- och mastern.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Hämta animationseffekter för formen på den normala bilden.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Hämta animationseffekter för platshållaren på layoutbilden.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Hämta animationseffekter för platshållaren på mastern.
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

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Flyg, Botten
Type: 134, subtype: 45            // Split, VertikalIn
Type: 126, subtype: 22            // RandomBars, Horisontell
```

## **Ändra timingmetoder för animationseffekter**

Aspose.Slides för PHP via Java låter dig ändra timing‑egenskaper för en animationseffekt.

Detta är Animation Timing-fönstret i Microsoft PowerPoint:

![exempel1_bild](shape-animation.png)

- PowerPoint Timing **Start**-rullgardinsmenyn motsvarar metoden [Timing::getTriggerType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/#getTriggerType).
- PowerPoint Timing **Duration** motsvarar metoden [Timing::getDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/#getDuration). Varaktigheten för en animation (i sekunder) är den totala tid som animationen tar för att slutföra ett cykel.
- PowerPoint Timing **Delay** motsvarar metoden [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/timing/#getTriggerDelayTime).

Så här ändrar du egenskaperna för Effect Timing:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden du behöver med hjälp av metoden [Effect::getTiming](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#getTiming).
3. Spara den modifierade PPTX-filen.

Den här PHP-koden demonstrerar operationen:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Hämtar huvudsekvensen för bilden.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Hämtar den första effekten i huvudsekvensen.
    $effect = $sequence->get_Item(0);
    # Ändrar effektens TriggerType till att starta vid klick
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Ändrar effektens varaktighet
    $effect->getTiming()->setDuration(3.0);
    # Ändrar effektens TriggerDelayTime
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Sparar PPTX-filen till disk
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ljud för animationseffekt**

Aspose.Slides tillhandahåller dessa metoder för att låta dig arbeta med ljud i animationseffekter: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Lägg till ljud för animationseffekt**

Den här PHP-koden visar hur du lägger till ett ljud för animationseffekten och stoppar det när nästa effekt startar:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Lägger till ljud i presentationens ljudsamling
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
    # Hämtar huvudsekvensen för bilden.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Hämtar den första effekten i huvudsekvensen
    $firstEffect = $sequence->get_Item(0);
    # Kontrollerar om effekten har "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Lägger till ljud för den första effekten
      $firstEffect->setSound($effectSound);
    }
    # Hämtar den första interaktiva sekvensen för bilden.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Sätter flaggan för effekten "Stop previous sound"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Skriver PPTX-filen till disk
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Extrahera ljud för animationseffekt**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
2. Hämta en bildreferens via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den inbäddade [setSound(IAudio value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) för varje animationseffekt.

Den här PHP-koden visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Hämtar huvudsekvensen för bilden.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extraherar effektljudet i bytearray
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Efter animation**

Aspose.Slides för PHP via Java låter dig ändra egenskapen After animation för en animationseffekt.

Detta är Animation Effect-fönstret och den utökade menyn i Microsoft PowerPoint:

![exempel1_bild](shape-after-animation.png)

PowerPoint Effect **After animation**-rullgardinsmenyn motsvarar dessa metoder: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setAfterAnimationType) metoden som beskriver After animation‑typen:
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** motsvarar typen [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/#DoNotDim) (standard efter animationstyp);
  * PowerPoint **Hide After Animation** motsvarar typen [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** motsvarar typen [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setAfterAnimationColor) metoden som definierar ett färgformat för after animation. Denna metod fungerar tillsammans med typen [AfterAnimationType::Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/afteranimationtype/#Color). Om du ändrar typen till en annan så rensas after animation‑färgen.

Den här PHP-koden visar hur du ändrar en after animation-effekt:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Hämtar den första effekten i huvudsekvensen
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändrar efteranimationstypen till Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Sätter färgen för efteranimationens dimning
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Skriver PPTX-filen till disk
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animera text**

Aspose.Slides tillhandahåller dessa metoder för att låta dig arbeta med en animationseffects *Animate text*-block:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setAnimateTextType) som beskriver typen av animera text för effekten. Formens text kan animeras:
  * Alla på en gång ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/sv/php-java/aspose.slides/animatetexttype/#AllAtOnce) typ)
  * Per ord ([AnimateTextType::ByWord](https://reference.aspose.com/slides/sv/php-java/aspose.slides/animatetexttype/#ByWord) typ)
  * Per bokstav ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setDelayBetweenTextParts) sätter en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procent av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Apply](#apply-animation-to-shape) eller hämta animationseffekten.
2. Använd metoden [setBuildType(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textanimation/#setBuildType) och värdet [BuildType::AsOneObject](https://reference.aspose.com/slides/sv/php-java/aspose.slides/buildtype/#AsOneObject) för att stänga av *By Paragraphs*-animationsläget.
3. Ställ in nya värden med hjälp av metoderna [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setAnimateTextType) och [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Spara den modifierade PPTX-filen.

Den här PHP-koden demonstrerar operationen:

```php
  # Instansierar en presentationsklass som representerar en presentationsfil.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Hämtar den första effekten i huvudsekvensen
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Ändrar effektens textanimations typ till "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Ändrar effektens animera text typ till "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Ställer in fördröjning mellan ord till 20 % av effektens varaktighet
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Skriver PPTX-filen till disk
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Export to HTML5](/slides/sv/php-java/export-to-html5/) och aktivera de [options](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/) som ansvarar för animationer av [shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimateshapes/) och [transition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/html5options/setanimatetransitions/) . Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar ändring av z-ordning (lagerordning) för former animationen?**

Animation och teckningsordning är oberoende: en effekt styr timing och typ av framträdande/försvinnande, medan [z-order](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getzorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är det allmänna PowerPoint‑beteendet; Aspose.Slides effekter‑och‑former-modellen följer samma logik.)

**Finns det begränsningar när animationer konverteras till video för vissa effekter?**

I allmänhet är [animations are supported](/slides/sv/php-java/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med biblioteksversionen.