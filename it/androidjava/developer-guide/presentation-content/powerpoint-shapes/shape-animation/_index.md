---
title: Applica animazioni di forme nelle presentazioni su Android
linktitle: Animazione forma
type: docs
weight: 60
url: /it/androidjava/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungi animazione
- ottieni animazione
- estrai animazione
- aggiungi effetto
- ottieni effetto
- estrai effetto
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forme, la temporizzazione, i suoni, il comportamento dopo l'animazione e il testo animato con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Aspose.Slides per Android via Java rappresenta le animazioni delle diapositive come effetti nella timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento dopo l'animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene eseguita man mano che la diapositiva avanza.
- Una **sequenza interattiva** inizia quando la sua forma trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva implementano [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/), si utilizza lo stesso metodo [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nella classe [EffectType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttype/).

## **Aggiungere animazioni alle forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) con la forma di destinazione, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quell'altra forma.

L'esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

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

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttriggertype/#OnClick) attende un clic nella sequenza principale, o un clic sulla forma trigger in una sequenza interattiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) inizia con l'effetto precedente.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) invece di `targetShape`. Per le opzioni di raggruppamento specifiche dei grafici, vedere [Animated Charts](/slides/it/androidjava/animated-charts/).

## **Leggere le animazioni delle forme**

Usa [ISequence.getEffectsByShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) quando conosci la forma di destinazione. Per ispezionare ogni effetto, enumera la sequenza principale e tutte le sequenze interattive. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

L'esempio seguente crea una forma con effetti nella sequenza principale e in quella interattiva, ottiene gli effetti che puntano alla forma e poi enumera tutte le sequenze sulla diapositiva.

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

Se ti servono solo gli effetti per una singola forma, individua prima la forma per nome, tipo di segnaposto o un'altra proprietà stabile; quindi chiama [ISequence.getEffectsByShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Non presumere che [IShapeCollection.get_Item](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) all'indice `0` sia sempre l'oggetto desiderato.

## **Lavorare con gli effetti dei segnaposto ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto sulla diapositiva layout e sul master. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) restituisce quel segnaposto genitore, o `null` se non esiste un genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Effetto di animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

L'esempio successivo utilizza una gerarchia di segnaposto da una nuova presentazione. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) viene verificata prima di utilizzare la forma restituita.

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

## **Modificare la temporizzazione dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [ITiming](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [ITiming.getTriggerType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** corrisponde a [ITiming.getDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getDuration--), in secondi.
- **Delay** corrisponde a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), in secondi.
- **Repeat** corrisponde a [ITiming.getRepeatCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), o [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** corrisponde a [ITiming.getRewind](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#getRewind--).

Questo esempio indipendente aggiunge un effetto, ne modifica la temporizzazione tramite l'oggetto restituito da [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), e salva il risultato. Conservare il riferimento a [IEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/) restituito evita un indice di raccolta non necessario.

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

Usa una modalità di ripetizione intenzionalmente. Combinare un conteggio di ripetizioni con un flag “until” può generare risultati confusi in visualizzatori diversi. Quando cambi le modalità di ripetizione, imposta [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) e [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) prima di [ITiming.setRepeatCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), poiché impostare uno dei due flag modifica anche la modalità di ripetizione attiva.

## **Aggiungere ed estrarre suoni di animazione**

Un effetto di animazione può fare riferimento a audio incorporato tramite [IEffect.getSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indica a un effetto di fermare l'audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

L'esempio seguente si basa su un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Utilizza gli oggetti restituiti da [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), quindi non è necessario alcun indice di sequenza.

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

### **Estrarre suoni di effetto incorporati**

L'esempio seguente si basa su una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali che quelle interattive e scrive ogni suono di effetto incorporato nella directory `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio esposto da [IAudio.getContentType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Per oggetti audio di grandi dimensioni, usa [IAudio.getStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudio/#getStream--) e copia lo stream in un file invece di caricare l'intero oggetto in un array di byte.

## **Impostare il comportamento Dopo l'animazione**

L'opzione **After animation** controlla cosa accade a una forma dopo la conclusione del suo effetto.

![Finestra di dialogo Opzioni effetto di PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/afteranimationtype/) supporta il mantenimento della forma invariata, il cambiamento del colore, la sua nasconditura dopo l'animazione o la nasconditura al clic successivo. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/afteranimationtype/#Color), imposta anche [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Questo esempio indipendente crea un effetto, imposta il suo comportamento dopo l'animazione tramite l'oggetto effetto restituito e salva il risultato.

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

Cambiare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/afteranimationtype/#Color) cancella l'impostazione del colore dopo l'animazione.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextanimation/#getBuildType--) controlla se i paragrafi appaiono tutti insieme o per livello di paragrafo.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) controlla se il testo appare tutto in una volta, parola per parola o lettera per lettera. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

L'esempio indipendente seguente anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/buildtype/#AsOneObject) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione della parola si applichi all'intero riquadro di testo.

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

Per costruire una casella di testo per paragrafo, imposta [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (o un altro livello di paragrafo). Per indirizzare un singolo paragrafo con il proprio effetto, utilizza la sovraccarico di [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) che accetta un [IParagraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraph/). Consulta [Animated Text](/slides/it/androidjava/animated-text/) per esempi a livello di paragrafo.

## **Esportazione e note di compatibilità**

- Il salvataggio in PPT o PPTX conserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.
- PDF e immagini statiche non riproducono le animazioni. Usa [HTML5 export](/slides/it/androidjava/export-to-html5/), GIF animate o [video conversion](/slides/it/androidjava/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.
- Per HTML5, abilita [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e, se necessario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Il rendering video supporta molti effetti comuni di entrata, enfatizzazione, uscita e percorso di movimento, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le [animazioni ed effetti supportati](/slides/it/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) attuali e testa le presentazioni critiche con la versione di Aspose.Slides in uso.
- Gli effetti personalizzati avanzati e gli effetti importati da altri formati di presentazione possono essere conservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalida il risultato esportato anziché fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animata o video quando è necessario conservare il movimento.

**Perché un effetto viene riprodotto in modo diverso in un video?**

L'esportazione video rende le animazioni invece di conservare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell'uso in produzione.

**Il spostamento di una forma in avanti o indietro cambia l'ordine di animazione?**

No. Lo z‑order della forma controlla la sovrapposizione, mentre l'ordine della sequenza e i trigger controllano la riproduzione delle animazioni. Modifica la timeline se hai bisogno di un ordine di riproduzione diverso.