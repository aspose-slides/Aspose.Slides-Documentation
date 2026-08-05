---
title: Converti le presentazioni PowerPoint in modalità Handout con JavaScript
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
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

Aspose.Slides offre la possibilità di convertire presentazioni in vari formati, incluso creare dispense per la stampa in modalità Handout. Questa modalità consente di configurare il modo in cui più diapositive appaiono su una singola pagina, risultando utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità impostando il metodo `setSlidesLayoutOptions` nelle classi [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handoutlayoutingoptions/), che determina quante diapositive vengono collocate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```js
// Carica una presentazione.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Imposta le opzioni di esportazione.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
slidesLayoutOptions.setPrintSlideNumbers(true);                                // stampa i numeri delle diapositive
slidesLayoutOptions.setPrintFrameSlide(true);                                  // stampa un riquadro intorno alle diapositive
slidesLayoutOptions.setPrintComments(false);                                   // nessun commento

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Esporta la presentazione in PDF con il layout scelto.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Tieni presente che il metodo `setSlidesLayoutOptions` è disponibile solo per determinati formati di output, come PDF, HTML, TIFF e quando si rende come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature diapositive per pagina nella modalità Handout?**

Aspose.Slides supporta [presets](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati rigorosamente dall'enumerazione [HandoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/handouttype/); layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Usa il metodo `setShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, come [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tiffoptions/).