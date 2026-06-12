---
title: Converti le diapositive della presentazione in immagini in .NET
linktitle: Diapositiva in immagine
type: docs
weight: 41
url: /it/net/convert-slide/
keywords:
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
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
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in C# utilizzando Aspose.Slides per .NET—rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides per .NET consente di convertire facilmente le diapositive delle presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive da esportare utilizzando:
    - L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/) o
    - L'interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/irenderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/).

In .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) è un oggetto che consente di lavorare con immagini definite da dati pixel. Puoi utilizzare un'istanza di questa classe per salvare le immagini in una vasta gamma di formati (BMP, JPG, PNG, ecc.).

## **Convertire le diapositive in bitmap e salvare le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e quindi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice C# dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converti la prima diapositiva della presentazione in una bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Salva l'immagine nel formato PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Convertire le diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un'immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/), puoi convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice mostra come farlo:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Converti la prima diapositiva della presentazione in una bitmap con le dimensioni specificate.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Salva l'immagine nel formato JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Convertire le diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/irenderingoptions/)—che consentono di controllare il rendering delle diapositive della presentazione in immagini. Entrambe le interfacce includono la proprietà `SlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) puoi specificare la posizione preferita per note e commenti nell'immagine risultante.

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
            CommentsAreaWidth = 500,                         // Imposta la larghezza dell'area dei commenti.
            CommentsAreaColor = Color.AntiqueWhite           // Imposta il colore dell'area dei commenti.
        }
    };

    // Converti la prima diapositiva della presentazione in un'immagine.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Salva l'immagine nel formato GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
In qualsiasi processo di conversione da diapositiva a immagine, la proprietà [NotesPosition](https://reference.aspose.com/slides/it/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) non può essere impostata su `BottomFull` (per specificare la posizione delle note) perché il testo di una nota può essere troppo grande, rendendo impossibile adattarlo alla dimensione dell'immagine specificata.
{{% /alert %}} 

## **Convertire le diapositive in immagini utilizzando le opzioni TIFF**

L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante, consentendo di specificare parametri come dimensione, risoluzione, tavolozza dei colori e altro.

Questo codice C# dimostra un processo di conversione in cui le opzioni TIFF vengono utilizzate per generare un'immagine in bianco e nero con una risoluzione di 300 DPI e una dimensione di 2160 × 2800:

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
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Imposta il formato pixel (bianco e nero).
        DpiX = 300,                                        // Imposta la risoluzione orizzontale.
        DpiY = 300                                         // Imposta la risoluzione verticale.
    };

    // Converti la diapositiva in un'immagine con le opzioni specificate.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Salva l'immagine in formato TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Convertire tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando efficacemente l'intera presentazione in una serie di immagini.

Questo esempio di codice mostra come convertire tutte le diapositive di una presentazione in immagini in C#:

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

        // Converti la diapositiva in un'immagine.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Salva l'immagine nel formato JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **FAQ**

**1. Aspose.Slides supporta il rendering delle diapositive con animazioni?**

No, il metodo `GetImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**2. Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Assicurati solo che siano incluse nel ciclo di elaborazione.

**3. Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici durante il salvataggio delle diapositive come immagini.