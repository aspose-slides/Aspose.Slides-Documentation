---
title: Gestire le transizioni delle diapositive nelle presentazioni in .NET
linktitle: Transizione diapositiva
type: docs
weight: 90
url: /it/net/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione Morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per .NET, con una guida passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni usando Aspose.Slides. Mostra come applicare tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l’avanzamento automatico, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni dell’effetto di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato come file PPTX. L’articolo risponde anche a domande comuni sulla velocità della transizione, i suoni della transizione, l’applicazione della stessa transizione a più diapositive e il controllo della transizione attualmente impostata su una diapositiva.

## **Aggiungi transizione diapositiva**
Per facilitare la comprensione, abbiamo dimostrato l'uso di Aspose.Slides per .NET per gestire semplici transizioni diapositive. Gli sviluppatori possono non solo applicare diversi effetti di transizione alle diapositive, ma anche personalizzare il comportamento di tali effetti. Per creare un semplice effetto di transizione diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Applica un tipo di transizione diapositiva sulla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per .NET tramite l'enumerazione TransitionType.
3. Scrivi il file della presentazione modificata.

```c#
// Istanzia la classe Presentation per caricare il file della presentazione di origine
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Applica la transizione di tipo cerchio alla diapositiva 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Applica la transizione di tipo pettine alla diapositiva 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Salva la presentazione su disco
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Aggiungi transizione diapositiva avanzata**
Nella sezione precedente abbiamo applicato un semplice effetto di transizione alla diapositiva. Ora, per rendere quell’effetto di transizione più avanzato e controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
2. Applica un tipo di transizione diapositiva sulla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per .NET.
3. Puoi anche impostare la transizione per avanzare al clic, dopo un periodo di tempo specifico o entrambi.
4. Se la transizione della diapositiva è abilitata per avanzare al clic, la transizione avverrà solo quando qualcuno farà clic con il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo che il tempo specificato sarà trascorso.
5. Scrivi la presentazione modificata come file di presentazione.

```c#
// Istanzia la classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Applica la transizione di tipo cerchio alla diapositiva 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Imposta il tempo di transizione a 3 secondi
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Applica la transizione di tipo pettine alla diapositiva 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Imposta il tempo di transizione a 5 secondi
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Applica la transizione di tipo zoom alla diapositiva 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Imposta il tempo di transizione a 7 secondi
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Scrivi la presentazione su disco
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Inoltre, utilizzando la proprietà [AdvanceAfter](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceafter/) è possibile verificare se una transizione diapositiva è stata configurata per passare alla diapositiva successiva o disabilitare l'impostazione.

Questo codice C# dimostra l'operazione:

```c#
// Istanzia una classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Ottiene la transizione della diapositiva
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Verifica se l'impostazione Advance After Time è abilitata
        if (slideTransition.AdvanceAfter)
        {
            // Stampa il valore di Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Disabilita la transizione dopo un tempo specifico se il valore AdvancedAfterTime è maggiore di 2 secondi
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Transizione Morph**
Aspose.Slides per .NET ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/imorphtransition). Rappresentano una nuova transizione morph introdotta in PowerPoint 2019. La transizione Morph consente di animare un movimento fluido da una diapositiva all'altra. Questo articolo descrive il concetto e come usare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario avere due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e poi spostare l'oggetto nella seconda diapositiva in una posizione diversa.

Il seguente frammento di codice mostra come aggiungere una copia della diapositiva con del testo alla presentazione e impostare una transizione di [morph type](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) alla seconda diapositiva.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Tipi di transizione Morph**
È stato aggiunto il nuovo enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionmorphtype). Rappresenta diversi tipi di transizione Morph per le diapositive.

L'enumerazione TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo per parole, dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo per caratteri, dove possibile.

Il seguente frammento di codice mostra come impostare la transizione morph su una diapositiva e cambiare il tipo morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Imposta effetti di transizione**
Aspose.Slides per .NET supporta l’impostazione degli effetti di transizione, come da nero, da sinistra, da destra, ecc. Per impostare l’effetto di transizione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
- Ottieni il riferimento della diapositiva.
- Imposta l'effetto di transizione.
- Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Nell’esempio riportato di seguito, abbiamo impostato gli effetti di transizione.

```c#
// Crea un'istanza della classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Imposta l'effetto
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Scrivi la presentazione su disco
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Imposta la [Speed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/speed/) della transizione usando l’impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionspeed/) (ad esempio, slow/medium/fast).

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. È possibile inserire un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e loop (ad esempio, [Sound](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/soundloop/), oltre a metadati come [SoundIsBuiltIn](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) e [SoundName](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Esamina le [impostazioni di transizione](https://reference.aspose.com/slides/it/net/aspose.slides/baseslide/slideshowtransition/) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/type/); quel valore indica esattamente quale effetto è applicato.