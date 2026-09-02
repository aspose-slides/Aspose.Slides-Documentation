---
title: Alakzat-animációk alkalmazása prezentációkban Java-val
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/java/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, ellenőrizhet és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java a diavetítés animációkat effektusokként ábrázolja egy dia idővonalában. Egy effektusnak van célobjektuma, animáció típusa és al típusa, egy indítója, időzítési beállításai, valamint opcionális tulajdonságai, például hang vagy a animáció utáni viselkedés.

Az idővonal kétféle sorozatot tartalmaz:

- A **fő sorozat** akkor játszódik, amikor a dia előrehalad.
- Egy **interaktív sorozat** akkor indul, amikor a hozzá tartozó indító alakzatot rákattintják.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diatartalomhoz ugyanazt a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust használhatja. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzat-animációk hozzáadása**

Animáció hozzáadásához szerezze meg a dia fő sorozatát, és hívja meg a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust a célobjektummal, effektustípussal, al-típussal és indítóval. Olyan effektus esetén, amely egy másik alakzat kattintásakor indul, hozzon létre egy interaktív sorozatot, amelynek indítója az a másik alakzat.

A következő példa létrehozza mindkét típusú animációt, és elmenti az eredményt a `shape-animations.pptx` fájlba.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Az indító szabályozza, mikor kezdődik egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#OnClick) a fő sorozatban egy kattintásra vagy egy interaktív sorozatban az indító alakzatra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#AfterPrevious) az előző effektus befejeződésekor indul.

Kép, diagram vagy más alakzat animálásához adja át az objektumot a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) hívásnak a `targetShape` helyett. Diagramokra vonatkozó csoportosítási lehetőségekért lásd a [Animated Charts](/slides/hu/java/animated-charts/) oldalt.

## **Alakzat-animációk olvasása**

Használja a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust, ha ismeri a célobjektumot. Az összes effektus megtekintéséhez enumerálja a fő sorozatot és minden interaktív sorozatot. Az enumerálás elkerüli azt a feltételezést, hogy egy sorozatban az `0` indexű effektus létezik.

A következő példa létrehoz egy alakzatot fő‑sorozati és interaktív effektusokkal, lekéri a alakzatot célozó effektusokat, majd enumerálja a dia összes sorozatát.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Ha csak egy alakzathoz szükségesek az effektusok, először azonosítsa az alakzatot név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívja a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust. Ne feltételezze, hogy a [IShapeCollection.get_Item](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#get_Item-int-) `0` indexe mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy normál dián lévő helyőrző örökölheti az animációs viselkedést a hozzá tartozó helyőrzőtől az elrendezés diáján és a mesterdián. A [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getBasePlaceholder--) visszaadja azt a szülőhelyőrzőt, vagy `null`‑t, ha nincs szülő.

A következő példaprezentációban a láblécnek **Random Bars** animációja van a normál dián, **Split** az elrendezés dián, és **Fly In** a mesterdián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animációs effektus az elrendezés dián](layout-shape-animation.png)

![Lábléc helyőrző animációs effektus a mester dián](master-shape-animation.png)

A következő példa egy új prezentáció helyőrző hierarchiáját használja. Effektusokat ad egy mester‑helyőrzőhöz, egy elrendezés‑helyőrzőhöz és a megfelelő helyőrzőhöz a normál dián. Minden [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getBasePlaceholder--) hívást ellenőriz, mielőtt a visszakapott alakzatot felhasználná.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédablak a [ITiming](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/) tulajdonságait tükrözi.

![PowerPoint Időzítés párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** a [ITiming.getTriggerType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getTriggerType--) értékét tükrözi.
- **Duration** a [ITiming.getDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getDuration--) értékét tükrözi, másodpercben.
- **Delay** a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getTriggerDelayTime--) értékét tükrözi, másodpercben.
- **Repeat** a [ITiming.getRepeatCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), vagy a [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) értékét tükrözi.
- **Rewind when done playing** a [ITiming.getRewind](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRewind--) értékét tükrözi.

Ez a független példa egy effektust ad hozzá, az [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektummal módosítja annak időzítését, majd elmenti az eredményt. A visszaadott [IEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/) hivatkozás megtartása elkerüli a szükségtelen gyűjtemény‑indexelést.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Használjon egyetlen ismétlési módot szándékosan. Egy ismétlésszám és egy „until” jelző kombinálása zavaró eredményeket okozhat különböző lejátszókban. Ismétlési módok változtatásakor állítsa be a [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) és a [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) értékeket, mielőtt a [ITiming.setRepeatCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatCount-float-) hívná, mivel bármelyik jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangra hivatkozhat a [IEffect.getSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getSound--) segítségével. A [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) egy effektust arra utasítja, hogy állítsa le egy korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az első effektus hangjaként beágyazza ezt a fájlt, a második effektust úgy konfigurálja, hogy leállítsa a hangot. Az effektusokhoz a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumokat használja, így nincs szükség sorozat‑indexre.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Beágyazott effektus hangok kinyerése**

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Mind a fő, mind az interaktív sorozatot átvizsgálja, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést a [IAudio.getContentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudio/#getContentType--) által megadott audio MIME‑típus alapján választja ki.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Nagy audio‑objektumok esetén használja a [IAudio.getStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudio/#getStream--) metódust, és másolja a streamet egy fájlba ahelyett, hogy az egész objektumot bájt‑tömbbe töltené be.

## **Animáció utáni viselkedés beállítása**

A **After animation** opció szabályozza, mi történik egy alakzattal, miután az effektus befejeződik.

![PowerPoint Effektus beállítások párbeszédablak az Animáció utáni beállításokkal](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/) osztály támogatja az alakzat érintetlenül hagyását, színének megváltoztatását, az animáció után elrejtését, vagy a következő kattintásra való elrejtését. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color), akkor a [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) is beállítható.

Ez a független példa egy effektust hoz létre, a visszaadott effektusobjektummal beállítja az animáció utáni viselkedést, majd elmenti az eredményt.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Az [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color) típusról való eltérés törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó vezérlőelemre épül:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextanimation/#getBuildType--) azt szabályozza, hogy a bekezdések együtt vagy bekezdésenként jelenjenek meg.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getAnimateTextType--) azt határozza meg, hogy a szöveg egyszerre, szóként vagy betűként jelenjen meg. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) a szavak vagy betűk közötti késleltetést állítja be. A pozitív érték a effektus időtartamának százaléka, a negatív érték másodpercben megadott késleltetés.

A következő független példa animálja egy szövegdoboz szavait. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti felépítést, így a szóbeállítás az egész szövegkeretre vonatkozik.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

A szövegdobozt bekezdésenként felépíteni, állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (vagy másik bekezdés‑szintet). Egyetlen bekezdéshez saját effektussal a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) túlterhelést kell használni, amely egy [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/)‑t fogad. Lásd a [Animated Text](/slides/hu/java/animated-text/) oldalt bekezdés‑szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs megjelenítő szabályozza.
- A PDF és a statikus képek nem játszanak animációkat. Használjon [HTML5 export](/slides/hu/java/export-to-html5/), animált GIF-et vagy [videó konvertálást](/slides/hu/java/convert-powerpoint-to-video/), ha a kimenetnek mozgást kell mutatnia.
- HTML5‑hez engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) beállítást, és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) opciót.
- A videó renderelés sok gyakori belépő, hangsúlyozó, kilépő és mozgáspálya‑effektust támogat, de nem minden PowerPoint‑effektus érhető el. Ellenőrizze az aktuális [supported animations and effects](/slides/hu/java/convert-powerpoint-to-video/#supported-animations-and-effects) oldalt, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Az egyedi, fejlett effektusok és más formátumokból importált effektusok megmaradhatnak a fájlban, de PowerPointban, HTML5‑ben vagy videóban eltérő módon jelenhetnek meg. Ellenőrizze az exportált eredményt, ne csak az effektus nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF egy statikus formátum, ezért az animációk és diaváltások nem játszhatók le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként egy videóban?**

A videóexport a animációkat rendereli, nem az eredeti PowerPoint‑viselkedést tárolja. egyes fejlett effektusok nem támogatottak vagy csak közelítően jelennek meg. Tekintse meg a támogatott‑effektus táblázatot, és tesztelje a konkrét prezentációt a tényleges használat előtt.

**Megváltoztatja egy alakzat előre vagy hátra mozgatása az animáció sorrendjét?**

Nem. Az alakzat z‑rendje csak a rétegezést befolyásolja, míg a sorozat sorrendje és az indítók szabályozzák az animáció lejátszását. Ha más lejátszási sorrendre van szükség, módosítsa az idővonalat.