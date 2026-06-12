---
title: Renderizza diapositiva come immagine SVG
type: docs
weight: 50
url: /it/net/render-slide-as-svg-image/
---
SVG—un acronimo di Scalable Vector Graphics—è un tipo o formato grafico standard utilizzato per rendere immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l'aspetto. 

SVG è uno dei pochi formati di immagini che soddisfa standard molto elevati in questi ambiti: scalabilità, interattività, prestazioni, accessibilità, programmabilità e altri. Per questi motivi è comunemente usato nello sviluppo web. 

Potresti voler utilizzare file SVG in questi scenari:

- quando prevedi di stampare la tua presentazione in un formato molto grande. Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG tutte le volte necessarie senza sacrificare la qualità.
- quando intendi utilizzare grafici e diagrammi dalle tue diapositive in diversi mezzi o piattaforme. La maggior parte dei lettori può interpretare i file SVG. 
- quando hai bisogno di utilizzare le dimensioni più piccole possibili per le immagini. I file SVG sono generalmente più piccoli delle loro controparti ad alta risoluzione in altri formati, soprattutto quelli basati su bitmap (JPEG o PNG).

Aspose.Slides per .NET consente di esportare le diapositive delle tue presentazioni come immagini **SVG**. Per generare un'immagine SVG da qualsiasi diapositiva, procedi così:

- Crea un'istanza della classe Presentation.
- Scorri tutte le diapositive della presentazione.
- Scrivi ogni diapositiva in un proprio file SVG tramite FileStream.

{{% alert color="primary" %}} 
Potresti provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) in cui abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per .NET.
{{% /alert %}} 

Questo codice di esempio in C# mostra come convertire PPT in SVG utilizzando Aspose.Slides:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```