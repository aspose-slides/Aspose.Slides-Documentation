---
title: Converti le presentazioni PowerPoint in PDF con note in PHP
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note usando Aspose.Slides per PHP via Java. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai a convertire le presentazioni PowerPoint in formato PDF con note del relatore usando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a completare questa attività in modo efficiente. Alla fine di questo articolo, sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF preservando le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

Per impostare le dimensioni e l'orientamento della pagina delle note prima dell'esportazione, consulta [Notes Page Size](/slides/it/php-java/notes-size/).

## **Converti PowerPoint in PDF con Note**

Il metodo `save` nella classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) può essere usato per convertire una presentazione PPT o PPTX in PDF con note del relatore. Con Aspose.Slides, basta caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/notescommentslayoutingoptions/) per includere le note del relatore, e poi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in PDF nella vista Note delle diapositive.

```php
$presentation = new Presentation("sample.pptx");

// Configura le opzioni PDF per il rendering delle note del relatore.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderizza le note del relatore sotto la diapositiva.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Salva la presentazione in PDF con le note del relatore.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}

Potresti voler provare il Convertitore online PowerPoint in PDF di Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/it/conversion).

{{% /alert %}}