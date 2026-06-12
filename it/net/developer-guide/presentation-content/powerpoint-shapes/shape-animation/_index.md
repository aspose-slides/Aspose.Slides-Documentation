---
title: Applicare animazioni di forme nelle presentazioni in .NET
linktitle: Animazione di forme
type: docs
weight: 60
url: /it/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come creare e personalizzare le animazioni di forme nelle presentazioni PowerPoint con Aspose.Slides per .NET. Distinguersi!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](/slides/it/net/animated-charts/). Conferiscono vita alle presentazioni o ai loro componenti. 

## **Perché usare le animazioni nelle presentazioni?**

Utilizzando le animazioni, puoi 

* controllare il flusso di informazioni
* sottolineare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* attirare l'attenzione dei lettori o degli spettatori sulle parti importanti di una presentazione

PowerPoint offre molte opzioni e strumenti per le animazioni e gli effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**. 

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi [Aspose.Slides.Animation](https://reference.aspose.com/slides/it/net/aspose.slides.animation/) ,
* Aspose.Slides fornisce oltre **150 effetti di animazione** nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effecttype). Questi effetti sono essenzialmente gli stessi (o equivalenti) effetti utilizzati in PowerPoint.

## **Applicare un'animazione a una TextBox**

Aspose.Slides per .NET consente di applicare un'animazione al testo in una forma. 

1. Creare un'istanza della classe [Presentation](http://www.aspose.com/api/net/slides/it/aspose.slides/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape). 
4. Aggiungere testo a [IAutoShape.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/properties/textframe).
5. Ottenere la sequenza principale di effetti.
6. Aggiungere un effetto di animazione a [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape).
7. Impostare la proprietà [TextAnimation.BuildType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/textanimation/properties/buildtype) sul valore proveniente dall'[enumerazione BuildType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/buildtype).
8. Scrivere la presentazione su disco come file PPTX.

Questo codice C# mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo sul valore *By 1st Level Paragraphs*:

```c#
 // Istanzia una classe Presentation che rappresenta un file di presentazione.
 using (Presentation pres = new Presentation())
 {
     ISlide sld = pres.Slides[0];
     
     // Aggiunge una nuova AutoShape con testo
     IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

     ITextFrame textFrame = autoShape.TextFrame;
     textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

     // Ottiene la sequenza principale della diapositiva.
     ISequence sequence = sld.Timeline.MainSequence;

     // Aggiunge l'effetto di animazione Fade alla forma
     IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

     // Anima il testo della forma per paragrafi di primo livello
     effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

     // Salva il file PPTX su disco
     pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
 }
```

{{%  alert color="primary"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides/iparagraph). Vedi [**Animated Text**](/slides/it/net/animated-text/).

{{% /alert %}} 

## **Applicare un'animazione a una PictureFrame**

1. Creare un'istanza della classe [Presentation](http://www.aspose.com/api/net/slides/it/aspose.slides/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere o ottenere un [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe) sulla diapositiva. 
5. Ottenere la sequenza principale di effetti.
6. Aggiungere un effetto di animazione a [PictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe).
8. Scrivere la presentazione su disco come file PPTX.

Questo codice C# mostra come applicare l'effetto `Fly` a un picture frame:

```c#
 // Istanzia una classe Presentation che rappresenta un file di presentazione.
 using (Presentation pres = new Presentation())
 {
     // Carica l'immagine da aggiungere alla collezione di immagini della presentazione
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // Aggiunge un picture frame alla diapositiva
     IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // Ottiene la sequenza principale della diapositiva.
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // Aggiunge l'effetto di animazione Fly da sinistra al picture frame
     IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

     // Salva il file PPTX su disco
     pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
 }
```

## **Applicare un'animazione a una Shape**

1. Creare un'istanza della classe [Presentation](http://www.aspose.com/api/net/slides/it/aspose.slides/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape). 
4. Aggiungere un `Bevel` [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape) (quando questo oggetto viene cliccato, l'animazione viene eseguita).
5. Creare una sequenza di effetti sulla forma bevel.
6. Creare un `UserPath` personalizzato.
7. Aggiungere comandi per muoversi al `UserPath`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice C# mostra come applicare l'effetto `PathFootball` (path football) a una shape:

```c#
 // Istanzia una classe Presentation che rappresenta un file di presentazione.
 using (Presentation pres = new Presentation())
 {
     ISlide sld = pres.Slides[0];

     // Crea l'effetto PathFootball per la forma esistente da zero.
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

     ashp.AddTextFrame("Animated TextBox");

     // Aggiunge l'effetto di animazione PathFootBall.
     pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                            EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Crea una sorta di "pulsante".
     IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

     // Crea una sequenza di effetti per il pulsante.
     ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

     // Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante è stato cliccato.
     IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Aggiunge comandi per lo spostamento poiché il percorso creato è vuoto.
     IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

     PointF[] pts = new PointF[1];
     pts[0] = new PointF(0.076f, 0.59f);
     motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
     pts[0] = new PointF(-0.076f, -0.59f);
     motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
     motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Scrive il file PPTX su disco
     pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
 }
```

## **Ottenere gli effetti di animazione applicati a una Shape**

I seguenti esempi mostrano come utilizzare il metodo `GetEffectsByShape` dell'interfaccia [ISequence](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/) per ottenere tutti gli effetti di animazione applicati a una shape.

**Esempio 1: Ottenere gli effetti di animazione applicati a una shape su una diapositiva normale**

In precedenza, hai imparato come aggiungere effetti di animazione alle shape nelle presentazioni PowerPoint. Il seguente codice di esempio mostra come ottenere gli effetti applicati alla prima shape sulla prima diapositiva normale nella presentazione `AnimExample_out.pptx`.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Ottiene la sequenza principale di animazione della diapositiva.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Ottiene la prima shape della prima diapositiva.
    IShape shape = firstSlide.Shapes[0];

    // Ottiene gli effetti di animazione applicati alla shape.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati dai segnaposto**

Se una shape su una diapositiva normale ha segnaposto che si trovano nella diapositiva layout e/o master, e sono stati aggiunti effetti di animazione a questi segnaposto, allora tutti gli effetti della shape verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposto.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una diapositiva contenente solo una shape di piè di pagina con il testo "Made with Aspose.Slides" e l'effetto **Random Bars** applicato alla shape.

![Effetto di animazione della shape della diapositiva](slide-shape-animation.png)

Assumiamo inoltre che l'effetto **Split** sia applicato al segnaposto di piè di pagina nella diapositiva **layout**.

![Effetto di animazione della shape del layout](layout-shape-animation.png)

Infine, l'effetto **Fly In** è applicato al segnaposto di piè di pagina nella diapositiva **master**.

![Effetto di animazione della shape master](master-shape-animation.png)

Il seguente codice di esempio mostra come utilizzare il metodo `GetBasePlaceholder` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) per accedere ai segnaposto della shape e ottenere gli effetti di animazione applicati alla shape del piè di pagina, includendo quelli ereditati dai segnaposto situati nelle diapositive layout e master.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottieni gli effetti di animazione della shape sulla diapositiva normale.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Ottieni gli effetti di animazione del segnaposto sulla diapositiva layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Ottieni gli effetti di animazione del segnaposto sulla diapositiva master.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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

## **Modificare le proprietà di temporizzazione degli effetti di animazione**

Aspose.Slides per .NET consente di modificare le proprietà di temporizzazione di un effetto di animazione.

![Pannello di temporizzazione dell'animazione](shape-animation.png)

Queste sono le corrispondenze tra la temporizzazione di PowerPoint e le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effect/properties/timing):

- L'elenco a discesa **Start** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/properties/triggertype). 
- La **Duration** di PowerPoint corrisponde alla proprietà [Effect.Timing.Duration](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/properties/duration). La durata di un'animazione (in secondi) è il tempo totale necessario per completare un ciclo. 
- Il **Delay** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- L'elenco a discesa **Repeat** di PowerPoint corrisponde a queste proprietà: 
  * la proprietà [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatcount) che descrive il *numero* di volte in cui l'effetto è ripetuto;
  * il flag [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilendslide) che specifica se l'effetto è ripetuto fino alla fine della diapositiva;
  * il flag [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/repeatuntilnextclick) che specifica se l'effetto è ripetuto fino al prossimo clic.
- La casella di controllo **Rewind when done playing** di PowerPoint corrisponde alla proprietà [Effect.Timing.Rewind](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itiming/rewind/). 

Questo è come cambiare le proprietà di temporizzazione dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta nuovi valori per le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effect/properties/timing) di cui hai bisogno. 
3. Salva il file PPTX modificato.

```c#
 // Istanzia una classe Presentation che rappresenta un file di presentazione.
 using (Presentation pres = new Presentation("AnimExample_out.pptx"))
 {
     // Ottiene la sequenza principale della diapositiva.
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // Ottiene il primo effetto della sequenza principale.
     IEffect effect = sequence[0];

     // Cambia il TriggerType dell'effetto per avviare al clic
     effect.Timing.TriggerType = EffectTriggerType.OnClick;

     // Cambia la durata dell'effetto
     effect.Timing.Duration = 3f;

     // Cambia il TriggerDelayTime dell'effetto
     effect.Timing.TriggerDelayTime = 0.5f;

     // Se il valore Repeat dell'effetto è "none"
     if (effect.Timing.RepeatCount == 1f)
     {
         // Cambia il Repeat dell'effetto su "Until Next Click"
         effect.Timing.RepeatUntilNextClick = true;
     }
     else
     {
         // Cambia il Repeat dell'effetto su "Until End of Slide"
         effect.Timing.RepeatUntilEndSlide = true;
     }

     // Attiva il Rewind dell'effetto
         effect.Timing.Rewind = true;
     
     // Salva il file PPTX su disco
     pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
 }
```

## **Suono dell'effetto di animazione**

Aspose.Slides fornisce queste proprietà per consentire di lavorare con i suoni negli effetti di animazione: 
- [IEffect.Sound](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Aggiungere un suono all'effetto di animazione**

Questo codice C# mostra come aggiungere un suono all'effetto di animazione e interromperlo quando inizia l'effetto successivo:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Aggiunge audio alla collezione audio della presentazione
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Ottiene la sequenza principale della diapositiva.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Ottiene il primo effetto della sequenza principale
	IEffect firstEffect = sequence[0];

	// Verifica l'effetto per "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Aggiunge suono per il primo effetto
		firstEffect.Sound = effectSound;
	}

	// Ottiene la prima sequenza interattiva della diapositiva.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Imposta il flag "Stop previous sound" dell'effetto
	interactiveSequence[0].StopPreviousSound = true;

	// Scrive il file PPTX su disco
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Estrarre un suono dall'effetto di animazione**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice. 
3. Ottenere la sequenza principale di effetti. 
4. Estrarre il [Sound](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effect/sound/) incorporato in ogni effetto di animazione. 

```c#
// Istanzia una classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Ottiene la sequenza principale della diapositiva.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Estrae il suono dell'effetto in un array di byte
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Dopo l'animazione**

Aspose.Slides per .NET consente di modificare la proprietà After animation di un effetto di animazione.

![Pannello After Animation](shape-after-animation.png)

L'elenco a discesa **After animation** di PowerPoint corrisponde a queste proprietà: 

- La proprietà [IEffect.AfterAnimationType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/afteranimationtype/) che descrive il tipo di After animation :
  * PowerPoint **More Colors** corrisponde al tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** corrisponde al tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) (tipo predefinito di after animation);
  * PowerPoint **Hide After Animation** corrisponde al tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** corrisponde al tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/) ;
- La proprietà [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/afteranimationcolor/) che definisce un formato di colore after animation. Questa proprietà funziona in combinazione con il tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/net/aspose.slides.animation/afteranimationtype/). Se cambi il tipo a un altro, il colore after animation verrà cancellato.

```c#
// Istanzia una classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ottiene il primo effetto della sequenza principale
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Cambia il tipo di After animation in Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Imposta il colore di attenuazione After animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Scrive il file PPTX su disco
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per consentire di lavorare con il blocco *Animate text* di un effetto di animazione:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/animatetexttype/) che descrive il tipo di animazione del testo dell'effetto. Il testo della shape può essere animato:
  * Tutto in una volta ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/it/net/aspose.slides.animation/animatetexttype/) tipo)
  * Per parola ([AnimateTextType.ByWord](https://reference.aspose.com/slides/it/net/aspose.slides.animation/animatetexttype/) tipo)
  * Per lettera ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/it/net/aspose.slides.animation/animatetexttype/) tipo)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/delaybetweentextparts/) imposta un ritardo tra le parti del testo animate (parole o lettere). Un valore positivo indica la percentuale della durata dell'effetto. Un valore negativo indica il ritardo in secondi.

Questo è come è possibile modificare le proprietà Animate text dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Impostare la proprietà [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/itextanimation/buildtype/) su valore [BuildType.AsOneObject](https://reference.aspose.com/slides/it/net/aspose.slides.animation/buildtype/) per disattivare la modalità di animazione *By Paragraphs*.
3. Impostare nuovi valori per le proprietà [IEffect.AnimateTextType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/animatetexttype/) e [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/it/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Salvare il file PPTX modificato.

```c#
// Istanzia una classe Presentation che rappresenta un file di presentazione.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ottiene il primo effetto della sequenza principale
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Cambia il tipo di animazione del testo dell'effetto in "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Cambia il tipo di animazione del testo dell'effetto in "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Imposta il ritardo tra le parole al 20% della durata dell'effetto
    firstEffect.DelayBetweenTextParts = 20f;

    // Scrive il file PPTX su disco
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Come posso garantire che le animazioni siano preservate quando pubblico la presentazione sul web?**

[Export to HTML5](/slides/it/net/export-to-html5/) e abilita le [opzioni](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/) responsabili delle animazioni di [shape](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animateshapes/) e di [transition](https://reference.aspose.com/slides/it/net/aspose.slides.export/html5options/animatetransitions/). L'HTML semplice non riproduce le animazioni delle diapositive, mentre l'HTML5 lo fa.

**Come influisce la modifica dell'ordine Z (ordine dei livelli) delle shape sull'animazione?**

L'ordine di animazione e di disegno sono indipendenti: un effetto controlla la temporizzazione e il tipo di apparizione/scomparsa, mentre lo [z-order](https://reference.aspose.com/slides/it/net/aspose.slides/shape/zorderposition/) determina cosa copre cosa. Il risultato visibile è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello effetti‑e‑shape di Aspose.Slides segue la stessa logica.)

**Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?**

In generale, le [animazioni sono supportate](/slides/it/net/convert-powerpoint-to-video/), ma in casi rari o per effetti specifici potrebbero essere renderizzate in modo diverso. Si consiglia di testare con gli effetti utilizzati e con la versione della libreria.