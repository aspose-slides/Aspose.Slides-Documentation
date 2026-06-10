---
title: Alakzatanimációk alkalmazása prezentációkban JavaScript segítségével
linktitle: Alakzatanimáció
type: docs
weight: 60
url: /hu/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzatanimációkat PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js via Java segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](/slides/hu/nodejs-java/animated-charts/) lehet alkalmazni. Életet lehelnek a prezentációkba vagy azok összetevőibe.

## **Miért használjunk animációkat a prezentációkban?**

* az információáramlás irányítása
* fontos pontok kiemelése
* növeli a közönség érdeklődését vagy részvételét
* a tartalmat könnyebben olvashatóvá, elsajátíthatóvá vagy feldolgozhatóvá teszi
* felhívja az olvasók vagy nézők figyelmét a prezentáció fontos részeire

A PowerPoint számos beállítást és eszközt kínál az animációkhoz és animációs hatásokhoz a **beérkezés**, **kilépés**, **kiemelés** és **mozgáspályák** kategóriákban.

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az animációkkal való munkához szükséges osztályokat és típusokat a `Aspose.Slides.Animation` névtérben,
* Az Aspose.Slides több mint **150 animációs hatást** biztosít a [EffectType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttype) felsorolásban. Ezek a hatások lényegében ugyanazok (vagy ekvivalensak), mint a PowerPointban használtak.

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for Node.js via Java lehetővé teszi animáció alkalmazását egy alakzat szövegére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá egy `rectangle` [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape)-t.
4. Adjon hozzá szöveget a [AutoShape.addTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) segítségével.
5. Szerezze meg a fő hatássorozatot.
6. Adjon animációs hatást a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape)-hez.
7. Hívja meg a `TextAnimation.setBuildType` metódust a `BuildType` felsorolásból származó értékkel.
8. Írja a prezentációt a lemezre PPTX fájlként.

Ez a Javascript kód megmutatja, hogyan alkalmazza a `Fade` hatást az AutoShape-re, és hogyan állítja be a szöveganimációt a *By 1st Level Paragraphs* értékre:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Új AutoShape-et ad hozzá szöveggel
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Lekéri a dia fő szekvenciáját.
    var sequence = sld.getTimeline().getMainSequence();
    // Fade animációs hatást ad a alakzathoz
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animálja az alakzat szövegét az első szintű bekezdések szerint
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Mentse a PPTX fájlt a lemezre
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

A szövegre alkalmazott animációk mellett animációkat alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph) elemre is. Lásd a [**Animated Text**](/slides/hu/nodejs-java/animated-text/)-t.

{{% /alert %}} 

## **Animáció alkalmazása képkeretre**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá vagy szerezzen be egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe) elemet a dián.
4. Szerezze meg a fő hatássorozatot.
5. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe)-hez.
6. Írja a prezentációt a lemezre PPTX fájlként.

Ez a Javascript kód megmutatja, hogyan alkalmazza a `Fly` hatást egy képkeretre:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
var pres = new aspose.slides.Presentation();
try {
    // Képet betölt, amely a prezentáció képkollekciójába kerül.
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Képkeretet ad hozzá a diára.
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Lekéri a dia fő szekvenciáját.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Fly from Left animációs hatást ad a képkerethez.
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Elmenti a PPTX fájlt a lemezre.
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján.
3. Adjon hozzá egy `rectangle` [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape)-t.
4. Adjon hozzá egy `Bevel` [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape) elemet (amikor erre az objektumra kattintanak, az animáció lejátszódik).
5. Hozzon létre egy hatássorozatot a bevel alakzaton.
6. Hozzon létre egy egyéni `UserPath`-t.
7. Adjon parancsokat a `UserPath`-ra való mozgáshoz.
8. Írja a prezentációt a lemezre PPTX fájlként.

Ez a Javascript kód megmutatja, hogyan alkalmazza a `PathFootball` (path football) hatást egy alakzatra:

```javascript
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // PathFootball hatást hoz létre egy létező alakzatra a semmiből.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Adds the PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Létrehoz egyfajta "gombot".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Létrehoz egy hatássorozatot ehhez a gombhoz.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Egy egyéni felhasználói útvonalat hoz létre. Objektumunk csak a gomb megnyomása után lesz mozgatva.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Parancsokat ad hozzá a mozgáshoz, mivel a létrehozott útvonal üres.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // A PPTX fájlt lemezre írja
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Az alakzatra alkalmazott animációs hatások lekérdezése**

A következő példák megmutatják, hogyan használhatja a `getEffectsByShape` metódust a [Sequence](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/) osztályból az alakzatra alkalmazott összes animációs hatás lekérdezéséhez.

**Példa 1: Animációs hatások lekérdezése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan adjunk animációs hatásokat az alakzatokhoz PowerPoint prezentációkban. A következő mintakód megmutatja, hogyan kaphatja meg az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban alkalmazott hatásokat.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő animációs szekvenciáját.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri az első alakzatot az első dián.
    var shape = firstSlide.getShapes().get_Item(0);

    // Lekéri az alakzatra alkalmazott animációs hatásokat.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Példa 2: Az összes animációs hatás lekérdezése, beleértve a helyőrzőkből örökölt hatásokat is**

Ha egy alakzat egy normál dián helyőrzőkkel rendelkezik, amelyek a elrendezési dián és/vagy a mesterdián találhatók, és ezekhez a helyőrzőkhöz animációs hatásokat adtak hozzá, akkor a diavetítés során az alakzat minden hatása lejátszásra kerül, beleértve a helyőrzőkből örökölt hatásokat is.

Tételezzük fel, hogy van egy `sample.pptx` nevű PowerPoint prezentációfájlunk, amely egyetlen diát tartalmaz, azon csak egy lábléc alakzat a "Made with Aspose.Slides" szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Slide shape animation effect](slide-shape-animation.png)

És tegyük fel, hogy a **Split** hatás alkalmazva van a lábléc helyőrzőre a **layout** dián.

![Layout shape animation effect](layout-shape-animation.png)

Végül, a **Fly In** hatás legyen alkalmazva a lábléc helyőrzőre a **master** dián.

![Master shape animation effect](master-shape-animation.png)

A következő mintakód megmutatja, hogyan használhatja a `getBasePlaceholder` metódust a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) osztályból a formahelyőrzők eléréséhez és a lábléc alakzatra alkalmazott animációs hatások lekérdezéséhez, beleértve a layout és master diákon található helyőrzőkből örökölt hatásokat is.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Repülés, Alul
Type: 134, subtype: 45            // Szétválás, Függőlegesen be
Type: 126, subtype: 22            // Véletlenszerű sávok, Vízszintes
```

## **Animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for Node.js via Java lehetővé teszi az animációs hatás időzítési tulajdonságainak módosítását.

Ez a Animáció Időzítés ablaktábla a Microsoft PowerPointban:

![example1_image](shape-animation.png)

Az alábbiak a megfelelő kapcsolatok a PowerPoint időzítés és a [Effect.Timing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Effect#getTiming--) tulajdonságok között:

- A PowerPoint időzítés **Start** legördülő listája megfelel a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Timing#getTriggerType--) tulajdonságnak.
- A PowerPoint időzítés **Duration** megfelel a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Timing#getDuration--) tulajdonságnak. Egy animáció időtartama (másodpercben) a teljes idő, amely szükséges az animáció egy ciklusának befejezéséhez.
- A PowerPoint időzítés **Delay** megfelel a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) tulajdonságnak.

Így módosíthatja az Effect Timing tulajdonságokat:

1. [Apply](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Effect#getTiming--) tulajdonságokhoz.
3. Mentse el a módosított PPTX fájlt.

Ez a Javascript kód demonstrálja a műveletet:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Lekéri a dia fő szekvenciáját.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Lekéri a fő szekvencia első hatását.
    var effect = sequence.get_Item(0);
    // Módosítja a hatás TriggerType-ot, hogy kattintásra induljon
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Módosítja a hatás időtartamát
    effect.getTiming().setDuration(3.0);
    // Módosítja a hatás TriggerDelayTime értékét
    effect.getTiming().setTriggerDelayTime(0.5);
    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animációs hatás hangja**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja a hangok kezeléséhez animációs hatásokban:

- [setSound(IAudio value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animációs hatás hangjának hozzáadása**

Ez a Javascript kód megmutatja, hogyan adjon hozzá animációs hatás hangot, és hogyan állítsa le azt, amikor a következő hatás elkezdődik:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Audio hozzáadása a prezentáció audio gyűjteményéhez
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Lekéri a dia fő szekvenciáját.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Lekéri a fő szekvencia első hatását
    var firstEffect = sequence.get_Item(0);
    // Ellenőrzi a hatást "No Sound" esetére
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Hangot ad hozzá az első hatáshoz
        firstEffect.setSound(effectSound);
    }
    // Lekéri a dia első interaktív szekvenciáját.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Beállítja a hatás "Stop previous sound" jelzőjét
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // A PPTX fájlt lemezre írja
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen be egy dia hivatkozást az indexe alapján. 
3. Szerezze meg a fő hatássorozatot. 
4. Nyissa ki a [setSound(IAudio value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) minden animációs hatásba beágyazott hangot.

Ez a Javascript kód megmutatja, hogyan nyerje ki az animációs hatásba beágyazott hangot:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lekéri a dia fő szekvenciáját.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Kinyeri a hatás hangját bájt tömbbe
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Animáció után**

Az Aspose.Slides for Node.js via Java lehetővé teszi az animációs hatás After animation tulajdonságának módosítását.

Ez a Animation Effect panel és a kibővített menü a Microsoft PowerPointban:

![example1_image](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő lista a következő tulajdonságoknak felel meg:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) metódus, amely leírja az After animation típust;
  * A PowerPoint **More Colors** a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#Color) típusnak felel meg;
  * A PowerPoint **Don't Dim** listaelem a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) típusnak felel meg (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** elem a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) típusnak felel meg;
  * A PowerPoint **Hide on Next Mouse Click** elem a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) típusnak felel meg;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) metódus, amely meghatározza az after animation színformátumot. Ez a metódus együtt működik a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#Color) típussal. Ha a típust másikra módosítja, az after animation szín törlésre kerül.

Ez a Javascript kód megmutatja, hogyan változtasson egy after animation hatást:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Lekéri a fő szekvencia első hatását
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Módosítja az after animation típust Színre
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Beállítja az after animation sötétítési színét
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szöveg animálása**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja egy animációs hatás *Animate text* blokkjének kezeléséhez:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) amely leírja a hatás *animate text* típusát. Az alakzat szövege animálható:
  * Egyszerre ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) típus)
  * Szó szerint ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/animatetexttype/#ByWord) típus)
  * Betűként ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/animatetexttype/#ByLetter) típus)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) beállít egy késleltetést az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték a késleltetést másodpercben határozza meg.

Így módosíthatja az Effect Animate text tulajdonságokat:

1. [Apply](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Állítsa a [setBuildType(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) metódust a [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/buildtype/#AsOneObject) értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.
3. Állítson be új értékeket a [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) és a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) tulajdonságokhoz.
4. Mentse el a módosított PPTX fájlt.

Ez a Javascript kód demonstrálja a műveletet:

```javascript
// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Lekéri a fő szekvencia első hatását
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Módosítja a hatás szöveganimáció típusát "As One Object"-ra
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Módosítja a hatás animált szöveg típusát "By word"-ra
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    firstEffect.setDelayBetweenTextParts(20.0);
    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre publikálásakor?**

[Export to HTML5](/slides/hu/nodejs-java/export-to-html5/) és engedélyezze az [options](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/) beállításokat, amelyek a [shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/setanimateshapes/) és [transition](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/setanimatetransitions/) animációkért felelnek. A sima HTML nem játssza le a diák animációit, míg a HTML5 igen.

**Hogyan befolyásolja az alakzatok z-rend (réteg sorrend) módosítása az animációt?**

Az animáció és a rajzolási sorrend független egymástól: egy hatás szabályozza az időzítést és a megjelenés/eltűnés típusát, míg a [z-order](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getzorderposition/) határozza meg, mi takarja meg mi­t. A látható eredményt a kettő kombinációja határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatások‑és‑alakzatok modellje ugyanazt a logikát követi.)

**Vannak korlátozások az animációk videóra konvertálásakor bizonyos hatások esetén?**

Általánosságban elmondható, hogy a [animations are supported](/slides/hu/nodejs-java/convert-powerpoint-to-video/) (animációk támogatottak), de ritka esetekben vagy bizonyos hatásoknál eltérően jelenhetnek meg. Javasolt a használt hatásokkal és a könyvtár verziójával tesztelni.