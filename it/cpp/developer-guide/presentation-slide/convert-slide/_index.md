---
title: Converti le diapositive della presentazione in immagini in C++
linktitle: Diapositiva a immagine
type: docs
weight: 41
url: /it/cpp/convert-slide/
keywords:
- convertire diapositiva
- esportare diapositiva
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

Aspose.Slides for C++ ti permette di convertire facilmente le diapositive delle presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un’immagine, segui questi passaggi:

1. Definisci le impostazioni di conversione desiderate e seleziona le diapositive da esportare usando:
    - L’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/),
    - L’interfaccia [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/).
2. Genera l’immagine della diapositiva chiamando il metodo [GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/).

Un [Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/) è un oggetto che consente di lavorare con immagini definite da dati pixel. Puoi utilizzare un’istanza di questa classe per salvare le immagini in un’ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Converti le diapositive in Bitmap e salva le immagini in PNG**

Puoi convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella tua applicazione. In alternativa, puoi convertire una diapositiva in un bitmap e poi salvare l’immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice C++ dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l’immagine in formato PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Converti le diapositive in immagini con dimensioni personalizzate**

Potresti aver bisogno di ottenere un’immagine di una certa dimensione. Utilizzando una sovraccarico del metodo [GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/getimage/), puoi convertire una diapositiva in un’immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice mostra come fare:

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

## **Converti le diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due interfacce—[ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/) e [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/)—che consentono di controllare il rendering delle diapositive in immagini. Entrambe le interfacce includono il metodo `set_SlidesLayoutOptions`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) puoi specificare la posizione preferita per note e commenti nell’immagine risultante.

Questo codice C++ dimostra come convertire una diapositiva con note e commenti:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Imposta la posizione delle note.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Imposta la posizione dei commenti.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Imposta la larghezza dell'area commenti.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Imposta il colore dell'area commenti.

// Crea le opzioni di rendering.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Converti la prima diapositiva della presentazione in un'immagine.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Salva l'immagine nel formato GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Durante qualsiasi processo di conversione da diapositiva a immagine, il metodo [set_NotesPosition](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) non può applicare `BottomFull` (per specificare la posizione delle note) perché il testo di una nota potrebbe essere troppo grande, rendendo impossibile farlo rientrare nella dimensione dell’immagine specificata.

{{% /alert %}} 

## **Converti le diapositive in immagini usando le opzioni TIFF**

L’interfaccia [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/) offre un controllo maggiore sull’immagine TIFF risultante, permettendo di specificare parametri come dimensione, risoluzione, palette colori e altro.

Questo codice C++ dimostra un processo di conversione in cui le opzioni TIFF sono usate per generare un’immagine in bianco e nero con risoluzione di 300 DPI e dimensioni di 2160 × 2800:

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

// Converte la diapositiva in un'immagine con le opzioni specificate.
auto image = slide->GetImage(tiffOptions);

// Salva l'immagine in formato TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Converti tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando l’intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in C++:

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

    // Converti la diapositiva in un'immagine.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Salva l'immagine nel formato JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Rendering emoji a colori**

{{% alert title="Note" color="warning" %}} 
Per rendere correttamente gli emoji a colori quando si convertono le diapositive in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione usa **Segoe UI Emoji** e questo font è assente, gli emoji potrebbero apparire in bianco e nero nelle immagini generate.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No, il metodo `GetImage` salva solo un’immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate allo stesso modo di quelle regolari. Assicurati solo che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici quando si salvano le diapositive come immagini.