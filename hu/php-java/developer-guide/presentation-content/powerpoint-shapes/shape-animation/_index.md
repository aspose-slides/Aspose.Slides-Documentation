---
title: Alakzatanimációk alkalmazása prezentációkban PHP használatával
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/php-java/shape-animation/
keywords:
- alakzat
- animáció
- hatás
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- hatás hozzáadása
- hatás lekérése
- hatás kinyerése
- hatás hangja
- animáció alkalmazása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzatanimációkat PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](https://docs.aspose.com/slides/hu/php-java/animated-charts/) lehet alkalmazni. Életet lehelnek a prezentációkba vagy azok elemeihez.

## **Miért használjunk animációkat a prezentációkban?**

* az információáramlás irányítása
* a fontos pontok kiemelése
* az érdeklődés vagy a közönség részvételének növelése
* a tartalom könnyebb olvasása, befogadása vagy feldolgozása
* a hallgatóság vagy nézők figyelmének felhívása a prezentáció fontos részeire

A PowerPoint számos lehetőséget és eszközt kínál az animációk és animációs hatások **belépés**, **kilépés**, **kiemelés** és **mozgáspálya** kategóriákban.

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az osztályokat és típusokat, amelyekre az animációk kezeléséhez a `Aspose.Slides.Animation` névtérben szükség van,
* Az Aspose.Slides több mint **150 animációs hatást** kínál a [EffectType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effecttype) felsorolásban. Ezek a hatások lényegében ugyanazok (vagy ekvivalensak), mint a PowerPointban használtak.

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy animációt alkalmazzunk egy alakzat szövegére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).
4. Adjon szöveget a `AutoShape` [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#getTextFrame) részéhez.
5. Szerezze meg a fő hatássorozatot.
6. Adjon animációs hatást a [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).
7. Használja a `TextAnimation.setBuildType` módszert és a `BuildType` felsorolás értékét.
8. Írja a prezentációt lemezre PPTX fájlként.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a `Fade` hatást az AutoShape-re, és állíthatja be a szöveganimációt *By 1st Level Paragraphs* értékre:

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Új AutoShape-et ad hozzá szöveggel
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Lekéri a dia fő szekvenciáját.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Fade animációs hatást ad az alakzathoz
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Az alakzat szövegét az 1. szintű bekezdések szerint animálja
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # A PPTX fájlt lemezre menti
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

A szövegre való animációk alkalmazása mellett animációkat is alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/). Lásd a [**Animated Text**](/slides/hu/php-java/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása képkockára**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá vagy szerezzen meg egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe) elemet a dián.
4. Szerezze meg a fő hatássorozatot.
5. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe).
6. Mentse a prezentációt lemezre PPTX fájlként.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a `Fly` hatást egy képkockára:

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
  $pres = new Presentation();
  try {
    # Betölti a képet, amelyet a prezentáció képkollekciójába kell hozzáadni.
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Képkockát ad a diára
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Lekéri a dia fő szekvenciáját.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Fly animációs hatást balról ad a képkockához
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # A PPTX fájlt lemezre menti
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/).
4. Adjon hozzá egy rézsút [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) (amikor ezt az objektumot kattintják, az animáció lejátszódik).
5. Hozzon létre egy hatássorozatot a rézsút alakzaton.
6. Hozzon létre egy egyéni `UserPath`-t.
7. Adjon parancsokat a `UserPath` felé mozgatáshoz.
8. Mentse a prezentációt lemezre PPTX fájlként.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a `PathFootball` (path football) hatást egy alakzatra:

```php
  # Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Új PathFootball hatást hoz létre egy meglévő alakzatra a semmiből.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # PathFootBall animációs hatást ad hozzá
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Valamilyen "gombot" hoz létre.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Hatássorozatot hoz létre ehhez a gombhoz.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Egy egyéni felhasználói útvonalat hoz létre. Az objektum csak a gomb megnyomása után mozdul el.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Mozgási parancsokat ad hozzá, mivel a létrehozott útvonal üres.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # A PPTX fájlt lemezre írja
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Az alakzatra alkalmazott animációs hatások lekérdezése**

Az alábbi példák bemutatják, hogyan használhatja a `getEffectsByShape` metódust a [Sequence](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sequence/) osztályból, hogy lekérje az alakzatra alkalmazott összes animációs hatást.

**Példa 1: Animációs hatások lekérése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan adjon animációs hatásokat alakzatokhoz PowerPoint prezentációkban. Az alábbi mintakód bemutatja, hogyan kérheti le az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Lekéri a dia fő animációs szekvenciáját.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Lekéri az első alakzatot az első dián.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Lekéri az alakzatra alkalmazott animációs hatásokat.
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

**Példa 2: Az összes animációs hatás lekérése, beleértve a helyőrzőkből örököltet is**

Ha egy alakzat egy normál dián helyőrzőkkel rendelkezik, amelyek a layout diához és/vagy a mesterdiához tartoznak, és animációs hatásokat adtak ezekhez a helyőrzőkhöz, akkor az alakzat összes hatása lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat is.

Tegyük fel, hogy van egy `sample.pptx` PowerPoint prezentációfájlunk, amely egyetlen diát tartalmaz, ahol csak egy lábléc alakzat van a „Made with Aspose.Slides” szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Slide shape animation effect](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás van alkalmazva a lábléc helyőrzőre a **layout** diához.

![Layout shape animation effect](layout-shape-animation.png)

Végül a **Fly In** hatás van alkalmazva a lábléc helyőrzőre a **master** dián.

![Master shape animation effect](master-shape-animation.png)

Az alábbi mintakód bemutatja, hogyan használhatja a `getBasePlaceholder` metódust a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályból a shape helyőrzők eléréséhez, és hogyan kaphatja meg a lábléc alakzatra alkalmazott animációs hatásokat, beleértve a layout és master diákon elhelyezkedő helyőrzőkből örökölt hatásokat.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Lekéri a normál dián lévő alakzat animációs hatásait.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Lekéri a layout dián lévő helyőrző animációs hatásait.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Lekéri a master dián lévő helyőrző animációs hatásait.
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
Type: 47, subtype: 2              // Repülés, Alul
Type: 134, subtype: 45            // Szétvágás, Függőleges be
Type: 126, subtype: 22            // Véletlen sávok, Vízszintes
```

## **Animációs hatás időzítési módszerek módosítása**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy módosítsa egy animációs hatás időzítési tulajdonságait.

Ez a Microsoft PowerPoint Animation Timing ablaka:

![example1_image](shape-animation.png)

Az alábbiak a megfelelő kapcsolatok a PowerPoint időzítés és az [Effect Timing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#getTiming) tulajdonságok között:

- A PowerPoint időzítés **Start** legördülő listája megfelel a [Timing::getTriggerType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/#getTriggerType) metódusnak.
- A PowerPoint időzítés **Duration** megfelel a [Timing::getDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/#getDuration) metódusnak. Egy animáció időtartama (másodpercben) a teljes idő, amely a hatás egy ciklusának befejezéséhez szükséges.
- A PowerPoint időzítés **Delay** megfelel a [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/hu/php-java/aspose.slides/timing/#getTriggerDelayTime) metódusnak.

Így módosíthatja az Effect Timing tulajdonságokat:

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Állítson be új értékeket a [Effect::getTiming](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#getTiming) metódus használatával.
3. Mentse a módosított PPTX fájlt.

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Lekéri a dia fő szekvenciáját.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Lekéri a fő szekvencia első hatását.
    $effect = $sequence->get_Item(0);
    # Módosítja a hatás TriggerType értékét kattintásra indításra
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Módosítja a hatás időtartamát
    $effect->getTiming()->setDuration(3.0);
    # Módosítja a hatás TriggerDelayTime értékét
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # A PPTX fájlt lemezre menti
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animációs hatás hangja**

Az Aspose.Slides a következő metódusokat biztosítja a hangok animációs hatásokban való kezeléséhez: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animációs hatás hangjának hozzáadása**

Ez a PHP kód bemutatja, hogyan adjon hozzá egy animációs hatás hangot, és állítsa le azt, amikor a következő hatás elindul:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Hozzáad egy hangot a prezentáció audio gyűjteményéhez
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
    # Lekéri a dia fő szekvenciáját.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Lekéri a fő szekvencia első hatását
    $firstEffect = $sequence->get_Item(0);
    # Ellenőrzi a hatást a "No Sound" esetére
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Hozzáad hangot az első hatáshoz
      $firstEffect->setSound($effectSound);
    }
    # Lekéri a dia első interaktív szekvenciáját.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Beállítja a hatás "Stop previous sound" jelzőjét
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # A PPTX fájlt lemezre írja
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján. 
3. Szerezze meg a fő hatássorozatot. 
4. Vonja ki a [setSound(IAudio value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) minden animációs hatáshoz beágyazott hangot.

Ez a PHP kód bemutatja, hogyan nyerheti ki egy animációs hatásba beágyazott hangot:

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Lekéri a dia fő szekvenciáját.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Kicsomagolja a hatás hangját bájt tömbbe
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Animáció után**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy módosítsa egy animációs hatás After animation (animáció után) tulajdonságát.

Ez a Microsoft PowerPoint Animation Effect panel és kiterjesztett menü:

![example1_image](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő listája megfelel az alábbi metódusoknak: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setAfterAnimationType) metódus, amely leírja az After animation típust:
  * A PowerPoint **More Colors** a [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/#Color) típussal egyezik;
  * A PowerPoint **Don't Dim** eleme a [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/#DoNotDim) típussal egyezik (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** eleme a [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) típussal egyezik;
  * A PowerPoint **Hide on Next Mouse Click** eleme a [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) típussal egyezik;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setAfterAnimationColor) metódus, amely meghatározza az after animation színformátumot. Ez a metódus a [AfterAnimationType::Color](https://reference.aspose.com/slides/hu/php-java/aspose.slides/afteranimationtype/#Color) típussal együtt működik. Ha a típust másikra változtatja, az after animation szín törlődik.

Ez a PHP kód bemutatja, hogyan módosíthat egy after animation hatást:

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Lekéri a fő szekvencia első hatását
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Megváltoztatja az after animation típusát Színre
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Beállítja az after animation halványítási színét
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # A PPTX fájlt lemezre írja
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szöveg animálása**

Az Aspose.Slides a következő metódusokat biztosítja az animációs hatás *Animate text* blokkjának kezeléséhez:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setAnimateTextType) metódus, amely leírja az animációs szöveg típusát a hatáson. Az alakzat szöveget lehet animálni:
  * Egyszerre ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/hu/php-java/aspose.slides/animatetexttype/#AllAtOnce) típus)
  * Szó szerint ([AnimateTextType::ByWord](https://reference.aspose.com/slides/hu/php-java/aspose.slides/animatetexttype/#ByWord) típus)
  * Betű szerint ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/animatetexttype/#ByLetter) típus)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setDelayBetweenTextParts) metódus, amely késleltetést állít be az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték késleltetést másodpercben.

Így módosíthatja az Effect Animate text tulajdonságokat:

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Használja a [setBuildType(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textanimation/#setBuildType) metódust és a [BuildType::AsOneObject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/buildtype/#AsOneObject) értéket az *By Paragraphs* animációs mód kikapcsolásához.
3. Állítson be új értékeket a [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setAnimateTextType) és a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/effect/#setDelayBetweenTextParts) metódusok használatával.
4. Mentse a módosított PPTX fájlt.

```php
  # Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Lekéri a fő szekvencia első hatását
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Megváltoztatja a hatás szöveganimáció típusát "As One Object" értékre
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Megváltoztatja a hatás Animate text típusát "By word" értékre
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    $firstEffect->setDelayBetweenTextParts(20.0);
    # A PPTX fájlt lemezre menti
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hogyan biztosíthatom, hogy az animációk megmaradnak a prezentáció webre publikálásakor?**

[Export to HTML5](/slides/hu/php-java/export-to-html5/) és engedélyezze a [beállításokat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/) , amelyek a [shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimateshapes/) és a [transition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/html5options/setanimatetransitions/) animációkat kezelik. A sima HTML nem játssza le a diák animációit, míg a HTML5 igen.

**Hogyan befolyásolja az alakzatok z-sorrendjének (réteg sorrend) módosítása az animációt?**

Az animáció és a rajzolási sorrend független egymástól: egy hatás szabályozza az időzítést és a megjelenés/eltűnés típusát, míg a [z-order](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getzorderposition/) meghatározza, mi takarja meg mi‑t. A látható eredményt a kombinációjuk határozza meg. (Ez a Microsoft PowerPoint általános viselkedése; az Aspose.Slides hatás‑alakzat modellje ugyanazt a logikát követi.)

**Általánosságban a animációk támogatottak, de ritka esetekben vagy bizonyos hatások esetén másként jelenhetnek meg. Ajánlott tesztelni a használt hatásokat és a könyvtár verziójával.**