---
title: Použití animací tvarů v prezentacích na Androidu
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Pro práci s jednotlivými chováními uvnitř efektu nebo úpravou segmentů motion‑path viz [Vlastní animace pro Java](/slides/cs/java/custom-animation/).

Aspose.Slides for Android via Java představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, časová nastavení a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **hlavní sekvence** se přehrává při postupu snímku.
- **interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku implementují [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), používáte stejnou metodu [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) pro většinu obsahu snímku. Dostupné efekty jsou vypsány ve třídě [EffectType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype/).

## **Přidání animací tvarů**

Pro přidání animace získáte hlavní sekvenci snímku a zavoláte [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začíná po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejímž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do `shape-animations.pptx`.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttriggertype/#OnClick) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) začíná současně s předchozím efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) začíná po dokončení předchozího efektu.

Pro animaci obrázku, grafu nebo jiného typu tvaru předáte tento objekt metodě [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) místo `targetShape`. Pro konkrétní možnosti seskupení grafu viz [Animované grafy](/slides/cs/androidjava/animated-charts/).

## **Čtení animací tvarů**

Použijte [ISequence.getEffectsByShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) když znáte cílový tvar. Pro prozkoumání každého efektu enumerujte hlavní sekvenci a všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s efekty v hlavní i interaktivní sekvenci, získá efekty cílené na tvar a poté projde všechny sekvence na snímku.

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

Pokud potřebujete efekty jen pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupce nebo jiné stabilní vlastnosti; poté zavolejte [ISequence.getEffectsByShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Nepředpokládejte, že [IShapeCollection.get_Item](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty zástupců**

Zástupce na běžném snímku může zdědit chování animace od odpovídajícího zástupce na rozvržení snímku a na hlavním snímku. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) vrací tohoto nadřazeného zástupce nebo `null`, pokud neexistuje.

V následující ukázkové prezentaci má zápatí **Random Bars** na běžném snímku, **Split** na rozvržení a **Fly In** na hlavním snímku.

![Animace zápatí na běžném snímku](slide-shape-animation.png)

![Animace zápatí na snímku rozvržení](layout-shape-animation.png)

![Animace zápatí na hlavním snímku](master-shape-animation.png)

Další příklad používá hierarchii zástupců z nové prezentace. Přidává efekty do hlavního zástupce, zástupce rozvržení a odpovídajícího zástupce na běžném snímku. Každé volání [IShape.getBasePlaceholder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) je před použitím vráceného tvaru ověřeno.

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

Dialog **Timing** v PowerPointu odpovídá vlastnostem [ITiming](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/).

![Dialog Timing v PowerPointu pro animační efekt](shape-animation.png)

- **Start** odpovídá [ITiming.getTriggerType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** odpovídá [ITiming.getDuration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getDuration--), v sekundách.
- **Delay** odpovídá [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), v sekundách.
- **Repeat** odpovídá [ITiming.getRepeatCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), nebo [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** odpovídá [ITiming.getRewind](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#getRewind--).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), a uloží výsledek. Uchování odkazu na vrácený [IEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/) zabraňuje zbytečnému indexování kolekce.

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

Používejte záměrně jen jeden režim opakování. Kombinace počtu opakování s příznakem „until“ může vést k nejasným výsledkům v různých prohlížečích. Při změně režimu opakování nastavte [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) a [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) před [ITiming.setRepeatCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), protože nastavení některého z příznaků také mění aktivní režim opakování.

## **Přidání a extrakce zvuků animací**

Efekt animace může odkazovat na vložený audio soubor pomocí [IEffect.getSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává lokální audio soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nakonfiguruje druhý efekt tak, aby zvuk zastavil. Používá objekty vrácené metodou [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), takže není vyžadován index sekvence.

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

Následující příklad očekává lokální prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá jak hlavní, tak interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána z audio MIME typu poskytovaného metodou [IAudio.getContentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Pro velké audio objekty použijte [IAudio.getStream](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudio/#getStream--) a zkopírujte stream do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** řídí, co se stane s tvarem po dokončení jeho efektu.

![Dialog možností efektu v PowerPointu ukazující nastavení After animation](shape-after-animation.png)

Třída [AfterAnimationType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color), nastavte také [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci prostřednictvím vráceného objektu efektu a uloží výsledek.

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

Změna typu od [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color) vymaže nastavení barvy po animaci.

## **Animace textu**

Animace textu má dva související ovladače:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextanimation/#getBuildType--) určuje, zda se odstavce objevují najednou nebo po jednotlivých odstavcích.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) určuje, zda se text objeví najednou, po slovech nebo po znacích. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) nastavuje prodlevu mezi slovy nebo znaky. Kladná hodnota je procento trvání efektu; záporná hodnota je prodleva v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/buildtype/#AsOneObject) vypíná stavbu po odstavcích, takže nastavení slova platí pro celý textový rámec.

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

Pro stavbu textového pole po odstavcích nastavte [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (nebo jinou úroveň odstavce). Pro cílení jediného odstavce s vlastním efektem použijte přetížení [ISequence.addEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) přijímající [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/). Viz [Animovaný text](/slides/cs/androidjava/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Uložení do PPT nebo PPTX zachová model animace, ale finální přehrávání řídí prohlížeč prezentace.
- PDF a statické obrázky animace nepřehrávají. Použijte [export do HTML5](/slides/cs/androidjava/export-to-html5/), animovaný GIF nebo [konverzi videa](/slides/cs/androidjava/convert-powerpoint-to-video/), když je nutné zobrazit pohyb.
- Pro HTML5 povolte [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a podle potřeby [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Rendering videa podporuje mnoho běžných efektů vstupu, důrazu, výstupu a motion‑path, ale ne všechny efekty PowerPointu jsou podporovány. Zkontrolujte aktuální [podporované animace a efekty](/slides/cs/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s verzí Aspose.Slides, kterou používáte.
- Pokročilé vlastní efekty a efekty importované z jiných formátů mohou být v souboru zachovány, ale vykreslí se odlišně v PowerPointu, HTML5 nebo videu. Výsledek exportu validujte, místo aby jste se spolehli jen na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, když je třeba zachovat pohyb.

**Proč se efekt přehrává odlišně ve videu?**

Export do videa renderuje animace místo ukládání původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prohlédněte si tabulku podporovaných efektů a otestujte konkrétní prezentaci před výrobním nasazením.

**Změní posunutí tvaru dopředu nebo dozadu jeho pořadí animací?**

Ne. Z‑order tvaru řídí překrývání, zatímco pořadí sekvence a spouštěče řídí přehrávání animací. Změňte časovou osu, pokud potřebujete jiný pořádek přehrávání.