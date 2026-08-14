---
title: Použití animací tvarů v prezentacích pomocí Javy
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/java/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides pro Java představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **hlavní sekvence** se přehrává při postupu snímku.
- **interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku implementují [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), používáte stejnou metodu [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pro většinu obsahu snímku. Dostupné efekty jsou vypsány ve třídě [EffectType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype/).

## **Přidání animací tvarů**

Chcete‑li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začíná po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejíž spouštěč je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do souboru `shape-animations.pptx`.

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

Spouštěč určuje, kdy se efekt spustí:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttriggertype/#OnClick) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttriggertype/#WithPrevious) začíná současně s předchozím efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttriggertype/#AfterPrevious) začíná po dokončení předchozího efektu.

Chcete‑li animovat obrázek, graf nebo jiný typ tvaru, předložte tento objekt metodě [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) místo `targetShape`. Pro možnost seskupení specifickou pro grafy viz [Animované grafy](/slides/cs/java/animated-charts/).

## **Čtení animací tvarů**

Použijte [ISequence.getEffectsByShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) pokud znáte cílový tvar. Pro prohlédnutí každého efektu enumerujte hlavní sekvenci i všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s hlavními a interaktivními efekty, získá efekty, které cílí na tento tvar, a poté enumeruje všechny sekvence na snímku.

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

Pokud potřebujete efekty pouze pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupce nebo jiné stabilní vlastnosti; poté zavolejte [ISequence.getEffectsByShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Nepředpokládejte, že [IShapeCollection.get_Item](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#get_Item-int-) na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty zástupců**

Zástupce na normálním snímku může dědit chování animace ze stejného zástupce na snímku rozvržení a hlavním snímku. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getBasePlaceholder--) vrací tento rodičovský zástupce nebo `null`, pokud žádný rodič neexistuje.

V následující ukázkové prezentaci má zápatí **Random Bars** na normálním snímku, **Split** na snímku rozvržení a **Fly In** na hlavním snímku.

![Animace zápatí na normálním snímku](slide-shape-animation.png)

![Animace zástupce zápatí na snímku rozvržení](layout-shape-animation.png)

![Animace zástupce zápatí na hlavním snímku](master-shape-animation.png)

Další příklad používá hierarchii zástupců z nové prezentace. Přidává efekty k hlavnímu zástupci, zástupci rozvržení a odpovídajícímu zástupci na normálním snímku. Každé volání [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getBasePlaceholder--) je před použitím vráceného tvaru zkontrolováno.

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

## **Změna časování animace**

Dialog PowerPoint **Timing** mapuje na vlastnosti [ITiming](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/).

![Dialog časování PowerPointu pro efekt animace](shape-animation.png)

- **Start** mapuje na [ITiming.getTriggerType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** mapuje na [ITiming.getDuration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getDuration--), v sekundách.
- **Delay** mapuje na [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getTriggerDelayTime--), v sekundách.
- **Repeat** mapuje na [ITiming.getRepeatCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), nebo [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** mapuje na [ITiming.getRewind](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#getRewind--).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), a uloží výsledek. Udržení reference na vrácený [IEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/) zabraňuje zbytečnému indexu v kolekci.

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

Úmyslně používejte jeden režim opakování. Kombinace počtu opakování s příznakem „until“ může způsobit zmatené výsledky v různých prohlížečích. Při změně režimů opakování nastavte [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) a [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) před [ITiming.setRepeatCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiming/#setRepeatCount-float-), protože nastavení kteréhokoli z příznaků také mění aktivní režim opakování.

## **Přidání a extrahování zvuků animací**

Animovaný efekt může odkazovat na vložený zvuk pomocí [IEffect.getSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává místní zvukový soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví druhý efekt tak, aby zastavil zvuk. Používá objekty vrácené metodou [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), takže není potřeba index sekvence.

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

### **Extrahování vložených zvuků efektů**

Následující příklad očekává místní prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána podle MIME typu zvuku, který poskytuje [IAudio.getContentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudio/#getContentType--).

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

U velkých zvukových objektů použijte [IAudio.getStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudio/#getStream--) a zkopírujte stream do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Volba **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog možností efektu PowerPointu zobrazující nastavení After animation](shape-after-animation.png)

Třída [AfterAnimationType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color), nastavte také [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a uloží výsledek.

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

Změna typu od [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dva související ovladače:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextanimation/#getBuildType--) řídí, zda se odstavce zobrazují najednou nebo po úrovních odstavců.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getAnimateTextType--) řídí, zda se text zobrazí najednou, po slovech nebo po znacích. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) nastavuje prodlevu mezi slovy nebo znaky. Kladná hodnota je procento trvání efektu; záporná hodnota je prodleva v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/buildtype/#AsOneObject) deaktivuje tvorbu odstavec po odstavci, takže nastavení slov se použije na celý textový rámec.

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

Chcete‑li vytvářet textové pole po odstavcích, nastavte [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/cs/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (nebo jinou úroveň odstavce). Pro cílení na jeden odstavec s vlastním efektem použijte přetížení [ISequence.addEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-), které přijímá [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/). Viz [Animovaný text](/slides/cs/java/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Uložení do PPT nebo PPTX zachovává model animací, ale finální přehrávání řídí prohlížeč prezentace.
- PDF a statické obrázky nepřehrávají animace. Použijte [HTML5 export](/slides/cs/java/export-to-html5/), animovaný GIF nebo [video konverzi](/slides/cs/java/convert-powerpoint-to-video/), pokud výstup musí zobrazovat pohyb.
- Pro HTML5 povolte [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a v případě potřeby také [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Vykreslování videa podporuje mnoho běžných vstupních, zdůrazňujících, ukončujících a pohybových efektů, ale ne každý efekt PowerPointu je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/java/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale mohou se v PowerPointu, HTML5 nebo videu vykreslovat odlišně. Ověřte exportovaný výsledek místo spoléhání se jen na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, pokud je třeba zachovat pohyb.

**Proč se efekt přehrává odlišně ve videu?**

Export do videa vykresluje animace místo uložení původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prohlédněte si tabulku podporovaných efektů a otestujte skutečnou prezentaci před nasazením do výroby.

**Mění přesunutí tvaru dopředu nebo dozadu jeho pořadí animací?**

Ne. Z‑řazení tvaru určuje překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animací. Změňte časovou osu, pokud potřebujete jiné pořadí přehrávání.