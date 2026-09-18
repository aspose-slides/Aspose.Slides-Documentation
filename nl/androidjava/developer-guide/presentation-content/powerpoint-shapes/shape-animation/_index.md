---
title: Vormanimaties toepassen in presentaties op Android
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/androidjava/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Om te werken met de afzonderlijke gedragingen binnen een effect of trajectsegmenten van beweging te bewerken, zie [Aangepaste animatie voor Java](/slides/nl/java/custom-animation/).

Aspose.Slides voor Android via Java stelt dia‑animaties voor als effecten in een diatijdlijn. Een effect heeft een doel‑vorm, een animatietype en subtype, een trigger, timing‑instellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten reeksen:

- De **hoofdreeks** wordt afgespeeld terwijl de dia wordt gepresenteerd.
- Een **interactieve reeks** start wanneer de trigger‑vorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, diagrammen, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) implementeren, gebruik je dezelfde [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de klasse [EffectType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttype/).

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdreeks van de dia op en roep je [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aan met de doel‑vorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve reeks waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide typen animaties en slaat het resultaat op in `shape-animations.pptx`.

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

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttriggertype/#OnClick) wacht op een klik in de hoofdreeks, of op een klik op de trigger‑vorm in een interactieve reeks.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) start gelijktijdig met het voorgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) start wanneer het voorgaande effect is voltooid.

Om een afbeelding, diagram of een ander type vorm te animeren, geef je dat object door aan [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) in plaats van `targetShape`. Voor diagram‑specifieke groeperingsopties, zie [Geanimeerde diagrammen](/slides/nl/androidjava/animated-charts/).

## **Vormanimaties lezen**

Gebruik [ISequence.getEffectsByShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) wanneer je de doel‑vorm kent. Om elk effect te inspecteren, doorloop je de hoofdreeks en elke interactieve reeks. Enumeratie voorkomt dat je aanneemt dat een reeks een effect op index `0` bevat.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effecten, haalt de effecten op die op de vorm gericht zijn, en doorloopt vervolgens elke reeks op de dia.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer je eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep daarna [ISequence.getEffectsByShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) aan. Ga er niet vanuit dat [IShapeCollection.get_Item](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) op index `0` altijd het bedoelde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een gewone dia kan animatiegedrag erven van de overeenkomstige placeholder op de lay‑outdia en de master‑dia. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) geeft die bovenliggende placeholder terug, of `null` wanneer er geen bovenliggend object bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de gewone dia, **Split** op de lay‑outdia en **Fly In** op de master‑dia.

![Animatie‑effect van voettekst op de gewone dia](slide-shape-animation.png)

![Animatie‑effect van voettekst‑placeholder op de lay‑outdia](layout-shape-animation.png)

![Animatie‑effect van voettekst‑placeholder op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een lay‑out‑placeholder en de overeenkomstige placeholder op een gewone dia. Elke aanroep van [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster komt overeen met de eigenschappen van [ITiming](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/).

![PowerPoint Timing‑dialoog voor een animatie‑effect](shape-animation.png)

- **Start** komt overeen met [ITiming.getTriggerType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** (duur) komt overeen met [ITiming.getDuration](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getDuration--), in seconden.
- **Delay** (vertraging) komt overeen met [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), in seconden.
- **Repeat** (herhalen) komt overeen met [ITiming.getRepeatCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), of [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** (terugspoelen bij voltooid) komt overeen met [ITiming.getRewind](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#getRewind--).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), en slaat het resultaat op. Het behouden van de geretourneerde [IEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/)‑referentie voorkomt een onnodige collectie‑index.

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

Gebruik één herhaal‑modus bewust. Het combineren van een herhaal‑aantal met een “until”‑vlag kan verwarrende resultaten geven in verschillende viewers. Bij het wijzigen van herhaal‑modi, stel [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) en [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) in vóór [ITiming.setRepeatCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), omdat het instellen van één van die vlaggen ook de actieve herhaal‑modus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan een ingebed audio‑bestand refereren via [IEffect.getSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) vertelt een effect om het eerder gestart geluid te stoppen.

### **Een geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embedt dat bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), zodat er geen reeksen‑index nodig is.

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

### **Ingebedde effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het doorzoekt zowel de hoofd‑ als de interactieve reeksen en schrijft elk ingebed effectgeluid weg naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audiomime‑type dat wordt teruggegeven door [IAudio.getContentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Voor grote audio‑objecten, gebruik [IAudio.getStream](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudio/#getStream--) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De **After animation**‑optie bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint Effect Options‑dialoog met After‑animation‑instellingen](shape-after-animation.png)

De klasse [AfterAnimationType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/) ondersteunt het ongewijzigd laten van de vorm, het wijzigen van de kleur, het verbergen na de animatie, of het verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#Color) is, stel je tevens [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het gedrag na de animatie in via het geretourneerde effectobject, en slaat het resultaat op.

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

Het wijzigen van het type van [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/afteranimationtype/#Color) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde instellingen:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextanimation/#getBuildType--) bepaalt of alinea’s tegelijk of per alinea‑niveau verschijnen.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) bepaalt of tekst in één keer, per woord of per letter verschijnt. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/buildtype/#AsOneObject) schakelt het op‑alinea‑basis bouwen uit zodat de woordinstelling van toepassing is op het volledige tekstkader.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) die een [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/androidjava/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt bepaald door de presentatie‑viewer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5‑export](/slides/nl/androidjava/export-to-html5/), een geanimeerde GIF of [video‑conversie](/slides/nl/androidjava/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Voor HTML5, schakel [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) in en, indien nodig, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Videoweergave ondersteunt veel gangbare binnenkomende, nadruk‑, uitgangs‑ en bewegings‑pad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [ondersteunde animaties en effecten](/slides/nl/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met de versie van Aspose.Slides die je gebruikt.
- Geavanceerde aangepaste effecten en effecten die zijn geïmporteerd uit andere presentatieformaten kunnen in het bestand behouden blijven, maar anders worden weergegeven in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen te vertrouwen op de effectnaam.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF of video wanneer beweging bewaard moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het oorspronkelijke PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of alleen benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie voordat je deze in productie gebruikt.

**Verandert het naar voren of naar achteren verplaatsen van een vorm de animatievolgorde?**

Nee. De z‑order van een vorm bepaalt de overlapping, terwijl de volgorde van de reeksen en triggers de animatie‑afspeelvolgorde bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.