---
title: Applica animazioni di forme nelle presentazioni usando Java
linktitle: Animazione Forma
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
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare animazioni di forme nelle presentazioni PowerPoint con Aspose.Slides per Java. Distinguersi!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](https://docs.aspose.com/slides/it/java/animated-charts/). Conferiscono vita alle presentazioni o ai loro componenti. 

## **Perché utilizzare le animazioni nelle presentazioni?**

Utilizzando le animazioni, è possibile 

* controllare il flusso di informazioni
* sottolineare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* attirare l'attenzione dei lettori o degli spettatori verso le parti importanti di una presentazione

PowerPoint fornisce molte opzioni e strumenti per le animazioni e gli effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**. 

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi `Aspose.Slides.Animation`,
* Aspose.Slides fornisce oltre **150 effetti di animazione** nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/java/com.aspose.slides/effecttype). Questi effetti sono essenzialmente gli stessi (o equivalenti) effetti utilizzati in PowerPoint.

## **Applica animazione a una TextBox**

Aspose.Slides per Java consente di applicare animazioni al testo in una forma. 

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape). 
4. Aggiungere testo a [IAutoShape.TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Ottenere la sequenza principale di effetti.
6. Aggiungere un effetto di animazione a [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape). 
7. Impostare la proprietà `TextAnimation.BuildType` sul valore dell'enumerazione `BuildType`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice Java mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo sul valore *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Instanzia una classe Presentation che rappresenta un file di presentazione.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiunge una nuova AutoShape con testo
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Aggiunge l'effetto di animazione Fade alla forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima il testo della forma per paragrafi di primo livello
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Salva il file PPTX su disco
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph). Vedere [**Animated Text**](/slides/it/java/animated-text/).

{{% /alert %}} 

## **Applica animazione a un PictureFrame**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere o ottenere un [PictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/pictureframe) sulla diapositiva. 
4. Ottenere la sequenza principale di effetti.
5. Aggiungere un effetto di animazione a [PictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/pictureframe).
6. Scrivere la presentazione su disco come file PPTX.

Questo codice Java mostra come applicare l'effetto `Fly` a un picture frame:

```java
import com.aspose.slides.*;

// Instanzia una classe di presentazione che rappresenta un file di presentazione.
Presentation pres = new Presentation();
try {
    // Carica l'immagine da aggiungere nella raccolta di immagini della presentazione
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Aggiunge picture frame alla diapositiva
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Aggiunge Fly da sinistra al picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salva il file PPTX su disco
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applica animazione a una Shape**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape). 
4. Aggiungere un `Bevel` [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape) (quando questo oggetto viene cliccato, l'animazione viene riprodotta).
5. Creare una sequenza di effetti sulla forma bevel.
6. Creare un `UserPath` personalizzato.
7. Aggiungere comandi per spostarsi al `UserPath`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice Java mostra come applicare l'effetto `PathFootball` (path football) a una shape:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Istanzia una classe Presentation che rappresenta un file PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crea l'effetto PathFootball per la forma esistente da zero.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Aggiunge l'effetto di animazione PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea una sorta di pulsante.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una sequenza di effetti per questo pulsante.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante è stato cliccato.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Aggiunge comandi di movimento poiché il percorso creato è vuoto.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Scrive il file PPTX su disco
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottenere gli effetti di animazione applicati a una Shape**

Gli esempi seguenti mostrano come utilizzare il metodo `getEffectsByShape` dall'interfaccia [ISequence](https://reference.aspose.com/slides/it/java/com.aspose.slides/isequence/) per ottenere tutti gli effetti di animazione applicati a una shape.

**Esempio 1: Ottenere gli effetti di animazione applicati a una shape su una diapositiva normale**

In precedenza, hai imparato come aggiungere effetti di animazione alle shape nelle presentazioni PowerPoint. Il codice di esempio seguente mostra come ottenere gli effetti applicati alla prima shape sulla prima diapositiva normale nella presentazione `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Ottiene la sequenza principale di animazione della diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ottiene la prima forma sulla prima diapositiva.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Ottiene gli effetti di animazione applicati alla forma.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati dai segnaposto**

Se una shape su una diapositiva normale ha dei segnaposto presenti sulla diapositiva layout e/o master, e sono stati aggiunti effetti di animazione a questi segnaposto, tutti gli effetti della shape verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposto.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una diapositiva contenente solo una shape di piè di pagina con il testo "Made with Aspose.Slides" e l'effetto **Random Bars** è applicato alla shape.

![Slide shape animation effect](slide-shape-animation.png)

Supponiamo inoltre che l'effetto **Split** sia applicato al segnaposto del piè di pagina sulla diapositiva **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Infine, l'effetto **Fly In** è applicato al segnaposto del piè di pagina sulla diapositiva **master**.

![Master shape animation effect](master-shape-animation.png)

Il codice di esempio seguente mostra come utilizzare il metodo `getBasePlaceholder` dall'interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per accedere ai segnaposto della shape e ottenere gli effetti di animazione applicati alla shape del piè di pagina, includendo quelli ereditati dai segnaposto situati sulle diapositive layout e master.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Modificare le proprietà di temporizzazione dell'effetto di animazione**

Aspose.Slides per Java consente di modificare le proprietà di Timing di un effetto di animazione.

Questo è il pannello Animation Timing in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Queste sono le corrispondenze tra il Timing di PowerPoint e le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/java/com.aspose.slides/IEffect#getTiming--) :

- L'elenco a discesa **Start** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITiming#getTriggerType--). 
- Il **Duration** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.Duration](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITiming#getDuration--). La durata di un'animazione (in secondi) è il tempo totale impiegato dall'animazione per completare un ciclo. 
- Il **Delay** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Ecco come modificare le proprietà di temporizzazione dell'effetto:

1. Applicare ([Apply](#apply-animation-to-shape)) o ottenere l'effetto di animazione.
2. Impostare nuovi valori per le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/java/com.aspose.slides/IEffect#getTiming--) necessarie. 
3. Salvare il file PPTX modificato.

```java
import com.aspose.slides.*;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ottiene il primo effetto della sequenza principale.
    IEffect effect = sequence.get_Item(0);

    // Cambia il TriggerType dell'effetto per avviarlo al clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Cambia la durata dell'effetto
    effect.getTiming().setDuration(3f);

    // Cambia il TriggerDelayTime dell'effetto
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Salva il file PPTX su disco
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Suono dell'effetto di animazione**

Aspose.Slides fornisce queste proprietà per consentire di gestire i suoni negli effetti di animazione: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Aggiungere un suono all'effetto di animazione**

Questo codice Java mostra come aggiungere un suono all'effetto di animazione e fermarlo quando inizia l'effetto successivo:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Aggiunge audio alla collezione audio della presentazione
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ottiene il primo effetto della sequenza principale
    IEffect firstEffect = sequence.get_Item(0);

    // Controlla l'effetto per "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Aggiunge suono per il primo effetto
        firstEffect.setSound(effectSound);
    }

    // Ottiene la prima sequenza interattiva della diapositiva.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Imposta il flag dell'effetto "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Scrive il file PPTX su disco
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Estrarre il suono di un effetto di animazione**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice. 
3. Ottenere la sequenza principale di effetti. 
4. Estrarre il [setSound(IAudio value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporato in ciascun effetto di animazione. 

Questo codice Java mostra come estrarre il suono incorporato in un effetto di animazione:

```java
import com.aspose.slides.*;

// Instanzia una classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Estrae il suono dell'effetto in un array di byte
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Dopo l'animazione**

Aspose.Slides per Java consente di modificare la proprietà After animation di un effetto di animazione.

Questo è il pannello Animation Effect e il menu esteso in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

L'elenco a discesa **After animation** di PowerPoint corrisponde a queste proprietà: 

- La proprietà [setAfterAnimationType(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) che descrive il tipo di After animation :
  * PowerPoint **More Colors** corrisponde al tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** corrisponde al tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo di after animation predefinito);
  * PowerPoint **Hide After Animation** corrisponde al tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** corrisponde al tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- La proprietà [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) che definisce un formato di colore After animation. Questa proprietà funziona in congiunzione con il tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/java/com.aspose.slides/afteranimationtype/#Color). Se si cambia il tipo, il colore After animation verrà cancellato.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanzia una classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ottiene il primo effetto della sequenza principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia il tipo di after animation in Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Imposta il colore di attenuazione after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Scrive il file PPTX su disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per consentire di lavorare con il blocco *Animate text* di un effetto di animazione: 

- La proprietà [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) che descrive il tipo di animazione del testo dell'effetto. Il testo della shape può essere animato:
  - Tutto in una volta ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/it/java/com.aspose.slides/animatetexttype/#AllAtOnce) tipo)
  - Per parola ([AnimateTextType.ByWord](https://reference.aspose.com/slides/it/java/com.aspose.slides/animatetexttype/#ByWord) tipo)
  - Per lettera ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/it/java/com.aspose.slides/animatetexttype/#ByLetter) tipo)
- La proprietà [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) imposta un ritardo tra le parti del testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell'effetto. Un valore negativo specifica il ritardo in secondi.

1. Applicare ([Apply](#apply-animation-to-shape)) o ottenere l'effetto di animazione.
2. Impostare la proprietà [setBuildType(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextanimation/#setBuildType-int-) al valore [BuildType.AsOneObject](https://reference.aspose.com/slides/it/java/com.aspose.slides/buildtype/#AsOneObject) per disattivare la modalità di animazione *By Paragraphs*.
3. Impostare nuovi valori per le proprietà [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Salvare il file PPTX modificato.

```java
import com.aspose.slides.*;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ottiene il primo effetto della sequenza principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia il tipo di animazione del testo dell'effetto a "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Cambia il tipo di animazione del testo dell'effetto a "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Imposta il ritardo tra le parole al 20% della durata dell'effetto
    firstEffect.setDelayBetweenTextParts(20f);

    // Scrive il file PPTX su disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Come posso garantire che le animazioni siano preservate quando pubblico la presentazione sul Web?

Esportare in HTML5](/slides/it/java/export-to-html5/) e abilitare le [options](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/) responsabili delle animazioni di [shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e [transition](https://reference.aspose.com/slides/it/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). L'HTML puro non riproduce le animazioni delle diapositive, mentre l'HTML5 lo fa.

### Come influisce la modifica dell'ordine Z (ordine dei livelli) delle shape sull'animazione?

Animazione e ordine di disegno sono indipendenti: un effetto controlla il timing e il tipo di apparizione/scomparsa, mentre lo [z-order](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getZOrderPosition--) determina cosa copre cosa. Il risultato visibile è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello effetti‑e‑shape di Aspose.Slides segue la stessa logica.)

### Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?

In generale, [animations are supported](/slides/it/java/convert-powerpoint-to-video/), ma casi rari o effetti specifici potrebbero essere renderizzati diversamente. Si consiglia di testare con gli effetti che si usano e con la versione della libreria.