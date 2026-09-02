---
title: Alakzatanimációk alkalmazása Android prezentációkban
linktitle: Alakzatanimáció
type: docs
weight: 60
url: /hu/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testreszabhat alakzatanimációkat, időzítést, hangokat, animáció utáni viselkedést és animált szöveget az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Android via Java a diavetítési animációkat effektusokként ábrázolja egy diát idővonalban. Egy effektusnak van cél objektuma, animáció típusa és altípusa, egy trigger, időzítési beállítások, és opcionális tulajdonságok, például hang vagy animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** a dia előrehaladtával játszódik.
- Egy **interaktív szekvencia** akkor indul, amikor a trigger alakra kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diára helyezett objektumok implementálják az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/), ezért a legtöbb diatartalomhoz ugyanazt a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust használhatja. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttype/) osztályban listázhatók.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze meg a dia fő szekvenciáját, és hívja meg az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust a cél alakkal, az effektus típusával, altípusával és a triggerrel. Ha egy effektus akkor kezdődik, amikor egy másik alakra kattintanak, hozzon létre egy interaktív szekvenciát, amelynek triggerje az a másik alak.

A következő példa mindkét típusú animációt létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

A trigger szabályozza, hogy egy effektus mikor indul:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#OnClick) a fő szekvenciában egy kattintásra, vagy egy interaktív szekvenciában a trigger alakra kattintásra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) akkor indul, amikor az előző effektus befejeződik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódusnak a `targetShape` helyett. Diagram-specifikus csoportosítási beállításokért lásd a [Animated Charts](/slides/hu/androidjava/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja az [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust, ha ismeri a cél alakot. Az összes effektus megtekintéséhez sorolja fel a fő szekvenciát és minden interaktív szekvenciát. A felsorolás elkerüli annak feltételezését, hogy egy szekvencia az `0` indexű effektust tartalmazza.

A következő példa egy alakzatot hoz létre fő-szekvenciás és interaktív effektusokkal, lekéri az alakzatra ható effektusokat, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakzatra vonatkozó effektusokra van szüksége, először azonosítsa az alakzatot név, helyfoglaló típus vagy más stabil tulajdonság alapján; ezután hívja meg az [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust. Ne feltételezze, hogy a [IShapeCollection.get_Item](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) `0` indexe mindig a kívánt objektum.

## **Örökölt helyfoglaló effektusok kezelése**

Egy normál dián lévő helyfoglaló örökölheti az animációs viselkedést a hozzá tartozó elrendezés-dián és a mester-dián lévő megfelelő helyfoglalótól. Az [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) visszaadja azt a szülőhelyfoglalót, vagy `null` értéket, ha nincs szülő.

A következő példaprezentációban a lábléc **Random Bars** animációt kap a normál dián, **Split** animációt az elrendezés-dián, és **Fly In** animációt a mester-dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyfoglaló animációs effektus az elrendezés dián](layout-shape-animation.png)

![Lábléc helyfoglaló animációs effektus a mester dián](master-shape-animation.png)

A következő példa egy új prezentáció helyfoglaló hierarchiáját használja. Effektusokat ad egy mester helyfoglalóhoz, egy elrendezés helyfoglalóhoz és a megfelelő helyfoglalóhoz a normál dián. Minden [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) hívást ellenőriznek, mielőtt a visszakapott alakzatot felhasználnák.

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

A PowerPoint **Timing** (Időzítés) párbeszédablaka a [ITiming](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/) tulajdonságaira vonatkozik.

![PowerPoint időzítési párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** a [ITiming.getTriggerType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getTriggerType--) -re térképeződik.
- **Duration** a [ITiming.getDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getDuration--) -re térképeződik, másodpercben.
- **Delay** a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) -re térképeződik, másodpercben.
- **Repeat** a [ITiming.getRepeatCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), vagy [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) -re térképeződik.
- **Rewind when done playing** a [ITiming.getRewind](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRewind--) -re térképeződik.

Ez az önálló példa egy effektust ad hozzá, megváltoztatja annak időzítését az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény index használatát.

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

Használjon egy ismétlési módot szándékosan. A repeat count (ismétlésszám) kombinálása egy „until” (eddig) jelzővel különböző megjelenítőben zavaró eredményeket okozhat. Ismétlési módok módosításakor állítsa be a [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) és a [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) metódusokat a [ITiming.setRepeatCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) előtt, mivel bármely jelző beállítása módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangra hivatkozhat a [IEffect.getSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getSound--) segítségével. A [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) azt mondja az effektusnak, hogy állítsa le az előző effektus által elindított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy `animation-sound.wav` nevű helyi hangfájlt vár. Két effektust hoz létre, az első effektus hangjaként beágyazza a fájlt, és a második effektust úgy konfigurálja, hogy leállítsa a hangot. A [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumokat használja, így nem szükséges szekvencia index.

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

A következő példa egy `presentation-with-animation-sounds.pptx` nevű helyi prezentációt vár. Átvizsgálja a fő és az interaktív szekvenciákat, és minden beágyazott effektus hangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést az [IAudio.getContentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudio/#getContentType--) által szolgáltatott audio MIME-típus alapján választja ki.

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

Nagy audio objektumok esetén használja a [IAudio.getStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudio/#getStream--) metódust, és a streamet másolja egy fájlba a teljes objektum byte tömbbe töltése helyett.

## **Animáció utáni viselkedés beállítása**

Az **After animation** (Animáció után) opció szabályozza, mi történik egy alakzattal, miután az effektusa befejeződik.

![PowerPoint effektus beállítások párbeszédablak mutatja az After animation beállításait](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/) osztály támogatja az alakzat változatlanul hagyását, színének módosítását, az animáció után elrejtését, vagy a következő kattintásnál való elrejtését. Ha a típus a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/#Color), akkor állítsa be a [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) értékét is.

Ez az önálló példa egy effektust hoz létre, beállítja annak animáció utáni viselkedését a visszakapott effektus objektumon keresztül, és elmenti az eredményt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

A [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/#Color) típusról való eltérés törli az animáció utáni szín beállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó vezérlése van:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextanimation/#getBuildType--) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) beállítja a szavak vagy betűk közötti késleltetést. A pozitív érték a effektus időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

A következő önálló példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti építést, így a szó beállítás a teljes szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (vagy más bekezdés szintet). Egyetlen bekezdés egyedi effektusának célzásához használja az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) túlterhelését, amely egy [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) paramétert fogad. Lásd a [Animated Text](/slides/hu/androidjava/animated-text/) oldalt bekezdés-szintű példákért.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentáció megjelenítője szabályozza.
- A PDF és a statikus képek nem játszanak animációt. Használjon [HTML5 export](/slides/hu/androidjava/export-to-html5/), animált GIF-et vagy [videó konverziót](/slides/hu/androidjava/convert-powerpoint-to-video/), ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) beállításait.
- A videó renderelés sok általános belépési, hangsúlyozó, kilépési és mozgásúti effektust támogat, de nem minden PowerPoint effektus támogatott. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- A fejlett egyedi effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de másként jelennek meg PowerPointban, HTML5-ben vagy videóban. Ellenőrizze az exportált eredményt, ne csak az effektus nevére támaszkodjon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF-ben?**  
A PDF statikus formátum, ezért az animációk és diaátmenetek nem játszódnak le. Exportáljon HTML5-re, animált GIF-re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másképp videóban?**  
A videóexport animációkat renderel, nem a PowerPoint eredeti viselkedését tárolja. Néhány fejlett effektus nem támogatott vagy csak közelítőleg jelenik meg. Tekintse át a támogatott effektusok táblázatát, és tesztelje a tényleges prezentációt a gyártás előtt.

**Az alakzat előre vagy hátra mozgatása megváltoztatja az animáció sorrendjét?**  
Nem. Az alakzat z-rendje csak a rétegezést (átfedést) szabályozza, míg a szekvencia sorrend és a triggerek irányítják az animáció lejátszását. Módosítsa az idővonalat, ha más lejátszási sorrendre van szükség.