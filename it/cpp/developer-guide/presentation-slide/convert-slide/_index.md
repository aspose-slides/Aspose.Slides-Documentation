---
title: Convertire le diapositive della presentazione in immagini in C++
linktitle: Diapositiva in immagine
type: docs
weight: 41
url: /it/cpp/convert-slide/
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
- C++
- Aspose.Slides
description: "Converti le diapositive da PPT, PPTX e ODP in immagini in C++ utilizzando Aspose.Slides—rendering veloce e di alta qualità con esempi di codice chiari."
---
## **Introduzione**

Aspose.Slides per C++ consente di convertire facilmente le diapositive delle presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive che vuoi esportare utilizzando:
    - L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/) oppure
    - L'interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/).
2. Genera l'immagine della diapositiva chiamando il metodo [GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/).

Un [Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/) è un oggetto che consente di lavorare con immagini definite da dati di pixel. È possibile utilizzare un'istanza di questa classe per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Convertire le diapositive in bitmap e salvare le immagini in PNG**

È possibile convertire una diapositiva in un oggetto bitmap e utilizzarlo direttamente nella propria applicazione. In alternativa, è possibile convertire una diapositiva in un bitmap e poi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice C++ mostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converti la prima diapositiva della presentazione in un bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Salva l'immagine nel formato PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convertire le diapositive in immagini con dimensioni personalizzate**

Potrebbe essere necessario ottenere un'immagine di dimensioni specifiche. Utilizzando una sovraccarico del metodo [GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/), è possibile convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza). 

Questo esempio di codice dimostra come farlo:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Converti la prima diapositiva della presentazione in un bitmap con le dimensioni specificate.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Salva l'immagine nel formato JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convertire le diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le interfacce includono il metodo `set_SlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) è possibile specificare la posizione preferita per note e commenti nell'immagine risultante.

Questo codice C++ mostra come convertire una diapositiva con note e commenti:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Imposta la posizione delle note.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Imposta la posizione dei commenti.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Imposta la larghezza dell'area dei commenti.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Imposta il colore dell'area dei commenti.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

In qualsiasi processo di conversione da diapositiva a immagine, il metodo [set_NotesPosition](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota può essere troppo grande, impedendone l'adattamento alla dimensione dell'immagine specificata.

{{% /alert %}} 

## **Convertire le diapositive in immagini utilizzando le opzioni TIFF**

L'interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/) offre un maggiore controllo sull'immagine TIFF risultante consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice C++ dimostra un processo di conversione in cui le opzioni TIFF sono utilizzate per produrre un'immagine in bianco e nero con risoluzione 300 DPI e dimensione di 2160 × 2800:

```cpp 
// Carica un file di presentazione.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ottieni la prima diapositiva dalla presentazione.
auto slide = presentation->get_Slide(0);

// Configura le impostazioni dell'immagine TIFF di output.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Imposta la dimensione dell'immagine.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Imposta il formato pixel (bianco e nero).
tiffOptions->set_DpiX(300);                                         // Imposta la risoluzione orizzontale.
tiffOptions->set_DpiY(300);                                         // Imposta la risoluzione verticale.

// Converti la diapositiva in un'immagine con le opzioni specificate.
auto image = slide->GetImage(tiffOptions);

// Salva l'immagine in formato TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convertire tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando efficacemente l'intera presentazione in una serie di immagini.

Questo esempio di codice mostra come convertire tutte le diapositive di una presentazione in immagini in C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Renderizza la presentazione in immagini diapositiva per diapositiva.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Converte la diapositiva in un'immagine.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Salva l'immagine nel formato JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQ**

**Aspose.Slides supporta il rendering delle diapositive con animazioni?**

No, il metodo `GetImage` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Basta assicurarsi che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici durante il salvataggio delle diapositive come immagini.