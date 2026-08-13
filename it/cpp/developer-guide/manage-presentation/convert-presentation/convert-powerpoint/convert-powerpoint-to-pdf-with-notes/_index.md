---
title: Converti le presentazioni PowerPoint in PDF con note in C++
linktitle: PowerPoint in PDF con note
type: docs
weight: 50
url: /it/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Converti i formati PPT e PPTX in PDF con note usando Aspose.Slides per C++. Conserva layout e note del relatore per presentazioni professionali."
---
## **Panoramica**

In questo articolo imparerai come convertire le presentazioni PowerPoint in formato PDF con le note del relatore utilizzando Aspose.Slides. Questa guida coprirà i passaggi necessari e fornirà esempi di codice per aiutarti a svolgere questa attività in modo efficiente. Alla fine di questo articolo, sarai in grado di:

- Implementare il processo di conversione per trasformare le diapositive PowerPoint in documenti PDF mantenendo le note del relatore.
- Personalizzare il PDF di output per garantire che le note del relatore siano incluse e formattate secondo le tue esigenze.

## **Converti PowerPoint in PDF con Note**

Il metodo `Save` nella classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) può essere utilizzato per convertire una presentazione PPT o PPTX in PDF con le note del relatore. Con Aspose.Slides, è sufficiente caricare la presentazione, configurare le opzioni di layout usando la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) per includere le note del relatore, e quindi salvare il file come PDF. Il frammento di codice seguente dimostra come convertire una presentazione di esempio in PDF nella visualizzazione diapositive con note.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configura le opzioni PDF per il rendering delle note del relatore.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderizza le note del relatore sotto la diapositiva.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salva la presentazione in PDF con le note del relatore.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Potresti voler provare Aspose [Convertitore online di PowerPoint in PDF](https://products.aspose.app/slides/it/conversion). 
{{% /alert %}}