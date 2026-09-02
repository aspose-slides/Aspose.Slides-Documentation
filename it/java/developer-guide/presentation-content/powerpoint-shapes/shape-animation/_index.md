---
title: Applicare animazioni di forma nelle presentazioni con Java
linktitle: Animazione di forma
type: docs
weight: 60
url: /it/java/shape-animation/
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
- suono dell'effetto
- applica animazione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento post-animazione e il testo animato con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e un sottotipo di animazione, un trigger, impostazioni temporali e proprietà opzionali come suono o comportamento dopo l'animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.  
- Una **sequenza interattiva** inizia quando la sua forma trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva implementano [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/), è possibile utilizzare lo stesso metodo [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nella classe [EffectType](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttype/).

## **Aggiungi animazioni alle forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) con la forma di destinazione, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quella forma.

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

Il trigger controlla quando inizia un effetto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttriggertype/#OnClick) attende un clic nella sequenza principale, o un clic sulla forma trigger in una sequenza interattiva.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttriggertype/#WithPrevious) inizia con l'effetto precedente.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttriggertype/#AfterPrevious) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) invece di `targetShape`. Per opzioni di raggruppamento specifiche per i grafici, consulta [Grafici animati](/slides/it/java/animated-charts/).

## **Leggi animazioni delle forme**

Usa [ISequence.getEffectsByShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) quando conosci la forma di destinazione. Per esaminare ogni effetto, elimina la sequenza principale e ogni sequenza interattiva. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

L'esempio seguente crea una forma con effetti nella sequenza principale e nella sequenza interattiva, ottiene gli effetti che hanno come destinazione la forma, e poi elenca ogni sequenza sulla diapositiva.

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

Se ti servono solo gli effetti per una singola forma, identifica prima la forma per nome, tipo di segnaposto o un'altra proprietà stabile; poi chiama [ISequence.getEffectsByShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Non presumere che [IShapeCollection.get_Item](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#get_Item-int-) all'indice `0` sia sempre l'oggetto previsto.

## **Lavora con gli effetti dei segnaposto ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal segnaposto corrispondente sulla sua diapositiva layout e master. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getBasePlaceholder--) restituisce quel segnaposto genitore, oppure `null` se non esiste un genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Animazione del segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

L'esempio successivo utilizza una gerarchia di segnaposti da una nuova presentazione. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getBasePlaceholder--) viene verificata prima di utilizzare la forma restituita.

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

## **Modifica la tempistica dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [ITiming](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [ITiming.getTriggerType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getTriggerType--).  
- **Duration** corrisponde a [ITiming.getDuration](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getDuration--), in secondi.  
- **Delay** corrisponde a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getTriggerDelayTime--), in secondi.  
- **Repeat** corrisponde a [ITiming.getRepeatCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), o [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).  
- **Rewind when done playing** corrisponde a [ITiming.getRewind](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#getRewind--).

Questo esempio indipendente aggiunge un effetto, modifica la sua tempistica tramite l'oggetto restituito da [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), e salva il risultato. Conservare il riferimento [IEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/) restituito evita un indice di raccolta non necessario.

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

Utilizza un solo modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizione con una bandiera "until" può generare risultati confusi in diversi visualizzatori. Quando cambi i modi di ripetizione, imposta [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) e [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) prima di [ITiming.setRepeatCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiming/#setRepeatCount-float-), poiché l'impostazione di una delle due bandiere modifica anche il modo di ripetizione attivo.

## **Aggiungi ed estrai suoni delle animazioni**

Un effetto di animazione può fare riferimento a audio incorporato tramite [IEffect.getSound](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indica a un effetto di interrompere l'audio avviato da un effetto precedente.

### **Aggiungi un suono a un effetto**

L'esempio seguente richiede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per interrompere il suono. Utilizza gli oggetti restituiti da [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), quindi non è necessario un indice di sequenza.

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

### **Estrai suoni incorporati negli effetti**

L'esempio seguente richiede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali sia quelle interattive e scrive ogni suono di effetto incorporato nella directory `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio fornito da [IAudio.getContentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudio/#getContentType--).

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

Per oggetti audio di grandi dimensioni, usa [IAudio.getStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudio/#getStream--) e copia lo stream in un file invece di caricare l'intero oggetto in un array di byte.

## **Imposta comportamento dopo l'animazione**

L'opzione **After animation** controlla cosa succede a una forma dopo il completamento del suo effetto.

![Finestra di dialogo Opzioni effetto di PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/) consente di lasciare la forma invariata, cambiare il suo colore, nasconderla dopo l'animazione o nasconderla al prossimo clic. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#Color), impostare anche [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Questo esempio indipendente crea un effetto, imposta il suo comportamento dopo l'animazione tramite l'oggetto effetto restituito, e salva il risultato.

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

Cambiare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#Color) cancella l'impostazione del colore after-animation.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextanimation/#getBuildType--) controlla se i paragrafi appaiono insieme o per livello di paragrafo.  
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getAnimateTextType--) controlla se il testo appare tutto insieme, per parola o per lettera. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

L'esempio indipendente seguente anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/java/com.aspose.slides/buildtype/#AsOneObject) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione per parola si applichi all'intero riquadro di testo.

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

Per costruire una casella di testo per paragrafo, imposta [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (o un altro livello di paragrafo). Per targeting un singolo paragrafo con il proprio effetto, usa la sovraccarico di [ISequence.addEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) che accetta un [IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/). Vedi [Testo animato](/slides/it/java/animated-text/) per esempi a livello di paragrafo.

## **Note su esportazione e compatibilità**

- Il salvataggio in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.  
- PDF e immagini statiche non riproducono animazioni. Usa [Esportazione HTML5](/slides/it/java/export-to-html5/), GIF animati o [conversione video](/slides/it/java/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.  
- Per HTML5, abilita [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e, se necessario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).  
- Il rendering video supporta molti effetti comuni di entrata, enfasi, uscita e percorsi di movimento, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le [animazioni ed effetti supportati](/slides/it/java/convert-powerpoint-to-video/#supported-animations-and-effects) attuali e testa le presentazioni critiche con la versione di Aspose.Slides di destinazione.  
- Gli effetti personalizzati avanzati e gli effetti importati da altri formati di presentazione possono essere conservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalida il risultato esportato anziché fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animati o video quando il movimento deve essere conservato.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione video rende le animazioni anziché memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell'uso in produzione.

**Spostare una forma in avanti o indietro cambia l'ordine di animazione?**

No. L'ordine Z della forma controlla la sovrapposizione, mentre l'ordine della sequenza e i trigger controllano la riproduzione dell'animazione. Modifica la timeline se hai bisogno di un ordine di riproduzione diverso.