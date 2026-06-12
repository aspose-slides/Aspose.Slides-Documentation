---
title: Convertire le presentazioni PowerPoint in TIFF con note in Python
linktitle: PowerPoint in TIFF con note
type: docs
weight: 100
url: /it/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in TIFF
- presentazione in TIFF
- diapositiva in TIFF
- PPT in TIFF
- PPTX in TIFF
- PowerPoint con note
- presentazione con note
- diapositiva con note
- PPT con note
- PPTX con note
- TIFF con note
- Python
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in TIFF con note utilizzando Aspose.Slides per Python via .NET. Scopri come esportare le diapositive con note del relatore in modo efficiente."
---
## **Introduzione**

Aspose.Slides per Python via .NET offre una soluzione semplice per convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) con note nel formato TIFF. Questo formato è ampiamente utilizzato per l'archiviazione di immagini ad alta qualità, la stampa e la conservazione dei documenti. Con Aspose.Slides, è possibile non solo esportare intere presentazioni con note del relatore, ma anche generare miniature delle diapositive nella visualizzazione Note Slide. Il processo di conversione è semplice ed efficiente, utilizzando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per trasformare l'intera presentazione in una serie di immagini TIFF preservando note e layout.

## **Convertire una presentazione in TIFF con note**

Salvare una presentazione PowerPoint o OpenDocument in TIFF con note utilizzando Aspose.Slides per Python via .NET prevede i seguenti passaggi:

1. Instanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/): caricare un file PowerPoint o OpenDocument.  
1. Configurare le opzioni di layout di output: utilizzare la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) per specificare come devono essere visualizzate note e commenti.  
1. Salvare la presentazione in TIFF: passare le opzioni configurate al metodo [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

Supponiamo di avere un file "speaker_notes.pptx" con la seguente diapositiva:

![Diapositiva della presentazione con note del relatore](slide_with_notes.png)

Il frammento di codice qui sotto mostra come convertire la presentazione in un'immagine TIFF nella visualizzazione Note Slide utilizzando la proprietà [slides_layout_options](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/slides_layout_options/).

```py
# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Visualizza le note sotto la diapositiva.
    
    # Configura le opzioni TIFF con layout delle note.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Salva la presentazione in TIFF con le note del relatore.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Il risultato:

![Immagine TIFF con note del relatore](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Scopri il [Convertitore gratuito da PowerPoint a Poster](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online) di Aspose.
{{% /alert %}}

## **FAQ**

**Posso controllare la posizione dell'area delle note nel TIFF risultante?**

Sì. Utilizzare le [impostazioni di layout delle note](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) per scegliere tra opzioni come `NONE`, `BOTTOM_TRUNCATED` o `BOTTOM_FULL`, che rispettivamente nascondono le note, le adattano a una singola pagina o consentono loro di fluire su pagine aggiuntive.

**Come posso ridurre le dimensioni di un file TIFF con note senza una perdita visibile di qualità?**

Scegliere una [compressione efficiente](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/compression_type/) (ad esempio `LZW` o `RLE`), impostare una DPI adeguata e, se accettabile, utilizzare un [formato pixel](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/pixel_format/) inferiore (come 8 bpp o 1 bpp per il bianco‑nero). Ridurre leggermente le [dimensioni dell'immagine](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/image_size/) può inoltre aiutare senza compromettere significativamente la leggibilità.

**Il carattere delle note influisce sul risultato se i caratteri originali sono mancanti sul sistema?**

Sì. I caratteri mancanti attivano la [sostituzione](/slides/it/python-net/font-selection-sequence/), che può modificare metriche e aspetto del testo. Per evitare ciò, [fornire i caratteri richiesti](/slides/it/python-net/custom-font/) o impostare un [carattere di fallback predefinito](/slides/it/python-net/fallback-font/) in modo che vengano utilizzati i tipi di carattere desiderati.