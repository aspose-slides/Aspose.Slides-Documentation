---
title: Applicera formanimationer i presentationer med Java
linktitle: Formanimation
type: docs
weight: 60
url: /sv/java/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, efter‑animationsbeteende och animerad text med Aspose.Slides för Java."
---
## **Översikt**

För att arbeta med de enskilda beteendena i en effekt eller redigera rörelsebansegment, se [Anpassad animation](/slides/sv/java/custom-animation/).

Aspose.Slides för Java representerar bildanimationer som effekter i en bildtidslinje. En effekt har en målform, en animationstyp och undertyp, en utlösare, tidsinställningar och valfria egenskaper såsom ljud eller efter‑animation beteende.

Tidslinjen innehåller två typer av sekvenser:

- **Huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startar när dess utlösande form klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt implementerar [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/), använder du samma [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) metod för det mesta bildinnehåll. De tillgängliga effekterna listas i klassen [EffectType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation, hämta bildens huvudsekvens och anropa [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) med målformen, effekt‑typen, undertypen och utlösaren. För en effekt som startar när en annan form klickas, skapa en interaktiv sekvens vars utlösare är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Utlösaren styr när en effekt startar:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effecttriggertype/#OnClick) väntar på ett klick i huvudsekvensen, eller på ett klick på utlösande form i en interaktiv sekvens.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effecttriggertype/#WithPrevious) startar med föregående effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/sv/java/com.aspose.slides/effecttriggertype/#AfterPrevious) startar när föregående effekt slutar.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) i stället för `targetShape`. För diagramspecifika grupperingsalternativ, se [Animera diagram](/slides/sv/java/animated-charts/).

## **Läs formanimationer**

Använd [ISequence.getEffectsByShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) när du känner till målformen. För att inspektera varje effekt, enumerera huvudsekvensen och varje interaktiv sekvens. Enumerering undviker antagandet att en sekvens innehåller en effekt på index `0`.

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

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller en annan stabil egenskap; anropa därefter [ISequence.getEffectsByShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Anta inte att [IShapeCollection.get_Item](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#get_Item-int-) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsbeteende från motsvarande platshållare på dess layout‑bild och master‑bild. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getBasePlaceholder--) returnerar den överordnade platshållaren, eller `null` när ingen förälder finns.

I följande exempelpresentation har sidfoten **Random Bars** på den vanliga bilden, **Split** på layout‑bilden och **Fly In** på master‑bilden.

![Fotanimationseffekt på normal bild](slide-shape-animation.png)

![Fotplatshållare animationseffekt på layoutbild](layout-shape-animation.png)

![Fotplatshållare animationseffekt på masterbild](master-shape-animation.png)

Nästa exempel använder en platshållar‑hierarki från en ny presentation. Det lägger till effekter på en master‑platshållare, en layout‑platshållare och den motsvarande platshållaren på en normal bild. Varje anrop till [IShape.getBasePlaceholder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getBasePlaceholder--) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint **Timing**‑dialogen motsvarar egenskaperna i [ITiming](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/).

![PowerPoint Timing-dialog för en animationseffekt](shape-animation.png)

- **Start** motsvarar [ITiming.getTriggerType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getTriggerType--).
- **Varaktighet** motsvarar [ITiming.getDuration](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getDuration--), i sekunder.
- **Fördröjning** motsvarar [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getTriggerDelayTime--), i sekunder.
- **Upprepning** motsvarar [ITiming.getRepeatCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), eller [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Spola tillbaka när spelning är klar** motsvarar [ITiming.getRewind](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#getRewind--).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), och sparar resultatet. Att behålla den returnerade [IEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/)‑referensen undviker ett onödigt samlingsindex.

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

Använd ett upprepningsläge medvetet. Att kombinera ett upprepningsantal med ett “tills”-flagga kan ge förvirrande resultat i olika visare. När du byter upprepningslägen, sätt [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) och [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) innan du anropar [ITiming.setRepeatCount](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiming/#setRepeatCount-float-), eftersom att sätta antingen flagga också ändrar det aktiva upprepningsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera till inbäddat ljud via [IEffect.getSound](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) talar om för en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud till en effekt**

Följande exempel förutsätter en lokal ljudfil med namnet `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten, och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), så inget sekvensindex krävs.

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

### **Extrahera inbäddade effektsljud**

Följande exempel förutsätter en lokal presentation med namnet `presentation-with-animation-sounds.pptx`. Det skannar både huvud‑ och interaktiva sekvenser och skriver varje inbäddat effektsljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [IAudio.getContentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaudio/#getContentType--).

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

För stora ljudobjekt, använd [IAudio.getStream](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iaudio/#getStream--) och kopiera strömmen till en fil istället för att ladda hela objektet i en byte‑array.

## **Ställ in efter‑animation beteende**

**After animation**‑alternativet styr vad som händer med en form efter att dess effekt har avslutats.

![PowerPoint effektalternativdialog som visar efter‑animation inställningar](shape-after-animation.png)

Klassen [AfterAnimationType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/) stödjer att låta formen förbli oförändrad, ändra dess färg, dölja den efter animationen, eller dölja den vid nästa klick. När typen är [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#Color), sätt även [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Detta fristående exempel skapar en effekt, sätter dess efter‑animation beteende via det returnerade effekt‑objektet, och sparar resultatet.

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

Att ändra typen från [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/afteranimationtype/#Color) rensar inställningen för efter‑animation färg.

## **Animera text**

Textanimation har två relaterade kontroller:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextanimation/#getBuildType--) styr huruvida stycken visas tillsammans eller per styckenivå.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#getAnimateTextType--) styr huruvida text visas på en gång, per ord eller per bokstav. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentandel av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animerar orden i en textruta. [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/java/com.aspose.slides/buildtype/#AsOneObject) inaktiverar stycke‑för‑stycke‑byggnad så att ordinställningen gäller hela textramen.

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

För att bygga en textruta per stycke, sätt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/sv/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (eller en annan styckenivå). För att rikta en enskild paragraf med sin egen effekt, använd den [ISequence.addEffect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) överlagring som accepterar ett [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/). Se [Animera text](/slides/sv/java/animated-text/) för exempel på styckenivå.

## **Export- och kompatibilitetsanteckningar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutliga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5-export](/slides/sv/java/export-to-html5/), animerad GIF eller [videokonvertering](/slides/sv/java/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) och, vid behov, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Videorendering stöder många vanliga inträdes‑, betoning‑, utgångs‑ och rörelse‑ban‑effekter, men inte varje PowerPoint‑effekt stöds. Kontrollera de aktuella [stödda animationerna och effekterna](/slides/sv/java/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med din mål‑Aspose.Slides‑version.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas annorlunda i PowerPoint, HTML5 eller video. Validera det exporterade resultatet snarare än att enbart lita på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Videosexport renderar animationer snarare än att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen med stödda effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar flyttning av en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och utlösare styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.