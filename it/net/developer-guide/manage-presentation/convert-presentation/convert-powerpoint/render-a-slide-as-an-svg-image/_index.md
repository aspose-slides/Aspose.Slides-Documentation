---
title: Renderizza le diapositive di presentazione come immagini SVG in .NET
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- salva PPT come SVG
- salva PPTX come SVG
- esporta PPT in SVG
- esporta PPTX in SVG
- renderizza diapositiva
- converti diapositiva
- esporta diapositiva
- immagine vettoriale
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come renderizzare le diapositive PowerPoint come immagini SVG usando Aspose.Slides per .NET. Visuali di alta qualità con semplici esempi di codice C#."
---
## **Panoramica**

Questo articolo spiega come rendere le diapositive di una presentazione come immagini SVG utilizzando Aspose.Slides. Descrive il formato SVG e i suoi vantaggi, inclusi scalabilità, accessibilità e idoneità per lo sviluppo web.

Imparerai come caricare un file di presentazione, iterare tra le sue diapositive e salvare ogni diapositiva come file SVG separato. L'articolo copre i formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, ODP e PPS, e mostra come eseguire la conversione programmaticamente con la classe `Presentation` e il metodo `WriteAsSvg`.

## **Formato SVG**
SVG — acronimo di Scalable Vector Graphics — è un tipo o formato grafico standard utilizzato per rendere immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l'aspetto.

SVG è uno dei pochi formati per immagini che soddisfa standard molto elevati in questi ambiti: scalabilità, interattività, prestazioni, accessibilità, programmabilità e altri. Per questi motivi è comunemente usato nello sviluppo web.

Potresti voler utilizzare file SVG quando hai bisogno di

- **stampare la tua presentazione in un *formato molto grande*.** Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG tutte le volte necessarie senza sacrificare la qualità.
- **utilizzare grafici e diagrammi dalle tue diapositive in *mezzi o piattaforme diversi**.* La maggior parte dei lettori può interpretare i file SVG.
- **usare le *dimensioni più piccole possibili per le immagini***. I file SVG sono generalmente più piccoli delle loro controparti ad alta risoluzione in altri formati, specialmente quelli basati su bitmap (JPEG o PNG).

## **Renderizzare una diapositiva come immagine SVG**

Aspose.Slides per .NET ti permette di esportare le diapositive nelle tue presentazioni come immagini SVG. Segui questi passaggi per generare immagini SVG:

_Passi: Conversioni da PowerPoint a SVG in C#_

Il seguente codice di esempio spiega queste conversioni usando .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Passi: Converti PowerPoint in SVG in C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Passi: Converti PPT in SVG in C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Passi: Converti PPTX in SVG in C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Passi: Converti ODP in SVG in C#</strong></a>

_Codice passo passo:_

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
   * estensione _.ppt_ per caricare il file **PPT** nella classe _Presentation_.
   * estensione _.pptx_ per caricare il file **PPTX** nella classe _Presentation_.
   * estensione _.odp_ per caricare il file **ODP** nella classe _Presentation_.
   * estensione _.pps_ per caricare il file **PPS** nella classe _Presentation_.
2. Itera tra tutte le diapositive della presentazione.
3. Scrivi ogni diapositiva nel proprio file SVG tramite FileStream.

{{% alert color="primary" %}} 

Potresti provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) in cui abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per .NET.

{{% /alert %}} 

Questo codice di esempio in C# ti mostra come convertire PowerPoint in SVG usando Aspose.Slides: 

``` csharp
// L'oggetto Presentation può caricare formati PowerPoint come PPT, PPTX, ODP ecc.
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

## **FAQ**

**Perché l'SVG risultante può apparire diverso a seconda del browser?**

Il supporto per specifiche funzionalità SVG è implementato in modo diverso dai motori dei browser. I parametri [SVGOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/) aiutano a attenuare le incompatibilità.

**È possibile esportare non solo le diapositive ma anche forme individuali in SVG?**

Sì. Qualsiasi [shape può essere salvata come SVG separato](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/), il che è comodo per icone, pittogrammi e riutilizzo di grafica.

**È possibile combinare più diapositive in un unico SVG (striscia/documento)?**

Lo scenario standard è una diapositiva → un SVG. Combinare più diapositive in un unico canvas SVG è un'operazione di post‑processing eseguita a livello dell'applicazione.

## **Vedi anche** 

Questo articolo copre anche questi argomenti. I codici sono gli stessi di quelli sopra.

_Formato_: **PowerPoint**
- [C# PowerPoint to SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Converter](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT to SVG Code](#csharp-ppt-to-svg)
- [C# PPT to SVG API](#csharp-ppt-to-svg)
- [C# PPT to SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT to SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT to SVG Converter](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX to SVG Code](#csharp-pptx-to-svg)
- [C# PPTX to SVG API](#csharp-pptx-to-svg)
- [C# PPTX to SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX to SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX to SVG Converter](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP to SVG Code](#csharp-odp-to-svg)
- [C# ODP to SVG API](#csharp-odp-to-svg)
- [C# ODP to SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP to SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP to SVG Converter](#csharp-odp-to-svg)