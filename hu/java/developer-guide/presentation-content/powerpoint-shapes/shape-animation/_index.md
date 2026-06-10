---
title: Alakzat animációk alkalmazása prezentációkban Java-val
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzat animációkat PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](https://docs.aspose.com/slides/hu/java/animated-charts/) alkalmazhatók. Életet adnak a prezentációknak vagy azok elemeinek. 

## **Miért használjunk animációkat a prezentációkban?**

Az animációk segítségével

* az információáramlás szabályozása
* a fontos pontok hangsúlyozása
* az érdeklődés vagy részvétel növelése a közönségnél
* a tartalom könnyebb olvasása, befogadása vagy feldolgozása
* a közönség figyelmének felhívása a prezentáció fontos részeire

A PowerPoint számos lehetőséget és eszközt kínál az animációkhoz és animációs hatásokhoz a **belépés**, **kilépés**, **kiemelés**, **mozgási útvonalak** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja a `Aspose.Slides.Animation` névtér alatt szükséges osztályokat és típusokat az animációk kezeléséhez,
* Az Aspose.Slides több mint **150 animációs hatást** kínál a [EffectType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttype) felsorolásban. Ezek a hatások lényegében azonosak (vagy ekvivalensek) a PowerPointban használt hatásokkal.

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for Java lehetővé teszi, hogy animációt alkalmazzunk egy alakzat szövegére. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezzen be egy diára való hivatkozást az indexe alapján.
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape) elemet. 
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)-hez.
5. Szerezze meg a fő hatássorozatot.
6. Adjon animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape)-hez. 
7. Állítsa be a `TextAnimation.BuildType` tulajdonságot a `BuildType` felsorolás megfelelő értékére.
8. Írja a prezentációt lemezre PPTX fájlként.

Ez a Java kód bemutatja, hogyan alkalmazhatja a `Fade` hatást az AutoShape-re, és hogyan állíthatja be a szöveg animációt *By 1st Level Paragraphs* értékre:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Új AutoShape-ot ad hozzá szöveggel
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fade animációs hatást ad hozzá az alakzathoz
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animálja az alakzat szövegét az első szintű bekezdések szerint
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Mentse a PPTX fájlt a lemezre
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Az animációk szövegre való alkalmazása mellett egyetlen [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph)-ra is alkalmazhat animációkat. Lásd [**Animált szöveg**](/slides/hu/java/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása képkockára**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezzen be egy diára való hivatkozást az indexe alapján.
3. Adjon hozzá vagy szerezze be a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe) elemet a dián. 
4. Szerezze meg a fő hatássorozatot.
5. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe)-hez.
6. Írja a prezentációt lemezre PPTX fájlként.

Ez a Java kód bemutatja, hogyan alkalmazhatja a `Fly` hatást egy képkockára:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál.
Presentation pres = new Presentation();
try {
    // Betölti a képet, amelyet a prezentáció képkönyvtárához adunk hozzá
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkockát ad a diára
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Balról bejövő Fly animációs hatást ad a képkockához
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Mentse a PPTX fájlt a lemezre
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezzen be egy diára való hivatkozást az indexe alapján.
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape) elemet. 
4. Adj hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape) elemet (amikor erre az objektumra kattintanak, az animáció lejátszásra kerül).
5. Hozzon létre egy hatássorozatot a bevel alakzaton.
6. Hozzon létre egy egyéni `UserPath`-t.
7. Adjon parancsokat a `UserPath`-ra való mozgatáshoz.
8. Írja a prezentációt lemezre PPTX fájlként.

Ez a Java kód bemutatja, hogyan alkalmazhatja a `PathFootball` (szpath football) hatást egy alakzatra:

```java
// Egy Presentation osztályt példányosít, amely egy PPTX fájlt reprezentál.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // PathFootball hatást hoz létre egy létező alakzatra a semmiből.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Hozzáadja a PathFootBall animációs hatást
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Létrehoz egyfajta "gombot".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Létrehoz egy hatássorozatot ennek a gombnak.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Létrehoz egy egyéni felhasználói útvonalat. Az objektum csak a gomb megnyomása után mozog.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Parancsokat ad hozzá a mozgáshoz, mivel a létrehozott útvonal üres.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Kiírja a PPTX fájlt a lemezre
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az alakzatra alkalmazott animációs hatások lekérése**

A következő példák bemutatják, hogyan használhatja a `getEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/) interfészből, hogy lekérje az alakzatra alkalmazott összes animációs hatást.

**Példa 1: Animációs hatások lekérése egy normál dián lévő alakzatra**

Korábban megtanultuk, hogyan adjunk animációs hatásokat alakzatokhoz a PowerPoint prezentációkban. A következő minta kód bemutatja, hogyan kérhetők le a hatások az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő animációs szekvenciáját.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri az első alakzatot az első dián.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Lekéri az alakzatra alkalmazott animációs hatásokat.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Példa 2: Az összes animációs hatás lekérése, beleértve a helyőrzőkből örökölt hatásokat**

Ha egy alakzat egy normál dián olyan helyőrzőkkel rendelkezik, amelyek az elrendezés dián és/vagy a mester dián találhatók, és animációs hatásokat adtak ezekhez a helyőrzőkhöz, akkor az alakzat összes hatása lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat.

Tegyük fel, hogy van egy `sample.pptx` PowerPoint prezentáció fájlunk, amely egyetlen diát tartalmaz, amely csak egy lábléc alakzatot tartalmaz a "Made with Aspose.Slides" szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Dia alakzat animációs hatás](slide-shape-animation.png)

Feltételezzük továbbá, hogy a **Split** hatás a lábléc helyőrzőre van alkalmazva az **elrendezés** dián.

![Elrendezés alakzat animációs hatás](layout-shape-animation.png)

Végül a **Fly In** hatás a lábléc helyőrzőre van alkalmazva a **mester** dián.

![Mester alakzat animációs hatás](master-shape-animation.png)

A következő minta kód bemutatja, hogyan használhatja a `getBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészből, hogy hozzáférjen az alakzat helyőrzőihez, és lekérje a lábléc alakzatra alkalmazott animációs hatásokat, beleértve a elrendezésen és a mester dián lévő helyőrzőkből örökölt hatásokat.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for Java lehetővé teszi, hogy módosítsa egy animációs hatás időzítési tulajdonságait.

Ez a Microsoft PowerPointben található Animációs időzítés ablaka:

![animációs időzítés](shape-animation.png)

Ezek a megfelelések a PowerPoint időzítés és az [Effect.Timing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IEffect#getTiming--) tulajdonságok között:

- A PowerPoint időzítés **Start** legördülő listája a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getTriggerType--) tulajdonságnak felel meg. 
- A PowerPoint időzítés **Duration** megfelel a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getDuration--) tulajdonságnak. Egy animáció időtartama (másodpercben) a teljes ciklus befejezéséhez szükséges idő. 
- A PowerPoint időzítés **Delay** megfelel a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getTriggerDelayTime--) tulajdonságnak. 

Így módosíthatja az Effect Timing tulajdonságokat:

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze be az animációs hatást.
2. Állítsa be az Ön által szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IEffect#getTiming--) tulajdonságok új értékeit. 
3. Mentse a módosított PPTX fájlt.

Ez a Java kód szemlélteti a műveletet:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lekéri a fő szekvencia első hatását.
    IEffect effect = sequence.get_Item(0);

    // Módosítja a hatás TriggerType-ot, hogy kattintásra kezdődjön
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Módosítja a hatás időtartamát
    effect.getTiming().setDuration(3f);

    // Módosítja a hatás TriggerDelayTime értékét
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Mentse a PPTX fájlt a lemezre
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animációs hatás hangja**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy hangokkal dolgozhasson animációs hatásokban: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Animációs hatás hangjának hozzáadása**

Ez a Java kód bemutatja, hogyan adjon hozzá egy animációs hatás hangját, és hogyan állítsa le, amikor a következő hatás elindul:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Hozzáad hangot a prezentáció hanggyűjteményéhez
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri a fő szekvencia első hatását
    IEffect firstEffect = sequence.get_Item(0);

    // Ellenőrzi a hatást "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Hozzáad hangot az első hatáshoz
        firstEffect.setSound(effectSound);
    }

    // Lekéri a dia első interaktív szekvenciáját.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Beállítja a hatás "Stop previous sound" jelzőjét
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Kiírja a PPTX fájlt a lemezre
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Szerezze meg a fő hatássorozatot. 
4. Nyerje ki a [setSound(IAudio value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) minden animációs hatásba ágyazott hangot. 

Ez a Java kód bemutatja, hogyan nyerhetjük ki az animációs hatásba beágyazott hangot:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Kinyeri a hatás hangját bájt tömbbe
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animáció után**

Az Aspose.Slides for Java lehetővé teszi, hogy módosítsa egy animációs hatás After animation (animáció után) tulajdonságát.

Ez a Microsoft PowerPointben található Animációs hatás ablaka és kiterjesztett menüje:

![animációs hatás menü](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő listája megfelel ezeknek a tulajdonságoknak: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) tulajdonság, amely leírja az After animation típust:
  * PowerPoint **More Colors** megfelel a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color) típusnak;
  * PowerPoint **Don't Dim** listaelem megfelel a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#DoNotDim) típusnak (alapértelmezett after animation típus);
  * PowerPoint **Hide After Animation** elem megfelel a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) típusnak;
  * PowerPoint **Hide on Next Mouse Click** elem megfelel a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) típusnak;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) tulajdonság, amely meghatározza az after animation színformátumot. Ez a tulajdonság a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color) típussal együtt működik. Ha a típust másikra változtatja, az after animation szín törlésre kerül.

Ez a Java kód bemutatja, hogyan változtathatunk meg egy after animation hatást:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő szekvencia első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Módosítja az animáció utáni típust Színre
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Beállítja az animáció utáni halványító színt
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Kiírja a PPTX fájlt a lemezre
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szöveg animálása**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy a *Animate text* blokkot kezelhesse egy animációs hatásban:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) amely leírja a hatás animált szöveg típusát. A forma szövegét animálhatja:
  - Mindegyiket egyszerre ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#AllAtOnce) típus)
  - Szó szerint ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#ByWord) típus)
  - Betű szerint ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#ByLetter) típus)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) beállítja a késleltetést az animált szöveg részei (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték a késleltetést másodpercben adja meg.

Így módosíthatja az Effect Animate text tulajdonságokat:

1. [Alkalmazza](#apply-animation-to-shape) vagy szerezze be az animációs hatást.
2. Állítsa be a [setBuildType(int value)] tulajdonságot a [BuildType.AsOneObject] értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.
3. Állítson be új értékeket a [setAnimateTextType(int value)] és a [setDelayBetweenTextParts(float value)] tulajdonságok számára.
4. Mentse a módosított PPTX fájlt.

Ez a Java kód bemutatja a műveletet:

```java
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt reprezentál.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő szekvencia első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Módosítja a hatás szöveganimáció típusát "As One Object" értékre
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Módosítja a hatás animált szöveg típusát "By word" értékre
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Beállítja a szavak közötti késleltetést az effektus időtartamának 20%-ára
    firstEffect.setDelayBetweenTextParts(20f);

    // Kiírja a PPTX fájlt a lemezre
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre publikálásakor?**

[Export to HTML5](/slides/hu/java/export-to-html5/) és engedélyezze a [beállításokat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/), amelyek a [shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és [transition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animációkért felelősek. A sima HTML nem játssza le a diák animációit, míg az HTML5 igen.

**Hogyan befolyásolja a z-sorrend (réteg sorrend) módosítása az animációt?**

Az animáció és a rajzolási sorrend független egymástól: egy hatás szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-sorrend](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getZOrderPosition--) határozza meg, hogy mi takarja le, mi. A látható eredményt a kettő kombinációja határozza meg. (Ez általános PowerPoint viselkedés; az Aspose.Slides hatások‑és‑alakzatok modellje ugyanezt a logikát követi.)

**Vannak korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?**

Általánosságban a [animációk támogatottak](/slides/hu/java/convert-powerpoint-to-video/), de ritka esetekben vagy specifikus hatásoknál eltérő módon jelenhetnek meg. Javasolt tesztelni a használt hatásokkal és a könyvtár verziójával.