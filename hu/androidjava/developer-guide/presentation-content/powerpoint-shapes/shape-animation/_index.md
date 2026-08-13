---
title: Alakzatanimációk alkalmazása Androidos bemutatókban
linktitle: Alakzatanimáció
type: docs
weight: 60
url: /hu/androidjava/shape-animation/
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
- hatás hang
- animáció alkalmazása
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és szabhat testre alakzatanimációkat PowerPoint bemutatókban az Aspose.Slides for Android Java segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](https://docs.aspose.com/slides/hu/androidjava/animated-charts/) lehet alkalmazni. Életet adnak a bemutatóknak vagy azok elemeinek.

## **Miért használjunk animációkat a bemutatókban?**

* a információáramlás szabályozása
* a fontos pontok kiemelése
* az érdeklődés vagy a közönség részvételének növelése
* a tartalom könnyebb olvasása, befogadása vagy feldolgozása
* az olvasók vagy nézők figyelmének felhívása a bemutató fontos részeire

A PowerPoint sok lehetőséget és eszközt kínál az animációk és animációs hatások számára az **belépés**, **kilépés**, **kiemelés** és **mozgási útvonalak** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja a szükséges osztályokat és típusokat az animációk kezeléséhez a `Aspose.Slides.Animation` névtér alatt,
* Az Aspose.Slides több mint **150 animációs hatást** biztosít a [EffectType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttype) felsorolásban. Ezek a hatások lényegében megegyeznek (vagy ekvivalensek) a PowerPointban használt hatásokkal.

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for Android Java segítségével lehetővé teszi, hogy animációt alkalmazzon az alakzat szövegére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzen meg egy dia referencia indexe alapján.
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape).
4. Adjon hozzá szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)‑hez.
5. Szerezze meg a fő hatássorozatot.
6. Adjon hozzá egy animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape)-hez.
7. Állítsa be a `TextAnimation.BuildType` tulajdonságot a `BuildType` felsorolás értékére.
8. Írja a bemutatót lemezre PPTX fájlként.

Ez a Java kód megmutatja, hogyan lehet alkalmazni a `Fade` hatást az AutoShape-re, és beállítani a szöveganimációt *1. szintű bekezdések szerint* értékre:

```java
import com.aspose.slides.*;

// Létrehozza egy prezentációs osztály példányát, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Új AutoShape-et ad hozzá szöveggel
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fade animációs hatást ad az alakzathoz
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Az alakzat szövegét az 1. szintű bekezdések szerint animálja
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 
Az animációk szövegre való alkalmazása mellett animációkat alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph). Lásd [**Animated Text**](/slides/hu/androidjava/animated-text/).
{{% /alert %}} 

## **Animáció alkalmazása képkeretre**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzen meg egy dia referencia indexe alapján.
3. Adjon hozzá vagy szerezzen meg egy [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe) elemet a diára.
4. Szerezze meg a fő hatássorozatot.
5. Adjon hozzá egy animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe)-hez.
6. Mentse el a bemutatót lemezre PPTX fájlként.

Ez a Java kód megmutatja, hogyan lehet alkalmazni a `Fly` hatást egy képkeretre:

```java
import com.aspose.slides.*;

// Létrehozza a prezentációs osztály egy példányát, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation();
try {
    // Betölti a képet, amely a prezentáció képgyűjteményéhez lesz hozzáadva
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad a diára
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lekéri a dia fő szekvenciáját.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fly from Left animációs hatást ad a képkerethez
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzen meg egy dia referencia indexe alapján.
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape).
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape) (amikor erre az objektumra kattintanak, az animáció lejátszásra kerül).
5. Hozzon létre egy hatássorozatot a bevel alakzaton.
6. Hozzon létre egy egyedi `UserPath`-t.
7. Adjon parancsokat a `UserPath`-ra mozgatáshoz.
8. Mentse el a bemutatót lemezre PPTX fájlként.

Ez a Java kód megmutatja, hogyan kell alkalmazni a `PathFootball` (labdarúgó pálya) hatást egy alakzatra:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Létrehozza a Presentation osztály egy példányát, amely egy PPTX fájlt képvisel.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Létrehozza a PathFootball hatást egy meglévő alakzatra a semmiből.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Hozzáadja a PathFootBall animációs hatást
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Létrehoz egyfajta "gombot".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Létrehoz egy hatássorozatot ehhez a gombhoz.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Létrehozza egy egyéni felhasználói útvonalat. Az objektum csak a gomb megnyomása után fog mozogni.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Hozzáad mozgatási parancsokat, mivel a létrehozott útvonal üres.
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

Az alábbi példák megmutatják, hogyan használja a `getEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/) interfészből, hogy lekérje egy alakzatra alkalmazott összes animációs hatást.

**Példa 1: Az animációs hatások lekérése egy alakzatra egy normál dián**

Eddig megtanulták, hogyan adjanak animációs hatásokat alakzatokhoz PowerPoint bemutatókban. Az alábbi minta kód megmutatja, hogyan lehet lekérni a hatásokat az első alakzatra az első normál dián a `AnimExample_out.pptx` bemutatóban.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő animációs sorozatát.
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

Ha egy alakzat egy normál dián helyőrzőkkel rendelkezik, amelyek a diaelrendezésen és/vagy a mester dián találhatók, és ezekhez a helyőrzőkhöz animációs hatásokat adtak hozzá, akkor a dia vetítése során az alakzat összes hatása lejátszásra kerül, beleértve a helyőrzőkből örökölt hatásokat.

Legyen egy PowerPoint bemutatófájl `sample.pptx` egy diával, amely csak egy lábléc alakzatot tartalmaz a „Made with Aspose.Slides” szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Dia alakzat animációs hatása](slide-shape-animation.png)

Tegyük fel, hogy a **Split** hatás a lábléc helyőrzőre van alkalmazva az **elrendezés** dián.

![Elrendezés alakzat animációs hatása](layout-shape-animation.png)

Végül, a **Fly In** hatás a lábléc helyőrzőre van alkalmazva a **mester** dián.

![Mester alakzat animációs hatása](master-shape-animation.png)

Az alábbi minta kód megmutatja, hogyan használja a `getBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészben, hogy elérje az alakzat helyőrzőit és lekérje a lábléc alakzatra alkalmazott animációs hatásokat, beleértve a elrendezés és mester diákon lévő helyőrzőkből örökölt hatásokat.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Az animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for Android Java segítségével módosíthatja egy animációs hatás időzítési tulajdonságait.

Ez a **Animation Timing** panel a Microsoft PowerPointben:

![example1_image](shape-animation.png)

Ezek a megfelelőségek a PowerPoint időzítés és az [Effect.Timing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IEffect#getTiming--) tulajdonságok között:

- A PowerPoint **Start** legördülő lista megfelel az [Effect.Timing.TriggerType] tulajdonságnak.
- A PowerPoint **Duration** megfelel az [Effect.Timing.Duration] tulajdonságnak. Az animáció időtartama (másodpercben) az a teljes idő, ameddig egy ciklus lejátszódik.
- A PowerPoint **Delay** megfelel az [Effect.Timing.TriggerDelayTime] tulajdonságnak.

Az alábbiak szerint módosíthatja a Effect Timing tulajdonságokat:

1. [Alkalmaz](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Állítson be új értékeket a szükséges [Effect.Timing] tulajdonságok számára.
3. Mentse el a módosított PPTX fájlt.

Ez a Java kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lekéri a dia fő sorozatát.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lekéri a fő sorozat első hatását.
    IEffect effect = sequence.get_Item(0);

    // Megváltoztatja a hatás TriggerType-át, hogy kattintásra induljon
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Megváltoztatja a hatás időtartamát
    effect.getTiming().setDuration(3f);

    // Megváltoztatja a hatás TriggerDelayTime-ot
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animációs hatás hangja**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy hangokkal dolgozhasson animációs hatásokban: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animációs hatás hangjának hozzáadása**

Ez a Java kód megmutatja, hogyan adjon hozzá egy animációs hatás hangot, és állítsa le, amikor a következő hatás elindul:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Hozzáad audiót a prezentáció audio gyűjteményéhez
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a dia fő sorozatát.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = sequence.get_Item(0);

    // Ellenőrzi, hogy a hatásnak nincs hangja
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Hangot ad az első hatáshoz
        firstEffect.setSound(effectSound);
    }

    // Lekéri a dia első interaktív sorozatát.
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen meg egy dia referencia indexe alapján. 
3. Szerezze meg a fő hatássorozatot. 
4. Vonja ki a [setSound(IAudio value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) minden animációs hatásba beágyazott hangot.

Ez a Java kód megmutatja, hogyan lehet kinyerni a animációs hatásba beágyazott hangot:

```java
import com.aspose.slides.*;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő sorozatát.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Kinyeri a hatás hangját bájt tömbként
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animáció után**

Az Aspose.Slides for Android Java lehetővé teszi, hogy módosítsa egy animációs hatás **After animation** (animáció után) tulajdonságát.

Ez a **Animation Effect** panel és bővített menü a Microsoft PowerPointben:

![example1_image](shape-after-animation.png)

A PowerPoint **After animation** legördülő lista megfelel ezeknek a tulajdonságoknak: 

- [setAfterAnimationType(int value)] tulajdonság, amely leírja az animáció utáni típust:
  * A PowerPoint **More Colors** a [AfterAnimationType.Color] típusnak felel meg;
  * A PowerPoint **Don't Dim** elem a [AfterAnimationType.DoNotDim] típusnak felel meg (alapértelmezett animáció utáni típus);
  * A PowerPoint **Hide After Animation** elem a [AfterAnimationType.HideAfterAnimation] típusnak felel meg;
  * A PowerPoint **Hide on Next Mouse Click** elem a [AfterAnimationType.HideOnNextMouseClick] típusnak felel meg;
- [setAfterAnimationColor(IColorFormat value)] tulajdonság, amely meghatározza az animáció utáni színformátumot. Ez a tulajdonság a [AfterAnimationType.Color] típussal együtt működik. Ha a típust másikra változtatja, az animáció utáni szín törlődik.

Ez a Java kód megmutatja, hogyan változtatható egy animáció utáni hatás:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Megváltoztatja az animáció utáni típust Color értékre
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Beállítja az animáció utáni elsötétítési színt
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szöveg animálása**

Az Aspose.Slides a következő tulajdonságokat biztosítja, hogy az animációs hatás *Animate text* blokkjával dolgozhasson:

- [setAnimateTextType(int value)] amely leírja az animált szöveg típusát a hatáson. A alakzat szövege animálható:
  * Egyszerre ([AnimateTextType.AllAtOnce] típus)
  * Szó szerint ([AnimateTextType.ByWord] típus)
  * Betű szerint ([AnimateTextType.ByLetter] típus)
- [setDelayBetweenTextParts(float value)] egy késleltetést állít be az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték másodpercben adja meg a késleltetést.

Az alábbiak szerint módosíthatja a Effect Animate text tulajdonságait:

1. [Alkalmaz](#apply-animation-to-shape) vagy szerezze meg az animációs hatást.
2. Állítsa be a [setBuildType(int value)] tulajdonságot a [BuildType.AsOneObject] értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.
3. Állítson be új értékeket a [setAnimateTextType(int value)] és [setDelayBetweenTextParts(float value)] tulajdonságokra.
4. Mentse el a módosított PPTX fájlt.

Ez a Java kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Megváltoztatja a hatás szöveganimáció típusát „As One Object” értékre
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Megváltoztatja a hatás Animate text típusát „By word” értékre
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    firstEffect.setDelayBetweenTextParts(20f);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Hogyan biztosíthatom, hogy az animációk megmaradjanak a bemutató webre való közzétételekor?

[Export to HTML5](/slides/hu/androidjava/export-to-html5/) és engedélyezze a [options](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/) beállításait, amelyek a [shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és [transition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animációkért felelnek. A sima HTML nem játssza le a diaanimációkat, míg az HTML5 igen.

### Hogyan befolyásolja az alakzatok z-sorrendjének (réteg sorrendjének) módosítása az animációt?

Az animáció és a rajzolási sorrend függetlenek: egy hatás szabályozza a megjelenés/eltűnés időzítését és típusát, míg a [z-order](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getZOrderPosition--) meghatározza, mi takarja meg, mi nem. A látható eredményt a kettő kombinációja definiálja. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatások‑és‑alakzatok modellje ugyanezt a logikát követi.)

### Vannak korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?

Általánosságban a [animációk támogatottak](/slides/hu/androidjava/convert-powerpoint-to-video/), de ritka esetekben vagy bizonyos hatásoknál eltérő módon jelenhetnek meg. Ajánlott tesztelni a használt hatásokkal és a könyvtár verziójával.