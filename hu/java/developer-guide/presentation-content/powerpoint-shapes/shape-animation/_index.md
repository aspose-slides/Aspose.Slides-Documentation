---
title: Alakzatanimációk alkalmazása prezentációkban Java használatával
linktitle: Alakzatanimáció
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
description: "Fedezze fel, hogyan hozhat létre és szabhat testre alakzatanimációkat PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyek szövegekre, képekre, alakzatokra vagy [diagramokra](https://docs.aspose.com/slides/hu/java/animated-charts/) alkalmazhatók. Életet adnak a bemutatóknak vagy azok részeinek. 

## **Miért használjunk animációkat a bemutatókban?**

* szabályozza az információáramlást  
* hangsúlyozza a fontos pontokat  
* növeli a közönség érdeklődését vagy részvételét  
* megkönnyíti a tartalom olvasását, befogadását vagy feldolgozását  
* felhívja az olvasók vagy nézők figyelmét a bemutató fontos részeire  

A PowerPoint számos lehetőséget és eszközt biztosít animációk és animációs hatások számára az **belépés**, **kilépés**, **kiemelés** és **mozgási útvonalak** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides a `Aspose.Slides.Animation` névtérben biztosítja az animációkkal dolgozáshoz szükséges osztályokat és típusokat,  
* Az Aspose.Slides a [EffectType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttype) felsorolás alatt több mint **150 animációs hatást** kínál. Ezek a hatások lényegében ugyanazok (vagy ekvivalensak), mint a PowerPoint-ban használtak.  

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for Java lehetővé teszi, hogy animációt alkalmazzunk egy alakzat szövegére. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia (slide) hivatkozást az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape)-et.  
4. Adjon szöveget a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)-hez.  
5. Szerezze be a hatások fő sorozatát.  
6. Adjon animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape)-hez.  
7. Állítsa be a `TextAnimation.BuildType` tulajdonságot a `BuildType` felsorolás értékére.  
8. Írja a prezentációt lemezre PPTX fájlként.  

Ez a Java kód megmutatja, hogyan kell alkalmazni a `Fade` hatást az AutoShape-re, és beállítani a szöveg animációt *By 1st Level Paragraphs* értékre:

```java
import com.aspose.slides.*;

// Példányosít egy prezentáció osztályt, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Új AutoShape-et ad hozzá szöveggel
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lekéri a dia fő sorozatát.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Fade animációs hatást ad az alakzathoz
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Alakzat szövegét 1. szintű bekezdések szerint animálja
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Mentse a PPTX fájlt a lemezre
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

A szövegre történő animációk mellett animációkat alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph)-ra is. Lásd [**Animated Text**](/slides/hu/java/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása képkeretre**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Adjon hozzá vagy szerezzen be egy [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe)-et a diára.  
4. Szerezze be a hatások fő sorozatát.  
5. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe)-hez.  
6. Írja a prezentációt lemezre PPTX fájlként.  

Ez a Java kód megmutatja, hogyan kell alkalmazni a `Fly` hatást egy képkeretre:

```java
import com.aspose.slides.*;

// Egy prezentációs osztályt példányosít, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation();
try {
    // Kép betöltése, amelyet a prezentáció képgyűjteményéhez adunk hozzá
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Képkeretet ad a diára
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lekéri a dia fő sorozatát.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Fly balról animációs hatást ad a képkerethez
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX fájl mentése a lemezre
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape)-t.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape)-et (amikor erre az objektumra kattintanak, az animáció elindul).  
5. Hozzon létre egy hatássorozatot a bevel alakzaton.  
6. Hozzon létre egy egyedi `UserPath`-t.  
7. Adj hozzá parancsokat a `UserPath`-re való mozgáshoz.  
8. Írja a prezentációt lemezre PPTX fájlként.  

Ez a Java kód megmutatja, hogyan kell alkalmazni a `PathFootball` (path football) hatást egy alakzatra:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Egy Presentation osztályt példányosít, amely egy PPTX fájlt képvisel.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // PathFootball effektust hoz létre egy meglévő alakzatra teljesen a semmiből.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Hozzáadja a PathFootBall animációs hatást
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Valamilyen "gombot" hoz létre.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Létrehoz egy hatássorozatot ehhez a gombhoz.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Egy egyedi felhasználói útvonalat hoz létre. Az objektum csak a gomb megnyomása után mozdul el.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Parancsokat ad hozzá a mozgáshoz, mivel a létrehozott útvonal üres.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // A PPTX fájlt a lemezre írja
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az alakzatra alkalmazott animációs hatások lekérése**

A következő példák megmutatják, hogyan kell használni a `getEffectsByShape` metódust a [ISequence](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/) interfészből, hogy lekérje az alakzatra alkalmazott összes animációs hatást.

**Példa 1: Az animációs hatások lekérése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan kell animációs hatásokat hozzáadni alakzatokhoz PowerPoint bemutatókban. A következő minta kód megmutatja, hogyan kell lekérni a hatásokat, amelyeket az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban alkalmaztak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lekéri a dia fő animációs sorozatát.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri az első dia első alakzatát.
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

Ha egy alakzat egy normál dián olyan helyőrzőkkel rendelkezik, amelyek az elrendezési dián és/vagy a mester dián találhatók, és animációs hatásokat adtak hozzá ezekhez a helyőrzőkhöz, akkor az alakzat összes hatása lejátszásra kerül a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat.

Tegyük fel, hogy van egy `sample.pptx` nevű PowerPoint prezentációs fájlunk, amely egyetlen diával rendelkezik, amely csak egy lábléc alakzatot tartalmaz a „Made with Aspose.Slides” szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Slide shape animation effect](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás van alkalmazva a lábléc helyőrzőre a **layout** dián.

![Layout shape animation effect](layout-shape-animation.png)

Végül a **Fly In** hatás van alkalmazva a lábléc helyőrzőre a **master** dián.

![Master shape animation effect](master-shape-animation.png)

A következő minta kód megmutatja, hogyan kell használni a `getBasePlaceholder` metódust a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészből, hogy hozzáférjünk az alakzat helyőrzőihez, és lekérjük a lábléc alakzatra alkalmazott animációs hatásokat, beleértve a elrendezési és mester diákról származó helyőrzőkből örökölt hatásokat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Lekéri a normál dián lévő alakzat animációs hatásait.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Lekéri a helyőrző animációs hatásait a layout dián.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Lekéri a helyőrző animációs hatásait a master dián.
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

Az Aspose.Slides for Java lehetővé teszi az animációs hatás időzítési tulajdonságainak módosítását.

Ez a Animation Timing panel a Microsoft PowerPoint-ben:

![example1_image](shape-animation.png)

Az alábbiak a PowerPoint Timing és a [Effect.Timing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IEffect#getTiming--) tulajdonságok közötti megfelelőségek:

- A PowerPoint Timing **Start** legördülő lista egyezik a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getTriggerType--) tulajdonsággal. 
- A PowerPoint Timing **Duration** egyezik a [Effect.Timing.Duration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getDuration--) tulajdonsággal. Egy animáció időtartama (másodpercben) az az összes idő, amely a animáció egy ciklusának befejezéséhez szükséges. 
- A PowerPoint Timing **Delay** egyezik a [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITiming#getTriggerDelayTime--) tulajdonsággal. 

Így módosíthatja a Effect Timing tulajdonságokat:

1. [Apply](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítson be új értékeket a szükséges [Effect.Timing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IEffect#getTiming--) tulajdonságokhoz.  
3. Mentse a módosított PPTX fájlt.  

Ez a Java kód bemutatja a műveletet:

```java
import com.aspose.slides.*;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lekéri a dia fő sorozatát.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lekéri a fő sorozat első hatását.
    IEffect effect = sequence.get_Item(0);

    // Módosítja a hatás TriggerType értékét, hogy kattintásra kezdődjön
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Módosítja a hatás időtartamát
    effect.getTiming().setDuration(3f);

    // Módosítja a hatás TriggerDelayTime értékét
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Mentése a PPTX fájlt a lemezre
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animációs hatás hangja**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja, hogy hangokkal dolgozhasson animációs hatásokban: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Animációs hatás hangjának hozzáadása**

Ez a Java kód megmutatja, hogyan kell hozzáadni egy animációs hatás hangot, és megállítani azt, amikor a következő hatás elindul:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Audiót ad a prezentáció audiógyűjteményéhez
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a dia fő sorozatát.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = sequence.get_Item(0);

    // Ellenőrzi a hatást \"No Sound\" szempontjából
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Hangot ad az első hatáshoz
        firstEffect.setSound(effectSound);
    }

    // Lekéri a dia első interaktív sorozatát.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Beállítja a hatás \"Stop previous sound\" jelzőjét
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // A PPTX fájlt a lemezre írja
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Szerezzen be egy dia hivatkozást az indexe alapján.  
3. Szerezze be a hatások fő sorozatát.  
4. Vonja ki a [setSound(IAudio value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) beágyazott hangot minden animációs hatáshoz.  

Ez a Java kód megmutatja, hogyan kell kinyerni az animációs hatásba beágyazott hangot:

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

        // Kivonja a hatás hangját bájt tömbbe
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animáció után**

Az Aspose.Slides for Java lehetővé teszi az animációs hatás After animation (az animáció utáni) tulajdonságának módosítását.

Ez az Animation Effect panel és a kiterjesztett menü a Microsoft PowerPointben:

![example1_image](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő lista ezeknek a tulajdonságoknak felel meg:

- A [setAfterAnimationType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) tulajdonság, amely leírja az After animation típusát:
  * A PowerPoint **More Colors** a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color) típussal egyezik;
  * A PowerPoint **Don't Dim** elem a [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#DoNotDim) típussal egyezik (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** elem a [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) típussal egyezik;
  * A PowerPoint **Hide on Next Mouse Click** elem a [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) típussal egyezik;
- A [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) tulajdonság, amely meghatározza az after animation színformátumot. Ez a tulajdonság a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color) típussal együtt működik. Ha a típust megváltoztatja, az after animation szín törlésre kerül.  

Ez a Java kód megmutatja, hogyan kell módosítani egy after animation hatást:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Megváltoztatja az animáció utáni típusát Színre
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Beállítja az animáció utáni halványító színt
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // A PPTX fájlt a lemezre írja
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szöveg animálása**

Az Aspose.Slides ezeket a tulajdonságokat biztosítja, hogy az animációs hatás *Animate text* blokkjával dolgozhasson:

- A [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) amely leírja a szöveg animálásának típusát a hatáson. Az alakzat szövege animálható:
  * Egyszerre ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#AllAtOnce) típus)
  * Szó szerint ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#ByWord) típus)
  * Betű szerint ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/animatetexttype/#ByLetter) típus)
- A [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) beállítja a késleltetést az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát jelöli. A negatív érték az időt másodpercben adja meg.  

Így módosíthatja a Effect Animate text tulajdonságokat:

1. [Apply](#apply-animation-to-shape) vagy szerezze be az animációs hatást.  
2. Állítsa be a [setBuildType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextanimation/#setBuildType-int-) tulajdonságot a [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/buildtype/#AsOneObject) értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.  
3. Állítson be új értékeket a [setAnimateTextType(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) és a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) tulajdonságokra.  
4. Mentse a módosított PPTX fájlt.  

Ez a Java kód bemutatja a műveletet:

```java
import com.aspose.slides.*;

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lekéri a fő sorozat első hatását
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Megváltoztatja a hatás Text animation type típusát "As One Object"-ra
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Megváltoztatja a hatás Animate text type típusát "By word"-ra
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    firstEffect.setDelayBetweenTextParts(20f);

    // A PPTX fájlt a lemezre írja
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### **Hogyan biztosíthatom, hogy az animációk megmaradnak a bemutató webre közzétételekor?**

[Export to HTML5](/slides/hu/java/export-to-html5/) és engedélyezze a [options](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/) beállításokat, amelyek a [shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és [transition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animációkért felelnek. A sima HTML nem játssza le a diák animációit, míg a HTML5 igen.

### **Hogyan befolyásolja az alakzatok z-rend (réteg sorrend) módosítása az animációt?**

Az animációs és a rajzolási sorrend független egymástól: egy hatás szabályozza az megjelenés/eltűnés időzítését és típusát, míg a [z-order](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getZOrderPosition--) meghatározza, mi takarja meg, mi nem. A látható eredményt a kombinációjuk határozza meg. (Ez a PowerPoint általános viselkedése; az Aspose.Slides hatások‑és‑alakzatok modellje ugyanazt a logikát követi.)

### **Vannak korlátozások az animációk videóvá konvertálásakor bizonyos hatások esetén?**

Általánosságban a [animációk támogatottak](/slides/hu/java/convert-powerpoint-to-video/), de ritka esetekben vagy bizonyos hatásoknál eltérő megjelenítés fordulhat elő. Ajánlott tesztelni a használt hatásokat és a könyvtár verziójával.