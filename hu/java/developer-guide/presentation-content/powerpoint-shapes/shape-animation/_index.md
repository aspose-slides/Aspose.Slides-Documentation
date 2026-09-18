---
title: Alakzatanimációk alkalmazása előadásokban Java használatával
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
- előadás
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az egyes viselkedések egy effektuson belül vagy a mozgásútra vonatkozó szegmensek szerkesztéséhez lásd a [Custom Animation](/slides/hu/java/custom-animation/) oldalt.

Az Aspose.Slides for Java a diaanimációkat effektusként ábrázolja egy diavetítési idővonalban. Egy effektus rendelkezik cél alakzattal, animáció típussal és altípussal, egy aktiválóval, időzítési beállításokkal, valamint opcionális tulajdonságokkal, mint például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **main sequence** a dia előrehaladtával lejátszódik.
- Egy **interactive sequence** akkor indul, amikor a hozzá tartozó aktiváló alakzatot rákattintják.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diatartalomhoz ugyanazt a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust használhatja. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttype/) osztályban vannak felsorolva.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze meg a dia fő szekvenciáját, és hívja meg a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódust a cél alakzattal, effektustípussal, altípussal és aktiválóval. Ha egy effektust szeretne, amely egy másik alakzatra kattintáskor indul, hozzon létre egy interactive sequence‑t, amelynek aktiválója az a másik alakzat.

Az alábbi példa létrehozza mindkét típusú animációt, és a `shape-animations.pptx` fájlba menti az eredményt.

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

Az aktiváló szabályozza, mikor kezdődik egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#OnClick) a fő szekvenciában kattintásra, vagy egy interactive sequence‑ben az aktiváló alakzatra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/java/com.aspose.slides/effecttriggertype/#AfterPrevious) az előző effektus befejeződésével kezdődik.

Kép, diagram vagy más alakzattípus animálásához adja át azt az objektumot a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metódusnak a `targetShape` helyett. A diagram-specifikus csoportosítási beállításokért lásd a [Animated Charts](/slides/hu/java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust, ha ismeri a cél alakzatot. Minden effektus megvizsgálásához enumerálja a fő szekvenciát és minden interactive sequence‑t. Az enumerálás elkerüli azt a feltevést, hogy egy szekvencia `0` indexű effektust tartalmaz.

Az alábbi példa létrehozza egy alakzatot fő- és interactive szekvenciás effektekkel, lekéri az alakzatot célozó effektusokat, majd enumerálja a dia minden szekvenciáját.

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

Ha csak egy alakzatra van szüksége, először azonosítsa az alakzatot név, placeholder típus vagy más stabil tulajdonság alapján; ezután hívja meg a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metódust. Ne tegyen feltevést, hogy a [IShapeCollection.get_Item](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#get_Item-int-) `0` indexű eleme mindig a kívánt objektum.

## **Örökölt placeholder effektusok kezelése**

A normál dián lévő placeholder örökölheti az animációs viselkedést a hozzá tartozó layout dián és mesterdián lévő placeholderből. A [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getBasePlaceholder--) visszaadja azt a szülő placeholder‑t, vagy `null`‑t, ha nincs szülő.

A következő bemutatóban a láblécnek **Random Bars** animációja van a normál dián, **Split** a layout dián, és **Fly In** a mesterdián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc placeholder animációs effektus a layout dián](layout-shape-animation.png)

![Lábléc placeholder animációs effektus a mesterdián](master-shape-animation.png)

A következő példa egy új bemutató placeholder hierarchiáját használja. Effektusokat ad egy mester placeholderhez, egy layout placeholderhez, és a megfelelő placeholderhez a normál dián. Minden [IShape.getBasePlaceholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getBasePlaceholder--) hívást ellenőriznek, mielőtt a visszakapott alakzatot felhasználnák.

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

A PowerPoint **Timing** párbeszédpanel a [ITiming](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/) tulajdonságaira van leképezve.

![PowerPoint időzítési párbeszédpanel egy animációs effektushoz](shape-animation.png)

- **Start** a [ITiming.getTriggerType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getTriggerType--) metódusra térképeződik.
- **Duration** a [ITiming.getDuration](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getDuration--) értékre, másodpercben.
- **Delay** a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getTriggerDelayTime--) értékre, másodpercben.
- **Repeat** a [ITiming.getRepeatCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), vagy [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) értékére.
- **Rewind when done playing** a [ITiming.getRewind](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#getRewind--) értékre.

Ez a független példa hozzáad egy effektust, módosítja az időzítését a [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjteményindex használatát.

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

Használjon egy ismétlési módot szándékosan. A repeat count és egy „until” jelző kombinálása zavaró eredményeket okozhat különböző megjelenítőkben. Ismétlési módok változtatásakor állítsa be a [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) és az [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) metódusokat a [ITiming.setRepeatCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiming/#setRepeatCount-float-) előtt, mivel bármely jelző beállítása is módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [IEffect.getSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getSound--) segítségével. A [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) azt mondja az effektusnak, hogy állítsa le a korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az első effektushoz beágyazza ezt a fájlt hangként, a második effektust úgy konfigurálja, hogy megállítsa a hangot. A [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) által visszaadott objektumokat használja, így nincs szükség szekvencia indexre.

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

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű bemutatót vár. Átvizsgálja a fő és interactive szekvenciákat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés az [IAudio.getContentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudio/#getContentType--) által visszaadott audio MIME‑típus alapján kerül kiválasztásra.

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

Nagy audio objektumok esetén használja az [IAudio.getStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudio/#getStream--) metódust, és a streamet fájlba másolja ahelyett, hogy az egész objektumot byte‑tömbbe töltené.

## **Az animáció utáni viselkedés beállítása**

A **After animation** beállítás szabályozza, hogy mi történik az alakzattal, miután az effektusa befejeződik.

![PowerPoint effektus opciók párbeszédablak az After animation beállításokkal](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/) osztály támogatja, hogy az alakzat változatlan maradjon, színt változtasson, a animáció után elrejtse, vagy a következő kattintásnál rejtse el. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/afteranimationtype/#Color), akkor a [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) értékét is be kell állítani.

Ez a független példa létrehoz egy effektust, a visszaadott effektusobjektumon keresztül beállítja az animáció utáni viselkedést, és elmenti az eredményt.

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

A [AfterAnimationType.Color] típusól való eltérés törli az animáció utáni szín beállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó vezérlővel rendelkezik:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextanimation/#getBuildType--) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getAnimateTextType--) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) a szavak vagy betűk közti késleltetést állítja be. A pozitív érték az effektus időtartamának százalékában, a negatív érték másodpercben adja meg a késleltetést.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti felépítést, így a szó beállítás a teljes szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (vagy egy másik bekezdés szintet). Egyetlen bekezdés saját effektussal való célzásához használja az [ISequence.addEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) olyan túlterhelését, amely egy [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) paramétert fogad. A bekezdés‑szintű példákért lásd a [Animated Text](/slides/hu/java/animated-text/) oldalt.

## **Exportálási és kompatibilitási megjegyzések**

- PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a bemutató megjelenítő szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használjon [HTML5 export](/slides/hu/java/export-to-html5/), animált GIF-et, vagy [videó konvertálást](/slides/hu/java/convert-powerpoint-to-video/), ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) beállítást, és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) opciót.
- A videó renderelés támogatja a legtöbb gyakori belépési, hangsúlyozási, kilépési és mozgásútra vonatkozó effektust, de nem minden PowerPoint effektus támogatott. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/java/convert-powerpoint-to-video/#supported-animations-and-effects) listát, és tesztelje a kritikus bemutatókat a használt Aspose.Slides verzióval.
- A fejlett egyedi effektusok és más bemutatóformátumokból importált effektusok megmaradhatnak a fájlban, de eltérően renderelődnek PowerPoint, HTML5 vagy videó esetén. Érvényesítse az exportált eredményt, ne csak az effektus nevére hagyatkozzon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem PDF-ben?**

A PDF statikus formátum, ezért az animációk és diaátmenetek nem játszhatók le. Exportáljon HTML5-re, animált GIF-re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként videóban?**

A videó exportálás az animációkat rendereli, nem tárolja az eredeti PowerPoint viselkedést. Néhány fejlett effektus nem támogatott vagy csak közelítően jelenik meg. Tekintse meg a támogatott effektusok táblázatát, és tesztelje a tényleges bemutatót a gyártás előtt.

**A forma előre vagy hátra helyezése megváltoztatja az animáció sorrendjét?**

Nem. Az alakzat z‑rendje csak a megjelenést (átfedést) szabályozza, míg a szekvencia sorrend és a trigger az animáció lejátszását. Módosítsa az idővonalat, ha más lejátszási sorrendre van szüksége.