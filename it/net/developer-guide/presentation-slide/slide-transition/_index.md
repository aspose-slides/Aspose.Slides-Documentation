---
title: Gestire le transizioni delle diapositive nelle presentazioni in .NET
linktitle: Transizione diapositiva
type: docs
weight: 90
url: /it/net/slide-transition/
keywords:
- transizione diapositiva
- aggiungere transizione diapositiva
- applicare transizione diapositiva
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
description: "Applica le transizioni delle diapositive, configura l'avanzamento automatico delle diapositive e personalizza le transizioni Morph e altri effetti di transizione con Aspose.Slides per .NET."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per .NET, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l'avanzamento con clic del mouse o timer e regolare le opzioni specifiche per un effetto. Questo articolo utilizza esempi in C# per applicare le transizioni, impostare durate precise delle transizioni, gestire la temporizzazione delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere una transizione diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e accedi alla proprietà [SlideShowTransition](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/slideshowtransition/) della diapositiva. Imposta il suo [Type](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/type/) a un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitiontype/), quindi salva la presentazione.

L'esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Aggiungere transizione diapositiva avanzata**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. Le seguenti proprietà controllano questo comportamento:

- [AdvanceOnClick](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceonclick/) consente allo spettatore di avanzare facendo clic con il mouse.
- [AdvanceAfter](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceafter/) abilita l'avanzamento automatico.
- [AdvanceAfterTime](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceaftertime/) specifica il ritardo prima dell'avanzamento automatico, in millisecondi.

Abilita sia l'avanzamento con clic che quello temporizzato per consentire allo spettatore di procedere con un clic o attendere il timer. Per usare solo il timer, imposta [AdvanceOnClick] a `false`. Il ritardo controlla quando la presentazione avanza; non imposta la durata dell'effetto di transizione visiva.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l'avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Per verificare se l'avanzamento temporizzato è abilitato, leggi [AdvanceAfter](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceafter/). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L'esempio successivo apre il file salvato sopra, segnala ogni timer abilitato e disabilita l'avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Controllare con precisione il timing della transizione**

Usa [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/duration/) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. La proprietà [SlideShowTransition](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/slideshowtransition/) della diapositiva espone queste impostazioni attraverso [ISlideShowTransition](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/):

| Proprietà | Scopo |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/duration/) | Imposta la durata dell'effetto di transizione stesso, in millisecondi. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Abilita [AdvanceAfter](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/advanceafter/) per attivare questo timer. |
| [Speed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/speed/) | Seleziona una categoria di velocità predefinita da [TransitionSpeed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium o Fast. Viene usata quando non è specificata una durata esatta. |

Il [Duration] controlla solo l'effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo dell'avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell'effetto dal tipo di transizione e dal valore di [Speed].

### **Applicare la stessa durata a tutte le diapositive**

Per una cadenza costante, applica lo stesso effetto e la stessa durata esatta a tutte le diapositive. Questo esempio carica `input.pptx`, seleziona Fade da [TransitionType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitiontype/), e assegna a ogni transizione una durata di 750 millisecondi. Abilita separatamente l'avanzamento automatico dopo 5.000 millisecondi e disabilita l'avanzamento con clic del mouse, quindi salva il risultato come PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Impostare durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto differenti. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l'introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1.200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordinare le transizioni con l'output animato**

Quando si prepara un [animated GIF](/slides/it/net/convert-powerpoint-to-animated-gif/), una [presentazione HTML5](/slides/it/net/export-to-html5/) o un [video](/slides/it/net/convert-powerpoint-to-video/), imposta durate di transizione precise prima dell'esportazione per corrispondere al ritmo desiderato. Ad esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ogni diapositiva per consentire il tempo per la narrazione o il contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi di output con la durata dell'effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fotogrammi al secondo. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Verifica gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza in anteprima l'output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Leggi [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/duration/) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e [Speed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/speed/) per determinare tale durata. Impostare un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra gli oggetti su diapositive consecutive. Per creare un effetto Morph semplice, clona una diapositiva, sposta o ridimensiona un oggetto nella copia e applica la transizione Morph alla seconda diapositiva. Questo fornisce alla transizione gli oggetti corrispondenti da animare tra lo stato originale e quello modificato.

L'esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e modifica la posizione e le dimensioni del rettangolo nella copia. Successivamente seleziona Morph dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l'effetto durante la presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Tipi di transizione Morph**

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionmorphtype/) controlla come Morph abbina e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionmorphtype/) tratta ogni forma come un intero oggetto.
- [ByWord](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionmorphtype/) anima il testo abbinando le parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionmorphtype/) anima il testo abbinando i caratteri dove possibile.

Imposta la proprietà [Type] della transizione a Morph prima di accedere al suo [Value]. Il valore fornisce quindi l'interfaccia [IMorphTransition](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/imorphtransition/), la cui proprietà [MorphType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/imorphtransition/morphtype/) seleziona la modalità di corrispondenza.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Impostare gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l'effetto inizia da una schermata nera. Le opzioni disponibili dipendono dal tipo di transizione selezionato. Imposta prima il tipo, quindi utilizza l'interfaccia appropriata dal suo [Value](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/value/).

L'esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Imposta [FromBlack](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) tramite [IOptionalBlackTransition](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/ioptionalblacktransition/) in modo che la transizione inizi da una schermata nera.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Preferisci [Duration](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/duration/) quando hai bisogno di una durata esatta dell'effetto in millisecondi. Usa [Speed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/slideshowtransition/speed/) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium o Fast — e non è impostata una durata esplicita. Queste impostazioni controllano l'effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare un audio a una transizione e farlo ripetere in loop?**

Sì. Assegna l'audio incorporato a [Sound](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/sound/), imposta [SoundMode](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/soundmode/) su StartSound dall'enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitionsoundmode/) e abilita [SoundLoop](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/soundloop/). L'audio si ripete in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più rapido per applicare la stessa transizione a tutte le diapositive?**

Scorri la collezione [Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) della presentazione e imposta la proprietà [Type](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/type/) della transizione di ogni diapositiva allo stesso valore. Imposta eventuali opzioni di timing ed effetto nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Leggi la proprietà [Type](https://reference.aspose.com/slides/it/net/aspose.slides/islideshowtransition/type/) dalla [SlideShowTransition](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/slideshowtransition/) della diapositiva. Restituisce un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/net/aspose.slides.slideshow/transitiontype/); None indica che non è stato applicato alcun effetto di transizione.