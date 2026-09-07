---
title: Convertire le presentazioni PowerPoint in PDF con note in Python
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire PPT
- convertire PPTX
- PowerPoint in PDF
- presentazione in PDF
- PPT in PDF
- PPTX in PDF
- salvare la presentazione come PDF
- esportare PPT in PDF
- esportare PPTX in PDF
- note del relatore
- PDF con note
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in PDF con note del relatore utilizzando Aspose.Slides per Python tramite Java. Configura la posizione delle note e preserva le note lunghe."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in PDF con note del relatore utilizzando Aspose.Slides per Python tramite Java. È possibile includere le note sotto ciascuna diapositiva e consentire alle note lunghe di continuare su pagine aggiuntive. Per altre impostazioni di esportazione PDF, vedere [Convert PowerPoint to PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).

## **Convertire PowerPoint in PDF con note**

Utilizzare il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) per esportare una presentazione PPT o PPTX in PDF. Per includere le note del relatore, creare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) e configurare il suo metodo [setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Assegnare questo layout a [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) usando [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Il seguente esempio carica `sample.pptx` ed esporta in `output.pdf` con le note del relatore sotto le diapositive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configura le opzioni PDF per la resa delle note del relatore.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Salva la presentazione in PDF con le note del relatore.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Puoi anche provare il [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/it/conversion).
{{% /alert %}}

## **Domande frequenti**

**Come posso impedire che le note lunghe del relatore vengano tagliate?**

Utilizzare [NotesPositions.BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomFull), come nell'esempio sopra. Questa impostazione visualizza le note complete, utilizzando pagine aggiuntive quando necessario.

**Posso mantenere ogni diapositiva e le sue note su una singola pagina?**

Utilizzare [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomTruncated). Questa impostazione limita le note a una pagina, quindi le note che non entrano potrebbero essere troncate.

**Come esportare le diapositive senza le note del relatore?**

Omettere la configurazione del layout delle note e utilizzare l'esportazione PDF standard descritta in [Convert PowerPoint to PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).