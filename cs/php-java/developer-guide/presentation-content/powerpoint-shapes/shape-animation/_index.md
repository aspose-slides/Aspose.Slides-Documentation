---
title: Použití animací tvarů v prezentacích pomocí PHP
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/php-java/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit animace tvarů v PowerPoint prezentacích pomocí Aspose.Slides pro PHP via Java. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](https://docs.aspose.com/slides/cs/php-java/animated-charts/). Oživí prezentace nebo jejich jednotlivé části.

## **Proč používat animace v prezentacích?**

Pomocí animací můžete  

* řídit tok informací  
* zdůraznit důležité body  
* zvýšit zájem nebo zapojení publika  
* učinit obsah snáze čitelným nebo stravitelným  
* upoutat pozornost čtenářů či diváků na důležité části v prezentaci  

PowerPoint nabízí mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**.  

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné pro práci s animacemi v namespace `Aspose.Slides.Animation`,  
* Aspose.Slides nabízí více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako efekty v PowerPointu.  

## **Použít animaci na TextBox**

Aspose.Slides for PHP via Java umožňuje aplikovat animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).  
2. Získejte odkaz na snímek podle jeho indexu.  
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).  
4. Přidejte text do [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#getTextFrame) objektu `AutoShape`.  
5. Získejte hlavní sekvenci efektů.  
6. Přidejte animační efekt k [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).  
7. Použijte metodu `TextAnimation.setBuildType` a hodnotu z enumerace `BuildType`.  
8. Uložte prezentaci na disk jako soubor PPTX.  

Tento PHP kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Přidá nový AutoShape s textem
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Získá hlavní sekvenci snímku.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Přidá efekt Fade animace k tvaru
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Animuje text tvaru pomocí 1. úrovně odstavců
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Uloží soubor PPTX na disk
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Kromě aplikace animací na text můžete také použít animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/). Viz [**Animovaný text**](/slides/cs/php-java/animated-text/).  

{{% /alert %}} 

## **Použít animaci na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).  
2. Získejte odkaz na snímek podle jeho indexu.  
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe) na snímku.  
4. Získejte hlavní sekvenci efektů.  
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe).  
6. Uložte prezentaci na disk jako soubor PPTX.  

Tento PHP kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
  $pres = new Presentation();
  try {
    # Načte obrázek, který bude přidán do kolekce obrázků prezentace
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá rámeček obrázku na snímek
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Získá hlavní sekvenci snímku.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Přidá efekt Fly zleva animace k rámečku obrázku
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Uloží soubor PPTX na disk
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Použít animaci na Shape**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).  
2. Získejte odkaz na snímek podle jeho indexu.  
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).  
4. Přidejte zkosený [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) (při kliknutí na tento objekt se spustí animace).  
5. Vytvořte sekvenci efektů pro zkosený tvar.  
6. Vytvořte vlastní `UserPath`.  
7. Přidejte příkazy pro pohyb po `UserPath`.  
8. Uložte prezentaci na disk jako soubor PPTX.  

Tento PHP kód ukazuje, jak aplikovat efekt `PathFootball` (cesta fotbal) na tvar:

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvoří efekt PathFootball pro existující tvar od začátku.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Přidá animaci PathFootBall.
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Vytvoří nějaký "button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Vytvoří sekvenci efektů pro toto tlačítko.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Vytvoří vlastní uživatelskou cestu. Náš objekt bude přesunut až po kliknutí na tlačítko.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Zapíše soubor PPTX na disk
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získat animační efekty aplikované na Shape**

Následující příklady ukazují, jak použít metodu `getEffectsByShape` ze třídy [Sequence](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získat animační efekty aplikované na tvar na běžném snímku**

Dříve jste se naučili, jak přidávat animační efekty k tvarům v PowerPoint prezentacích. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním běžném snímku v prezentaci `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Získá hlavní animační sekvenci snímku.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Získá první tvar na prvním snímku.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Získá animační efekty aplikované na tvar.
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

**Příklad 2: Získat všechny animační efekty, včetně těch zděděných z placeholderů**

Pokud má tvar na běžném snímku placeholdery, které jsou součástí rozložení nebo hlavní šablony, a na tyto placeholdery byly přidány animační efekty, pak se během prezentace přehrají všechny efekty tvaru, včetně těch zděděných z placeholderů.

Předpokládejme, že máme soubor PowerPoint prezentace `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tento tvar je aplikován efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Dále předpokládejme, že na placeholder zápatí v **rozložení** je aplikován efekt **Split**.

![Layout shape animation effect](layout-shape-animation.png)

A nakonec je na placeholder zápatí v **hlavní** šabloně aplikován efekt **Fly In**.

![Master shape animation effect](master-shape-animation.png)

Níže je ukázkový kód, který používá metodu `getBasePlaceholder` ze třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných v rozložení a hlavní šabloně.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Získá animační efekty tvaru na běžném snímku.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Get animation effects of the placeholder on the layout slide.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Get animation effects of the placeholder on the master slide.
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

Výstup:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Bottom
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Změna časování animačního efektu**

Aspose.Slides for PHP via Java umožňuje měnit vlastnosti Timing animačního efektu.

Toto je panel **Animation Timing** v Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto odpovídají mezi PowerPoint Timing a [Effect Timing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#getTiming) vlastnostmi:

- Rozbalovací seznam **Start** v PowerPoint Timing odpovídá metodě [Timing::getTriggerType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/#getTriggerType).  
- **Duration** v PowerPoint Timing odpovídá metodě [Timing::getDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/#getDuration). Délka animace (v sekundách) je celkový čas potřebný k dokončení jednoho cyklu.  
- **Delay** v PowerPoint Timing odpovídá metodě [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/timing/#getTriggerDelayTime).  

Takto měníte vlastnosti Effect Timing:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.  
2. Nastavte nové hodnoty pomocí metody [Effect::getTiming](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#getTiming).  
3. Uložte upravený soubor PPTX.  

Tento PHP kód demonstruje operaci:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Získá hlavní sekvenci snímku.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Získá první efekt hlavní sekvence.
    $effect = $sequence->get_Item(0);
    # Změní TriggerType efektu na spuštění kliknutím
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Změní dobu trvání efektu
    $effect->getTiming()->setDuration(3.0);
    # Změní TriggerDelayTime efektu
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Uloží soubor PPTX na disk
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje následující metody pro práci se zvuky v animačních efektech:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Přidat zvuk animačního efektu**

Tento PHP kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Přidá audio do kolekce audio prezentace
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
    # Získá hlavní sekvenci snímku.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Získá první efekt hlavní sekvence
    $firstEffect = $sequence->get_Item(0);
    # Kontroluje efekt pro "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Přidá zvuk pro první efekt
      $firstEffect->setSound($effectSound);
    }
    # Získá první interaktivní sekvenci snímku.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Nastaví příznak efektu "Stop previous sound"
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Zapíše soubor PPTX na disk
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Extrahovat zvuk animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).  
2. Získejte odkaz na snímek podle jeho indexu.  
3. Získejte hlavní sekvenci efektů.  
4. Extrahujte vložený [setSound(IAudio value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) zvuk z každého animačního efektu.  

Tento PHP kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Získá hlavní sekvenci snímku.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrahuje zvuk efektu do pole bajtů
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Po animaci**

Aspose.Slides for PHP via Java umožňuje měnit vlastnost **After animation** animačního efektu.

Toto je panel **Animation Effect** a rozšířené menu v Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam **After animation** v PowerPoint odpovídá těmto metodám:  

- metoda [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setAfterAnimationType) popisuje typ po‑animace:  
  * **More Colors** v PowerPoint odpovídá typu [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** odpovídá typu [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ);  
  * **Hide After Animation** odpovídá typu [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- metoda [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setAfterAnimationColor) definuje formát barvy po‑animace. Tato metoda funguje ve spojení s typem [AfterAnimationType::Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/afteranimationtype/#Color). Pokud typ změníte na jiný, barva po‑animace bude vymazána.  

Tento PHP kód ukazuje, jak změnit efekt po‑animace:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Získá první efekt hlavní sekvence
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Změní typ po‑animace na Barvu
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Nastaví barvu ztmavení po‑animace
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Zapíše soubor PPTX na disk
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animovat text**

Aspose.Slides poskytuje následující metody pro práci s blokem *Animate text* animačního efektu:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setAnimateTextType) popisuje typ animace textu. Text tvaru může být animován:  
  - Vše najednou ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/cs/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Po slovech ([AnimateTextType::ByWord](https://reference.aspose.com/slides/cs/php-java/aspose.slides/animatetexttype/#ByWord))  
  - Po písmenech ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setDelayBetweenTextParts) nastavuje zpoždění mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu, záporná hodnota udává zpoždění v sekundách.  

Takto můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.  
2. Použijte metodu [setBuildType(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textanimation/#setBuildType) a hodnotu [BuildType::AsOneObject](https://reference.aspose.com/slides/cs/php-java/aspose.slides/buildtype/#AsOneObject) pro vypnutí režimu *By Paragraphs*.  
3. Nastavte nové hodnoty pomocí metod [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setAnimateTextType) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Uložte upravený soubor PPTX.  

Tento PHP kód demonstruje operaci:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Získá první efekt hlavní sekvence
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Změní typ textové animace efektu na "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Změní typ animace textu efektu na "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Nastaví zpoždění mezi slovy na 20% trvání efektu
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Zapíše soubor PPTX na disk
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak mohu zajistit, že se animace zachovají při publikování prezentace na web?**

[Exportovat do HTML5](/slides/cs/php-java/export-to-html5/) a povolit [možnosti](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/) zodpovědné za animace [tvarů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimateshapes/) a [přechodů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/html5options/setanimatetransitions/). Běžné HTML animace nespuští, HTML5 ano.  

**Jak ovlivňuje změna z‑orderu (pořadí vrstev) tvarů animaci?**

Pořadí animace a kreslení jsou nezávislé: efekt řídí časování a typ objevení/odstranění, zatímco [z‑order](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getzorderposition/) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model Aspose.Slides efekty‑a‑tvary funguje podle stejné logiky.)  

**Existují omezení při převodu animací do videa pro některé efekty?**

Obecně jsou [animace podporovány](/slides/cs/php-java/convert-powerpoint-to-video/), ale v rizikových případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučujeme testovat s konkrétními efekty a verzí knihovny.