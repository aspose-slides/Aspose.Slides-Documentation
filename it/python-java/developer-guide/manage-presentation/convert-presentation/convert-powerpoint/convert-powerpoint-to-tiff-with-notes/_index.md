---
title: Convertire presentazioni PowerPoint in TIFF con note in Python
linktitle: PowerPoint in TIFF con note
type: docs
weight: 100
url: /it/python-java/convert-powerpoint-to-tiff-with-notes/
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
- salvare PPT come TIFF
- salvare PPTX come TIFF
- esportare PPT in TIFF
- esportare PPTX in TIFF
- PowerPoint con note
- presentazione con note
- diapositiva con note
- PPT con note
- PPTX con note
- TIFF con note
- Python
- Java
- Aspose.Slides
description: Converti le presentazioni PowerPoint in TIFF con note utilizzando Aspose.Slides per Python tramite Java. Scopri come esportare le diapositive con note del relatore in modo efficiente.
---
## **Introduzione**

Aspose.Slides for Python via Java offre una soluzione semplice per convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) con note nel formato TIFF. Questo formato è ampiamente utilizzato per l'archiviazione di immagini ad alta qualità, la stampa e la conservazione di documenti. Utilizza il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) per esportare le diapositive e le loro note del relatore in un unico file TIFF multipagina.

## **Convertire una presentazione in TIFF con note**

Salvare una presentazione PowerPoint o OpenDocument in TIFF con note utilizzando Aspose.Slides for Python via Java comporta i seguenti passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/): caricare un file PowerPoint o OpenDocument.  
1. Configurare le opzioni di layout di output: utilizzare la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) per specificare come devono essere visualizzate note e commenti.  
1. Salvare la presentazione in TIFF: passare le opzioni configurate al metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save).

Supponiamo di avere un file "speaker_notes.pptx" con la seguente diapositiva:

![La diapositiva della presentazione con note del relatore](slide_with_notes.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Visualizza le note del relatore complete sotto ogni diapositiva.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Configura la risoluzione TIFF e il layout delle note.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Salva la presentazione in TIFF con le note del relatore.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Il risultato:

![L'immagine TIFF con note del relatore](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Scopri Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso controllare la posizione dell'area delle note nel TIFF risultante?**

Sì. Configura [setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) con [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomTruncated) per far rientrare le note in una pagina, eventualmente troncandole, oppure con [NotesPositions.BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomFull) per visualizzare tutte le note usando pagine aggiuntive se necessario. Per esportare le diapositive senza note, ometti la configurazione del layout delle note come mostrato in [Convert PowerPoint to TIFF](/slides/it/python-java/convert-powerpoint-to-tiff/).

**Come posso ridurre le dimensioni di un file TIFF con note senza perdere la qualità dell'immagine?**

Utilizza la compressione lossless [LZW compression](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffcompressiontypes/#LZW) tramite [setCompressionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setCompressionType). Ridurre la risoluzione o la profondità di colore può ulteriormente diminuire le dimensioni del file, ma potrebbe influire sulla qualità dell'immagine e sulla leggibilità delle note. Consulta le [TIFF export settings](/slides/it/python-java/convert-powerpoint-to-tiff/) per ulteriori opzioni.

**Il carattere nelle note influisce sul risultato se i caratteri originali mancano sul sistema?**

Sì. I caratteri mancanti attivano la [font substitution](/slides/it/python-java/font-selection-sequence/), che può modificare metriche e aspetto del testo. [Supply the required fonts](/slides/it/python-java/custom-font/) per mantenere i tipi di carattere previsti.