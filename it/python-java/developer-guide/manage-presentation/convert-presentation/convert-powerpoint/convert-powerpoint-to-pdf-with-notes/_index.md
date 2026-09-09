---
title: Converti le presentazioni PowerPoint in PDF con note in Python
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- converti PowerPoint
- converti presentazione
- converti PPT
- converti PPTX
- PowerPoint in PDF
- presentazione in PDF
- PPT in PDF
- PPTX in PDF
- salva presentazione come PDF
- esporta PPT in PDF
- esporta PPTX in PDF
- note del relatore
- PDF con note
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in PDF con le note del relatore utilizzando Aspose.Slides per Python tramite Java. Configura la posizione delle note e conserva le note lunghe."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in PDF con le note del relatore utilizzando Aspose.Slides per Python tramite Java. È possibile includere le note sotto ogni diapositiva e consentire alle note lunghe di continuare su pagine aggiuntive. Per altre impostazioni di esportazione PDF, vedere [Convert PowerPoint to PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).

## **Converti PowerPoint in PDF con Note**

Utilizzare il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) per esportare una presentazione PPT o PPTX in PDF. Per includere le note del relatore, creare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) e configurare la posizione delle note con il suo metodo [setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Assegnare questo layout a [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) usando [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

L'esempio seguente carica `sample.pptx` ed lo esporta in `output.pdf` con le note del relatore sotto le diapositive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configura le opzioni PDF per la visualizzazione delle note del relatore.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Salva la presentazione in PDF con le note del relatore.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Puoi anche provare il [Convertitore online PowerPoint in PDF](https://products.aspose.app/slides/it/conversion).
{{% /alert %}}

## **FAQ**

**Come posso impedire che le note del relatore lunghe vengano tagliate?**

Utilizzare [NotesPositions.BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomFull), come nell'esempio sopra. Questa impostazione visualizza le note complete, creando pagine aggiuntive se necessario.

**Posso mantenere ogni diapositiva e le relative note su una sola pagina?**

Utilizzare [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomTruncated). Questa impostazione limita le note a una pagina, quindi le note che non entrano possono essere troncate.

**Come esportare le diapositive senza note del relatore?**

Omettere la configurazione del layout delle note e utilizzare l'esportazione PDF standard descritta in [Convert PowerPoint to PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).