---
title: Tillämpa formanimationer i presentationer med JavaScript
linktitle: Formanimation
type: docs
weight: 60
url: /sv/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar formanimationer i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js via Java. Stick ut!"
---
## **Introduktion**

Animationer är visuella effekter som kan tillämpas på texter, bilder, former eller [diagram](/slides/sv/nodejs-java/animated-charts/). De ger liv åt presentationer eller dess beståndsdelar.

## **Varför använda animationer i presentationer?**

* styr informationens flöde
* betona viktiga punkter
* öka intresse eller deltagande bland din publik
* göra innehållet lättare att läsa, assimilera eller bearbeta
* rikta läsarnas eller tittarnas uppmärksamhet till viktiga delar i en presentation

PowerPoint erbjuder många alternativ och verktyg för animationer och animationseffekter inom kategorierna **entré**, **utgång**, **betoning** och **rörelsespår**.

## **Animationer i Aspose.Slides**

* Aspose.Slides tillhandahåller de klasser och typer du behöver för att arbeta med animationer i `Aspose.Slides.Animation`‑namnrymden,
* Aspose.Slides tillhandahåller över **150 animationseffekter** under [EffectType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effecttype)‑enumerationen. Dessa effekter är i princip samma (eller motsvarande) effekter som används i PowerPoint.

## **Tillämpa animation på TextBox**

Aspose.Slides för Node.js via Java låter dig tillämpa animation på texten i en form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slidreferens via dess index.
3. Lägg till en `rectangle` [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape).
4. Lägg till text med [AutoShape.addTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Hämta huvudsekvensen av effekter.
6. Lägg till en animationseffekt till [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape).
7. Anropa `TextAnimation.setBuildType`‑metoden med värdet från `BuildType`‑enumerationen.
8. Skriv presentationen till disk som en PPTX‑fil.

Den här Javascript‑koden visar hur du applicerar `Fade`‑effekten på AutoShape och sätter textanimationen till *By 1st Level Paragraphs*-värdet:

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Lägger till en ny AutoShape med text
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Hämtar huvudsekvensen för bilden.
    var sequence = sld.getTimeline().getMainSequence();
    // Lägger till Fade‑animationseffekt till formen
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animera formens text efter första nivåns stycken
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Spara PPTX‑filen till disk
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Förutom att applicera animationer på text kan du också applicera animationer på ett enskilt [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph). Se [**Animerad text**](/slides/sv/nodejs-java/animated-text/).

{{% /alert %}} 

## **Tillämpa animation på PictureFrame**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slides referens via dess index.
3. Lägg till eller hämta en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe) på bilden.
4. Hämta huvudsekvensen av effekter.
5. Lägg till en animationseffekt till [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe).
6. Skriv presentationen till disk som en PPTX‑fil.

Den här Javascript‑koden visar hur du applicerar `Fly`‑effekten på en bildram:

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil.
var pres = new aspose.slides.Presentation();
try {
    // Ladda bild som ska läggas till i presentationens bildsamling
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Lägger till bildram på bilden
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Hämtar huvudsekvensen för bilden.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Lägger till Fly‑från‑vänster‑animationseffekt till bildramen
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Spara PPTX‑filen till disk
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tillämpa animation på Shape**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slides referens via dess index.
3. Lägg till en `rectangle` [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape).
4. Lägg till en `Bevel` [AutoShape] (när detta objekt klickas spelas animationen).
5. Skapa en sekvens av effekter på bevelformen.
6. Skapa en anpassad `UserPath`.
7. Lägg till kommandon för att flytta till `UserPath`.
8. Skriv presentationen till disk som en PPTX‑fil.

Den här Javascript‑koden visar hur du applicerar `PathFootball`‑effekten på en form:

```javascript
// Instansiera en Presentation-klass som representerar en PPTX-fil.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Skapar PathFootball-effekt för befintlig form från början.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Lägger till PathFootBall-animations­effekten
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Skapar någon form av "knapp".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Skapar en sekvens av effekter för den här knappen.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Skapar en anpassad användarstig. Vårt objekt kommer bara att flyttas efter att knappen har klickats.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Lägger till kommandon för rörelse eftersom den skapade stigen är tom.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Skriver PPTX-filen till disk
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hämta animationseffekterna som tillämpats på Shape**

Följande exempel visar hur du använder `getEffectsByShape`‑metoden från [Sequence](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/)‑klassen för att hämta alla animationseffekter som har tillämpats på en form.

**Exempel 1: Hämta animationseffekter som tillämpats på en form på en normal slide**

Tidigare lärde du dig hur man lägger till animationseffekter på former i PowerPoint‑presentationer. Följande exempel kod visar hur du hämtar effekterna som tillämpats på den första formen på den första normala bilden i presentationen `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Hämtar huvudanimationssekvensen för bilden.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Hämtar den första formen på den första bilden.
    var shape = firstSlide.getShapes().get_Item(0);

    // Hämtar animationseffekter som tillämpats på formen.
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

**Exempel 2: Hämta alla animationseffekter, inklusive de som är ärvda från platshållare**

Om en form på en normal bild har platshållare som finns på layout‑bilden och/eller huvudd bilden, och animationseffekter har lagts till dessa platshållare, så kommer alla effekter för formen att spelas upp under bildspelet, inklusive de som är ärvda från platshållarna.

Låt oss säga att vi har en PowerPoint‑presentation `sample.pptx` med en bild som bara innehåller en sidfotform med texten "Made with Aspose.Slides" och **Random Bars**‑effekten är tillämpad på formen.

![Slide shape animation effect](slide-shape-animation.png)

Antag också att **Split**‑effekten är tillämpad på sidfotens platshållare på **layout**‑bilden.

![Layout shape animation effect](layout-shape-animation.png)

Och slutligen är **Fly In**‑effekten tillämpad på sidfotens platshållare på **master**‑bilden.

![Master shape animation effect](master-shape-animation.png)

Följande exempel kod visar hur du använder `getBasePlaceholder`‑metoden från [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)‑klassen för att komma åt formens platshållare och hämta animationseffekterna som tillämpats på sidfotformen, inklusive de som är ärvda från platshållare på layout‑ och master‑bilderna.

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
Type: 47, subtype: 2              // Flyg, Botten
Type: 134, subtype: 45            // Split, VertikalIn
Type: 126, subtype: 22            // RandomBars, Horisontell
```

## **Ändra tidsinställningarna för animationseffekter**

Aspose.Slides för Node.js via Java låter dig ändra tidsegenskaperna för en animationseffekt.

Detta är panelen Animation Timing i Microsoft PowerPoint:

![example1_image](shape-animation.png)

Detta är motsvarigheterna mellan PowerPoint Timing och [Effect.Timing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Effect#getTiming--)‑egenskaper:

- PowerPoint Timing **Start**‑rullgardinslistan motsvarar [Effect.Timing.TriggerType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Timing#getTriggerType--)‑egenskapen.
- PowerPoint Timing **Duration** motsvarar [Effect.Timing.Duration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Timing#getDuration--)‑egenskapen. Tidslängden för en animation (i sekunder) är den totala tid det tar för animationen att genomföra en cykel.
- PowerPoint Timing **Delay** motsvarar [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--)‑egenskapen.

Så här ändrar du egenskaperna för Effect Timing:

1. [Tillämpa](#apply-animation-to-shape) eller hämta animationseffekten.
2. Ställ in nya värden för de [Effect.Timing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Effect#getTiming--)‑egenskaper du behöver.
3. Spara den ändrade PPTX‑filen.

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Hämtar huvudsekvensen för bilden.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Hämtar den första effekten i huvudsekvensen.
    var effect = sequence.get_Item(0);
    // Ändrar effektens TriggerType till att starta vid klick
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Ändrar effektens varaktighet
    effect.getTiming().setDuration(3.0);
    // Ändrar effektens TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5);
    // Sparar PPTX-filen till disk
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ljud för animationseffekt**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med ljud i animationseffekter: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Lägg till ljud för animationseffekt**

Den här Javascript‑koden visar hur du lägger till ett ljud för en animationseffekt och stoppar det när nästa effekt startar:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Lägger till ljud i presentationens ljudsamling
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Hämtar huvudsekvensen för bilden.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Hämtar den första effekten i huvudsekvensen
    var firstEffect = sequence.get_Item(0);
    // Kontrollerar om effekten har "Inget ljud"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Lägger till ljud för den första effekten
        firstEffect.setSound(effectSound);
    }
    // Hämtar den första interaktiva sekvensen för bilden.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Sätter flaggan "Stoppa tidigare ljud" för effekten
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Skriver PPTX-filen till disk
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Extrahera ljud för animationseffekt**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta en slides referens via dess index. 
3. Hämta huvudsekvensen av effekter. 
4. Extrahera den [setSound(IAudio value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) som är inbäddad i varje animationseffekt.

Den här Javascript‑koden visar hur du extraherar ljudet som är inbäddat i en animationseffekt:

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Hämtar huvudsekvensen för bilden.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extraherar effektens ljud i en byte-array
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Efter animation**

Aspose.Slides för Node.js via Java låter dig ändra After animation‑egenskapen för en animationseffekt.

Detta är panelen Animation Effect och den utökade menyn i Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation**‑rullgardinslistan motsvarar dessa egenskaper: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) metoden som beskriver typen för After animation;
  * PowerPoint **More Colors** motsvarar typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim**‑listobjektet motsvarar typen [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (standard typ för efteranimation);
  * PowerPoint **Hide After Animation**‑objektet motsvarar typen [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click**‑objektet motsvarar typen [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) metoden som definierar ett färgformat för efteranimation. Denna metod fungerar tillsammans med typen [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#Color). Om du ändrar typen till en annan kommer färgen för efteranimation att rensas.

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Hämtar den första effekten i huvudsekvensen
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Ändrar efteranimationstypen till Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Sätter färgen för efteranimationens dimning
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Skriver PPTX-filen till disk
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animera text**

Aspose.Slides tillhandahåller dessa egenskaper för att låta dig arbeta med en animationseffekts *Animate text*-block:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) som beskriver en animate text‑typ för effekten. Formtexten kan animeras:
  - Alla på en gång ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Ord för ord ([AnimateTextType.ByWord](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/animatetexttype/#ByWord) typ)
  - Bokstav för bokstav ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) sätter en fördröjning mellan de animerade textdelarna (ord eller bokstäver). Ett positivt värde anger procenten av effektens varaktighet. Ett negativt värde anger fördröjning i sekunder.

Så här kan du ändra egenskaperna för Effect Animate text:

1. [Tillämpa](#apply-animation-to-shape) eller hämta animationseffekten.
2. Använd [setBuildType(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textanimation/#setBuildType-int-)‑metoden med värdet [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/buildtype/#AsOneObject) för att inaktivera *By Paragraphs*-animationsläget.
3. Ställ in nya värden för [setAnimateTextType(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) och [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-)‑egenskaperna.
4. Spara den ändrade PPTX‑filen.

```javascript
// Instansierar en presentationsklass som representerar en presentationsfil.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Hämtar den första effekten i huvudsekvensen
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Ändrar effektens textanimeringstyp till "Som ett objekt"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Ändrar effektens animera text-typ till "Ord för ord"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Ställer in fördröjningen mellan ord till 20 % av effektens varaktighet
    firstEffect.setDelayBetweenTextParts(20.0);
    // Skriver PPTX-filen till disk
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hur kan jag säkerställa att animationer bevaras när presentationen publiceras på webben?**

[Exportera till HTML5](/slides/sv/nodejs-java/export-to-html5/) och aktivera de [alternativ](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/html5options/) som ansvarar för [form](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/html5options/setanimateshapes/) och [övergång](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/html5options/setanimatetransitions/) animationer. Vanlig HTML spelar inte upp bildanimationer, medan HTML5 gör det.

**Hur påverkar ändring av z-ordning (lagerordning) för former animationen?**

Animation‑ och ritordning är oberoende: en effekt styr tidpunkten och typen av framträde/försvinnande, medan [z-ordning](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getzorderposition/) bestämmer vad som täcker vad. Det synliga resultatet definieras av deras kombination. (Detta är den generella PowerPoint‑beteendet; Aspose.Slides modell för effekter‑och‑former följer samma logik.)

**Finns det begränsningar vid konvertering av animationer till video för vissa effekter?**

I allmänhet [animationer stöds](/slides/sv/nodejs-java/convert-powerpoint-to-video/), men sällsynta fall eller specifika effekter kan renderas annorlunda. Det rekommenderas att testa med de effekter du använder och med den biblioteksversion du har.