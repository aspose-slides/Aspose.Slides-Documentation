---
title: Converti presentazioni PowerPoint in modalità Handout usando C++
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/cpp/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- dispensa
- PPT
- PPTX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Converti le presentazioni in dispense in C++. Imposta le diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides, con codice di esempio. Provalo gratis."
---
## **Introduzione**

Aspose.Slides fornisce la possibilità di convertire le presentazioni in vari formati, incluso la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, rendendola utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità chiamando il metodo `set_SlidesLayoutOptions` nelle interfacce [IPdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/).

Per impostare le dimensioni e l'orientamento della pagina di stampa prima dell'esportazione, vedere [Notes Page Size](/slides/it/cpp/notes-size/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handoutlayoutingoptions/), che determina quante diapositive vengono posizionate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Carica una presentazione.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Imposta le opzioni di esportazione.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 diapositive su una pagina orizzontalmente
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // stampa i numeri delle diapositive
slidesLayoutOptions->set_PrintFrameSlide(true);                      // stampa una cornice attorno alle diapositive
slidesLayoutOptions->set_PrintComments(false);                       // nessun commento

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Tieni presente che il metodo `set_SlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF, e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

### Qual è il numero massimo di miniature di diapositive per pagina in modalità Handout?

Aspose.Slides supporta [presets](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

### Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?

No. Il numero e l'ordinamento delle miniature sono controllati rigorosamente dall'enumerazione [HandoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handouttype/); layout arbitrari non sono supportati.

### Posso includere diapositive nascoste nell'output Handout?

Sì. Utilizzare il metodo `set_ShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, ad esempio [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/).