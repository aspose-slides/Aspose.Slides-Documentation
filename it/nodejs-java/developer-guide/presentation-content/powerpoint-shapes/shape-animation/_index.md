---
title: Applica animazioni di forma nelle presentazioni usando JavaScript
linktitle: Animazione Forma
type: docs
weight: 60
url: /it/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e personalizzare le animazioni di forma nelle presentazioni PowerPoint con JavaScript e Aspose.Slides per Node.js via Java. Distinguiti!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](/slides/it/nodejs-java/animated-charts/). Danno vita a presentazioni o ai loro componenti.

## **Perché utilizzare animazioni nelle presentazioni?**

Utilizzando le animazioni, è possibile  

* controllare il flusso di informazioni  
* enfatizzare i punti importanti  
* aumentare l’interesse o la partecipazione del pubblico  
* rendere più facile la lettura, l’assimilazione o l’elaborazione dei contenuti  
* attirare l’attenzione dei lettori o degli spettatori sulle parti importanti di una presentazione  

PowerPoint offre molte opzioni e strumenti per animazioni ed effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**.  

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi `Aspose.Slides.Animation`,  
* Aspose.Slides offre oltre **150 effetti di animazione** tramite l’enumerazione [EffectType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttype). Questi effetti sono essenzialmente gli stessi (o equivalenti) effetti utilizzati in PowerPoint.  

## **Applicare animazione a TextBox**

Aspose.Slides per Node.js via Java consente di applicare animazione al testo contenuto in una forma.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).  
2. Ottenere un riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere un `rectangle` [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape).  
4. Aggiungere testo usando [AutoShape.addTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).  
5. Ottenere la sequenza principale di effetti.  
6. Aggiungere un effetto di animazione all’[AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape).  
7. Chiamare il metodo `TextAnimation.setBuildType` con il valore dell’enumerazione `BuildType`.  
8. Scrivere la presentazione su disco come file PPTX.  

Questo codice Javascript mostra come applicare l’effetto `Fade` all’AutoShape e impostare l’animazione del testo su *By 1st Level Paragraphs*:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Aggiunge una nuova AutoShape con testo
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Ottiene la sequenza principale della diapositiva.
    var sequence = sld.getTimeline().getMainSequence();
    // Aggiunge l’effetto di animazione Fade alla forma
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Anima il testo della forma per paragrafi di primo livello
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Salva il file PPTX su disco
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph). Vedi [**Testo animato**](/slides/it/nodejs-java/animated-text/).

{{% /alert %}} 

## **Applicare animazione a PictureFrame**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).  
2. Ottenere un riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere o ottenere un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe) sulla diapositiva.  
4. Ottenere la sequenza principale di effetti.  
5. Aggiungere un effetto di animazione al [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe).  
6. Scrivere la presentazione su disco come file PPTX.  

Questo codice Javascript mostra come applicare l’effetto `Fly` a un picture frame:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione.
var pres = new aspose.slides.Presentation();
try {
    // Carica l'immagine da aggiungere alla raccolta immagini della presentazione
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Aggiunge un picture frame alla diapositiva
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Ottiene la sequenza principale della diapositiva.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Aggiunge l'effetto di animazione Fly da sinistra al picture frame
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Salva il file PPTX su disco
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Applicare animazione a Shape**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).  
2. Ottenere un riferimento a una diapositiva tramite il suo indice.  
3. Aggiungere un `rectangle` [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape).  
4. Aggiungere una `Bevel` [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape) (quando questo oggetto viene cliccato, l’animazione viene avviata).  
5. Creare una sequenza di effetti sulla forma bevel.  
6. Creare un `UserPath` personalizzato.  
7. Aggiungere comandi per spostarsi sul `UserPath`.  
8. Scrivere la presentazione su disco come file PPTX.  

Questo codice Javascript mostra come applicare l’effetto `PathFootball` a una forma:

```javascript
// Istanzia una classe Presentation che rappresenta un file PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Crea l'effetto PathFootball per una forma esistente da zero.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Aggiunge l'effetto di animazione PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Crea una sorta di "button".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Crea una sequenza di effetti per questo button.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il button è stato cliccato.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Aggiunge comandi per lo spostamento poiché il percorso creato è vuoto.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Scrive il file PPTX su disco
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ottenere gli effetti di animazione applicati a una Shape**

Gli esempi seguenti mostrano come utilizzare il metodo `getEffectsByShape` della classe [Sequence](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/) per ottenere tutti gli effetti di animazione applicati a una forma.

**Esempio 1: Ottenere gli effetti di animazione applicati a una forma su una diapositiva normale**

In precedenza hai imparato a aggiungere effetti di animazione a forme in presentazioni PowerPoint. Il seguente codice di esempio mostra come ottenere gli effetti applicati alla prima forma della prima diapositiva normale nella presentazione `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Ottiene la sequenza principale di animazione della diapositiva.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Ottiene la prima forma sulla prima diapositiva.
    var shape = firstSlide.getShapes().get_Item(0);

    // Ottiene gli effetti di animazione applicati alla forma.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati da segnaposto**

Se una forma su una diapositiva normale ha segnaposto che si trovano nella diapositiva layout e/o master, e a questi segnaposto sono stati aggiunti effetti di animazione, allora tutti gli effetti della forma verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposto.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una diapositiva contenente solo una forma piè di pagina con il testo “Made with Aspose.Slides” e l’effetto **Random Bars** applicato alla forma.

![effetto animazione forma diapositiva](slide-shape-animation.png)

Supponiamo inoltre che l’effetto **Split** sia applicato al segnaposto piè di pagina sulla diapositiva **layout**.

![effetto animazione forma layout](layout-shape-animation.png)

Infine, l’effetto **Fly In** è applicato al segnaposto piè di pagina sulla diapositiva **master**.

![effetto animazione forma master](master-shape-animation.png)

Il seguente codice di esempio mostra come utilizzare il metodo `getBasePlaceholder` della classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) per accedere ai segnaposto della forma e ottenere gli effetti di animazione applicati alla forma piè di pagina, inclusi quelli ereditati dai segnaposto situati su layout e master.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Ottiene gli effetti di animazione della forma sulla diapositiva normale.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Ottiene gli effetti di animazione del segnaposto sulla diapositiva layout.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Ottiene gli effetti di animazione del segnaposto sulla diapositiva master.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vola, In basso
Type: 134, subtype: 45            // Dividi, VerticalIn
Type: 126, subtype: 22            // Barre casuali, Orizzontale
```

## **Modificare le proprietà di timing dell’effetto di animazione**

Aspose.Slides per Node.js via Java consente di modificare le proprietà di Timing di un effetto di animazione.

Questo è il pannello Timing dell’animazione in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Queste sono le corrispondenze tra il Timing di PowerPoint e le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Effect#getTiming--):

- L’elenco a discesa **Start** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Timing#getTriggerType--).  
- **Duration** di PowerPoint corrisponde alla proprietà [Effect.Timing.Duration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Timing#getDuration--). La durata di un’animazione (in secondi) è il tempo totale necessario per completare un ciclo.  
- **Delay** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).  

Ecco come modificare le proprietà di Timing dell’effetto:

1. [Applicare](#apply-animation-to-shape) o ottenere l’effetto di animazione.  
2. Impostare nuovi valori per le proprietà di [Effect.Timing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Effect#getTiming--) necessarie.  
3. Salvare il file PPTX modificato.  

Questo codice Javascript dimostra l’operazione:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Ottiene la sequenza principale della diapositiva.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Ottiene il primo effetto della sequenza principale.
    var effect = sequence.get_Item(0);
    // Modifica il TriggerType dell'effetto per avviarlo al clic
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Modifica la durata dell'effetto
    effect.getTiming().setDuration(3.0);
    // Modifica il TriggerDelayTime dell'effetto
    effect.getTiming().setTriggerDelayTime(0.5);
    // Salva il file PPTX su disco
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Suono dell’effetto di animazione**

Aspose.Slides fornisce queste proprietà per lavorare con i suoni negli effetti di animazione:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Aggiungere suono all’effetto di animazione**

Questo codice Javascript mostra come aggiungere un suono all’effetto di animazione e fermarlo quando inizia il successivo effetto:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Aggiunge audio alla collezione audio della presentazione
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Ottiene la sequenza principale della diapositiva.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Ottiene il primo effetto della sequenza principale
    var firstEffect = sequence.get_Item(0);
    // Verifica l'effetto per "Nessun suono"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Aggiunge il suono al primo effetto
        firstEffect.setSound(effectSound);
    }
    // Ottiene la prima sequenza interattiva della diapositiva.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Imposta il flag "Stop previous sound" dell'effetto
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Scrive il file PPTX su disco
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Estrarre il suono dell’effetto di animazione**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).  
2. Ottenere un riferimento a una diapositiva tramite il suo indice.  
3. Ottenere la sequenza principale di effetti.  
4. Estrarre il [setSound(IAudio value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) incorporato in ciascun effetto di animazione.  

Questo codice Javascript mostra come estrarre il suono incorporato in un effetto di animazione:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Ottiene la sequenza principale della diapositiva.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Estrae il suono dell'effetto in un array di byte
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Dopo l’animazione**

Aspose.Slides per Node.js via Java consente di modificare la proprietà “After animation” di un effetto di animazione.

Questo è il pannello dell’effetto di animazione e il menu esteso in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

L’elenco a discesa **After animation** di PowerPoint corrisponde a queste proprietà:  

- Metodo [setAfterAnimationType(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) che descrive il tipo di “After animation”;  
  * **More Colors** di PowerPoint corrisponde al tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color);  
  * **Don’t Dim** di PowerPoint corrisponde al tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo predefinito);  
  * **Hide After Animation** di PowerPoint corrisponde al tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** di PowerPoint corrisponde al tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- Metodo [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) che definisce un formato colore “after animation”. Questo metodo funziona in combinazione con il tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color). Se si cambia il tipo, il colore “after animation” verrà cancellato.  

Questo codice Javascript mostra come modificare un effetto “after animation”:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ottiene il primo effetto della sequenza principale
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Cambia il tipo di animazione successiva a Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Imposta il colore di dim dell'animazione successiva
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Scrive il file PPTX su disco
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per gestire il blocco *Animate text* di un effetto di animazione:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) che descrive il tipo di animazione del testo dell’effetto. Il testo della forma può essere animato:  
  - Tutto in una volta ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Parola per parola ([AnimateTextType.ByWord](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/animatetexttype/#ByWord))  
  - Letterra per lettera ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) imposta un ritardo tra le parti di testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell’effetto; un valore negativo specifica il ritardo in secondi.  

Ecco come è possibile modificare le proprietà “Animate text” dell’effetto:

1. [Applicare](#apply-animation-to-shape) o ottenere l’effetto di animazione.  
2. Impostare il metodo [setBuildType(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) su [BuildType.AsOneObject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/buildtype/#AsOneObject) per disattivare la modalità *By Paragraphs*.  
3. Impostare nuovi valori per le proprietà [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).  
4. Salvare il file PPTX modificato.  

Questo codice Javascript dimostra l’operazione:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ottiene il primo effetto della sequenza principale
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Cambia il tipo di animazione testo dell'effetto a "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Cambia il tipo di animazione testo dell'effetto a "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Imposta il ritardo tra le parole al 20% della durata dell'effetto
    firstEffect.setDelayBetweenTextParts(20.0);
    // Scrive il file PPTX su disco
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come posso assicurarmi che le animazioni vengano preservate quando pubblico la presentazione sul web?**

[Esporta in HTML5](/slides/it/nodejs-java/export-to-html5/) e abilita le [opzioni](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/) responsabili delle animazioni di [shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/setanimateshapes/) e di [transition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/setanimatetransitions/). L’HTML semplice non riproduce le animazioni delle diapositive, mentre l’HTML5 lo fa.  

**In che modo la modifica dell’ordine Z (ordine dei livelli) delle forme influisce sull’animazione?**

L’ordine di animazione e l’ordine di disegno sono indipendenti: un effetto controlla il timing e il tipo di comparsa/scomparsa, mentre lo [z-order](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getzorderposition/) determina quale elemento copre quale. Il risultato visibile è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello di effetti‑e‑forme di Aspose.Slides segue la stessa logica.)  

**Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?**

In generale, le [animazioni sono supportate](/slides/it/nodejs-java/convert-powerpoint-to-video/), ma casi rari o effetti specifici potrebbero essere renderizzati diversamente. Si consiglia di testare con gli effetti utilizzati e con la versione della libreria.