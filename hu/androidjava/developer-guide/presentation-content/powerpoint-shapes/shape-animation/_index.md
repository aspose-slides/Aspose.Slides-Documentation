---
title: Alkalmazzon alakzat animációkat Androidon a prezentációkban
linktitle: Alakzat animáció
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
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testreszabhat alakzati animációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

Az effektusok egyedi viselkedésével való munkához vagy a mozgásútvonal-szegmensek szerkesztéséhez, lásd a [Custom Animation for Java](/slides/hu/java/custom-animation/).

Az Aspose.Slides for Android via Java a diaanimációkat effektusokként jeleníti meg egy diaidővonalon. Egy effektusnak van célalakja, animáció típusa és altípusa, egy trigger, időzítési beállítások, valamint opcionális tulajdonságok, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle sorozatot tartalmaz:

- A **fő sorozat** a dia haladtával játszódik le.
- Egy **interaktív sorozat** akkor indul, amikor a trigger alakra kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diaelemhez ugyanazt a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust használhatja. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze meg a dia fő sorozatát, és hívja meg a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust a célalak, az effektustípus, az altípus és a trigger megadásával. Ha egy effektust úgy szeretne indítani, hogy egy másik alakra kattintanak, hozzon létre egy interaktív sorozatot, amelynek triggerje ez a másik alak.

Az alábbi példa mindkét típusú animációt létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

A trigger határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#OnClick) a fő sorozatban kattintásra vagy az interaktív sorozat trigger alakjára vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) akkor kezdődik, amikor az előző effektus befejeződik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódusnak a `targetShape` helyett. A diagramokra vonatkozó csoportosítási lehetőségekért lásd a [Animated Charts](/slides/hu/androidjava/animated-charts/).

## **Alakzatanimációk olvasása**

Használja a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust, ha ismeri a célalakot. Minden effektus megtekintéséhez járja be a fő sorozatot és minden interaktív sorozatot. A feltérképezés elkerüli annak a feltételezését, hogy egy sorozat a `0` indexű effektust tartalmazza.

Az alábbi példa egy alakzatot hoz létre fő- és interaktív effektusokkal, lekéri az alakzatot célzó effektusokat, majd végigjárja a dián lévő összes sorozatot.

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

Ha csak egy alakzatra van szüksége, először azonosítsa az alakzatot név, helykitöltő típus vagy más stabil tulajdonság alapján; ezután hívja meg a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust. Ne feltételezze, hogy a [IShapeCollection.get_Item](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) a `0` indexen mindig a kívánt objektum.

## **Örökölt helykitöltő hatások kezelése**

Egy helykitöltő a normál dián örökölheti az animációs viselkedést a megfelelő helykitöltőtől a master‑diáról vagy a layout‑diáról. A [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) visszaadja ezt a szülőhelykitöltőt, vagy `null`‑t, ha nincs szülő.

Az alábbi példa‑prezentációban a láblécnek **Random Bars** animációja van a normál dián, **Split** a layout‑dián, és **Fly In** a master‑dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helykitöltő animációja a layout‑dián](layout-shape-animation.png)

![Lábléc helykitöltő animációja a master‑dián](master-shape-animation.png)

A következő példa egy új prezentáció helykitöltő‑hierarchiáját használja. Effektusokat ad egy master‑helykitöltőhöz, egy layout‑helykitöltőhöz és a megfelelő helykitöltőhöz a normál dián. Minden [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) hívás ellenőrzésre kerül, mielőtt a visszakapott alakzatot felhasználnák.

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

A PowerPoint **Timing** párbeszédablaka a [ITiming](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/) tulajdonságaira térképeződik.

![PowerPoint időzítési párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** a [ITiming.getTriggerType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getTriggerType--) értékére vonatkozik.
- **Duration** a [ITiming.getDuration](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getDuration--) értékét jelenti másodpercben.
- **Delay** a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) értékét jelenti másodpercben.
- **Repeat** a [ITiming.getRepeatCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatCount--), a [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) vagy a [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) beállításokra vonatkozik.
- **Rewind when done playing** a [ITiming.getRewind](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#getRewind--) értékét jelenti.

Ez a független példa egy effektust ad hozzá, a [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektummal módosítja az időzítését, és elmenti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény‑indexelést.

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

Használjon egy ismétlési módot szándékosan. Az ismétlésszám és egy „until” zászló együttes használata zavaró eredményeket okozhat különböző lejátszókban. Amikor ismétlési módokat változtat, állítsa be először a [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) és a [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) értékét, majd a [ITiming.setRepeatCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) metódust, mivel bármelyik zászló beállítása automatikusan módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott audióra hivatkozhat a [IEffect.getSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getSound--) metódussal. A [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) megmondja egy effektusnak, hogy állítsa le az előző effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az első effektushoz beágyazza ezt a fájlt hangként, a második effektust pedig úgy konfigurálja, hogy leállítsa a hangot. A [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumokat használja, így nem szükséges sorozat‑indexet megadni.

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

### **Beágyazott effektushangok kinyerése**

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Bejárja a fő és az interaktív sorozatokat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír ki. A kiterjesztés a [IAudio.getContentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudio/#getContentType--) által visszaadott audio MIME‑típus alapján kerül kiválasztásra.

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

Nagy audio objektumok esetén használja a [IAudio.getStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudio/#getStream--) metódust, és másolja a streamet egy fájlba ahelyett, hogy az egész objektumot byte‑tömbbe töltené be.

## **Az animáció utáni viselkedés beállítása**

Az **After animation** beállítás szabályozza, mi történik egy alakzattal az effektus befejezése után.

![PowerPoint effektusbeállítások párbeszédablak az After animation beállításokkal](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/) osztály támogatja a forma változatlan hagyását, a szín módosítását, a forma elrejtését az animáció után, vagy a következő kattintásra történő elrejtést. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/#Color), akkor a [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) is beállítható.

Ez a független példa egy effektust hoz létre, a visszakapott effektusobjektummal beállítja az animáció utáni viselkedést, és elmenti az eredményt.

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

A típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/afteranimationtype/#Color)‑ról való eltávolítása törli az after‑animation színbeállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó vezérlése van:

- A [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextanimation/#getBuildType--) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- Az [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) határozza meg, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) a szavak vagy betűk közti késleltetést állítja be. A pozitív érték az effektus időtartamának százalékában, a negatív érték másodpercben megadott késleltetés.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti építést, így a szó‑beállítás az egész szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti építéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (vagy másik bekezdés‑szint) értéket. Egyetlen bekezdéshez, saját effektussal, használja az [ISequence.addEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) túlterhelt változatát, amely egy [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) objektumot fogad. Lásd az [Animated Text](/slides/hu/androidjava/animated-text/) oldalt a bekezdés‑szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- PPT vagy PPTX mentése megőrzi az animációs modellt, de a végső lejátszást a prezentáció‑megtekintő szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használjon [HTML5 export](/slides/hu/androidjava/export-to-html5/), animált GIF‑et vagy [videókonverziót](/slides/hu/androidjava/convert-powerpoint-to-video/), ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) beállításokat.
- A videórenderelés sok gyakori belépő, hangsúlyozó, kilépő és mozgásútvonal‑effektust támogat, de nem minden PowerPoint‑effektus érhető el. Ellenőrizze az aktuális [támogatott animációkat és effektusokat](/slides/hu/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Az egyedi hatások és más formátumokból importált hatások megmaradhatnak a fájlban, de PowerPoint‑ban, HTML5‑ben vagy videóban eltérően jelenhetnek meg. Ellenőrizze az exportált eredményt, ne csak a hatás nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF egy statikus formátum, ezért az animációk és diaváltások nem játszhatók le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként egy videóban?**

A videóexport animációkat renderel, a helyett, hogy az eredeti PowerPoint‑viselkedést tárolná. Néhány fejlett effektus nem támogatott vagy csak közelítően jelenik meg. Tekintse meg a támogatott‑effektus táblázatot és tesztelje a tényleges prezentációt a termelés előtt.

**Megváltoztatja egy alakzat előre vagy hátra helyezése az animáció sorrendjét?**

Nem. Az alakzat z‑rendje csak az átfedést szabályozza, míútt a sorozatrend és a triggerek az animáció lejátszását. Ha más lejátszási sorrendre van szükség, módosítsa az idővonalat.