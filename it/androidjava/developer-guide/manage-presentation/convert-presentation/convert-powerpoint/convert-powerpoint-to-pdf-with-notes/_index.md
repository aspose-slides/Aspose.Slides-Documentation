---
title: Converti presentazioni PowerPoint in PDF con note su Android
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note utilizzando Aspose.Slides per Android tramite Java. Conserva i layout e le note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai come convertire le presentazioni PowerPoint in formato PDF con le note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a svolgere questa attività in modo efficiente. Alla fine di questo articolo sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF preservando le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

## **Converti PowerPoint in PDF con Note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in PDF con le note del relatore. Con Aspose.Slides, devi semplicemente caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/notescommentslayoutingoptions/) per includere le note del relatore, e quindi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in PDF nella visualizzazione Note diapositive.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Configura le opzioni PDF per la renderizzazione delle note del relatore.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizza le note del relatore sotto la diapositiva.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Salva la presentazione in PDF con le note del relatore.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Potresti voler dare un'occhiata al Convertitore online PowerPoint in PDF di Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/it/conversion). 
{{% /alert %}}