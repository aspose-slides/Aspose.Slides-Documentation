---
title: Converti le diapositive di presentazione in immagini in .NET
linktitle: Diapositiva a immagine
type: docs
weight: 41
url: /it/net/convert-slide/
keywords: 
- convertire diapositiva
- esportare diapositiva
- diapositiva in immagine
- salvare diapositiva come immagine
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in C# usando Aspose.Slides per .NET—rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides per .NET consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un’immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive da esportare utilizzando:
    - l’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/), oppure
    - l’interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/irenderingoptions/).
2. Genera l’immagine della diapositiva chiamando il metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/).

In .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) è un oggetto che consente di lavorare con immagini definite da dati dei pixel. Puoi usare un’istanza di questa classe per salvare le immagini in un’ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti diapositive in bitmap e salva le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e poi salvare l’immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice C# dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l’immagine in formato PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converte la prima diapositiva della presentazione in un bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Salva l'immagine nel formato PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Converti diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un’immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/), è possibile convertire una diapositiva in un’immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice dimostra come farlo:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converte la prima diapositiva della presentazione in un bitmap con la dimensione specificata.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Salva l'immagine nel formato JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Converti diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/irenderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le interfacce includono la proprietà `SlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) è possibile specificare la posizione preferita per note e commenti nell’immagine risultante.

Questo codice C# dimostra come convertire una diapositiva con note e commenti:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Carica un file di presentazione.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Crea le opzioni di rendering.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Imposta la posizione delle note.
            CommentsPosition = CommentsPositions.Right,      // Imposta la posizione dei commenti.
            CommentsAreaWidth = 500,                         // Imposta la larghezza dell'area commenti.
            CommentsAreaColor = Color.AntiqueWhite           // Imposta il colore dell'area commenti.
        }
    };

    // Converte la prima diapositiva della presentazione in un'immagine.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Salva l'immagine nel formato GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

In qualsiasi processo di conversione da diapositiva a immagine, la proprietà [NotesPosition](https://reference.aspose.com/slides/it/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) non può essere impostata su `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande, impedendo il corretto adattamento all’interno della dimensione dell’immagine specificata.

{{% /alert %}} 

## **Converti diapositive in immagini utilizzando le opzioni TIFF**

L’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/) offre un controllo maggiore sull’immagine TIFF risultante, consentendo di specificare parametri quali dimensione, risoluzione, palette di colori e altro.

Questo codice C# dimostra un processo di conversione in cui le opzioni TIFF vengono usate per produrre un’immagine in bianco e nero con risoluzione di 300 DPI e dimensioni di 2160 × 2800:

```cs
// Carica un file di presentazione.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Ottieni la prima diapositiva dalla presentazione.
    ISlide slide = presentation.Slides[0];

    // Configura le impostazioni dell'immagine TIFF di output.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Imposta la dimensione dell'immagine.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Imposta il formato dei pixel (bianco e nero).
        DpiX = 300,                                        // Imposta la risoluzione orizzontale.
        DpiY = 300                                         // Imposta la risoluzione verticale.
    };

    // Converte la diapositiva in un'immagine con le opzioni specificate.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Salva l'immagine in formato TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Converti tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando l’intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Renderizza la presentazione in immagini diapositiva per diapositiva.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
        if (presentation.Slides[i].Hidden)
            continue;

        // Converte la diapositiva in un'immagine.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Salva l'immagine nel formato JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Rendering di emoji a colori**

{{% alert title="Note" color="warning" %}} 
Per rendere correttamente le emoji a colori quando si convertono le diapositive di una presentazione in immagini, i caratteri emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo carattere manca, le emoji potrebbero apparire in bianco e nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `GetImage` salva solo un’immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Basta assicurarsi che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.