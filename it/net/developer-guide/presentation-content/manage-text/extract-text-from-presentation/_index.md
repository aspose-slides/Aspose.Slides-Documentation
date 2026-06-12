---
title: Estrazione avanzata di testo dalle presentazioni in .NET
linktitle: Estrai testo
type: docs
weight: 90
url: /it/net/extract-text-from-presentation/
keywords:
- estrarre testo
- estrarre testo dalla diapositiva
- estrarre testo dalla presentazione
- estrarre testo da PowerPoint
- estrarre testo da OpenDocument
- estrarre testo da PPT
- estrarre testo da PPTX
- estrarre testo da ODP
- recuperare testo
- recuperare testo dalla diapositiva
- recuperare testo dalla presentazione
- recuperare testo da PowerPoint
- recuperare testo da OpenDocument
- recuperare testo da PPT
- recuperare testo da PPTX
- recuperare testo da ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Estrai rapidamente il testo da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET. Segui la nostra semplice guida passo passo per risparmiare tempo."
---
## **Panoramica**

L'estrazione del testo dalle presentazioni è un'attività comune ma essenziale per gli sviluppatori che lavorano con contenuti delle diapositive. Che tu stia gestendo file Microsoft PowerPoint in formato PPT o PPTX, o presentazioni OpenDocument (ODP), accedere e recuperare i dati testuali può essere fondamentale per analisi, automazione, indicizzazione o migrazione di contenuti.

Questo articolo fornisce una guida completa su come estrarre in modo efficiente il testo da vari formati di presentazione, inclusi PPT, PPTX e ODP, utilizzando Aspose.Slides per .NET. Imparerai come iterare sistematicamente gli elementi della presentazione per recuperare accuratamente il contenuto testuale di cui hai bisogno.

## **Estrai testo da una diapositiva**

Aspose.Slides per .NET fornisce lo spazio dei nomi [Aspose.Slides.Util](https://reference.aspose.com/slides/it/net/aspose.slides.util/) che include la classe [SlideUtil](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/). Questa classe espone diversi metodi statici sovraccaricati per estrarre tutto il testo da una presentazione o da una diapositiva. Per estrarre il testo da una diapositiva in una presentazione, utilizza il metodo [GetAllTextBoxes](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/getalltextboxes/). Questo metodo accetta un oggetto di tipo [IBaseSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/) come parametro. Quando eseguito, il metodo scandisce l'intera diapositiva alla ricerca di testo e restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/), mantenendo qualsiasi formattazione del testo.

Il seguente frammento di codice estrae tutto il testo dalla prima diapositiva della presentazione:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Estrai testo da una presentazione**

Per scansionare il testo dell'intera presentazione, usa il metodo statico [GetAllTextFrames](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/getalltextframes/) esposto dalla classe [SlideUtil](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/). Accetta due parametri:

1. Primo, un oggetto [IPresentation](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/) che rappresenta una presentazione PowerPoint o OpenDocument da cui verrà estratto il testo.
1. Secondo, un valore `Boolean` che indica se le diapositive master devono essere incluse durante la scansione del testo nella presentazione.

Il metodo restituisce un array di oggetti di tipo [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/), includendo le informazioni di formattazione del testo. Il codice sottostante scandisce il testo e i dettagli di formattazione da una presentazione, incluse le diapositive master.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Estrazione di testo categorizzata e veloce**

La classe [PresentationFactory](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/) fornisce anche metodi per estrarre tutto il testo dalle presentazioni:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

L'argomento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/it/net/aspose.slides/textextractionarrangingmode/) indica la modalità di organizzazione del risultato di estrazione del testo e può essere impostato sui seguenti valori:
- `Unarranged` - Il testo grezzo senza considerare la sua posizione sulla diapositiva.
- `Arranged` - Il testo è disposto nello stesso ordine della diapositiva.

La modalità `Unarranged` può essere usata quando la velocità è fondamentale; è più veloce della modalità `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationtext/) rappresenta il testo grezzo estratto dalla presentazione. La sua proprietà `SlidesText` restituisce un array di oggetti di tipo [ISlideText](https://reference.aspose.com/slides/it/net/aspose.slides/islidetext/). Ogni oggetto rappresenta il testo sulla diapositiva corrispondente. L'oggetto di tipo [ISlideText](https://reference.aspose.com/slides/it/net/aspose.slides/islidetext/) ha le seguenti proprietà:

- `Text` - Il testo all'interno delle forme della diapositiva.
- `MasterText` - Il testo all'interno delle forme della diapositiva master associate a questa diapositiva.
- `LayoutText` - Il testo all'interno delle forme della diapositiva layout associate a questa diapositiva.
- `NotesText` - Il testo all'interno delle forme della diapositiva note associate a questa diapositiva.
- `CommentsText` - Il testo all'interno dei commenti associati a questa diapositiva.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Quanto velocemente Aspose.Slides elabora grandi presentazioni durante l'estrazione del testo?**

Aspose.Slides è ottimizzato per alte prestazioni e può elaborare anche [grandi presentazioni](/slides/it/net/open-presentation/), rendendolo adatto a scenari di elaborazione in tempo reale o in batch.

**Aspose.Slides può estrarre testo da tabelle e grafici all'interno delle presentazioni?**

Sì. Aspose.Slides può estrarre testo da molti elementi della diapositiva, incluse tabelle e oggetti correlati a grafici, così da poter accedere e analizzare il contenuto testuale nelle strutture di presentazione comuni.

**È necessaria una licenza speciale di Aspose.Slides per estrarre testo dalle presentazioni?**

Puoi estrarre testo utilizzando la versione di prova gratuita di Aspose.Slides, anche se avrà [alcune limitazioni](/slides/it/net/licensing/), come la possibilità di elaborare solo un numero limitato di diapositive. Per un utilizzo senza restrizioni e per gestire presentazioni più grandi, si consiglia di acquistare una licenza completa.