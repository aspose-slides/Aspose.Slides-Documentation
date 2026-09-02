---
title: Vormanimaties toepassen in presentaties met Java
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java stelt dia‑animaties voor als effecten in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, tijdinstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten reeksen:

- De **hoofdsequentie** wordt afgespeeld terwijl de dia voortschrijdt.
- Een **interactieve sequentie** start wanneer de trigger‑vorm erop wordt geklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) implementeren, gebruik je dezelfde [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)‑methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de [EffectType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttype/)‑klasse.

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdsequentie van de dia op en roep je [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve sequentie waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animaties aan en slaat het resultaat op in `shape-animations.pptx`.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttriggertype/#OnClick) wacht op een klik in de hoofdsequentie, of op een klik op de trigger‑vorm in een interactieve sequentie.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttriggertype/#WithPrevious) start gelijktijdig met het voorgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/java/com.aspose.slides/effecttriggertype/#AfterPrevious) start wanneer het voorgaande effect is afgelopen.

Om een afbeelding, grafiek of een ander vormtype te animeren, geef je dat object door aan [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) in plaats van `targetShape`. Voor diagram‑specifieke groepeeropties, zie [Animated Charts](/slides/nl/java/animated-charts/).

## **Vormanimaties lezen**

Gebruik [ISequence.getEffectsByShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) wanneer je de doelvorm kent. Om elk effect te inspecteren, doorloop je de hoofdsequentie en elke interactieve sequentie. Doorloop­enumeratie voorkomt de aanname dat een sequentie een effect op index `0` bevat.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer die vorm eerst op naam, placeholder‑type of een andere stabiele eigenschap; roep daarna [ISequence.getEffectsByShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) aan. Ga niet ervan uit dat [IShapeCollection.get_Item](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#get_Item-int-) op index `0` altijd het bedoelde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag erven van de overeenkomstige placeholder op de layout‑dia en de master‑dia. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getBasePlaceholder--) retourneert die bovenliggende placeholder, of `null` wanneer er geen bovenliggende bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de layout‑dia en **Fly In** op de master‑dia.

![Voettekst‑animatie‑effect op de normale dia](slide-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de layout‑dia](layout-shape-animation.png)

![Voettekst‑placeholder‑animatie‑effect op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een layout‑placeholder en de overeenkomstige placeholder op een normale dia. Elke oproep van [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getBasePlaceholder--) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

Het PowerPoint **Timing**‑dialoogvenster komt overeen met de eigenschappen van [ITiming](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/).

![PowerPoint Timing dialoog voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [ITiming.getTriggerType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duur** correspondeert met [ITiming.getDuration](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getDuration--), in seconden.
- **Vertraging** correspondeert met [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getTriggerDelayTime--), in seconden.
- **Herhalen** correspondeert met [ITiming.getRepeatCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), of [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Terugspoelen na afspelen** correspondeert met [ITiming.getRewind](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#getRewind--).

Dit onafhankelijke voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), en slaat het resultaat op. Het behouden van de geretourneerde [IEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/)‑referentie voorkomt een onnodige collecties‑index.

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

Gebruik één herhaalmodus bewust. Het combineren van een herhaal­telling met een “tot‑”‑vlag kan verwarrende resultaten opleveren in verschillende viewers. Wanneer je de herhaal­modi wijzigt, stel je eerst [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) en [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) in voordat je [ITiming.setRepeatCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiming/#setRepeatCount-float-) aanroept, omdat het instellen van een vlag ook de actieve herhaalmodus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan ingebedde audio refereren via [IEffect.getSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) instrueert een effect om audio die door een eerder effect is gestart te stoppen.

### **Geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten aan, embedt dat bestand als het geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), dus een sequentie‑index is niet nodig.

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

### **Ingesloten effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel hoofd‑ als interactieve sequenties en schrijft elk ingebed effectgeluid naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt geëxposeerd door [IAudio.getContentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudio/#getContentType--).

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

Voor grote audio‑objecten gebruik je [IAudio.getStream](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudio/#getStream--) en kopieer je de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De **After animation**‑optie bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint Effect Options dialoog met instellingen voor After animation](shape-after-animation.png)

De [AfterAnimationType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/)‑klasse ondersteunt het ongewijzigd laten van de vorm, het wijzigen van de kleur, het verbergen na de animatie, of het verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color) is, stel je ook [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) in.

Dit onafhankelijke voorbeeld maakt een effect aan, stelt het gedrag na animatie in via het geretourneerde effect‑object, en slaat het resultaat op.

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

Het wijzigen van het type vanaf [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/java/com.aspose.slides/afteranimationtype/#Color) wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde besturingselementen:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextanimation/#getBuildType--) bepaalt of alinea's tegelijk of per alinea‑niveau verschijnen.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getAnimateTextType--) bepaalt of tekst in één keer, per woord of per letter verschijnt. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende onafhankelijke voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/java/com.aspose.slides/buildtype/#AsOneObject) schakelt het op‑alinea‑opbouwen uit zodat de woordinstelling geldt voor het volledige tekstframe.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) die een [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) accepteert. Zie [Animated Text](/slides/nl/java/animated-text/) voor alinea‑niveau voorbeelden.

## **Export‑ en compatibiliteits­notities**

- Opslaan naar PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt geregeld door de presentatiewiewer.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/java/export-to-html5/), geanimeerde GIF, of [video conversion](/slides/nl/java/convert-powerpoint-to-video/) wanneer de output beweging moet laten zien.
- Voor HTML5 schakel [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) in en, indien nodig, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Video‑rendering ondersteunt veel gangbare binnenkomende, nadruk‑, uitgang‑ en bewegings‑pad‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/java/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met uw doel‑Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentaties kunnen behouden blijven in het bestand maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het oorspronkelijke PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecten en test de uiteindelijke presentatie voordat je deze in productie gebruikt.

**Verandert het naar voren of achteren verplaatsen van een vorm de animatievolgorde?**

Nee. De z‑order van een vorm bepaalt overlappen, terwijl de volgorde van de reeksen en de triggers de weergave van animaties bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.