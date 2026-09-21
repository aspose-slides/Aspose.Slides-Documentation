---
title: Convertire le presentazioni PowerPoint in modalità Handout usando JavaScript
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- convertire PowerPoint
- convertire presentazione
- modalità handout
- dispensa
- PPT
- PPTX
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni in dispense. Imposta il numero di diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides per Node.js, con codice di esempio. Provalo gratis."
---
## **Introduzione**

Aspose.Slides offre la possibilità di convertire presentazioni in vari formati, incluso la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, risultando utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità impostando il metodo `setSlidesLayoutOptions` nelle classi [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/).

Per impostare le dimensioni e l'orientamento della pagina della dispensa prima dell'esportazione, vedere [Notes Page Size](/slides/it/nodejs-java/notes-size/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handoutlayoutingoptions/) che determina quante diapositive vengono posizionate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Carica una presentazione.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
slidesLayoutOptions.setPrintSlideNumbers(true);                                // stampa i numeri delle diapositive
slidesLayoutOptions.setPrintFrameSlide(true);                                  // stampa una cornice attorno alle diapositive
slidesLayoutOptions.setPrintComments(false);                                   // nessun commento

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
Tenete presente che il metodo `setSlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF, e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina in modalità Handout?**

Aspose.Slides supporta [presets](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati rigorosamente dall'enumerazione [HandoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handouttype/); i layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Utilizzare il metodo `setShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, ad esempio [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/).