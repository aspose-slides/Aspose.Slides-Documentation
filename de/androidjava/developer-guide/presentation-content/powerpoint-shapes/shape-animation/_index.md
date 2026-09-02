---
title: Shape‑Animationen in Präsentationen auf Android anwenden
linktitle: Shape‑Animation
type: docs
weight: 60
url: /de/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Shape‑Animationen, Zeitsteuerung, Sounds, Nach‑Animation‑Verhalten und animierten Text mit Aspose.Slides für Android via Java hinzufügen, inspizieren und anpassen."
---
## **Übersicht**

Aspose.Slides for Android via Java stellt Folienanimationen als Effekte in einer Folientimeline dar. Ein Effekt verfügt über eine Zielform, einen Animationstyp und -untertyp, einen Auslöser, Zeiteinstellungen sowie optionale Eigenschaften wie Sound oder ein Verhalten nach der Animation.

Die Timeline enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie voranschreitet.
- Eine **interaktive Sequenz** startet, wenn die zugehörige Auslöserform angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) implementieren, verwenden Sie für die meisten Folieninhalte dieselbe Methode [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-). Die verfügbaren Effekte sind in der Klasse [EffectType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen Sie [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) mit der Zielform, dem Effekttyp, Untertyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser steuert, wann ein Effekt startet:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttriggertype/#OnClick) wartet auf einen Klick in der Hauptsequenz oder auf einen Klick auf die Auslöserform in einer interaktiven Sequenz.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) startet, wenn der vorherige Effekt beendet ist.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) anstelle von `targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animierte Diagramme](/slides/de/androidjava/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [ISequence.getEffectsByShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-), wenn Sie die Zielform kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Durch das Enumerieren wird vermieden, anzunehmen, dass eine Sequenz einen Effekt am Index `0` enthält.

Das folgende Beispiel erstellt eine Form mit Hauptsequenz‑ und interaktiven Effekten, ermittelt die Effekte, die die Form ansprechen, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie die Effekte nur für eine Form benötigen, identifizieren Sie zunächst die Form anhand von Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [ISequence.getEffectsByShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) auf. Gehen Sie nicht davon aus, dass [IShapeCollection.get_Item](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) am Index `0` stets das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhaltereffekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf seiner Layout‑Folie und Master‑Folie erben. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) gibt diesen übergeordneten Platzhalter zurück oder `null`, wenn kein übergeordneter Platzhalter existiert.

In der folgenden Beispielpräsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Fußzeilen-Animationseffekt auf der normalen Folie](slide-shape-animation.png)

![Fußzeilen-Platzhalter-Animationseffekt auf der Layout‑Folie](layout-shape-animation.png)

![Fußzeilen-Platzhalter-Animationseffekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel verwendet eine Platzhalterhierarchie aus einer neuen Präsentation. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [ITiming](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/).

![PowerPoint‑Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [ITiming.getTriggerType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Dauer** entspricht [ITiming.getDuration](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getDuration--), in Sekunden.
- **Verzögerung** entspricht [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), in Sekunden.
- **Wiederholung** entspricht [ITiming.getRepeatCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), oder [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Zurückspulen nach dem Abspielen** entspricht [ITiming.getRewind](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#getRewind--).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [IEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Das Kombinieren einer Wiederholungszahl mit einem „until“‑Flag kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Wenn Sie Wiederholungsmodi ändern, setzen Sie [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) und [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) vor [ITiming.setRepeatCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), da das Setzen eines der Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animationssounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [IEffect.getSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getSound--) eingebettete Audiodateien referenzieren. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) weist einen Effekt an, von einem früheren Effekt gestarteten Sound zu stoppen.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch interaktive Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem von [IAudio.getContentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudio/#getContentType--) bereitgestellten Audio‑MIME‑Typ ausgewählt.

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

Für große Audioobjekte verwenden Sie [IAudio.getStream](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudio/#getStream--) und kopieren Sie den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animationsverhalten festlegen**

Die Option **After animation** steuert, was mit einer Form geschieht, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effekt‑Optionen‑Dialog, der Nach‑Animation‑Einstellungen zeigt](shape-after-animation.png)

Die Klasse [AfterAnimationType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/) unterstützt das Belassen der Form unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#Color) ist, setzen Sie zusätzlich [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Dieses eigenständige Beispiel erstellt einen Effekt, legt sein Nach‑Animationsverhalten über das zurückgegebene Effektobjekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType.Color](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/afteranimationtype/#Color) löscht die Nach‑Animations‑Farbeinstellung.

## **Text animieren**

Die Textanimation hat zwei zugehörige Einstellungen:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextanimation/#getBuildType--) steuert, ob Absätze gemeinsam oder auf Absatz‑Ebene erscheinen.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) steuert, ob Text gleichzeitig, wortweise oder buchstabenweise erscheint. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) legt die Verzögerung zwischen Wörtern oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende eigenständige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AsOneObject](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/buildtype/#AsOneObject) deaktiviert das Aufbauen Absatz‑für‑Absatz, sodass die Wort‑Einstellung für den gesamten Textrahmen gilt.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (oder einen anderen Absatz‑Level). Um einen einzelnen Absatz mit einem eigenen Effekt zu versehen, verwenden Sie die Überladung von [ISequence.addEffect](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-), die ein [IParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/) akzeptiert. Siehe [Animierter Text](/slides/de/androidjava/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitätshinweise**

- Das Speichern als PPT oder PPTX bewahrt das Animationsmodell, jedoch wird die endgültige Wiedergabe vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5‑Export](/slides/de/androidjava/export-to-html5/), animierte GIFs oder [Video‑Konvertierung](/slides/de/androidjava/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und bei Bedarf [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Die Video‑Renderung unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungspfad‑Effekte, jedoch nicht jeden PowerPoint‑Effekt. Prüfen Sie die aktuelle [unterstützten Animationen und Effekte](/slides/de/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, jedoch in PowerPoint, HTML5 oder Video anders dargestellt werden. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht wiedergegeben. Exportieren Sie zu HTML5, animierten GIFs oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders abgespielt?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder nur angenähert. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die tatsächliche Präsentation vor dem Produktionseinsatz.

**Verändert das Vorwärts‑ oder Rückwärts‑Bewegen einer Form die Reihenfolge ihrer Animation?**

Nein. Die Z‑Reihenfolge einer Form steuert die Überlappung, während die Reihenfolge der Sequenz und die Auslöser die Wiedergabe der Animation bestimmen. Ändern Sie die Timeline, wenn Sie eine andere Wiedergabereihenfolge benötigen.