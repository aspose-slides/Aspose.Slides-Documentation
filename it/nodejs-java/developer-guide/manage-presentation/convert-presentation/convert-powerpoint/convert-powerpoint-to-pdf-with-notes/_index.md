---
title: Converti le presentazioni PowerPoint in PDF con note in JavaScript
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PDF
- presentazione in PDF
- diapositiva in PDF
- PPT in PDF
- PPTX in PDF
- salva presentazione come PDF
- salva PPT come PDF
- salva PPTX come PDF
- esporta PPT in PDF
- esporta PPTX in PDF
- note del relatore
- PDF con note
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note in JavaScript utilizzando Aspose.Slides per Node.js. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai come convertire le presentazioni PowerPoint in formato PDF con note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a completare questa attività in modo efficiente. Alla fine dell'articolo sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF mantenendo le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

Per impostare le dimensioni e l'orientamento della pagina delle note prima dell'esportazione, vedi [Dimensione pagina note](/slides/it/nodejs-java/notes-size/).

## **Converti PowerPoint in PDF con Note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in PDF con le note del relatore. Con Aspose.Slides, devi semplicemente caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notescommentslayoutingoptions/) per includere le note del relatore, quindi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in PDF nella visualizzazione diapositiva note.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Configura le opzioni PDF per il rendering delle note del relatore.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderizza le note del relatore sotto la diapositiva.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}

Potresti voler provare il Convertitore online PowerPoint in PDF di Aspose [Convertitore online PowerPoint in PDF](https://products.aspose.app/slides/it/conversion).

{{% /alert %}}