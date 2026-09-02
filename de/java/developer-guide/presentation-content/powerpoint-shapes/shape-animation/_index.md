---
title: "Shape-Animationen in Präsentationen mit Java anwenden"
linktitle: "Formanimation"
type: docs
weight: 60
url: /de/java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, Nach-Animations-Verhalten und animierten Text mit Aspose.Slides für Java hinzufügen, überprüfen und anpassen."
---
## **Übersicht**

Aspose.Slides für Java stellt Folienanimationen als Effekte in einer Folientimeline dar. Ein Effekt hat eine Zielform, einen Animationstyp und -untertyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Ton oder Verhalten nach der Animation.

Die Timeline enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöserform angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) implementieren, verwenden Sie für die meisten Folieninhalte dieselbe [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)‑Methode. Die verfügbaren Effekte sind in der Klasse [EffectType](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttype/) aufgelistet.

## **Formanimations hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) mit der Zielform, dem Effekt‑Typ, Untertyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erzeugt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser bestimmt, wann ein Effekt startet:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttriggertype/#OnClick) wartet in der Hauptsequenz auf einen Klick oder in einer interaktiven Sequenz auf einen Klick auf die Auslöserform.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttriggertype/#WithPrevious) startet zusammen mit dem vorhergehenden Effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/de/java/com.aspose.slides/effecttriggertype/#AfterPrevious) startet, wenn der vorhergehende Effekt endet.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) anstelle von `targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/java/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [ISequence.getEffectsByShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-), wenn Sie die Zielform kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Die Enumeration vermeidet die Annahme, dass eine Sequenz an Index `0` einen Effekt enthält.

Das folgende Beispiel erstellt eine Form mit Haupt‑ und Interaktionseffekten, ermittelt die Effekte, die die Form ansprechen, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine Form benötigen, identifizieren Sie die Form zunächst nach Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [ISequence.getEffectsByShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) auf. Gehen Sie nicht davon aus, dass [IShapeCollection.get_Item](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#get_Item-int-) an Index `0` immer das beabsichtigte Objekt ist.

## **Arbeiten mit geerbten Platzhaltereffekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf seiner Layout‑ und Masterfolie erben. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getBasePlaceholder--) gibt diesen übergeordneten Platzhalter zurück oder `null`, wenn kein übergeordnetes Element existiert.

Im folgenden Beispiel‑Präsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Footer-Animationseffekt auf der normalen Folie](slide-shape-animation.png)

![Footer-Platzhalter‑Animationseffekt auf der Layout‑Folie](layout-shape-animation.png)

![Footer-Platzhalter‑Animationseffekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel verwendet eine Platzhalterhierarchie aus einer neuen Präsentation. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getBasePlaceholder--) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

## **Animationszeit ändern**

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [ITiming](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/).

![PowerPoint‑Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [ITiming.getTriggerType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** entspricht [ITiming.getDuration](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getDuration--), in Sekunden.
- **Delay** entspricht [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getTriggerDelayTime--), in Sekunden.
- **Repeat** entspricht [ITiming.getRepeatCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), oder [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** entspricht [ITiming.getRewind](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#getRewind--).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) zurückgegebene Objekt und speichert das Ergebnis. Das Behalten der zurückgegebenen [IEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Die Kombination eines Wiederholungszählers mit einem „bis“-Flag kann in verschiedenen Viewer‑Programmen verwirrende Ergebnisse erzeugen. Beim Ändern der Wiederholungsmodi setzen Sie zuerst [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) und [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) und dann [ITiming.setRepeatCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiming/#setRepeatCount-float-), da das Setzen eines Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animationssounds hinzufügen und extrahieren**

Ein Animationseffekt kann eingebetteten Audio‑Content über [IEffect.getSound](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getSound--) referenzieren. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) weist einen Effekt an, Audio zu stoppen, das von einem früheren Effekt gestartet wurde.

### **Einem Effekt einen Sound hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch Interaktionssequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem Audio‑MIME‑Typ ermittelt, der von [IAudio.getContentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudio/#getContentType--) bereitgestellt wird.

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

Für große Audio‑Objekte verwenden Sie [IAudio.getStream](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudio/#getStream--) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animationsverhalten festlegen**

Die Option **After animation** bestimmt, was mit einer Form geschieht, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effekt‑Optionen‑Dialog zeigt After‑Animation‑Einstellungen](shape-after-animation.png)

Die Klasse [AfterAnimationType](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/) unterstützt das Beibehalten der Form, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#Color) ist, setzen Sie zusätzlich [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Dieses eigenständige Beispiel erstellt einen Effekt, legt dessen Nach‑Animationsverhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType.Color](https://reference.aspose.com/slides/de/java/com.aspose.slides/afteranimationtype/#Color) entfernt die Einstellung für die Nach‑Animationsfarbe.

## **Text animieren**

Bei der Textanimation gibt es zwei zusammengehörige Steuerungen:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextanimation/#getBuildType--) bestimmt, ob Absätze gemeinsam oder absatzweise erscheinen.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getAnimateTextType--) bestimmt, ob Text auf einmal, Wort‑ für Wort oder Buchstabe‑ für Buchstabe erscheint. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) legt die Verzögerung zwischen Wörtern oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende eigenständige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AsOneObject](https://reference.aspose.com/slides/de/java/com.aspose.slides/buildtype/#AsOneObject) deaktiviert das Absatzzusammenbauen, sodass die Wort‑Einstellung auf den gesamten Textrahmen angewendet wird.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/de/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (oder ein anderes Absatz‑Level). Um einen einzelnen Absatz mit eigenem Effekt zu versehen, verwenden Sie die Überladung von [ISequence.addEffect](https://reference.aspose.com/slides/de/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) , die ein [IParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/) akzeptiert. Siehe [Animated Text](/slides/de/java/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern als PPT oder PPTX bewahrt das Animationsmodell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie den [HTML5‑Export](/slides/de/java/export-to-html5/), animierte GIFs oder die [Video‑Konvertierung](/slides/de/java/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und bei Bedarf [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Die Video‑Renderung unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungspfad‑Effekte, aber nicht jeder PowerPoint‑Effekt wird unterstützt. Prüfen Sie die aktuelle [unterstützten Animationen und Effekte](/slides/de/java/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einem PDF?**

PDF ist ein statisches Format, sodass Animationen und Folienübergänge nicht abgespielt werden. Exportieren Sie zu HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders abgespielt?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige erweiterte Effekte werden nicht unterstützt oder nur approximiert. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die eigentliche Präsentation vor der Produktion.

**Ändert das Vor‑ oder Zurück‑Bewegen einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge der Form steuert die Überlappung, während die Sequenz‑Reihenfolge und Auslöser die Wiedergabe der Animation bestimmen. Ändern Sie die Timeline, wenn Sie eine andere Wiedergabereihenfolge benötigen.