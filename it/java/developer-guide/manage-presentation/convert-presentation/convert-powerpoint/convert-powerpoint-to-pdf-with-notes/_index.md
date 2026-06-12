---
title: Converti le presentazioni PowerPoint in PDF con note in Java
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note utilizzando Aspose.Slides per Java. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai a convertire presentazioni PowerPoint in formato PDF con le note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a completare questo compito in modo efficiente. Alla fine di questo articolo sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF mantenendo le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

## **Converti PowerPoint in PDF con Note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in un PDF con le note del relatore. Con Aspose.Slides, basta caricare la presentazione, configurare le opzioni di layout utilizzando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/notescommentslayoutingoptions/) per includere le note del relatore, e quindi salvare il file come PDF. Il seguente frammento di codice dimostra come convertire una presentazione di esempio in un PDF nella visualizzazione Note delle diapositive.

```java
Presentation presentation = new Presentation("sample.pptx");

// Configura le opzioni PDF per il rendering delle note del relatore.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizza le note del relatore sotto la diapositiva.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Salva la presentazione in PDF con le note del relatore.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Potresti voler provare Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/it/conversion). 
{{% /alert %}}