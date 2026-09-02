---
title: Convertire le diapositive PowerPoint in immagini con Python
linktitle: Diapositiva in immagine
type: docs
weight: 41
url: /it/python-net/convert-slide/
keywords:
- convertire diapositiva
- convertire diapositiva in immagine
- esportare diapositiva come immagine
- salvare diapositiva come immagine
- diapositiva a immagine
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- Python
- Aspose.Slides
description: "Scopri come convertire le diapositive PowerPoint e OpenDocument in vari formati utilizzando Aspose.Slides per Python tramite .NET. Esporta facilmente le diapositive PPTX e ODP in BMP, PNG, JPEG, TIFF e altri formati con risultati di alta qualità."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET consente di convertire facilmente le diapositive di presentazioni PowerPoint e OpenDocument in vari formati immagine, tra cui BMP, PNG, JPG (JPEG), GIF e altri.

Per convertire una diapositiva in un'immagine, seguire questi passaggi:

1. Definire le impostazioni di conversione desiderate e selezionare le diapositive da esportare utilizzando:
    - La classe [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/), oppure
    - La classe [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/).
2. Generare l'immagine della diapositiva chiamando il metodo `get_image` della classe [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/).

In Aspose.Slides per Python tramite .NET, [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) è una classe che consente di lavorare con immagini definite da dati pixel. È possibile utilizzare un'istanza di questa classe per salvare le immagini in un'ampia gamma di formati (BMP, JPG, PNG, ecc.).

## **Convertire le diapositive in Bitmap e salvare le immagini in PNG**

È possibile convertire una diapositiva in un oggetto bitmap e usarlo direttamente nella propria applicazione. In alternativa, è possibile convertire una diapositiva in un bitmap e poi salvare l'immagine in JPEG o in qualsiasi altro formato preferito.

Questo codice Python dimostra come convertire la prima diapositiva di una presentazione in un oggetto bitmap e poi salvare l'immagine in formato PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Converti la prima diapositiva della presentazione in una bitmap.
    with presentation.slides[0].get_image() as image:
        # Salva l'immagine nel formato PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Convertire le diapositive in immagini con dimensioni personalizzate**

Potrebbe essere necessario ottenere un'immagine di una certa dimensione. Utilizzando un overload del metodo [get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), è possibile convertire una diapositiva in un'immagine con dimensioni specifiche (larghezza e altezza).

Questo esempio di codice dimostra come fare:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Converte la prima diapositiva della presentazione in una bitmap con le dimensioni specificate.
    with presentation.slides[0].get_image(image_size) as image:
        # Salva l'immagine nel formato JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Convertire le diapositive con note e commenti in immagini**

Alcune diapositive possono contenere note e commenti.

Aspose.Slides fornisce due classi—[TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/) e [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/)—che consentono di controllare il rendering delle diapositive di presentazione in immagini. Entrambe le classi includono la proprietà `slides_layout_options`, che permette di configurare il rendering di note e commenti su una diapositiva durante la conversione in immagine.

Con la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) è possibile specificare la posizione preferita per note e commenti nell'immagine risultante.

Questo codice Python dimostra come convertire una diapositiva con note e commenti:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Imposta la posizione delle note.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Imposta la posizione dei commenti.
    notes_comments_options.comments_area_width = 500                                       # Imposta la larghezza dell'area dei commenti.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Imposta il colore per l'area dei commenti.

    # Crea le opzioni di rendering.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Converti la prima diapositiva della presentazione in un'immagine.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Salva l'immagine nel formato GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Nota" color="warning" %}} 

In qualsiasi processo di conversione da diapositiva a immagine, la proprietà [notes_position](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) non può essere impostata su `BOTTOM_FULL` (per specificare la posizione delle note) perché il testo di una nota può essere troppo grande, impedendo di adattarsi alla dimensione dell'immagine specificata.

{{% /alert %}} 

## **Convertire le diapositive in immagini utilizzando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/) offre un controllo maggiore sull'immagine TIFF risultante, consentendo di specificare parametri come dimensione, risoluzione, palette di colori e altro.

Questo codice Python dimostra un processo di conversione in cui le opzioni TIFF vengono utilizzate per produrre un'immagine in bianco e nero con risoluzione 300 DPI e dimensioni di 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Carica un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Ottieni la prima diapositiva dalla presentazione.
    slide = presentation.slides[0]

    # Configura le impostazioni dell'immagine TIFF di output.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Imposta la dimensione dell'immagine.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Imposta il formato pixel (bianco e nero).
    options.dpi_x = 300                                                        # Imposta la risoluzione orizzontale.
    options.dpi_y = 300                                                        # Imposta la risoluzione verticale.

    # Converte la diapositiva in un'immagine con le opzioni specificate.
    with slide.get_image(options) as image:
        # Salva l'immagine nel formato TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Convertire tutte le diapositive in immagini**

Aspose.Slides consente di convertire tutte le diapositive di una presentazione in immagini, trasformando l'intera presentazione in una serie di immagini.

Questo esempio di codice dimostra come convertire tutte le diapositive di una presentazione in immagini in Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Renderizza la presentazione in immagini diapositiva per diapositiva.
    for i, slide in enumerate(presentation.slides):
        # Controlla le diapositive nascoste (non renderizzare le diapositive nascoste).
        if slide.hidden:
            continue

        # Converte la diapositiva in un'immagine.
        with slide.get_image(scale_x, scale_y) as image:
            # Salva l'immagine nel formato JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **Rendering di Emoji a colori**

{{% alert title="Nota" color="warning" %}} 
Per rendere correttamente le emoji a colori durante la conversione delle diapositive di presentazione in immagini, i font emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font è assente, le emoji potrebbero apparire in bianco e nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering delle diapositive con animazioni?**

No, il metodo `get_image` salva solo un'immagine statica della diapositiva, senza animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì, le diapositive nascoste possono essere elaborate come quelle normali. Assicurati solo che siano incluse nel ciclo di elaborazione.

**Le immagini possono essere salvate con ombre ed effetti?**

Sì, Aspose.Slides supporta il rendering di ombre, trasparenza e altri effetti grafici durante il salvataggio delle diapositive come immagini.